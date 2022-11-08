using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C1 RID: 193
	public interface IRendererFactory
	{
		// Token: 0x0600068F RID: 1679
		I2dRenderer Create2dRenderer();

		// Token: 0x06000690 RID: 1680
		IFontRenderer CreateFontRenderer();

		// Token: 0x06000691 RID: 1681
		IFadeTransitionRenderer CreateFadeTransitionRenderer();

		// Token: 0x06000692 RID: 1682
		ITileRenderer CreateTileRenderer();

		// Token: 0x06000693 RID: 1683
		IObjectRenderer CreateObjectRenderer();

		// Token: 0x06000694 RID: 1684
		ICharacterRenderer CreateCharacterRenderer();

		// Token: 0x06000695 RID: 1685
		IWaterRenderer CreateWaterRenderer();

		// Token: 0x06000696 RID: 1686
		IHeatRenderer CreateHeatRenderer();

		// Token: 0x06000697 RID: 1687
		INonLayerRenderer CreateNonLayerRenderer();

		// Token: 0x06000698 RID: 1688
		IMaskRenderer CreateMaskRenderer();
	}
}
