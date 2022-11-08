using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BD RID: 189
	public interface ICharacterRenderer : IRenderer, IDisposable
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000663 RID: 1635
		// (set) Token: 0x06000664 RID: 1636
		Rectangle ClipRectangle { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000665 RID: 1637
		// (set) Token: 0x06000666 RID: 1638
		Matrix4 ModelMatrix { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000667 RID: 1639
		// (set) Token: 0x06000668 RID: 1640
		int Filter { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000669 RID: 1641
		// (set) Token: 0x0600066A RID: 1642
		double FilterAmount { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600066B RID: 1643
		// (set) Token: 0x0600066C RID: 1644
		float Brightness { get; set; }

		// Token: 0x0600066D RID: 1645
		void RenderTexture(ITexture skinTexture, ITexture bodyTexture, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false);

		// Token: 0x0600066E RID: 1646
		void RenderTexture(ITexture skinTexture, ITexture bodyTexture, double hueShift, double satuationShift, double luminosityShift, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false);

		// Token: 0x0600066F RID: 1647
		void RenderTextureGhost(ITexture skinTexture, ITexture bodyTexture, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false);
	}
}
