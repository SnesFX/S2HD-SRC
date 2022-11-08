using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x0200000F RID: 15
	public interface IImmutableDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		// Token: 0x06000054 RID: 84
		IImmutableDictionary<TKey, TValue> Clear();

		// Token: 0x06000055 RID: 85
		IImmutableDictionary<TKey, TValue> Add(TKey key, TValue value);

		// Token: 0x06000056 RID: 86
		IImmutableDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs);

		// Token: 0x06000057 RID: 87
		IImmutableDictionary<TKey, TValue> SetItem(TKey key, TValue value);

		// Token: 0x06000058 RID: 88
		IImmutableDictionary<TKey, TValue> SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items);

		// Token: 0x06000059 RID: 89
		IImmutableDictionary<TKey, TValue> RemoveRange(IEnumerable<TKey> keys);

		// Token: 0x0600005A RID: 90
		IImmutableDictionary<TKey, TValue> Remove(TKey key);

		// Token: 0x0600005B RID: 91
		bool Contains(KeyValuePair<TKey, TValue> pair);

		// Token: 0x0600005C RID: 92
		bool TryGetKey(TKey equalKey, out TKey actualKey);
	}
}
