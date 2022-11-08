using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x0200097E RID: 2430
	[Flags]
	public enum MapBufferUsageMask
	{
		// Token: 0x04009FCC RID: 40908
		MapReadBit = 1,
		// Token: 0x04009FCD RID: 40909
		MapReadBitExt = 1,
		// Token: 0x04009FCE RID: 40910
		MapWriteBit = 2,
		// Token: 0x04009FCF RID: 40911
		MapWriteBitExt = 2,
		// Token: 0x04009FD0 RID: 40912
		MapInvalidateRangeBit = 4,
		// Token: 0x04009FD1 RID: 40913
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04009FD2 RID: 40914
		MapInvalidateBufferBit = 8,
		// Token: 0x04009FD3 RID: 40915
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04009FD4 RID: 40916
		MapFlushExplicitBit = 16,
		// Token: 0x04009FD5 RID: 40917
		MapFlushExplicitBitExt = 16,
		// Token: 0x04009FD6 RID: 40918
		MapUnsynchronizedBit = 32,
		// Token: 0x04009FD7 RID: 40919
		MapUnsynchronizedBitExt = 32,
		// Token: 0x04009FD8 RID: 40920
		MapPersistentBit = 64,
		// Token: 0x04009FD9 RID: 40921
		MapCoherentBit = 128,
		// Token: 0x04009FDA RID: 40922
		DynamicStorageBit = 256,
		// Token: 0x04009FDB RID: 40923
		ClientStorageBit = 512
	}
}
