using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B27 RID: 2855
	internal enum NSOpenGLContextParameter
	{
		// Token: 0x0400B59B RID: 46491
		[Obsolete]
		SwapRectangle = 200,
		// Token: 0x0400B59C RID: 46492
		[Obsolete]
		SwapRectangleEnable,
		// Token: 0x0400B59D RID: 46493
		[Obsolete]
		RasterizationEnable = 221,
		// Token: 0x0400B59E RID: 46494
		SwapInterval,
		// Token: 0x0400B59F RID: 46495
		SurfaceOrder = 235,
		// Token: 0x0400B5A0 RID: 46496
		SurfaceOpacity,
		// Token: 0x0400B5A1 RID: 46497
		[Obsolete]
		StateValidation = 301,
		// Token: 0x0400B5A2 RID: 46498
		SurfaceBackingSize = 304,
		// Token: 0x0400B5A3 RID: 46499
		[Obsolete]
		SurfaceSurfaceVolatile = 306,
		// Token: 0x0400B5A4 RID: 46500
		ReclaimResources = 308,
		// Token: 0x0400B5A5 RID: 46501
		CurrentRendererID,
		// Token: 0x0400B5A6 RID: 46502
		GpuVertexProcessing,
		// Token: 0x0400B5A7 RID: 46503
		GpuFragmentProcessing,
		// Token: 0x0400B5A8 RID: 46504
		HasDrawable = 314,
		// Token: 0x0400B5A9 RID: 46505
		MpsSwapsInFlight
	}
}
