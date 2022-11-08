using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000359 RID: 857
	public enum GetPName
	{
		// Token: 0x04003415 RID: 13333
		CurrentColor = 2816,
		// Token: 0x04003416 RID: 13334
		CurrentIndex,
		// Token: 0x04003417 RID: 13335
		CurrentNormal,
		// Token: 0x04003418 RID: 13336
		CurrentTextureCoords,
		// Token: 0x04003419 RID: 13337
		CurrentRasterColor,
		// Token: 0x0400341A RID: 13338
		CurrentRasterIndex,
		// Token: 0x0400341B RID: 13339
		CurrentRasterTextureCoords,
		// Token: 0x0400341C RID: 13340
		CurrentRasterPosition,
		// Token: 0x0400341D RID: 13341
		CurrentRasterPositionValid,
		// Token: 0x0400341E RID: 13342
		CurrentRasterDistance,
		// Token: 0x0400341F RID: 13343
		PointSmooth = 2832,
		// Token: 0x04003420 RID: 13344
		PointSize,
		// Token: 0x04003421 RID: 13345
		PointSizeRange,
		// Token: 0x04003422 RID: 13346
		SmoothPointSizeRange = 2834,
		// Token: 0x04003423 RID: 13347
		PointSizeGranularity,
		// Token: 0x04003424 RID: 13348
		SmoothPointSizeGranularity = 2835,
		// Token: 0x04003425 RID: 13349
		LineSmooth = 2848,
		// Token: 0x04003426 RID: 13350
		LineWidth,
		// Token: 0x04003427 RID: 13351
		LineWidthRange,
		// Token: 0x04003428 RID: 13352
		SmoothLineWidthRange = 2850,
		// Token: 0x04003429 RID: 13353
		LineWidthGranularity,
		// Token: 0x0400342A RID: 13354
		SmoothLineWidthGranularity = 2851,
		// Token: 0x0400342B RID: 13355
		LineStipple,
		// Token: 0x0400342C RID: 13356
		LineStipplePattern,
		// Token: 0x0400342D RID: 13357
		LineStippleRepeat,
		// Token: 0x0400342E RID: 13358
		ListMode = 2864,
		// Token: 0x0400342F RID: 13359
		MaxListNesting,
		// Token: 0x04003430 RID: 13360
		ListBase,
		// Token: 0x04003431 RID: 13361
		ListIndex,
		// Token: 0x04003432 RID: 13362
		PolygonMode = 2880,
		// Token: 0x04003433 RID: 13363
		PolygonSmooth,
		// Token: 0x04003434 RID: 13364
		PolygonStipple,
		// Token: 0x04003435 RID: 13365
		EdgeFlag,
		// Token: 0x04003436 RID: 13366
		CullFace,
		// Token: 0x04003437 RID: 13367
		CullFaceMode,
		// Token: 0x04003438 RID: 13368
		FrontFace,
		// Token: 0x04003439 RID: 13369
		Lighting = 2896,
		// Token: 0x0400343A RID: 13370
		LightModelLocalViewer,
		// Token: 0x0400343B RID: 13371
		LightModelTwoSide,
		// Token: 0x0400343C RID: 13372
		LightModelAmbient,
		// Token: 0x0400343D RID: 13373
		ShadeModel,
		// Token: 0x0400343E RID: 13374
		ColorMaterialFace,
		// Token: 0x0400343F RID: 13375
		ColorMaterialParameter,
		// Token: 0x04003440 RID: 13376
		ColorMaterial,
		// Token: 0x04003441 RID: 13377
		Fog = 2912,
		// Token: 0x04003442 RID: 13378
		FogIndex,
		// Token: 0x04003443 RID: 13379
		FogDensity,
		// Token: 0x04003444 RID: 13380
		FogStart,
		// Token: 0x04003445 RID: 13381
		FogEnd,
		// Token: 0x04003446 RID: 13382
		FogMode,
		// Token: 0x04003447 RID: 13383
		FogColor,
		// Token: 0x04003448 RID: 13384
		DepthRange = 2928,
		// Token: 0x04003449 RID: 13385
		DepthTest,
		// Token: 0x0400344A RID: 13386
		DepthWritemask,
		// Token: 0x0400344B RID: 13387
		DepthClearValue,
		// Token: 0x0400344C RID: 13388
		DepthFunc,
		// Token: 0x0400344D RID: 13389
		AccumClearValue = 2944,
		// Token: 0x0400344E RID: 13390
		StencilTest = 2960,
		// Token: 0x0400344F RID: 13391
		StencilClearValue,
		// Token: 0x04003450 RID: 13392
		StencilFunc,
		// Token: 0x04003451 RID: 13393
		StencilValueMask,
		// Token: 0x04003452 RID: 13394
		StencilFail,
		// Token: 0x04003453 RID: 13395
		StencilPassDepthFail,
		// Token: 0x04003454 RID: 13396
		StencilPassDepthPass,
		// Token: 0x04003455 RID: 13397
		StencilRef,
		// Token: 0x04003456 RID: 13398
		StencilWritemask,
		// Token: 0x04003457 RID: 13399
		MatrixMode = 2976,
		// Token: 0x04003458 RID: 13400
		Normalize,
		// Token: 0x04003459 RID: 13401
		Viewport,
		// Token: 0x0400345A RID: 13402
		Modelview0StackDepthExt,
		// Token: 0x0400345B RID: 13403
		ModelviewStackDepth = 2979,
		// Token: 0x0400345C RID: 13404
		ProjectionStackDepth,
		// Token: 0x0400345D RID: 13405
		TextureStackDepth,
		// Token: 0x0400345E RID: 13406
		Modelview0MatrixExt,
		// Token: 0x0400345F RID: 13407
		ModelviewMatrix = 2982,
		// Token: 0x04003460 RID: 13408
		ProjectionMatrix,
		// Token: 0x04003461 RID: 13409
		TextureMatrix,
		// Token: 0x04003462 RID: 13410
		AttribStackDepth = 2992,
		// Token: 0x04003463 RID: 13411
		ClientAttribStackDepth,
		// Token: 0x04003464 RID: 13412
		AlphaTest = 3008,
		// Token: 0x04003465 RID: 13413
		AlphaTestQcom = 3008,
		// Token: 0x04003466 RID: 13414
		AlphaTestFunc,
		// Token: 0x04003467 RID: 13415
		AlphaTestFuncQcom = 3009,
		// Token: 0x04003468 RID: 13416
		AlphaTestRef,
		// Token: 0x04003469 RID: 13417
		AlphaTestRefQcom = 3010,
		// Token: 0x0400346A RID: 13418
		Dither = 3024,
		// Token: 0x0400346B RID: 13419
		BlendDst = 3040,
		// Token: 0x0400346C RID: 13420
		BlendSrc,
		// Token: 0x0400346D RID: 13421
		Blend,
		// Token: 0x0400346E RID: 13422
		LogicOpMode = 3056,
		// Token: 0x0400346F RID: 13423
		IndexLogicOp,
		// Token: 0x04003470 RID: 13424
		LogicOp = 3057,
		// Token: 0x04003471 RID: 13425
		ColorLogicOp,
		// Token: 0x04003472 RID: 13426
		AuxBuffers = 3072,
		// Token: 0x04003473 RID: 13427
		DrawBuffer,
		// Token: 0x04003474 RID: 13428
		DrawBufferExt = 3073,
		// Token: 0x04003475 RID: 13429
		ReadBuffer,
		// Token: 0x04003476 RID: 13430
		ReadBufferExt = 3074,
		// Token: 0x04003477 RID: 13431
		ReadBufferNv = 3074,
		// Token: 0x04003478 RID: 13432
		ScissorBox = 3088,
		// Token: 0x04003479 RID: 13433
		ScissorTest,
		// Token: 0x0400347A RID: 13434
		IndexClearValue = 3104,
		// Token: 0x0400347B RID: 13435
		IndexWritemask,
		// Token: 0x0400347C RID: 13436
		ColorClearValue,
		// Token: 0x0400347D RID: 13437
		ColorWritemask,
		// Token: 0x0400347E RID: 13438
		IndexMode = 3120,
		// Token: 0x0400347F RID: 13439
		RgbaMode,
		// Token: 0x04003480 RID: 13440
		Doublebuffer,
		// Token: 0x04003481 RID: 13441
		Stereo,
		// Token: 0x04003482 RID: 13442
		RenderMode = 3136,
		// Token: 0x04003483 RID: 13443
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04003484 RID: 13444
		PointSmoothHint,
		// Token: 0x04003485 RID: 13445
		LineSmoothHint,
		// Token: 0x04003486 RID: 13446
		PolygonSmoothHint,
		// Token: 0x04003487 RID: 13447
		FogHint,
		// Token: 0x04003488 RID: 13448
		TextureGenS = 3168,
		// Token: 0x04003489 RID: 13449
		TextureGenT,
		// Token: 0x0400348A RID: 13450
		TextureGenR,
		// Token: 0x0400348B RID: 13451
		TextureGenQ,
		// Token: 0x0400348C RID: 13452
		PixelMapIToISize = 3248,
		// Token: 0x0400348D RID: 13453
		PixelMapSToSSize,
		// Token: 0x0400348E RID: 13454
		PixelMapIToRSize,
		// Token: 0x0400348F RID: 13455
		PixelMapIToGSize,
		// Token: 0x04003490 RID: 13456
		PixelMapIToBSize,
		// Token: 0x04003491 RID: 13457
		PixelMapIToASize,
		// Token: 0x04003492 RID: 13458
		PixelMapRToRSize,
		// Token: 0x04003493 RID: 13459
		PixelMapGToGSize,
		// Token: 0x04003494 RID: 13460
		PixelMapBToBSize,
		// Token: 0x04003495 RID: 13461
		PixelMapAToASize,
		// Token: 0x04003496 RID: 13462
		UnpackSwapBytes = 3312,
		// Token: 0x04003497 RID: 13463
		UnpackLsbFirst,
		// Token: 0x04003498 RID: 13464
		UnpackRowLength,
		// Token: 0x04003499 RID: 13465
		UnpackSkipRows,
		// Token: 0x0400349A RID: 13466
		UnpackSkipPixels,
		// Token: 0x0400349B RID: 13467
		UnpackAlignment,
		// Token: 0x0400349C RID: 13468
		PackSwapBytes = 3328,
		// Token: 0x0400349D RID: 13469
		PackLsbFirst,
		// Token: 0x0400349E RID: 13470
		PackRowLength,
		// Token: 0x0400349F RID: 13471
		PackSkipRows,
		// Token: 0x040034A0 RID: 13472
		PackSkipPixels,
		// Token: 0x040034A1 RID: 13473
		PackAlignment,
		// Token: 0x040034A2 RID: 13474
		MapColor = 3344,
		// Token: 0x040034A3 RID: 13475
		MapStencil,
		// Token: 0x040034A4 RID: 13476
		IndexShift,
		// Token: 0x040034A5 RID: 13477
		IndexOffset,
		// Token: 0x040034A6 RID: 13478
		RedScale,
		// Token: 0x040034A7 RID: 13479
		RedBias,
		// Token: 0x040034A8 RID: 13480
		ZoomX,
		// Token: 0x040034A9 RID: 13481
		ZoomY,
		// Token: 0x040034AA RID: 13482
		GreenScale,
		// Token: 0x040034AB RID: 13483
		GreenBias,
		// Token: 0x040034AC RID: 13484
		BlueScale,
		// Token: 0x040034AD RID: 13485
		BlueBias,
		// Token: 0x040034AE RID: 13486
		AlphaScale,
		// Token: 0x040034AF RID: 13487
		AlphaBias,
		// Token: 0x040034B0 RID: 13488
		DepthScale,
		// Token: 0x040034B1 RID: 13489
		DepthBias,
		// Token: 0x040034B2 RID: 13490
		MaxEvalOrder = 3376,
		// Token: 0x040034B3 RID: 13491
		MaxLights,
		// Token: 0x040034B4 RID: 13492
		MaxClipDistances,
		// Token: 0x040034B5 RID: 13493
		MaxClipPlanes = 3378,
		// Token: 0x040034B6 RID: 13494
		MaxTextureSize,
		// Token: 0x040034B7 RID: 13495
		MaxPixelMapTable,
		// Token: 0x040034B8 RID: 13496
		MaxAttribStackDepth,
		// Token: 0x040034B9 RID: 13497
		MaxModelviewStackDepth,
		// Token: 0x040034BA RID: 13498
		MaxNameStackDepth,
		// Token: 0x040034BB RID: 13499
		MaxProjectionStackDepth,
		// Token: 0x040034BC RID: 13500
		MaxTextureStackDepth,
		// Token: 0x040034BD RID: 13501
		MaxViewportDims,
		// Token: 0x040034BE RID: 13502
		MaxClientAttribStackDepth,
		// Token: 0x040034BF RID: 13503
		SubpixelBits = 3408,
		// Token: 0x040034C0 RID: 13504
		IndexBits,
		// Token: 0x040034C1 RID: 13505
		RedBits,
		// Token: 0x040034C2 RID: 13506
		GreenBits,
		// Token: 0x040034C3 RID: 13507
		BlueBits,
		// Token: 0x040034C4 RID: 13508
		AlphaBits,
		// Token: 0x040034C5 RID: 13509
		DepthBits,
		// Token: 0x040034C6 RID: 13510
		StencilBits,
		// Token: 0x040034C7 RID: 13511
		AccumRedBits,
		// Token: 0x040034C8 RID: 13512
		AccumGreenBits,
		// Token: 0x040034C9 RID: 13513
		AccumBlueBits,
		// Token: 0x040034CA RID: 13514
		AccumAlphaBits,
		// Token: 0x040034CB RID: 13515
		NameStackDepth = 3440,
		// Token: 0x040034CC RID: 13516
		AutoNormal = 3456,
		// Token: 0x040034CD RID: 13517
		Map1Color4 = 3472,
		// Token: 0x040034CE RID: 13518
		Map1Index,
		// Token: 0x040034CF RID: 13519
		Map1Normal,
		// Token: 0x040034D0 RID: 13520
		Map1TextureCoord1,
		// Token: 0x040034D1 RID: 13521
		Map1TextureCoord2,
		// Token: 0x040034D2 RID: 13522
		Map1TextureCoord3,
		// Token: 0x040034D3 RID: 13523
		Map1TextureCoord4,
		// Token: 0x040034D4 RID: 13524
		Map1Vertex3,
		// Token: 0x040034D5 RID: 13525
		Map1Vertex4,
		// Token: 0x040034D6 RID: 13526
		Map2Color4 = 3504,
		// Token: 0x040034D7 RID: 13527
		Map2Index,
		// Token: 0x040034D8 RID: 13528
		Map2Normal,
		// Token: 0x040034D9 RID: 13529
		Map2TextureCoord1,
		// Token: 0x040034DA RID: 13530
		Map2TextureCoord2,
		// Token: 0x040034DB RID: 13531
		Map2TextureCoord3,
		// Token: 0x040034DC RID: 13532
		Map2TextureCoord4,
		// Token: 0x040034DD RID: 13533
		Map2Vertex3,
		// Token: 0x040034DE RID: 13534
		Map2Vertex4,
		// Token: 0x040034DF RID: 13535
		Map1GridDomain = 3536,
		// Token: 0x040034E0 RID: 13536
		Map1GridSegments,
		// Token: 0x040034E1 RID: 13537
		Map2GridDomain,
		// Token: 0x040034E2 RID: 13538
		Map2GridSegments,
		// Token: 0x040034E3 RID: 13539
		Texture1D = 3552,
		// Token: 0x040034E4 RID: 13540
		Texture2D,
		// Token: 0x040034E5 RID: 13541
		FeedbackBufferSize = 3569,
		// Token: 0x040034E6 RID: 13542
		FeedbackBufferType,
		// Token: 0x040034E7 RID: 13543
		SelectionBufferSize = 3572,
		// Token: 0x040034E8 RID: 13544
		PolygonOffsetUnits = 10752,
		// Token: 0x040034E9 RID: 13545
		PolygonOffsetPoint,
		// Token: 0x040034EA RID: 13546
		PolygonOffsetLine,
		// Token: 0x040034EB RID: 13547
		ClipPlane0 = 12288,
		// Token: 0x040034EC RID: 13548
		ClipPlane1,
		// Token: 0x040034ED RID: 13549
		ClipPlane2,
		// Token: 0x040034EE RID: 13550
		ClipPlane3,
		// Token: 0x040034EF RID: 13551
		ClipPlane4,
		// Token: 0x040034F0 RID: 13552
		ClipPlane5,
		// Token: 0x040034F1 RID: 13553
		Light0 = 16384,
		// Token: 0x040034F2 RID: 13554
		Light1,
		// Token: 0x040034F3 RID: 13555
		Light2,
		// Token: 0x040034F4 RID: 13556
		Light3,
		// Token: 0x040034F5 RID: 13557
		Light4,
		// Token: 0x040034F6 RID: 13558
		Light5,
		// Token: 0x040034F7 RID: 13559
		Light6,
		// Token: 0x040034F8 RID: 13560
		Light7,
		// Token: 0x040034F9 RID: 13561
		BlendColorExt = 32773,
		// Token: 0x040034FA RID: 13562
		BlendEquationExt = 32777,
		// Token: 0x040034FB RID: 13563
		BlendEquationRgb = 32777,
		// Token: 0x040034FC RID: 13564
		PackCmykHintExt = 32782,
		// Token: 0x040034FD RID: 13565
		UnpackCmykHintExt,
		// Token: 0x040034FE RID: 13566
		Convolution1DExt,
		// Token: 0x040034FF RID: 13567
		Convolution2DExt,
		// Token: 0x04003500 RID: 13568
		Separable2DExt,
		// Token: 0x04003501 RID: 13569
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x04003502 RID: 13570
		PostConvolutionGreenScaleExt,
		// Token: 0x04003503 RID: 13571
		PostConvolutionBlueScaleExt,
		// Token: 0x04003504 RID: 13572
		PostConvolutionAlphaScaleExt,
		// Token: 0x04003505 RID: 13573
		PostConvolutionRedBiasExt,
		// Token: 0x04003506 RID: 13574
		PostConvolutionGreenBiasExt,
		// Token: 0x04003507 RID: 13575
		PostConvolutionBlueBiasExt,
		// Token: 0x04003508 RID: 13576
		PostConvolutionAlphaBiasExt,
		// Token: 0x04003509 RID: 13577
		HistogramExt,
		// Token: 0x0400350A RID: 13578
		MinmaxExt = 32814,
		// Token: 0x0400350B RID: 13579
		PolygonOffsetFill = 32823,
		// Token: 0x0400350C RID: 13580
		PolygonOffsetFactor,
		// Token: 0x0400350D RID: 13581
		PolygonOffsetBiasExt,
		// Token: 0x0400350E RID: 13582
		RescaleNormalExt,
		// Token: 0x0400350F RID: 13583
		TextureBinding1D = 32872,
		// Token: 0x04003510 RID: 13584
		TextureBinding2D,
		// Token: 0x04003511 RID: 13585
		Texture3DBindingExt,
		// Token: 0x04003512 RID: 13586
		TextureBinding3D = 32874,
		// Token: 0x04003513 RID: 13587
		PackSkipImagesExt,
		// Token: 0x04003514 RID: 13588
		PackImageHeightExt,
		// Token: 0x04003515 RID: 13589
		UnpackSkipImagesExt,
		// Token: 0x04003516 RID: 13590
		UnpackImageHeightExt,
		// Token: 0x04003517 RID: 13591
		Texture3DExt,
		// Token: 0x04003518 RID: 13592
		Max3DTextureSize = 32883,
		// Token: 0x04003519 RID: 13593
		Max3DTextureSizeExt = 32883,
		// Token: 0x0400351A RID: 13594
		VertexArray,
		// Token: 0x0400351B RID: 13595
		NormalArray,
		// Token: 0x0400351C RID: 13596
		ColorArray,
		// Token: 0x0400351D RID: 13597
		IndexArray,
		// Token: 0x0400351E RID: 13598
		TextureCoordArray,
		// Token: 0x0400351F RID: 13599
		EdgeFlagArray,
		// Token: 0x04003520 RID: 13600
		VertexArraySize,
		// Token: 0x04003521 RID: 13601
		VertexArrayType,
		// Token: 0x04003522 RID: 13602
		VertexArrayStride,
		// Token: 0x04003523 RID: 13603
		VertexArrayCountExt,
		// Token: 0x04003524 RID: 13604
		NormalArrayType,
		// Token: 0x04003525 RID: 13605
		NormalArrayStride,
		// Token: 0x04003526 RID: 13606
		NormalArrayCountExt,
		// Token: 0x04003527 RID: 13607
		ColorArraySize,
		// Token: 0x04003528 RID: 13608
		ColorArrayType,
		// Token: 0x04003529 RID: 13609
		ColorArrayStride,
		// Token: 0x0400352A RID: 13610
		ColorArrayCountExt,
		// Token: 0x0400352B RID: 13611
		IndexArrayType,
		// Token: 0x0400352C RID: 13612
		IndexArrayStride,
		// Token: 0x0400352D RID: 13613
		IndexArrayCountExt,
		// Token: 0x0400352E RID: 13614
		TextureCoordArraySize,
		// Token: 0x0400352F RID: 13615
		TextureCoordArrayType,
		// Token: 0x04003530 RID: 13616
		TextureCoordArrayStride,
		// Token: 0x04003531 RID: 13617
		TextureCoordArrayCountExt,
		// Token: 0x04003532 RID: 13618
		EdgeFlagArrayStride,
		// Token: 0x04003533 RID: 13619
		EdgeFlagArrayCountExt,
		// Token: 0x04003534 RID: 13620
		InterlaceSgix = 32916,
		// Token: 0x04003535 RID: 13621
		DetailTexture2DBindingSgis = 32918,
		// Token: 0x04003536 RID: 13622
		Multisample = 32925,
		// Token: 0x04003537 RID: 13623
		MultisampleSgis = 32925,
		// Token: 0x04003538 RID: 13624
		SampleAlphaToCoverage,
		// Token: 0x04003539 RID: 13625
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x0400353A RID: 13626
		SampleAlphaToOne,
		// Token: 0x0400353B RID: 13627
		SampleAlphaToOneSgis = 32927,
		// Token: 0x0400353C RID: 13628
		SampleCoverage,
		// Token: 0x0400353D RID: 13629
		SampleMaskSgis = 32928,
		// Token: 0x0400353E RID: 13630
		SampleBuffers = 32936,
		// Token: 0x0400353F RID: 13631
		SampleBuffersSgis = 32936,
		// Token: 0x04003540 RID: 13632
		Samples,
		// Token: 0x04003541 RID: 13633
		SamplesSgis = 32937,
		// Token: 0x04003542 RID: 13634
		SampleCoverageValue,
		// Token: 0x04003543 RID: 13635
		SampleMaskValueSgis = 32938,
		// Token: 0x04003544 RID: 13636
		SampleCoverageInvert,
		// Token: 0x04003545 RID: 13637
		SampleMaskInvertSgis = 32939,
		// Token: 0x04003546 RID: 13638
		SamplePatternSgis,
		// Token: 0x04003547 RID: 13639
		ColorMatrixSgi = 32945,
		// Token: 0x04003548 RID: 13640
		ColorMatrixStackDepthSgi,
		// Token: 0x04003549 RID: 13641
		MaxColorMatrixStackDepthSgi,
		// Token: 0x0400354A RID: 13642
		PostColorMatrixRedScaleSgi,
		// Token: 0x0400354B RID: 13643
		PostColorMatrixGreenScaleSgi,
		// Token: 0x0400354C RID: 13644
		PostColorMatrixBlueScaleSgi,
		// Token: 0x0400354D RID: 13645
		PostColorMatrixAlphaScaleSgi,
		// Token: 0x0400354E RID: 13646
		PostColorMatrixRedBiasSgi,
		// Token: 0x0400354F RID: 13647
		PostColorMatrixGreenBiasSgi,
		// Token: 0x04003550 RID: 13648
		PostColorMatrixBlueBiasSgi,
		// Token: 0x04003551 RID: 13649
		PostColorMatrixAlphaBiasSgi,
		// Token: 0x04003552 RID: 13650
		TextureColorTableSgi,
		// Token: 0x04003553 RID: 13651
		BlendDstRgb = 32968,
		// Token: 0x04003554 RID: 13652
		BlendSrcRgb,
		// Token: 0x04003555 RID: 13653
		BlendDstAlpha,
		// Token: 0x04003556 RID: 13654
		BlendSrcAlpha,
		// Token: 0x04003557 RID: 13655
		ColorTableSgi = 32976,
		// Token: 0x04003558 RID: 13656
		PostConvolutionColorTableSgi,
		// Token: 0x04003559 RID: 13657
		PostColorMatrixColorTableSgi,
		// Token: 0x0400355A RID: 13658
		MaxElementsVertices = 33000,
		// Token: 0x0400355B RID: 13659
		MaxElementsIndices,
		// Token: 0x0400355C RID: 13660
		PointSizeMin = 33062,
		// Token: 0x0400355D RID: 13661
		PointSizeMinSgis = 33062,
		// Token: 0x0400355E RID: 13662
		PointSizeMax,
		// Token: 0x0400355F RID: 13663
		PointSizeMaxSgis = 33063,
		// Token: 0x04003560 RID: 13664
		PointFadeThresholdSize,
		// Token: 0x04003561 RID: 13665
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x04003562 RID: 13666
		DistanceAttenuationSgis,
		// Token: 0x04003563 RID: 13667
		PointDistanceAttenuation = 33065,
		// Token: 0x04003564 RID: 13668
		FogFuncPointsSgis = 33067,
		// Token: 0x04003565 RID: 13669
		MaxFogFuncPointsSgis,
		// Token: 0x04003566 RID: 13670
		PackSkipVolumesSgis = 33072,
		// Token: 0x04003567 RID: 13671
		PackImageDepthSgis,
		// Token: 0x04003568 RID: 13672
		UnpackSkipVolumesSgis,
		// Token: 0x04003569 RID: 13673
		UnpackImageDepthSgis,
		// Token: 0x0400356A RID: 13674
		Texture4DSgis,
		// Token: 0x0400356B RID: 13675
		Max4DTextureSizeSgis = 33080,
		// Token: 0x0400356C RID: 13676
		PixelTexGenSgix,
		// Token: 0x0400356D RID: 13677
		PixelTileBestAlignmentSgix = 33086,
		// Token: 0x0400356E RID: 13678
		PixelTileCacheIncrementSgix,
		// Token: 0x0400356F RID: 13679
		PixelTileWidthSgix,
		// Token: 0x04003570 RID: 13680
		PixelTileHeightSgix,
		// Token: 0x04003571 RID: 13681
		PixelTileGridWidthSgix,
		// Token: 0x04003572 RID: 13682
		PixelTileGridHeightSgix,
		// Token: 0x04003573 RID: 13683
		PixelTileGridDepthSgix,
		// Token: 0x04003574 RID: 13684
		PixelTileCacheSizeSgix,
		// Token: 0x04003575 RID: 13685
		SpriteSgix = 33096,
		// Token: 0x04003576 RID: 13686
		SpriteModeSgix,
		// Token: 0x04003577 RID: 13687
		SpriteAxisSgix,
		// Token: 0x04003578 RID: 13688
		SpriteTranslationSgix,
		// Token: 0x04003579 RID: 13689
		Texture4DBindingSgis = 33103,
		// Token: 0x0400357A RID: 13690
		MaxClipmapDepthSgix = 33143,
		// Token: 0x0400357B RID: 13691
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400357C RID: 13692
		PostTextureFilterBiasRangeSgix = 33147,
		// Token: 0x0400357D RID: 13693
		PostTextureFilterScaleRangeSgix,
		// Token: 0x0400357E RID: 13694
		ReferencePlaneSgix,
		// Token: 0x0400357F RID: 13695
		ReferencePlaneEquationSgix,
		// Token: 0x04003580 RID: 13696
		IrInstrument1Sgix,
		// Token: 0x04003581 RID: 13697
		InstrumentMeasurementsSgix = 33153,
		// Token: 0x04003582 RID: 13698
		CalligraphicFragmentSgix = 33155,
		// Token: 0x04003583 RID: 13699
		FramezoomSgix = 33163,
		// Token: 0x04003584 RID: 13700
		FramezoomFactorSgix,
		// Token: 0x04003585 RID: 13701
		MaxFramezoomFactorSgix,
		// Token: 0x04003586 RID: 13702
		GenerateMipmapHint = 33170,
		// Token: 0x04003587 RID: 13703
		GenerateMipmapHintSgis = 33170,
		// Token: 0x04003588 RID: 13704
		DeformationsMaskSgix = 33174,
		// Token: 0x04003589 RID: 13705
		FogOffsetSgix = 33176,
		// Token: 0x0400358A RID: 13706
		FogOffsetValueSgix,
		// Token: 0x0400358B RID: 13707
		LightModelColorControl = 33272,
		// Token: 0x0400358C RID: 13708
		SharedTexturePaletteExt = 33275,
		// Token: 0x0400358D RID: 13709
		MajorVersion = 33307,
		// Token: 0x0400358E RID: 13710
		MinorVersion,
		// Token: 0x0400358F RID: 13711
		NumExtensions,
		// Token: 0x04003590 RID: 13712
		ContextFlags,
		// Token: 0x04003591 RID: 13713
		ProgramPipelineBinding = 33370,
		// Token: 0x04003592 RID: 13714
		MaxViewports,
		// Token: 0x04003593 RID: 13715
		ViewportSubpixelBits,
		// Token: 0x04003594 RID: 13716
		ViewportBoundsRange,
		// Token: 0x04003595 RID: 13717
		LayerProvokingVertex,
		// Token: 0x04003596 RID: 13718
		ViewportIndexProvokingVertex,
		// Token: 0x04003597 RID: 13719
		ConvolutionHintSgix = 33558,
		// Token: 0x04003598 RID: 13720
		AsyncMarkerSgix = 33577,
		// Token: 0x04003599 RID: 13721
		PixelTexGenModeSgix = 33579,
		// Token: 0x0400359A RID: 13722
		AsyncHistogramSgix,
		// Token: 0x0400359B RID: 13723
		MaxAsyncHistogramSgix,
		// Token: 0x0400359C RID: 13724
		PixelTextureSgis = 33619,
		// Token: 0x0400359D RID: 13725
		AsyncTexImageSgix = 33628,
		// Token: 0x0400359E RID: 13726
		AsyncDrawPixelsSgix,
		// Token: 0x0400359F RID: 13727
		AsyncReadPixelsSgix,
		// Token: 0x040035A0 RID: 13728
		MaxAsyncTexImageSgix,
		// Token: 0x040035A1 RID: 13729
		MaxAsyncDrawPixelsSgix,
		// Token: 0x040035A2 RID: 13730
		MaxAsyncReadPixelsSgix,
		// Token: 0x040035A3 RID: 13731
		VertexPreclipSgix = 33774,
		// Token: 0x040035A4 RID: 13732
		VertexPreclipHintSgix,
		// Token: 0x040035A5 RID: 13733
		FragmentLightingSgix = 33792,
		// Token: 0x040035A6 RID: 13734
		FragmentColorMaterialSgix,
		// Token: 0x040035A7 RID: 13735
		FragmentColorMaterialFaceSgix,
		// Token: 0x040035A8 RID: 13736
		FragmentColorMaterialParameterSgix,
		// Token: 0x040035A9 RID: 13737
		MaxFragmentLightsSgix,
		// Token: 0x040035AA RID: 13738
		MaxActiveLightsSgix,
		// Token: 0x040035AB RID: 13739
		LightEnvModeSgix = 33799,
		// Token: 0x040035AC RID: 13740
		FragmentLightModelLocalViewerSgix,
		// Token: 0x040035AD RID: 13741
		FragmentLightModelTwoSideSgix,
		// Token: 0x040035AE RID: 13742
		FragmentLightModelAmbientSgix,
		// Token: 0x040035AF RID: 13743
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x040035B0 RID: 13744
		FragmentLight0Sgix,
		// Token: 0x040035B1 RID: 13745
		PackResampleSgix = 33836,
		// Token: 0x040035B2 RID: 13746
		UnpackResampleSgix,
		// Token: 0x040035B3 RID: 13747
		CurrentFogCoord = 33875,
		// Token: 0x040035B4 RID: 13748
		FogCoordArrayType,
		// Token: 0x040035B5 RID: 13749
		FogCoordArrayStride,
		// Token: 0x040035B6 RID: 13750
		ColorSum = 33880,
		// Token: 0x040035B7 RID: 13751
		CurrentSecondaryColor,
		// Token: 0x040035B8 RID: 13752
		SecondaryColorArraySize,
		// Token: 0x040035B9 RID: 13753
		SecondaryColorArrayType,
		// Token: 0x040035BA RID: 13754
		SecondaryColorArrayStride,
		// Token: 0x040035BB RID: 13755
		CurrentRasterSecondaryColor = 33887,
		// Token: 0x040035BC RID: 13756
		AliasedPointSizeRange = 33901,
		// Token: 0x040035BD RID: 13757
		AliasedLineWidthRange,
		// Token: 0x040035BE RID: 13758
		ActiveTexture = 34016,
		// Token: 0x040035BF RID: 13759
		ClientActiveTexture,
		// Token: 0x040035C0 RID: 13760
		MaxTextureUnits,
		// Token: 0x040035C1 RID: 13761
		TransposeModelviewMatrix,
		// Token: 0x040035C2 RID: 13762
		TransposeProjectionMatrix,
		// Token: 0x040035C3 RID: 13763
		TransposeTextureMatrix,
		// Token: 0x040035C4 RID: 13764
		TransposeColorMatrix,
		// Token: 0x040035C5 RID: 13765
		MaxRenderbufferSize = 34024,
		// Token: 0x040035C6 RID: 13766
		MaxRenderbufferSizeExt = 34024,
		// Token: 0x040035C7 RID: 13767
		TextureCompressionHint = 34031,
		// Token: 0x040035C8 RID: 13768
		TextureBindingRectangle = 34038,
		// Token: 0x040035C9 RID: 13769
		MaxRectangleTextureSize = 34040,
		// Token: 0x040035CA RID: 13770
		MaxTextureLodBias = 34045,
		// Token: 0x040035CB RID: 13771
		TextureCubeMap = 34067,
		// Token: 0x040035CC RID: 13772
		TextureBindingCubeMap,
		// Token: 0x040035CD RID: 13773
		MaxCubeMapTextureSize = 34076,
		// Token: 0x040035CE RID: 13774
		PackSubsampleRateSgix = 34208,
		// Token: 0x040035CF RID: 13775
		UnpackSubsampleRateSgix,
		// Token: 0x040035D0 RID: 13776
		VertexArrayBinding = 34229,
		// Token: 0x040035D1 RID: 13777
		ProgramPointSize = 34370,
		// Token: 0x040035D2 RID: 13778
		DepthClamp = 34383,
		// Token: 0x040035D3 RID: 13779
		NumCompressedTextureFormats = 34466,
		// Token: 0x040035D4 RID: 13780
		CompressedTextureFormats,
		// Token: 0x040035D5 RID: 13781
		NumProgramBinaryFormats = 34814,
		// Token: 0x040035D6 RID: 13782
		ProgramBinaryFormats,
		// Token: 0x040035D7 RID: 13783
		StencilBackFunc,
		// Token: 0x040035D8 RID: 13784
		StencilBackFail,
		// Token: 0x040035D9 RID: 13785
		StencilBackPassDepthFail,
		// Token: 0x040035DA RID: 13786
		StencilBackPassDepthPass,
		// Token: 0x040035DB RID: 13787
		RgbaFloatMode = 34848,
		// Token: 0x040035DC RID: 13788
		MaxDrawBuffers = 34852,
		// Token: 0x040035DD RID: 13789
		DrawBuffer0,
		// Token: 0x040035DE RID: 13790
		DrawBuffer1,
		// Token: 0x040035DF RID: 13791
		DrawBuffer2,
		// Token: 0x040035E0 RID: 13792
		DrawBuffer3,
		// Token: 0x040035E1 RID: 13793
		DrawBuffer4,
		// Token: 0x040035E2 RID: 13794
		DrawBuffer5,
		// Token: 0x040035E3 RID: 13795
		DrawBuffer6,
		// Token: 0x040035E4 RID: 13796
		DrawBuffer7,
		// Token: 0x040035E5 RID: 13797
		DrawBuffer8,
		// Token: 0x040035E6 RID: 13798
		DrawBuffer9,
		// Token: 0x040035E7 RID: 13799
		DrawBuffer10,
		// Token: 0x040035E8 RID: 13800
		DrawBuffer11,
		// Token: 0x040035E9 RID: 13801
		DrawBuffer12,
		// Token: 0x040035EA RID: 13802
		DrawBuffer13,
		// Token: 0x040035EB RID: 13803
		DrawBuffer14,
		// Token: 0x040035EC RID: 13804
		DrawBuffer15,
		// Token: 0x040035ED RID: 13805
		BlendEquationAlpha = 34877,
		// Token: 0x040035EE RID: 13806
		TextureCubeMapSeamless = 34895,
		// Token: 0x040035EF RID: 13807
		PointSprite = 34913,
		// Token: 0x040035F0 RID: 13808
		MaxVertexAttribs = 34921,
		// Token: 0x040035F1 RID: 13809
		MaxTessControlInputComponents = 34924,
		// Token: 0x040035F2 RID: 13810
		MaxTessEvaluationInputComponents,
		// Token: 0x040035F3 RID: 13811
		MaxTextureCoords = 34929,
		// Token: 0x040035F4 RID: 13812
		MaxTextureImageUnits,
		// Token: 0x040035F5 RID: 13813
		ArrayBufferBinding = 34964,
		// Token: 0x040035F6 RID: 13814
		ElementArrayBufferBinding,
		// Token: 0x040035F7 RID: 13815
		VertexArrayBufferBinding,
		// Token: 0x040035F8 RID: 13816
		NormalArrayBufferBinding,
		// Token: 0x040035F9 RID: 13817
		ColorArrayBufferBinding,
		// Token: 0x040035FA RID: 13818
		IndexArrayBufferBinding,
		// Token: 0x040035FB RID: 13819
		TextureCoordArrayBufferBinding,
		// Token: 0x040035FC RID: 13820
		EdgeFlagArrayBufferBinding,
		// Token: 0x040035FD RID: 13821
		SecondaryColorArrayBufferBinding,
		// Token: 0x040035FE RID: 13822
		FogCoordArrayBufferBinding,
		// Token: 0x040035FF RID: 13823
		WeightArrayBufferBinding,
		// Token: 0x04003600 RID: 13824
		VertexAttribArrayBufferBinding,
		// Token: 0x04003601 RID: 13825
		PixelPackBufferBinding = 35053,
		// Token: 0x04003602 RID: 13826
		PixelUnpackBufferBinding = 35055,
		// Token: 0x04003603 RID: 13827
		MaxDualSourceDrawBuffers = 35068,
		// Token: 0x04003604 RID: 13828
		MaxArrayTextureLayers = 35071,
		// Token: 0x04003605 RID: 13829
		MinProgramTexelOffset = 35076,
		// Token: 0x04003606 RID: 13830
		MaxProgramTexelOffset,
		// Token: 0x04003607 RID: 13831
		SamplerBinding = 35097,
		// Token: 0x04003608 RID: 13832
		ClampVertexColor,
		// Token: 0x04003609 RID: 13833
		ClampFragmentColor,
		// Token: 0x0400360A RID: 13834
		ClampReadColor,
		// Token: 0x0400360B RID: 13835
		MaxVertexUniformBlocks = 35371,
		// Token: 0x0400360C RID: 13836
		MaxGeometryUniformBlocks,
		// Token: 0x0400360D RID: 13837
		MaxFragmentUniformBlocks,
		// Token: 0x0400360E RID: 13838
		MaxCombinedUniformBlocks,
		// Token: 0x0400360F RID: 13839
		MaxUniformBufferBindings,
		// Token: 0x04003610 RID: 13840
		MaxUniformBlockSize,
		// Token: 0x04003611 RID: 13841
		MaxCombinedVertexUniformComponents,
		// Token: 0x04003612 RID: 13842
		MaxCombinedGeometryUniformComponents,
		// Token: 0x04003613 RID: 13843
		MaxCombinedFragmentUniformComponents,
		// Token: 0x04003614 RID: 13844
		UniformBufferOffsetAlignment,
		// Token: 0x04003615 RID: 13845
		MaxFragmentUniformComponents = 35657,
		// Token: 0x04003616 RID: 13846
		MaxVertexUniformComponents,
		// Token: 0x04003617 RID: 13847
		MaxVaryingComponents,
		// Token: 0x04003618 RID: 13848
		MaxVaryingFloats = 35659,
		// Token: 0x04003619 RID: 13849
		MaxVertexTextureImageUnits,
		// Token: 0x0400361A RID: 13850
		MaxCombinedTextureImageUnits,
		// Token: 0x0400361B RID: 13851
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x0400361C RID: 13852
		CurrentProgram = 35725,
		// Token: 0x0400361D RID: 13853
		ImplementationColorReadType = 35738,
		// Token: 0x0400361E RID: 13854
		ImplementationColorReadFormat,
		// Token: 0x0400361F RID: 13855
		TextureBinding1DArray = 35868,
		// Token: 0x04003620 RID: 13856
		TextureBinding2DArray,
		// Token: 0x04003621 RID: 13857
		MaxGeometryTextureImageUnits = 35881,
		// Token: 0x04003622 RID: 13858
		TextureBuffer,
		// Token: 0x04003623 RID: 13859
		MaxTextureBufferSize,
		// Token: 0x04003624 RID: 13860
		TextureBindingBuffer,
		// Token: 0x04003625 RID: 13861
		TextureBufferDataStoreBinding,
		// Token: 0x04003626 RID: 13862
		SampleShading = 35894,
		// Token: 0x04003627 RID: 13863
		MinSampleShadingValue,
		// Token: 0x04003628 RID: 13864
		MaxTransformFeedbackSeparateComponents = 35968,
		// Token: 0x04003629 RID: 13865
		MaxTransformFeedbackInterleavedComponents = 35978,
		// Token: 0x0400362A RID: 13866
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x0400362B RID: 13867
		StencilBackRef = 36003,
		// Token: 0x0400362C RID: 13868
		StencilBackValueMask,
		// Token: 0x0400362D RID: 13869
		StencilBackWritemask,
		// Token: 0x0400362E RID: 13870
		DrawFramebufferBinding,
		// Token: 0x0400362F RID: 13871
		FramebufferBinding = 36006,
		// Token: 0x04003630 RID: 13872
		FramebufferBindingExt = 36006,
		// Token: 0x04003631 RID: 13873
		RenderbufferBinding,
		// Token: 0x04003632 RID: 13874
		RenderbufferBindingExt = 36007,
		// Token: 0x04003633 RID: 13875
		ReadFramebufferBinding = 36010,
		// Token: 0x04003634 RID: 13876
		MaxColorAttachments = 36063,
		// Token: 0x04003635 RID: 13877
		MaxColorAttachmentsExt = 36063,
		// Token: 0x04003636 RID: 13878
		MaxSamples = 36183,
		// Token: 0x04003637 RID: 13879
		FramebufferSrgb = 36281,
		// Token: 0x04003638 RID: 13880
		MaxGeometryVaryingComponents = 36317,
		// Token: 0x04003639 RID: 13881
		MaxVertexVaryingComponents,
		// Token: 0x0400363A RID: 13882
		MaxGeometryUniformComponents,
		// Token: 0x0400363B RID: 13883
		MaxGeometryOutputVertices,
		// Token: 0x0400363C RID: 13884
		MaxGeometryTotalOutputComponents,
		// Token: 0x0400363D RID: 13885
		MaxSubroutines = 36327,
		// Token: 0x0400363E RID: 13886
		MaxSubroutineUniformLocations,
		// Token: 0x0400363F RID: 13887
		ShaderBinaryFormats = 36344,
		// Token: 0x04003640 RID: 13888
		NumShaderBinaryFormats,
		// Token: 0x04003641 RID: 13889
		ShaderCompiler,
		// Token: 0x04003642 RID: 13890
		MaxVertexUniformVectors,
		// Token: 0x04003643 RID: 13891
		MaxVaryingVectors,
		// Token: 0x04003644 RID: 13892
		MaxFragmentUniformVectors,
		// Token: 0x04003645 RID: 13893
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x04003646 RID: 13894
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x04003647 RID: 13895
		TransformFeedbackBufferPaused = 36387,
		// Token: 0x04003648 RID: 13896
		TransformFeedbackBufferActive,
		// Token: 0x04003649 RID: 13897
		TransformFeedbackBinding,
		// Token: 0x0400364A RID: 13898
		Timestamp = 36392,
		// Token: 0x0400364B RID: 13899
		QuadsFollowProvokingVertexConvention = 36428,
		// Token: 0x0400364C RID: 13900
		ProvokingVertex = 36431,
		// Token: 0x0400364D RID: 13901
		SampleMask = 36433,
		// Token: 0x0400364E RID: 13902
		MaxSampleMaskWords = 36441,
		// Token: 0x0400364F RID: 13903
		MaxGeometryShaderInvocations,
		// Token: 0x04003650 RID: 13904
		MinFragmentInterpolationOffset,
		// Token: 0x04003651 RID: 13905
		MaxFragmentInterpolationOffset,
		// Token: 0x04003652 RID: 13906
		FragmentInterpolationOffsetBits,
		// Token: 0x04003653 RID: 13907
		MinProgramTextureGatherOffset,
		// Token: 0x04003654 RID: 13908
		MaxProgramTextureGatherOffset,
		// Token: 0x04003655 RID: 13909
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x04003656 RID: 13910
		MaxVertexStreams,
		// Token: 0x04003657 RID: 13911
		PatchVertices,
		// Token: 0x04003658 RID: 13912
		PatchDefaultInnerLevel,
		// Token: 0x04003659 RID: 13913
		PatchDefaultOuterLevel,
		// Token: 0x0400365A RID: 13914
		MaxPatchVertices = 36477,
		// Token: 0x0400365B RID: 13915
		MaxTessGenLevel,
		// Token: 0x0400365C RID: 13916
		MaxTessControlUniformComponents,
		// Token: 0x0400365D RID: 13917
		MaxTessEvaluationUniformComponents,
		// Token: 0x0400365E RID: 13918
		MaxTessControlTextureImageUnits,
		// Token: 0x0400365F RID: 13919
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x04003660 RID: 13920
		MaxTessControlOutputComponents,
		// Token: 0x04003661 RID: 13921
		MaxTessPatchComponents,
		// Token: 0x04003662 RID: 13922
		MaxTessControlTotalOutputComponents,
		// Token: 0x04003663 RID: 13923
		MaxTessEvaluationOutputComponents,
		// Token: 0x04003664 RID: 13924
		MaxTessControlUniformBlocks = 36489,
		// Token: 0x04003665 RID: 13925
		MaxTessEvaluationUniformBlocks,
		// Token: 0x04003666 RID: 13926
		DrawIndirectBufferBinding = 36675,
		// Token: 0x04003667 RID: 13927
		MaxVertexImageUniforms = 37066,
		// Token: 0x04003668 RID: 13928
		MaxTessControlImageUniforms,
		// Token: 0x04003669 RID: 13929
		MaxTessEvaluationImageUniforms,
		// Token: 0x0400366A RID: 13930
		MaxGeometryImageUniforms,
		// Token: 0x0400366B RID: 13931
		MaxFragmentImageUniforms,
		// Token: 0x0400366C RID: 13932
		MaxCombinedImageUniforms,
		// Token: 0x0400366D RID: 13933
		TextureBinding2DMultisample = 37124,
		// Token: 0x0400366E RID: 13934
		TextureBinding2DMultisampleArray,
		// Token: 0x0400366F RID: 13935
		MaxColorTextureSamples = 37134,
		// Token: 0x04003670 RID: 13936
		MaxDepthTextureSamples,
		// Token: 0x04003671 RID: 13937
		MaxIntegerSamples,
		// Token: 0x04003672 RID: 13938
		MaxVertexOutputComponents = 37154,
		// Token: 0x04003673 RID: 13939
		MaxGeometryInputComponents,
		// Token: 0x04003674 RID: 13940
		MaxGeometryOutputComponents,
		// Token: 0x04003675 RID: 13941
		MaxFragmentInputComponents,
		// Token: 0x04003676 RID: 13942
		MaxComputeImageUniforms = 37309
	}
}
