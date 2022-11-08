using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200062E RID: 1582
	public enum ArbMapBufferRange
	{
		// Token: 0x04006153 RID: 24915
		MapReadBit = 1,
		// Token: 0x04006154 RID: 24916
		MapWriteBit,
		// Token: 0x04006155 RID: 24917
		MapInvalidateRangeBit = 4,
		// Token: 0x04006156 RID: 24918
		MapInvalidateBufferBit = 8,
		// Token: 0x04006157 RID: 24919
		MapFlushExplicitBit = 16,
		// Token: 0x04006158 RID: 24920
		MapUnsynchronizedBit = 32
	}
}
