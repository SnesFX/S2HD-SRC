using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace S2HD.Menu
{
	// Token: 0x020000B2 RID: 178
	internal class ListMenuViewModel : IListMenuViewModel, IMenuViewModel
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0001D2AF File Offset: 0x0001B4AF
		public ImmutableArray<IMenuItem> Items { get; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001D2B7 File Offset: 0x0001B4B7
		public object Tag { get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0001D2BF File Offset: 0x0001B4BF
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x0001D2C7 File Offset: 0x0001B4C7
		public int HighlightedIndex { get; set; }

		// Token: 0x06000436 RID: 1078 RVA: 0x0001D2D0 File Offset: 0x0001B4D0
		public ListMenuViewModel(IEnumerable<IMenuItem> items, object tag = null) : this(items.ToImmutableArray<IMenuItem>(), tag)
		{
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001D2DF File Offset: 0x0001B4DF
		public ListMenuViewModel(ImmutableArray<IMenuItem> items, object tag = null)
		{
			this.Items = items;
			this.Tag = tag;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0001D2F5 File Offset: 0x0001B4F5
		public override string ToString()
		{
			return string.Join<IMenuItem>(", ", this.Items);
		}
	}
}
