using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006ED RID: 1773
	[Flags]
	public enum MapBufferUsageMask
	{
		// Token: 0x04006A95 RID: 27285
		MapReadBit = 1,
		// Token: 0x04006A96 RID: 27286
		MapReadBitExt = 1,
		// Token: 0x04006A97 RID: 27287
		MapWriteBit = 2,
		// Token: 0x04006A98 RID: 27288
		MapWriteBitExt = 2,
		// Token: 0x04006A99 RID: 27289
		MapInvalidateRangeBit = 4,
		// Token: 0x04006A9A RID: 27290
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04006A9B RID: 27291
		MapInvalidateBufferBit = 8,
		// Token: 0x04006A9C RID: 27292
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04006A9D RID: 27293
		MapFlushExplicitBit = 16,
		// Token: 0x04006A9E RID: 27294
		MapFlushExplicitBitExt = 16,
		// Token: 0x04006A9F RID: 27295
		MapUnsynchronizedBit = 32,
		// Token: 0x04006AA0 RID: 27296
		MapUnsynchronizedBitExt = 32,
		// Token: 0x04006AA1 RID: 27297
		MapPersistentBit = 64,
		// Token: 0x04006AA2 RID: 27298
		MapCoherentBit = 128,
		// Token: 0x04006AA3 RID: 27299
		DynamicStorageBit = 256,
		// Token: 0x04006AA4 RID: 27300
		ClientStorageBit = 512
	}
}
