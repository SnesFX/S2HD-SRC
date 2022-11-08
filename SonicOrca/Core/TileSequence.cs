using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x0200014B RID: 331
	public class TileSequence : ITile
	{
		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000DAC RID: 3500 RVA: 0x00034530 File Offset: 0x00032730
		public int Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x0000225B File Offset: 0x0000045B
		public bool Animated
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00034538 File Offset: 0x00032738
		public TileSequence(TileSet tileSet, int id, IEnumerable<int> tileIds)
		{
			this._tileSet = tileSet;
			this._id = id;
			this._tileIds = tileIds.ToArray<int>();
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00006325 File Offset: 0x00004525
		public void Animate()
		{
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x0003455C File Offset: 0x0003275C
		public void Draw(Renderer renderer, int flags, int x, int y)
		{
			foreach (int tile in this._tileIds)
			{
				ITile tile2;
				if (this._tileSet.TryGetValue(tile, out tile2))
				{
					tile2.Draw(renderer, flags, x, y);
				}
			}
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x000345A0 File Offset: 0x000327A0
		public void Draw(Renderer renderer, int flags, Rectanglei source, Rectanglei destination)
		{
			ITileRenderer tileRenderer = renderer.GetTileRenderer();
			if (tileRenderer.Rendering)
			{
				this.Draw(tileRenderer, flags, source, destination);
				return;
			}
			this.Draw(renderer.Get2dRenderer(), flags, source, destination);
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x000345D8 File Offset: 0x000327D8
		public void Draw(I2dRenderer g, int flags, Rectanglei source, Rectanglei destination)
		{
			foreach (int tile in this._tileIds)
			{
				ITile tile2;
				if (this._tileSet.TryGetValue(tile, out tile2))
				{
					tile2.Draw(g, flags, source, destination);
				}
			}
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x0003461C File Offset: 0x0003281C
		public void Draw(ITileRenderer tileRenderer, int flags, Rectanglei source, Rectanglei destination)
		{
			foreach (int tile in this._tileIds)
			{
				ITile tile2;
				if (this._tileSet.TryGetValue(tile, out tile2))
				{
					tile2.Draw(tileRenderer, flags, source, destination);
				}
			}
		}

		// Token: 0x040007C3 RID: 1987
		private readonly TileSet _tileSet;

		// Token: 0x040007C4 RID: 1988
		private readonly int _id;

		// Token: 0x040007C5 RID: 1989
		private readonly int[] _tileIds;
	}
}
