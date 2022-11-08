using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Accord.Collections
{
	// Token: 0x0200006F RID: 111
	[Serializable]
	public abstract class ReadOnlyKeyedCollection<TKey, TValue> : ReadOnlyCollection<TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IList<TValue>, ICollection<TValue>, IEnumerable<TValue>, IReadOnlyCollection<TValue>
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00007260 File Offset: 0x00006260
		protected ReadOnlyKeyedCollection(IList<TValue> components) : base(components)
		{
			this.dictionary = new Dictionary<TKey, TValue>();
			foreach (TValue tvalue in components)
			{
				this.dictionary.Add(this.GetKeyForItem(tvalue), tvalue);
			}
		}

		// Token: 0x060002F3 RID: 755
		protected abstract TKey GetKeyForItem(TValue item);

		// Token: 0x060002F4 RID: 756 RVA: 0x000072C8 File Offset: 0x000062C8
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
		{
			return this.dictionary.GetEnumerator();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000072DA File Offset: 0x000062DA
		public bool ContainsKey(TKey key)
		{
			return this.dictionary.ContainsKey(key);
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x000072E8 File Offset: 0x000062E8
		public ICollection<TKey> Keys
		{
			get
			{
				return this.dictionary.Keys;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x000072F5 File Offset: 0x000062F5
		public ICollection<TValue> Values
		{
			get
			{
				return this.dictionary.Values;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00007302 File Offset: 0x00006302
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.dictionary.TryGetValue(key, out value);
		}

		// Token: 0x17000059 RID: 89
		public TValue this[TKey key]
		{
			get
			{
				return this.dictionary[key];
			}
			set
			{
				throw new NotSupportedException("This collection is read-only");
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000732B File Offset: 0x0000632B
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<!0, !1>>)this.dictionary).Contains(item);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00007339 File Offset: 0x00006339
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<!0, !1>>)this.dictionary).CopyTo(array, arrayIndex);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000731F File Offset: 0x0000631F
		public void Add(TKey key, TValue value)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000731F File Offset: 0x0000631F
		public void Add(KeyValuePair<TValue, TKey> item)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000731F File Offset: 0x0000631F
		public bool Remove(TKey key)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000731F File Offset: 0x0000631F
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000731F File Offset: 0x0000631F
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000731F File Offset: 0x0000631F
		public void Insert(int index, TValue item)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000731F File Offset: 0x0000631F
		public void RemoveAt(int index)
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000731F File Offset: 0x0000631F
		public void Clear()
		{
			throw new NotSupportedException("This collection is read-only");
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00005C0B File Offset: 0x00004C0B
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x04000046 RID: 70
		private Dictionary<TKey, TValue> dictionary;
	}
}
