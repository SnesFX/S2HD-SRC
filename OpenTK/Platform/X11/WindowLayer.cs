using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000123 RID: 291
	internal enum WindowLayer
	{
		// Token: 0x04000A30 RID: 2608
		Desktop,
		// Token: 0x04000A31 RID: 2609
		Below = 2,
		// Token: 0x04000A32 RID: 2610
		Normal = 4,
		// Token: 0x04000A33 RID: 2611
		OnTop = 6,
		// Token: 0x04000A34 RID: 2612
		Dock = 8,
		// Token: 0x04000A35 RID: 2613
		AboveDock = 10,
		// Token: 0x04000A36 RID: 2614
		Menu = 12
	}
}
