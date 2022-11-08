using System;
using System.Collections.Generic;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000E4 RID: 228
	public abstract class Renderer : IDisposable
	{
		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0001F0C3 File Offset: 0x0001D2C3
		public WindowContext Window
		{
			get
			{
				return this._window;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0001F0CB File Offset: 0x0001D2CB
		public IRenderer CurrentRenderer
		{
			get
			{
				return this._currentRenderer;
			}
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0001F0D3 File Offset: 0x0001D2D3
		public Renderer(WindowContext window)
		{
			this._window = window;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0001F0F0 File Offset: 0x0001D2F0
		public void Dispose()
		{
			foreach (IRenderer renderer in this._registeredRenderers)
			{
				renderer.Dispose();
			}
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0001F140 File Offset: 0x0001D340
		public void RegisterRenderer(IRenderer renderer)
		{
			this._registeredRenderers.Add(renderer);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0001F14F File Offset: 0x0001D34F
		public void ActivateRenderer(IRenderer renderer)
		{
			if (this._currentRenderer != null && this._currentRenderer != renderer)
			{
				this._currentRenderer.Deactivate();
			}
			this._currentRenderer = renderer;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001F174 File Offset: 0x0001D374
		public void DeativateRenderer()
		{
			this.ActivateRenderer(null);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001F180 File Offset: 0x0001D380
		public static void GetVertices(Rectangle destination, Vector2[] vertices)
		{
			vertices[0].X = destination.Left;
			vertices[0].Y = destination.Top;
			vertices[1].X = destination.Left;
			vertices[2].Y = (vertices[1].Y = vertices[0].Y + destination.Height);
			vertices[3].X = (vertices[2].X = vertices[0].X + destination.Width);
			vertices[3].Y = destination.Top;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001F238 File Offset: 0x0001D438
		public static void GetTextureMappings(ITexture texture, Rectanglei source, Vector2[] textureMappings, bool flipX = false, bool flipY = false)
		{
			double x = flipX ? ((double)source.Right / (double)texture.Width) : ((double)source.Left / (double)texture.Width);
			double x2 = flipX ? ((double)source.Left / (double)texture.Width) : ((double)source.Right / (double)texture.Width);
			double y = flipY ? ((double)source.Bottom / (double)texture.Height) : ((double)source.Top / (double)texture.Height);
			double y2 = flipY ? ((double)source.Top / (double)texture.Height) : ((double)source.Bottom / (double)texture.Height);
			textureMappings[0].X = x;
			textureMappings[0].Y = y;
			textureMappings[1].X = x;
			textureMappings[1].Y = y2;
			textureMappings[2].X = x2;
			textureMappings[2].Y = y2;
			textureMappings[3].X = x2;
			textureMappings[3].Y = y;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0001F348 File Offset: 0x0001D548
		public static void GetTextureMappingsHalfIn(ITexture texture, Rectanglei source, ref Vector2[] textureMappings, bool flipX = false, bool flipY = false)
		{
			double x = flipX ? (((double)source.Right - 0.5) / (double)texture.Width) : (((double)source.Left + 0.5) / (double)texture.Width);
			double x2 = flipX ? (((double)source.Left + 0.5) / (double)texture.Width) : (((double)source.Right - 0.5) / (double)texture.Width);
			double y = flipY ? (((double)source.Bottom - 0.5) / (double)texture.Height) : (((double)source.Top + 0.5) / (double)texture.Height);
			double y2 = flipY ? (((double)source.Top + 0.5) / (double)texture.Height) : (((double)source.Bottom - 0.5) / (double)texture.Height);
			textureMappings[0].X = x;
			textureMappings[0].Y = y;
			textureMappings[1].X = x;
			textureMappings[1].Y = y2;
			textureMappings[2].X = x2;
			textureMappings[2].Y = y2;
			textureMappings[3].X = x2;
			textureMappings[3].Y = y;
		}

		// Token: 0x060007DC RID: 2012
		public abstract I2dRenderer Get2dRenderer();

		// Token: 0x060007DD RID: 2013
		public abstract IFontRenderer GetFontRenderer();

		// Token: 0x060007DE RID: 2014
		public abstract ITileRenderer GetTileRenderer();

		// Token: 0x060007DF RID: 2015
		public abstract IObjectRenderer GetObjectRenderer();

		// Token: 0x060007E0 RID: 2016
		public abstract ICharacterRenderer GetCharacterRenderer();

		// Token: 0x060007E1 RID: 2017
		public abstract IWaterRenderer GetWaterRenderer();

		// Token: 0x060007E2 RID: 2018
		public abstract IHeatRenderer GetHeatRenderer();

		// Token: 0x060007E3 RID: 2019
		public abstract INonLayerRenderer GetNonLayerRenderer();

		// Token: 0x060007E4 RID: 2020
		public abstract IMaskRenderer GetMaskRenderer();

		// Token: 0x060007E5 RID: 2021
		public abstract IFadeTransitionRenderer CreateFadeTransitionRenderer();

		// Token: 0x040004DE RID: 1246
		private readonly HashSet<IRenderer> _registeredRenderers = new HashSet<IRenderer>();

		// Token: 0x040004DF RID: 1247
		private readonly WindowContext _window;

		// Token: 0x040004E0 RID: 1248
		private IRenderer _currentRenderer;
	}
}
