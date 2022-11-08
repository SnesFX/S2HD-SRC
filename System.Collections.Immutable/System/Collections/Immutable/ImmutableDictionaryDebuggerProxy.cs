using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x0200001F RID: 31
	internal class ImmutableDictionaryDebuggerProxy<TKey, TValue> : ImmutableEnumerableDebuggerProxy<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0000509E File Offset: 0x0000329E
		public ImmutableDictionaryDebuggerProxy(IImmutableDictionary<TKey, TValue> dictionary) : base(dictionary)
		{
		}
	}
}
