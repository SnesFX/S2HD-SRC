using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace S2HD.Menu
{
	// Token: 0x020000C4 RID: 196
	internal class SettingListMenuViewModel : ISettingListMenuViewModel, IMenuViewModel
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0001F9F0 File Offset: 0x0001DBF0
		public ImmutableArray<ISetting> Items { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0001F9F8 File Offset: 0x0001DBF8
		public object Tag { get; }

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001FA00 File Offset: 0x0001DC00
		public SettingListMenuViewModel(IEnumerable<ISetting> items, object tag = null) : this(items.ToImmutableArray<ISetting>(), tag)
		{
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001FA0F File Offset: 0x0001DC0F
		public SettingListMenuViewModel(ImmutableArray<ISetting> items, object tag = null)
		{
			this.Items = items;
			this.Tag = tag;
		}
	}
}
