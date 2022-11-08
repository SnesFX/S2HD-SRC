using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000914 RID: 2324
	public enum EsVersion20
	{
		// Token: 0x04009916 RID: 39190
		False,
		// Token: 0x04009917 RID: 39191
		NoError = 0,
		// Token: 0x04009918 RID: 39192
		None = 0,
		// Token: 0x04009919 RID: 39193
		Zero = 0,
		// Token: 0x0400991A RID: 39194
		Points = 0,
		// Token: 0x0400991B RID: 39195
		DepthBufferBit = 256,
		// Token: 0x0400991C RID: 39196
		StencilBufferBit = 1024,
		// Token: 0x0400991D RID: 39197
		ColorBufferBit = 16384,
		// Token: 0x0400991E RID: 39198
		Lines = 1,
		// Token: 0x0400991F RID: 39199
		LineLoop,
		// Token: 0x04009920 RID: 39200
		LineStrip,
		// Token: 0x04009921 RID: 39201
		Triangles,
		// Token: 0x04009922 RID: 39202
		TriangleStrip,
		// Token: 0x04009923 RID: 39203
		TriangleFan,
		// Token: 0x04009924 RID: 39204
		Never = 512,
		// Token: 0x04009925 RID: 39205
		Less,
		// Token: 0x04009926 RID: 39206
		Equal,
		// Token: 0x04009927 RID: 39207
		Lequal,
		// Token: 0x04009928 RID: 39208
		Greater,
		// Token: 0x04009929 RID: 39209
		Notequal,
		// Token: 0x0400992A RID: 39210
		Gequal,
		// Token: 0x0400992B RID: 39211
		Always,
		// Token: 0x0400992C RID: 39212
		SrcColor = 768,
		// Token: 0x0400992D RID: 39213
		OneMinusSrcColor,
		// Token: 0x0400992E RID: 39214
		SrcAlpha,
		// Token: 0x0400992F RID: 39215
		OneMinusSrcAlpha,
		// Token: 0x04009930 RID: 39216
		DstAlpha,
		// Token: 0x04009931 RID: 39217
		OneMinusDstAlpha,
		// Token: 0x04009932 RID: 39218
		DstColor,
		// Token: 0x04009933 RID: 39219
		OneMinusDstColor,
		// Token: 0x04009934 RID: 39220
		SrcAlphaSaturate,
		// Token: 0x04009935 RID: 39221
		Front = 1028,
		// Token: 0x04009936 RID: 39222
		Back,
		// Token: 0x04009937 RID: 39223
		FrontAndBack = 1032,
		// Token: 0x04009938 RID: 39224
		InvalidEnum = 1280,
		// Token: 0x04009939 RID: 39225
		InvalidValue,
		// Token: 0x0400993A RID: 39226
		InvalidOperation,
		// Token: 0x0400993B RID: 39227
		OutOfMemory = 1285,
		// Token: 0x0400993C RID: 39228
		InvalidFramebufferOperation,
		// Token: 0x0400993D RID: 39229
		Cw = 2304,
		// Token: 0x0400993E RID: 39230
		Ccw,
		// Token: 0x0400993F RID: 39231
		LineWidth = 2849,
		// Token: 0x04009940 RID: 39232
		CullFace = 2884,
		// Token: 0x04009941 RID: 39233
		CullFaceMode,
		// Token: 0x04009942 RID: 39234
		FrontFace,
		// Token: 0x04009943 RID: 39235
		DepthRange = 2928,
		// Token: 0x04009944 RID: 39236
		DepthTest,
		// Token: 0x04009945 RID: 39237
		DepthWritemask,
		// Token: 0x04009946 RID: 39238
		DepthClearValue,
		// Token: 0x04009947 RID: 39239
		DepthFunc,
		// Token: 0x04009948 RID: 39240
		StencilTest = 2960,
		// Token: 0x04009949 RID: 39241
		StencilClearValue,
		// Token: 0x0400994A RID: 39242
		StencilFunc,
		// Token: 0x0400994B RID: 39243
		StencilValueMask,
		// Token: 0x0400994C RID: 39244
		StencilFail,
		// Token: 0x0400994D RID: 39245
		StencilPassDepthFail,
		// Token: 0x0400994E RID: 39246
		StencilPassDepthPass,
		// Token: 0x0400994F RID: 39247
		StencilRef,
		// Token: 0x04009950 RID: 39248
		StencilWritemask,
		// Token: 0x04009951 RID: 39249
		Viewport = 2978,
		// Token: 0x04009952 RID: 39250
		Dither = 3024,
		// Token: 0x04009953 RID: 39251
		Blend = 3042,
		// Token: 0x04009954 RID: 39252
		ScissorBox = 3088,
		// Token: 0x04009955 RID: 39253
		ScissorTest,
		// Token: 0x04009956 RID: 39254
		ColorClearValue = 3106,
		// Token: 0x04009957 RID: 39255
		ColorWritemask,
		// Token: 0x04009958 RID: 39256
		UnpackAlignment = 3317,
		// Token: 0x04009959 RID: 39257
		PackAlignment = 3333,
		// Token: 0x0400995A RID: 39258
		MaxTextureSize = 3379,
		// Token: 0x0400995B RID: 39259
		MaxViewportDims = 3386,
		// Token: 0x0400995C RID: 39260
		SubpixelBits = 3408,
		// Token: 0x0400995D RID: 39261
		RedBits = 3410,
		// Token: 0x0400995E RID: 39262
		GreenBits,
		// Token: 0x0400995F RID: 39263
		BlueBits,
		// Token: 0x04009960 RID: 39264
		AlphaBits,
		// Token: 0x04009961 RID: 39265
		DepthBits,
		// Token: 0x04009962 RID: 39266
		StencilBits,
		// Token: 0x04009963 RID: 39267
		Texture2D = 3553,
		// Token: 0x04009964 RID: 39268
		DontCare = 4352,
		// Token: 0x04009965 RID: 39269
		Fastest,
		// Token: 0x04009966 RID: 39270
		Nicest,
		// Token: 0x04009967 RID: 39271
		Byte = 5120,
		// Token: 0x04009968 RID: 39272
		UnsignedByte,
		// Token: 0x04009969 RID: 39273
		Short,
		// Token: 0x0400996A RID: 39274
		UnsignedShort,
		// Token: 0x0400996B RID: 39275
		Int,
		// Token: 0x0400996C RID: 39276
		UnsignedInt,
		// Token: 0x0400996D RID: 39277
		Float,
		// Token: 0x0400996E RID: 39278
		Fixed = 5132,
		// Token: 0x0400996F RID: 39279
		Invert = 5386,
		// Token: 0x04009970 RID: 39280
		Texture = 5890,
		// Token: 0x04009971 RID: 39281
		DepthComponent = 6402,
		// Token: 0x04009972 RID: 39282
		Alpha = 6406,
		// Token: 0x04009973 RID: 39283
		Rgb,
		// Token: 0x04009974 RID: 39284
		Rgba,
		// Token: 0x04009975 RID: 39285
		Luminance,
		// Token: 0x04009976 RID: 39286
		LuminanceAlpha,
		// Token: 0x04009977 RID: 39287
		Keep = 7680,
		// Token: 0x04009978 RID: 39288
		Replace,
		// Token: 0x04009979 RID: 39289
		Incr,
		// Token: 0x0400997A RID: 39290
		Decr,
		// Token: 0x0400997B RID: 39291
		Vendor = 7936,
		// Token: 0x0400997C RID: 39292
		Renderer,
		// Token: 0x0400997D RID: 39293
		Version,
		// Token: 0x0400997E RID: 39294
		Extensions,
		// Token: 0x0400997F RID: 39295
		Nearest = 9728,
		// Token: 0x04009980 RID: 39296
		Linear,
		// Token: 0x04009981 RID: 39297
		NearestMipmapNearest = 9984,
		// Token: 0x04009982 RID: 39298
		LinearMipmapNearest,
		// Token: 0x04009983 RID: 39299
		NearestMipmapLinear,
		// Token: 0x04009984 RID: 39300
		LinearMipmapLinear,
		// Token: 0x04009985 RID: 39301
		TextureMagFilter = 10240,
		// Token: 0x04009986 RID: 39302
		TextureMinFilter,
		// Token: 0x04009987 RID: 39303
		TextureWrapS,
		// Token: 0x04009988 RID: 39304
		TextureWrapT,
		// Token: 0x04009989 RID: 39305
		Repeat = 10497,
		// Token: 0x0400998A RID: 39306
		PolygonOffsetUnits = 10752,
		// Token: 0x0400998B RID: 39307
		ConstantColor = 32769,
		// Token: 0x0400998C RID: 39308
		OneMinusConstantColor,
		// Token: 0x0400998D RID: 39309
		ConstantAlpha,
		// Token: 0x0400998E RID: 39310
		OneMinusConstantAlpha,
		// Token: 0x0400998F RID: 39311
		BlendColor,
		// Token: 0x04009990 RID: 39312
		FuncAdd,
		// Token: 0x04009991 RID: 39313
		BlendEquation = 32777,
		// Token: 0x04009992 RID: 39314
		BlendEquationRgb = 32777,
		// Token: 0x04009993 RID: 39315
		FuncSubtract,
		// Token: 0x04009994 RID: 39316
		FuncReverseSubtract,
		// Token: 0x04009995 RID: 39317
		UnsignedShort4444 = 32819,
		// Token: 0x04009996 RID: 39318
		UnsignedShort5551,
		// Token: 0x04009997 RID: 39319
		PolygonOffsetFill = 32823,
		// Token: 0x04009998 RID: 39320
		PolygonOffsetFactor,
		// Token: 0x04009999 RID: 39321
		Rgba4 = 32854,
		// Token: 0x0400999A RID: 39322
		Rgb5A1,
		// Token: 0x0400999B RID: 39323
		TextureBinding2D = 32873,
		// Token: 0x0400999C RID: 39324
		SampleAlphaToCoverage = 32926,
		// Token: 0x0400999D RID: 39325
		SampleCoverage = 32928,
		// Token: 0x0400999E RID: 39326
		SampleBuffers = 32936,
		// Token: 0x0400999F RID: 39327
		Samples,
		// Token: 0x040099A0 RID: 39328
		SampleCoverageValue,
		// Token: 0x040099A1 RID: 39329
		SampleCoverageInvert,
		// Token: 0x040099A2 RID: 39330
		BlendDstRgb = 32968,
		// Token: 0x040099A3 RID: 39331
		BlendSrcRgb,
		// Token: 0x040099A4 RID: 39332
		BlendDstAlpha,
		// Token: 0x040099A5 RID: 39333
		BlendSrcAlpha,
		// Token: 0x040099A6 RID: 39334
		ClampToEdge = 33071,
		// Token: 0x040099A7 RID: 39335
		GenerateMipmapHint = 33170,
		// Token: 0x040099A8 RID: 39336
		DepthComponent16 = 33189,
		// Token: 0x040099A9 RID: 39337
		UnsignedShort565 = 33635,
		// Token: 0x040099AA RID: 39338
		MirroredRepeat = 33648,
		// Token: 0x040099AB RID: 39339
		AliasedPointSizeRange = 33901,
		// Token: 0x040099AC RID: 39340
		AliasedLineWidthRange,
		// Token: 0x040099AD RID: 39341
		Texture0 = 33984,
		// Token: 0x040099AE RID: 39342
		Texture1,
		// Token: 0x040099AF RID: 39343
		Texture2,
		// Token: 0x040099B0 RID: 39344
		Texture3,
		// Token: 0x040099B1 RID: 39345
		Texture4,
		// Token: 0x040099B2 RID: 39346
		Texture5,
		// Token: 0x040099B3 RID: 39347
		Texture6,
		// Token: 0x040099B4 RID: 39348
		Texture7,
		// Token: 0x040099B5 RID: 39349
		Texture8,
		// Token: 0x040099B6 RID: 39350
		Texture9,
		// Token: 0x040099B7 RID: 39351
		Texture10,
		// Token: 0x040099B8 RID: 39352
		Texture11,
		// Token: 0x040099B9 RID: 39353
		Texture12,
		// Token: 0x040099BA RID: 39354
		Texture13,
		// Token: 0x040099BB RID: 39355
		Texture14,
		// Token: 0x040099BC RID: 39356
		Texture15,
		// Token: 0x040099BD RID: 39357
		Texture16,
		// Token: 0x040099BE RID: 39358
		Texture17,
		// Token: 0x040099BF RID: 39359
		Texture18,
		// Token: 0x040099C0 RID: 39360
		Texture19,
		// Token: 0x040099C1 RID: 39361
		Texture20,
		// Token: 0x040099C2 RID: 39362
		Texture21,
		// Token: 0x040099C3 RID: 39363
		Texture22,
		// Token: 0x040099C4 RID: 39364
		Texture23,
		// Token: 0x040099C5 RID: 39365
		Texture24,
		// Token: 0x040099C6 RID: 39366
		Texture25,
		// Token: 0x040099C7 RID: 39367
		Texture26,
		// Token: 0x040099C8 RID: 39368
		Texture27,
		// Token: 0x040099C9 RID: 39369
		Texture28,
		// Token: 0x040099CA RID: 39370
		Texture29,
		// Token: 0x040099CB RID: 39371
		Texture30,
		// Token: 0x040099CC RID: 39372
		Texture31,
		// Token: 0x040099CD RID: 39373
		ActiveTexture,
		// Token: 0x040099CE RID: 39374
		MaxRenderbufferSize = 34024,
		// Token: 0x040099CF RID: 39375
		IncrWrap = 34055,
		// Token: 0x040099D0 RID: 39376
		DecrWrap,
		// Token: 0x040099D1 RID: 39377
		TextureCubeMap = 34067,
		// Token: 0x040099D2 RID: 39378
		TextureBindingCubeMap,
		// Token: 0x040099D3 RID: 39379
		TextureCubeMapPositiveX,
		// Token: 0x040099D4 RID: 39380
		TextureCubeMapNegativeX,
		// Token: 0x040099D5 RID: 39381
		TextureCubeMapPositiveY,
		// Token: 0x040099D6 RID: 39382
		TextureCubeMapNegativeY,
		// Token: 0x040099D7 RID: 39383
		TextureCubeMapPositiveZ,
		// Token: 0x040099D8 RID: 39384
		TextureCubeMapNegativeZ,
		// Token: 0x040099D9 RID: 39385
		MaxCubeMapTextureSize = 34076,
		// Token: 0x040099DA RID: 39386
		VertexAttribArrayEnabled = 34338,
		// Token: 0x040099DB RID: 39387
		VertexAttribArraySize,
		// Token: 0x040099DC RID: 39388
		VertexAttribArrayStride,
		// Token: 0x040099DD RID: 39389
		VertexAttribArrayType,
		// Token: 0x040099DE RID: 39390
		CurrentVertexAttrib,
		// Token: 0x040099DF RID: 39391
		VertexAttribArrayPointer = 34373,
		// Token: 0x040099E0 RID: 39392
		NumCompressedTextureFormats = 34466,
		// Token: 0x040099E1 RID: 39393
		CompressedTextureFormats,
		// Token: 0x040099E2 RID: 39394
		BufferSize = 34660,
		// Token: 0x040099E3 RID: 39395
		BufferUsage,
		// Token: 0x040099E4 RID: 39396
		StencilBackFunc = 34816,
		// Token: 0x040099E5 RID: 39397
		StencilBackFail,
		// Token: 0x040099E6 RID: 39398
		StencilBackPassDepthFail,
		// Token: 0x040099E7 RID: 39399
		StencilBackPassDepthPass,
		// Token: 0x040099E8 RID: 39400
		BlendEquationAlpha = 34877,
		// Token: 0x040099E9 RID: 39401
		MaxVertexAttribs = 34921,
		// Token: 0x040099EA RID: 39402
		VertexAttribArrayNormalized,
		// Token: 0x040099EB RID: 39403
		MaxTextureImageUnits = 34930,
		// Token: 0x040099EC RID: 39404
		ArrayBuffer = 34962,
		// Token: 0x040099ED RID: 39405
		ElementArrayBuffer,
		// Token: 0x040099EE RID: 39406
		ArrayBufferBinding,
		// Token: 0x040099EF RID: 39407
		ElementArrayBufferBinding,
		// Token: 0x040099F0 RID: 39408
		VertexAttribArrayBufferBinding = 34975,
		// Token: 0x040099F1 RID: 39409
		StreamDraw = 35040,
		// Token: 0x040099F2 RID: 39410
		StaticDraw = 35044,
		// Token: 0x040099F3 RID: 39411
		DynamicDraw = 35048,
		// Token: 0x040099F4 RID: 39412
		FragmentShader = 35632,
		// Token: 0x040099F5 RID: 39413
		VertexShader,
		// Token: 0x040099F6 RID: 39414
		MaxVertexTextureImageUnits = 35660,
		// Token: 0x040099F7 RID: 39415
		MaxCombinedTextureImageUnits,
		// Token: 0x040099F8 RID: 39416
		ShaderType = 35663,
		// Token: 0x040099F9 RID: 39417
		FloatVec2,
		// Token: 0x040099FA RID: 39418
		FloatVec3,
		// Token: 0x040099FB RID: 39419
		FloatVec4,
		// Token: 0x040099FC RID: 39420
		IntVec2,
		// Token: 0x040099FD RID: 39421
		IntVec3,
		// Token: 0x040099FE RID: 39422
		IntVec4,
		// Token: 0x040099FF RID: 39423
		Bool,
		// Token: 0x04009A00 RID: 39424
		BoolVec2,
		// Token: 0x04009A01 RID: 39425
		BoolVec3,
		// Token: 0x04009A02 RID: 39426
		BoolVec4,
		// Token: 0x04009A03 RID: 39427
		FloatMat2,
		// Token: 0x04009A04 RID: 39428
		FloatMat3,
		// Token: 0x04009A05 RID: 39429
		FloatMat4,
		// Token: 0x04009A06 RID: 39430
		Sampler2D = 35678,
		// Token: 0x04009A07 RID: 39431
		SamplerCube = 35680,
		// Token: 0x04009A08 RID: 39432
		DeleteStatus = 35712,
		// Token: 0x04009A09 RID: 39433
		CompileStatus,
		// Token: 0x04009A0A RID: 39434
		LinkStatus,
		// Token: 0x04009A0B RID: 39435
		ValidateStatus,
		// Token: 0x04009A0C RID: 39436
		InfoLogLength,
		// Token: 0x04009A0D RID: 39437
		AttachedShaders,
		// Token: 0x04009A0E RID: 39438
		ActiveUniforms,
		// Token: 0x04009A0F RID: 39439
		ActiveUniformMaxLength,
		// Token: 0x04009A10 RID: 39440
		ShaderSourceLength,
		// Token: 0x04009A11 RID: 39441
		ActiveAttributes,
		// Token: 0x04009A12 RID: 39442
		ActiveAttributeMaxLength,
		// Token: 0x04009A13 RID: 39443
		ShadingLanguageVersion = 35724,
		// Token: 0x04009A14 RID: 39444
		CurrentProgram,
		// Token: 0x04009A15 RID: 39445
		ImplementationColorReadType = 35738,
		// Token: 0x04009A16 RID: 39446
		ImplementationColorReadFormat,
		// Token: 0x04009A17 RID: 39447
		StencilBackRef = 36003,
		// Token: 0x04009A18 RID: 39448
		StencilBackValueMask,
		// Token: 0x04009A19 RID: 39449
		StencilBackWritemask,
		// Token: 0x04009A1A RID: 39450
		FramebufferBinding,
		// Token: 0x04009A1B RID: 39451
		RenderbufferBinding,
		// Token: 0x04009A1C RID: 39452
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04009A1D RID: 39453
		FramebufferAttachmentObjectName,
		// Token: 0x04009A1E RID: 39454
		FramebufferAttachmentTextureLevel,
		// Token: 0x04009A1F RID: 39455
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04009A20 RID: 39456
		FramebufferComplete = 36053,
		// Token: 0x04009A21 RID: 39457
		FramebufferIncompleteAttachment,
		// Token: 0x04009A22 RID: 39458
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04009A23 RID: 39459
		FramebufferIncompleteDimensions = 36057,
		// Token: 0x04009A24 RID: 39460
		FramebufferUnsupported = 36061,
		// Token: 0x04009A25 RID: 39461
		ColorAttachment0 = 36064,
		// Token: 0x04009A26 RID: 39462
		DepthAttachment = 36096,
		// Token: 0x04009A27 RID: 39463
		StencilAttachment = 36128,
		// Token: 0x04009A28 RID: 39464
		Framebuffer = 36160,
		// Token: 0x04009A29 RID: 39465
		Renderbuffer,
		// Token: 0x04009A2A RID: 39466
		RenderbufferWidth,
		// Token: 0x04009A2B RID: 39467
		RenderbufferHeight,
		// Token: 0x04009A2C RID: 39468
		RenderbufferInternalFormat,
		// Token: 0x04009A2D RID: 39469
		StencilIndex8 = 36168,
		// Token: 0x04009A2E RID: 39470
		RenderbufferRedSize = 36176,
		// Token: 0x04009A2F RID: 39471
		RenderbufferGreenSize,
		// Token: 0x04009A30 RID: 39472
		RenderbufferBlueSize,
		// Token: 0x04009A31 RID: 39473
		RenderbufferAlphaSize,
		// Token: 0x04009A32 RID: 39474
		RenderbufferDepthSize,
		// Token: 0x04009A33 RID: 39475
		RenderbufferStencilSize,
		// Token: 0x04009A34 RID: 39476
		Rgb565 = 36194,
		// Token: 0x04009A35 RID: 39477
		LowFloat = 36336,
		// Token: 0x04009A36 RID: 39478
		MediumFloat,
		// Token: 0x04009A37 RID: 39479
		HighFloat,
		// Token: 0x04009A38 RID: 39480
		LowInt,
		// Token: 0x04009A39 RID: 39481
		MediumInt,
		// Token: 0x04009A3A RID: 39482
		HighInt,
		// Token: 0x04009A3B RID: 39483
		ShaderBinaryFormats = 36344,
		// Token: 0x04009A3C RID: 39484
		NumShaderBinaryFormats,
		// Token: 0x04009A3D RID: 39485
		ShaderCompiler,
		// Token: 0x04009A3E RID: 39486
		MaxVertexUniformVectors,
		// Token: 0x04009A3F RID: 39487
		MaxVaryingVectors,
		// Token: 0x04009A40 RID: 39488
		MaxFragmentUniformVectors,
		// Token: 0x04009A41 RID: 39489
		One = 1,
		// Token: 0x04009A42 RID: 39490
		True = 1
	}
}
