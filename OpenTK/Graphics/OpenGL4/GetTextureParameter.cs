using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006D5 RID: 1749
	public enum GetTextureParameter
	{
		// Token: 0x040068B6 RID: 26806
		TextureWidth = 4096,
		// Token: 0x040068B7 RID: 26807
		TextureHeight,
		// Token: 0x040068B8 RID: 26808
		TextureInternalFormat = 4099,
		// Token: 0x040068B9 RID: 26809
		TextureBorderColor,
		// Token: 0x040068BA RID: 26810
		TextureBorderColorNv = 4100,
		// Token: 0x040068BB RID: 26811
		TextureMagFilter = 10240,
		// Token: 0x040068BC RID: 26812
		TextureMinFilter,
		// Token: 0x040068BD RID: 26813
		TextureWrapS,
		// Token: 0x040068BE RID: 26814
		TextureWrapT,
		// Token: 0x040068BF RID: 26815
		TextureRedSize = 32860,
		// Token: 0x040068C0 RID: 26816
		TextureGreenSize,
		// Token: 0x040068C1 RID: 26817
		TextureBlueSize,
		// Token: 0x040068C2 RID: 26818
		TextureAlphaSize,
		// Token: 0x040068C3 RID: 26819
		TextureDepth = 32881,
		// Token: 0x040068C4 RID: 26820
		TextureDepthExt = 32881,
		// Token: 0x040068C5 RID: 26821
		TextureWrapR,
		// Token: 0x040068C6 RID: 26822
		TextureWrapRExt = 32882,
		// Token: 0x040068C7 RID: 26823
		DetailTextureLevelSgis = 32922,
		// Token: 0x040068C8 RID: 26824
		DetailTextureModeSgis,
		// Token: 0x040068C9 RID: 26825
		DetailTextureFuncPointsSgis,
		// Token: 0x040068CA RID: 26826
		SharpenTextureFuncPointsSgis = 32944,
		// Token: 0x040068CB RID: 26827
		ShadowAmbientSgix = 32959,
		// Token: 0x040068CC RID: 26828
		DualTextureSelectSgis = 33060,
		// Token: 0x040068CD RID: 26829
		QuadTextureSelectSgis,
		// Token: 0x040068CE RID: 26830
		Texture4DsizeSgis = 33078,
		// Token: 0x040068CF RID: 26831
		TextureWrapQSgis,
		// Token: 0x040068D0 RID: 26832
		TextureMinLod = 33082,
		// Token: 0x040068D1 RID: 26833
		TextureMinLodSgis = 33082,
		// Token: 0x040068D2 RID: 26834
		TextureMaxLod,
		// Token: 0x040068D3 RID: 26835
		TextureMaxLodSgis = 33083,
		// Token: 0x040068D4 RID: 26836
		TextureBaseLevel,
		// Token: 0x040068D5 RID: 26837
		TextureBaseLevelSgis = 33084,
		// Token: 0x040068D6 RID: 26838
		TextureMaxLevel,
		// Token: 0x040068D7 RID: 26839
		TextureMaxLevelSgis = 33085,
		// Token: 0x040068D8 RID: 26840
		TextureFilter4SizeSgis = 33095,
		// Token: 0x040068D9 RID: 26841
		TextureClipmapCenterSgix = 33137,
		// Token: 0x040068DA RID: 26842
		TextureClipmapFrameSgix,
		// Token: 0x040068DB RID: 26843
		TextureClipmapOffsetSgix,
		// Token: 0x040068DC RID: 26844
		TextureClipmapVirtualDepthSgix,
		// Token: 0x040068DD RID: 26845
		TextureClipmapLodOffsetSgix,
		// Token: 0x040068DE RID: 26846
		TextureClipmapDepthSgix,
		// Token: 0x040068DF RID: 26847
		PostTextureFilterBiasSgix = 33145,
		// Token: 0x040068E0 RID: 26848
		PostTextureFilterScaleSgix,
		// Token: 0x040068E1 RID: 26849
		TextureLodBiasSSgix = 33166,
		// Token: 0x040068E2 RID: 26850
		TextureLodBiasTSgix,
		// Token: 0x040068E3 RID: 26851
		TextureLodBiasRSgix,
		// Token: 0x040068E4 RID: 26852
		GenerateMipmap,
		// Token: 0x040068E5 RID: 26853
		GenerateMipmapSgis = 33169,
		// Token: 0x040068E6 RID: 26854
		TextureCompareSgix = 33178,
		// Token: 0x040068E7 RID: 26855
		TextureCompareOperatorSgix,
		// Token: 0x040068E8 RID: 26856
		TextureLequalRSgix,
		// Token: 0x040068E9 RID: 26857
		TextureGequalRSgix,
		// Token: 0x040068EA RID: 26858
		TextureMaxClampSSgix = 33641,
		// Token: 0x040068EB RID: 26859
		TextureMaxClampTSgix,
		// Token: 0x040068EC RID: 26860
		TextureMaxClampRSgix,
		// Token: 0x040068ED RID: 26861
		TextureCompressedImageSize = 34464,
		// Token: 0x040068EE RID: 26862
		TextureCompressed,
		// Token: 0x040068EF RID: 26863
		TextureDepthSize = 34890,
		// Token: 0x040068F0 RID: 26864
		DepthTextureMode,
		// Token: 0x040068F1 RID: 26865
		TextureCompareMode,
		// Token: 0x040068F2 RID: 26866
		TextureCompareFunc,
		// Token: 0x040068F3 RID: 26867
		TextureStencilSize = 35057,
		// Token: 0x040068F4 RID: 26868
		TextureRedType = 35856,
		// Token: 0x040068F5 RID: 26869
		TextureGreenType,
		// Token: 0x040068F6 RID: 26870
		TextureBlueType,
		// Token: 0x040068F7 RID: 26871
		TextureAlphaType,
		// Token: 0x040068F8 RID: 26872
		TextureLuminanceType,
		// Token: 0x040068F9 RID: 26873
		TextureIntensityType,
		// Token: 0x040068FA RID: 26874
		TextureDepthType,
		// Token: 0x040068FB RID: 26875
		TextureSharedSize = 35903,
		// Token: 0x040068FC RID: 26876
		TextureSwizzleR = 36418,
		// Token: 0x040068FD RID: 26877
		TextureSwizzleG,
		// Token: 0x040068FE RID: 26878
		TextureSwizzleB,
		// Token: 0x040068FF RID: 26879
		TextureSwizzleA,
		// Token: 0x04006900 RID: 26880
		TextureSwizzleRgba,
		// Token: 0x04006901 RID: 26881
		TextureSamples = 37126,
		// Token: 0x04006902 RID: 26882
		TextureFixedSampleLocations
	}
}
