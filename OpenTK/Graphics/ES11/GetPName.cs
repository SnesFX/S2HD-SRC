using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A57 RID: 2647
	public enum GetPName
	{
		// Token: 0x0400AC63 RID: 44131
		CurrentColor = 2816,
		// Token: 0x0400AC64 RID: 44132
		CurrentIndex,
		// Token: 0x0400AC65 RID: 44133
		CurrentNormal,
		// Token: 0x0400AC66 RID: 44134
		CurrentTextureCoords,
		// Token: 0x0400AC67 RID: 44135
		CurrentRasterColor,
		// Token: 0x0400AC68 RID: 44136
		CurrentRasterIndex,
		// Token: 0x0400AC69 RID: 44137
		CurrentRasterTextureCoords,
		// Token: 0x0400AC6A RID: 44138
		CurrentRasterPosition,
		// Token: 0x0400AC6B RID: 44139
		CurrentRasterPositionValid,
		// Token: 0x0400AC6C RID: 44140
		CurrentRasterDistance,
		// Token: 0x0400AC6D RID: 44141
		PointSmooth = 2832,
		// Token: 0x0400AC6E RID: 44142
		PointSize,
		// Token: 0x0400AC6F RID: 44143
		PointSizeRange,
		// Token: 0x0400AC70 RID: 44144
		SmoothPointSizeRange = 2834,
		// Token: 0x0400AC71 RID: 44145
		PointSizeGranularity,
		// Token: 0x0400AC72 RID: 44146
		SmoothPointSizeGranularity = 2835,
		// Token: 0x0400AC73 RID: 44147
		LineSmooth = 2848,
		// Token: 0x0400AC74 RID: 44148
		LineWidth,
		// Token: 0x0400AC75 RID: 44149
		LineWidthRange,
		// Token: 0x0400AC76 RID: 44150
		SmoothLineWidthRange = 2850,
		// Token: 0x0400AC77 RID: 44151
		LineWidthGranularity,
		// Token: 0x0400AC78 RID: 44152
		SmoothLineWidthGranularity = 2851,
		// Token: 0x0400AC79 RID: 44153
		LineStipple,
		// Token: 0x0400AC7A RID: 44154
		LineStipplePattern,
		// Token: 0x0400AC7B RID: 44155
		LineStippleRepeat,
		// Token: 0x0400AC7C RID: 44156
		ListMode = 2864,
		// Token: 0x0400AC7D RID: 44157
		MaxListNesting,
		// Token: 0x0400AC7E RID: 44158
		ListBase,
		// Token: 0x0400AC7F RID: 44159
		ListIndex,
		// Token: 0x0400AC80 RID: 44160
		PolygonMode = 2880,
		// Token: 0x0400AC81 RID: 44161
		PolygonSmooth,
		// Token: 0x0400AC82 RID: 44162
		PolygonStipple,
		// Token: 0x0400AC83 RID: 44163
		EdgeFlag,
		// Token: 0x0400AC84 RID: 44164
		CullFace,
		// Token: 0x0400AC85 RID: 44165
		CullFaceMode,
		// Token: 0x0400AC86 RID: 44166
		FrontFace,
		// Token: 0x0400AC87 RID: 44167
		Lighting = 2896,
		// Token: 0x0400AC88 RID: 44168
		LightModelLocalViewer,
		// Token: 0x0400AC89 RID: 44169
		LightModelTwoSide,
		// Token: 0x0400AC8A RID: 44170
		LightModelAmbient,
		// Token: 0x0400AC8B RID: 44171
		ShadeModel,
		// Token: 0x0400AC8C RID: 44172
		ColorMaterialFace,
		// Token: 0x0400AC8D RID: 44173
		ColorMaterialParameter,
		// Token: 0x0400AC8E RID: 44174
		ColorMaterial,
		// Token: 0x0400AC8F RID: 44175
		Fog = 2912,
		// Token: 0x0400AC90 RID: 44176
		FogIndex,
		// Token: 0x0400AC91 RID: 44177
		FogDensity,
		// Token: 0x0400AC92 RID: 44178
		FogStart,
		// Token: 0x0400AC93 RID: 44179
		FogEnd,
		// Token: 0x0400AC94 RID: 44180
		FogMode,
		// Token: 0x0400AC95 RID: 44181
		FogColor,
		// Token: 0x0400AC96 RID: 44182
		DepthRange = 2928,
		// Token: 0x0400AC97 RID: 44183
		DepthTest,
		// Token: 0x0400AC98 RID: 44184
		DepthWritemask,
		// Token: 0x0400AC99 RID: 44185
		DepthClearValue,
		// Token: 0x0400AC9A RID: 44186
		DepthFunc,
		// Token: 0x0400AC9B RID: 44187
		AccumClearValue = 2944,
		// Token: 0x0400AC9C RID: 44188
		StencilTest = 2960,
		// Token: 0x0400AC9D RID: 44189
		StencilClearValue,
		// Token: 0x0400AC9E RID: 44190
		StencilFunc,
		// Token: 0x0400AC9F RID: 44191
		StencilValueMask,
		// Token: 0x0400ACA0 RID: 44192
		StencilFail,
		// Token: 0x0400ACA1 RID: 44193
		StencilPassDepthFail,
		// Token: 0x0400ACA2 RID: 44194
		StencilPassDepthPass,
		// Token: 0x0400ACA3 RID: 44195
		StencilRef,
		// Token: 0x0400ACA4 RID: 44196
		StencilWritemask,
		// Token: 0x0400ACA5 RID: 44197
		MatrixMode = 2976,
		// Token: 0x0400ACA6 RID: 44198
		Normalize,
		// Token: 0x0400ACA7 RID: 44199
		Viewport,
		// Token: 0x0400ACA8 RID: 44200
		Modelview0StackDepthExt,
		// Token: 0x0400ACA9 RID: 44201
		ModelviewStackDepth = 2979,
		// Token: 0x0400ACAA RID: 44202
		ProjectionStackDepth,
		// Token: 0x0400ACAB RID: 44203
		TextureStackDepth,
		// Token: 0x0400ACAC RID: 44204
		Modelview0MatrixExt,
		// Token: 0x0400ACAD RID: 44205
		ModelviewMatrix = 2982,
		// Token: 0x0400ACAE RID: 44206
		ProjectionMatrix,
		// Token: 0x0400ACAF RID: 44207
		TextureMatrix,
		// Token: 0x0400ACB0 RID: 44208
		AttribStackDepth = 2992,
		// Token: 0x0400ACB1 RID: 44209
		ClientAttribStackDepth,
		// Token: 0x0400ACB2 RID: 44210
		AlphaTest = 3008,
		// Token: 0x0400ACB3 RID: 44211
		AlphaTestQcom = 3008,
		// Token: 0x0400ACB4 RID: 44212
		AlphaTestFunc,
		// Token: 0x0400ACB5 RID: 44213
		AlphaTestFuncQcom = 3009,
		// Token: 0x0400ACB6 RID: 44214
		AlphaTestRef,
		// Token: 0x0400ACB7 RID: 44215
		AlphaTestRefQcom = 3010,
		// Token: 0x0400ACB8 RID: 44216
		Dither = 3024,
		// Token: 0x0400ACB9 RID: 44217
		BlendDst = 3040,
		// Token: 0x0400ACBA RID: 44218
		BlendSrc,
		// Token: 0x0400ACBB RID: 44219
		Blend,
		// Token: 0x0400ACBC RID: 44220
		LogicOpMode = 3056,
		// Token: 0x0400ACBD RID: 44221
		IndexLogicOp,
		// Token: 0x0400ACBE RID: 44222
		LogicOp = 3057,
		// Token: 0x0400ACBF RID: 44223
		ColorLogicOp,
		// Token: 0x0400ACC0 RID: 44224
		AuxBuffers = 3072,
		// Token: 0x0400ACC1 RID: 44225
		DrawBuffer,
		// Token: 0x0400ACC2 RID: 44226
		DrawBufferExt = 3073,
		// Token: 0x0400ACC3 RID: 44227
		ReadBuffer,
		// Token: 0x0400ACC4 RID: 44228
		ReadBufferExt = 3074,
		// Token: 0x0400ACC5 RID: 44229
		ReadBufferNv = 3074,
		// Token: 0x0400ACC6 RID: 44230
		ScissorBox = 3088,
		// Token: 0x0400ACC7 RID: 44231
		ScissorTest,
		// Token: 0x0400ACC8 RID: 44232
		IndexClearValue = 3104,
		// Token: 0x0400ACC9 RID: 44233
		IndexWritemask,
		// Token: 0x0400ACCA RID: 44234
		ColorClearValue,
		// Token: 0x0400ACCB RID: 44235
		ColorWritemask,
		// Token: 0x0400ACCC RID: 44236
		IndexMode = 3120,
		// Token: 0x0400ACCD RID: 44237
		RgbaMode,
		// Token: 0x0400ACCE RID: 44238
		Doublebuffer,
		// Token: 0x0400ACCF RID: 44239
		Stereo,
		// Token: 0x0400ACD0 RID: 44240
		RenderMode = 3136,
		// Token: 0x0400ACD1 RID: 44241
		PerspectiveCorrectionHint = 3152,
		// Token: 0x0400ACD2 RID: 44242
		PointSmoothHint,
		// Token: 0x0400ACD3 RID: 44243
		LineSmoothHint,
		// Token: 0x0400ACD4 RID: 44244
		PolygonSmoothHint,
		// Token: 0x0400ACD5 RID: 44245
		FogHint,
		// Token: 0x0400ACD6 RID: 44246
		TextureGenS = 3168,
		// Token: 0x0400ACD7 RID: 44247
		TextureGenT,
		// Token: 0x0400ACD8 RID: 44248
		TextureGenR,
		// Token: 0x0400ACD9 RID: 44249
		TextureGenQ,
		// Token: 0x0400ACDA RID: 44250
		PixelMapIToISize = 3248,
		// Token: 0x0400ACDB RID: 44251
		PixelMapSToSSize,
		// Token: 0x0400ACDC RID: 44252
		PixelMapIToRSize,
		// Token: 0x0400ACDD RID: 44253
		PixelMapIToGSize,
		// Token: 0x0400ACDE RID: 44254
		PixelMapIToBSize,
		// Token: 0x0400ACDF RID: 44255
		PixelMapIToASize,
		// Token: 0x0400ACE0 RID: 44256
		PixelMapRToRSize,
		// Token: 0x0400ACE1 RID: 44257
		PixelMapGToGSize,
		// Token: 0x0400ACE2 RID: 44258
		PixelMapBToBSize,
		// Token: 0x0400ACE3 RID: 44259
		PixelMapAToASize,
		// Token: 0x0400ACE4 RID: 44260
		UnpackSwapBytes = 3312,
		// Token: 0x0400ACE5 RID: 44261
		UnpackLsbFirst,
		// Token: 0x0400ACE6 RID: 44262
		UnpackRowLength,
		// Token: 0x0400ACE7 RID: 44263
		UnpackSkipRows,
		// Token: 0x0400ACE8 RID: 44264
		UnpackSkipPixels,
		// Token: 0x0400ACE9 RID: 44265
		UnpackAlignment,
		// Token: 0x0400ACEA RID: 44266
		PackSwapBytes = 3328,
		// Token: 0x0400ACEB RID: 44267
		PackLsbFirst,
		// Token: 0x0400ACEC RID: 44268
		PackRowLength,
		// Token: 0x0400ACED RID: 44269
		PackSkipRows,
		// Token: 0x0400ACEE RID: 44270
		PackSkipPixels,
		// Token: 0x0400ACEF RID: 44271
		PackAlignment,
		// Token: 0x0400ACF0 RID: 44272
		MapColor = 3344,
		// Token: 0x0400ACF1 RID: 44273
		MapStencil,
		// Token: 0x0400ACF2 RID: 44274
		IndexShift,
		// Token: 0x0400ACF3 RID: 44275
		IndexOffset,
		// Token: 0x0400ACF4 RID: 44276
		RedScale,
		// Token: 0x0400ACF5 RID: 44277
		RedBias,
		// Token: 0x0400ACF6 RID: 44278
		ZoomX,
		// Token: 0x0400ACF7 RID: 44279
		ZoomY,
		// Token: 0x0400ACF8 RID: 44280
		GreenScale,
		// Token: 0x0400ACF9 RID: 44281
		GreenBias,
		// Token: 0x0400ACFA RID: 44282
		BlueScale,
		// Token: 0x0400ACFB RID: 44283
		BlueBias,
		// Token: 0x0400ACFC RID: 44284
		AlphaScale,
		// Token: 0x0400ACFD RID: 44285
		AlphaBias,
		// Token: 0x0400ACFE RID: 44286
		DepthScale,
		// Token: 0x0400ACFF RID: 44287
		DepthBias,
		// Token: 0x0400AD00 RID: 44288
		MaxEvalOrder = 3376,
		// Token: 0x0400AD01 RID: 44289
		MaxLights,
		// Token: 0x0400AD02 RID: 44290
		MaxClipDistances,
		// Token: 0x0400AD03 RID: 44291
		MaxClipPlanes = 3378,
		// Token: 0x0400AD04 RID: 44292
		MaxTextureSize,
		// Token: 0x0400AD05 RID: 44293
		MaxPixelMapTable,
		// Token: 0x0400AD06 RID: 44294
		MaxAttribStackDepth,
		// Token: 0x0400AD07 RID: 44295
		MaxModelviewStackDepth,
		// Token: 0x0400AD08 RID: 44296
		MaxNameStackDepth,
		// Token: 0x0400AD09 RID: 44297
		MaxProjectionStackDepth,
		// Token: 0x0400AD0A RID: 44298
		MaxTextureStackDepth,
		// Token: 0x0400AD0B RID: 44299
		MaxViewportDims,
		// Token: 0x0400AD0C RID: 44300
		MaxClientAttribStackDepth,
		// Token: 0x0400AD0D RID: 44301
		SubpixelBits = 3408,
		// Token: 0x0400AD0E RID: 44302
		IndexBits,
		// Token: 0x0400AD0F RID: 44303
		RedBits,
		// Token: 0x0400AD10 RID: 44304
		GreenBits,
		// Token: 0x0400AD11 RID: 44305
		BlueBits,
		// Token: 0x0400AD12 RID: 44306
		AlphaBits,
		// Token: 0x0400AD13 RID: 44307
		DepthBits,
		// Token: 0x0400AD14 RID: 44308
		StencilBits,
		// Token: 0x0400AD15 RID: 44309
		AccumRedBits,
		// Token: 0x0400AD16 RID: 44310
		AccumGreenBits,
		// Token: 0x0400AD17 RID: 44311
		AccumBlueBits,
		// Token: 0x0400AD18 RID: 44312
		AccumAlphaBits,
		// Token: 0x0400AD19 RID: 44313
		NameStackDepth = 3440,
		// Token: 0x0400AD1A RID: 44314
		AutoNormal = 3456,
		// Token: 0x0400AD1B RID: 44315
		Map1Color4 = 3472,
		// Token: 0x0400AD1C RID: 44316
		Map1Index,
		// Token: 0x0400AD1D RID: 44317
		Map1Normal,
		// Token: 0x0400AD1E RID: 44318
		Map1TextureCoord1,
		// Token: 0x0400AD1F RID: 44319
		Map1TextureCoord2,
		// Token: 0x0400AD20 RID: 44320
		Map1TextureCoord3,
		// Token: 0x0400AD21 RID: 44321
		Map1TextureCoord4,
		// Token: 0x0400AD22 RID: 44322
		Map1Vertex3,
		// Token: 0x0400AD23 RID: 44323
		Map1Vertex4,
		// Token: 0x0400AD24 RID: 44324
		Map2Color4 = 3504,
		// Token: 0x0400AD25 RID: 44325
		Map2Index,
		// Token: 0x0400AD26 RID: 44326
		Map2Normal,
		// Token: 0x0400AD27 RID: 44327
		Map2TextureCoord1,
		// Token: 0x0400AD28 RID: 44328
		Map2TextureCoord2,
		// Token: 0x0400AD29 RID: 44329
		Map2TextureCoord3,
		// Token: 0x0400AD2A RID: 44330
		Map2TextureCoord4,
		// Token: 0x0400AD2B RID: 44331
		Map2Vertex3,
		// Token: 0x0400AD2C RID: 44332
		Map2Vertex4,
		// Token: 0x0400AD2D RID: 44333
		Map1GridDomain = 3536,
		// Token: 0x0400AD2E RID: 44334
		Map1GridSegments,
		// Token: 0x0400AD2F RID: 44335
		Map2GridDomain,
		// Token: 0x0400AD30 RID: 44336
		Map2GridSegments,
		// Token: 0x0400AD31 RID: 44337
		Texture1D = 3552,
		// Token: 0x0400AD32 RID: 44338
		Texture2D,
		// Token: 0x0400AD33 RID: 44339
		FeedbackBufferSize = 3569,
		// Token: 0x0400AD34 RID: 44340
		FeedbackBufferType,
		// Token: 0x0400AD35 RID: 44341
		SelectionBufferSize = 3572,
		// Token: 0x0400AD36 RID: 44342
		PolygonOffsetUnits = 10752,
		// Token: 0x0400AD37 RID: 44343
		PolygonOffsetPoint,
		// Token: 0x0400AD38 RID: 44344
		PolygonOffsetLine,
		// Token: 0x0400AD39 RID: 44345
		ClipPlane0 = 12288,
		// Token: 0x0400AD3A RID: 44346
		ClipPlane1,
		// Token: 0x0400AD3B RID: 44347
		ClipPlane2,
		// Token: 0x0400AD3C RID: 44348
		ClipPlane3,
		// Token: 0x0400AD3D RID: 44349
		ClipPlane4,
		// Token: 0x0400AD3E RID: 44350
		ClipPlane5,
		// Token: 0x0400AD3F RID: 44351
		Light0 = 16384,
		// Token: 0x0400AD40 RID: 44352
		Light1,
		// Token: 0x0400AD41 RID: 44353
		Light2,
		// Token: 0x0400AD42 RID: 44354
		Light3,
		// Token: 0x0400AD43 RID: 44355
		Light4,
		// Token: 0x0400AD44 RID: 44356
		Light5,
		// Token: 0x0400AD45 RID: 44357
		Light6,
		// Token: 0x0400AD46 RID: 44358
		Light7,
		// Token: 0x0400AD47 RID: 44359
		BlendColorExt = 32773,
		// Token: 0x0400AD48 RID: 44360
		BlendEquationExt = 32777,
		// Token: 0x0400AD49 RID: 44361
		PackCmykHintExt = 32782,
		// Token: 0x0400AD4A RID: 44362
		UnpackCmykHintExt,
		// Token: 0x0400AD4B RID: 44363
		Convolution1DExt,
		// Token: 0x0400AD4C RID: 44364
		Convolution2DExt,
		// Token: 0x0400AD4D RID: 44365
		Separable2DExt,
		// Token: 0x0400AD4E RID: 44366
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x0400AD4F RID: 44367
		PostConvolutionGreenScaleExt,
		// Token: 0x0400AD50 RID: 44368
		PostConvolutionBlueScaleExt,
		// Token: 0x0400AD51 RID: 44369
		PostConvolutionAlphaScaleExt,
		// Token: 0x0400AD52 RID: 44370
		PostConvolutionRedBiasExt,
		// Token: 0x0400AD53 RID: 44371
		PostConvolutionGreenBiasExt,
		// Token: 0x0400AD54 RID: 44372
		PostConvolutionBlueBiasExt,
		// Token: 0x0400AD55 RID: 44373
		PostConvolutionAlphaBiasExt,
		// Token: 0x0400AD56 RID: 44374
		HistogramExt,
		// Token: 0x0400AD57 RID: 44375
		MinmaxExt = 32814,
		// Token: 0x0400AD58 RID: 44376
		PolygonOffsetFill = 32823,
		// Token: 0x0400AD59 RID: 44377
		PolygonOffsetFactor,
		// Token: 0x0400AD5A RID: 44378
		PolygonOffsetBiasExt,
		// Token: 0x0400AD5B RID: 44379
		RescaleNormalExt,
		// Token: 0x0400AD5C RID: 44380
		TextureBinding1D = 32872,
		// Token: 0x0400AD5D RID: 44381
		TextureBinding2D,
		// Token: 0x0400AD5E RID: 44382
		Texture3DBindingExt,
		// Token: 0x0400AD5F RID: 44383
		TextureBinding3D = 32874,
		// Token: 0x0400AD60 RID: 44384
		PackSkipImagesExt,
		// Token: 0x0400AD61 RID: 44385
		PackImageHeightExt,
		// Token: 0x0400AD62 RID: 44386
		UnpackSkipImagesExt,
		// Token: 0x0400AD63 RID: 44387
		UnpackImageHeightExt,
		// Token: 0x0400AD64 RID: 44388
		Texture3DExt,
		// Token: 0x0400AD65 RID: 44389
		Max3DTextureSizeExt = 32883,
		// Token: 0x0400AD66 RID: 44390
		VertexArray,
		// Token: 0x0400AD67 RID: 44391
		NormalArray,
		// Token: 0x0400AD68 RID: 44392
		ColorArray,
		// Token: 0x0400AD69 RID: 44393
		IndexArray,
		// Token: 0x0400AD6A RID: 44394
		TextureCoordArray,
		// Token: 0x0400AD6B RID: 44395
		EdgeFlagArray,
		// Token: 0x0400AD6C RID: 44396
		VertexArraySize,
		// Token: 0x0400AD6D RID: 44397
		VertexArrayType,
		// Token: 0x0400AD6E RID: 44398
		VertexArrayStride,
		// Token: 0x0400AD6F RID: 44399
		VertexArrayCountExt,
		// Token: 0x0400AD70 RID: 44400
		NormalArrayType,
		// Token: 0x0400AD71 RID: 44401
		NormalArrayStride,
		// Token: 0x0400AD72 RID: 44402
		NormalArrayCountExt,
		// Token: 0x0400AD73 RID: 44403
		ColorArraySize,
		// Token: 0x0400AD74 RID: 44404
		ColorArrayType,
		// Token: 0x0400AD75 RID: 44405
		ColorArrayStride,
		// Token: 0x0400AD76 RID: 44406
		ColorArrayCountExt,
		// Token: 0x0400AD77 RID: 44407
		IndexArrayType,
		// Token: 0x0400AD78 RID: 44408
		IndexArrayStride,
		// Token: 0x0400AD79 RID: 44409
		IndexArrayCountExt,
		// Token: 0x0400AD7A RID: 44410
		TextureCoordArraySize,
		// Token: 0x0400AD7B RID: 44411
		TextureCoordArrayType,
		// Token: 0x0400AD7C RID: 44412
		TextureCoordArrayStride,
		// Token: 0x0400AD7D RID: 44413
		TextureCoordArrayCountExt,
		// Token: 0x0400AD7E RID: 44414
		EdgeFlagArrayStride,
		// Token: 0x0400AD7F RID: 44415
		EdgeFlagArrayCountExt,
		// Token: 0x0400AD80 RID: 44416
		InterlaceSgix = 32916,
		// Token: 0x0400AD81 RID: 44417
		DetailTexture2DBindingSgis = 32918,
		// Token: 0x0400AD82 RID: 44418
		MultisampleSgis = 32925,
		// Token: 0x0400AD83 RID: 44419
		SampleAlphaToMaskSgis,
		// Token: 0x0400AD84 RID: 44420
		SampleAlphaToOneSgis,
		// Token: 0x0400AD85 RID: 44421
		SampleMaskSgis,
		// Token: 0x0400AD86 RID: 44422
		SampleBuffersSgis = 32936,
		// Token: 0x0400AD87 RID: 44423
		SamplesSgis,
		// Token: 0x0400AD88 RID: 44424
		SampleMaskValueSgis,
		// Token: 0x0400AD89 RID: 44425
		SampleMaskInvertSgis,
		// Token: 0x0400AD8A RID: 44426
		SamplePatternSgis,
		// Token: 0x0400AD8B RID: 44427
		ColorMatrixSgi = 32945,
		// Token: 0x0400AD8C RID: 44428
		ColorMatrixStackDepthSgi,
		// Token: 0x0400AD8D RID: 44429
		MaxColorMatrixStackDepthSgi,
		// Token: 0x0400AD8E RID: 44430
		PostColorMatrixRedScaleSgi,
		// Token: 0x0400AD8F RID: 44431
		PostColorMatrixGreenScaleSgi,
		// Token: 0x0400AD90 RID: 44432
		PostColorMatrixBlueScaleSgi,
		// Token: 0x0400AD91 RID: 44433
		PostColorMatrixAlphaScaleSgi,
		// Token: 0x0400AD92 RID: 44434
		PostColorMatrixRedBiasSgi,
		// Token: 0x0400AD93 RID: 44435
		PostColorMatrixGreenBiasSgi,
		// Token: 0x0400AD94 RID: 44436
		PostColorMatrixBlueBiasSgi,
		// Token: 0x0400AD95 RID: 44437
		PostColorMatrixAlphaBiasSgi,
		// Token: 0x0400AD96 RID: 44438
		TextureColorTableSgi,
		// Token: 0x0400AD97 RID: 44439
		ColorTableSgi = 32976,
		// Token: 0x0400AD98 RID: 44440
		PostConvolutionColorTableSgi,
		// Token: 0x0400AD99 RID: 44441
		PostColorMatrixColorTableSgi,
		// Token: 0x0400AD9A RID: 44442
		PointSizeMinSgis = 33062,
		// Token: 0x0400AD9B RID: 44443
		PointSizeMaxSgis,
		// Token: 0x0400AD9C RID: 44444
		PointFadeThresholdSizeSgis,
		// Token: 0x0400AD9D RID: 44445
		DistanceAttenuationSgis,
		// Token: 0x0400AD9E RID: 44446
		FogFuncPointsSgis = 33067,
		// Token: 0x0400AD9F RID: 44447
		MaxFogFuncPointsSgis,
		// Token: 0x0400ADA0 RID: 44448
		PackSkipVolumesSgis = 33072,
		// Token: 0x0400ADA1 RID: 44449
		PackImageDepthSgis,
		// Token: 0x0400ADA2 RID: 44450
		UnpackSkipVolumesSgis,
		// Token: 0x0400ADA3 RID: 44451
		UnpackImageDepthSgis,
		// Token: 0x0400ADA4 RID: 44452
		Texture4DSgis,
		// Token: 0x0400ADA5 RID: 44453
		Max4DTextureSizeSgis = 33080,
		// Token: 0x0400ADA6 RID: 44454
		PixelTexGenSgix,
		// Token: 0x0400ADA7 RID: 44455
		PixelTileBestAlignmentSgix = 33086,
		// Token: 0x0400ADA8 RID: 44456
		PixelTileCacheIncrementSgix,
		// Token: 0x0400ADA9 RID: 44457
		PixelTileWidthSgix,
		// Token: 0x0400ADAA RID: 44458
		PixelTileHeightSgix,
		// Token: 0x0400ADAB RID: 44459
		PixelTileGridWidthSgix,
		// Token: 0x0400ADAC RID: 44460
		PixelTileGridHeightSgix,
		// Token: 0x0400ADAD RID: 44461
		PixelTileGridDepthSgix,
		// Token: 0x0400ADAE RID: 44462
		PixelTileCacheSizeSgix,
		// Token: 0x0400ADAF RID: 44463
		SpriteSgix = 33096,
		// Token: 0x0400ADB0 RID: 44464
		SpriteModeSgix,
		// Token: 0x0400ADB1 RID: 44465
		SpriteAxisSgix,
		// Token: 0x0400ADB2 RID: 44466
		SpriteTranslationSgix,
		// Token: 0x0400ADB3 RID: 44467
		Texture4DBindingSgis = 33103,
		// Token: 0x0400ADB4 RID: 44468
		MaxClipmapDepthSgix = 33143,
		// Token: 0x0400ADB5 RID: 44469
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400ADB6 RID: 44470
		PostTextureFilterBiasRangeSgix = 33147,
		// Token: 0x0400ADB7 RID: 44471
		PostTextureFilterScaleRangeSgix,
		// Token: 0x0400ADB8 RID: 44472
		ReferencePlaneSgix,
		// Token: 0x0400ADB9 RID: 44473
		ReferencePlaneEquationSgix,
		// Token: 0x0400ADBA RID: 44474
		IrInstrument1Sgix,
		// Token: 0x0400ADBB RID: 44475
		InstrumentMeasurementsSgix = 33153,
		// Token: 0x0400ADBC RID: 44476
		CalligraphicFragmentSgix = 33155,
		// Token: 0x0400ADBD RID: 44477
		FramezoomSgix = 33163,
		// Token: 0x0400ADBE RID: 44478
		FramezoomFactorSgix,
		// Token: 0x0400ADBF RID: 44479
		MaxFramezoomFactorSgix,
		// Token: 0x0400ADC0 RID: 44480
		GenerateMipmapHintSgis = 33170,
		// Token: 0x0400ADC1 RID: 44481
		DeformationsMaskSgix = 33174,
		// Token: 0x0400ADC2 RID: 44482
		FogOffsetSgix = 33176,
		// Token: 0x0400ADC3 RID: 44483
		FogOffsetValueSgix,
		// Token: 0x0400ADC4 RID: 44484
		LightModelColorControl = 33272,
		// Token: 0x0400ADC5 RID: 44485
		SharedTexturePaletteExt = 33275,
		// Token: 0x0400ADC6 RID: 44486
		ConvolutionHintSgix = 33558,
		// Token: 0x0400ADC7 RID: 44487
		AsyncMarkerSgix = 33577,
		// Token: 0x0400ADC8 RID: 44488
		PixelTexGenModeSgix = 33579,
		// Token: 0x0400ADC9 RID: 44489
		AsyncHistogramSgix,
		// Token: 0x0400ADCA RID: 44490
		MaxAsyncHistogramSgix,
		// Token: 0x0400ADCB RID: 44491
		PixelTextureSgis = 33619,
		// Token: 0x0400ADCC RID: 44492
		AsyncTexImageSgix = 33628,
		// Token: 0x0400ADCD RID: 44493
		AsyncDrawPixelsSgix,
		// Token: 0x0400ADCE RID: 44494
		AsyncReadPixelsSgix,
		// Token: 0x0400ADCF RID: 44495
		MaxAsyncTexImageSgix,
		// Token: 0x0400ADD0 RID: 44496
		MaxAsyncDrawPixelsSgix,
		// Token: 0x0400ADD1 RID: 44497
		MaxAsyncReadPixelsSgix,
		// Token: 0x0400ADD2 RID: 44498
		VertexPreclipSgix = 33774,
		// Token: 0x0400ADD3 RID: 44499
		VertexPreclipHintSgix,
		// Token: 0x0400ADD4 RID: 44500
		FragmentLightingSgix = 33792,
		// Token: 0x0400ADD5 RID: 44501
		FragmentColorMaterialSgix,
		// Token: 0x0400ADD6 RID: 44502
		FragmentColorMaterialFaceSgix,
		// Token: 0x0400ADD7 RID: 44503
		FragmentColorMaterialParameterSgix,
		// Token: 0x0400ADD8 RID: 44504
		MaxFragmentLightsSgix,
		// Token: 0x0400ADD9 RID: 44505
		MaxActiveLightsSgix,
		// Token: 0x0400ADDA RID: 44506
		LightEnvModeSgix = 33799,
		// Token: 0x0400ADDB RID: 44507
		FragmentLightModelLocalViewerSgix,
		// Token: 0x0400ADDC RID: 44508
		FragmentLightModelTwoSideSgix,
		// Token: 0x0400ADDD RID: 44509
		FragmentLightModelAmbientSgix,
		// Token: 0x0400ADDE RID: 44510
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x0400ADDF RID: 44511
		FragmentLight0Sgix,
		// Token: 0x0400ADE0 RID: 44512
		PackResampleSgix = 33836,
		// Token: 0x0400ADE1 RID: 44513
		UnpackResampleSgix,
		// Token: 0x0400ADE2 RID: 44514
		AliasedPointSizeRange = 33901,
		// Token: 0x0400ADE3 RID: 44515
		AliasedLineWidthRange,
		// Token: 0x0400ADE4 RID: 44516
		PackSubsampleRateSgix = 34208,
		// Token: 0x0400ADE5 RID: 44517
		UnpackSubsampleRateSgix
	}
}
