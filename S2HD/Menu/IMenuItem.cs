using System;

namespace S2HD.Menu
{
	// Token: 0x020000AD RID: 173
	internal interface IMenuItem
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000421 RID: 1057
		string Text { get; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000422 RID: 1058
		IMenuViewModel Next { get; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000423 RID: 1059
		object Tag { get; }
	}
}
