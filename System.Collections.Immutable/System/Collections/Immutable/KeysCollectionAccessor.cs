using System;

namespace System.Collections.Immutable
{
	// Token: 0x02000034 RID: 52
	internal class KeysCollectionAccessor<TKey, TValue> : KeysOrValuesCollectionAccessor<TKey, TValue, TKey>
	{
		// Token: 0x0600033F RID: 831 RVA: 0x00008BD0 File Offset: 0x00006DD0
		internal KeysCollectionAccessor(IImmutableDictionary<TKey, TValue> dictionary) : base(dictionary, dictionary.Keys)
		{
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00008BDF File Offset: 0x00006DDF
		public override bool Contains(TKey item)
		{
			return base.Dictionary.ContainsKey(item);
		}
	}
}
