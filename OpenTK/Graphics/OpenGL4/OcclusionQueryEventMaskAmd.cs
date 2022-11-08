using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006FC RID: 1788
	[Flags]
	public enum OcclusionQueryEventMaskAmd
	{
		// Token: 0x04006B41 RID: 27457
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04006B42 RID: 27458
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04006B43 RID: 27459
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04006B44 RID: 27460
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04006B45 RID: 27461
		QueryAllEventBitsAmd = -1
	}
}
