using System;
using System.Collections.Generic;

namespace S2HD.Menu
{
	// Token: 0x020000BD RID: 189
	internal interface ISpinnerSetting : ISetting
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600047D RID: 1149
		IReadOnlyList<string> Values { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600047E RID: 1150
		// (set) Token: 0x0600047F RID: 1151
		int SelectedIndex { get; set; }
	}
}
