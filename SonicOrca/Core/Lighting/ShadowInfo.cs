using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x02000189 RID: 393
	public class ShadowInfo : IShadowInfo
	{
		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x00043C31 File Offset: 0x00041E31
		// (set) Token: 0x0600111F RID: 4383 RVA: 0x00043C39 File Offset: 0x00041E39
		public Vector2i MaxShadowOffset { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06001120 RID: 4384 RVA: 0x00043C42 File Offset: 0x00041E42
		// (set) Token: 0x06001121 RID: 4385 RVA: 0x00043C4A File Offset: 0x00041E4A
		public Vector2i OcclusionSize { get; set; }
	}
}
