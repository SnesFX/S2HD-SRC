using System;
using System.Collections.Immutable;

namespace S2HD.Menu
{
	// Token: 0x020000AF RID: 175
	internal interface ISettingListMenuViewModel : IMenuViewModel
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600042D RID: 1069
		ImmutableArray<ISetting> Items { get; }
	}
}
