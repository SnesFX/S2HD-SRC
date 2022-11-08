using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020002AD RID: 685
	public enum BufferStorageFlags
	{
		// Token: 0x04002DB3 RID: 11699
		MapReadBit = 1,
		// Token: 0x04002DB4 RID: 11700
		MapWriteBit,
		// Token: 0x04002DB5 RID: 11701
		MapPersistentBit = 64,
		// Token: 0x04002DB6 RID: 11702
		MapCoherentBit = 128,
		// Token: 0x04002DB7 RID: 11703
		DynamicStorageBit = 256,
		// Token: 0x04002DB8 RID: 11704
		ClientStorageBit = 512
	}
}
