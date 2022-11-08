using System;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing
{
	// Token: 0x02000003 RID: 3
	public class DefaultRendererFactory : IRendererFactory
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002181 File Offset: 0x00000381
		private DefaultRendererFactory(IGraphicsContext graphicsContext)
		{
			this._graphicsContext = graphicsContext;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002190 File Offset: 0x00000390
		public static IRendererFactory Create(IGraphicsContext graphicsContext)
		{
			return new DefaultRendererFactory(graphicsContext);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002198 File Offset: 0x00000398
		public I2dRenderer Create2dRenderer()
		{
			return null;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002198 File Offset: 0x00000398
		public IFontRenderer CreateFontRenderer()
		{
			return null;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000219B File Offset: 0x0000039B
		public IFadeTransitionRenderer CreateFadeTransitionRenderer()
		{
			return new ClassicFadeTransitionRenderer(this._graphicsContext);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002198 File Offset: 0x00000398
		public ITileRenderer CreateTileRenderer()
		{
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002198 File Offset: 0x00000398
		public IObjectRenderer CreateObjectRenderer()
		{
			return null;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002198 File Offset: 0x00000398
		public ICharacterRenderer CreateCharacterRenderer()
		{
			return null;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002198 File Offset: 0x00000398
		public IWaterRenderer CreateWaterRenderer()
		{
			return null;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002198 File Offset: 0x00000398
		public IHeatRenderer CreateHeatRenderer()
		{
			return null;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002198 File Offset: 0x00000398
		public INonLayerRenderer CreateNonLayerRenderer()
		{
			return null;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002198 File Offset: 0x00000398
		public IMaskRenderer CreateMaskRenderer()
		{
			return null;
		}

		// Token: 0x04000001 RID: 1
		private readonly IGraphicsContext _graphicsContext;
	}
}
