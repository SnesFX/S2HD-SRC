using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000923 RID: 2339
	public enum ExtMapBufferRange
	{
		// Token: 0x04009ACE RID: 39630
		MapReadBitExt = 1,
		// Token: 0x04009ACF RID: 39631
		MapWriteBitExt,
		// Token: 0x04009AD0 RID: 39632
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04009AD1 RID: 39633
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04009AD2 RID: 39634
		MapFlushExplicitBitExt = 16,
		// Token: 0x04009AD3 RID: 39635
		MapUnsynchronizedBitExt = 32
	}
}
