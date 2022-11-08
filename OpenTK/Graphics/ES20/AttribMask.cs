using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x020008E9 RID: 2281
	[Flags]
	public enum AttribMask
	{
		// Token: 0x0400977D RID: 38781
		CurrentBit = 1,
		// Token: 0x0400977E RID: 38782
		PointBit = 2,
		// Token: 0x0400977F RID: 38783
		LineBit = 4,
		// Token: 0x04009780 RID: 38784
		PolygonBit = 8,
		// Token: 0x04009781 RID: 38785
		PolygonStippleBit = 16,
		// Token: 0x04009782 RID: 38786
		PixelModeBit = 32,
		// Token: 0x04009783 RID: 38787
		LightingBit = 64,
		// Token: 0x04009784 RID: 38788
		FogBit = 128,
		// Token: 0x04009785 RID: 38789
		DepthBufferBit = 256,
		// Token: 0x04009786 RID: 38790
		AccumBufferBit = 512,
		// Token: 0x04009787 RID: 38791
		StencilBufferBit = 1024,
		// Token: 0x04009788 RID: 38792
		ViewportBit = 2048,
		// Token: 0x04009789 RID: 38793
		TransformBit = 4096,
		// Token: 0x0400978A RID: 38794
		EnableBit = 8192,
		// Token: 0x0400978B RID: 38795
		ColorBufferBit = 16384,
		// Token: 0x0400978C RID: 38796
		HintBit = 32768,
		// Token: 0x0400978D RID: 38797
		EvalBit = 65536,
		// Token: 0x0400978E RID: 38798
		ListBit = 131072,
		// Token: 0x0400978F RID: 38799
		TextureBit = 262144,
		// Token: 0x04009790 RID: 38800
		ScissorBit = 524288,
		// Token: 0x04009791 RID: 38801
		MultisampleBit = 536870912,
		// Token: 0x04009792 RID: 38802
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04009793 RID: 38803
		MultisampleBitArb = 536870912,
		// Token: 0x04009794 RID: 38804
		MultisampleBitExt = 536870912,
		// Token: 0x04009795 RID: 38805
		AllAttribBits = -1
	}
}
