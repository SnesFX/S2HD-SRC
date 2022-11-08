using System;

namespace System.Collections.Generic
{
	// Token: 0x0200003F RID: 63
	internal interface ISortKeyCollection<in TKey>
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600037A RID: 890
		IComparer<TKey> KeyComparer { get; }
	}
}
