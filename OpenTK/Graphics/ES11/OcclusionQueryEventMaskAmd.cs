using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A80 RID: 2688
	[Flags]
	public enum OcclusionQueryEventMaskAmd
	{
		// Token: 0x0400AFB4 RID: 44980
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x0400AFB5 RID: 44981
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x0400AFB6 RID: 44982
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x0400AFB7 RID: 44983
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x0400AFB8 RID: 44984
		QueryAllEventBitsAmd = -1
	}
}
