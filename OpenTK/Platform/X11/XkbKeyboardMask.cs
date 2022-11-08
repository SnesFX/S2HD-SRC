using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B4F RID: 2895
	[Flags]
	internal enum XkbKeyboardMask
	{
		// Token: 0x0400B748 RID: 46920
		Controls = 1,
		// Token: 0x0400B749 RID: 46921
		ServerMap = 2,
		// Token: 0x0400B74A RID: 46922
		IClientMap = 4,
		// Token: 0x0400B74B RID: 46923
		IndicatorMap = 8,
		// Token: 0x0400B74C RID: 46924
		Names = 16,
		// Token: 0x0400B74D RID: 46925
		CompatibilityMap = 32,
		// Token: 0x0400B74E RID: 46926
		Geometry = 64,
		// Token: 0x0400B74F RID: 46927
		AllComponents = 128
	}
}
