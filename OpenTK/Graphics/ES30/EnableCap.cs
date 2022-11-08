using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007C1 RID: 1985
	public enum EnableCap
	{
		// Token: 0x0400804D RID: 32845
		PointSmooth = 2832,
		// Token: 0x0400804E RID: 32846
		LineSmooth = 2848,
		// Token: 0x0400804F RID: 32847
		LineStipple = 2852,
		// Token: 0x04008050 RID: 32848
		PolygonSmooth = 2881,
		// Token: 0x04008051 RID: 32849
		PolygonStipple,
		// Token: 0x04008052 RID: 32850
		CullFace = 2884,
		// Token: 0x04008053 RID: 32851
		Lighting = 2896,
		// Token: 0x04008054 RID: 32852
		ColorMaterial = 2903,
		// Token: 0x04008055 RID: 32853
		Fog = 2912,
		// Token: 0x04008056 RID: 32854
		DepthTest = 2929,
		// Token: 0x04008057 RID: 32855
		StencilTest = 2960,
		// Token: 0x04008058 RID: 32856
		Normalize = 2977,
		// Token: 0x04008059 RID: 32857
		AlphaTest = 3008,
		// Token: 0x0400805A RID: 32858
		Dither = 3024,
		// Token: 0x0400805B RID: 32859
		Blend = 3042,
		// Token: 0x0400805C RID: 32860
		IndexLogicOp = 3057,
		// Token: 0x0400805D RID: 32861
		ColorLogicOp,
		// Token: 0x0400805E RID: 32862
		ScissorTest = 3089,
		// Token: 0x0400805F RID: 32863
		TextureGenS = 3168,
		// Token: 0x04008060 RID: 32864
		TextureGenT,
		// Token: 0x04008061 RID: 32865
		TextureGenR,
		// Token: 0x04008062 RID: 32866
		TextureGenQ,
		// Token: 0x04008063 RID: 32867
		AutoNormal = 3456,
		// Token: 0x04008064 RID: 32868
		Map1Color4 = 3472,
		// Token: 0x04008065 RID: 32869
		Map1Index,
		// Token: 0x04008066 RID: 32870
		Map1Normal,
		// Token: 0x04008067 RID: 32871
		Map1TextureCoord1,
		// Token: 0x04008068 RID: 32872
		Map1TextureCoord2,
		// Token: 0x04008069 RID: 32873
		Map1TextureCoord3,
		// Token: 0x0400806A RID: 32874
		Map1TextureCoord4,
		// Token: 0x0400806B RID: 32875
		Map1Vertex3,
		// Token: 0x0400806C RID: 32876
		Map1Vertex4,
		// Token: 0x0400806D RID: 32877
		Map2Color4 = 3504,
		// Token: 0x0400806E RID: 32878
		Map2Index,
		// Token: 0x0400806F RID: 32879
		Map2Normal,
		// Token: 0x04008070 RID: 32880
		Map2TextureCoord1,
		// Token: 0x04008071 RID: 32881
		Map2TextureCoord2,
		// Token: 0x04008072 RID: 32882
		Map2TextureCoord3,
		// Token: 0x04008073 RID: 32883
		Map2TextureCoord4,
		// Token: 0x04008074 RID: 32884
		Map2Vertex3,
		// Token: 0x04008075 RID: 32885
		Map2Vertex4,
		// Token: 0x04008076 RID: 32886
		Texture1D = 3552,
		// Token: 0x04008077 RID: 32887
		Texture2D,
		// Token: 0x04008078 RID: 32888
		PolygonOffsetPoint = 10753,
		// Token: 0x04008079 RID: 32889
		PolygonOffsetLine,
		// Token: 0x0400807A RID: 32890
		ClipPlane0 = 12288,
		// Token: 0x0400807B RID: 32891
		ClipPlane1,
		// Token: 0x0400807C RID: 32892
		ClipPlane2,
		// Token: 0x0400807D RID: 32893
		ClipPlane3,
		// Token: 0x0400807E RID: 32894
		ClipPlane4,
		// Token: 0x0400807F RID: 32895
		ClipPlane5,
		// Token: 0x04008080 RID: 32896
		Light0 = 16384,
		// Token: 0x04008081 RID: 32897
		Light1,
		// Token: 0x04008082 RID: 32898
		Light2,
		// Token: 0x04008083 RID: 32899
		Light3,
		// Token: 0x04008084 RID: 32900
		Light4,
		// Token: 0x04008085 RID: 32901
		Light5,
		// Token: 0x04008086 RID: 32902
		Light6,
		// Token: 0x04008087 RID: 32903
		Light7,
		// Token: 0x04008088 RID: 32904
		Convolution1DExt = 32784,
		// Token: 0x04008089 RID: 32905
		Convolution2DExt,
		// Token: 0x0400808A RID: 32906
		Separable2DExt,
		// Token: 0x0400808B RID: 32907
		HistogramExt = 32804,
		// Token: 0x0400808C RID: 32908
		MinmaxExt = 32814,
		// Token: 0x0400808D RID: 32909
		PolygonOffsetFill = 32823,
		// Token: 0x0400808E RID: 32910
		RescaleNormalExt = 32826,
		// Token: 0x0400808F RID: 32911
		Texture3DExt = 32879,
		// Token: 0x04008090 RID: 32912
		VertexArray = 32884,
		// Token: 0x04008091 RID: 32913
		NormalArray,
		// Token: 0x04008092 RID: 32914
		ColorArray,
		// Token: 0x04008093 RID: 32915
		IndexArray,
		// Token: 0x04008094 RID: 32916
		TextureCoordArray,
		// Token: 0x04008095 RID: 32917
		EdgeFlagArray,
		// Token: 0x04008096 RID: 32918
		InterlaceSgix = 32916,
		// Token: 0x04008097 RID: 32919
		MultisampleSgis = 32925,
		// Token: 0x04008098 RID: 32920
		SampleAlphaToCoverage,
		// Token: 0x04008099 RID: 32921
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x0400809A RID: 32922
		SampleAlphaToOneSgis,
		// Token: 0x0400809B RID: 32923
		SampleCoverage,
		// Token: 0x0400809C RID: 32924
		SampleMaskSgis = 32928,
		// Token: 0x0400809D RID: 32925
		TextureColorTableSgi = 32956,
		// Token: 0x0400809E RID: 32926
		ColorTableSgi = 32976,
		// Token: 0x0400809F RID: 32927
		PostConvolutionColorTableSgi,
		// Token: 0x040080A0 RID: 32928
		PostColorMatrixColorTableSgi,
		// Token: 0x040080A1 RID: 32929
		Texture4DSgis = 33076,
		// Token: 0x040080A2 RID: 32930
		PixelTexGenSgix = 33081,
		// Token: 0x040080A3 RID: 32931
		SpriteSgix = 33096,
		// Token: 0x040080A4 RID: 32932
		ReferencePlaneSgix = 33149,
		// Token: 0x040080A5 RID: 32933
		IrInstrument1Sgix = 33151,
		// Token: 0x040080A6 RID: 32934
		CalligraphicFragmentSgix = 33155,
		// Token: 0x040080A7 RID: 32935
		FramezoomSgix = 33163,
		// Token: 0x040080A8 RID: 32936
		FogOffsetSgix = 33176,
		// Token: 0x040080A9 RID: 32937
		SharedTexturePaletteExt = 33275,
		// Token: 0x040080AA RID: 32938
		AsyncHistogramSgix = 33580,
		// Token: 0x040080AB RID: 32939
		PixelTextureSgis = 33619,
		// Token: 0x040080AC RID: 32940
		AsyncTexImageSgix = 33628,
		// Token: 0x040080AD RID: 32941
		AsyncDrawPixelsSgix,
		// Token: 0x040080AE RID: 32942
		AsyncReadPixelsSgix,
		// Token: 0x040080AF RID: 32943
		FragmentLightingSgix = 33792,
		// Token: 0x040080B0 RID: 32944
		FragmentColorMaterialSgix,
		// Token: 0x040080B1 RID: 32945
		FragmentLight0Sgix = 33804,
		// Token: 0x040080B2 RID: 32946
		FragmentLight1Sgix,
		// Token: 0x040080B3 RID: 32947
		FragmentLight2Sgix,
		// Token: 0x040080B4 RID: 32948
		FragmentLight3Sgix,
		// Token: 0x040080B5 RID: 32949
		FragmentLight4Sgix,
		// Token: 0x040080B6 RID: 32950
		FragmentLight5Sgix,
		// Token: 0x040080B7 RID: 32951
		FragmentLight6Sgix,
		// Token: 0x040080B8 RID: 32952
		FragmentLight7Sgix,
		// Token: 0x040080B9 RID: 32953
		RasterizerDiscard = 35977,
		// Token: 0x040080BA RID: 32954
		PrimitiveRestartFixedIndex = 36201
	}
}
