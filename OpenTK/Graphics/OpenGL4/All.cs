using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000602 RID: 1538
	public enum All
	{
		// Token: 0x0400565E RID: 22110
		False,
		// Token: 0x0400565F RID: 22111
		LayoutDefaultIntel = 0,
		// Token: 0x04005660 RID: 22112
		NoError = 0,
		// Token: 0x04005661 RID: 22113
		None = 0,
		// Token: 0x04005662 RID: 22114
		NoneOes = 0,
		// Token: 0x04005663 RID: 22115
		Zero = 0,
		// Token: 0x04005664 RID: 22116
		Points = 0,
		// Token: 0x04005665 RID: 22117
		ContextCoreProfileBit,
		// Token: 0x04005666 RID: 22118
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x04005667 RID: 22119
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04005668 RID: 22120
		SyncFlushCommandsBit = 1,
		// Token: 0x04005669 RID: 22121
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x0400566A RID: 22122
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x0400566B RID: 22123
		VertexShaderBit = 1,
		// Token: 0x0400566C RID: 22124
		VertexShaderBitExt = 1,
		// Token: 0x0400566D RID: 22125
		ContextCompatibilityProfileBit,
		// Token: 0x0400566E RID: 22126
		ContextFlagDebugBit = 2,
		// Token: 0x0400566F RID: 22127
		ContextFlagDebugBitKhr = 2,
		// Token: 0x04005670 RID: 22128
		ElementArrayBarrierBit = 2,
		// Token: 0x04005671 RID: 22129
		ElementArrayBarrierBitExt = 2,
		// Token: 0x04005672 RID: 22130
		FragmentShaderBit = 2,
		// Token: 0x04005673 RID: 22131
		FragmentShaderBitExt = 2,
		// Token: 0x04005674 RID: 22132
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04005675 RID: 22133
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x04005676 RID: 22134
		GeometryShaderBit = 4,
		// Token: 0x04005677 RID: 22135
		GeometryShaderBitExt = 4,
		// Token: 0x04005678 RID: 22136
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04005679 RID: 22137
		UniformBarrierBit = 4,
		// Token: 0x0400567A RID: 22138
		UniformBarrierBitExt = 4,
		// Token: 0x0400567B RID: 22139
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x0400567C RID: 22140
		TessControlShaderBit = 8,
		// Token: 0x0400567D RID: 22141
		TessControlShaderBitExt = 8,
		// Token: 0x0400567E RID: 22142
		TextureFetchBarrierBit = 8,
		// Token: 0x0400567F RID: 22143
		TextureFetchBarrierBitExt = 8,
		// Token: 0x04005680 RID: 22144
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x04005681 RID: 22145
		TessEvaluationShaderBit = 16,
		// Token: 0x04005682 RID: 22146
		TessEvaluationShaderBitExt = 16,
		// Token: 0x04005683 RID: 22147
		ComputeShaderBit = 32,
		// Token: 0x04005684 RID: 22148
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04005685 RID: 22149
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04005686 RID: 22150
		CommandBarrierBit = 64,
		// Token: 0x04005687 RID: 22151
		CommandBarrierBitExt = 64,
		// Token: 0x04005688 RID: 22152
		PixelBufferBarrierBit = 128,
		// Token: 0x04005689 RID: 22153
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400568A RID: 22154
		DepthBufferBit = 256,
		// Token: 0x0400568B RID: 22155
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400568C RID: 22156
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400568D RID: 22157
		AccumBufferBit = 512,
		// Token: 0x0400568E RID: 22158
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400568F RID: 22159
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x04005690 RID: 22160
		FramebufferBarrierBit = 1024,
		// Token: 0x04005691 RID: 22161
		FramebufferBarrierBitExt = 1024,
		// Token: 0x04005692 RID: 22162
		StencilBufferBit = 1024,
		// Token: 0x04005693 RID: 22163
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04005694 RID: 22164
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x04005695 RID: 22165
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04005696 RID: 22166
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x04005697 RID: 22167
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04005698 RID: 22168
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04005699 RID: 22169
		ColorBufferBit = 16384,
		// Token: 0x0400569A RID: 22170
		CoverageBufferBitNv = 32768,
		// Token: 0x0400569B RID: 22171
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400569C RID: 22172
		Lines = 1,
		// Token: 0x0400569D RID: 22173
		MapReadBit = 1,
		// Token: 0x0400569E RID: 22174
		MapReadBitExt = 1,
		// Token: 0x0400569F RID: 22175
		LineLoop,
		// Token: 0x040056A0 RID: 22176
		MapWriteBit = 2,
		// Token: 0x040056A1 RID: 22177
		MapWriteBitExt = 2,
		// Token: 0x040056A2 RID: 22178
		LineStrip,
		// Token: 0x040056A3 RID: 22179
		MapInvalidateRangeBit,
		// Token: 0x040056A4 RID: 22180
		MapInvalidateRangeBitExt = 4,
		// Token: 0x040056A5 RID: 22181
		Triangles = 4,
		// Token: 0x040056A6 RID: 22182
		TriangleStrip,
		// Token: 0x040056A7 RID: 22183
		TriangleFan,
		// Token: 0x040056A8 RID: 22184
		Quads,
		// Token: 0x040056A9 RID: 22185
		QuadsExt = 7,
		// Token: 0x040056AA RID: 22186
		MapInvalidateBufferBit,
		// Token: 0x040056AB RID: 22187
		MapInvalidateBufferBitExt = 8,
		// Token: 0x040056AC RID: 22188
		QuadStrip = 8,
		// Token: 0x040056AD RID: 22189
		Polygon,
		// Token: 0x040056AE RID: 22190
		LinesAdjacency,
		// Token: 0x040056AF RID: 22191
		LinesAdjacencyArb = 10,
		// Token: 0x040056B0 RID: 22192
		LinesAdjacencyExt = 10,
		// Token: 0x040056B1 RID: 22193
		LineStripAdjacency,
		// Token: 0x040056B2 RID: 22194
		LineStripAdjacencyArb = 11,
		// Token: 0x040056B3 RID: 22195
		LineStripAdjacencyExt = 11,
		// Token: 0x040056B4 RID: 22196
		TrianglesAdjacency,
		// Token: 0x040056B5 RID: 22197
		TrianglesAdjacencyArb = 12,
		// Token: 0x040056B6 RID: 22198
		TrianglesAdjacencyExt = 12,
		// Token: 0x040056B7 RID: 22199
		TriangleStripAdjacency,
		// Token: 0x040056B8 RID: 22200
		TriangleStripAdjacencyArb = 13,
		// Token: 0x040056B9 RID: 22201
		TriangleStripAdjacencyExt = 13,
		// Token: 0x040056BA RID: 22202
		Patches,
		// Token: 0x040056BB RID: 22203
		PatchesExt = 14,
		// Token: 0x040056BC RID: 22204
		MapFlushExplicitBit = 16,
		// Token: 0x040056BD RID: 22205
		MapFlushExplicitBitExt = 16,
		// Token: 0x040056BE RID: 22206
		MapUnsynchronizedBit = 32,
		// Token: 0x040056BF RID: 22207
		MapUnsynchronizedBitExt = 32,
		// Token: 0x040056C0 RID: 22208
		MapPersistentBit = 64,
		// Token: 0x040056C1 RID: 22209
		MapCoherentBit = 128,
		// Token: 0x040056C2 RID: 22210
		DynamicStorageBit = 256,
		// Token: 0x040056C3 RID: 22211
		Add = 260,
		// Token: 0x040056C4 RID: 22212
		ClientStorageBit = 512,
		// Token: 0x040056C5 RID: 22213
		Never = 512,
		// Token: 0x040056C6 RID: 22214
		Less,
		// Token: 0x040056C7 RID: 22215
		Equal,
		// Token: 0x040056C8 RID: 22216
		Lequal,
		// Token: 0x040056C9 RID: 22217
		Greater,
		// Token: 0x040056CA RID: 22218
		Notequal,
		// Token: 0x040056CB RID: 22219
		Gequal,
		// Token: 0x040056CC RID: 22220
		Always,
		// Token: 0x040056CD RID: 22221
		SrcColor = 768,
		// Token: 0x040056CE RID: 22222
		OneMinusSrcColor,
		// Token: 0x040056CF RID: 22223
		SrcAlpha,
		// Token: 0x040056D0 RID: 22224
		OneMinusSrcAlpha,
		// Token: 0x040056D1 RID: 22225
		DstAlpha,
		// Token: 0x040056D2 RID: 22226
		OneMinusDstAlpha,
		// Token: 0x040056D3 RID: 22227
		DstColor,
		// Token: 0x040056D4 RID: 22228
		OneMinusDstColor,
		// Token: 0x040056D5 RID: 22229
		SrcAlphaSaturate,
		// Token: 0x040056D6 RID: 22230
		FrontLeft = 1024,
		// Token: 0x040056D7 RID: 22231
		FrontRight,
		// Token: 0x040056D8 RID: 22232
		BackLeft,
		// Token: 0x040056D9 RID: 22233
		BackRight,
		// Token: 0x040056DA RID: 22234
		Front,
		// Token: 0x040056DB RID: 22235
		Back,
		// Token: 0x040056DC RID: 22236
		Left,
		// Token: 0x040056DD RID: 22237
		Right,
		// Token: 0x040056DE RID: 22238
		FrontAndBack,
		// Token: 0x040056DF RID: 22239
		Aux0,
		// Token: 0x040056E0 RID: 22240
		Aux1,
		// Token: 0x040056E1 RID: 22241
		Aux2,
		// Token: 0x040056E2 RID: 22242
		Aux3,
		// Token: 0x040056E3 RID: 22243
		InvalidEnum = 1280,
		// Token: 0x040056E4 RID: 22244
		InvalidValue,
		// Token: 0x040056E5 RID: 22245
		InvalidOperation,
		// Token: 0x040056E6 RID: 22246
		StackOverflow,
		// Token: 0x040056E7 RID: 22247
		StackOverflowKhr = 1283,
		// Token: 0x040056E8 RID: 22248
		StackUnderflow,
		// Token: 0x040056E9 RID: 22249
		StackUnderflowKhr = 1284,
		// Token: 0x040056EA RID: 22250
		OutOfMemory,
		// Token: 0x040056EB RID: 22251
		InvalidFramebufferOperation,
		// Token: 0x040056EC RID: 22252
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x040056ED RID: 22253
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x040056EE RID: 22254
		Cw = 2304,
		// Token: 0x040056EF RID: 22255
		Ccw,
		// Token: 0x040056F0 RID: 22256
		PointSmooth = 2832,
		// Token: 0x040056F1 RID: 22257
		PointSize,
		// Token: 0x040056F2 RID: 22258
		PointSizeRange,
		// Token: 0x040056F3 RID: 22259
		SmoothPointSizeRange = 2834,
		// Token: 0x040056F4 RID: 22260
		PointSizeGranularity,
		// Token: 0x040056F5 RID: 22261
		SmoothPointSizeGranularity = 2835,
		// Token: 0x040056F6 RID: 22262
		LineSmooth = 2848,
		// Token: 0x040056F7 RID: 22263
		LineWidth,
		// Token: 0x040056F8 RID: 22264
		LineWidthRange,
		// Token: 0x040056F9 RID: 22265
		SmoothLineWidthRange = 2850,
		// Token: 0x040056FA RID: 22266
		LineWidthGranularity,
		// Token: 0x040056FB RID: 22267
		SmoothLineWidthGranularity = 2851,
		// Token: 0x040056FC RID: 22268
		LineStipple,
		// Token: 0x040056FD RID: 22269
		PolygonMode = 2880,
		// Token: 0x040056FE RID: 22270
		PolygonSmooth,
		// Token: 0x040056FF RID: 22271
		PolygonStipple,
		// Token: 0x04005700 RID: 22272
		CullFace = 2884,
		// Token: 0x04005701 RID: 22273
		CullFaceMode,
		// Token: 0x04005702 RID: 22274
		FrontFace,
		// Token: 0x04005703 RID: 22275
		Lighting = 2896,
		// Token: 0x04005704 RID: 22276
		LightModelLocalViewer,
		// Token: 0x04005705 RID: 22277
		LightModelTwoSide,
		// Token: 0x04005706 RID: 22278
		LightModelAmbient,
		// Token: 0x04005707 RID: 22279
		ColorMaterial = 2903,
		// Token: 0x04005708 RID: 22280
		Fog = 2912,
		// Token: 0x04005709 RID: 22281
		FogIndex,
		// Token: 0x0400570A RID: 22282
		FogDensity,
		// Token: 0x0400570B RID: 22283
		FogStart,
		// Token: 0x0400570C RID: 22284
		FogEnd,
		// Token: 0x0400570D RID: 22285
		FogMode,
		// Token: 0x0400570E RID: 22286
		FogColor,
		// Token: 0x0400570F RID: 22287
		DepthRange = 2928,
		// Token: 0x04005710 RID: 22288
		DepthTest,
		// Token: 0x04005711 RID: 22289
		DepthWritemask,
		// Token: 0x04005712 RID: 22290
		DepthClearValue,
		// Token: 0x04005713 RID: 22291
		DepthFunc,
		// Token: 0x04005714 RID: 22292
		StencilTest = 2960,
		// Token: 0x04005715 RID: 22293
		StencilClearValue,
		// Token: 0x04005716 RID: 22294
		StencilFunc,
		// Token: 0x04005717 RID: 22295
		StencilValueMask,
		// Token: 0x04005718 RID: 22296
		StencilFail,
		// Token: 0x04005719 RID: 22297
		StencilPassDepthFail,
		// Token: 0x0400571A RID: 22298
		StencilPassDepthPass,
		// Token: 0x0400571B RID: 22299
		StencilRef,
		// Token: 0x0400571C RID: 22300
		StencilWritemask,
		// Token: 0x0400571D RID: 22301
		Normalize = 2977,
		// Token: 0x0400571E RID: 22302
		Viewport,
		// Token: 0x0400571F RID: 22303
		Modelview0StackDepthExt,
		// Token: 0x04005720 RID: 22304
		Modelview0MatrixExt = 2982,
		// Token: 0x04005721 RID: 22305
		AlphaTest = 3008,
		// Token: 0x04005722 RID: 22306
		AlphaTestQcom = 3008,
		// Token: 0x04005723 RID: 22307
		AlphaTestFuncQcom,
		// Token: 0x04005724 RID: 22308
		AlphaTestRefQcom,
		// Token: 0x04005725 RID: 22309
		Dither = 3024,
		// Token: 0x04005726 RID: 22310
		BlendDst = 3040,
		// Token: 0x04005727 RID: 22311
		BlendSrc,
		// Token: 0x04005728 RID: 22312
		Blend,
		// Token: 0x04005729 RID: 22313
		LogicOpMode = 3056,
		// Token: 0x0400572A RID: 22314
		IndexLogicOp,
		// Token: 0x0400572B RID: 22315
		LogicOp = 3057,
		// Token: 0x0400572C RID: 22316
		ColorLogicOp,
		// Token: 0x0400572D RID: 22317
		DrawBuffer = 3073,
		// Token: 0x0400572E RID: 22318
		DrawBufferExt = 3073,
		// Token: 0x0400572F RID: 22319
		ReadBuffer,
		// Token: 0x04005730 RID: 22320
		ReadBufferExt = 3074,
		// Token: 0x04005731 RID: 22321
		ReadBufferNv = 3074,
		// Token: 0x04005732 RID: 22322
		ScissorBox = 3088,
		// Token: 0x04005733 RID: 22323
		ScissorTest,
		// Token: 0x04005734 RID: 22324
		ColorClearValue = 3106,
		// Token: 0x04005735 RID: 22325
		ColorWritemask,
		// Token: 0x04005736 RID: 22326
		Doublebuffer = 3122,
		// Token: 0x04005737 RID: 22327
		Stereo,
		// Token: 0x04005738 RID: 22328
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04005739 RID: 22329
		PointSmoothHint,
		// Token: 0x0400573A RID: 22330
		LineSmoothHint,
		// Token: 0x0400573B RID: 22331
		PolygonSmoothHint,
		// Token: 0x0400573C RID: 22332
		FogHint,
		// Token: 0x0400573D RID: 22333
		TextureGenS = 3168,
		// Token: 0x0400573E RID: 22334
		TextureGenT,
		// Token: 0x0400573F RID: 22335
		TextureGenR,
		// Token: 0x04005740 RID: 22336
		TextureGenQ,
		// Token: 0x04005741 RID: 22337
		PixelMapIToI = 3184,
		// Token: 0x04005742 RID: 22338
		PixelMapSToS,
		// Token: 0x04005743 RID: 22339
		PixelMapIToR,
		// Token: 0x04005744 RID: 22340
		PixelMapIToG,
		// Token: 0x04005745 RID: 22341
		PixelMapIToB,
		// Token: 0x04005746 RID: 22342
		PixelMapIToA,
		// Token: 0x04005747 RID: 22343
		PixelMapRToR,
		// Token: 0x04005748 RID: 22344
		PixelMapGToG,
		// Token: 0x04005749 RID: 22345
		PixelMapBToB,
		// Token: 0x0400574A RID: 22346
		PixelMapAToA,
		// Token: 0x0400574B RID: 22347
		UnpackSwapBytes = 3312,
		// Token: 0x0400574C RID: 22348
		UnpackLsbFirst,
		// Token: 0x0400574D RID: 22349
		UnpackRowLength,
		// Token: 0x0400574E RID: 22350
		UnpackRowLengthExt = 3314,
		// Token: 0x0400574F RID: 22351
		UnpackSkipRows,
		// Token: 0x04005750 RID: 22352
		UnpackSkipRowsExt = 3315,
		// Token: 0x04005751 RID: 22353
		UnpackSkipPixels,
		// Token: 0x04005752 RID: 22354
		UnpackSkipPixelsExt = 3316,
		// Token: 0x04005753 RID: 22355
		UnpackAlignment,
		// Token: 0x04005754 RID: 22356
		PackSwapBytes = 3328,
		// Token: 0x04005755 RID: 22357
		PackLsbFirst,
		// Token: 0x04005756 RID: 22358
		PackRowLength,
		// Token: 0x04005757 RID: 22359
		PackSkipRows,
		// Token: 0x04005758 RID: 22360
		PackSkipPixels,
		// Token: 0x04005759 RID: 22361
		PackAlignment,
		// Token: 0x0400575A RID: 22362
		MapColor = 3344,
		// Token: 0x0400575B RID: 22363
		MapStencil,
		// Token: 0x0400575C RID: 22364
		IndexShift,
		// Token: 0x0400575D RID: 22365
		IndexOffset,
		// Token: 0x0400575E RID: 22366
		RedScale,
		// Token: 0x0400575F RID: 22367
		RedBias,
		// Token: 0x04005760 RID: 22368
		GreenScale = 3352,
		// Token: 0x04005761 RID: 22369
		GreenBias,
		// Token: 0x04005762 RID: 22370
		BlueScale,
		// Token: 0x04005763 RID: 22371
		BlueBias,
		// Token: 0x04005764 RID: 22372
		AlphaScale,
		// Token: 0x04005765 RID: 22373
		AlphaBias,
		// Token: 0x04005766 RID: 22374
		DepthScale,
		// Token: 0x04005767 RID: 22375
		DepthBias,
		// Token: 0x04005768 RID: 22376
		MaxClipDistances = 3378,
		// Token: 0x04005769 RID: 22377
		MaxTextureSize,
		// Token: 0x0400576A RID: 22378
		MaxViewportDims = 3386,
		// Token: 0x0400576B RID: 22379
		SubpixelBits = 3408,
		// Token: 0x0400576C RID: 22380
		AutoNormal = 3456,
		// Token: 0x0400576D RID: 22381
		Map1Color4 = 3472,
		// Token: 0x0400576E RID: 22382
		Map1Index,
		// Token: 0x0400576F RID: 22383
		Map1Normal,
		// Token: 0x04005770 RID: 22384
		Map1TextureCoord1,
		// Token: 0x04005771 RID: 22385
		Map1TextureCoord2,
		// Token: 0x04005772 RID: 22386
		Map1TextureCoord3,
		// Token: 0x04005773 RID: 22387
		Map1TextureCoord4,
		// Token: 0x04005774 RID: 22388
		Map1Vertex3,
		// Token: 0x04005775 RID: 22389
		Map1Vertex4,
		// Token: 0x04005776 RID: 22390
		Map2Color4 = 3504,
		// Token: 0x04005777 RID: 22391
		Map2Index,
		// Token: 0x04005778 RID: 22392
		Map2Normal,
		// Token: 0x04005779 RID: 22393
		Map2TextureCoord1,
		// Token: 0x0400577A RID: 22394
		Map2TextureCoord2,
		// Token: 0x0400577B RID: 22395
		Map2TextureCoord3,
		// Token: 0x0400577C RID: 22396
		Map2TextureCoord4,
		// Token: 0x0400577D RID: 22397
		Map2Vertex3,
		// Token: 0x0400577E RID: 22398
		Map2Vertex4,
		// Token: 0x0400577F RID: 22399
		Texture1D = 3552,
		// Token: 0x04005780 RID: 22400
		Texture2D,
		// Token: 0x04005781 RID: 22401
		TextureWidth = 4096,
		// Token: 0x04005782 RID: 22402
		TextureHeight,
		// Token: 0x04005783 RID: 22403
		TextureInternalFormat = 4099,
		// Token: 0x04005784 RID: 22404
		TextureBorderColor,
		// Token: 0x04005785 RID: 22405
		TextureBorderColorNv = 4100,
		// Token: 0x04005786 RID: 22406
		DontCare = 4352,
		// Token: 0x04005787 RID: 22407
		Fastest,
		// Token: 0x04005788 RID: 22408
		Nicest,
		// Token: 0x04005789 RID: 22409
		Ambient = 4608,
		// Token: 0x0400578A RID: 22410
		Diffuse,
		// Token: 0x0400578B RID: 22411
		Specular,
		// Token: 0x0400578C RID: 22412
		Byte = 5120,
		// Token: 0x0400578D RID: 22413
		UnsignedByte,
		// Token: 0x0400578E RID: 22414
		Short,
		// Token: 0x0400578F RID: 22415
		UnsignedShort,
		// Token: 0x04005790 RID: 22416
		Int,
		// Token: 0x04005791 RID: 22417
		UnsignedInt,
		// Token: 0x04005792 RID: 22418
		Float,
		// Token: 0x04005793 RID: 22419
		Double = 5130,
		// Token: 0x04005794 RID: 22420
		HalfFloat,
		// Token: 0x04005795 RID: 22421
		Fixed,
		// Token: 0x04005796 RID: 22422
		UnsignedInt64Arb = 5135,
		// Token: 0x04005797 RID: 22423
		Clear = 5376,
		// Token: 0x04005798 RID: 22424
		And,
		// Token: 0x04005799 RID: 22425
		AndReverse,
		// Token: 0x0400579A RID: 22426
		Copy,
		// Token: 0x0400579B RID: 22427
		AndInverted,
		// Token: 0x0400579C RID: 22428
		Noop,
		// Token: 0x0400579D RID: 22429
		Xor,
		// Token: 0x0400579E RID: 22430
		Or,
		// Token: 0x0400579F RID: 22431
		Nor,
		// Token: 0x040057A0 RID: 22432
		Equiv,
		// Token: 0x040057A1 RID: 22433
		Invert,
		// Token: 0x040057A2 RID: 22434
		OrReverse,
		// Token: 0x040057A3 RID: 22435
		CopyInverted,
		// Token: 0x040057A4 RID: 22436
		OrInverted,
		// Token: 0x040057A5 RID: 22437
		Nand,
		// Token: 0x040057A6 RID: 22438
		Set,
		// Token: 0x040057A7 RID: 22439
		Emission = 5632,
		// Token: 0x040057A8 RID: 22440
		AmbientAndDiffuse = 5634,
		// Token: 0x040057A9 RID: 22441
		Modelview0Ext = 5888,
		// Token: 0x040057AA RID: 22442
		Texture = 5890,
		// Token: 0x040057AB RID: 22443
		Color = 6144,
		// Token: 0x040057AC RID: 22444
		ColorExt = 6144,
		// Token: 0x040057AD RID: 22445
		Depth,
		// Token: 0x040057AE RID: 22446
		DepthExt = 6145,
		// Token: 0x040057AF RID: 22447
		Stencil,
		// Token: 0x040057B0 RID: 22448
		StencilExt = 6146,
		// Token: 0x040057B1 RID: 22449
		ColorIndex = 6400,
		// Token: 0x040057B2 RID: 22450
		StencilIndex,
		// Token: 0x040057B3 RID: 22451
		DepthComponent,
		// Token: 0x040057B4 RID: 22452
		Red,
		// Token: 0x040057B5 RID: 22453
		RedExt = 6403,
		// Token: 0x040057B6 RID: 22454
		Green,
		// Token: 0x040057B7 RID: 22455
		Blue,
		// Token: 0x040057B8 RID: 22456
		Alpha,
		// Token: 0x040057B9 RID: 22457
		Rgb,
		// Token: 0x040057BA RID: 22458
		Rgba,
		// Token: 0x040057BB RID: 22459
		Luminance,
		// Token: 0x040057BC RID: 22460
		LuminanceAlpha,
		// Token: 0x040057BD RID: 22461
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x040057BE RID: 22462
		ConserveMemoryHintPgi = 107005,
		// Token: 0x040057BF RID: 22463
		ReclaimMemoryHintPgi,
		// Token: 0x040057C0 RID: 22464
		NativeGraphicsBeginHintPgi = 107011,
		// Token: 0x040057C1 RID: 22465
		NativeGraphicsEndHintPgi,
		// Token: 0x040057C2 RID: 22466
		AlwaysFastHintPgi = 107020,
		// Token: 0x040057C3 RID: 22467
		AlwaysSoftHintPgi,
		// Token: 0x040057C4 RID: 22468
		AllowDrawObjHintPgi,
		// Token: 0x040057C5 RID: 22469
		AllowDrawWinHintPgi,
		// Token: 0x040057C6 RID: 22470
		AllowDrawFrgHintPgi,
		// Token: 0x040057C7 RID: 22471
		AllowDrawMemHintPgi,
		// Token: 0x040057C8 RID: 22472
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x040057C9 RID: 22473
		StrictLightingHintPgi,
		// Token: 0x040057CA RID: 22474
		StrictScissorHintPgi,
		// Token: 0x040057CB RID: 22475
		FullStippleHintPgi,
		// Token: 0x040057CC RID: 22476
		ClipNearHintPgi = 107040,
		// Token: 0x040057CD RID: 22477
		ClipFarHintPgi,
		// Token: 0x040057CE RID: 22478
		WideLineHintPgi,
		// Token: 0x040057CF RID: 22479
		BackNormalsHintPgi,
		// Token: 0x040057D0 RID: 22480
		VertexDataHintPgi = 107050,
		// Token: 0x040057D1 RID: 22481
		VertexConsistentHintPgi,
		// Token: 0x040057D2 RID: 22482
		MaterialSideHintPgi,
		// Token: 0x040057D3 RID: 22483
		MaxVertexHintPgi,
		// Token: 0x040057D4 RID: 22484
		Point = 6912,
		// Token: 0x040057D5 RID: 22485
		Line,
		// Token: 0x040057D6 RID: 22486
		Fill,
		// Token: 0x040057D7 RID: 22487
		Keep = 7680,
		// Token: 0x040057D8 RID: 22488
		Replace,
		// Token: 0x040057D9 RID: 22489
		Incr,
		// Token: 0x040057DA RID: 22490
		Decr,
		// Token: 0x040057DB RID: 22491
		Vendor = 7936,
		// Token: 0x040057DC RID: 22492
		Renderer,
		// Token: 0x040057DD RID: 22493
		Version,
		// Token: 0x040057DE RID: 22494
		Extensions,
		// Token: 0x040057DF RID: 22495
		MultisampleBit = 536870912,
		// Token: 0x040057E0 RID: 22496
		MultisampleBit3Dfx = 536870912,
		// Token: 0x040057E1 RID: 22497
		MultisampleBitArb = 536870912,
		// Token: 0x040057E2 RID: 22498
		MultisampleBitExt = 536870912,
		// Token: 0x040057E3 RID: 22499
		Modulate = 8448,
		// Token: 0x040057E4 RID: 22500
		Nearest = 9728,
		// Token: 0x040057E5 RID: 22501
		Linear,
		// Token: 0x040057E6 RID: 22502
		NearestMipmapNearest = 9984,
		// Token: 0x040057E7 RID: 22503
		LinearMipmapNearest,
		// Token: 0x040057E8 RID: 22504
		NearestMipmapLinear,
		// Token: 0x040057E9 RID: 22505
		LinearMipmapLinear,
		// Token: 0x040057EA RID: 22506
		TextureMagFilter = 10240,
		// Token: 0x040057EB RID: 22507
		TextureMinFilter,
		// Token: 0x040057EC RID: 22508
		TextureWrapS,
		// Token: 0x040057ED RID: 22509
		TextureWrapT,
		// Token: 0x040057EE RID: 22510
		Repeat = 10497,
		// Token: 0x040057EF RID: 22511
		PolygonOffsetUnits = 10752,
		// Token: 0x040057F0 RID: 22512
		PolygonOffsetPoint,
		// Token: 0x040057F1 RID: 22513
		PolygonOffsetLine,
		// Token: 0x040057F2 RID: 22514
		R3G3B2 = 10768,
		// Token: 0x040057F3 RID: 22515
		ClipDistance0 = 12288,
		// Token: 0x040057F4 RID: 22516
		ClipPlane0 = 12288,
		// Token: 0x040057F5 RID: 22517
		ClipDistance1,
		// Token: 0x040057F6 RID: 22518
		ClipPlane1 = 12289,
		// Token: 0x040057F7 RID: 22519
		ClipDistance2,
		// Token: 0x040057F8 RID: 22520
		ClipPlane2 = 12290,
		// Token: 0x040057F9 RID: 22521
		ClipDistance3,
		// Token: 0x040057FA RID: 22522
		ClipPlane3 = 12291,
		// Token: 0x040057FB RID: 22523
		ClipDistance4,
		// Token: 0x040057FC RID: 22524
		ClipPlane4 = 12292,
		// Token: 0x040057FD RID: 22525
		ClipDistance5,
		// Token: 0x040057FE RID: 22526
		ClipPlane5 = 12293,
		// Token: 0x040057FF RID: 22527
		ClipDistance6,
		// Token: 0x04005800 RID: 22528
		ClipDistance7,
		// Token: 0x04005801 RID: 22529
		Light0 = 16384,
		// Token: 0x04005802 RID: 22530
		Light1,
		// Token: 0x04005803 RID: 22531
		Light2,
		// Token: 0x04005804 RID: 22532
		Light3,
		// Token: 0x04005805 RID: 22533
		Light4,
		// Token: 0x04005806 RID: 22534
		Light5,
		// Token: 0x04005807 RID: 22535
		Light6,
		// Token: 0x04005808 RID: 22536
		Light7,
		// Token: 0x04005809 RID: 22537
		AbgrExt = 32768,
		// Token: 0x0400580A RID: 22538
		ConstantColor,
		// Token: 0x0400580B RID: 22539
		ConstantColorExt = 32769,
		// Token: 0x0400580C RID: 22540
		OneMinusConstantColor,
		// Token: 0x0400580D RID: 22541
		OneMinusConstantColorExt = 32770,
		// Token: 0x0400580E RID: 22542
		ConstantAlpha,
		// Token: 0x0400580F RID: 22543
		ConstantAlphaExt = 32771,
		// Token: 0x04005810 RID: 22544
		OneMinusConstantAlpha,
		// Token: 0x04005811 RID: 22545
		OneMinusConstantAlphaExt = 32772,
		// Token: 0x04005812 RID: 22546
		BlendColor,
		// Token: 0x04005813 RID: 22547
		BlendColorExt = 32773,
		// Token: 0x04005814 RID: 22548
		FuncAdd,
		// Token: 0x04005815 RID: 22549
		FuncAddExt = 32774,
		// Token: 0x04005816 RID: 22550
		Min,
		// Token: 0x04005817 RID: 22551
		MinExt = 32775,
		// Token: 0x04005818 RID: 22552
		Max,
		// Token: 0x04005819 RID: 22553
		MaxExt = 32776,
		// Token: 0x0400581A RID: 22554
		BlendEquation,
		// Token: 0x0400581B RID: 22555
		BlendEquationExt = 32777,
		// Token: 0x0400581C RID: 22556
		BlendEquationRgb = 32777,
		// Token: 0x0400581D RID: 22557
		FuncSubtract,
		// Token: 0x0400581E RID: 22558
		FuncSubtractExt = 32778,
		// Token: 0x0400581F RID: 22559
		FuncReverseSubtract,
		// Token: 0x04005820 RID: 22560
		FuncReverseSubtractExt = 32779,
		// Token: 0x04005821 RID: 22561
		CmykExt,
		// Token: 0x04005822 RID: 22562
		CmykaExt,
		// Token: 0x04005823 RID: 22563
		PackCmykHintExt,
		// Token: 0x04005824 RID: 22564
		UnpackCmykHintExt,
		// Token: 0x04005825 RID: 22565
		Convolution1D,
		// Token: 0x04005826 RID: 22566
		Convolution1DExt = 32784,
		// Token: 0x04005827 RID: 22567
		Convolution2D,
		// Token: 0x04005828 RID: 22568
		Convolution2DExt = 32785,
		// Token: 0x04005829 RID: 22569
		Separable2D,
		// Token: 0x0400582A RID: 22570
		Separable2DExt = 32786,
		// Token: 0x0400582B RID: 22571
		ConvolutionBorderMode,
		// Token: 0x0400582C RID: 22572
		ConvolutionBorderModeExt = 32787,
		// Token: 0x0400582D RID: 22573
		ConvolutionFilterScale,
		// Token: 0x0400582E RID: 22574
		ConvolutionFilterScaleExt = 32788,
		// Token: 0x0400582F RID: 22575
		ConvolutionFilterBias,
		// Token: 0x04005830 RID: 22576
		ConvolutionFilterBiasExt = 32789,
		// Token: 0x04005831 RID: 22577
		Reduce,
		// Token: 0x04005832 RID: 22578
		ReduceExt = 32790,
		// Token: 0x04005833 RID: 22579
		ConvolutionFormat,
		// Token: 0x04005834 RID: 22580
		ConvolutionFormatExt = 32791,
		// Token: 0x04005835 RID: 22581
		ConvolutionWidth,
		// Token: 0x04005836 RID: 22582
		ConvolutionWidthExt = 32792,
		// Token: 0x04005837 RID: 22583
		ConvolutionHeight,
		// Token: 0x04005838 RID: 22584
		ConvolutionHeightExt = 32793,
		// Token: 0x04005839 RID: 22585
		MaxConvolutionWidth,
		// Token: 0x0400583A RID: 22586
		MaxConvolutionWidthExt = 32794,
		// Token: 0x0400583B RID: 22587
		MaxConvolutionHeight,
		// Token: 0x0400583C RID: 22588
		MaxConvolutionHeightExt = 32795,
		// Token: 0x0400583D RID: 22589
		PostConvolutionRedScale,
		// Token: 0x0400583E RID: 22590
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x0400583F RID: 22591
		PostConvolutionGreenScale,
		// Token: 0x04005840 RID: 22592
		PostConvolutionGreenScaleExt = 32797,
		// Token: 0x04005841 RID: 22593
		PostConvolutionBlueScale,
		// Token: 0x04005842 RID: 22594
		PostConvolutionBlueScaleExt = 32798,
		// Token: 0x04005843 RID: 22595
		PostConvolutionAlphaScale,
		// Token: 0x04005844 RID: 22596
		PostConvolutionAlphaScaleExt = 32799,
		// Token: 0x04005845 RID: 22597
		PostConvolutionRedBias,
		// Token: 0x04005846 RID: 22598
		PostConvolutionRedBiasExt = 32800,
		// Token: 0x04005847 RID: 22599
		PostConvolutionGreenBias,
		// Token: 0x04005848 RID: 22600
		PostConvolutionGreenBiasExt = 32801,
		// Token: 0x04005849 RID: 22601
		PostConvolutionBlueBias,
		// Token: 0x0400584A RID: 22602
		PostConvolutionBlueBiasExt = 32802,
		// Token: 0x0400584B RID: 22603
		PostConvolutionAlphaBias,
		// Token: 0x0400584C RID: 22604
		PostConvolutionAlphaBiasExt = 32803,
		// Token: 0x0400584D RID: 22605
		Histogram,
		// Token: 0x0400584E RID: 22606
		HistogramExt = 32804,
		// Token: 0x0400584F RID: 22607
		ProxyHistogram,
		// Token: 0x04005850 RID: 22608
		ProxyHistogramExt = 32805,
		// Token: 0x04005851 RID: 22609
		HistogramWidth,
		// Token: 0x04005852 RID: 22610
		HistogramWidthExt = 32806,
		// Token: 0x04005853 RID: 22611
		HistogramFormat,
		// Token: 0x04005854 RID: 22612
		HistogramFormatExt = 32807,
		// Token: 0x04005855 RID: 22613
		HistogramRedSize,
		// Token: 0x04005856 RID: 22614
		HistogramRedSizeExt = 32808,
		// Token: 0x04005857 RID: 22615
		HistogramGreenSize,
		// Token: 0x04005858 RID: 22616
		HistogramGreenSizeExt = 32809,
		// Token: 0x04005859 RID: 22617
		HistogramBlueSize,
		// Token: 0x0400585A RID: 22618
		HistogramBlueSizeExt = 32810,
		// Token: 0x0400585B RID: 22619
		HistogramAlphaSize,
		// Token: 0x0400585C RID: 22620
		HistogramAlphaSizeExt = 32811,
		// Token: 0x0400585D RID: 22621
		HistogramLuminanceSize,
		// Token: 0x0400585E RID: 22622
		HistogramLuminanceSizeExt = 32812,
		// Token: 0x0400585F RID: 22623
		HistogramSink,
		// Token: 0x04005860 RID: 22624
		HistogramSinkExt = 32813,
		// Token: 0x04005861 RID: 22625
		Minmax,
		// Token: 0x04005862 RID: 22626
		MinmaxExt = 32814,
		// Token: 0x04005863 RID: 22627
		MinmaxFormat,
		// Token: 0x04005864 RID: 22628
		MinmaxFormatExt = 32815,
		// Token: 0x04005865 RID: 22629
		MinmaxSink,
		// Token: 0x04005866 RID: 22630
		MinmaxSinkExt = 32816,
		// Token: 0x04005867 RID: 22631
		TableTooLarge,
		// Token: 0x04005868 RID: 22632
		TableTooLargeExt = 32817,
		// Token: 0x04005869 RID: 22633
		UnsignedByte332,
		// Token: 0x0400586A RID: 22634
		UnsignedByte332Ext = 32818,
		// Token: 0x0400586B RID: 22635
		UnsignedShort4444,
		// Token: 0x0400586C RID: 22636
		UnsignedShort4444Ext = 32819,
		// Token: 0x0400586D RID: 22637
		UnsignedShort5551,
		// Token: 0x0400586E RID: 22638
		UnsignedShort5551Ext = 32820,
		// Token: 0x0400586F RID: 22639
		UnsignedInt8888,
		// Token: 0x04005870 RID: 22640
		UnsignedInt8888Ext = 32821,
		// Token: 0x04005871 RID: 22641
		UnsignedInt1010102,
		// Token: 0x04005872 RID: 22642
		UnsignedInt1010102Ext = 32822,
		// Token: 0x04005873 RID: 22643
		PolygonOffsetFill,
		// Token: 0x04005874 RID: 22644
		PolygonOffsetFactor,
		// Token: 0x04005875 RID: 22645
		PolygonOffsetBiasExt,
		// Token: 0x04005876 RID: 22646
		RescaleNormal,
		// Token: 0x04005877 RID: 22647
		RescaleNormalExt = 32826,
		// Token: 0x04005878 RID: 22648
		Rgb2Ext = 32846,
		// Token: 0x04005879 RID: 22649
		Rgb4,
		// Token: 0x0400587A RID: 22650
		Rgb5,
		// Token: 0x0400587B RID: 22651
		Rgb8,
		// Token: 0x0400587C RID: 22652
		Rgb10,
		// Token: 0x0400587D RID: 22653
		Rgb12,
		// Token: 0x0400587E RID: 22654
		Rgb16,
		// Token: 0x0400587F RID: 22655
		Rgba2,
		// Token: 0x04005880 RID: 22656
		Rgba4,
		// Token: 0x04005881 RID: 22657
		Rgb5A1,
		// Token: 0x04005882 RID: 22658
		Rgba8,
		// Token: 0x04005883 RID: 22659
		Rgb10A2,
		// Token: 0x04005884 RID: 22660
		Rgba12,
		// Token: 0x04005885 RID: 22661
		Rgba16,
		// Token: 0x04005886 RID: 22662
		TextureRedSize,
		// Token: 0x04005887 RID: 22663
		TextureGreenSize,
		// Token: 0x04005888 RID: 22664
		TextureBlueSize,
		// Token: 0x04005889 RID: 22665
		TextureAlphaSize,
		// Token: 0x0400588A RID: 22666
		ReplaceExt = 32866,
		// Token: 0x0400588B RID: 22667
		ProxyTexture1D,
		// Token: 0x0400588C RID: 22668
		ProxyTexture1DExt = 32867,
		// Token: 0x0400588D RID: 22669
		ProxyTexture2D,
		// Token: 0x0400588E RID: 22670
		ProxyTexture2DExt = 32868,
		// Token: 0x0400588F RID: 22671
		TextureTooLargeExt,
		// Token: 0x04005890 RID: 22672
		TexturePriority,
		// Token: 0x04005891 RID: 22673
		TexturePriorityExt = 32870,
		// Token: 0x04005892 RID: 22674
		TextureBinding1D = 32872,
		// Token: 0x04005893 RID: 22675
		TextureBinding2D,
		// Token: 0x04005894 RID: 22676
		Texture3DBindingExt,
		// Token: 0x04005895 RID: 22677
		TextureBinding3D = 32874,
		// Token: 0x04005896 RID: 22678
		PackSkipImages,
		// Token: 0x04005897 RID: 22679
		PackSkipImagesExt = 32875,
		// Token: 0x04005898 RID: 22680
		PackImageHeight,
		// Token: 0x04005899 RID: 22681
		PackImageHeightExt = 32876,
		// Token: 0x0400589A RID: 22682
		UnpackSkipImages,
		// Token: 0x0400589B RID: 22683
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400589C RID: 22684
		UnpackImageHeight,
		// Token: 0x0400589D RID: 22685
		UnpackImageHeightExt = 32878,
		// Token: 0x0400589E RID: 22686
		Texture3D,
		// Token: 0x0400589F RID: 22687
		Texture3DExt = 32879,
		// Token: 0x040058A0 RID: 22688
		Texture3DOes = 32879,
		// Token: 0x040058A1 RID: 22689
		ProxyTexture3D,
		// Token: 0x040058A2 RID: 22690
		ProxyTexture3DExt = 32880,
		// Token: 0x040058A3 RID: 22691
		TextureDepth,
		// Token: 0x040058A4 RID: 22692
		TextureDepthExt = 32881,
		// Token: 0x040058A5 RID: 22693
		TextureWrapR,
		// Token: 0x040058A6 RID: 22694
		TextureWrapRExt = 32882,
		// Token: 0x040058A7 RID: 22695
		TextureWrapROes = 32882,
		// Token: 0x040058A8 RID: 22696
		Max3DTextureSize,
		// Token: 0x040058A9 RID: 22697
		Max3DTextureSizeExt = 32883,
		// Token: 0x040058AA RID: 22698
		VertexArray,
		// Token: 0x040058AB RID: 22699
		VertexArrayKhr = 32884,
		// Token: 0x040058AC RID: 22700
		NormalArray,
		// Token: 0x040058AD RID: 22701
		ColorArray,
		// Token: 0x040058AE RID: 22702
		IndexArray,
		// Token: 0x040058AF RID: 22703
		TextureCoordArray,
		// Token: 0x040058B0 RID: 22704
		EdgeFlagArray,
		// Token: 0x040058B1 RID: 22705
		VertexArrayCountExt = 32893,
		// Token: 0x040058B2 RID: 22706
		NormalArrayCountExt = 32896,
		// Token: 0x040058B3 RID: 22707
		ColorArrayCountExt = 32900,
		// Token: 0x040058B4 RID: 22708
		IndexArrayCountExt = 32903,
		// Token: 0x040058B5 RID: 22709
		TextureCoordArrayCountExt = 32907,
		// Token: 0x040058B6 RID: 22710
		EdgeFlagArrayCountExt = 32909,
		// Token: 0x040058B7 RID: 22711
		VertexArrayPointerExt,
		// Token: 0x040058B8 RID: 22712
		NormalArrayPointerExt,
		// Token: 0x040058B9 RID: 22713
		ColorArrayPointerExt,
		// Token: 0x040058BA RID: 22714
		IndexArrayPointerExt,
		// Token: 0x040058BB RID: 22715
		TextureCoordArrayPointerExt,
		// Token: 0x040058BC RID: 22716
		EdgeFlagArrayPointerExt,
		// Token: 0x040058BD RID: 22717
		InterlaceSgix,
		// Token: 0x040058BE RID: 22718
		DetailTexture2DSgis,
		// Token: 0x040058BF RID: 22719
		DetailTexture2DBindingSgis,
		// Token: 0x040058C0 RID: 22720
		LinearDetailSgis,
		// Token: 0x040058C1 RID: 22721
		LinearDetailAlphaSgis,
		// Token: 0x040058C2 RID: 22722
		LinearDetailColorSgis,
		// Token: 0x040058C3 RID: 22723
		DetailTextureLevelSgis,
		// Token: 0x040058C4 RID: 22724
		DetailTextureModeSgis,
		// Token: 0x040058C5 RID: 22725
		DetailTextureFuncPointsSgis,
		// Token: 0x040058C6 RID: 22726
		Multisample,
		// Token: 0x040058C7 RID: 22727
		MultisampleSgis = 32925,
		// Token: 0x040058C8 RID: 22728
		SampleAlphaToCoverage,
		// Token: 0x040058C9 RID: 22729
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x040058CA RID: 22730
		SampleAlphaToOne,
		// Token: 0x040058CB RID: 22731
		SampleAlphaToOneSgis = 32927,
		// Token: 0x040058CC RID: 22732
		SampleCoverage,
		// Token: 0x040058CD RID: 22733
		SampleMaskSgis = 32928,
		// Token: 0x040058CE RID: 22734
		Gl1PassExt,
		// Token: 0x040058CF RID: 22735
		Gl1PassSgis = 32929,
		// Token: 0x040058D0 RID: 22736
		Gl2Pass0Ext,
		// Token: 0x040058D1 RID: 22737
		Gl2Pass0Sgis = 32930,
		// Token: 0x040058D2 RID: 22738
		Gl2Pass1Ext,
		// Token: 0x040058D3 RID: 22739
		Gl2Pass1Sgis = 32931,
		// Token: 0x040058D4 RID: 22740
		Gl4Pass0Ext,
		// Token: 0x040058D5 RID: 22741
		Gl4Pass0Sgis = 32932,
		// Token: 0x040058D6 RID: 22742
		Gl4Pass1Ext,
		// Token: 0x040058D7 RID: 22743
		Gl4Pass1Sgis = 32933,
		// Token: 0x040058D8 RID: 22744
		Gl4Pass2Ext,
		// Token: 0x040058D9 RID: 22745
		Gl4Pass2Sgis = 32934,
		// Token: 0x040058DA RID: 22746
		Gl4Pass3Ext,
		// Token: 0x040058DB RID: 22747
		Gl4Pass3Sgis = 32935,
		// Token: 0x040058DC RID: 22748
		SampleBuffers,
		// Token: 0x040058DD RID: 22749
		SampleBuffersSgis = 32936,
		// Token: 0x040058DE RID: 22750
		Samples,
		// Token: 0x040058DF RID: 22751
		SamplesSgis = 32937,
		// Token: 0x040058E0 RID: 22752
		SampleCoverageValue,
		// Token: 0x040058E1 RID: 22753
		SampleMaskValueSgis = 32938,
		// Token: 0x040058E2 RID: 22754
		SampleCoverageInvert,
		// Token: 0x040058E3 RID: 22755
		SampleMaskInvertSgis = 32939,
		// Token: 0x040058E4 RID: 22756
		SamplePatternSgis,
		// Token: 0x040058E5 RID: 22757
		LinearSharpenSgis,
		// Token: 0x040058E6 RID: 22758
		LinearSharpenAlphaSgis,
		// Token: 0x040058E7 RID: 22759
		LinearSharpenColorSgis,
		// Token: 0x040058E8 RID: 22760
		SharpenTextureFuncPointsSgis,
		// Token: 0x040058E9 RID: 22761
		ColorMatrix,
		// Token: 0x040058EA RID: 22762
		ColorMatrixSgi = 32945,
		// Token: 0x040058EB RID: 22763
		ColorMatrixStackDepth,
		// Token: 0x040058EC RID: 22764
		ColorMatrixStackDepthSgi = 32946,
		// Token: 0x040058ED RID: 22765
		MaxColorMatrixStackDepth,
		// Token: 0x040058EE RID: 22766
		MaxColorMatrixStackDepthSgi = 32947,
		// Token: 0x040058EF RID: 22767
		PostColorMatrixRedScale,
		// Token: 0x040058F0 RID: 22768
		PostColorMatrixRedScaleSgi = 32948,
		// Token: 0x040058F1 RID: 22769
		PostColorMatrixGreenScale,
		// Token: 0x040058F2 RID: 22770
		PostColorMatrixGreenScaleSgi = 32949,
		// Token: 0x040058F3 RID: 22771
		PostColorMatrixBlueScale,
		// Token: 0x040058F4 RID: 22772
		PostColorMatrixBlueScaleSgi = 32950,
		// Token: 0x040058F5 RID: 22773
		PostColorMatrixAlphaScale,
		// Token: 0x040058F6 RID: 22774
		PostColorMatrixAlphaScaleSgi = 32951,
		// Token: 0x040058F7 RID: 22775
		PostColorMatrixRedBias,
		// Token: 0x040058F8 RID: 22776
		PostColorMatrixRedBiasSgi = 32952,
		// Token: 0x040058F9 RID: 22777
		PostColorMatrixGreenBias,
		// Token: 0x040058FA RID: 22778
		PostColorMatrixGreenBiasSgi = 32953,
		// Token: 0x040058FB RID: 22779
		PostColorMatrixBlueBias,
		// Token: 0x040058FC RID: 22780
		PostColorMatrixBlueBiasSgi = 32954,
		// Token: 0x040058FD RID: 22781
		PostColorMatrixAlphaBias,
		// Token: 0x040058FE RID: 22782
		PostColorMatrixAlphaBiasSgi = 32955,
		// Token: 0x040058FF RID: 22783
		TextureColorTableSgi,
		// Token: 0x04005900 RID: 22784
		ProxyTextureColorTableSgi,
		// Token: 0x04005901 RID: 22785
		TextureEnvBiasSgix,
		// Token: 0x04005902 RID: 22786
		ShadowAmbientSgix,
		// Token: 0x04005903 RID: 22787
		TextureCompareFailValue = 32959,
		// Token: 0x04005904 RID: 22788
		BlendDstRgb = 32968,
		// Token: 0x04005905 RID: 22789
		BlendSrcRgb,
		// Token: 0x04005906 RID: 22790
		BlendDstAlpha,
		// Token: 0x04005907 RID: 22791
		BlendSrcAlpha,
		// Token: 0x04005908 RID: 22792
		ColorTable = 32976,
		// Token: 0x04005909 RID: 22793
		ColorTableSgi = 32976,
		// Token: 0x0400590A RID: 22794
		PostConvolutionColorTable,
		// Token: 0x0400590B RID: 22795
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x0400590C RID: 22796
		PostColorMatrixColorTable,
		// Token: 0x0400590D RID: 22797
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x0400590E RID: 22798
		ProxyColorTable,
		// Token: 0x0400590F RID: 22799
		ProxyColorTableSgi = 32979,
		// Token: 0x04005910 RID: 22800
		ProxyPostConvolutionColorTable,
		// Token: 0x04005911 RID: 22801
		ProxyPostConvolutionColorTableSgi = 32980,
		// Token: 0x04005912 RID: 22802
		ProxyPostColorMatrixColorTable,
		// Token: 0x04005913 RID: 22803
		ProxyPostColorMatrixColorTableSgi = 32981,
		// Token: 0x04005914 RID: 22804
		ColorTableScale,
		// Token: 0x04005915 RID: 22805
		ColorTableScaleSgi = 32982,
		// Token: 0x04005916 RID: 22806
		ColorTableBias,
		// Token: 0x04005917 RID: 22807
		ColorTableBiasSgi = 32983,
		// Token: 0x04005918 RID: 22808
		ColorTableFormat,
		// Token: 0x04005919 RID: 22809
		ColorTableFormatSgi = 32984,
		// Token: 0x0400591A RID: 22810
		ColorTableWidth,
		// Token: 0x0400591B RID: 22811
		ColorTableWidthSgi = 32985,
		// Token: 0x0400591C RID: 22812
		ColorTableRedSize,
		// Token: 0x0400591D RID: 22813
		ColorTableRedSizeSgi = 32986,
		// Token: 0x0400591E RID: 22814
		ColorTableGreenSize,
		// Token: 0x0400591F RID: 22815
		ColorTableGreenSizeSgi = 32987,
		// Token: 0x04005920 RID: 22816
		ColorTableBlueSize,
		// Token: 0x04005921 RID: 22817
		ColorTableBlueSizeSgi = 32988,
		// Token: 0x04005922 RID: 22818
		ColorTableAlphaSize,
		// Token: 0x04005923 RID: 22819
		ColorTableAlphaSizeSgi = 32989,
		// Token: 0x04005924 RID: 22820
		ColorTableLuminanceSize,
		// Token: 0x04005925 RID: 22821
		ColorTableLuminanceSizeSgi = 32990,
		// Token: 0x04005926 RID: 22822
		ColorTableIntensitySize,
		// Token: 0x04005927 RID: 22823
		ColorTableIntensitySizeSgi = 32991,
		// Token: 0x04005928 RID: 22824
		Bgr,
		// Token: 0x04005929 RID: 22825
		Bgra,
		// Token: 0x0400592A RID: 22826
		MaxElementsVertices = 33000,
		// Token: 0x0400592B RID: 22827
		MaxElementsIndices,
		// Token: 0x0400592C RID: 22828
		PhongHintWin = 33003,
		// Token: 0x0400592D RID: 22829
		ParameterBufferArb = 33006,
		// Token: 0x0400592E RID: 22830
		ParameterBufferBindingArb,
		// Token: 0x0400592F RID: 22831
		ClipVolumeClippingHintExt,
		// Token: 0x04005930 RID: 22832
		DualAlpha4Sgis = 33040,
		// Token: 0x04005931 RID: 22833
		DualAlpha8Sgis,
		// Token: 0x04005932 RID: 22834
		DualAlpha12Sgis,
		// Token: 0x04005933 RID: 22835
		DualAlpha16Sgis,
		// Token: 0x04005934 RID: 22836
		DualLuminance4Sgis,
		// Token: 0x04005935 RID: 22837
		DualLuminance8Sgis,
		// Token: 0x04005936 RID: 22838
		DualLuminance12Sgis,
		// Token: 0x04005937 RID: 22839
		DualLuminance16Sgis,
		// Token: 0x04005938 RID: 22840
		DualIntensity4Sgis,
		// Token: 0x04005939 RID: 22841
		DualIntensity8Sgis,
		// Token: 0x0400593A RID: 22842
		DualIntensity12Sgis,
		// Token: 0x0400593B RID: 22843
		DualIntensity16Sgis,
		// Token: 0x0400593C RID: 22844
		DualLuminanceAlpha4Sgis,
		// Token: 0x0400593D RID: 22845
		DualLuminanceAlpha8Sgis,
		// Token: 0x0400593E RID: 22846
		QuadAlpha4Sgis,
		// Token: 0x0400593F RID: 22847
		QuadAlpha8Sgis,
		// Token: 0x04005940 RID: 22848
		QuadLuminance4Sgis,
		// Token: 0x04005941 RID: 22849
		QuadLuminance8Sgis,
		// Token: 0x04005942 RID: 22850
		QuadIntensity4Sgis,
		// Token: 0x04005943 RID: 22851
		QuadIntensity8Sgis,
		// Token: 0x04005944 RID: 22852
		DualTextureSelectSgis,
		// Token: 0x04005945 RID: 22853
		QuadTextureSelectSgis,
		// Token: 0x04005946 RID: 22854
		PointSizeMin,
		// Token: 0x04005947 RID: 22855
		PointSizeMinArb = 33062,
		// Token: 0x04005948 RID: 22856
		PointSizeMinExt = 33062,
		// Token: 0x04005949 RID: 22857
		PointSizeMinSgis = 33062,
		// Token: 0x0400594A RID: 22858
		PointSizeMax,
		// Token: 0x0400594B RID: 22859
		PointSizeMaxArb = 33063,
		// Token: 0x0400594C RID: 22860
		PointSizeMaxExt = 33063,
		// Token: 0x0400594D RID: 22861
		PointSizeMaxSgis = 33063,
		// Token: 0x0400594E RID: 22862
		PointFadeThresholdSize,
		// Token: 0x0400594F RID: 22863
		PointFadeThresholdSizeArb = 33064,
		// Token: 0x04005950 RID: 22864
		PointFadeThresholdSizeExt = 33064,
		// Token: 0x04005951 RID: 22865
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x04005952 RID: 22866
		DistanceAttenuationExt,
		// Token: 0x04005953 RID: 22867
		DistanceAttenuationSgis = 33065,
		// Token: 0x04005954 RID: 22868
		PointDistanceAttenuation = 33065,
		// Token: 0x04005955 RID: 22869
		PointDistanceAttenuationArb = 33065,
		// Token: 0x04005956 RID: 22870
		FogFuncSgis,
		// Token: 0x04005957 RID: 22871
		FogFuncPointsSgis,
		// Token: 0x04005958 RID: 22872
		MaxFogFuncPointsSgis,
		// Token: 0x04005959 RID: 22873
		ClampToBorder,
		// Token: 0x0400595A RID: 22874
		ClampToBorderArb = 33069,
		// Token: 0x0400595B RID: 22875
		ClampToBorderNv = 33069,
		// Token: 0x0400595C RID: 22876
		ClampToBorderSgis = 33069,
		// Token: 0x0400595D RID: 22877
		TextureMultiBufferHintSgix,
		// Token: 0x0400595E RID: 22878
		ClampToEdge,
		// Token: 0x0400595F RID: 22879
		ClampToEdgeSgis = 33071,
		// Token: 0x04005960 RID: 22880
		PackSkipVolumesSgis,
		// Token: 0x04005961 RID: 22881
		PackImageDepthSgis,
		// Token: 0x04005962 RID: 22882
		UnpackSkipVolumesSgis,
		// Token: 0x04005963 RID: 22883
		UnpackImageDepthSgis,
		// Token: 0x04005964 RID: 22884
		Texture4DSgis,
		// Token: 0x04005965 RID: 22885
		ProxyTexture4DSgis,
		// Token: 0x04005966 RID: 22886
		Texture4DsizeSgis,
		// Token: 0x04005967 RID: 22887
		TextureWrapQSgis,
		// Token: 0x04005968 RID: 22888
		Max4DTextureSizeSgis,
		// Token: 0x04005969 RID: 22889
		PixelTexGenSgix,
		// Token: 0x0400596A RID: 22890
		TextureMinLod,
		// Token: 0x0400596B RID: 22891
		TextureMinLodSgis = 33082,
		// Token: 0x0400596C RID: 22892
		TextureMaxLod,
		// Token: 0x0400596D RID: 22893
		TextureMaxLodSgis = 33083,
		// Token: 0x0400596E RID: 22894
		TextureBaseLevel,
		// Token: 0x0400596F RID: 22895
		TextureBaseLevelSgis = 33084,
		// Token: 0x04005970 RID: 22896
		TextureMaxLevel,
		// Token: 0x04005971 RID: 22897
		TextureMaxLevelSgis = 33085,
		// Token: 0x04005972 RID: 22898
		PixelTileBestAlignmentSgix,
		// Token: 0x04005973 RID: 22899
		PixelTileCacheIncrementSgix,
		// Token: 0x04005974 RID: 22900
		PixelTileWidthSgix,
		// Token: 0x04005975 RID: 22901
		PixelTileHeightSgix,
		// Token: 0x04005976 RID: 22902
		PixelTileGridWidthSgix,
		// Token: 0x04005977 RID: 22903
		PixelTileGridHeightSgix,
		// Token: 0x04005978 RID: 22904
		PixelTileGridDepthSgix,
		// Token: 0x04005979 RID: 22905
		PixelTileCacheSizeSgix,
		// Token: 0x0400597A RID: 22906
		Filter4Sgis,
		// Token: 0x0400597B RID: 22907
		TextureFilter4SizeSgis,
		// Token: 0x0400597C RID: 22908
		SpriteSgix,
		// Token: 0x0400597D RID: 22909
		SpriteModeSgix,
		// Token: 0x0400597E RID: 22910
		SpriteAxisSgix,
		// Token: 0x0400597F RID: 22911
		SpriteTranslationSgix,
		// Token: 0x04005980 RID: 22912
		Texture4DBindingSgis = 33103,
		// Token: 0x04005981 RID: 22913
		ConstantBorder = 33105,
		// Token: 0x04005982 RID: 22914
		ReplicateBorder = 33107,
		// Token: 0x04005983 RID: 22915
		ConvolutionBorderColor,
		// Token: 0x04005984 RID: 22916
		LinearClipmapLinearSgix = 33136,
		// Token: 0x04005985 RID: 22917
		TextureClipmapCenterSgix,
		// Token: 0x04005986 RID: 22918
		TextureClipmapFrameSgix,
		// Token: 0x04005987 RID: 22919
		TextureClipmapOffsetSgix,
		// Token: 0x04005988 RID: 22920
		TextureClipmapVirtualDepthSgix,
		// Token: 0x04005989 RID: 22921
		TextureClipmapLodOffsetSgix,
		// Token: 0x0400598A RID: 22922
		TextureClipmapDepthSgix,
		// Token: 0x0400598B RID: 22923
		MaxClipmapDepthSgix,
		// Token: 0x0400598C RID: 22924
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400598D RID: 22925
		PostTextureFilterBiasSgix,
		// Token: 0x0400598E RID: 22926
		PostTextureFilterScaleSgix,
		// Token: 0x0400598F RID: 22927
		PostTextureFilterBiasRangeSgix,
		// Token: 0x04005990 RID: 22928
		PostTextureFilterScaleRangeSgix,
		// Token: 0x04005991 RID: 22929
		ReferencePlaneSgix,
		// Token: 0x04005992 RID: 22930
		ReferencePlaneEquationSgix,
		// Token: 0x04005993 RID: 22931
		IrInstrument1Sgix,
		// Token: 0x04005994 RID: 22932
		InstrumentBufferPointerSgix,
		// Token: 0x04005995 RID: 22933
		InstrumentMeasurementsSgix,
		// Token: 0x04005996 RID: 22934
		ListPrioritySgix,
		// Token: 0x04005997 RID: 22935
		CalligraphicFragmentSgix,
		// Token: 0x04005998 RID: 22936
		PixelTexGenQCeilingSgix,
		// Token: 0x04005999 RID: 22937
		PixelTexGenQRoundSgix,
		// Token: 0x0400599A RID: 22938
		PixelTexGenQFloorSgix,
		// Token: 0x0400599B RID: 22939
		PixelTexGenAlphaReplaceSgix,
		// Token: 0x0400599C RID: 22940
		PixelTexGenAlphaNoReplaceSgix,
		// Token: 0x0400599D RID: 22941
		PixelTexGenAlphaLsSgix,
		// Token: 0x0400599E RID: 22942
		PixelTexGenAlphaMsSgix,
		// Token: 0x0400599F RID: 22943
		FramezoomSgix,
		// Token: 0x040059A0 RID: 22944
		FramezoomFactorSgix,
		// Token: 0x040059A1 RID: 22945
		MaxFramezoomFactorSgix,
		// Token: 0x040059A2 RID: 22946
		TextureLodBiasSSgix,
		// Token: 0x040059A3 RID: 22947
		TextureLodBiasTSgix,
		// Token: 0x040059A4 RID: 22948
		TextureLodBiasRSgix,
		// Token: 0x040059A5 RID: 22949
		GenerateMipmap,
		// Token: 0x040059A6 RID: 22950
		GenerateMipmapSgis = 33169,
		// Token: 0x040059A7 RID: 22951
		GenerateMipmapHint,
		// Token: 0x040059A8 RID: 22952
		GenerateMipmapHintSgis = 33170,
		// Token: 0x040059A9 RID: 22953
		GeometryDeformationSgix = 33172,
		// Token: 0x040059AA RID: 22954
		TextureDeformationSgix,
		// Token: 0x040059AB RID: 22955
		DeformationsMaskSgix,
		// Token: 0x040059AC RID: 22956
		FogOffsetSgix = 33176,
		// Token: 0x040059AD RID: 22957
		FogOffsetValueSgix,
		// Token: 0x040059AE RID: 22958
		TextureCompareSgix,
		// Token: 0x040059AF RID: 22959
		TextureCompareOperatorSgix,
		// Token: 0x040059B0 RID: 22960
		TextureLequalRSgix,
		// Token: 0x040059B1 RID: 22961
		TextureGequalRSgix,
		// Token: 0x040059B2 RID: 22962
		DepthComponent16 = 33189,
		// Token: 0x040059B3 RID: 22963
		DepthComponent16Sgix = 33189,
		// Token: 0x040059B4 RID: 22964
		DepthComponent24,
		// Token: 0x040059B5 RID: 22965
		DepthComponent24Sgix = 33190,
		// Token: 0x040059B6 RID: 22966
		DepthComponent32,
		// Token: 0x040059B7 RID: 22967
		DepthComponent32Sgix = 33191,
		// Token: 0x040059B8 RID: 22968
		Ycrcb422Sgix = 33211,
		// Token: 0x040059B9 RID: 22969
		Ycrcb444Sgix,
		// Token: 0x040059BA RID: 22970
		EyeDistanceToPointSgis = 33264,
		// Token: 0x040059BB RID: 22971
		ObjectDistanceToPointSgis,
		// Token: 0x040059BC RID: 22972
		EyeDistanceToLineSgis,
		// Token: 0x040059BD RID: 22973
		ObjectDistanceToLineSgis,
		// Token: 0x040059BE RID: 22974
		EyePointSgis,
		// Token: 0x040059BF RID: 22975
		ObjectPointSgis,
		// Token: 0x040059C0 RID: 22976
		EyeLineSgis,
		// Token: 0x040059C1 RID: 22977
		ObjectLineSgis,
		// Token: 0x040059C2 RID: 22978
		LightModelColorControl,
		// Token: 0x040059C3 RID: 22979
		LightModelColorControlExt = 33272,
		// Token: 0x040059C4 RID: 22980
		SingleColor,
		// Token: 0x040059C5 RID: 22981
		SingleColorExt = 33273,
		// Token: 0x040059C6 RID: 22982
		SeparateSpecularColor,
		// Token: 0x040059C7 RID: 22983
		SeparateSpecularColorExt = 33274,
		// Token: 0x040059C8 RID: 22984
		SharedTexturePaletteExt,
		// Token: 0x040059C9 RID: 22985
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x040059CA RID: 22986
		FramebufferAttachmentComponentType,
		// Token: 0x040059CB RID: 22987
		FramebufferAttachmentRedSize,
		// Token: 0x040059CC RID: 22988
		FramebufferAttachmentGreenSize,
		// Token: 0x040059CD RID: 22989
		FramebufferAttachmentBlueSize,
		// Token: 0x040059CE RID: 22990
		FramebufferAttachmentAlphaSize,
		// Token: 0x040059CF RID: 22991
		FramebufferAttachmentDepthSize,
		// Token: 0x040059D0 RID: 22992
		FramebufferAttachmentStencilSize,
		// Token: 0x040059D1 RID: 22993
		FramebufferDefault,
		// Token: 0x040059D2 RID: 22994
		FramebufferUndefined,
		// Token: 0x040059D3 RID: 22995
		DepthStencilAttachment,
		// Token: 0x040059D4 RID: 22996
		MajorVersion,
		// Token: 0x040059D5 RID: 22997
		MinorVersion,
		// Token: 0x040059D6 RID: 22998
		NumExtensions,
		// Token: 0x040059D7 RID: 22999
		ContextFlags,
		// Token: 0x040059D8 RID: 23000
		BufferImmutableStorage,
		// Token: 0x040059D9 RID: 23001
		BufferStorageFlags,
		// Token: 0x040059DA RID: 23002
		PrimitiveRestartForPatchesSupported,
		// Token: 0x040059DB RID: 23003
		Index,
		// Token: 0x040059DC RID: 23004
		CompressedRed = 33317,
		// Token: 0x040059DD RID: 23005
		CompressedRg,
		// Token: 0x040059DE RID: 23006
		Rg,
		// Token: 0x040059DF RID: 23007
		RgInteger,
		// Token: 0x040059E0 RID: 23008
		R8,
		// Token: 0x040059E1 RID: 23009
		R16,
		// Token: 0x040059E2 RID: 23010
		Rg8,
		// Token: 0x040059E3 RID: 23011
		Rg16,
		// Token: 0x040059E4 RID: 23012
		R16f,
		// Token: 0x040059E5 RID: 23013
		R32f,
		// Token: 0x040059E6 RID: 23014
		Rg16f,
		// Token: 0x040059E7 RID: 23015
		Rg32f,
		// Token: 0x040059E8 RID: 23016
		R8i,
		// Token: 0x040059E9 RID: 23017
		R8ui,
		// Token: 0x040059EA RID: 23018
		R16i,
		// Token: 0x040059EB RID: 23019
		R16ui,
		// Token: 0x040059EC RID: 23020
		R32i,
		// Token: 0x040059ED RID: 23021
		R32ui,
		// Token: 0x040059EE RID: 23022
		Rg8i,
		// Token: 0x040059EF RID: 23023
		Rg8ui,
		// Token: 0x040059F0 RID: 23024
		Rg16i,
		// Token: 0x040059F1 RID: 23025
		Rg16ui,
		// Token: 0x040059F2 RID: 23026
		Rg32i,
		// Token: 0x040059F3 RID: 23027
		Rg32ui,
		// Token: 0x040059F4 RID: 23028
		SyncClEventArb = 33344,
		// Token: 0x040059F5 RID: 23029
		SyncClEventCompleteArb,
		// Token: 0x040059F6 RID: 23030
		DebugOutputSynchronous,
		// Token: 0x040059F7 RID: 23031
		DebugOutputSynchronousArb = 33346,
		// Token: 0x040059F8 RID: 23032
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x040059F9 RID: 23033
		DebugNextLoggedMessageLength,
		// Token: 0x040059FA RID: 23034
		DebugNextLoggedMessageLengthArb = 33347,
		// Token: 0x040059FB RID: 23035
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x040059FC RID: 23036
		DebugCallbackFunction,
		// Token: 0x040059FD RID: 23037
		DebugCallbackFunctionArb = 33348,
		// Token: 0x040059FE RID: 23038
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x040059FF RID: 23039
		DebugCallbackUserParam,
		// Token: 0x04005A00 RID: 23040
		DebugCallbackUserParamArb = 33349,
		// Token: 0x04005A01 RID: 23041
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x04005A02 RID: 23042
		DebugSourceApi,
		// Token: 0x04005A03 RID: 23043
		DebugSourceApiArb = 33350,
		// Token: 0x04005A04 RID: 23044
		DebugSourceApiKhr = 33350,
		// Token: 0x04005A05 RID: 23045
		DebugSourceWindowSystem,
		// Token: 0x04005A06 RID: 23046
		DebugSourceWindowSystemArb = 33351,
		// Token: 0x04005A07 RID: 23047
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x04005A08 RID: 23048
		DebugSourceShaderCompiler,
		// Token: 0x04005A09 RID: 23049
		DebugSourceShaderCompilerArb = 33352,
		// Token: 0x04005A0A RID: 23050
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x04005A0B RID: 23051
		DebugSourceThirdParty,
		// Token: 0x04005A0C RID: 23052
		DebugSourceThirdPartyArb = 33353,
		// Token: 0x04005A0D RID: 23053
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x04005A0E RID: 23054
		DebugSourceApplication,
		// Token: 0x04005A0F RID: 23055
		DebugSourceApplicationArb = 33354,
		// Token: 0x04005A10 RID: 23056
		DebugSourceApplicationKhr = 33354,
		// Token: 0x04005A11 RID: 23057
		DebugSourceOther,
		// Token: 0x04005A12 RID: 23058
		DebugSourceOtherArb = 33355,
		// Token: 0x04005A13 RID: 23059
		DebugSourceOtherKhr = 33355,
		// Token: 0x04005A14 RID: 23060
		DebugTypeError,
		// Token: 0x04005A15 RID: 23061
		DebugTypeErrorArb = 33356,
		// Token: 0x04005A16 RID: 23062
		DebugTypeErrorKhr = 33356,
		// Token: 0x04005A17 RID: 23063
		DebugTypeDeprecatedBehavior,
		// Token: 0x04005A18 RID: 23064
		DebugTypeDeprecatedBehaviorArb = 33357,
		// Token: 0x04005A19 RID: 23065
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04005A1A RID: 23066
		DebugTypeUndefinedBehavior,
		// Token: 0x04005A1B RID: 23067
		DebugTypeUndefinedBehaviorArb = 33358,
		// Token: 0x04005A1C RID: 23068
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x04005A1D RID: 23069
		DebugTypePortability,
		// Token: 0x04005A1E RID: 23070
		DebugTypePortabilityArb = 33359,
		// Token: 0x04005A1F RID: 23071
		DebugTypePortabilityKhr = 33359,
		// Token: 0x04005A20 RID: 23072
		DebugTypePerformance,
		// Token: 0x04005A21 RID: 23073
		DebugTypePerformanceArb = 33360,
		// Token: 0x04005A22 RID: 23074
		DebugTypePerformanceKhr = 33360,
		// Token: 0x04005A23 RID: 23075
		DebugTypeOther,
		// Token: 0x04005A24 RID: 23076
		DebugTypeOtherArb = 33361,
		// Token: 0x04005A25 RID: 23077
		DebugTypeOtherKhr = 33361,
		// Token: 0x04005A26 RID: 23078
		LoseContextOnResetArb,
		// Token: 0x04005A27 RID: 23079
		GuiltyContextResetArb,
		// Token: 0x04005A28 RID: 23080
		InnocentContextResetArb,
		// Token: 0x04005A29 RID: 23081
		UnknownContextResetArb,
		// Token: 0x04005A2A RID: 23082
		ResetNotificationStrategyArb,
		// Token: 0x04005A2B RID: 23083
		ProgramBinaryRetrievableHint,
		// Token: 0x04005A2C RID: 23084
		ProgramSeparable,
		// Token: 0x04005A2D RID: 23085
		ActiveProgram,
		// Token: 0x04005A2E RID: 23086
		ProgramPipelineBinding,
		// Token: 0x04005A2F RID: 23087
		MaxViewports,
		// Token: 0x04005A30 RID: 23088
		ViewportSubpixelBits,
		// Token: 0x04005A31 RID: 23089
		ViewportBoundsRange,
		// Token: 0x04005A32 RID: 23090
		LayerProvokingVertex,
		// Token: 0x04005A33 RID: 23091
		ViewportIndexProvokingVertex,
		// Token: 0x04005A34 RID: 23092
		UndefinedVertex,
		// Token: 0x04005A35 RID: 23093
		NoResetNotificationArb,
		// Token: 0x04005A36 RID: 23094
		MaxComputeSharedMemorySize,
		// Token: 0x04005A37 RID: 23095
		MaxComputeUniformComponents,
		// Token: 0x04005A38 RID: 23096
		MaxComputeAtomicCounterBuffers,
		// Token: 0x04005A39 RID: 23097
		MaxComputeAtomicCounters,
		// Token: 0x04005A3A RID: 23098
		MaxCombinedComputeUniformComponents,
		// Token: 0x04005A3B RID: 23099
		ComputeWorkGroupSize,
		// Token: 0x04005A3C RID: 23100
		DebugTypeMarker,
		// Token: 0x04005A3D RID: 23101
		DebugTypeMarkerKhr = 33384,
		// Token: 0x04005A3E RID: 23102
		DebugTypePushGroup,
		// Token: 0x04005A3F RID: 23103
		DebugTypePushGroupKhr = 33385,
		// Token: 0x04005A40 RID: 23104
		DebugTypePopGroup,
		// Token: 0x04005A41 RID: 23105
		DebugTypePopGroupKhr = 33386,
		// Token: 0x04005A42 RID: 23106
		DebugSeverityNotification,
		// Token: 0x04005A43 RID: 23107
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x04005A44 RID: 23108
		MaxDebugGroupStackDepth,
		// Token: 0x04005A45 RID: 23109
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x04005A46 RID: 23110
		DebugGroupStackDepth,
		// Token: 0x04005A47 RID: 23111
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x04005A48 RID: 23112
		MaxUniformLocations,
		// Token: 0x04005A49 RID: 23113
		InternalformatSupported,
		// Token: 0x04005A4A RID: 23114
		InternalformatPreferred,
		// Token: 0x04005A4B RID: 23115
		InternalformatRedSize,
		// Token: 0x04005A4C RID: 23116
		InternalformatGreenSize,
		// Token: 0x04005A4D RID: 23117
		InternalformatBlueSize,
		// Token: 0x04005A4E RID: 23118
		InternalformatAlphaSize,
		// Token: 0x04005A4F RID: 23119
		InternalformatDepthSize,
		// Token: 0x04005A50 RID: 23120
		InternalformatStencilSize,
		// Token: 0x04005A51 RID: 23121
		InternalformatSharedSize,
		// Token: 0x04005A52 RID: 23122
		InternalformatRedType,
		// Token: 0x04005A53 RID: 23123
		InternalformatGreenType,
		// Token: 0x04005A54 RID: 23124
		InternalformatBlueType,
		// Token: 0x04005A55 RID: 23125
		InternalformatAlphaType,
		// Token: 0x04005A56 RID: 23126
		InternalformatDepthType,
		// Token: 0x04005A57 RID: 23127
		InternalformatStencilType,
		// Token: 0x04005A58 RID: 23128
		MaxWidth,
		// Token: 0x04005A59 RID: 23129
		MaxHeight,
		// Token: 0x04005A5A RID: 23130
		MaxDepth,
		// Token: 0x04005A5B RID: 23131
		MaxLayers,
		// Token: 0x04005A5C RID: 23132
		MaxCombinedDimensions,
		// Token: 0x04005A5D RID: 23133
		ColorComponents,
		// Token: 0x04005A5E RID: 23134
		DepthComponents,
		// Token: 0x04005A5F RID: 23135
		StencilComponents,
		// Token: 0x04005A60 RID: 23136
		ColorRenderable,
		// Token: 0x04005A61 RID: 23137
		DepthRenderable,
		// Token: 0x04005A62 RID: 23138
		StencilRenderable,
		// Token: 0x04005A63 RID: 23139
		FramebufferRenderable,
		// Token: 0x04005A64 RID: 23140
		FramebufferRenderableLayered,
		// Token: 0x04005A65 RID: 23141
		FramebufferBlend,
		// Token: 0x04005A66 RID: 23142
		ReadPixels,
		// Token: 0x04005A67 RID: 23143
		ReadPixelsFormat,
		// Token: 0x04005A68 RID: 23144
		ReadPixelsType,
		// Token: 0x04005A69 RID: 23145
		TextureImageFormat,
		// Token: 0x04005A6A RID: 23146
		TextureImageType,
		// Token: 0x04005A6B RID: 23147
		GetTextureImageFormat,
		// Token: 0x04005A6C RID: 23148
		GetTextureImageType,
		// Token: 0x04005A6D RID: 23149
		Mipmap,
		// Token: 0x04005A6E RID: 23150
		ManualGenerateMipmap,
		// Token: 0x04005A6F RID: 23151
		AutoGenerateMipmap,
		// Token: 0x04005A70 RID: 23152
		ColorEncoding,
		// Token: 0x04005A71 RID: 23153
		SrgbRead,
		// Token: 0x04005A72 RID: 23154
		SrgbWrite,
		// Token: 0x04005A73 RID: 23155
		SrgbDecodeArb,
		// Token: 0x04005A74 RID: 23156
		Filter,
		// Token: 0x04005A75 RID: 23157
		VertexTexture,
		// Token: 0x04005A76 RID: 23158
		TessControlTexture,
		// Token: 0x04005A77 RID: 23159
		TessEvaluationTexture,
		// Token: 0x04005A78 RID: 23160
		GeometryTexture,
		// Token: 0x04005A79 RID: 23161
		FragmentTexture,
		// Token: 0x04005A7A RID: 23162
		ComputeTexture,
		// Token: 0x04005A7B RID: 23163
		TextureShadow,
		// Token: 0x04005A7C RID: 23164
		TextureGather,
		// Token: 0x04005A7D RID: 23165
		TextureGatherShadow,
		// Token: 0x04005A7E RID: 23166
		ShaderImageLoad,
		// Token: 0x04005A7F RID: 23167
		ShaderImageStore,
		// Token: 0x04005A80 RID: 23168
		ShaderImageAtomic,
		// Token: 0x04005A81 RID: 23169
		ImageTexelSize,
		// Token: 0x04005A82 RID: 23170
		ImageCompatibilityClass,
		// Token: 0x04005A83 RID: 23171
		ImagePixelFormat,
		// Token: 0x04005A84 RID: 23172
		ImagePixelType,
		// Token: 0x04005A85 RID: 23173
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x04005A86 RID: 23174
		SimultaneousTextureAndStencilTest,
		// Token: 0x04005A87 RID: 23175
		SimultaneousTextureAndDepthWrite,
		// Token: 0x04005A88 RID: 23176
		SimultaneousTextureAndStencilWrite,
		// Token: 0x04005A89 RID: 23177
		TextureCompressedBlockWidth = 33457,
		// Token: 0x04005A8A RID: 23178
		TextureCompressedBlockHeight,
		// Token: 0x04005A8B RID: 23179
		TextureCompressedBlockSize,
		// Token: 0x04005A8C RID: 23180
		ClearBuffer,
		// Token: 0x04005A8D RID: 23181
		TextureView,
		// Token: 0x04005A8E RID: 23182
		ViewCompatibilityClass,
		// Token: 0x04005A8F RID: 23183
		FullSupport,
		// Token: 0x04005A90 RID: 23184
		CaveatSupport,
		// Token: 0x04005A91 RID: 23185
		ImageClass4X32,
		// Token: 0x04005A92 RID: 23186
		ImageClass2X32,
		// Token: 0x04005A93 RID: 23187
		ImageClass1X32,
		// Token: 0x04005A94 RID: 23188
		ImageClass4X16,
		// Token: 0x04005A95 RID: 23189
		ImageClass2X16,
		// Token: 0x04005A96 RID: 23190
		ImageClass1X16,
		// Token: 0x04005A97 RID: 23191
		ImageClass4X8,
		// Token: 0x04005A98 RID: 23192
		ImageClass2X8,
		// Token: 0x04005A99 RID: 23193
		ImageClass1X8,
		// Token: 0x04005A9A RID: 23194
		ImageClass111110,
		// Token: 0x04005A9B RID: 23195
		ImageClass1010102,
		// Token: 0x04005A9C RID: 23196
		ViewClass128Bits,
		// Token: 0x04005A9D RID: 23197
		ViewClass96Bits,
		// Token: 0x04005A9E RID: 23198
		ViewClass64Bits,
		// Token: 0x04005A9F RID: 23199
		ViewClass48Bits,
		// Token: 0x04005AA0 RID: 23200
		ViewClass32Bits,
		// Token: 0x04005AA1 RID: 23201
		ViewClass24Bits,
		// Token: 0x04005AA2 RID: 23202
		ViewClass16Bits,
		// Token: 0x04005AA3 RID: 23203
		ViewClass8Bits,
		// Token: 0x04005AA4 RID: 23204
		ViewClassS3tcDxt1Rgb,
		// Token: 0x04005AA5 RID: 23205
		ViewClassS3tcDxt1Rgba,
		// Token: 0x04005AA6 RID: 23206
		ViewClassS3tcDxt3Rgba,
		// Token: 0x04005AA7 RID: 23207
		ViewClassS3tcDxt5Rgba,
		// Token: 0x04005AA8 RID: 23208
		ViewClassRgtc1Red,
		// Token: 0x04005AA9 RID: 23209
		ViewClassRgtc2Rg,
		// Token: 0x04005AAA RID: 23210
		ViewClassBptcUnorm,
		// Token: 0x04005AAB RID: 23211
		ViewClassBptcFloat,
		// Token: 0x04005AAC RID: 23212
		VertexAttribBinding,
		// Token: 0x04005AAD RID: 23213
		VertexAttribRelativeOffset,
		// Token: 0x04005AAE RID: 23214
		VertexBindingDivisor,
		// Token: 0x04005AAF RID: 23215
		VertexBindingOffset,
		// Token: 0x04005AB0 RID: 23216
		VertexBindingStride,
		// Token: 0x04005AB1 RID: 23217
		MaxVertexAttribRelativeOffset,
		// Token: 0x04005AB2 RID: 23218
		MaxVertexAttribBindings,
		// Token: 0x04005AB3 RID: 23219
		TextureViewMinLevel,
		// Token: 0x04005AB4 RID: 23220
		TextureViewNumLevels,
		// Token: 0x04005AB5 RID: 23221
		TextureViewMinLayer,
		// Token: 0x04005AB6 RID: 23222
		TextureViewNumLayers,
		// Token: 0x04005AB7 RID: 23223
		TextureImmutableLevels,
		// Token: 0x04005AB8 RID: 23224
		Buffer,
		// Token: 0x04005AB9 RID: 23225
		BufferKhr = 33504,
		// Token: 0x04005ABA RID: 23226
		Shader,
		// Token: 0x04005ABB RID: 23227
		ShaderKhr = 33505,
		// Token: 0x04005ABC RID: 23228
		Program,
		// Token: 0x04005ABD RID: 23229
		ProgramKhr = 33506,
		// Token: 0x04005ABE RID: 23230
		Query,
		// Token: 0x04005ABF RID: 23231
		QueryKhr = 33507,
		// Token: 0x04005AC0 RID: 23232
		ProgramPipeline,
		// Token: 0x04005AC1 RID: 23233
		MaxVertexAttribStride,
		// Token: 0x04005AC2 RID: 23234
		Sampler,
		// Token: 0x04005AC3 RID: 23235
		SamplerKhr = 33510,
		// Token: 0x04005AC4 RID: 23236
		DisplayList,
		// Token: 0x04005AC5 RID: 23237
		MaxLabelLength,
		// Token: 0x04005AC6 RID: 23238
		MaxLabelLengthKhr = 33512,
		// Token: 0x04005AC7 RID: 23239
		NumShadingLanguageVersions,
		// Token: 0x04005AC8 RID: 23240
		ConvolutionHintSgix = 33558,
		// Token: 0x04005AC9 RID: 23241
		AlphaMinSgix = 33568,
		// Token: 0x04005ACA RID: 23242
		AlphaMaxSgix,
		// Token: 0x04005ACB RID: 23243
		ScalebiasHintSgix,
		// Token: 0x04005ACC RID: 23244
		AsyncMarkerSgix = 33577,
		// Token: 0x04005ACD RID: 23245
		PixelTexGenModeSgix = 33579,
		// Token: 0x04005ACE RID: 23246
		AsyncHistogramSgix,
		// Token: 0x04005ACF RID: 23247
		MaxAsyncHistogramSgix,
		// Token: 0x04005AD0 RID: 23248
		PixelTextureSgis = 33619,
		// Token: 0x04005AD1 RID: 23249
		PixelFragmentRgbSourceSgis,
		// Token: 0x04005AD2 RID: 23250
		PixelFragmentAlphaSourceSgis,
		// Token: 0x04005AD3 RID: 23251
		LineQualityHintSgix = 33627,
		// Token: 0x04005AD4 RID: 23252
		AsyncTexImageSgix,
		// Token: 0x04005AD5 RID: 23253
		AsyncDrawPixelsSgix,
		// Token: 0x04005AD6 RID: 23254
		AsyncReadPixelsSgix,
		// Token: 0x04005AD7 RID: 23255
		MaxAsyncTexImageSgix,
		// Token: 0x04005AD8 RID: 23256
		MaxAsyncDrawPixelsSgix,
		// Token: 0x04005AD9 RID: 23257
		MaxAsyncReadPixelsSgix,
		// Token: 0x04005ADA RID: 23258
		UnsignedByte233Rev,
		// Token: 0x04005ADB RID: 23259
		UnsignedByte233Reversed = 33634,
		// Token: 0x04005ADC RID: 23260
		UnsignedShort565,
		// Token: 0x04005ADD RID: 23261
		UnsignedShort565Rev,
		// Token: 0x04005ADE RID: 23262
		UnsignedShort565Reversed = 33636,
		// Token: 0x04005ADF RID: 23263
		UnsignedShort4444Rev,
		// Token: 0x04005AE0 RID: 23264
		UnsignedShort4444Reversed = 33637,
		// Token: 0x04005AE1 RID: 23265
		UnsignedShort1555Rev,
		// Token: 0x04005AE2 RID: 23266
		UnsignedShort1555Reversed = 33638,
		// Token: 0x04005AE3 RID: 23267
		UnsignedInt8888Rev,
		// Token: 0x04005AE4 RID: 23268
		UnsignedInt8888Reversed = 33639,
		// Token: 0x04005AE5 RID: 23269
		UnsignedInt2101010Rev,
		// Token: 0x04005AE6 RID: 23270
		UnsignedInt2101010Reversed = 33640,
		// Token: 0x04005AE7 RID: 23271
		TextureMaxClampSSgix,
		// Token: 0x04005AE8 RID: 23272
		TextureMaxClampTSgix,
		// Token: 0x04005AE9 RID: 23273
		TextureMaxClampRSgix,
		// Token: 0x04005AEA RID: 23274
		MirroredRepeat = 33648,
		// Token: 0x04005AEB RID: 23275
		VertexPreclipSgix = 33774,
		// Token: 0x04005AEC RID: 23276
		VertexPreclipHintSgix,
		// Token: 0x04005AED RID: 23277
		CompressedRgbS3tcDxt1Ext,
		// Token: 0x04005AEE RID: 23278
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x04005AEF RID: 23279
		CompressedRgbaS3tcDxt3Ext,
		// Token: 0x04005AF0 RID: 23280
		CompressedRgbaS3tcDxt5Ext,
		// Token: 0x04005AF1 RID: 23281
		FragmentLightingSgix = 33792,
		// Token: 0x04005AF2 RID: 23282
		FragmentColorMaterialSgix,
		// Token: 0x04005AF3 RID: 23283
		FragmentColorMaterialFaceSgix,
		// Token: 0x04005AF4 RID: 23284
		FragmentColorMaterialParameterSgix,
		// Token: 0x04005AF5 RID: 23285
		MaxFragmentLightsSgix,
		// Token: 0x04005AF6 RID: 23286
		MaxActiveLightsSgix,
		// Token: 0x04005AF7 RID: 23287
		LightEnvModeSgix = 33799,
		// Token: 0x04005AF8 RID: 23288
		FragmentLightModelLocalViewerSgix,
		// Token: 0x04005AF9 RID: 23289
		FragmentLightModelTwoSideSgix,
		// Token: 0x04005AFA RID: 23290
		FragmentLightModelAmbientSgix,
		// Token: 0x04005AFB RID: 23291
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x04005AFC RID: 23292
		FragmentLight0Sgix,
		// Token: 0x04005AFD RID: 23293
		FragmentLight1Sgix,
		// Token: 0x04005AFE RID: 23294
		FragmentLight2Sgix,
		// Token: 0x04005AFF RID: 23295
		FragmentLight3Sgix,
		// Token: 0x04005B00 RID: 23296
		FragmentLight4Sgix,
		// Token: 0x04005B01 RID: 23297
		FragmentLight5Sgix,
		// Token: 0x04005B02 RID: 23298
		FragmentLight6Sgix,
		// Token: 0x04005B03 RID: 23299
		FragmentLight7Sgix,
		// Token: 0x04005B04 RID: 23300
		PackResampleSgix = 33836,
		// Token: 0x04005B05 RID: 23301
		UnpackResampleSgix,
		// Token: 0x04005B06 RID: 23302
		ResampleReplicateSgix,
		// Token: 0x04005B07 RID: 23303
		ResampleZeroFillSgix,
		// Token: 0x04005B08 RID: 23304
		ResampleDecimateSgix,
		// Token: 0x04005B09 RID: 23305
		NearestClipmapNearestSgix = 33869,
		// Token: 0x04005B0A RID: 23306
		NearestClipmapLinearSgix,
		// Token: 0x04005B0B RID: 23307
		LinearClipmapNearestSgix,
		// Token: 0x04005B0C RID: 23308
		FogCoordSrc,
		// Token: 0x04005B0D RID: 23309
		FogCoord,
		// Token: 0x04005B0E RID: 23310
		FragmentDepth,
		// Token: 0x04005B0F RID: 23311
		CurrentFogCoord,
		// Token: 0x04005B10 RID: 23312
		FogCoordArrayType,
		// Token: 0x04005B11 RID: 23313
		FogCoordArrayStride,
		// Token: 0x04005B12 RID: 23314
		FogCoordArrayPointer,
		// Token: 0x04005B13 RID: 23315
		FogCoordArray,
		// Token: 0x04005B14 RID: 23316
		ColorSum,
		// Token: 0x04005B15 RID: 23317
		CurrentSecondaryColor,
		// Token: 0x04005B16 RID: 23318
		SecondaryColorArraySize,
		// Token: 0x04005B17 RID: 23319
		SecondaryColorArrayType,
		// Token: 0x04005B18 RID: 23320
		SecondaryColorArrayStride,
		// Token: 0x04005B19 RID: 23321
		SecondaryColorArrayPointer,
		// Token: 0x04005B1A RID: 23322
		SecondaryColorArray,
		// Token: 0x04005B1B RID: 23323
		CurrentRasterSecondaryColor,
		// Token: 0x04005B1C RID: 23324
		RgbIccSgix,
		// Token: 0x04005B1D RID: 23325
		RgbaIccSgix,
		// Token: 0x04005B1E RID: 23326
		AlphaIccSgix,
		// Token: 0x04005B1F RID: 23327
		LuminanceIccSgix,
		// Token: 0x04005B20 RID: 23328
		IntensityIccSgix,
		// Token: 0x04005B21 RID: 23329
		LuminanceAlphaIccSgix,
		// Token: 0x04005B22 RID: 23330
		R5G6B5IccSgix,
		// Token: 0x04005B23 RID: 23331
		R5G6B5A8IccSgix,
		// Token: 0x04005B24 RID: 23332
		Alpha16IccSgix,
		// Token: 0x04005B25 RID: 23333
		Luminance16IccSgix,
		// Token: 0x04005B26 RID: 23334
		Intensity16IccSgix,
		// Token: 0x04005B27 RID: 23335
		Luminance16Alpha8IccSgix,
		// Token: 0x04005B28 RID: 23336
		AliasedPointSizeRange = 33901,
		// Token: 0x04005B29 RID: 23337
		AliasedLineWidthRange,
		// Token: 0x04005B2A RID: 23338
		Texture0 = 33984,
		// Token: 0x04005B2B RID: 23339
		Texture1,
		// Token: 0x04005B2C RID: 23340
		Texture2,
		// Token: 0x04005B2D RID: 23341
		Texture3,
		// Token: 0x04005B2E RID: 23342
		Texture4,
		// Token: 0x04005B2F RID: 23343
		Texture5,
		// Token: 0x04005B30 RID: 23344
		Texture6,
		// Token: 0x04005B31 RID: 23345
		Texture7,
		// Token: 0x04005B32 RID: 23346
		Texture8,
		// Token: 0x04005B33 RID: 23347
		Texture9,
		// Token: 0x04005B34 RID: 23348
		Texture10,
		// Token: 0x04005B35 RID: 23349
		Texture11,
		// Token: 0x04005B36 RID: 23350
		Texture12,
		// Token: 0x04005B37 RID: 23351
		Texture13,
		// Token: 0x04005B38 RID: 23352
		Texture14,
		// Token: 0x04005B39 RID: 23353
		Texture15,
		// Token: 0x04005B3A RID: 23354
		Texture16,
		// Token: 0x04005B3B RID: 23355
		Texture17,
		// Token: 0x04005B3C RID: 23356
		Texture18,
		// Token: 0x04005B3D RID: 23357
		Texture19,
		// Token: 0x04005B3E RID: 23358
		Texture20,
		// Token: 0x04005B3F RID: 23359
		Texture21,
		// Token: 0x04005B40 RID: 23360
		Texture22,
		// Token: 0x04005B41 RID: 23361
		Texture23,
		// Token: 0x04005B42 RID: 23362
		Texture24,
		// Token: 0x04005B43 RID: 23363
		Texture25,
		// Token: 0x04005B44 RID: 23364
		Texture26,
		// Token: 0x04005B45 RID: 23365
		Texture27,
		// Token: 0x04005B46 RID: 23366
		Texture28,
		// Token: 0x04005B47 RID: 23367
		Texture29,
		// Token: 0x04005B48 RID: 23368
		Texture30,
		// Token: 0x04005B49 RID: 23369
		Texture31,
		// Token: 0x04005B4A RID: 23370
		ActiveTexture,
		// Token: 0x04005B4B RID: 23371
		ClientActiveTexture,
		// Token: 0x04005B4C RID: 23372
		MaxTextureUnits,
		// Token: 0x04005B4D RID: 23373
		TransposeModelviewMatrix,
		// Token: 0x04005B4E RID: 23374
		TransposeProjectionMatrix,
		// Token: 0x04005B4F RID: 23375
		TransposeTextureMatrix,
		// Token: 0x04005B50 RID: 23376
		TransposeColorMatrix,
		// Token: 0x04005B51 RID: 23377
		Subtract,
		// Token: 0x04005B52 RID: 23378
		MaxRenderbufferSize,
		// Token: 0x04005B53 RID: 23379
		MaxRenderbufferSizeExt = 34024,
		// Token: 0x04005B54 RID: 23380
		CompressedAlpha,
		// Token: 0x04005B55 RID: 23381
		CompressedLuminance,
		// Token: 0x04005B56 RID: 23382
		CompressedLuminanceAlpha,
		// Token: 0x04005B57 RID: 23383
		CompressedIntensity,
		// Token: 0x04005B58 RID: 23384
		CompressedRgb,
		// Token: 0x04005B59 RID: 23385
		CompressedRgba,
		// Token: 0x04005B5A RID: 23386
		TextureCompressionHint,
		// Token: 0x04005B5B RID: 23387
		TextureCompressionHintArb = 34031,
		// Token: 0x04005B5C RID: 23388
		UniformBlockReferencedByTessControlShader,
		// Token: 0x04005B5D RID: 23389
		UniformBlockReferencedByTessEvaluationShader,
		// Token: 0x04005B5E RID: 23390
		TextureRectangle = 34037,
		// Token: 0x04005B5F RID: 23391
		TextureBindingRectangle,
		// Token: 0x04005B60 RID: 23392
		ProxyTextureRectangle,
		// Token: 0x04005B61 RID: 23393
		MaxRectangleTextureSize,
		// Token: 0x04005B62 RID: 23394
		DepthStencil,
		// Token: 0x04005B63 RID: 23395
		UnsignedInt248,
		// Token: 0x04005B64 RID: 23396
		MaxTextureLodBias = 34045,
		// Token: 0x04005B65 RID: 23397
		TextureMaxAnisotropyExt,
		// Token: 0x04005B66 RID: 23398
		TextureFilterControl = 34048,
		// Token: 0x04005B67 RID: 23399
		TextureLodBias,
		// Token: 0x04005B68 RID: 23400
		IncrWrap = 34055,
		// Token: 0x04005B69 RID: 23401
		DecrWrap,
		// Token: 0x04005B6A RID: 23402
		NormalMap = 34065,
		// Token: 0x04005B6B RID: 23403
		ReflectionMap,
		// Token: 0x04005B6C RID: 23404
		TextureCubeMap,
		// Token: 0x04005B6D RID: 23405
		TextureBindingCubeMap,
		// Token: 0x04005B6E RID: 23406
		TextureCubeMapPositiveX,
		// Token: 0x04005B6F RID: 23407
		TextureCubeMapNegativeX,
		// Token: 0x04005B70 RID: 23408
		TextureCubeMapPositiveY,
		// Token: 0x04005B71 RID: 23409
		TextureCubeMapNegativeY,
		// Token: 0x04005B72 RID: 23410
		TextureCubeMapPositiveZ,
		// Token: 0x04005B73 RID: 23411
		TextureCubeMapNegativeZ,
		// Token: 0x04005B74 RID: 23412
		ProxyTextureCubeMap,
		// Token: 0x04005B75 RID: 23413
		MaxCubeMapTextureSize,
		// Token: 0x04005B76 RID: 23414
		VertexArrayStorageHintApple = 34079,
		// Token: 0x04005B77 RID: 23415
		MultisampleFilterHintNv = 34100,
		// Token: 0x04005B78 RID: 23416
		Combine = 34160,
		// Token: 0x04005B79 RID: 23417
		CombineRgb,
		// Token: 0x04005B7A RID: 23418
		CombineAlpha,
		// Token: 0x04005B7B RID: 23419
		RgbScale,
		// Token: 0x04005B7C RID: 23420
		AddSigned,
		// Token: 0x04005B7D RID: 23421
		Interpolate,
		// Token: 0x04005B7E RID: 23422
		Constant,
		// Token: 0x04005B7F RID: 23423
		PrimaryColor,
		// Token: 0x04005B80 RID: 23424
		Previous,
		// Token: 0x04005B81 RID: 23425
		Source0Rgb = 34176,
		// Token: 0x04005B82 RID: 23426
		Src1Rgb,
		// Token: 0x04005B83 RID: 23427
		Src2Rgb,
		// Token: 0x04005B84 RID: 23428
		Src0Alpha = 34184,
		// Token: 0x04005B85 RID: 23429
		Src1Alpha,
		// Token: 0x04005B86 RID: 23430
		Src2Alpha,
		// Token: 0x04005B87 RID: 23431
		Operand0Rgb = 34192,
		// Token: 0x04005B88 RID: 23432
		Operand1Rgb,
		// Token: 0x04005B89 RID: 23433
		Operand2Rgb,
		// Token: 0x04005B8A RID: 23434
		Operand0Alpha = 34200,
		// Token: 0x04005B8B RID: 23435
		Operand1Alpha,
		// Token: 0x04005B8C RID: 23436
		Operand2Alpha,
		// Token: 0x04005B8D RID: 23437
		PackSubsampleRateSgix = 34208,
		// Token: 0x04005B8E RID: 23438
		UnpackSubsampleRateSgix,
		// Token: 0x04005B8F RID: 23439
		PixelSubsample4444Sgix,
		// Token: 0x04005B90 RID: 23440
		PixelSubsample2424Sgix,
		// Token: 0x04005B91 RID: 23441
		PixelSubsample4242Sgix,
		// Token: 0x04005B92 RID: 23442
		TransformHintApple = 34225,
		// Token: 0x04005B93 RID: 23443
		VertexArrayBinding = 34229,
		// Token: 0x04005B94 RID: 23444
		TextureStorageHintApple = 34236,
		// Token: 0x04005B95 RID: 23445
		VertexProgram = 34336,
		// Token: 0x04005B96 RID: 23446
		ArrayEnabled = 34338,
		// Token: 0x04005B97 RID: 23447
		VertexAttribArrayEnabled = 34338,
		// Token: 0x04005B98 RID: 23448
		VertexAttribArraySize,
		// Token: 0x04005B99 RID: 23449
		VertexAttribArrayStride,
		// Token: 0x04005B9A RID: 23450
		ArrayType,
		// Token: 0x04005B9B RID: 23451
		VertexAttribArrayType = 34341,
		// Token: 0x04005B9C RID: 23452
		CurrentVertexAttrib,
		// Token: 0x04005B9D RID: 23453
		ProgramLength,
		// Token: 0x04005B9E RID: 23454
		ProgramString,
		// Token: 0x04005B9F RID: 23455
		ProgramPointSize = 34370,
		// Token: 0x04005BA0 RID: 23456
		VertexProgramPointSize = 34370,
		// Token: 0x04005BA1 RID: 23457
		VertexProgramTwoSide,
		// Token: 0x04005BA2 RID: 23458
		ArrayPointer = 34373,
		// Token: 0x04005BA3 RID: 23459
		VertexAttribArrayPointer = 34373,
		// Token: 0x04005BA4 RID: 23460
		DepthClamp = 34383,
		// Token: 0x04005BA5 RID: 23461
		ProgramBinding = 34423,
		// Token: 0x04005BA6 RID: 23462
		TextureCompressedImageSize = 34464,
		// Token: 0x04005BA7 RID: 23463
		TextureCompressed,
		// Token: 0x04005BA8 RID: 23464
		NumCompressedTextureFormats,
		// Token: 0x04005BA9 RID: 23465
		CompressedTextureFormats,
		// Token: 0x04005BAA RID: 23466
		Dot3Rgb = 34478,
		// Token: 0x04005BAB RID: 23467
		Dot3Rgba,
		// Token: 0x04005BAC RID: 23468
		ProgramBinaryLength = 34625,
		// Token: 0x04005BAD RID: 23469
		MirrorClampToEdge = 34627,
		// Token: 0x04005BAE RID: 23470
		VertexAttribArrayLong = 34638,
		// Token: 0x04005BAF RID: 23471
		BufferSize = 34660,
		// Token: 0x04005BB0 RID: 23472
		BufferUsage,
		// Token: 0x04005BB1 RID: 23473
		NumProgramBinaryFormats = 34814,
		// Token: 0x04005BB2 RID: 23474
		ProgramBinaryFormats,
		// Token: 0x04005BB3 RID: 23475
		StencilBackFunc,
		// Token: 0x04005BB4 RID: 23476
		StencilBackFail,
		// Token: 0x04005BB5 RID: 23477
		StencilBackPassDepthFail,
		// Token: 0x04005BB6 RID: 23478
		StencilBackPassDepthPass,
		// Token: 0x04005BB7 RID: 23479
		FragmentProgram,
		// Token: 0x04005BB8 RID: 23480
		ProgramAluInstructionsArb,
		// Token: 0x04005BB9 RID: 23481
		ProgramTexInstructionsArb,
		// Token: 0x04005BBA RID: 23482
		ProgramTexIndirectionsArb,
		// Token: 0x04005BBB RID: 23483
		ProgramNativeAluInstructionsArb,
		// Token: 0x04005BBC RID: 23484
		ProgramNativeTexInstructionsArb,
		// Token: 0x04005BBD RID: 23485
		ProgramNativeTexIndirectionsArb,
		// Token: 0x04005BBE RID: 23486
		MaxProgramAluInstructionsArb,
		// Token: 0x04005BBF RID: 23487
		MaxProgramTexInstructionsArb,
		// Token: 0x04005BC0 RID: 23488
		MaxProgramTexIndirectionsArb,
		// Token: 0x04005BC1 RID: 23489
		MaxProgramNativeAluInstructionsArb,
		// Token: 0x04005BC2 RID: 23490
		MaxProgramNativeTexInstructionsArb,
		// Token: 0x04005BC3 RID: 23491
		MaxProgramNativeTexIndirectionsArb,
		// Token: 0x04005BC4 RID: 23492
		Rgba32f = 34836,
		// Token: 0x04005BC5 RID: 23493
		Rgb32f,
		// Token: 0x04005BC6 RID: 23494
		Rgba16f = 34842,
		// Token: 0x04005BC7 RID: 23495
		Rgb16f,
		// Token: 0x04005BC8 RID: 23496
		RgbaFloatMode = 34848,
		// Token: 0x04005BC9 RID: 23497
		MaxDrawBuffers = 34852,
		// Token: 0x04005BCA RID: 23498
		DrawBuffer0,
		// Token: 0x04005BCB RID: 23499
		DrawBuffer1,
		// Token: 0x04005BCC RID: 23500
		DrawBuffer2,
		// Token: 0x04005BCD RID: 23501
		DrawBuffer3,
		// Token: 0x04005BCE RID: 23502
		DrawBuffer4,
		// Token: 0x04005BCF RID: 23503
		DrawBuffer5,
		// Token: 0x04005BD0 RID: 23504
		DrawBuffer6,
		// Token: 0x04005BD1 RID: 23505
		DrawBuffer7,
		// Token: 0x04005BD2 RID: 23506
		DrawBuffer8,
		// Token: 0x04005BD3 RID: 23507
		DrawBuffer9,
		// Token: 0x04005BD4 RID: 23508
		DrawBuffer10,
		// Token: 0x04005BD5 RID: 23509
		DrawBuffer11,
		// Token: 0x04005BD6 RID: 23510
		DrawBuffer12,
		// Token: 0x04005BD7 RID: 23511
		DrawBuffer13,
		// Token: 0x04005BD8 RID: 23512
		DrawBuffer14,
		// Token: 0x04005BD9 RID: 23513
		DrawBuffer15,
		// Token: 0x04005BDA RID: 23514
		BlendEquationAlpha = 34877,
		// Token: 0x04005BDB RID: 23515
		TextureDepthSize = 34890,
		// Token: 0x04005BDC RID: 23516
		DepthTextureMode,
		// Token: 0x04005BDD RID: 23517
		TextureCompareMode,
		// Token: 0x04005BDE RID: 23518
		TextureCompareFunc,
		// Token: 0x04005BDF RID: 23519
		CompareRefToTexture,
		// Token: 0x04005BE0 RID: 23520
		CompareRToTexture = 34894,
		// Token: 0x04005BE1 RID: 23521
		TextureCubeMapSeamless,
		// Token: 0x04005BE2 RID: 23522
		PointSprite = 34913,
		// Token: 0x04005BE3 RID: 23523
		CoordReplace,
		// Token: 0x04005BE4 RID: 23524
		QueryCounterBits = 34916,
		// Token: 0x04005BE5 RID: 23525
		CurrentQuery,
		// Token: 0x04005BE6 RID: 23526
		QueryResult,
		// Token: 0x04005BE7 RID: 23527
		QueryResultAvailable,
		// Token: 0x04005BE8 RID: 23528
		MaxVertexAttribs = 34921,
		// Token: 0x04005BE9 RID: 23529
		ArrayNormalized,
		// Token: 0x04005BEA RID: 23530
		VertexAttribArrayNormalized = 34922,
		// Token: 0x04005BEB RID: 23531
		MaxTessControlInputComponents = 34924,
		// Token: 0x04005BEC RID: 23532
		MaxTessEvaluationInputComponents,
		// Token: 0x04005BED RID: 23533
		MaxTextureCoords = 34929,
		// Token: 0x04005BEE RID: 23534
		MaxTextureImageUnits,
		// Token: 0x04005BEF RID: 23535
		ProgramFormatAsciiArb = 34933,
		// Token: 0x04005BF0 RID: 23536
		ProgramFormat,
		// Token: 0x04005BF1 RID: 23537
		GeometryShaderInvocations = 34943,
		// Token: 0x04005BF2 RID: 23538
		ArrayBuffer = 34962,
		// Token: 0x04005BF3 RID: 23539
		ElementArrayBuffer,
		// Token: 0x04005BF4 RID: 23540
		ArrayBufferBinding,
		// Token: 0x04005BF5 RID: 23541
		ElementArrayBufferBinding,
		// Token: 0x04005BF6 RID: 23542
		VertexArrayBufferBinding,
		// Token: 0x04005BF7 RID: 23543
		NormalArrayBufferBinding,
		// Token: 0x04005BF8 RID: 23544
		ColorArrayBufferBinding,
		// Token: 0x04005BF9 RID: 23545
		IndexArrayBufferBinding,
		// Token: 0x04005BFA RID: 23546
		TextureCoordArrayBufferBinding,
		// Token: 0x04005BFB RID: 23547
		EdgeFlagArrayBufferBinding,
		// Token: 0x04005BFC RID: 23548
		SecondaryColorArrayBufferBinding,
		// Token: 0x04005BFD RID: 23549
		FogCoordArrayBufferBinding,
		// Token: 0x04005BFE RID: 23550
		WeightArrayBufferBinding,
		// Token: 0x04005BFF RID: 23551
		VertexAttribArrayBufferBinding,
		// Token: 0x04005C00 RID: 23552
		ProgramInstruction,
		// Token: 0x04005C01 RID: 23553
		MaxProgramInstructions,
		// Token: 0x04005C02 RID: 23554
		ProgramNativeInstructions,
		// Token: 0x04005C03 RID: 23555
		MaxProgramNativeInstructions,
		// Token: 0x04005C04 RID: 23556
		ProgramTemporaries,
		// Token: 0x04005C05 RID: 23557
		MaxProgramTemporaries,
		// Token: 0x04005C06 RID: 23558
		ProgramNativeTemporaries,
		// Token: 0x04005C07 RID: 23559
		MaxProgramNativeTemporaries,
		// Token: 0x04005C08 RID: 23560
		ProgramParameters,
		// Token: 0x04005C09 RID: 23561
		MaxProgramParameters,
		// Token: 0x04005C0A RID: 23562
		ProgramNativeParameters,
		// Token: 0x04005C0B RID: 23563
		MaxProgramNativeParameters,
		// Token: 0x04005C0C RID: 23564
		ProgramAttribs,
		// Token: 0x04005C0D RID: 23565
		MaxProgramAttribs,
		// Token: 0x04005C0E RID: 23566
		ProgramNativeAttribs,
		// Token: 0x04005C0F RID: 23567
		MaxProgramNativeAttribs,
		// Token: 0x04005C10 RID: 23568
		ProgramAddressRegisters,
		// Token: 0x04005C11 RID: 23569
		MaxProgramAddressRegisters,
		// Token: 0x04005C12 RID: 23570
		ProgramNativeAddressRegisters,
		// Token: 0x04005C13 RID: 23571
		MaxProgramNativeAddressRegisters,
		// Token: 0x04005C14 RID: 23572
		MaxProgramLocalParameters,
		// Token: 0x04005C15 RID: 23573
		MaxProgramEnvParameters,
		// Token: 0x04005C16 RID: 23574
		ProgramUnderNativeLimits,
		// Token: 0x04005C17 RID: 23575
		ReadOnly = 35000,
		// Token: 0x04005C18 RID: 23576
		WriteOnly,
		// Token: 0x04005C19 RID: 23577
		ReadWrite,
		// Token: 0x04005C1A RID: 23578
		BufferAccess,
		// Token: 0x04005C1B RID: 23579
		BufferMapped,
		// Token: 0x04005C1C RID: 23580
		BufferMapPointer,
		// Token: 0x04005C1D RID: 23581
		TimeElapsed = 35007,
		// Token: 0x04005C1E RID: 23582
		Matrix0,
		// Token: 0x04005C1F RID: 23583
		Matrix1,
		// Token: 0x04005C20 RID: 23584
		Matrix2,
		// Token: 0x04005C21 RID: 23585
		Matrix3,
		// Token: 0x04005C22 RID: 23586
		Matrix4,
		// Token: 0x04005C23 RID: 23587
		Matrix5,
		// Token: 0x04005C24 RID: 23588
		Matrix6,
		// Token: 0x04005C25 RID: 23589
		Matrix7,
		// Token: 0x04005C26 RID: 23590
		Matrix8,
		// Token: 0x04005C27 RID: 23591
		Matrix9,
		// Token: 0x04005C28 RID: 23592
		Matrix10,
		// Token: 0x04005C29 RID: 23593
		Matrix11,
		// Token: 0x04005C2A RID: 23594
		Matrix12,
		// Token: 0x04005C2B RID: 23595
		Matrix13,
		// Token: 0x04005C2C RID: 23596
		Matrix14,
		// Token: 0x04005C2D RID: 23597
		Matrix15,
		// Token: 0x04005C2E RID: 23598
		Matrix16,
		// Token: 0x04005C2F RID: 23599
		Matrix17,
		// Token: 0x04005C30 RID: 23600
		Matrix18,
		// Token: 0x04005C31 RID: 23601
		Matrix19,
		// Token: 0x04005C32 RID: 23602
		Matrix20,
		// Token: 0x04005C33 RID: 23603
		Matrix21,
		// Token: 0x04005C34 RID: 23604
		Matrix22,
		// Token: 0x04005C35 RID: 23605
		Matrix23,
		// Token: 0x04005C36 RID: 23606
		Matrix24,
		// Token: 0x04005C37 RID: 23607
		Matrix25,
		// Token: 0x04005C38 RID: 23608
		Matrix26,
		// Token: 0x04005C39 RID: 23609
		Matrix27,
		// Token: 0x04005C3A RID: 23610
		Matrix28,
		// Token: 0x04005C3B RID: 23611
		Matrix29,
		// Token: 0x04005C3C RID: 23612
		Matrix30,
		// Token: 0x04005C3D RID: 23613
		Matrix31,
		// Token: 0x04005C3E RID: 23614
		StreamDraw,
		// Token: 0x04005C3F RID: 23615
		StreamRead,
		// Token: 0x04005C40 RID: 23616
		StreamCopy,
		// Token: 0x04005C41 RID: 23617
		StaticDraw = 35044,
		// Token: 0x04005C42 RID: 23618
		StaticRead,
		// Token: 0x04005C43 RID: 23619
		StaticCopy,
		// Token: 0x04005C44 RID: 23620
		DynamicDraw = 35048,
		// Token: 0x04005C45 RID: 23621
		DynamicRead,
		// Token: 0x04005C46 RID: 23622
		DynamicCopy,
		// Token: 0x04005C47 RID: 23623
		PixelPackBuffer,
		// Token: 0x04005C48 RID: 23624
		PixelUnpackBuffer,
		// Token: 0x04005C49 RID: 23625
		PixelPackBufferBinding,
		// Token: 0x04005C4A RID: 23626
		PixelUnpackBufferBinding = 35055,
		// Token: 0x04005C4B RID: 23627
		Depth24Stencil8,
		// Token: 0x04005C4C RID: 23628
		TextureStencilSize,
		// Token: 0x04005C4D RID: 23629
		Src1Color = 35065,
		// Token: 0x04005C4E RID: 23630
		OneMinusSrc1Color,
		// Token: 0x04005C4F RID: 23631
		OneMinusSrc1Alpha,
		// Token: 0x04005C50 RID: 23632
		MaxDualSourceDrawBuffers,
		// Token: 0x04005C51 RID: 23633
		VertexAttribArrayInteger,
		// Token: 0x04005C52 RID: 23634
		ArrayDivisor,
		// Token: 0x04005C53 RID: 23635
		VertexAttribArrayDivisor = 35070,
		// Token: 0x04005C54 RID: 23636
		MaxArrayTextureLayers,
		// Token: 0x04005C55 RID: 23637
		MinProgramTexelOffset = 35076,
		// Token: 0x04005C56 RID: 23638
		MaxProgramTexelOffset,
		// Token: 0x04005C57 RID: 23639
		SamplesPassed = 35092,
		// Token: 0x04005C58 RID: 23640
		GeometryVerticesOut = 35094,
		// Token: 0x04005C59 RID: 23641
		GeometryInputType,
		// Token: 0x04005C5A RID: 23642
		GeometryOutputType,
		// Token: 0x04005C5B RID: 23643
		SamplerBinding,
		// Token: 0x04005C5C RID: 23644
		ClampVertexColor,
		// Token: 0x04005C5D RID: 23645
		ClampFragmentColor,
		// Token: 0x04005C5E RID: 23646
		ClampReadColor,
		// Token: 0x04005C5F RID: 23647
		FixedOnly,
		// Token: 0x04005C60 RID: 23648
		PackResampleOml = 35204,
		// Token: 0x04005C61 RID: 23649
		UnpackResampleOml,
		// Token: 0x04005C62 RID: 23650
		UniformBuffer = 35345,
		// Token: 0x04005C63 RID: 23651
		UniformBufferBinding = 35368,
		// Token: 0x04005C64 RID: 23652
		UniformBufferStart,
		// Token: 0x04005C65 RID: 23653
		UniformBufferSize,
		// Token: 0x04005C66 RID: 23654
		MaxVertexUniformBlocks,
		// Token: 0x04005C67 RID: 23655
		MaxGeometryUniformBlocks,
		// Token: 0x04005C68 RID: 23656
		MaxFragmentUniformBlocks,
		// Token: 0x04005C69 RID: 23657
		MaxCombinedUniformBlocks,
		// Token: 0x04005C6A RID: 23658
		MaxUniformBufferBindings,
		// Token: 0x04005C6B RID: 23659
		MaxUniformBlockSize,
		// Token: 0x04005C6C RID: 23660
		MaxCombinedVertexUniformComponents,
		// Token: 0x04005C6D RID: 23661
		MaxCombinedGeometryUniformComponents,
		// Token: 0x04005C6E RID: 23662
		MaxCombinedFragmentUniformComponents,
		// Token: 0x04005C6F RID: 23663
		UniformBufferOffsetAlignment,
		// Token: 0x04005C70 RID: 23664
		ActiveUniformBlockMaxNameLength,
		// Token: 0x04005C71 RID: 23665
		ActiveUniformBlocks,
		// Token: 0x04005C72 RID: 23666
		UniformType,
		// Token: 0x04005C73 RID: 23667
		UniformSize,
		// Token: 0x04005C74 RID: 23668
		UniformNameLength,
		// Token: 0x04005C75 RID: 23669
		UniformBlockIndex,
		// Token: 0x04005C76 RID: 23670
		UniformOffset,
		// Token: 0x04005C77 RID: 23671
		UniformArrayStride,
		// Token: 0x04005C78 RID: 23672
		UniformMatrixStride,
		// Token: 0x04005C79 RID: 23673
		UniformIsRowMajor,
		// Token: 0x04005C7A RID: 23674
		UniformBlockBinding,
		// Token: 0x04005C7B RID: 23675
		UniformBlockDataSize,
		// Token: 0x04005C7C RID: 23676
		UniformBlockNameLength,
		// Token: 0x04005C7D RID: 23677
		UniformBlockActiveUniforms,
		// Token: 0x04005C7E RID: 23678
		UniformBlockActiveUniformIndices,
		// Token: 0x04005C7F RID: 23679
		UniformBlockReferencedByVertexShader,
		// Token: 0x04005C80 RID: 23680
		UniformBlockReferencedByGeometryShader,
		// Token: 0x04005C81 RID: 23681
		UniformBlockReferencedByFragmentShader,
		// Token: 0x04005C82 RID: 23682
		FragmentShader = 35632,
		// Token: 0x04005C83 RID: 23683
		VertexShader,
		// Token: 0x04005C84 RID: 23684
		MaxFragmentUniformComponents = 35657,
		// Token: 0x04005C85 RID: 23685
		MaxVertexUniformComponents,
		// Token: 0x04005C86 RID: 23686
		MaxVaryingComponents,
		// Token: 0x04005C87 RID: 23687
		MaxVaryingFloats = 35659,
		// Token: 0x04005C88 RID: 23688
		MaxVertexTextureImageUnits,
		// Token: 0x04005C89 RID: 23689
		MaxCombinedTextureImageUnits,
		// Token: 0x04005C8A RID: 23690
		ShaderType = 35663,
		// Token: 0x04005C8B RID: 23691
		FloatVec2,
		// Token: 0x04005C8C RID: 23692
		FloatVec3,
		// Token: 0x04005C8D RID: 23693
		FloatVec4,
		// Token: 0x04005C8E RID: 23694
		IntVec2,
		// Token: 0x04005C8F RID: 23695
		IntVec3,
		// Token: 0x04005C90 RID: 23696
		IntVec4,
		// Token: 0x04005C91 RID: 23697
		Bool,
		// Token: 0x04005C92 RID: 23698
		BoolVec2,
		// Token: 0x04005C93 RID: 23699
		BoolVec3,
		// Token: 0x04005C94 RID: 23700
		BoolVec4,
		// Token: 0x04005C95 RID: 23701
		FloatMat2,
		// Token: 0x04005C96 RID: 23702
		FloatMat3,
		// Token: 0x04005C97 RID: 23703
		FloatMat4,
		// Token: 0x04005C98 RID: 23704
		Sampler1D,
		// Token: 0x04005C99 RID: 23705
		Sampler2D,
		// Token: 0x04005C9A RID: 23706
		Sampler3D,
		// Token: 0x04005C9B RID: 23707
		SamplerCube,
		// Token: 0x04005C9C RID: 23708
		Sampler1DShadow,
		// Token: 0x04005C9D RID: 23709
		Sampler2DShadow,
		// Token: 0x04005C9E RID: 23710
		Sampler2DRect,
		// Token: 0x04005C9F RID: 23711
		Sampler2DRectShadow,
		// Token: 0x04005CA0 RID: 23712
		FloatMat2x3,
		// Token: 0x04005CA1 RID: 23713
		FloatMat2x4,
		// Token: 0x04005CA2 RID: 23714
		FloatMat3x2,
		// Token: 0x04005CA3 RID: 23715
		FloatMat3x4,
		// Token: 0x04005CA4 RID: 23716
		FloatMat4x2,
		// Token: 0x04005CA5 RID: 23717
		FloatMat4x3,
		// Token: 0x04005CA6 RID: 23718
		DeleteStatus = 35712,
		// Token: 0x04005CA7 RID: 23719
		CompileStatus,
		// Token: 0x04005CA8 RID: 23720
		LinkStatus,
		// Token: 0x04005CA9 RID: 23721
		ValidateStatus,
		// Token: 0x04005CAA RID: 23722
		InfoLogLength,
		// Token: 0x04005CAB RID: 23723
		AttachedShaders,
		// Token: 0x04005CAC RID: 23724
		ActiveUniforms,
		// Token: 0x04005CAD RID: 23725
		ActiveUniformMaxLength,
		// Token: 0x04005CAE RID: 23726
		ShaderSourceLength,
		// Token: 0x04005CAF RID: 23727
		ActiveAttributes,
		// Token: 0x04005CB0 RID: 23728
		ActiveAttributeMaxLength,
		// Token: 0x04005CB1 RID: 23729
		FragmentShaderDerivativeHint,
		// Token: 0x04005CB2 RID: 23730
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x04005CB3 RID: 23731
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x04005CB4 RID: 23732
		ShadingLanguageVersion,
		// Token: 0x04005CB5 RID: 23733
		CurrentProgram,
		// Token: 0x04005CB6 RID: 23734
		ImplementationColorReadType = 35738,
		// Token: 0x04005CB7 RID: 23735
		ImplementationColorReadFormat,
		// Token: 0x04005CB8 RID: 23736
		TextureRedType = 35856,
		// Token: 0x04005CB9 RID: 23737
		TextureGreenType,
		// Token: 0x04005CBA RID: 23738
		TextureBlueType,
		// Token: 0x04005CBB RID: 23739
		TextureAlphaType,
		// Token: 0x04005CBC RID: 23740
		TextureLuminanceType,
		// Token: 0x04005CBD RID: 23741
		TextureIntensityType,
		// Token: 0x04005CBE RID: 23742
		TextureDepthType,
		// Token: 0x04005CBF RID: 23743
		UnsignedNormalized,
		// Token: 0x04005CC0 RID: 23744
		Texture1DArray,
		// Token: 0x04005CC1 RID: 23745
		ProxyTexture1DArray,
		// Token: 0x04005CC2 RID: 23746
		Texture2DArray,
		// Token: 0x04005CC3 RID: 23747
		ProxyTexture2DArray,
		// Token: 0x04005CC4 RID: 23748
		TextureBinding1DArray,
		// Token: 0x04005CC5 RID: 23749
		TextureBinding2DArray,
		// Token: 0x04005CC6 RID: 23750
		MaxGeometryTextureImageUnits = 35881,
		// Token: 0x04005CC7 RID: 23751
		TextureBuffer,
		// Token: 0x04005CC8 RID: 23752
		TextureBufferBinding = 35882,
		// Token: 0x04005CC9 RID: 23753
		MaxTextureBufferSize,
		// Token: 0x04005CCA RID: 23754
		TextureBindingBuffer,
		// Token: 0x04005CCB RID: 23755
		TextureBufferDataStoreBinding,
		// Token: 0x04005CCC RID: 23756
		AnySamplesPassed = 35887,
		// Token: 0x04005CCD RID: 23757
		SampleShading = 35894,
		// Token: 0x04005CCE RID: 23758
		SampleShadingArb = 35894,
		// Token: 0x04005CCF RID: 23759
		MinSampleShadingValue,
		// Token: 0x04005CD0 RID: 23760
		MinSampleShadingValueArb = 35895,
		// Token: 0x04005CD1 RID: 23761
		R11fG11fB10f = 35898,
		// Token: 0x04005CD2 RID: 23762
		UnsignedInt10F11F11FRev,
		// Token: 0x04005CD3 RID: 23763
		Rgb9E5 = 35901,
		// Token: 0x04005CD4 RID: 23764
		UnsignedInt5999Rev,
		// Token: 0x04005CD5 RID: 23765
		TextureSharedSize,
		// Token: 0x04005CD6 RID: 23766
		Srgb,
		// Token: 0x04005CD7 RID: 23767
		Srgb8,
		// Token: 0x04005CD8 RID: 23768
		SrgbAlpha,
		// Token: 0x04005CD9 RID: 23769
		Srgb8Alpha8,
		// Token: 0x04005CDA RID: 23770
		SluminanceAlpha,
		// Token: 0x04005CDB RID: 23771
		Sluminance8Alpha8,
		// Token: 0x04005CDC RID: 23772
		Sluminance,
		// Token: 0x04005CDD RID: 23773
		Sluminance8,
		// Token: 0x04005CDE RID: 23774
		CompressedSrgb,
		// Token: 0x04005CDF RID: 23775
		CompressedSrgbAlpha,
		// Token: 0x04005CE0 RID: 23776
		CompressedSluminance,
		// Token: 0x04005CE1 RID: 23777
		CompressedSluminanceAlpha,
		// Token: 0x04005CE2 RID: 23778
		CompressedSrgbS3tcDxt1Ext,
		// Token: 0x04005CE3 RID: 23779
		CompressedSrgbAlphaS3tcDxt1Ext,
		// Token: 0x04005CE4 RID: 23780
		CompressedSrgbAlphaS3tcDxt3Ext,
		// Token: 0x04005CE5 RID: 23781
		CompressedSrgbAlphaS3tcDxt5Ext,
		// Token: 0x04005CE6 RID: 23782
		TransformFeedbackVaryingMaxLength = 35958,
		// Token: 0x04005CE7 RID: 23783
		TransformFeedbackBufferMode = 35967,
		// Token: 0x04005CE8 RID: 23784
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x04005CE9 RID: 23785
		TransformFeedbackVaryings = 35971,
		// Token: 0x04005CEA RID: 23786
		TransformFeedbackBufferStart,
		// Token: 0x04005CEB RID: 23787
		TransformFeedbackBufferSize,
		// Token: 0x04005CEC RID: 23788
		PrimitivesGenerated = 35975,
		// Token: 0x04005CED RID: 23789
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04005CEE RID: 23790
		RasterizerDiscard,
		// Token: 0x04005CEF RID: 23791
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x04005CF0 RID: 23792
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x04005CF1 RID: 23793
		InterleavedAttribs,
		// Token: 0x04005CF2 RID: 23794
		SeparateAttribs,
		// Token: 0x04005CF3 RID: 23795
		TransformFeedbackBuffer,
		// Token: 0x04005CF4 RID: 23796
		TransformFeedbackBufferBinding,
		// Token: 0x04005CF5 RID: 23797
		PointSpriteCoordOrigin = 36000,
		// Token: 0x04005CF6 RID: 23798
		LowerLeft,
		// Token: 0x04005CF7 RID: 23799
		UpperLeft,
		// Token: 0x04005CF8 RID: 23800
		StencilBackRef,
		// Token: 0x04005CF9 RID: 23801
		StencilBackValueMask,
		// Token: 0x04005CFA RID: 23802
		StencilBackWritemask,
		// Token: 0x04005CFB RID: 23803
		DrawFramebufferBinding,
		// Token: 0x04005CFC RID: 23804
		FramebufferBinding = 36006,
		// Token: 0x04005CFD RID: 23805
		FramebufferBindingExt = 36006,
		// Token: 0x04005CFE RID: 23806
		RenderbufferBinding,
		// Token: 0x04005CFF RID: 23807
		RenderbufferBindingExt = 36007,
		// Token: 0x04005D00 RID: 23808
		ReadFramebuffer,
		// Token: 0x04005D01 RID: 23809
		DrawFramebuffer,
		// Token: 0x04005D02 RID: 23810
		ReadFramebufferBinding,
		// Token: 0x04005D03 RID: 23811
		RenderbufferSamples,
		// Token: 0x04005D04 RID: 23812
		DepthComponent32f,
		// Token: 0x04005D05 RID: 23813
		Depth32fStencil8,
		// Token: 0x04005D06 RID: 23814
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04005D07 RID: 23815
		FramebufferAttachmentObjectTypeExt = 36048,
		// Token: 0x04005D08 RID: 23816
		FramebufferAttachmentObjectName,
		// Token: 0x04005D09 RID: 23817
		FramebufferAttachmentObjectNameExt = 36049,
		// Token: 0x04005D0A RID: 23818
		FramebufferAttachmentTextureLevel,
		// Token: 0x04005D0B RID: 23819
		FramebufferAttachmentTextureLevelExt = 36050,
		// Token: 0x04005D0C RID: 23820
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04005D0D RID: 23821
		FramebufferAttachmentTextureCubeMapFaceExt = 36051,
		// Token: 0x04005D0E RID: 23822
		FramebufferAttachmentTexture3DZoffsetExt,
		// Token: 0x04005D0F RID: 23823
		FramebufferAttachmentTextureLayer = 36052,
		// Token: 0x04005D10 RID: 23824
		FramebufferComplete,
		// Token: 0x04005D11 RID: 23825
		FramebufferCompleteExt = 36053,
		// Token: 0x04005D12 RID: 23826
		FramebufferIncompleteAttachment,
		// Token: 0x04005D13 RID: 23827
		FramebufferIncompleteAttachmentExt = 36054,
		// Token: 0x04005D14 RID: 23828
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04005D15 RID: 23829
		FramebufferIncompleteMissingAttachmentExt = 36055,
		// Token: 0x04005D16 RID: 23830
		FramebufferIncompleteDimensionsExt = 36057,
		// Token: 0x04005D17 RID: 23831
		FramebufferIncompleteFormatsExt,
		// Token: 0x04005D18 RID: 23832
		FramebufferIncompleteDrawBuffer,
		// Token: 0x04005D19 RID: 23833
		FramebufferIncompleteDrawBufferExt = 36059,
		// Token: 0x04005D1A RID: 23834
		FramebufferIncompleteReadBuffer,
		// Token: 0x04005D1B RID: 23835
		FramebufferIncompleteReadBufferExt = 36060,
		// Token: 0x04005D1C RID: 23836
		FramebufferUnsupported,
		// Token: 0x04005D1D RID: 23837
		FramebufferUnsupportedExt = 36061,
		// Token: 0x04005D1E RID: 23838
		MaxColorAttachments = 36063,
		// Token: 0x04005D1F RID: 23839
		MaxColorAttachmentsExt = 36063,
		// Token: 0x04005D20 RID: 23840
		ColorAttachment0,
		// Token: 0x04005D21 RID: 23841
		ColorAttachment0Ext = 36064,
		// Token: 0x04005D22 RID: 23842
		ColorAttachment1,
		// Token: 0x04005D23 RID: 23843
		ColorAttachment1Ext = 36065,
		// Token: 0x04005D24 RID: 23844
		ColorAttachment2,
		// Token: 0x04005D25 RID: 23845
		ColorAttachment2Ext = 36066,
		// Token: 0x04005D26 RID: 23846
		ColorAttachment3,
		// Token: 0x04005D27 RID: 23847
		ColorAttachment3Ext = 36067,
		// Token: 0x04005D28 RID: 23848
		ColorAttachment4,
		// Token: 0x04005D29 RID: 23849
		ColorAttachment4Ext = 36068,
		// Token: 0x04005D2A RID: 23850
		ColorAttachment5,
		// Token: 0x04005D2B RID: 23851
		ColorAttachment5Ext = 36069,
		// Token: 0x04005D2C RID: 23852
		ColorAttachment6,
		// Token: 0x04005D2D RID: 23853
		ColorAttachment6Ext = 36070,
		// Token: 0x04005D2E RID: 23854
		ColorAttachment7,
		// Token: 0x04005D2F RID: 23855
		ColorAttachment7Ext = 36071,
		// Token: 0x04005D30 RID: 23856
		ColorAttachment8,
		// Token: 0x04005D31 RID: 23857
		ColorAttachment8Ext = 36072,
		// Token: 0x04005D32 RID: 23858
		ColorAttachment9,
		// Token: 0x04005D33 RID: 23859
		ColorAttachment9Ext = 36073,
		// Token: 0x04005D34 RID: 23860
		ColorAttachment10,
		// Token: 0x04005D35 RID: 23861
		ColorAttachment10Ext = 36074,
		// Token: 0x04005D36 RID: 23862
		ColorAttachment11,
		// Token: 0x04005D37 RID: 23863
		ColorAttachment11Ext = 36075,
		// Token: 0x04005D38 RID: 23864
		ColorAttachment12,
		// Token: 0x04005D39 RID: 23865
		ColorAttachment12Ext = 36076,
		// Token: 0x04005D3A RID: 23866
		ColorAttachment13,
		// Token: 0x04005D3B RID: 23867
		ColorAttachment13Ext = 36077,
		// Token: 0x04005D3C RID: 23868
		ColorAttachment14,
		// Token: 0x04005D3D RID: 23869
		ColorAttachment14Ext = 36078,
		// Token: 0x04005D3E RID: 23870
		ColorAttachment15,
		// Token: 0x04005D3F RID: 23871
		ColorAttachment15Ext = 36079,
		// Token: 0x04005D40 RID: 23872
		DepthAttachment = 36096,
		// Token: 0x04005D41 RID: 23873
		DepthAttachmentExt = 36096,
		// Token: 0x04005D42 RID: 23874
		StencilAttachment = 36128,
		// Token: 0x04005D43 RID: 23875
		StencilAttachmentExt = 36128,
		// Token: 0x04005D44 RID: 23876
		Framebuffer = 36160,
		// Token: 0x04005D45 RID: 23877
		FramebufferExt = 36160,
		// Token: 0x04005D46 RID: 23878
		Renderbuffer,
		// Token: 0x04005D47 RID: 23879
		RenderbufferExt = 36161,
		// Token: 0x04005D48 RID: 23880
		RenderbufferWidth,
		// Token: 0x04005D49 RID: 23881
		RenderbufferWidthExt = 36162,
		// Token: 0x04005D4A RID: 23882
		RenderbufferHeight,
		// Token: 0x04005D4B RID: 23883
		RenderbufferHeightExt = 36163,
		// Token: 0x04005D4C RID: 23884
		RenderbufferInternalFormat,
		// Token: 0x04005D4D RID: 23885
		RenderbufferInternalFormatExt = 36164,
		// Token: 0x04005D4E RID: 23886
		StencilIndex1 = 36166,
		// Token: 0x04005D4F RID: 23887
		StencilIndex1Ext = 36166,
		// Token: 0x04005D50 RID: 23888
		StencilIndex4,
		// Token: 0x04005D51 RID: 23889
		StencilIndex4Ext = 36167,
		// Token: 0x04005D52 RID: 23890
		StencilIndex8,
		// Token: 0x04005D53 RID: 23891
		StencilIndex8Ext = 36168,
		// Token: 0x04005D54 RID: 23892
		StencilIndex16,
		// Token: 0x04005D55 RID: 23893
		StencilIndex16Ext = 36169,
		// Token: 0x04005D56 RID: 23894
		RenderbufferRedSize = 36176,
		// Token: 0x04005D57 RID: 23895
		RenderbufferRedSizeExt = 36176,
		// Token: 0x04005D58 RID: 23896
		RenderbufferGreenSize,
		// Token: 0x04005D59 RID: 23897
		RenderbufferGreenSizeExt = 36177,
		// Token: 0x04005D5A RID: 23898
		RenderbufferBlueSize,
		// Token: 0x04005D5B RID: 23899
		RenderbufferBlueSizeExt = 36178,
		// Token: 0x04005D5C RID: 23900
		RenderbufferAlphaSize,
		// Token: 0x04005D5D RID: 23901
		RenderbufferAlphaSizeExt = 36179,
		// Token: 0x04005D5E RID: 23902
		RenderbufferDepthSize,
		// Token: 0x04005D5F RID: 23903
		RenderbufferDepthSizeExt = 36180,
		// Token: 0x04005D60 RID: 23904
		RenderbufferStencilSize,
		// Token: 0x04005D61 RID: 23905
		RenderbufferStencilSizeExt = 36181,
		// Token: 0x04005D62 RID: 23906
		FramebufferIncompleteMultisample,
		// Token: 0x04005D63 RID: 23907
		MaxSamples,
		// Token: 0x04005D64 RID: 23908
		Rgb565 = 36194,
		// Token: 0x04005D65 RID: 23909
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x04005D66 RID: 23910
		AnySamplesPassedConservative,
		// Token: 0x04005D67 RID: 23911
		MaxElementIndex,
		// Token: 0x04005D68 RID: 23912
		Rgba32ui = 36208,
		// Token: 0x04005D69 RID: 23913
		Rgb32ui,
		// Token: 0x04005D6A RID: 23914
		Rgba16ui = 36214,
		// Token: 0x04005D6B RID: 23915
		Rgb16ui,
		// Token: 0x04005D6C RID: 23916
		Rgba8ui = 36220,
		// Token: 0x04005D6D RID: 23917
		Rgb8ui,
		// Token: 0x04005D6E RID: 23918
		Rgba32i = 36226,
		// Token: 0x04005D6F RID: 23919
		Rgb32i,
		// Token: 0x04005D70 RID: 23920
		Rgba16i = 36232,
		// Token: 0x04005D71 RID: 23921
		Rgb16i,
		// Token: 0x04005D72 RID: 23922
		Rgba8i = 36238,
		// Token: 0x04005D73 RID: 23923
		Rgb8i,
		// Token: 0x04005D74 RID: 23924
		RedInteger = 36244,
		// Token: 0x04005D75 RID: 23925
		GreenInteger,
		// Token: 0x04005D76 RID: 23926
		BlueInteger,
		// Token: 0x04005D77 RID: 23927
		AlphaInteger,
		// Token: 0x04005D78 RID: 23928
		RgbInteger,
		// Token: 0x04005D79 RID: 23929
		RgbaInteger,
		// Token: 0x04005D7A RID: 23930
		BgrInteger,
		// Token: 0x04005D7B RID: 23931
		BgraInteger,
		// Token: 0x04005D7C RID: 23932
		Int2101010Rev = 36255,
		// Token: 0x04005D7D RID: 23933
		FramebufferAttachmentLayered = 36263,
		// Token: 0x04005D7E RID: 23934
		FramebufferIncompleteLayerTargets,
		// Token: 0x04005D7F RID: 23935
		FramebufferIncompleteLayerCount,
		// Token: 0x04005D80 RID: 23936
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x04005D81 RID: 23937
		ShaderIncludeArb,
		// Token: 0x04005D82 RID: 23938
		FramebufferSrgb = 36281,
		// Token: 0x04005D83 RID: 23939
		CompressedRedRgtc1 = 36283,
		// Token: 0x04005D84 RID: 23940
		CompressedSignedRedRgtc1,
		// Token: 0x04005D85 RID: 23941
		CompressedRgRgtc2,
		// Token: 0x04005D86 RID: 23942
		CompressedSignedRgRgtc2,
		// Token: 0x04005D87 RID: 23943
		Sampler1DArray = 36288,
		// Token: 0x04005D88 RID: 23944
		Sampler2DArray,
		// Token: 0x04005D89 RID: 23945
		SamplerBuffer,
		// Token: 0x04005D8A RID: 23946
		Sampler1DArrayShadow,
		// Token: 0x04005D8B RID: 23947
		Sampler2DArrayShadow,
		// Token: 0x04005D8C RID: 23948
		SamplerCubeShadow,
		// Token: 0x04005D8D RID: 23949
		UnsignedIntVec2,
		// Token: 0x04005D8E RID: 23950
		UnsignedIntVec3,
		// Token: 0x04005D8F RID: 23951
		UnsignedIntVec4,
		// Token: 0x04005D90 RID: 23952
		IntSampler1D,
		// Token: 0x04005D91 RID: 23953
		IntSampler2D,
		// Token: 0x04005D92 RID: 23954
		IntSampler3D,
		// Token: 0x04005D93 RID: 23955
		IntSamplerCube,
		// Token: 0x04005D94 RID: 23956
		IntSampler2DRect,
		// Token: 0x04005D95 RID: 23957
		IntSampler1DArray,
		// Token: 0x04005D96 RID: 23958
		IntSampler2DArray,
		// Token: 0x04005D97 RID: 23959
		IntSamplerBuffer,
		// Token: 0x04005D98 RID: 23960
		UnsignedIntSampler1D,
		// Token: 0x04005D99 RID: 23961
		UnsignedIntSampler2D,
		// Token: 0x04005D9A RID: 23962
		UnsignedIntSampler3D,
		// Token: 0x04005D9B RID: 23963
		UnsignedIntSamplerCube,
		// Token: 0x04005D9C RID: 23964
		UnsignedIntSampler2DRect,
		// Token: 0x04005D9D RID: 23965
		UnsignedIntSampler1DArray,
		// Token: 0x04005D9E RID: 23966
		UnsignedIntSampler2DArray,
		// Token: 0x04005D9F RID: 23967
		UnsignedIntSamplerBuffer,
		// Token: 0x04005DA0 RID: 23968
		GeometryShader,
		// Token: 0x04005DA1 RID: 23969
		MaxGeometryVaryingComponents = 36317,
		// Token: 0x04005DA2 RID: 23970
		MaxVertexVaryingComponents,
		// Token: 0x04005DA3 RID: 23971
		MaxGeometryUniformComponents,
		// Token: 0x04005DA4 RID: 23972
		MaxGeometryOutputVertices,
		// Token: 0x04005DA5 RID: 23973
		MaxGeometryTotalOutputComponents,
		// Token: 0x04005DA6 RID: 23974
		ActiveSubroutines = 36325,
		// Token: 0x04005DA7 RID: 23975
		ActiveSubroutineUniforms,
		// Token: 0x04005DA8 RID: 23976
		MaxSubroutines,
		// Token: 0x04005DA9 RID: 23977
		MaxSubroutineUniformLocations,
		// Token: 0x04005DAA RID: 23978
		NamedStringLengthArb,
		// Token: 0x04005DAB RID: 23979
		NamedStringTypeArb,
		// Token: 0x04005DAC RID: 23980
		LowFloat = 36336,
		// Token: 0x04005DAD RID: 23981
		MediumFloat,
		// Token: 0x04005DAE RID: 23982
		HighFloat,
		// Token: 0x04005DAF RID: 23983
		LowInt,
		// Token: 0x04005DB0 RID: 23984
		MediumInt,
		// Token: 0x04005DB1 RID: 23985
		HighInt,
		// Token: 0x04005DB2 RID: 23986
		ShaderBinaryFormats = 36344,
		// Token: 0x04005DB3 RID: 23987
		NumShaderBinaryFormats,
		// Token: 0x04005DB4 RID: 23988
		ShaderCompiler,
		// Token: 0x04005DB5 RID: 23989
		MaxVertexUniformVectors,
		// Token: 0x04005DB6 RID: 23990
		MaxVaryingVectors,
		// Token: 0x04005DB7 RID: 23991
		MaxFragmentUniformVectors,
		// Token: 0x04005DB8 RID: 23992
		QueryWait = 36371,
		// Token: 0x04005DB9 RID: 23993
		QueryNoWait,
		// Token: 0x04005DBA RID: 23994
		QueryByRegionWait,
		// Token: 0x04005DBB RID: 23995
		QueryByRegionNoWait,
		// Token: 0x04005DBC RID: 23996
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x04005DBD RID: 23997
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x04005DBE RID: 23998
		TransformFeedback = 36386,
		// Token: 0x04005DBF RID: 23999
		TransformFeedbackBufferPaused,
		// Token: 0x04005DC0 RID: 24000
		TransformFeedbackPaused = 36387,
		// Token: 0x04005DC1 RID: 24001
		TransformFeedbackActive,
		// Token: 0x04005DC2 RID: 24002
		TransformFeedbackBufferActive = 36388,
		// Token: 0x04005DC3 RID: 24003
		TransformFeedbackBinding,
		// Token: 0x04005DC4 RID: 24004
		Timestamp = 36392,
		// Token: 0x04005DC5 RID: 24005
		TextureSwizzleR = 36418,
		// Token: 0x04005DC6 RID: 24006
		TextureSwizzleG,
		// Token: 0x04005DC7 RID: 24007
		TextureSwizzleB,
		// Token: 0x04005DC8 RID: 24008
		TextureSwizzleA,
		// Token: 0x04005DC9 RID: 24009
		TextureSwizzleRgba,
		// Token: 0x04005DCA RID: 24010
		ActiveSubroutineUniformLocations,
		// Token: 0x04005DCB RID: 24011
		ActiveSubroutineMaxLength,
		// Token: 0x04005DCC RID: 24012
		ActiveSubroutineUniformMaxLength,
		// Token: 0x04005DCD RID: 24013
		NumCompatibleSubroutines,
		// Token: 0x04005DCE RID: 24014
		CompatibleSubroutines,
		// Token: 0x04005DCF RID: 24015
		QuadsFollowProvokingVertexConvention,
		// Token: 0x04005DD0 RID: 24016
		FirstVertexConvention,
		// Token: 0x04005DD1 RID: 24017
		LastVertexConvention,
		// Token: 0x04005DD2 RID: 24018
		ProvokingVertex,
		// Token: 0x04005DD3 RID: 24019
		SamplePosition,
		// Token: 0x04005DD4 RID: 24020
		SampleMask,
		// Token: 0x04005DD5 RID: 24021
		SampleMaskValue,
		// Token: 0x04005DD6 RID: 24022
		MaxSampleMaskWords = 36441,
		// Token: 0x04005DD7 RID: 24023
		MaxGeometryShaderInvocations,
		// Token: 0x04005DD8 RID: 24024
		MinFragmentInterpolationOffset,
		// Token: 0x04005DD9 RID: 24025
		MaxFragmentInterpolationOffset,
		// Token: 0x04005DDA RID: 24026
		FragmentInterpolationOffsetBits,
		// Token: 0x04005DDB RID: 24027
		MinProgramTextureGatherOffset,
		// Token: 0x04005DDC RID: 24028
		MinProgramTextureGatherOffsetArb = 36446,
		// Token: 0x04005DDD RID: 24029
		MaxProgramTextureGatherOffset,
		// Token: 0x04005DDE RID: 24030
		MaxProgramTextureGatherOffsetArb = 36447,
		// Token: 0x04005DDF RID: 24031
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x04005DE0 RID: 24032
		MaxVertexStreams,
		// Token: 0x04005DE1 RID: 24033
		PatchVertices,
		// Token: 0x04005DE2 RID: 24034
		PatchDefaultInnerLevel,
		// Token: 0x04005DE3 RID: 24035
		PatchDefaultOuterLevel,
		// Token: 0x04005DE4 RID: 24036
		TessControlOutputVertices,
		// Token: 0x04005DE5 RID: 24037
		TessGenMode,
		// Token: 0x04005DE6 RID: 24038
		TessGenSpacing,
		// Token: 0x04005DE7 RID: 24039
		TessGenVertexOrder,
		// Token: 0x04005DE8 RID: 24040
		TessGenPointMode,
		// Token: 0x04005DE9 RID: 24041
		Isolines,
		// Token: 0x04005DEA RID: 24042
		FractionalOdd,
		// Token: 0x04005DEB RID: 24043
		FractionalEven,
		// Token: 0x04005DEC RID: 24044
		MaxPatchVertices,
		// Token: 0x04005DED RID: 24045
		MaxTessGenLevel,
		// Token: 0x04005DEE RID: 24046
		MaxTessControlUniformComponents,
		// Token: 0x04005DEF RID: 24047
		MaxTessEvaluationUniformComponents,
		// Token: 0x04005DF0 RID: 24048
		MaxTessControlTextureImageUnits,
		// Token: 0x04005DF1 RID: 24049
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x04005DF2 RID: 24050
		MaxTessControlOutputComponents,
		// Token: 0x04005DF3 RID: 24051
		MaxTessPatchComponents,
		// Token: 0x04005DF4 RID: 24052
		MaxTessControlTotalOutputComponents,
		// Token: 0x04005DF5 RID: 24053
		MaxTessEvaluationOutputComponents,
		// Token: 0x04005DF6 RID: 24054
		TessEvaluationShader,
		// Token: 0x04005DF7 RID: 24055
		TessControlShader,
		// Token: 0x04005DF8 RID: 24056
		MaxTessControlUniformBlocks,
		// Token: 0x04005DF9 RID: 24057
		MaxTessEvaluationUniformBlocks,
		// Token: 0x04005DFA RID: 24058
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x04005DFB RID: 24059
		CompressedRgbaBptcUnormArb = 36492,
		// Token: 0x04005DFC RID: 24060
		CompressedSrgbAlphaBptcUnorm,
		// Token: 0x04005DFD RID: 24061
		CompressedSrgbAlphaBptcUnormArb = 36493,
		// Token: 0x04005DFE RID: 24062
		CompressedRgbBptcSignedFloat,
		// Token: 0x04005DFF RID: 24063
		CompressedRgbBptcSignedFloatArb = 36494,
		// Token: 0x04005E00 RID: 24064
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x04005E01 RID: 24065
		CompressedRgbBptcUnsignedFloatArb = 36495,
		// Token: 0x04005E02 RID: 24066
		CopyReadBuffer = 36662,
		// Token: 0x04005E03 RID: 24067
		CopyReadBufferBinding = 36662,
		// Token: 0x04005E04 RID: 24068
		CopyWriteBuffer,
		// Token: 0x04005E05 RID: 24069
		CopyWriteBufferBinding = 36663,
		// Token: 0x04005E06 RID: 24070
		MaxImageUnits,
		// Token: 0x04005E07 RID: 24071
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x04005E08 RID: 24072
		MaxCombinedShaderOutputResources = 36665,
		// Token: 0x04005E09 RID: 24073
		ImageBindingName,
		// Token: 0x04005E0A RID: 24074
		ImageBindingLevel,
		// Token: 0x04005E0B RID: 24075
		ImageBindingLayered,
		// Token: 0x04005E0C RID: 24076
		ImageBindingLayer,
		// Token: 0x04005E0D RID: 24077
		ImageBindingAccess,
		// Token: 0x04005E0E RID: 24078
		DrawIndirectBuffer,
		// Token: 0x04005E0F RID: 24079
		DrawIndirectBufferBinding = 36675,
		// Token: 0x04005E10 RID: 24080
		DoubleMat2 = 36678,
		// Token: 0x04005E11 RID: 24081
		DoubleMat3,
		// Token: 0x04005E12 RID: 24082
		DoubleMat4,
		// Token: 0x04005E13 RID: 24083
		DoubleMat2x3,
		// Token: 0x04005E14 RID: 24084
		DoubleMat2x4,
		// Token: 0x04005E15 RID: 24085
		DoubleMat3x2,
		// Token: 0x04005E16 RID: 24086
		DoubleMat3x4,
		// Token: 0x04005E17 RID: 24087
		DoubleMat4x2,
		// Token: 0x04005E18 RID: 24088
		DoubleMat4x3,
		// Token: 0x04005E19 RID: 24089
		VertexBindingBuffer,
		// Token: 0x04005E1A RID: 24090
		R8Snorm = 36756,
		// Token: 0x04005E1B RID: 24091
		Rg8Snorm,
		// Token: 0x04005E1C RID: 24092
		Rgb8Snorm,
		// Token: 0x04005E1D RID: 24093
		Rgba8Snorm,
		// Token: 0x04005E1E RID: 24094
		R16Snorm,
		// Token: 0x04005E1F RID: 24095
		Rg16Snorm,
		// Token: 0x04005E20 RID: 24096
		Rgb16Snorm,
		// Token: 0x04005E21 RID: 24097
		Rgba16Snorm,
		// Token: 0x04005E22 RID: 24098
		SignedNormalized,
		// Token: 0x04005E23 RID: 24099
		PrimitiveRestart,
		// Token: 0x04005E24 RID: 24100
		PrimitiveRestartIndex,
		// Token: 0x04005E25 RID: 24101
		MaxProgramTextureGatherComponentsArb,
		// Token: 0x04005E26 RID: 24102
		BinningControlHintQcom = 36784,
		// Token: 0x04005E27 RID: 24103
		DoubleVec2 = 36860,
		// Token: 0x04005E28 RID: 24104
		DoubleVec3,
		// Token: 0x04005E29 RID: 24105
		DoubleVec4,
		// Token: 0x04005E2A RID: 24106
		SamplerBufferAmd = 36865,
		// Token: 0x04005E2B RID: 24107
		IntSamplerBufferAmd,
		// Token: 0x04005E2C RID: 24108
		UnsignedIntSamplerBufferAmd,
		// Token: 0x04005E2D RID: 24109
		TessellationModeAmd,
		// Token: 0x04005E2E RID: 24110
		TessellationFactorAmd,
		// Token: 0x04005E2F RID: 24111
		DiscreteAmd,
		// Token: 0x04005E30 RID: 24112
		ContinuousAmd,
		// Token: 0x04005E31 RID: 24113
		TextureCubeMapArray = 36873,
		// Token: 0x04005E32 RID: 24114
		TextureCubeMapArrayArb = 36873,
		// Token: 0x04005E33 RID: 24115
		TextureBindingCubeMapArray,
		// Token: 0x04005E34 RID: 24116
		TextureBindingCubeMapArrayArb = 36874,
		// Token: 0x04005E35 RID: 24117
		ProxyTextureCubeMapArray,
		// Token: 0x04005E36 RID: 24118
		ProxyTextureCubeMapArrayArb = 36875,
		// Token: 0x04005E37 RID: 24119
		SamplerCubeMapArray,
		// Token: 0x04005E38 RID: 24120
		SamplerCubeMapArrayArb = 36876,
		// Token: 0x04005E39 RID: 24121
		SamplerCubeMapArrayShadow,
		// Token: 0x04005E3A RID: 24122
		SamplerCubeMapArrayShadowArb = 36877,
		// Token: 0x04005E3B RID: 24123
		IntSamplerCubeMapArray,
		// Token: 0x04005E3C RID: 24124
		IntSamplerCubeMapArrayArb = 36878,
		// Token: 0x04005E3D RID: 24125
		UnsignedIntSamplerCubeMapArray,
		// Token: 0x04005E3E RID: 24126
		UnsignedIntSamplerCubeMapArrayArb = 36879,
		// Token: 0x04005E3F RID: 24127
		Image1D = 36940,
		// Token: 0x04005E40 RID: 24128
		Image2D,
		// Token: 0x04005E41 RID: 24129
		Image3D,
		// Token: 0x04005E42 RID: 24130
		Image2DRect,
		// Token: 0x04005E43 RID: 24131
		ImageCube,
		// Token: 0x04005E44 RID: 24132
		ImageBuffer,
		// Token: 0x04005E45 RID: 24133
		Image1DArray,
		// Token: 0x04005E46 RID: 24134
		Image2DArray,
		// Token: 0x04005E47 RID: 24135
		ImageCubeMapArray,
		// Token: 0x04005E48 RID: 24136
		Image2DMultisample,
		// Token: 0x04005E49 RID: 24137
		Image2DMultisampleArray,
		// Token: 0x04005E4A RID: 24138
		IntImage1D,
		// Token: 0x04005E4B RID: 24139
		IntImage2D,
		// Token: 0x04005E4C RID: 24140
		IntImage3D,
		// Token: 0x04005E4D RID: 24141
		IntImage2DRect,
		// Token: 0x04005E4E RID: 24142
		IntImageCube,
		// Token: 0x04005E4F RID: 24143
		IntImageBuffer,
		// Token: 0x04005E50 RID: 24144
		IntImage1DArray,
		// Token: 0x04005E51 RID: 24145
		IntImage2DArray,
		// Token: 0x04005E52 RID: 24146
		IntImageCubeMapArray,
		// Token: 0x04005E53 RID: 24147
		IntImage2DMultisample,
		// Token: 0x04005E54 RID: 24148
		IntImage2DMultisampleArray,
		// Token: 0x04005E55 RID: 24149
		UnsignedIntImage1D,
		// Token: 0x04005E56 RID: 24150
		UnsignedIntImage2D,
		// Token: 0x04005E57 RID: 24151
		UnsignedIntImage3D,
		// Token: 0x04005E58 RID: 24152
		UnsignedIntImage2DRect,
		// Token: 0x04005E59 RID: 24153
		UnsignedIntImageCube,
		// Token: 0x04005E5A RID: 24154
		UnsignedIntImageBuffer,
		// Token: 0x04005E5B RID: 24155
		UnsignedIntImage1DArray,
		// Token: 0x04005E5C RID: 24156
		UnsignedIntImage2DArray,
		// Token: 0x04005E5D RID: 24157
		UnsignedIntImageCubeMapArray,
		// Token: 0x04005E5E RID: 24158
		UnsignedIntImage2DMultisample,
		// Token: 0x04005E5F RID: 24159
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x04005E60 RID: 24160
		MaxImageSamples,
		// Token: 0x04005E61 RID: 24161
		ImageBindingFormat,
		// Token: 0x04005E62 RID: 24162
		Rgb10A2ui,
		// Token: 0x04005E63 RID: 24163
		MinMapBufferAlignment = 37052,
		// Token: 0x04005E64 RID: 24164
		ImageFormatCompatibilityType = 37063,
		// Token: 0x04005E65 RID: 24165
		ImageFormatCompatibilityBySize,
		// Token: 0x04005E66 RID: 24166
		ImageFormatCompatibilityByClass,
		// Token: 0x04005E67 RID: 24167
		MaxVertexImageUniforms,
		// Token: 0x04005E68 RID: 24168
		MaxTessControlImageUniforms,
		// Token: 0x04005E69 RID: 24169
		MaxTessEvaluationImageUniforms,
		// Token: 0x04005E6A RID: 24170
		MaxGeometryImageUniforms,
		// Token: 0x04005E6B RID: 24171
		MaxFragmentImageUniforms,
		// Token: 0x04005E6C RID: 24172
		MaxCombinedImageUniforms,
		// Token: 0x04005E6D RID: 24173
		ShaderStorageBuffer = 37074,
		// Token: 0x04005E6E RID: 24174
		ShaderStorageBufferBinding,
		// Token: 0x04005E6F RID: 24175
		ShaderStorageBufferStart,
		// Token: 0x04005E70 RID: 24176
		ShaderStorageBufferSize,
		// Token: 0x04005E71 RID: 24177
		MaxVertexShaderStorageBlocks,
		// Token: 0x04005E72 RID: 24178
		MaxGeometryShaderStorageBlocks,
		// Token: 0x04005E73 RID: 24179
		MaxTessControlShaderStorageBlocks,
		// Token: 0x04005E74 RID: 24180
		MaxTessEvaluationShaderStorageBlocks,
		// Token: 0x04005E75 RID: 24181
		MaxFragmentShaderStorageBlocks,
		// Token: 0x04005E76 RID: 24182
		MaxComputeShaderStorageBlocks,
		// Token: 0x04005E77 RID: 24183
		MaxCombinedShaderStorageBlocks,
		// Token: 0x04005E78 RID: 24184
		MaxShaderStorageBufferBindings,
		// Token: 0x04005E79 RID: 24185
		MaxShaderStorageBlockSize,
		// Token: 0x04005E7A RID: 24186
		ShaderStorageBufferOffsetAlignment,
		// Token: 0x04005E7B RID: 24187
		DepthStencilTextureMode = 37098,
		// Token: 0x04005E7C RID: 24188
		MaxComputeFixedGroupInvocationsArb,
		// Token: 0x04005E7D RID: 24189
		MaxComputeWorkGroupInvocations = 37099,
		// Token: 0x04005E7E RID: 24190
		UniformBlockReferencedByComputeShader,
		// Token: 0x04005E7F RID: 24191
		AtomicCounterBufferReferencedByComputeShader,
		// Token: 0x04005E80 RID: 24192
		DispatchIndirectBuffer,
		// Token: 0x04005E81 RID: 24193
		DispatchIndirectBufferBinding,
		// Token: 0x04005E82 RID: 24194
		Texture2DMultisample = 37120,
		// Token: 0x04005E83 RID: 24195
		ProxyTexture2DMultisample,
		// Token: 0x04005E84 RID: 24196
		Texture2DMultisampleArray,
		// Token: 0x04005E85 RID: 24197
		ProxyTexture2DMultisampleArray,
		// Token: 0x04005E86 RID: 24198
		TextureBinding2DMultisample,
		// Token: 0x04005E87 RID: 24199
		TextureBinding2DMultisampleArray,
		// Token: 0x04005E88 RID: 24200
		TextureSamples,
		// Token: 0x04005E89 RID: 24201
		TextureFixedSampleLocations,
		// Token: 0x04005E8A RID: 24202
		Sampler2DMultisample,
		// Token: 0x04005E8B RID: 24203
		IntSampler2DMultisample,
		// Token: 0x04005E8C RID: 24204
		UnsignedIntSampler2DMultisample,
		// Token: 0x04005E8D RID: 24205
		Sampler2DMultisampleArray,
		// Token: 0x04005E8E RID: 24206
		IntSampler2DMultisampleArray,
		// Token: 0x04005E8F RID: 24207
		UnsignedIntSampler2DMultisampleArray,
		// Token: 0x04005E90 RID: 24208
		MaxColorTextureSamples,
		// Token: 0x04005E91 RID: 24209
		MaxDepthTextureSamples,
		// Token: 0x04005E92 RID: 24210
		MaxIntegerSamples,
		// Token: 0x04005E93 RID: 24211
		MaxServerWaitTimeout,
		// Token: 0x04005E94 RID: 24212
		ObjectType,
		// Token: 0x04005E95 RID: 24213
		SyncCondition,
		// Token: 0x04005E96 RID: 24214
		SyncStatus,
		// Token: 0x04005E97 RID: 24215
		SyncFlags,
		// Token: 0x04005E98 RID: 24216
		SyncFence,
		// Token: 0x04005E99 RID: 24217
		SyncGpuCommandsComplete,
		// Token: 0x04005E9A RID: 24218
		Unsignaled,
		// Token: 0x04005E9B RID: 24219
		Signaled,
		// Token: 0x04005E9C RID: 24220
		AlreadySignaled,
		// Token: 0x04005E9D RID: 24221
		TimeoutExpired,
		// Token: 0x04005E9E RID: 24222
		ConditionSatisfied,
		// Token: 0x04005E9F RID: 24223
		WaitFailed,
		// Token: 0x04005EA0 RID: 24224
		BufferAccessFlags = 37151,
		// Token: 0x04005EA1 RID: 24225
		BufferMapLength,
		// Token: 0x04005EA2 RID: 24226
		BufferMapOffset,
		// Token: 0x04005EA3 RID: 24227
		MaxVertexOutputComponents,
		// Token: 0x04005EA4 RID: 24228
		MaxGeometryInputComponents,
		// Token: 0x04005EA5 RID: 24229
		MaxGeometryOutputComponents,
		// Token: 0x04005EA6 RID: 24230
		MaxFragmentInputComponents,
		// Token: 0x04005EA7 RID: 24231
		ContextProfileMask,
		// Token: 0x04005EA8 RID: 24232
		UnpackCompressedBlockWidth,
		// Token: 0x04005EA9 RID: 24233
		UnpackCompressedBlockHeight,
		// Token: 0x04005EAA RID: 24234
		UnpackCompressedBlockDepth,
		// Token: 0x04005EAB RID: 24235
		UnpackCompressedBlockSize,
		// Token: 0x04005EAC RID: 24236
		PackCompressedBlockWidth,
		// Token: 0x04005EAD RID: 24237
		PackCompressedBlockHeight,
		// Token: 0x04005EAE RID: 24238
		PackCompressedBlockDepth,
		// Token: 0x04005EAF RID: 24239
		PackCompressedBlockSize,
		// Token: 0x04005EB0 RID: 24240
		TextureImmutableFormat,
		// Token: 0x04005EB1 RID: 24241
		MaxDebugMessageLength = 37187,
		// Token: 0x04005EB2 RID: 24242
		MaxDebugMessageLengthArb = 37187,
		// Token: 0x04005EB3 RID: 24243
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04005EB4 RID: 24244
		MaxDebugLoggedMessages,
		// Token: 0x04005EB5 RID: 24245
		MaxDebugLoggedMessagesArb = 37188,
		// Token: 0x04005EB6 RID: 24246
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04005EB7 RID: 24247
		DebugLoggedMessages,
		// Token: 0x04005EB8 RID: 24248
		DebugLoggedMessagesArb = 37189,
		// Token: 0x04005EB9 RID: 24249
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x04005EBA RID: 24250
		DebugSeverityHigh,
		// Token: 0x04005EBB RID: 24251
		DebugSeverityHighArb = 37190,
		// Token: 0x04005EBC RID: 24252
		DebugSeverityHighKhr = 37190,
		// Token: 0x04005EBD RID: 24253
		DebugSeverityMedium,
		// Token: 0x04005EBE RID: 24254
		DebugSeverityMediumArb = 37191,
		// Token: 0x04005EBF RID: 24255
		DebugSeverityMediumKhr = 37191,
		// Token: 0x04005EC0 RID: 24256
		DebugSeverityLow,
		// Token: 0x04005EC1 RID: 24257
		DebugSeverityLowArb = 37192,
		// Token: 0x04005EC2 RID: 24258
		DebugSeverityLowKhr = 37192,
		// Token: 0x04005EC3 RID: 24259
		QueryBuffer = 37266,
		// Token: 0x04005EC4 RID: 24260
		QueryBufferBinding,
		// Token: 0x04005EC5 RID: 24261
		QueryResultNoWait,
		// Token: 0x04005EC6 RID: 24262
		VirtualPageSizeXArb,
		// Token: 0x04005EC7 RID: 24263
		VirtualPageSizeYArb,
		// Token: 0x04005EC8 RID: 24264
		VirtualPageSizeZArb,
		// Token: 0x04005EC9 RID: 24265
		MaxSparseTextureSizeArb,
		// Token: 0x04005ECA RID: 24266
		MaxSparse3DTextureSizeArb,
		// Token: 0x04005ECB RID: 24267
		MaxSparseArrayTextureLayersArb,
		// Token: 0x04005ECC RID: 24268
		MinSparseLevelArb,
		// Token: 0x04005ECD RID: 24269
		TextureBufferOffset = 37277,
		// Token: 0x04005ECE RID: 24270
		TextureBufferSize,
		// Token: 0x04005ECF RID: 24271
		TextureBufferOffsetAlignment,
		// Token: 0x04005ED0 RID: 24272
		TextureSparseArb = 37286,
		// Token: 0x04005ED1 RID: 24273
		VirtualPageSizeIndexArb,
		// Token: 0x04005ED2 RID: 24274
		NumVirtualPageSizesArb,
		// Token: 0x04005ED3 RID: 24275
		SparseTextureFullArrayCubeMipmapsArb,
		// Token: 0x04005ED4 RID: 24276
		ComputeShader = 37305,
		// Token: 0x04005ED5 RID: 24277
		MaxComputeUniformBlocks = 37307,
		// Token: 0x04005ED6 RID: 24278
		MaxComputeTextureImageUnits,
		// Token: 0x04005ED7 RID: 24279
		MaxComputeImageUniforms,
		// Token: 0x04005ED8 RID: 24280
		MaxComputeWorkGroupCount,
		// Token: 0x04005ED9 RID: 24281
		MaxComputeFixedGroupSizeArb,
		// Token: 0x04005EDA RID: 24282
		MaxComputeWorkGroupSize = 37311,
		// Token: 0x04005EDB RID: 24283
		CompressedR11Eac = 37488,
		// Token: 0x04005EDC RID: 24284
		CompressedSignedR11Eac,
		// Token: 0x04005EDD RID: 24285
		CompressedRg11Eac,
		// Token: 0x04005EDE RID: 24286
		CompressedSignedRg11Eac,
		// Token: 0x04005EDF RID: 24287
		CompressedRgb8Etc2,
		// Token: 0x04005EE0 RID: 24288
		CompressedSrgb8Etc2,
		// Token: 0x04005EE1 RID: 24289
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x04005EE2 RID: 24290
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x04005EE3 RID: 24291
		CompressedRgba8Etc2Eac,
		// Token: 0x04005EE4 RID: 24292
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x04005EE5 RID: 24293
		AtomicCounterBuffer = 37568,
		// Token: 0x04005EE6 RID: 24294
		AtomicCounterBufferBinding,
		// Token: 0x04005EE7 RID: 24295
		AtomicCounterBufferStart,
		// Token: 0x04005EE8 RID: 24296
		AtomicCounterBufferSize,
		// Token: 0x04005EE9 RID: 24297
		AtomicCounterBufferDataSize,
		// Token: 0x04005EEA RID: 24298
		AtomicCounterBufferActiveAtomicCounters,
		// Token: 0x04005EEB RID: 24299
		AtomicCounterBufferActiveAtomicCounterIndices,
		// Token: 0x04005EEC RID: 24300
		AtomicCounterBufferReferencedByVertexShader,
		// Token: 0x04005EED RID: 24301
		AtomicCounterBufferReferencedByTessControlShader,
		// Token: 0x04005EEE RID: 24302
		AtomicCounterBufferReferencedByTessEvaluationShader,
		// Token: 0x04005EEF RID: 24303
		AtomicCounterBufferReferencedByGeometryShader,
		// Token: 0x04005EF0 RID: 24304
		AtomicCounterBufferReferencedByFragmentShader,
		// Token: 0x04005EF1 RID: 24305
		MaxVertexAtomicCounterBuffers,
		// Token: 0x04005EF2 RID: 24306
		MaxTessControlAtomicCounterBuffers,
		// Token: 0x04005EF3 RID: 24307
		MaxTessEvaluationAtomicCounterBuffers,
		// Token: 0x04005EF4 RID: 24308
		MaxGeometryAtomicCounterBuffers,
		// Token: 0x04005EF5 RID: 24309
		MaxFragmentAtomicCounterBuffers,
		// Token: 0x04005EF6 RID: 24310
		MaxCombinedAtomicCounterBuffers,
		// Token: 0x04005EF7 RID: 24311
		MaxVertexAtomicCounters,
		// Token: 0x04005EF8 RID: 24312
		MaxTessControlAtomicCounters,
		// Token: 0x04005EF9 RID: 24313
		MaxTessEvaluationAtomicCounters,
		// Token: 0x04005EFA RID: 24314
		MaxGeometryAtomicCounters,
		// Token: 0x04005EFB RID: 24315
		MaxFragmentAtomicCounters,
		// Token: 0x04005EFC RID: 24316
		MaxCombinedAtomicCounters,
		// Token: 0x04005EFD RID: 24317
		MaxAtomicCounterBufferSize,
		// Token: 0x04005EFE RID: 24318
		ActiveAtomicCounterBuffers,
		// Token: 0x04005EFF RID: 24319
		UniformAtomicCounterBufferIndex,
		// Token: 0x04005F00 RID: 24320
		UnsignedIntAtomicCounter,
		// Token: 0x04005F01 RID: 24321
		MaxAtomicCounterBufferBindings,
		// Token: 0x04005F02 RID: 24322
		DebugOutput = 37600,
		// Token: 0x04005F03 RID: 24323
		DebugOutputKhr = 37600,
		// Token: 0x04005F04 RID: 24324
		Uniform,
		// Token: 0x04005F05 RID: 24325
		UniformBlock,
		// Token: 0x04005F06 RID: 24326
		ProgramInput,
		// Token: 0x04005F07 RID: 24327
		ProgramOutput,
		// Token: 0x04005F08 RID: 24328
		BufferVariable,
		// Token: 0x04005F09 RID: 24329
		ShaderStorageBlock,
		// Token: 0x04005F0A RID: 24330
		IsPerPatch,
		// Token: 0x04005F0B RID: 24331
		VertexSubroutine,
		// Token: 0x04005F0C RID: 24332
		TessControlSubroutine,
		// Token: 0x04005F0D RID: 24333
		TessEvaluationSubroutine,
		// Token: 0x04005F0E RID: 24334
		GeometrySubroutine,
		// Token: 0x04005F0F RID: 24335
		FragmentSubroutine,
		// Token: 0x04005F10 RID: 24336
		ComputeSubroutine,
		// Token: 0x04005F11 RID: 24337
		VertexSubroutineUniform,
		// Token: 0x04005F12 RID: 24338
		TessControlSubroutineUniform,
		// Token: 0x04005F13 RID: 24339
		TessEvaluationSubroutineUniform,
		// Token: 0x04005F14 RID: 24340
		GeometrySubroutineUniform,
		// Token: 0x04005F15 RID: 24341
		FragmentSubroutineUniform,
		// Token: 0x04005F16 RID: 24342
		ComputeSubroutineUniform,
		// Token: 0x04005F17 RID: 24343
		TransformFeedbackVarying,
		// Token: 0x04005F18 RID: 24344
		ActiveResources,
		// Token: 0x04005F19 RID: 24345
		MaxNameLength,
		// Token: 0x04005F1A RID: 24346
		MaxNumActiveVariables,
		// Token: 0x04005F1B RID: 24347
		MaxNumCompatibleSubroutines,
		// Token: 0x04005F1C RID: 24348
		NameLength,
		// Token: 0x04005F1D RID: 24349
		Type,
		// Token: 0x04005F1E RID: 24350
		ArraySize,
		// Token: 0x04005F1F RID: 24351
		Offset,
		// Token: 0x04005F20 RID: 24352
		BlockIndex,
		// Token: 0x04005F21 RID: 24353
		ArrayStride,
		// Token: 0x04005F22 RID: 24354
		MatrixStride,
		// Token: 0x04005F23 RID: 24355
		IsRowMajor,
		// Token: 0x04005F24 RID: 24356
		AtomicCounterBufferIndex,
		// Token: 0x04005F25 RID: 24357
		BufferBinding,
		// Token: 0x04005F26 RID: 24358
		BufferDataSize,
		// Token: 0x04005F27 RID: 24359
		NumActiveVariables,
		// Token: 0x04005F28 RID: 24360
		ActiveVariables,
		// Token: 0x04005F29 RID: 24361
		ReferencedByVertexShader,
		// Token: 0x04005F2A RID: 24362
		ReferencedByTessControlShader,
		// Token: 0x04005F2B RID: 24363
		ReferencedByTessEvaluationShader,
		// Token: 0x04005F2C RID: 24364
		ReferencedByGeometryShader,
		// Token: 0x04005F2D RID: 24365
		ReferencedByFragmentShader,
		// Token: 0x04005F2E RID: 24366
		ReferencedByComputeShader,
		// Token: 0x04005F2F RID: 24367
		TopLevelArraySize,
		// Token: 0x04005F30 RID: 24368
		TopLevelArrayStride,
		// Token: 0x04005F31 RID: 24369
		Location,
		// Token: 0x04005F32 RID: 24370
		LocationIndex,
		// Token: 0x04005F33 RID: 24371
		FramebufferDefaultWidth,
		// Token: 0x04005F34 RID: 24372
		FramebufferDefaultHeight,
		// Token: 0x04005F35 RID: 24373
		FramebufferDefaultLayers,
		// Token: 0x04005F36 RID: 24374
		FramebufferDefaultSamples,
		// Token: 0x04005F37 RID: 24375
		FramebufferDefaultFixedSampleLocations,
		// Token: 0x04005F38 RID: 24376
		MaxFramebufferWidth,
		// Token: 0x04005F39 RID: 24377
		MaxFramebufferHeight,
		// Token: 0x04005F3A RID: 24378
		MaxFramebufferLayers,
		// Token: 0x04005F3B RID: 24379
		MaxFramebufferSamples,
		// Token: 0x04005F3C RID: 24380
		MaxComputeVariableGroupInvocationsArb = 37700,
		// Token: 0x04005F3D RID: 24381
		MaxComputeVariableGroupSizeArb,
		// Token: 0x04005F3E RID: 24382
		LocationComponent = 37706,
		// Token: 0x04005F3F RID: 24383
		TransformFeedbackBufferIndex,
		// Token: 0x04005F40 RID: 24384
		TransformFeedbackBufferStride,
		// Token: 0x04005F41 RID: 24385
		ClearTexture = 37733,
		// Token: 0x04005F42 RID: 24386
		NumSampleCounts = 37760,
		// Token: 0x04005F43 RID: 24387
		CompressedRgbaAstc4X4Khr = 37808,
		// Token: 0x04005F44 RID: 24388
		CompressedRgbaAstc5X4Khr,
		// Token: 0x04005F45 RID: 24389
		CompressedRgbaAstc5X5Khr,
		// Token: 0x04005F46 RID: 24390
		CompressedRgbaAstc6X5Khr,
		// Token: 0x04005F47 RID: 24391
		CompressedRgbaAstc6X6Khr,
		// Token: 0x04005F48 RID: 24392
		CompressedRgbaAstc8X5Khr,
		// Token: 0x04005F49 RID: 24393
		CompressedRgbaAstc8X6Khr,
		// Token: 0x04005F4A RID: 24394
		CompressedRgbaAstc8X8Khr,
		// Token: 0x04005F4B RID: 24395
		CompressedRgbaAstc10X5Khr,
		// Token: 0x04005F4C RID: 24396
		CompressedRgbaAstc10X6Khr,
		// Token: 0x04005F4D RID: 24397
		CompressedRgbaAstc10X8Khr,
		// Token: 0x04005F4E RID: 24398
		CompressedRgbaAstc10X10Khr,
		// Token: 0x04005F4F RID: 24399
		CompressedRgbaAstc12X10Khr,
		// Token: 0x04005F50 RID: 24400
		CompressedRgbaAstc12X12Khr,
		// Token: 0x04005F51 RID: 24401
		CompressedSrgb8Alpha8Astc4X4Khr = 37840,
		// Token: 0x04005F52 RID: 24402
		CompressedSrgb8Alpha8Astc5X4Khr,
		// Token: 0x04005F53 RID: 24403
		CompressedSrgb8Alpha8Astc5X5Khr,
		// Token: 0x04005F54 RID: 24404
		CompressedSrgb8Alpha8Astc6X5Khr,
		// Token: 0x04005F55 RID: 24405
		CompressedSrgb8Alpha8Astc6X6Khr,
		// Token: 0x04005F56 RID: 24406
		CompressedSrgb8Alpha8Astc8X5Khr,
		// Token: 0x04005F57 RID: 24407
		CompressedSrgb8Alpha8Astc8X6Khr,
		// Token: 0x04005F58 RID: 24408
		CompressedSrgb8Alpha8Astc8X8Khr,
		// Token: 0x04005F59 RID: 24409
		CompressedSrgb8Alpha8Astc10X5Khr,
		// Token: 0x04005F5A RID: 24410
		CompressedSrgb8Alpha8Astc10X6Khr,
		// Token: 0x04005F5B RID: 24411
		CompressedSrgb8Alpha8Astc10X8Khr,
		// Token: 0x04005F5C RID: 24412
		CompressedSrgb8Alpha8Astc10X10Khr,
		// Token: 0x04005F5D RID: 24413
		CompressedSrgb8Alpha8Astc12X10Khr,
		// Token: 0x04005F5E RID: 24414
		CompressedSrgb8Alpha8Astc12X12Khr,
		// Token: 0x04005F5F RID: 24415
		AllBarrierBits = -1,
		// Token: 0x04005F60 RID: 24416
		AllBarrierBitsExt = -1,
		// Token: 0x04005F61 RID: 24417
		AllShaderBits = -1,
		// Token: 0x04005F62 RID: 24418
		AllShaderBitsExt = -1,
		// Token: 0x04005F63 RID: 24419
		InvalidIndex = -1,
		// Token: 0x04005F64 RID: 24420
		QueryAllEventBitsAmd = -1,
		// Token: 0x04005F65 RID: 24421
		TimeoutIgnored = -1,
		// Token: 0x04005F66 RID: 24422
		LayoutLinearIntel = 1,
		// Token: 0x04005F67 RID: 24423
		One = 1,
		// Token: 0x04005F68 RID: 24424
		True = 1,
		// Token: 0x04005F69 RID: 24425
		LayoutLinearCpuCachedIntel,
		// Token: 0x04005F6A RID: 24426
		Two = 2,
		// Token: 0x04005F6B RID: 24427
		Three,
		// Token: 0x04005F6C RID: 24428
		Four
	}
}
