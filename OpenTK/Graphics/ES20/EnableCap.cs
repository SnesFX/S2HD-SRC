using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000912 RID: 2322
	public enum EnableCap
	{
		// Token: 0x0400989B RID: 39067
		PointSmooth = 2832,
		// Token: 0x0400989C RID: 39068
		LineSmooth = 2848,
		// Token: 0x0400989D RID: 39069
		LineStipple = 2852,
		// Token: 0x0400989E RID: 39070
		PolygonSmooth = 2881,
		// Token: 0x0400989F RID: 39071
		PolygonStipple,
		// Token: 0x040098A0 RID: 39072
		CullFace = 2884,
		// Token: 0x040098A1 RID: 39073
		Lighting = 2896,
		// Token: 0x040098A2 RID: 39074
		ColorMaterial = 2903,
		// Token: 0x040098A3 RID: 39075
		Fog = 2912,
		// Token: 0x040098A4 RID: 39076
		DepthTest = 2929,
		// Token: 0x040098A5 RID: 39077
		StencilTest = 2960,
		// Token: 0x040098A6 RID: 39078
		Normalize = 2977,
		// Token: 0x040098A7 RID: 39079
		AlphaTest = 3008,
		// Token: 0x040098A8 RID: 39080
		Dither = 3024,
		// Token: 0x040098A9 RID: 39081
		Blend = 3042,
		// Token: 0x040098AA RID: 39082
		IndexLogicOp = 3057,
		// Token: 0x040098AB RID: 39083
		ColorLogicOp,
		// Token: 0x040098AC RID: 39084
		ScissorTest = 3089,
		// Token: 0x040098AD RID: 39085
		TextureGenS = 3168,
		// Token: 0x040098AE RID: 39086
		TextureGenT,
		// Token: 0x040098AF RID: 39087
		TextureGenR,
		// Token: 0x040098B0 RID: 39088
		TextureGenQ,
		// Token: 0x040098B1 RID: 39089
		AutoNormal = 3456,
		// Token: 0x040098B2 RID: 39090
		Map1Color4 = 3472,
		// Token: 0x040098B3 RID: 39091
		Map1Index,
		// Token: 0x040098B4 RID: 39092
		Map1Normal,
		// Token: 0x040098B5 RID: 39093
		Map1TextureCoord1,
		// Token: 0x040098B6 RID: 39094
		Map1TextureCoord2,
		// Token: 0x040098B7 RID: 39095
		Map1TextureCoord3,
		// Token: 0x040098B8 RID: 39096
		Map1TextureCoord4,
		// Token: 0x040098B9 RID: 39097
		Map1Vertex3,
		// Token: 0x040098BA RID: 39098
		Map1Vertex4,
		// Token: 0x040098BB RID: 39099
		Map2Color4 = 3504,
		// Token: 0x040098BC RID: 39100
		Map2Index,
		// Token: 0x040098BD RID: 39101
		Map2Normal,
		// Token: 0x040098BE RID: 39102
		Map2TextureCoord1,
		// Token: 0x040098BF RID: 39103
		Map2TextureCoord2,
		// Token: 0x040098C0 RID: 39104
		Map2TextureCoord3,
		// Token: 0x040098C1 RID: 39105
		Map2TextureCoord4,
		// Token: 0x040098C2 RID: 39106
		Map2Vertex3,
		// Token: 0x040098C3 RID: 39107
		Map2Vertex4,
		// Token: 0x040098C4 RID: 39108
		Texture1D = 3552,
		// Token: 0x040098C5 RID: 39109
		Texture2D,
		// Token: 0x040098C6 RID: 39110
		PolygonOffsetPoint = 10753,
		// Token: 0x040098C7 RID: 39111
		PolygonOffsetLine,
		// Token: 0x040098C8 RID: 39112
		ClipPlane0 = 12288,
		// Token: 0x040098C9 RID: 39113
		ClipPlane1,
		// Token: 0x040098CA RID: 39114
		ClipPlane2,
		// Token: 0x040098CB RID: 39115
		ClipPlane3,
		// Token: 0x040098CC RID: 39116
		ClipPlane4,
		// Token: 0x040098CD RID: 39117
		ClipPlane5,
		// Token: 0x040098CE RID: 39118
		Light0 = 16384,
		// Token: 0x040098CF RID: 39119
		Light1,
		// Token: 0x040098D0 RID: 39120
		Light2,
		// Token: 0x040098D1 RID: 39121
		Light3,
		// Token: 0x040098D2 RID: 39122
		Light4,
		// Token: 0x040098D3 RID: 39123
		Light5,
		// Token: 0x040098D4 RID: 39124
		Light6,
		// Token: 0x040098D5 RID: 39125
		Light7,
		// Token: 0x040098D6 RID: 39126
		Convolution1DExt = 32784,
		// Token: 0x040098D7 RID: 39127
		Convolution2DExt,
		// Token: 0x040098D8 RID: 39128
		Separable2DExt,
		// Token: 0x040098D9 RID: 39129
		HistogramExt = 32804,
		// Token: 0x040098DA RID: 39130
		MinmaxExt = 32814,
		// Token: 0x040098DB RID: 39131
		PolygonOffsetFill = 32823,
		// Token: 0x040098DC RID: 39132
		RescaleNormalExt = 32826,
		// Token: 0x040098DD RID: 39133
		Texture3DExt = 32879,
		// Token: 0x040098DE RID: 39134
		VertexArray = 32884,
		// Token: 0x040098DF RID: 39135
		NormalArray,
		// Token: 0x040098E0 RID: 39136
		ColorArray,
		// Token: 0x040098E1 RID: 39137
		IndexArray,
		// Token: 0x040098E2 RID: 39138
		TextureCoordArray,
		// Token: 0x040098E3 RID: 39139
		EdgeFlagArray,
		// Token: 0x040098E4 RID: 39140
		InterlaceSgix = 32916,
		// Token: 0x040098E5 RID: 39141
		MultisampleSgis = 32925,
		// Token: 0x040098E6 RID: 39142
		SampleAlphaToMaskSgis,
		// Token: 0x040098E7 RID: 39143
		SampleAlphaToCoverage = 32926,
		// Token: 0x040098E8 RID: 39144
		SampleAlphaToOneSgis,
		// Token: 0x040098E9 RID: 39145
		SampleMaskSgis,
		// Token: 0x040098EA RID: 39146
		SampleCoverage = 32928,
		// Token: 0x040098EB RID: 39147
		TextureColorTableSgi = 32956,
		// Token: 0x040098EC RID: 39148
		ColorTableSgi = 32976,
		// Token: 0x040098ED RID: 39149
		PostConvolutionColorTableSgi,
		// Token: 0x040098EE RID: 39150
		PostColorMatrixColorTableSgi,
		// Token: 0x040098EF RID: 39151
		Texture4DSgis = 33076,
		// Token: 0x040098F0 RID: 39152
		PixelTexGenSgix = 33081,
		// Token: 0x040098F1 RID: 39153
		SpriteSgix = 33096,
		// Token: 0x040098F2 RID: 39154
		ReferencePlaneSgix = 33149,
		// Token: 0x040098F3 RID: 39155
		IrInstrument1Sgix = 33151,
		// Token: 0x040098F4 RID: 39156
		CalligraphicFragmentSgix = 33155,
		// Token: 0x040098F5 RID: 39157
		FramezoomSgix = 33163,
		// Token: 0x040098F6 RID: 39158
		FogOffsetSgix = 33176,
		// Token: 0x040098F7 RID: 39159
		SharedTexturePaletteExt = 33275,
		// Token: 0x040098F8 RID: 39160
		AsyncHistogramSgix = 33580,
		// Token: 0x040098F9 RID: 39161
		PixelTextureSgis = 33619,
		// Token: 0x040098FA RID: 39162
		AsyncTexImageSgix = 33628,
		// Token: 0x040098FB RID: 39163
		AsyncDrawPixelsSgix,
		// Token: 0x040098FC RID: 39164
		AsyncReadPixelsSgix,
		// Token: 0x040098FD RID: 39165
		FragmentLightingSgix = 33792,
		// Token: 0x040098FE RID: 39166
		FragmentColorMaterialSgix,
		// Token: 0x040098FF RID: 39167
		FragmentLight0Sgix = 33804,
		// Token: 0x04009900 RID: 39168
		FragmentLight1Sgix,
		// Token: 0x04009901 RID: 39169
		FragmentLight2Sgix,
		// Token: 0x04009902 RID: 39170
		FragmentLight3Sgix,
		// Token: 0x04009903 RID: 39171
		FragmentLight4Sgix,
		// Token: 0x04009904 RID: 39172
		FragmentLight5Sgix,
		// Token: 0x04009905 RID: 39173
		FragmentLight6Sgix,
		// Token: 0x04009906 RID: 39174
		FragmentLight7Sgix
	}
}
