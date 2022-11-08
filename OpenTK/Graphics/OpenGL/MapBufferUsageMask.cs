using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200038C RID: 908
	[Flags]
	public enum MapBufferUsageMask
	{
		// Token: 0x0400392F RID: 14639
		MapReadBit = 1,
		// Token: 0x04003930 RID: 14640
		MapReadBitExt = 1,
		// Token: 0x04003931 RID: 14641
		MapWriteBit = 2,
		// Token: 0x04003932 RID: 14642
		MapWriteBitExt = 2,
		// Token: 0x04003933 RID: 14643
		MapInvalidateRangeBit = 4,
		// Token: 0x04003934 RID: 14644
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04003935 RID: 14645
		MapInvalidateBufferBit = 8,
		// Token: 0x04003936 RID: 14646
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04003937 RID: 14647
		MapFlushExplicitBit = 16,
		// Token: 0x04003938 RID: 14648
		MapFlushExplicitBitExt = 16,
		// Token: 0x04003939 RID: 14649
		MapUnsynchronizedBit = 32,
		// Token: 0x0400393A RID: 14650
		MapUnsynchronizedBitExt = 32,
		// Token: 0x0400393B RID: 14651
		MapPersistentBit = 64,
		// Token: 0x0400393C RID: 14652
		MapCoherentBit = 128,
		// Token: 0x0400393D RID: 14653
		DynamicStorageBit = 256,
		// Token: 0x0400393E RID: 14654
		ClientStorageBit = 512
	}
}
