using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A35 RID: 2613
	public enum EnableCap
	{
		// Token: 0x0400AB35 RID: 43829
		PointSmooth = 2832,
		// Token: 0x0400AB36 RID: 43830
		LineSmooth = 2848,
		// Token: 0x0400AB37 RID: 43831
		LineStipple = 2852,
		// Token: 0x0400AB38 RID: 43832
		PolygonSmooth = 2881,
		// Token: 0x0400AB39 RID: 43833
		PolygonStipple,
		// Token: 0x0400AB3A RID: 43834
		CullFace = 2884,
		// Token: 0x0400AB3B RID: 43835
		Lighting = 2896,
		// Token: 0x0400AB3C RID: 43836
		ColorMaterial = 2903,
		// Token: 0x0400AB3D RID: 43837
		Fog = 2912,
		// Token: 0x0400AB3E RID: 43838
		DepthTest = 2929,
		// Token: 0x0400AB3F RID: 43839
		StencilTest = 2960,
		// Token: 0x0400AB40 RID: 43840
		Normalize = 2977,
		// Token: 0x0400AB41 RID: 43841
		AlphaTest = 3008,
		// Token: 0x0400AB42 RID: 43842
		Dither = 3024,
		// Token: 0x0400AB43 RID: 43843
		Blend = 3042,
		// Token: 0x0400AB44 RID: 43844
		IndexLogicOp = 3057,
		// Token: 0x0400AB45 RID: 43845
		ColorLogicOp,
		// Token: 0x0400AB46 RID: 43846
		ScissorTest = 3089,
		// Token: 0x0400AB47 RID: 43847
		TextureGenS = 3168,
		// Token: 0x0400AB48 RID: 43848
		TextureGenT,
		// Token: 0x0400AB49 RID: 43849
		TextureGenR,
		// Token: 0x0400AB4A RID: 43850
		TextureGenQ,
		// Token: 0x0400AB4B RID: 43851
		AutoNormal = 3456,
		// Token: 0x0400AB4C RID: 43852
		Map1Color4 = 3472,
		// Token: 0x0400AB4D RID: 43853
		Map1Index,
		// Token: 0x0400AB4E RID: 43854
		Map1Normal,
		// Token: 0x0400AB4F RID: 43855
		Map1TextureCoord1,
		// Token: 0x0400AB50 RID: 43856
		Map1TextureCoord2,
		// Token: 0x0400AB51 RID: 43857
		Map1TextureCoord3,
		// Token: 0x0400AB52 RID: 43858
		Map1TextureCoord4,
		// Token: 0x0400AB53 RID: 43859
		Map1Vertex3,
		// Token: 0x0400AB54 RID: 43860
		Map1Vertex4,
		// Token: 0x0400AB55 RID: 43861
		Map2Color4 = 3504,
		// Token: 0x0400AB56 RID: 43862
		Map2Index,
		// Token: 0x0400AB57 RID: 43863
		Map2Normal,
		// Token: 0x0400AB58 RID: 43864
		Map2TextureCoord1,
		// Token: 0x0400AB59 RID: 43865
		Map2TextureCoord2,
		// Token: 0x0400AB5A RID: 43866
		Map2TextureCoord3,
		// Token: 0x0400AB5B RID: 43867
		Map2TextureCoord4,
		// Token: 0x0400AB5C RID: 43868
		Map2Vertex3,
		// Token: 0x0400AB5D RID: 43869
		Map2Vertex4,
		// Token: 0x0400AB5E RID: 43870
		Texture1D = 3552,
		// Token: 0x0400AB5F RID: 43871
		Texture2D,
		// Token: 0x0400AB60 RID: 43872
		PolygonOffsetPoint = 10753,
		// Token: 0x0400AB61 RID: 43873
		PolygonOffsetLine,
		// Token: 0x0400AB62 RID: 43874
		ClipPlane0 = 12288,
		// Token: 0x0400AB63 RID: 43875
		ClipPlane1,
		// Token: 0x0400AB64 RID: 43876
		ClipPlane2,
		// Token: 0x0400AB65 RID: 43877
		ClipPlane3,
		// Token: 0x0400AB66 RID: 43878
		ClipPlane4,
		// Token: 0x0400AB67 RID: 43879
		ClipPlane5,
		// Token: 0x0400AB68 RID: 43880
		Light0 = 16384,
		// Token: 0x0400AB69 RID: 43881
		Light1,
		// Token: 0x0400AB6A RID: 43882
		Light2,
		// Token: 0x0400AB6B RID: 43883
		Light3,
		// Token: 0x0400AB6C RID: 43884
		Light4,
		// Token: 0x0400AB6D RID: 43885
		Light5,
		// Token: 0x0400AB6E RID: 43886
		Light6,
		// Token: 0x0400AB6F RID: 43887
		Light7,
		// Token: 0x0400AB70 RID: 43888
		Convolution1DExt = 32784,
		// Token: 0x0400AB71 RID: 43889
		Convolution2DExt,
		// Token: 0x0400AB72 RID: 43890
		Separable2DExt,
		// Token: 0x0400AB73 RID: 43891
		HistogramExt = 32804,
		// Token: 0x0400AB74 RID: 43892
		MinmaxExt = 32814,
		// Token: 0x0400AB75 RID: 43893
		PolygonOffsetFill = 32823,
		// Token: 0x0400AB76 RID: 43894
		RescaleNormalExt = 32826,
		// Token: 0x0400AB77 RID: 43895
		Texture3DExt = 32879,
		// Token: 0x0400AB78 RID: 43896
		VertexArray = 32884,
		// Token: 0x0400AB79 RID: 43897
		NormalArray,
		// Token: 0x0400AB7A RID: 43898
		ColorArray,
		// Token: 0x0400AB7B RID: 43899
		IndexArray,
		// Token: 0x0400AB7C RID: 43900
		TextureCoordArray,
		// Token: 0x0400AB7D RID: 43901
		EdgeFlagArray,
		// Token: 0x0400AB7E RID: 43902
		InterlaceSgix = 32916,
		// Token: 0x0400AB7F RID: 43903
		MultisampleSgis = 32925,
		// Token: 0x0400AB80 RID: 43904
		SampleAlphaToMaskSgis,
		// Token: 0x0400AB81 RID: 43905
		SampleAlphaToOneSgis,
		// Token: 0x0400AB82 RID: 43906
		SampleMaskSgis,
		// Token: 0x0400AB83 RID: 43907
		TextureColorTableSgi = 32956,
		// Token: 0x0400AB84 RID: 43908
		ColorTableSgi = 32976,
		// Token: 0x0400AB85 RID: 43909
		PostConvolutionColorTableSgi,
		// Token: 0x0400AB86 RID: 43910
		PostColorMatrixColorTableSgi,
		// Token: 0x0400AB87 RID: 43911
		Texture4DSgis = 33076,
		// Token: 0x0400AB88 RID: 43912
		PixelTexGenSgix = 33081,
		// Token: 0x0400AB89 RID: 43913
		SpriteSgix = 33096,
		// Token: 0x0400AB8A RID: 43914
		ReferencePlaneSgix = 33149,
		// Token: 0x0400AB8B RID: 43915
		IrInstrument1Sgix = 33151,
		// Token: 0x0400AB8C RID: 43916
		CalligraphicFragmentSgix = 33155,
		// Token: 0x0400AB8D RID: 43917
		FramezoomSgix = 33163,
		// Token: 0x0400AB8E RID: 43918
		FogOffsetSgix = 33176,
		// Token: 0x0400AB8F RID: 43919
		SharedTexturePaletteExt = 33275,
		// Token: 0x0400AB90 RID: 43920
		AsyncHistogramSgix = 33580,
		// Token: 0x0400AB91 RID: 43921
		PixelTextureSgis = 33619,
		// Token: 0x0400AB92 RID: 43922
		AsyncTexImageSgix = 33628,
		// Token: 0x0400AB93 RID: 43923
		AsyncDrawPixelsSgix,
		// Token: 0x0400AB94 RID: 43924
		AsyncReadPixelsSgix,
		// Token: 0x0400AB95 RID: 43925
		FragmentLightingSgix = 33792,
		// Token: 0x0400AB96 RID: 43926
		FragmentColorMaterialSgix,
		// Token: 0x0400AB97 RID: 43927
		FragmentLight0Sgix = 33804,
		// Token: 0x0400AB98 RID: 43928
		FragmentLight1Sgix,
		// Token: 0x0400AB99 RID: 43929
		FragmentLight2Sgix,
		// Token: 0x0400AB9A RID: 43930
		FragmentLight3Sgix,
		// Token: 0x0400AB9B RID: 43931
		FragmentLight4Sgix,
		// Token: 0x0400AB9C RID: 43932
		FragmentLight5Sgix,
		// Token: 0x0400AB9D RID: 43933
		FragmentLight6Sgix,
		// Token: 0x0400AB9E RID: 43934
		FragmentLight7Sgix
	}
}
