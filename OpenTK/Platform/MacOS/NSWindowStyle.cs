using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B24 RID: 2852
	[Flags]
	internal enum NSWindowStyle
	{
		// Token: 0x0400B562 RID: 46434
		Borderless = 0,
		// Token: 0x0400B563 RID: 46435
		Titled = 1,
		// Token: 0x0400B564 RID: 46436
		Closable = 2,
		// Token: 0x0400B565 RID: 46437
		Miniaturizable = 4,
		// Token: 0x0400B566 RID: 46438
		Resizable = 8,
		// Token: 0x0400B567 RID: 46439
		Utility = 16,
		// Token: 0x0400B568 RID: 46440
		DocModal = 64,
		// Token: 0x0400B569 RID: 46441
		NonactivatingPanel = 128,
		// Token: 0x0400B56A RID: 46442
		TexturedBackground = 256,
		// Token: 0x0400B56B RID: 46443
		Unscaled = 2048,
		// Token: 0x0400B56C RID: 46444
		UnifiedTitleAndToolbar = 4096,
		// Token: 0x0400B56D RID: 46445
		Hud = 8192,
		// Token: 0x0400B56E RID: 46446
		FullScreenWindow = 16384
	}
}
