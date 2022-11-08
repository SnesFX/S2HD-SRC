using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x02000187 RID: 391
	public interface ILightSource
	{
		// Token: 0x0600111B RID: 4379
		Vector2i GetShadowOffset(Vector2i position, IShadowInfo shadowInfo);
	}
}
