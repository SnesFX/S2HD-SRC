using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000495 RID: 1173
	public enum Version11
	{
		// Token: 0x0400439B RID: 17307
		False,
		// Token: 0x0400439C RID: 17308
		NoError = 0,
		// Token: 0x0400439D RID: 17309
		None = 0,
		// Token: 0x0400439E RID: 17310
		Zero = 0,
		// Token: 0x0400439F RID: 17311
		Points = 0,
		// Token: 0x040043A0 RID: 17312
		ClientPixelStoreBit,
		// Token: 0x040043A1 RID: 17313
		CurrentBit = 1,
		// Token: 0x040043A2 RID: 17314
		ClientVertexArrayBit,
		// Token: 0x040043A3 RID: 17315
		PointBit = 2,
		// Token: 0x040043A4 RID: 17316
		LineBit = 4,
		// Token: 0x040043A5 RID: 17317
		PolygonBit = 8,
		// Token: 0x040043A6 RID: 17318
		PolygonStippleBit = 16,
		// Token: 0x040043A7 RID: 17319
		PixelModeBit = 32,
		// Token: 0x040043A8 RID: 17320
		LightingBit = 64,
		// Token: 0x040043A9 RID: 17321
		FogBit = 128,
		// Token: 0x040043AA RID: 17322
		DepthBufferBit = 256,
		// Token: 0x040043AB RID: 17323
		AccumBufferBit = 512,
		// Token: 0x040043AC RID: 17324
		StencilBufferBit = 1024,
		// Token: 0x040043AD RID: 17325
		ViewportBit = 2048,
		// Token: 0x040043AE RID: 17326
		TransformBit = 4096,
		// Token: 0x040043AF RID: 17327
		EnableBit = 8192,
		// Token: 0x040043B0 RID: 17328
		ColorBufferBit = 16384,
		// Token: 0x040043B1 RID: 17329
		HintBit = 32768,
		// Token: 0x040043B2 RID: 17330
		Lines = 1,
		// Token: 0x040043B3 RID: 17331
		EvalBit = 65536,
		// Token: 0x040043B4 RID: 17332
		LineLoop = 2,
		// Token: 0x040043B5 RID: 17333
		ListBit = 131072,
		// Token: 0x040043B6 RID: 17334
		LineStrip = 3,
		// Token: 0x040043B7 RID: 17335
		Triangles,
		// Token: 0x040043B8 RID: 17336
		TextureBit = 262144,
		// Token: 0x040043B9 RID: 17337
		TriangleStrip = 5,
		// Token: 0x040043BA RID: 17338
		TriangleFan,
		// Token: 0x040043BB RID: 17339
		Quads,
		// Token: 0x040043BC RID: 17340
		QuadStrip,
		// Token: 0x040043BD RID: 17341
		ScissorBit = 524288,
		// Token: 0x040043BE RID: 17342
		Polygon = 9,
		// Token: 0x040043BF RID: 17343
		Accum = 256,
		// Token: 0x040043C0 RID: 17344
		Load,
		// Token: 0x040043C1 RID: 17345
		Return,
		// Token: 0x040043C2 RID: 17346
		Mult,
		// Token: 0x040043C3 RID: 17347
		Add,
		// Token: 0x040043C4 RID: 17348
		Never = 512,
		// Token: 0x040043C5 RID: 17349
		Less,
		// Token: 0x040043C6 RID: 17350
		Equal,
		// Token: 0x040043C7 RID: 17351
		Lequal,
		// Token: 0x040043C8 RID: 17352
		Greater,
		// Token: 0x040043C9 RID: 17353
		Notequal,
		// Token: 0x040043CA RID: 17354
		Gequal,
		// Token: 0x040043CB RID: 17355
		Always,
		// Token: 0x040043CC RID: 17356
		SrcColor = 768,
		// Token: 0x040043CD RID: 17357
		OneMinusSrcColor,
		// Token: 0x040043CE RID: 17358
		SrcAlpha,
		// Token: 0x040043CF RID: 17359
		OneMinusSrcAlpha,
		// Token: 0x040043D0 RID: 17360
		DstAlpha,
		// Token: 0x040043D1 RID: 17361
		OneMinusDstAlpha,
		// Token: 0x040043D2 RID: 17362
		DstColor,
		// Token: 0x040043D3 RID: 17363
		OneMinusDstColor,
		// Token: 0x040043D4 RID: 17364
		SrcAlphaSaturate,
		// Token: 0x040043D5 RID: 17365
		FrontLeft = 1024,
		// Token: 0x040043D6 RID: 17366
		FrontRight,
		// Token: 0x040043D7 RID: 17367
		BackLeft,
		// Token: 0x040043D8 RID: 17368
		BackRight,
		// Token: 0x040043D9 RID: 17369
		Front,
		// Token: 0x040043DA RID: 17370
		Back,
		// Token: 0x040043DB RID: 17371
		Left,
		// Token: 0x040043DC RID: 17372
		Right,
		// Token: 0x040043DD RID: 17373
		FrontAndBack,
		// Token: 0x040043DE RID: 17374
		Aux0,
		// Token: 0x040043DF RID: 17375
		Aux1,
		// Token: 0x040043E0 RID: 17376
		Aux2,
		// Token: 0x040043E1 RID: 17377
		Aux3,
		// Token: 0x040043E2 RID: 17378
		InvalidEnum = 1280,
		// Token: 0x040043E3 RID: 17379
		InvalidValue,
		// Token: 0x040043E4 RID: 17380
		InvalidOperation,
		// Token: 0x040043E5 RID: 17381
		StackOverflow,
		// Token: 0x040043E6 RID: 17382
		StackUnderflow,
		// Token: 0x040043E7 RID: 17383
		OutOfMemory,
		// Token: 0x040043E8 RID: 17384
		Gl2D = 1536,
		// Token: 0x040043E9 RID: 17385
		Gl3D,
		// Token: 0x040043EA RID: 17386
		Gl3DColor,
		// Token: 0x040043EB RID: 17387
		Gl3DColorTexture,
		// Token: 0x040043EC RID: 17388
		Gl4DColorTexture,
		// Token: 0x040043ED RID: 17389
		PassThroughToken = 1792,
		// Token: 0x040043EE RID: 17390
		PointToken,
		// Token: 0x040043EF RID: 17391
		LineToken,
		// Token: 0x040043F0 RID: 17392
		PolygonToken,
		// Token: 0x040043F1 RID: 17393
		BitmapToken,
		// Token: 0x040043F2 RID: 17394
		DrawPixelToken,
		// Token: 0x040043F3 RID: 17395
		CopyPixelToken,
		// Token: 0x040043F4 RID: 17396
		LineResetToken,
		// Token: 0x040043F5 RID: 17397
		Exp = 2048,
		// Token: 0x040043F6 RID: 17398
		Exp2,
		// Token: 0x040043F7 RID: 17399
		Cw = 2304,
		// Token: 0x040043F8 RID: 17400
		Ccw,
		// Token: 0x040043F9 RID: 17401
		Coeff = 2560,
		// Token: 0x040043FA RID: 17402
		Order,
		// Token: 0x040043FB RID: 17403
		Domain,
		// Token: 0x040043FC RID: 17404
		CurrentColor = 2816,
		// Token: 0x040043FD RID: 17405
		CurrentIndex,
		// Token: 0x040043FE RID: 17406
		CurrentNormal,
		// Token: 0x040043FF RID: 17407
		CurrentTextureCoords,
		// Token: 0x04004400 RID: 17408
		CurrentRasterColor,
		// Token: 0x04004401 RID: 17409
		CurrentRasterIndex,
		// Token: 0x04004402 RID: 17410
		CurrentRasterTextureCoords,
		// Token: 0x04004403 RID: 17411
		CurrentRasterPosition,
		// Token: 0x04004404 RID: 17412
		CurrentRasterPositionValid,
		// Token: 0x04004405 RID: 17413
		CurrentRasterDistance,
		// Token: 0x04004406 RID: 17414
		PointSmooth = 2832,
		// Token: 0x04004407 RID: 17415
		PointSize,
		// Token: 0x04004408 RID: 17416
		PointSizeRange,
		// Token: 0x04004409 RID: 17417
		PointSizeGranularity,
		// Token: 0x0400440A RID: 17418
		LineSmooth = 2848,
		// Token: 0x0400440B RID: 17419
		LineWidth,
		// Token: 0x0400440C RID: 17420
		LineWidthRange,
		// Token: 0x0400440D RID: 17421
		LineWidthGranularity,
		// Token: 0x0400440E RID: 17422
		LineStipple,
		// Token: 0x0400440F RID: 17423
		LineStipplePattern,
		// Token: 0x04004410 RID: 17424
		LineStippleRepeat,
		// Token: 0x04004411 RID: 17425
		ListMode = 2864,
		// Token: 0x04004412 RID: 17426
		MaxListNesting,
		// Token: 0x04004413 RID: 17427
		ListBase,
		// Token: 0x04004414 RID: 17428
		ListIndex,
		// Token: 0x04004415 RID: 17429
		PolygonMode = 2880,
		// Token: 0x04004416 RID: 17430
		PolygonSmooth,
		// Token: 0x04004417 RID: 17431
		PolygonStipple,
		// Token: 0x04004418 RID: 17432
		EdgeFlag,
		// Token: 0x04004419 RID: 17433
		CullFace,
		// Token: 0x0400441A RID: 17434
		CullFaceMode,
		// Token: 0x0400441B RID: 17435
		FrontFace,
		// Token: 0x0400441C RID: 17436
		Lighting = 2896,
		// Token: 0x0400441D RID: 17437
		LightModelLocalViewer,
		// Token: 0x0400441E RID: 17438
		LightModelTwoSide,
		// Token: 0x0400441F RID: 17439
		LightModelAmbient,
		// Token: 0x04004420 RID: 17440
		ShadeModel,
		// Token: 0x04004421 RID: 17441
		ColorMaterialFace,
		// Token: 0x04004422 RID: 17442
		ColorMaterialParameter,
		// Token: 0x04004423 RID: 17443
		ColorMaterial,
		// Token: 0x04004424 RID: 17444
		Fog = 2912,
		// Token: 0x04004425 RID: 17445
		FogIndex,
		// Token: 0x04004426 RID: 17446
		FogDensity,
		// Token: 0x04004427 RID: 17447
		FogStart,
		// Token: 0x04004428 RID: 17448
		FogEnd,
		// Token: 0x04004429 RID: 17449
		FogMode,
		// Token: 0x0400442A RID: 17450
		FogColor,
		// Token: 0x0400442B RID: 17451
		DepthRange = 2928,
		// Token: 0x0400442C RID: 17452
		DepthTest,
		// Token: 0x0400442D RID: 17453
		DepthWritemask,
		// Token: 0x0400442E RID: 17454
		DepthClearValue,
		// Token: 0x0400442F RID: 17455
		DepthFunc,
		// Token: 0x04004430 RID: 17456
		AccumClearValue = 2944,
		// Token: 0x04004431 RID: 17457
		StencilTest = 2960,
		// Token: 0x04004432 RID: 17458
		StencilClearValue,
		// Token: 0x04004433 RID: 17459
		StencilFunc,
		// Token: 0x04004434 RID: 17460
		StencilValueMask,
		// Token: 0x04004435 RID: 17461
		StencilFail,
		// Token: 0x04004436 RID: 17462
		StencilPassDepthFail,
		// Token: 0x04004437 RID: 17463
		StencilPassDepthPass,
		// Token: 0x04004438 RID: 17464
		StencilRef,
		// Token: 0x04004439 RID: 17465
		StencilWritemask,
		// Token: 0x0400443A RID: 17466
		MatrixMode = 2976,
		// Token: 0x0400443B RID: 17467
		Normalize,
		// Token: 0x0400443C RID: 17468
		Viewport,
		// Token: 0x0400443D RID: 17469
		ModelviewStackDepth,
		// Token: 0x0400443E RID: 17470
		ProjectionStackDepth,
		// Token: 0x0400443F RID: 17471
		TextureStackDepth,
		// Token: 0x04004440 RID: 17472
		ModelviewMatrix,
		// Token: 0x04004441 RID: 17473
		ProjectionMatrix,
		// Token: 0x04004442 RID: 17474
		TextureMatrix,
		// Token: 0x04004443 RID: 17475
		AttribStackDepth = 2992,
		// Token: 0x04004444 RID: 17476
		ClientAttribStackDepth,
		// Token: 0x04004445 RID: 17477
		AlphaTest = 3008,
		// Token: 0x04004446 RID: 17478
		AlphaTestFunc,
		// Token: 0x04004447 RID: 17479
		AlphaTestRef,
		// Token: 0x04004448 RID: 17480
		Dither = 3024,
		// Token: 0x04004449 RID: 17481
		BlendDst = 3040,
		// Token: 0x0400444A RID: 17482
		BlendSrc,
		// Token: 0x0400444B RID: 17483
		Blend,
		// Token: 0x0400444C RID: 17484
		LogicOpMode = 3056,
		// Token: 0x0400444D RID: 17485
		IndexLogicOp,
		// Token: 0x0400444E RID: 17486
		LogicOp = 3057,
		// Token: 0x0400444F RID: 17487
		ColorLogicOp,
		// Token: 0x04004450 RID: 17488
		AuxBuffers = 3072,
		// Token: 0x04004451 RID: 17489
		DrawBuffer,
		// Token: 0x04004452 RID: 17490
		ReadBuffer,
		// Token: 0x04004453 RID: 17491
		ScissorBox = 3088,
		// Token: 0x04004454 RID: 17492
		ScissorTest,
		// Token: 0x04004455 RID: 17493
		IndexClearValue = 3104,
		// Token: 0x04004456 RID: 17494
		IndexWritemask,
		// Token: 0x04004457 RID: 17495
		ColorClearValue,
		// Token: 0x04004458 RID: 17496
		ColorWritemask,
		// Token: 0x04004459 RID: 17497
		IndexMode = 3120,
		// Token: 0x0400445A RID: 17498
		RgbaMode,
		// Token: 0x0400445B RID: 17499
		Doublebuffer,
		// Token: 0x0400445C RID: 17500
		Stereo,
		// Token: 0x0400445D RID: 17501
		RenderMode = 3136,
		// Token: 0x0400445E RID: 17502
		PerspectiveCorrectionHint = 3152,
		// Token: 0x0400445F RID: 17503
		PointSmoothHint,
		// Token: 0x04004460 RID: 17504
		LineSmoothHint,
		// Token: 0x04004461 RID: 17505
		PolygonSmoothHint,
		// Token: 0x04004462 RID: 17506
		FogHint,
		// Token: 0x04004463 RID: 17507
		TextureGenS = 3168,
		// Token: 0x04004464 RID: 17508
		TextureGenT,
		// Token: 0x04004465 RID: 17509
		TextureGenR,
		// Token: 0x04004466 RID: 17510
		TextureGenQ,
		// Token: 0x04004467 RID: 17511
		PixelMapIToI = 3184,
		// Token: 0x04004468 RID: 17512
		PixelMapSToS,
		// Token: 0x04004469 RID: 17513
		PixelMapIToR,
		// Token: 0x0400446A RID: 17514
		PixelMapIToG,
		// Token: 0x0400446B RID: 17515
		PixelMapIToB,
		// Token: 0x0400446C RID: 17516
		PixelMapIToA,
		// Token: 0x0400446D RID: 17517
		PixelMapRToR,
		// Token: 0x0400446E RID: 17518
		PixelMapGToG,
		// Token: 0x0400446F RID: 17519
		PixelMapBToB,
		// Token: 0x04004470 RID: 17520
		PixelMapAToA,
		// Token: 0x04004471 RID: 17521
		PixelMapIToISize = 3248,
		// Token: 0x04004472 RID: 17522
		PixelMapSToSSize,
		// Token: 0x04004473 RID: 17523
		PixelMapIToRSize,
		// Token: 0x04004474 RID: 17524
		PixelMapIToGSize,
		// Token: 0x04004475 RID: 17525
		PixelMapIToBSize,
		// Token: 0x04004476 RID: 17526
		PixelMapIToASize,
		// Token: 0x04004477 RID: 17527
		PixelMapRToRSize,
		// Token: 0x04004478 RID: 17528
		PixelMapGToGSize,
		// Token: 0x04004479 RID: 17529
		PixelMapBToBSize,
		// Token: 0x0400447A RID: 17530
		PixelMapAToASize,
		// Token: 0x0400447B RID: 17531
		UnpackSwapBytes = 3312,
		// Token: 0x0400447C RID: 17532
		UnpackLsbFirst,
		// Token: 0x0400447D RID: 17533
		UnpackRowLength,
		// Token: 0x0400447E RID: 17534
		UnpackSkipRows,
		// Token: 0x0400447F RID: 17535
		UnpackSkipPixels,
		// Token: 0x04004480 RID: 17536
		UnpackAlignment,
		// Token: 0x04004481 RID: 17537
		PackSwapBytes = 3328,
		// Token: 0x04004482 RID: 17538
		PackLsbFirst,
		// Token: 0x04004483 RID: 17539
		PackRowLength,
		// Token: 0x04004484 RID: 17540
		PackSkipRows,
		// Token: 0x04004485 RID: 17541
		PackSkipPixels,
		// Token: 0x04004486 RID: 17542
		PackAlignment,
		// Token: 0x04004487 RID: 17543
		MapColor = 3344,
		// Token: 0x04004488 RID: 17544
		MapStencil,
		// Token: 0x04004489 RID: 17545
		IndexShift,
		// Token: 0x0400448A RID: 17546
		IndexOffset,
		// Token: 0x0400448B RID: 17547
		RedScale,
		// Token: 0x0400448C RID: 17548
		RedBias,
		// Token: 0x0400448D RID: 17549
		ZoomX,
		// Token: 0x0400448E RID: 17550
		ZoomY,
		// Token: 0x0400448F RID: 17551
		GreenScale,
		// Token: 0x04004490 RID: 17552
		GreenBias,
		// Token: 0x04004491 RID: 17553
		BlueScale,
		// Token: 0x04004492 RID: 17554
		BlueBias,
		// Token: 0x04004493 RID: 17555
		AlphaScale,
		// Token: 0x04004494 RID: 17556
		AlphaBias,
		// Token: 0x04004495 RID: 17557
		DepthScale,
		// Token: 0x04004496 RID: 17558
		DepthBias,
		// Token: 0x04004497 RID: 17559
		MaxEvalOrder = 3376,
		// Token: 0x04004498 RID: 17560
		MaxLights,
		// Token: 0x04004499 RID: 17561
		MaxClipPlanes,
		// Token: 0x0400449A RID: 17562
		MaxTextureSize,
		// Token: 0x0400449B RID: 17563
		MaxPixelMapTable,
		// Token: 0x0400449C RID: 17564
		MaxAttribStackDepth,
		// Token: 0x0400449D RID: 17565
		MaxModelviewStackDepth,
		// Token: 0x0400449E RID: 17566
		MaxNameStackDepth,
		// Token: 0x0400449F RID: 17567
		MaxProjectionStackDepth,
		// Token: 0x040044A0 RID: 17568
		MaxTextureStackDepth,
		// Token: 0x040044A1 RID: 17569
		MaxViewportDims,
		// Token: 0x040044A2 RID: 17570
		MaxClientAttribStackDepth,
		// Token: 0x040044A3 RID: 17571
		SubpixelBits = 3408,
		// Token: 0x040044A4 RID: 17572
		IndexBits,
		// Token: 0x040044A5 RID: 17573
		RedBits,
		// Token: 0x040044A6 RID: 17574
		GreenBits,
		// Token: 0x040044A7 RID: 17575
		BlueBits,
		// Token: 0x040044A8 RID: 17576
		AlphaBits,
		// Token: 0x040044A9 RID: 17577
		DepthBits,
		// Token: 0x040044AA RID: 17578
		StencilBits,
		// Token: 0x040044AB RID: 17579
		AccumRedBits,
		// Token: 0x040044AC RID: 17580
		AccumGreenBits,
		// Token: 0x040044AD RID: 17581
		AccumBlueBits,
		// Token: 0x040044AE RID: 17582
		AccumAlphaBits,
		// Token: 0x040044AF RID: 17583
		NameStackDepth = 3440,
		// Token: 0x040044B0 RID: 17584
		AutoNormal = 3456,
		// Token: 0x040044B1 RID: 17585
		Map1Color4 = 3472,
		// Token: 0x040044B2 RID: 17586
		Map1Index,
		// Token: 0x040044B3 RID: 17587
		Map1Normal,
		// Token: 0x040044B4 RID: 17588
		Map1TextureCoord1,
		// Token: 0x040044B5 RID: 17589
		Map1TextureCoord2,
		// Token: 0x040044B6 RID: 17590
		Map1TextureCoord3,
		// Token: 0x040044B7 RID: 17591
		Map1TextureCoord4,
		// Token: 0x040044B8 RID: 17592
		Map1Vertex3,
		// Token: 0x040044B9 RID: 17593
		Map1Vertex4,
		// Token: 0x040044BA RID: 17594
		Map2Color4 = 3504,
		// Token: 0x040044BB RID: 17595
		Map2Index,
		// Token: 0x040044BC RID: 17596
		Map2Normal,
		// Token: 0x040044BD RID: 17597
		Map2TextureCoord1,
		// Token: 0x040044BE RID: 17598
		Map2TextureCoord2,
		// Token: 0x040044BF RID: 17599
		Map2TextureCoord3,
		// Token: 0x040044C0 RID: 17600
		Map2TextureCoord4,
		// Token: 0x040044C1 RID: 17601
		Map2Vertex3,
		// Token: 0x040044C2 RID: 17602
		Map2Vertex4,
		// Token: 0x040044C3 RID: 17603
		Map1GridDomain = 3536,
		// Token: 0x040044C4 RID: 17604
		Map1GridSegments,
		// Token: 0x040044C5 RID: 17605
		Map2GridDomain,
		// Token: 0x040044C6 RID: 17606
		Map2GridSegments,
		// Token: 0x040044C7 RID: 17607
		Texture1D = 3552,
		// Token: 0x040044C8 RID: 17608
		Texture2D,
		// Token: 0x040044C9 RID: 17609
		FeedbackBufferPointer = 3568,
		// Token: 0x040044CA RID: 17610
		FeedbackBufferSize,
		// Token: 0x040044CB RID: 17611
		FeedbackBufferType,
		// Token: 0x040044CC RID: 17612
		SelectionBufferPointer,
		// Token: 0x040044CD RID: 17613
		SelectionBufferSize,
		// Token: 0x040044CE RID: 17614
		TextureWidth = 4096,
		// Token: 0x040044CF RID: 17615
		TextureHeight,
		// Token: 0x040044D0 RID: 17616
		TextureComponents = 4099,
		// Token: 0x040044D1 RID: 17617
		TextureInternalFormat = 4099,
		// Token: 0x040044D2 RID: 17618
		TextureBorderColor,
		// Token: 0x040044D3 RID: 17619
		TextureBorder,
		// Token: 0x040044D4 RID: 17620
		DontCare = 4352,
		// Token: 0x040044D5 RID: 17621
		Fastest,
		// Token: 0x040044D6 RID: 17622
		Nicest,
		// Token: 0x040044D7 RID: 17623
		Ambient = 4608,
		// Token: 0x040044D8 RID: 17624
		Diffuse,
		// Token: 0x040044D9 RID: 17625
		Specular,
		// Token: 0x040044DA RID: 17626
		Position,
		// Token: 0x040044DB RID: 17627
		SpotDirection,
		// Token: 0x040044DC RID: 17628
		SpotExponent,
		// Token: 0x040044DD RID: 17629
		SpotCutoff,
		// Token: 0x040044DE RID: 17630
		ConstantAttenuation,
		// Token: 0x040044DF RID: 17631
		LinearAttenuation,
		// Token: 0x040044E0 RID: 17632
		QuadraticAttenuation,
		// Token: 0x040044E1 RID: 17633
		Compile = 4864,
		// Token: 0x040044E2 RID: 17634
		CompileAndExecute,
		// Token: 0x040044E3 RID: 17635
		Byte = 5120,
		// Token: 0x040044E4 RID: 17636
		UnsignedByte,
		// Token: 0x040044E5 RID: 17637
		Short,
		// Token: 0x040044E6 RID: 17638
		UnsignedShort,
		// Token: 0x040044E7 RID: 17639
		Int,
		// Token: 0x040044E8 RID: 17640
		UnsignedInt,
		// Token: 0x040044E9 RID: 17641
		Float,
		// Token: 0x040044EA RID: 17642
		Gl2Bytes,
		// Token: 0x040044EB RID: 17643
		Gl3Bytes,
		// Token: 0x040044EC RID: 17644
		Gl4Bytes,
		// Token: 0x040044ED RID: 17645
		Double,
		// Token: 0x040044EE RID: 17646
		Clear = 5376,
		// Token: 0x040044EF RID: 17647
		And,
		// Token: 0x040044F0 RID: 17648
		AndReverse,
		// Token: 0x040044F1 RID: 17649
		Copy,
		// Token: 0x040044F2 RID: 17650
		AndInverted,
		// Token: 0x040044F3 RID: 17651
		Noop,
		// Token: 0x040044F4 RID: 17652
		Xor,
		// Token: 0x040044F5 RID: 17653
		Or,
		// Token: 0x040044F6 RID: 17654
		Nor,
		// Token: 0x040044F7 RID: 17655
		Equiv,
		// Token: 0x040044F8 RID: 17656
		Invert,
		// Token: 0x040044F9 RID: 17657
		OrReverse,
		// Token: 0x040044FA RID: 17658
		CopyInverted,
		// Token: 0x040044FB RID: 17659
		OrInverted,
		// Token: 0x040044FC RID: 17660
		Nand,
		// Token: 0x040044FD RID: 17661
		Set,
		// Token: 0x040044FE RID: 17662
		Emission = 5632,
		// Token: 0x040044FF RID: 17663
		Shininess,
		// Token: 0x04004500 RID: 17664
		AmbientAndDiffuse,
		// Token: 0x04004501 RID: 17665
		ColorIndexes,
		// Token: 0x04004502 RID: 17666
		Modelview = 5888,
		// Token: 0x04004503 RID: 17667
		Projection,
		// Token: 0x04004504 RID: 17668
		Texture,
		// Token: 0x04004505 RID: 17669
		Color = 6144,
		// Token: 0x04004506 RID: 17670
		Depth,
		// Token: 0x04004507 RID: 17671
		Stencil,
		// Token: 0x04004508 RID: 17672
		ColorIndex = 6400,
		// Token: 0x04004509 RID: 17673
		StencilIndex,
		// Token: 0x0400450A RID: 17674
		DepthComponent,
		// Token: 0x0400450B RID: 17675
		Red,
		// Token: 0x0400450C RID: 17676
		Green,
		// Token: 0x0400450D RID: 17677
		Blue,
		// Token: 0x0400450E RID: 17678
		Alpha,
		// Token: 0x0400450F RID: 17679
		Rgb,
		// Token: 0x04004510 RID: 17680
		Rgba,
		// Token: 0x04004511 RID: 17681
		Luminance,
		// Token: 0x04004512 RID: 17682
		LuminanceAlpha,
		// Token: 0x04004513 RID: 17683
		Bitmap = 6656,
		// Token: 0x04004514 RID: 17684
		Point = 6912,
		// Token: 0x04004515 RID: 17685
		Line,
		// Token: 0x04004516 RID: 17686
		Fill,
		// Token: 0x04004517 RID: 17687
		Render = 7168,
		// Token: 0x04004518 RID: 17688
		Feedback,
		// Token: 0x04004519 RID: 17689
		Select,
		// Token: 0x0400451A RID: 17690
		Flat = 7424,
		// Token: 0x0400451B RID: 17691
		Smooth,
		// Token: 0x0400451C RID: 17692
		Keep = 7680,
		// Token: 0x0400451D RID: 17693
		Replace,
		// Token: 0x0400451E RID: 17694
		Incr,
		// Token: 0x0400451F RID: 17695
		Decr,
		// Token: 0x04004520 RID: 17696
		Vendor = 7936,
		// Token: 0x04004521 RID: 17697
		Renderer,
		// Token: 0x04004522 RID: 17698
		Version,
		// Token: 0x04004523 RID: 17699
		Extensions,
		// Token: 0x04004524 RID: 17700
		S = 8192,
		// Token: 0x04004525 RID: 17701
		T,
		// Token: 0x04004526 RID: 17702
		R,
		// Token: 0x04004527 RID: 17703
		Q,
		// Token: 0x04004528 RID: 17704
		Modulate = 8448,
		// Token: 0x04004529 RID: 17705
		Decal,
		// Token: 0x0400452A RID: 17706
		TextureEnvMode = 8704,
		// Token: 0x0400452B RID: 17707
		TextureEnvColor,
		// Token: 0x0400452C RID: 17708
		TextureEnv = 8960,
		// Token: 0x0400452D RID: 17709
		EyeLinear = 9216,
		// Token: 0x0400452E RID: 17710
		ObjectLinear,
		// Token: 0x0400452F RID: 17711
		SphereMap,
		// Token: 0x04004530 RID: 17712
		TextureGenMode = 9472,
		// Token: 0x04004531 RID: 17713
		ObjectPlane,
		// Token: 0x04004532 RID: 17714
		EyePlane,
		// Token: 0x04004533 RID: 17715
		Nearest = 9728,
		// Token: 0x04004534 RID: 17716
		Linear,
		// Token: 0x04004535 RID: 17717
		NearestMipmapNearest = 9984,
		// Token: 0x04004536 RID: 17718
		LinearMipmapNearest,
		// Token: 0x04004537 RID: 17719
		NearestMipmapLinear,
		// Token: 0x04004538 RID: 17720
		LinearMipmapLinear,
		// Token: 0x04004539 RID: 17721
		TextureMagFilter = 10240,
		// Token: 0x0400453A RID: 17722
		TextureMinFilter,
		// Token: 0x0400453B RID: 17723
		TextureWrapS,
		// Token: 0x0400453C RID: 17724
		TextureWrapT,
		// Token: 0x0400453D RID: 17725
		Clamp = 10496,
		// Token: 0x0400453E RID: 17726
		Repeat,
		// Token: 0x0400453F RID: 17727
		PolygonOffsetUnits = 10752,
		// Token: 0x04004540 RID: 17728
		PolygonOffsetPoint,
		// Token: 0x04004541 RID: 17729
		PolygonOffsetLine,
		// Token: 0x04004542 RID: 17730
		R3G3B2 = 10768,
		// Token: 0x04004543 RID: 17731
		V2f = 10784,
		// Token: 0x04004544 RID: 17732
		V3f,
		// Token: 0x04004545 RID: 17733
		C4ubV2f,
		// Token: 0x04004546 RID: 17734
		C4ubV3f,
		// Token: 0x04004547 RID: 17735
		C3fV3f,
		// Token: 0x04004548 RID: 17736
		N3fV3f,
		// Token: 0x04004549 RID: 17737
		C4fN3fV3f,
		// Token: 0x0400454A RID: 17738
		T2fV3f,
		// Token: 0x0400454B RID: 17739
		T4fV4f,
		// Token: 0x0400454C RID: 17740
		T2fC4ubV3f,
		// Token: 0x0400454D RID: 17741
		T2fC3fV3f,
		// Token: 0x0400454E RID: 17742
		T2fN3fV3f,
		// Token: 0x0400454F RID: 17743
		T2fC4fN3fV3f,
		// Token: 0x04004550 RID: 17744
		T4fC4fN3fV4f,
		// Token: 0x04004551 RID: 17745
		ClipPlane0 = 12288,
		// Token: 0x04004552 RID: 17746
		ClipPlane1,
		// Token: 0x04004553 RID: 17747
		ClipPlane2,
		// Token: 0x04004554 RID: 17748
		ClipPlane3,
		// Token: 0x04004555 RID: 17749
		ClipPlane4,
		// Token: 0x04004556 RID: 17750
		ClipPlane5,
		// Token: 0x04004557 RID: 17751
		Light0 = 16384,
		// Token: 0x04004558 RID: 17752
		Light1,
		// Token: 0x04004559 RID: 17753
		Light2,
		// Token: 0x0400455A RID: 17754
		Light3,
		// Token: 0x0400455B RID: 17755
		Light4,
		// Token: 0x0400455C RID: 17756
		Light5,
		// Token: 0x0400455D RID: 17757
		Light6,
		// Token: 0x0400455E RID: 17758
		Light7,
		// Token: 0x0400455F RID: 17759
		PolygonOffsetFill = 32823,
		// Token: 0x04004560 RID: 17760
		PolygonOffsetFactor,
		// Token: 0x04004561 RID: 17761
		Alpha4 = 32827,
		// Token: 0x04004562 RID: 17762
		Alpha8,
		// Token: 0x04004563 RID: 17763
		Alpha12,
		// Token: 0x04004564 RID: 17764
		Alpha16,
		// Token: 0x04004565 RID: 17765
		Luminance4,
		// Token: 0x04004566 RID: 17766
		Luminance8,
		// Token: 0x04004567 RID: 17767
		Luminance12,
		// Token: 0x04004568 RID: 17768
		Luminance16,
		// Token: 0x04004569 RID: 17769
		Luminance4Alpha4,
		// Token: 0x0400456A RID: 17770
		Luminance6Alpha2,
		// Token: 0x0400456B RID: 17771
		Luminance8Alpha8,
		// Token: 0x0400456C RID: 17772
		Luminance12Alpha4,
		// Token: 0x0400456D RID: 17773
		Luminance12Alpha12,
		// Token: 0x0400456E RID: 17774
		Luminance16Alpha16,
		// Token: 0x0400456F RID: 17775
		Intensity,
		// Token: 0x04004570 RID: 17776
		Intensity4,
		// Token: 0x04004571 RID: 17777
		Intensity8,
		// Token: 0x04004572 RID: 17778
		Intensity12,
		// Token: 0x04004573 RID: 17779
		Intensity16,
		// Token: 0x04004574 RID: 17780
		Rgb4 = 32847,
		// Token: 0x04004575 RID: 17781
		Rgb5,
		// Token: 0x04004576 RID: 17782
		Rgb8,
		// Token: 0x04004577 RID: 17783
		Rgb10,
		// Token: 0x04004578 RID: 17784
		Rgb12,
		// Token: 0x04004579 RID: 17785
		Rgb16,
		// Token: 0x0400457A RID: 17786
		Rgba2,
		// Token: 0x0400457B RID: 17787
		Rgba4,
		// Token: 0x0400457C RID: 17788
		Rgb5A1,
		// Token: 0x0400457D RID: 17789
		Rgba8,
		// Token: 0x0400457E RID: 17790
		Rgb10A2,
		// Token: 0x0400457F RID: 17791
		Rgba12,
		// Token: 0x04004580 RID: 17792
		Rgba16,
		// Token: 0x04004581 RID: 17793
		TextureRedSize,
		// Token: 0x04004582 RID: 17794
		TextureGreenSize,
		// Token: 0x04004583 RID: 17795
		TextureBlueSize,
		// Token: 0x04004584 RID: 17796
		TextureAlphaSize,
		// Token: 0x04004585 RID: 17797
		TextureLuminanceSize,
		// Token: 0x04004586 RID: 17798
		TextureIntensitySize,
		// Token: 0x04004587 RID: 17799
		ProxyTexture1D = 32867,
		// Token: 0x04004588 RID: 17800
		ProxyTexture2D,
		// Token: 0x04004589 RID: 17801
		TexturePriority = 32870,
		// Token: 0x0400458A RID: 17802
		TextureResident,
		// Token: 0x0400458B RID: 17803
		TextureBinding1D,
		// Token: 0x0400458C RID: 17804
		TextureBinding2D,
		// Token: 0x0400458D RID: 17805
		VertexArray = 32884,
		// Token: 0x0400458E RID: 17806
		NormalArray,
		// Token: 0x0400458F RID: 17807
		ColorArray,
		// Token: 0x04004590 RID: 17808
		IndexArray,
		// Token: 0x04004591 RID: 17809
		TextureCoordArray,
		// Token: 0x04004592 RID: 17810
		EdgeFlagArray,
		// Token: 0x04004593 RID: 17811
		VertexArraySize,
		// Token: 0x04004594 RID: 17812
		VertexArrayType,
		// Token: 0x04004595 RID: 17813
		VertexArrayStride,
		// Token: 0x04004596 RID: 17814
		NormalArrayType = 32894,
		// Token: 0x04004597 RID: 17815
		NormalArrayStride,
		// Token: 0x04004598 RID: 17816
		ColorArraySize = 32897,
		// Token: 0x04004599 RID: 17817
		ColorArrayType,
		// Token: 0x0400459A RID: 17818
		ColorArrayStride,
		// Token: 0x0400459B RID: 17819
		IndexArrayType = 32901,
		// Token: 0x0400459C RID: 17820
		IndexArrayStride,
		// Token: 0x0400459D RID: 17821
		TextureCoordArraySize = 32904,
		// Token: 0x0400459E RID: 17822
		TextureCoordArrayType,
		// Token: 0x0400459F RID: 17823
		TextureCoordArrayStride,
		// Token: 0x040045A0 RID: 17824
		EdgeFlagArrayStride = 32908,
		// Token: 0x040045A1 RID: 17825
		VertexArrayPointer = 32910,
		// Token: 0x040045A2 RID: 17826
		NormalArrayPointer,
		// Token: 0x040045A3 RID: 17827
		ColorArrayPointer,
		// Token: 0x040045A4 RID: 17828
		IndexArrayPointer,
		// Token: 0x040045A5 RID: 17829
		TextureCoordArrayPointer,
		// Token: 0x040045A6 RID: 17830
		EdgeFlagArrayPointer,
		// Token: 0x040045A7 RID: 17831
		AllAttribBits = -1,
		// Token: 0x040045A8 RID: 17832
		ClientAllAttribBits = -1,
		// Token: 0x040045A9 RID: 17833
		One = 1,
		// Token: 0x040045AA RID: 17834
		True = 1
	}
}
