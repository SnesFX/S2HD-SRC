using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000087 RID: 135
	internal struct PixelFormatDescriptor
	{
		// Token: 0x0400030F RID: 783
		internal short Size;

		// Token: 0x04000310 RID: 784
		internal short Version;

		// Token: 0x04000311 RID: 785
		internal PixelFormatDescriptorFlags Flags;

		// Token: 0x04000312 RID: 786
		internal PixelType PixelType;

		// Token: 0x04000313 RID: 787
		internal byte ColorBits;

		// Token: 0x04000314 RID: 788
		internal byte RedBits;

		// Token: 0x04000315 RID: 789
		internal byte RedShift;

		// Token: 0x04000316 RID: 790
		internal byte GreenBits;

		// Token: 0x04000317 RID: 791
		internal byte GreenShift;

		// Token: 0x04000318 RID: 792
		internal byte BlueBits;

		// Token: 0x04000319 RID: 793
		internal byte BlueShift;

		// Token: 0x0400031A RID: 794
		internal byte AlphaBits;

		// Token: 0x0400031B RID: 795
		internal byte AlphaShift;

		// Token: 0x0400031C RID: 796
		internal byte AccumBits;

		// Token: 0x0400031D RID: 797
		internal byte AccumRedBits;

		// Token: 0x0400031E RID: 798
		internal byte AccumGreenBits;

		// Token: 0x0400031F RID: 799
		internal byte AccumBlueBits;

		// Token: 0x04000320 RID: 800
		internal byte AccumAlphaBits;

		// Token: 0x04000321 RID: 801
		internal byte DepthBits;

		// Token: 0x04000322 RID: 802
		internal byte StencilBits;

		// Token: 0x04000323 RID: 803
		internal byte AuxBuffers;

		// Token: 0x04000324 RID: 804
		internal byte LayerType;

		// Token: 0x04000325 RID: 805
		private byte Reserved;

		// Token: 0x04000326 RID: 806
		internal int LayerMask;

		// Token: 0x04000327 RID: 807
		internal int VisibleMask;

		// Token: 0x04000328 RID: 808
		internal int DamageMask;
	}
}
