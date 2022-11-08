using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000127 RID: 295
	[Flags]
	internal enum CreateWindowMask : long
	{
		// Token: 0x04000A5D RID: 2653
		CWBackPixmap = 1L,
		// Token: 0x04000A5E RID: 2654
		CWBackPixel = 2L,
		// Token: 0x04000A5F RID: 2655
		CWSaveUnder = 1024L,
		// Token: 0x04000A60 RID: 2656
		CWEventMask = 2048L,
		// Token: 0x04000A61 RID: 2657
		CWDontPropagate = 4096L,
		// Token: 0x04000A62 RID: 2658
		CWColormap = 8192L,
		// Token: 0x04000A63 RID: 2659
		CWCursor = 16384L,
		// Token: 0x04000A64 RID: 2660
		CWBorderPixmap = 4L,
		// Token: 0x04000A65 RID: 2661
		CWBorderPixel = 8L,
		// Token: 0x04000A66 RID: 2662
		CWBitGravity = 16L,
		// Token: 0x04000A67 RID: 2663
		CWWinGravity = 32L,
		// Token: 0x04000A68 RID: 2664
		CWBackingStore = 64L,
		// Token: 0x04000A69 RID: 2665
		CWBackingPlanes = 128L,
		// Token: 0x04000A6A RID: 2666
		CWBackingPixel = 256L,
		// Token: 0x04000A6B RID: 2667
		CWOverrideRedirect = 512L
	}
}
