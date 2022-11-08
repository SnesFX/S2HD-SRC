using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020001FA RID: 506
	public enum ArbBufferStorage
	{
		// Token: 0x04002630 RID: 9776
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04002631 RID: 9777
		MapReadBit = 1,
		// Token: 0x04002632 RID: 9778
		MapWriteBit,
		// Token: 0x04002633 RID: 9779
		MapPersistentBit = 64,
		// Token: 0x04002634 RID: 9780
		MapCoherentBit = 128,
		// Token: 0x04002635 RID: 9781
		DynamicStorageBit = 256,
		// Token: 0x04002636 RID: 9782
		ClientStorageBit = 512,
		// Token: 0x04002637 RID: 9783
		BufferImmutableStorage = 33311,
		// Token: 0x04002638 RID: 9784
		BufferStorageFlags
	}
}
