using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007C4 RID: 1988
	public enum EsVersion30
	{
		// Token: 0x040081F8 RID: 33272
		SyncFlushCommandsBit = 1,
		// Token: 0x040081F9 RID: 33273
		MapReadBit = 1,
		// Token: 0x040081FA RID: 33274
		MapWriteBit,
		// Token: 0x040081FB RID: 33275
		MapInvalidateRangeBit = 4,
		// Token: 0x040081FC RID: 33276
		MapInvalidateBufferBit = 8,
		// Token: 0x040081FD RID: 33277
		MapFlushExplicitBit = 16,
		// Token: 0x040081FE RID: 33278
		MapUnsynchronizedBit = 32,
		// Token: 0x040081FF RID: 33279
		ReadBuffer = 3074,
		// Token: 0x04008200 RID: 33280
		UnpackRowLength = 3314,
		// Token: 0x04008201 RID: 33281
		UnpackSkipRows,
		// Token: 0x04008202 RID: 33282
		UnpackSkipPixels,
		// Token: 0x04008203 RID: 33283
		PackRowLength = 3330,
		// Token: 0x04008204 RID: 33284
		PackSkipRows,
		// Token: 0x04008205 RID: 33285
		PackSkipPixels,
		// Token: 0x04008206 RID: 33286
		HalfFloat = 5131,
		// Token: 0x04008207 RID: 33287
		Color = 6144,
		// Token: 0x04008208 RID: 33288
		Depth,
		// Token: 0x04008209 RID: 33289
		Stencil,
		// Token: 0x0400820A RID: 33290
		Red = 6403,
		// Token: 0x0400820B RID: 33291
		Green,
		// Token: 0x0400820C RID: 33292
		Blue,
		// Token: 0x0400820D RID: 33293
		Min = 32775,
		// Token: 0x0400820E RID: 33294
		Max,
		// Token: 0x0400820F RID: 33295
		Rgb8 = 32849,
		// Token: 0x04008210 RID: 33296
		Rgba8 = 32856,
		// Token: 0x04008211 RID: 33297
		Rgb10A2,
		// Token: 0x04008212 RID: 33298
		TextureBinding3D = 32874,
		// Token: 0x04008213 RID: 33299
		UnpackSkipImages = 32877,
		// Token: 0x04008214 RID: 33300
		UnpackImageHeight,
		// Token: 0x04008215 RID: 33301
		Texture3D,
		// Token: 0x04008216 RID: 33302
		TextureWrapR = 32882,
		// Token: 0x04008217 RID: 33303
		Max3DTextureSize,
		// Token: 0x04008218 RID: 33304
		MaxElementsVertices = 33000,
		// Token: 0x04008219 RID: 33305
		MaxElementsIndices,
		// Token: 0x0400821A RID: 33306
		TextureMinLod = 33082,
		// Token: 0x0400821B RID: 33307
		TextureMaxLod,
		// Token: 0x0400821C RID: 33308
		TextureBaseLevel,
		// Token: 0x0400821D RID: 33309
		TextureMaxLevel,
		// Token: 0x0400821E RID: 33310
		DepthComponent24 = 33190,
		// Token: 0x0400821F RID: 33311
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x04008220 RID: 33312
		FramebufferAttachmentComponentType,
		// Token: 0x04008221 RID: 33313
		FramebufferAttachmentRedSize,
		// Token: 0x04008222 RID: 33314
		FramebufferAttachmentGreenSize,
		// Token: 0x04008223 RID: 33315
		FramebufferAttachmentBlueSize,
		// Token: 0x04008224 RID: 33316
		FramebufferAttachmentAlphaSize,
		// Token: 0x04008225 RID: 33317
		FramebufferAttachmentDepthSize,
		// Token: 0x04008226 RID: 33318
		FramebufferAttachmentStencilSize,
		// Token: 0x04008227 RID: 33319
		FramebufferDefault,
		// Token: 0x04008228 RID: 33320
		FramebufferUndefined,
		// Token: 0x04008229 RID: 33321
		DepthStencilAttachment,
		// Token: 0x0400822A RID: 33322
		MajorVersion,
		// Token: 0x0400822B RID: 33323
		MinorVersion,
		// Token: 0x0400822C RID: 33324
		NumExtensions,
		// Token: 0x0400822D RID: 33325
		Rg = 33319,
		// Token: 0x0400822E RID: 33326
		RgInteger,
		// Token: 0x0400822F RID: 33327
		R8,
		// Token: 0x04008230 RID: 33328
		Rg8 = 33323,
		// Token: 0x04008231 RID: 33329
		R16f = 33325,
		// Token: 0x04008232 RID: 33330
		R32f,
		// Token: 0x04008233 RID: 33331
		Rg16f,
		// Token: 0x04008234 RID: 33332
		Rg32f,
		// Token: 0x04008235 RID: 33333
		R8i,
		// Token: 0x04008236 RID: 33334
		R8ui,
		// Token: 0x04008237 RID: 33335
		R16i,
		// Token: 0x04008238 RID: 33336
		R16ui,
		// Token: 0x04008239 RID: 33337
		R32i,
		// Token: 0x0400823A RID: 33338
		R32ui,
		// Token: 0x0400823B RID: 33339
		Rg8i,
		// Token: 0x0400823C RID: 33340
		Rg8ui,
		// Token: 0x0400823D RID: 33341
		Rg16i,
		// Token: 0x0400823E RID: 33342
		Rg16ui,
		// Token: 0x0400823F RID: 33343
		Rg32i,
		// Token: 0x04008240 RID: 33344
		Rg32ui,
		// Token: 0x04008241 RID: 33345
		ProgramBinaryRetrievableHint = 33367,
		// Token: 0x04008242 RID: 33346
		TextureImmutableLevels = 33503,
		// Token: 0x04008243 RID: 33347
		UnsignedInt2101010Rev = 33640,
		// Token: 0x04008244 RID: 33348
		DepthStencil = 34041,
		// Token: 0x04008245 RID: 33349
		UnsignedInt248,
		// Token: 0x04008246 RID: 33350
		MaxTextureLodBias = 34045,
		// Token: 0x04008247 RID: 33351
		VertexArrayBinding = 34229,
		// Token: 0x04008248 RID: 33352
		ProgramBinaryLength = 34625,
		// Token: 0x04008249 RID: 33353
		NumProgramBinaryFormats = 34814,
		// Token: 0x0400824A RID: 33354
		ProgramBinaryFormats,
		// Token: 0x0400824B RID: 33355
		Rgba32f = 34836,
		// Token: 0x0400824C RID: 33356
		Rgb32f,
		// Token: 0x0400824D RID: 33357
		Rgba16f = 34842,
		// Token: 0x0400824E RID: 33358
		Rgb16f,
		// Token: 0x0400824F RID: 33359
		MaxDrawBuffers = 34852,
		// Token: 0x04008250 RID: 33360
		DrawBuffer0,
		// Token: 0x04008251 RID: 33361
		DrawBuffer1,
		// Token: 0x04008252 RID: 33362
		DrawBuffer2,
		// Token: 0x04008253 RID: 33363
		DrawBuffer3,
		// Token: 0x04008254 RID: 33364
		DrawBuffer4,
		// Token: 0x04008255 RID: 33365
		DrawBuffer5,
		// Token: 0x04008256 RID: 33366
		DrawBuffer6,
		// Token: 0x04008257 RID: 33367
		DrawBuffer7,
		// Token: 0x04008258 RID: 33368
		DrawBuffer8,
		// Token: 0x04008259 RID: 33369
		DrawBuffer9,
		// Token: 0x0400825A RID: 33370
		DrawBuffer10,
		// Token: 0x0400825B RID: 33371
		DrawBuffer11,
		// Token: 0x0400825C RID: 33372
		DrawBuffer12,
		// Token: 0x0400825D RID: 33373
		DrawBuffer13,
		// Token: 0x0400825E RID: 33374
		DrawBuffer14,
		// Token: 0x0400825F RID: 33375
		DrawBuffer15,
		// Token: 0x04008260 RID: 33376
		TextureCompareMode = 34892,
		// Token: 0x04008261 RID: 33377
		TextureCompareFunc,
		// Token: 0x04008262 RID: 33378
		CompareRefToTexture,
		// Token: 0x04008263 RID: 33379
		CurrentQuery = 34917,
		// Token: 0x04008264 RID: 33380
		QueryResult,
		// Token: 0x04008265 RID: 33381
		QueryResultAvailable,
		// Token: 0x04008266 RID: 33382
		BufferMapped = 35004,
		// Token: 0x04008267 RID: 33383
		BufferMapPointer,
		// Token: 0x04008268 RID: 33384
		StreamRead = 35041,
		// Token: 0x04008269 RID: 33385
		StreamCopy,
		// Token: 0x0400826A RID: 33386
		StaticRead = 35045,
		// Token: 0x0400826B RID: 33387
		StaticCopy,
		// Token: 0x0400826C RID: 33388
		DynamicRead = 35049,
		// Token: 0x0400826D RID: 33389
		DynamicCopy,
		// Token: 0x0400826E RID: 33390
		PixelPackBuffer,
		// Token: 0x0400826F RID: 33391
		PixelUnpackBuffer,
		// Token: 0x04008270 RID: 33392
		PixelPackBufferBinding,
		// Token: 0x04008271 RID: 33393
		PixelUnpackBufferBinding = 35055,
		// Token: 0x04008272 RID: 33394
		Depth24Stencil8,
		// Token: 0x04008273 RID: 33395
		VertexAttribArrayInteger = 35069,
		// Token: 0x04008274 RID: 33396
		VertexAttribArrayDivisor,
		// Token: 0x04008275 RID: 33397
		MaxArrayTextureLayers,
		// Token: 0x04008276 RID: 33398
		MinProgramTexelOffset = 35076,
		// Token: 0x04008277 RID: 33399
		MaxProgramTexelOffset,
		// Token: 0x04008278 RID: 33400
		SamplerBinding = 35097,
		// Token: 0x04008279 RID: 33401
		UniformBuffer = 35345,
		// Token: 0x0400827A RID: 33402
		UniformBufferBinding = 35368,
		// Token: 0x0400827B RID: 33403
		UniformBufferStart,
		// Token: 0x0400827C RID: 33404
		UniformBufferSize,
		// Token: 0x0400827D RID: 33405
		MaxVertexUniformBlocks,
		// Token: 0x0400827E RID: 33406
		MaxFragmentUniformBlocks = 35373,
		// Token: 0x0400827F RID: 33407
		MaxCombinedUniformBlocks,
		// Token: 0x04008280 RID: 33408
		MaxUniformBufferBindings,
		// Token: 0x04008281 RID: 33409
		MaxUniformBlockSize,
		// Token: 0x04008282 RID: 33410
		MaxCombinedVertexUniformComponents,
		// Token: 0x04008283 RID: 33411
		MaxCombinedFragmentUniformComponents = 35379,
		// Token: 0x04008284 RID: 33412
		UniformBufferOffsetAlignment,
		// Token: 0x04008285 RID: 33413
		ActiveUniformBlockMaxNameLength,
		// Token: 0x04008286 RID: 33414
		ActiveUniformBlocks,
		// Token: 0x04008287 RID: 33415
		UniformType,
		// Token: 0x04008288 RID: 33416
		UniformSize,
		// Token: 0x04008289 RID: 33417
		UniformNameLength,
		// Token: 0x0400828A RID: 33418
		UniformBlockIndex,
		// Token: 0x0400828B RID: 33419
		UniformOffset,
		// Token: 0x0400828C RID: 33420
		UniformArrayStride,
		// Token: 0x0400828D RID: 33421
		UniformMatrixStride,
		// Token: 0x0400828E RID: 33422
		UniformIsRowMajor,
		// Token: 0x0400828F RID: 33423
		UniformBlockBinding,
		// Token: 0x04008290 RID: 33424
		UniformBlockDataSize,
		// Token: 0x04008291 RID: 33425
		UniformBlockNameLength,
		// Token: 0x04008292 RID: 33426
		UniformBlockActiveUniforms,
		// Token: 0x04008293 RID: 33427
		UniformBlockActiveUniformIndices,
		// Token: 0x04008294 RID: 33428
		UniformBlockReferencedByVertexShader,
		// Token: 0x04008295 RID: 33429
		UniformBlockReferencedByFragmentShader = 35398,
		// Token: 0x04008296 RID: 33430
		MaxFragmentUniformComponents = 35657,
		// Token: 0x04008297 RID: 33431
		MaxVertexUniformComponents,
		// Token: 0x04008298 RID: 33432
		MaxVaryingComponents,
		// Token: 0x04008299 RID: 33433
		Sampler3D = 35679,
		// Token: 0x0400829A RID: 33434
		Sampler2DShadow = 35682,
		// Token: 0x0400829B RID: 33435
		FloatMat2x3 = 35685,
		// Token: 0x0400829C RID: 33436
		FloatMat2x4,
		// Token: 0x0400829D RID: 33437
		FloatMat3x2,
		// Token: 0x0400829E RID: 33438
		FloatMat3x4,
		// Token: 0x0400829F RID: 33439
		FloatMat4x2,
		// Token: 0x040082A0 RID: 33440
		FloatMat4x3,
		// Token: 0x040082A1 RID: 33441
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x040082A2 RID: 33442
		UnsignedNormalized = 35863,
		// Token: 0x040082A3 RID: 33443
		Texture2DArray = 35866,
		// Token: 0x040082A4 RID: 33444
		TextureBinding2DArray = 35869,
		// Token: 0x040082A5 RID: 33445
		AnySamplesPassed = 35887,
		// Token: 0x040082A6 RID: 33446
		R11fG11fB10f = 35898,
		// Token: 0x040082A7 RID: 33447
		UnsignedInt10F11F11FRev,
		// Token: 0x040082A8 RID: 33448
		Rgb9E5 = 35901,
		// Token: 0x040082A9 RID: 33449
		UnsignedInt5999Rev,
		// Token: 0x040082AA RID: 33450
		Srgb = 35904,
		// Token: 0x040082AB RID: 33451
		Srgb8,
		// Token: 0x040082AC RID: 33452
		Srgb8Alpha8 = 35907,
		// Token: 0x040082AD RID: 33453
		TransformFeedbackVaryingMaxLength = 35958,
		// Token: 0x040082AE RID: 33454
		TransformFeedbackBufferMode = 35967,
		// Token: 0x040082AF RID: 33455
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x040082B0 RID: 33456
		TransformFeedbackVaryings = 35971,
		// Token: 0x040082B1 RID: 33457
		TransformFeedbackBufferStart,
		// Token: 0x040082B2 RID: 33458
		TransformFeedbackBufferSize,
		// Token: 0x040082B3 RID: 33459
		TransformFeedbackPrimitivesWritten = 35976,
		// Token: 0x040082B4 RID: 33460
		RasterizerDiscard,
		// Token: 0x040082B5 RID: 33461
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x040082B6 RID: 33462
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x040082B7 RID: 33463
		InterleavedAttribs,
		// Token: 0x040082B8 RID: 33464
		SeparateAttribs,
		// Token: 0x040082B9 RID: 33465
		TransformFeedbackBuffer,
		// Token: 0x040082BA RID: 33466
		TransformFeedbackBufferBinding,
		// Token: 0x040082BB RID: 33467
		DrawFramebufferBinding = 36006,
		// Token: 0x040082BC RID: 33468
		ReadFramebuffer = 36008,
		// Token: 0x040082BD RID: 33469
		DrawFramebuffer,
		// Token: 0x040082BE RID: 33470
		ReadFramebufferBinding,
		// Token: 0x040082BF RID: 33471
		RenderbufferSamples,
		// Token: 0x040082C0 RID: 33472
		DepthComponent32f,
		// Token: 0x040082C1 RID: 33473
		Depth32fStencil8,
		// Token: 0x040082C2 RID: 33474
		FramebufferAttachmentTextureLayer = 36052,
		// Token: 0x040082C3 RID: 33475
		MaxColorAttachments = 36063,
		// Token: 0x040082C4 RID: 33476
		ColorAttachment1 = 36065,
		// Token: 0x040082C5 RID: 33477
		ColorAttachment2,
		// Token: 0x040082C6 RID: 33478
		ColorAttachment3,
		// Token: 0x040082C7 RID: 33479
		ColorAttachment4,
		// Token: 0x040082C8 RID: 33480
		ColorAttachment5,
		// Token: 0x040082C9 RID: 33481
		ColorAttachment6,
		// Token: 0x040082CA RID: 33482
		ColorAttachment7,
		// Token: 0x040082CB RID: 33483
		ColorAttachment8,
		// Token: 0x040082CC RID: 33484
		ColorAttachment9,
		// Token: 0x040082CD RID: 33485
		ColorAttachment10,
		// Token: 0x040082CE RID: 33486
		ColorAttachment11,
		// Token: 0x040082CF RID: 33487
		ColorAttachment12,
		// Token: 0x040082D0 RID: 33488
		ColorAttachment13,
		// Token: 0x040082D1 RID: 33489
		ColorAttachment14,
		// Token: 0x040082D2 RID: 33490
		ColorAttachment15,
		// Token: 0x040082D3 RID: 33491
		FramebufferIncompleteMultisample = 36182,
		// Token: 0x040082D4 RID: 33492
		MaxSamples,
		// Token: 0x040082D5 RID: 33493
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x040082D6 RID: 33494
		AnySamplesPassedConservative,
		// Token: 0x040082D7 RID: 33495
		MaxElementIndex,
		// Token: 0x040082D8 RID: 33496
		Rgba32ui = 36208,
		// Token: 0x040082D9 RID: 33497
		Rgb32ui,
		// Token: 0x040082DA RID: 33498
		Rgba16ui = 36214,
		// Token: 0x040082DB RID: 33499
		Rgb16ui,
		// Token: 0x040082DC RID: 33500
		Rgba8ui = 36220,
		// Token: 0x040082DD RID: 33501
		Rgb8ui,
		// Token: 0x040082DE RID: 33502
		Rgba32i = 36226,
		// Token: 0x040082DF RID: 33503
		Rgb32i,
		// Token: 0x040082E0 RID: 33504
		Rgba16i = 36232,
		// Token: 0x040082E1 RID: 33505
		Rgb16i,
		// Token: 0x040082E2 RID: 33506
		Rgba8i = 36238,
		// Token: 0x040082E3 RID: 33507
		Rgb8i,
		// Token: 0x040082E4 RID: 33508
		RedInteger = 36244,
		// Token: 0x040082E5 RID: 33509
		RgbInteger = 36248,
		// Token: 0x040082E6 RID: 33510
		RgbaInteger,
		// Token: 0x040082E7 RID: 33511
		Int2101010Rev = 36255,
		// Token: 0x040082E8 RID: 33512
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x040082E9 RID: 33513
		Sampler2DArray = 36289,
		// Token: 0x040082EA RID: 33514
		Sampler2DArrayShadow = 36292,
		// Token: 0x040082EB RID: 33515
		SamplerCubeShadow,
		// Token: 0x040082EC RID: 33516
		UnsignedIntVec2,
		// Token: 0x040082ED RID: 33517
		UnsignedIntVec3,
		// Token: 0x040082EE RID: 33518
		UnsignedIntVec4,
		// Token: 0x040082EF RID: 33519
		IntSampler2D = 36298,
		// Token: 0x040082F0 RID: 33520
		IntSampler3D,
		// Token: 0x040082F1 RID: 33521
		IntSamplerCube,
		// Token: 0x040082F2 RID: 33522
		IntSampler2DArray = 36303,
		// Token: 0x040082F3 RID: 33523
		UnsignedIntSampler2D = 36306,
		// Token: 0x040082F4 RID: 33524
		UnsignedIntSampler3D,
		// Token: 0x040082F5 RID: 33525
		UnsignedIntSamplerCube,
		// Token: 0x040082F6 RID: 33526
		UnsignedIntSampler2DArray = 36311,
		// Token: 0x040082F7 RID: 33527
		TransformFeedback = 36386,
		// Token: 0x040082F8 RID: 33528
		TransformFeedbackPaused,
		// Token: 0x040082F9 RID: 33529
		TransformFeedbackActive,
		// Token: 0x040082FA RID: 33530
		TransformFeedbackBinding,
		// Token: 0x040082FB RID: 33531
		TextureSwizzleR = 36418,
		// Token: 0x040082FC RID: 33532
		TextureSwizzleG,
		// Token: 0x040082FD RID: 33533
		TextureSwizzleB,
		// Token: 0x040082FE RID: 33534
		TextureSwizzleA,
		// Token: 0x040082FF RID: 33535
		CopyReadBuffer = 36662,
		// Token: 0x04008300 RID: 33536
		CopyReadBufferBinding = 36662,
		// Token: 0x04008301 RID: 33537
		CopyWriteBuffer,
		// Token: 0x04008302 RID: 33538
		CopyWriteBufferBinding = 36663,
		// Token: 0x04008303 RID: 33539
		R8Snorm = 36756,
		// Token: 0x04008304 RID: 33540
		Rg8Snorm,
		// Token: 0x04008305 RID: 33541
		Rgb8Snorm,
		// Token: 0x04008306 RID: 33542
		Rgba8Snorm,
		// Token: 0x04008307 RID: 33543
		SignedNormalized = 36764,
		// Token: 0x04008308 RID: 33544
		Rgb10A2ui = 36975,
		// Token: 0x04008309 RID: 33545
		MaxServerWaitTimeout = 37137,
		// Token: 0x0400830A RID: 33546
		ObjectType,
		// Token: 0x0400830B RID: 33547
		SyncCondition,
		// Token: 0x0400830C RID: 33548
		SyncStatus,
		// Token: 0x0400830D RID: 33549
		SyncFlags,
		// Token: 0x0400830E RID: 33550
		SyncFence,
		// Token: 0x0400830F RID: 33551
		SyncGpuCommandsComplete,
		// Token: 0x04008310 RID: 33552
		Unsignaled,
		// Token: 0x04008311 RID: 33553
		Signaled,
		// Token: 0x04008312 RID: 33554
		AlreadySignaled,
		// Token: 0x04008313 RID: 33555
		TimeoutExpired,
		// Token: 0x04008314 RID: 33556
		ConditionSatisfied,
		// Token: 0x04008315 RID: 33557
		WaitFailed,
		// Token: 0x04008316 RID: 33558
		BufferAccessFlags = 37151,
		// Token: 0x04008317 RID: 33559
		BufferMapLength,
		// Token: 0x04008318 RID: 33560
		BufferMapOffset,
		// Token: 0x04008319 RID: 33561
		MaxVertexOutputComponents,
		// Token: 0x0400831A RID: 33562
		MaxFragmentInputComponents = 37157,
		// Token: 0x0400831B RID: 33563
		TextureImmutableFormat = 37167,
		// Token: 0x0400831C RID: 33564
		CompressedR11Eac = 37488,
		// Token: 0x0400831D RID: 33565
		CompressedSignedR11Eac,
		// Token: 0x0400831E RID: 33566
		CompressedRg11Eac,
		// Token: 0x0400831F RID: 33567
		CompressedSignedRg11Eac,
		// Token: 0x04008320 RID: 33568
		CompressedRgb8Etc2,
		// Token: 0x04008321 RID: 33569
		CompressedSrgb8Etc2,
		// Token: 0x04008322 RID: 33570
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x04008323 RID: 33571
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x04008324 RID: 33572
		CompressedRgba8Etc2Eac,
		// Token: 0x04008325 RID: 33573
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x04008326 RID: 33574
		NumSampleCounts = 37760,
		// Token: 0x04008327 RID: 33575
		InvalidIndex = -1,
		// Token: 0x04008328 RID: 33576
		TimeoutIgnored = -1
	}
}
