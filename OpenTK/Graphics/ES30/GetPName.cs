using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x0200080D RID: 2061
	public enum GetPName
	{
		// Token: 0x04008537 RID: 34103
		CurrentColor = 2816,
		// Token: 0x04008538 RID: 34104
		CurrentIndex,
		// Token: 0x04008539 RID: 34105
		CurrentNormal,
		// Token: 0x0400853A RID: 34106
		CurrentTextureCoords,
		// Token: 0x0400853B RID: 34107
		CurrentRasterColor,
		// Token: 0x0400853C RID: 34108
		CurrentRasterIndex,
		// Token: 0x0400853D RID: 34109
		CurrentRasterTextureCoords,
		// Token: 0x0400853E RID: 34110
		CurrentRasterPosition,
		// Token: 0x0400853F RID: 34111
		CurrentRasterPositionValid,
		// Token: 0x04008540 RID: 34112
		CurrentRasterDistance,
		// Token: 0x04008541 RID: 34113
		PointSmooth = 2832,
		// Token: 0x04008542 RID: 34114
		PointSize,
		// Token: 0x04008543 RID: 34115
		PointSizeRange,
		// Token: 0x04008544 RID: 34116
		SmoothPointSizeRange = 2834,
		// Token: 0x04008545 RID: 34117
		PointSizeGranularity,
		// Token: 0x04008546 RID: 34118
		SmoothPointSizeGranularity = 2835,
		// Token: 0x04008547 RID: 34119
		LineSmooth = 2848,
		// Token: 0x04008548 RID: 34120
		LineWidth,
		// Token: 0x04008549 RID: 34121
		LineWidthRange,
		// Token: 0x0400854A RID: 34122
		SmoothLineWidthRange = 2850,
		// Token: 0x0400854B RID: 34123
		LineWidthGranularity,
		// Token: 0x0400854C RID: 34124
		SmoothLineWidthGranularity = 2851,
		// Token: 0x0400854D RID: 34125
		LineStipple,
		// Token: 0x0400854E RID: 34126
		LineStipplePattern,
		// Token: 0x0400854F RID: 34127
		LineStippleRepeat,
		// Token: 0x04008550 RID: 34128
		ListMode = 2864,
		// Token: 0x04008551 RID: 34129
		MaxListNesting,
		// Token: 0x04008552 RID: 34130
		ListBase,
		// Token: 0x04008553 RID: 34131
		ListIndex,
		// Token: 0x04008554 RID: 34132
		PolygonMode = 2880,
		// Token: 0x04008555 RID: 34133
		PolygonSmooth,
		// Token: 0x04008556 RID: 34134
		PolygonStipple,
		// Token: 0x04008557 RID: 34135
		EdgeFlag,
		// Token: 0x04008558 RID: 34136
		CullFace,
		// Token: 0x04008559 RID: 34137
		CullFaceMode,
		// Token: 0x0400855A RID: 34138
		FrontFace,
		// Token: 0x0400855B RID: 34139
		Lighting = 2896,
		// Token: 0x0400855C RID: 34140
		LightModelLocalViewer,
		// Token: 0x0400855D RID: 34141
		LightModelTwoSide,
		// Token: 0x0400855E RID: 34142
		LightModelAmbient,
		// Token: 0x0400855F RID: 34143
		ShadeModel,
		// Token: 0x04008560 RID: 34144
		ColorMaterialFace,
		// Token: 0x04008561 RID: 34145
		ColorMaterialParameter,
		// Token: 0x04008562 RID: 34146
		ColorMaterial,
		// Token: 0x04008563 RID: 34147
		Fog = 2912,
		// Token: 0x04008564 RID: 34148
		FogIndex,
		// Token: 0x04008565 RID: 34149
		FogDensity,
		// Token: 0x04008566 RID: 34150
		FogStart,
		// Token: 0x04008567 RID: 34151
		FogEnd,
		// Token: 0x04008568 RID: 34152
		FogMode,
		// Token: 0x04008569 RID: 34153
		FogColor,
		// Token: 0x0400856A RID: 34154
		DepthRange = 2928,
		// Token: 0x0400856B RID: 34155
		DepthTest,
		// Token: 0x0400856C RID: 34156
		DepthWritemask,
		// Token: 0x0400856D RID: 34157
		DepthClearValue,
		// Token: 0x0400856E RID: 34158
		DepthFunc,
		// Token: 0x0400856F RID: 34159
		AccumClearValue = 2944,
		// Token: 0x04008570 RID: 34160
		StencilTest = 2960,
		// Token: 0x04008571 RID: 34161
		StencilClearValue,
		// Token: 0x04008572 RID: 34162
		StencilFunc,
		// Token: 0x04008573 RID: 34163
		StencilValueMask,
		// Token: 0x04008574 RID: 34164
		StencilFail,
		// Token: 0x04008575 RID: 34165
		StencilPassDepthFail,
		// Token: 0x04008576 RID: 34166
		StencilPassDepthPass,
		// Token: 0x04008577 RID: 34167
		StencilRef,
		// Token: 0x04008578 RID: 34168
		StencilWritemask,
		// Token: 0x04008579 RID: 34169
		MatrixMode = 2976,
		// Token: 0x0400857A RID: 34170
		Normalize,
		// Token: 0x0400857B RID: 34171
		Viewport,
		// Token: 0x0400857C RID: 34172
		Modelview0StackDepthExt,
		// Token: 0x0400857D RID: 34173
		ModelviewStackDepth = 2979,
		// Token: 0x0400857E RID: 34174
		ProjectionStackDepth,
		// Token: 0x0400857F RID: 34175
		TextureStackDepth,
		// Token: 0x04008580 RID: 34176
		Modelview0MatrixExt,
		// Token: 0x04008581 RID: 34177
		ModelviewMatrix = 2982,
		// Token: 0x04008582 RID: 34178
		ProjectionMatrix,
		// Token: 0x04008583 RID: 34179
		TextureMatrix,
		// Token: 0x04008584 RID: 34180
		AttribStackDepth = 2992,
		// Token: 0x04008585 RID: 34181
		ClientAttribStackDepth,
		// Token: 0x04008586 RID: 34182
		AlphaTest = 3008,
		// Token: 0x04008587 RID: 34183
		AlphaTestQcom = 3008,
		// Token: 0x04008588 RID: 34184
		AlphaTestFunc,
		// Token: 0x04008589 RID: 34185
		AlphaTestFuncQcom = 3009,
		// Token: 0x0400858A RID: 34186
		AlphaTestRef,
		// Token: 0x0400858B RID: 34187
		AlphaTestRefQcom = 3010,
		// Token: 0x0400858C RID: 34188
		Dither = 3024,
		// Token: 0x0400858D RID: 34189
		BlendDst = 3040,
		// Token: 0x0400858E RID: 34190
		BlendSrc,
		// Token: 0x0400858F RID: 34191
		Blend,
		// Token: 0x04008590 RID: 34192
		LogicOpMode = 3056,
		// Token: 0x04008591 RID: 34193
		IndexLogicOp,
		// Token: 0x04008592 RID: 34194
		LogicOp = 3057,
		// Token: 0x04008593 RID: 34195
		ColorLogicOp,
		// Token: 0x04008594 RID: 34196
		AuxBuffers = 3072,
		// Token: 0x04008595 RID: 34197
		DrawBuffer,
		// Token: 0x04008596 RID: 34198
		DrawBufferExt = 3073,
		// Token: 0x04008597 RID: 34199
		ReadBuffer,
		// Token: 0x04008598 RID: 34200
		ReadBufferExt = 3074,
		// Token: 0x04008599 RID: 34201
		ReadBufferNv = 3074,
		// Token: 0x0400859A RID: 34202
		ScissorBox = 3088,
		// Token: 0x0400859B RID: 34203
		ScissorTest,
		// Token: 0x0400859C RID: 34204
		IndexClearValue = 3104,
		// Token: 0x0400859D RID: 34205
		IndexWritemask,
		// Token: 0x0400859E RID: 34206
		ColorClearValue,
		// Token: 0x0400859F RID: 34207
		ColorWritemask,
		// Token: 0x040085A0 RID: 34208
		IndexMode = 3120,
		// Token: 0x040085A1 RID: 34209
		RgbaMode,
		// Token: 0x040085A2 RID: 34210
		Doublebuffer,
		// Token: 0x040085A3 RID: 34211
		Stereo,
		// Token: 0x040085A4 RID: 34212
		RenderMode = 3136,
		// Token: 0x040085A5 RID: 34213
		PerspectiveCorrectionHint = 3152,
		// Token: 0x040085A6 RID: 34214
		PointSmoothHint,
		// Token: 0x040085A7 RID: 34215
		LineSmoothHint,
		// Token: 0x040085A8 RID: 34216
		PolygonSmoothHint,
		// Token: 0x040085A9 RID: 34217
		FogHint,
		// Token: 0x040085AA RID: 34218
		TextureGenS = 3168,
		// Token: 0x040085AB RID: 34219
		TextureGenT,
		// Token: 0x040085AC RID: 34220
		TextureGenR,
		// Token: 0x040085AD RID: 34221
		TextureGenQ,
		// Token: 0x040085AE RID: 34222
		PixelMapIToISize = 3248,
		// Token: 0x040085AF RID: 34223
		PixelMapSToSSize,
		// Token: 0x040085B0 RID: 34224
		PixelMapIToRSize,
		// Token: 0x040085B1 RID: 34225
		PixelMapIToGSize,
		// Token: 0x040085B2 RID: 34226
		PixelMapIToBSize,
		// Token: 0x040085B3 RID: 34227
		PixelMapIToASize,
		// Token: 0x040085B4 RID: 34228
		PixelMapRToRSize,
		// Token: 0x040085B5 RID: 34229
		PixelMapGToGSize,
		// Token: 0x040085B6 RID: 34230
		PixelMapBToBSize,
		// Token: 0x040085B7 RID: 34231
		PixelMapAToASize,
		// Token: 0x040085B8 RID: 34232
		UnpackSwapBytes = 3312,
		// Token: 0x040085B9 RID: 34233
		UnpackLsbFirst,
		// Token: 0x040085BA RID: 34234
		UnpackRowLength,
		// Token: 0x040085BB RID: 34235
		UnpackSkipRows,
		// Token: 0x040085BC RID: 34236
		UnpackSkipPixels,
		// Token: 0x040085BD RID: 34237
		UnpackAlignment,
		// Token: 0x040085BE RID: 34238
		PackSwapBytes = 3328,
		// Token: 0x040085BF RID: 34239
		PackLsbFirst,
		// Token: 0x040085C0 RID: 34240
		PackRowLength,
		// Token: 0x040085C1 RID: 34241
		PackSkipRows,
		// Token: 0x040085C2 RID: 34242
		PackSkipPixels,
		// Token: 0x040085C3 RID: 34243
		PackAlignment,
		// Token: 0x040085C4 RID: 34244
		MapColor = 3344,
		// Token: 0x040085C5 RID: 34245
		MapStencil,
		// Token: 0x040085C6 RID: 34246
		IndexShift,
		// Token: 0x040085C7 RID: 34247
		IndexOffset,
		// Token: 0x040085C8 RID: 34248
		RedScale,
		// Token: 0x040085C9 RID: 34249
		RedBias,
		// Token: 0x040085CA RID: 34250
		ZoomX,
		// Token: 0x040085CB RID: 34251
		ZoomY,
		// Token: 0x040085CC RID: 34252
		GreenScale,
		// Token: 0x040085CD RID: 34253
		GreenBias,
		// Token: 0x040085CE RID: 34254
		BlueScale,
		// Token: 0x040085CF RID: 34255
		BlueBias,
		// Token: 0x040085D0 RID: 34256
		AlphaScale,
		// Token: 0x040085D1 RID: 34257
		AlphaBias,
		// Token: 0x040085D2 RID: 34258
		DepthScale,
		// Token: 0x040085D3 RID: 34259
		DepthBias,
		// Token: 0x040085D4 RID: 34260
		MaxEvalOrder = 3376,
		// Token: 0x040085D5 RID: 34261
		MaxLights,
		// Token: 0x040085D6 RID: 34262
		MaxClipDistances,
		// Token: 0x040085D7 RID: 34263
		MaxClipPlanes = 3378,
		// Token: 0x040085D8 RID: 34264
		MaxTextureSize,
		// Token: 0x040085D9 RID: 34265
		MaxPixelMapTable,
		// Token: 0x040085DA RID: 34266
		MaxAttribStackDepth,
		// Token: 0x040085DB RID: 34267
		MaxModelviewStackDepth,
		// Token: 0x040085DC RID: 34268
		MaxNameStackDepth,
		// Token: 0x040085DD RID: 34269
		MaxProjectionStackDepth,
		// Token: 0x040085DE RID: 34270
		MaxTextureStackDepth,
		// Token: 0x040085DF RID: 34271
		MaxViewportDims,
		// Token: 0x040085E0 RID: 34272
		MaxClientAttribStackDepth,
		// Token: 0x040085E1 RID: 34273
		SubpixelBits = 3408,
		// Token: 0x040085E2 RID: 34274
		IndexBits,
		// Token: 0x040085E3 RID: 34275
		RedBits,
		// Token: 0x040085E4 RID: 34276
		GreenBits,
		// Token: 0x040085E5 RID: 34277
		BlueBits,
		// Token: 0x040085E6 RID: 34278
		AlphaBits,
		// Token: 0x040085E7 RID: 34279
		DepthBits,
		// Token: 0x040085E8 RID: 34280
		StencilBits,
		// Token: 0x040085E9 RID: 34281
		AccumRedBits,
		// Token: 0x040085EA RID: 34282
		AccumGreenBits,
		// Token: 0x040085EB RID: 34283
		AccumBlueBits,
		// Token: 0x040085EC RID: 34284
		AccumAlphaBits,
		// Token: 0x040085ED RID: 34285
		NameStackDepth = 3440,
		// Token: 0x040085EE RID: 34286
		AutoNormal = 3456,
		// Token: 0x040085EF RID: 34287
		Map1Color4 = 3472,
		// Token: 0x040085F0 RID: 34288
		Map1Index,
		// Token: 0x040085F1 RID: 34289
		Map1Normal,
		// Token: 0x040085F2 RID: 34290
		Map1TextureCoord1,
		// Token: 0x040085F3 RID: 34291
		Map1TextureCoord2,
		// Token: 0x040085F4 RID: 34292
		Map1TextureCoord3,
		// Token: 0x040085F5 RID: 34293
		Map1TextureCoord4,
		// Token: 0x040085F6 RID: 34294
		Map1Vertex3,
		// Token: 0x040085F7 RID: 34295
		Map1Vertex4,
		// Token: 0x040085F8 RID: 34296
		Map2Color4 = 3504,
		// Token: 0x040085F9 RID: 34297
		Map2Index,
		// Token: 0x040085FA RID: 34298
		Map2Normal,
		// Token: 0x040085FB RID: 34299
		Map2TextureCoord1,
		// Token: 0x040085FC RID: 34300
		Map2TextureCoord2,
		// Token: 0x040085FD RID: 34301
		Map2TextureCoord3,
		// Token: 0x040085FE RID: 34302
		Map2TextureCoord4,
		// Token: 0x040085FF RID: 34303
		Map2Vertex3,
		// Token: 0x04008600 RID: 34304
		Map2Vertex4,
		// Token: 0x04008601 RID: 34305
		Map1GridDomain = 3536,
		// Token: 0x04008602 RID: 34306
		Map1GridSegments,
		// Token: 0x04008603 RID: 34307
		Map2GridDomain,
		// Token: 0x04008604 RID: 34308
		Map2GridSegments,
		// Token: 0x04008605 RID: 34309
		Texture1D = 3552,
		// Token: 0x04008606 RID: 34310
		Texture2D,
		// Token: 0x04008607 RID: 34311
		FeedbackBufferSize = 3569,
		// Token: 0x04008608 RID: 34312
		FeedbackBufferType,
		// Token: 0x04008609 RID: 34313
		SelectionBufferSize = 3572,
		// Token: 0x0400860A RID: 34314
		PolygonOffsetUnits = 10752,
		// Token: 0x0400860B RID: 34315
		PolygonOffsetPoint,
		// Token: 0x0400860C RID: 34316
		PolygonOffsetLine,
		// Token: 0x0400860D RID: 34317
		ClipPlane0 = 12288,
		// Token: 0x0400860E RID: 34318
		ClipPlane1,
		// Token: 0x0400860F RID: 34319
		ClipPlane2,
		// Token: 0x04008610 RID: 34320
		ClipPlane3,
		// Token: 0x04008611 RID: 34321
		ClipPlane4,
		// Token: 0x04008612 RID: 34322
		ClipPlane5,
		// Token: 0x04008613 RID: 34323
		Light0 = 16384,
		// Token: 0x04008614 RID: 34324
		Light1,
		// Token: 0x04008615 RID: 34325
		Light2,
		// Token: 0x04008616 RID: 34326
		Light3,
		// Token: 0x04008617 RID: 34327
		Light4,
		// Token: 0x04008618 RID: 34328
		Light5,
		// Token: 0x04008619 RID: 34329
		Light6,
		// Token: 0x0400861A RID: 34330
		Light7,
		// Token: 0x0400861B RID: 34331
		BlendColor = 32773,
		// Token: 0x0400861C RID: 34332
		BlendColorExt = 32773,
		// Token: 0x0400861D RID: 34333
		BlendEquationExt = 32777,
		// Token: 0x0400861E RID: 34334
		BlendEquationRgb = 32777,
		// Token: 0x0400861F RID: 34335
		BlendEquation = 32777,
		// Token: 0x04008620 RID: 34336
		PackCmykHintExt = 32782,
		// Token: 0x04008621 RID: 34337
		UnpackCmykHintExt,
		// Token: 0x04008622 RID: 34338
		Convolution1DExt,
		// Token: 0x04008623 RID: 34339
		Convolution2DExt,
		// Token: 0x04008624 RID: 34340
		Separable2DExt,
		// Token: 0x04008625 RID: 34341
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x04008626 RID: 34342
		PostConvolutionGreenScaleExt,
		// Token: 0x04008627 RID: 34343
		PostConvolutionBlueScaleExt,
		// Token: 0x04008628 RID: 34344
		PostConvolutionAlphaScaleExt,
		// Token: 0x04008629 RID: 34345
		PostConvolutionRedBiasExt,
		// Token: 0x0400862A RID: 34346
		PostConvolutionGreenBiasExt,
		// Token: 0x0400862B RID: 34347
		PostConvolutionBlueBiasExt,
		// Token: 0x0400862C RID: 34348
		PostConvolutionAlphaBiasExt,
		// Token: 0x0400862D RID: 34349
		HistogramExt,
		// Token: 0x0400862E RID: 34350
		MinmaxExt = 32814,
		// Token: 0x0400862F RID: 34351
		PolygonOffsetFill = 32823,
		// Token: 0x04008630 RID: 34352
		PolygonOffsetFactor,
		// Token: 0x04008631 RID: 34353
		PolygonOffsetBiasExt,
		// Token: 0x04008632 RID: 34354
		RescaleNormalExt,
		// Token: 0x04008633 RID: 34355
		TextureBinding1D = 32872,
		// Token: 0x04008634 RID: 34356
		TextureBinding2D,
		// Token: 0x04008635 RID: 34357
		Texture3DBindingExt,
		// Token: 0x04008636 RID: 34358
		TextureBinding3D = 32874,
		// Token: 0x04008637 RID: 34359
		TextureBinding3DOes = 32874,
		// Token: 0x04008638 RID: 34360
		PackSkipImagesExt,
		// Token: 0x04008639 RID: 34361
		PackImageHeightExt,
		// Token: 0x0400863A RID: 34362
		UnpackSkipImages,
		// Token: 0x0400863B RID: 34363
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400863C RID: 34364
		UnpackImageHeight,
		// Token: 0x0400863D RID: 34365
		UnpackImageHeightExt = 32878,
		// Token: 0x0400863E RID: 34366
		Texture3DExt,
		// Token: 0x0400863F RID: 34367
		Max3DTextureSize = 32883,
		// Token: 0x04008640 RID: 34368
		Max3DTextureSizeExt = 32883,
		// Token: 0x04008641 RID: 34369
		Max3DTextureSizeOes = 32883,
		// Token: 0x04008642 RID: 34370
		VertexArray,
		// Token: 0x04008643 RID: 34371
		NormalArray,
		// Token: 0x04008644 RID: 34372
		ColorArray,
		// Token: 0x04008645 RID: 34373
		IndexArray,
		// Token: 0x04008646 RID: 34374
		TextureCoordArray,
		// Token: 0x04008647 RID: 34375
		EdgeFlagArray,
		// Token: 0x04008648 RID: 34376
		VertexArraySize,
		// Token: 0x04008649 RID: 34377
		VertexArrayType,
		// Token: 0x0400864A RID: 34378
		VertexArrayStride,
		// Token: 0x0400864B RID: 34379
		VertexArrayCountExt,
		// Token: 0x0400864C RID: 34380
		NormalArrayType,
		// Token: 0x0400864D RID: 34381
		NormalArrayStride,
		// Token: 0x0400864E RID: 34382
		NormalArrayCountExt,
		// Token: 0x0400864F RID: 34383
		ColorArraySize,
		// Token: 0x04008650 RID: 34384
		ColorArrayType,
		// Token: 0x04008651 RID: 34385
		ColorArrayStride,
		// Token: 0x04008652 RID: 34386
		ColorArrayCountExt,
		// Token: 0x04008653 RID: 34387
		IndexArrayType,
		// Token: 0x04008654 RID: 34388
		IndexArrayStride,
		// Token: 0x04008655 RID: 34389
		IndexArrayCountExt,
		// Token: 0x04008656 RID: 34390
		TextureCoordArraySize,
		// Token: 0x04008657 RID: 34391
		TextureCoordArrayType,
		// Token: 0x04008658 RID: 34392
		TextureCoordArrayStride,
		// Token: 0x04008659 RID: 34393
		TextureCoordArrayCountExt,
		// Token: 0x0400865A RID: 34394
		EdgeFlagArrayStride,
		// Token: 0x0400865B RID: 34395
		EdgeFlagArrayCountExt,
		// Token: 0x0400865C RID: 34396
		InterlaceSgix = 32916,
		// Token: 0x0400865D RID: 34397
		DetailTexture2DBindingSgis = 32918,
		// Token: 0x0400865E RID: 34398
		MultisampleSgis = 32925,
		// Token: 0x0400865F RID: 34399
		SampleAlphaToCoverage,
		// Token: 0x04008660 RID: 34400
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x04008661 RID: 34401
		SampleAlphaToOneSgis,
		// Token: 0x04008662 RID: 34402
		SampleCoverage,
		// Token: 0x04008663 RID: 34403
		SampleMaskSgis = 32928,
		// Token: 0x04008664 RID: 34404
		SampleBuffers = 32936,
		// Token: 0x04008665 RID: 34405
		SampleBuffersSgis = 32936,
		// Token: 0x04008666 RID: 34406
		SamplesSgis,
		// Token: 0x04008667 RID: 34407
		Samples = 32937,
		// Token: 0x04008668 RID: 34408
		SampleCoverageValue,
		// Token: 0x04008669 RID: 34409
		SampleMaskValueSgis = 32938,
		// Token: 0x0400866A RID: 34410
		SampleCoverageInvert,
		// Token: 0x0400866B RID: 34411
		SampleMaskInvertSgis = 32939,
		// Token: 0x0400866C RID: 34412
		SamplePatternSgis,
		// Token: 0x0400866D RID: 34413
		ColorMatrixSgi = 32945,
		// Token: 0x0400866E RID: 34414
		ColorMatrixStackDepthSgi,
		// Token: 0x0400866F RID: 34415
		MaxColorMatrixStackDepthSgi,
		// Token: 0x04008670 RID: 34416
		PostColorMatrixRedScaleSgi,
		// Token: 0x04008671 RID: 34417
		PostColorMatrixGreenScaleSgi,
		// Token: 0x04008672 RID: 34418
		PostColorMatrixBlueScaleSgi,
		// Token: 0x04008673 RID: 34419
		PostColorMatrixAlphaScaleSgi,
		// Token: 0x04008674 RID: 34420
		PostColorMatrixRedBiasSgi,
		// Token: 0x04008675 RID: 34421
		PostColorMatrixGreenBiasSgi,
		// Token: 0x04008676 RID: 34422
		PostColorMatrixBlueBiasSgi,
		// Token: 0x04008677 RID: 34423
		PostColorMatrixAlphaBiasSgi,
		// Token: 0x04008678 RID: 34424
		TextureColorTableSgi,
		// Token: 0x04008679 RID: 34425
		BlendDstRgb = 32968,
		// Token: 0x0400867A RID: 34426
		BlendSrcRgb,
		// Token: 0x0400867B RID: 34427
		BlendDstAlpha,
		// Token: 0x0400867C RID: 34428
		BlendSrcAlpha,
		// Token: 0x0400867D RID: 34429
		ColorTableSgi = 32976,
		// Token: 0x0400867E RID: 34430
		PostConvolutionColorTableSgi,
		// Token: 0x0400867F RID: 34431
		PostColorMatrixColorTableSgi,
		// Token: 0x04008680 RID: 34432
		MaxElementsVertices = 33000,
		// Token: 0x04008681 RID: 34433
		MaxElementsIndices,
		// Token: 0x04008682 RID: 34434
		PointSizeMinSgis = 33062,
		// Token: 0x04008683 RID: 34435
		PointSizeMaxSgis,
		// Token: 0x04008684 RID: 34436
		PointFadeThresholdSizeSgis,
		// Token: 0x04008685 RID: 34437
		DistanceAttenuationSgis,
		// Token: 0x04008686 RID: 34438
		FogFuncPointsSgis = 33067,
		// Token: 0x04008687 RID: 34439
		MaxFogFuncPointsSgis,
		// Token: 0x04008688 RID: 34440
		PackSkipVolumesSgis = 33072,
		// Token: 0x04008689 RID: 34441
		PackImageDepthSgis,
		// Token: 0x0400868A RID: 34442
		UnpackSkipVolumesSgis,
		// Token: 0x0400868B RID: 34443
		UnpackImageDepthSgis,
		// Token: 0x0400868C RID: 34444
		Texture4DSgis,
		// Token: 0x0400868D RID: 34445
		Max4DTextureSizeSgis = 33080,
		// Token: 0x0400868E RID: 34446
		PixelTexGenSgix,
		// Token: 0x0400868F RID: 34447
		PixelTileBestAlignmentSgix = 33086,
		// Token: 0x04008690 RID: 34448
		PixelTileCacheIncrementSgix,
		// Token: 0x04008691 RID: 34449
		PixelTileWidthSgix,
		// Token: 0x04008692 RID: 34450
		PixelTileHeightSgix,
		// Token: 0x04008693 RID: 34451
		PixelTileGridWidthSgix,
		// Token: 0x04008694 RID: 34452
		PixelTileGridHeightSgix,
		// Token: 0x04008695 RID: 34453
		PixelTileGridDepthSgix,
		// Token: 0x04008696 RID: 34454
		PixelTileCacheSizeSgix,
		// Token: 0x04008697 RID: 34455
		SpriteSgix = 33096,
		// Token: 0x04008698 RID: 34456
		SpriteModeSgix,
		// Token: 0x04008699 RID: 34457
		SpriteAxisSgix,
		// Token: 0x0400869A RID: 34458
		SpriteTranslationSgix,
		// Token: 0x0400869B RID: 34459
		Texture4DBindingSgis = 33103,
		// Token: 0x0400869C RID: 34460
		MaxClipmapDepthSgix = 33143,
		// Token: 0x0400869D RID: 34461
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400869E RID: 34462
		PostTextureFilterBiasRangeSgix = 33147,
		// Token: 0x0400869F RID: 34463
		PostTextureFilterScaleRangeSgix,
		// Token: 0x040086A0 RID: 34464
		ReferencePlaneSgix,
		// Token: 0x040086A1 RID: 34465
		ReferencePlaneEquationSgix,
		// Token: 0x040086A2 RID: 34466
		IrInstrument1Sgix,
		// Token: 0x040086A3 RID: 34467
		InstrumentMeasurementsSgix = 33153,
		// Token: 0x040086A4 RID: 34468
		CalligraphicFragmentSgix = 33155,
		// Token: 0x040086A5 RID: 34469
		FramezoomSgix = 33163,
		// Token: 0x040086A6 RID: 34470
		FramezoomFactorSgix,
		// Token: 0x040086A7 RID: 34471
		MaxFramezoomFactorSgix,
		// Token: 0x040086A8 RID: 34472
		GenerateMipmapHint = 33170,
		// Token: 0x040086A9 RID: 34473
		GenerateMipmapHintSgis = 33170,
		// Token: 0x040086AA RID: 34474
		DeformationsMaskSgix = 33174,
		// Token: 0x040086AB RID: 34475
		FogOffsetSgix = 33176,
		// Token: 0x040086AC RID: 34476
		FogOffsetValueSgix,
		// Token: 0x040086AD RID: 34477
		LightModelColorControl = 33272,
		// Token: 0x040086AE RID: 34478
		SharedTexturePaletteExt = 33275,
		// Token: 0x040086AF RID: 34479
		MajorVersion = 33307,
		// Token: 0x040086B0 RID: 34480
		MinorVersion,
		// Token: 0x040086B1 RID: 34481
		NumExtensions,
		// Token: 0x040086B2 RID: 34482
		ConvolutionHintSgix = 33558,
		// Token: 0x040086B3 RID: 34483
		AsyncMarkerSgix = 33577,
		// Token: 0x040086B4 RID: 34484
		PixelTexGenModeSgix = 33579,
		// Token: 0x040086B5 RID: 34485
		AsyncHistogramSgix,
		// Token: 0x040086B6 RID: 34486
		MaxAsyncHistogramSgix,
		// Token: 0x040086B7 RID: 34487
		PixelTextureSgis = 33619,
		// Token: 0x040086B8 RID: 34488
		AsyncTexImageSgix = 33628,
		// Token: 0x040086B9 RID: 34489
		AsyncDrawPixelsSgix,
		// Token: 0x040086BA RID: 34490
		AsyncReadPixelsSgix,
		// Token: 0x040086BB RID: 34491
		MaxAsyncTexImageSgix,
		// Token: 0x040086BC RID: 34492
		MaxAsyncDrawPixelsSgix,
		// Token: 0x040086BD RID: 34493
		MaxAsyncReadPixelsSgix,
		// Token: 0x040086BE RID: 34494
		VertexPreclipSgix = 33774,
		// Token: 0x040086BF RID: 34495
		VertexPreclipHintSgix,
		// Token: 0x040086C0 RID: 34496
		FragmentLightingSgix = 33792,
		// Token: 0x040086C1 RID: 34497
		FragmentColorMaterialSgix,
		// Token: 0x040086C2 RID: 34498
		FragmentColorMaterialFaceSgix,
		// Token: 0x040086C3 RID: 34499
		FragmentColorMaterialParameterSgix,
		// Token: 0x040086C4 RID: 34500
		MaxFragmentLightsSgix,
		// Token: 0x040086C5 RID: 34501
		MaxActiveLightsSgix,
		// Token: 0x040086C6 RID: 34502
		LightEnvModeSgix = 33799,
		// Token: 0x040086C7 RID: 34503
		FragmentLightModelLocalViewerSgix,
		// Token: 0x040086C8 RID: 34504
		FragmentLightModelTwoSideSgix,
		// Token: 0x040086C9 RID: 34505
		FragmentLightModelAmbientSgix,
		// Token: 0x040086CA RID: 34506
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x040086CB RID: 34507
		FragmentLight0Sgix,
		// Token: 0x040086CC RID: 34508
		PackResampleSgix = 33836,
		// Token: 0x040086CD RID: 34509
		UnpackResampleSgix,
		// Token: 0x040086CE RID: 34510
		AliasedPointSizeRange = 33901,
		// Token: 0x040086CF RID: 34511
		AliasedLineWidthRange,
		// Token: 0x040086D0 RID: 34512
		ActiveTexture = 34016,
		// Token: 0x040086D1 RID: 34513
		MaxRenderbufferSize = 34024,
		// Token: 0x040086D2 RID: 34514
		MaxTextureLodBias = 34045,
		// Token: 0x040086D3 RID: 34515
		TextureBindingCubeMap = 34068,
		// Token: 0x040086D4 RID: 34516
		MaxCubeMapTextureSize = 34076,
		// Token: 0x040086D5 RID: 34517
		PackSubsampleRateSgix = 34208,
		// Token: 0x040086D6 RID: 34518
		UnpackSubsampleRateSgix,
		// Token: 0x040086D7 RID: 34519
		VertexArrayBinding = 34229,
		// Token: 0x040086D8 RID: 34520
		NumCompressedTextureFormats = 34466,
		// Token: 0x040086D9 RID: 34521
		CompressedTextureFormats,
		// Token: 0x040086DA RID: 34522
		NumProgramBinaryFormats = 34814,
		// Token: 0x040086DB RID: 34523
		ProgramBinaryFormats,
		// Token: 0x040086DC RID: 34524
		StencilBackFunc,
		// Token: 0x040086DD RID: 34525
		StencilBackFail,
		// Token: 0x040086DE RID: 34526
		StencilBackPassDepthFail,
		// Token: 0x040086DF RID: 34527
		StencilBackPassDepthPass,
		// Token: 0x040086E0 RID: 34528
		MaxDrawBuffers = 34852,
		// Token: 0x040086E1 RID: 34529
		DrawBuffer0,
		// Token: 0x040086E2 RID: 34530
		DrawBuffer1,
		// Token: 0x040086E3 RID: 34531
		DrawBuffer2,
		// Token: 0x040086E4 RID: 34532
		DrawBuffer3,
		// Token: 0x040086E5 RID: 34533
		DrawBuffer4,
		// Token: 0x040086E6 RID: 34534
		DrawBuffer5,
		// Token: 0x040086E7 RID: 34535
		DrawBuffer6,
		// Token: 0x040086E8 RID: 34536
		DrawBuffer7,
		// Token: 0x040086E9 RID: 34537
		DrawBuffer8,
		// Token: 0x040086EA RID: 34538
		DrawBuffer9,
		// Token: 0x040086EB RID: 34539
		DrawBuffer10,
		// Token: 0x040086EC RID: 34540
		DrawBuffer11,
		// Token: 0x040086ED RID: 34541
		DrawBuffer12,
		// Token: 0x040086EE RID: 34542
		DrawBuffer13,
		// Token: 0x040086EF RID: 34543
		DrawBuffer14,
		// Token: 0x040086F0 RID: 34544
		DrawBuffer15,
		// Token: 0x040086F1 RID: 34545
		BlendEquationAlpha = 34877,
		// Token: 0x040086F2 RID: 34546
		MaxVertexAttribs = 34921,
		// Token: 0x040086F3 RID: 34547
		MaxTextureImageUnits = 34930,
		// Token: 0x040086F4 RID: 34548
		ArrayBufferBinding = 34964,
		// Token: 0x040086F5 RID: 34549
		ElementArrayBufferBinding,
		// Token: 0x040086F6 RID: 34550
		PixelPackBufferBinding = 35053,
		// Token: 0x040086F7 RID: 34551
		PixelUnpackBufferBinding = 35055,
		// Token: 0x040086F8 RID: 34552
		MaxArrayTextureLayers = 35071,
		// Token: 0x040086F9 RID: 34553
		MinProgramTexelOffset = 35076,
		// Token: 0x040086FA RID: 34554
		MaxProgramTexelOffset,
		// Token: 0x040086FB RID: 34555
		UniformBufferBinding = 35368,
		// Token: 0x040086FC RID: 34556
		MaxVertexUniformBlocks = 35371,
		// Token: 0x040086FD RID: 34557
		MaxFragmentUniformBlocks = 35373,
		// Token: 0x040086FE RID: 34558
		MaxCombinedUniformBlocks,
		// Token: 0x040086FF RID: 34559
		MaxUniformBufferBindings,
		// Token: 0x04008700 RID: 34560
		MaxUniformBlockSize,
		// Token: 0x04008701 RID: 34561
		MaxCombinedVertexUniformComponents,
		// Token: 0x04008702 RID: 34562
		MaxCombinedFragmentUniformComponents = 35379,
		// Token: 0x04008703 RID: 34563
		UniformBufferOffsetAlignment,
		// Token: 0x04008704 RID: 34564
		MaxFragmentUniformComponents = 35657,
		// Token: 0x04008705 RID: 34565
		MaxVertexUniformComponents,
		// Token: 0x04008706 RID: 34566
		MaxVaryingComponents,
		// Token: 0x04008707 RID: 34567
		MaxVertexTextureImageUnits,
		// Token: 0x04008708 RID: 34568
		MaxCombinedTextureImageUnits,
		// Token: 0x04008709 RID: 34569
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x0400870A RID: 34570
		CurrentProgram = 35725,
		// Token: 0x0400870B RID: 34571
		ImplementationColorReadType = 35738,
		// Token: 0x0400870C RID: 34572
		ImplementationColorReadFormat,
		// Token: 0x0400870D RID: 34573
		TextureBinding2DArray = 35869,
		// Token: 0x0400870E RID: 34574
		MaxTransformFeedbackSeparateComponents = 35968,
		// Token: 0x0400870F RID: 34575
		RasterizerDiscard = 35977,
		// Token: 0x04008710 RID: 34576
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x04008711 RID: 34577
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x04008712 RID: 34578
		TransformFeedbackBufferBinding = 35983,
		// Token: 0x04008713 RID: 34579
		StencilBackRef = 36003,
		// Token: 0x04008714 RID: 34580
		StencilBackValueMask,
		// Token: 0x04008715 RID: 34581
		StencilBackWritemask,
		// Token: 0x04008716 RID: 34582
		DrawFramebufferBinding,
		// Token: 0x04008717 RID: 34583
		FramebufferBinding = 36006,
		// Token: 0x04008718 RID: 34584
		RenderbufferBinding,
		// Token: 0x04008719 RID: 34585
		ReadFramebufferBinding = 36010,
		// Token: 0x0400871A RID: 34586
		MaxColorAttachments = 36063,
		// Token: 0x0400871B RID: 34587
		MaxSamples = 36183,
		// Token: 0x0400871C RID: 34588
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x0400871D RID: 34589
		MaxElementIndex = 36203,
		// Token: 0x0400871E RID: 34590
		ShaderBinaryFormats = 36344,
		// Token: 0x0400871F RID: 34591
		NumShaderBinaryFormats,
		// Token: 0x04008720 RID: 34592
		ShaderCompiler,
		// Token: 0x04008721 RID: 34593
		MaxVertexUniformVectors,
		// Token: 0x04008722 RID: 34594
		MaxVaryingVectors,
		// Token: 0x04008723 RID: 34595
		MaxFragmentUniformVectors,
		// Token: 0x04008724 RID: 34596
		TransformFeedbackPaused = 36387,
		// Token: 0x04008725 RID: 34597
		TransformFeedbackActive,
		// Token: 0x04008726 RID: 34598
		TransformFeedbackBinding,
		// Token: 0x04008727 RID: 34599
		TimestampExt = 36392,
		// Token: 0x04008728 RID: 34600
		CopyReadBufferBinding = 36662,
		// Token: 0x04008729 RID: 34601
		CopyWriteBufferBinding,
		// Token: 0x0400872A RID: 34602
		GpuDisjointExt = 36795,
		// Token: 0x0400872B RID: 34603
		MaxMultiviewBuffersExt = 37106,
		// Token: 0x0400872C RID: 34604
		MaxServerWaitTimeout = 37137,
		// Token: 0x0400872D RID: 34605
		MaxVertexOutputComponents = 37154,
		// Token: 0x0400872E RID: 34606
		MaxFragmentInputComponents = 37157
	}
}
