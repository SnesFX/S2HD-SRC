using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A24 RID: 2596
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x0400AAC0 RID: 43712
		DepthBufferBit = 256,
		// Token: 0x0400AAC1 RID: 43713
		AccumBufferBit = 512,
		// Token: 0x0400AAC2 RID: 43714
		StencilBufferBit = 1024,
		// Token: 0x0400AAC3 RID: 43715
		ColorBufferBit = 16384,
		// Token: 0x0400AAC4 RID: 43716
		CoverageBufferBitNv = 32768
	}
}
