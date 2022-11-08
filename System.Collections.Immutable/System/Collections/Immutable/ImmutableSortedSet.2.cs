using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x0200002F RID: 47
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableSortedSet<T> : IImmutableSet<!0>, IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, ISortKeyCollection<T>, IReadOnlyList<!0>, IList<!0>, ICollection<!0>, ISet<!0>, IList, ICollection, IStrongEnumerable<T, ImmutableSortedSet<T>.Enumerator>
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x00007E5D File Offset: 0x0000605D
		internal ImmutableSortedSet(IComparer<T> comparer = null)
		{
			this._root = ImmutableSortedSet<T>.Node.EmptyNode;
			this._comparer = (comparer ?? Comparer<T>.Default);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00007E80 File Offset: 0x00006080
		private ImmutableSortedSet(ImmutableSortedSet<T>.Node root, IComparer<T> comparer)
		{
			Requires.NotNull<ImmutableSortedSet<T>.Node>(root, "root");
			Requires.NotNull<IComparer<T>>(comparer, "comparer");
			root.Freeze();
			this._root = root;
			this._comparer = comparer;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00007EB2 File Offset: 0x000060B2
		public ImmutableSortedSet<T> Clear()
		{
			if (!this._root.IsEmpty)
			{
				return ImmutableSortedSet<T>.Empty.WithComparer(this._comparer);
			}
			return this;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00007ED3 File Offset: 0x000060D3
		public T Max
		{
			get
			{
				return this._root.Max;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00007EE0 File Offset: 0x000060E0
		public T Min
		{
			get
			{
				return this._root.Min;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00007EED File Offset: 0x000060ED
		public bool IsEmpty
		{
			get
			{
				return this._root.IsEmpty;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x00007EFA File Offset: 0x000060FA
		public int Count
		{
			get
			{
				return this._root.Count;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00007F07 File Offset: 0x00006107
		public IComparer<T> KeyComparer
		{
			get
			{
				return this._comparer;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00007F0F File Offset: 0x0000610F
		internal IBinaryTree Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x1700007C RID: 124
		public T this[int index]
		{
			get
			{
				return this._root[index];
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00007F25 File Offset: 0x00006125
		public ImmutableSortedSet<T>.Builder ToBuilder()
		{
			return new ImmutableSortedSet<T>.Builder(this);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00007F30 File Offset: 0x00006130
		public ImmutableSortedSet<T> Add(T value)
		{
			Requires.NotNullAllowStructs<T>(value, "value");
			bool flag;
			return this.Wrap(this._root.Add(value, this._comparer, out flag));
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00007F64 File Offset: 0x00006164
		public ImmutableSortedSet<T> Remove(T value)
		{
			Requires.NotNullAllowStructs<T>(value, "value");
			bool flag;
			return this.Wrap(this._root.Remove(value, this._comparer, out flag));
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00007F98 File Offset: 0x00006198
		public bool TryGetValue(T equalValue, out T actualValue)
		{
			Requires.NotNullAllowStructs<T>(equalValue, "equalValue");
			ImmutableSortedSet<T>.Node node = this._root.Search(equalValue, this._comparer);
			if (node.IsEmpty)
			{
				actualValue = equalValue;
				return false;
			}
			actualValue = node.Key;
			return true;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00007FE4 File Offset: 0x000061E4
		public ImmutableSortedSet<T> Intersect(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableSortedSet<T> immutableSortedSet = this.Clear();
			foreach (T value in other.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				if (this.Contains(value))
				{
					immutableSortedSet = immutableSortedSet.Add(value);
				}
			}
			return immutableSortedSet;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00008058 File Offset: 0x00006258
		public ImmutableSortedSet<T> Except(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableSortedSet<T>.Node node = this._root;
			foreach (T key in other.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				bool flag;
				node = node.Remove(key, this._comparer, out flag);
			}
			return this.Wrap(node);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000080D0 File Offset: 0x000062D0
		public ImmutableSortedSet<T> SymmetricExcept(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableSortedSet<T> immutableSortedSet = ImmutableSortedSet.CreateRange<T>(this._comparer, other);
			ImmutableSortedSet<T> immutableSortedSet2 = this.Clear();
			foreach (T value in this)
			{
				if (!immutableSortedSet.Contains(value))
				{
					immutableSortedSet2 = immutableSortedSet2.Add(value);
				}
			}
			foreach (T value2 in immutableSortedSet)
			{
				if (!this.Contains(value2))
				{
					immutableSortedSet2 = immutableSortedSet2.Add(value2);
				}
			}
			return immutableSortedSet2;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00008194 File Offset: 0x00006394
		public ImmutableSortedSet<T> Union(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			ImmutableSortedSet<T> immutableSortedSet;
			if (ImmutableSortedSet<T>.TryCastToImmutableSortedSet(other, out immutableSortedSet) && immutableSortedSet.KeyComparer == this.KeyComparer)
			{
				if (immutableSortedSet.IsEmpty)
				{
					return this;
				}
				if (this.IsEmpty)
				{
					return immutableSortedSet;
				}
				if (immutableSortedSet.Count > this.Count)
				{
					return immutableSortedSet.Union(this);
				}
			}
			int num;
			if (this.IsEmpty || (other.TryGetCount(out num) && (float)(this.Count + num) * 0.15f > (float)this.Count))
			{
				return this.LeafToRootRefill(other);
			}
			return this.UnionIncremental(other);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00008228 File Offset: 0x00006428
		public ImmutableSortedSet<T> WithComparer(IComparer<T> comparer)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			if (comparer == this._comparer)
			{
				return this;
			}
			ImmutableSortedSet<T> immutableSortedSet = new ImmutableSortedSet<T>(ImmutableSortedSet<T>.Node.EmptyNode, comparer);
			return immutableSortedSet.Union(this);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00008260 File Offset: 0x00006460
		public bool SetEquals(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (this == other)
			{
				return true;
			}
			SortedSet<T> sortedSet = new SortedSet<T>(other, this.KeyComparer);
			if (this.Count != sortedSet.Count)
			{
				return false;
			}
			int num = 0;
			foreach (T value in sortedSet)
			{
				if (!this.Contains(value))
				{
					return false;
				}
				num++;
			}
			return num == this.Count;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000082F8 File Offset: 0x000064F8
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (this.IsEmpty)
			{
				return other.Any<T>();
			}
			SortedSet<T> sortedSet = new SortedSet<T>(other, this.KeyComparer);
			if (this.Count >= sortedSet.Count)
			{
				return false;
			}
			int num = 0;
			bool flag = false;
			foreach (T value in sortedSet)
			{
				if (this.Contains(value))
				{
					num++;
				}
				else
				{
					flag = true;
				}
				if (num == this.Count && flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000083A4 File Offset: 0x000065A4
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (this.IsEmpty)
			{
				return false;
			}
			int num = 0;
			foreach (T value in other.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				num++;
				if (!this.Contains(value))
				{
					return false;
				}
			}
			return this.Count > num;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00008428 File Offset: 0x00006628
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (this.IsEmpty)
			{
				return true;
			}
			SortedSet<T> sortedSet = new SortedSet<T>(other, this.KeyComparer);
			int num = 0;
			foreach (T value in sortedSet)
			{
				if (this.Contains(value))
				{
					num++;
				}
			}
			return num == this.Count;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000084AC File Offset: 0x000066AC
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			foreach (T value in other.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				if (!this.Contains(value))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00008518 File Offset: 0x00006718
		public bool Overlaps(IEnumerable<T> other)
		{
			Requires.NotNull<IEnumerable<T>>(other, "other");
			if (this.IsEmpty)
			{
				return false;
			}
			foreach (T value in other.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				if (this.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000858C File Offset: 0x0000678C
		public IEnumerable<T> Reverse()
		{
			return new ImmutableSortedSet<T>.ReverseEnumerable(this._root);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00008599 File Offset: 0x00006799
		public int IndexOf(T item)
		{
			Requires.NotNullAllowStructs<T>(item, "item");
			return this._root.IndexOf(item, this._comparer);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000085B8 File Offset: 0x000067B8
		public bool Contains(T value)
		{
			Requires.NotNullAllowStructs<T>(value, "value");
			return this._root.Contains(value, this._comparer);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000085D7 File Offset: 0x000067D7
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000085DF File Offset: 0x000067DF
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Add(T value)
		{
			return this.Add(value);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000085E8 File Offset: 0x000067E8
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Remove(T value)
		{
			return this.Remove(value);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000085F1 File Offset: 0x000067F1
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Intersect(IEnumerable<T> other)
		{
			return this.Intersect(other);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000085FA File Offset: 0x000067FA
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Except(IEnumerable<T> other)
		{
			return this.Except(other);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00008603 File Offset: 0x00006803
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.SymmetricExcept(IEnumerable<T> other)
		{
			return this.SymmetricExcept(other);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000860C File Offset: 0x0000680C
		[ExcludeFromCodeCoverage]
		IImmutableSet<T> IImmutableSet<!0>.Union(IEnumerable<T> other)
		{
			return this.Union(other);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000317B File Offset: 0x0000137B
		bool ISet<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.ExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.IntersectWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.SymmetricExceptWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000317B File Offset: 0x0000137B
		void ISet<!0>.UnionWith(IEnumerable<T> other)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00003182 File Offset: 0x00001382
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00008615 File Offset: 0x00006815
		void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
		{
			this._root.CopyTo(array, arrayIndex);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700007E RID: 126
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

		// Token: 0x06000300 RID: 768 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00003182 File Offset: 0x00001382
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00003182 File Offset: 0x00001382
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000317B File Offset: 0x0000137B
		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000862D File Offset: 0x0000682D
		bool IList.Contains(object value)
		{
			return this.Contains((T)((object)value));
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000863B File Offset: 0x0000683B
		int IList.IndexOf(object value)
		{
			return this.IndexOf((T)((object)value));
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000317B File Offset: 0x0000137B
		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000083 RID: 131
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

		// Token: 0x0600030F RID: 783 RVA: 0x00008657 File Offset: 0x00006857
		void ICollection.CopyTo(Array array, int index)
		{
			this._root.CopyTo(array, index);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00008666 File Offset: 0x00006866
		[ExcludeFromCodeCoverage]
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00008666 File Offset: 0x00006866
		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00008673 File Offset: 0x00006873
		public ImmutableSortedSet<T>.Enumerator GetEnumerator()
		{
			return this._root.GetEnumerator();
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00008680 File Offset: 0x00006880
		private static bool TryCastToImmutableSortedSet(IEnumerable<T> sequence, out ImmutableSortedSet<T> other)
		{
			other = (sequence as ImmutableSortedSet<T>);
			if (other != null)
			{
				return true;
			}
			ImmutableSortedSet<T>.Builder builder = sequence as ImmutableSortedSet<T>.Builder;
			if (builder != null)
			{
				other = builder.ToImmutable();
				return true;
			}
			return false;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000086B0 File Offset: 0x000068B0
		private static ImmutableSortedSet<T> Wrap(ImmutableSortedSet<T>.Node root, IComparer<T> comparer)
		{
			if (!root.IsEmpty)
			{
				return new ImmutableSortedSet<T>(root, comparer);
			}
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000086D0 File Offset: 0x000068D0
		private ImmutableSortedSet<T> UnionIncremental(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			ImmutableSortedSet<T>.Node node = this._root;
			foreach (T key in items.GetEnumerableDisposable<T, ImmutableSortedSet<T>.Enumerator>())
			{
				bool flag;
				node = node.Add(key, this._comparer, out flag);
			}
			return this.Wrap(node);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00008748 File Offset: 0x00006948
		private ImmutableSortedSet<T> Wrap(ImmutableSortedSet<T>.Node root)
		{
			if (root == this._root)
			{
				return this;
			}
			if (!root.IsEmpty)
			{
				return new ImmutableSortedSet<T>(root, this._comparer);
			}
			return this.Clear();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00008770 File Offset: 0x00006970
		private ImmutableSortedSet<T> LeafToRootRefill(IEnumerable<T> addedItems)
		{
			Requires.NotNull<IEnumerable<T>>(addedItems, "addedItems");
			List<T> list;
			if (this.IsEmpty)
			{
				int num;
				if (addedItems.TryGetCount(out num) && num == 0)
				{
					return this;
				}
				list = new List<T>(addedItems);
				if (list.Count == 0)
				{
					return this;
				}
			}
			else
			{
				list = new List<T>(this);
				list.AddRange(addedItems);
			}
			IComparer<T> keyComparer = this.KeyComparer;
			list.Sort(keyComparer);
			int num2 = 1;
			for (int i = 1; i < list.Count; i++)
			{
				if (keyComparer.Compare(list[i], list[i - 1]) != 0)
				{
					list[num2++] = list[i];
				}
			}
			list.RemoveRange(num2, list.Count - num2);
			ImmutableSortedSet<T>.Node root = ImmutableSortedSet<T>.Node.NodeTreeFromList(list.AsOrderedCollection<T>(), 0, list.Count);
			return this.Wrap(root);
		}

		// Token: 0x0400002C RID: 44
		private const float RefillOverIncrementalThreshold = 0.15f;

		// Token: 0x0400002D RID: 45
		public static readonly ImmutableSortedSet<T> Empty = new ImmutableSortedSet<T>(null);

		// Token: 0x0400002E RID: 46
		private readonly ImmutableSortedSet<T>.Node _root;

		// Token: 0x0400002F RID: 47
		private readonly IComparer<T> _comparer;

		// Token: 0x02000066 RID: 102
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableSortedSetBuilderDebuggerProxy<>))]
		public sealed class Builder : ISortKeyCollection<T>, IReadOnlyCollection<!0>, IEnumerable<!0>, IEnumerable, ISet<!0>, ICollection<!0>, ICollection
		{
			// Token: 0x06000593 RID: 1427 RVA: 0x0000F15C File Offset: 0x0000D35C
			internal Builder(ImmutableSortedSet<T> set)
			{
				Requires.NotNull<ImmutableSortedSet<T>>(set, "set");
				this._root = set._root;
				this._comparer = set.KeyComparer;
				this._immutable = set;
			}

			// Token: 0x1700011F RID: 287
			// (get) Token: 0x06000594 RID: 1428 RVA: 0x0000F1AF File Offset: 0x0000D3AF
			public int Count
			{
				get
				{
					return this.Root.Count;
				}
			}

			// Token: 0x17000120 RID: 288
			// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000121 RID: 289
			public T this[int index]
			{
				get
				{
					return this._root[index];
				}
			}

			// Token: 0x17000122 RID: 290
			// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000F1CA File Offset: 0x0000D3CA
			public T Max
			{
				get
				{
					return this._root.Max;
				}
			}

			// Token: 0x17000123 RID: 291
			// (get) Token: 0x06000598 RID: 1432 RVA: 0x0000F1D7 File Offset: 0x0000D3D7
			public T Min
			{
				get
				{
					return this._root.Min;
				}
			}

			// Token: 0x17000124 RID: 292
			// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000F1E4 File Offset: 0x0000D3E4
			// (set) Token: 0x0600059A RID: 1434 RVA: 0x0000F1EC File Offset: 0x0000D3EC
			public IComparer<T> KeyComparer
			{
				get
				{
					return this._comparer;
				}
				set
				{
					Requires.NotNull<IComparer<T>>(value, "value");
					if (value != this._comparer)
					{
						ImmutableSortedSet<T>.Node node = ImmutableSortedSet<T>.Node.EmptyNode;
						foreach (T key in this)
						{
							bool flag;
							node = node.Add(key, value, out flag);
						}
						this._immutable = null;
						this._comparer = value;
						this.Root = node;
					}
				}
			}

			// Token: 0x17000125 RID: 293
			// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000F270 File Offset: 0x0000D470
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x17000126 RID: 294
			// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000F278 File Offset: 0x0000D478
			// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000F280 File Offset: 0x0000D480
			private ImmutableSortedSet<T>.Node Root
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

			// Token: 0x0600059E RID: 1438 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
			public bool Add(T item)
			{
				bool result;
				this.Root = this.Root.Add(item, this._comparer, out result);
				return result;
			}

			// Token: 0x0600059F RID: 1439 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
			public void ExceptWith(IEnumerable<T> other)
			{
				Requires.NotNull<IEnumerable<T>>(other, "other");
				foreach (T key in other)
				{
					bool flag;
					this.Root = this.Root.Remove(key, this._comparer, out flag);
				}
			}

			// Token: 0x060005A0 RID: 1440 RVA: 0x0000F338 File Offset: 0x0000D538
			public void IntersectWith(IEnumerable<T> other)
			{
				Requires.NotNull<IEnumerable<T>>(other, "other");
				ImmutableSortedSet<T>.Node node = ImmutableSortedSet<T>.Node.EmptyNode;
				foreach (T t in other)
				{
					if (this.Contains(t))
					{
						bool flag;
						node = node.Add(t, this._comparer, out flag);
					}
				}
				this.Root = node;
			}

			// Token: 0x060005A1 RID: 1441 RVA: 0x0000F3AC File Offset: 0x0000D5AC
			public bool IsProperSubsetOf(IEnumerable<T> other)
			{
				return this.ToImmutable().IsProperSubsetOf(other);
			}

			// Token: 0x060005A2 RID: 1442 RVA: 0x0000F3BA File Offset: 0x0000D5BA
			public bool IsProperSupersetOf(IEnumerable<T> other)
			{
				return this.ToImmutable().IsProperSupersetOf(other);
			}

			// Token: 0x060005A3 RID: 1443 RVA: 0x0000F3C8 File Offset: 0x0000D5C8
			public bool IsSubsetOf(IEnumerable<T> other)
			{
				return this.ToImmutable().IsSubsetOf(other);
			}

			// Token: 0x060005A4 RID: 1444 RVA: 0x0000F3D6 File Offset: 0x0000D5D6
			public bool IsSupersetOf(IEnumerable<T> other)
			{
				return this.ToImmutable().IsSupersetOf(other);
			}

			// Token: 0x060005A5 RID: 1445 RVA: 0x0000F3E4 File Offset: 0x0000D5E4
			public bool Overlaps(IEnumerable<T> other)
			{
				return this.ToImmutable().Overlaps(other);
			}

			// Token: 0x060005A6 RID: 1446 RVA: 0x0000F3F2 File Offset: 0x0000D5F2
			public bool SetEquals(IEnumerable<T> other)
			{
				return this.ToImmutable().SetEquals(other);
			}

			// Token: 0x060005A7 RID: 1447 RVA: 0x0000F400 File Offset: 0x0000D600
			public void SymmetricExceptWith(IEnumerable<T> other)
			{
				this.Root = this.ToImmutable().SymmetricExcept(other)._root;
			}

			// Token: 0x060005A8 RID: 1448 RVA: 0x0000F41C File Offset: 0x0000D61C
			public void UnionWith(IEnumerable<T> other)
			{
				Requires.NotNull<IEnumerable<T>>(other, "other");
				foreach (T key in other)
				{
					bool flag;
					this.Root = this.Root.Add(key, this._comparer, out flag);
				}
			}

			// Token: 0x060005A9 RID: 1449 RVA: 0x0000F484 File Offset: 0x0000D684
			void ICollection<!0>.Add(T item)
			{
				this.Add(item);
			}

			// Token: 0x060005AA RID: 1450 RVA: 0x0000F48E File Offset: 0x0000D68E
			public void Clear()
			{
				this.Root = ImmutableSortedSet<T>.Node.EmptyNode;
			}

			// Token: 0x060005AB RID: 1451 RVA: 0x0000F49B File Offset: 0x0000D69B
			public bool Contains(T item)
			{
				return this.Root.Contains(item, this._comparer);
			}

			// Token: 0x060005AC RID: 1452 RVA: 0x0000F4AF File Offset: 0x0000D6AF
			void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
			{
				this._root.CopyTo(array, arrayIndex);
			}

			// Token: 0x060005AD RID: 1453 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
			public bool Remove(T item)
			{
				bool result;
				this.Root = this.Root.Remove(item, this._comparer, out result);
				return result;
			}

			// Token: 0x060005AE RID: 1454 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
			public ImmutableSortedSet<T>.Enumerator GetEnumerator()
			{
				return this.Root.GetEnumerator(this);
			}

			// Token: 0x060005AF RID: 1455 RVA: 0x0000F4F6 File Offset: 0x0000D6F6
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.Root.GetEnumerator();
			}

			// Token: 0x060005B0 RID: 1456 RVA: 0x0000F508 File Offset: 0x0000D708
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060005B1 RID: 1457 RVA: 0x0000F515 File Offset: 0x0000D715
			public IEnumerable<T> Reverse()
			{
				return new ImmutableSortedSet<T>.ReverseEnumerable(this._root);
			}

			// Token: 0x060005B2 RID: 1458 RVA: 0x0000F522 File Offset: 0x0000D722
			public ImmutableSortedSet<T> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableSortedSet<T>.Wrap(this.Root, this._comparer);
				}
				return this._immutable;
			}

			// Token: 0x060005B3 RID: 1459 RVA: 0x0000F549 File Offset: 0x0000D749
			void ICollection.CopyTo(Array array, int arrayIndex)
			{
				this.Root.CopyTo(array, arrayIndex);
			}

			// Token: 0x17000127 RID: 295
			// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0000206B File Offset: 0x0000026B
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000128 RID: 296
			// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0000F558 File Offset: 0x0000D758
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

			// Token: 0x040000D7 RID: 215
			private ImmutableSortedSet<T>.Node _root = ImmutableSortedSet<T>.Node.EmptyNode;

			// Token: 0x040000D8 RID: 216
			private IComparer<T> _comparer = Comparer<T>.Default;

			// Token: 0x040000D9 RID: 217
			private ImmutableSortedSet<T> _immutable;

			// Token: 0x040000DA RID: 218
			private int _version;

			// Token: 0x040000DB RID: 219
			private object _syncRoot;
		}

		// Token: 0x02000067 RID: 103
		private class ReverseEnumerable : IEnumerable<!0>, IEnumerable
		{
			// Token: 0x060005B6 RID: 1462 RVA: 0x0000F57A File Offset: 0x0000D77A
			internal ReverseEnumerable(ImmutableSortedSet<T>.Node root)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(root, "root");
				this._root = root;
			}

			// Token: 0x060005B7 RID: 1463 RVA: 0x0000F594 File Offset: 0x0000D794
			public IEnumerator<T> GetEnumerator()
			{
				return this._root.Reverse();
			}

			// Token: 0x060005B8 RID: 1464 RVA: 0x0000F5A1 File Offset: 0x0000D7A1
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x040000DC RID: 220
			private readonly ImmutableSortedSet<T>.Node _root;
		}

		// Token: 0x02000068 RID: 104
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable, ISecurePooledObjectUser, IStrongEnumerator<T>
		{
			// Token: 0x060005B9 RID: 1465 RVA: 0x0000F5AC File Offset: 0x0000D7AC
			internal Enumerator(ImmutableSortedSet<T>.Node root, ImmutableSortedSet<T>.Builder builder = null, bool reverse = false)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(root, "root");
				this._root = root;
				this._builder = builder;
				this._current = null;
				this._reverse = reverse;
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
				this._poolUserId = SecureObjectPool.NewId();
				this._stack = null;
				if (!ImmutableSortedSet<T>.Enumerator.s_enumeratingStacks.TryTake(this, out this._stack))
				{
					this._stack = ImmutableSortedSet<T>.Enumerator.s_enumeratingStacks.PrepNew(this, new Stack<RefAsValueType<ImmutableSortedSet<T>.Node>>(root.Height));
				}
				this.PushNext(this._root);
			}

			// Token: 0x17000129 RID: 297
			// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000F649 File Offset: 0x0000D849
			int ISecurePooledObjectUser.PoolUserId
			{
				get
				{
					return this._poolUserId;
				}
			}

			// Token: 0x1700012A RID: 298
			// (get) Token: 0x060005BB RID: 1467 RVA: 0x0000F651 File Offset: 0x0000D851
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

			// Token: 0x1700012B RID: 299
			// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000F672 File Offset: 0x0000D872
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060005BD RID: 1469 RVA: 0x0000F680 File Offset: 0x0000D880
			public void Dispose()
			{
				this._root = null;
				this._current = null;
				Stack<RefAsValueType<ImmutableSortedSet<T>.Node>> stack;
				if (this._stack != null && this._stack.TryUse<ImmutableSortedSet<T>.Enumerator>(ref this, out stack))
				{
					stack.ClearFastWhenEmpty<RefAsValueType<ImmutableSortedSet<T>.Node>>();
					ImmutableSortedSet<T>.Enumerator.s_enumeratingStacks.TryAdd(this, this._stack);
					this._stack = null;
				}
			}

			// Token: 0x060005BE RID: 1470 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				this.ThrowIfChanged();
				Stack<RefAsValueType<ImmutableSortedSet<T>.Node>> stack = this._stack.Use<ImmutableSortedSet<T>.Enumerator>(ref this);
				if (stack.Count > 0)
				{
					ImmutableSortedSet<T>.Node value = stack.Pop().Value;
					this._current = value;
					this.PushNext(this._reverse ? value.Left : value.Right);
					return true;
				}
				this._current = null;
				return false;
			}

			// Token: 0x060005BF RID: 1471 RVA: 0x0000F740 File Offset: 0x0000D940
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._current = null;
				Stack<RefAsValueType<ImmutableSortedSet<T>.Node>> stack = this._stack.Use<ImmutableSortedSet<T>.Enumerator>(ref this);
				stack.ClearFastWhenEmpty<RefAsValueType<ImmutableSortedSet<T>.Node>>();
				this.PushNext(this._root);
			}

			// Token: 0x060005C0 RID: 1472 RVA: 0x0000F795 File Offset: 0x0000D995
			private void ThrowIfDisposed()
			{
				if (this._root == null || (this._stack != null && !this._stack.IsOwned<ImmutableSortedSet<T>.Enumerator>(ref this)))
				{
					Requires.FailObjectDisposed<ImmutableSortedSet<T>.Enumerator>(this);
				}
			}

			// Token: 0x060005C1 RID: 1473 RVA: 0x0000F7C0 File Offset: 0x0000D9C0
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x060005C2 RID: 1474 RVA: 0x0000F7E8 File Offset: 0x0000D9E8
			private void PushNext(ImmutableSortedSet<T>.Node node)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(node, "node");
				Stack<RefAsValueType<ImmutableSortedSet<T>.Node>> stack = this._stack.Use<ImmutableSortedSet<T>.Enumerator>(ref this);
				while (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<ImmutableSortedSet<T>.Node>(node));
					node = (this._reverse ? node.Right : node.Left);
				}
			}

			// Token: 0x040000DD RID: 221
			private static readonly SecureObjectPool<Stack<RefAsValueType<ImmutableSortedSet<T>.Node>>, ImmutableSortedSet<T>.Enumerator> s_enumeratingStacks = new SecureObjectPool<Stack<RefAsValueType<ImmutableSortedSet<T>.Node>>, ImmutableSortedSet<T>.Enumerator>();

			// Token: 0x040000DE RID: 222
			private readonly ImmutableSortedSet<T>.Builder _builder;

			// Token: 0x040000DF RID: 223
			private readonly int _poolUserId;

			// Token: 0x040000E0 RID: 224
			private readonly bool _reverse;

			// Token: 0x040000E1 RID: 225
			private ImmutableSortedSet<T>.Node _root;

			// Token: 0x040000E2 RID: 226
			private SecurePooledObject<Stack<RefAsValueType<ImmutableSortedSet<T>.Node>>> _stack;

			// Token: 0x040000E3 RID: 227
			private ImmutableSortedSet<T>.Node _current;

			// Token: 0x040000E4 RID: 228
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x02000069 RID: 105
		[DebuggerDisplay("{_key}")]
		internal sealed class Node : IBinaryTree<T>, IBinaryTree, IEnumerable<!0>, IEnumerable
		{
			// Token: 0x060005C4 RID: 1476 RVA: 0x0000F847 File Offset: 0x0000DA47
			private Node()
			{
				this._frozen = true;
			}

			// Token: 0x060005C5 RID: 1477 RVA: 0x0000F858 File Offset: 0x0000DA58
			private Node(T key, ImmutableSortedSet<T>.Node left, ImmutableSortedSet<T>.Node right, bool frozen = false)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<ImmutableSortedSet<T>.Node>(left, "left");
				Requires.NotNull<ImmutableSortedSet<T>.Node>(right, "right");
				this._key = key;
				this._left = left;
				this._right = right;
				this._height = checked(1 + Math.Max(left._height, right._height));
				this._count = 1 + left._count + right._count;
				this._frozen = frozen;
			}

			// Token: 0x1700012C RID: 300
			// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0000F8D8 File Offset: 0x0000DAD8
			public bool IsEmpty
			{
				get
				{
					return this._left == null;
				}
			}

			// Token: 0x1700012D RID: 301
			// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000F8E3 File Offset: 0x0000DAE3
			public int Height
			{
				get
				{
					return (int)this._height;
				}
			}

			// Token: 0x1700012E RID: 302
			// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0000F8EB File Offset: 0x0000DAEB
			public ImmutableSortedSet<T>.Node Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x1700012F RID: 303
			// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000F8EB File Offset: 0x0000DAEB
			IBinaryTree IBinaryTree.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x17000130 RID: 304
			// (get) Token: 0x060005CA RID: 1482 RVA: 0x0000F8F3 File Offset: 0x0000DAF3
			public ImmutableSortedSet<T>.Node Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x17000131 RID: 305
			// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000F8F3 File Offset: 0x0000DAF3
			IBinaryTree IBinaryTree.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x17000132 RID: 306
			// (get) Token: 0x060005CC RID: 1484 RVA: 0x0000F8EB File Offset: 0x0000DAEB
			IBinaryTree<T> IBinaryTree<!0>.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x17000133 RID: 307
			// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000F8F3 File Offset: 0x0000DAF3
			IBinaryTree<T> IBinaryTree<!0>.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x17000134 RID: 308
			// (get) Token: 0x060005CE RID: 1486 RVA: 0x0000F8FB File Offset: 0x0000DAFB
			public T Value
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x17000135 RID: 309
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000F903 File Offset: 0x0000DB03
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x17000136 RID: 310
			// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0000F8FB File Offset: 0x0000DAFB
			internal T Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x17000137 RID: 311
			// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000F90C File Offset: 0x0000DB0C
			internal T Max
			{
				get
				{
					if (this.IsEmpty)
					{
						return default(T);
					}
					ImmutableSortedSet<T>.Node node = this;
					while (!node._right.IsEmpty)
					{
						node = node._right;
					}
					return node._key;
				}
			}

			// Token: 0x17000138 RID: 312
			// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0000F94C File Offset: 0x0000DB4C
			internal T Min
			{
				get
				{
					if (this.IsEmpty)
					{
						return default(T);
					}
					ImmutableSortedSet<T>.Node node = this;
					while (!node._left.IsEmpty)
					{
						node = node._left;
					}
					return node._key;
				}
			}

			// Token: 0x17000139 RID: 313
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

			// Token: 0x060005D4 RID: 1492 RVA: 0x0000F9FE File Offset: 0x0000DBFE
			public ImmutableSortedSet<T>.Enumerator GetEnumerator()
			{
				return new ImmutableSortedSet<T>.Enumerator(this, null, false);
			}

			// Token: 0x060005D5 RID: 1493 RVA: 0x0000FA08 File Offset: 0x0000DC08
			[ExcludeFromCodeCoverage]
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060005D6 RID: 1494 RVA: 0x0000FA08 File Offset: 0x0000DC08
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060005D7 RID: 1495 RVA: 0x0000FA15 File Offset: 0x0000DC15
			internal ImmutableSortedSet<T>.Enumerator GetEnumerator(ImmutableSortedSet<T>.Builder builder)
			{
				return new ImmutableSortedSet<T>.Enumerator(this, builder, false);
			}

			// Token: 0x060005D8 RID: 1496 RVA: 0x0000FA20 File Offset: 0x0000DC20
			internal void CopyTo(T[] array, int arrayIndex)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (T t in this)
				{
					array[arrayIndex++] = t;
				}
			}

			// Token: 0x060005D9 RID: 1497 RVA: 0x0000FAAC File Offset: 0x0000DCAC
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

			// Token: 0x060005DA RID: 1498 RVA: 0x0000FB4C File Offset: 0x0000DD4C
			internal ImmutableSortedSet<T>.Node Add(T key, IComparer<T> comparer, out bool mutated)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<IComparer<T>>(comparer, "comparer");
				if (this.IsEmpty)
				{
					mutated = true;
					return new ImmutableSortedSet<T>.Node(key, this, this, false);
				}
				ImmutableSortedSet<T>.Node node = this;
				int num = comparer.Compare(key, this._key);
				if (num > 0)
				{
					ImmutableSortedSet<T>.Node right = this._right.Add(key, comparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(null, right);
					}
				}
				else
				{
					if (num >= 0)
					{
						mutated = false;
						return this;
					}
					ImmutableSortedSet<T>.Node left = this._left.Add(key, comparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(left, null);
					}
				}
				if (!mutated)
				{
					return node;
				}
				return ImmutableSortedSet<T>.Node.MakeBalanced(node);
			}

			// Token: 0x060005DB RID: 1499 RVA: 0x0000FBEC File Offset: 0x0000DDEC
			internal ImmutableSortedSet<T>.Node Remove(T key, IComparer<T> comparer, out bool mutated)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<IComparer<T>>(comparer, "comparer");
				if (this.IsEmpty)
				{
					mutated = false;
					return this;
				}
				ImmutableSortedSet<T>.Node node = this;
				int num = comparer.Compare(key, this._key);
				if (num == 0)
				{
					mutated = true;
					if (this._right.IsEmpty && this._left.IsEmpty)
					{
						node = ImmutableSortedSet<T>.Node.EmptyNode;
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
						ImmutableSortedSet<T>.Node node2 = this._right;
						while (!node2._left.IsEmpty)
						{
							node2 = node2._left;
						}
						bool flag;
						ImmutableSortedSet<T>.Node right = this._right.Remove(node2._key, comparer, out flag);
						node = node2.Mutate(this._left, right);
					}
				}
				else if (num < 0)
				{
					ImmutableSortedSet<T>.Node left = this._left.Remove(key, comparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(left, null);
					}
				}
				else
				{
					ImmutableSortedSet<T>.Node right2 = this._right.Remove(key, comparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(null, right2);
					}
				}
				if (!node.IsEmpty)
				{
					return ImmutableSortedSet<T>.Node.MakeBalanced(node);
				}
				return node;
			}

			// Token: 0x060005DC RID: 1500 RVA: 0x0000FD3C File Offset: 0x0000DF3C
			internal bool Contains(T key, IComparer<T> comparer)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<IComparer<T>>(comparer, "comparer");
				return !this.Search(key, comparer).IsEmpty;
			}

			// Token: 0x060005DD RID: 1501 RVA: 0x0000FD64 File Offset: 0x0000DF64
			internal void Freeze()
			{
				if (!this._frozen)
				{
					this._left.Freeze();
					this._right.Freeze();
					this._frozen = true;
				}
			}

			// Token: 0x060005DE RID: 1502 RVA: 0x0000FD8C File Offset: 0x0000DF8C
			internal ImmutableSortedSet<T>.Node Search(T key, IComparer<T> comparer)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<IComparer<T>>(comparer, "comparer");
				if (this.IsEmpty)
				{
					return this;
				}
				int num = comparer.Compare(key, this._key);
				if (num == 0)
				{
					return this;
				}
				if (num > 0)
				{
					return this._right.Search(key, comparer);
				}
				return this._left.Search(key, comparer);
			}

			// Token: 0x060005DF RID: 1503 RVA: 0x0000FDEC File Offset: 0x0000DFEC
			internal int IndexOf(T key, IComparer<T> comparer)
			{
				Requires.NotNullAllowStructs<T>(key, "key");
				Requires.NotNull<IComparer<T>>(comparer, "comparer");
				if (this.IsEmpty)
				{
					return -1;
				}
				int num = comparer.Compare(key, this._key);
				if (num == 0)
				{
					return this._left.Count;
				}
				if (num > 0)
				{
					int num2 = this._right.IndexOf(key, comparer);
					bool flag = num2 < 0;
					if (flag)
					{
						num2 = ~num2;
					}
					num2 = this._left.Count + 1 + num2;
					if (flag)
					{
						num2 = ~num2;
					}
					return num2;
				}
				return this._left.IndexOf(key, comparer);
			}

			// Token: 0x060005E0 RID: 1504 RVA: 0x0000FE78 File Offset: 0x0000E078
			internal IEnumerator<T> Reverse()
			{
				return new ImmutableSortedSet<T>.Enumerator(this, null, true);
			}

			// Token: 0x060005E1 RID: 1505 RVA: 0x0000FE88 File Offset: 0x0000E088
			private static ImmutableSortedSet<T>.Node RotateLeft(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				if (tree._right.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedSet<T>.Node right = tree._right;
				return right.Mutate(tree.Mutate(null, right._left), null);
			}

			// Token: 0x060005E2 RID: 1506 RVA: 0x0000FECC File Offset: 0x0000E0CC
			private static ImmutableSortedSet<T>.Node RotateRight(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				if (tree._left.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedSet<T>.Node left = tree._left;
				return left.Mutate(null, tree.Mutate(left._right, null));
			}

			// Token: 0x060005E3 RID: 1507 RVA: 0x0000FF10 File Offset: 0x0000E110
			private static ImmutableSortedSet<T>.Node DoubleLeft(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				if (tree._right.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedSet<T>.Node tree2 = tree.Mutate(null, ImmutableSortedSet<T>.Node.RotateRight(tree._right));
				return ImmutableSortedSet<T>.Node.RotateLeft(tree2);
			}

			// Token: 0x060005E4 RID: 1508 RVA: 0x0000FF50 File Offset: 0x0000E150
			private static ImmutableSortedSet<T>.Node DoubleRight(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				if (tree._left.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedSet<T>.Node tree2 = tree.Mutate(ImmutableSortedSet<T>.Node.RotateLeft(tree._left), null);
				return ImmutableSortedSet<T>.Node.RotateRight(tree2);
			}

			// Token: 0x060005E5 RID: 1509 RVA: 0x0000FF90 File Offset: 0x0000E190
			private static int Balance(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				return (int)(tree._right._height - tree._left._height);
			}

			// Token: 0x060005E6 RID: 1510 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
			private static bool IsRightHeavy(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				return ImmutableSortedSet<T>.Node.Balance(tree) >= 2;
			}

			// Token: 0x060005E7 RID: 1511 RVA: 0x0000FFCD File Offset: 0x0000E1CD
			private static bool IsLeftHeavy(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				return ImmutableSortedSet<T>.Node.Balance(tree) <= -2;
			}

			// Token: 0x060005E8 RID: 1512 RVA: 0x0000FFE8 File Offset: 0x0000E1E8
			private static ImmutableSortedSet<T>.Node MakeBalanced(ImmutableSortedSet<T>.Node tree)
			{
				Requires.NotNull<ImmutableSortedSet<T>.Node>(tree, "tree");
				if (ImmutableSortedSet<T>.Node.IsRightHeavy(tree))
				{
					if (ImmutableSortedSet<T>.Node.Balance(tree._right) >= 0)
					{
						return ImmutableSortedSet<T>.Node.RotateLeft(tree);
					}
					return ImmutableSortedSet<T>.Node.DoubleLeft(tree);
				}
				else
				{
					if (!ImmutableSortedSet<T>.Node.IsLeftHeavy(tree))
					{
						return tree;
					}
					if (ImmutableSortedSet<T>.Node.Balance(tree._left) <= 0)
					{
						return ImmutableSortedSet<T>.Node.RotateRight(tree);
					}
					return ImmutableSortedSet<T>.Node.DoubleRight(tree);
				}
			}

			// Token: 0x060005E9 RID: 1513 RVA: 0x0001004C File Offset: 0x0000E24C
			internal static ImmutableSortedSet<T>.Node NodeTreeFromList(IOrderedCollection<T> items, int start, int length)
			{
				Requires.NotNull<IOrderedCollection<T>>(items, "items");
				if (length == 0)
				{
					return ImmutableSortedSet<T>.Node.EmptyNode;
				}
				int num = (length - 1) / 2;
				int num2 = length - 1 - num;
				ImmutableSortedSet<T>.Node left = ImmutableSortedSet<T>.Node.NodeTreeFromList(items, start, num2);
				ImmutableSortedSet<T>.Node right = ImmutableSortedSet<T>.Node.NodeTreeFromList(items, start + num2 + 1, num);
				return new ImmutableSortedSet<T>.Node(items[start + num2], left, right, true);
			}

			// Token: 0x060005EA RID: 1514 RVA: 0x000100A0 File Offset: 0x0000E2A0
			private ImmutableSortedSet<T>.Node Mutate(ImmutableSortedSet<T>.Node left = null, ImmutableSortedSet<T>.Node right = null)
			{
				if (this._frozen)
				{
					return new ImmutableSortedSet<T>.Node(this._key, left ?? this._left, right ?? this._right, false);
				}
				if (left != null)
				{
					this._left = left;
				}
				if (right != null)
				{
					this._right = right;
				}
				this._height = checked(1 + Math.Max(this._left._height, this._right._height));
				this._count = 1 + this._left._count + this._right._count;
				return this;
			}

			// Token: 0x040000E5 RID: 229
			internal static readonly ImmutableSortedSet<T>.Node EmptyNode = new ImmutableSortedSet<T>.Node();

			// Token: 0x040000E6 RID: 230
			private readonly T _key;

			// Token: 0x040000E7 RID: 231
			private bool _frozen;

			// Token: 0x040000E8 RID: 232
			private byte _height;

			// Token: 0x040000E9 RID: 233
			private int _count;

			// Token: 0x040000EA RID: 234
			private ImmutableSortedSet<T>.Node _left;

			// Token: 0x040000EB RID: 235
			private ImmutableSortedSet<T>.Node _right;
		}
	}
}
