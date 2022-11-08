using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020002D7 RID: 727
	public enum EnableCap
	{
		// Token: 0x04002EE6 RID: 12006
		PointSmooth = 2832,
		// Token: 0x04002EE7 RID: 12007
		LineSmooth = 2848,
		// Token: 0x04002EE8 RID: 12008
		LineStipple = 2852,
		// Token: 0x04002EE9 RID: 12009
		PolygonSmooth = 2881,
		// Token: 0x04002EEA RID: 12010
		PolygonStipple,
		// Token: 0x04002EEB RID: 12011
		CullFace = 2884,
		// Token: 0x04002EEC RID: 12012
		Lighting = 2896,
		// Token: 0x04002EED RID: 12013
		ColorMaterial = 2903,
		// Token: 0x04002EEE RID: 12014
		Fog = 2912,
		// Token: 0x04002EEF RID: 12015
		DepthTest = 2929,
		// Token: 0x04002EF0 RID: 12016
		StencilTest = 2960,
		// Token: 0x04002EF1 RID: 12017
		Normalize = 2977,
		// Token: 0x04002EF2 RID: 12018
		AlphaTest = 3008,
		// Token: 0x04002EF3 RID: 12019
		Dither = 3024,
		// Token: 0x04002EF4 RID: 12020
		Blend = 3042,
		// Token: 0x04002EF5 RID: 12021
		IndexLogicOp = 3057,
		// Token: 0x04002EF6 RID: 12022
		ColorLogicOp,
		// Token: 0x04002EF7 RID: 12023
		ScissorTest = 3089,
		// Token: 0x04002EF8 RID: 12024
		TextureGenS = 3168,
		// Token: 0x04002EF9 RID: 12025
		TextureGenT,
		// Token: 0x04002EFA RID: 12026
		TextureGenR,
		// Token: 0x04002EFB RID: 12027
		TextureGenQ,
		// Token: 0x04002EFC RID: 12028
		AutoNormal = 3456,
		// Token: 0x04002EFD RID: 12029
		Map1Color4 = 3472,
		// Token: 0x04002EFE RID: 12030
		Map1Index,
		// Token: 0x04002EFF RID: 12031
		Map1Normal,
		// Token: 0x04002F00 RID: 12032
		Map1TextureCoord1,
		// Token: 0x04002F01 RID: 12033
		Map1TextureCoord2,
		// Token: 0x04002F02 RID: 12034
		Map1TextureCoord3,
		// Token: 0x04002F03 RID: 12035
		Map1TextureCoord4,
		// Token: 0x04002F04 RID: 12036
		Map1Vertex3,
		// Token: 0x04002F05 RID: 12037
		Map1Vertex4,
		// Token: 0x04002F06 RID: 12038
		Map2Color4 = 3504,
		// Token: 0x04002F07 RID: 12039
		Map2Index,
		// Token: 0x04002F08 RID: 12040
		Map2Normal,
		// Token: 0x04002F09 RID: 12041
		Map2TextureCoord1,
		// Token: 0x04002F0A RID: 12042
		Map2TextureCoord2,
		// Token: 0x04002F0B RID: 12043
		Map2TextureCoord3,
		// Token: 0x04002F0C RID: 12044
		Map2TextureCoord4,
		// Token: 0x04002F0D RID: 12045
		Map2Vertex3,
		// Token: 0x04002F0E RID: 12046
		Map2Vertex4,
		// Token: 0x04002F0F RID: 12047
		Texture1D = 3552,
		// Token: 0x04002F10 RID: 12048
		Texture2D,
		// Token: 0x04002F11 RID: 12049
		PolygonOffsetPoint = 10753,
		// Token: 0x04002F12 RID: 12050
		PolygonOffsetLine,
		// Token: 0x04002F13 RID: 12051
		ClipDistance0 = 12288,
		// Token: 0x04002F14 RID: 12052
		ClipPlane0 = 12288,
		// Token: 0x04002F15 RID: 12053
		ClipDistance1,
		// Token: 0x04002F16 RID: 12054
		ClipPlane1 = 12289,
		// Token: 0x04002F17 RID: 12055
		ClipDistance2,
		// Token: 0x04002F18 RID: 12056
		ClipPlane2 = 12290,
		// Token: 0x04002F19 RID: 12057
		ClipDistance3,
		// Token: 0x04002F1A RID: 12058
		ClipPlane3 = 12291,
		// Token: 0x04002F1B RID: 12059
		ClipDistance4,
		// Token: 0x04002F1C RID: 12060
		ClipPlane4 = 12292,
		// Token: 0x04002F1D RID: 12061
		ClipDistance5,
		// Token: 0x04002F1E RID: 12062
		ClipPlane5 = 12293,
		// Token: 0x04002F1F RID: 12063
		ClipDistance6,
		// Token: 0x04002F20 RID: 12064
		ClipDistance7,
		// Token: 0x04002F21 RID: 12065
		Light0 = 16384,
		// Token: 0x04002F22 RID: 12066
		Light1,
		// Token: 0x04002F23 RID: 12067
		Light2,
		// Token: 0x04002F24 RID: 12068
		Light3,
		// Token: 0x04002F25 RID: 12069
		Light4,
		// Token: 0x04002F26 RID: 12070
		Light5,
		// Token: 0x04002F27 RID: 12071
		Light6,
		// Token: 0x04002F28 RID: 12072
		Light7,
		// Token: 0x04002F29 RID: 12073
		Convolution1D = 32784,
		// Token: 0x04002F2A RID: 12074
		Convolution1DExt = 32784,
		// Token: 0x04002F2B RID: 12075
		Convolution2D,
		// Token: 0x04002F2C RID: 12076
		Convolution2DExt = 32785,
		// Token: 0x04002F2D RID: 12077
		Separable2D,
		// Token: 0x04002F2E RID: 12078
		Separable2DExt = 32786,
		// Token: 0x04002F2F RID: 12079
		Histogram = 32804,
		// Token: 0x04002F30 RID: 12080
		HistogramExt = 32804,
		// Token: 0x04002F31 RID: 12081
		MinmaxExt = 32814,
		// Token: 0x04002F32 RID: 12082
		PolygonOffsetFill = 32823,
		// Token: 0x04002F33 RID: 12083
		RescaleNormal = 32826,
		// Token: 0x04002F34 RID: 12084
		RescaleNormalExt = 32826,
		// Token: 0x04002F35 RID: 12085
		Texture3DExt = 32879,
		// Token: 0x04002F36 RID: 12086
		VertexArray = 32884,
		// Token: 0x04002F37 RID: 12087
		NormalArray,
		// Token: 0x04002F38 RID: 12088
		ColorArray,
		// Token: 0x04002F39 RID: 12089
		IndexArray,
		// Token: 0x04002F3A RID: 12090
		TextureCoordArray,
		// Token: 0x04002F3B RID: 12091
		EdgeFlagArray,
		// Token: 0x04002F3C RID: 12092
		InterlaceSgix = 32916,
		// Token: 0x04002F3D RID: 12093
		Multisample = 32925,
		// Token: 0x04002F3E RID: 12094
		MultisampleSgis = 32925,
		// Token: 0x04002F3F RID: 12095
		SampleAlphaToCoverage,
		// Token: 0x04002F40 RID: 12096
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x04002F41 RID: 12097
		SampleAlphaToOne,
		// Token: 0x04002F42 RID: 12098
		SampleAlphaToOneSgis = 32927,
		// Token: 0x04002F43 RID: 12099
		SampleCoverage,
		// Token: 0x04002F44 RID: 12100
		SampleMaskSgis = 32928,
		// Token: 0x04002F45 RID: 12101
		TextureColorTableSgi = 32956,
		// Token: 0x04002F46 RID: 12102
		ColorTable = 32976,
		// Token: 0x04002F47 RID: 12103
		ColorTableSgi = 32976,
		// Token: 0x04002F48 RID: 12104
		PostConvolutionColorTable,
		// Token: 0x04002F49 RID: 12105
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x04002F4A RID: 12106
		PostColorMatrixColorTable,
		// Token: 0x04002F4B RID: 12107
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x04002F4C RID: 12108
		Texture4DSgis = 33076,
		// Token: 0x04002F4D RID: 12109
		PixelTexGenSgix = 33081,
		// Token: 0x04002F4E RID: 12110
		SpriteSgix = 33096,
		// Token: 0x04002F4F RID: 12111
		ReferencePlaneSgix = 33149,
		// Token: 0x04002F50 RID: 12112
		IrInstrument1Sgix = 33151,
		// Token: 0x04002F51 RID: 12113
		CalligraphicFragmentSgix = 33155,
		// Token: 0x04002F52 RID: 12114
		FramezoomSgix = 33163,
		// Token: 0x04002F53 RID: 12115
		FogOffsetSgix = 33176,
		// Token: 0x04002F54 RID: 12116
		SharedTexturePaletteExt = 33275,
		// Token: 0x04002F55 RID: 12117
		DebugOutputSynchronous = 33346,
		// Token: 0x04002F56 RID: 12118
		AsyncHistogramSgix = 33580,
		// Token: 0x04002F57 RID: 12119
		PixelTextureSgis = 33619,
		// Token: 0x04002F58 RID: 12120
		AsyncTexImageSgix = 33628,
		// Token: 0x04002F59 RID: 12121
		AsyncDrawPixelsSgix,
		// Token: 0x04002F5A RID: 12122
		AsyncReadPixelsSgix,
		// Token: 0x04002F5B RID: 12123
		FragmentLightingSgix = 33792,
		// Token: 0x04002F5C RID: 12124
		FragmentColorMaterialSgix,
		// Token: 0x04002F5D RID: 12125
		FragmentLight0Sgix = 33804,
		// Token: 0x04002F5E RID: 12126
		FragmentLight1Sgix,
		// Token: 0x04002F5F RID: 12127
		FragmentLight2Sgix,
		// Token: 0x04002F60 RID: 12128
		FragmentLight3Sgix,
		// Token: 0x04002F61 RID: 12129
		FragmentLight4Sgix,
		// Token: 0x04002F62 RID: 12130
		FragmentLight5Sgix,
		// Token: 0x04002F63 RID: 12131
		FragmentLight6Sgix,
		// Token: 0x04002F64 RID: 12132
		FragmentLight7Sgix,
		// Token: 0x04002F65 RID: 12133
		FogCoordArray = 33879,
		// Token: 0x04002F66 RID: 12134
		ColorSum,
		// Token: 0x04002F67 RID: 12135
		SecondaryColorArray = 33886,
		// Token: 0x04002F68 RID: 12136
		TextureRectangle = 34037,
		// Token: 0x04002F69 RID: 12137
		TextureCubeMap = 34067,
		// Token: 0x04002F6A RID: 12138
		ProgramPointSize = 34370,
		// Token: 0x04002F6B RID: 12139
		VertexProgramPointSize = 34370,
		// Token: 0x04002F6C RID: 12140
		VertexProgramTwoSide,
		// Token: 0x04002F6D RID: 12141
		DepthClamp = 34383,
		// Token: 0x04002F6E RID: 12142
		TextureCubeMapSeamless = 34895,
		// Token: 0x04002F6F RID: 12143
		PointSprite = 34913,
		// Token: 0x04002F70 RID: 12144
		SampleShading = 35894,
		// Token: 0x04002F71 RID: 12145
		RasterizerDiscard = 35977,
		// Token: 0x04002F72 RID: 12146
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x04002F73 RID: 12147
		FramebufferSrgb = 36281,
		// Token: 0x04002F74 RID: 12148
		SampleMask = 36433,
		// Token: 0x04002F75 RID: 12149
		PrimitiveRestart = 36765,
		// Token: 0x04002F76 RID: 12150
		DebugOutput = 37600
	}
}
