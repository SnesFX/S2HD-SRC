using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020002A6 RID: 678
	[Flags]
	public enum BufferAccessMask
	{
		// Token: 0x04002D90 RID: 11664
		MapReadBit = 1,
		// Token: 0x04002D91 RID: 11665
		MapWriteBit = 2,
		// Token: 0x04002D92 RID: 11666
		MapInvalidateRangeBit = 4,
		// Token: 0x04002D93 RID: 11667
		MapInvalidateBufferBit = 8,
		// Token: 0x04002D94 RID: 11668
		MapFlushExplicitBit = 16,
		// Token: 0x04002D95 RID: 11669
		MapUnsynchronizedBit = 32,
		// Token: 0x04002D96 RID: 11670
		MapPersistentBit = 64,
		// Token: 0x04002D97 RID: 11671
		MapCoherentBit = 128
	}
}
