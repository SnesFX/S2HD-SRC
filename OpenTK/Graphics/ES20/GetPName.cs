using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x0200095C RID: 2396
	public enum GetPName
	{
		// Token: 0x04009C19 RID: 39961
		CurrentColor = 2816,
		// Token: 0x04009C1A RID: 39962
		CurrentIndex,
		// Token: 0x04009C1B RID: 39963
		CurrentNormal,
		// Token: 0x04009C1C RID: 39964
		CurrentTextureCoords,
		// Token: 0x04009C1D RID: 39965
		CurrentRasterColor,
		// Token: 0x04009C1E RID: 39966
		CurrentRasterIndex,
		// Token: 0x04009C1F RID: 39967
		CurrentRasterTextureCoords,
		// Token: 0x04009C20 RID: 39968
		CurrentRasterPosition,
		// Token: 0x04009C21 RID: 39969
		CurrentRasterPositionValid,
		// Token: 0x04009C22 RID: 39970
		CurrentRasterDistance,
		// Token: 0x04009C23 RID: 39971
		PointSmooth = 2832,
		// Token: 0x04009C24 RID: 39972
		PointSize,
		// Token: 0x04009C25 RID: 39973
		PointSizeRange,
		// Token: 0x04009C26 RID: 39974
		SmoothPointSizeRange = 2834,
		// Token: 0x04009C27 RID: 39975
		PointSizeGranularity,
		// Token: 0x04009C28 RID: 39976
		SmoothPointSizeGranularity = 2835,
		// Token: 0x04009C29 RID: 39977
		LineSmooth = 2848,
		// Token: 0x04009C2A RID: 39978
		LineWidth,
		// Token: 0x04009C2B RID: 39979
		LineWidthRange,
		// Token: 0x04009C2C RID: 39980
		SmoothLineWidthRange = 2850,
		// Token: 0x04009C2D RID: 39981
		LineWidthGranularity,
		// Token: 0x04009C2E RID: 39982
		SmoothLineWidthGranularity = 2851,
		// Token: 0x04009C2F RID: 39983
		LineStipple,
		// Token: 0x04009C30 RID: 39984
		LineStipplePattern,
		// Token: 0x04009C31 RID: 39985
		LineStippleRepeat,
		// Token: 0x04009C32 RID: 39986
		ListMode = 2864,
		// Token: 0x04009C33 RID: 39987
		MaxListNesting,
		// Token: 0x04009C34 RID: 39988
		ListBase,
		// Token: 0x04009C35 RID: 39989
		ListIndex,
		// Token: 0x04009C36 RID: 39990
		PolygonMode = 2880,
		// Token: 0x04009C37 RID: 39991
		PolygonSmooth,
		// Token: 0x04009C38 RID: 39992
		PolygonStipple,
		// Token: 0x04009C39 RID: 39993
		EdgeFlag,
		// Token: 0x04009C3A RID: 39994
		CullFace,
		// Token: 0x04009C3B RID: 39995
		CullFaceMode,
		// Token: 0x04009C3C RID: 39996
		FrontFace,
		// Token: 0x04009C3D RID: 39997
		Lighting = 2896,
		// Token: 0x04009C3E RID: 39998
		LightModelLocalViewer,
		// Token: 0x04009C3F RID: 39999
		LightModelTwoSide,
		// Token: 0x04009C40 RID: 40000
		LightModelAmbient,
		// Token: 0x04009C41 RID: 40001
		ShadeModel,
		// Token: 0x04009C42 RID: 40002
		ColorMaterialFace,
		// Token: 0x04009C43 RID: 40003
		ColorMaterialParameter,
		// Token: 0x04009C44 RID: 40004
		ColorMaterial,
		// Token: 0x04009C45 RID: 40005
		Fog = 2912,
		// Token: 0x04009C46 RID: 40006
		FogIndex,
		// Token: 0x04009C47 RID: 40007
		FogDensity,
		// Token: 0x04009C48 RID: 40008
		FogStart,
		// Token: 0x04009C49 RID: 40009
		FogEnd,
		// Token: 0x04009C4A RID: 40010
		FogMode,
		// Token: 0x04009C4B RID: 40011
		FogColor,
		// Token: 0x04009C4C RID: 40012
		DepthRange = 2928,
		// Token: 0x04009C4D RID: 40013
		DepthTest,
		// Token: 0x04009C4E RID: 40014
		DepthWritemask,
		// Token: 0x04009C4F RID: 40015
		DepthClearValue,
		// Token: 0x04009C50 RID: 40016
		DepthFunc,
		// Token: 0x04009C51 RID: 40017
		AccumClearValue = 2944,
		// Token: 0x04009C52 RID: 40018
		StencilTest = 2960,
		// Token: 0x04009C53 RID: 40019
		StencilClearValue,
		// Token: 0x04009C54 RID: 40020
		StencilFunc,
		// Token: 0x04009C55 RID: 40021
		StencilValueMask,
		// Token: 0x04009C56 RID: 40022
		StencilFail,
		// Token: 0x04009C57 RID: 40023
		StencilPassDepthFail,
		// Token: 0x04009C58 RID: 40024
		StencilPassDepthPass,
		// Token: 0x04009C59 RID: 40025
		StencilRef,
		// Token: 0x04009C5A RID: 40026
		StencilWritemask,
		// Token: 0x04009C5B RID: 40027
		MatrixMode = 2976,
		// Token: 0x04009C5C RID: 40028
		Normalize,
		// Token: 0x04009C5D RID: 40029
		Viewport,
		// Token: 0x04009C5E RID: 40030
		Modelview0StackDepthExt,
		// Token: 0x04009C5F RID: 40031
		ModelviewStackDepth = 2979,
		// Token: 0x04009C60 RID: 40032
		ProjectionStackDepth,
		// Token: 0x04009C61 RID: 40033
		TextureStackDepth,
		// Token: 0x04009C62 RID: 40034
		Modelview0MatrixExt,
		// Token: 0x04009C63 RID: 40035
		ModelviewMatrix = 2982,
		// Token: 0x04009C64 RID: 40036
		ProjectionMatrix,
		// Token: 0x04009C65 RID: 40037
		TextureMatrix,
		// Token: 0x04009C66 RID: 40038
		AttribStackDepth = 2992,
		// Token: 0x04009C67 RID: 40039
		ClientAttribStackDepth,
		// Token: 0x04009C68 RID: 40040
		AlphaTest = 3008,
		// Token: 0x04009C69 RID: 40041
		AlphaTestQcom = 3008,
		// Token: 0x04009C6A RID: 40042
		AlphaTestFunc,
		// Token: 0x04009C6B RID: 40043
		AlphaTestFuncQcom = 3009,
		// Token: 0x04009C6C RID: 40044
		AlphaTestRef,
		// Token: 0x04009C6D RID: 40045
		AlphaTestRefQcom = 3010,
		// Token: 0x04009C6E RID: 40046
		Dither = 3024,
		// Token: 0x04009C6F RID: 40047
		BlendDst = 3040,
		// Token: 0x04009C70 RID: 40048
		BlendSrc,
		// Token: 0x04009C71 RID: 40049
		Blend,
		// Token: 0x04009C72 RID: 40050
		LogicOpMode = 3056,
		// Token: 0x04009C73 RID: 40051
		IndexLogicOp,
		// Token: 0x04009C74 RID: 40052
		LogicOp = 3057,
		// Token: 0x04009C75 RID: 40053
		ColorLogicOp,
		// Token: 0x04009C76 RID: 40054
		AuxBuffers = 3072,
		// Token: 0x04009C77 RID: 40055
		DrawBuffer,
		// Token: 0x04009C78 RID: 40056
		DrawBufferExt = 3073,
		// Token: 0x04009C79 RID: 40057
		ReadBuffer,
		// Token: 0x04009C7A RID: 40058
		ReadBufferExt = 3074,
		// Token: 0x04009C7B RID: 40059
		ReadBufferNv = 3074,
		// Token: 0x04009C7C RID: 40060
		ScissorBox = 3088,
		// Token: 0x04009C7D RID: 40061
		ScissorTest,
		// Token: 0x04009C7E RID: 40062
		IndexClearValue = 3104,
		// Token: 0x04009C7F RID: 40063
		IndexWritemask,
		// Token: 0x04009C80 RID: 40064
		ColorClearValue,
		// Token: 0x04009C81 RID: 40065
		ColorWritemask,
		// Token: 0x04009C82 RID: 40066
		IndexMode = 3120,
		// Token: 0x04009C83 RID: 40067
		RgbaMode,
		// Token: 0x04009C84 RID: 40068
		Doublebuffer,
		// Token: 0x04009C85 RID: 40069
		Stereo,
		// Token: 0x04009C86 RID: 40070
		RenderMode = 3136,
		// Token: 0x04009C87 RID: 40071
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04009C88 RID: 40072
		PointSmoothHint,
		// Token: 0x04009C89 RID: 40073
		LineSmoothHint,
		// Token: 0x04009C8A RID: 40074
		PolygonSmoothHint,
		// Token: 0x04009C8B RID: 40075
		FogHint,
		// Token: 0x04009C8C RID: 40076
		TextureGenS = 3168,
		// Token: 0x04009C8D RID: 40077
		TextureGenT,
		// Token: 0x04009C8E RID: 40078
		TextureGenR,
		// Token: 0x04009C8F RID: 40079
		TextureGenQ,
		// Token: 0x04009C90 RID: 40080
		PixelMapIToISize = 3248,
		// Token: 0x04009C91 RID: 40081
		PixelMapSToSSize,
		// Token: 0x04009C92 RID: 40082
		PixelMapIToRSize,
		// Token: 0x04009C93 RID: 40083
		PixelMapIToGSize,
		// Token: 0x04009C94 RID: 40084
		PixelMapIToBSize,
		// Token: 0x04009C95 RID: 40085
		PixelMapIToASize,
		// Token: 0x04009C96 RID: 40086
		PixelMapRToRSize,
		// Token: 0x04009C97 RID: 40087
		PixelMapGToGSize,
		// Token: 0x04009C98 RID: 40088
		PixelMapBToBSize,
		// Token: 0x04009C99 RID: 40089
		PixelMapAToASize,
		// Token: 0x04009C9A RID: 40090
		UnpackSwapBytes = 3312,
		// Token: 0x04009C9B RID: 40091
		UnpackLsbFirst,
		// Token: 0x04009C9C RID: 40092
		UnpackRowLength,
		// Token: 0x04009C9D RID: 40093
		UnpackSkipRows,
		// Token: 0x04009C9E RID: 40094
		UnpackSkipPixels,
		// Token: 0x04009C9F RID: 40095
		UnpackAlignment,
		// Token: 0x04009CA0 RID: 40096
		PackSwapBytes = 3328,
		// Token: 0x04009CA1 RID: 40097
		PackLsbFirst,
		// Token: 0x04009CA2 RID: 40098
		PackRowLength,
		// Token: 0x04009CA3 RID: 40099
		PackSkipRows,
		// Token: 0x04009CA4 RID: 40100
		PackSkipPixels,
		// Token: 0x04009CA5 RID: 40101
		PackAlignment,
		// Token: 0x04009CA6 RID: 40102
		MapColor = 3344,
		// Token: 0x04009CA7 RID: 40103
		MapStencil,
		// Token: 0x04009CA8 RID: 40104
		IndexShift,
		// Token: 0x04009CA9 RID: 40105
		IndexOffset,
		// Token: 0x04009CAA RID: 40106
		RedScale,
		// Token: 0x04009CAB RID: 40107
		RedBias,
		// Token: 0x04009CAC RID: 40108
		ZoomX,
		// Token: 0x04009CAD RID: 40109
		ZoomY,
		// Token: 0x04009CAE RID: 40110
		GreenScale,
		// Token: 0x04009CAF RID: 40111
		GreenBias,
		// Token: 0x04009CB0 RID: 40112
		BlueScale,
		// Token: 0x04009CB1 RID: 40113
		BlueBias,
		// Token: 0x04009CB2 RID: 40114
		AlphaScale,
		// Token: 0x04009CB3 RID: 40115
		AlphaBias,
		// Token: 0x04009CB4 RID: 40116
		DepthScale,
		// Token: 0x04009CB5 RID: 40117
		DepthBias,
		// Token: 0x04009CB6 RID: 40118
		MaxEvalOrder = 3376,
		// Token: 0x04009CB7 RID: 40119
		MaxLights,
		// Token: 0x04009CB8 RID: 40120
		MaxClipDistances,
		// Token: 0x04009CB9 RID: 40121
		MaxClipPlanes = 3378,
		// Token: 0x04009CBA RID: 40122
		MaxTextureSize,
		// Token: 0x04009CBB RID: 40123
		MaxPixelMapTable,
		// Token: 0x04009CBC RID: 40124
		MaxAttribStackDepth,
		// Token: 0x04009CBD RID: 40125
		MaxModelviewStackDepth,
		// Token: 0x04009CBE RID: 40126
		MaxNameStackDepth,
		// Token: 0x04009CBF RID: 40127
		MaxProjectionStackDepth,
		// Token: 0x04009CC0 RID: 40128
		MaxTextureStackDepth,
		// Token: 0x04009CC1 RID: 40129
		MaxViewportDims,
		// Token: 0x04009CC2 RID: 40130
		MaxClientAttribStackDepth,
		// Token: 0x04009CC3 RID: 40131
		SubpixelBits = 3408,
		// Token: 0x04009CC4 RID: 40132
		IndexBits,
		// Token: 0x04009CC5 RID: 40133
		RedBits,
		// Token: 0x04009CC6 RID: 40134
		GreenBits,
		// Token: 0x04009CC7 RID: 40135
		BlueBits,
		// Token: 0x04009CC8 RID: 40136
		AlphaBits,
		// Token: 0x04009CC9 RID: 40137
		DepthBits,
		// Token: 0x04009CCA RID: 40138
		StencilBits,
		// Token: 0x04009CCB RID: 40139
		AccumRedBits,
		// Token: 0x04009CCC RID: 40140
		AccumGreenBits,
		// Token: 0x04009CCD RID: 40141
		AccumBlueBits,
		// Token: 0x04009CCE RID: 40142
		AccumAlphaBits,
		// Token: 0x04009CCF RID: 40143
		NameStackDepth = 3440,
		// Token: 0x04009CD0 RID: 40144
		AutoNormal = 3456,
		// Token: 0x04009CD1 RID: 40145
		Map1Color4 = 3472,
		// Token: 0x04009CD2 RID: 40146
		Map1Index,
		// Token: 0x04009CD3 RID: 40147
		Map1Normal,
		// Token: 0x04009CD4 RID: 40148
		Map1TextureCoord1,
		// Token: 0x04009CD5 RID: 40149
		Map1TextureCoord2,
		// Token: 0x04009CD6 RID: 40150
		Map1TextureCoord3,
		// Token: 0x04009CD7 RID: 40151
		Map1TextureCoord4,
		// Token: 0x04009CD8 RID: 40152
		Map1Vertex3,
		// Token: 0x04009CD9 RID: 40153
		Map1Vertex4,
		// Token: 0x04009CDA RID: 40154
		Map2Color4 = 3504,
		// Token: 0x04009CDB RID: 40155
		Map2Index,
		// Token: 0x04009CDC RID: 40156
		Map2Normal,
		// Token: 0x04009CDD RID: 40157
		Map2TextureCoord1,
		// Token: 0x04009CDE RID: 40158
		Map2TextureCoord2,
		// Token: 0x04009CDF RID: 40159
		Map2TextureCoord3,
		// Token: 0x04009CE0 RID: 40160
		Map2TextureCoord4,
		// Token: 0x04009CE1 RID: 40161
		Map2Vertex3,
		// Token: 0x04009CE2 RID: 40162
		Map2Vertex4,
		// Token: 0x04009CE3 RID: 40163
		Map1GridDomain = 3536,
		// Token: 0x04009CE4 RID: 40164
		Map1GridSegments,
		// Token: 0x04009CE5 RID: 40165
		Map2GridDomain,
		// Token: 0x04009CE6 RID: 40166
		Map2GridSegments,
		// Token: 0x04009CE7 RID: 40167
		Texture1D = 3552,
		// Token: 0x04009CE8 RID: 40168
		Texture2D,
		// Token: 0x04009CE9 RID: 40169
		FeedbackBufferSize = 3569,
		// Token: 0x04009CEA RID: 40170
		FeedbackBufferType,
		// Token: 0x04009CEB RID: 40171
		SelectionBufferSize = 3572,
		// Token: 0x04009CEC RID: 40172
		PolygonOffsetUnits = 10752,
		// Token: 0x04009CED RID: 40173
		PolygonOffsetPoint,
		// Token: 0x04009CEE RID: 40174
		PolygonOffsetLine,
		// Token: 0x04009CEF RID: 40175
		ClipPlane0 = 12288,
		// Token: 0x04009CF0 RID: 40176
		ClipPlane1,
		// Token: 0x04009CF1 RID: 40177
		ClipPlane2,
		// Token: 0x04009CF2 RID: 40178
		ClipPlane3,
		// Token: 0x04009CF3 RID: 40179
		ClipPlane4,
		// Token: 0x04009CF4 RID: 40180
		ClipPlane5,
		// Token: 0x04009CF5 RID: 40181
		Light0 = 16384,
		// Token: 0x04009CF6 RID: 40182
		Light1,
		// Token: 0x04009CF7 RID: 40183
		Light2,
		// Token: 0x04009CF8 RID: 40184
		Light3,
		// Token: 0x04009CF9 RID: 40185
		Light4,
		// Token: 0x04009CFA RID: 40186
		Light5,
		// Token: 0x04009CFB RID: 40187
		Light6,
		// Token: 0x04009CFC RID: 40188
		Light7,
		// Token: 0x04009CFD RID: 40189
		BlendColorExt = 32773,
		// Token: 0x04009CFE RID: 40190
		BlendColor = 32773,
		// Token: 0x04009CFF RID: 40191
		BlendEquationExt = 32777,
		// Token: 0x04009D00 RID: 40192
		BlendEquation = 32777,
		// Token: 0x04009D01 RID: 40193
		BlendEquationRgb = 32777,
		// Token: 0x04009D02 RID: 40194
		PackCmykHintExt = 32782,
		// Token: 0x04009D03 RID: 40195
		UnpackCmykHintExt,
		// Token: 0x04009D04 RID: 40196
		Convolution1DExt,
		// Token: 0x04009D05 RID: 40197
		Convolution2DExt,
		// Token: 0x04009D06 RID: 40198
		Separable2DExt,
		// Token: 0x04009D07 RID: 40199
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x04009D08 RID: 40200
		PostConvolutionGreenScaleExt,
		// Token: 0x04009D09 RID: 40201
		PostConvolutionBlueScaleExt,
		// Token: 0x04009D0A RID: 40202
		PostConvolutionAlphaScaleExt,
		// Token: 0x04009D0B RID: 40203
		PostConvolutionRedBiasExt,
		// Token: 0x04009D0C RID: 40204
		PostConvolutionGreenBiasExt,
		// Token: 0x04009D0D RID: 40205
		PostConvolutionBlueBiasExt,
		// Token: 0x04009D0E RID: 40206
		PostConvolutionAlphaBiasExt,
		// Token: 0x04009D0F RID: 40207
		HistogramExt,
		// Token: 0x04009D10 RID: 40208
		MinmaxExt = 32814,
		// Token: 0x04009D11 RID: 40209
		PolygonOffsetFill = 32823,
		// Token: 0x04009D12 RID: 40210
		PolygonOffsetFactor,
		// Token: 0x04009D13 RID: 40211
		PolygonOffsetBiasExt,
		// Token: 0x04009D14 RID: 40212
		RescaleNormalExt,
		// Token: 0x04009D15 RID: 40213
		TextureBinding1D = 32872,
		// Token: 0x04009D16 RID: 40214
		TextureBinding2D,
		// Token: 0x04009D17 RID: 40215
		Texture3DBindingExt,
		// Token: 0x04009D18 RID: 40216
		TextureBinding3D = 32874,
		// Token: 0x04009D19 RID: 40217
		TextureBinding3DOes = 32874,
		// Token: 0x04009D1A RID: 40218
		PackSkipImagesExt,
		// Token: 0x04009D1B RID: 40219
		PackImageHeightExt,
		// Token: 0x04009D1C RID: 40220
		UnpackSkipImagesExt,
		// Token: 0x04009D1D RID: 40221
		UnpackImageHeightExt,
		// Token: 0x04009D1E RID: 40222
		Texture3DExt,
		// Token: 0x04009D1F RID: 40223
		Max3DTextureSizeExt = 32883,
		// Token: 0x04009D20 RID: 40224
		Max3DTextureSizeOes = 32883,
		// Token: 0x04009D21 RID: 40225
		VertexArray,
		// Token: 0x04009D22 RID: 40226
		NormalArray,
		// Token: 0x04009D23 RID: 40227
		ColorArray,
		// Token: 0x04009D24 RID: 40228
		IndexArray,
		// Token: 0x04009D25 RID: 40229
		TextureCoordArray,
		// Token: 0x04009D26 RID: 40230
		EdgeFlagArray,
		// Token: 0x04009D27 RID: 40231
		VertexArraySize,
		// Token: 0x04009D28 RID: 40232
		VertexArrayType,
		// Token: 0x04009D29 RID: 40233
		VertexArrayStride,
		// Token: 0x04009D2A RID: 40234
		VertexArrayCountExt,
		// Token: 0x04009D2B RID: 40235
		NormalArrayType,
		// Token: 0x04009D2C RID: 40236
		NormalArrayStride,
		// Token: 0x04009D2D RID: 40237
		NormalArrayCountExt,
		// Token: 0x04009D2E RID: 40238
		ColorArraySize,
		// Token: 0x04009D2F RID: 40239
		ColorArrayType,
		// Token: 0x04009D30 RID: 40240
		ColorArrayStride,
		// Token: 0x04009D31 RID: 40241
		ColorArrayCountExt,
		// Token: 0x04009D32 RID: 40242
		IndexArrayType,
		// Token: 0x04009D33 RID: 40243
		IndexArrayStride,
		// Token: 0x04009D34 RID: 40244
		IndexArrayCountExt,
		// Token: 0x04009D35 RID: 40245
		TextureCoordArraySize,
		// Token: 0x04009D36 RID: 40246
		TextureCoordArrayType,
		// Token: 0x04009D37 RID: 40247
		TextureCoordArrayStride,
		// Token: 0x04009D38 RID: 40248
		TextureCoordArrayCountExt,
		// Token: 0x04009D39 RID: 40249
		EdgeFlagArrayStride,
		// Token: 0x04009D3A RID: 40250
		EdgeFlagArrayCountExt,
		// Token: 0x04009D3B RID: 40251
		InterlaceSgix = 32916,
		// Token: 0x04009D3C RID: 40252
		DetailTexture2DBindingSgis = 32918,
		// Token: 0x04009D3D RID: 40253
		MultisampleSgis = 32925,
		// Token: 0x04009D3E RID: 40254
		SampleAlphaToMaskSgis,
		// Token: 0x04009D3F RID: 40255
		SampleAlphaToCoverage = 32926,
		// Token: 0x04009D40 RID: 40256
		SampleAlphaToOneSgis,
		// Token: 0x04009D41 RID: 40257
		SampleMaskSgis,
		// Token: 0x04009D42 RID: 40258
		SampleCoverage = 32928,
		// Token: 0x04009D43 RID: 40259
		SampleBuffersSgis = 32936,
		// Token: 0x04009D44 RID: 40260
		SampleBuffers = 32936,
		// Token: 0x04009D45 RID: 40261
		SamplesSgis,
		// Token: 0x04009D46 RID: 40262
		Samples = 32937,
		// Token: 0x04009D47 RID: 40263
		SampleMaskValueSgis,
		// Token: 0x04009D48 RID: 40264
		SampleCoverageValue = 32938,
		// Token: 0x04009D49 RID: 40265
		SampleMaskInvertSgis,
		// Token: 0x04009D4A RID: 40266
		SampleCoverageInvert = 32939,
		// Token: 0x04009D4B RID: 40267
		SamplePatternSgis,
		// Token: 0x04009D4C RID: 40268
		ColorMatrixSgi = 32945,
		// Token: 0x04009D4D RID: 40269
		ColorMatrixStackDepthSgi,
		// Token: 0x04009D4E RID: 40270
		MaxColorMatrixStackDepthSgi,
		// Token: 0x04009D4F RID: 40271
		PostColorMatrixRedScaleSgi,
		// Token: 0x04009D50 RID: 40272
		PostColorMatrixGreenScaleSgi,
		// Token: 0x04009D51 RID: 40273
		PostColorMatrixBlueScaleSgi,
		// Token: 0x04009D52 RID: 40274
		PostColorMatrixAlphaScaleSgi,
		// Token: 0x04009D53 RID: 40275
		PostColorMatrixRedBiasSgi,
		// Token: 0x04009D54 RID: 40276
		PostColorMatrixGreenBiasSgi,
		// Token: 0x04009D55 RID: 40277
		PostColorMatrixBlueBiasSgi,
		// Token: 0x04009D56 RID: 40278
		PostColorMatrixAlphaBiasSgi,
		// Token: 0x04009D57 RID: 40279
		TextureColorTableSgi,
		// Token: 0x04009D58 RID: 40280
		BlendDstRgb = 32968,
		// Token: 0x04009D59 RID: 40281
		BlendSrcRgb,
		// Token: 0x04009D5A RID: 40282
		BlendDstAlpha,
		// Token: 0x04009D5B RID: 40283
		BlendSrcAlpha,
		// Token: 0x04009D5C RID: 40284
		ColorTableSgi = 32976,
		// Token: 0x04009D5D RID: 40285
		PostConvolutionColorTableSgi,
		// Token: 0x04009D5E RID: 40286
		PostColorMatrixColorTableSgi,
		// Token: 0x04009D5F RID: 40287
		PointSizeMinSgis = 33062,
		// Token: 0x04009D60 RID: 40288
		PointSizeMaxSgis,
		// Token: 0x04009D61 RID: 40289
		PointFadeThresholdSizeSgis,
		// Token: 0x04009D62 RID: 40290
		DistanceAttenuationSgis,
		// Token: 0x04009D63 RID: 40291
		FogFuncPointsSgis = 33067,
		// Token: 0x04009D64 RID: 40292
		MaxFogFuncPointsSgis,
		// Token: 0x04009D65 RID: 40293
		PackSkipVolumesSgis = 33072,
		// Token: 0x04009D66 RID: 40294
		PackImageDepthSgis,
		// Token: 0x04009D67 RID: 40295
		UnpackSkipVolumesSgis,
		// Token: 0x04009D68 RID: 40296
		UnpackImageDepthSgis,
		// Token: 0x04009D69 RID: 40297
		Texture4DSgis,
		// Token: 0x04009D6A RID: 40298
		Max4DTextureSizeSgis = 33080,
		// Token: 0x04009D6B RID: 40299
		PixelTexGenSgix,
		// Token: 0x04009D6C RID: 40300
		PixelTileBestAlignmentSgix = 33086,
		// Token: 0x04009D6D RID: 40301
		PixelTileCacheIncrementSgix,
		// Token: 0x04009D6E RID: 40302
		PixelTileWidthSgix,
		// Token: 0x04009D6F RID: 40303
		PixelTileHeightSgix,
		// Token: 0x04009D70 RID: 40304
		PixelTileGridWidthSgix,
		// Token: 0x04009D71 RID: 40305
		PixelTileGridHeightSgix,
		// Token: 0x04009D72 RID: 40306
		PixelTileGridDepthSgix,
		// Token: 0x04009D73 RID: 40307
		PixelTileCacheSizeSgix,
		// Token: 0x04009D74 RID: 40308
		SpriteSgix = 33096,
		// Token: 0x04009D75 RID: 40309
		SpriteModeSgix,
		// Token: 0x04009D76 RID: 40310
		SpriteAxisSgix,
		// Token: 0x04009D77 RID: 40311
		SpriteTranslationSgix,
		// Token: 0x04009D78 RID: 40312
		Texture4DBindingSgis = 33103,
		// Token: 0x04009D79 RID: 40313
		MaxClipmapDepthSgix = 33143,
		// Token: 0x04009D7A RID: 40314
		MaxClipmapVirtualDepthSgix,
		// Token: 0x04009D7B RID: 40315
		PostTextureFilterBiasRangeSgix = 33147,
		// Token: 0x04009D7C RID: 40316
		PostTextureFilterScaleRangeSgix,
		// Token: 0x04009D7D RID: 40317
		ReferencePlaneSgix,
		// Token: 0x04009D7E RID: 40318
		ReferencePlaneEquationSgix,
		// Token: 0x04009D7F RID: 40319
		IrInstrument1Sgix,
		// Token: 0x04009D80 RID: 40320
		InstrumentMeasurementsSgix = 33153,
		// Token: 0x04009D81 RID: 40321
		CalligraphicFragmentSgix = 33155,
		// Token: 0x04009D82 RID: 40322
		FramezoomSgix = 33163,
		// Token: 0x04009D83 RID: 40323
		FramezoomFactorSgix,
		// Token: 0x04009D84 RID: 40324
		MaxFramezoomFactorSgix,
		// Token: 0x04009D85 RID: 40325
		GenerateMipmapHintSgis = 33170,
		// Token: 0x04009D86 RID: 40326
		GenerateMipmapHint = 33170,
		// Token: 0x04009D87 RID: 40327
		DeformationsMaskSgix = 33174,
		// Token: 0x04009D88 RID: 40328
		FogOffsetSgix = 33176,
		// Token: 0x04009D89 RID: 40329
		FogOffsetValueSgix,
		// Token: 0x04009D8A RID: 40330
		LightModelColorControl = 33272,
		// Token: 0x04009D8B RID: 40331
		SharedTexturePaletteExt = 33275,
		// Token: 0x04009D8C RID: 40332
		ConvolutionHintSgix = 33558,
		// Token: 0x04009D8D RID: 40333
		AsyncMarkerSgix = 33577,
		// Token: 0x04009D8E RID: 40334
		PixelTexGenModeSgix = 33579,
		// Token: 0x04009D8F RID: 40335
		AsyncHistogramSgix,
		// Token: 0x04009D90 RID: 40336
		MaxAsyncHistogramSgix,
		// Token: 0x04009D91 RID: 40337
		PixelTextureSgis = 33619,
		// Token: 0x04009D92 RID: 40338
		AsyncTexImageSgix = 33628,
		// Token: 0x04009D93 RID: 40339
		AsyncDrawPixelsSgix,
		// Token: 0x04009D94 RID: 40340
		AsyncReadPixelsSgix,
		// Token: 0x04009D95 RID: 40341
		MaxAsyncTexImageSgix,
		// Token: 0x04009D96 RID: 40342
		MaxAsyncDrawPixelsSgix,
		// Token: 0x04009D97 RID: 40343
		MaxAsyncReadPixelsSgix,
		// Token: 0x04009D98 RID: 40344
		VertexPreclipSgix = 33774,
		// Token: 0x04009D99 RID: 40345
		VertexPreclipHintSgix,
		// Token: 0x04009D9A RID: 40346
		FragmentLightingSgix = 33792,
		// Token: 0x04009D9B RID: 40347
		FragmentColorMaterialSgix,
		// Token: 0x04009D9C RID: 40348
		FragmentColorMaterialFaceSgix,
		// Token: 0x04009D9D RID: 40349
		FragmentColorMaterialParameterSgix,
		// Token: 0x04009D9E RID: 40350
		MaxFragmentLightsSgix,
		// Token: 0x04009D9F RID: 40351
		MaxActiveLightsSgix,
		// Token: 0x04009DA0 RID: 40352
		LightEnvModeSgix = 33799,
		// Token: 0x04009DA1 RID: 40353
		FragmentLightModelLocalViewerSgix,
		// Token: 0x04009DA2 RID: 40354
		FragmentLightModelTwoSideSgix,
		// Token: 0x04009DA3 RID: 40355
		FragmentLightModelAmbientSgix,
		// Token: 0x04009DA4 RID: 40356
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x04009DA5 RID: 40357
		FragmentLight0Sgix,
		// Token: 0x04009DA6 RID: 40358
		PackResampleSgix = 33836,
		// Token: 0x04009DA7 RID: 40359
		UnpackResampleSgix,
		// Token: 0x04009DA8 RID: 40360
		AliasedPointSizeRange = 33901,
		// Token: 0x04009DA9 RID: 40361
		AliasedLineWidthRange,
		// Token: 0x04009DAA RID: 40362
		ActiveTexture = 34016,
		// Token: 0x04009DAB RID: 40363
		MaxRenderbufferSize = 34024,
		// Token: 0x04009DAC RID: 40364
		TextureBindingCubeMap = 34068,
		// Token: 0x04009DAD RID: 40365
		MaxCubeMapTextureSize = 34076,
		// Token: 0x04009DAE RID: 40366
		PackSubsampleRateSgix = 34208,
		// Token: 0x04009DAF RID: 40367
		UnpackSubsampleRateSgix,
		// Token: 0x04009DB0 RID: 40368
		NumCompressedTextureFormats = 34466,
		// Token: 0x04009DB1 RID: 40369
		CompressedTextureFormats,
		// Token: 0x04009DB2 RID: 40370
		StencilBackFunc = 34816,
		// Token: 0x04009DB3 RID: 40371
		StencilBackFail,
		// Token: 0x04009DB4 RID: 40372
		StencilBackPassDepthFail,
		// Token: 0x04009DB5 RID: 40373
		StencilBackPassDepthPass,
		// Token: 0x04009DB6 RID: 40374
		BlendEquationAlpha = 34877,
		// Token: 0x04009DB7 RID: 40375
		MaxVertexAttribs = 34921,
		// Token: 0x04009DB8 RID: 40376
		MaxTextureImageUnits = 34930,
		// Token: 0x04009DB9 RID: 40377
		ArrayBufferBinding = 34964,
		// Token: 0x04009DBA RID: 40378
		ElementArrayBufferBinding,
		// Token: 0x04009DBB RID: 40379
		MaxVertexTextureImageUnits = 35660,
		// Token: 0x04009DBC RID: 40380
		MaxCombinedTextureImageUnits,
		// Token: 0x04009DBD RID: 40381
		CurrentProgram = 35725,
		// Token: 0x04009DBE RID: 40382
		ImplementationColorReadType = 35738,
		// Token: 0x04009DBF RID: 40383
		ImplementationColorReadFormat,
		// Token: 0x04009DC0 RID: 40384
		StencilBackRef = 36003,
		// Token: 0x04009DC1 RID: 40385
		StencilBackValueMask,
		// Token: 0x04009DC2 RID: 40386
		StencilBackWritemask,
		// Token: 0x04009DC3 RID: 40387
		FramebufferBinding,
		// Token: 0x04009DC4 RID: 40388
		RenderbufferBinding,
		// Token: 0x04009DC5 RID: 40389
		ShaderBinaryFormats = 36344,
		// Token: 0x04009DC6 RID: 40390
		NumShaderBinaryFormats,
		// Token: 0x04009DC7 RID: 40391
		ShaderCompiler,
		// Token: 0x04009DC8 RID: 40392
		MaxVertexUniformVectors,
		// Token: 0x04009DC9 RID: 40393
		MaxVaryingVectors,
		// Token: 0x04009DCA RID: 40394
		MaxFragmentUniformVectors,
		// Token: 0x04009DCB RID: 40395
		TimestampExt = 36392,
		// Token: 0x04009DCC RID: 40396
		GpuDisjointExt = 36795,
		// Token: 0x04009DCD RID: 40397
		MaxMultiviewBuffersExt = 37106
	}
}
