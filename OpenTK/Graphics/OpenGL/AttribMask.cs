using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200029A RID: 666
	[Flags]
	public enum AttribMask
	{
		// Token: 0x04002D14 RID: 11540
		CurrentBit = 1,
		// Token: 0x04002D15 RID: 11541
		PointBit = 2,
		// Token: 0x04002D16 RID: 11542
		LineBit = 4,
		// Token: 0x04002D17 RID: 11543
		PolygonBit = 8,
		// Token: 0x04002D18 RID: 11544
		PolygonStippleBit = 16,
		// Token: 0x04002D19 RID: 11545
		PixelModeBit = 32,
		// Token: 0x04002D1A RID: 11546
		LightingBit = 64,
		// Token: 0x04002D1B RID: 11547
		FogBit = 128,
		// Token: 0x04002D1C RID: 11548
		DepthBufferBit = 256,
		// Token: 0x04002D1D RID: 11549
		AccumBufferBit = 512,
		// Token: 0x04002D1E RID: 11550
		StencilBufferBit = 1024,
		// Token: 0x04002D1F RID: 11551
		ViewportBit = 2048,
		// Token: 0x04002D20 RID: 11552
		TransformBit = 4096,
		// Token: 0x04002D21 RID: 11553
		EnableBit = 8192,
		// Token: 0x04002D22 RID: 11554
		ColorBufferBit = 16384,
		// Token: 0x04002D23 RID: 11555
		HintBit = 32768,
		// Token: 0x04002D24 RID: 11556
		EvalBit = 65536,
		// Token: 0x04002D25 RID: 11557
		ListBit = 131072,
		// Token: 0x04002D26 RID: 11558
		TextureBit = 262144,
		// Token: 0x04002D27 RID: 11559
		ScissorBit = 524288,
		// Token: 0x04002D28 RID: 11560
		MultisampleBit = 536870912,
		// Token: 0x04002D29 RID: 11561
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04002D2A RID: 11562
		MultisampleBitArb = 536870912,
		// Token: 0x04002D2B RID: 11563
		MultisampleBitExt = 536870912,
		// Token: 0x04002D2C RID: 11564
		AllAttribBits = -1
	}
}
