using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200060A RID: 1546
	public enum ArbBufferStorage
	{
		// Token: 0x04005F91 RID: 24465
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04005F92 RID: 24466
		MapReadBit = 1,
		// Token: 0x04005F93 RID: 24467
		MapWriteBit,
		// Token: 0x04005F94 RID: 24468
		MapPersistentBit = 64,
		// Token: 0x04005F95 RID: 24469
		MapCoherentBit = 128,
		// Token: 0x04005F96 RID: 24470
		DynamicStorageBit = 256,
		// Token: 0x04005F97 RID: 24471
		ClientStorageBit = 512,
		// Token: 0x04005F98 RID: 24472
		BufferImmutableStorage = 33311,
		// Token: 0x04005F99 RID: 24473
		BufferStorageFlags
	}
}
