using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A39 RID: 2617
	public enum ExtMapBufferRange
	{
		// Token: 0x0400ABB7 RID: 43959
		MapReadBitExt = 1,
		// Token: 0x0400ABB8 RID: 43960
		MapWriteBitExt,
		// Token: 0x0400ABB9 RID: 43961
		MapInvalidateRangeBitExt = 4,
		// Token: 0x0400ABBA RID: 43962
		MapInvalidateBufferBitExt = 8,
		// Token: 0x0400ABBB RID: 43963
		MapFlushExplicitBitExt = 16,
		// Token: 0x0400ABBC RID: 43964
		MapUnsynchronizedBitExt = 32
	}
}
