using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x02000026 RID: 38
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableListDebuggerProxy<>))]
	public sealed class ImmutableList<T> : IImmutableList<!0>, IReadOnlyList<!0>, IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, IList<!0>, ICollection<!0>, IList, ICollection, IOrderedCollection<T>, IImmutableListQueries<T>, IStrongEnumerable<T, ImmutableList<T>.Enumerator>
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x00006770 File Offset: 0x00004970
		internal ImmutableList()
		{
			this._root = ImmutableList<T>.Node.EmptyNode;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00006783 File Offset: 0x00004983
		private ImmutableList(ImmutableList<T>.Node root)
		{
			Requires.NotNull<ImmutableList<T>.Node>(root, "root");
			root.Freeze();
			this._root = root;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000067A3 File Offset: 0x000049A3
		public ImmutableList<T> Clear()
		{
			return ImmutableList<T>.Empty;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000067AA File Offset: 0x000049AA
		public int BinarySearch(T item)
		{
			return this.BinarySearch(item, null);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000067B4 File Offset: 0x000049B4
		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return this.BinarySearch(0, this.Count, item, comparer);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000067C5 File Offset: 0x000049C5
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return this._root.BinarySearch(index, count, item, comparer);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000067D7 File Offset: 0x000049D7
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsEmpty
		{
			get
			{
				return this._root.IsEmpty;
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000067E4 File Offset: 0x000049E4
		IImmutableList<T> IImmutableList<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000067EC File Offset: 0x000049EC
		public int Count
		{
			get
			{
				return this._root.Count;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000055 RID: 85
		public T this[int index]
		{
			get
			{
				return this._root[index];
			}
		}

		// Token: 0x17000056 RID: 86
		T IOrderedCollection<!0>.this[int index]
		{
			get
			{
				return this[index];
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00006810 File Offset: 0x00004A10
		public ImmutableList<T>.Builder ToBuilder()
		{
			return new ImmutableList<T>.Builder(this);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00006818 File Offset: 0x00004A18
		public ImmutableList<T> Add(T value)
		{
			ImmutableList<T>.Node root = this._root.Add(value);
			return this.Wrap(root);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000683C File Offset: 0x00004A3C
		public ImmutableList<T> AddRange(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty)
			{
				return ImmutableList<T>.CreateRange(items);
			}
			ImmutableList<T>.Node root = this._root.AddRange(items);
			return this.Wrap(root);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00006877 File Offset: 0x00004A77
		public ImmutableList<T> Insert(int index, T item)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			return this.Wrap(this._root.Insert(index, item));
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000068AC File Offset: 0x00004AAC
		public ImmutableList<T> InsertRange(int index, IEnumerable<T> items)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			Requires.NotNull<IEnumerable<T>>(items, "items");
			ImmutableList<T>.Node root = this._root.InsertRange(index, items);
			return this.Wrap(root);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000068F7 File Offset: 0x00004AF7
		public ImmutableList<T> Remove(T value)
		{
			return this.Remove(value, EqualityComparer<T>.Default);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00006908 File Offset: 0x00004B08
		public ImmutableList<T> Remove(T value, IEqualityComparer<T> equalityComparer)
		{
			int num = this.IndexOf(value, equalityComparer);
			if (num >= 0)
			{
				return this.RemoveAt(num);
			}
			return this;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000692C File Offset: 0x00004B2C
		public ImmutableList<T> RemoveRange(int index, int count)
		{
			Requires.Range(index >= 0 && index <= this.Count, "index", null);
			Requires.Range(count >= 0 && index + count <= this.Count, "count", null);
			ImmutableList<T>.Node node = this._root;
			int num = count;
			while (num-- > 0)
			{
				node = node.RemoveAt(index);
			}
			return this.Wrap(node);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00006999 File Offset: 0x00004B99
		public ImmutableList<T> RemoveRange(IEnumerable<T> items)
		{
			return this.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x000069A8 File Offset: 0x00004BA8
		public ImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (this.IsEmpty)
			{
				return this;
			}
			ImmutableList<T>.Node node = this._root;
			foreach (T item in items.GetEnumerableDisposable<T, ImmutableList<T>.Enumerator>())
			{
				int num = node.IndexOf(item, equalityComparer);
				if (num >= 0)
				{
					node = node.RemoveAt(num);
				}
			}
			return this.Wrap(node);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00006A34 File Offset: 0x00004C34
		public ImmutableList<T> RemoveAt(int index)
		{
			Requires.Range(index >= 0 && index < this.Count, "index", null);
			ImmutableList<T>.Node root = this._root.RemoveAt(index);
			return this.Wrap(root);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00006A70 File Offset: 0x00004C70
		public ImmutableList<T> RemoveAll(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this.Wrap(this._root.RemoveAll(match));
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00006A8F File Offset: 0x00004C8F
		public ImmutableList<T> SetItem(int index, T value)
		{
			return this.Wrap(this._root.ReplaceAt(index, value));
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00006AA4 File Offset: 0x00004CA4
		public ImmutableList<T> Replace(T oldValue, T newValue)
		{
			return this.Replace(oldValue, newValue, EqualityComparer<T>.Default);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00006AB4 File Offset: 0x00004CB4
		public ImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
		{
			int num = this.IndexOf(oldValue, equalityComparer);
			if (num < 0)
			{
				throw new ArgumentException(SR.CannotFindOldValue, "oldValue");
			}
			return this.SetItem(num, newValue);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00006AE6 File Offset: 0x00004CE6
		public ImmutableList<T> Reverse()
		{
			return this.Wrap(this._root.Reverse());
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00006AF9 File Offset: 0x00004CF9
		public ImmutableList<T> Reverse(int index, int count)
		{
			return this.Wrap(this._root.Reverse(index, count));
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00006B0E File Offset: 0x00004D0E
		public ImmutableList<T> Sort()
		{
			return this.Wrap(this._root.Sort());
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00006B21 File Offset: 0x00004D21
		public ImmutableList<T> Sort(Comparison<T> comparison)
		{
			Requires.NotNull<Comparison<T>>(comparison, "comparison");
			return this.Wrap(this._root.Sort(comparison));
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00006B40 File Offset: 0x00004D40
		public ImmutableList<T> Sort(IComparer<T> comparer)
		{
			return this.Wrap(this._root.Sort(comparer));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00006B54 File Offset: 0x00004D54
		public ImmutableList<T> Sort(int index, int count, IComparer<T> comparer)
		{
			Requires.Range(index >= 0, "index", null);
			Requires.Range(count >= 0, "count", null);
			Requires.Range(index + count <= this.Count, "count", null);
			return this.Wrap(this._root.Sort(index, count, comparer));
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00006BB4 File Offset: 0x00004DB4
		public void ForEach(Action<T> action)
		{
			Requires.NotNull<Action<T>>(action, "action");
			foreach (T obj in this)
			{
				action(obj);
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00006C10 File Offset: 0x00004E10
		public void CopyTo(T[] array)
		{
			Requires.NotNull<T[]>(array, "array");
			Requires.Range(array.Length >= this.Count, "array", null);
			this._root.CopyTo(array);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00006C44 File Offset: 0x00004E44
		public void CopyTo(T[] array, int arrayIndex)
		{
			Requires.NotNull<T[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			this._root.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00006C96 File Offset: 0x00004E96
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			this._root.CopyTo(index, array, arrayIndex, count);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00006CA8 File Offset: 0x00004EA8
		public ImmutableList<T> GetRange(int index, int count)
		{
			Requires.Range(index >= 0, "index", null);
			Requires.Range(count >= 0, "count", null);
			Requires.Range(index + count <= this.Count, "count", null);
			return this.Wrap(ImmutableList<T>.Node.NodeTreeFromList(this, index, count));
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00006D00 File Offset: 0x00004F00
		public ImmutableList<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter)
		{
			Requires.NotNull<Func<T, TOutput>>(converter, "converter");
			return ImmutableList<TOutput>.WrapNode(this._root.ConvertAll<TOutput>(converter));
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00006D1E File Offset: 0x00004F1E
		public bool Exists(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.Exists(match);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00006D37 File Offset: 0x00004F37
		public T Find(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.Find(match);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00006D50 File Offset: 0x00004F50
		public ImmutableList<T> FindAll(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.FindAll(match);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00006D69 File Offset: 0x00004F69
		public int FindIndex(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.FindIndex(match);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00006D84 File Offset: 0x00004F84
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			Requires.Range(startIndex >= 0, "startIndex", null);
			Requires.Range(startIndex <= this.Count, "startIndex", null);
			return this._root.FindIndex(startIndex, match);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00006DD4 File Offset: 0x00004FD4
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			Requires.Range(startIndex >= 0, "startIndex", null);
			Requires.Range(count >= 0, "count", null);
			Requires.Range(startIndex + count <= this.Count, "count", null);
			return this._root.FindIndex(startIndex, count, match);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00006E37 File Offset: 0x00005037
		public T FindLast(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.FindLast(match);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00006E50 File Offset: 0x00005050
		public int FindLastIndex(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.FindLastIndex(match);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00006E6C File Offset: 0x0000506C
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			Requires.Range(startIndex >= 0, "startIndex", null);
			Requires.Range(startIndex == 0 || startIndex < this.Count, "startIndex", null);
			return this._root.FindLastIndex(startIndex, match);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00006EC0 File Offset: 0x000050C0
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			Requires.Range(startIndex >= 0, "startIndex", null);
			Requires.Range(count <= this.Count, "count", null);
			Requires.Range(startIndex - count + 1 >= 0, "startIndex", null);
			return this._root.FindLastIndex(startIndex, count, match);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00006F25 File Offset: 0x00005125
		public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
		{
			return this._root.IndexOf(item, index, count, equalityComparer);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00006F37 File Offset: 0x00005137
		public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
		{
			return this._root.LastIndexOf(item, index, count, equalityComparer);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00006F49 File Offset: 0x00005149
		public bool TrueForAll(Predicate<T> match)
		{
			Requires.NotNull<Predicate<T>>(match, "match");
			return this._root.TrueForAll(match);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00006F62 File Offset: 0x00005162
		public bool Contains(T value)
		{
			return this.IndexOf(value) >= 0;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00006F71 File Offset: 0x00005171
		public int IndexOf(T value)
		{
			return this.IndexOf(value, EqualityComparer<T>.Default);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00006F7F File Offset: 0x0000517F
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Add(T value)
		{
			return this.Add(value);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00006F88 File Offset: 0x00005188
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.AddRange(IEnumerable<T> items)
		{
			return this.AddRange(items);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00006F91 File Offset: 0x00005191
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Insert(int index, T item)
		{
			return this.Insert(index, item);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00006F9B File Offset: 0x0000519B
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.InsertRange(int index, IEnumerable<T> items)
		{
			return this.InsertRange(index, items);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00006FA5 File Offset: 0x000051A5
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Remove(T value, IEqualityComparer<T> equalityComparer)
		{
			return this.Remove(value, equalityComparer);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00006FAF File Offset: 0x000051AF
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveAll(Predicate<T> match)
		{
			return this.RemoveAll(match);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006FB8 File Offset: 0x000051B8
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
		{
			return this.RemoveRange(items, equalityComparer);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00006FC2 File Offset: 0x000051C2
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveRange(int index, int count)
		{
			return this.RemoveRange(index, count);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00006FCC File Offset: 0x000051CC
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveAt(int index)
		{
			return this.RemoveAt(index);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00006FD5 File Offset: 0x000051D5
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.SetItem(int index, T value)
		{
			return this.SetItem(index, value);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00006FDF File Offset: 0x000051DF
		IImmutableList<T> IImmutableList<!0>.Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
		{
			return this.Replace(oldValue, newValue, equalityComparer);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006FEA File Offset: 0x000051EA
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00006FEA File Offset: 0x000051EA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000057 RID: 87
		T IList<!0>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00003182 File Offset: 0x00001382
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00006FF7 File Offset: 0x000051F7
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			this._root.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000317B File Offset: 0x0000137B
		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00007006 File Offset: 0x00005206
		bool IList.Contains(object value)
		{
			return ImmutableList<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000701E File Offset: 0x0000521E
		int IList.IndexOf(object value)
		{
			if (ImmutableList<T>.IsCompatibleObject(value))
			{
				return this.IndexOf((T)((object)value));
			}
			return -1;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00003182 File Offset: 0x00001382
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00003182 File Offset: 0x00001382
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700005B RID: 91
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00007044 File Offset: 0x00005244
		public ImmutableList<T>.Enumerator GetEnumerator()
		{
			return new ImmutableList<T>.Enumerator(this._root, null, -1, -1, false);
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00007055 File Offset: 0x00005255
		internal ImmutableList<T>.Node Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000705D File Offset: 0x0000525D
		private static ImmutableList<T> WrapNode(ImmutableList<T>.Node root)
		{
			if (!root.IsEmpty)
			{
				return new ImmutableList<T>(root);
			}
			return ImmutableList<T>.Empty;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00007074 File Offset: 0x00005274
		private static bool TryCastToImmutableList(IEnumerable<T> sequence, out ImmutableList<T> other)
		{
			other = (sequence as ImmutableList<T>);
			if (other != null)
			{
				return true;
			}
			ImmutableList<T>.Builder builder = sequence as ImmutableList<T>.Builder;
			if (builder != null)
			{
				other = builder.ToImmutable();
				return true;
			}
			return false;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000070A4 File Offset: 0x000052A4
		private static bool IsCompatibleObject(object value)
		{
			return value is T || (value == null && default(T) == null);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000070D1 File Offset: 0x000052D1
		private ImmutableList<T> Wrap(ImmutableList<T>.Node root)
		{
			if (root == this._root)
			{
				return this;
			}
			if (!root.IsEmpty)
			{
				return new ImmutableList<T>(root);
			}
			return this.Clear();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000070F4 File Offset: 0x000052F4
		private static ImmutableList<T> CreateRange(IEnumerable<T> items)
		{
			ImmutableList<T> result;
			if (ImmutableList<T>.TryCastToImmutableList(items, out result))
			{
				return result;
			}
			IOrderedCollection<T> orderedCollection = items.AsOrderedCollection<T>();
			if (orderedCollection.Count == 0)
			{
				return ImmutableList<T>.Empty;
			}
			ImmutableList<T>.Node root = ImmutableList<T>.Node.NodeTreeFromList(orderedCollection, 0, orderedCollection.Count);
			return new ImmutableList<T>(root);
		}

		// Token: 0x0400001B RID: 27
		public static readonly ImmutableList<T> Empty = new ImmutableList<T>();

		// Token: 0x0400001C RID: 28
		private readonly ImmutableList<T>.Node _root;

		// Token: 0x0200005D RID: 93
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableListBuilderDebuggerProxy<>))]
		public sealed class Builder : IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IList, ICollection, IOrderedCollection<!0>, IImmutableListQueries<T>, IReadOnlyList<!0>, IReadOnlyCollection<!0>
		{
			// Token: 0x06000483 RID: 1155 RVA: 0x0000BBF8 File Offset: 0x00009DF8
			internal Builder(ImmutableList<T> list)
			{
				Requires.NotNull<ImmutableList<T>>(list, "list");
				this._root = list._root;
				this._immutable = list;
			}

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000BC29 File Offset: 0x00009E29
			public int Count
			{
				get
				{
					return this.Root.Count;
				}
			}

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x06000486 RID: 1158 RVA: 0x0000BC36 File Offset: 0x00009E36
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000BC3E File Offset: 0x00009E3E
			// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000BC46 File Offset: 0x00009E46
			internal ImmutableList<T>.Node Root
			{
				get
				{
					return this._root;
				}
				private set
				{
					this._version++;
					if (this._root != value)
					{
						this._root = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x170000E1 RID: 225
			public T this[int index]
			{
				get
				{
					return this.Root[index];
				}
				set
				{
					this.Root = this.Root.ReplaceAt(index, value);
				}
			}

			// Token: 0x170000E2 RID: 226
			T IOrderedCollection<!0>.this[int index]
			{
				get
				{
					return this[index];
				}
			}

			// Token: 0x0600048C RID: 1164 RVA: 0x0000BC99 File Offset: 0x00009E99
			public int IndexOf(T item)
			{
				return this.Root.IndexOf(item, EqualityComparer<T>.Default);
			}

			// Token: 0x0600048D RID: 1165 RVA: 0x0000BCAC File Offset: 0x00009EAC
			public void Insert(int index, T item)
			{
				this.Root = this.Root.Insert(index, item);
			}

			// Token: 0x0600048E RID: 1166 RVA: 0x0000BCC1 File Offset: 0x00009EC1
			public void RemoveAt(int index)
			{
				this.Root = this.Root.RemoveAt(index);
			}

			// Token: 0x0600048F RID: 1167 RVA: 0x0000BCD5 File Offset: 0x00009ED5
			public void Add(T item)
			{
				this.Root = this.Root.Add(item);
			}

			// Token: 0x06000490 RID: 1168 RVA: 0x0000BCE9 File Offset: 0x00009EE9
			public void Clear()
			{
				this.Root = ImmutableList<T>.Node.EmptyNode;
			}

			// Token: 0x06000491 RID: 1169 RVA: 0x0000BCF6 File Offset: 0x00009EF6
			public bool Contains(T item)
			{
				return this.IndexOf(item) >= 0;
			}

			// Token: 0x06000492 RID: 1170 RVA: 0x0000BD08 File Offset: 0x00009F08
			public bool Remove(T item)
			{
				int num = this.IndexOf(item);
				if (num < 0)
				{
					return false;
				}
				this.Root = this.Root.RemoveAt(num);
				return true;
			}

			// Token: 0x06000493 RID: 1171 RVA: 0x0000BD36 File Offset: 0x00009F36
			public ImmutableList<T>.Enumerator GetEnumerator()
			{
				return this.Root.GetEnumerator(this);
			}

			// Token: 0x06000494 RID: 1172 RVA: 0x0000BD44 File Offset: 0x00009F44
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000495 RID: 1173 RVA: 0x0000BD44 File Offset: 0x00009F44
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000496 RID: 1174 RVA: 0x0000BD54 File Offset: 0x00009F54
			public void ForEach(Action<T> action)
			{
				Requires.NotNull<Action<T>>(action, "action");
				foreach (T obj in this)
				{
					action(obj);
				}
			}

			// Token: 0x06000497 RID: 1175 RVA: 0x0000BDB0 File Offset: 0x00009FB0
			public void CopyTo(T[] array)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(array.Length >= this.Count, "array", null);
				this._root.CopyTo(array);
			}

			// Token: 0x06000498 RID: 1176 RVA: 0x0000BDE2 File Offset: 0x00009FE2
			public void CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				this._root.CopyTo(array, arrayIndex);
			}

			// Token: 0x06000499 RID: 1177 RVA: 0x0000BE17 File Offset: 0x0000A017
			public void CopyTo(int index, T[] array, int arrayIndex, int count)
			{
				this._root.CopyTo(index, array, arrayIndex, count);
			}

			// Token: 0x0600049A RID: 1178 RVA: 0x0000BE2C File Offset: 0x0000A02C
			public ImmutableList<T> GetRange(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				return ImmutableList<T>.WrapNode(ImmutableList<T>.Node.NodeTreeFromList(this, index, count));
			}

			// Token: 0x0600049B RID: 1179 RVA: 0x0000BE83 File Offset: 0x0000A083
			public ImmutableList<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter)
			{
				Requires.NotNull<Func<T, TOutput>>(converter, "converter");
				return ImmutableList<TOutput>.WrapNode(this._root.ConvertAll<TOutput>(converter));
			}

			// Token: 0x0600049C RID: 1180 RVA: 0x0000BEA1 File Offset: 0x0000A0A1
			public bool Exists(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.Exists(match);
			}

			// Token: 0x0600049D RID: 1181 RVA: 0x0000BEBA File Offset: 0x0000A0BA
			public T Find(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.Find(match);
			}

			// Token: 0x0600049E RID: 1182 RVA: 0x0000BED3 File Offset: 0x0000A0D3
			public ImmutableList<T> FindAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.FindAll(match);
			}

			// Token: 0x0600049F RID: 1183 RVA: 0x0000BEEC File Offset: 0x0000A0EC
			public int FindIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.FindIndex(match);
			}

			// Token: 0x060004A0 RID: 1184 RVA: 0x0000BF08 File Offset: 0x0000A108
			public int FindIndex(int startIndex, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(startIndex <= this.Count, "startIndex", null);
				return this._root.FindIndex(startIndex, match);
			}

			// Token: 0x060004A1 RID: 1185 RVA: 0x0000BF58 File Offset: 0x0000A158
			public int FindIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(startIndex + count <= this.Count, "count", null);
				return this._root.FindIndex(startIndex, count, match);
			}

			// Token: 0x060004A2 RID: 1186 RVA: 0x0000BFBB File Offset: 0x0000A1BB
			public T FindLast(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.FindLast(match);
			}

			// Token: 0x060004A3 RID: 1187 RVA: 0x0000BFD4 File Offset: 0x0000A1D4
			public int FindLastIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.FindLastIndex(match);
			}

			// Token: 0x060004A4 RID: 1188 RVA: 0x0000BFF0 File Offset: 0x0000A1F0
			public int FindLastIndex(int startIndex, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(startIndex == 0 || startIndex < this.Count, "startIndex", null);
				return this._root.FindLastIndex(startIndex, match);
			}

			// Token: 0x060004A5 RID: 1189 RVA: 0x0000C044 File Offset: 0x0000A244
			public int FindLastIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count <= this.Count, "count", null);
				Requires.Range(startIndex - count + 1 >= 0, "startIndex", null);
				return this._root.FindLastIndex(startIndex, count, match);
			}

			// Token: 0x060004A6 RID: 1190 RVA: 0x0000C0A9 File Offset: 0x0000A2A9
			public int IndexOf(T item, int index)
			{
				return this._root.IndexOf(item, index, this.Count - index, EqualityComparer<T>.Default);
			}

			// Token: 0x060004A7 RID: 1191 RVA: 0x0000C0C5 File Offset: 0x0000A2C5
			public int IndexOf(T item, int index, int count)
			{
				return this._root.IndexOf(item, index, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004A8 RID: 1192 RVA: 0x0000C0DA File Offset: 0x0000A2DA
			public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
			{
				return this._root.IndexOf(item, index, count, equalityComparer);
			}

			// Token: 0x060004A9 RID: 1193 RVA: 0x0000C0EC File Offset: 0x0000A2EC
			public int LastIndexOf(T item)
			{
				if (this.Count == 0)
				{
					return -1;
				}
				return this._root.LastIndexOf(item, this.Count - 1, this.Count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004AA RID: 1194 RVA: 0x0000C117 File Offset: 0x0000A317
			public int LastIndexOf(T item, int startIndex)
			{
				if (this.Count == 0 && startIndex == 0)
				{
					return -1;
				}
				return this._root.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
			}

			// Token: 0x060004AB RID: 1195 RVA: 0x0000C13B File Offset: 0x0000A33B
			public int LastIndexOf(T item, int startIndex, int count)
			{
				return this._root.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060004AC RID: 1196 RVA: 0x0000C150 File Offset: 0x0000A350
			public int LastIndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
			{
				return this._root.LastIndexOf(item, startIndex, count, equalityComparer);
			}

			// Token: 0x060004AD RID: 1197 RVA: 0x0000C162 File Offset: 0x0000A362
			public bool TrueForAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this._root.TrueForAll(match);
			}

			// Token: 0x060004AE RID: 1198 RVA: 0x0000C17B File Offset: 0x0000A37B
			public void AddRange(IEnumerable<T> items)
			{
				Requires.NotNull<IEnumerable<T>>(items, "items");
				this.Root = this.Root.AddRange(items);
			}

			// Token: 0x060004AF RID: 1199 RVA: 0x0000C19A File Offset: 0x0000A39A
			public void InsertRange(int index, IEnumerable<T> items)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				Requires.NotNull<IEnumerable<T>>(items, "items");
				this.Root = this.Root.InsertRange(index, items);
			}

			// Token: 0x060004B0 RID: 1200 RVA: 0x0000C1D8 File Offset: 0x0000A3D8
			public int RemoveAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				int count = this.Count;
				this.Root = this.Root.RemoveAll(match);
				return count - this.Count;
			}

			// Token: 0x060004B1 RID: 1201 RVA: 0x0000C211 File Offset: 0x0000A411
			public void Reverse()
			{
				this.Reverse(0, this.Count);
			}

			// Token: 0x060004B2 RID: 1202 RVA: 0x0000C220 File Offset: 0x0000A420
			public void Reverse(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				this.Root = this.Root.Reverse(index, count);
			}

			// Token: 0x060004B3 RID: 1203 RVA: 0x0000C27D File Offset: 0x0000A47D
			public void Sort()
			{
				this.Root = this.Root.Sort();
			}

			// Token: 0x060004B4 RID: 1204 RVA: 0x0000C290 File Offset: 0x0000A490
			public void Sort(Comparison<T> comparison)
			{
				Requires.NotNull<Comparison<T>>(comparison, "comparison");
				this.Root = this.Root.Sort(comparison);
			}

			// Token: 0x060004B5 RID: 1205 RVA: 0x0000C2AF File Offset: 0x0000A4AF
			public void Sort(IComparer<T> comparer)
			{
				this.Root = this.Root.Sort(comparer);
			}

			// Token: 0x060004B6 RID: 1206 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
			public void Sort(int index, int count, IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				this.Root = this.Root.Sort(index, count, comparer);
			}

			// Token: 0x060004B7 RID: 1207 RVA: 0x0000C322 File Offset: 0x0000A522
			public int BinarySearch(T item)
			{
				return this.BinarySearch(item, null);
			}

			// Token: 0x060004B8 RID: 1208 RVA: 0x0000C32C File Offset: 0x0000A52C
			public int BinarySearch(T item, IComparer<T> comparer)
			{
				return this.BinarySearch(0, this.Count, item, comparer);
			}

			// Token: 0x060004B9 RID: 1209 RVA: 0x0000C33D File Offset: 0x0000A53D
			public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
			{
				return this.Root.BinarySearch(index, count, item, comparer);
			}

			// Token: 0x060004BA RID: 1210 RVA: 0x0000C34F File Offset: 0x0000A54F
			public ImmutableList<T> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableList<T>.WrapNode(this.Root);
				}
				return this._immutable;
			}

			// Token: 0x060004BB RID: 1211 RVA: 0x0000C370 File Offset: 0x0000A570
			int IList.Add(object value)
			{
				this.Add((T)((object)value));
				return this.Count - 1;
			}

			// Token: 0x060004BC RID: 1212 RVA: 0x0000C386 File Offset: 0x0000A586
			void IList.Clear()
			{
				this.Clear();
			}

			// Token: 0x060004BD RID: 1213 RVA: 0x0000C38E File Offset: 0x0000A58E
			bool IList.Contains(object value)
			{
				return ImmutableList<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
			}

			// Token: 0x060004BE RID: 1214 RVA: 0x0000C3A6 File Offset: 0x0000A5A6
			int IList.IndexOf(object value)
			{
				if (ImmutableList<T>.IsCompatibleObject(value))
				{
					return this.IndexOf((T)((object)value));
				}
				return -1;
			}

			// Token: 0x060004BF RID: 1215 RVA: 0x0000C3BE File Offset: 0x0000A5BE
			void IList.Insert(int index, object value)
			{
				this.Insert(index, (T)((object)value));
			}

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000206B File Offset: 0x0000026B
			bool IList.IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000206B File Offset: 0x0000026B
			bool IList.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060004C2 RID: 1218 RVA: 0x0000C3CD File Offset: 0x0000A5CD
			void IList.Remove(object value)
			{
				if (ImmutableList<T>.IsCompatibleObject(value))
				{
					this.Remove((T)((object)value));
				}
			}

			// Token: 0x170000E5 RID: 229
			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index] = (T)((object)value);
				}
			}

			// Token: 0x060004C5 RID: 1221 RVA: 0x0000C401 File Offset: 0x0000A601
			void ICollection.CopyTo(Array array, int arrayIndex)
			{
				this.Root.CopyTo(array, arrayIndex);
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000206B File Offset: 0x0000026B
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0000C410 File Offset: 0x0000A610
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			object ICollection.SyncRoot
			{
				get
				{
					if (this._syncRoot == null)
					{
						Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
					}
					return this._syncRoot;
				}
			}

			// Token: 0x040000A3 RID: 163
			private ImmutableList<T>.Node _root = ImmutableList<T>.Node.EmptyNode;

			// Token: 0x040000A4 RID: 164
			private ImmutableList<T> _immutable;

			// Token: 0x040000A5 RID: 165
			private int _version;

			// Token: 0x040000A6 RID: 166
			private object _syncRoot;
		}

		// Token: 0x0200005E RID: 94
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable, ISecurePooledObjectUser, IStrongEnumerator<T>
		{
			// Token: 0x060004C8 RID: 1224 RVA: 0x0000C434 File Offset: 0x0000A634
			internal Enumerator(ImmutableList<T>.Node root, ImmutableList<T>.Builder builder = null, int startIndex = -1, int count = -1, bool reversed = false)
			{
				Requires.NotNull<ImmutableList<T>.Node>(root, "root");
				Requires.Range(startIndex >= -1, "startIndex", null);
				Requires.Range(count >= -1, "count", null);
				Requires.Argument(reversed || count == -1 || ((startIndex == -1) ? 0 : startIndex) + count <= root.Count);
				Requires.Argument(!reversed || count == -1 || ((startIndex == -1) ? (root.Count - 1) : startIndex) - count + 1 >= 0);
				this._root = root;
				this._builder = builder;
				this._current = null;
				this._startIndex = ((startIndex >= 0) ? startIndex : (reversed ? (root.Count - 1) : 0));
				this._count = ((count == -1) ? root.Count : count);
				this._remainingCount = this._count;
				this._reversed = reversed;
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
				this._poolUserId = SecureObjectPool.NewId();
				this._stack = null;
				if (this._count > 0)
				{
					if (!ImmutableList<T>.Enumerator.s_EnumeratingStacks.TryTake(this, out this._stack))
					{
						this._stack = ImmutableList<T>.Enumerator.s_EnumeratingStacks.PrepNew(this, new Stack<RefAsValueType<ImmutableList<T>.Node>>(root.Height));
					}
					this.ResetStack();
				}
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0000C589 File Offset: 0x0000A789
			int ISecurePooledObjectUser.PoolUserId
			{
				get
				{
					return this._poolUserId;
				}
			}

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000C591 File Offset: 0x0000A791
			public T Current
			{
				get
				{
					this.ThrowIfDisposed();
					if (this._current != null)
					{
						return this._current.Value;
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x060004CB RID: 1227 RVA: 0x0000C5B2 File Offset: 0x0000A7B2
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060004CC RID: 1228 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
			public void Dispose()
			{
				this._root = null;
				this._current = null;
				Stack<RefAsValueType<ImmutableList<T>.Node>> stack;
				if (this._stack != null && this._stack.TryUse<ImmutableList<T>.Enumerator>(ref this, out stack))
				{
					stack.ClearFastWhenEmpty<RefAsValueType<ImmutableList<T>.Node>>();
					ImmutableList<T>.Enumerator.s_EnumeratingStacks.TryAdd(this, this._stack);
				}
				this._stack = null;
			}

			// Token: 0x060004CD RID: 1229 RVA: 0x0000C618 File Offset: 0x0000A818
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				this.ThrowIfChanged();
				if (this._stack != null)
				{
					Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
					if (this._remainingCount > 0 && stack.Count > 0)
					{
						ImmutableList<T>.Node value = stack.Pop().Value;
						this._current = value;
						this.PushNext(this.NextBranch(value));
						this._remainingCount--;
						return true;
					}
				}
				this._current = null;
				return false;
			}

			// Token: 0x060004CE RID: 1230 RVA: 0x0000C690 File Offset: 0x0000A890
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._remainingCount = this._count;
				if (this._stack != null)
				{
					this.ResetStack();
				}
			}

			// Token: 0x060004CF RID: 1231 RVA: 0x0000C6D0 File Offset: 0x0000A8D0
			private void ResetStack()
			{
				Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
				stack.ClearFastWhenEmpty<RefAsValueType<ImmutableList<T>.Node>>();
				ImmutableList<T>.Node node = this._root;
				int num = this._reversed ? (this._root.Count - this._startIndex - 1) : this._startIndex;
				while (!node.IsEmpty && num != this.PreviousBranch(node).Count)
				{
					if (num < this.PreviousBranch(node).Count)
					{
						stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
						node = this.PreviousBranch(node);
					}
					else
					{
						num -= this.PreviousBranch(node).Count + 1;
						node = this.NextBranch(node);
					}
				}
				if (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
				}
			}

			// Token: 0x060004D0 RID: 1232 RVA: 0x0000C787 File Offset: 0x0000A987
			private ImmutableList<T>.Node NextBranch(ImmutableList<T>.Node node)
			{
				if (!this._reversed)
				{
					return node.Right;
				}
				return node.Left;
			}

			// Token: 0x060004D1 RID: 1233 RVA: 0x0000C79E File Offset: 0x0000A99E
			private ImmutableList<T>.Node PreviousBranch(ImmutableList<T>.Node node)
			{
				if (!this._reversed)
				{
					return node.Left;
				}
				return node.Right;
			}

			// Token: 0x060004D2 RID: 1234 RVA: 0x0000C7B5 File Offset: 0x0000A9B5
			private void ThrowIfDisposed()
			{
				if (this._root == null || (this._stack != null && !this._stack.IsOwned<ImmutableList<T>.Enumerator>(ref this)))
				{
					Requires.FailObjectDisposed<ImmutableList<T>.Enumerator>(this);
				}
			}

			// Token: 0x060004D3 RID: 1235 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x060004D4 RID: 1236 RVA: 0x0000C808 File Offset: 0x0000AA08
			private void PushNext(ImmutableList<T>.Node node)
			{
				Requires.NotNull<ImmutableList<T>.Node>(node, "node");
				if (!node.IsEmpty)
				{
					Stack<RefAsValueType<ImmutableList<T>.Node>> stack = this._stack.Use<ImmutableList<T>.Enumerator>(ref this);
					while (!node.IsEmpty)
					{
						stack.Push(new RefAsValueType<ImmutableList<T>.Node>(node));
						node = this.PreviousBranch(node);
					}
				}
			}

			// Token: 0x040000A7 RID: 167
			private static readonly SecureObjectPool<Stack<RefAsValueType<ImmutableList<T>.Node>>, ImmutableList<T>.Enumerator> s_EnumeratingStacks = new SecureObjectPool<Stack<RefAsValueType<ImmutableList<T>.Node>>, ImmutableList<T>.Enumerator>();

			// Token: 0x040000A8 RID: 168
			private readonly ImmutableList<T>.Builder _builder;

			// Token: 0x040000A9 RID: 169
			private readonly int _poolUserId;

			// Token: 0x040000AA RID: 170
			private readonly int _startIndex;

			// Token: 0x040000AB RID: 171
			private readonly int _count;

			// Token: 0x040000AC RID: 172
			private int _remainingCount;

			// Token: 0x040000AD RID: 173
			private bool _reversed;

			// Token: 0x040000AE RID: 174
			private ImmutableList<T>.Node _root;

			// Token: 0x040000AF RID: 175
			private SecurePooledObject<Stack<RefAsValueType<ImmutableList<T>.Node>>> _stack;

			// Token: 0x040000B0 RID: 176
			private ImmutableList<T>.Node _current;

			// Token: 0x040000B1 RID: 177
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x0200005F RID: 95
		[DebuggerDisplay("{_key}")]
		internal sealed class Node : IBinaryTree<!0>, IBinaryTree, IEnumerable<!0>, IEnumerable
		{
			// Token: 0x060004D6 RID: 1238 RVA: 0x0000C860 File Offset: 0x0000AA60
			private Node()
			{
				this._frozen = true;
			}

			// Token: 0x060004D7 RID: 1239 RVA: 0x0000C870 File Offset: 0x0000AA70
			private Node(T key, ImmutableList<T>.Node left, ImmutableList<T>.Node right, bool frozen = false)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				this._key = key;
				this._left = left;
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(left, right);
				this._count = ImmutableList<T>.Node.ParentCount(left, right);
				this._frozen = frozen;
			}

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000C8D0 File Offset: 0x0000AAD0
			public bool IsEmpty
			{
				get
				{
					return this._left == null;
				}
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000C8DB File Offset: 0x0000AADB
			public int Height
			{
				get
				{
					return (int)this._height;
				}
			}

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x060004DA RID: 1242 RVA: 0x0000C8E3 File Offset: 0x0000AAE3
			public ImmutableList<T>.Node Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000C8E3 File Offset: 0x0000AAE3
			IBinaryTree IBinaryTree.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060004DC RID: 1244 RVA: 0x0000C8EB File Offset: 0x0000AAEB
			public ImmutableList<T>.Node Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000C8EB File Offset: 0x0000AAEB
			IBinaryTree IBinaryTree.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x060004DE RID: 1246 RVA: 0x0000C8E3 File Offset: 0x0000AAE3
			IBinaryTree<T> IBinaryTree<!0>.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x060004DF RID: 1247 RVA: 0x0000C8EB File Offset: 0x0000AAEB
			IBinaryTree<T> IBinaryTree<!0>.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
			public T Value
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000C8FB File Offset: 0x0000AAFB
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
			internal T Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x170000F6 RID: 246
			internal T this[int index]
			{
				get
				{
					Requires.Range(index >= 0 && index < this.Count, "index", null);
					if (index < this._left._count)
					{
						return this._left[index];
					}
					if (index > this._left._count)
					{
						return this._right[index - this._left._count - 1];
					}
					return this._key;
				}
			}

			// Token: 0x060004E4 RID: 1252 RVA: 0x0000C976 File Offset: 0x0000AB76
			public ImmutableList<T>.Enumerator GetEnumerator()
			{
				return new ImmutableList<T>.Enumerator(this, null, -1, -1, false);
			}

			// Token: 0x060004E5 RID: 1253 RVA: 0x0000C982 File Offset: 0x0000AB82
			[ExcludeFromCodeCoverage]
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060004E6 RID: 1254 RVA: 0x0000C982 File Offset: 0x0000AB82
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060004E7 RID: 1255 RVA: 0x0000C98F File Offset: 0x0000AB8F
			internal ImmutableList<T>.Enumerator GetEnumerator(ImmutableList<T>.Builder builder)
			{
				return new ImmutableList<T>.Enumerator(this, builder, -1, -1, false);
			}

			// Token: 0x060004E8 RID: 1256 RVA: 0x0000C99C File Offset: 0x0000AB9C
			internal static ImmutableList<T>.Node NodeTreeFromList(IOrderedCollection<T> items, int start, int length)
			{
				Requires.NotNull<IOrderedCollection<T>>(items, "items");
				Requires.Range(start >= 0, "start", null);
				Requires.Range(length >= 0, "length", null);
				if (length == 0)
				{
					return ImmutableList<T>.Node.EmptyNode;
				}
				int num = (length - 1) / 2;
				int num2 = length - 1 - num;
				ImmutableList<T>.Node left = ImmutableList<T>.Node.NodeTreeFromList(items, start, num2);
				ImmutableList<T>.Node right = ImmutableList<T>.Node.NodeTreeFromList(items, start + num2 + 1, num);
				return new ImmutableList<T>.Node(items[start + num2], left, right, true);
			}

			// Token: 0x060004E9 RID: 1257 RVA: 0x0000CA14 File Offset: 0x0000AC14
			internal ImmutableList<T>.Node Add(T key)
			{
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateLeaf(key);
				}
				ImmutableList<T>.Node right = this._right.Add(key);
				ImmutableList<T>.Node node = this.MutateRight(right);
				if (!node.IsBalanced)
				{
					return node.BalanceRight();
				}
				return node;
			}

			// Token: 0x060004EA RID: 1258 RVA: 0x0000CA58 File Offset: 0x0000AC58
			internal ImmutableList<T>.Node Insert(int index, T key)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateLeaf(key);
				}
				if (index <= this._left._count)
				{
					ImmutableList<T>.Node left = this._left.Insert(index, key);
					ImmutableList<T>.Node node = this.MutateLeft(left);
					if (!node.IsBalanced)
					{
						return node.BalanceLeft();
					}
					return node;
				}
				else
				{
					ImmutableList<T>.Node right = this._right.Insert(index - this._left._count - 1, key);
					ImmutableList<T>.Node node2 = this.MutateRight(right);
					if (!node2.IsBalanced)
					{
						return node2.BalanceRight();
					}
					return node2;
				}
			}

			// Token: 0x060004EB RID: 1259 RVA: 0x0000CAFC File Offset: 0x0000ACFC
			internal ImmutableList<T>.Node AddRange(IEnumerable<T> keys)
			{
				Requires.NotNull<IEnumerable<T>>(keys, "keys");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateRange(keys);
				}
				ImmutableList<T>.Node right = this._right.AddRange(keys);
				ImmutableList<T>.Node node = this.MutateRight(right);
				return node.BalanceMany();
			}

			// Token: 0x060004EC RID: 1260 RVA: 0x0000CB40 File Offset: 0x0000AD40
			internal ImmutableList<T>.Node InsertRange(int index, IEnumerable<T> keys)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				Requires.NotNull<IEnumerable<T>>(keys, "keys");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Node.CreateRange(keys);
				}
				ImmutableList<T>.Node node;
				if (index <= this._left._count)
				{
					ImmutableList<T>.Node left = this._left.InsertRange(index, keys);
					node = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right = this._right.InsertRange(index - this._left._count - 1, keys);
					node = this.MutateRight(right);
				}
				return node.BalanceMany();
			}

			// Token: 0x060004ED RID: 1261 RVA: 0x0000CBD8 File Offset: 0x0000ADD8
			internal ImmutableList<T>.Node RemoveAt(int index)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				ImmutableList<T>.Node node;
				if (index == this._left._count)
				{
					if (this._right.IsEmpty && this._left.IsEmpty)
					{
						node = ImmutableList<T>.Node.EmptyNode;
					}
					else if (this._right.IsEmpty && !this._left.IsEmpty)
					{
						node = this._left;
					}
					else if (!this._right.IsEmpty && this._left.IsEmpty)
					{
						node = this._right;
					}
					else
					{
						ImmutableList<T>.Node node2 = this._right;
						while (!node2._left.IsEmpty)
						{
							node2 = node2._left;
						}
						ImmutableList<T>.Node right = this._right.RemoveAt(0);
						node = node2.MutateBoth(this._left, right);
					}
				}
				else if (index < this._left._count)
				{
					ImmutableList<T>.Node left = this._left.RemoveAt(index);
					node = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right2 = this._right.RemoveAt(index - this._left._count - 1);
					node = this.MutateRight(right2);
				}
				if (!node.IsEmpty && !node.IsBalanced)
				{
					return node.Balance();
				}
				return node;
			}

			// Token: 0x060004EE RID: 1262 RVA: 0x0000CD20 File Offset: 0x0000AF20
			internal ImmutableList<T>.Node RemoveAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				ImmutableList<T>.Node node = this;
				int num = 0;
				foreach (T obj in this)
				{
					if (match(obj))
					{
						node = node.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
				return node;
			}

			// Token: 0x060004EF RID: 1263 RVA: 0x0000CD90 File Offset: 0x0000AF90
			internal ImmutableList<T>.Node ReplaceAt(int index, T value)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				ImmutableList<T>.Node result;
				if (index == this._left._count)
				{
					result = this.MutateKey(value);
				}
				else if (index < this._left._count)
				{
					ImmutableList<T>.Node left = this._left.ReplaceAt(index, value);
					result = this.MutateLeft(left);
				}
				else
				{
					ImmutableList<T>.Node right = this._right.ReplaceAt(index - this._left._count - 1, value);
					result = this.MutateRight(right);
				}
				return result;
			}

			// Token: 0x060004F0 RID: 1264 RVA: 0x0000CE1D File Offset: 0x0000B01D
			internal ImmutableList<T>.Node Reverse()
			{
				return this.Reverse(0, this.Count);
			}

			// Token: 0x060004F1 RID: 1265 RVA: 0x0000CE2C File Offset: 0x0000B02C
			internal ImmutableList<T>.Node Reverse(int index, int count)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "index", null);
				ImmutableList<T>.Node node = this;
				int i = index;
				int num = index + count - 1;
				while (i < num)
				{
					T value = node[i];
					T value2 = node[num];
					node = node.ReplaceAt(num, value).ReplaceAt(i, value2);
					i++;
					num--;
				}
				return node;
			}

			// Token: 0x060004F2 RID: 1266 RVA: 0x0000CEB1 File Offset: 0x0000B0B1
			internal ImmutableList<T>.Node Sort()
			{
				return this.Sort(Comparer<T>.Default);
			}

			// Token: 0x060004F3 RID: 1267 RVA: 0x0000CEC0 File Offset: 0x0000B0C0
			internal ImmutableList<T>.Node Sort(Comparison<T> comparison)
			{
				Requires.NotNull<Comparison<T>>(comparison, "comparison");
				T[] array = new T[this.Count];
				this.CopyTo(array);
				Array.Sort<T>(array, comparison);
				return ImmutableList<T>.Node.NodeTreeFromList(array.AsOrderedCollection<T>(), 0, this.Count);
			}

			// Token: 0x060004F4 RID: 1268 RVA: 0x0000CF04 File Offset: 0x0000B104
			internal ImmutableList<T>.Node Sort(IComparer<T> comparer)
			{
				return this.Sort(0, this.Count, comparer);
			}

			// Token: 0x060004F5 RID: 1269 RVA: 0x0000CF14 File Offset: 0x0000B114
			internal ImmutableList<T>.Node Sort(int index, int count, IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Argument(index + count <= this.Count);
				T[] array = new T[this.Count];
				this.CopyTo(array);
				Array.Sort<T>(array, index, count, comparer);
				return ImmutableList<T>.Node.NodeTreeFromList(array.AsOrderedCollection<T>(), 0, this.Count);
			}

			// Token: 0x060004F6 RID: 1270 RVA: 0x0000CF88 File Offset: 0x0000B188
			internal int BinarySearch(int index, int count, T item, IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				comparer = (comparer ?? Comparer<T>.Default);
				if (this.IsEmpty || count <= 0)
				{
					return ~index;
				}
				int count2 = this._left.Count;
				if (index + count <= count2)
				{
					return this._left.BinarySearch(index, count, item, comparer);
				}
				if (index > count2)
				{
					int num = this._right.BinarySearch(index - count2 - 1, count, item, comparer);
					int num2 = count2 + 1;
					if (num >= 0)
					{
						return num + num2;
					}
					return num - num2;
				}
				else
				{
					int num3 = comparer.Compare(item, this._key);
					if (num3 == 0)
					{
						return count2;
					}
					if (num3 > 0)
					{
						int num4 = count - (count2 - index) - 1;
						int num5 = (num4 < 0) ? -1 : this._right.BinarySearch(0, num4, item, comparer);
						int num6 = count2 + 1;
						if (num5 >= 0)
						{
							return num5 + num6;
						}
						return num5 - num6;
					}
					else
					{
						if (index == count2)
						{
							return ~index;
						}
						return this._left.BinarySearch(index, count, item, comparer);
					}
				}
			}

			// Token: 0x060004F7 RID: 1271 RVA: 0x0000D08E File Offset: 0x0000B28E
			internal int IndexOf(T item, IEqualityComparer<T> equalityComparer)
			{
				return this.IndexOf(item, 0, this.Count, equalityComparer);
			}

			// Token: 0x060004F8 RID: 1272 RVA: 0x0000D0A0 File Offset: 0x0000B2A0
			internal int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(count <= this.Count, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, false))
				{
					while (enumerator.MoveNext())
					{
						if (equalityComparer.Equals(item, enumerator.Current))
						{
							return index;
						}
						index++;
					}
				}
				return -1;
			}

			// Token: 0x060004F9 RID: 1273 RVA: 0x0000D164 File Offset: 0x0000B364
			internal int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0 && count <= this.Count, "count", null);
				Requires.Argument(index - count + 1 >= 0);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, true))
				{
					while (enumerator.MoveNext())
					{
						if (equalityComparer.Equals(item, enumerator.Current))
						{
							return index;
						}
						index--;
					}
				}
				return -1;
			}

			// Token: 0x060004FA RID: 1274 RVA: 0x0000D214 File Offset: 0x0000B414
			internal void CopyTo(T[] array)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Argument(array.Length >= this.Count);
				int num = 0;
				foreach (T t in this)
				{
					array[num++] = t;
				}
			}

			// Token: 0x060004FB RID: 1275 RVA: 0x0000D288 File Offset: 0x0000B488
			internal void CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(arrayIndex <= array.Length, "arrayIndex", null);
				Requires.Argument(arrayIndex + this.Count <= array.Length);
				foreach (T t in this)
				{
					array[arrayIndex++] = t;
				}
			}

			// Token: 0x060004FC RID: 1276 RVA: 0x0000D324 File Offset: 0x0000B524
			internal void CopyTo(int index, T[] array, int arrayIndex, int count)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Range(index + count <= this.Count, "count", null);
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(arrayIndex + count <= array.Length, "arrayIndex", null);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, index, count, false))
				{
					while (enumerator.MoveNext())
					{
						T t = enumerator.Current;
						array[arrayIndex++] = t;
					}
				}
			}

			// Token: 0x060004FD RID: 1277 RVA: 0x0000D3F0 File Offset: 0x0000B5F0
			internal void CopyTo(Array array, int arrayIndex)
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

			// Token: 0x060004FE RID: 1278 RVA: 0x0000D490 File Offset: 0x0000B690
			internal ImmutableList<TOutput>.Node ConvertAll<TOutput>(Func<T, TOutput> converter)
			{
				ImmutableList<TOutput>.Node emptyNode = ImmutableList<TOutput>.Node.EmptyNode;
				if (this.IsEmpty)
				{
					return emptyNode;
				}
				return emptyNode.AddRange(this.Select(converter));
			}

			// Token: 0x060004FF RID: 1279 RVA: 0x0000D4BC File Offset: 0x0000B6BC
			internal bool TrueForAll(Predicate<T> match)
			{
				foreach (T obj in this)
				{
					if (!match(obj))
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x06000500 RID: 1280 RVA: 0x0000D514 File Offset: 0x0000B714
			internal bool Exists(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				foreach (T obj in this)
				{
					if (match(obj))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000501 RID: 1281 RVA: 0x0000D578 File Offset: 0x0000B778
			internal T Find(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				foreach (T t in this)
				{
					if (match(t))
					{
						return t;
					}
				}
				return default(T);
			}

			// Token: 0x06000502 RID: 1282 RVA: 0x0000D5E4 File Offset: 0x0000B7E4
			internal ImmutableList<T> FindAll(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				if (this.IsEmpty)
				{
					return ImmutableList<T>.Empty;
				}
				List<T> list = null;
				foreach (T t in this)
				{
					if (match(t))
					{
						if (list == null)
						{
							list = new List<T>();
						}
						list.Add(t);
					}
				}
				if (list == null)
				{
					return ImmutableList<T>.Empty;
				}
				return ImmutableList.CreateRange<T>(list);
			}

			// Token: 0x06000503 RID: 1283 RVA: 0x0000D670 File Offset: 0x0000B870
			internal int FindIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				return this.FindIndex(0, this._count, match);
			}

			// Token: 0x06000504 RID: 1284 RVA: 0x0000D68C File Offset: 0x0000B88C
			internal int FindIndex(int startIndex, Predicate<T> match)
			{
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(startIndex <= this.Count, "startIndex", null);
				Requires.NotNull<Predicate<T>>(match, "match");
				return this.FindIndex(startIndex, this.Count - startIndex, match);
			}

			// Token: 0x06000505 RID: 1285 RVA: 0x0000D6E0 File Offset: 0x0000B8E0
			internal int FindIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count >= 0, "count", null);
				Requires.Argument(startIndex + count <= this.Count);
				Requires.NotNull<Predicate<T>>(match, "match");
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, startIndex, count, false))
				{
					int num = startIndex;
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return num;
						}
						num++;
					}
				}
				return -1;
			}

			// Token: 0x06000506 RID: 1286 RVA: 0x0000D784 File Offset: 0x0000B984
			internal T FindLast(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, -1, -1, true))
				{
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return enumerator.Current;
						}
					}
				}
				return default(T);
			}

			// Token: 0x06000507 RID: 1287 RVA: 0x0000D7F8 File Offset: 0x0000B9F8
			internal int FindLastIndex(Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				if (this.IsEmpty)
				{
					return -1;
				}
				return this.FindLastIndex(this.Count - 1, this.Count, match);
			}

			// Token: 0x06000508 RID: 1288 RVA: 0x0000D824 File Offset: 0x0000BA24
			internal int FindLastIndex(int startIndex, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(startIndex == 0 || startIndex < this.Count, "startIndex", null);
				if (this.IsEmpty)
				{
					return -1;
				}
				return this.FindLastIndex(startIndex, startIndex + 1, match);
			}

			// Token: 0x06000509 RID: 1289 RVA: 0x0000D880 File Offset: 0x0000BA80
			internal int FindLastIndex(int startIndex, int count, Predicate<T> match)
			{
				Requires.NotNull<Predicate<T>>(match, "match");
				Requires.Range(startIndex >= 0, "startIndex", null);
				Requires.Range(count <= this.Count, "count", null);
				Requires.Argument(startIndex - count + 1 >= 0);
				using (ImmutableList<T>.Enumerator enumerator = new ImmutableList<T>.Enumerator(this, null, startIndex, count, true))
				{
					int num = startIndex;
					while (enumerator.MoveNext())
					{
						if (match(enumerator.Current))
						{
							return num;
						}
						num--;
					}
				}
				return -1;
			}

			// Token: 0x0600050A RID: 1290 RVA: 0x0000D924 File Offset: 0x0000BB24
			internal void Freeze()
			{
				if (!this._frozen)
				{
					this._left.Freeze();
					this._right.Freeze();
					this._frozen = true;
				}
			}

			// Token: 0x0600050B RID: 1291 RVA: 0x0000D94B File Offset: 0x0000BB4B
			private ImmutableList<T>.Node RotateLeft()
			{
				return this._right.MutateLeft(this.MutateRight(this._right._left));
			}

			// Token: 0x0600050C RID: 1292 RVA: 0x0000D969 File Offset: 0x0000BB69
			private ImmutableList<T>.Node RotateRight()
			{
				return this._left.MutateRight(this.MutateLeft(this._left._right));
			}

			// Token: 0x0600050D RID: 1293 RVA: 0x0000D988 File Offset: 0x0000BB88
			private ImmutableList<T>.Node DoubleLeft()
			{
				ImmutableList<T>.Node right = this._right;
				ImmutableList<T>.Node left = right._left;
				return left.MutateBoth(this.MutateRight(left._left), right.MutateLeft(left._right));
			}

			// Token: 0x0600050E RID: 1294 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
			private ImmutableList<T>.Node DoubleRight()
			{
				ImmutableList<T>.Node left = this._left;
				ImmutableList<T>.Node right = left._right;
				return right.MutateBoth(left.MutateRight(right._left), this.MutateLeft(right._right));
			}

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x0600050F RID: 1295 RVA: 0x0000D9FD File Offset: 0x0000BBFD
			private int BalanceFactor
			{
				get
				{
					return (int)(this._right._height - this._left._height);
				}
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x06000510 RID: 1296 RVA: 0x0000DA16 File Offset: 0x0000BC16
			private bool IsRightHeavy
			{
				get
				{
					return this.BalanceFactor >= 2;
				}
			}

			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x06000511 RID: 1297 RVA: 0x0000DA24 File Offset: 0x0000BC24
			private bool IsLeftHeavy
			{
				get
				{
					return this.BalanceFactor <= -2;
				}
			}

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x06000512 RID: 1298 RVA: 0x0000DA33 File Offset: 0x0000BC33
			private bool IsBalanced
			{
				get
				{
					return this.BalanceFactor + 1 <= 2;
				}
			}

			// Token: 0x06000513 RID: 1299 RVA: 0x0000DA43 File Offset: 0x0000BC43
			private ImmutableList<T>.Node Balance()
			{
				if (!this.IsLeftHeavy)
				{
					return this.BalanceRight();
				}
				return this.BalanceLeft();
			}

			// Token: 0x06000514 RID: 1300 RVA: 0x0000DA5A File Offset: 0x0000BC5A
			private ImmutableList<T>.Node BalanceLeft()
			{
				if (this._left.BalanceFactor <= 0)
				{
					return this.RotateRight();
				}
				return this.DoubleRight();
			}

			// Token: 0x06000515 RID: 1301 RVA: 0x0000DA77 File Offset: 0x0000BC77
			private ImmutableList<T>.Node BalanceRight()
			{
				if (this._right.BalanceFactor >= 0)
				{
					return this.RotateLeft();
				}
				return this.DoubleLeft();
			}

			// Token: 0x06000516 RID: 1302 RVA: 0x0000DA94 File Offset: 0x0000BC94
			private ImmutableList<T>.Node BalanceMany()
			{
				ImmutableList<T>.Node node = this;
				while (!node.IsBalanced)
				{
					if (node.IsRightHeavy)
					{
						node = node.BalanceRight();
						node.MutateLeft(node._left.BalanceMany());
					}
					else
					{
						node = node.BalanceLeft();
						node.MutateRight(node._right.BalanceMany());
					}
				}
				return node;
			}

			// Token: 0x06000517 RID: 1303 RVA: 0x0000DAEC File Offset: 0x0000BCEC
			private ImmutableList<T>.Node MutateBoth(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, left, right, false);
				}
				this._left = left;
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(left, right);
				this._count = ImmutableList<T>.Node.ParentCount(left, right);
				return this;
			}

			// Token: 0x06000518 RID: 1304 RVA: 0x0000DB50 File Offset: 0x0000BD50
			private ImmutableList<T>.Node MutateLeft(ImmutableList<T>.Node left)
			{
				Requires.NotNull<ImmutableList<T>.Node>(left, "left");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, left, this._right, false);
				}
				this._left = left;
				this._height = ImmutableList<T>.Node.ParentHeight(left, this._right);
				this._count = ImmutableList<T>.Node.ParentCount(left, this._right);
				return this;
			}

			// Token: 0x06000519 RID: 1305 RVA: 0x0000DBB0 File Offset: 0x0000BDB0
			private ImmutableList<T>.Node MutateRight(ImmutableList<T>.Node right)
			{
				Requires.NotNull<ImmutableList<T>.Node>(right, "right");
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(this._key, this._left, right, false);
				}
				this._right = right;
				this._height = ImmutableList<T>.Node.ParentHeight(this._left, right);
				this._count = ImmutableList<T>.Node.ParentCount(this._left, right);
				return this;
			}

			// Token: 0x0600051A RID: 1306 RVA: 0x0000DC10 File Offset: 0x0000BE10
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static byte ParentHeight(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				return checked(1 + Math.Max(left._height, right._height));
			}

			// Token: 0x0600051B RID: 1307 RVA: 0x0000DC26 File Offset: 0x0000BE26
			private static int ParentCount(ImmutableList<T>.Node left, ImmutableList<T>.Node right)
			{
				return 1 + left._count + right._count;
			}

			// Token: 0x0600051C RID: 1308 RVA: 0x0000DC37 File Offset: 0x0000BE37
			private ImmutableList<T>.Node MutateKey(T key)
			{
				if (this._frozen)
				{
					return new ImmutableList<T>.Node(key, this._left, this._right, false);
				}
				this._key = key;
				return this;
			}

			// Token: 0x0600051D RID: 1309 RVA: 0x0000DC60 File Offset: 0x0000BE60
			private static ImmutableList<T>.Node CreateRange(IEnumerable<T> keys)
			{
				ImmutableList<T> immutableList;
				if (ImmutableList<T>.TryCastToImmutableList(keys, out immutableList))
				{
					return immutableList._root;
				}
				IOrderedCollection<T> orderedCollection = keys.AsOrderedCollection<T>();
				return ImmutableList<T>.Node.NodeTreeFromList(orderedCollection, 0, orderedCollection.Count);
			}

			// Token: 0x0600051E RID: 1310 RVA: 0x0000DC92 File Offset: 0x0000BE92
			private static ImmutableList<T>.Node CreateLeaf(T key)
			{
				return new ImmutableList<T>.Node(key, ImmutableList<T>.Node.EmptyNode, ImmutableList<T>.Node.EmptyNode, false);
			}

			// Token: 0x040000B2 RID: 178
			internal static readonly ImmutableList<T>.Node EmptyNode = new ImmutableList<T>.Node();

			// Token: 0x040000B3 RID: 179
			private T _key;

			// Token: 0x040000B4 RID: 180
			private bool _frozen;

			// Token: 0x040000B5 RID: 181
			private byte _height;

			// Token: 0x040000B6 RID: 182
			private int _count;

			// Token: 0x040000B7 RID: 183
			private ImmutableList<T>.Node _left;

			// Token: 0x040000B8 RID: 184
			private ImmutableList<T>.Node _right;
		}
	}
}
