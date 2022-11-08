using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000857 RID: 2135
	[Flags]
	public enum OcclusionQueryEventMaskAmd
	{
		// Token: 0x04008A64 RID: 35428
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04008A65 RID: 35429
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04008A66 RID: 35430
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04008A67 RID: 35431
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04008A68 RID: 35432
		QueryAllEventBitsAmd = -1
	}
}
