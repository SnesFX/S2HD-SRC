using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000125 RID: 293
	internal enum WindowHints
	{
		// Token: 0x04000A43 RID: 2627
		SkipFocus = 1,
		// Token: 0x04000A44 RID: 2628
		SkipWinlist,
		// Token: 0x04000A45 RID: 2629
		SkipTaskbar = 4,
		// Token: 0x04000A46 RID: 2630
		GroupTransient = 8,
		// Token: 0x04000A47 RID: 2631
		FocusOnClick = 16,
		// Token: 0x04000A48 RID: 2632
		DoNotCover = 32
	}
}
