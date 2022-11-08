using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000671 RID: 1649
	[Flags]
	public enum AttribMask
	{
		// Token: 0x0400638C RID: 25484
		DepthBufferBit = 256,
		// Token: 0x0400638D RID: 25485
		StencilBufferBit = 1024,
		// Token: 0x0400638E RID: 25486
		ColorBufferBit = 16384,
		// Token: 0x0400638F RID: 25487
		MultisampleBit = 536870912,
		// Token: 0x04006390 RID: 25488
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04006391 RID: 25489
		MultisampleBitArb = 536870912,
		// Token: 0x04006392 RID: 25490
		MultisampleBitExt = 536870912
	}
}
