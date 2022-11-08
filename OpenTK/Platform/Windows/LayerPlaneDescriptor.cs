using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000088 RID: 136
	internal struct LayerPlaneDescriptor
	{
		// Token: 0x04000329 RID: 809
		internal static readonly short Size = (short)Marshal.SizeOf(typeof(LayerPlaneDescriptor));

		// Token: 0x0400032A RID: 810
		internal short Version;

		// Token: 0x0400032B RID: 811
		internal int Flags;

		// Token: 0x0400032C RID: 812
		internal byte PixelType;

		// Token: 0x0400032D RID: 813
		internal byte ColorBits;

		// Token: 0x0400032E RID: 814
		internal byte RedBits;

		// Token: 0x0400032F RID: 815
		internal byte RedShift;

		// Token: 0x04000330 RID: 816
		internal byte GreenBits;

		// Token: 0x04000331 RID: 817
		internal byte GreenShift;

		// Token: 0x04000332 RID: 818
		internal byte BlueBits;

		// Token: 0x04000333 RID: 819
		internal byte BlueShift;

		// Token: 0x04000334 RID: 820
		internal byte AlphaBits;

		// Token: 0x04000335 RID: 821
		internal byte AlphaShift;

		// Token: 0x04000336 RID: 822
		internal byte AccumBits;

		// Token: 0x04000337 RID: 823
		internal byte AccumRedBits;

		// Token: 0x04000338 RID: 824
		internal byte AccumGreenBits;

		// Token: 0x04000339 RID: 825
		internal byte AccumBlueBits;

		// Token: 0x0400033A RID: 826
		internal byte AccumAlphaBits;

		// Token: 0x0400033B RID: 827
		internal byte DepthBits;

		// Token: 0x0400033C RID: 828
		internal byte StencilBits;

		// Token: 0x0400033D RID: 829
		internal byte AuxBuffers;

		// Token: 0x0400033E RID: 830
		internal byte LayerPlane;

		// Token: 0x0400033F RID: 831
		private byte Reserved;

		// Token: 0x04000340 RID: 832
		internal int crTransparent;
	}
}
