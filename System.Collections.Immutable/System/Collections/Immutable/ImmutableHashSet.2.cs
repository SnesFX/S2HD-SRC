using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x02000023 RID: 35
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableHashSet<T> : IImmutableSet<T>, IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, IHashKeyCollection<T>, ICollection<!0>, ISet<T>, ICollection, IStrongEnumerable<T, ImmutableHashSet<T>.Enumerator>
	{
		// Token: 0x06000196 RID: 406 RVA: 0x000053E1 File Offset: 0x000035E1
		internal ImmutableHashSet(IEqualityComparer<T> equalityComparer) : this(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, equalityComparer, 0)
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000053F0 File Offset: 0x000035F0
		private ImmutableHashSet(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			root.Freeze(ImmutableHashSet<T>.s_FreezeBucketAction);
			this._root = root;
			this._count = count;
			this._equalityComparer = equalityComparer;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000542E File Offset: 0x0000362E
		public ImmutableHashSet<T> Clear()
		{
			if (!this.IsEmpty)
			{
				return ImmutableHashSet<T>.Empty.WithComparer(this._equalityComparer);
			}
			return this;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000544A File Offset: 0x0000364A
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00005452 File Offset: 0x00003652
		public bool IsEmpty
		{
			get
			{
				return this.Count == 0;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000545D File Offset: 0x0000365D
		public IEqualityComparer<T> KeyComparer
		{
			get
			{
				return this._equalityComparer;
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00005465 File Offset: 0x00003665
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0000546D File Offset: 0x0000366D
		internal IBinaryTree Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00005475 File Offset: 0x00003675
		private ImmutableHashSet<T>.MutationInput Origin
		{
			get
			{
				return new ImmutableHashSet<T>.MutationInput(this);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000547D File Offset: 0x0000367D
		public ImmutableHashSet<T>.Builder ToBuilder()
		{
			return new ImmutableHashSet<T>.Builder(this);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00005488 File Offset: 0x00003688
		public ImmutableHashSet<T> Add(T item)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			return ImmutableHashSet<T>.Add(item, this.Origin).Finalize(this);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000054B8 File Offset: 0x000036B8
		public ImmutableHashSet<T> Remove(T item)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			return ImmutableHashSet<T>.Remove(item, this.Origin).Finalize(this);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000054E8 File Offset: 0x000036E8
		public bool TryGetValue(T equalValue, out T actualValue)
		{
			Requires.NotNullAllowStructs<T>(equalValue, "equalValue");
			int hashCode = this._equalityComparer.GetHashCode(equalValue);
			ImmutableHashSet<T>.HashBucket hashBucket;
			if (this._root.TryGetValue(hashCode, out hashBucket))
			{
				return hashBucket.TryExchange(equalValue, this._equalityComparer, out actualValue);
			}
			actualValue = equalValue;
			return false;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00005535 File Offset: 0x00003735
		public ImmutableHashSet<T> Union(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return this.Union(other, false);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000554C File Offset: 0x0000374C
		public ImmutableHashSet<T> Intersect(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Intersect(other, this.Origin).Finalize(this);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000557C File Offset: 0x0000377C
		public ImmutableHashSet<T> Except(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Except(other, this._equalityComparer, this._root).Finalize(this);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000055B0 File Offset: 0x000037B0
		public ImmutableHashSet<T> SymmetricExcept(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.SymmetricExcept(other, this.Origin).Finalize(this);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000055DD File Offset: 0x000037DD
		public bool SetEquals(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return this == other || ImmutableHashSet<T>.SetEquals(other, this.Origin);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000055FC File Offset: 0x000037FC
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsProperSubsetOf(other, this.Origin);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00005615 File Offset: 0x00003815
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsProperSupersetOf(other, this.Origin);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000562E File Offset: 0x0000382E
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsSubsetOf(other, this.Origin);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005647 File Offset: 0x00003847
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.IsSupersetOf(other, this.Origin);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00005660 File Offset: 0x00003860
		public bool Overlaps(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			return ImmutableHashSet<T>.Overlaps(other, this.Origin);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00005679 File Offset: 0x00003879
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Add(T item)
		{
			return this.Add(item);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00005682 File Offset: 0x00003882
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Remove(T item)
		{
			return this.Remove(item);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000568B File Offset: 0x0000388B
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Union(IEnumerable<T> other)
		{
			return this.Union(other);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00005694 File Offset: 0x00003894
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Intersect(IEnumerable<T> other)
		{
			return this.Intersect(other);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000569D File Offset: 0x0000389D
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Except(IEnumerable<T> other)
		{
			return this.Except(other);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000056A6 File Offset: 0x000038A6
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.SymmetricExcept(IEnumerable<T> other)
		{
			return this.SymmetricExcept(other);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000056AF File Offset: 0x000038AF
		public bool Contains(T item)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			return ImmutableHashSet<T>.Contains(item, this.Origin);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000056C8 File Offset: 0x000038C8
		public ImmutableHashSet<T> WithComparer(IEqualityComparer<T> equalityComparer)
		{
			if (equalityComparer == null)
			{
				equalityComparer = EqualityComparer<T>.Default;
			}
			if (equalityComparer == this._equalityComparer)
			{
				return this;
			}
			ImmutableHashSet<T> immutableHashSet = new ImmutableHashSet<T>(equalityComparer);
			return immutableHashSet.Union(this, true);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000317B File Offset: 0x0000137B
		bool ISet<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.ExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.IntersectWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.SymmetricExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.UnionWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00003182 File Offset: 0x00001382
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000056FC File Offset: 0x000038FC
		void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
		{
			Requires.NotNull<T[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (T t in this)
			{
				array[arrayIndex++] = t;
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005788 File Offset: 0x00003988
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			Requires.NotNull<Array>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (T t in this)
			{
				array.SetValue(t, new int[]
				{
					arrayIndex++
				});
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00005828 File Offset: 0x00003A28
		public ImmutableHashSet<T>.Enumerator GetEnumerator()
		{
			return new ImmutableHashSet<T>.Enumerator(this._root, null);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00005836 File Offset: 0x00003A36
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00005836 File Offset: 0x00003A36
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00005844 File Offset: 0x00003A44
		private static bool IsSupersetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000058B0 File Offset: 0x00003AB0
		private static ImmutableHashSet<T>.MutationResult Add(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			int hashCode = origin.EqualityComparer.GetHashCode(item);
			ImmutableHashSet<T>.OperationResult operationResult;
			ImmutableHashSet<T>.HashBucket newBucket = origin.Root.GetValueOrDefault(hashCode).Add(item, origin.EqualityComparer, out operationResult);
			if (operationResult == ImmutableHashSet<T>.OperationResult.NoChangeRequired)
			{
				return new ImmutableHashSet<T>.MutationResult(origin.Root, 0, ImmutableHashSet<T>.CountType.Adjustment);
			}
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = ImmutableHashSet<T>.UpdateRoot(origin.Root, hashCode, newBucket);
			return new ImmutableHashSet<T>.MutationResult(root, 1, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00005924 File Offset: 0x00003B24
		private static ImmutableHashSet<T>.MutationResult Remove(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			ImmutableHashSet<T>.OperationResult operationResult = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
			int hashCode = origin.EqualityComparer.GetHashCode(item);
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = origin.Root;
			ImmutableHashSet<T>.HashBucket hashBucket;
			if (origin.Root.TryGetValue(hashCode, out hashBucket))
			{
				ImmutableHashSet<T>.HashBucket newBucket = hashBucket.Remove(item, origin.EqualityComparer, out operationResult);
				if (operationResult == ImmutableHashSet<T>.OperationResult.NoChangeRequired)
				{
					return new ImmutableHashSet<T>.MutationResult(origin.Root, 0, ImmutableHashSet<T>.CountType.Adjustment);
				}
				root = ImmutableHashSet<T>.UpdateRoot(origin.Root, hashCode, newBucket);
			}
			return new ImmutableHashSet<T>.MutationResult(root, (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged) ? -1 : 0, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000059AC File Offset: 0x00003BAC
		private static bool Contains(T item, ImmutableHashSet<T>.MutationInput origin)
		{
			int hashCode = origin.EqualityComparer.GetHashCode(item);
			ImmutableHashSet<T>.HashBucket hashBucket;
			return origin.Root.TryGetValue(hashCode, out hashBucket) && hashBucket.Contains(item, origin.EqualityComparer);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000059EC File Offset: 0x00003BEC
		private static ImmutableHashSet<T>.MutationResult Union(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> sortedInt32KeyNode = origin.Root;
			foreach (T t in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				int hashCode = origin.EqualityComparer.GetHashCode(t);
				ImmutableHashSet<T>.OperationResult operationResult;
				ImmutableHashSet<T>.HashBucket newBucket = sortedInt32KeyNode.GetValueOrDefault(hashCode).Add(t, origin.EqualityComparer, out operationResult);
				if (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged)
				{
					sortedInt32KeyNode = ImmutableHashSet<T>.UpdateRoot(sortedInt32KeyNode, hashCode, newBucket);
					num++;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(sortedInt32KeyNode, num, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00005A9C File Offset: 0x00003C9C
		private static bool Overlaps(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return false;
			}
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005B18 File Offset: 0x00003D18
		private static bool SetEquals(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			if (origin.Count != hashSet.Count)
			{
				return false;
			}
			int num = 0;
			foreach (T item in hashSet)
			{
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
				num++;
			}
			return num == origin.Count;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00005BAC File Offset: 0x00003DAC
		private static SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> UpdateRoot(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int hashCode, ImmutableHashSet<T>.HashBucket newBucket)
		{
			bool flag;
			if (newBucket.IsEmpty)
			{
				return root.Remove(hashCode, out flag);
			}
			bool flag2;
			return root.SetItem(hashCode, newBucket, EqualityComparer<ImmutableHashSet<T>.HashBucket>.Default, out flag2, out flag);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00005BE0 File Offset: 0x00003DE0
		private static ImmutableHashSet<T>.MutationResult Intersect(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			int num = 0;
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Add(item, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, num));
					root = mutationResult.Root;
					num += mutationResult.Count;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(root, num, ImmutableHashSet<T>.CountType.FinalValue);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00005C80 File Offset: 0x00003E80
		private static ImmutableHashSet<T>.MutationResult Except(IEnumerable<T> other, IEqualityComparer<T> equalityComparer, SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> sortedInt32KeyNode = root;
			foreach (T t in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				int hashCode = equalityComparer.GetHashCode(t);
				ImmutableHashSet<T>.HashBucket hashBucket;
				if (sortedInt32KeyNode.TryGetValue(hashCode, out hashBucket))
				{
					ImmutableHashSet<T>.OperationResult operationResult;
					ImmutableHashSet<T>.HashBucket newBucket = hashBucket.Remove(t, equalityComparer, out operationResult);
					if (operationResult == ImmutableHashSet<T>.OperationResult.SizeChanged)
					{
						num--;
						sortedInt32KeyNode = ImmutableHashSet<T>.UpdateRoot(sortedInt32KeyNode, hashCode, newBucket);
					}
				}
			}
			return new ImmutableHashSet<T>.MutationResult(sortedInt32KeyNode, num, ImmutableHashSet<T>.CountType.Adjustment);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00005D34 File Offset: 0x00003F34
		private static ImmutableHashSet<T>.MutationResult SymmetricExcept(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableHashSet<T> immutableHashSet = ImmutableHashSet.CreateRange<T>(origin.EqualityComparer, other);
			int num = 0;
			SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			foreach (T item in new ImmutableHashSet<T>.NodeEnumerable(origin.Root))
			{
				if (!immutableHashSet.Contains(item))
				{
					ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Add(item, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, num));
					root = mutationResult.Root;
					num += mutationResult.Count;
				}
			}
			foreach (T item2 in immutableHashSet)
			{
				if (!ImmutableHashSet<T>.Contains(item2, origin))
				{
					ImmutableHashSet<T>.MutationResult mutationResult2 = ImmutableHashSet<T>.Add(item2, new ImmutableHashSet<T>.MutationInput(root, origin.EqualityComparer, num));
					root = mutationResult2.Root;
					num += mutationResult2.Count;
				}
			}
			return new ImmutableHashSet<T>.MutationResult(root, num, ImmutableHashSet<T>.CountType.FinalValue);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00005E54 File Offset: 0x00004054
		private static bool IsProperSubsetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return other.Any<T>();
			}
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			if (origin.Count >= hashSet.Count)
			{
				return false;
			}
			int num = 0;
			bool flag = false;
			foreach (T item in hashSet)
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					num++;
				}
				else
				{
					flag = true;
				}
				if (num == origin.Count && flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00005F08 File Offset: 0x00004108
		private static bool IsProperSupersetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return false;
			}
			int num = 0;
			foreach (T item in other.GetEnumerableDisposable<T, ImmutableHashSet<T>.Enumerator>())
			{
				num++;
				if (!ImmutableHashSet<T>.Contains(item, origin))
				{
					return false;
				}
			}
			return origin.Count > num;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00005F94 File Offset: 0x00004194
		private static bool IsSubsetOf(IEnumerable<T> other, ImmutableHashSet<T>.MutationInput origin)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (origin.Root.IsEmpty)
			{
				return true;
			}
			HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
			int num = 0;
			foreach (T item in hashSet)
			{
				if (ImmutableHashSet<T>.Contains(item, origin))
				{
					num++;
				}
			}
			return num == origin.Count;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00006020 File Offset: 0x00004220
		private static ImmutableHashSet<T> Wrap(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
			Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
			Requires.Range(count >= 0, "count", null);
			return new ImmutableHashSet<T>(root, equalityComparer, count);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00006052 File Offset: 0x00004252
		private ImmutableHashSet<T> Wrap(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int adjustedCountIfDifferentRoot)
		{
			if (root == this._root)
			{
				return this;
			}
			return new ImmutableHashSet<T>(root, this._equalityComparer, adjustedCountIfDifferentRoot);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000606C File Offset: 0x0000426C
		private ImmutableHashSet<T> Union(IEnumerable<T> items, bool avoidWithComparer)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty && !avoidWithComparer)
			{
				ImmutableHashSet<T> immutableHashSet = items as ImmutableHashSet<T>;
				if (immutableHashSet != null)
				{
					return immutableHashSet.WithComparer(this.KeyComparer);
				}
			}
			return ImmutableHashSet<T>.Union(items, this.Origin).Finalize(this);
		}

		// Token: 0x04000016 RID: 22
		public static readonly ImmutableHashSet<T> Empty = new ImmutableHashSet<T>(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, EqualityComparer<T>.Default, 0);

		// Token: 0x04000017 RID: 23
		private static readonly Action<KeyValuePair<int, ImmutableHashSet<T>.HashBucket>> s_FreezeBucketAction = delegate(KeyValuePair<int, ImmutableHashSet<T>.HashBucket> kv)
		{
			kv.Value.Freeze();
		};

		// Token: 0x04000018 RID: 24
		private readonly IEqualityComparer<T> _equalityComparer;

		// Token: 0x04000019 RID: 25
		private readonly int _count;

		// Token: 0x0400001A RID: 26
		private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

		// Token: 0x02000054 RID: 84
		[DebuggerDisplay("Count = {Count}")]
		public sealed class Builder : IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, ISet<!0>, ICollection<!0>
		{
			// Token: 0x06000445 RID: 1093 RVA: 0x0000B3F4 File Offset: 0x000095F4
			internal Builder(ImmutableHashSet<T> set)
			{
				Requires.NotNull<ImmutableHashSet<T>>(set, "set");
				this._root = set._root;
				this._count = set._count;
				this._equalityComparer = set._equalityComparer;
				this._immutable = set;
			}

			// Token: 0x170000CE RID: 206
			// (get) Token: 0x06000446 RID: 1094 RVA: 0x0000B448 File Offset: 0x00009648
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000B450 File Offset: 0x00009650
			// (set) Token: 0x06000449 RID: 1097 RVA: 0x0000B458 File Offset: 0x00009658
			public IEqualityComparer<T> KeyComparer
			{
				get
				{
					return this._equalityComparer;
				}
				set
				{
					Requires.NotNull<IEqualityComparer<T>>(value, "value");
					if (value != this._equalityComparer)
					{
						ImmutableHashSet<T>.MutationResult mutationResult = ImmutableHashSet<T>.Union(this, new ImmutableHashSet<T>.MutationInput(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode, value, 0));
						this._immutable = null;
						this._equalityComparer = value;
						this.Root = mutationResult.Root;
						this._count = mutationResult.Count;
					}
				}
			}

			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x0600044A RID: 1098 RVA: 0x0000B4B4 File Offset: 0x000096B4
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000B4BC File Offset: 0x000096BC
			private ImmutableHashSet<T>.MutationInput Origin
			{
				get
				{
					return new ImmutableHashSet<T>.MutationInput(this.Root, this._equalityComparer, this._count);
				}
			}

			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x0600044C RID: 1100 RVA: 0x0000B4D5 File Offset: 0x000096D5
			// (set) Token: 0x0600044D RID: 1101 RVA: 0x0000B4DD File Offset: 0x000096DD
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
				set
				{
					this._version++;
					if (this._root != value)
					{
						this._root = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x0600044E RID: 1102 RVA: 0x0000B504 File Offset: 0x00009704
			public ImmutableHashSet<T>.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.Enumerator(this._root, this);
			}

			// Token: 0x0600044F RID: 1103 RVA: 0x0000B512 File Offset: 0x00009712
			public ImmutableHashSet<T> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableHashSet<T>.Wrap(this._root, this._equalityComparer, this._count);
				}
				return this._immutable;
			}

			// Token: 0x06000450 RID: 1104 RVA: 0x0000B540 File Offset: 0x00009740
			public bool Add(T item)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Add(item, this.Origin);
				this.Apply(result);
				return result.Count != 0;
			}

			// Token: 0x06000451 RID: 1105 RVA: 0x0000B56C File Offset: 0x0000976C
			public bool Remove(T item)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Remove(item, this.Origin);
				this.Apply(result);
				return result.Count != 0;
			}

			// Token: 0x06000452 RID: 1106 RVA: 0x0000B597 File Offset: 0x00009797
			public bool Contains(T item)
			{
				return ImmutableHashSet<T>.Contains(item, this.Origin);
			}

			// Token: 0x06000453 RID: 1107 RVA: 0x0000B5A5 File Offset: 0x000097A5
			public void Clear()
			{
				this._count = 0;
				this.Root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;
			}

			// Token: 0x06000454 RID: 1108 RVA: 0x0000B5BC File Offset: 0x000097BC
			public void ExceptWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Except(other, this._equalityComparer, this._root);
				this.Apply(result);
			}

			// Token: 0x06000455 RID: 1109 RVA: 0x0000B5E4 File Offset: 0x000097E4
			public void IntersectWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Intersect(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x06000456 RID: 1110 RVA: 0x0000B605 File Offset: 0x00009805
			public bool IsProperSubsetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsProperSubsetOf(other, this.Origin);
			}

			// Token: 0x06000457 RID: 1111 RVA: 0x0000B613 File Offset: 0x00009813
			public bool IsProperSupersetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsProperSupersetOf(other, this.Origin);
			}

			// Token: 0x06000458 RID: 1112 RVA: 0x0000B621 File Offset: 0x00009821
			public bool IsSubsetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsSubsetOf(other, this.Origin);
			}

			// Token: 0x06000459 RID: 1113 RVA: 0x0000B62F File Offset: 0x0000982F
			public bool IsSupersetOf(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.IsSupersetOf(other, this.Origin);
			}

			// Token: 0x0600045A RID: 1114 RVA: 0x0000B63D File Offset: 0x0000983D
			public bool Overlaps(IEnumerable<T> other)
			{
				return ImmutableHashSet<T>.Overlaps(other, this.Origin);
			}

			// Token: 0x0600045B RID: 1115 RVA: 0x0000B64B File Offset: 0x0000984B
			public bool SetEquals(IEnumerable<T> other)
			{
				return this == other || ImmutableHashSet<T>.SetEquals(other, this.Origin);
			}

			// Token: 0x0600045C RID: 1116 RVA: 0x0000B660 File Offset: 0x00009860
			public void SymmetricExceptWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.SymmetricExcept(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x0600045D RID: 1117 RVA: 0x0000B684 File Offset: 0x00009884
			public void UnionWith(IEnumerable<T> other)
			{
				ImmutableHashSet<T>.MutationResult result = ImmutableHashSet<T>.Union(other, this.Origin);
				this.Apply(result);
			}

			// Token: 0x0600045E RID: 1118 RVA: 0x0000B6A5 File Offset: 0x000098A5
			void ICollection<!0>.Add(T item)
			{
				this.Add(item);
			}

			// Token: 0x0600045F RID: 1119 RVA: 0x0000B6B0 File Offset: 0x000098B0
			void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (T t in this)
				{
					array[arrayIndex++] = t;
				}
			}

			// Token: 0x06000460 RID: 1120 RVA: 0x0000B73C File Offset: 0x0000993C
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000461 RID: 1121 RVA: 0x0000B73C File Offset: 0x0000993C
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000462 RID: 1122 RVA: 0x0000B749 File Offset: 0x00009949
			private void Apply(ImmutableHashSet<T>.MutationResult result)
			{
				this.Root = result.Root;
				if (result.CountType == ImmutableHashSet<T>.CountType.Adjustment)
				{
					this._count += result.Count;
					return;
				}
				this._count = result.Count;
			}

			// Token: 0x0400008A RID: 138
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root = SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.EmptyNode;

			// Token: 0x0400008B RID: 139
			private IEqualityComparer<T> _equalityComparer;

			// Token: 0x0400008C RID: 140
			private int _count;

			// Token: 0x0400008D RID: 141
			private ImmutableHashSet<T> _immutable;

			// Token: 0x0400008E RID: 142
			private int _version;
		}

		// Token: 0x02000055 RID: 85
		public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable, IStrongEnumerator<T>
		{
			// Token: 0x06000463 RID: 1123 RVA: 0x0000B783 File Offset: 0x00009983
			internal Enumerator(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, ImmutableHashSet<T>.Builder builder = null)
			{
				this._builder = builder;
				this._mapEnumerator = new SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.Enumerator(root);
				this._bucketEnumerator = default(ImmutableHashSet<T>.HashBucket.Enumerator);
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
			}

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x06000464 RID: 1124 RVA: 0x0000B7B6 File Offset: 0x000099B6
			public T Current
			{
				get
				{
					this._mapEnumerator.ThrowIfDisposed();
					return this._bucketEnumerator.Current;
				}
			}

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000B7CE File Offset: 0x000099CE
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000466 RID: 1126 RVA: 0x0000B7DC File Offset: 0x000099DC
			public bool MoveNext()
			{
				this.ThrowIfChanged();
				if (this._bucketEnumerator.MoveNext())
				{
					return true;
				}
				if (this._mapEnumerator.MoveNext())
				{
					KeyValuePair<int, ImmutableHashSet<T>.HashBucket> keyValuePair = this._mapEnumerator.Current;
					this._bucketEnumerator = new ImmutableHashSet<T>.HashBucket.Enumerator(keyValuePair.Value);
					return this._bucketEnumerator.MoveNext();
				}
				return false;
			}

			// Token: 0x06000467 RID: 1127 RVA: 0x0000B836 File Offset: 0x00009A36
			public void Reset()
			{
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._mapEnumerator.Reset();
				this._bucketEnumerator.Dispose();
				this._bucketEnumerator = default(ImmutableHashSet<T>.HashBucket.Enumerator);
			}

			// Token: 0x06000468 RID: 1128 RVA: 0x0000B876 File Offset: 0x00009A76
			public void Dispose()
			{
				this._mapEnumerator.Dispose();
				this._bucketEnumerator.Dispose();
			}

			// Token: 0x06000469 RID: 1129 RVA: 0x0000B88E File Offset: 0x00009A8E
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x0400008F RID: 143
			private readonly ImmutableHashSet<T>.Builder _builder;

			// Token: 0x04000090 RID: 144
			private SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>.Enumerator _mapEnumerator;

			// Token: 0x04000091 RID: 145
			private ImmutableHashSet<T>.HashBucket.Enumerator _bucketEnumerator;

			// Token: 0x04000092 RID: 146
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x02000056 RID: 86
		internal enum OperationResult
		{
			// Token: 0x04000094 RID: 148
			SizeChanged,
			// Token: 0x04000095 RID: 149
			NoChangeRequired
		}

		// Token: 0x02000057 RID: 87
		internal struct HashBucket
		{
			// Token: 0x0600046A RID: 1130 RVA: 0x0000B8B6 File Offset: 0x00009AB6
			private HashBucket(T firstElement, ImmutableList<T>.Node additionalElements = null)
			{
				this._firstValue = firstElement;
				this._additionalElements = (additionalElements ?? ImmutableList<T>.Node.EmptyNode);
			}

			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000B8CF File Offset: 0x00009ACF
			internal bool IsEmpty
			{
				get
				{
					return this._additionalElements == null;
				}
			}

			// Token: 0x0600046C RID: 1132 RVA: 0x0000B8DA File Offset: 0x00009ADA
			public ImmutableHashSet<T>.HashBucket.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.HashBucket.Enumerator(this);
			}

			// Token: 0x0600046D RID: 1133 RVA: 0x0000B8E8 File Offset: 0x00009AE8
			internal ImmutableHashSet<T>.HashBucket Add(T value, IEqualityComparer<T> valueComparer, out ImmutableHashSet<T>.OperationResult result)
			{
				if (this.IsEmpty)
				{
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(value, null);
				}
				if (valueComparer.Equals(value, this._firstValue) || this._additionalElements.IndexOf(value, valueComparer) >= 0)
				{
					result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
					return this;
				}
				result = ImmutableHashSet<T>.OperationResult.SizeChanged;
				return new ImmutableHashSet<T>.HashBucket(this._firstValue, this._additionalElements.Add(value));
			}

			// Token: 0x0600046E RID: 1134 RVA: 0x0000B94B File Offset: 0x00009B4B
			internal bool Contains(T value, IEqualityComparer<T> valueComparer)
			{
				return !this.IsEmpty && (valueComparer.Equals(value, this._firstValue) || this._additionalElements.IndexOf(value, valueComparer) >= 0);
			}

			// Token: 0x0600046F RID: 1135 RVA: 0x0000B97C File Offset: 0x00009B7C
			internal bool TryExchange(T value, IEqualityComparer<T> valueComparer, out T existingValue)
			{
				if (!this.IsEmpty)
				{
					if (valueComparer.Equals(value, this._firstValue))
					{
						existingValue = this._firstValue;
						return true;
					}
					int num = this._additionalElements.IndexOf(value, valueComparer);
					if (num >= 0)
					{
						existingValue = this._additionalElements[num];
						return true;
					}
				}
				existingValue = value;
				return false;
			}

			// Token: 0x06000470 RID: 1136 RVA: 0x0000B9DC File Offset: 0x00009BDC
			internal ImmutableHashSet<T>.HashBucket Remove(T value, IEqualityComparer<T> equalityComparer, out ImmutableHashSet<T>.OperationResult result)
			{
				if (this.IsEmpty)
				{
					result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
					return this;
				}
				if (equalityComparer.Equals(this._firstValue, value))
				{
					if (this._additionalElements.IsEmpty)
					{
						result = ImmutableHashSet<T>.OperationResult.SizeChanged;
						return default(ImmutableHashSet<T>.HashBucket);
					}
					int count = this._additionalElements.Left.Count;
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(this._additionalElements.Key, this._additionalElements.RemoveAt(count));
				}
				else
				{
					int num = this._additionalElements.IndexOf(value, equalityComparer);
					if (num < 0)
					{
						result = ImmutableHashSet<T>.OperationResult.NoChangeRequired;
						return this;
					}
					result = ImmutableHashSet<T>.OperationResult.SizeChanged;
					return new ImmutableHashSet<T>.HashBucket(this._firstValue, this._additionalElements.RemoveAt(num));
				}
			}

			// Token: 0x06000471 RID: 1137 RVA: 0x0000BA8B File Offset: 0x00009C8B
			internal void Freeze()
			{
				if (this._additionalElements != null)
				{
					this._additionalElements.Freeze();
				}
			}

			// Token: 0x04000096 RID: 150
			private readonly T _firstValue;

			// Token: 0x04000097 RID: 151
			private readonly ImmutableList<T>.Node _additionalElements;

			// Token: 0x02000072 RID: 114
			internal struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable
			{
				// Token: 0x06000627 RID: 1575 RVA: 0x00010B06 File Offset: 0x0000ED06
				internal Enumerator(ImmutableHashSet<T>.HashBucket bucket)
				{
					this._disposed = false;
					this._bucket = bucket;
					this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst;
					this._additionalEnumerator = default(ImmutableList<T>.Enumerator);
				}

				// Token: 0x1700014A RID: 330
				// (get) Token: 0x06000628 RID: 1576 RVA: 0x00010B29 File Offset: 0x0000ED29
				object IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x1700014B RID: 331
				// (get) Token: 0x06000629 RID: 1577 RVA: 0x00010B38 File Offset: 0x0000ED38
				public T Current
				{
					get
					{
						this.ThrowIfDisposed();
						ImmutableHashSet<T>.HashBucket.Enumerator.Position currentPosition = this._currentPosition;
						if (currentPosition == ImmutableHashSet<T>.HashBucket.Enumerator.Position.First)
						{
							return this._bucket._firstValue;
						}
						if (currentPosition != ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional)
						{
							throw new InvalidOperationException();
						}
						return this._additionalEnumerator.Current;
					}
				}

				// Token: 0x0600062A RID: 1578 RVA: 0x00010B7C File Offset: 0x0000ED7C
				public bool MoveNext()
				{
					this.ThrowIfDisposed();
					if (this._bucket.IsEmpty)
					{
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.End;
						return false;
					}
					switch (this._currentPosition)
					{
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst:
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.First;
						return true;
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.First:
						if (this._bucket._additionalElements.IsEmpty)
						{
							this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.End;
							return false;
						}
						this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional;
						this._additionalEnumerator = new ImmutableList<T>.Enumerator(this._bucket._additionalElements, null, -1, -1, false);
						return this._additionalEnumerator.MoveNext();
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.Additional:
						return this._additionalEnumerator.MoveNext();
					case ImmutableHashSet<T>.HashBucket.Enumerator.Position.End:
						return false;
					default:
						throw new InvalidOperationException();
					}
				}

				// Token: 0x0600062B RID: 1579 RVA: 0x00010C2B File Offset: 0x0000EE2B
				public void Reset()
				{
					this.ThrowIfDisposed();
					this._additionalEnumerator.Dispose();
					this._currentPosition = ImmutableHashSet<T>.HashBucket.Enumerator.Position.BeforeFirst;
				}

				// Token: 0x0600062C RID: 1580 RVA: 0x00010C45 File Offset: 0x0000EE45
				public void Dispose()
				{
					this._disposed = true;
					this._additionalEnumerator.Dispose();
				}

				// Token: 0x0600062D RID: 1581 RVA: 0x00010C59 File Offset: 0x0000EE59
				private void ThrowIfDisposed()
				{
					if (this._disposed)
					{
						Requires.FailObjectDisposed<ImmutableHashSet<T>.HashBucket.Enumerator>(this);
					}
				}

				// Token: 0x0400010C RID: 268
				private readonly ImmutableHashSet<T>.HashBucket _bucket;

				// Token: 0x0400010D RID: 269
				private bool _disposed;

				// Token: 0x0400010E RID: 270
				private ImmutableHashSet<T>.HashBucket.Enumerator.Position _currentPosition;

				// Token: 0x0400010F RID: 271
				private ImmutableList<T>.Enumerator _additionalEnumerator;

				// Token: 0x02000075 RID: 117
				private enum Position
				{
					// Token: 0x04000119 RID: 281
					BeforeFirst,
					// Token: 0x0400011A RID: 282
					First,
					// Token: 0x0400011B RID: 283
					Additional,
					// Token: 0x0400011C RID: 284
					End
				}
			}
		}

		// Token: 0x02000058 RID: 88
		private struct MutationInput
		{
			// Token: 0x06000472 RID: 1138 RVA: 0x0000BAA0 File Offset: 0x00009CA0
			internal MutationInput(ImmutableHashSet<T> set)
			{
				Requires.NotNull<ImmutableHashSet<T>>(set, "set");
				this._root = set._root;
				this._equalityComparer = set._equalityComparer;
				this._count = set._count;
			}

			// Token: 0x06000473 RID: 1139 RVA: 0x0000BAD1 File Offset: 0x00009CD1
			internal MutationInput(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				Requires.NotNull<IEqualityComparer<T>>(equalityComparer, "equalityComparer");
				Requires.Range(count >= 0, "count", null);
				this._root = root;
				this._equalityComparer = equalityComparer;
				this._count = count;
			}

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000BB10 File Offset: 0x00009D10
			internal SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000BB18 File Offset: 0x00009D18
			internal IEqualityComparer<T> EqualityComparer
			{
				get
				{
					return this._equalityComparer;
				}
			}

			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000BB20 File Offset: 0x00009D20
			internal int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x04000098 RID: 152
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

			// Token: 0x04000099 RID: 153
			private readonly IEqualityComparer<T> _equalityComparer;

			// Token: 0x0400009A RID: 154
			private readonly int _count;
		}

		// Token: 0x02000059 RID: 89
		private enum CountType
		{
			// Token: 0x0400009C RID: 156
			Adjustment,
			// Token: 0x0400009D RID: 157
			FinalValue
		}

		// Token: 0x0200005A RID: 90
		private struct MutationResult
		{
			// Token: 0x06000477 RID: 1143 RVA: 0x0000BB28 File Offset: 0x00009D28
			internal MutationResult(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root, int count, ImmutableHashSet<T>.CountType countType = ImmutableHashSet<T>.CountType.Adjustment)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				this._root = root;
				this._count = count;
				this._countType = countType;
			}

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000BB4A File Offset: 0x00009D4A
			internal SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000479 RID: 1145 RVA: 0x0000BB52 File Offset: 0x00009D52
			internal int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000BB5A File Offset: 0x00009D5A
			internal ImmutableHashSet<T>.CountType CountType
			{
				get
				{
					return this._countType;
				}
			}

			// Token: 0x0600047B RID: 1147 RVA: 0x0000BB64 File Offset: 0x00009D64
			internal ImmutableHashSet<T> Finalize(ImmutableHashSet<T> priorSet)
			{
				Requires.NotNull<ImmutableHashSet<T>>(priorSet, "priorSet");
				int num = this.Count;
				if (this.CountType == ImmutableHashSet<T>.CountType.Adjustment)
				{
					num += priorSet._count;
				}
				return priorSet.Wrap(this.Root, num);
			}

			// Token: 0x0400009E RID: 158
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;

			// Token: 0x0400009F RID: 159
			private readonly int _count;

			// Token: 0x040000A0 RID: 160
			private readonly ImmutableHashSet<T>.CountType _countType;
		}

		// Token: 0x0200005B RID: 91
		private struct NodeEnumerable : IEnumerable<!0>, IEnumerable
		{
			// Token: 0x0600047C RID: 1148 RVA: 0x0000BBA1 File Offset: 0x00009DA1
			internal NodeEnumerable(SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> root)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket>>(root, "root");
				this._root = root;
			}

			// Token: 0x0600047D RID: 1149 RVA: 0x0000BBB5 File Offset: 0x00009DB5
			public ImmutableHashSet<T>.Enumerator GetEnumerator()
			{
				return new ImmutableHashSet<T>.Enumerator(this._root, null);
			}

			// Token: 0x0600047E RID: 1150 RVA: 0x0000BBC3 File Offset: 0x00009DC3
			[ExcludeFromCodeCoverage]
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x0600047F RID: 1151 RVA: 0x0000BBC3 File Offset: 0x00009DC3
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x040000A1 RID: 161
			private readonly SortedInt32KeyNode<ImmutableHashSet<T>.HashBucket> _root;
		}
	}
}
