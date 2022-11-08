using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000229 RID: 553
	public enum ArbMapBufferRange
	{
		// Token: 0x04002881 RID: 10369
		MapReadBit = 1,
		// Token: 0x04002882 RID: 10370
		MapWriteBit,
		// Token: 0x04002883 RID: 10371
		MapInvalidateRangeBit = 4,
		// Token: 0x04002884 RID: 10372
		MapInvalidateBufferBit = 8,
		// Token: 0x04002885 RID: 10373
		MapFlushExplicitBit = 16,
		// Token: 0x04002886 RID: 10374
		MapUnsynchronizedBit = 32
	}
}
