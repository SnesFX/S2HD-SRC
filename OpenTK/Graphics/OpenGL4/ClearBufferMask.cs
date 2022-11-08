using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200068D RID: 1677
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x04006452 RID: 25682
		None = 0,
		// Token: 0x04006453 RID: 25683
		DepthBufferBit = 256,
		// Token: 0x04006454 RID: 25684
		AccumBufferBit = 512,
		// Token: 0x04006455 RID: 25685
		StencilBufferBit = 1024,
		// Token: 0x04006456 RID: 25686
		ColorBufferBit = 16384,
		// Token: 0x04006457 RID: 25687
		CoverageBufferBitNv = 32768
	}
}
