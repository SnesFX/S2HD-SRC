using System;

namespace System.Collections.Generic
{
	// Token: 0x0200003E RID: 62
	internal interface IHashKeyCollection<in TKey>
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000379 RID: 889
		IEqualityComparer<TKey> KeyComparer { get; }
	}
}
