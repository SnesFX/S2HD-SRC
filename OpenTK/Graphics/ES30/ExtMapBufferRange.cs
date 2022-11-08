using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007D3 RID: 2003
	public enum ExtMapBufferRange
	{
		// Token: 0x040083B4 RID: 33716
		MapReadBitExt = 1,
		// Token: 0x040083B5 RID: 33717
		MapWriteBitExt,
		// Token: 0x040083B6 RID: 33718
		MapInvalidateRangeBitExt = 4,
		// Token: 0x040083B7 RID: 33719
		MapInvalidateBufferBitExt = 8,
		// Token: 0x040083B8 RID: 33720
		MapFlushExplicitBitExt = 16,
		// Token: 0x040083B9 RID: 33721
		MapUnsynchronizedBitExt = 32
	}
}
