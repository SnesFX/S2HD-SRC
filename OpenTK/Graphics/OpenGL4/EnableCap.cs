using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006AE RID: 1710
	public enum EnableCap
	{
		// Token: 0x04006537 RID: 25911
		LineSmooth = 2848,
		// Token: 0x04006538 RID: 25912
		PolygonSmooth = 2881,
		// Token: 0x04006539 RID: 25913
		CullFace = 2884,
		// Token: 0x0400653A RID: 25914
		DepthTest = 2929,
		// Token: 0x0400653B RID: 25915
		StencilTest = 2960,
		// Token: 0x0400653C RID: 25916
		Dither = 3024,
		// Token: 0x0400653D RID: 25917
		Blend = 3042,
		// Token: 0x0400653E RID: 25918
		ColorLogicOp = 3058,
		// Token: 0x0400653F RID: 25919
		ScissorTest = 3089,
		// Token: 0x04006540 RID: 25920
		Texture1D = 3552,
		// Token: 0x04006541 RID: 25921
		Texture2D,
		// Token: 0x04006542 RID: 25922
		PolygonOffsetPoint = 10753,
		// Token: 0x04006543 RID: 25923
		PolygonOffsetLine,
		// Token: 0x04006544 RID: 25924
		ClipDistance0 = 12288,
		// Token: 0x04006545 RID: 25925
		ClipPlane0 = 12288,
		// Token: 0x04006546 RID: 25926
		ClipDistance1,
		// Token: 0x04006547 RID: 25927
		ClipPlane1 = 12289,
		// Token: 0x04006548 RID: 25928
		ClipDistance2,
		// Token: 0x04006549 RID: 25929
		ClipPlane2 = 12290,
		// Token: 0x0400654A RID: 25930
		ClipDistance3,
		// Token: 0x0400654B RID: 25931
		ClipPlane3 = 12291,
		// Token: 0x0400654C RID: 25932
		ClipDistance4,
		// Token: 0x0400654D RID: 25933
		ClipPlane4 = 12292,
		// Token: 0x0400654E RID: 25934
		ClipDistance5,
		// Token: 0x0400654F RID: 25935
		ClipPlane5 = 12293,
		// Token: 0x04006550 RID: 25936
		ClipDistance6,
		// Token: 0x04006551 RID: 25937
		ClipDistance7,
		// Token: 0x04006552 RID: 25938
		Convolution1D = 32784,
		// Token: 0x04006553 RID: 25939
		Convolution1DExt = 32784,
		// Token: 0x04006554 RID: 25940
		Convolution2D,
		// Token: 0x04006555 RID: 25941
		Convolution2DExt = 32785,
		// Token: 0x04006556 RID: 25942
		Separable2D,
		// Token: 0x04006557 RID: 25943
		Separable2DExt = 32786,
		// Token: 0x04006558 RID: 25944
		Histogram = 32804,
		// Token: 0x04006559 RID: 25945
		HistogramExt = 32804,
		// Token: 0x0400655A RID: 25946
		MinmaxExt = 32814,
		// Token: 0x0400655B RID: 25947
		PolygonOffsetFill = 32823,
		// Token: 0x0400655C RID: 25948
		RescaleNormal = 32826,
		// Token: 0x0400655D RID: 25949
		RescaleNormalExt = 32826,
		// Token: 0x0400655E RID: 25950
		Texture3DExt = 32879,
		// Token: 0x0400655F RID: 25951
		InterlaceSgix = 32916,
		// Token: 0x04006560 RID: 25952
		Multisample = 32925,
		// Token: 0x04006561 RID: 25953
		MultisampleSgis = 32925,
		// Token: 0x04006562 RID: 25954
		SampleAlphaToCoverage,
		// Token: 0x04006563 RID: 25955
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x04006564 RID: 25956
		SampleAlphaToOne,
		// Token: 0x04006565 RID: 25957
		SampleAlphaToOneSgis = 32927,
		// Token: 0x04006566 RID: 25958
		SampleCoverage,
		// Token: 0x04006567 RID: 25959
		SampleMaskSgis = 32928,
		// Token: 0x04006568 RID: 25960
		TextureColorTableSgi = 32956,
		// Token: 0x04006569 RID: 25961
		ColorTable = 32976,
		// Token: 0x0400656A RID: 25962
		ColorTableSgi = 32976,
		// Token: 0x0400656B RID: 25963
		PostConvolutionColorTable,
		// Token: 0x0400656C RID: 25964
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x0400656D RID: 25965
		PostColorMatrixColorTable,
		// Token: 0x0400656E RID: 25966
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x0400656F RID: 25967
		Texture4DSgis = 33076,
		// Token: 0x04006570 RID: 25968
		PixelTexGenSgix = 33081,
		// Token: 0x04006571 RID: 25969
		SpriteSgix = 33096,
		// Token: 0x04006572 RID: 25970
		ReferencePlaneSgix = 33149,
		// Token: 0x04006573 RID: 25971
		IrInstrument1Sgix = 33151,
		// Token: 0x04006574 RID: 25972
		CalligraphicFragmentSgix = 33155,
		// Token: 0x04006575 RID: 25973
		FramezoomSgix = 33163,
		// Token: 0x04006576 RID: 25974
		FogOffsetSgix = 33176,
		// Token: 0x04006577 RID: 25975
		SharedTexturePaletteExt = 33275,
		// Token: 0x04006578 RID: 25976
		DebugOutputSynchronous = 33346,
		// Token: 0x04006579 RID: 25977
		AsyncHistogramSgix = 33580,
		// Token: 0x0400657A RID: 25978
		PixelTextureSgis = 33619,
		// Token: 0x0400657B RID: 25979
		AsyncTexImageSgix = 33628,
		// Token: 0x0400657C RID: 25980
		AsyncDrawPixelsSgix,
		// Token: 0x0400657D RID: 25981
		AsyncReadPixelsSgix,
		// Token: 0x0400657E RID: 25982
		FragmentLightingSgix = 33792,
		// Token: 0x0400657F RID: 25983
		FragmentColorMaterialSgix,
		// Token: 0x04006580 RID: 25984
		FragmentLight0Sgix = 33804,
		// Token: 0x04006581 RID: 25985
		FragmentLight1Sgix,
		// Token: 0x04006582 RID: 25986
		FragmentLight2Sgix,
		// Token: 0x04006583 RID: 25987
		FragmentLight3Sgix,
		// Token: 0x04006584 RID: 25988
		FragmentLight4Sgix,
		// Token: 0x04006585 RID: 25989
		FragmentLight5Sgix,
		// Token: 0x04006586 RID: 25990
		FragmentLight6Sgix,
		// Token: 0x04006587 RID: 25991
		FragmentLight7Sgix,
		// Token: 0x04006588 RID: 25992
		FogCoordArray = 33879,
		// Token: 0x04006589 RID: 25993
		ColorSum,
		// Token: 0x0400658A RID: 25994
		SecondaryColorArray = 33886,
		// Token: 0x0400658B RID: 25995
		TextureRectangle = 34037,
		// Token: 0x0400658C RID: 25996
		TextureCubeMap = 34067,
		// Token: 0x0400658D RID: 25997
		ProgramPointSize = 34370,
		// Token: 0x0400658E RID: 25998
		VertexProgramPointSize = 34370,
		// Token: 0x0400658F RID: 25999
		VertexProgramTwoSide,
		// Token: 0x04006590 RID: 26000
		DepthClamp = 34383,
		// Token: 0x04006591 RID: 26001
		TextureCubeMapSeamless = 34895,
		// Token: 0x04006592 RID: 26002
		PointSprite = 34913,
		// Token: 0x04006593 RID: 26003
		SampleShading = 35894,
		// Token: 0x04006594 RID: 26004
		RasterizerDiscard = 35977,
		// Token: 0x04006595 RID: 26005
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x04006596 RID: 26006
		FramebufferSrgb = 36281,
		// Token: 0x04006597 RID: 26007
		SampleMask = 36433,
		// Token: 0x04006598 RID: 26008
		PrimitiveRestart = 36765,
		// Token: 0x04006599 RID: 26009
		DebugOutput = 37600
	}
}
