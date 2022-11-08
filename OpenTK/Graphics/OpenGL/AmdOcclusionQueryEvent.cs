using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020001D4 RID: 468
	public enum AmdOcclusionQueryEvent
	{
		// Token: 0x04002595 RID: 9621
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04002596 RID: 9622
		QueryDepthFailEventBitAmd,
		// Token: 0x04002597 RID: 9623
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04002598 RID: 9624
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04002599 RID: 9625
		OcclusionQueryEventMaskAmd = 34639,
		// Token: 0x0400259A RID: 9626
		QueryAllEventBitsAmd = -1
	}
}
