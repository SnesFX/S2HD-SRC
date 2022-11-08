using System;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000EA RID: 234
	public class FilmInstance
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0001F79C File Offset: 0x0001D99C
		public FilmGroup FilmGroup
		{
			get
			{
				return this._filmGroup;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0001F7A4 File Offset: 0x0001D9A4
		public bool Playing
		{
			get
			{
				return this._playing;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0001F7AC File Offset: 0x0001D9AC
		public bool Finished
		{
			get
			{
				return this._finished;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0001F7B4 File Offset: 0x0001D9B4
		public double CurrentTime
		{
			get
			{
				IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.FirstOrDefault<IFilmBuffer>();
				if (filmBuffer != null)
				{
					return filmBuffer.CurrentTime;
				}
				return 0.0;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0001F7E8 File Offset: 0x0001D9E8
		public double Duration
		{
			get
			{
				IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.FirstOrDefault<IFilmBuffer>();
				if (filmBuffer != null)
				{
					return filmBuffer.Duration;
				}
				return 0.0;
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0001F819 File Offset: 0x0001DA19
		public FilmInstance(ResourceTree resourceTree, string resourceKey)
		{
			this._filmGroup = resourceTree.GetLoadedResource<FilmGroup>(resourceKey);
			this._film = this._filmGroup.First<Film>();
			this.SetupRenderTarget();
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0001F845 File Offset: 0x0001DA45
		public FilmInstance(FilmGroup filmGroup)
		{
			this._filmGroup = filmGroup;
			this._film = this._filmGroup.First<Film>();
			this.SetupRenderTarget();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0001F86C File Offset: 0x0001DA6C
		private void SetupRenderTarget()
		{
			IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.First<IFilmBuffer>();
			IGraphicsContext graphicsContext = SonicOrcaGameContext.Singleton.Window.GraphicsContext;
			this._renderTarget = graphicsContext.CreateTexture(filmBuffer.Width, filmBuffer.Height, 4, new byte[filmBuffer.Width * filmBuffer.Height * 4], false);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0001F8C8 File Offset: 0x0001DAC8
		public void Animate()
		{
			IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.First<IFilmBuffer>();
			filmBuffer.Decode();
			if (filmBuffer.CurrentTime >= filmBuffer.Duration)
			{
				this._finished = true;
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00006325 File Offset: 0x00004525
		public void Seek(int ticks)
		{
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0001F901 File Offset: 0x0001DB01
		public void Draw(Renderer renderer, Vector2 offset = default(Vector2), bool flipX = false, bool flipY = false)
		{
			this.Draw(renderer, Colours.White, offset, flipX, flipY);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0001F914 File Offset: 0x0001DB14
		public void Draw(Renderer renderer, Colour colour, Vector2 offset = default(Vector2), bool flipX = false, bool flipY = false)
		{
			IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.First<IFilmBuffer>();
			Rectanglei r = new Rectanglei(0, 0, filmBuffer.Width, filmBuffer.Height);
			Rectanglei r2 = new Rectanglei(0, 0, filmBuffer.Width, filmBuffer.Height);
			I2dRenderer renderer2 = renderer.Get2dRenderer();
			this.Draw(renderer2, colour, r, r2, flipX, flipY);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0001F97C File Offset: 0x0001DB7C
		public void Draw(I2dRenderer renderer, Colour colour, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			IFilmBuffer filmBuffer = this._filmGroup.FilmBuffers.First<IFilmBuffer>();
			byte[] argbData = filmBuffer.GetArgbData();
			this._renderTarget.SetArgbData(filmBuffer.Width, filmBuffer.Height, argbData);
			using (renderer.BeginMatixState())
			{
				Matrix4 matrix = Matrix4.Identity;
				matrix *= Matrix4.CreateScale((double)(flipX ? -1 : 1), (double)(flipY ? -1 : 1), 1.0);
				renderer.ModelMatrix = matrix;
				renderer.Colour = Colours.White;
				renderer.BlendMode = BlendMode.Opaque;
				renderer.RenderTexture(this._renderTarget, source, destination, flipX, flipY);
			}
		}

		// Token: 0x040004F4 RID: 1268
		private readonly FilmGroup _filmGroup;

		// Token: 0x040004F5 RID: 1269
		private Film _film;

		// Token: 0x040004F6 RID: 1270
		private bool _playing;

		// Token: 0x040004F7 RID: 1271
		private bool _finished;

		// Token: 0x040004F8 RID: 1272
		private ITexture _renderTarget;
	}
}
