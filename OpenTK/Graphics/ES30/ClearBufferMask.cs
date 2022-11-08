using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007A5 RID: 1957
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x04007F80 RID: 32640
		DepthBufferBit = 256,
		// Token: 0x04007F81 RID: 32641
		AccumBufferBit = 512,
		// Token: 0x04007F82 RID: 32642
		StencilBufferBit = 1024,
		// Token: 0x04007F83 RID: 32643
		ColorBufferBit = 16384,
		// Token: 0x04007F84 RID: 32644
		CoverageBufferBitNv = 32768
	}
}
