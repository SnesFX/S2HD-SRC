using System;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing
{
	// Token: 0x02000005 RID: 5
	public class TheRenderer : Renderer
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002455 File Offset: 0x00000655
		public TheRenderer(WindowContext windowContext) : base(windowContext)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000245E File Offset: 0x0000065E
		public override I2dRenderer Get2dRenderer()
		{
			return SimpleRenderer.FromRenderer(this);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002466 File Offset: 0x00000666
		public override IFontRenderer GetFontRenderer()
		{
			return FontRenderer.FromRenderer(this);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000246E File Offset: 0x0000066E
		public override ITileRenderer GetTileRenderer()
		{
			return TileRenderer.FromRenderer(this);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002476 File Offset: 0x00000676
		public override IObjectRenderer GetObjectRenderer()
		{
			return ObjectRenderer.FromRenderer(this);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000247E File Offset: 0x0000067E
		public override ICharacterRenderer GetCharacterRenderer()
		{
			return CharacterRenderer.FromRenderer(this);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002486 File Offset: 0x00000686
		public override IWaterRenderer GetWaterRenderer()
		{
			return WaterRenderer.FromRenderer(this);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000248E File Offset: 0x0000068E
		public override IHeatRenderer GetHeatRenderer()
		{
			return HeatRenderer.FromRenderer(this);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002496 File Offset: 0x00000696
		public override INonLayerRenderer GetNonLayerRenderer()
		{
			return NonLayerRenderer.FromRenderer(this);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000249E File Offset: 0x0000069E
		public override IMaskRenderer GetMaskRenderer()
		{
			return MaskRenderer.FromRenderer(this);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024A6 File Offset: 0x000006A6
		public override IFadeTransitionRenderer CreateFadeTransitionRenderer()
		{
			return new ClassicFadeTransitionRenderer(base.Window.GraphicsContext);
		}
	}
}
