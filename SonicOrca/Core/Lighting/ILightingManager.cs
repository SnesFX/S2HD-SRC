using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x02000186 RID: 390
	public interface ILightingManager
	{
		// Token: 0x06001118 RID: 4376
		void RegisterLightSource(ILightSource lightSource);

		// Token: 0x06001119 RID: 4377
		void UnregisterLightSource(ILightSource lightSource);

		// Token: 0x0600111A RID: 4378
		Vector2i GetShadowOffset(Vector2i forPosition, IShadowInfo shadowInfo);
	}
}
