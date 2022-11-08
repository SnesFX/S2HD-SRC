using System;

namespace OpenTK.Graphics.ES10
{
	// Token: 0x020004D9 RID: 1241
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x04004BEE RID: 19438
		DepthBufferBit = 256,
		// Token: 0x04004BEF RID: 19439
		StencilBufferBit = 1024,
		// Token: 0x04004BF0 RID: 19440
		ColorBufferBit = 16384
	}
}
