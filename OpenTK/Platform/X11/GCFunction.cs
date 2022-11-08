using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000173 RID: 371
	[Flags]
	internal enum GCFunction
	{
		// Token: 0x04000F21 RID: 3873
		GCFunction = 1,
		// Token: 0x04000F22 RID: 3874
		GCPlaneMask = 2,
		// Token: 0x04000F23 RID: 3875
		GCForeground = 4,
		// Token: 0x04000F24 RID: 3876
		GCBackground = 8,
		// Token: 0x04000F25 RID: 3877
		GCLineWidth = 16,
		// Token: 0x04000F26 RID: 3878
		GCLineStyle = 32,
		// Token: 0x04000F27 RID: 3879
		GCCapStyle = 64,
		// Token: 0x04000F28 RID: 3880
		GCJoinStyle = 128,
		// Token: 0x04000F29 RID: 3881
		GCFillStyle = 256,
		// Token: 0x04000F2A RID: 3882
		GCFillRule = 512,
		// Token: 0x04000F2B RID: 3883
		GCTile = 1024,
		// Token: 0x04000F2C RID: 3884
		GCStipple = 2048,
		// Token: 0x04000F2D RID: 3885
		GCTileStipXOrigin = 4096,
		// Token: 0x04000F2E RID: 3886
		GCTileStipYOrigin = 8192,
		// Token: 0x04000F2F RID: 3887
		GCFont = 16384,
		// Token: 0x04000F30 RID: 3888
		GCSubwindowMode = 32768,
		// Token: 0x04000F31 RID: 3889
		GCGraphicsExposures = 65536,
		// Token: 0x04000F32 RID: 3890
		GCClipXOrigin = 131072,
		// Token: 0x04000F33 RID: 3891
		GCClipYOrigin = 262144,
		// Token: 0x04000F34 RID: 3892
		GCClipMask = 524288,
		// Token: 0x04000F35 RID: 3893
		GCDashOffset = 1048576,
		// Token: 0x04000F36 RID: 3894
		GCDashList = 2097152,
		// Token: 0x04000F37 RID: 3895
		GCArcMode = 4194304
	}
}
