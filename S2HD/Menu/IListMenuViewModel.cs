using System;
using System.Collections.Immutable;

namespace S2HD.Menu
{
	// Token: 0x020000B0 RID: 176
	internal interface IListMenuViewModel : IMenuViewModel
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600042E RID: 1070
		ImmutableArray<IMenuItem> Items { get; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600042F RID: 1071
		// (set) Token: 0x06000430 RID: 1072
		int HighlightedIndex { get; set; }
	}
}
