using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000812 RID: 2066
	public enum GetTextureParameter
	{
		// Token: 0x04008754 RID: 34644
		TextureWidth = 4096,
		// Token: 0x04008755 RID: 34645
		TextureHeight,
		// Token: 0x04008756 RID: 34646
		TextureComponents = 4099,
		// Token: 0x04008757 RID: 34647
		TextureInternalFormat = 4099,
		// Token: 0x04008758 RID: 34648
		TextureBorderColor,
		// Token: 0x04008759 RID: 34649
		TextureBorderColorNv = 4100,
		// Token: 0x0400875A RID: 34650
		TextureBorder,
		// Token: 0x0400875B RID: 34651
		TextureMagFilter = 10240,
		// Token: 0x0400875C RID: 34652
		TextureMinFilter,
		// Token: 0x0400875D RID: 34653
		TextureWrapS,
		// Token: 0x0400875E RID: 34654
		TextureWrapT,
		// Token: 0x0400875F RID: 34655
		TextureRedSize = 32860,
		// Token: 0x04008760 RID: 34656
		TextureGreenSize,
		// Token: 0x04008761 RID: 34657
		TextureBlueSize,
		// Token: 0x04008762 RID: 34658
		TextureAlphaSize,
		// Token: 0x04008763 RID: 34659
		TextureLuminanceSize,
		// Token: 0x04008764 RID: 34660
		TextureIntensitySize,
		// Token: 0x04008765 RID: 34661
		TexturePriority = 32870,
		// Token: 0x04008766 RID: 34662
		TextureResident,
		// Token: 0x04008767 RID: 34663
		TextureDepthExt = 32881,
		// Token: 0x04008768 RID: 34664
		TextureWrapRExt,
		// Token: 0x04008769 RID: 34665
		DetailTextureLevelSgis = 32922,
		// Token: 0x0400876A RID: 34666
		DetailTextureModeSgis,
		// Token: 0x0400876B RID: 34667
		DetailTextureFuncPointsSgis,
		// Token: 0x0400876C RID: 34668
		SharpenTextureFuncPointsSgis = 32944,
		// Token: 0x0400876D RID: 34669
		ShadowAmbientSgix = 32959,
		// Token: 0x0400876E RID: 34670
		DualTextureSelectSgis = 33060,
		// Token: 0x0400876F RID: 34671
		QuadTextureSelectSgis,
		// Token: 0x04008770 RID: 34672
		Texture4DsizeSgis = 33078,
		// Token: 0x04008771 RID: 34673
		TextureWrapQSgis,
		// Token: 0x04008772 RID: 34674
		TextureMinLodSgis = 33082,
		// Token: 0x04008773 RID: 34675
		TextureMaxLodSgis,
		// Token: 0x04008774 RID: 34676
		TextureBaseLevelSgis,
		// Token: 0x04008775 RID: 34677
		TextureMaxLevelSgis,
		// Token: 0x04008776 RID: 34678
		TextureFilter4SizeSgis = 33095,
		// Token: 0x04008777 RID: 34679
		TextureClipmapCenterSgix = 33137,
		// Token: 0x04008778 RID: 34680
		TextureClipmapFrameSgix,
		// Token: 0x04008779 RID: 34681
		TextureClipmapOffsetSgix,
		// Token: 0x0400877A RID: 34682
		TextureClipmapVirtualDepthSgix,
		// Token: 0x0400877B RID: 34683
		TextureClipmapLodOffsetSgix,
		// Token: 0x0400877C RID: 34684
		TextureClipmapDepthSgix,
		// Token: 0x0400877D RID: 34685
		PostTextureFilterBiasSgix = 33145,
		// Token: 0x0400877E RID: 34686
		PostTextureFilterScaleSgix,
		// Token: 0x0400877F RID: 34687
		TextureLodBiasSSgix = 33166,
		// Token: 0x04008780 RID: 34688
		TextureLodBiasTSgix,
		// Token: 0x04008781 RID: 34689
		TextureLodBiasRSgix,
		// Token: 0x04008782 RID: 34690
		GenerateMipmapSgis,
		// Token: 0x04008783 RID: 34691
		TextureCompareSgix = 33178,
		// Token: 0x04008784 RID: 34692
		TextureCompareOperatorSgix,
		// Token: 0x04008785 RID: 34693
		TextureLequalRSgix,
		// Token: 0x04008786 RID: 34694
		TextureGequalRSgix,
		// Token: 0x04008787 RID: 34695
		TextureMaxClampSSgix = 33641,
		// Token: 0x04008788 RID: 34696
		TextureMaxClampTSgix,
		// Token: 0x04008789 RID: 34697
		TextureMaxClampRSgix
	}
}
