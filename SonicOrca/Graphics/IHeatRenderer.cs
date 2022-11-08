using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BE RID: 190
	public interface IHeatRenderer : IRenderer, IDisposable
	{
		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000670 RID: 1648
		// (set) Token: 0x06000671 RID: 1649
		ITexture DistortionTexture { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000672 RID: 1650
		// (set) Token: 0x06000673 RID: 1651
		double DistortionAmount { get; set; }

		// Token: 0x06000674 RID: 1652
		void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false);

		// Token: 0x06000675 RID: 1653
		void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false);
	}
}
