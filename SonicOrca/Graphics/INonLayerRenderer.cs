using System;
using System.Collections.Generic;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C0 RID: 192
	public interface INonLayerRenderer : IRenderer, IDisposable
	{
		// Token: 0x0600068E RID: 1678
		void Render(IEnumerable<Rectanglei> rects);
	}
}
