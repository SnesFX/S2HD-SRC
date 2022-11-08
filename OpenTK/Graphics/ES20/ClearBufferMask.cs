using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x020008F6 RID: 2294
	[Flags]
	public enum ClearBufferMask
	{
		// Token: 0x040097EA RID: 38890
		DepthBufferBit = 256,
		// Token: 0x040097EB RID: 38891
		AccumBufferBit = 512,
		// Token: 0x040097EC RID: 38892
		StencilBufferBit = 1024,
		// Token: 0x040097ED RID: 38893
		ColorBufferBit = 16384,
		// Token: 0x040097EE RID: 38894
		CoverageBufferBitNv = 32768
	}
}
