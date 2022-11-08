using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x0200002C RID: 44
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableDictionaryDebuggerProxy<, >))]
	public sealed class ImmutableSortedDictionary<TKey, TValue> : IImmutableDictionary<!0, !1>, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable, ISortKeyCollection<TKey>, IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IDictionary, ICollection
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000759D File Offset: 0x0000579D
		internal ImmutableSortedDictionary(IComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
		{
			this._keyComparer = (keyComparer ?? Comparer<TKey>.Default);
			this._valueComparer = (valueComparer ?? EqualityComparer<TValue>.Default);
			this._root = ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000075D0 File Offset: 0x000057D0
		private ImmutableSortedDictionary(ImmutableSortedDictionary<TKey, TValue>.Node root, int count, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(root, "root");
			Requires.Range(count >= 0, "count", null);
			Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
			Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
			root.Freeze();
			this._root = root;
			this._count = count;
			this._keyComparer = keyComparer;
			this._valueComparer = valueComparer;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000763A File Offset: 0x0000583A
		public ImmutableSortedDictionary<TKey, TValue> Clear()
		{
			if (!this._root.IsEmpty)
			{
				return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(this._keyComparer, this._valueComparer);
			}
			return this;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00007661 File Offset: 0x00005861
		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return this._valueComparer;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00007669 File Offset: 0x00005869
		public bool IsEmpty
		{
			get
			{
				return this._root.IsEmpty;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00007676 File Offset: 0x00005876
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0000767E File Offset: 0x0000587E
		public IEnumerable<TKey> Keys
		{
			get
			{
				return this._root.Keys;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000768B File Offset: 0x0000588B
		public IEnumerable<TValue> Values
		{
			get
			{
				return this._root.Values;
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007698 File Offset: 0x00005898
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600028A RID: 650 RVA: 0x000076A0 File Offset: 0x000058A0
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			get
			{
				return new KeysCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000076A8 File Offset: 0x000058A8
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			get
			{
				return new ValuesCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00003182 File Offset: 0x00001382
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000076B0 File Offset: 0x000058B0
		public IComparer<TKey> KeyComparer
		{
			get
			{
				return this._keyComparer;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000076B8 File Offset: 0x000058B8
		internal ImmutableSortedDictionary<TKey, TValue>.Node Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x1700006C RID: 108
		public TValue this[TKey key]
		{
			get
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				TValue result;
				if (this.TryGetValue(key, out result))
				{
					return result;
				}
				throw new KeyNotFoundException();
			}
		}

		// Token: 0x1700006D RID: 109
		TValue IDictionary<!0, !1>.this[TKey key]
		{
			get
			{
				return this[key];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000076F3 File Offset: 0x000058F3
		public ImmutableSortedDictionary<TKey, TValue>.Builder ToBuilder()
		{
			return new ImmutableSortedDictionary<TKey, TValue>.Builder(this);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000076FC File Offset: 0x000058FC
		public ImmutableSortedDictionary<TKey, TValue> Add(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			bool flag;
			ImmutableSortedDictionary<TKey, TValue>.Node root = this._root.Add(key, value, this._keyComparer, this._valueComparer, out flag);
			return this.Wrap(root, this._count + 1);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00007740 File Offset: 0x00005940
		public ImmutableSortedDictionary<TKey, TValue> SetItem(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			bool flag;
			bool flag2;
			ImmutableSortedDictionary<TKey, TValue>.Node root = this._root.SetItem(key, value, this._keyComparer, this._valueComparer, out flag, out flag2);
			return this.Wrap(root, flag ? this._count : (this._count + 1));
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00007790 File Offset: 0x00005990
		public ImmutableSortedDictionary<TKey, TValue> SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			return this.AddRange(items, true, false);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000077A6 File Offset: 0x000059A6
		public ImmutableSortedDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			return this.AddRange(items, false, false);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000077BC File Offset: 0x000059BC
		public ImmutableSortedDictionary<TKey, TValue> Remove(TKey value)
		{
			Requires.NotNullAllowStructs<TKey>(value, "value");
			bool flag;
			ImmutableSortedDictionary<TKey, TValue>.Node root = this._root.Remove(value, this._keyComparer, out flag);
			return this.Wrap(root, this._count - 1);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000077F8 File Offset: 0x000059F8
		public ImmutableSortedDictionary<TKey, TValue> RemoveRange(IEnumerable<TKey> keys)
		{
			Requires.NotNull<IEnumerable<TKey>>(keys, "keys");
			ImmutableSortedDictionary<TKey, TValue>.Node node = this._root;
			int num = this._count;
			foreach (TKey key in keys)
			{
				bool flag;
				ImmutableSortedDictionary<TKey, TValue>.Node node2 = node.Remove(key, this._keyComparer, out flag);
				if (flag)
				{
					node = node2;
					num--;
				}
			}
			return this.Wrap(node, num);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00007878 File Offset: 0x00005A78
		public ImmutableSortedDictionary<TKey, TValue> WithComparers(IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			if (keyComparer == null)
			{
				keyComparer = Comparer<TKey>.Default;
			}
			if (valueComparer == null)
			{
				valueComparer = EqualityComparer<TValue>.Default;
			}
			if (keyComparer != this._keyComparer)
			{
				ImmutableSortedDictionary<TKey, TValue> immutableSortedDictionary = new ImmutableSortedDictionary<TKey, TValue>(ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode, 0, keyComparer, valueComparer);
				return immutableSortedDictionary.AddRange(this, false, true);
			}
			if (valueComparer == this._valueComparer)
			{
				return this;
			}
			return new ImmutableSortedDictionary<TKey, TValue>(this._root, this._count, this._keyComparer, valueComparer);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000078DF File Offset: 0x00005ADF
		public ImmutableSortedDictionary<TKey, TValue> WithComparers(IComparer<TKey> keyComparer)
		{
			return this.WithComparers(keyComparer, this._valueComparer);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000078EE File Offset: 0x00005AEE
		public bool ContainsValue(TValue value)
		{
			return this._root.ContainsValue(value, this._valueComparer);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00007902 File Offset: 0x00005B02
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			return this.Add(key, value);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000790C File Offset: 0x00005B0C
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.SetItem(TKey key, TValue value)
		{
			return this.SetItem(key, value);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00007916 File Offset: 0x00005B16
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return this.SetItems(items);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000791F File Offset: 0x00005B1F
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			return this.AddRange(pairs);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00007928 File Offset: 0x00005B28
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.RemoveRange(IEnumerable<TKey> keys)
		{
			return this.RemoveRange(keys);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00007931 File Offset: 0x00005B31
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Remove(TKey key)
		{
			return this.Remove(key);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000793A File Offset: 0x00005B3A
		public bool ContainsKey(TKey key)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return this._root.ContainsKey(key, this._keyComparer);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00007959 File Offset: 0x00005B59
		public bool Contains(KeyValuePair<TKey, TValue> pair)
		{
			return this._root.Contains(pair, this._keyComparer, this._valueComparer);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00007973 File Offset: 0x00005B73
		public bool TryGetValue(TKey key, out TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return this._root.TryGetValue(key, this._keyComparer, out value);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00007993 File Offset: 0x00005B93
		public bool TryGetKey(TKey equalKey, out TKey actualKey)
		{
			Requires.NotNullAllowStructs<TKey>(equalKey, "equalKey");
			return this._root.TryGetKey(equalKey, this._keyComparer, out actualKey);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000317B File Offset: 0x0000137B
		bool IDictionary<!0, !1>.Remove(TKey key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<KeyValuePair<!0, !1>>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000079B4 File Offset: 0x00005BB4
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			Requires.NotNull<KeyValuePair<TKey, TValue>[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
			{
				array[arrayIndex++] = keyValuePair;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00003182 File Offset: 0x00001382
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00003182 File Offset: 0x00001382
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000076A0 File Offset: 0x000058A0
		ICollection IDictionary.Keys
		{
			get
			{
				return new KeysCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000076A8 File Offset: 0x000058A8
		ICollection IDictionary.Values
		{
			get
			{
				return new ValuesCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00007A40 File Offset: 0x00005C40
		bool IDictionary.Contains(object key)
		{
			return this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00007A4E File Offset: 0x00005C4E
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new DictionaryEnumerator<TKey, TValue>(this.GetEnumerator());
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Remove(object key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000072 RID: 114
		object IDictionary.this[object key]
		{
			get
			{
				return this[(TKey)((object)key)];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00007A73 File Offset: 0x00005C73
		void ICollection.CopyTo(Array array, int index)
		{
			this._root.CopyTo(array, index, this.Count);
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00007A88 File Offset: 0x00005C88
		[ExcludeFromCodeCoverage]
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00007A88 File Offset: 0x00005C88
		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00007A95 File Offset: 0x00005C95
		public ImmutableSortedDictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return this._root.GetEnumerator();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00007AA2 File Offset: 0x00005CA2
		private static ImmutableSortedDictionary<TKey, TValue> Wrap(ImmutableSortedDictionary<TKey, TValue>.Node root, int count, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			if (!root.IsEmpty)
			{
				return new ImmutableSortedDictionary<TKey, TValue>(root, count, keyComparer, valueComparer);
			}
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00007AC4 File Offset: 0x00005CC4
		private static bool TryCastToImmutableMap(IEnumerable<KeyValuePair<TKey, TValue>> sequence, out ImmutableSortedDictionary<TKey, TValue> other)
		{
			other = (sequence as ImmutableSortedDictionary<TKey, TValue>);
			if (other != null)
			{
				return true;
			}
			ImmutableSortedDictionary<TKey, TValue>.Builder builder = sequence as ImmutableSortedDictionary<TKey, TValue>.Builder;
			if (builder != null)
			{
				other = builder.ToImmutable();
				return true;
			}
			return false;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00007AF4 File Offset: 0x00005CF4
		private ImmutableSortedDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items, bool overwriteOnCollision, bool avoidToSortedMap)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			if (this.IsEmpty && !avoidToSortedMap)
			{
				return this.FillFromEmpty(items, overwriteOnCollision);
			}
			ImmutableSortedDictionary<TKey, TValue>.Node node = this._root;
			int num = this._count;
			foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
			{
				bool flag = false;
				bool flag2;
				ImmutableSortedDictionary<TKey, TValue>.Node node2 = overwriteOnCollision ? node.SetItem(keyValuePair.Key, keyValuePair.Value, this._keyComparer, this._valueComparer, out flag, out flag2) : node.Add(keyValuePair.Key, keyValuePair.Value, this._keyComparer, this._valueComparer, out flag2);
				if (flag2)
				{
					node = node2;
					if (!flag)
					{
						num++;
					}
				}
			}
			return this.Wrap(node, num);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00007BCC File Offset: 0x00005DCC
		private ImmutableSortedDictionary<TKey, TValue> Wrap(ImmutableSortedDictionary<TKey, TValue>.Node root, int adjustedCountIfDifferentRoot)
		{
			if (this._root == root)
			{
				return this;
			}
			if (!root.IsEmpty)
			{
				return new ImmutableSortedDictionary<TKey, TValue>(root, adjustedCountIfDifferentRoot, this._keyComparer, this._valueComparer);
			}
			return this.Clear();
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00007BFC File Offset: 0x00005DFC
		private ImmutableSortedDictionary<TKey, TValue> FillFromEmpty(IEnumerable<KeyValuePair<TKey, TValue>> items, bool overwriteOnCollision)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			ImmutableSortedDictionary<TKey, TValue> immutableSortedDictionary;
			if (ImmutableSortedDictionary<TKey, TValue>.TryCastToImmutableMap(items, out immutableSortedDictionary))
			{
				return immutableSortedDictionary.WithComparers(this.KeyComparer, this.ValueComparer);
			}
			IDictionary<TKey, TValue> dictionary = items as IDictionary<!0, !1>;
			SortedDictionary<TKey, TValue> sortedDictionary;
			if (dictionary != null)
			{
				sortedDictionary = new SortedDictionary<TKey, TValue>(dictionary, this.KeyComparer);
			}
			else
			{
				sortedDictionary = new SortedDictionary<TKey, TValue>(this.KeyComparer);
				foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
				{
					TValue x;
					if (overwriteOnCollision)
					{
						sortedDictionary[keyValuePair.Key] = keyValuePair.Value;
					}
					else if (sortedDictionary.TryGetValue(keyValuePair.Key, out x))
					{
						if (!this._valueComparer.Equals(x, keyValuePair.Value))
						{
							throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
							{
								keyValuePair.Key
							}));
						}
					}
					else
					{
						sortedDictionary.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
			}
			if (sortedDictionary.Count == 0)
			{
				return this;
			}
			ImmutableSortedDictionary<TKey, TValue>.Node root = ImmutableSortedDictionary<TKey, TValue>.Node.NodeTreeFromSortedDictionary(sortedDictionary);
			return new ImmutableSortedDictionary<TKey, TValue>(root, sortedDictionary.Count, this.KeyComparer, this.ValueComparer);
		}

		// Token: 0x04000025 RID: 37
		public static readonly ImmutableSortedDictionary<TKey, TValue> Empty = new ImmutableSortedDictionary<TKey, TValue>(null, null);

		// Token: 0x04000026 RID: 38
		private readonly ImmutableSortedDictionary<TKey, TValue>.Node _root;

		// Token: 0x04000027 RID: 39
		private readonly int _count;

		// Token: 0x04000028 RID: 40
		private readonly IComparer<TKey> _keyComparer;

		// Token: 0x04000029 RID: 41
		private readonly IEqualityComparer<TValue> _valueComparer;

		// Token: 0x02000063 RID: 99
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableSortedDictionaryBuilderDebuggerProxy<, >))]
		public sealed class Builder : IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IDictionary, ICollection
		{
			// Token: 0x0600052C RID: 1324 RVA: 0x0000DF10 File Offset: 0x0000C110
			internal Builder(ImmutableSortedDictionary<TKey, TValue> map)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>>(map, "map");
				this._root = map._root;
				this._keyComparer = map.KeyComparer;
				this._valueComparer = map.ValueComparer;
				this._count = map.Count;
				this._immutable = map;
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x0600052D RID: 1325 RVA: 0x0000DF86 File Offset: 0x0000C186
			ICollection<TKey> IDictionary<!0, !1>.Keys
			{
				get
				{
					return this.Root.Keys.ToArray(this.Count);
				}
			}

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000DF9E File Offset: 0x0000C19E
			public IEnumerable<TKey> Keys
			{
				get
				{
					return this.Root.Keys;
				}
			}

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000DFAB File Offset: 0x0000C1AB
			ICollection<TValue> IDictionary<!0, !1>.Values
			{
				get
				{
					return this.Root.Values.ToArray(this.Count);
				}
			}

			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000DFC3 File Offset: 0x0000C1C3
			public IEnumerable<TValue> Values
			{
				get
				{
					return this.Root.Values;
				}
			}

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000104 RID: 260
			// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000DFD8 File Offset: 0x0000C1D8
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x06000534 RID: 1332 RVA: 0x0000DFE0 File Offset: 0x0000C1E0
			// (set) Token: 0x06000535 RID: 1333 RVA: 0x0000DFE8 File Offset: 0x0000C1E8
			private ImmutableSortedDictionary<TKey, TValue>.Node Root
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

			// Token: 0x17000106 RID: 262
			public TValue this[TKey key]
			{
				get
				{
					TValue result;
					if (this.TryGetValue(key, out result))
					{
						return result;
					}
					throw new KeyNotFoundException();
				}
				set
				{
					bool flag;
					bool flag2;
					this.Root = this._root.SetItem(key, value, this._keyComparer, this._valueComparer, out flag, out flag2);
					if (flag2 && !flag)
					{
						this._count++;
					}
				}
			}

			// Token: 0x17000107 RID: 263
			// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000206B File Offset: 0x0000026B
			bool IDictionary.IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000206B File Offset: 0x0000026B
			bool IDictionary.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000E074 File Offset: 0x0000C274
			ICollection IDictionary.Keys
			{
				get
				{
					return this.Keys.ToArray(this.Count);
				}
			}

			// Token: 0x1700010A RID: 266
			// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000E087 File Offset: 0x0000C287
			ICollection IDictionary.Values
			{
				get
				{
					return this.Values.ToArray(this.Count);
				}
			}

			// Token: 0x1700010B RID: 267
			// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000E09A File Offset: 0x0000C29A
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

			// Token: 0x1700010C RID: 268
			// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000206B File Offset: 0x0000026B
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700010D RID: 269
			// (get) Token: 0x0600053E RID: 1342 RVA: 0x0000E0BC File Offset: 0x0000C2BC
			// (set) Token: 0x0600053F RID: 1343 RVA: 0x0000E0C4 File Offset: 0x0000C2C4
			public IComparer<TKey> KeyComparer
			{
				get
				{
					return this._keyComparer;
				}
				set
				{
					Requires.NotNull<IComparer<TKey>>(value, "value");
					if (value != this._keyComparer)
					{
						ImmutableSortedDictionary<TKey, TValue>.Node node = ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;
						int num = 0;
						foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
						{
							bool flag;
							node = node.Add(keyValuePair.Key, keyValuePair.Value, value, this._valueComparer, out flag);
							if (flag)
							{
								num++;
							}
						}
						this._keyComparer = value;
						this.Root = node;
						this._count = num;
					}
				}
			}

			// Token: 0x1700010E RID: 270
			// (get) Token: 0x06000540 RID: 1344 RVA: 0x0000E164 File Offset: 0x0000C364
			// (set) Token: 0x06000541 RID: 1345 RVA: 0x0000E16C File Offset: 0x0000C36C
			public IEqualityComparer<TValue> ValueComparer
			{
				get
				{
					return this._valueComparer;
				}
				set
				{
					Requires.NotNull<IEqualityComparer<TValue>>(value, "value");
					if (value != this._valueComparer)
					{
						this._valueComparer = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x06000542 RID: 1346 RVA: 0x0000E190 File Offset: 0x0000C390
			void IDictionary.Add(object key, object value)
			{
				this.Add((TKey)((object)key), (TValue)((object)value));
			}

			// Token: 0x06000543 RID: 1347 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
			bool IDictionary.Contains(object key)
			{
				return this.ContainsKey((TKey)((object)key));
			}

			// Token: 0x06000544 RID: 1348 RVA: 0x0000E1B2 File Offset: 0x0000C3B2
			IDictionaryEnumerator IDictionary.GetEnumerator()
			{
				return new DictionaryEnumerator<TKey, TValue>(this.GetEnumerator());
			}

			// Token: 0x06000545 RID: 1349 RVA: 0x0000E1C4 File Offset: 0x0000C3C4
			void IDictionary.Remove(object key)
			{
				this.Remove((TKey)((object)key));
			}

			// Token: 0x1700010F RID: 271
			object IDictionary.this[object key]
			{
				get
				{
					return this[(TKey)((object)key)];
				}
				set
				{
					this[(TKey)((object)key)] = (TValue)((object)value);
				}
			}

			// Token: 0x06000548 RID: 1352 RVA: 0x0000E1FA File Offset: 0x0000C3FA
			void ICollection.CopyTo(Array array, int index)
			{
				this.Root.CopyTo(array, index, this.Count);
			}

			// Token: 0x06000549 RID: 1353 RVA: 0x0000E210 File Offset: 0x0000C410
			public void Add(TKey key, TValue value)
			{
				bool flag;
				this.Root = this.Root.Add(key, value, this._keyComparer, this._valueComparer, out flag);
				if (flag)
				{
					this._count++;
				}
			}

			// Token: 0x0600054A RID: 1354 RVA: 0x0000E24F File Offset: 0x0000C44F
			public bool ContainsKey(TKey key)
			{
				return this.Root.ContainsKey(key, this._keyComparer);
			}

			// Token: 0x0600054B RID: 1355 RVA: 0x0000E264 File Offset: 0x0000C464
			public bool Remove(TKey key)
			{
				bool flag;
				this.Root = this.Root.Remove(key, this._keyComparer, out flag);
				if (flag)
				{
					this._count--;
				}
				return flag;
			}

			// Token: 0x0600054C RID: 1356 RVA: 0x0000E29D File Offset: 0x0000C49D
			public bool TryGetValue(TKey key, out TValue value)
			{
				return this.Root.TryGetValue(key, this._keyComparer, out value);
			}

			// Token: 0x0600054D RID: 1357 RVA: 0x0000E2B2 File Offset: 0x0000C4B2
			public bool TryGetKey(TKey equalKey, out TKey actualKey)
			{
				Requires.NotNullAllowStructs<TKey>(equalKey, "equalKey");
				return this.Root.TryGetKey(equalKey, this._keyComparer, out actualKey);
			}

			// Token: 0x0600054E RID: 1358 RVA: 0x0000E2D2 File Offset: 0x0000C4D2
			public void Add(KeyValuePair<TKey, TValue> item)
			{
				this.Add(item.Key, item.Value);
			}

			// Token: 0x0600054F RID: 1359 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
			public void Clear()
			{
				this.Root = ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;
				this._count = 0;
			}

			// Token: 0x06000550 RID: 1360 RVA: 0x0000E2FC File Offset: 0x0000C4FC
			public bool Contains(KeyValuePair<TKey, TValue> item)
			{
				return this.Root.Contains(item, this._keyComparer, this._valueComparer);
			}

			// Token: 0x06000551 RID: 1361 RVA: 0x0000E316 File Offset: 0x0000C516
			void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
				this.Root.CopyTo(array, arrayIndex, this.Count);
			}

			// Token: 0x06000552 RID: 1362 RVA: 0x0000E32B File Offset: 0x0000C52B
			public bool Remove(KeyValuePair<TKey, TValue> item)
			{
				return this.Contains(item) && this.Remove(item.Key);
			}

			// Token: 0x06000553 RID: 1363 RVA: 0x0000E345 File Offset: 0x0000C545
			public ImmutableSortedDictionary<TKey, TValue>.Enumerator GetEnumerator()
			{
				return this.Root.GetEnumerator(this);
			}

			// Token: 0x06000554 RID: 1364 RVA: 0x0000E353 File Offset: 0x0000C553
			IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000555 RID: 1365 RVA: 0x0000E353 File Offset: 0x0000C553
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000556 RID: 1366 RVA: 0x0000E360 File Offset: 0x0000C560
			public bool ContainsValue(TValue value)
			{
				return this._root.ContainsValue(value, this._valueComparer);
			}

			// Token: 0x06000557 RID: 1367 RVA: 0x0000E374 File Offset: 0x0000C574
			public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
			{
				Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
				foreach (KeyValuePair<TKey, TValue> item in items)
				{
					this.Add(item);
				}
			}

			// Token: 0x06000558 RID: 1368 RVA: 0x0000E3C8 File Offset: 0x0000C5C8
			public void RemoveRange(IEnumerable<TKey> keys)
			{
				Requires.NotNull<IEnumerable<TKey>>(keys, "keys");
				foreach (TKey key in keys)
				{
					this.Remove(key);
				}
			}

			// Token: 0x06000559 RID: 1369 RVA: 0x0000E41C File Offset: 0x0000C61C
			public TValue GetValueOrDefault(TKey key)
			{
				return this.GetValueOrDefault(key, default(TValue));
			}

			// Token: 0x0600055A RID: 1370 RVA: 0x0000E43C File Offset: 0x0000C63C
			public TValue GetValueOrDefault(TKey key, TValue defaultValue)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				TValue result;
				if (this.TryGetValue(key, out result))
				{
					return result;
				}
				return defaultValue;
			}

			// Token: 0x0600055B RID: 1371 RVA: 0x0000E462 File Offset: 0x0000C662
			public ImmutableSortedDictionary<TKey, TValue> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableSortedDictionary<TKey, TValue>.Wrap(this.Root, this._count, this._keyComparer, this._valueComparer);
				}
				return this._immutable;
			}

			// Token: 0x040000C2 RID: 194
			private ImmutableSortedDictionary<TKey, TValue>.Node _root = ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;

			// Token: 0x040000C3 RID: 195
			private IComparer<TKey> _keyComparer = Comparer<TKey>.Default;

			// Token: 0x040000C4 RID: 196
			private IEqualityComparer<TValue> _valueComparer = EqualityComparer<TValue>.Default;

			// Token: 0x040000C5 RID: 197
			private int _count;

			// Token: 0x040000C6 RID: 198
			private ImmutableSortedDictionary<TKey, TValue> _immutable;

			// Token: 0x040000C7 RID: 199
			private int _version;

			// Token: 0x040000C8 RID: 200
			private object _syncRoot;
		}

		// Token: 0x02000064 RID: 100
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, ISecurePooledObjectUser
		{
			// Token: 0x0600055C RID: 1372 RVA: 0x0000E498 File Offset: 0x0000C698
			internal Enumerator(ImmutableSortedDictionary<TKey, TValue>.Node root, ImmutableSortedDictionary<TKey, TValue>.Builder builder = null)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(root, "root");
				this._root = root;
				this._builder = builder;
				this._current = null;
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
				this._poolUserId = SecureObjectPool.NewId();
				this._stack = null;
				if (!this._root.IsEmpty)
				{
					if (!ImmutableSortedDictionary<TKey, TValue>.Enumerator.s_enumeratingStacks.TryTake(this, out this._stack))
					{
						this._stack = ImmutableSortedDictionary<TKey, TValue>.Enumerator.s_enumeratingStacks.PrepNew(this, new Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>(root.Height));
					}
					this.PushLeft(this._root);
				}
			}

			// Token: 0x17000110 RID: 272
			// (get) Token: 0x0600055D RID: 1373 RVA: 0x0000E53B File Offset: 0x0000C73B
			public KeyValuePair<TKey, TValue> Current
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

			// Token: 0x17000111 RID: 273
			// (get) Token: 0x0600055E RID: 1374 RVA: 0x0000E55C File Offset: 0x0000C75C
			int ISecurePooledObjectUser.PoolUserId
			{
				get
				{
					return this._poolUserId;
				}
			}

			// Token: 0x17000112 RID: 274
			// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000E564 File Offset: 0x0000C764
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000560 RID: 1376 RVA: 0x0000E574 File Offset: 0x0000C774
			public void Dispose()
			{
				this._root = null;
				this._current = null;
				Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>> stack;
				if (this._stack != null && this._stack.TryUse<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(ref this, out stack))
				{
					stack.ClearFastWhenEmpty<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>();
					ImmutableSortedDictionary<TKey, TValue>.Enumerator.s_enumeratingStacks.TryAdd(this, this._stack);
				}
				this._stack = null;
			}

			// Token: 0x06000561 RID: 1377 RVA: 0x0000E5CC File Offset: 0x0000C7CC
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				this.ThrowIfChanged();
				if (this._stack != null)
				{
					Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>> stack = this._stack.Use<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(ref this);
					if (stack.Count > 0)
					{
						ImmutableSortedDictionary<TKey, TValue>.Node value = stack.Pop().Value;
						this._current = value;
						this.PushLeft(value.Right);
						return true;
					}
				}
				this._current = null;
				return false;
			}

			// Token: 0x06000562 RID: 1378 RVA: 0x0000E62C File Offset: 0x0000C82C
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._current = null;
				if (this._stack != null)
				{
					Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>> stack = this._stack.Use<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(ref this);
					stack.ClearFastWhenEmpty<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>();
					this.PushLeft(this._root);
				}
			}

			// Token: 0x06000563 RID: 1379 RVA: 0x0000E689 File Offset: 0x0000C889
			internal void ThrowIfDisposed()
			{
				if (this._root == null || (this._stack != null && !this._stack.IsOwned<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(ref this)))
				{
					Requires.FailObjectDisposed<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(this);
				}
			}

			// Token: 0x06000564 RID: 1380 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x06000565 RID: 1381 RVA: 0x0000E6DC File Offset: 0x0000C8DC
			private void PushLeft(ImmutableSortedDictionary<TKey, TValue>.Node node)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(node, "node");
				Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>> stack = this._stack.Use<ImmutableSortedDictionary<TKey, TValue>.Enumerator>(ref this);
				while (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>(node));
					node = node.Left;
				}
			}

			// Token: 0x040000C9 RID: 201
			private static readonly SecureObjectPool<Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>, ImmutableSortedDictionary<TKey, TValue>.Enumerator> s_enumeratingStacks = new SecureObjectPool<Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>, ImmutableSortedDictionary<TKey, TValue>.Enumerator>();

			// Token: 0x040000CA RID: 202
			private readonly ImmutableSortedDictionary<TKey, TValue>.Builder _builder;

			// Token: 0x040000CB RID: 203
			private readonly int _poolUserId;

			// Token: 0x040000CC RID: 204
			private ImmutableSortedDictionary<TKey, TValue>.Node _root;

			// Token: 0x040000CD RID: 205
			private SecurePooledObject<Stack<RefAsValueType<ImmutableSortedDictionary<TKey, TValue>.Node>>> _stack;

			// Token: 0x040000CE RID: 206
			private ImmutableSortedDictionary<TKey, TValue>.Node _current;

			// Token: 0x040000CF RID: 207
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x02000065 RID: 101
		[DebuggerDisplay("{_key} = {_value}")]
		internal sealed class Node : IBinaryTree<KeyValuePair<TKey, TValue>>, IBinaryTree, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable
		{
			// Token: 0x06000567 RID: 1383 RVA: 0x0000E72B File Offset: 0x0000C92B
			private Node()
			{
				this._frozen = true;
			}

			// Token: 0x06000568 RID: 1384 RVA: 0x0000E73C File Offset: 0x0000C93C
			private Node(TKey key, TValue value, ImmutableSortedDictionary<TKey, TValue>.Node left, ImmutableSortedDictionary<TKey, TValue>.Node right, bool frozen = false)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(left, "left");
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(right, "right");
				this._key = key;
				this._value = value;
				this._left = left;
				this._right = right;
				this._height = checked(1 + Math.Max(left._height, right._height));
				this._frozen = frozen;
			}

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000E7B1 File Offset: 0x0000C9B1
			public bool IsEmpty
			{
				get
				{
					return this._left == null;
				}
			}

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000E7BC File Offset: 0x0000C9BC
			IBinaryTree<KeyValuePair<TKey, TValue>> IBinaryTree<KeyValuePair<!0, !1>>.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x17000115 RID: 277
			// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
			IBinaryTree<KeyValuePair<TKey, TValue>> IBinaryTree<KeyValuePair<!0, !1>>.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x17000116 RID: 278
			// (get) Token: 0x0600056C RID: 1388 RVA: 0x0000E7CC File Offset: 0x0000C9CC
			public int Height
			{
				get
				{
					return (int)this._height;
				}
			}

			// Token: 0x17000117 RID: 279
			// (get) Token: 0x0600056D RID: 1389 RVA: 0x0000E7BC File Offset: 0x0000C9BC
			public ImmutableSortedDictionary<TKey, TValue>.Node Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x17000118 RID: 280
			// (get) Token: 0x0600056E RID: 1390 RVA: 0x0000E7BC File Offset: 0x0000C9BC
			IBinaryTree IBinaryTree.Left
			{
				get
				{
					return this._left;
				}
			}

			// Token: 0x17000119 RID: 281
			// (get) Token: 0x0600056F RID: 1391 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
			public ImmutableSortedDictionary<TKey, TValue>.Node Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x1700011A RID: 282
			// (get) Token: 0x06000570 RID: 1392 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
			IBinaryTree IBinaryTree.Right
			{
				get
				{
					return this._right;
				}
			}

			// Token: 0x1700011B RID: 283
			// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000E7D4 File Offset: 0x0000C9D4
			public KeyValuePair<TKey, TValue> Value
			{
				get
				{
					return new KeyValuePair<TKey, TValue>(this._key, this._value);
				}
			}

			// Token: 0x1700011C RID: 284
			// (get) Token: 0x06000572 RID: 1394 RVA: 0x0000317B File Offset: 0x0000137B
			int IBinaryTree.Count
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x1700011D RID: 285
			// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000E7E7 File Offset: 0x0000C9E7
			internal IEnumerable<TKey> Keys
			{
				get
				{
					return from p in this
					select p.Key;
				}
			}

			// Token: 0x1700011E RID: 286
			// (get) Token: 0x06000574 RID: 1396 RVA: 0x0000E80E File Offset: 0x0000CA0E
			internal IEnumerable<TValue> Values
			{
				get
				{
					return from p in this
					select p.Value;
				}
			}

			// Token: 0x06000575 RID: 1397 RVA: 0x0000E835 File Offset: 0x0000CA35
			public ImmutableSortedDictionary<TKey, TValue>.Enumerator GetEnumerator()
			{
				return new ImmutableSortedDictionary<TKey, TValue>.Enumerator(this, null);
			}

			// Token: 0x06000576 RID: 1398 RVA: 0x0000E83E File Offset: 0x0000CA3E
			IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000577 RID: 1399 RVA: 0x0000E83E File Offset: 0x0000CA3E
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000578 RID: 1400 RVA: 0x0000E84B File Offset: 0x0000CA4B
			internal ImmutableSortedDictionary<TKey, TValue>.Enumerator GetEnumerator(ImmutableSortedDictionary<TKey, TValue>.Builder builder)
			{
				return new ImmutableSortedDictionary<TKey, TValue>.Enumerator(this, builder);
			}

			// Token: 0x06000579 RID: 1401 RVA: 0x0000E854 File Offset: 0x0000CA54
			internal void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex, int dictionarySize)
			{
				Requires.NotNull<KeyValuePair<TKey, TValue>[]>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + dictionarySize, "arrayIndex", null);
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					array[arrayIndex++] = keyValuePair;
				}
			}

			// Token: 0x0600057A RID: 1402 RVA: 0x0000E8DC File Offset: 0x0000CADC
			internal void CopyTo(Array array, int arrayIndex, int dictionarySize)
			{
				Requires.NotNull<Array>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + dictionarySize, "arrayIndex", null);
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					array.SetValue(new DictionaryEntry(keyValuePair.Key, keyValuePair.Value), new int[]
					{
						arrayIndex++
					});
				}
			}

			// Token: 0x0600057B RID: 1403 RVA: 0x0000E990 File Offset: 0x0000CB90
			internal static ImmutableSortedDictionary<TKey, TValue>.Node NodeTreeFromSortedDictionary(SortedDictionary<TKey, TValue> dictionary)
			{
				Requires.NotNull<SortedDictionary<TKey, TValue>>(dictionary, "dictionary");
				IOrderedCollection<KeyValuePair<TKey, TValue>> orderedCollection = dictionary.AsOrderedCollection<KeyValuePair<TKey, TValue>>();
				return ImmutableSortedDictionary<TKey, TValue>.Node.NodeTreeFromList(orderedCollection, 0, orderedCollection.Count);
			}

			// Token: 0x0600057C RID: 1404 RVA: 0x0000E9BC File Offset: 0x0000CBBC
			internal ImmutableSortedDictionary<TKey, TValue>.Node Add(TKey key, TValue value, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, out bool mutated)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				bool flag;
				return this.SetOrAdd(key, value, keyComparer, valueComparer, false, out flag, out mutated);
			}

			// Token: 0x0600057D RID: 1405 RVA: 0x0000E9FB File Offset: 0x0000CBFB
			internal ImmutableSortedDictionary<TKey, TValue>.Node SetItem(TKey key, TValue value, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, out bool replacedExistingValue, out bool mutated)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				return this.SetOrAdd(key, value, keyComparer, valueComparer, true, out replacedExistingValue, out mutated);
			}

			// Token: 0x0600057E RID: 1406 RVA: 0x0000EA2F File Offset: 0x0000CC2F
			internal ImmutableSortedDictionary<TKey, TValue>.Node Remove(TKey key, IComparer<TKey> keyComparer, out bool mutated)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				return this.RemoveRecursive(key, keyComparer, out mutated);
			}

			// Token: 0x0600057F RID: 1407 RVA: 0x0000EA50 File Offset: 0x0000CC50
			internal bool TryGetValue(TKey key, IComparer<TKey> keyComparer, out TValue value)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				ImmutableSortedDictionary<TKey, TValue>.Node node = this.Search(key, keyComparer);
				if (node.IsEmpty)
				{
					value = default(TValue);
					return false;
				}
				value = node._value;
				return true;
			}

			// Token: 0x06000580 RID: 1408 RVA: 0x0000EA9C File Offset: 0x0000CC9C
			internal bool TryGetKey(TKey equalKey, IComparer<TKey> keyComparer, out TKey actualKey)
			{
				Requires.NotNullAllowStructs<TKey>(equalKey, "equalKey");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				ImmutableSortedDictionary<TKey, TValue>.Node node = this.Search(equalKey, keyComparer);
				if (node.IsEmpty)
				{
					actualKey = equalKey;
					return false;
				}
				actualKey = node._key;
				return true;
			}

			// Token: 0x06000581 RID: 1409 RVA: 0x0000EAE6 File Offset: 0x0000CCE6
			internal bool ContainsKey(TKey key, IComparer<TKey> keyComparer)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				return !this.Search(key, keyComparer).IsEmpty;
			}

			// Token: 0x06000582 RID: 1410 RVA: 0x0000EB10 File Offset: 0x0000CD10
			internal bool ContainsValue(TValue value, IEqualityComparer<TValue> valueComparer)
			{
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					if (valueComparer.Equals(value, keyValuePair.Value))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000583 RID: 1411 RVA: 0x0000EB7C File Offset: 0x0000CD7C
			internal bool Contains(KeyValuePair<TKey, TValue> pair, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			{
				Requires.NotNullAllowStructs<TKey>(pair.Key, "Key");
				Requires.NotNull<IComparer<TKey>>(keyComparer, "keyComparer");
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				ImmutableSortedDictionary<TKey, TValue>.Node node = this.Search(pair.Key, keyComparer);
				return !node.IsEmpty && valueComparer.Equals(node._value, pair.Value);
			}

			// Token: 0x06000584 RID: 1412 RVA: 0x0000EBDC File Offset: 0x0000CDDC
			internal void Freeze()
			{
				if (!this._frozen)
				{
					this._left.Freeze();
					this._right.Freeze();
					this._frozen = true;
				}
			}

			// Token: 0x06000585 RID: 1413 RVA: 0x0000EC04 File Offset: 0x0000CE04
			private static ImmutableSortedDictionary<TKey, TValue>.Node RotateLeft(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				if (tree._right.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedDictionary<TKey, TValue>.Node right = tree._right;
				return right.Mutate(tree.Mutate(null, right._left), null);
			}

			// Token: 0x06000586 RID: 1414 RVA: 0x0000EC48 File Offset: 0x0000CE48
			private static ImmutableSortedDictionary<TKey, TValue>.Node RotateRight(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				if (tree._left.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedDictionary<TKey, TValue>.Node left = tree._left;
				return left.Mutate(null, tree.Mutate(left._right, null));
			}

			// Token: 0x06000587 RID: 1415 RVA: 0x0000EC8C File Offset: 0x0000CE8C
			private static ImmutableSortedDictionary<TKey, TValue>.Node DoubleLeft(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				if (tree._right.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedDictionary<TKey, TValue>.Node tree2 = tree.Mutate(null, ImmutableSortedDictionary<TKey, TValue>.Node.RotateRight(tree._right));
				return ImmutableSortedDictionary<TKey, TValue>.Node.RotateLeft(tree2);
			}

			// Token: 0x06000588 RID: 1416 RVA: 0x0000ECCC File Offset: 0x0000CECC
			private static ImmutableSortedDictionary<TKey, TValue>.Node DoubleRight(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				if (tree._left.IsEmpty)
				{
					return tree;
				}
				ImmutableSortedDictionary<TKey, TValue>.Node tree2 = tree.Mutate(ImmutableSortedDictionary<TKey, TValue>.Node.RotateLeft(tree._left), null);
				return ImmutableSortedDictionary<TKey, TValue>.Node.RotateRight(tree2);
			}

			// Token: 0x06000589 RID: 1417 RVA: 0x0000ED0C File Offset: 0x0000CF0C
			private static int Balance(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				return (int)(tree._right._height - tree._left._height);
			}

			// Token: 0x0600058A RID: 1418 RVA: 0x0000ED30 File Offset: 0x0000CF30
			private static bool IsRightHeavy(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				return ImmutableSortedDictionary<TKey, TValue>.Node.Balance(tree) >= 2;
			}

			// Token: 0x0600058B RID: 1419 RVA: 0x0000ED49 File Offset: 0x0000CF49
			private static bool IsLeftHeavy(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				return ImmutableSortedDictionary<TKey, TValue>.Node.Balance(tree) <= -2;
			}

			// Token: 0x0600058C RID: 1420 RVA: 0x0000ED64 File Offset: 0x0000CF64
			private static ImmutableSortedDictionary<TKey, TValue>.Node MakeBalanced(ImmutableSortedDictionary<TKey, TValue>.Node tree)
			{
				Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Node>(tree, "tree");
				if (ImmutableSortedDictionary<TKey, TValue>.Node.IsRightHeavy(tree))
				{
					if (ImmutableSortedDictionary<TKey, TValue>.Node.Balance(tree._right) >= 0)
					{
						return ImmutableSortedDictionary<TKey, TValue>.Node.RotateLeft(tree);
					}
					return ImmutableSortedDictionary<TKey, TValue>.Node.DoubleLeft(tree);
				}
				else
				{
					if (!ImmutableSortedDictionary<TKey, TValue>.Node.IsLeftHeavy(tree))
					{
						return tree;
					}
					if (ImmutableSortedDictionary<TKey, TValue>.Node.Balance(tree._left) <= 0)
					{
						return ImmutableSortedDictionary<TKey, TValue>.Node.RotateRight(tree);
					}
					return ImmutableSortedDictionary<TKey, TValue>.Node.DoubleRight(tree);
				}
			}

			// Token: 0x0600058D RID: 1421 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
			private static ImmutableSortedDictionary<TKey, TValue>.Node NodeTreeFromList(IOrderedCollection<KeyValuePair<TKey, TValue>> items, int start, int length)
			{
				Requires.NotNull<IOrderedCollection<KeyValuePair<TKey, TValue>>>(items, "items");
				Requires.Range(start >= 0, "start", null);
				Requires.Range(length >= 0, "length", null);
				if (length == 0)
				{
					return ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;
				}
				int num = (length - 1) / 2;
				int num2 = length - 1 - num;
				ImmutableSortedDictionary<TKey, TValue>.Node left = ImmutableSortedDictionary<TKey, TValue>.Node.NodeTreeFromList(items, start, num2);
				ImmutableSortedDictionary<TKey, TValue>.Node right = ImmutableSortedDictionary<TKey, TValue>.Node.NodeTreeFromList(items, start + num2 + 1, num);
				KeyValuePair<TKey, TValue> keyValuePair = items[start + num2];
				return new ImmutableSortedDictionary<TKey, TValue>.Node(keyValuePair.Key, keyValuePair.Value, left, right, true);
			}

			// Token: 0x0600058E RID: 1422 RVA: 0x0000EE50 File Offset: 0x0000D050
			private ImmutableSortedDictionary<TKey, TValue>.Node SetOrAdd(TKey key, TValue value, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, bool overwriteExistingValue, out bool replacedExistingValue, out bool mutated)
			{
				replacedExistingValue = false;
				if (this.IsEmpty)
				{
					mutated = true;
					return new ImmutableSortedDictionary<TKey, TValue>.Node(key, value, this, this, false);
				}
				ImmutableSortedDictionary<TKey, TValue>.Node node = this;
				int num = keyComparer.Compare(key, this._key);
				if (num > 0)
				{
					ImmutableSortedDictionary<TKey, TValue>.Node right = this._right.SetOrAdd(key, value, keyComparer, valueComparer, overwriteExistingValue, out replacedExistingValue, out mutated);
					if (mutated)
					{
						node = this.Mutate(null, right);
					}
				}
				else if (num < 0)
				{
					ImmutableSortedDictionary<TKey, TValue>.Node left = this._left.SetOrAdd(key, value, keyComparer, valueComparer, overwriteExistingValue, out replacedExistingValue, out mutated);
					if (mutated)
					{
						node = this.Mutate(left, null);
					}
				}
				else
				{
					if (valueComparer.Equals(this._value, value))
					{
						mutated = false;
						return this;
					}
					if (!overwriteExistingValue)
					{
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
						{
							key
						}));
					}
					mutated = true;
					replacedExistingValue = true;
					node = new ImmutableSortedDictionary<TKey, TValue>.Node(key, value, this._left, this._right, false);
				}
				if (!mutated)
				{
					return node;
				}
				return ImmutableSortedDictionary<TKey, TValue>.Node.MakeBalanced(node);
			}

			// Token: 0x0600058F RID: 1423 RVA: 0x0000EF50 File Offset: 0x0000D150
			private ImmutableSortedDictionary<TKey, TValue>.Node RemoveRecursive(TKey key, IComparer<TKey> keyComparer, out bool mutated)
			{
				if (this.IsEmpty)
				{
					mutated = false;
					return this;
				}
				ImmutableSortedDictionary<TKey, TValue>.Node node = this;
				int num = keyComparer.Compare(key, this._key);
				if (num == 0)
				{
					mutated = true;
					if (this._right.IsEmpty && this._left.IsEmpty)
					{
						node = ImmutableSortedDictionary<TKey, TValue>.Node.EmptyNode;
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
						ImmutableSortedDictionary<TKey, TValue>.Node node2 = this._right;
						while (!node2._left.IsEmpty)
						{
							node2 = node2._left;
						}
						bool flag;
						ImmutableSortedDictionary<TKey, TValue>.Node right = this._right.Remove(node2._key, keyComparer, out flag);
						node = node2.Mutate(this._left, right);
					}
				}
				else if (num < 0)
				{
					ImmutableSortedDictionary<TKey, TValue>.Node left = this._left.Remove(key, keyComparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(left, null);
					}
				}
				else
				{
					ImmutableSortedDictionary<TKey, TValue>.Node right2 = this._right.Remove(key, keyComparer, out mutated);
					if (mutated)
					{
						node = this.Mutate(null, right2);
					}
				}
				if (!node.IsEmpty)
				{
					return ImmutableSortedDictionary<TKey, TValue>.Node.MakeBalanced(node);
				}
				return node;
			}

			// Token: 0x06000590 RID: 1424 RVA: 0x0000F08C File Offset: 0x0000D28C
			private ImmutableSortedDictionary<TKey, TValue>.Node Mutate(ImmutableSortedDictionary<TKey, TValue>.Node left = null, ImmutableSortedDictionary<TKey, TValue>.Node right = null)
			{
				if (this._frozen)
				{
					return new ImmutableSortedDictionary<TKey, TValue>.Node(this._key, this._value, left ?? this._left, right ?? this._right, false);
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
				return this;
			}

			// Token: 0x06000591 RID: 1425 RVA: 0x0000F104 File Offset: 0x0000D304
			private ImmutableSortedDictionary<TKey, TValue>.Node Search(TKey key, IComparer<TKey> keyComparer)
			{
				if (this.IsEmpty)
				{
					return this;
				}
				int num = keyComparer.Compare(key, this._key);
				if (num == 0)
				{
					return this;
				}
				if (num > 0)
				{
					return this._right.Search(key, keyComparer);
				}
				return this._left.Search(key, keyComparer);
			}

			// Token: 0x040000D0 RID: 208
			internal static readonly ImmutableSortedDictionary<TKey, TValue>.Node EmptyNode = new ImmutableSortedDictionary<TKey, TValue>.Node();

			// Token: 0x040000D1 RID: 209
			private readonly TKey _key;

			// Token: 0x040000D2 RID: 210
			private TValue _value;

			// Token: 0x040000D3 RID: 211
			private bool _frozen;

			// Token: 0x040000D4 RID: 212
			private byte _height;

			// Token: 0x040000D5 RID: 213
			private ImmutableSortedDictionary<TKey, TValue>.Node _left;

			// Token: 0x040000D6 RID: 214
			private ImmutableSortedDictionary<TKey, TValue>.Node _right;
		}
	}
}
