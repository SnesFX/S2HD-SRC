using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020003EF RID: 1007
	[Flags]
	public enum OcclusionQueryEventMaskAmd
	{
		// Token: 0x04003D1E RID: 15646
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04003D1F RID: 15647
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04003D20 RID: 15648
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04003D21 RID: 15649
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04003D22 RID: 15650
		QueryAllEventBitsAmd = -1
	}
}
