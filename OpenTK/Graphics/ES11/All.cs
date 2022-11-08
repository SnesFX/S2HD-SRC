using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A10 RID: 2576
	public enum All
	{
		// Token: 0x0400A44E RID: 42062
		False,
		// Token: 0x0400A44F RID: 42063
		LayoutDefaultIntel = 0,
		// Token: 0x0400A450 RID: 42064
		NoError = 0,
		// Token: 0x0400A451 RID: 42065
		None = 0,
		// Token: 0x0400A452 RID: 42066
		NoneOes = 0,
		// Token: 0x0400A453 RID: 42067
		Zero = 0,
		// Token: 0x0400A454 RID: 42068
		Points = 0,
		// Token: 0x0400A455 RID: 42069
		ClientPixelStoreBit,
		// Token: 0x0400A456 RID: 42070
		ColorBufferBit0Qcom = 1,
		// Token: 0x0400A457 RID: 42071
		ContextCoreProfileBit = 1,
		// Token: 0x0400A458 RID: 42072
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x0400A459 RID: 42073
		CurrentBit = 1,
		// Token: 0x0400A45A RID: 42074
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x0400A45B RID: 42075
		SyncFlushCommandsBitApple = 1,
		// Token: 0x0400A45C RID: 42076
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x0400A45D RID: 42077
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x0400A45E RID: 42078
		VertexShaderBit = 1,
		// Token: 0x0400A45F RID: 42079
		VertexShaderBitExt = 1,
		// Token: 0x0400A460 RID: 42080
		ClientVertexArrayBit,
		// Token: 0x0400A461 RID: 42081
		ColorBufferBit1Qcom = 2,
		// Token: 0x0400A462 RID: 42082
		ContextCompatibilityProfileBit = 2,
		// Token: 0x0400A463 RID: 42083
		ContextFlagDebugBit = 2,
		// Token: 0x0400A464 RID: 42084
		ContextFlagDebugBitKhr = 2,
		// Token: 0x0400A465 RID: 42085
		ElementArrayBarrierBit = 2,
		// Token: 0x0400A466 RID: 42086
		ElementArrayBarrierBitExt = 2,
		// Token: 0x0400A467 RID: 42087
		FragmentShaderBit = 2,
		// Token: 0x0400A468 RID: 42088
		FragmentShaderBitExt = 2,
		// Token: 0x0400A469 RID: 42089
		PointBit = 2,
		// Token: 0x0400A46A RID: 42090
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x0400A46B RID: 42091
		ColorBufferBit2Qcom = 4,
		// Token: 0x0400A46C RID: 42092
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x0400A46D RID: 42093
		GeometryShaderBit = 4,
		// Token: 0x0400A46E RID: 42094
		GeometryShaderBitExt = 4,
		// Token: 0x0400A46F RID: 42095
		LineBit = 4,
		// Token: 0x0400A470 RID: 42096
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x0400A471 RID: 42097
		UniformBarrierBit = 4,
		// Token: 0x0400A472 RID: 42098
		UniformBarrierBitExt = 4,
		// Token: 0x0400A473 RID: 42099
		ColorBufferBit3Qcom = 8,
		// Token: 0x0400A474 RID: 42100
		PolygonBit = 8,
		// Token: 0x0400A475 RID: 42101
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x0400A476 RID: 42102
		TessControlShaderBit = 8,
		// Token: 0x0400A477 RID: 42103
		TessControlShaderBitExt = 8,
		// Token: 0x0400A478 RID: 42104
		TextureFetchBarrierBit = 8,
		// Token: 0x0400A479 RID: 42105
		TextureFetchBarrierBitExt = 8,
		// Token: 0x0400A47A RID: 42106
		ColorBufferBit4Qcom = 16,
		// Token: 0x0400A47B RID: 42107
		PolygonStippleBit = 16,
		// Token: 0x0400A47C RID: 42108
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x0400A47D RID: 42109
		TessEvaluationShaderBit = 16,
		// Token: 0x0400A47E RID: 42110
		TessEvaluationShaderBitExt = 16,
		// Token: 0x0400A47F RID: 42111
		ColorBufferBit5Qcom = 32,
		// Token: 0x0400A480 RID: 42112
		ComputeShaderBit = 32,
		// Token: 0x0400A481 RID: 42113
		PixelModeBit = 32,
		// Token: 0x0400A482 RID: 42114
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x0400A483 RID: 42115
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x0400A484 RID: 42116
		ColorBufferBit6Qcom = 64,
		// Token: 0x0400A485 RID: 42117
		CommandBarrierBit = 64,
		// Token: 0x0400A486 RID: 42118
		CommandBarrierBitExt = 64,
		// Token: 0x0400A487 RID: 42119
		LightingBit = 64,
		// Token: 0x0400A488 RID: 42120
		ColorBufferBit7Qcom = 128,
		// Token: 0x0400A489 RID: 42121
		FogBit = 128,
		// Token: 0x0400A48A RID: 42122
		PixelBufferBarrierBit = 128,
		// Token: 0x0400A48B RID: 42123
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400A48C RID: 42124
		DepthBufferBit = 256,
		// Token: 0x0400A48D RID: 42125
		DepthBufferBit0Qcom = 256,
		// Token: 0x0400A48E RID: 42126
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400A48F RID: 42127
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400A490 RID: 42128
		AccumBufferBit = 512,
		// Token: 0x0400A491 RID: 42129
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400A492 RID: 42130
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x0400A493 RID: 42131
		DepthBufferBit1Qcom = 512,
		// Token: 0x0400A494 RID: 42132
		DepthBufferBit2Qcom = 1024,
		// Token: 0x0400A495 RID: 42133
		FramebufferBarrierBit = 1024,
		// Token: 0x0400A496 RID: 42134
		FramebufferBarrierBitExt = 1024,
		// Token: 0x0400A497 RID: 42135
		StencilBufferBit = 1024,
		// Token: 0x0400A498 RID: 42136
		DepthBufferBit3Qcom = 2048,
		// Token: 0x0400A499 RID: 42137
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400A49A RID: 42138
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x0400A49B RID: 42139
		ViewportBit = 2048,
		// Token: 0x0400A49C RID: 42140
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400A49D RID: 42141
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x0400A49E RID: 42142
		DepthBufferBit4Qcom = 4096,
		// Token: 0x0400A49F RID: 42143
		TransformBit = 4096,
		// Token: 0x0400A4A0 RID: 42144
		DepthBufferBit5Qcom = 8192,
		// Token: 0x0400A4A1 RID: 42145
		EnableBit = 8192,
		// Token: 0x0400A4A2 RID: 42146
		ShaderStorageBarrierBit = 8192,
		// Token: 0x0400A4A3 RID: 42147
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x0400A4A4 RID: 42148
		ColorBufferBit = 16384,
		// Token: 0x0400A4A5 RID: 42149
		DepthBufferBit6Qcom = 16384,
		// Token: 0x0400A4A6 RID: 42150
		CoverageBufferBitNv = 32768,
		// Token: 0x0400A4A7 RID: 42151
		DepthBufferBit7Qcom = 32768,
		// Token: 0x0400A4A8 RID: 42152
		HintBit = 32768,
		// Token: 0x0400A4A9 RID: 42153
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400A4AA RID: 42154
		MapReadBit = 1,
		// Token: 0x0400A4AB RID: 42155
		MapReadBitExt = 1,
		// Token: 0x0400A4AC RID: 42156
		Lines = 1,
		// Token: 0x0400A4AD RID: 42157
		EvalBit = 65536,
		// Token: 0x0400A4AE RID: 42158
		StencilBufferBit0Qcom = 65536,
		// Token: 0x0400A4AF RID: 42159
		LineLoop = 2,
		// Token: 0x0400A4B0 RID: 42160
		MapWriteBit = 2,
		// Token: 0x0400A4B1 RID: 42161
		MapWriteBitExt = 2,
		// Token: 0x0400A4B2 RID: 42162
		ListBit = 131072,
		// Token: 0x0400A4B3 RID: 42163
		StencilBufferBit1Qcom = 131072,
		// Token: 0x0400A4B4 RID: 42164
		LineStrip = 3,
		// Token: 0x0400A4B5 RID: 42165
		MapInvalidateRangeBit,
		// Token: 0x0400A4B6 RID: 42166
		MapInvalidateRangeBitExt = 4,
		// Token: 0x0400A4B7 RID: 42167
		Triangles = 4,
		// Token: 0x0400A4B8 RID: 42168
		StencilBufferBit2Qcom = 262144,
		// Token: 0x0400A4B9 RID: 42169
		TextureBit = 262144,
		// Token: 0x0400A4BA RID: 42170
		TriangleStrip = 5,
		// Token: 0x0400A4BB RID: 42171
		TriangleFan,
		// Token: 0x0400A4BC RID: 42172
		Quads,
		// Token: 0x0400A4BD RID: 42173
		QuadsExt = 7,
		// Token: 0x0400A4BE RID: 42174
		MapInvalidateBufferBit,
		// Token: 0x0400A4BF RID: 42175
		MapInvalidateBufferBitExt = 8,
		// Token: 0x0400A4C0 RID: 42176
		QuadStrip = 8,
		// Token: 0x0400A4C1 RID: 42177
		ScissorBit = 524288,
		// Token: 0x0400A4C2 RID: 42178
		StencilBufferBit3Qcom = 524288,
		// Token: 0x0400A4C3 RID: 42179
		Polygon = 9,
		// Token: 0x0400A4C4 RID: 42180
		LinesAdjacency,
		// Token: 0x0400A4C5 RID: 42181
		LinesAdjacencyArb = 10,
		// Token: 0x0400A4C6 RID: 42182
		LinesAdjacencyExt = 10,
		// Token: 0x0400A4C7 RID: 42183
		LineStripAdjacency,
		// Token: 0x0400A4C8 RID: 42184
		LineStripAdjacencyArb = 11,
		// Token: 0x0400A4C9 RID: 42185
		LineStripAdjacencyExt = 11,
		// Token: 0x0400A4CA RID: 42186
		TrianglesAdjacency,
		// Token: 0x0400A4CB RID: 42187
		TrianglesAdjacencyArb = 12,
		// Token: 0x0400A4CC RID: 42188
		TrianglesAdjacencyExt = 12,
		// Token: 0x0400A4CD RID: 42189
		TriangleStripAdjacency,
		// Token: 0x0400A4CE RID: 42190
		TriangleStripAdjacencyArb = 13,
		// Token: 0x0400A4CF RID: 42191
		TriangleStripAdjacencyExt = 13,
		// Token: 0x0400A4D0 RID: 42192
		Patches,
		// Token: 0x0400A4D1 RID: 42193
		PatchesExt = 14,
		// Token: 0x0400A4D2 RID: 42194
		MapFlushExplicitBit = 16,
		// Token: 0x0400A4D3 RID: 42195
		MapFlushExplicitBitExt = 16,
		// Token: 0x0400A4D4 RID: 42196
		StencilBufferBit4Qcom = 1048576,
		// Token: 0x0400A4D5 RID: 42197
		MapUnsynchronizedBit = 32,
		// Token: 0x0400A4D6 RID: 42198
		MapUnsynchronizedBitExt = 32,
		// Token: 0x0400A4D7 RID: 42199
		StencilBufferBit5Qcom = 2097152,
		// Token: 0x0400A4D8 RID: 42200
		MapPersistentBit = 64,
		// Token: 0x0400A4D9 RID: 42201
		StencilBufferBit6Qcom = 4194304,
		// Token: 0x0400A4DA RID: 42202
		MapCoherentBit = 128,
		// Token: 0x0400A4DB RID: 42203
		StencilBufferBit7Qcom = 8388608,
		// Token: 0x0400A4DC RID: 42204
		Accum = 256,
		// Token: 0x0400A4DD RID: 42205
		DynamicStorageBit = 256,
		// Token: 0x0400A4DE RID: 42206
		MultisampleBufferBit0Qcom = 16777216,
		// Token: 0x0400A4DF RID: 42207
		Load = 257,
		// Token: 0x0400A4E0 RID: 42208
		Return,
		// Token: 0x0400A4E1 RID: 42209
		Mult,
		// Token: 0x0400A4E2 RID: 42210
		Add,
		// Token: 0x0400A4E3 RID: 42211
		ClientStorageBit = 512,
		// Token: 0x0400A4E4 RID: 42212
		Never = 512,
		// Token: 0x0400A4E5 RID: 42213
		MultisampleBufferBit1Qcom = 33554432,
		// Token: 0x0400A4E6 RID: 42214
		Less = 513,
		// Token: 0x0400A4E7 RID: 42215
		Equal,
		// Token: 0x0400A4E8 RID: 42216
		Lequal,
		// Token: 0x0400A4E9 RID: 42217
		Greater,
		// Token: 0x0400A4EA RID: 42218
		Notequal,
		// Token: 0x0400A4EB RID: 42219
		Gequal,
		// Token: 0x0400A4EC RID: 42220
		Always,
		// Token: 0x0400A4ED RID: 42221
		SrcColor = 768,
		// Token: 0x0400A4EE RID: 42222
		OneMinusSrcColor,
		// Token: 0x0400A4EF RID: 42223
		SrcAlpha,
		// Token: 0x0400A4F0 RID: 42224
		OneMinusSrcAlpha,
		// Token: 0x0400A4F1 RID: 42225
		DstAlpha,
		// Token: 0x0400A4F2 RID: 42226
		OneMinusDstAlpha,
		// Token: 0x0400A4F3 RID: 42227
		DstColor,
		// Token: 0x0400A4F4 RID: 42228
		OneMinusDstColor,
		// Token: 0x0400A4F5 RID: 42229
		SrcAlphaSaturate,
		// Token: 0x0400A4F6 RID: 42230
		FrontLeft = 1024,
		// Token: 0x0400A4F7 RID: 42231
		MultisampleBufferBit2Qcom = 67108864,
		// Token: 0x0400A4F8 RID: 42232
		FrontRight = 1025,
		// Token: 0x0400A4F9 RID: 42233
		BackLeft,
		// Token: 0x0400A4FA RID: 42234
		BackRight,
		// Token: 0x0400A4FB RID: 42235
		Front,
		// Token: 0x0400A4FC RID: 42236
		Back,
		// Token: 0x0400A4FD RID: 42237
		Left,
		// Token: 0x0400A4FE RID: 42238
		Right,
		// Token: 0x0400A4FF RID: 42239
		FrontAndBack,
		// Token: 0x0400A500 RID: 42240
		Aux0,
		// Token: 0x0400A501 RID: 42241
		Aux1,
		// Token: 0x0400A502 RID: 42242
		Aux2,
		// Token: 0x0400A503 RID: 42243
		Aux3,
		// Token: 0x0400A504 RID: 42244
		InvalidEnum = 1280,
		// Token: 0x0400A505 RID: 42245
		InvalidValue,
		// Token: 0x0400A506 RID: 42246
		InvalidOperation,
		// Token: 0x0400A507 RID: 42247
		StackOverflow,
		// Token: 0x0400A508 RID: 42248
		StackUnderflow,
		// Token: 0x0400A509 RID: 42249
		OutOfMemory,
		// Token: 0x0400A50A RID: 42250
		InvalidFramebufferOperation,
		// Token: 0x0400A50B RID: 42251
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x0400A50C RID: 42252
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x0400A50D RID: 42253
		Gl2D = 1536,
		// Token: 0x0400A50E RID: 42254
		Gl3D,
		// Token: 0x0400A50F RID: 42255
		Gl3DColor,
		// Token: 0x0400A510 RID: 42256
		Gl3DColorTexture,
		// Token: 0x0400A511 RID: 42257
		Gl4DColorTexture,
		// Token: 0x0400A512 RID: 42258
		PassThroughToken = 1792,
		// Token: 0x0400A513 RID: 42259
		PointToken,
		// Token: 0x0400A514 RID: 42260
		LineToken,
		// Token: 0x0400A515 RID: 42261
		PolygonToken,
		// Token: 0x0400A516 RID: 42262
		BitmapToken,
		// Token: 0x0400A517 RID: 42263
		DrawPixelToken,
		// Token: 0x0400A518 RID: 42264
		CopyPixelToken,
		// Token: 0x0400A519 RID: 42265
		LineResetToken,
		// Token: 0x0400A51A RID: 42266
		Exp = 2048,
		// Token: 0x0400A51B RID: 42267
		MultisampleBufferBit3Qcom = 134217728,
		// Token: 0x0400A51C RID: 42268
		Exp2 = 2049,
		// Token: 0x0400A51D RID: 42269
		Cw = 2304,
		// Token: 0x0400A51E RID: 42270
		Ccw,
		// Token: 0x0400A51F RID: 42271
		Coeff = 2560,
		// Token: 0x0400A520 RID: 42272
		Order,
		// Token: 0x0400A521 RID: 42273
		Domain,
		// Token: 0x0400A522 RID: 42274
		CurrentColor = 2816,
		// Token: 0x0400A523 RID: 42275
		CurrentIndex,
		// Token: 0x0400A524 RID: 42276
		CurrentNormal,
		// Token: 0x0400A525 RID: 42277
		CurrentTextureCoords,
		// Token: 0x0400A526 RID: 42278
		CurrentRasterColor,
		// Token: 0x0400A527 RID: 42279
		CurrentRasterIndex,
		// Token: 0x0400A528 RID: 42280
		CurrentRasterTextureCoords,
		// Token: 0x0400A529 RID: 42281
		CurrentRasterPosition,
		// Token: 0x0400A52A RID: 42282
		CurrentRasterPositionValid,
		// Token: 0x0400A52B RID: 42283
		CurrentRasterDistance,
		// Token: 0x0400A52C RID: 42284
		PointSmooth = 2832,
		// Token: 0x0400A52D RID: 42285
		PointSize,
		// Token: 0x0400A52E RID: 42286
		PointSizeRange,
		// Token: 0x0400A52F RID: 42287
		SmoothPointSizeRange = 2834,
		// Token: 0x0400A530 RID: 42288
		PointSizeGranularity,
		// Token: 0x0400A531 RID: 42289
		SmoothPointSizeGranularity = 2835,
		// Token: 0x0400A532 RID: 42290
		LineSmooth = 2848,
		// Token: 0x0400A533 RID: 42291
		LineWidth,
		// Token: 0x0400A534 RID: 42292
		LineWidthRange,
		// Token: 0x0400A535 RID: 42293
		SmoothLineWidthRange = 2850,
		// Token: 0x0400A536 RID: 42294
		LineWidthGranularity,
		// Token: 0x0400A537 RID: 42295
		SmoothLineWidthGranularity = 2851,
		// Token: 0x0400A538 RID: 42296
		LineStipple,
		// Token: 0x0400A539 RID: 42297
		LineStipplePattern,
		// Token: 0x0400A53A RID: 42298
		LineStippleRepeat,
		// Token: 0x0400A53B RID: 42299
		ListMode = 2864,
		// Token: 0x0400A53C RID: 42300
		MaxListNesting,
		// Token: 0x0400A53D RID: 42301
		ListBase,
		// Token: 0x0400A53E RID: 42302
		ListIndex,
		// Token: 0x0400A53F RID: 42303
		PolygonMode = 2880,
		// Token: 0x0400A540 RID: 42304
		PolygonSmooth,
		// Token: 0x0400A541 RID: 42305
		PolygonStipple,
		// Token: 0x0400A542 RID: 42306
		EdgeFlag,
		// Token: 0x0400A543 RID: 42307
		CullFace,
		// Token: 0x0400A544 RID: 42308
		CullFaceMode,
		// Token: 0x0400A545 RID: 42309
		FrontFace,
		// Token: 0x0400A546 RID: 42310
		Lighting = 2896,
		// Token: 0x0400A547 RID: 42311
		LightModelLocalViewer,
		// Token: 0x0400A548 RID: 42312
		LightModelTwoSide,
		// Token: 0x0400A549 RID: 42313
		LightModelAmbient,
		// Token: 0x0400A54A RID: 42314
		ShadeModel,
		// Token: 0x0400A54B RID: 42315
		ColorMaterialFace,
		// Token: 0x0400A54C RID: 42316
		ColorMaterialParameter,
		// Token: 0x0400A54D RID: 42317
		ColorMaterial,
		// Token: 0x0400A54E RID: 42318
		Fog = 2912,
		// Token: 0x0400A54F RID: 42319
		FogIndex,
		// Token: 0x0400A550 RID: 42320
		FogDensity,
		// Token: 0x0400A551 RID: 42321
		FogStart,
		// Token: 0x0400A552 RID: 42322
		FogEnd,
		// Token: 0x0400A553 RID: 42323
		FogMode,
		// Token: 0x0400A554 RID: 42324
		FogColor,
		// Token: 0x0400A555 RID: 42325
		DepthRange = 2928,
		// Token: 0x0400A556 RID: 42326
		DepthTest,
		// Token: 0x0400A557 RID: 42327
		DepthWritemask,
		// Token: 0x0400A558 RID: 42328
		DepthClearValue,
		// Token: 0x0400A559 RID: 42329
		DepthFunc,
		// Token: 0x0400A55A RID: 42330
		AccumClearValue = 2944,
		// Token: 0x0400A55B RID: 42331
		StencilTest = 2960,
		// Token: 0x0400A55C RID: 42332
		StencilClearValue,
		// Token: 0x0400A55D RID: 42333
		StencilFunc,
		// Token: 0x0400A55E RID: 42334
		StencilValueMask,
		// Token: 0x0400A55F RID: 42335
		StencilFail,
		// Token: 0x0400A560 RID: 42336
		StencilPassDepthFail,
		// Token: 0x0400A561 RID: 42337
		StencilPassDepthPass,
		// Token: 0x0400A562 RID: 42338
		StencilRef,
		// Token: 0x0400A563 RID: 42339
		StencilWritemask,
		// Token: 0x0400A564 RID: 42340
		MatrixMode = 2976,
		// Token: 0x0400A565 RID: 42341
		Normalize,
		// Token: 0x0400A566 RID: 42342
		Viewport,
		// Token: 0x0400A567 RID: 42343
		Modelview0StackDepthExt,
		// Token: 0x0400A568 RID: 42344
		ModelviewStackDepth = 2979,
		// Token: 0x0400A569 RID: 42345
		ProjectionStackDepth,
		// Token: 0x0400A56A RID: 42346
		TextureStackDepth,
		// Token: 0x0400A56B RID: 42347
		Modelview0MatrixExt,
		// Token: 0x0400A56C RID: 42348
		ModelviewMatrix = 2982,
		// Token: 0x0400A56D RID: 42349
		ProjectionMatrix,
		// Token: 0x0400A56E RID: 42350
		TextureMatrix,
		// Token: 0x0400A56F RID: 42351
		AttribStackDepth = 2992,
		// Token: 0x0400A570 RID: 42352
		ClientAttribStackDepth,
		// Token: 0x0400A571 RID: 42353
		AlphaTest = 3008,
		// Token: 0x0400A572 RID: 42354
		AlphaTestQcom = 3008,
		// Token: 0x0400A573 RID: 42355
		AlphaTestFunc,
		// Token: 0x0400A574 RID: 42356
		AlphaTestFuncQcom = 3009,
		// Token: 0x0400A575 RID: 42357
		AlphaTestRef,
		// Token: 0x0400A576 RID: 42358
		AlphaTestRefQcom = 3010,
		// Token: 0x0400A577 RID: 42359
		Dither = 3024,
		// Token: 0x0400A578 RID: 42360
		BlendDst = 3040,
		// Token: 0x0400A579 RID: 42361
		BlendSrc,
		// Token: 0x0400A57A RID: 42362
		Blend,
		// Token: 0x0400A57B RID: 42363
		LogicOpMode = 3056,
		// Token: 0x0400A57C RID: 42364
		IndexLogicOp,
		// Token: 0x0400A57D RID: 42365
		LogicOp = 3057,
		// Token: 0x0400A57E RID: 42366
		ColorLogicOp,
		// Token: 0x0400A57F RID: 42367
		AuxBuffers = 3072,
		// Token: 0x0400A580 RID: 42368
		DrawBuffer,
		// Token: 0x0400A581 RID: 42369
		DrawBufferExt = 3073,
		// Token: 0x0400A582 RID: 42370
		ReadBuffer,
		// Token: 0x0400A583 RID: 42371
		ReadBufferExt = 3074,
		// Token: 0x0400A584 RID: 42372
		ReadBufferNv = 3074,
		// Token: 0x0400A585 RID: 42373
		ScissorBox = 3088,
		// Token: 0x0400A586 RID: 42374
		ScissorTest,
		// Token: 0x0400A587 RID: 42375
		IndexClearValue = 3104,
		// Token: 0x0400A588 RID: 42376
		IndexWritemask,
		// Token: 0x0400A589 RID: 42377
		ColorClearValue,
		// Token: 0x0400A58A RID: 42378
		ColorWritemask,
		// Token: 0x0400A58B RID: 42379
		IndexMode = 3120,
		// Token: 0x0400A58C RID: 42380
		RgbaMode,
		// Token: 0x0400A58D RID: 42381
		Doublebuffer,
		// Token: 0x0400A58E RID: 42382
		Stereo,
		// Token: 0x0400A58F RID: 42383
		RenderMode = 3136,
		// Token: 0x0400A590 RID: 42384
		PerspectiveCorrectionHint = 3152,
		// Token: 0x0400A591 RID: 42385
		PointSmoothHint,
		// Token: 0x0400A592 RID: 42386
		LineSmoothHint,
		// Token: 0x0400A593 RID: 42387
		PolygonSmoothHint,
		// Token: 0x0400A594 RID: 42388
		FogHint,
		// Token: 0x0400A595 RID: 42389
		TextureGenS = 3168,
		// Token: 0x0400A596 RID: 42390
		TextureGenT,
		// Token: 0x0400A597 RID: 42391
		TextureGenR,
		// Token: 0x0400A598 RID: 42392
		TextureGenQ,
		// Token: 0x0400A599 RID: 42393
		PixelMapIToI = 3184,
		// Token: 0x0400A59A RID: 42394
		PixelMapSToS,
		// Token: 0x0400A59B RID: 42395
		PixelMapIToR,
		// Token: 0x0400A59C RID: 42396
		PixelMapIToG,
		// Token: 0x0400A59D RID: 42397
		PixelMapIToB,
		// Token: 0x0400A59E RID: 42398
		PixelMapIToA,
		// Token: 0x0400A59F RID: 42399
		PixelMapRToR,
		// Token: 0x0400A5A0 RID: 42400
		PixelMapGToG,
		// Token: 0x0400A5A1 RID: 42401
		PixelMapBToB,
		// Token: 0x0400A5A2 RID: 42402
		PixelMapAToA,
		// Token: 0x0400A5A3 RID: 42403
		PixelMapIToISize = 3248,
		// Token: 0x0400A5A4 RID: 42404
		PixelMapSToSSize,
		// Token: 0x0400A5A5 RID: 42405
		PixelMapIToRSize,
		// Token: 0x0400A5A6 RID: 42406
		PixelMapIToGSize,
		// Token: 0x0400A5A7 RID: 42407
		PixelMapIToBSize,
		// Token: 0x0400A5A8 RID: 42408
		PixelMapIToASize,
		// Token: 0x0400A5A9 RID: 42409
		PixelMapRToRSize,
		// Token: 0x0400A5AA RID: 42410
		PixelMapGToGSize,
		// Token: 0x0400A5AB RID: 42411
		PixelMapBToBSize,
		// Token: 0x0400A5AC RID: 42412
		PixelMapAToASize,
		// Token: 0x0400A5AD RID: 42413
		UnpackSwapBytes = 3312,
		// Token: 0x0400A5AE RID: 42414
		UnpackLsbFirst,
		// Token: 0x0400A5AF RID: 42415
		UnpackRowLength,
		// Token: 0x0400A5B0 RID: 42416
		UnpackRowLengthExt = 3314,
		// Token: 0x0400A5B1 RID: 42417
		UnpackSkipRows,
		// Token: 0x0400A5B2 RID: 42418
		UnpackSkipRowsExt = 3315,
		// Token: 0x0400A5B3 RID: 42419
		UnpackSkipPixels,
		// Token: 0x0400A5B4 RID: 42420
		UnpackSkipPixelsExt = 3316,
		// Token: 0x0400A5B5 RID: 42421
		UnpackAlignment,
		// Token: 0x0400A5B6 RID: 42422
		PackSwapBytes = 3328,
		// Token: 0x0400A5B7 RID: 42423
		PackLsbFirst,
		// Token: 0x0400A5B8 RID: 42424
		PackRowLength,
		// Token: 0x0400A5B9 RID: 42425
		PackSkipRows,
		// Token: 0x0400A5BA RID: 42426
		PackSkipPixels,
		// Token: 0x0400A5BB RID: 42427
		PackAlignment,
		// Token: 0x0400A5BC RID: 42428
		MapColor = 3344,
		// Token: 0x0400A5BD RID: 42429
		MapStencil,
		// Token: 0x0400A5BE RID: 42430
		IndexShift,
		// Token: 0x0400A5BF RID: 42431
		IndexOffset,
		// Token: 0x0400A5C0 RID: 42432
		RedScale,
		// Token: 0x0400A5C1 RID: 42433
		RedBias,
		// Token: 0x0400A5C2 RID: 42434
		ZoomX,
		// Token: 0x0400A5C3 RID: 42435
		ZoomY,
		// Token: 0x0400A5C4 RID: 42436
		GreenScale,
		// Token: 0x0400A5C5 RID: 42437
		GreenBias,
		// Token: 0x0400A5C6 RID: 42438
		BlueScale,
		// Token: 0x0400A5C7 RID: 42439
		BlueBias,
		// Token: 0x0400A5C8 RID: 42440
		AlphaScale,
		// Token: 0x0400A5C9 RID: 42441
		AlphaBias,
		// Token: 0x0400A5CA RID: 42442
		DepthScale,
		// Token: 0x0400A5CB RID: 42443
		DepthBias,
		// Token: 0x0400A5CC RID: 42444
		MaxEvalOrder = 3376,
		// Token: 0x0400A5CD RID: 42445
		MaxLights,
		// Token: 0x0400A5CE RID: 42446
		MaxClipDistances,
		// Token: 0x0400A5CF RID: 42447
		MaxClipPlanes = 3378,
		// Token: 0x0400A5D0 RID: 42448
		MaxClipPlanesImg = 3378,
		// Token: 0x0400A5D1 RID: 42449
		MaxTextureSize,
		// Token: 0x0400A5D2 RID: 42450
		MaxPixelMapTable,
		// Token: 0x0400A5D3 RID: 42451
		MaxAttribStackDepth,
		// Token: 0x0400A5D4 RID: 42452
		MaxModelviewStackDepth,
		// Token: 0x0400A5D5 RID: 42453
		MaxNameStackDepth,
		// Token: 0x0400A5D6 RID: 42454
		MaxProjectionStackDepth,
		// Token: 0x0400A5D7 RID: 42455
		MaxTextureStackDepth,
		// Token: 0x0400A5D8 RID: 42456
		MaxViewportDims,
		// Token: 0x0400A5D9 RID: 42457
		MaxClientAttribStackDepth,
		// Token: 0x0400A5DA RID: 42458
		SubpixelBits = 3408,
		// Token: 0x0400A5DB RID: 42459
		IndexBits,
		// Token: 0x0400A5DC RID: 42460
		RedBits,
		// Token: 0x0400A5DD RID: 42461
		GreenBits,
		// Token: 0x0400A5DE RID: 42462
		BlueBits,
		// Token: 0x0400A5DF RID: 42463
		AlphaBits,
		// Token: 0x0400A5E0 RID: 42464
		DepthBits,
		// Token: 0x0400A5E1 RID: 42465
		StencilBits,
		// Token: 0x0400A5E2 RID: 42466
		AccumRedBits,
		// Token: 0x0400A5E3 RID: 42467
		AccumGreenBits,
		// Token: 0x0400A5E4 RID: 42468
		AccumBlueBits,
		// Token: 0x0400A5E5 RID: 42469
		AccumAlphaBits,
		// Token: 0x0400A5E6 RID: 42470
		NameStackDepth = 3440,
		// Token: 0x0400A5E7 RID: 42471
		AutoNormal = 3456,
		// Token: 0x0400A5E8 RID: 42472
		Map1Color4 = 3472,
		// Token: 0x0400A5E9 RID: 42473
		Map1Index,
		// Token: 0x0400A5EA RID: 42474
		Map1Normal,
		// Token: 0x0400A5EB RID: 42475
		Map1TextureCoord1,
		// Token: 0x0400A5EC RID: 42476
		Map1TextureCoord2,
		// Token: 0x0400A5ED RID: 42477
		Map1TextureCoord3,
		// Token: 0x0400A5EE RID: 42478
		Map1TextureCoord4,
		// Token: 0x0400A5EF RID: 42479
		Map1Vertex3,
		// Token: 0x0400A5F0 RID: 42480
		Map1Vertex4,
		// Token: 0x0400A5F1 RID: 42481
		Map2Color4 = 3504,
		// Token: 0x0400A5F2 RID: 42482
		Map2Index,
		// Token: 0x0400A5F3 RID: 42483
		Map2Normal,
		// Token: 0x0400A5F4 RID: 42484
		Map2TextureCoord1,
		// Token: 0x0400A5F5 RID: 42485
		Map2TextureCoord2,
		// Token: 0x0400A5F6 RID: 42486
		Map2TextureCoord3,
		// Token: 0x0400A5F7 RID: 42487
		Map2TextureCoord4,
		// Token: 0x0400A5F8 RID: 42488
		Map2Vertex3,
		// Token: 0x0400A5F9 RID: 42489
		Map2Vertex4,
		// Token: 0x0400A5FA RID: 42490
		Map1GridDomain = 3536,
		// Token: 0x0400A5FB RID: 42491
		Map1GridSegments,
		// Token: 0x0400A5FC RID: 42492
		Map2GridDomain,
		// Token: 0x0400A5FD RID: 42493
		Map2GridSegments,
		// Token: 0x0400A5FE RID: 42494
		Texture1D = 3552,
		// Token: 0x0400A5FF RID: 42495
		Texture2D,
		// Token: 0x0400A600 RID: 42496
		FeedbackBufferPointer = 3568,
		// Token: 0x0400A601 RID: 42497
		FeedbackBufferSize,
		// Token: 0x0400A602 RID: 42498
		FeedbackBufferType,
		// Token: 0x0400A603 RID: 42499
		SelectionBufferPointer,
		// Token: 0x0400A604 RID: 42500
		SelectionBufferSize,
		// Token: 0x0400A605 RID: 42501
		TextureWidth = 4096,
		// Token: 0x0400A606 RID: 42502
		MultisampleBufferBit4Qcom = 268435456,
		// Token: 0x0400A607 RID: 42503
		TextureHeight = 4097,
		// Token: 0x0400A608 RID: 42504
		TextureComponents = 4099,
		// Token: 0x0400A609 RID: 42505
		TextureInternalFormat = 4099,
		// Token: 0x0400A60A RID: 42506
		TextureBorderColor,
		// Token: 0x0400A60B RID: 42507
		TextureBorderColorNv = 4100,
		// Token: 0x0400A60C RID: 42508
		TextureBorder,
		// Token: 0x0400A60D RID: 42509
		DontCare = 4352,
		// Token: 0x0400A60E RID: 42510
		Fastest,
		// Token: 0x0400A60F RID: 42511
		Nicest,
		// Token: 0x0400A610 RID: 42512
		Ambient = 4608,
		// Token: 0x0400A611 RID: 42513
		Diffuse,
		// Token: 0x0400A612 RID: 42514
		Specular,
		// Token: 0x0400A613 RID: 42515
		Position,
		// Token: 0x0400A614 RID: 42516
		SpotDirection,
		// Token: 0x0400A615 RID: 42517
		SpotExponent,
		// Token: 0x0400A616 RID: 42518
		SpotCutoff,
		// Token: 0x0400A617 RID: 42519
		ConstantAttenuation,
		// Token: 0x0400A618 RID: 42520
		LinearAttenuation,
		// Token: 0x0400A619 RID: 42521
		QuadraticAttenuation,
		// Token: 0x0400A61A RID: 42522
		Compile = 4864,
		// Token: 0x0400A61B RID: 42523
		CompileAndExecute,
		// Token: 0x0400A61C RID: 42524
		Byte = 5120,
		// Token: 0x0400A61D RID: 42525
		UnsignedByte,
		// Token: 0x0400A61E RID: 42526
		Short,
		// Token: 0x0400A61F RID: 42527
		UnsignedShort,
		// Token: 0x0400A620 RID: 42528
		Int,
		// Token: 0x0400A621 RID: 42529
		UnsignedInt,
		// Token: 0x0400A622 RID: 42530
		Float,
		// Token: 0x0400A623 RID: 42531
		Gl2Bytes,
		// Token: 0x0400A624 RID: 42532
		Gl3Bytes,
		// Token: 0x0400A625 RID: 42533
		Gl4Bytes,
		// Token: 0x0400A626 RID: 42534
		Double,
		// Token: 0x0400A627 RID: 42535
		Fixed = 5132,
		// Token: 0x0400A628 RID: 42536
		FixedOes = 5132,
		// Token: 0x0400A629 RID: 42537
		Clear = 5376,
		// Token: 0x0400A62A RID: 42538
		And,
		// Token: 0x0400A62B RID: 42539
		AndReverse,
		// Token: 0x0400A62C RID: 42540
		Copy,
		// Token: 0x0400A62D RID: 42541
		AndInverted,
		// Token: 0x0400A62E RID: 42542
		Noop,
		// Token: 0x0400A62F RID: 42543
		Xor,
		// Token: 0x0400A630 RID: 42544
		Or,
		// Token: 0x0400A631 RID: 42545
		Nor,
		// Token: 0x0400A632 RID: 42546
		Equiv,
		// Token: 0x0400A633 RID: 42547
		Invert,
		// Token: 0x0400A634 RID: 42548
		OrReverse,
		// Token: 0x0400A635 RID: 42549
		CopyInverted,
		// Token: 0x0400A636 RID: 42550
		OrInverted,
		// Token: 0x0400A637 RID: 42551
		Nand,
		// Token: 0x0400A638 RID: 42552
		Set,
		// Token: 0x0400A639 RID: 42553
		Emission = 5632,
		// Token: 0x0400A63A RID: 42554
		Shininess,
		// Token: 0x0400A63B RID: 42555
		AmbientAndDiffuse,
		// Token: 0x0400A63C RID: 42556
		ColorIndexes,
		// Token: 0x0400A63D RID: 42557
		Modelview = 5888,
		// Token: 0x0400A63E RID: 42558
		Modelview0Ext = 5888,
		// Token: 0x0400A63F RID: 42559
		Projection,
		// Token: 0x0400A640 RID: 42560
		Texture,
		// Token: 0x0400A641 RID: 42561
		Color = 6144,
		// Token: 0x0400A642 RID: 42562
		ColorExt = 6144,
		// Token: 0x0400A643 RID: 42563
		Depth,
		// Token: 0x0400A644 RID: 42564
		DepthExt = 6145,
		// Token: 0x0400A645 RID: 42565
		Stencil,
		// Token: 0x0400A646 RID: 42566
		StencilExt = 6146,
		// Token: 0x0400A647 RID: 42567
		ColorIndex = 6400,
		// Token: 0x0400A648 RID: 42568
		StencilIndex,
		// Token: 0x0400A649 RID: 42569
		DepthComponent,
		// Token: 0x0400A64A RID: 42570
		Red,
		// Token: 0x0400A64B RID: 42571
		RedExt = 6403,
		// Token: 0x0400A64C RID: 42572
		Green,
		// Token: 0x0400A64D RID: 42573
		Blue,
		// Token: 0x0400A64E RID: 42574
		Alpha,
		// Token: 0x0400A64F RID: 42575
		Rgb,
		// Token: 0x0400A650 RID: 42576
		Rgba,
		// Token: 0x0400A651 RID: 42577
		Luminance,
		// Token: 0x0400A652 RID: 42578
		LuminanceAlpha,
		// Token: 0x0400A653 RID: 42579
		Bitmap = 6656,
		// Token: 0x0400A654 RID: 42580
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x0400A655 RID: 42581
		ConserveMemoryHintPgi = 107005,
		// Token: 0x0400A656 RID: 42582
		ReclaimMemoryHintPgi,
		// Token: 0x0400A657 RID: 42583
		NativeGraphicsBeginHintPgi = 107011,
		// Token: 0x0400A658 RID: 42584
		NativeGraphicsEndHintPgi,
		// Token: 0x0400A659 RID: 42585
		AlwaysFastHintPgi = 107020,
		// Token: 0x0400A65A RID: 42586
		AlwaysSoftHintPgi,
		// Token: 0x0400A65B RID: 42587
		AllowDrawObjHintPgi,
		// Token: 0x0400A65C RID: 42588
		AllowDrawWinHintPgi,
		// Token: 0x0400A65D RID: 42589
		AllowDrawFrgHintPgi,
		// Token: 0x0400A65E RID: 42590
		AllowDrawMemHintPgi,
		// Token: 0x0400A65F RID: 42591
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x0400A660 RID: 42592
		StrictLightingHintPgi,
		// Token: 0x0400A661 RID: 42593
		StrictScissorHintPgi,
		// Token: 0x0400A662 RID: 42594
		FullStippleHintPgi,
		// Token: 0x0400A663 RID: 42595
		ClipNearHintPgi = 107040,
		// Token: 0x0400A664 RID: 42596
		ClipFarHintPgi,
		// Token: 0x0400A665 RID: 42597
		WideLineHintPgi,
		// Token: 0x0400A666 RID: 42598
		BackNormalsHintPgi,
		// Token: 0x0400A667 RID: 42599
		VertexDataHintPgi = 107050,
		// Token: 0x0400A668 RID: 42600
		VertexConsistentHintPgi,
		// Token: 0x0400A669 RID: 42601
		MaterialSideHintPgi,
		// Token: 0x0400A66A RID: 42602
		MaxVertexHintPgi,
		// Token: 0x0400A66B RID: 42603
		Point = 6912,
		// Token: 0x0400A66C RID: 42604
		Line,
		// Token: 0x0400A66D RID: 42605
		Fill,
		// Token: 0x0400A66E RID: 42606
		Render = 7168,
		// Token: 0x0400A66F RID: 42607
		Feedback,
		// Token: 0x0400A670 RID: 42608
		Select,
		// Token: 0x0400A671 RID: 42609
		Flat = 7424,
		// Token: 0x0400A672 RID: 42610
		Smooth,
		// Token: 0x0400A673 RID: 42611
		Keep = 7680,
		// Token: 0x0400A674 RID: 42612
		Replace,
		// Token: 0x0400A675 RID: 42613
		Incr,
		// Token: 0x0400A676 RID: 42614
		Decr,
		// Token: 0x0400A677 RID: 42615
		Vendor = 7936,
		// Token: 0x0400A678 RID: 42616
		Renderer,
		// Token: 0x0400A679 RID: 42617
		Version,
		// Token: 0x0400A67A RID: 42618
		Extensions,
		// Token: 0x0400A67B RID: 42619
		S = 8192,
		// Token: 0x0400A67C RID: 42620
		MultisampleBit = 536870912,
		// Token: 0x0400A67D RID: 42621
		MultisampleBit3Dfx = 536870912,
		// Token: 0x0400A67E RID: 42622
		MultisampleBitArb = 536870912,
		// Token: 0x0400A67F RID: 42623
		MultisampleBitExt = 536870912,
		// Token: 0x0400A680 RID: 42624
		MultisampleBufferBit5Qcom = 536870912,
		// Token: 0x0400A681 RID: 42625
		T = 8193,
		// Token: 0x0400A682 RID: 42626
		R,
		// Token: 0x0400A683 RID: 42627
		Q,
		// Token: 0x0400A684 RID: 42628
		Modulate = 8448,
		// Token: 0x0400A685 RID: 42629
		Decal,
		// Token: 0x0400A686 RID: 42630
		TextureEnvMode = 8704,
		// Token: 0x0400A687 RID: 42631
		TextureEnvColor,
		// Token: 0x0400A688 RID: 42632
		TextureEnv = 8960,
		// Token: 0x0400A689 RID: 42633
		EyeLinear = 9216,
		// Token: 0x0400A68A RID: 42634
		ObjectLinear,
		// Token: 0x0400A68B RID: 42635
		SphereMap,
		// Token: 0x0400A68C RID: 42636
		TextureGenMode = 9472,
		// Token: 0x0400A68D RID: 42637
		TextureGenModeOes = 9472,
		// Token: 0x0400A68E RID: 42638
		ObjectPlane,
		// Token: 0x0400A68F RID: 42639
		EyePlane,
		// Token: 0x0400A690 RID: 42640
		Nearest = 9728,
		// Token: 0x0400A691 RID: 42641
		Linear,
		// Token: 0x0400A692 RID: 42642
		NearestMipmapNearest = 9984,
		// Token: 0x0400A693 RID: 42643
		LinearMipmapNearest,
		// Token: 0x0400A694 RID: 42644
		NearestMipmapLinear,
		// Token: 0x0400A695 RID: 42645
		LinearMipmapLinear,
		// Token: 0x0400A696 RID: 42646
		TextureMagFilter = 10240,
		// Token: 0x0400A697 RID: 42647
		TextureMinFilter,
		// Token: 0x0400A698 RID: 42648
		TextureWrapS,
		// Token: 0x0400A699 RID: 42649
		TextureWrapT,
		// Token: 0x0400A69A RID: 42650
		Clamp = 10496,
		// Token: 0x0400A69B RID: 42651
		Repeat,
		// Token: 0x0400A69C RID: 42652
		PolygonOffsetUnits = 10752,
		// Token: 0x0400A69D RID: 42653
		PolygonOffsetPoint,
		// Token: 0x0400A69E RID: 42654
		PolygonOffsetLine,
		// Token: 0x0400A69F RID: 42655
		R3G3B2 = 10768,
		// Token: 0x0400A6A0 RID: 42656
		V2f = 10784,
		// Token: 0x0400A6A1 RID: 42657
		V3f,
		// Token: 0x0400A6A2 RID: 42658
		C4ubV2f,
		// Token: 0x0400A6A3 RID: 42659
		C4ubV3f,
		// Token: 0x0400A6A4 RID: 42660
		C3fV3f,
		// Token: 0x0400A6A5 RID: 42661
		N3fV3f,
		// Token: 0x0400A6A6 RID: 42662
		C4fN3fV3f,
		// Token: 0x0400A6A7 RID: 42663
		T2fV3f,
		// Token: 0x0400A6A8 RID: 42664
		T4fV4f,
		// Token: 0x0400A6A9 RID: 42665
		T2fC4ubV3f,
		// Token: 0x0400A6AA RID: 42666
		T2fC3fV3f,
		// Token: 0x0400A6AB RID: 42667
		T2fN3fV3f,
		// Token: 0x0400A6AC RID: 42668
		T2fC4fN3fV3f,
		// Token: 0x0400A6AD RID: 42669
		T4fC4fN3fV4f,
		// Token: 0x0400A6AE RID: 42670
		ClipDistance0 = 12288,
		// Token: 0x0400A6AF RID: 42671
		ClipPlane0 = 12288,
		// Token: 0x0400A6B0 RID: 42672
		ClipPlane0Img = 12288,
		// Token: 0x0400A6B1 RID: 42673
		ClipDistance1,
		// Token: 0x0400A6B2 RID: 42674
		ClipPlane1 = 12289,
		// Token: 0x0400A6B3 RID: 42675
		ClipPlane1Img = 12289,
		// Token: 0x0400A6B4 RID: 42676
		ClipDistance2,
		// Token: 0x0400A6B5 RID: 42677
		ClipPlane2 = 12290,
		// Token: 0x0400A6B6 RID: 42678
		ClipPlane2Img = 12290,
		// Token: 0x0400A6B7 RID: 42679
		ClipDistance3,
		// Token: 0x0400A6B8 RID: 42680
		ClipPlane3 = 12291,
		// Token: 0x0400A6B9 RID: 42681
		ClipPlane3Img = 12291,
		// Token: 0x0400A6BA RID: 42682
		ClipDistance4,
		// Token: 0x0400A6BB RID: 42683
		ClipPlane4 = 12292,
		// Token: 0x0400A6BC RID: 42684
		ClipPlane4Img = 12292,
		// Token: 0x0400A6BD RID: 42685
		ClipDistance5,
		// Token: 0x0400A6BE RID: 42686
		ClipPlane5 = 12293,
		// Token: 0x0400A6BF RID: 42687
		ClipPlane5Img = 12293,
		// Token: 0x0400A6C0 RID: 42688
		ClipDistance6,
		// Token: 0x0400A6C1 RID: 42689
		ClipDistance7,
		// Token: 0x0400A6C2 RID: 42690
		Light0 = 16384,
		// Token: 0x0400A6C3 RID: 42691
		MultisampleBufferBit6Qcom = 1073741824,
		// Token: 0x0400A6C4 RID: 42692
		Light1 = 16385,
		// Token: 0x0400A6C5 RID: 42693
		Light2,
		// Token: 0x0400A6C6 RID: 42694
		Light3,
		// Token: 0x0400A6C7 RID: 42695
		Light4,
		// Token: 0x0400A6C8 RID: 42696
		Light5,
		// Token: 0x0400A6C9 RID: 42697
		Light6,
		// Token: 0x0400A6CA RID: 42698
		Light7,
		// Token: 0x0400A6CB RID: 42699
		AbgrExt = 32768,
		// Token: 0x0400A6CC RID: 42700
		MultisampleBufferBit7Qcom = -2147483648,
		// Token: 0x0400A6CD RID: 42701
		ConstantColorExt = 32769,
		// Token: 0x0400A6CE RID: 42702
		OneMinusConstantColorExt,
		// Token: 0x0400A6CF RID: 42703
		ConstantAlphaExt,
		// Token: 0x0400A6D0 RID: 42704
		OneMinusConstantAlphaExt,
		// Token: 0x0400A6D1 RID: 42705
		BlendColorExt,
		// Token: 0x0400A6D2 RID: 42706
		FuncAddExt,
		// Token: 0x0400A6D3 RID: 42707
		FuncAddOes = 32774,
		// Token: 0x0400A6D4 RID: 42708
		MinExt,
		// Token: 0x0400A6D5 RID: 42709
		MaxExt,
		// Token: 0x0400A6D6 RID: 42710
		BlendEquationExt,
		// Token: 0x0400A6D7 RID: 42711
		BlendEquationOes = 32777,
		// Token: 0x0400A6D8 RID: 42712
		BlendEquationRgbOes = 32777,
		// Token: 0x0400A6D9 RID: 42713
		FuncSubtractExt,
		// Token: 0x0400A6DA RID: 42714
		FuncSubtractOes = 32778,
		// Token: 0x0400A6DB RID: 42715
		FuncReverseSubtractExt,
		// Token: 0x0400A6DC RID: 42716
		FuncReverseSubtractOes = 32779,
		// Token: 0x0400A6DD RID: 42717
		CmykExt,
		// Token: 0x0400A6DE RID: 42718
		CmykaExt,
		// Token: 0x0400A6DF RID: 42719
		PackCmykHintExt,
		// Token: 0x0400A6E0 RID: 42720
		UnpackCmykHintExt,
		// Token: 0x0400A6E1 RID: 42721
		Convolution1D,
		// Token: 0x0400A6E2 RID: 42722
		Convolution1DExt = 32784,
		// Token: 0x0400A6E3 RID: 42723
		Convolution2D,
		// Token: 0x0400A6E4 RID: 42724
		Convolution2DExt = 32785,
		// Token: 0x0400A6E5 RID: 42725
		Separable2D,
		// Token: 0x0400A6E6 RID: 42726
		Separable2DExt = 32786,
		// Token: 0x0400A6E7 RID: 42727
		ConvolutionBorderMode,
		// Token: 0x0400A6E8 RID: 42728
		ConvolutionBorderModeExt = 32787,
		// Token: 0x0400A6E9 RID: 42729
		ConvolutionFilterScale,
		// Token: 0x0400A6EA RID: 42730
		ConvolutionFilterScaleExt = 32788,
		// Token: 0x0400A6EB RID: 42731
		ConvolutionFilterBias,
		// Token: 0x0400A6EC RID: 42732
		ConvolutionFilterBiasExt = 32789,
		// Token: 0x0400A6ED RID: 42733
		Reduce,
		// Token: 0x0400A6EE RID: 42734
		ReduceExt = 32790,
		// Token: 0x0400A6EF RID: 42735
		ConvolutionFormatExt,
		// Token: 0x0400A6F0 RID: 42736
		ConvolutionWidthExt,
		// Token: 0x0400A6F1 RID: 42737
		ConvolutionHeightExt,
		// Token: 0x0400A6F2 RID: 42738
		MaxConvolutionWidthExt,
		// Token: 0x0400A6F3 RID: 42739
		MaxConvolutionHeightExt,
		// Token: 0x0400A6F4 RID: 42740
		PostConvolutionRedScale,
		// Token: 0x0400A6F5 RID: 42741
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x0400A6F6 RID: 42742
		PostConvolutionGreenScale,
		// Token: 0x0400A6F7 RID: 42743
		PostConvolutionGreenScaleExt = 32797,
		// Token: 0x0400A6F8 RID: 42744
		PostConvolutionBlueScale,
		// Token: 0x0400A6F9 RID: 42745
		PostConvolutionBlueScaleExt = 32798,
		// Token: 0x0400A6FA RID: 42746
		PostConvolutionAlphaScale,
		// Token: 0x0400A6FB RID: 42747
		PostConvolutionAlphaScaleExt = 32799,
		// Token: 0x0400A6FC RID: 42748
		PostConvolutionRedBias,
		// Token: 0x0400A6FD RID: 42749
		PostConvolutionRedBiasExt = 32800,
		// Token: 0x0400A6FE RID: 42750
		PostConvolutionGreenBias,
		// Token: 0x0400A6FF RID: 42751
		PostConvolutionGreenBiasExt = 32801,
		// Token: 0x0400A700 RID: 42752
		PostConvolutionBlueBias,
		// Token: 0x0400A701 RID: 42753
		PostConvolutionBlueBiasExt = 32802,
		// Token: 0x0400A702 RID: 42754
		PostConvolutionAlphaBias,
		// Token: 0x0400A703 RID: 42755
		PostConvolutionAlphaBiasExt = 32803,
		// Token: 0x0400A704 RID: 42756
		Histogram,
		// Token: 0x0400A705 RID: 42757
		HistogramExt = 32804,
		// Token: 0x0400A706 RID: 42758
		ProxyHistogram,
		// Token: 0x0400A707 RID: 42759
		ProxyHistogramExt = 32805,
		// Token: 0x0400A708 RID: 42760
		HistogramWidthExt,
		// Token: 0x0400A709 RID: 42761
		HistogramFormatExt,
		// Token: 0x0400A70A RID: 42762
		HistogramRedSizeExt,
		// Token: 0x0400A70B RID: 42763
		HistogramGreenSizeExt,
		// Token: 0x0400A70C RID: 42764
		HistogramBlueSizeExt,
		// Token: 0x0400A70D RID: 42765
		HistogramAlphaSizeExt,
		// Token: 0x0400A70E RID: 42766
		HistogramLuminanceSizeExt,
		// Token: 0x0400A70F RID: 42767
		HistogramSinkExt,
		// Token: 0x0400A710 RID: 42768
		Minmax,
		// Token: 0x0400A711 RID: 42769
		MinmaxExt = 32814,
		// Token: 0x0400A712 RID: 42770
		MinmaxFormat,
		// Token: 0x0400A713 RID: 42771
		MinmaxFormatExt = 32815,
		// Token: 0x0400A714 RID: 42772
		MinmaxSink,
		// Token: 0x0400A715 RID: 42773
		MinmaxSinkExt = 32816,
		// Token: 0x0400A716 RID: 42774
		TableTooLarge,
		// Token: 0x0400A717 RID: 42775
		TableTooLargeExt = 32817,
		// Token: 0x0400A718 RID: 42776
		UnsignedByte332,
		// Token: 0x0400A719 RID: 42777
		UnsignedByte332Ext = 32818,
		// Token: 0x0400A71A RID: 42778
		UnsignedShort4444,
		// Token: 0x0400A71B RID: 42779
		UnsignedShort4444Ext = 32819,
		// Token: 0x0400A71C RID: 42780
		UnsignedShort5551,
		// Token: 0x0400A71D RID: 42781
		UnsignedShort5551Ext = 32820,
		// Token: 0x0400A71E RID: 42782
		UnsignedInt8888,
		// Token: 0x0400A71F RID: 42783
		UnsignedInt8888Ext = 32821,
		// Token: 0x0400A720 RID: 42784
		UnsignedInt1010102,
		// Token: 0x0400A721 RID: 42785
		UnsignedInt1010102Ext = 32822,
		// Token: 0x0400A722 RID: 42786
		PolygonOffsetFill,
		// Token: 0x0400A723 RID: 42787
		PolygonOffsetFactor,
		// Token: 0x0400A724 RID: 42788
		PolygonOffsetBiasExt,
		// Token: 0x0400A725 RID: 42789
		RescaleNormal,
		// Token: 0x0400A726 RID: 42790
		RescaleNormalExt = 32826,
		// Token: 0x0400A727 RID: 42791
		Alpha4,
		// Token: 0x0400A728 RID: 42792
		Alpha8,
		// Token: 0x0400A729 RID: 42793
		Alpha8Ext = 32828,
		// Token: 0x0400A72A RID: 42794
		Alpha8Oes = 32828,
		// Token: 0x0400A72B RID: 42795
		Alpha12,
		// Token: 0x0400A72C RID: 42796
		Alpha16,
		// Token: 0x0400A72D RID: 42797
		Luminance4,
		// Token: 0x0400A72E RID: 42798
		Luminance8,
		// Token: 0x0400A72F RID: 42799
		Luminance8Ext = 32832,
		// Token: 0x0400A730 RID: 42800
		Luminance8Oes = 32832,
		// Token: 0x0400A731 RID: 42801
		Luminance12,
		// Token: 0x0400A732 RID: 42802
		Luminance16,
		// Token: 0x0400A733 RID: 42803
		Luminance4Alpha4,
		// Token: 0x0400A734 RID: 42804
		Luminance4Alpha4Oes = 32835,
		// Token: 0x0400A735 RID: 42805
		Luminance6Alpha2,
		// Token: 0x0400A736 RID: 42806
		Luminance8Alpha8,
		// Token: 0x0400A737 RID: 42807
		Luminance8Alpha8Ext = 32837,
		// Token: 0x0400A738 RID: 42808
		Luminance8Alpha8Oes = 32837,
		// Token: 0x0400A739 RID: 42809
		Luminance12Alpha4,
		// Token: 0x0400A73A RID: 42810
		Luminance12Alpha12,
		// Token: 0x0400A73B RID: 42811
		Luminance16Alpha16,
		// Token: 0x0400A73C RID: 42812
		Intensity,
		// Token: 0x0400A73D RID: 42813
		Intensity4,
		// Token: 0x0400A73E RID: 42814
		Intensity8,
		// Token: 0x0400A73F RID: 42815
		Intensity12,
		// Token: 0x0400A740 RID: 42816
		Intensity16,
		// Token: 0x0400A741 RID: 42817
		Rgb2Ext,
		// Token: 0x0400A742 RID: 42818
		Rgb4,
		// Token: 0x0400A743 RID: 42819
		Rgb5,
		// Token: 0x0400A744 RID: 42820
		Rgb8,
		// Token: 0x0400A745 RID: 42821
		Rgb8Oes = 32849,
		// Token: 0x0400A746 RID: 42822
		Rgb10,
		// Token: 0x0400A747 RID: 42823
		Rgb10Ext = 32850,
		// Token: 0x0400A748 RID: 42824
		Rgb12,
		// Token: 0x0400A749 RID: 42825
		Rgb16,
		// Token: 0x0400A74A RID: 42826
		Rgba2,
		// Token: 0x0400A74B RID: 42827
		Rgba4,
		// Token: 0x0400A74C RID: 42828
		Rgba4Oes = 32854,
		// Token: 0x0400A74D RID: 42829
		Rgb5A1,
		// Token: 0x0400A74E RID: 42830
		Rgb5A1Oes = 32855,
		// Token: 0x0400A74F RID: 42831
		Rgba8,
		// Token: 0x0400A750 RID: 42832
		Rgba8Oes = 32856,
		// Token: 0x0400A751 RID: 42833
		Rgb10A2,
		// Token: 0x0400A752 RID: 42834
		Rgb10A2Ext = 32857,
		// Token: 0x0400A753 RID: 42835
		Rgba12,
		// Token: 0x0400A754 RID: 42836
		Rgba16,
		// Token: 0x0400A755 RID: 42837
		TextureRedSize,
		// Token: 0x0400A756 RID: 42838
		TextureGreenSize,
		// Token: 0x0400A757 RID: 42839
		TextureBlueSize,
		// Token: 0x0400A758 RID: 42840
		TextureAlphaSize,
		// Token: 0x0400A759 RID: 42841
		TextureLuminanceSize,
		// Token: 0x0400A75A RID: 42842
		TextureIntensitySize,
		// Token: 0x0400A75B RID: 42843
		ReplaceExt,
		// Token: 0x0400A75C RID: 42844
		ProxyTexture1D,
		// Token: 0x0400A75D RID: 42845
		ProxyTexture1DExt = 32867,
		// Token: 0x0400A75E RID: 42846
		ProxyTexture2D,
		// Token: 0x0400A75F RID: 42847
		ProxyTexture2DExt = 32868,
		// Token: 0x0400A760 RID: 42848
		TextureTooLargeExt,
		// Token: 0x0400A761 RID: 42849
		TexturePriority,
		// Token: 0x0400A762 RID: 42850
		TexturePriorityExt = 32870,
		// Token: 0x0400A763 RID: 42851
		TextureResident,
		// Token: 0x0400A764 RID: 42852
		TextureBinding1D,
		// Token: 0x0400A765 RID: 42853
		TextureBinding2D,
		// Token: 0x0400A766 RID: 42854
		Texture3DBindingExt,
		// Token: 0x0400A767 RID: 42855
		TextureBinding3D = 32874,
		// Token: 0x0400A768 RID: 42856
		PackSkipImages,
		// Token: 0x0400A769 RID: 42857
		PackSkipImagesExt = 32875,
		// Token: 0x0400A76A RID: 42858
		PackImageHeight,
		// Token: 0x0400A76B RID: 42859
		PackImageHeightExt = 32876,
		// Token: 0x0400A76C RID: 42860
		UnpackSkipImages,
		// Token: 0x0400A76D RID: 42861
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400A76E RID: 42862
		UnpackImageHeight,
		// Token: 0x0400A76F RID: 42863
		UnpackImageHeightExt = 32878,
		// Token: 0x0400A770 RID: 42864
		Texture3D,
		// Token: 0x0400A771 RID: 42865
		Texture3DExt = 32879,
		// Token: 0x0400A772 RID: 42866
		Texture3DOes = 32879,
		// Token: 0x0400A773 RID: 42867
		ProxyTexture3D,
		// Token: 0x0400A774 RID: 42868
		ProxyTexture3DExt = 32880,
		// Token: 0x0400A775 RID: 42869
		TextureDepthExt,
		// Token: 0x0400A776 RID: 42870
		TextureWrapR,
		// Token: 0x0400A777 RID: 42871
		TextureWrapRExt = 32882,
		// Token: 0x0400A778 RID: 42872
		TextureWrapROes = 32882,
		// Token: 0x0400A779 RID: 42873
		Max3DTextureSizeExt,
		// Token: 0x0400A77A RID: 42874
		VertexArray,
		// Token: 0x0400A77B RID: 42875
		NormalArray,
		// Token: 0x0400A77C RID: 42876
		ColorArray,
		// Token: 0x0400A77D RID: 42877
		IndexArray,
		// Token: 0x0400A77E RID: 42878
		TextureCoordArray,
		// Token: 0x0400A77F RID: 42879
		EdgeFlagArray,
		// Token: 0x0400A780 RID: 42880
		VertexArraySize,
		// Token: 0x0400A781 RID: 42881
		VertexArrayType,
		// Token: 0x0400A782 RID: 42882
		VertexArrayStride,
		// Token: 0x0400A783 RID: 42883
		VertexArrayCountExt,
		// Token: 0x0400A784 RID: 42884
		NormalArrayType,
		// Token: 0x0400A785 RID: 42885
		NormalArrayStride,
		// Token: 0x0400A786 RID: 42886
		NormalArrayCountExt,
		// Token: 0x0400A787 RID: 42887
		ColorArraySize,
		// Token: 0x0400A788 RID: 42888
		ColorArrayType,
		// Token: 0x0400A789 RID: 42889
		ColorArrayStride,
		// Token: 0x0400A78A RID: 42890
		ColorArrayCountExt,
		// Token: 0x0400A78B RID: 42891
		IndexArrayType,
		// Token: 0x0400A78C RID: 42892
		IndexArrayStride,
		// Token: 0x0400A78D RID: 42893
		IndexArrayCountExt,
		// Token: 0x0400A78E RID: 42894
		TextureCoordArraySize,
		// Token: 0x0400A78F RID: 42895
		TextureCoordArrayType,
		// Token: 0x0400A790 RID: 42896
		TextureCoordArrayStride,
		// Token: 0x0400A791 RID: 42897
		TextureCoordArrayCountExt,
		// Token: 0x0400A792 RID: 42898
		EdgeFlagArrayStride,
		// Token: 0x0400A793 RID: 42899
		EdgeFlagArrayCountExt,
		// Token: 0x0400A794 RID: 42900
		VertexArrayPointer,
		// Token: 0x0400A795 RID: 42901
		VertexArrayPointerExt = 32910,
		// Token: 0x0400A796 RID: 42902
		NormalArrayPointer,
		// Token: 0x0400A797 RID: 42903
		NormalArrayPointerExt = 32911,
		// Token: 0x0400A798 RID: 42904
		ColorArrayPointer,
		// Token: 0x0400A799 RID: 42905
		ColorArrayPointerExt = 32912,
		// Token: 0x0400A79A RID: 42906
		IndexArrayPointer,
		// Token: 0x0400A79B RID: 42907
		IndexArrayPointerExt = 32913,
		// Token: 0x0400A79C RID: 42908
		TextureCoordArrayPointer,
		// Token: 0x0400A79D RID: 42909
		TextureCoordArrayPointerExt = 32914,
		// Token: 0x0400A79E RID: 42910
		EdgeFlagArrayPointer,
		// Token: 0x0400A79F RID: 42911
		EdgeFlagArrayPointerExt = 32915,
		// Token: 0x0400A7A0 RID: 42912
		InterlaceSgix,
		// Token: 0x0400A7A1 RID: 42913
		DetailTexture2DSgis,
		// Token: 0x0400A7A2 RID: 42914
		DetailTexture2DBindingSgis,
		// Token: 0x0400A7A3 RID: 42915
		LinearDetailSgis,
		// Token: 0x0400A7A4 RID: 42916
		LinearDetailAlphaSgis,
		// Token: 0x0400A7A5 RID: 42917
		LinearDetailColorSgis,
		// Token: 0x0400A7A6 RID: 42918
		DetailTextureLevelSgis,
		// Token: 0x0400A7A7 RID: 42919
		DetailTextureModeSgis,
		// Token: 0x0400A7A8 RID: 42920
		DetailTextureFuncPointsSgis,
		// Token: 0x0400A7A9 RID: 42921
		Multisample,
		// Token: 0x0400A7AA RID: 42922
		MultisampleSgis = 32925,
		// Token: 0x0400A7AB RID: 42923
		SampleAlphaToCoverage,
		// Token: 0x0400A7AC RID: 42924
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x0400A7AD RID: 42925
		SampleAlphaToOne,
		// Token: 0x0400A7AE RID: 42926
		SampleAlphaToOneSgis = 32927,
		// Token: 0x0400A7AF RID: 42927
		SampleCoverage,
		// Token: 0x0400A7B0 RID: 42928
		SampleMaskSgis = 32928,
		// Token: 0x0400A7B1 RID: 42929
		Gl1PassExt,
		// Token: 0x0400A7B2 RID: 42930
		Gl1PassSgis = 32929,
		// Token: 0x0400A7B3 RID: 42931
		Gl2Pass0Ext,
		// Token: 0x0400A7B4 RID: 42932
		Gl2Pass0Sgis = 32930,
		// Token: 0x0400A7B5 RID: 42933
		Gl2Pass1Ext,
		// Token: 0x0400A7B6 RID: 42934
		Gl2Pass1Sgis = 32931,
		// Token: 0x0400A7B7 RID: 42935
		Gl4Pass0Ext,
		// Token: 0x0400A7B8 RID: 42936
		Gl4Pass0Sgis = 32932,
		// Token: 0x0400A7B9 RID: 42937
		Gl4Pass1Ext,
		// Token: 0x0400A7BA RID: 42938
		Gl4Pass1Sgis = 32933,
		// Token: 0x0400A7BB RID: 42939
		Gl4Pass2Ext,
		// Token: 0x0400A7BC RID: 42940
		Gl4Pass2Sgis = 32934,
		// Token: 0x0400A7BD RID: 42941
		Gl4Pass3Ext,
		// Token: 0x0400A7BE RID: 42942
		Gl4Pass3Sgis = 32935,
		// Token: 0x0400A7BF RID: 42943
		SampleBuffers,
		// Token: 0x0400A7C0 RID: 42944
		SampleBuffersSgis = 32936,
		// Token: 0x0400A7C1 RID: 42945
		Samples,
		// Token: 0x0400A7C2 RID: 42946
		SamplesSgis = 32937,
		// Token: 0x0400A7C3 RID: 42947
		SampleCoverageValue,
		// Token: 0x0400A7C4 RID: 42948
		SampleMaskValueSgis = 32938,
		// Token: 0x0400A7C5 RID: 42949
		SampleCoverageInvert,
		// Token: 0x0400A7C6 RID: 42950
		SampleMaskInvertSgis = 32939,
		// Token: 0x0400A7C7 RID: 42951
		SamplePatternSgis,
		// Token: 0x0400A7C8 RID: 42952
		LinearSharpenSgis,
		// Token: 0x0400A7C9 RID: 42953
		LinearSharpenAlphaSgis,
		// Token: 0x0400A7CA RID: 42954
		LinearSharpenColorSgis,
		// Token: 0x0400A7CB RID: 42955
		SharpenTextureFuncPointsSgis,
		// Token: 0x0400A7CC RID: 42956
		ColorMatrixSgi,
		// Token: 0x0400A7CD RID: 42957
		ColorMatrixStackDepthSgi,
		// Token: 0x0400A7CE RID: 42958
		MaxColorMatrixStackDepthSgi,
		// Token: 0x0400A7CF RID: 42959
		PostColorMatrixRedScale,
		// Token: 0x0400A7D0 RID: 42960
		PostColorMatrixRedScaleSgi = 32948,
		// Token: 0x0400A7D1 RID: 42961
		PostColorMatrixGreenScale,
		// Token: 0x0400A7D2 RID: 42962
		PostColorMatrixGreenScaleSgi = 32949,
		// Token: 0x0400A7D3 RID: 42963
		PostColorMatrixBlueScale,
		// Token: 0x0400A7D4 RID: 42964
		PostColorMatrixBlueScaleSgi = 32950,
		// Token: 0x0400A7D5 RID: 42965
		PostColorMatrixAlphaScale,
		// Token: 0x0400A7D6 RID: 42966
		PostColorMatrixAlphaScaleSgi = 32951,
		// Token: 0x0400A7D7 RID: 42967
		PostColorMatrixRedBias,
		// Token: 0x0400A7D8 RID: 42968
		PostColorMatrixRedBiasSgi = 32952,
		// Token: 0x0400A7D9 RID: 42969
		PostColorMatrixGreenBias,
		// Token: 0x0400A7DA RID: 42970
		PostColorMatrixGreenBiasSgi = 32953,
		// Token: 0x0400A7DB RID: 42971
		PostColorMatrixBlueBias,
		// Token: 0x0400A7DC RID: 42972
		PostColorMatrixBlueBiasSgi = 32954,
		// Token: 0x0400A7DD RID: 42973
		PostColorMatrixAlphaBias,
		// Token: 0x0400A7DE RID: 42974
		PostColorMatrixAlphaBiasSgi = 32955,
		// Token: 0x0400A7DF RID: 42975
		TextureColorTableSgi,
		// Token: 0x0400A7E0 RID: 42976
		ProxyTextureColorTableSgi,
		// Token: 0x0400A7E1 RID: 42977
		TextureEnvBiasSgix,
		// Token: 0x0400A7E2 RID: 42978
		ShadowAmbientSgix,
		// Token: 0x0400A7E3 RID: 42979
		BlendDstRgbOes = 32968,
		// Token: 0x0400A7E4 RID: 42980
		BlendSrcRgbOes,
		// Token: 0x0400A7E5 RID: 42981
		BlendDstAlphaOes,
		// Token: 0x0400A7E6 RID: 42982
		BlendSrcAlphaOes,
		// Token: 0x0400A7E7 RID: 42983
		ColorTable = 32976,
		// Token: 0x0400A7E8 RID: 42984
		ColorTableSgi = 32976,
		// Token: 0x0400A7E9 RID: 42985
		PostConvolutionColorTable,
		// Token: 0x0400A7EA RID: 42986
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x0400A7EB RID: 42987
		PostColorMatrixColorTable,
		// Token: 0x0400A7EC RID: 42988
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x0400A7ED RID: 42989
		ProxyColorTable,
		// Token: 0x0400A7EE RID: 42990
		ProxyColorTableSgi = 32979,
		// Token: 0x0400A7EF RID: 42991
		ProxyPostConvolutionColorTable,
		// Token: 0x0400A7F0 RID: 42992
		ProxyPostConvolutionColorTableSgi = 32980,
		// Token: 0x0400A7F1 RID: 42993
		ProxyPostColorMatrixColorTable,
		// Token: 0x0400A7F2 RID: 42994
		ProxyPostColorMatrixColorTableSgi = 32981,
		// Token: 0x0400A7F3 RID: 42995
		ColorTableScale,
		// Token: 0x0400A7F4 RID: 42996
		ColorTableScaleSgi = 32982,
		// Token: 0x0400A7F5 RID: 42997
		ColorTableBias,
		// Token: 0x0400A7F6 RID: 42998
		ColorTableBiasSgi = 32983,
		// Token: 0x0400A7F7 RID: 42999
		ColorTableFormatSgi,
		// Token: 0x0400A7F8 RID: 43000
		ColorTableWidthSgi,
		// Token: 0x0400A7F9 RID: 43001
		ColorTableRedSizeSgi,
		// Token: 0x0400A7FA RID: 43002
		ColorTableGreenSizeSgi,
		// Token: 0x0400A7FB RID: 43003
		ColorTableBlueSizeSgi,
		// Token: 0x0400A7FC RID: 43004
		ColorTableAlphaSizeSgi,
		// Token: 0x0400A7FD RID: 43005
		ColorTableLuminanceSizeSgi,
		// Token: 0x0400A7FE RID: 43006
		ColorTableIntensitySizeSgi,
		// Token: 0x0400A7FF RID: 43007
		Bgra = 32993,
		// Token: 0x0400A800 RID: 43008
		BgraExt = 32993,
		// Token: 0x0400A801 RID: 43009
		BgraImg = 32993,
		// Token: 0x0400A802 RID: 43010
		PhongHintWin = 33003,
		// Token: 0x0400A803 RID: 43011
		ClipVolumeClippingHintExt = 33008,
		// Token: 0x0400A804 RID: 43012
		DualAlpha4Sgis = 33040,
		// Token: 0x0400A805 RID: 43013
		DualAlpha8Sgis,
		// Token: 0x0400A806 RID: 43014
		DualAlpha12Sgis,
		// Token: 0x0400A807 RID: 43015
		DualAlpha16Sgis,
		// Token: 0x0400A808 RID: 43016
		DualLuminance4Sgis,
		// Token: 0x0400A809 RID: 43017
		DualLuminance8Sgis,
		// Token: 0x0400A80A RID: 43018
		DualLuminance12Sgis,
		// Token: 0x0400A80B RID: 43019
		DualLuminance16Sgis,
		// Token: 0x0400A80C RID: 43020
		DualIntensity4Sgis,
		// Token: 0x0400A80D RID: 43021
		DualIntensity8Sgis,
		// Token: 0x0400A80E RID: 43022
		DualIntensity12Sgis,
		// Token: 0x0400A80F RID: 43023
		DualIntensity16Sgis,
		// Token: 0x0400A810 RID: 43024
		DualLuminanceAlpha4Sgis,
		// Token: 0x0400A811 RID: 43025
		DualLuminanceAlpha8Sgis,
		// Token: 0x0400A812 RID: 43026
		QuadAlpha4Sgis,
		// Token: 0x0400A813 RID: 43027
		QuadAlpha8Sgis,
		// Token: 0x0400A814 RID: 43028
		QuadLuminance4Sgis,
		// Token: 0x0400A815 RID: 43029
		QuadLuminance8Sgis,
		// Token: 0x0400A816 RID: 43030
		QuadIntensity4Sgis,
		// Token: 0x0400A817 RID: 43031
		QuadIntensity8Sgis,
		// Token: 0x0400A818 RID: 43032
		DualTextureSelectSgis,
		// Token: 0x0400A819 RID: 43033
		QuadTextureSelectSgis,
		// Token: 0x0400A81A RID: 43034
		PointSizeMin,
		// Token: 0x0400A81B RID: 43035
		PointSizeMinArb = 33062,
		// Token: 0x0400A81C RID: 43036
		PointSizeMinExt = 33062,
		// Token: 0x0400A81D RID: 43037
		PointSizeMinSgis = 33062,
		// Token: 0x0400A81E RID: 43038
		PointSizeMax,
		// Token: 0x0400A81F RID: 43039
		PointSizeMaxArb = 33063,
		// Token: 0x0400A820 RID: 43040
		PointSizeMaxExt = 33063,
		// Token: 0x0400A821 RID: 43041
		PointSizeMaxSgis = 33063,
		// Token: 0x0400A822 RID: 43042
		PointFadeThresholdSize,
		// Token: 0x0400A823 RID: 43043
		PointFadeThresholdSizeArb = 33064,
		// Token: 0x0400A824 RID: 43044
		PointFadeThresholdSizeExt = 33064,
		// Token: 0x0400A825 RID: 43045
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x0400A826 RID: 43046
		DistanceAttenuationExt,
		// Token: 0x0400A827 RID: 43047
		DistanceAttenuationSgis = 33065,
		// Token: 0x0400A828 RID: 43048
		PointDistanceAttenuation = 33065,
		// Token: 0x0400A829 RID: 43049
		PointDistanceAttenuationArb = 33065,
		// Token: 0x0400A82A RID: 43050
		FogFuncSgis,
		// Token: 0x0400A82B RID: 43051
		FogFuncPointsSgis,
		// Token: 0x0400A82C RID: 43052
		MaxFogFuncPointsSgis,
		// Token: 0x0400A82D RID: 43053
		ClampToBorder,
		// Token: 0x0400A82E RID: 43054
		ClampToBorderArb = 33069,
		// Token: 0x0400A82F RID: 43055
		ClampToBorderNv = 33069,
		// Token: 0x0400A830 RID: 43056
		ClampToBorderSgis = 33069,
		// Token: 0x0400A831 RID: 43057
		TextureMultiBufferHintSgix,
		// Token: 0x0400A832 RID: 43058
		ClampToEdge,
		// Token: 0x0400A833 RID: 43059
		ClampToEdgeSgis = 33071,
		// Token: 0x0400A834 RID: 43060
		PackSkipVolumesSgis,
		// Token: 0x0400A835 RID: 43061
		PackImageDepthSgis,
		// Token: 0x0400A836 RID: 43062
		UnpackSkipVolumesSgis,
		// Token: 0x0400A837 RID: 43063
		UnpackImageDepthSgis,
		// Token: 0x0400A838 RID: 43064
		Texture4DSgis,
		// Token: 0x0400A839 RID: 43065
		ProxyTexture4DSgis,
		// Token: 0x0400A83A RID: 43066
		Texture4DsizeSgis,
		// Token: 0x0400A83B RID: 43067
		TextureWrapQSgis,
		// Token: 0x0400A83C RID: 43068
		Max4DTextureSizeSgis,
		// Token: 0x0400A83D RID: 43069
		PixelTexGenSgix,
		// Token: 0x0400A83E RID: 43070
		TextureMinLod,
		// Token: 0x0400A83F RID: 43071
		TextureMinLodSgis = 33082,
		// Token: 0x0400A840 RID: 43072
		TextureMaxLod,
		// Token: 0x0400A841 RID: 43073
		TextureMaxLodSgis = 33083,
		// Token: 0x0400A842 RID: 43074
		TextureBaseLevel,
		// Token: 0x0400A843 RID: 43075
		TextureBaseLevelSgis = 33084,
		// Token: 0x0400A844 RID: 43076
		TextureMaxLevel,
		// Token: 0x0400A845 RID: 43077
		TextureMaxLevelApple = 33085,
		// Token: 0x0400A846 RID: 43078
		TextureMaxLevelSgis = 33085,
		// Token: 0x0400A847 RID: 43079
		PixelTileBestAlignmentSgix,
		// Token: 0x0400A848 RID: 43080
		PixelTileCacheIncrementSgix,
		// Token: 0x0400A849 RID: 43081
		PixelTileWidthSgix,
		// Token: 0x0400A84A RID: 43082
		PixelTileHeightSgix,
		// Token: 0x0400A84B RID: 43083
		PixelTileGridWidthSgix,
		// Token: 0x0400A84C RID: 43084
		PixelTileGridHeightSgix,
		// Token: 0x0400A84D RID: 43085
		PixelTileGridDepthSgix,
		// Token: 0x0400A84E RID: 43086
		PixelTileCacheSizeSgix,
		// Token: 0x0400A84F RID: 43087
		Filter4Sgis,
		// Token: 0x0400A850 RID: 43088
		TextureFilter4SizeSgis,
		// Token: 0x0400A851 RID: 43089
		SpriteSgix,
		// Token: 0x0400A852 RID: 43090
		SpriteModeSgix,
		// Token: 0x0400A853 RID: 43091
		SpriteAxisSgix,
		// Token: 0x0400A854 RID: 43092
		SpriteTranslationSgix,
		// Token: 0x0400A855 RID: 43093
		Texture4DBindingSgis = 33103,
		// Token: 0x0400A856 RID: 43094
		LinearClipmapLinearSgix = 33136,
		// Token: 0x0400A857 RID: 43095
		TextureClipmapCenterSgix,
		// Token: 0x0400A858 RID: 43096
		TextureClipmapFrameSgix,
		// Token: 0x0400A859 RID: 43097
		TextureClipmapOffsetSgix,
		// Token: 0x0400A85A RID: 43098
		TextureClipmapVirtualDepthSgix,
		// Token: 0x0400A85B RID: 43099
		TextureClipmapLodOffsetSgix,
		// Token: 0x0400A85C RID: 43100
		TextureClipmapDepthSgix,
		// Token: 0x0400A85D RID: 43101
		MaxClipmapDepthSgix,
		// Token: 0x0400A85E RID: 43102
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400A85F RID: 43103
		PostTextureFilterBiasSgix,
		// Token: 0x0400A860 RID: 43104
		PostTextureFilterScaleSgix,
		// Token: 0x0400A861 RID: 43105
		PostTextureFilterBiasRangeSgix,
		// Token: 0x0400A862 RID: 43106
		PostTextureFilterScaleRangeSgix,
		// Token: 0x0400A863 RID: 43107
		ReferencePlaneSgix,
		// Token: 0x0400A864 RID: 43108
		ReferencePlaneEquationSgix,
		// Token: 0x0400A865 RID: 43109
		IrInstrument1Sgix,
		// Token: 0x0400A866 RID: 43110
		InstrumentBufferPointerSgix,
		// Token: 0x0400A867 RID: 43111
		InstrumentMeasurementsSgix,
		// Token: 0x0400A868 RID: 43112
		ListPrioritySgix,
		// Token: 0x0400A869 RID: 43113
		CalligraphicFragmentSgix,
		// Token: 0x0400A86A RID: 43114
		PixelTexGenQCeilingSgix,
		// Token: 0x0400A86B RID: 43115
		PixelTexGenQRoundSgix,
		// Token: 0x0400A86C RID: 43116
		PixelTexGenQFloorSgix,
		// Token: 0x0400A86D RID: 43117
		PixelTexGenAlphaReplaceSgix,
		// Token: 0x0400A86E RID: 43118
		PixelTexGenAlphaNoReplaceSgix,
		// Token: 0x0400A86F RID: 43119
		PixelTexGenAlphaLsSgix,
		// Token: 0x0400A870 RID: 43120
		PixelTexGenAlphaMsSgix,
		// Token: 0x0400A871 RID: 43121
		FramezoomSgix,
		// Token: 0x0400A872 RID: 43122
		FramezoomFactorSgix,
		// Token: 0x0400A873 RID: 43123
		MaxFramezoomFactorSgix,
		// Token: 0x0400A874 RID: 43124
		TextureLodBiasSSgix,
		// Token: 0x0400A875 RID: 43125
		TextureLodBiasTSgix,
		// Token: 0x0400A876 RID: 43126
		TextureLodBiasRSgix,
		// Token: 0x0400A877 RID: 43127
		GenerateMipmap,
		// Token: 0x0400A878 RID: 43128
		GenerateMipmapSgis = 33169,
		// Token: 0x0400A879 RID: 43129
		GenerateMipmapHint,
		// Token: 0x0400A87A RID: 43130
		GenerateMipmapHintSgis = 33170,
		// Token: 0x0400A87B RID: 43131
		GeometryDeformationSgix = 33172,
		// Token: 0x0400A87C RID: 43132
		TextureDeformationSgix,
		// Token: 0x0400A87D RID: 43133
		DeformationsMaskSgix,
		// Token: 0x0400A87E RID: 43134
		FogOffsetSgix = 33176,
		// Token: 0x0400A87F RID: 43135
		FogOffsetValueSgix,
		// Token: 0x0400A880 RID: 43136
		TextureCompareSgix,
		// Token: 0x0400A881 RID: 43137
		TextureCompareOperatorSgix,
		// Token: 0x0400A882 RID: 43138
		TextureLequalRSgix,
		// Token: 0x0400A883 RID: 43139
		TextureGequalRSgix,
		// Token: 0x0400A884 RID: 43140
		DepthComponent16Oes = 33189,
		// Token: 0x0400A885 RID: 43141
		DepthComponent16Sgix = 33189,
		// Token: 0x0400A886 RID: 43142
		DepthComponent24Oes,
		// Token: 0x0400A887 RID: 43143
		DepthComponent24Sgix = 33190,
		// Token: 0x0400A888 RID: 43144
		DepthComponent32Oes,
		// Token: 0x0400A889 RID: 43145
		DepthComponent32Sgix = 33191,
		// Token: 0x0400A88A RID: 43146
		Ycrcb422Sgix = 33211,
		// Token: 0x0400A88B RID: 43147
		Ycrcb444Sgix,
		// Token: 0x0400A88C RID: 43148
		EyeDistanceToPointSgis = 33264,
		// Token: 0x0400A88D RID: 43149
		ObjectDistanceToPointSgis,
		// Token: 0x0400A88E RID: 43150
		EyeDistanceToLineSgis,
		// Token: 0x0400A88F RID: 43151
		ObjectDistanceToLineSgis,
		// Token: 0x0400A890 RID: 43152
		EyePointSgis,
		// Token: 0x0400A891 RID: 43153
		ObjectPointSgis,
		// Token: 0x0400A892 RID: 43154
		EyeLineSgis,
		// Token: 0x0400A893 RID: 43155
		ObjectLineSgis,
		// Token: 0x0400A894 RID: 43156
		LightModelColorControl,
		// Token: 0x0400A895 RID: 43157
		LightModelColorControlExt = 33272,
		// Token: 0x0400A896 RID: 43158
		SingleColor,
		// Token: 0x0400A897 RID: 43159
		SingleColorExt = 33273,
		// Token: 0x0400A898 RID: 43160
		SeparateSpecularColor,
		// Token: 0x0400A899 RID: 43161
		SeparateSpecularColorExt = 33274,
		// Token: 0x0400A89A RID: 43162
		SharedTexturePaletteExt,
		// Token: 0x0400A89B RID: 43163
		FramebufferAttachmentColorEncodingExt = 33296,
		// Token: 0x0400A89C RID: 43164
		R8Ext = 33321,
		// Token: 0x0400A89D RID: 43165
		Rg8Ext = 33323,
		// Token: 0x0400A89E RID: 43166
		R16fExt = 33325,
		// Token: 0x0400A89F RID: 43167
		R32fExt,
		// Token: 0x0400A8A0 RID: 43168
		Rg16fExt,
		// Token: 0x0400A8A1 RID: 43169
		Rg32fExt,
		// Token: 0x0400A8A2 RID: 43170
		LoseContextOnResetExt = 33362,
		// Token: 0x0400A8A3 RID: 43171
		GuiltyContextResetExt,
		// Token: 0x0400A8A4 RID: 43172
		InnocentContextResetExt,
		// Token: 0x0400A8A5 RID: 43173
		UnknownContextResetExt,
		// Token: 0x0400A8A6 RID: 43174
		ResetNotificationStrategyExt,
		// Token: 0x0400A8A7 RID: 43175
		ProgramBinaryRetrievableHint,
		// Token: 0x0400A8A8 RID: 43176
		NoResetNotificationExt = 33377,
		// Token: 0x0400A8A9 RID: 43177
		ConvolutionHintSgix = 33558,
		// Token: 0x0400A8AA RID: 43178
		AlphaMinSgix = 33568,
		// Token: 0x0400A8AB RID: 43179
		AlphaMaxSgix,
		// Token: 0x0400A8AC RID: 43180
		ScalebiasHintSgix,
		// Token: 0x0400A8AD RID: 43181
		AsyncMarkerSgix = 33577,
		// Token: 0x0400A8AE RID: 43182
		PixelTexGenModeSgix = 33579,
		// Token: 0x0400A8AF RID: 43183
		AsyncHistogramSgix,
		// Token: 0x0400A8B0 RID: 43184
		MaxAsyncHistogramSgix,
		// Token: 0x0400A8B1 RID: 43185
		PixelTextureSgis = 33619,
		// Token: 0x0400A8B2 RID: 43186
		PixelFragmentRgbSourceSgis,
		// Token: 0x0400A8B3 RID: 43187
		PixelFragmentAlphaSourceSgis,
		// Token: 0x0400A8B4 RID: 43188
		LineQualityHintSgix = 33627,
		// Token: 0x0400A8B5 RID: 43189
		AsyncTexImageSgix,
		// Token: 0x0400A8B6 RID: 43190
		AsyncDrawPixelsSgix,
		// Token: 0x0400A8B7 RID: 43191
		AsyncReadPixelsSgix,
		// Token: 0x0400A8B8 RID: 43192
		MaxAsyncTexImageSgix,
		// Token: 0x0400A8B9 RID: 43193
		MaxAsyncDrawPixelsSgix,
		// Token: 0x0400A8BA RID: 43194
		MaxAsyncReadPixelsSgix,
		// Token: 0x0400A8BB RID: 43195
		UnsignedShort565 = 33635,
		// Token: 0x0400A8BC RID: 43196
		UnsignedShort4444Rev = 33637,
		// Token: 0x0400A8BD RID: 43197
		UnsignedShort4444RevExt = 33637,
		// Token: 0x0400A8BE RID: 43198
		UnsignedShort4444RevImg = 33637,
		// Token: 0x0400A8BF RID: 43199
		UnsignedShort1555Rev,
		// Token: 0x0400A8C0 RID: 43200
		UnsignedShort1555RevExt = 33638,
		// Token: 0x0400A8C1 RID: 43201
		TextureMaxClampSSgix = 33641,
		// Token: 0x0400A8C2 RID: 43202
		TextureMaxClampTSgix,
		// Token: 0x0400A8C3 RID: 43203
		TextureMaxClampRSgix,
		// Token: 0x0400A8C4 RID: 43204
		MirroredRepeatOes = 33648,
		// Token: 0x0400A8C5 RID: 43205
		VertexPreclipSgix = 33774,
		// Token: 0x0400A8C6 RID: 43206
		VertexPreclipHintSgix,
		// Token: 0x0400A8C7 RID: 43207
		CompressedRgbS3tcDxt1Ext,
		// Token: 0x0400A8C8 RID: 43208
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x0400A8C9 RID: 43209
		FragmentLightingSgix = 33792,
		// Token: 0x0400A8CA RID: 43210
		FragmentColorMaterialSgix,
		// Token: 0x0400A8CB RID: 43211
		FragmentColorMaterialFaceSgix,
		// Token: 0x0400A8CC RID: 43212
		FragmentColorMaterialParameterSgix,
		// Token: 0x0400A8CD RID: 43213
		MaxFragmentLightsSgix,
		// Token: 0x0400A8CE RID: 43214
		MaxActiveLightsSgix,
		// Token: 0x0400A8CF RID: 43215
		LightEnvModeSgix = 33799,
		// Token: 0x0400A8D0 RID: 43216
		FragmentLightModelLocalViewerSgix,
		// Token: 0x0400A8D1 RID: 43217
		FragmentLightModelTwoSideSgix,
		// Token: 0x0400A8D2 RID: 43218
		FragmentLightModelAmbientSgix,
		// Token: 0x0400A8D3 RID: 43219
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x0400A8D4 RID: 43220
		FragmentLight0Sgix,
		// Token: 0x0400A8D5 RID: 43221
		FragmentLight1Sgix,
		// Token: 0x0400A8D6 RID: 43222
		FragmentLight2Sgix,
		// Token: 0x0400A8D7 RID: 43223
		FragmentLight3Sgix,
		// Token: 0x0400A8D8 RID: 43224
		FragmentLight4Sgix,
		// Token: 0x0400A8D9 RID: 43225
		FragmentLight5Sgix,
		// Token: 0x0400A8DA RID: 43226
		FragmentLight6Sgix,
		// Token: 0x0400A8DB RID: 43227
		FragmentLight7Sgix,
		// Token: 0x0400A8DC RID: 43228
		PackResampleSgix = 33836,
		// Token: 0x0400A8DD RID: 43229
		UnpackResampleSgix,
		// Token: 0x0400A8DE RID: 43230
		ResampleReplicateSgix,
		// Token: 0x0400A8DF RID: 43231
		ResampleZeroFillSgix,
		// Token: 0x0400A8E0 RID: 43232
		ResampleDecimateSgix,
		// Token: 0x0400A8E1 RID: 43233
		NearestClipmapNearestSgix = 33869,
		// Token: 0x0400A8E2 RID: 43234
		NearestClipmapLinearSgix,
		// Token: 0x0400A8E3 RID: 43235
		LinearClipmapNearestSgix,
		// Token: 0x0400A8E4 RID: 43236
		AliasedPointSizeRange = 33901,
		// Token: 0x0400A8E5 RID: 43237
		AliasedLineWidthRange,
		// Token: 0x0400A8E6 RID: 43238
		Texture0 = 33984,
		// Token: 0x0400A8E7 RID: 43239
		Texture1,
		// Token: 0x0400A8E8 RID: 43240
		Texture2,
		// Token: 0x0400A8E9 RID: 43241
		Texture3,
		// Token: 0x0400A8EA RID: 43242
		Texture4,
		// Token: 0x0400A8EB RID: 43243
		Texture5,
		// Token: 0x0400A8EC RID: 43244
		Texture6,
		// Token: 0x0400A8ED RID: 43245
		Texture7,
		// Token: 0x0400A8EE RID: 43246
		Texture8,
		// Token: 0x0400A8EF RID: 43247
		Texture9,
		// Token: 0x0400A8F0 RID: 43248
		Texture10,
		// Token: 0x0400A8F1 RID: 43249
		Texture11,
		// Token: 0x0400A8F2 RID: 43250
		Texture12,
		// Token: 0x0400A8F3 RID: 43251
		Texture13,
		// Token: 0x0400A8F4 RID: 43252
		Texture14,
		// Token: 0x0400A8F5 RID: 43253
		Texture15,
		// Token: 0x0400A8F6 RID: 43254
		Texture16,
		// Token: 0x0400A8F7 RID: 43255
		Texture17,
		// Token: 0x0400A8F8 RID: 43256
		Texture18,
		// Token: 0x0400A8F9 RID: 43257
		Texture19,
		// Token: 0x0400A8FA RID: 43258
		Texture20,
		// Token: 0x0400A8FB RID: 43259
		Texture21,
		// Token: 0x0400A8FC RID: 43260
		Texture22,
		// Token: 0x0400A8FD RID: 43261
		Texture23,
		// Token: 0x0400A8FE RID: 43262
		Texture24,
		// Token: 0x0400A8FF RID: 43263
		Texture25,
		// Token: 0x0400A900 RID: 43264
		Texture26,
		// Token: 0x0400A901 RID: 43265
		Texture27,
		// Token: 0x0400A902 RID: 43266
		Texture28,
		// Token: 0x0400A903 RID: 43267
		Texture29,
		// Token: 0x0400A904 RID: 43268
		Texture30,
		// Token: 0x0400A905 RID: 43269
		Texture31,
		// Token: 0x0400A906 RID: 43270
		ActiveTexture,
		// Token: 0x0400A907 RID: 43271
		ClientActiveTexture,
		// Token: 0x0400A908 RID: 43272
		MaxTextureUnits,
		// Token: 0x0400A909 RID: 43273
		Subtract = 34023,
		// Token: 0x0400A90A RID: 43274
		MaxRenderbufferSizeOes,
		// Token: 0x0400A90B RID: 43275
		TextureCompressionHint = 34031,
		// Token: 0x0400A90C RID: 43276
		TextureCompressionHintArb = 34031,
		// Token: 0x0400A90D RID: 43277
		AllCompletedNv = 34034,
		// Token: 0x0400A90E RID: 43278
		FenceStatusNv,
		// Token: 0x0400A90F RID: 43279
		FenceConditionNv,
		// Token: 0x0400A910 RID: 43280
		DepthStencilOes = 34041,
		// Token: 0x0400A911 RID: 43281
		UnsignedInt248Oes,
		// Token: 0x0400A912 RID: 43282
		MaxTextureLodBiasExt = 34045,
		// Token: 0x0400A913 RID: 43283
		TextureMaxAnisotropyExt,
		// Token: 0x0400A914 RID: 43284
		MaxTextureMaxAnisotropyExt,
		// Token: 0x0400A915 RID: 43285
		TextureFilterControlExt,
		// Token: 0x0400A916 RID: 43286
		TextureLodBiasExt,
		// Token: 0x0400A917 RID: 43287
		IncrWrapOes = 34055,
		// Token: 0x0400A918 RID: 43288
		DecrWrapOes,
		// Token: 0x0400A919 RID: 43289
		NormalMapOes = 34065,
		// Token: 0x0400A91A RID: 43290
		ReflectionMapOes,
		// Token: 0x0400A91B RID: 43291
		TextureCubeMapOes,
		// Token: 0x0400A91C RID: 43292
		TextureBindingCubeMapOes,
		// Token: 0x0400A91D RID: 43293
		TextureCubeMapPositiveXOes,
		// Token: 0x0400A91E RID: 43294
		TextureCubeMapNegativeXOes,
		// Token: 0x0400A91F RID: 43295
		TextureCubeMapPositiveYOes,
		// Token: 0x0400A920 RID: 43296
		TextureCubeMapNegativeYOes,
		// Token: 0x0400A921 RID: 43297
		TextureCubeMapPositiveZOes,
		// Token: 0x0400A922 RID: 43298
		TextureCubeMapNegativeZOes,
		// Token: 0x0400A923 RID: 43299
		MaxCubeMapTextureSizeOes = 34076,
		// Token: 0x0400A924 RID: 43300
		VertexArrayStorageHintApple = 34079,
		// Token: 0x0400A925 RID: 43301
		MultisampleFilterHintNv = 34100,
		// Token: 0x0400A926 RID: 43302
		Combine = 34160,
		// Token: 0x0400A927 RID: 43303
		CombineRgb,
		// Token: 0x0400A928 RID: 43304
		CombineAlpha,
		// Token: 0x0400A929 RID: 43305
		RgbScale,
		// Token: 0x0400A92A RID: 43306
		AddSigned,
		// Token: 0x0400A92B RID: 43307
		Interpolate,
		// Token: 0x0400A92C RID: 43308
		Constant,
		// Token: 0x0400A92D RID: 43309
		PrimaryColor,
		// Token: 0x0400A92E RID: 43310
		Previous,
		// Token: 0x0400A92F RID: 43311
		Src0Rgb = 34176,
		// Token: 0x0400A930 RID: 43312
		Src1Rgb,
		// Token: 0x0400A931 RID: 43313
		Src2Rgb,
		// Token: 0x0400A932 RID: 43314
		Src0Alpha = 34184,
		// Token: 0x0400A933 RID: 43315
		Src1Alpha,
		// Token: 0x0400A934 RID: 43316
		Src2Alpha,
		// Token: 0x0400A935 RID: 43317
		Operand0Rgb = 34192,
		// Token: 0x0400A936 RID: 43318
		Operand1Rgb,
		// Token: 0x0400A937 RID: 43319
		Operand2Rgb,
		// Token: 0x0400A938 RID: 43320
		Operand0Alpha = 34200,
		// Token: 0x0400A939 RID: 43321
		Operand1Alpha,
		// Token: 0x0400A93A RID: 43322
		Operand2Alpha,
		// Token: 0x0400A93B RID: 43323
		PackSubsampleRateSgix = 34208,
		// Token: 0x0400A93C RID: 43324
		UnpackSubsampleRateSgix,
		// Token: 0x0400A93D RID: 43325
		PixelSubsample4444Sgix,
		// Token: 0x0400A93E RID: 43326
		PixelSubsample2424Sgix,
		// Token: 0x0400A93F RID: 43327
		PixelSubsample4242Sgix,
		// Token: 0x0400A940 RID: 43328
		TransformHintApple = 34225,
		// Token: 0x0400A941 RID: 43329
		VertexArrayBindingOes = 34229,
		// Token: 0x0400A942 RID: 43330
		TextureStorageHintApple = 34236,
		// Token: 0x0400A943 RID: 43331
		NumCompressedTextureFormats = 34466,
		// Token: 0x0400A944 RID: 43332
		CompressedTextureFormats,
		// Token: 0x0400A945 RID: 43333
		MaxVertexUnitsOes,
		// Token: 0x0400A946 RID: 43334
		WeightArrayTypeOes = 34473,
		// Token: 0x0400A947 RID: 43335
		WeightArrayStrideOes,
		// Token: 0x0400A948 RID: 43336
		WeightArraySizeOes,
		// Token: 0x0400A949 RID: 43337
		WeightArrayPointerOes,
		// Token: 0x0400A94A RID: 43338
		WeightArrayOes,
		// Token: 0x0400A94B RID: 43339
		Dot3Rgb,
		// Token: 0x0400A94C RID: 43340
		Dot3Rgba,
		// Token: 0x0400A94D RID: 43341
		Dot3RgbaImg = 34479,
		// Token: 0x0400A94E RID: 43342
		BufferSize = 34660,
		// Token: 0x0400A94F RID: 43343
		BufferUsage,
		// Token: 0x0400A950 RID: 43344
		AtcRgbaInterpolatedAlphaAmd = 34798,
		// Token: 0x0400A951 RID: 43345
		Gl3DcXAmd = 34809,
		// Token: 0x0400A952 RID: 43346
		Gl3DcXyAmd,
		// Token: 0x0400A953 RID: 43347
		Rgba32fExt = 34836,
		// Token: 0x0400A954 RID: 43348
		Rgb32fExt,
		// Token: 0x0400A955 RID: 43349
		Alpha32fExt,
		// Token: 0x0400A956 RID: 43350
		Luminance32fExt = 34840,
		// Token: 0x0400A957 RID: 43351
		LuminanceAlpha32fExt,
		// Token: 0x0400A958 RID: 43352
		Rgba16fExt,
		// Token: 0x0400A959 RID: 43353
		Rgb16fExt,
		// Token: 0x0400A95A RID: 43354
		Alpha16fExt,
		// Token: 0x0400A95B RID: 43355
		Luminance16fExt = 34846,
		// Token: 0x0400A95C RID: 43356
		LuminanceAlpha16fExt,
		// Token: 0x0400A95D RID: 43357
		WriteonlyRenderingQcom = 34851,
		// Token: 0x0400A95E RID: 43358
		BlendEquationAlphaOes = 34877,
		// Token: 0x0400A95F RID: 43359
		MatrixPaletteOes = 34880,
		// Token: 0x0400A960 RID: 43360
		MaxPaletteMatricesOes = 34882,
		// Token: 0x0400A961 RID: 43361
		CurrentPaletteMatrixOes,
		// Token: 0x0400A962 RID: 43362
		MatrixIndexArrayOes,
		// Token: 0x0400A963 RID: 43363
		MatrixIndexArraySizeOes = 34886,
		// Token: 0x0400A964 RID: 43364
		MatrixIndexArrayTypeOes,
		// Token: 0x0400A965 RID: 43365
		MatrixIndexArrayStrideOes,
		// Token: 0x0400A966 RID: 43366
		MatrixIndexArrayPointerOes,
		// Token: 0x0400A967 RID: 43367
		PointSpriteOes = 34913,
		// Token: 0x0400A968 RID: 43368
		CoordReplaceOes,
		// Token: 0x0400A969 RID: 43369
		ArrayBuffer = 34962,
		// Token: 0x0400A96A RID: 43370
		ElementArrayBuffer,
		// Token: 0x0400A96B RID: 43371
		ArrayBufferBinding,
		// Token: 0x0400A96C RID: 43372
		ElementArrayBufferBinding,
		// Token: 0x0400A96D RID: 43373
		VertexArrayBufferBinding,
		// Token: 0x0400A96E RID: 43374
		NormalArrayBufferBinding,
		// Token: 0x0400A96F RID: 43375
		ColorArrayBufferBinding,
		// Token: 0x0400A970 RID: 43376
		TextureCoordArrayBufferBinding = 34970,
		// Token: 0x0400A971 RID: 43377
		WeightArrayBufferBindingOes = 34974,
		// Token: 0x0400A972 RID: 43378
		WriteOnlyOes = 35001,
		// Token: 0x0400A973 RID: 43379
		BufferAccessOes = 35003,
		// Token: 0x0400A974 RID: 43380
		BufferMappedOes,
		// Token: 0x0400A975 RID: 43381
		BufferMapPointerOes,
		// Token: 0x0400A976 RID: 43382
		StaticDraw = 35044,
		// Token: 0x0400A977 RID: 43383
		DynamicDraw = 35048,
		// Token: 0x0400A978 RID: 43384
		Depth24Stencil8Oes = 35056,
		// Token: 0x0400A979 RID: 43385
		PackResampleOml = 35204,
		// Token: 0x0400A97A RID: 43386
		UnpackResampleOml,
		// Token: 0x0400A97B RID: 43387
		PointSizeArrayTypeOes = 35210,
		// Token: 0x0400A97C RID: 43388
		PointSizeArrayStrideOes,
		// Token: 0x0400A97D RID: 43389
		PointSizeArrayPointerOes,
		// Token: 0x0400A97E RID: 43390
		ModelviewMatrixFloatAsIntBitsOes,
		// Token: 0x0400A97F RID: 43391
		ProjectionMatrixFloatAsIntBitsOes,
		// Token: 0x0400A980 RID: 43392
		TextureMatrixFloatAsIntBitsOes,
		// Token: 0x0400A981 RID: 43393
		SyncObjectApple = 35411,
		// Token: 0x0400A982 RID: 43394
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x0400A983 RID: 43395
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x0400A984 RID: 43396
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x0400A985 RID: 43397
		Palette4Rgb8Oes = 35728,
		// Token: 0x0400A986 RID: 43398
		Palette4Rgba8Oes,
		// Token: 0x0400A987 RID: 43399
		Palette4R5G6B5Oes,
		// Token: 0x0400A988 RID: 43400
		Palette4Rgba4Oes,
		// Token: 0x0400A989 RID: 43401
		Palette4Rgb5A1Oes,
		// Token: 0x0400A98A RID: 43402
		Palette8Rgb8Oes,
		// Token: 0x0400A98B RID: 43403
		Palette8Rgba8Oes,
		// Token: 0x0400A98C RID: 43404
		Palette8R5G6B5Oes,
		// Token: 0x0400A98D RID: 43405
		Palette8Rgba4Oes,
		// Token: 0x0400A98E RID: 43406
		Palette8Rgb5A1Oes,
		// Token: 0x0400A98F RID: 43407
		ImplementationColorReadTypeOes,
		// Token: 0x0400A990 RID: 43408
		ImplementationColorReadFormatOes,
		// Token: 0x0400A991 RID: 43409
		PointSizeArrayOes,
		// Token: 0x0400A992 RID: 43410
		TextureCropRectOes,
		// Token: 0x0400A993 RID: 43411
		MatrixIndexArrayBufferBindingOes,
		// Token: 0x0400A994 RID: 43412
		PointSizeArrayBufferBindingOes,
		// Token: 0x0400A995 RID: 43413
		TextureWidthQcom = 35794,
		// Token: 0x0400A996 RID: 43414
		TextureHeightQcom,
		// Token: 0x0400A997 RID: 43415
		TextureDepthQcom,
		// Token: 0x0400A998 RID: 43416
		TextureInternalFormatQcom,
		// Token: 0x0400A999 RID: 43417
		TextureFormatQcom,
		// Token: 0x0400A99A RID: 43418
		TextureTypeQcom,
		// Token: 0x0400A99B RID: 43419
		TextureImageValidQcom,
		// Token: 0x0400A99C RID: 43420
		TextureNumLevelsQcom,
		// Token: 0x0400A99D RID: 43421
		TextureTargetQcom,
		// Token: 0x0400A99E RID: 43422
		TextureObjectValidQcom,
		// Token: 0x0400A99F RID: 43423
		StateRestore,
		// Token: 0x0400A9A0 RID: 43424
		CompressedRgbPvrtc4Bppv1Img = 35840,
		// Token: 0x0400A9A1 RID: 43425
		CompressedRgbPvrtc2Bppv1Img,
		// Token: 0x0400A9A2 RID: 43426
		CompressedRgbaPvrtc4Bppv1Img,
		// Token: 0x0400A9A3 RID: 43427
		CompressedRgbaPvrtc2Bppv1Img,
		// Token: 0x0400A9A4 RID: 43428
		ModulateColorImg,
		// Token: 0x0400A9A5 RID: 43429
		RecipAddSignedAlphaImg,
		// Token: 0x0400A9A6 RID: 43430
		TextureAlphaModulateImg,
		// Token: 0x0400A9A7 RID: 43431
		FactorAlphaModulateImg,
		// Token: 0x0400A9A8 RID: 43432
		FragmentAlphaModulateImg,
		// Token: 0x0400A9A9 RID: 43433
		AddBlendImg,
		// Token: 0x0400A9AA RID: 43434
		SrgbExt = 35904,
		// Token: 0x0400A9AB RID: 43435
		SrgbAlphaExt = 35906,
		// Token: 0x0400A9AC RID: 43436
		Srgb8Alpha8Ext,
		// Token: 0x0400A9AD RID: 43437
		AtcRgbAmd = 35986,
		// Token: 0x0400A9AE RID: 43438
		AtcRgbaExplicitAlphaAmd,
		// Token: 0x0400A9AF RID: 43439
		DrawFramebufferBindingApple = 36006,
		// Token: 0x0400A9B0 RID: 43440
		FramebufferBindingOes = 36006,
		// Token: 0x0400A9B1 RID: 43441
		RenderbufferBindingOes,
		// Token: 0x0400A9B2 RID: 43442
		ReadFramebufferApple,
		// Token: 0x0400A9B3 RID: 43443
		DrawFramebufferApple,
		// Token: 0x0400A9B4 RID: 43444
		ReadFramebufferBindingApple,
		// Token: 0x0400A9B5 RID: 43445
		RenderbufferSamplesApple,
		// Token: 0x0400A9B6 RID: 43446
		RenderbufferSamplesExt = 36011,
		// Token: 0x0400A9B7 RID: 43447
		FramebufferAttachmentObjectTypeOes = 36048,
		// Token: 0x0400A9B8 RID: 43448
		FramebufferAttachmentObjectNameOes,
		// Token: 0x0400A9B9 RID: 43449
		FramebufferAttachmentTextureLevelOes,
		// Token: 0x0400A9BA RID: 43450
		FramebufferAttachmentTextureCubeMapFaceOes,
		// Token: 0x0400A9BB RID: 43451
		FramebufferCompleteOes = 36053,
		// Token: 0x0400A9BC RID: 43452
		FramebufferIncompleteAttachmentOes,
		// Token: 0x0400A9BD RID: 43453
		FramebufferIncompleteMissingAttachmentOes,
		// Token: 0x0400A9BE RID: 43454
		FramebufferIncompleteDimensionsOes = 36057,
		// Token: 0x0400A9BF RID: 43455
		FramebufferIncompleteFormatsOes,
		// Token: 0x0400A9C0 RID: 43456
		FramebufferUnsupportedOes = 36061,
		// Token: 0x0400A9C1 RID: 43457
		ColorAttachment0Oes = 36064,
		// Token: 0x0400A9C2 RID: 43458
		DepthAttachmentOes = 36096,
		// Token: 0x0400A9C3 RID: 43459
		StencilAttachmentOes = 36128,
		// Token: 0x0400A9C4 RID: 43460
		FramebufferOes = 36160,
		// Token: 0x0400A9C5 RID: 43461
		RenderbufferOes,
		// Token: 0x0400A9C6 RID: 43462
		RenderbufferWidthOes,
		// Token: 0x0400A9C7 RID: 43463
		RenderbufferHeightOes,
		// Token: 0x0400A9C8 RID: 43464
		RenderbufferInternalFormatOes,
		// Token: 0x0400A9C9 RID: 43465
		StencilIndex1Oes = 36166,
		// Token: 0x0400A9CA RID: 43466
		StencilIndex4Oes,
		// Token: 0x0400A9CB RID: 43467
		StencilIndex8Oes,
		// Token: 0x0400A9CC RID: 43468
		RenderbufferRedSizeOes = 36176,
		// Token: 0x0400A9CD RID: 43469
		RenderbufferGreenSizeOes,
		// Token: 0x0400A9CE RID: 43470
		RenderbufferBlueSizeOes,
		// Token: 0x0400A9CF RID: 43471
		RenderbufferAlphaSizeOes,
		// Token: 0x0400A9D0 RID: 43472
		RenderbufferDepthSizeOes,
		// Token: 0x0400A9D1 RID: 43473
		RenderbufferStencilSizeOes,
		// Token: 0x0400A9D2 RID: 43474
		FramebufferIncompleteMultisampleApple,
		// Token: 0x0400A9D3 RID: 43475
		FramebufferIncompleteMultisampleExt = 36182,
		// Token: 0x0400A9D4 RID: 43476
		MaxSamplesApple,
		// Token: 0x0400A9D5 RID: 43477
		MaxSamplesExt = 36183,
		// Token: 0x0400A9D6 RID: 43478
		TextureGenStrOes = 36192,
		// Token: 0x0400A9D7 RID: 43479
		Rgb565Oes = 36194,
		// Token: 0x0400A9D8 RID: 43480
		Etc1Rgb8Oes = 36196,
		// Token: 0x0400A9D9 RID: 43481
		TextureExternalOes,
		// Token: 0x0400A9DA RID: 43482
		SamplerExternalOes,
		// Token: 0x0400A9DB RID: 43483
		TextureBindingExternalOes,
		// Token: 0x0400A9DC RID: 43484
		RequiredTextureImageUnitsOes,
		// Token: 0x0400A9DD RID: 43485
		FramebufferAttachmentTextureSamplesExt = 36204,
		// Token: 0x0400A9DE RID: 43486
		PerfmonGlobalModeQcom = 36768,
		// Token: 0x0400A9DF RID: 43487
		BinningControlHintQcom = 36784,
		// Token: 0x0400A9E0 RID: 43488
		ContextRobustAccessExt = 37107,
		// Token: 0x0400A9E1 RID: 43489
		MaxServerWaitTimeoutApple = 37137,
		// Token: 0x0400A9E2 RID: 43490
		ObjectTypeApple,
		// Token: 0x0400A9E3 RID: 43491
		SyncConditionApple,
		// Token: 0x0400A9E4 RID: 43492
		SyncStatusApple,
		// Token: 0x0400A9E5 RID: 43493
		SyncFlagsApple,
		// Token: 0x0400A9E6 RID: 43494
		SyncFenceApple,
		// Token: 0x0400A9E7 RID: 43495
		SyncGpuCommandsCompleteApple,
		// Token: 0x0400A9E8 RID: 43496
		UnsignaledApple,
		// Token: 0x0400A9E9 RID: 43497
		SignaledApple,
		// Token: 0x0400A9EA RID: 43498
		AlreadySignaledApple,
		// Token: 0x0400A9EB RID: 43499
		TimeoutExpiredApple,
		// Token: 0x0400A9EC RID: 43500
		ConditionSatisfiedApple,
		// Token: 0x0400A9ED RID: 43501
		WaitFailedApple,
		// Token: 0x0400A9EE RID: 43502
		TextureImmutableFormatExt = 37167,
		// Token: 0x0400A9EF RID: 43503
		RenderbufferSamplesImg = 37171,
		// Token: 0x0400A9F0 RID: 43504
		FramebufferIncompleteMultisampleImg,
		// Token: 0x0400A9F1 RID: 43505
		MaxSamplesImg,
		// Token: 0x0400A9F2 RID: 43506
		TextureSamplesImg,
		// Token: 0x0400A9F3 RID: 43507
		Bgra8Ext = 37793,
		// Token: 0x0400A9F4 RID: 43508
		AllAttribBits = -1,
		// Token: 0x0400A9F5 RID: 43509
		AllBarrierBits = -1,
		// Token: 0x0400A9F6 RID: 43510
		AllBarrierBitsExt = -1,
		// Token: 0x0400A9F7 RID: 43511
		AllShaderBits = -1,
		// Token: 0x0400A9F8 RID: 43512
		AllShaderBitsExt = -1,
		// Token: 0x0400A9F9 RID: 43513
		ClientAllAttribBits = -1,
		// Token: 0x0400A9FA RID: 43514
		QueryAllEventBitsAmd = -1,
		// Token: 0x0400A9FB RID: 43515
		TimeoutIgnoredApple = -1,
		// Token: 0x0400A9FC RID: 43516
		AmdCompressed3DcTexture = 1,
		// Token: 0x0400A9FD RID: 43517
		AmdCompressedAtcTexture = 1,
		// Token: 0x0400A9FE RID: 43518
		ExtTextureFilterAnisotropic = 1,
		// Token: 0x0400A9FF RID: 43519
		ExtTextureFormatBgra8888 = 1,
		// Token: 0x0400AA00 RID: 43520
		ImgReadFormat = 1,
		// Token: 0x0400AA01 RID: 43521
		ImgTextureCompressionPvrtc = 1,
		// Token: 0x0400AA02 RID: 43522
		ImgTextureEnvEnhancedFixedFunction = 1,
		// Token: 0x0400AA03 RID: 43523
		ImgUserClipPlane = 1,
		// Token: 0x0400AA04 RID: 43524
		LayoutLinearIntel = 1,
		// Token: 0x0400AA05 RID: 43525
		NvFence = 1,
		// Token: 0x0400AA06 RID: 43526
		OesBlendEquationSeparate = 1,
		// Token: 0x0400AA07 RID: 43527
		OesBlendFuncSeparate = 1,
		// Token: 0x0400AA08 RID: 43528
		OesBlendSubtract = 1,
		// Token: 0x0400AA09 RID: 43529
		OesByteCoordinates = 1,
		// Token: 0x0400AA0A RID: 43530
		OesCompressedEtc1Rgb8Texture = 1,
		// Token: 0x0400AA0B RID: 43531
		OesCompressedPalettedTexture = 1,
		// Token: 0x0400AA0C RID: 43532
		OesDepth24 = 1,
		// Token: 0x0400AA0D RID: 43533
		OesDepth32 = 1,
		// Token: 0x0400AA0E RID: 43534
		OesDrawTexture = 1,
		// Token: 0x0400AA0F RID: 43535
		OesEglImage = 1,
		// Token: 0x0400AA10 RID: 43536
		OesElementIndexUint = 1,
		// Token: 0x0400AA11 RID: 43537
		OesExtendedMatrixPalette = 1,
		// Token: 0x0400AA12 RID: 43538
		OesFboRenderMipmap = 1,
		// Token: 0x0400AA13 RID: 43539
		OesFixedPoint = 1,
		// Token: 0x0400AA14 RID: 43540
		OesFramebufferObject = 1,
		// Token: 0x0400AA15 RID: 43541
		OesMapbuffer = 1,
		// Token: 0x0400AA16 RID: 43542
		OesMatrixGet = 1,
		// Token: 0x0400AA17 RID: 43543
		OesMatrixPalette = 1,
		// Token: 0x0400AA18 RID: 43544
		OesPackedDepthStencil = 1,
		// Token: 0x0400AA19 RID: 43545
		OesPointSizeArray = 1,
		// Token: 0x0400AA1A RID: 43546
		OesPointSprite = 1,
		// Token: 0x0400AA1B RID: 43547
		OesQueryMatrix = 1,
		// Token: 0x0400AA1C RID: 43548
		OesReadFormat = 1,
		// Token: 0x0400AA1D RID: 43549
		OesRgb8Rgba8 = 1,
		// Token: 0x0400AA1E RID: 43550
		OesSinglePrecision = 1,
		// Token: 0x0400AA1F RID: 43551
		OesStencil1 = 1,
		// Token: 0x0400AA20 RID: 43552
		OesStencil4 = 1,
		// Token: 0x0400AA21 RID: 43553
		OesStencil8 = 1,
		// Token: 0x0400AA22 RID: 43554
		OesStencilWrap = 1,
		// Token: 0x0400AA23 RID: 43555
		OesTextureCubeMap = 1,
		// Token: 0x0400AA24 RID: 43556
		OesTextureEnvCrossbar = 1,
		// Token: 0x0400AA25 RID: 43557
		OesTextureMirroredRepeat = 1,
		// Token: 0x0400AA26 RID: 43558
		One = 1,
		// Token: 0x0400AA27 RID: 43559
		QcomDriverControl = 1,
		// Token: 0x0400AA28 RID: 43560
		QcomPerfmonGlobalMode = 1,
		// Token: 0x0400AA29 RID: 43561
		True = 1,
		// Token: 0x0400AA2A RID: 43562
		VersionEsCl10 = 1,
		// Token: 0x0400AA2B RID: 43563
		VersionEsCl11 = 1,
		// Token: 0x0400AA2C RID: 43564
		VersionEsCm10 = 1,
		// Token: 0x0400AA2D RID: 43565
		VersionEsCm11 = 1,
		// Token: 0x0400AA2E RID: 43566
		LayoutLinearCpuCachedIntel
	}
}
