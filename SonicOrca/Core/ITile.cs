using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000148 RID: 328
	public interface ITile
	{
		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000D9A RID: 3482
		int Id { get; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000D9B RID: 3483
		bool Animated { get; }

		// Token: 0x06000D9C RID: 3484
		void Animate();

		// Token: 0x06000D9D RID: 3485
		void Draw(Renderer renderer, int flags, int x, int y);

		// Token: 0x06000D9E RID: 3486
		void Draw(Renderer renderer, int flags, Rectanglei source, Rectanglei destination);

		// Token: 0x06000D9F RID: 3487
		void Draw(I2dRenderer g, int flags, Rectanglei source, Rectanglei destination);

		// Token: 0x06000DA0 RID: 3488
		void Draw(ITileRenderer tileRenderer, int flags, Rectanglei source, Rectanglei destination);
	}
}
