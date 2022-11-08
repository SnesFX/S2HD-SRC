using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000794 RID: 1940
	[Flags]
	public enum AttribMask
	{
		// Token: 0x04007EEF RID: 32495
		CurrentBit = 1,
		// Token: 0x04007EF0 RID: 32496
		PointBit = 2,
		// Token: 0x04007EF1 RID: 32497
		LineBit = 4,
		// Token: 0x04007EF2 RID: 32498
		PolygonBit = 8,
		// Token: 0x04007EF3 RID: 32499
		PolygonStippleBit = 16,
		// Token: 0x04007EF4 RID: 32500
		PixelModeBit = 32,
		// Token: 0x04007EF5 RID: 32501
		LightingBit = 64,
		// Token: 0x04007EF6 RID: 32502
		FogBit = 128,
		// Token: 0x04007EF7 RID: 32503
		DepthBufferBit = 256,
		// Token: 0x04007EF8 RID: 32504
		AccumBufferBit = 512,
		// Token: 0x04007EF9 RID: 32505
		StencilBufferBit = 1024,
		// Token: 0x04007EFA RID: 32506
		ViewportBit = 2048,
		// Token: 0x04007EFB RID: 32507
		TransformBit = 4096,
		// Token: 0x04007EFC RID: 32508
		EnableBit = 8192,
		// Token: 0x04007EFD RID: 32509
		ColorBufferBit = 16384,
		// Token: 0x04007EFE RID: 32510
		HintBit = 32768,
		// Token: 0x04007EFF RID: 32511
		EvalBit = 65536,
		// Token: 0x04007F00 RID: 32512
		ListBit = 131072,
		// Token: 0x04007F01 RID: 32513
		TextureBit = 262144,
		// Token: 0x04007F02 RID: 32514
		ScissorBit = 524288,
		// Token: 0x04007F03 RID: 32515
		MultisampleBit = 536870912,
		// Token: 0x04007F04 RID: 32516
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04007F05 RID: 32517
		MultisampleBitArb = 536870912,
		// Token: 0x04007F06 RID: 32518
		MultisampleBitExt = 536870912,
		// Token: 0x04007F07 RID: 32519
		AllAttribBits = -1
	}
}
