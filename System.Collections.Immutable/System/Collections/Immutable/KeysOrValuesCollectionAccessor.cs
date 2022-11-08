using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000033 RID: 51
	internal abstract class KeysOrValuesCollectionAccessor<TKey, TValue, T> : ICollection<T>, IEnumerable<!2>, IEnumerable, ICollection
	{
		// Token: 0x06000331 RID: 817 RVA: 0x00008A55 File Offset: 0x00006C55
		protected KeysOrValuesCollectionAccessor(IImmutableDictionary<TKey, TValue> dictionary, IEnumerable<T> keysOrValues)
		{
			Requires.NotNull<IImmutableDictionary<TKey, TValue>>(dictionary, "dictionary");
			Requires.NotNull<IEnumerable<T>>(keysOrValues, "keysOrValues");
			this._dictionary = dictionary;
			this._keysOrValues = keysOrValues;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00003182 File Offset: 0x00001382
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00008A81 File Offset: 0x00006C81
		public int Count
		{
			get
			{
				return this._dictionary.Count;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00008A8E File Offset: 0x00006C8E
		protected IImmutableDictionary<TKey, TValue> Dictionary
		{
			get
			{
				return this._dictionary;
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000317B File Offset: 0x0000137B
		public void Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000317B File Offset: 0x0000137B
		public void Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000337 RID: 823
		public abstract bool Contains(T item);

		// Token: 0x06000338 RID: 824 RVA: 0x00008A98 File Offset: 0x00006C98
		public void CopyTo(T[] array, int arrayIndex)
		{
			Requires.NotNull<T[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (T t in this)
			{
				array[arrayIndex++] = t;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000317B File Offset: 0x0000137B
		public bool Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00008B20 File Offset: 0x00006D20
		public IEnumerator<T> GetEnumerator()
		{
			return this._keysOrValues.GetEnumerator();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00008B2D File Offset: 0x00006D2D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00008B38 File Offset: 0x00006D38
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

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x04000035 RID: 53
		private readonly IImmutableDictionary<TKey, TValue> _dictionary;

		// Token: 0x04000036 RID: 54
		private readonly IEnumerable<T> _keysOrValues;
	}
}
