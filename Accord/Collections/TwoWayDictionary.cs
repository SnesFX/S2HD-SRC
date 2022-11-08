using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accord.Collections
{
	// Token: 0x0200006E RID: 110
	[Serializable]
	public sealed class TwoWayDictionary<TFirst, TSecond> : IDictionary<TFirst, TSecond>, ICollection<KeyValuePair<TFirst, TSecond>>, IEnumerable<KeyValuePair<TFirst, TSecond>>, IEnumerable, IReadOnlyDictionary<TFirst, TSecond>, IReadOnlyCollection<KeyValuePair<TFirst, TSecond>>, IDictionary, ICollection
	{
		// Token: 0x060002CE RID: 718 RVA: 0x00006E2B File Offset: 0x00005E2B
		public TwoWayDictionary()
		{
			this.firstToSecond = new Dictionary<TFirst, TSecond>();
			this.secondToFirst = new Dictionary<TSecond, TFirst>();
			this.reverse = new TwoWayDictionary<TFirst, TSecond>.ReverseDictionary(this);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00006E55 File Offset: 0x00005E55
		public TwoWayDictionary(int capacity)
		{
			this.firstToSecond = new Dictionary<TFirst, TSecond>(capacity);
			this.secondToFirst = new Dictionary<TSecond, TFirst>(capacity);
			this.reverse = new TwoWayDictionary<TFirst, TSecond>.ReverseDictionary(this);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00006E84 File Offset: 0x00005E84
		public TwoWayDictionary(IDictionary<TFirst, TSecond> dictionary)
		{
			this.firstToSecond = new Dictionary<TFirst, TSecond>(dictionary);
			this.secondToFirst = new Dictionary<TSecond, TFirst>();
			foreach (KeyValuePair<TFirst, TSecond> keyValuePair in dictionary)
			{
				this.secondToFirst.Add(keyValuePair.Value, keyValuePair.Key);
			}
			this.reverse = new TwoWayDictionary<TFirst, TSecond>.ReverseDictionary(this);
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x00006F08 File Offset: 0x00005F08
		public IDictionary<TSecond, TFirst> Reverse
		{
			get
			{
				return this.reverse;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00006F10 File Offset: 0x00005F10
		public int Count
		{
			get
			{
				return this.firstToSecond.Count;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x00006F1D File Offset: 0x00005F1D
		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)this.firstToSecond).SyncRoot;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00006F2F File Offset: 0x00005F2F
		bool ICollection.IsSynchronized
		{
			get
			{
				return ((ICollection)this.firstToSecond).IsSynchronized;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00006F41 File Offset: 0x00005F41
		bool IDictionary.IsFixedSize
		{
			get
			{
				return ((IDictionary)this.firstToSecond).IsFixedSize;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00006F53 File Offset: 0x00005F53
		public bool IsReadOnly
		{
			get
			{
				return this.firstToSecond.IsReadOnly || this.secondToFirst.IsReadOnly;
			}
		}

		// Token: 0x1700004F RID: 79
		public TSecond this[TFirst key]
		{
			get
			{
				return this.firstToSecond[key];
			}
			set
			{
				this.firstToSecond[key] = value;
				this.secondToFirst[value] = key;
			}
		}

		// Token: 0x17000050 RID: 80
		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)this.firstToSecond)[key];
			}
			set
			{
				((IDictionary)this.firstToSecond)[key] = value;
				((IDictionary)this.secondToFirst)[value] = key;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002DB RID: 731 RVA: 0x00006FD2 File Offset: 0x00005FD2
		public ICollection<TFirst> Keys
		{
			get
			{
				return this.firstToSecond.Keys;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00006FDF File Offset: 0x00005FDF
		ICollection IDictionary.Keys
		{
			get
			{
				return ((IDictionary)this.firstToSecond).Keys;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00006FF1 File Offset: 0x00005FF1
		IEnumerable<TFirst> IReadOnlyDictionary<!0, !1>.Keys
		{
			get
			{
				return ((IReadOnlyDictionary<TFirst, TSecond>)this.firstToSecond).Keys;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00007003 File Offset: 0x00006003
		public ICollection<TSecond> Values
		{
			get
			{
				return this.firstToSecond.Values;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00007010 File Offset: 0x00006010
		ICollection IDictionary.Values
		{
			get
			{
				return ((IDictionary)this.firstToSecond).Values;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00007022 File Offset: 0x00006022
		IEnumerable<TSecond> IReadOnlyDictionary<!0, !1>.Values
		{
			get
			{
				return ((IReadOnlyDictionary<TFirst, TSecond>)this.firstToSecond).Values;
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00007034 File Offset: 0x00006034
		public IEnumerator<KeyValuePair<TFirst, TSecond>> GetEnumerator()
		{
			return this.firstToSecond.GetEnumerator();
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00007041 File Offset: 0x00006041
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00007049 File Offset: 0x00006049
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)this.firstToSecond).GetEnumerator();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000705B File Offset: 0x0000605B
		public void Add(TFirst key, TSecond value)
		{
			this.firstToSecond.Add(key, value);
			this.secondToFirst.Add(value, key);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00007077 File Offset: 0x00006077
		void IDictionary.Add(object key, object value)
		{
			((IDictionary)this.firstToSecond).Add(key, value);
			((IDictionary)this.secondToFirst).Add(value, key);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000709D File Offset: 0x0000609D
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TFirst, TSecond> item)
		{
			this.firstToSecond.Add(item);
			this.secondToFirst.Add(item.Value, item.Key);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000070C4 File Offset: 0x000060C4
		public bool ContainsKey(TFirst key)
		{
			return this.firstToSecond.ContainsKey(key);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000070D2 File Offset: 0x000060D2
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TFirst, TSecond> item)
		{
			return this.firstToSecond.Contains(item);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x000070E0 File Offset: 0x000060E0
		public bool TryGetValue(TFirst key, out TSecond value)
		{
			return this.firstToSecond.TryGetValue(key, out value);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x000070F0 File Offset: 0x000060F0
		public bool Remove(TFirst key)
		{
			TSecond key2;
			if (this.firstToSecond.TryGetValue(key, out key2))
			{
				this.firstToSecond.Remove(key);
				this.secondToFirst.Remove(key2);
				return true;
			}
			return false;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000712C File Offset: 0x0000612C
		void IDictionary.Remove(object key)
		{
			IDictionary dictionary = (IDictionary)this.firstToSecond;
			if (!dictionary.Contains(key))
			{
				return;
			}
			object key2 = dictionary[key];
			dictionary.Remove(key);
			((IDictionary)this.secondToFirst).Remove(key2);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000716F File Offset: 0x0000616F
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TFirst, TSecond> item)
		{
			return this.firstToSecond.Remove(item);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000717D File Offset: 0x0000617D
		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)this.firstToSecond).Contains(key);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00007190 File Offset: 0x00006190
		public void Clear()
		{
			this.firstToSecond.Clear();
			this.secondToFirst.Clear();
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000071A8 File Offset: 0x000061A8
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TFirst, TSecond>[] array, int arrayIndex)
		{
			this.firstToSecond.CopyTo(array, arrayIndex);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000071B7 File Offset: 0x000061B7
		void ICollection.CopyTo(Array array, int index)
		{
			((IDictionary)this.firstToSecond).CopyTo(array, index);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000071CC File Offset: 0x000061CC
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			(this.firstToSecond as IDeserializationCallback).OnDeserialization(this);
			this.secondToFirst = new Dictionary<TSecond, TFirst>(this.firstToSecond.Count);
			foreach (KeyValuePair<TFirst, TSecond> keyValuePair in this.firstToSecond)
			{
				this.secondToFirst.Add(keyValuePair.Value, keyValuePair.Key);
			}
			this.reverse = new TwoWayDictionary<TFirst, TSecond>.ReverseDictionary(this);
		}

		// Token: 0x04000043 RID: 67
		private IDictionary<TFirst, TSecond> firstToSecond;

		// Token: 0x04000044 RID: 68
		[NonSerialized]
		private IDictionary<TSecond, TFirst> secondToFirst;

		// Token: 0x04000045 RID: 69
		[NonSerialized]
		private TwoWayDictionary<TFirst, TSecond>.ReverseDictionary reverse;

		// Token: 0x02000087 RID: 135
		private class ReverseDictionary : IDictionary<TSecond, TFirst>, ICollection<KeyValuePair<TSecond, TFirst>>, IEnumerable<KeyValuePair<TSecond, TFirst>>, IEnumerable, IReadOnlyDictionary<TSecond, TFirst>, IReadOnlyCollection<KeyValuePair<TSecond, TFirst>>, IDictionary, ICollection
		{
			// Token: 0x060003AF RID: 943 RVA: 0x00009260 File Offset: 0x00008260
			public ReverseDictionary(TwoWayDictionary<TFirst, TSecond> owner)
			{
				this.owner = owner;
			}

			// Token: 0x17000082 RID: 130
			// (get) Token: 0x060003B0 RID: 944 RVA: 0x0000926F File Offset: 0x0000826F
			public int Count
			{
				get
				{
					return this.owner.secondToFirst.Count;
				}
			}

			// Token: 0x17000083 RID: 131
			// (get) Token: 0x060003B1 RID: 945 RVA: 0x00009281 File Offset: 0x00008281
			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)this.owner.secondToFirst).SyncRoot;
				}
			}

			// Token: 0x17000084 RID: 132
			// (get) Token: 0x060003B2 RID: 946 RVA: 0x00009298 File Offset: 0x00008298
			bool ICollection.IsSynchronized
			{
				get
				{
					return ((ICollection)this.owner.secondToFirst).IsSynchronized;
				}
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x060003B3 RID: 947 RVA: 0x000092AF File Offset: 0x000082AF
			bool IDictionary.IsFixedSize
			{
				get
				{
					return ((IDictionary)this.owner.secondToFirst).IsFixedSize;
				}
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x060003B4 RID: 948 RVA: 0x000092C6 File Offset: 0x000082C6
			public bool IsReadOnly
			{
				get
				{
					return this.owner.secondToFirst.IsReadOnly || this.owner.firstToSecond.IsReadOnly;
				}
			}

			// Token: 0x17000087 RID: 135
			public TFirst this[TSecond key]
			{
				get
				{
					return this.owner.secondToFirst[key];
				}
				set
				{
					this.owner.secondToFirst[key] = value;
					this.owner.firstToSecond[value] = key;
				}
			}

			// Token: 0x17000088 RID: 136
			object IDictionary.this[object key]
			{
				get
				{
					return ((IDictionary)this.owner.secondToFirst)[key];
				}
				set
				{
					((IDictionary)this.owner.secondToFirst)[key] = value;
					((IDictionary)this.owner.firstToSecond)[value] = key;
				}
			}

			// Token: 0x17000089 RID: 137
			// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000936D File Offset: 0x0000836D
			public ICollection<TSecond> Keys
			{
				get
				{
					return this.owner.secondToFirst.Keys;
				}
			}

			// Token: 0x1700008A RID: 138
			// (get) Token: 0x060003BA RID: 954 RVA: 0x0000937F File Offset: 0x0000837F
			ICollection IDictionary.Keys
			{
				get
				{
					return ((IDictionary)this.owner.secondToFirst).Keys;
				}
			}

			// Token: 0x1700008B RID: 139
			// (get) Token: 0x060003BB RID: 955 RVA: 0x00009396 File Offset: 0x00008396
			IEnumerable<TSecond> IReadOnlyDictionary<!1, !0>.Keys
			{
				get
				{
					return ((IReadOnlyDictionary<TSecond, TFirst>)this.owner.secondToFirst).Keys;
				}
			}

			// Token: 0x1700008C RID: 140
			// (get) Token: 0x060003BC RID: 956 RVA: 0x000093AD File Offset: 0x000083AD
			public ICollection<TFirst> Values
			{
				get
				{
					return this.owner.secondToFirst.Values;
				}
			}

			// Token: 0x1700008D RID: 141
			// (get) Token: 0x060003BD RID: 957 RVA: 0x000093BF File Offset: 0x000083BF
			ICollection IDictionary.Values
			{
				get
				{
					return ((IDictionary)this.owner.secondToFirst).Values;
				}
			}

			// Token: 0x1700008E RID: 142
			// (get) Token: 0x060003BE RID: 958 RVA: 0x000093D6 File Offset: 0x000083D6
			IEnumerable<TFirst> IReadOnlyDictionary<!1, !0>.Values
			{
				get
				{
					return ((IReadOnlyDictionary<TSecond, TFirst>)this.owner.secondToFirst).Values;
				}
			}

			// Token: 0x060003BF RID: 959 RVA: 0x000093ED File Offset: 0x000083ED
			public IEnumerator<KeyValuePair<TSecond, TFirst>> GetEnumerator()
			{
				return this.owner.secondToFirst.GetEnumerator();
			}

			// Token: 0x060003C0 RID: 960 RVA: 0x000093FF File Offset: 0x000083FF
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003C1 RID: 961 RVA: 0x00009407 File Offset: 0x00008407
			IDictionaryEnumerator IDictionary.GetEnumerator()
			{
				return ((IDictionary)this.owner.secondToFirst).GetEnumerator();
			}

			// Token: 0x060003C2 RID: 962 RVA: 0x0000941E File Offset: 0x0000841E
			public void Add(TSecond key, TFirst value)
			{
				this.owner.secondToFirst.Add(key, value);
				this.owner.firstToSecond.Add(value, key);
			}

			// Token: 0x060003C3 RID: 963 RVA: 0x00009444 File Offset: 0x00008444
			void IDictionary.Add(object key, object value)
			{
				((IDictionary)this.owner.secondToFirst).Add(key, value);
				((IDictionary)this.owner.firstToSecond).Add(value, key);
			}

			// Token: 0x060003C4 RID: 964 RVA: 0x00009474 File Offset: 0x00008474
			void ICollection<KeyValuePair<!1, !0>>.Add(KeyValuePair<TSecond, TFirst> item)
			{
				this.owner.secondToFirst.Add(item);
				this.owner.firstToSecond.Add(item.Value, item.Key);
			}

			// Token: 0x060003C5 RID: 965 RVA: 0x000094A5 File Offset: 0x000084A5
			public bool ContainsKey(TSecond key)
			{
				return this.owner.secondToFirst.ContainsKey(key);
			}

			// Token: 0x060003C6 RID: 966 RVA: 0x000094B8 File Offset: 0x000084B8
			bool ICollection<KeyValuePair<!1, !0>>.Contains(KeyValuePair<TSecond, TFirst> item)
			{
				return this.owner.secondToFirst.Contains(item);
			}

			// Token: 0x060003C7 RID: 967 RVA: 0x000094CB File Offset: 0x000084CB
			public bool TryGetValue(TSecond key, out TFirst value)
			{
				return this.owner.secondToFirst.TryGetValue(key, out value);
			}

			// Token: 0x060003C8 RID: 968 RVA: 0x000094E0 File Offset: 0x000084E0
			public bool Remove(TSecond key)
			{
				TFirst key2;
				if (this.owner.secondToFirst.TryGetValue(key, out key2))
				{
					this.owner.secondToFirst.Remove(key);
					this.owner.firstToSecond.Remove(key2);
					return true;
				}
				return false;
			}

			// Token: 0x060003C9 RID: 969 RVA: 0x0000952C File Offset: 0x0000852C
			void IDictionary.Remove(object key)
			{
				IDictionary dictionary = (IDictionary)this.owner.secondToFirst;
				if (!dictionary.Contains(key))
				{
					return;
				}
				object key2 = dictionary[key];
				dictionary.Remove(key);
				((IDictionary)this.owner.firstToSecond).Remove(key2);
			}

			// Token: 0x060003CA RID: 970 RVA: 0x00009579 File Offset: 0x00008579
			bool ICollection<KeyValuePair<!1, !0>>.Remove(KeyValuePair<TSecond, TFirst> item)
			{
				return this.owner.secondToFirst.Remove(item);
			}

			// Token: 0x060003CB RID: 971 RVA: 0x0000958C File Offset: 0x0000858C
			bool IDictionary.Contains(object key)
			{
				return ((IDictionary)this.owner.secondToFirst).Contains(key);
			}

			// Token: 0x060003CC RID: 972 RVA: 0x000095A4 File Offset: 0x000085A4
			public void Clear()
			{
				this.owner.secondToFirst.Clear();
				this.owner.firstToSecond.Clear();
			}

			// Token: 0x060003CD RID: 973 RVA: 0x000095C6 File Offset: 0x000085C6
			void ICollection<KeyValuePair<!1, !0>>.CopyTo(KeyValuePair<TSecond, TFirst>[] array, int arrayIndex)
			{
				this.owner.secondToFirst.CopyTo(array, arrayIndex);
			}

			// Token: 0x060003CE RID: 974 RVA: 0x000095DA File Offset: 0x000085DA
			void ICollection.CopyTo(Array array, int index)
			{
				((IDictionary)this.owner.secondToFirst).CopyTo(array, index);
			}

			// Token: 0x04000099 RID: 153
			private readonly TwoWayDictionary<TFirst, TSecond> owner;
		}
	}
}
