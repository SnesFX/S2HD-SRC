using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A1D RID: 2589
	[Flags]
	public enum AttribMask
	{
		// Token: 0x0400AA6A RID: 43626
		CurrentBit = 1,
		// Token: 0x0400AA6B RID: 43627
		PointBit = 2,
		// Token: 0x0400AA6C RID: 43628
		LineBit = 4,
		// Token: 0x0400AA6D RID: 43629
		PolygonBit = 8,
		// Token: 0x0400AA6E RID: 43630
		PolygonStippleBit = 16,
		// Token: 0x0400AA6F RID: 43631
		PixelModeBit = 32,
		// Token: 0x0400AA70 RID: 43632
		LightingBit = 64,
		// Token: 0x0400AA71 RID: 43633
		FogBit = 128,
		// Token: 0x0400AA72 RID: 43634
		DepthBufferBit = 256,
		// Token: 0x0400AA73 RID: 43635
		AccumBufferBit = 512,
		// Token: 0x0400AA74 RID: 43636
		StencilBufferBit = 1024,
		// Token: 0x0400AA75 RID: 43637
		ViewportBit = 2048,
		// Token: 0x0400AA76 RID: 43638
		TransformBit = 4096,
		// Token: 0x0400AA77 RID: 43639
		EnableBit = 8192,
		// Token: 0x0400AA78 RID: 43640
		ColorBufferBit = 16384,
		// Token: 0x0400AA79 RID: 43641
		HintBit = 32768,
		// Token: 0x0400AA7A RID: 43642
		EvalBit = 65536,
		// Token: 0x0400AA7B RID: 43643
		ListBit = 131072,
		// Token: 0x0400AA7C RID: 43644
		TextureBit = 262144,
		// Token: 0x0400AA7D RID: 43645
		ScissorBit = 524288,
		// Token: 0x0400AA7E RID: 43646
		MultisampleBit = 536870912,
		// Token: 0x0400AA7F RID: 43647
		MultisampleBit3Dfx = 536870912,
		// Token: 0x0400AA80 RID: 43648
		MultisampleBitArb = 536870912,
		// Token: 0x0400AA81 RID: 43649
		MultisampleBitExt = 536870912,
		// Token: 0x0400AA82 RID: 43650
		AllAttribBits = -1
	}
}
