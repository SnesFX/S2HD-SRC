using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x02000188 RID: 392
	public interface IShadowInfo
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x0600111C RID: 4380
		Vector2i MaxShadowOffset { get; }

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x0600111D RID: 4381
		Vector2i OcclusionSize { get; }
	}
}
