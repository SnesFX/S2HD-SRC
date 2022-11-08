using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200035E RID: 862
	public enum GetTextureParameter
	{
		// Token: 0x040036AD RID: 13997
		TextureWidth = 4096,
		// Token: 0x040036AE RID: 13998
		TextureHeight,
		// Token: 0x040036AF RID: 13999
		TextureComponents = 4099,
		// Token: 0x040036B0 RID: 14000
		TextureInternalFormat = 4099,
		// Token: 0x040036B1 RID: 14001
		TextureBorderColor,
		// Token: 0x040036B2 RID: 14002
		TextureBorderColorNv = 4100,
		// Token: 0x040036B3 RID: 14003
		TextureBorder,
		// Token: 0x040036B4 RID: 14004
		TextureMagFilter = 10240,
		// Token: 0x040036B5 RID: 14005
		TextureMinFilter,
		// Token: 0x040036B6 RID: 14006
		TextureWrapS,
		// Token: 0x040036B7 RID: 14007
		TextureWrapT,
		// Token: 0x040036B8 RID: 14008
		TextureRedSize = 32860,
		// Token: 0x040036B9 RID: 14009
		TextureGreenSize,
		// Token: 0x040036BA RID: 14010
		TextureBlueSize,
		// Token: 0x040036BB RID: 14011
		TextureAlphaSize,
		// Token: 0x040036BC RID: 14012
		TextureLuminanceSize,
		// Token: 0x040036BD RID: 14013
		TextureIntensitySize,
		// Token: 0x040036BE RID: 14014
		TexturePriority = 32870,
		// Token: 0x040036BF RID: 14015
		TextureResident,
		// Token: 0x040036C0 RID: 14016
		TextureDepth = 32881,
		// Token: 0x040036C1 RID: 14017
		TextureDepthExt = 32881,
		// Token: 0x040036C2 RID: 14018
		TextureWrapR,
		// Token: 0x040036C3 RID: 14019
		TextureWrapRExt = 32882,
		// Token: 0x040036C4 RID: 14020
		DetailTextureLevelSgis = 32922,
		// Token: 0x040036C5 RID: 14021
		DetailTextureModeSgis,
		// Token: 0x040036C6 RID: 14022
		DetailTextureFuncPointsSgis,
		// Token: 0x040036C7 RID: 14023
		SharpenTextureFuncPointsSgis = 32944,
		// Token: 0x040036C8 RID: 14024
		ShadowAmbientSgix = 32959,
		// Token: 0x040036C9 RID: 14025
		DualTextureSelectSgis = 33060,
		// Token: 0x040036CA RID: 14026
		QuadTextureSelectSgis,
		// Token: 0x040036CB RID: 14027
		Texture4DsizeSgis = 33078,
		// Token: 0x040036CC RID: 14028
		TextureWrapQSgis,
		// Token: 0x040036CD RID: 14029
		TextureMinLod = 33082,
		// Token: 0x040036CE RID: 14030
		TextureMinLodSgis = 33082,
		// Token: 0x040036CF RID: 14031
		TextureMaxLod,
		// Token: 0x040036D0 RID: 14032
		TextureMaxLodSgis = 33083,
		// Token: 0x040036D1 RID: 14033
		TextureBaseLevel,
		// Token: 0x040036D2 RID: 14034
		TextureBaseLevelSgis = 33084,
		// Token: 0x040036D3 RID: 14035
		TextureMaxLevel,
		// Token: 0x040036D4 RID: 14036
		TextureMaxLevelSgis = 33085,
		// Token: 0x040036D5 RID: 14037
		TextureFilter4SizeSgis = 33095,
		// Token: 0x040036D6 RID: 14038
		TextureClipmapCenterSgix = 33137,
		// Token: 0x040036D7 RID: 14039
		TextureClipmapFrameSgix,
		// Token: 0x040036D8 RID: 14040
		TextureClipmapOffsetSgix,
		// Token: 0x040036D9 RID: 14041
		TextureClipmapVirtualDepthSgix,
		// Token: 0x040036DA RID: 14042
		TextureClipmapLodOffsetSgix,
		// Token: 0x040036DB RID: 14043
		TextureClipmapDepthSgix,
		// Token: 0x040036DC RID: 14044
		PostTextureFilterBiasSgix = 33145,
		// Token: 0x040036DD RID: 14045
		PostTextureFilterScaleSgix,
		// Token: 0x040036DE RID: 14046
		TextureLodBiasSSgix = 33166,
		// Token: 0x040036DF RID: 14047
		TextureLodBiasTSgix,
		// Token: 0x040036E0 RID: 14048
		TextureLodBiasRSgix,
		// Token: 0x040036E1 RID: 14049
		GenerateMipmap,
		// Token: 0x040036E2 RID: 14050
		GenerateMipmapSgis = 33169,
		// Token: 0x040036E3 RID: 14051
		TextureCompareSgix = 33178,
		// Token: 0x040036E4 RID: 14052
		TextureCompareOperatorSgix,
		// Token: 0x040036E5 RID: 14053
		TextureLequalRSgix,
		// Token: 0x040036E6 RID: 14054
		TextureGequalRSgix,
		// Token: 0x040036E7 RID: 14055
		TextureMaxClampSSgix = 33641,
		// Token: 0x040036E8 RID: 14056
		TextureMaxClampTSgix,
		// Token: 0x040036E9 RID: 14057
		TextureMaxClampRSgix,
		// Token: 0x040036EA RID: 14058
		TextureCompressedImageSize = 34464,
		// Token: 0x040036EB RID: 14059
		TextureCompressed,
		// Token: 0x040036EC RID: 14060
		TextureDepthSize = 34890,
		// Token: 0x040036ED RID: 14061
		DepthTextureMode,
		// Token: 0x040036EE RID: 14062
		TextureCompareMode,
		// Token: 0x040036EF RID: 14063
		TextureCompareFunc,
		// Token: 0x040036F0 RID: 14064
		TextureStencilSize = 35057,
		// Token: 0x040036F1 RID: 14065
		TextureRedType = 35856,
		// Token: 0x040036F2 RID: 14066
		TextureGreenType,
		// Token: 0x040036F3 RID: 14067
		TextureBlueType,
		// Token: 0x040036F4 RID: 14068
		TextureAlphaType,
		// Token: 0x040036F5 RID: 14069
		TextureLuminanceType,
		// Token: 0x040036F6 RID: 14070
		TextureIntensityType,
		// Token: 0x040036F7 RID: 14071
		TextureDepthType,
		// Token: 0x040036F8 RID: 14072
		TextureSharedSize = 35903,
		// Token: 0x040036F9 RID: 14073
		TextureSwizzleR = 36418,
		// Token: 0x040036FA RID: 14074
		TextureSwizzleG,
		// Token: 0x040036FB RID: 14075
		TextureSwizzleB,
		// Token: 0x040036FC RID: 14076
		TextureSwizzleA,
		// Token: 0x040036FD RID: 14077
		TextureSwizzleRgba,
		// Token: 0x040036FE RID: 14078
		TextureSamples = 37126,
		// Token: 0x040036FF RID: 14079
		TextureFixedSampleLocations
	}
}
