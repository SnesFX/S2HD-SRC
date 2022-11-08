using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000684 RID: 1668
	public enum BufferStorageFlags
	{
		// Token: 0x04006416 RID: 25622
		MapReadBit = 1,
		// Token: 0x04006417 RID: 25623
		MapWriteBit,
		// Token: 0x04006418 RID: 25624
		MapPersistentBit = 64,
		// Token: 0x04006419 RID: 25625
		MapCoherentBit = 128,
		// Token: 0x0400641A RID: 25626
		DynamicStorageBit = 256,
		// Token: 0x0400641B RID: 25627
		ClientStorageBit = 512
	}
}
