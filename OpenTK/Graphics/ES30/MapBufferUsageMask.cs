using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000831 RID: 2097
	[Flags]
	public enum MapBufferUsageMask
	{
		// Token: 0x04008942 RID: 35138
		MapReadBit = 1,
		// Token: 0x04008943 RID: 35139
		MapReadBitExt = 1,
		// Token: 0x04008944 RID: 35140
		MapWriteBit = 2,
		// Token: 0x04008945 RID: 35141
		MapWriteBitExt = 2,
		// Token: 0x04008946 RID: 35142
		MapInvalidateRangeBit = 4,
		// Token: 0x04008947 RID: 35143
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04008948 RID: 35144
		MapInvalidateBufferBit = 8,
		// Token: 0x04008949 RID: 35145
		MapInvalidateBufferBitExt = 8,
		// Token: 0x0400894A RID: 35146
		MapFlushExplicitBit = 16,
		// Token: 0x0400894B RID: 35147
		MapFlushExplicitBitExt = 16,
		// Token: 0x0400894C RID: 35148
		MapUnsynchronizedBit = 32,
		// Token: 0x0400894D RID: 35149
		MapUnsynchronizedBitExt = 32,
		// Token: 0x0400894E RID: 35150
		MapPersistentBit = 64,
		// Token: 0x0400894F RID: 35151
		MapCoherentBit = 128,
		// Token: 0x04008950 RID: 35152
		DynamicStorageBit = 256,
		// Token: 0x04008951 RID: 35153
		ClientStorageBit = 512
	}
}
