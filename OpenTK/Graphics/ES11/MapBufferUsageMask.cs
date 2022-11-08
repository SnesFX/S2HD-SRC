using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A73 RID: 2675
	[Flags]
	public enum MapBufferUsageMask
	{
		// Token: 0x0400AF41 RID: 44865
		MapReadBit = 1,
		// Token: 0x0400AF42 RID: 44866
		MapReadBitExt = 1,
		// Token: 0x0400AF43 RID: 44867
		MapWriteBit = 2,
		// Token: 0x0400AF44 RID: 44868
		MapWriteBitExt = 2,
		// Token: 0x0400AF45 RID: 44869
		MapInvalidateRangeBit = 4,
		// Token: 0x0400AF46 RID: 44870
		MapInvalidateRangeBitExt = 4,
		// Token: 0x0400AF47 RID: 44871
		MapInvalidateBufferBit = 8,
		// Token: 0x0400AF48 RID: 44872
		MapInvalidateBufferBitExt = 8,
		// Token: 0x0400AF49 RID: 44873
		MapFlushExplicitBit = 16,
		// Token: 0x0400AF4A RID: 44874
		MapFlushExplicitBitExt = 16,
		// Token: 0x0400AF4B RID: 44875
		MapUnsynchronizedBit = 32,
		// Token: 0x0400AF4C RID: 44876
		MapUnsynchronizedBitExt = 32,
		// Token: 0x0400AF4D RID: 44877
		MapPersistentBit = 64,
		// Token: 0x0400AF4E RID: 44878
		MapCoherentBit = 128,
		// Token: 0x0400AF4F RID: 44879
		DynamicStorageBit = 256,
		// Token: 0x0400AF50 RID: 44880
		ClientStorageBit = 512
	}
}
