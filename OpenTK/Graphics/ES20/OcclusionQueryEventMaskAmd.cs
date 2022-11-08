using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x020009A4 RID: 2468
	[Flags]
	public enum OcclusionQueryEventMaskAmd
	{
		// Token: 0x0400A0ED RID: 41197
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x0400A0EE RID: 41198
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x0400A0EF RID: 41199
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x0400A0F0 RID: 41200
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x0400A0F1 RID: 41201
		QueryAllEventBitsAmd = -1
	}
}
