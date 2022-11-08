using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200041C RID: 1052
	public enum RenderbufferStorage
	{
		// Token: 0x04003FD7 RID: 16343
		DepthComponent = 6402,
		// Token: 0x04003FD8 RID: 16344
		R3G3B2 = 10768,
		// Token: 0x04003FD9 RID: 16345
		Alpha4 = 32827,
		// Token: 0x04003FDA RID: 16346
		Alpha8,
		// Token: 0x04003FDB RID: 16347
		Alpha12,
		// Token: 0x04003FDC RID: 16348
		Alpha16,
		// Token: 0x04003FDD RID: 16349
		Rgb4 = 32847,
		// Token: 0x04003FDE RID: 16350
		Rgb5,
		// Token: 0x04003FDF RID: 16351
		Rgb8,
		// Token: 0x04003FE0 RID: 16352
		Rgb10,
		// Token: 0x04003FE1 RID: 16353
		Rgb12,
		// Token: 0x04003FE2 RID: 16354
		Rgb16,
		// Token: 0x04003FE3 RID: 16355
		Rgba2,
		// Token: 0x04003FE4 RID: 16356
		Rgba4,
		// Token: 0x04003FE5 RID: 16357
		Rgba8 = 32856,
		// Token: 0x04003FE6 RID: 16358
		Rgb10A2,
		// Token: 0x04003FE7 RID: 16359
		Rgba12,
		// Token: 0x04003FE8 RID: 16360
		Rgba16,
		// Token: 0x04003FE9 RID: 16361
		DepthComponent16 = 33189,
		// Token: 0x04003FEA RID: 16362
		DepthComponent24,
		// Token: 0x04003FEB RID: 16363
		DepthComponent32,
		// Token: 0x04003FEC RID: 16364
		R8 = 33321,
		// Token: 0x04003FED RID: 16365
		R16,
		// Token: 0x04003FEE RID: 16366
		Rg8,
		// Token: 0x04003FEF RID: 16367
		Rg16,
		// Token: 0x04003FF0 RID: 16368
		R16f,
		// Token: 0x04003FF1 RID: 16369
		R32f,
		// Token: 0x04003FF2 RID: 16370
		Rg16f,
		// Token: 0x04003FF3 RID: 16371
		Rg32f,
		// Token: 0x04003FF4 RID: 16372
		R8i,
		// Token: 0x04003FF5 RID: 16373
		R8ui,
		// Token: 0x04003FF6 RID: 16374
		R16i,
		// Token: 0x04003FF7 RID: 16375
		R16ui,
		// Token: 0x04003FF8 RID: 16376
		R32i,
		// Token: 0x04003FF9 RID: 16377
		R32ui,
		// Token: 0x04003FFA RID: 16378
		Rg8i,
		// Token: 0x04003FFB RID: 16379
		Rg8ui,
		// Token: 0x04003FFC RID: 16380
		Rg16i,
		// Token: 0x04003FFD RID: 16381
		Rg16ui,
		// Token: 0x04003FFE RID: 16382
		Rg32i,
		// Token: 0x04003FFF RID: 16383
		Rg32ui,
		// Token: 0x04004000 RID: 16384
		DepthStencil = 34041,
		// Token: 0x04004001 RID: 16385
		Rgba32f = 34836,
		// Token: 0x04004002 RID: 16386
		Rgb32f,
		// Token: 0x04004003 RID: 16387
		Rgba16f = 34842,
		// Token: 0x04004004 RID: 16388
		Rgb16f,
		// Token: 0x04004005 RID: 16389
		Depth24Stencil8 = 35056,
		// Token: 0x04004006 RID: 16390
		R11fG11fB10f = 35898,
		// Token: 0x04004007 RID: 16391
		Rgb9E5 = 35901,
		// Token: 0x04004008 RID: 16392
		Srgb8 = 35905,
		// Token: 0x04004009 RID: 16393
		Srgb8Alpha8 = 35907,
		// Token: 0x0400400A RID: 16394
		DepthComponent32f = 36012,
		// Token: 0x0400400B RID: 16395
		Depth32fStencil8,
		// Token: 0x0400400C RID: 16396
		StencilIndex1 = 36166,
		// Token: 0x0400400D RID: 16397
		StencilIndex1Ext = 36166,
		// Token: 0x0400400E RID: 16398
		StencilIndex4,
		// Token: 0x0400400F RID: 16399
		StencilIndex4Ext = 36167,
		// Token: 0x04004010 RID: 16400
		StencilIndex8,
		// Token: 0x04004011 RID: 16401
		StencilIndex8Ext = 36168,
		// Token: 0x04004012 RID: 16402
		StencilIndex16,
		// Token: 0x04004013 RID: 16403
		StencilIndex16Ext = 36169,
		// Token: 0x04004014 RID: 16404
		Rgba32ui = 36208,
		// Token: 0x04004015 RID: 16405
		Rgb32ui,
		// Token: 0x04004016 RID: 16406
		Rgba16ui = 36214,
		// Token: 0x04004017 RID: 16407
		Rgb16ui,
		// Token: 0x04004018 RID: 16408
		Rgba8ui = 36220,
		// Token: 0x04004019 RID: 16409
		Rgb8ui,
		// Token: 0x0400401A RID: 16410
		Rgba32i = 36226,
		// Token: 0x0400401B RID: 16411
		Rgb32i,
		// Token: 0x0400401C RID: 16412
		Rgba16i = 36232,
		// Token: 0x0400401D RID: 16413
		Rgb16i,
		// Token: 0x0400401E RID: 16414
		Rgba8i = 36238,
		// Token: 0x0400401F RID: 16415
		Rgb8i,
		// Token: 0x04004020 RID: 16416
		Rgb10A2ui = 36975
	}
}
