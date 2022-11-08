using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006D0 RID: 1744
	public enum GetPName
	{
		// Token: 0x04006697 RID: 26263
		PointSmooth = 2832,
		// Token: 0x04006698 RID: 26264
		PointSize,
		// Token: 0x04006699 RID: 26265
		PointSizeRange,
		// Token: 0x0400669A RID: 26266
		SmoothPointSizeRange = 2834,
		// Token: 0x0400669B RID: 26267
		PointSizeGranularity,
		// Token: 0x0400669C RID: 26268
		SmoothPointSizeGranularity = 2835,
		// Token: 0x0400669D RID: 26269
		LineSmooth = 2848,
		// Token: 0x0400669E RID: 26270
		LineWidth,
		// Token: 0x0400669F RID: 26271
		LineWidthRange,
		// Token: 0x040066A0 RID: 26272
		SmoothLineWidthRange = 2850,
		// Token: 0x040066A1 RID: 26273
		LineWidthGranularity,
		// Token: 0x040066A2 RID: 26274
		SmoothLineWidthGranularity = 2851,
		// Token: 0x040066A3 RID: 26275
		LineStipple,
		// Token: 0x040066A4 RID: 26276
		PolygonMode = 2880,
		// Token: 0x040066A5 RID: 26277
		PolygonSmooth,
		// Token: 0x040066A6 RID: 26278
		PolygonStipple,
		// Token: 0x040066A7 RID: 26279
		CullFace = 2884,
		// Token: 0x040066A8 RID: 26280
		CullFaceMode,
		// Token: 0x040066A9 RID: 26281
		FrontFace,
		// Token: 0x040066AA RID: 26282
		Lighting = 2896,
		// Token: 0x040066AB RID: 26283
		ColorMaterial = 2903,
		// Token: 0x040066AC RID: 26284
		Fog = 2912,
		// Token: 0x040066AD RID: 26285
		FogIndex,
		// Token: 0x040066AE RID: 26286
		FogDensity,
		// Token: 0x040066AF RID: 26287
		FogStart,
		// Token: 0x040066B0 RID: 26288
		FogEnd,
		// Token: 0x040066B1 RID: 26289
		FogMode,
		// Token: 0x040066B2 RID: 26290
		FogColor,
		// Token: 0x040066B3 RID: 26291
		DepthRange = 2928,
		// Token: 0x040066B4 RID: 26292
		DepthTest,
		// Token: 0x040066B5 RID: 26293
		DepthWritemask,
		// Token: 0x040066B6 RID: 26294
		DepthClearValue,
		// Token: 0x040066B7 RID: 26295
		DepthFunc,
		// Token: 0x040066B8 RID: 26296
		StencilTest = 2960,
		// Token: 0x040066B9 RID: 26297
		StencilClearValue,
		// Token: 0x040066BA RID: 26298
		StencilFunc,
		// Token: 0x040066BB RID: 26299
		StencilValueMask,
		// Token: 0x040066BC RID: 26300
		StencilFail,
		// Token: 0x040066BD RID: 26301
		StencilPassDepthFail,
		// Token: 0x040066BE RID: 26302
		StencilPassDepthPass,
		// Token: 0x040066BF RID: 26303
		StencilRef,
		// Token: 0x040066C0 RID: 26304
		StencilWritemask,
		// Token: 0x040066C1 RID: 26305
		Normalize = 2977,
		// Token: 0x040066C2 RID: 26306
		Viewport,
		// Token: 0x040066C3 RID: 26307
		Modelview0StackDepthExt,
		// Token: 0x040066C4 RID: 26308
		Modelview0MatrixExt = 2982,
		// Token: 0x040066C5 RID: 26309
		AlphaTest = 3008,
		// Token: 0x040066C6 RID: 26310
		AlphaTestQcom = 3008,
		// Token: 0x040066C7 RID: 26311
		AlphaTestFuncQcom,
		// Token: 0x040066C8 RID: 26312
		AlphaTestRefQcom,
		// Token: 0x040066C9 RID: 26313
		Dither = 3024,
		// Token: 0x040066CA RID: 26314
		BlendDst = 3040,
		// Token: 0x040066CB RID: 26315
		BlendSrc,
		// Token: 0x040066CC RID: 26316
		Blend,
		// Token: 0x040066CD RID: 26317
		LogicOpMode = 3056,
		// Token: 0x040066CE RID: 26318
		IndexLogicOp,
		// Token: 0x040066CF RID: 26319
		LogicOp = 3057,
		// Token: 0x040066D0 RID: 26320
		ColorLogicOp,
		// Token: 0x040066D1 RID: 26321
		DrawBuffer = 3073,
		// Token: 0x040066D2 RID: 26322
		DrawBufferExt = 3073,
		// Token: 0x040066D3 RID: 26323
		ReadBuffer,
		// Token: 0x040066D4 RID: 26324
		ReadBufferExt = 3074,
		// Token: 0x040066D5 RID: 26325
		ReadBufferNv = 3074,
		// Token: 0x040066D6 RID: 26326
		ScissorBox = 3088,
		// Token: 0x040066D7 RID: 26327
		ScissorTest,
		// Token: 0x040066D8 RID: 26328
		ColorClearValue = 3106,
		// Token: 0x040066D9 RID: 26329
		ColorWritemask,
		// Token: 0x040066DA RID: 26330
		Doublebuffer = 3122,
		// Token: 0x040066DB RID: 26331
		Stereo,
		// Token: 0x040066DC RID: 26332
		LineSmoothHint = 3154,
		// Token: 0x040066DD RID: 26333
		PolygonSmoothHint,
		// Token: 0x040066DE RID: 26334
		TextureGenS = 3168,
		// Token: 0x040066DF RID: 26335
		TextureGenT,
		// Token: 0x040066E0 RID: 26336
		TextureGenR,
		// Token: 0x040066E1 RID: 26337
		TextureGenQ,
		// Token: 0x040066E2 RID: 26338
		UnpackSwapBytes = 3312,
		// Token: 0x040066E3 RID: 26339
		UnpackLsbFirst,
		// Token: 0x040066E4 RID: 26340
		UnpackRowLength,
		// Token: 0x040066E5 RID: 26341
		UnpackSkipRows,
		// Token: 0x040066E6 RID: 26342
		UnpackSkipPixels,
		// Token: 0x040066E7 RID: 26343
		UnpackAlignment,
		// Token: 0x040066E8 RID: 26344
		PackSwapBytes = 3328,
		// Token: 0x040066E9 RID: 26345
		PackLsbFirst,
		// Token: 0x040066EA RID: 26346
		PackRowLength,
		// Token: 0x040066EB RID: 26347
		PackSkipRows,
		// Token: 0x040066EC RID: 26348
		PackSkipPixels,
		// Token: 0x040066ED RID: 26349
		PackAlignment,
		// Token: 0x040066EE RID: 26350
		MaxClipDistances = 3378,
		// Token: 0x040066EF RID: 26351
		MaxTextureSize,
		// Token: 0x040066F0 RID: 26352
		MaxViewportDims = 3386,
		// Token: 0x040066F1 RID: 26353
		SubpixelBits = 3408,
		// Token: 0x040066F2 RID: 26354
		AutoNormal = 3456,
		// Token: 0x040066F3 RID: 26355
		Map1Color4 = 3472,
		// Token: 0x040066F4 RID: 26356
		Map1Index,
		// Token: 0x040066F5 RID: 26357
		Map1Normal,
		// Token: 0x040066F6 RID: 26358
		Map1TextureCoord1,
		// Token: 0x040066F7 RID: 26359
		Map1TextureCoord2,
		// Token: 0x040066F8 RID: 26360
		Map1TextureCoord3,
		// Token: 0x040066F9 RID: 26361
		Map1TextureCoord4,
		// Token: 0x040066FA RID: 26362
		Map1Vertex3,
		// Token: 0x040066FB RID: 26363
		Map1Vertex4,
		// Token: 0x040066FC RID: 26364
		Map2Color4 = 3504,
		// Token: 0x040066FD RID: 26365
		Map2Index,
		// Token: 0x040066FE RID: 26366
		Map2Normal,
		// Token: 0x040066FF RID: 26367
		Map2TextureCoord1,
		// Token: 0x04006700 RID: 26368
		Map2TextureCoord2,
		// Token: 0x04006701 RID: 26369
		Map2TextureCoord3,
		// Token: 0x04006702 RID: 26370
		Map2TextureCoord4,
		// Token: 0x04006703 RID: 26371
		Map2Vertex3,
		// Token: 0x04006704 RID: 26372
		Map2Vertex4,
		// Token: 0x04006705 RID: 26373
		Texture1D = 3552,
		// Token: 0x04006706 RID: 26374
		Texture2D,
		// Token: 0x04006707 RID: 26375
		PolygonOffsetUnits = 10752,
		// Token: 0x04006708 RID: 26376
		PolygonOffsetPoint,
		// Token: 0x04006709 RID: 26377
		PolygonOffsetLine,
		// Token: 0x0400670A RID: 26378
		ClipPlane0 = 12288,
		// Token: 0x0400670B RID: 26379
		ClipPlane1,
		// Token: 0x0400670C RID: 26380
		ClipPlane2,
		// Token: 0x0400670D RID: 26381
		ClipPlane3,
		// Token: 0x0400670E RID: 26382
		ClipPlane4,
		// Token: 0x0400670F RID: 26383
		ClipPlane5,
		// Token: 0x04006710 RID: 26384
		Light0 = 16384,
		// Token: 0x04006711 RID: 26385
		Light1,
		// Token: 0x04006712 RID: 26386
		Light2,
		// Token: 0x04006713 RID: 26387
		Light3,
		// Token: 0x04006714 RID: 26388
		Light4,
		// Token: 0x04006715 RID: 26389
		Light5,
		// Token: 0x04006716 RID: 26390
		Light6,
		// Token: 0x04006717 RID: 26391
		Light7,
		// Token: 0x04006718 RID: 26392
		BlendColorExt = 32773,
		// Token: 0x04006719 RID: 26393
		BlendEquationExt = 32777,
		// Token: 0x0400671A RID: 26394
		BlendEquationRgb = 32777,
		// Token: 0x0400671B RID: 26395
		PackCmykHintExt = 32782,
		// Token: 0x0400671C RID: 26396
		UnpackCmykHintExt,
		// Token: 0x0400671D RID: 26397
		Convolution1DExt,
		// Token: 0x0400671E RID: 26398
		Convolution2DExt,
		// Token: 0x0400671F RID: 26399
		Separable2DExt,
		// Token: 0x04006720 RID: 26400
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x04006721 RID: 26401
		PostConvolutionGreenScaleExt,
		// Token: 0x04006722 RID: 26402
		PostConvolutionBlueScaleExt,
		// Token: 0x04006723 RID: 26403
		PostConvolutionAlphaScaleExt,
		// Token: 0x04006724 RID: 26404
		PostConvolutionRedBiasExt,
		// Token: 0x04006725 RID: 26405
		PostConvolutionGreenBiasExt,
		// Token: 0x04006726 RID: 26406
		PostConvolutionBlueBiasExt,
		// Token: 0x04006727 RID: 26407
		PostConvolutionAlphaBiasExt,
		// Token: 0x04006728 RID: 26408
		HistogramExt,
		// Token: 0x04006729 RID: 26409
		MinmaxExt = 32814,
		// Token: 0x0400672A RID: 26410
		PolygonOffsetFill = 32823,
		// Token: 0x0400672B RID: 26411
		PolygonOffsetFactor,
		// Token: 0x0400672C RID: 26412
		PolygonOffsetBiasExt,
		// Token: 0x0400672D RID: 26413
		RescaleNormalExt,
		// Token: 0x0400672E RID: 26414
		TextureBinding1D = 32872,
		// Token: 0x0400672F RID: 26415
		TextureBinding2D,
		// Token: 0x04006730 RID: 26416
		Texture3DBindingExt,
		// Token: 0x04006731 RID: 26417
		TextureBinding3D = 32874,
		// Token: 0x04006732 RID: 26418
		PackSkipImagesExt,
		// Token: 0x04006733 RID: 26419
		PackImageHeightExt,
		// Token: 0x04006734 RID: 26420
		UnpackSkipImagesExt,
		// Token: 0x04006735 RID: 26421
		UnpackImageHeightExt,
		// Token: 0x04006736 RID: 26422
		Texture3DExt,
		// Token: 0x04006737 RID: 26423
		Max3DTextureSize = 32883,
		// Token: 0x04006738 RID: 26424
		Max3DTextureSizeExt = 32883,
		// Token: 0x04006739 RID: 26425
		VertexArray,
		// Token: 0x0400673A RID: 26426
		NormalArray,
		// Token: 0x0400673B RID: 26427
		ColorArray,
		// Token: 0x0400673C RID: 26428
		IndexArray,
		// Token: 0x0400673D RID: 26429
		TextureCoordArray,
		// Token: 0x0400673E RID: 26430
		EdgeFlagArray,
		// Token: 0x0400673F RID: 26431
		VertexArrayCountExt = 32893,
		// Token: 0x04006740 RID: 26432
		NormalArrayCountExt = 32896,
		// Token: 0x04006741 RID: 26433
		ColorArrayCountExt = 32900,
		// Token: 0x04006742 RID: 26434
		IndexArrayCountExt = 32903,
		// Token: 0x04006743 RID: 26435
		TextureCoordArrayCountExt = 32907,
		// Token: 0x04006744 RID: 26436
		EdgeFlagArrayCountExt = 32909,
		// Token: 0x04006745 RID: 26437
		InterlaceSgix = 32916,
		// Token: 0x04006746 RID: 26438
		DetailTexture2DBindingSgis = 32918,
		// Token: 0x04006747 RID: 26439
		Multisample = 32925,
		// Token: 0x04006748 RID: 26440
		MultisampleSgis = 32925,
		// Token: 0x04006749 RID: 26441
		SampleAlphaToCoverage,
		// Token: 0x0400674A RID: 26442
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x0400674B RID: 26443
		SampleAlphaToOne,
		// Token: 0x0400674C RID: 26444
		SampleAlphaToOneSgis = 32927,
		// Token: 0x0400674D RID: 26445
		SampleCoverage,
		// Token: 0x0400674E RID: 26446
		SampleMaskSgis = 32928,
		// Token: 0x0400674F RID: 26447
		SampleBuffers = 32936,
		// Token: 0x04006750 RID: 26448
		SampleBuffersSgis = 32936,
		// Token: 0x04006751 RID: 26449
		Samples,
		// Token: 0x04006752 RID: 26450
		SamplesSgis = 32937,
		// Token: 0x04006753 RID: 26451
		SampleCoverageValue,
		// Token: 0x04006754 RID: 26452
		SampleMaskValueSgis = 32938,
		// Token: 0x04006755 RID: 26453
		SampleCoverageInvert,
		// Token: 0x04006756 RID: 26454
		SampleMaskInvertSgis = 32939,
		// Token: 0x04006757 RID: 26455
		SamplePatternSgis,
		// Token: 0x04006758 RID: 26456
		ColorMatrixSgi = 32945,
		// Token: 0x04006759 RID: 26457
		ColorMatrixStackDepthSgi,
		// Token: 0x0400675A RID: 26458
		MaxColorMatrixStackDepthSgi,
		// Token: 0x0400675B RID: 26459
		PostColorMatrixRedScaleSgi,
		// Token: 0x0400675C RID: 26460
		PostColorMatrixGreenScaleSgi,
		// Token: 0x0400675D RID: 26461
		PostColorMatrixBlueScaleSgi,
		// Token: 0x0400675E RID: 26462
		PostColorMatrixAlphaScaleSgi,
		// Token: 0x0400675F RID: 26463
		PostColorMatrixRedBiasSgi,
		// Token: 0x04006760 RID: 26464
		PostColorMatrixGreenBiasSgi,
		// Token: 0x04006761 RID: 26465
		PostColorMatrixBlueBiasSgi,
		// Token: 0x04006762 RID: 26466
		PostColorMatrixAlphaBiasSgi,
		// Token: 0x04006763 RID: 26467
		TextureColorTableSgi,
		// Token: 0x04006764 RID: 26468
		BlendDstRgb = 32968,
		// Token: 0x04006765 RID: 26469
		BlendSrcRgb,
		// Token: 0x04006766 RID: 26470
		BlendDstAlpha,
		// Token: 0x04006767 RID: 26471
		BlendSrcAlpha,
		// Token: 0x04006768 RID: 26472
		ColorTableSgi = 32976,
		// Token: 0x04006769 RID: 26473
		PostConvolutionColorTableSgi,
		// Token: 0x0400676A RID: 26474
		PostColorMatrixColorTableSgi,
		// Token: 0x0400676B RID: 26475
		MaxElementsVertices = 33000,
		// Token: 0x0400676C RID: 26476
		MaxElementsIndices,
		// Token: 0x0400676D RID: 26477
		PointSizeMin = 33062,
		// Token: 0x0400676E RID: 26478
		PointSizeMinSgis = 33062,
		// Token: 0x0400676F RID: 26479
		PointSizeMax,
		// Token: 0x04006770 RID: 26480
		PointSizeMaxSgis = 33063,
		// Token: 0x04006771 RID: 26481
		PointFadeThresholdSize,
		// Token: 0x04006772 RID: 26482
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x04006773 RID: 26483
		DistanceAttenuationSgis,
		// Token: 0x04006774 RID: 26484
		PointDistanceAttenuation = 33065,
		// Token: 0x04006775 RID: 26485
		FogFuncPointsSgis = 33067,
		// Token: 0x04006776 RID: 26486
		MaxFogFuncPointsSgis,
		// Token: 0x04006777 RID: 26487
		PackSkipVolumesSgis = 33072,
		// Token: 0x04006778 RID: 26488
		PackImageDepthSgis,
		// Token: 0x04006779 RID: 26489
		UnpackSkipVolumesSgis,
		// Token: 0x0400677A RID: 26490
		UnpackImageDepthSgis,
		// Token: 0x0400677B RID: 26491
		Texture4DSgis,
		// Token: 0x0400677C RID: 26492
		Max4DTextureSizeSgis = 33080,
		// Token: 0x0400677D RID: 26493
		PixelTexGenSgix,
		// Token: 0x0400677E RID: 26494
		PixelTileBestAlignmentSgix = 33086,
		// Token: 0x0400677F RID: 26495
		PixelTileCacheIncrementSgix,
		// Token: 0x04006780 RID: 26496
		PixelTileWidthSgix,
		// Token: 0x04006781 RID: 26497
		PixelTileHeightSgix,
		// Token: 0x04006782 RID: 26498
		PixelTileGridWidthSgix,
		// Token: 0x04006783 RID: 26499
		PixelTileGridHeightSgix,
		// Token: 0x04006784 RID: 26500
		PixelTileGridDepthSgix,
		// Token: 0x04006785 RID: 26501
		PixelTileCacheSizeSgix,
		// Token: 0x04006786 RID: 26502
		SpriteSgix = 33096,
		// Token: 0x04006787 RID: 26503
		SpriteModeSgix,
		// Token: 0x04006788 RID: 26504
		SpriteAxisSgix,
		// Token: 0x04006789 RID: 26505
		SpriteTranslationSgix,
		// Token: 0x0400678A RID: 26506
		Texture4DBindingSgis = 33103,
		// Token: 0x0400678B RID: 26507
		MaxClipmapDepthSgix = 33143,
		// Token: 0x0400678C RID: 26508
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400678D RID: 26509
		PostTextureFilterBiasRangeSgix = 33147,
		// Token: 0x0400678E RID: 26510
		PostTextureFilterScaleRangeSgix,
		// Token: 0x0400678F RID: 26511
		ReferencePlaneSgix,
		// Token: 0x04006790 RID: 26512
		ReferencePlaneEquationSgix,
		// Token: 0x04006791 RID: 26513
		IrInstrument1Sgix,
		// Token: 0x04006792 RID: 26514
		InstrumentMeasurementsSgix = 33153,
		// Token: 0x04006793 RID: 26515
		CalligraphicFragmentSgix = 33155,
		// Token: 0x04006794 RID: 26516
		FramezoomSgix = 33163,
		// Token: 0x04006795 RID: 26517
		FramezoomFactorSgix,
		// Token: 0x04006796 RID: 26518
		MaxFramezoomFactorSgix,
		// Token: 0x04006797 RID: 26519
		GenerateMipmapHint = 33170,
		// Token: 0x04006798 RID: 26520
		GenerateMipmapHintSgis = 33170,
		// Token: 0x04006799 RID: 26521
		DeformationsMaskSgix = 33174,
		// Token: 0x0400679A RID: 26522
		FogOffsetSgix = 33176,
		// Token: 0x0400679B RID: 26523
		FogOffsetValueSgix,
		// Token: 0x0400679C RID: 26524
		LightModelColorControl = 33272,
		// Token: 0x0400679D RID: 26525
		SharedTexturePaletteExt = 33275,
		// Token: 0x0400679E RID: 26526
		MajorVersion = 33307,
		// Token: 0x0400679F RID: 26527
		MinorVersion,
		// Token: 0x040067A0 RID: 26528
		NumExtensions,
		// Token: 0x040067A1 RID: 26529
		ContextFlags,
		// Token: 0x040067A2 RID: 26530
		ProgramPipelineBinding = 33370,
		// Token: 0x040067A3 RID: 26531
		MaxViewports,
		// Token: 0x040067A4 RID: 26532
		ViewportSubpixelBits,
		// Token: 0x040067A5 RID: 26533
		ViewportBoundsRange,
		// Token: 0x040067A6 RID: 26534
		LayerProvokingVertex,
		// Token: 0x040067A7 RID: 26535
		ViewportIndexProvokingVertex,
		// Token: 0x040067A8 RID: 26536
		ConvolutionHintSgix = 33558,
		// Token: 0x040067A9 RID: 26537
		AsyncMarkerSgix = 33577,
		// Token: 0x040067AA RID: 26538
		PixelTexGenModeSgix = 33579,
		// Token: 0x040067AB RID: 26539
		AsyncHistogramSgix,
		// Token: 0x040067AC RID: 26540
		MaxAsyncHistogramSgix,
		// Token: 0x040067AD RID: 26541
		PixelTextureSgis = 33619,
		// Token: 0x040067AE RID: 26542
		AsyncTexImageSgix = 33628,
		// Token: 0x040067AF RID: 26543
		AsyncDrawPixelsSgix,
		// Token: 0x040067B0 RID: 26544
		AsyncReadPixelsSgix,
		// Token: 0x040067B1 RID: 26545
		MaxAsyncTexImageSgix,
		// Token: 0x040067B2 RID: 26546
		MaxAsyncDrawPixelsSgix,
		// Token: 0x040067B3 RID: 26547
		MaxAsyncReadPixelsSgix,
		// Token: 0x040067B4 RID: 26548
		VertexPreclipSgix = 33774,
		// Token: 0x040067B5 RID: 26549
		VertexPreclipHintSgix,
		// Token: 0x040067B6 RID: 26550
		FragmentLightingSgix = 33792,
		// Token: 0x040067B7 RID: 26551
		FragmentColorMaterialSgix,
		// Token: 0x040067B8 RID: 26552
		FragmentColorMaterialFaceSgix,
		// Token: 0x040067B9 RID: 26553
		FragmentColorMaterialParameterSgix,
		// Token: 0x040067BA RID: 26554
		MaxFragmentLightsSgix,
		// Token: 0x040067BB RID: 26555
		MaxActiveLightsSgix,
		// Token: 0x040067BC RID: 26556
		LightEnvModeSgix = 33799,
		// Token: 0x040067BD RID: 26557
		FragmentLightModelLocalViewerSgix,
		// Token: 0x040067BE RID: 26558
		FragmentLightModelTwoSideSgix,
		// Token: 0x040067BF RID: 26559
		FragmentLightModelAmbientSgix,
		// Token: 0x040067C0 RID: 26560
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x040067C1 RID: 26561
		FragmentLight0Sgix,
		// Token: 0x040067C2 RID: 26562
		PackResampleSgix = 33836,
		// Token: 0x040067C3 RID: 26563
		UnpackResampleSgix,
		// Token: 0x040067C4 RID: 26564
		CurrentFogCoord = 33875,
		// Token: 0x040067C5 RID: 26565
		FogCoordArrayType,
		// Token: 0x040067C6 RID: 26566
		FogCoordArrayStride,
		// Token: 0x040067C7 RID: 26567
		ColorSum = 33880,
		// Token: 0x040067C8 RID: 26568
		CurrentSecondaryColor,
		// Token: 0x040067C9 RID: 26569
		SecondaryColorArraySize,
		// Token: 0x040067CA RID: 26570
		SecondaryColorArrayType,
		// Token: 0x040067CB RID: 26571
		SecondaryColorArrayStride,
		// Token: 0x040067CC RID: 26572
		CurrentRasterSecondaryColor = 33887,
		// Token: 0x040067CD RID: 26573
		AliasedPointSizeRange = 33901,
		// Token: 0x040067CE RID: 26574
		AliasedLineWidthRange,
		// Token: 0x040067CF RID: 26575
		ActiveTexture = 34016,
		// Token: 0x040067D0 RID: 26576
		ClientActiveTexture,
		// Token: 0x040067D1 RID: 26577
		MaxTextureUnits,
		// Token: 0x040067D2 RID: 26578
		TransposeModelviewMatrix,
		// Token: 0x040067D3 RID: 26579
		TransposeProjectionMatrix,
		// Token: 0x040067D4 RID: 26580
		TransposeTextureMatrix,
		// Token: 0x040067D5 RID: 26581
		TransposeColorMatrix,
		// Token: 0x040067D6 RID: 26582
		MaxRenderbufferSize = 34024,
		// Token: 0x040067D7 RID: 26583
		MaxRenderbufferSizeExt = 34024,
		// Token: 0x040067D8 RID: 26584
		TextureCompressionHint = 34031,
		// Token: 0x040067D9 RID: 26585
		TextureBindingRectangle = 34038,
		// Token: 0x040067DA RID: 26586
		MaxRectangleTextureSize = 34040,
		// Token: 0x040067DB RID: 26587
		MaxTextureLodBias = 34045,
		// Token: 0x040067DC RID: 26588
		TextureCubeMap = 34067,
		// Token: 0x040067DD RID: 26589
		TextureBindingCubeMap,
		// Token: 0x040067DE RID: 26590
		MaxCubeMapTextureSize = 34076,
		// Token: 0x040067DF RID: 26591
		PackSubsampleRateSgix = 34208,
		// Token: 0x040067E0 RID: 26592
		UnpackSubsampleRateSgix,
		// Token: 0x040067E1 RID: 26593
		VertexArrayBinding = 34229,
		// Token: 0x040067E2 RID: 26594
		ProgramPointSize = 34370,
		// Token: 0x040067E3 RID: 26595
		DepthClamp = 34383,
		// Token: 0x040067E4 RID: 26596
		NumCompressedTextureFormats = 34466,
		// Token: 0x040067E5 RID: 26597
		CompressedTextureFormats,
		// Token: 0x040067E6 RID: 26598
		NumProgramBinaryFormats = 34814,
		// Token: 0x040067E7 RID: 26599
		ProgramBinaryFormats,
		// Token: 0x040067E8 RID: 26600
		StencilBackFunc,
		// Token: 0x040067E9 RID: 26601
		StencilBackFail,
		// Token: 0x040067EA RID: 26602
		StencilBackPassDepthFail,
		// Token: 0x040067EB RID: 26603
		StencilBackPassDepthPass,
		// Token: 0x040067EC RID: 26604
		RgbaFloatMode = 34848,
		// Token: 0x040067ED RID: 26605
		MaxDrawBuffers = 34852,
		// Token: 0x040067EE RID: 26606
		DrawBuffer0,
		// Token: 0x040067EF RID: 26607
		DrawBuffer1,
		// Token: 0x040067F0 RID: 26608
		DrawBuffer2,
		// Token: 0x040067F1 RID: 26609
		DrawBuffer3,
		// Token: 0x040067F2 RID: 26610
		DrawBuffer4,
		// Token: 0x040067F3 RID: 26611
		DrawBuffer5,
		// Token: 0x040067F4 RID: 26612
		DrawBuffer6,
		// Token: 0x040067F5 RID: 26613
		DrawBuffer7,
		// Token: 0x040067F6 RID: 26614
		DrawBuffer8,
		// Token: 0x040067F7 RID: 26615
		DrawBuffer9,
		// Token: 0x040067F8 RID: 26616
		DrawBuffer10,
		// Token: 0x040067F9 RID: 26617
		DrawBuffer11,
		// Token: 0x040067FA RID: 26618
		DrawBuffer12,
		// Token: 0x040067FB RID: 26619
		DrawBuffer13,
		// Token: 0x040067FC RID: 26620
		DrawBuffer14,
		// Token: 0x040067FD RID: 26621
		DrawBuffer15,
		// Token: 0x040067FE RID: 26622
		BlendEquationAlpha = 34877,
		// Token: 0x040067FF RID: 26623
		TextureCubeMapSeamless = 34895,
		// Token: 0x04006800 RID: 26624
		PointSprite = 34913,
		// Token: 0x04006801 RID: 26625
		MaxVertexAttribs = 34921,
		// Token: 0x04006802 RID: 26626
		MaxTessControlInputComponents = 34924,
		// Token: 0x04006803 RID: 26627
		MaxTessEvaluationInputComponents,
		// Token: 0x04006804 RID: 26628
		MaxTextureCoords = 34929,
		// Token: 0x04006805 RID: 26629
		MaxTextureImageUnits,
		// Token: 0x04006806 RID: 26630
		ArrayBufferBinding = 34964,
		// Token: 0x04006807 RID: 26631
		ElementArrayBufferBinding,
		// Token: 0x04006808 RID: 26632
		VertexArrayBufferBinding,
		// Token: 0x04006809 RID: 26633
		NormalArrayBufferBinding,
		// Token: 0x0400680A RID: 26634
		ColorArrayBufferBinding,
		// Token: 0x0400680B RID: 26635
		IndexArrayBufferBinding,
		// Token: 0x0400680C RID: 26636
		TextureCoordArrayBufferBinding,
		// Token: 0x0400680D RID: 26637
		EdgeFlagArrayBufferBinding,
		// Token: 0x0400680E RID: 26638
		SecondaryColorArrayBufferBinding,
		// Token: 0x0400680F RID: 26639
		FogCoordArrayBufferBinding,
		// Token: 0x04006810 RID: 26640
		WeightArrayBufferBinding,
		// Token: 0x04006811 RID: 26641
		VertexAttribArrayBufferBinding,
		// Token: 0x04006812 RID: 26642
		PixelPackBufferBinding = 35053,
		// Token: 0x04006813 RID: 26643
		PixelUnpackBufferBinding = 35055,
		// Token: 0x04006814 RID: 26644
		MaxDualSourceDrawBuffers = 35068,
		// Token: 0x04006815 RID: 26645
		MaxArrayTextureLayers = 35071,
		// Token: 0x04006816 RID: 26646
		MinProgramTexelOffset = 35076,
		// Token: 0x04006817 RID: 26647
		MaxProgramTexelOffset,
		// Token: 0x04006818 RID: 26648
		SamplerBinding = 35097,
		// Token: 0x04006819 RID: 26649
		ClampVertexColor,
		// Token: 0x0400681A RID: 26650
		ClampFragmentColor,
		// Token: 0x0400681B RID: 26651
		ClampReadColor,
		// Token: 0x0400681C RID: 26652
		MaxVertexUniformBlocks = 35371,
		// Token: 0x0400681D RID: 26653
		MaxGeometryUniformBlocks,
		// Token: 0x0400681E RID: 26654
		MaxFragmentUniformBlocks,
		// Token: 0x0400681F RID: 26655
		MaxCombinedUniformBlocks,
		// Token: 0x04006820 RID: 26656
		MaxUniformBufferBindings,
		// Token: 0x04006821 RID: 26657
		MaxUniformBlockSize,
		// Token: 0x04006822 RID: 26658
		MaxCombinedVertexUniformComponents,
		// Token: 0x04006823 RID: 26659
		MaxCombinedGeometryUniformComponents,
		// Token: 0x04006824 RID: 26660
		MaxCombinedFragmentUniformComponents,
		// Token: 0x04006825 RID: 26661
		UniformBufferOffsetAlignment,
		// Token: 0x04006826 RID: 26662
		MaxFragmentUniformComponents = 35657,
		// Token: 0x04006827 RID: 26663
		MaxVertexUniformComponents,
		// Token: 0x04006828 RID: 26664
		MaxVaryingComponents,
		// Token: 0x04006829 RID: 26665
		MaxVaryingFloats = 35659,
		// Token: 0x0400682A RID: 26666
		MaxVertexTextureImageUnits,
		// Token: 0x0400682B RID: 26667
		MaxCombinedTextureImageUnits,
		// Token: 0x0400682C RID: 26668
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x0400682D RID: 26669
		CurrentProgram = 35725,
		// Token: 0x0400682E RID: 26670
		ImplementationColorReadType = 35738,
		// Token: 0x0400682F RID: 26671
		ImplementationColorReadFormat,
		// Token: 0x04006830 RID: 26672
		TextureBinding1DArray = 35868,
		// Token: 0x04006831 RID: 26673
		TextureBinding2DArray,
		// Token: 0x04006832 RID: 26674
		MaxGeometryTextureImageUnits = 35881,
		// Token: 0x04006833 RID: 26675
		TextureBuffer,
		// Token: 0x04006834 RID: 26676
		MaxTextureBufferSize,
		// Token: 0x04006835 RID: 26677
		TextureBindingBuffer,
		// Token: 0x04006836 RID: 26678
		TextureBufferDataStoreBinding,
		// Token: 0x04006837 RID: 26679
		SampleShading = 35894,
		// Token: 0x04006838 RID: 26680
		MinSampleShadingValue,
		// Token: 0x04006839 RID: 26681
		MaxTransformFeedbackSeparateComponents = 35968,
		// Token: 0x0400683A RID: 26682
		MaxTransformFeedbackInterleavedComponents = 35978,
		// Token: 0x0400683B RID: 26683
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x0400683C RID: 26684
		StencilBackRef = 36003,
		// Token: 0x0400683D RID: 26685
		StencilBackValueMask,
		// Token: 0x0400683E RID: 26686
		StencilBackWritemask,
		// Token: 0x0400683F RID: 26687
		DrawFramebufferBinding,
		// Token: 0x04006840 RID: 26688
		FramebufferBinding = 36006,
		// Token: 0x04006841 RID: 26689
		FramebufferBindingExt = 36006,
		// Token: 0x04006842 RID: 26690
		RenderbufferBinding,
		// Token: 0x04006843 RID: 26691
		RenderbufferBindingExt = 36007,
		// Token: 0x04006844 RID: 26692
		ReadFramebufferBinding = 36010,
		// Token: 0x04006845 RID: 26693
		MaxColorAttachments = 36063,
		// Token: 0x04006846 RID: 26694
		MaxColorAttachmentsExt = 36063,
		// Token: 0x04006847 RID: 26695
		MaxSamples = 36183,
		// Token: 0x04006848 RID: 26696
		FramebufferSrgb = 36281,
		// Token: 0x04006849 RID: 26697
		MaxGeometryVaryingComponents = 36317,
		// Token: 0x0400684A RID: 26698
		MaxVertexVaryingComponents,
		// Token: 0x0400684B RID: 26699
		MaxGeometryUniformComponents,
		// Token: 0x0400684C RID: 26700
		MaxGeometryOutputVertices,
		// Token: 0x0400684D RID: 26701
		MaxGeometryTotalOutputComponents,
		// Token: 0x0400684E RID: 26702
		MaxSubroutines = 36327,
		// Token: 0x0400684F RID: 26703
		MaxSubroutineUniformLocations,
		// Token: 0x04006850 RID: 26704
		ShaderBinaryFormats = 36344,
		// Token: 0x04006851 RID: 26705
		NumShaderBinaryFormats,
		// Token: 0x04006852 RID: 26706
		ShaderCompiler,
		// Token: 0x04006853 RID: 26707
		MaxVertexUniformVectors,
		// Token: 0x04006854 RID: 26708
		MaxVaryingVectors,
		// Token: 0x04006855 RID: 26709
		MaxFragmentUniformVectors,
		// Token: 0x04006856 RID: 26710
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x04006857 RID: 26711
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x04006858 RID: 26712
		TransformFeedbackBufferPaused = 36387,
		// Token: 0x04006859 RID: 26713
		TransformFeedbackBufferActive,
		// Token: 0x0400685A RID: 26714
		TransformFeedbackBinding,
		// Token: 0x0400685B RID: 26715
		Timestamp = 36392,
		// Token: 0x0400685C RID: 26716
		QuadsFollowProvokingVertexConvention = 36428,
		// Token: 0x0400685D RID: 26717
		ProvokingVertex = 36431,
		// Token: 0x0400685E RID: 26718
		SampleMask = 36433,
		// Token: 0x0400685F RID: 26719
		MaxSampleMaskWords = 36441,
		// Token: 0x04006860 RID: 26720
		MaxGeometryShaderInvocations,
		// Token: 0x04006861 RID: 26721
		MinFragmentInterpolationOffset,
		// Token: 0x04006862 RID: 26722
		MaxFragmentInterpolationOffset,
		// Token: 0x04006863 RID: 26723
		FragmentInterpolationOffsetBits,
		// Token: 0x04006864 RID: 26724
		MinProgramTextureGatherOffset,
		// Token: 0x04006865 RID: 26725
		MaxProgramTextureGatherOffset,
		// Token: 0x04006866 RID: 26726
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x04006867 RID: 26727
		MaxVertexStreams,
		// Token: 0x04006868 RID: 26728
		PatchVertices,
		// Token: 0x04006869 RID: 26729
		PatchDefaultInnerLevel,
		// Token: 0x0400686A RID: 26730
		PatchDefaultOuterLevel,
		// Token: 0x0400686B RID: 26731
		MaxPatchVertices = 36477,
		// Token: 0x0400686C RID: 26732
		MaxTessGenLevel,
		// Token: 0x0400686D RID: 26733
		MaxTessControlUniformComponents,
		// Token: 0x0400686E RID: 26734
		MaxTessEvaluationUniformComponents,
		// Token: 0x0400686F RID: 26735
		MaxTessControlTextureImageUnits,
		// Token: 0x04006870 RID: 26736
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x04006871 RID: 26737
		MaxTessControlOutputComponents,
		// Token: 0x04006872 RID: 26738
		MaxTessPatchComponents,
		// Token: 0x04006873 RID: 26739
		MaxTessControlTotalOutputComponents,
		// Token: 0x04006874 RID: 26740
		MaxTessEvaluationOutputComponents,
		// Token: 0x04006875 RID: 26741
		MaxTessControlUniformBlocks = 36489,
		// Token: 0x04006876 RID: 26742
		MaxTessEvaluationUniformBlocks,
		// Token: 0x04006877 RID: 26743
		DrawIndirectBufferBinding = 36675,
		// Token: 0x04006878 RID: 26744
		MaxVertexImageUniforms = 37066,
		// Token: 0x04006879 RID: 26745
		MaxTessControlImageUniforms,
		// Token: 0x0400687A RID: 26746
		MaxTessEvaluationImageUniforms,
		// Token: 0x0400687B RID: 26747
		MaxGeometryImageUniforms,
		// Token: 0x0400687C RID: 26748
		MaxFragmentImageUniforms,
		// Token: 0x0400687D RID: 26749
		MaxCombinedImageUniforms,
		// Token: 0x0400687E RID: 26750
		TextureBinding2DMultisample = 37124,
		// Token: 0x0400687F RID: 26751
		TextureBinding2DMultisampleArray,
		// Token: 0x04006880 RID: 26752
		MaxColorTextureSamples = 37134,
		// Token: 0x04006881 RID: 26753
		MaxDepthTextureSamples,
		// Token: 0x04006882 RID: 26754
		MaxIntegerSamples,
		// Token: 0x04006883 RID: 26755
		MaxVertexOutputComponents = 37154,
		// Token: 0x04006884 RID: 26756
		MaxGeometryInputComponents,
		// Token: 0x04006885 RID: 26757
		MaxGeometryOutputComponents,
		// Token: 0x04006886 RID: 26758
		MaxFragmentInputComponents,
		// Token: 0x04006887 RID: 26759
		MaxComputeImageUniforms = 37309
	}
}
