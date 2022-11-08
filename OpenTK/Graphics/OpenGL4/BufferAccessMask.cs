using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200067D RID: 1661
	[Flags]
	public enum BufferAccessMask
	{
		// Token: 0x040063F5 RID: 25589
		MapReadBit = 1,
		// Token: 0x040063F6 RID: 25590
		MapWriteBit = 2,
		// Token: 0x040063F7 RID: 25591
		MapInvalidateRangeBit = 4,
		// Token: 0x040063F8 RID: 25592
		MapInvalidateBufferBit = 8,
		// Token: 0x040063F9 RID: 25593
		MapFlushExplicitBit = 16,
		// Token: 0x040063FA RID: 25594
		MapUnsynchronizedBit = 32,
		// Token: 0x040063FB RID: 25595
		MapPersistentBit = 64,
		// Token: 0x040063FC RID: 25596
		MapCoherentBit = 128
	}
}
