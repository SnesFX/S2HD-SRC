using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000149 RID: 329
	public class Tile : ITile
	{
		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00034060 File Offset: 0x00032260
		public int Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00034068 File Offset: 0x00032268
		public bool Animated
		{
			get
			{
				return this._frames.Length > 1;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00034075 File Offset: 0x00032275
		public IReadOnlyList<Tile.Frame> Frames
		{
			get
			{
				return this._frames;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x0003407D File Offset: 0x0003227D
		public TileBlendMode Blend
		{
			get
			{
				return this._blend;
			}
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00034088 File Offset: 0x00032288
		public Tile(TileSet tileSet, int id, IEnumerable<Tile.Frame> frames, TileBlendMode blend = TileBlendMode.Alpha)
		{
			this._tileSet = tileSet;
			this._id = id;
			this._frames = frames.ToArray<Tile.Frame>();
			this._blend = blend;
			if (this._frames.Length >= 1)
			{
				this._opacity = this._frames[0].Opacity;
				if (this._frames.Length >= 2)
				{
					this._opacityChange = (this._frames[1].Opacity - this._opacity) / (float)(this._frames[0].Delay + 1);
				}
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00034120 File Offset: 0x00032320
		public void Animate()
		{
			if (this._frames.Length <= 1)
			{
				return;
			}
			Tile.Frame frame = this._frames[this._currentFrameIndex];
			if (this._frameTime < frame.Delay)
			{
				this._frameTime++;
				this._opacity += this._opacityChange;
				return;
			}
			this._currentFrameIndex = (this._currentFrameIndex + 1) % this._frames.Length;
			this._frameTime = 0;
			frame = this._frames[this._currentFrameIndex];
			this._opacity = frame.Opacity;
			int num = this._currentFrameIndex + 1;
			if (num >= this._frames.Length)
			{
				num = 0;
			}
			Tile.Frame frame2 = this._frames[num];
			if (frame2.Opacity != this._opacity && frame.Delay > 0)
			{
				this._opacityChange = (frame2.Opacity - this._opacity) / (float)(frame.Delay + 1);
				return;
			}
			this._opacityChange = 0f;
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00034224 File Offset: 0x00032424
		public void Draw(Renderer renderer, int flags, int x, int y)
		{
			Tile.Frame[] frames = this._frames;
			int currentFrameIndex = this._currentFrameIndex;
			this.Draw(renderer, flags, new Rectangle(0.0, 0.0, 64.0, 64.0), new Rectangle((double)x, (double)y, 64.0, 64.0));
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0003429C File Offset: 0x0003249C
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

		// Token: 0x06000DA9 RID: 3497 RVA: 0x000342D4 File Offset: 0x000324D4
		public void Draw(I2dRenderer g, int flags, Rectanglei source, Rectanglei destination)
		{
			Tile.Frame frame = this._frames[this._currentFrameIndex];
			source.X = (((flags & 16384) == 0) ? (frame.X + source.X) : (frame.X + 64 - source.Width - source.X));
			source.Y = (((flags & 32768) == 0) ? (frame.Y + source.Y) : (frame.Y + 64 - source.Height - source.Y));
			ITexture texture = this._tileSet.Textures[frame.TextureId];
			g.BlendMode = ((this._blend == TileBlendMode.Additive) ? BlendMode.Additive : BlendMode.Alpha);
			g.Colour = new Colour((double)this._opacity, 1.0, 1.0, 1.0);
			g.RenderTexture(texture, source, destination, (flags & 16384) != 0, (flags & 32768) != 0);
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000343EC File Offset: 0x000325EC
		public void Draw(ITileRenderer tileRenderer, int flags, Rectanglei source, Rectanglei destination)
		{
			Tile.Frame frame = this._frames[this._currentFrameIndex];
			source.X = (((flags & 16384) == 0) ? (frame.X + source.X) : (frame.X + 64 - source.Width - source.X));
			source.Y = (((flags & 32768) == 0) ? (frame.Y + source.Y) : (frame.Y + 64 - source.Height - source.Y));
			tileRenderer.AddTile(source, destination, frame.TextureId, (flags & 16384) != 0, (flags & 32768) != 0, this._opacity, this._blend);
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x000344B4 File Offset: 0x000326B4
		public override string ToString()
		{
			if (this._frames.Length != 1)
			{
				return string.Format("Id = {0} Frames = {1}", this._frames.Length);
			}
			return string.Format("Id = {0} TextureId = {1} X = {2} Y = {3}", this._frames[0].TextureId, this._frames[0].X, this._frames[0].Y);
		}

		// Token: 0x040007B2 RID: 1970
		public const int Size = 64;

		// Token: 0x040007B3 RID: 1971
		public const int IndexMask = 4095;

		// Token: 0x040007B4 RID: 1972
		public const int TileSetMask = 12288;

		// Token: 0x040007B5 RID: 1973
		public const int FlipXMask = 16384;

		// Token: 0x040007B6 RID: 1974
		public const int FlipYMask = 32768;

		// Token: 0x040007B7 RID: 1975
		private readonly TileSet _tileSet;

		// Token: 0x040007B8 RID: 1976
		private readonly int _id;

		// Token: 0x040007B9 RID: 1977
		private readonly Tile.Frame[] _frames;

		// Token: 0x040007BA RID: 1978
		private readonly TileBlendMode _blend;

		// Token: 0x040007BB RID: 1979
		private int _currentFrameIndex;

		// Token: 0x040007BC RID: 1980
		private int _frameTime;

		// Token: 0x040007BD RID: 1981
		private float _opacity;

		// Token: 0x040007BE RID: 1982
		private float _opacityChange;

		// Token: 0x02000235 RID: 565
		public struct Frame
		{
			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x06001444 RID: 5188 RVA: 0x0004DF49 File Offset: 0x0004C149
			// (set) Token: 0x06001445 RID: 5189 RVA: 0x0004DF51 File Offset: 0x0004C151
			public int TextureId { get; set; }

			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x06001446 RID: 5190 RVA: 0x0004DF5A File Offset: 0x0004C15A
			// (set) Token: 0x06001447 RID: 5191 RVA: 0x0004DF62 File Offset: 0x0004C162
			public int X { get; set; }

			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x06001448 RID: 5192 RVA: 0x0004DF6B File Offset: 0x0004C16B
			// (set) Token: 0x06001449 RID: 5193 RVA: 0x0004DF73 File Offset: 0x0004C173
			public int Y { get; set; }

			// Token: 0x1700053D RID: 1341
			// (get) Token: 0x0600144A RID: 5194 RVA: 0x0004DF7C File Offset: 0x0004C17C
			// (set) Token: 0x0600144B RID: 5195 RVA: 0x0004DF84 File Offset: 0x0004C184
			public float Opacity { get; set; }

			// Token: 0x1700053E RID: 1342
			// (get) Token: 0x0600144C RID: 5196 RVA: 0x0004DF8D File Offset: 0x0004C18D
			// (set) Token: 0x0600144D RID: 5197 RVA: 0x0004DF95 File Offset: 0x0004C195
			public int Delay { get; set; }

			// Token: 0x0600144E RID: 5198 RVA: 0x0004DFA0 File Offset: 0x0004C1A0
			public override string ToString()
			{
				return string.Format("TextureId = {0} X = {1} Y = {2} Opacity = {3} Delay = {4}", new object[]
				{
					this.TextureId,
					this.X,
					this.Y,
					this.Opacity,
					this.Delay
				});
			}
		}
	}
}
