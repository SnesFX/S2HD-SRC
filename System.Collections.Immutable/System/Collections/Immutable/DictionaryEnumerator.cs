using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x0200000A RID: 10
	internal class DictionaryEnumerator<TKey, TValue> : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002B04 File Offset: 0x00000D04
		internal DictionaryEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> inner)
		{
			Requires.NotNull<IEnumerator<KeyValuePair<TKey, TValue>>>(inner, "inner");
			this._inner = inner;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002B20 File Offset: 0x00000D20
		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this._inner.Current;
				object key = keyValuePair.Key;
				keyValuePair = this._inner.Current;
				return new DictionaryEntry(key, keyValuePair.Value);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002B64 File Offset: 0x00000D64
		public object Key
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this._inner.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002B8C File Offset: 0x00000D8C
		public object Value
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this._inner.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002BB1 File Offset: 0x00000DB1
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002BBE File Offset: 0x00000DBE
		public bool MoveNext()
		{
			return this._inner.MoveNext();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002BCB File Offset: 0x00000DCB
		public void Reset()
		{
			this._inner.Reset();
		}

		// Token: 0x04000006 RID: 6
		private readonly IEnumerator<KeyValuePair<TKey, TValue>> _inner;
	}
}
