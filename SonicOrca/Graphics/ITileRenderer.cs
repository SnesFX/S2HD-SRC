using System;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C5 RID: 197
	public interface ITileRenderer : IRenderer, IDisposable
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060006B4 RID: 1716
		// (set) Token: 0x060006B5 RID: 1717
		Rectangle ClipRectangle { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060006B6 RID: 1718
		// (set) Token: 0x060006B7 RID: 1719
		Matrix4 ModelMatrix { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060006B8 RID: 1720
		// (set) Token: 0x060006B9 RID: 1721
		ITexture[] Textures { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060006BA RID: 1722
		// (set) Token: 0x060006BB RID: 1723
		int Filter { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060006BC RID: 1724
		// (set) Token: 0x060006BD RID: 1725
		double FilterAmount { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060006BE RID: 1726
		bool Rendering { get; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060006BF RID: 1727
		int NumTiles { get; }

		// Token: 0x060006C0 RID: 1728
		void BeginRender();

		// Token: 0x060006C1 RID: 1729
		void AddTile(Rectanglei source, Rectanglei destination, int textureIndex, bool flipX = false, bool flipY = false, float opacity = 1f, TileBlendMode blend = TileBlendMode.Alpha);

		// Token: 0x060006C2 RID: 1730
		void EndRender();
	}
}
