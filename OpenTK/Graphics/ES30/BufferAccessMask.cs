using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x0200079C RID: 1948
	[Flags]
	public enum BufferAccessMask
	{
		// Token: 0x04007F4E RID: 32590
		MapReadBit = 1,
		// Token: 0x04007F4F RID: 32591
		MapWriteBit = 2,
		// Token: 0x04007F50 RID: 32592
		MapInvalidateRangeBit = 4,
		// Token: 0x04007F51 RID: 32593
		MapInvalidateBufferBit = 8,
		// Token: 0x04007F52 RID: 32594
		MapFlushExplicitBit = 16,
		// Token: 0x04007F53 RID: 32595
		MapUnsynchronizedBit = 32
	}
}
