using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B25 RID: 2853
	internal enum NSOpenGLPixelFormatAttribute
	{
		// Token: 0x0400B570 RID: 46448
		AllRenderers = 1,
		// Token: 0x0400B571 RID: 46449
		TrippleBuffer = 3,
		// Token: 0x0400B572 RID: 46450
		DoubleBuffer = 5,
		// Token: 0x0400B573 RID: 46451
		Stereo,
		// Token: 0x0400B574 RID: 46452
		AuxBuffers,
		// Token: 0x0400B575 RID: 46453
		ColorSize,
		// Token: 0x0400B576 RID: 46454
		AlphaSize = 11,
		// Token: 0x0400B577 RID: 46455
		DepthSize,
		// Token: 0x0400B578 RID: 46456
		StencilSize,
		// Token: 0x0400B579 RID: 46457
		AccumSize,
		// Token: 0x0400B57A RID: 46458
		MinimumPolicy = 51,
		// Token: 0x0400B57B RID: 46459
		MaximumPolicy,
		// Token: 0x0400B57C RID: 46460
		OffScreen,
		// Token: 0x0400B57D RID: 46461
		FullScreen,
		// Token: 0x0400B57E RID: 46462
		SampleBuffers,
		// Token: 0x0400B57F RID: 46463
		Samples,
		// Token: 0x0400B580 RID: 46464
		AuxDepthStencil,
		// Token: 0x0400B581 RID: 46465
		ColorFloat,
		// Token: 0x0400B582 RID: 46466
		Multisample,
		// Token: 0x0400B583 RID: 46467
		Supersample,
		// Token: 0x0400B584 RID: 46468
		SampleAlpha,
		// Token: 0x0400B585 RID: 46469
		RendererID = 70,
		// Token: 0x0400B586 RID: 46470
		SingleRenderer,
		// Token: 0x0400B587 RID: 46471
		NoRecovery,
		// Token: 0x0400B588 RID: 46472
		Accelerated,
		// Token: 0x0400B589 RID: 46473
		ClosestPolicy,
		// Token: 0x0400B58A RID: 46474
		[Obsolete]
		Robust,
		// Token: 0x0400B58B RID: 46475
		BackingStore,
		// Token: 0x0400B58C RID: 46476
		[Obsolete]
		MPSafe = 78,
		// Token: 0x0400B58D RID: 46477
		Window = 80,
		// Token: 0x0400B58E RID: 46478
		[Obsolete]
		MultiScreen,
		// Token: 0x0400B58F RID: 46479
		Compliant = 83,
		// Token: 0x0400B590 RID: 46480
		ScreenMask,
		// Token: 0x0400B591 RID: 46481
		PixelBuffer = 90,
		// Token: 0x0400B592 RID: 46482
		RemotePixelBuffer,
		// Token: 0x0400B593 RID: 46483
		AllowOfflineRenderers = 96,
		// Token: 0x0400B594 RID: 46484
		AcceleratedCompute,
		// Token: 0x0400B595 RID: 46485
		OpenGLProfile = 99,
		// Token: 0x0400B596 RID: 46486
		VirtualScreenCount = 128
	}
}
