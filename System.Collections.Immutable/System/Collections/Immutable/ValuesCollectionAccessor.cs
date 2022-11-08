using System;

namespace System.Collections.Immutable
{
	// Token: 0x02000035 RID: 53
	internal class ValuesCollectionAccessor<TKey, TValue> : KeysOrValuesCollectionAccessor<TKey, TValue, TValue>
	{
		// Token: 0x06000341 RID: 833 RVA: 0x00008BED File Offset: 0x00006DED
		internal ValuesCollectionAccessor(IImmutableDictionary<TKey, TValue> dictionary) : base(dictionary, dictionary.Values)
		{
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00008BFC File Offset: 0x00006DFC
		public override bool Contains(TValue item)
		{
			ImmutableSortedDictionary<TKey, TValue> immutableSortedDictionary = base.Dictionary as ImmutableSortedDictionary<TKey, TValue>;
			if (immutableSortedDictionary != null)
			{
				return immutableSortedDictionary.ContainsValue(item);
			}
			IImmutableDictionaryInternal<TKey, TValue> immutableDictionaryInternal = base.Dictionary as IImmutableDictionaryInternal<TKey, TValue>;
			if (immutableDictionaryInternal != null)
			{
				return immutableDictionaryInternal.ContainsValue(item);
			}
			throw new NotSupportedException();
		}
	}
}
