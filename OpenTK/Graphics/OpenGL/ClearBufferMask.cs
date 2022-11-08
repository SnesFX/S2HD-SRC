using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020002B6 RID: 694
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x04002DEF RID: 11759
		None = 0,
		// Token: 0x04002DF0 RID: 11760
		DepthBufferBit = 256,
		// Token: 0x04002DF1 RID: 11761
		AccumBufferBit = 512,
		// Token: 0x04002DF2 RID: 11762
		StencilBufferBit = 1024,
		// Token: 0x04002DF3 RID: 11763
		ColorBufferBit = 16384,
		// Token: 0x04002DF4 RID: 11764
		CoverageBufferBitNv = 32768
	}
}
