using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000779 RID: 1913
	public enum All
	{
		// Token: 0x040075CB RID: 30155
		False,
		// Token: 0x040075CC RID: 30156
		LayoutDefaultIntel = 0,
		// Token: 0x040075CD RID: 30157
		NoError = 0,
		// Token: 0x040075CE RID: 30158
		None = 0,
		// Token: 0x040075CF RID: 30159
		NoneOes = 0,
		// Token: 0x040075D0 RID: 30160
		Zero = 0,
		// Token: 0x040075D1 RID: 30161
		Points = 0,
		// Token: 0x040075D2 RID: 30162
		PerfquerySingleContextIntel = 0,
		// Token: 0x040075D3 RID: 30163
		ClientPixelStoreBit,
		// Token: 0x040075D4 RID: 30164
		ColorBufferBit0Qcom = 1,
		// Token: 0x040075D5 RID: 30165
		ContextCoreProfileBit = 1,
		// Token: 0x040075D6 RID: 30166
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x040075D7 RID: 30167
		CurrentBit = 1,
		// Token: 0x040075D8 RID: 30168
		PerfqueryGlobalContextIntel = 1,
		// Token: 0x040075D9 RID: 30169
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x040075DA RID: 30170
		SyncFlushCommandsBit = 1,
		// Token: 0x040075DB RID: 30171
		SyncFlushCommandsBitApple = 1,
		// Token: 0x040075DC RID: 30172
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x040075DD RID: 30173
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x040075DE RID: 30174
		VertexShaderBit = 1,
		// Token: 0x040075DF RID: 30175
		VertexShaderBitExt = 1,
		// Token: 0x040075E0 RID: 30176
		ClientVertexArrayBit,
		// Token: 0x040075E1 RID: 30177
		ColorBufferBit1Qcom = 2,
		// Token: 0x040075E2 RID: 30178
		ContextCompatibilityProfileBit = 2,
		// Token: 0x040075E3 RID: 30179
		ContextFlagDebugBit = 2,
		// Token: 0x040075E4 RID: 30180
		ContextFlagDebugBitKhr = 2,
		// Token: 0x040075E5 RID: 30181
		ElementArrayBarrierBit = 2,
		// Token: 0x040075E6 RID: 30182
		ElementArrayBarrierBitExt = 2,
		// Token: 0x040075E7 RID: 30183
		FragmentShaderBit = 2,
		// Token: 0x040075E8 RID: 30184
		FragmentShaderBitExt = 2,
		// Token: 0x040075E9 RID: 30185
		PointBit = 2,
		// Token: 0x040075EA RID: 30186
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x040075EB RID: 30187
		ColorBufferBit2Qcom = 4,
		// Token: 0x040075EC RID: 30188
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x040075ED RID: 30189
		GeometryShaderBit = 4,
		// Token: 0x040075EE RID: 30190
		GeometryShaderBitExt = 4,
		// Token: 0x040075EF RID: 30191
		LineBit = 4,
		// Token: 0x040075F0 RID: 30192
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x040075F1 RID: 30193
		UniformBarrierBit = 4,
		// Token: 0x040075F2 RID: 30194
		UniformBarrierBitExt = 4,
		// Token: 0x040075F3 RID: 30195
		ColorBufferBit3Qcom = 8,
		// Token: 0x040075F4 RID: 30196
		PolygonBit = 8,
		// Token: 0x040075F5 RID: 30197
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x040075F6 RID: 30198
		TessControlShaderBit = 8,
		// Token: 0x040075F7 RID: 30199
		TessControlShaderBitExt = 8,
		// Token: 0x040075F8 RID: 30200
		TextureFetchBarrierBit = 8,
		// Token: 0x040075F9 RID: 30201
		TextureFetchBarrierBitExt = 8,
		// Token: 0x040075FA RID: 30202
		ColorBufferBit4Qcom = 16,
		// Token: 0x040075FB RID: 30203
		PolygonStippleBit = 16,
		// Token: 0x040075FC RID: 30204
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x040075FD RID: 30205
		TessEvaluationShaderBit = 16,
		// Token: 0x040075FE RID: 30206
		TessEvaluationShaderBitExt = 16,
		// Token: 0x040075FF RID: 30207
		ColorBufferBit5Qcom = 32,
		// Token: 0x04007600 RID: 30208
		ComputeShaderBit = 32,
		// Token: 0x04007601 RID: 30209
		PixelModeBit = 32,
		// Token: 0x04007602 RID: 30210
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04007603 RID: 30211
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04007604 RID: 30212
		ColorBufferBit6Qcom = 64,
		// Token: 0x04007605 RID: 30213
		CommandBarrierBit = 64,
		// Token: 0x04007606 RID: 30214
		CommandBarrierBitExt = 64,
		// Token: 0x04007607 RID: 30215
		LightingBit = 64,
		// Token: 0x04007608 RID: 30216
		ColorBufferBit7Qcom = 128,
		// Token: 0x04007609 RID: 30217
		FogBit = 128,
		// Token: 0x0400760A RID: 30218
		PixelBufferBarrierBit = 128,
		// Token: 0x0400760B RID: 30219
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400760C RID: 30220
		DepthBufferBit = 256,
		// Token: 0x0400760D RID: 30221
		DepthBufferBit0Qcom = 256,
		// Token: 0x0400760E RID: 30222
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400760F RID: 30223
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x04007610 RID: 30224
		AccumBufferBit = 512,
		// Token: 0x04007611 RID: 30225
		BufferUpdateBarrierBit = 512,
		// Token: 0x04007612 RID: 30226
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x04007613 RID: 30227
		DepthBufferBit1Qcom = 512,
		// Token: 0x04007614 RID: 30228
		DepthBufferBit2Qcom = 1024,
		// Token: 0x04007615 RID: 30229
		FramebufferBarrierBit = 1024,
		// Token: 0x04007616 RID: 30230
		FramebufferBarrierBitExt = 1024,
		// Token: 0x04007617 RID: 30231
		StencilBufferBit = 1024,
		// Token: 0x04007618 RID: 30232
		DepthBufferBit3Qcom = 2048,
		// Token: 0x04007619 RID: 30233
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400761A RID: 30234
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x0400761B RID: 30235
		ViewportBit = 2048,
		// Token: 0x0400761C RID: 30236
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400761D RID: 30237
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x0400761E RID: 30238
		DepthBufferBit4Qcom = 4096,
		// Token: 0x0400761F RID: 30239
		TransformBit = 4096,
		// Token: 0x04007620 RID: 30240
		DepthBufferBit5Qcom = 8192,
		// Token: 0x04007621 RID: 30241
		EnableBit = 8192,
		// Token: 0x04007622 RID: 30242
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04007623 RID: 30243
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04007624 RID: 30244
		ColorBufferBit = 16384,
		// Token: 0x04007625 RID: 30245
		DepthBufferBit6Qcom = 16384,
		// Token: 0x04007626 RID: 30246
		CoverageBufferBitNv = 32768,
		// Token: 0x04007627 RID: 30247
		DepthBufferBit7Qcom = 32768,
		// Token: 0x04007628 RID: 30248
		HintBit = 32768,
		// Token: 0x04007629 RID: 30249
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400762A RID: 30250
		MapReadBit = 1,
		// Token: 0x0400762B RID: 30251
		MapReadBitExt = 1,
		// Token: 0x0400762C RID: 30252
		Lines = 1,
		// Token: 0x0400762D RID: 30253
		EvalBit = 65536,
		// Token: 0x0400762E RID: 30254
		StencilBufferBit0Qcom = 65536,
		// Token: 0x0400762F RID: 30255
		LineLoop = 2,
		// Token: 0x04007630 RID: 30256
		MapWriteBit = 2,
		// Token: 0x04007631 RID: 30257
		MapWriteBitExt = 2,
		// Token: 0x04007632 RID: 30258
		ListBit = 131072,
		// Token: 0x04007633 RID: 30259
		StencilBufferBit1Qcom = 131072,
		// Token: 0x04007634 RID: 30260
		LineStrip = 3,
		// Token: 0x04007635 RID: 30261
		MapInvalidateRangeBit,
		// Token: 0x04007636 RID: 30262
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04007637 RID: 30263
		Triangles = 4,
		// Token: 0x04007638 RID: 30264
		StencilBufferBit2Qcom = 262144,
		// Token: 0x04007639 RID: 30265
		TextureBit = 262144,
		// Token: 0x0400763A RID: 30266
		TriangleStrip = 5,
		// Token: 0x0400763B RID: 30267
		TriangleFan,
		// Token: 0x0400763C RID: 30268
		Quads,
		// Token: 0x0400763D RID: 30269
		QuadsExt = 7,
		// Token: 0x0400763E RID: 30270
		MapInvalidateBufferBit,
		// Token: 0x0400763F RID: 30271
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04007640 RID: 30272
		QuadStrip = 8,
		// Token: 0x04007641 RID: 30273
		ScissorBit = 524288,
		// Token: 0x04007642 RID: 30274
		StencilBufferBit3Qcom = 524288,
		// Token: 0x04007643 RID: 30275
		Polygon = 9,
		// Token: 0x04007644 RID: 30276
		LinesAdjacency,
		// Token: 0x04007645 RID: 30277
		LinesAdjacencyArb = 10,
		// Token: 0x04007646 RID: 30278
		LinesAdjacencyExt = 10,
		// Token: 0x04007647 RID: 30279
		LineStripAdjacency,
		// Token: 0x04007648 RID: 30280
		LineStripAdjacencyArb = 11,
		// Token: 0x04007649 RID: 30281
		LineStripAdjacencyExt = 11,
		// Token: 0x0400764A RID: 30282
		TrianglesAdjacency,
		// Token: 0x0400764B RID: 30283
		TrianglesAdjacencyArb = 12,
		// Token: 0x0400764C RID: 30284
		TrianglesAdjacencyExt = 12,
		// Token: 0x0400764D RID: 30285
		TriangleStripAdjacency,
		// Token: 0x0400764E RID: 30286
		TriangleStripAdjacencyArb = 13,
		// Token: 0x0400764F RID: 30287
		TriangleStripAdjacencyExt = 13,
		// Token: 0x04007650 RID: 30288
		Patches,
		// Token: 0x04007651 RID: 30289
		PatchesExt = 14,
		// Token: 0x04007652 RID: 30290
		MapFlushExplicitBit = 16,
		// Token: 0x04007653 RID: 30291
		MapFlushExplicitBitExt = 16,
		// Token: 0x04007654 RID: 30292
		StencilBufferBit4Qcom = 1048576,
		// Token: 0x04007655 RID: 30293
		MapUnsynchronizedBit = 32,
		// Token: 0x04007656 RID: 30294
		MapUnsynchronizedBitExt = 32,
		// Token: 0x04007657 RID: 30295
		StencilBufferBit5Qcom = 2097152,
		// Token: 0x04007658 RID: 30296
		MapPersistentBit = 64,
		// Token: 0x04007659 RID: 30297
		StencilBufferBit6Qcom = 4194304,
		// Token: 0x0400765A RID: 30298
		MapCoherentBit = 128,
		// Token: 0x0400765B RID: 30299
		StencilBufferBit7Qcom = 8388608,
		// Token: 0x0400765C RID: 30300
		Accum = 256,
		// Token: 0x0400765D RID: 30301
		DynamicStorageBit = 256,
		// Token: 0x0400765E RID: 30302
		MultisampleBufferBit0Qcom = 16777216,
		// Token: 0x0400765F RID: 30303
		Load = 257,
		// Token: 0x04007660 RID: 30304
		Return,
		// Token: 0x04007661 RID: 30305
		Mult,
		// Token: 0x04007662 RID: 30306
		Add,
		// Token: 0x04007663 RID: 30307
		ClientStorageBit = 512,
		// Token: 0x04007664 RID: 30308
		Never = 512,
		// Token: 0x04007665 RID: 30309
		MultisampleBufferBit1Qcom = 33554432,
		// Token: 0x04007666 RID: 30310
		Less = 513,
		// Token: 0x04007667 RID: 30311
		Equal,
		// Token: 0x04007668 RID: 30312
		Lequal,
		// Token: 0x04007669 RID: 30313
		Greater,
		// Token: 0x0400766A RID: 30314
		Notequal,
		// Token: 0x0400766B RID: 30315
		Gequal,
		// Token: 0x0400766C RID: 30316
		Always,
		// Token: 0x0400766D RID: 30317
		SrcColor = 768,
		// Token: 0x0400766E RID: 30318
		OneMinusSrcColor,
		// Token: 0x0400766F RID: 30319
		SrcAlpha,
		// Token: 0x04007670 RID: 30320
		OneMinusSrcAlpha,
		// Token: 0x04007671 RID: 30321
		DstAlpha,
		// Token: 0x04007672 RID: 30322
		OneMinusDstAlpha,
		// Token: 0x04007673 RID: 30323
		DstColor,
		// Token: 0x04007674 RID: 30324
		OneMinusDstColor,
		// Token: 0x04007675 RID: 30325
		SrcAlphaSaturate,
		// Token: 0x04007676 RID: 30326
		FrontLeft = 1024,
		// Token: 0x04007677 RID: 30327
		MultisampleBufferBit2Qcom = 67108864,
		// Token: 0x04007678 RID: 30328
		FrontRight = 1025,
		// Token: 0x04007679 RID: 30329
		BackLeft,
		// Token: 0x0400767A RID: 30330
		BackRight,
		// Token: 0x0400767B RID: 30331
		Front,
		// Token: 0x0400767C RID: 30332
		Back,
		// Token: 0x0400767D RID: 30333
		Left,
		// Token: 0x0400767E RID: 30334
		Right,
		// Token: 0x0400767F RID: 30335
		FrontAndBack,
		// Token: 0x04007680 RID: 30336
		Aux0,
		// Token: 0x04007681 RID: 30337
		Aux1,
		// Token: 0x04007682 RID: 30338
		Aux2,
		// Token: 0x04007683 RID: 30339
		Aux3,
		// Token: 0x04007684 RID: 30340
		InvalidEnum = 1280,
		// Token: 0x04007685 RID: 30341
		InvalidValue,
		// Token: 0x04007686 RID: 30342
		InvalidOperation,
		// Token: 0x04007687 RID: 30343
		StackOverflow,
		// Token: 0x04007688 RID: 30344
		StackOverflowKhr = 1283,
		// Token: 0x04007689 RID: 30345
		StackUnderflow,
		// Token: 0x0400768A RID: 30346
		StackUnderflowKhr = 1284,
		// Token: 0x0400768B RID: 30347
		OutOfMemory,
		// Token: 0x0400768C RID: 30348
		InvalidFramebufferOperation,
		// Token: 0x0400768D RID: 30349
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x0400768E RID: 30350
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x0400768F RID: 30351
		Gl2D = 1536,
		// Token: 0x04007690 RID: 30352
		Gl3D,
		// Token: 0x04007691 RID: 30353
		Gl3DColor,
		// Token: 0x04007692 RID: 30354
		Gl3DColorTexture,
		// Token: 0x04007693 RID: 30355
		Gl4DColorTexture,
		// Token: 0x04007694 RID: 30356
		PassThroughToken = 1792,
		// Token: 0x04007695 RID: 30357
		PointToken,
		// Token: 0x04007696 RID: 30358
		LineToken,
		// Token: 0x04007697 RID: 30359
		PolygonToken,
		// Token: 0x04007698 RID: 30360
		BitmapToken,
		// Token: 0x04007699 RID: 30361
		DrawPixelToken,
		// Token: 0x0400769A RID: 30362
		CopyPixelToken,
		// Token: 0x0400769B RID: 30363
		LineResetToken,
		// Token: 0x0400769C RID: 30364
		Exp = 2048,
		// Token: 0x0400769D RID: 30365
		MultisampleBufferBit3Qcom = 134217728,
		// Token: 0x0400769E RID: 30366
		Exp2 = 2049,
		// Token: 0x0400769F RID: 30367
		Cw = 2304,
		// Token: 0x040076A0 RID: 30368
		Ccw,
		// Token: 0x040076A1 RID: 30369
		Coeff = 2560,
		// Token: 0x040076A2 RID: 30370
		Order,
		// Token: 0x040076A3 RID: 30371
		Domain,
		// Token: 0x040076A4 RID: 30372
		CurrentColor = 2816,
		// Token: 0x040076A5 RID: 30373
		CurrentIndex,
		// Token: 0x040076A6 RID: 30374
		CurrentNormal,
		// Token: 0x040076A7 RID: 30375
		CurrentTextureCoords,
		// Token: 0x040076A8 RID: 30376
		CurrentRasterColor,
		// Token: 0x040076A9 RID: 30377
		CurrentRasterIndex,
		// Token: 0x040076AA RID: 30378
		CurrentRasterTextureCoords,
		// Token: 0x040076AB RID: 30379
		CurrentRasterPosition,
		// Token: 0x040076AC RID: 30380
		CurrentRasterPositionValid,
		// Token: 0x040076AD RID: 30381
		CurrentRasterDistance,
		// Token: 0x040076AE RID: 30382
		PointSmooth = 2832,
		// Token: 0x040076AF RID: 30383
		PointSize,
		// Token: 0x040076B0 RID: 30384
		PointSizeRange,
		// Token: 0x040076B1 RID: 30385
		SmoothPointSizeRange = 2834,
		// Token: 0x040076B2 RID: 30386
		PointSizeGranularity,
		// Token: 0x040076B3 RID: 30387
		SmoothPointSizeGranularity = 2835,
		// Token: 0x040076B4 RID: 30388
		LineSmooth = 2848,
		// Token: 0x040076B5 RID: 30389
		LineWidth,
		// Token: 0x040076B6 RID: 30390
		LineWidthRange,
		// Token: 0x040076B7 RID: 30391
		SmoothLineWidthRange = 2850,
		// Token: 0x040076B8 RID: 30392
		LineWidthGranularity,
		// Token: 0x040076B9 RID: 30393
		SmoothLineWidthGranularity = 2851,
		// Token: 0x040076BA RID: 30394
		LineStipple,
		// Token: 0x040076BB RID: 30395
		LineStipplePattern,
		// Token: 0x040076BC RID: 30396
		LineStippleRepeat,
		// Token: 0x040076BD RID: 30397
		ListMode = 2864,
		// Token: 0x040076BE RID: 30398
		MaxListNesting,
		// Token: 0x040076BF RID: 30399
		ListBase,
		// Token: 0x040076C0 RID: 30400
		ListIndex,
		// Token: 0x040076C1 RID: 30401
		PolygonMode = 2880,
		// Token: 0x040076C2 RID: 30402
		PolygonSmooth,
		// Token: 0x040076C3 RID: 30403
		PolygonStipple,
		// Token: 0x040076C4 RID: 30404
		EdgeFlag,
		// Token: 0x040076C5 RID: 30405
		CullFace,
		// Token: 0x040076C6 RID: 30406
		CullFaceMode,
		// Token: 0x040076C7 RID: 30407
		FrontFace,
		// Token: 0x040076C8 RID: 30408
		Lighting = 2896,
		// Token: 0x040076C9 RID: 30409
		LightModelLocalViewer,
		// Token: 0x040076CA RID: 30410
		LightModelTwoSide,
		// Token: 0x040076CB RID: 30411
		LightModelAmbient,
		// Token: 0x040076CC RID: 30412
		ShadeModel,
		// Token: 0x040076CD RID: 30413
		ColorMaterialFace,
		// Token: 0x040076CE RID: 30414
		ColorMaterialParameter,
		// Token: 0x040076CF RID: 30415
		ColorMaterial,
		// Token: 0x040076D0 RID: 30416
		Fog = 2912,
		// Token: 0x040076D1 RID: 30417
		FogIndex,
		// Token: 0x040076D2 RID: 30418
		FogDensity,
		// Token: 0x040076D3 RID: 30419
		FogStart,
		// Token: 0x040076D4 RID: 30420
		FogEnd,
		// Token: 0x040076D5 RID: 30421
		FogMode,
		// Token: 0x040076D6 RID: 30422
		FogColor,
		// Token: 0x040076D7 RID: 30423
		DepthRange = 2928,
		// Token: 0x040076D8 RID: 30424
		DepthTest,
		// Token: 0x040076D9 RID: 30425
		DepthWritemask,
		// Token: 0x040076DA RID: 30426
		DepthClearValue,
		// Token: 0x040076DB RID: 30427
		DepthFunc,
		// Token: 0x040076DC RID: 30428
		AccumClearValue = 2944,
		// Token: 0x040076DD RID: 30429
		StencilTest = 2960,
		// Token: 0x040076DE RID: 30430
		StencilClearValue,
		// Token: 0x040076DF RID: 30431
		StencilFunc,
		// Token: 0x040076E0 RID: 30432
		StencilValueMask,
		// Token: 0x040076E1 RID: 30433
		StencilFail,
		// Token: 0x040076E2 RID: 30434
		StencilPassDepthFail,
		// Token: 0x040076E3 RID: 30435
		StencilPassDepthPass,
		// Token: 0x040076E4 RID: 30436
		StencilRef,
		// Token: 0x040076E5 RID: 30437
		StencilWritemask,
		// Token: 0x040076E6 RID: 30438
		MatrixMode = 2976,
		// Token: 0x040076E7 RID: 30439
		Normalize,
		// Token: 0x040076E8 RID: 30440
		Viewport,
		// Token: 0x040076E9 RID: 30441
		Modelview0StackDepthExt,
		// Token: 0x040076EA RID: 30442
		ModelviewStackDepth = 2979,
		// Token: 0x040076EB RID: 30443
		ProjectionStackDepth,
		// Token: 0x040076EC RID: 30444
		TextureStackDepth,
		// Token: 0x040076ED RID: 30445
		Modelview0MatrixExt,
		// Token: 0x040076EE RID: 30446
		ModelviewMatrix = 2982,
		// Token: 0x040076EF RID: 30447
		ProjectionMatrix,
		// Token: 0x040076F0 RID: 30448
		TextureMatrix,
		// Token: 0x040076F1 RID: 30449
		AttribStackDepth = 2992,
		// Token: 0x040076F2 RID: 30450
		ClientAttribStackDepth,
		// Token: 0x040076F3 RID: 30451
		AlphaTest = 3008,
		// Token: 0x040076F4 RID: 30452
		AlphaTestQcom = 3008,
		// Token: 0x040076F5 RID: 30453
		AlphaTestFunc,
		// Token: 0x040076F6 RID: 30454
		AlphaTestFuncQcom = 3009,
		// Token: 0x040076F7 RID: 30455
		AlphaTestRef,
		// Token: 0x040076F8 RID: 30456
		AlphaTestRefQcom = 3010,
		// Token: 0x040076F9 RID: 30457
		Dither = 3024,
		// Token: 0x040076FA RID: 30458
		BlendDst = 3040,
		// Token: 0x040076FB RID: 30459
		BlendSrc,
		// Token: 0x040076FC RID: 30460
		Blend,
		// Token: 0x040076FD RID: 30461
		LogicOpMode = 3056,
		// Token: 0x040076FE RID: 30462
		IndexLogicOp,
		// Token: 0x040076FF RID: 30463
		LogicOp = 3057,
		// Token: 0x04007700 RID: 30464
		ColorLogicOp,
		// Token: 0x04007701 RID: 30465
		AuxBuffers = 3072,
		// Token: 0x04007702 RID: 30466
		DrawBuffer,
		// Token: 0x04007703 RID: 30467
		DrawBufferExt = 3073,
		// Token: 0x04007704 RID: 30468
		ReadBuffer,
		// Token: 0x04007705 RID: 30469
		ReadBufferExt = 3074,
		// Token: 0x04007706 RID: 30470
		ReadBufferNv = 3074,
		// Token: 0x04007707 RID: 30471
		ScissorBox = 3088,
		// Token: 0x04007708 RID: 30472
		ScissorTest,
		// Token: 0x04007709 RID: 30473
		IndexClearValue = 3104,
		// Token: 0x0400770A RID: 30474
		IndexWritemask,
		// Token: 0x0400770B RID: 30475
		ColorClearValue,
		// Token: 0x0400770C RID: 30476
		ColorWritemask,
		// Token: 0x0400770D RID: 30477
		IndexMode = 3120,
		// Token: 0x0400770E RID: 30478
		RgbaMode,
		// Token: 0x0400770F RID: 30479
		Doublebuffer,
		// Token: 0x04007710 RID: 30480
		Stereo,
		// Token: 0x04007711 RID: 30481
		RenderMode = 3136,
		// Token: 0x04007712 RID: 30482
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04007713 RID: 30483
		PointSmoothHint,
		// Token: 0x04007714 RID: 30484
		LineSmoothHint,
		// Token: 0x04007715 RID: 30485
		PolygonSmoothHint,
		// Token: 0x04007716 RID: 30486
		FogHint,
		// Token: 0x04007717 RID: 30487
		TextureGenS = 3168,
		// Token: 0x04007718 RID: 30488
		TextureGenT,
		// Token: 0x04007719 RID: 30489
		TextureGenR,
		// Token: 0x0400771A RID: 30490
		TextureGenQ,
		// Token: 0x0400771B RID: 30491
		PixelMapIToI = 3184,
		// Token: 0x0400771C RID: 30492
		PixelMapSToS,
		// Token: 0x0400771D RID: 30493
		PixelMapIToR,
		// Token: 0x0400771E RID: 30494
		PixelMapIToG,
		// Token: 0x0400771F RID: 30495
		PixelMapIToB,
		// Token: 0x04007720 RID: 30496
		PixelMapIToA,
		// Token: 0x04007721 RID: 30497
		PixelMapRToR,
		// Token: 0x04007722 RID: 30498
		PixelMapGToG,
		// Token: 0x04007723 RID: 30499
		PixelMapBToB,
		// Token: 0x04007724 RID: 30500
		PixelMapAToA,
		// Token: 0x04007725 RID: 30501
		PixelMapIToISize = 3248,
		// Token: 0x04007726 RID: 30502
		PixelMapSToSSize,
		// Token: 0x04007727 RID: 30503
		PixelMapIToRSize,
		// Token: 0x04007728 RID: 30504
		PixelMapIToGSize,
		// Token: 0x04007729 RID: 30505
		PixelMapIToBSize,
		// Token: 0x0400772A RID: 30506
		PixelMapIToASize,
		// Token: 0x0400772B RID: 30507
		PixelMapRToRSize,
		// Token: 0x0400772C RID: 30508
		PixelMapGToGSize,
		// Token: 0x0400772D RID: 30509
		PixelMapBToBSize,
		// Token: 0x0400772E RID: 30510
		PixelMapAToASize,
		// Token: 0x0400772F RID: 30511
		UnpackSwapBytes = 3312,
		// Token: 0x04007730 RID: 30512
		UnpackLsbFirst,
		// Token: 0x04007731 RID: 30513
		UnpackRowLength,
		// Token: 0x04007732 RID: 30514
		UnpackRowLengthExt = 3314,
		// Token: 0x04007733 RID: 30515
		UnpackSkipRows,
		// Token: 0x04007734 RID: 30516
		UnpackSkipRowsExt = 3315,
		// Token: 0x04007735 RID: 30517
		UnpackSkipPixels,
		// Token: 0x04007736 RID: 30518
		UnpackSkipPixelsExt = 3316,
		// Token: 0x04007737 RID: 30519
		UnpackAlignment,
		// Token: 0x04007738 RID: 30520
		PackSwapBytes = 3328,
		// Token: 0x04007739 RID: 30521
		PackLsbFirst,
		// Token: 0x0400773A RID: 30522
		PackRowLength,
		// Token: 0x0400773B RID: 30523
		PackSkipRows,
		// Token: 0x0400773C RID: 30524
		PackSkipPixels,
		// Token: 0x0400773D RID: 30525
		PackAlignment,
		// Token: 0x0400773E RID: 30526
		MapColor = 3344,
		// Token: 0x0400773F RID: 30527
		MapStencil,
		// Token: 0x04007740 RID: 30528
		IndexShift,
		// Token: 0x04007741 RID: 30529
		IndexOffset,
		// Token: 0x04007742 RID: 30530
		RedScale,
		// Token: 0x04007743 RID: 30531
		RedBias,
		// Token: 0x04007744 RID: 30532
		ZoomX,
		// Token: 0x04007745 RID: 30533
		ZoomY,
		// Token: 0x04007746 RID: 30534
		GreenScale,
		// Token: 0x04007747 RID: 30535
		GreenBias,
		// Token: 0x04007748 RID: 30536
		BlueScale,
		// Token: 0x04007749 RID: 30537
		BlueBias,
		// Token: 0x0400774A RID: 30538
		AlphaScale,
		// Token: 0x0400774B RID: 30539
		AlphaBias,
		// Token: 0x0400774C RID: 30540
		DepthScale,
		// Token: 0x0400774D RID: 30541
		DepthBias,
		// Token: 0x0400774E RID: 30542
		MaxEvalOrder = 3376,
		// Token: 0x0400774F RID: 30543
		MaxLights,
		// Token: 0x04007750 RID: 30544
		MaxClipDistances,
		// Token: 0x04007751 RID: 30545
		MaxClipPlanes = 3378,
		// Token: 0x04007752 RID: 30546
		MaxTextureSize,
		// Token: 0x04007753 RID: 30547
		MaxPixelMapTable,
		// Token: 0x04007754 RID: 30548
		MaxAttribStackDepth,
		// Token: 0x04007755 RID: 30549
		MaxModelviewStackDepth,
		// Token: 0x04007756 RID: 30550
		MaxNameStackDepth,
		// Token: 0x04007757 RID: 30551
		MaxProjectionStackDepth,
		// Token: 0x04007758 RID: 30552
		MaxTextureStackDepth,
		// Token: 0x04007759 RID: 30553
		MaxViewportDims,
		// Token: 0x0400775A RID: 30554
		MaxClientAttribStackDepth,
		// Token: 0x0400775B RID: 30555
		SubpixelBits = 3408,
		// Token: 0x0400775C RID: 30556
		IndexBits,
		// Token: 0x0400775D RID: 30557
		RedBits,
		// Token: 0x0400775E RID: 30558
		GreenBits,
		// Token: 0x0400775F RID: 30559
		BlueBits,
		// Token: 0x04007760 RID: 30560
		AlphaBits,
		// Token: 0x04007761 RID: 30561
		DepthBits,
		// Token: 0x04007762 RID: 30562
		StencilBits,
		// Token: 0x04007763 RID: 30563
		AccumRedBits,
		// Token: 0x04007764 RID: 30564
		AccumGreenBits,
		// Token: 0x04007765 RID: 30565
		AccumBlueBits,
		// Token: 0x04007766 RID: 30566
		AccumAlphaBits,
		// Token: 0x04007767 RID: 30567
		NameStackDepth = 3440,
		// Token: 0x04007768 RID: 30568
		AutoNormal = 3456,
		// Token: 0x04007769 RID: 30569
		Map1Color4 = 3472,
		// Token: 0x0400776A RID: 30570
		Map1Index,
		// Token: 0x0400776B RID: 30571
		Map1Normal,
		// Token: 0x0400776C RID: 30572
		Map1TextureCoord1,
		// Token: 0x0400776D RID: 30573
		Map1TextureCoord2,
		// Token: 0x0400776E RID: 30574
		Map1TextureCoord3,
		// Token: 0x0400776F RID: 30575
		Map1TextureCoord4,
		// Token: 0x04007770 RID: 30576
		Map1Vertex3,
		// Token: 0x04007771 RID: 30577
		Map1Vertex4,
		// Token: 0x04007772 RID: 30578
		Map2Color4 = 3504,
		// Token: 0x04007773 RID: 30579
		Map2Index,
		// Token: 0x04007774 RID: 30580
		Map2Normal,
		// Token: 0x04007775 RID: 30581
		Map2TextureCoord1,
		// Token: 0x04007776 RID: 30582
		Map2TextureCoord2,
		// Token: 0x04007777 RID: 30583
		Map2TextureCoord3,
		// Token: 0x04007778 RID: 30584
		Map2TextureCoord4,
		// Token: 0x04007779 RID: 30585
		Map2Vertex3,
		// Token: 0x0400777A RID: 30586
		Map2Vertex4,
		// Token: 0x0400777B RID: 30587
		Map1GridDomain = 3536,
		// Token: 0x0400777C RID: 30588
		Map1GridSegments,
		// Token: 0x0400777D RID: 30589
		Map2GridDomain,
		// Token: 0x0400777E RID: 30590
		Map2GridSegments,
		// Token: 0x0400777F RID: 30591
		Texture1D = 3552,
		// Token: 0x04007780 RID: 30592
		Texture2D,
		// Token: 0x04007781 RID: 30593
		FeedbackBufferPointer = 3568,
		// Token: 0x04007782 RID: 30594
		FeedbackBufferSize,
		// Token: 0x04007783 RID: 30595
		FeedbackBufferType,
		// Token: 0x04007784 RID: 30596
		SelectionBufferPointer,
		// Token: 0x04007785 RID: 30597
		SelectionBufferSize,
		// Token: 0x04007786 RID: 30598
		TextureWidth = 4096,
		// Token: 0x04007787 RID: 30599
		MultisampleBufferBit4Qcom = 268435456,
		// Token: 0x04007788 RID: 30600
		TextureHeight = 4097,
		// Token: 0x04007789 RID: 30601
		TextureComponents = 4099,
		// Token: 0x0400778A RID: 30602
		TextureInternalFormat = 4099,
		// Token: 0x0400778B RID: 30603
		TextureBorderColor,
		// Token: 0x0400778C RID: 30604
		TextureBorderColorExt = 4100,
		// Token: 0x0400778D RID: 30605
		TextureBorderColorNv = 4100,
		// Token: 0x0400778E RID: 30606
		TextureBorder,
		// Token: 0x0400778F RID: 30607
		DontCare = 4352,
		// Token: 0x04007790 RID: 30608
		Fastest,
		// Token: 0x04007791 RID: 30609
		Nicest,
		// Token: 0x04007792 RID: 30610
		Ambient = 4608,
		// Token: 0x04007793 RID: 30611
		Diffuse,
		// Token: 0x04007794 RID: 30612
		Specular,
		// Token: 0x04007795 RID: 30613
		Position,
		// Token: 0x04007796 RID: 30614
		SpotDirection,
		// Token: 0x04007797 RID: 30615
		SpotExponent,
		// Token: 0x04007798 RID: 30616
		SpotCutoff,
		// Token: 0x04007799 RID: 30617
		ConstantAttenuation,
		// Token: 0x0400779A RID: 30618
		LinearAttenuation,
		// Token: 0x0400779B RID: 30619
		QuadraticAttenuation,
		// Token: 0x0400779C RID: 30620
		Compile = 4864,
		// Token: 0x0400779D RID: 30621
		CompileAndExecute,
		// Token: 0x0400779E RID: 30622
		Byte = 5120,
		// Token: 0x0400779F RID: 30623
		UnsignedByte,
		// Token: 0x040077A0 RID: 30624
		Short,
		// Token: 0x040077A1 RID: 30625
		UnsignedShort,
		// Token: 0x040077A2 RID: 30626
		Int,
		// Token: 0x040077A3 RID: 30627
		UnsignedInt,
		// Token: 0x040077A4 RID: 30628
		Float,
		// Token: 0x040077A5 RID: 30629
		Gl2Bytes,
		// Token: 0x040077A6 RID: 30630
		Gl3Bytes,
		// Token: 0x040077A7 RID: 30631
		Gl4Bytes,
		// Token: 0x040077A8 RID: 30632
		Double,
		// Token: 0x040077A9 RID: 30633
		HalfFloat,
		// Token: 0x040077AA RID: 30634
		Fixed,
		// Token: 0x040077AB RID: 30635
		Clear = 5376,
		// Token: 0x040077AC RID: 30636
		And,
		// Token: 0x040077AD RID: 30637
		AndReverse,
		// Token: 0x040077AE RID: 30638
		Copy,
		// Token: 0x040077AF RID: 30639
		AndInverted,
		// Token: 0x040077B0 RID: 30640
		Noop,
		// Token: 0x040077B1 RID: 30641
		Xor,
		// Token: 0x040077B2 RID: 30642
		XorNv = 5382,
		// Token: 0x040077B3 RID: 30643
		Or,
		// Token: 0x040077B4 RID: 30644
		Nor,
		// Token: 0x040077B5 RID: 30645
		Equiv,
		// Token: 0x040077B6 RID: 30646
		Invert,
		// Token: 0x040077B7 RID: 30647
		OrReverse,
		// Token: 0x040077B8 RID: 30648
		CopyInverted,
		// Token: 0x040077B9 RID: 30649
		OrInverted,
		// Token: 0x040077BA RID: 30650
		Nand,
		// Token: 0x040077BB RID: 30651
		Set,
		// Token: 0x040077BC RID: 30652
		Emission = 5632,
		// Token: 0x040077BD RID: 30653
		Shininess,
		// Token: 0x040077BE RID: 30654
		AmbientAndDiffuse,
		// Token: 0x040077BF RID: 30655
		ColorIndexes,
		// Token: 0x040077C0 RID: 30656
		Modelview = 5888,
		// Token: 0x040077C1 RID: 30657
		Modelview0Ext = 5888,
		// Token: 0x040077C2 RID: 30658
		Projection,
		// Token: 0x040077C3 RID: 30659
		Texture,
		// Token: 0x040077C4 RID: 30660
		Color = 6144,
		// Token: 0x040077C5 RID: 30661
		ColorExt = 6144,
		// Token: 0x040077C6 RID: 30662
		Depth,
		// Token: 0x040077C7 RID: 30663
		DepthExt = 6145,
		// Token: 0x040077C8 RID: 30664
		Stencil,
		// Token: 0x040077C9 RID: 30665
		StencilExt = 6146,
		// Token: 0x040077CA RID: 30666
		ColorIndex = 6400,
		// Token: 0x040077CB RID: 30667
		StencilIndex,
		// Token: 0x040077CC RID: 30668
		StencilIndexOes = 6401,
		// Token: 0x040077CD RID: 30669
		DepthComponent,
		// Token: 0x040077CE RID: 30670
		Red,
		// Token: 0x040077CF RID: 30671
		RedExt = 6403,
		// Token: 0x040077D0 RID: 30672
		RedNv = 6403,
		// Token: 0x040077D1 RID: 30673
		Green,
		// Token: 0x040077D2 RID: 30674
		GreenNv = 6404,
		// Token: 0x040077D3 RID: 30675
		Blue,
		// Token: 0x040077D4 RID: 30676
		BlueNv = 6405,
		// Token: 0x040077D5 RID: 30677
		Alpha,
		// Token: 0x040077D6 RID: 30678
		Rgb,
		// Token: 0x040077D7 RID: 30679
		Rgba,
		// Token: 0x040077D8 RID: 30680
		Luminance,
		// Token: 0x040077D9 RID: 30681
		LuminanceAlpha,
		// Token: 0x040077DA RID: 30682
		Bitmap = 6656,
		// Token: 0x040077DB RID: 30683
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x040077DC RID: 30684
		ConserveMemoryHintPgi = 107005,
		// Token: 0x040077DD RID: 30685
		ReclaimMemoryHintPgi,
		// Token: 0x040077DE RID: 30686
		NativeGraphicsBeginHintPgi = 107011,
		// Token: 0x040077DF RID: 30687
		NativeGraphicsEndHintPgi,
		// Token: 0x040077E0 RID: 30688
		AlwaysFastHintPgi = 107020,
		// Token: 0x040077E1 RID: 30689
		AlwaysSoftHintPgi,
		// Token: 0x040077E2 RID: 30690
		AllowDrawObjHintPgi,
		// Token: 0x040077E3 RID: 30691
		AllowDrawWinHintPgi,
		// Token: 0x040077E4 RID: 30692
		AllowDrawFrgHintPgi,
		// Token: 0x040077E5 RID: 30693
		AllowDrawMemHintPgi,
		// Token: 0x040077E6 RID: 30694
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x040077E7 RID: 30695
		StrictLightingHintPgi,
		// Token: 0x040077E8 RID: 30696
		StrictScissorHintPgi,
		// Token: 0x040077E9 RID: 30697
		FullStippleHintPgi,
		// Token: 0x040077EA RID: 30698
		ClipNearHintPgi = 107040,
		// Token: 0x040077EB RID: 30699
		ClipFarHintPgi,
		// Token: 0x040077EC RID: 30700
		WideLineHintPgi,
		// Token: 0x040077ED RID: 30701
		BackNormalsHintPgi,
		// Token: 0x040077EE RID: 30702
		VertexDataHintPgi = 107050,
		// Token: 0x040077EF RID: 30703
		VertexConsistentHintPgi,
		// Token: 0x040077F0 RID: 30704
		MaterialSideHintPgi,
		// Token: 0x040077F1 RID: 30705
		MaxVertexHintPgi,
		// Token: 0x040077F2 RID: 30706
		Point = 6912,
		// Token: 0x040077F3 RID: 30707
		Line,
		// Token: 0x040077F4 RID: 30708
		Fill,
		// Token: 0x040077F5 RID: 30709
		Render = 7168,
		// Token: 0x040077F6 RID: 30710
		Feedback,
		// Token: 0x040077F7 RID: 30711
		Select,
		// Token: 0x040077F8 RID: 30712
		Flat = 7424,
		// Token: 0x040077F9 RID: 30713
		Smooth,
		// Token: 0x040077FA RID: 30714
		Keep = 7680,
		// Token: 0x040077FB RID: 30715
		Replace,
		// Token: 0x040077FC RID: 30716
		Incr,
		// Token: 0x040077FD RID: 30717
		Decr,
		// Token: 0x040077FE RID: 30718
		Vendor = 7936,
		// Token: 0x040077FF RID: 30719
		Renderer,
		// Token: 0x04007800 RID: 30720
		Version,
		// Token: 0x04007801 RID: 30721
		Extensions,
		// Token: 0x04007802 RID: 30722
		S = 8192,
		// Token: 0x04007803 RID: 30723
		MultisampleBit = 536870912,
		// Token: 0x04007804 RID: 30724
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04007805 RID: 30725
		MultisampleBitArb = 536870912,
		// Token: 0x04007806 RID: 30726
		MultisampleBitExt = 536870912,
		// Token: 0x04007807 RID: 30727
		MultisampleBufferBit5Qcom = 536870912,
		// Token: 0x04007808 RID: 30728
		T = 8193,
		// Token: 0x04007809 RID: 30729
		R,
		// Token: 0x0400780A RID: 30730
		Q,
		// Token: 0x0400780B RID: 30731
		Modulate = 8448,
		// Token: 0x0400780C RID: 30732
		Decal,
		// Token: 0x0400780D RID: 30733
		TextureEnvMode = 8704,
		// Token: 0x0400780E RID: 30734
		TextureEnvColor,
		// Token: 0x0400780F RID: 30735
		TextureEnv = 8960,
		// Token: 0x04007810 RID: 30736
		EyeLinear = 9216,
		// Token: 0x04007811 RID: 30737
		ObjectLinear,
		// Token: 0x04007812 RID: 30738
		SphereMap,
		// Token: 0x04007813 RID: 30739
		TextureGenMode = 9472,
		// Token: 0x04007814 RID: 30740
		ObjectPlane,
		// Token: 0x04007815 RID: 30741
		EyePlane,
		// Token: 0x04007816 RID: 30742
		Nearest = 9728,
		// Token: 0x04007817 RID: 30743
		Linear,
		// Token: 0x04007818 RID: 30744
		NearestMipmapNearest = 9984,
		// Token: 0x04007819 RID: 30745
		LinearMipmapNearest,
		// Token: 0x0400781A RID: 30746
		NearestMipmapLinear,
		// Token: 0x0400781B RID: 30747
		LinearMipmapLinear,
		// Token: 0x0400781C RID: 30748
		TextureMagFilter = 10240,
		// Token: 0x0400781D RID: 30749
		TextureMinFilter,
		// Token: 0x0400781E RID: 30750
		TextureWrapS,
		// Token: 0x0400781F RID: 30751
		TextureWrapT,
		// Token: 0x04007820 RID: 30752
		Clamp = 10496,
		// Token: 0x04007821 RID: 30753
		Repeat,
		// Token: 0x04007822 RID: 30754
		PolygonOffsetUnits = 10752,
		// Token: 0x04007823 RID: 30755
		PolygonOffsetPoint,
		// Token: 0x04007824 RID: 30756
		PolygonOffsetLine,
		// Token: 0x04007825 RID: 30757
		R3G3B2 = 10768,
		// Token: 0x04007826 RID: 30758
		V2f = 10784,
		// Token: 0x04007827 RID: 30759
		V3f,
		// Token: 0x04007828 RID: 30760
		C4ubV2f,
		// Token: 0x04007829 RID: 30761
		C4ubV3f,
		// Token: 0x0400782A RID: 30762
		C3fV3f,
		// Token: 0x0400782B RID: 30763
		N3fV3f,
		// Token: 0x0400782C RID: 30764
		C4fN3fV3f,
		// Token: 0x0400782D RID: 30765
		T2fV3f,
		// Token: 0x0400782E RID: 30766
		T4fV4f,
		// Token: 0x0400782F RID: 30767
		T2fC4ubV3f,
		// Token: 0x04007830 RID: 30768
		T2fC3fV3f,
		// Token: 0x04007831 RID: 30769
		T2fN3fV3f,
		// Token: 0x04007832 RID: 30770
		T2fC4fN3fV3f,
		// Token: 0x04007833 RID: 30771
		T4fC4fN3fV4f,
		// Token: 0x04007834 RID: 30772
		ClipDistance0 = 12288,
		// Token: 0x04007835 RID: 30773
		ClipPlane0 = 12288,
		// Token: 0x04007836 RID: 30774
		ClipDistance1,
		// Token: 0x04007837 RID: 30775
		ClipPlane1 = 12289,
		// Token: 0x04007838 RID: 30776
		ClipDistance2,
		// Token: 0x04007839 RID: 30777
		ClipPlane2 = 12290,
		// Token: 0x0400783A RID: 30778
		ClipDistance3,
		// Token: 0x0400783B RID: 30779
		ClipPlane3 = 12291,
		// Token: 0x0400783C RID: 30780
		ClipDistance4,
		// Token: 0x0400783D RID: 30781
		ClipPlane4 = 12292,
		// Token: 0x0400783E RID: 30782
		ClipDistance5,
		// Token: 0x0400783F RID: 30783
		ClipPlane5 = 12293,
		// Token: 0x04007840 RID: 30784
		ClipDistance6,
		// Token: 0x04007841 RID: 30785
		ClipDistance7,
		// Token: 0x04007842 RID: 30786
		Light0 = 16384,
		// Token: 0x04007843 RID: 30787
		MultisampleBufferBit6Qcom = 1073741824,
		// Token: 0x04007844 RID: 30788
		Light1 = 16385,
		// Token: 0x04007845 RID: 30789
		Light2,
		// Token: 0x04007846 RID: 30790
		Light3,
		// Token: 0x04007847 RID: 30791
		Light4,
		// Token: 0x04007848 RID: 30792
		Light5,
		// Token: 0x04007849 RID: 30793
		Light6,
		// Token: 0x0400784A RID: 30794
		Light7,
		// Token: 0x0400784B RID: 30795
		AbgrExt = 32768,
		// Token: 0x0400784C RID: 30796
		MultisampleBufferBit7Qcom = -2147483648,
		// Token: 0x0400784D RID: 30797
		ConstantColor = 32769,
		// Token: 0x0400784E RID: 30798
		ConstantColorExt = 32769,
		// Token: 0x0400784F RID: 30799
		OneMinusConstantColor,
		// Token: 0x04007850 RID: 30800
		OneMinusConstantColorExt = 32770,
		// Token: 0x04007851 RID: 30801
		ConstantAlpha,
		// Token: 0x04007852 RID: 30802
		ConstantAlphaExt = 32771,
		// Token: 0x04007853 RID: 30803
		OneMinusConstantAlpha,
		// Token: 0x04007854 RID: 30804
		OneMinusConstantAlphaExt = 32772,
		// Token: 0x04007855 RID: 30805
		BlendColor,
		// Token: 0x04007856 RID: 30806
		BlendColorExt = 32773,
		// Token: 0x04007857 RID: 30807
		FuncAdd,
		// Token: 0x04007858 RID: 30808
		FuncAddExt = 32774,
		// Token: 0x04007859 RID: 30809
		Min,
		// Token: 0x0400785A RID: 30810
		MinExt = 32775,
		// Token: 0x0400785B RID: 30811
		Max,
		// Token: 0x0400785C RID: 30812
		MaxExt = 32776,
		// Token: 0x0400785D RID: 30813
		BlendEquation,
		// Token: 0x0400785E RID: 30814
		BlendEquationExt = 32777,
		// Token: 0x0400785F RID: 30815
		BlendEquationRgb = 32777,
		// Token: 0x04007860 RID: 30816
		FuncSubtract,
		// Token: 0x04007861 RID: 30817
		FuncSubtractExt = 32778,
		// Token: 0x04007862 RID: 30818
		FuncReverseSubtract,
		// Token: 0x04007863 RID: 30819
		FuncReverseSubtractExt = 32779,
		// Token: 0x04007864 RID: 30820
		CmykExt,
		// Token: 0x04007865 RID: 30821
		CmykaExt,
		// Token: 0x04007866 RID: 30822
		PackCmykHintExt,
		// Token: 0x04007867 RID: 30823
		UnpackCmykHintExt,
		// Token: 0x04007868 RID: 30824
		Convolution1D,
		// Token: 0x04007869 RID: 30825
		Convolution1DExt = 32784,
		// Token: 0x0400786A RID: 30826
		Convolution2D,
		// Token: 0x0400786B RID: 30827
		Convolution2DExt = 32785,
		// Token: 0x0400786C RID: 30828
		Separable2D,
		// Token: 0x0400786D RID: 30829
		Separable2DExt = 32786,
		// Token: 0x0400786E RID: 30830
		ConvolutionBorderMode,
		// Token: 0x0400786F RID: 30831
		ConvolutionBorderModeExt = 32787,
		// Token: 0x04007870 RID: 30832
		ConvolutionFilterScale,
		// Token: 0x04007871 RID: 30833
		ConvolutionFilterScaleExt = 32788,
		// Token: 0x04007872 RID: 30834
		ConvolutionFilterBias,
		// Token: 0x04007873 RID: 30835
		ConvolutionFilterBiasExt = 32789,
		// Token: 0x04007874 RID: 30836
		Reduce,
		// Token: 0x04007875 RID: 30837
		ReduceExt = 32790,
		// Token: 0x04007876 RID: 30838
		ConvolutionFormatExt,
		// Token: 0x04007877 RID: 30839
		ConvolutionWidthExt,
		// Token: 0x04007878 RID: 30840
		ConvolutionHeightExt,
		// Token: 0x04007879 RID: 30841
		MaxConvolutionWidthExt,
		// Token: 0x0400787A RID: 30842
		MaxConvolutionHeightExt,
		// Token: 0x0400787B RID: 30843
		PostConvolutionRedScale,
		// Token: 0x0400787C RID: 30844
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x0400787D RID: 30845
		PostConvolutionGreenScale,
		// Token: 0x0400787E RID: 30846
		PostConvolutionGreenScaleExt = 32797,
		// Token: 0x0400787F RID: 30847
		PostConvolutionBlueScale,
		// Token: 0x04007880 RID: 30848
		PostConvolutionBlueScaleExt = 32798,
		// Token: 0x04007881 RID: 30849
		PostConvolutionAlphaScale,
		// Token: 0x04007882 RID: 30850
		PostConvolutionAlphaScaleExt = 32799,
		// Token: 0x04007883 RID: 30851
		PostConvolutionRedBias,
		// Token: 0x04007884 RID: 30852
		PostConvolutionRedBiasExt = 32800,
		// Token: 0x04007885 RID: 30853
		PostConvolutionGreenBias,
		// Token: 0x04007886 RID: 30854
		PostConvolutionGreenBiasExt = 32801,
		// Token: 0x04007887 RID: 30855
		PostConvolutionBlueBias,
		// Token: 0x04007888 RID: 30856
		PostConvolutionBlueBiasExt = 32802,
		// Token: 0x04007889 RID: 30857
		PostConvolutionAlphaBias,
		// Token: 0x0400788A RID: 30858
		PostConvolutionAlphaBiasExt = 32803,
		// Token: 0x0400788B RID: 30859
		Histogram,
		// Token: 0x0400788C RID: 30860
		HistogramExt = 32804,
		// Token: 0x0400788D RID: 30861
		ProxyHistogram,
		// Token: 0x0400788E RID: 30862
		ProxyHistogramExt = 32805,
		// Token: 0x0400788F RID: 30863
		HistogramWidthExt,
		// Token: 0x04007890 RID: 30864
		HistogramFormatExt,
		// Token: 0x04007891 RID: 30865
		HistogramRedSizeExt,
		// Token: 0x04007892 RID: 30866
		HistogramGreenSizeExt,
		// Token: 0x04007893 RID: 30867
		HistogramBlueSizeExt,
		// Token: 0x04007894 RID: 30868
		HistogramAlphaSizeExt,
		// Token: 0x04007895 RID: 30869
		HistogramLuminanceSizeExt,
		// Token: 0x04007896 RID: 30870
		HistogramSinkExt,
		// Token: 0x04007897 RID: 30871
		Minmax,
		// Token: 0x04007898 RID: 30872
		MinmaxExt = 32814,
		// Token: 0x04007899 RID: 30873
		MinmaxFormat,
		// Token: 0x0400789A RID: 30874
		MinmaxFormatExt = 32815,
		// Token: 0x0400789B RID: 30875
		MinmaxSink,
		// Token: 0x0400789C RID: 30876
		MinmaxSinkExt = 32816,
		// Token: 0x0400789D RID: 30877
		TableTooLarge,
		// Token: 0x0400789E RID: 30878
		TableTooLargeExt = 32817,
		// Token: 0x0400789F RID: 30879
		UnsignedByte332,
		// Token: 0x040078A0 RID: 30880
		UnsignedByte332Ext = 32818,
		// Token: 0x040078A1 RID: 30881
		UnsignedShort4444,
		// Token: 0x040078A2 RID: 30882
		UnsignedShort4444Ext = 32819,
		// Token: 0x040078A3 RID: 30883
		UnsignedShort5551,
		// Token: 0x040078A4 RID: 30884
		UnsignedShort5551Ext = 32820,
		// Token: 0x040078A5 RID: 30885
		UnsignedInt8888,
		// Token: 0x040078A6 RID: 30886
		UnsignedInt8888Ext = 32821,
		// Token: 0x040078A7 RID: 30887
		UnsignedInt1010102,
		// Token: 0x040078A8 RID: 30888
		UnsignedInt1010102Ext = 32822,
		// Token: 0x040078A9 RID: 30889
		PolygonOffsetFill,
		// Token: 0x040078AA RID: 30890
		PolygonOffsetFactor,
		// Token: 0x040078AB RID: 30891
		PolygonOffsetBiasExt,
		// Token: 0x040078AC RID: 30892
		RescaleNormalExt,
		// Token: 0x040078AD RID: 30893
		Alpha4,
		// Token: 0x040078AE RID: 30894
		Alpha8,
		// Token: 0x040078AF RID: 30895
		Alpha8Ext = 32828,
		// Token: 0x040078B0 RID: 30896
		Alpha8Oes = 32828,
		// Token: 0x040078B1 RID: 30897
		Alpha12,
		// Token: 0x040078B2 RID: 30898
		Alpha16,
		// Token: 0x040078B3 RID: 30899
		Luminance4,
		// Token: 0x040078B4 RID: 30900
		Luminance8,
		// Token: 0x040078B5 RID: 30901
		Luminance8Ext = 32832,
		// Token: 0x040078B6 RID: 30902
		Luminance8Oes = 32832,
		// Token: 0x040078B7 RID: 30903
		Luminance12,
		// Token: 0x040078B8 RID: 30904
		Luminance16,
		// Token: 0x040078B9 RID: 30905
		Luminance4Alpha4,
		// Token: 0x040078BA RID: 30906
		Luminance4Alpha4Oes = 32835,
		// Token: 0x040078BB RID: 30907
		Luminance6Alpha2,
		// Token: 0x040078BC RID: 30908
		Luminance8Alpha8,
		// Token: 0x040078BD RID: 30909
		Luminance8Alpha8Ext = 32837,
		// Token: 0x040078BE RID: 30910
		Luminance8Alpha8Oes = 32837,
		// Token: 0x040078BF RID: 30911
		Luminance12Alpha4,
		// Token: 0x040078C0 RID: 30912
		Luminance12Alpha12,
		// Token: 0x040078C1 RID: 30913
		Luminance16Alpha16,
		// Token: 0x040078C2 RID: 30914
		Intensity,
		// Token: 0x040078C3 RID: 30915
		Intensity4,
		// Token: 0x040078C4 RID: 30916
		Intensity8,
		// Token: 0x040078C5 RID: 30917
		Intensity12,
		// Token: 0x040078C6 RID: 30918
		Intensity16,
		// Token: 0x040078C7 RID: 30919
		Rgb2Ext,
		// Token: 0x040078C8 RID: 30920
		Rgb4,
		// Token: 0x040078C9 RID: 30921
		Rgb5,
		// Token: 0x040078CA RID: 30922
		Rgb8,
		// Token: 0x040078CB RID: 30923
		Rgb8Oes = 32849,
		// Token: 0x040078CC RID: 30924
		Rgb10,
		// Token: 0x040078CD RID: 30925
		Rgb10Ext = 32850,
		// Token: 0x040078CE RID: 30926
		Rgb12,
		// Token: 0x040078CF RID: 30927
		Rgb16,
		// Token: 0x040078D0 RID: 30928
		Rgba2,
		// Token: 0x040078D1 RID: 30929
		Rgba4Oes,
		// Token: 0x040078D2 RID: 30930
		Rgba4 = 32854,
		// Token: 0x040078D3 RID: 30931
		Rgb5A1,
		// Token: 0x040078D4 RID: 30932
		Rgb5A1Oes = 32855,
		// Token: 0x040078D5 RID: 30933
		Rgba8,
		// Token: 0x040078D6 RID: 30934
		Rgba8Oes = 32856,
		// Token: 0x040078D7 RID: 30935
		Rgb10A2,
		// Token: 0x040078D8 RID: 30936
		Rgb10A2Ext = 32857,
		// Token: 0x040078D9 RID: 30937
		Rgba12,
		// Token: 0x040078DA RID: 30938
		Rgba16,
		// Token: 0x040078DB RID: 30939
		TextureRedSize,
		// Token: 0x040078DC RID: 30940
		TextureGreenSize,
		// Token: 0x040078DD RID: 30941
		TextureBlueSize,
		// Token: 0x040078DE RID: 30942
		TextureAlphaSize,
		// Token: 0x040078DF RID: 30943
		TextureLuminanceSize,
		// Token: 0x040078E0 RID: 30944
		TextureIntensitySize,
		// Token: 0x040078E1 RID: 30945
		ReplaceExt,
		// Token: 0x040078E2 RID: 30946
		ProxyTexture1D,
		// Token: 0x040078E3 RID: 30947
		ProxyTexture1DExt = 32867,
		// Token: 0x040078E4 RID: 30948
		ProxyTexture2D,
		// Token: 0x040078E5 RID: 30949
		ProxyTexture2DExt = 32868,
		// Token: 0x040078E6 RID: 30950
		TextureTooLargeExt,
		// Token: 0x040078E7 RID: 30951
		TexturePriority,
		// Token: 0x040078E8 RID: 30952
		TexturePriorityExt = 32870,
		// Token: 0x040078E9 RID: 30953
		TextureResident,
		// Token: 0x040078EA RID: 30954
		TextureBinding1D,
		// Token: 0x040078EB RID: 30955
		TextureBinding2D,
		// Token: 0x040078EC RID: 30956
		Texture3DBindingExt,
		// Token: 0x040078ED RID: 30957
		TextureBinding3D = 32874,
		// Token: 0x040078EE RID: 30958
		TextureBinding3DOes = 32874,
		// Token: 0x040078EF RID: 30959
		PackSkipImages,
		// Token: 0x040078F0 RID: 30960
		PackSkipImagesExt = 32875,
		// Token: 0x040078F1 RID: 30961
		PackImageHeight,
		// Token: 0x040078F2 RID: 30962
		PackImageHeightExt = 32876,
		// Token: 0x040078F3 RID: 30963
		UnpackSkipImages,
		// Token: 0x040078F4 RID: 30964
		UnpackSkipImagesExt = 32877,
		// Token: 0x040078F5 RID: 30965
		UnpackImageHeight,
		// Token: 0x040078F6 RID: 30966
		UnpackImageHeightExt = 32878,
		// Token: 0x040078F7 RID: 30967
		Texture3D,
		// Token: 0x040078F8 RID: 30968
		Texture3DExt = 32879,
		// Token: 0x040078F9 RID: 30969
		Texture3DOes = 32879,
		// Token: 0x040078FA RID: 30970
		ProxyTexture3D,
		// Token: 0x040078FB RID: 30971
		ProxyTexture3DExt = 32880,
		// Token: 0x040078FC RID: 30972
		TextureDepthExt,
		// Token: 0x040078FD RID: 30973
		TextureWrapR,
		// Token: 0x040078FE RID: 30974
		TextureWrapRExt = 32882,
		// Token: 0x040078FF RID: 30975
		TextureWrapROes = 32882,
		// Token: 0x04007900 RID: 30976
		Max3DTextureSize,
		// Token: 0x04007901 RID: 30977
		Max3DTextureSizeExt = 32883,
		// Token: 0x04007902 RID: 30978
		Max3DTextureSizeOes = 32883,
		// Token: 0x04007903 RID: 30979
		VertexArray,
		// Token: 0x04007904 RID: 30980
		VertexArrayKhr = 32884,
		// Token: 0x04007905 RID: 30981
		NormalArray,
		// Token: 0x04007906 RID: 30982
		ColorArray,
		// Token: 0x04007907 RID: 30983
		IndexArray,
		// Token: 0x04007908 RID: 30984
		TextureCoordArray,
		// Token: 0x04007909 RID: 30985
		EdgeFlagArray,
		// Token: 0x0400790A RID: 30986
		VertexArraySize,
		// Token: 0x0400790B RID: 30987
		VertexArrayType,
		// Token: 0x0400790C RID: 30988
		VertexArrayStride,
		// Token: 0x0400790D RID: 30989
		VertexArrayCountExt,
		// Token: 0x0400790E RID: 30990
		NormalArrayType,
		// Token: 0x0400790F RID: 30991
		NormalArrayStride,
		// Token: 0x04007910 RID: 30992
		NormalArrayCountExt,
		// Token: 0x04007911 RID: 30993
		ColorArraySize,
		// Token: 0x04007912 RID: 30994
		ColorArrayType,
		// Token: 0x04007913 RID: 30995
		ColorArrayStride,
		// Token: 0x04007914 RID: 30996
		ColorArrayCountExt,
		// Token: 0x04007915 RID: 30997
		IndexArrayType,
		// Token: 0x04007916 RID: 30998
		IndexArrayStride,
		// Token: 0x04007917 RID: 30999
		IndexArrayCountExt,
		// Token: 0x04007918 RID: 31000
		TextureCoordArraySize,
		// Token: 0x04007919 RID: 31001
		TextureCoordArrayType,
		// Token: 0x0400791A RID: 31002
		TextureCoordArrayStride,
		// Token: 0x0400791B RID: 31003
		TextureCoordArrayCountExt,
		// Token: 0x0400791C RID: 31004
		EdgeFlagArrayStride,
		// Token: 0x0400791D RID: 31005
		EdgeFlagArrayCountExt,
		// Token: 0x0400791E RID: 31006
		VertexArrayPointer,
		// Token: 0x0400791F RID: 31007
		VertexArrayPointerExt = 32910,
		// Token: 0x04007920 RID: 31008
		NormalArrayPointer,
		// Token: 0x04007921 RID: 31009
		NormalArrayPointerExt = 32911,
		// Token: 0x04007922 RID: 31010
		ColorArrayPointer,
		// Token: 0x04007923 RID: 31011
		ColorArrayPointerExt = 32912,
		// Token: 0x04007924 RID: 31012
		IndexArrayPointer,
		// Token: 0x04007925 RID: 31013
		IndexArrayPointerExt = 32913,
		// Token: 0x04007926 RID: 31014
		TextureCoordArrayPointer,
		// Token: 0x04007927 RID: 31015
		TextureCoordArrayPointerExt = 32914,
		// Token: 0x04007928 RID: 31016
		EdgeFlagArrayPointer,
		// Token: 0x04007929 RID: 31017
		EdgeFlagArrayPointerExt = 32915,
		// Token: 0x0400792A RID: 31018
		InterlaceSgix,
		// Token: 0x0400792B RID: 31019
		DetailTexture2DSgis,
		// Token: 0x0400792C RID: 31020
		DetailTexture2DBindingSgis,
		// Token: 0x0400792D RID: 31021
		LinearDetailSgis,
		// Token: 0x0400792E RID: 31022
		LinearDetailAlphaSgis,
		// Token: 0x0400792F RID: 31023
		LinearDetailColorSgis,
		// Token: 0x04007930 RID: 31024
		DetailTextureLevelSgis,
		// Token: 0x04007931 RID: 31025
		DetailTextureModeSgis,
		// Token: 0x04007932 RID: 31026
		DetailTextureFuncPointsSgis,
		// Token: 0x04007933 RID: 31027
		MultisampleSgis,
		// Token: 0x04007934 RID: 31028
		SampleAlphaToCoverage,
		// Token: 0x04007935 RID: 31029
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x04007936 RID: 31030
		SampleAlphaToOneSgis,
		// Token: 0x04007937 RID: 31031
		SampleCoverage,
		// Token: 0x04007938 RID: 31032
		SampleMaskSgis = 32928,
		// Token: 0x04007939 RID: 31033
		Gl1PassExt,
		// Token: 0x0400793A RID: 31034
		Gl1PassSgis = 32929,
		// Token: 0x0400793B RID: 31035
		Gl2Pass0Ext,
		// Token: 0x0400793C RID: 31036
		Gl2Pass0Sgis = 32930,
		// Token: 0x0400793D RID: 31037
		Gl2Pass1Ext,
		// Token: 0x0400793E RID: 31038
		Gl2Pass1Sgis = 32931,
		// Token: 0x0400793F RID: 31039
		Gl4Pass0Ext,
		// Token: 0x04007940 RID: 31040
		Gl4Pass0Sgis = 32932,
		// Token: 0x04007941 RID: 31041
		Gl4Pass1Ext,
		// Token: 0x04007942 RID: 31042
		Gl4Pass1Sgis = 32933,
		// Token: 0x04007943 RID: 31043
		Gl4Pass2Ext,
		// Token: 0x04007944 RID: 31044
		Gl4Pass2Sgis = 32934,
		// Token: 0x04007945 RID: 31045
		Gl4Pass3Ext,
		// Token: 0x04007946 RID: 31046
		Gl4Pass3Sgis = 32935,
		// Token: 0x04007947 RID: 31047
		SampleBuffers,
		// Token: 0x04007948 RID: 31048
		SampleBuffersSgis = 32936,
		// Token: 0x04007949 RID: 31049
		SamplesSgis,
		// Token: 0x0400794A RID: 31050
		Samples = 32937,
		// Token: 0x0400794B RID: 31051
		SampleCoverageValue,
		// Token: 0x0400794C RID: 31052
		SampleMaskValueSgis = 32938,
		// Token: 0x0400794D RID: 31053
		SampleCoverageInvert,
		// Token: 0x0400794E RID: 31054
		SampleMaskInvertSgis = 32939,
		// Token: 0x0400794F RID: 31055
		SamplePatternSgis,
		// Token: 0x04007950 RID: 31056
		LinearSharpenSgis,
		// Token: 0x04007951 RID: 31057
		LinearSharpenAlphaSgis,
		// Token: 0x04007952 RID: 31058
		LinearSharpenColorSgis,
		// Token: 0x04007953 RID: 31059
		SharpenTextureFuncPointsSgis,
		// Token: 0x04007954 RID: 31060
		ColorMatrixSgi,
		// Token: 0x04007955 RID: 31061
		ColorMatrixStackDepthSgi,
		// Token: 0x04007956 RID: 31062
		MaxColorMatrixStackDepthSgi,
		// Token: 0x04007957 RID: 31063
		PostColorMatrixRedScale,
		// Token: 0x04007958 RID: 31064
		PostColorMatrixRedScaleSgi = 32948,
		// Token: 0x04007959 RID: 31065
		PostColorMatrixGreenScale,
		// Token: 0x0400795A RID: 31066
		PostColorMatrixGreenScaleSgi = 32949,
		// Token: 0x0400795B RID: 31067
		PostColorMatrixBlueScale,
		// Token: 0x0400795C RID: 31068
		PostColorMatrixBlueScaleSgi = 32950,
		// Token: 0x0400795D RID: 31069
		PostColorMatrixAlphaScale,
		// Token: 0x0400795E RID: 31070
		PostColorMatrixAlphaScaleSgi = 32951,
		// Token: 0x0400795F RID: 31071
		PostColorMatrixRedBias,
		// Token: 0x04007960 RID: 31072
		PostColorMatrixRedBiasSgi = 32952,
		// Token: 0x04007961 RID: 31073
		PostColorMatrixGreenBias,
		// Token: 0x04007962 RID: 31074
		PostColorMatrixGreenBiasSgi = 32953,
		// Token: 0x04007963 RID: 31075
		PostColorMatrixBlueBias,
		// Token: 0x04007964 RID: 31076
		PostColorMatrixBlueBiasSgi = 32954,
		// Token: 0x04007965 RID: 31077
		PostColorMatrixAlphaBias,
		// Token: 0x04007966 RID: 31078
		PostColorMatrixAlphaBiasSgi = 32955,
		// Token: 0x04007967 RID: 31079
		TextureColorTableSgi,
		// Token: 0x04007968 RID: 31080
		ProxyTextureColorTableSgi,
		// Token: 0x04007969 RID: 31081
		TextureEnvBiasSgix,
		// Token: 0x0400796A RID: 31082
		ShadowAmbientSgix,
		// Token: 0x0400796B RID: 31083
		BlendDstRgb = 32968,
		// Token: 0x0400796C RID: 31084
		BlendSrcRgb,
		// Token: 0x0400796D RID: 31085
		BlendDstAlpha,
		// Token: 0x0400796E RID: 31086
		BlendSrcAlpha,
		// Token: 0x0400796F RID: 31087
		ColorTable = 32976,
		// Token: 0x04007970 RID: 31088
		ColorTableSgi = 32976,
		// Token: 0x04007971 RID: 31089
		PostConvolutionColorTable,
		// Token: 0x04007972 RID: 31090
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x04007973 RID: 31091
		PostColorMatrixColorTable,
		// Token: 0x04007974 RID: 31092
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x04007975 RID: 31093
		ProxyColorTable,
		// Token: 0x04007976 RID: 31094
		ProxyColorTableSgi = 32979,
		// Token: 0x04007977 RID: 31095
		ProxyPostConvolutionColorTable,
		// Token: 0x04007978 RID: 31096
		ProxyPostConvolutionColorTableSgi = 32980,
		// Token: 0x04007979 RID: 31097
		ProxyPostColorMatrixColorTable,
		// Token: 0x0400797A RID: 31098
		ProxyPostColorMatrixColorTableSgi = 32981,
		// Token: 0x0400797B RID: 31099
		ColorTableScale,
		// Token: 0x0400797C RID: 31100
		ColorTableScaleSgi = 32982,
		// Token: 0x0400797D RID: 31101
		ColorTableBias,
		// Token: 0x0400797E RID: 31102
		ColorTableBiasSgi = 32983,
		// Token: 0x0400797F RID: 31103
		ColorTableFormatSgi,
		// Token: 0x04007980 RID: 31104
		ColorTableWidthSgi,
		// Token: 0x04007981 RID: 31105
		ColorTableRedSizeSgi,
		// Token: 0x04007982 RID: 31106
		ColorTableGreenSizeSgi,
		// Token: 0x04007983 RID: 31107
		ColorTableBlueSizeSgi,
		// Token: 0x04007984 RID: 31108
		ColorTableAlphaSizeSgi,
		// Token: 0x04007985 RID: 31109
		ColorTableLuminanceSizeSgi,
		// Token: 0x04007986 RID: 31110
		ColorTableIntensitySizeSgi,
		// Token: 0x04007987 RID: 31111
		BgraExt = 32993,
		// Token: 0x04007988 RID: 31112
		BgraImg = 32993,
		// Token: 0x04007989 RID: 31113
		MaxElementsVertices = 33000,
		// Token: 0x0400798A RID: 31114
		MaxElementsIndices,
		// Token: 0x0400798B RID: 31115
		PhongHintWin = 33003,
		// Token: 0x0400798C RID: 31116
		ClipVolumeClippingHintExt = 33008,
		// Token: 0x0400798D RID: 31117
		DualAlpha4Sgis = 33040,
		// Token: 0x0400798E RID: 31118
		DualAlpha8Sgis,
		// Token: 0x0400798F RID: 31119
		DualAlpha12Sgis,
		// Token: 0x04007990 RID: 31120
		DualAlpha16Sgis,
		// Token: 0x04007991 RID: 31121
		DualLuminance4Sgis,
		// Token: 0x04007992 RID: 31122
		DualLuminance8Sgis,
		// Token: 0x04007993 RID: 31123
		DualLuminance12Sgis,
		// Token: 0x04007994 RID: 31124
		DualLuminance16Sgis,
		// Token: 0x04007995 RID: 31125
		DualIntensity4Sgis,
		// Token: 0x04007996 RID: 31126
		DualIntensity8Sgis,
		// Token: 0x04007997 RID: 31127
		DualIntensity12Sgis,
		// Token: 0x04007998 RID: 31128
		DualIntensity16Sgis,
		// Token: 0x04007999 RID: 31129
		DualLuminanceAlpha4Sgis,
		// Token: 0x0400799A RID: 31130
		DualLuminanceAlpha8Sgis,
		// Token: 0x0400799B RID: 31131
		QuadAlpha4Sgis,
		// Token: 0x0400799C RID: 31132
		QuadAlpha8Sgis,
		// Token: 0x0400799D RID: 31133
		QuadLuminance4Sgis,
		// Token: 0x0400799E RID: 31134
		QuadLuminance8Sgis,
		// Token: 0x0400799F RID: 31135
		QuadIntensity4Sgis,
		// Token: 0x040079A0 RID: 31136
		QuadIntensity8Sgis,
		// Token: 0x040079A1 RID: 31137
		DualTextureSelectSgis,
		// Token: 0x040079A2 RID: 31138
		QuadTextureSelectSgis,
		// Token: 0x040079A3 RID: 31139
		PointSizeMin,
		// Token: 0x040079A4 RID: 31140
		PointSizeMinArb = 33062,
		// Token: 0x040079A5 RID: 31141
		PointSizeMinExt = 33062,
		// Token: 0x040079A6 RID: 31142
		PointSizeMinSgis = 33062,
		// Token: 0x040079A7 RID: 31143
		PointSizeMax,
		// Token: 0x040079A8 RID: 31144
		PointSizeMaxArb = 33063,
		// Token: 0x040079A9 RID: 31145
		PointSizeMaxExt = 33063,
		// Token: 0x040079AA RID: 31146
		PointSizeMaxSgis = 33063,
		// Token: 0x040079AB RID: 31147
		PointFadeThresholdSize,
		// Token: 0x040079AC RID: 31148
		PointFadeThresholdSizeArb = 33064,
		// Token: 0x040079AD RID: 31149
		PointFadeThresholdSizeExt = 33064,
		// Token: 0x040079AE RID: 31150
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x040079AF RID: 31151
		DistanceAttenuationExt,
		// Token: 0x040079B0 RID: 31152
		DistanceAttenuationSgis = 33065,
		// Token: 0x040079B1 RID: 31153
		PointDistanceAttenuation = 33065,
		// Token: 0x040079B2 RID: 31154
		PointDistanceAttenuationArb = 33065,
		// Token: 0x040079B3 RID: 31155
		FogFuncSgis,
		// Token: 0x040079B4 RID: 31156
		FogFuncPointsSgis,
		// Token: 0x040079B5 RID: 31157
		MaxFogFuncPointsSgis,
		// Token: 0x040079B6 RID: 31158
		ClampToBorder,
		// Token: 0x040079B7 RID: 31159
		ClampToBorderArb = 33069,
		// Token: 0x040079B8 RID: 31160
		ClampToBorderExt = 33069,
		// Token: 0x040079B9 RID: 31161
		ClampToBorderNv = 33069,
		// Token: 0x040079BA RID: 31162
		ClampToBorderSgis = 33069,
		// Token: 0x040079BB RID: 31163
		TextureMultiBufferHintSgix,
		// Token: 0x040079BC RID: 31164
		ClampToEdge,
		// Token: 0x040079BD RID: 31165
		ClampToEdgeSgis = 33071,
		// Token: 0x040079BE RID: 31166
		PackSkipVolumesSgis,
		// Token: 0x040079BF RID: 31167
		PackImageDepthSgis,
		// Token: 0x040079C0 RID: 31168
		UnpackSkipVolumesSgis,
		// Token: 0x040079C1 RID: 31169
		UnpackImageDepthSgis,
		// Token: 0x040079C2 RID: 31170
		Texture4DSgis,
		// Token: 0x040079C3 RID: 31171
		ProxyTexture4DSgis,
		// Token: 0x040079C4 RID: 31172
		Texture4DsizeSgis,
		// Token: 0x040079C5 RID: 31173
		TextureWrapQSgis,
		// Token: 0x040079C6 RID: 31174
		Max4DTextureSizeSgis,
		// Token: 0x040079C7 RID: 31175
		PixelTexGenSgix,
		// Token: 0x040079C8 RID: 31176
		TextureMinLod,
		// Token: 0x040079C9 RID: 31177
		TextureMinLodSgis = 33082,
		// Token: 0x040079CA RID: 31178
		TextureMaxLod,
		// Token: 0x040079CB RID: 31179
		TextureMaxLodSgis = 33083,
		// Token: 0x040079CC RID: 31180
		TextureBaseLevel,
		// Token: 0x040079CD RID: 31181
		TextureBaseLevelSgis = 33084,
		// Token: 0x040079CE RID: 31182
		TextureMaxLevel,
		// Token: 0x040079CF RID: 31183
		TextureMaxLevelApple = 33085,
		// Token: 0x040079D0 RID: 31184
		TextureMaxLevelSgis = 33085,
		// Token: 0x040079D1 RID: 31185
		PixelTileBestAlignmentSgix,
		// Token: 0x040079D2 RID: 31186
		PixelTileCacheIncrementSgix,
		// Token: 0x040079D3 RID: 31187
		PixelTileWidthSgix,
		// Token: 0x040079D4 RID: 31188
		PixelTileHeightSgix,
		// Token: 0x040079D5 RID: 31189
		PixelTileGridWidthSgix,
		// Token: 0x040079D6 RID: 31190
		PixelTileGridHeightSgix,
		// Token: 0x040079D7 RID: 31191
		PixelTileGridDepthSgix,
		// Token: 0x040079D8 RID: 31192
		PixelTileCacheSizeSgix,
		// Token: 0x040079D9 RID: 31193
		Filter4Sgis,
		// Token: 0x040079DA RID: 31194
		TextureFilter4SizeSgis,
		// Token: 0x040079DB RID: 31195
		SpriteSgix,
		// Token: 0x040079DC RID: 31196
		SpriteModeSgix,
		// Token: 0x040079DD RID: 31197
		SpriteAxisSgix,
		// Token: 0x040079DE RID: 31198
		SpriteTranslationSgix,
		// Token: 0x040079DF RID: 31199
		Texture4DBindingSgis = 33103,
		// Token: 0x040079E0 RID: 31200
		LinearClipmapLinearSgix = 33136,
		// Token: 0x040079E1 RID: 31201
		TextureClipmapCenterSgix,
		// Token: 0x040079E2 RID: 31202
		TextureClipmapFrameSgix,
		// Token: 0x040079E3 RID: 31203
		TextureClipmapOffsetSgix,
		// Token: 0x040079E4 RID: 31204
		TextureClipmapVirtualDepthSgix,
		// Token: 0x040079E5 RID: 31205
		TextureClipmapLodOffsetSgix,
		// Token: 0x040079E6 RID: 31206
		TextureClipmapDepthSgix,
		// Token: 0x040079E7 RID: 31207
		MaxClipmapDepthSgix,
		// Token: 0x040079E8 RID: 31208
		MaxClipmapVirtualDepthSgix,
		// Token: 0x040079E9 RID: 31209
		PostTextureFilterBiasSgix,
		// Token: 0x040079EA RID: 31210
		PostTextureFilterScaleSgix,
		// Token: 0x040079EB RID: 31211
		PostTextureFilterBiasRangeSgix,
		// Token: 0x040079EC RID: 31212
		PostTextureFilterScaleRangeSgix,
		// Token: 0x040079ED RID: 31213
		ReferencePlaneSgix,
		// Token: 0x040079EE RID: 31214
		ReferencePlaneEquationSgix,
		// Token: 0x040079EF RID: 31215
		IrInstrument1Sgix,
		// Token: 0x040079F0 RID: 31216
		InstrumentBufferPointerSgix,
		// Token: 0x040079F1 RID: 31217
		InstrumentMeasurementsSgix,
		// Token: 0x040079F2 RID: 31218
		ListPrioritySgix,
		// Token: 0x040079F3 RID: 31219
		CalligraphicFragmentSgix,
		// Token: 0x040079F4 RID: 31220
		PixelTexGenQCeilingSgix,
		// Token: 0x040079F5 RID: 31221
		PixelTexGenQRoundSgix,
		// Token: 0x040079F6 RID: 31222
		PixelTexGenQFloorSgix,
		// Token: 0x040079F7 RID: 31223
		PixelTexGenAlphaReplaceSgix,
		// Token: 0x040079F8 RID: 31224
		PixelTexGenAlphaNoReplaceSgix,
		// Token: 0x040079F9 RID: 31225
		PixelTexGenAlphaLsSgix,
		// Token: 0x040079FA RID: 31226
		PixelTexGenAlphaMsSgix,
		// Token: 0x040079FB RID: 31227
		FramezoomSgix,
		// Token: 0x040079FC RID: 31228
		FramezoomFactorSgix,
		// Token: 0x040079FD RID: 31229
		MaxFramezoomFactorSgix,
		// Token: 0x040079FE RID: 31230
		TextureLodBiasSSgix,
		// Token: 0x040079FF RID: 31231
		TextureLodBiasTSgix,
		// Token: 0x04007A00 RID: 31232
		TextureLodBiasRSgix,
		// Token: 0x04007A01 RID: 31233
		GenerateMipmap,
		// Token: 0x04007A02 RID: 31234
		GenerateMipmapSgis = 33169,
		// Token: 0x04007A03 RID: 31235
		GenerateMipmapHint,
		// Token: 0x04007A04 RID: 31236
		GenerateMipmapHintSgis = 33170,
		// Token: 0x04007A05 RID: 31237
		GeometryDeformationSgix = 33172,
		// Token: 0x04007A06 RID: 31238
		TextureDeformationSgix,
		// Token: 0x04007A07 RID: 31239
		DeformationsMaskSgix,
		// Token: 0x04007A08 RID: 31240
		FogOffsetSgix = 33176,
		// Token: 0x04007A09 RID: 31241
		FogOffsetValueSgix,
		// Token: 0x04007A0A RID: 31242
		TextureCompareSgix,
		// Token: 0x04007A0B RID: 31243
		TextureCompareOperatorSgix,
		// Token: 0x04007A0C RID: 31244
		TextureLequalRSgix,
		// Token: 0x04007A0D RID: 31245
		TextureGequalRSgix,
		// Token: 0x04007A0E RID: 31246
		DepthComponent16 = 33189,
		// Token: 0x04007A0F RID: 31247
		DepthComponent16Oes = 33189,
		// Token: 0x04007A10 RID: 31248
		DepthComponent16Sgix = 33189,
		// Token: 0x04007A11 RID: 31249
		DepthComponent24,
		// Token: 0x04007A12 RID: 31250
		DepthComponent24Oes = 33190,
		// Token: 0x04007A13 RID: 31251
		DepthComponent24Sgix = 33190,
		// Token: 0x04007A14 RID: 31252
		DepthComponent32Oes,
		// Token: 0x04007A15 RID: 31253
		DepthComponent32Sgix = 33191,
		// Token: 0x04007A16 RID: 31254
		Ycrcb422Sgix = 33211,
		// Token: 0x04007A17 RID: 31255
		Ycrcb444Sgix,
		// Token: 0x04007A18 RID: 31256
		EyeDistanceToPointSgis = 33264,
		// Token: 0x04007A19 RID: 31257
		ObjectDistanceToPointSgis,
		// Token: 0x04007A1A RID: 31258
		EyeDistanceToLineSgis,
		// Token: 0x04007A1B RID: 31259
		ObjectDistanceToLineSgis,
		// Token: 0x04007A1C RID: 31260
		EyePointSgis,
		// Token: 0x04007A1D RID: 31261
		ObjectPointSgis,
		// Token: 0x04007A1E RID: 31262
		EyeLineSgis,
		// Token: 0x04007A1F RID: 31263
		ObjectLineSgis,
		// Token: 0x04007A20 RID: 31264
		LightModelColorControl,
		// Token: 0x04007A21 RID: 31265
		LightModelColorControlExt = 33272,
		// Token: 0x04007A22 RID: 31266
		SingleColor,
		// Token: 0x04007A23 RID: 31267
		SingleColorExt = 33273,
		// Token: 0x04007A24 RID: 31268
		SeparateSpecularColor,
		// Token: 0x04007A25 RID: 31269
		SeparateSpecularColorExt = 33274,
		// Token: 0x04007A26 RID: 31270
		SharedTexturePaletteExt,
		// Token: 0x04007A27 RID: 31271
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x04007A28 RID: 31272
		FramebufferAttachmentColorEncodingExt = 33296,
		// Token: 0x04007A29 RID: 31273
		FramebufferAttachmentComponentType,
		// Token: 0x04007A2A RID: 31274
		FramebufferAttachmentComponentTypeExt = 33297,
		// Token: 0x04007A2B RID: 31275
		FramebufferAttachmentRedSize,
		// Token: 0x04007A2C RID: 31276
		FramebufferAttachmentGreenSize,
		// Token: 0x04007A2D RID: 31277
		FramebufferAttachmentBlueSize,
		// Token: 0x04007A2E RID: 31278
		FramebufferAttachmentAlphaSize,
		// Token: 0x04007A2F RID: 31279
		FramebufferAttachmentDepthSize,
		// Token: 0x04007A30 RID: 31280
		FramebufferAttachmentStencilSize,
		// Token: 0x04007A31 RID: 31281
		FramebufferDefault,
		// Token: 0x04007A32 RID: 31282
		FramebufferUndefined,
		// Token: 0x04007A33 RID: 31283
		FramebufferUndefinedOes = 33305,
		// Token: 0x04007A34 RID: 31284
		DepthStencilAttachment,
		// Token: 0x04007A35 RID: 31285
		MajorVersion,
		// Token: 0x04007A36 RID: 31286
		MinorVersion,
		// Token: 0x04007A37 RID: 31287
		NumExtensions,
		// Token: 0x04007A38 RID: 31288
		PrimitiveRestartForPatchesSupported = 33313,
		// Token: 0x04007A39 RID: 31289
		Rg = 33319,
		// Token: 0x04007A3A RID: 31290
		RgExt = 33319,
		// Token: 0x04007A3B RID: 31291
		RgInteger,
		// Token: 0x04007A3C RID: 31292
		R8,
		// Token: 0x04007A3D RID: 31293
		R8Ext = 33321,
		// Token: 0x04007A3E RID: 31294
		Rg8 = 33323,
		// Token: 0x04007A3F RID: 31295
		Rg8Ext = 33323,
		// Token: 0x04007A40 RID: 31296
		R16f = 33325,
		// Token: 0x04007A41 RID: 31297
		R16fExt = 33325,
		// Token: 0x04007A42 RID: 31298
		R32f,
		// Token: 0x04007A43 RID: 31299
		R32fExt = 33326,
		// Token: 0x04007A44 RID: 31300
		Rg16f,
		// Token: 0x04007A45 RID: 31301
		Rg16fExt = 33327,
		// Token: 0x04007A46 RID: 31302
		Rg32f,
		// Token: 0x04007A47 RID: 31303
		Rg32fExt = 33328,
		// Token: 0x04007A48 RID: 31304
		R8i,
		// Token: 0x04007A49 RID: 31305
		R8ui,
		// Token: 0x04007A4A RID: 31306
		R16i,
		// Token: 0x04007A4B RID: 31307
		R16ui,
		// Token: 0x04007A4C RID: 31308
		R32i,
		// Token: 0x04007A4D RID: 31309
		R32ui,
		// Token: 0x04007A4E RID: 31310
		Rg8i,
		// Token: 0x04007A4F RID: 31311
		Rg8ui,
		// Token: 0x04007A50 RID: 31312
		Rg16i,
		// Token: 0x04007A51 RID: 31313
		Rg16ui,
		// Token: 0x04007A52 RID: 31314
		Rg32i,
		// Token: 0x04007A53 RID: 31315
		Rg32ui,
		// Token: 0x04007A54 RID: 31316
		DebugOutputSynchronous = 33346,
		// Token: 0x04007A55 RID: 31317
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x04007A56 RID: 31318
		DebugNextLoggedMessageLength,
		// Token: 0x04007A57 RID: 31319
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x04007A58 RID: 31320
		DebugCallbackFunction,
		// Token: 0x04007A59 RID: 31321
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x04007A5A RID: 31322
		DebugCallbackUserParam,
		// Token: 0x04007A5B RID: 31323
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x04007A5C RID: 31324
		DebugSourceApi,
		// Token: 0x04007A5D RID: 31325
		DebugSourceApiKhr = 33350,
		// Token: 0x04007A5E RID: 31326
		DebugSourceWindowSystem,
		// Token: 0x04007A5F RID: 31327
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x04007A60 RID: 31328
		DebugSourceShaderCompiler,
		// Token: 0x04007A61 RID: 31329
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x04007A62 RID: 31330
		DebugSourceThirdParty,
		// Token: 0x04007A63 RID: 31331
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x04007A64 RID: 31332
		DebugSourceApplication,
		// Token: 0x04007A65 RID: 31333
		DebugSourceApplicationKhr = 33354,
		// Token: 0x04007A66 RID: 31334
		DebugSourceOther,
		// Token: 0x04007A67 RID: 31335
		DebugSourceOtherKhr = 33355,
		// Token: 0x04007A68 RID: 31336
		DebugTypeError,
		// Token: 0x04007A69 RID: 31337
		DebugTypeErrorKhr = 33356,
		// Token: 0x04007A6A RID: 31338
		DebugTypeDeprecatedBehavior,
		// Token: 0x04007A6B RID: 31339
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04007A6C RID: 31340
		DebugTypeUndefinedBehavior,
		// Token: 0x04007A6D RID: 31341
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x04007A6E RID: 31342
		DebugTypePortability,
		// Token: 0x04007A6F RID: 31343
		DebugTypePortabilityKhr = 33359,
		// Token: 0x04007A70 RID: 31344
		DebugTypePerformance,
		// Token: 0x04007A71 RID: 31345
		DebugTypePerformanceKhr = 33360,
		// Token: 0x04007A72 RID: 31346
		DebugTypeOther,
		// Token: 0x04007A73 RID: 31347
		DebugTypeOtherKhr = 33361,
		// Token: 0x04007A74 RID: 31348
		LoseContextOnResetExt,
		// Token: 0x04007A75 RID: 31349
		GuiltyContextResetExt,
		// Token: 0x04007A76 RID: 31350
		InnocentContextResetExt,
		// Token: 0x04007A77 RID: 31351
		UnknownContextResetExt,
		// Token: 0x04007A78 RID: 31352
		ResetNotificationStrategyExt,
		// Token: 0x04007A79 RID: 31353
		ProgramBinaryRetrievableHint,
		// Token: 0x04007A7A RID: 31354
		ProgramSeparableExt,
		// Token: 0x04007A7B RID: 31355
		ActiveProgramExt,
		// Token: 0x04007A7C RID: 31356
		ProgramPipelineBindingExt,
		// Token: 0x04007A7D RID: 31357
		LayerProvokingVertexExt = 33374,
		// Token: 0x04007A7E RID: 31358
		UndefinedVertexExt = 33376,
		// Token: 0x04007A7F RID: 31359
		NoResetNotificationExt,
		// Token: 0x04007A80 RID: 31360
		DebugTypeMarker = 33384,
		// Token: 0x04007A81 RID: 31361
		DebugTypeMarkerKhr = 33384,
		// Token: 0x04007A82 RID: 31362
		DebugTypePushGroup,
		// Token: 0x04007A83 RID: 31363
		DebugTypePushGroupKhr = 33385,
		// Token: 0x04007A84 RID: 31364
		DebugTypePopGroup,
		// Token: 0x04007A85 RID: 31365
		DebugTypePopGroupKhr = 33386,
		// Token: 0x04007A86 RID: 31366
		DebugSeverityNotification,
		// Token: 0x04007A87 RID: 31367
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x04007A88 RID: 31368
		MaxDebugGroupStackDepth,
		// Token: 0x04007A89 RID: 31369
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x04007A8A RID: 31370
		DebugGroupStackDepth,
		// Token: 0x04007A8B RID: 31371
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x04007A8C RID: 31372
		TextureViewMinLevelExt = 33499,
		// Token: 0x04007A8D RID: 31373
		TextureViewNumLevelsExt,
		// Token: 0x04007A8E RID: 31374
		TextureViewMinLayerExt,
		// Token: 0x04007A8F RID: 31375
		TextureViewNumLayersExt,
		// Token: 0x04007A90 RID: 31376
		TextureImmutableLevels,
		// Token: 0x04007A91 RID: 31377
		Buffer,
		// Token: 0x04007A92 RID: 31378
		BufferKhr = 33504,
		// Token: 0x04007A93 RID: 31379
		Shader,
		// Token: 0x04007A94 RID: 31380
		ShaderKhr = 33505,
		// Token: 0x04007A95 RID: 31381
		Program,
		// Token: 0x04007A96 RID: 31382
		ProgramKhr = 33506,
		// Token: 0x04007A97 RID: 31383
		Query,
		// Token: 0x04007A98 RID: 31384
		QueryKhr = 33507,
		// Token: 0x04007A99 RID: 31385
		ProgramPipeline,
		// Token: 0x04007A9A RID: 31386
		Sampler = 33510,
		// Token: 0x04007A9B RID: 31387
		SamplerKhr = 33510,
		// Token: 0x04007A9C RID: 31388
		DisplayList,
		// Token: 0x04007A9D RID: 31389
		MaxLabelLength,
		// Token: 0x04007A9E RID: 31390
		MaxLabelLengthKhr = 33512,
		// Token: 0x04007A9F RID: 31391
		ConvolutionHintSgix = 33558,
		// Token: 0x04007AA0 RID: 31392
		AlphaMinSgix = 33568,
		// Token: 0x04007AA1 RID: 31393
		AlphaMaxSgix,
		// Token: 0x04007AA2 RID: 31394
		ScalebiasHintSgix,
		// Token: 0x04007AA3 RID: 31395
		AsyncMarkerSgix = 33577,
		// Token: 0x04007AA4 RID: 31396
		PixelTexGenModeSgix = 33579,
		// Token: 0x04007AA5 RID: 31397
		AsyncHistogramSgix,
		// Token: 0x04007AA6 RID: 31398
		MaxAsyncHistogramSgix,
		// Token: 0x04007AA7 RID: 31399
		PixelTextureSgis = 33619,
		// Token: 0x04007AA8 RID: 31400
		PixelFragmentRgbSourceSgis,
		// Token: 0x04007AA9 RID: 31401
		PixelFragmentAlphaSourceSgis,
		// Token: 0x04007AAA RID: 31402
		LineQualityHintSgix = 33627,
		// Token: 0x04007AAB RID: 31403
		AsyncTexImageSgix,
		// Token: 0x04007AAC RID: 31404
		AsyncDrawPixelsSgix,
		// Token: 0x04007AAD RID: 31405
		AsyncReadPixelsSgix,
		// Token: 0x04007AAE RID: 31406
		MaxAsyncTexImageSgix,
		// Token: 0x04007AAF RID: 31407
		MaxAsyncDrawPixelsSgix,
		// Token: 0x04007AB0 RID: 31408
		MaxAsyncReadPixelsSgix,
		// Token: 0x04007AB1 RID: 31409
		UnsignedShort565 = 33635,
		// Token: 0x04007AB2 RID: 31410
		UnsignedShort4444RevExt = 33637,
		// Token: 0x04007AB3 RID: 31411
		UnsignedShort4444RevImg = 33637,
		// Token: 0x04007AB4 RID: 31412
		UnsignedShort1555RevExt,
		// Token: 0x04007AB5 RID: 31413
		UnsignedInt2101010Rev = 33640,
		// Token: 0x04007AB6 RID: 31414
		UnsignedInt2101010RevExt = 33640,
		// Token: 0x04007AB7 RID: 31415
		TextureMaxClampSSgix,
		// Token: 0x04007AB8 RID: 31416
		TextureMaxClampTSgix,
		// Token: 0x04007AB9 RID: 31417
		TextureMaxClampRSgix,
		// Token: 0x04007ABA RID: 31418
		MirroredRepeat = 33648,
		// Token: 0x04007ABB RID: 31419
		VertexPreclipSgix = 33774,
		// Token: 0x04007ABC RID: 31420
		VertexPreclipHintSgix,
		// Token: 0x04007ABD RID: 31421
		CompressedRgbS3tcDxt1Ext,
		// Token: 0x04007ABE RID: 31422
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x04007ABF RID: 31423
		CompressedRgbaS3tcDxt3Angle,
		// Token: 0x04007AC0 RID: 31424
		CompressedRgbaS3tcDxt3Ext = 33778,
		// Token: 0x04007AC1 RID: 31425
		CompressedRgbaS3tcDxt5Angle,
		// Token: 0x04007AC2 RID: 31426
		CompressedRgbaS3tcDxt5Ext = 33779,
		// Token: 0x04007AC3 RID: 31427
		PerfqueryDonotFlushIntel = 33785,
		// Token: 0x04007AC4 RID: 31428
		PerfqueryFlushIntel,
		// Token: 0x04007AC5 RID: 31429
		PerfqueryWaitIntel,
		// Token: 0x04007AC6 RID: 31430
		FragmentLightingSgix = 33792,
		// Token: 0x04007AC7 RID: 31431
		FragmentColorMaterialSgix,
		// Token: 0x04007AC8 RID: 31432
		FragmentColorMaterialFaceSgix,
		// Token: 0x04007AC9 RID: 31433
		FragmentColorMaterialParameterSgix,
		// Token: 0x04007ACA RID: 31434
		MaxFragmentLightsSgix,
		// Token: 0x04007ACB RID: 31435
		MaxActiveLightsSgix,
		// Token: 0x04007ACC RID: 31436
		LightEnvModeSgix = 33799,
		// Token: 0x04007ACD RID: 31437
		FragmentLightModelLocalViewerSgix,
		// Token: 0x04007ACE RID: 31438
		FragmentLightModelTwoSideSgix,
		// Token: 0x04007ACF RID: 31439
		FragmentLightModelAmbientSgix,
		// Token: 0x04007AD0 RID: 31440
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x04007AD1 RID: 31441
		FragmentLight0Sgix,
		// Token: 0x04007AD2 RID: 31442
		FragmentLight1Sgix,
		// Token: 0x04007AD3 RID: 31443
		FragmentLight2Sgix,
		// Token: 0x04007AD4 RID: 31444
		FragmentLight3Sgix,
		// Token: 0x04007AD5 RID: 31445
		FragmentLight4Sgix,
		// Token: 0x04007AD6 RID: 31446
		FragmentLight5Sgix,
		// Token: 0x04007AD7 RID: 31447
		FragmentLight6Sgix,
		// Token: 0x04007AD8 RID: 31448
		FragmentLight7Sgix,
		// Token: 0x04007AD9 RID: 31449
		PackResampleSgix = 33836,
		// Token: 0x04007ADA RID: 31450
		UnpackResampleSgix,
		// Token: 0x04007ADB RID: 31451
		ResampleReplicateSgix,
		// Token: 0x04007ADC RID: 31452
		ResampleZeroFillSgix,
		// Token: 0x04007ADD RID: 31453
		ResampleDecimateSgix,
		// Token: 0x04007ADE RID: 31454
		NearestClipmapNearestSgix = 33869,
		// Token: 0x04007ADF RID: 31455
		NearestClipmapLinearSgix,
		// Token: 0x04007AE0 RID: 31456
		LinearClipmapNearestSgix,
		// Token: 0x04007AE1 RID: 31457
		AliasedPointSizeRange = 33901,
		// Token: 0x04007AE2 RID: 31458
		AliasedLineWidthRange,
		// Token: 0x04007AE3 RID: 31459
		Texture0 = 33984,
		// Token: 0x04007AE4 RID: 31460
		Texture1,
		// Token: 0x04007AE5 RID: 31461
		Texture2,
		// Token: 0x04007AE6 RID: 31462
		Texture3,
		// Token: 0x04007AE7 RID: 31463
		Texture4,
		// Token: 0x04007AE8 RID: 31464
		Texture5,
		// Token: 0x04007AE9 RID: 31465
		Texture6,
		// Token: 0x04007AEA RID: 31466
		Texture7,
		// Token: 0x04007AEB RID: 31467
		Texture8,
		// Token: 0x04007AEC RID: 31468
		Texture9,
		// Token: 0x04007AED RID: 31469
		Texture10,
		// Token: 0x04007AEE RID: 31470
		Texture11,
		// Token: 0x04007AEF RID: 31471
		Texture12,
		// Token: 0x04007AF0 RID: 31472
		Texture13,
		// Token: 0x04007AF1 RID: 31473
		Texture14,
		// Token: 0x04007AF2 RID: 31474
		Texture15,
		// Token: 0x04007AF3 RID: 31475
		Texture16,
		// Token: 0x04007AF4 RID: 31476
		Texture17,
		// Token: 0x04007AF5 RID: 31477
		Texture18,
		// Token: 0x04007AF6 RID: 31478
		Texture19,
		// Token: 0x04007AF7 RID: 31479
		Texture20,
		// Token: 0x04007AF8 RID: 31480
		Texture21,
		// Token: 0x04007AF9 RID: 31481
		Texture22,
		// Token: 0x04007AFA RID: 31482
		Texture23,
		// Token: 0x04007AFB RID: 31483
		Texture24,
		// Token: 0x04007AFC RID: 31484
		Texture25,
		// Token: 0x04007AFD RID: 31485
		Texture26,
		// Token: 0x04007AFE RID: 31486
		Texture27,
		// Token: 0x04007AFF RID: 31487
		Texture28,
		// Token: 0x04007B00 RID: 31488
		Texture29,
		// Token: 0x04007B01 RID: 31489
		Texture30,
		// Token: 0x04007B02 RID: 31490
		Texture31,
		// Token: 0x04007B03 RID: 31491
		ActiveTexture,
		// Token: 0x04007B04 RID: 31492
		MaxRenderbufferSize = 34024,
		// Token: 0x04007B05 RID: 31493
		TextureCompressionHint = 34031,
		// Token: 0x04007B06 RID: 31494
		TextureCompressionHintArb = 34031,
		// Token: 0x04007B07 RID: 31495
		AllCompletedNv = 34034,
		// Token: 0x04007B08 RID: 31496
		FenceStatusNv,
		// Token: 0x04007B09 RID: 31497
		FenceConditionNv,
		// Token: 0x04007B0A RID: 31498
		DepthStencil = 34041,
		// Token: 0x04007B0B RID: 31499
		DepthStencilOes = 34041,
		// Token: 0x04007B0C RID: 31500
		UnsignedInt248,
		// Token: 0x04007B0D RID: 31501
		UnsignedInt248Oes = 34042,
		// Token: 0x04007B0E RID: 31502
		MaxTextureLodBias = 34045,
		// Token: 0x04007B0F RID: 31503
		TextureMaxAnisotropyExt,
		// Token: 0x04007B10 RID: 31504
		MaxTextureMaxAnisotropyExt,
		// Token: 0x04007B11 RID: 31505
		IncrWrap = 34055,
		// Token: 0x04007B12 RID: 31506
		DecrWrap,
		// Token: 0x04007B13 RID: 31507
		TextureCubeMap = 34067,
		// Token: 0x04007B14 RID: 31508
		TextureBindingCubeMap,
		// Token: 0x04007B15 RID: 31509
		TextureCubeMapPositiveX,
		// Token: 0x04007B16 RID: 31510
		TextureCubeMapNegativeX,
		// Token: 0x04007B17 RID: 31511
		TextureCubeMapPositiveY,
		// Token: 0x04007B18 RID: 31512
		TextureCubeMapNegativeY,
		// Token: 0x04007B19 RID: 31513
		TextureCubeMapPositiveZ,
		// Token: 0x04007B1A RID: 31514
		TextureCubeMapNegativeZ,
		// Token: 0x04007B1B RID: 31515
		MaxCubeMapTextureSize = 34076,
		// Token: 0x04007B1C RID: 31516
		VertexArrayStorageHintApple = 34079,
		// Token: 0x04007B1D RID: 31517
		MultisampleFilterHintNv = 34100,
		// Token: 0x04007B1E RID: 31518
		PackSubsampleRateSgix = 34208,
		// Token: 0x04007B1F RID: 31519
		UnpackSubsampleRateSgix,
		// Token: 0x04007B20 RID: 31520
		PixelSubsample4444Sgix,
		// Token: 0x04007B21 RID: 31521
		PixelSubsample2424Sgix,
		// Token: 0x04007B22 RID: 31522
		PixelSubsample4242Sgix,
		// Token: 0x04007B23 RID: 31523
		TransformHintApple = 34225,
		// Token: 0x04007B24 RID: 31524
		VertexArrayBinding = 34229,
		// Token: 0x04007B25 RID: 31525
		VertexArrayBindingOes = 34229,
		// Token: 0x04007B26 RID: 31526
		UnsignedShort88Apple = 34234,
		// Token: 0x04007B27 RID: 31527
		UnsignedShort88RevApple,
		// Token: 0x04007B28 RID: 31528
		TextureStorageHintApple,
		// Token: 0x04007B29 RID: 31529
		VertexAttribArrayEnabled = 34338,
		// Token: 0x04007B2A RID: 31530
		VertexAttribArraySize,
		// Token: 0x04007B2B RID: 31531
		VertexAttribArrayStride,
		// Token: 0x04007B2C RID: 31532
		VertexAttribArrayType,
		// Token: 0x04007B2D RID: 31533
		CurrentVertexAttrib,
		// Token: 0x04007B2E RID: 31534
		VertexAttribArrayPointer = 34373,
		// Token: 0x04007B2F RID: 31535
		NumCompressedTextureFormats = 34466,
		// Token: 0x04007B30 RID: 31536
		CompressedTextureFormats,
		// Token: 0x04007B31 RID: 31537
		Z400BinaryAmd = 34624,
		// Token: 0x04007B32 RID: 31538
		ProgramBinaryLength,
		// Token: 0x04007B33 RID: 31539
		ProgramBinaryLengthOes = 34625,
		// Token: 0x04007B34 RID: 31540
		BufferSize = 34660,
		// Token: 0x04007B35 RID: 31541
		BufferUsage,
		// Token: 0x04007B36 RID: 31542
		AtcRgbaInterpolatedAlphaAmd = 34798,
		// Token: 0x04007B37 RID: 31543
		Gl3DcXAmd = 34809,
		// Token: 0x04007B38 RID: 31544
		Gl3DcXyAmd,
		// Token: 0x04007B39 RID: 31545
		NumProgramBinaryFormats = 34814,
		// Token: 0x04007B3A RID: 31546
		NumProgramBinaryFormatsOes = 34814,
		// Token: 0x04007B3B RID: 31547
		ProgramBinaryFormats,
		// Token: 0x04007B3C RID: 31548
		ProgramBinaryFormatsOes = 34815,
		// Token: 0x04007B3D RID: 31549
		StencilBackFunc,
		// Token: 0x04007B3E RID: 31550
		StencilBackFail,
		// Token: 0x04007B3F RID: 31551
		StencilBackPassDepthFail,
		// Token: 0x04007B40 RID: 31552
		StencilBackPassDepthPass,
		// Token: 0x04007B41 RID: 31553
		Rgba32f = 34836,
		// Token: 0x04007B42 RID: 31554
		Rgba32fExt = 34836,
		// Token: 0x04007B43 RID: 31555
		Rgb32f,
		// Token: 0x04007B44 RID: 31556
		Rgb32fExt = 34837,
		// Token: 0x04007B45 RID: 31557
		Alpha32fExt,
		// Token: 0x04007B46 RID: 31558
		Luminance32fExt = 34840,
		// Token: 0x04007B47 RID: 31559
		LuminanceAlpha32fExt,
		// Token: 0x04007B48 RID: 31560
		Rgba16f,
		// Token: 0x04007B49 RID: 31561
		Rgba16fExt = 34842,
		// Token: 0x04007B4A RID: 31562
		Rgb16f,
		// Token: 0x04007B4B RID: 31563
		Rgb16fExt = 34843,
		// Token: 0x04007B4C RID: 31564
		Alpha16fExt,
		// Token: 0x04007B4D RID: 31565
		Luminance16fExt = 34846,
		// Token: 0x04007B4E RID: 31566
		LuminanceAlpha16fExt,
		// Token: 0x04007B4F RID: 31567
		WriteonlyRenderingQcom = 34851,
		// Token: 0x04007B50 RID: 31568
		MaxDrawBuffers,
		// Token: 0x04007B51 RID: 31569
		MaxDrawBuffersExt = 34852,
		// Token: 0x04007B52 RID: 31570
		MaxDrawBuffersNv = 34852,
		// Token: 0x04007B53 RID: 31571
		DrawBuffer0,
		// Token: 0x04007B54 RID: 31572
		DrawBuffer0Ext = 34853,
		// Token: 0x04007B55 RID: 31573
		DrawBuffer0Nv = 34853,
		// Token: 0x04007B56 RID: 31574
		DrawBuffer1,
		// Token: 0x04007B57 RID: 31575
		DrawBuffer1Ext = 34854,
		// Token: 0x04007B58 RID: 31576
		DrawBuffer1Nv = 34854,
		// Token: 0x04007B59 RID: 31577
		DrawBuffer2,
		// Token: 0x04007B5A RID: 31578
		DrawBuffer2Ext = 34855,
		// Token: 0x04007B5B RID: 31579
		DrawBuffer2Nv = 34855,
		// Token: 0x04007B5C RID: 31580
		DrawBuffer3,
		// Token: 0x04007B5D RID: 31581
		DrawBuffer3Ext = 34856,
		// Token: 0x04007B5E RID: 31582
		DrawBuffer3Nv = 34856,
		// Token: 0x04007B5F RID: 31583
		DrawBuffer4,
		// Token: 0x04007B60 RID: 31584
		DrawBuffer4Ext = 34857,
		// Token: 0x04007B61 RID: 31585
		DrawBuffer4Nv = 34857,
		// Token: 0x04007B62 RID: 31586
		DrawBuffer5,
		// Token: 0x04007B63 RID: 31587
		DrawBuffer5Ext = 34858,
		// Token: 0x04007B64 RID: 31588
		DrawBuffer5Nv = 34858,
		// Token: 0x04007B65 RID: 31589
		DrawBuffer6,
		// Token: 0x04007B66 RID: 31590
		DrawBuffer6Ext = 34859,
		// Token: 0x04007B67 RID: 31591
		DrawBuffer6Nv = 34859,
		// Token: 0x04007B68 RID: 31592
		DrawBuffer7,
		// Token: 0x04007B69 RID: 31593
		DrawBuffer7Ext = 34860,
		// Token: 0x04007B6A RID: 31594
		DrawBuffer7Nv = 34860,
		// Token: 0x04007B6B RID: 31595
		DrawBuffer8,
		// Token: 0x04007B6C RID: 31596
		DrawBuffer8Ext = 34861,
		// Token: 0x04007B6D RID: 31597
		DrawBuffer8Nv = 34861,
		// Token: 0x04007B6E RID: 31598
		DrawBuffer9,
		// Token: 0x04007B6F RID: 31599
		DrawBuffer9Ext = 34862,
		// Token: 0x04007B70 RID: 31600
		DrawBuffer9Nv = 34862,
		// Token: 0x04007B71 RID: 31601
		DrawBuffer10,
		// Token: 0x04007B72 RID: 31602
		DrawBuffer10Ext = 34863,
		// Token: 0x04007B73 RID: 31603
		DrawBuffer10Nv = 34863,
		// Token: 0x04007B74 RID: 31604
		DrawBuffer11,
		// Token: 0x04007B75 RID: 31605
		DrawBuffer11Ext = 34864,
		// Token: 0x04007B76 RID: 31606
		DrawBuffer11Nv = 34864,
		// Token: 0x04007B77 RID: 31607
		DrawBuffer12,
		// Token: 0x04007B78 RID: 31608
		DrawBuffer12Ext = 34865,
		// Token: 0x04007B79 RID: 31609
		DrawBuffer12Nv = 34865,
		// Token: 0x04007B7A RID: 31610
		DrawBuffer13,
		// Token: 0x04007B7B RID: 31611
		DrawBuffer13Ext = 34866,
		// Token: 0x04007B7C RID: 31612
		DrawBuffer13Nv = 34866,
		// Token: 0x04007B7D RID: 31613
		DrawBuffer14,
		// Token: 0x04007B7E RID: 31614
		DrawBuffer14Ext = 34867,
		// Token: 0x04007B7F RID: 31615
		DrawBuffer14Nv = 34867,
		// Token: 0x04007B80 RID: 31616
		DrawBuffer15,
		// Token: 0x04007B81 RID: 31617
		DrawBuffer15Ext = 34868,
		// Token: 0x04007B82 RID: 31618
		DrawBuffer15Nv = 34868,
		// Token: 0x04007B83 RID: 31619
		BlendEquationAlpha = 34877,
		// Token: 0x04007B84 RID: 31620
		TextureCompareMode = 34892,
		// Token: 0x04007B85 RID: 31621
		TextureCompareModeExt = 34892,
		// Token: 0x04007B86 RID: 31622
		TextureCompareFunc,
		// Token: 0x04007B87 RID: 31623
		TextureCompareFuncExt = 34893,
		// Token: 0x04007B88 RID: 31624
		CompareRefToTexture,
		// Token: 0x04007B89 RID: 31625
		CompareRefToTextureExt = 34894,
		// Token: 0x04007B8A RID: 31626
		QueryCounterBitsExt = 34916,
		// Token: 0x04007B8B RID: 31627
		CurrentQuery,
		// Token: 0x04007B8C RID: 31628
		CurrentQueryExt = 34917,
		// Token: 0x04007B8D RID: 31629
		QueryResult,
		// Token: 0x04007B8E RID: 31630
		QueryResultExt = 34918,
		// Token: 0x04007B8F RID: 31631
		QueryResultAvailable,
		// Token: 0x04007B90 RID: 31632
		QueryResultAvailableExt = 34919,
		// Token: 0x04007B91 RID: 31633
		MaxVertexAttribs = 34921,
		// Token: 0x04007B92 RID: 31634
		VertexAttribArrayNormalized,
		// Token: 0x04007B93 RID: 31635
		MaxTessControlInputComponentsExt = 34924,
		// Token: 0x04007B94 RID: 31636
		MaxTessEvaluationInputComponentsExt,
		// Token: 0x04007B95 RID: 31637
		MaxTextureImageUnits = 34930,
		// Token: 0x04007B96 RID: 31638
		GeometryShaderInvocationsExt = 34943,
		// Token: 0x04007B97 RID: 31639
		ArrayBuffer = 34962,
		// Token: 0x04007B98 RID: 31640
		ElementArrayBuffer,
		// Token: 0x04007B99 RID: 31641
		ArrayBufferBinding,
		// Token: 0x04007B9A RID: 31642
		ElementArrayBufferBinding,
		// Token: 0x04007B9B RID: 31643
		VertexAttribArrayBufferBinding = 34975,
		// Token: 0x04007B9C RID: 31644
		WriteOnlyOes = 35001,
		// Token: 0x04007B9D RID: 31645
		BufferAccessOes = 35003,
		// Token: 0x04007B9E RID: 31646
		BufferMapped,
		// Token: 0x04007B9F RID: 31647
		BufferMappedOes = 35004,
		// Token: 0x04007BA0 RID: 31648
		BufferMapPointer,
		// Token: 0x04007BA1 RID: 31649
		BufferMapPointerOes = 35005,
		// Token: 0x04007BA2 RID: 31650
		TimeElapsedExt = 35007,
		// Token: 0x04007BA3 RID: 31651
		StreamDraw = 35040,
		// Token: 0x04007BA4 RID: 31652
		StreamRead,
		// Token: 0x04007BA5 RID: 31653
		StreamCopy,
		// Token: 0x04007BA6 RID: 31654
		StaticDraw = 35044,
		// Token: 0x04007BA7 RID: 31655
		StaticRead,
		// Token: 0x04007BA8 RID: 31656
		StaticCopy,
		// Token: 0x04007BA9 RID: 31657
		DynamicDraw = 35048,
		// Token: 0x04007BAA RID: 31658
		DynamicRead,
		// Token: 0x04007BAB RID: 31659
		DynamicCopy,
		// Token: 0x04007BAC RID: 31660
		PixelPackBuffer,
		// Token: 0x04007BAD RID: 31661
		PixelUnpackBuffer,
		// Token: 0x04007BAE RID: 31662
		PixelPackBufferBinding,
		// Token: 0x04007BAF RID: 31663
		Etc1Srgb8Nv,
		// Token: 0x04007BB0 RID: 31664
		PixelUnpackBufferBinding,
		// Token: 0x04007BB1 RID: 31665
		Depth24Stencil8,
		// Token: 0x04007BB2 RID: 31666
		Depth24Stencil8Oes = 35056,
		// Token: 0x04007BB3 RID: 31667
		VertexAttribArrayInteger = 35069,
		// Token: 0x04007BB4 RID: 31668
		VertexAttribArrayDivisor,
		// Token: 0x04007BB5 RID: 31669
		VertexAttribArrayDivisorAngle = 35070,
		// Token: 0x04007BB6 RID: 31670
		VertexAttribArrayDivisorExt = 35070,
		// Token: 0x04007BB7 RID: 31671
		VertexAttribArrayDivisorNv = 35070,
		// Token: 0x04007BB8 RID: 31672
		MaxArrayTextureLayers,
		// Token: 0x04007BB9 RID: 31673
		MinProgramTexelOffset = 35076,
		// Token: 0x04007BBA RID: 31674
		MaxProgramTexelOffset,
		// Token: 0x04007BBB RID: 31675
		GeometryLinkedVerticesOutExt = 35094,
		// Token: 0x04007BBC RID: 31676
		GeometryLinkedInputTypeExt,
		// Token: 0x04007BBD RID: 31677
		GeometryLinkedOutputTypeExt,
		// Token: 0x04007BBE RID: 31678
		SamplerBinding,
		// Token: 0x04007BBF RID: 31679
		PackResampleOml = 35204,
		// Token: 0x04007BC0 RID: 31680
		UnpackResampleOml,
		// Token: 0x04007BC1 RID: 31681
		UniformBuffer = 35345,
		// Token: 0x04007BC2 RID: 31682
		Rgb422Apple = 35359,
		// Token: 0x04007BC3 RID: 31683
		UniformBufferBinding = 35368,
		// Token: 0x04007BC4 RID: 31684
		UniformBufferStart,
		// Token: 0x04007BC5 RID: 31685
		UniformBufferSize,
		// Token: 0x04007BC6 RID: 31686
		MaxVertexUniformBlocks,
		// Token: 0x04007BC7 RID: 31687
		MaxGeometryUniformBlocksExt,
		// Token: 0x04007BC8 RID: 31688
		MaxFragmentUniformBlocks,
		// Token: 0x04007BC9 RID: 31689
		MaxCombinedUniformBlocks,
		// Token: 0x04007BCA RID: 31690
		MaxUniformBufferBindings,
		// Token: 0x04007BCB RID: 31691
		MaxUniformBlockSize,
		// Token: 0x04007BCC RID: 31692
		MaxCombinedVertexUniformComponents,
		// Token: 0x04007BCD RID: 31693
		MaxCombinedGeometryUniformComponentsExt,
		// Token: 0x04007BCE RID: 31694
		MaxCombinedFragmentUniformComponents,
		// Token: 0x04007BCF RID: 31695
		UniformBufferOffsetAlignment,
		// Token: 0x04007BD0 RID: 31696
		ActiveUniformBlockMaxNameLength,
		// Token: 0x04007BD1 RID: 31697
		ActiveUniformBlocks,
		// Token: 0x04007BD2 RID: 31698
		UniformType,
		// Token: 0x04007BD3 RID: 31699
		UniformSize,
		// Token: 0x04007BD4 RID: 31700
		UniformNameLength,
		// Token: 0x04007BD5 RID: 31701
		UniformBlockIndex,
		// Token: 0x04007BD6 RID: 31702
		UniformOffset,
		// Token: 0x04007BD7 RID: 31703
		UniformArrayStride,
		// Token: 0x04007BD8 RID: 31704
		UniformMatrixStride,
		// Token: 0x04007BD9 RID: 31705
		UniformIsRowMajor,
		// Token: 0x04007BDA RID: 31706
		UniformBlockBinding,
		// Token: 0x04007BDB RID: 31707
		UniformBlockDataSize,
		// Token: 0x04007BDC RID: 31708
		UniformBlockNameLength,
		// Token: 0x04007BDD RID: 31709
		UniformBlockActiveUniforms,
		// Token: 0x04007BDE RID: 31710
		UniformBlockActiveUniformIndices,
		// Token: 0x04007BDF RID: 31711
		UniformBlockReferencedByVertexShader,
		// Token: 0x04007BE0 RID: 31712
		UniformBlockReferencedByFragmentShader = 35398,
		// Token: 0x04007BE1 RID: 31713
		TextureSrgbDecodeExt = 35400,
		// Token: 0x04007BE2 RID: 31714
		DecodeExt,
		// Token: 0x04007BE3 RID: 31715
		SkipDecodeExt,
		// Token: 0x04007BE4 RID: 31716
		ProgramPipelineObjectExt = 35407,
		// Token: 0x04007BE5 RID: 31717
		RgbRaw422Apple = 35409,
		// Token: 0x04007BE6 RID: 31718
		FragmentShaderDiscardsSamplesExt,
		// Token: 0x04007BE7 RID: 31719
		SyncObjectApple,
		// Token: 0x04007BE8 RID: 31720
		CompressedSrgbPvrtc2Bppv1Ext,
		// Token: 0x04007BE9 RID: 31721
		CompressedSrgbPvrtc4Bppv1Ext,
		// Token: 0x04007BEA RID: 31722
		CompressedSrgbAlphaPvrtc2Bppv1Ext,
		// Token: 0x04007BEB RID: 31723
		CompressedSrgbAlphaPvrtc4Bppv1Ext,
		// Token: 0x04007BEC RID: 31724
		FragmentShader = 35632,
		// Token: 0x04007BED RID: 31725
		VertexShader,
		// Token: 0x04007BEE RID: 31726
		ProgramObjectExt = 35648,
		// Token: 0x04007BEF RID: 31727
		ShaderObjectExt = 35656,
		// Token: 0x04007BF0 RID: 31728
		MaxFragmentUniformComponents,
		// Token: 0x04007BF1 RID: 31729
		MaxVertexUniformComponents,
		// Token: 0x04007BF2 RID: 31730
		MaxVaryingComponents,
		// Token: 0x04007BF3 RID: 31731
		MaxVertexTextureImageUnits,
		// Token: 0x04007BF4 RID: 31732
		MaxCombinedTextureImageUnits,
		// Token: 0x04007BF5 RID: 31733
		ShaderType = 35663,
		// Token: 0x04007BF6 RID: 31734
		FloatVec2,
		// Token: 0x04007BF7 RID: 31735
		FloatVec3,
		// Token: 0x04007BF8 RID: 31736
		FloatVec4,
		// Token: 0x04007BF9 RID: 31737
		IntVec2,
		// Token: 0x04007BFA RID: 31738
		IntVec3,
		// Token: 0x04007BFB RID: 31739
		IntVec4,
		// Token: 0x04007BFC RID: 31740
		Bool,
		// Token: 0x04007BFD RID: 31741
		BoolVec2,
		// Token: 0x04007BFE RID: 31742
		BoolVec3,
		// Token: 0x04007BFF RID: 31743
		BoolVec4,
		// Token: 0x04007C00 RID: 31744
		FloatMat2,
		// Token: 0x04007C01 RID: 31745
		FloatMat3,
		// Token: 0x04007C02 RID: 31746
		FloatMat4,
		// Token: 0x04007C03 RID: 31747
		Sampler2D = 35678,
		// Token: 0x04007C04 RID: 31748
		Sampler3D,
		// Token: 0x04007C05 RID: 31749
		Sampler3DOes = 35679,
		// Token: 0x04007C06 RID: 31750
		SamplerCube,
		// Token: 0x04007C07 RID: 31751
		Sampler2DShadow = 35682,
		// Token: 0x04007C08 RID: 31752
		Sampler2DShadowExt = 35682,
		// Token: 0x04007C09 RID: 31753
		FloatMat2x3 = 35685,
		// Token: 0x04007C0A RID: 31754
		FloatMat2x3Nv = 35685,
		// Token: 0x04007C0B RID: 31755
		FloatMat2x4,
		// Token: 0x04007C0C RID: 31756
		FloatMat2x4Nv = 35686,
		// Token: 0x04007C0D RID: 31757
		FloatMat3x2,
		// Token: 0x04007C0E RID: 31758
		FloatMat3x2Nv = 35687,
		// Token: 0x04007C0F RID: 31759
		FloatMat3x4,
		// Token: 0x04007C10 RID: 31760
		FloatMat3x4Nv = 35688,
		// Token: 0x04007C11 RID: 31761
		FloatMat4x2,
		// Token: 0x04007C12 RID: 31762
		FloatMat4x2Nv = 35689,
		// Token: 0x04007C13 RID: 31763
		FloatMat4x3,
		// Token: 0x04007C14 RID: 31764
		FloatMat4x3Nv = 35690,
		// Token: 0x04007C15 RID: 31765
		DeleteStatus = 35712,
		// Token: 0x04007C16 RID: 31766
		CompileStatus,
		// Token: 0x04007C17 RID: 31767
		LinkStatus,
		// Token: 0x04007C18 RID: 31768
		ValidateStatus,
		// Token: 0x04007C19 RID: 31769
		InfoLogLength,
		// Token: 0x04007C1A RID: 31770
		AttachedShaders,
		// Token: 0x04007C1B RID: 31771
		ActiveUniforms,
		// Token: 0x04007C1C RID: 31772
		ActiveUniformMaxLength,
		// Token: 0x04007C1D RID: 31773
		ShaderSourceLength,
		// Token: 0x04007C1E RID: 31774
		ActiveAttributes,
		// Token: 0x04007C1F RID: 31775
		ActiveAttributeMaxLength,
		// Token: 0x04007C20 RID: 31776
		FragmentShaderDerivativeHint,
		// Token: 0x04007C21 RID: 31777
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x04007C22 RID: 31778
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x04007C23 RID: 31779
		ShadingLanguageVersion,
		// Token: 0x04007C24 RID: 31780
		CurrentProgram,
		// Token: 0x04007C25 RID: 31781
		Palette4Rgb8Oes = 35728,
		// Token: 0x04007C26 RID: 31782
		Palette4Rgba8Oes,
		// Token: 0x04007C27 RID: 31783
		Palette4R5G6B5Oes,
		// Token: 0x04007C28 RID: 31784
		Palette4Rgba4Oes,
		// Token: 0x04007C29 RID: 31785
		Palette4Rgb5A1Oes,
		// Token: 0x04007C2A RID: 31786
		Palette8Rgb8Oes,
		// Token: 0x04007C2B RID: 31787
		Palette8Rgba8Oes,
		// Token: 0x04007C2C RID: 31788
		Palette8R5G6B5Oes,
		// Token: 0x04007C2D RID: 31789
		Palette8Rgba4Oes,
		// Token: 0x04007C2E RID: 31790
		Palette8Rgb5A1Oes,
		// Token: 0x04007C2F RID: 31791
		ImplementationColorReadType,
		// Token: 0x04007C30 RID: 31792
		ImplementationColorReadFormat,
		// Token: 0x04007C31 RID: 31793
		CounterTypeAmd = 35776,
		// Token: 0x04007C32 RID: 31794
		CounterRangeAmd,
		// Token: 0x04007C33 RID: 31795
		UnsignedInt64Amd,
		// Token: 0x04007C34 RID: 31796
		PercentageAmd,
		// Token: 0x04007C35 RID: 31797
		PerfmonResultAvailableAmd,
		// Token: 0x04007C36 RID: 31798
		PerfmonResultSizeAmd,
		// Token: 0x04007C37 RID: 31799
		PerfmonResultAmd,
		// Token: 0x04007C38 RID: 31800
		TextureWidthQcom = 35794,
		// Token: 0x04007C39 RID: 31801
		TextureHeightQcom,
		// Token: 0x04007C3A RID: 31802
		TextureDepthQcom,
		// Token: 0x04007C3B RID: 31803
		TextureInternalFormatQcom,
		// Token: 0x04007C3C RID: 31804
		TextureFormatQcom,
		// Token: 0x04007C3D RID: 31805
		TextureTypeQcom,
		// Token: 0x04007C3E RID: 31806
		TextureImageValidQcom,
		// Token: 0x04007C3F RID: 31807
		TextureNumLevelsQcom,
		// Token: 0x04007C40 RID: 31808
		TextureTargetQcom,
		// Token: 0x04007C41 RID: 31809
		TextureObjectValidQcom,
		// Token: 0x04007C42 RID: 31810
		StateRestore,
		// Token: 0x04007C43 RID: 31811
		CompressedRgbPvrtc4Bppv1Img = 35840,
		// Token: 0x04007C44 RID: 31812
		CompressedRgbPvrtc2Bppv1Img,
		// Token: 0x04007C45 RID: 31813
		CompressedRgbaPvrtc4Bppv1Img,
		// Token: 0x04007C46 RID: 31814
		CompressedRgbaPvrtc2Bppv1Img,
		// Token: 0x04007C47 RID: 31815
		SgxBinaryImg = 35850,
		// Token: 0x04007C48 RID: 31816
		UnsignedNormalized = 35863,
		// Token: 0x04007C49 RID: 31817
		UnsignedNormalizedExt = 35863,
		// Token: 0x04007C4A RID: 31818
		Texture2DArray = 35866,
		// Token: 0x04007C4B RID: 31819
		TextureBinding2DArray = 35869,
		// Token: 0x04007C4C RID: 31820
		MaxGeometryTextureImageUnitsExt = 35881,
		// Token: 0x04007C4D RID: 31821
		TextureBufferBindingExt,
		// Token: 0x04007C4E RID: 31822
		TextureBufferExt = 35882,
		// Token: 0x04007C4F RID: 31823
		MaxTextureBufferSizeExt,
		// Token: 0x04007C50 RID: 31824
		TextureBindingBufferExt,
		// Token: 0x04007C51 RID: 31825
		TextureBufferDataStoreBindingExt,
		// Token: 0x04007C52 RID: 31826
		AnySamplesPassed = 35887,
		// Token: 0x04007C53 RID: 31827
		AnySamplesPassedExt = 35887,
		// Token: 0x04007C54 RID: 31828
		SampleShadingOes = 35894,
		// Token: 0x04007C55 RID: 31829
		MinSampleShadingValueOes,
		// Token: 0x04007C56 RID: 31830
		R11fG11fB10f = 35898,
		// Token: 0x04007C57 RID: 31831
		UnsignedInt10F11F11FRev,
		// Token: 0x04007C58 RID: 31832
		Rgb9E5 = 35901,
		// Token: 0x04007C59 RID: 31833
		UnsignedInt5999Rev,
		// Token: 0x04007C5A RID: 31834
		Srgb = 35904,
		// Token: 0x04007C5B RID: 31835
		SrgbExt = 35904,
		// Token: 0x04007C5C RID: 31836
		Srgb8,
		// Token: 0x04007C5D RID: 31837
		Srgb8Nv = 35905,
		// Token: 0x04007C5E RID: 31838
		SrgbAlphaExt,
		// Token: 0x04007C5F RID: 31839
		Srgb8Alpha8,
		// Token: 0x04007C60 RID: 31840
		Srgb8Alpha8Ext = 35907,
		// Token: 0x04007C61 RID: 31841
		SluminanceAlphaNv,
		// Token: 0x04007C62 RID: 31842
		Sluminance8Alpha8Nv,
		// Token: 0x04007C63 RID: 31843
		SluminanceNv,
		// Token: 0x04007C64 RID: 31844
		Sluminance8Nv,
		// Token: 0x04007C65 RID: 31845
		CompressedSrgbS3tcDxt1Nv = 35916,
		// Token: 0x04007C66 RID: 31846
		CompressedSrgbAlphaS3tcDxt1Nv,
		// Token: 0x04007C67 RID: 31847
		CompressedSrgbAlphaS3tcDxt3Nv,
		// Token: 0x04007C68 RID: 31848
		CompressedSrgbAlphaS3tcDxt5Nv,
		// Token: 0x04007C69 RID: 31849
		TransformFeedbackVaryingMaxLength = 35958,
		// Token: 0x04007C6A RID: 31850
		TransformFeedbackBufferMode = 35967,
		// Token: 0x04007C6B RID: 31851
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x04007C6C RID: 31852
		TransformFeedbackVaryings = 35971,
		// Token: 0x04007C6D RID: 31853
		TransformFeedbackBufferStart,
		// Token: 0x04007C6E RID: 31854
		TransformFeedbackBufferSize,
		// Token: 0x04007C6F RID: 31855
		PrimitivesGeneratedExt = 35975,
		// Token: 0x04007C70 RID: 31856
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04007C71 RID: 31857
		RasterizerDiscard,
		// Token: 0x04007C72 RID: 31858
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x04007C73 RID: 31859
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x04007C74 RID: 31860
		InterleavedAttribs,
		// Token: 0x04007C75 RID: 31861
		SeparateAttribs,
		// Token: 0x04007C76 RID: 31862
		TransformFeedbackBuffer,
		// Token: 0x04007C77 RID: 31863
		TransformFeedbackBufferBinding,
		// Token: 0x04007C78 RID: 31864
		AtcRgbAmd = 35986,
		// Token: 0x04007C79 RID: 31865
		AtcRgbaExplicitAlphaAmd,
		// Token: 0x04007C7A RID: 31866
		StencilBackRef = 36003,
		// Token: 0x04007C7B RID: 31867
		StencilBackValueMask,
		// Token: 0x04007C7C RID: 31868
		StencilBackWritemask,
		// Token: 0x04007C7D RID: 31869
		DrawFramebufferBinding,
		// Token: 0x04007C7E RID: 31870
		DrawFramebufferBindingAngle = 36006,
		// Token: 0x04007C7F RID: 31871
		DrawFramebufferBindingApple = 36006,
		// Token: 0x04007C80 RID: 31872
		DrawFramebufferBindingNv = 36006,
		// Token: 0x04007C81 RID: 31873
		FramebufferBinding = 36006,
		// Token: 0x04007C82 RID: 31874
		RenderbufferBinding,
		// Token: 0x04007C83 RID: 31875
		ReadFramebuffer,
		// Token: 0x04007C84 RID: 31876
		ReadFramebufferAngle = 36008,
		// Token: 0x04007C85 RID: 31877
		ReadFramebufferApple = 36008,
		// Token: 0x04007C86 RID: 31878
		ReadFramebufferNv = 36008,
		// Token: 0x04007C87 RID: 31879
		DrawFramebuffer,
		// Token: 0x04007C88 RID: 31880
		DrawFramebufferAngle = 36009,
		// Token: 0x04007C89 RID: 31881
		DrawFramebufferApple = 36009,
		// Token: 0x04007C8A RID: 31882
		DrawFramebufferNv = 36009,
		// Token: 0x04007C8B RID: 31883
		ReadFramebufferBinding,
		// Token: 0x04007C8C RID: 31884
		ReadFramebufferBindingAngle = 36010,
		// Token: 0x04007C8D RID: 31885
		ReadFramebufferBindingApple = 36010,
		// Token: 0x04007C8E RID: 31886
		ReadFramebufferBindingNv = 36010,
		// Token: 0x04007C8F RID: 31887
		RenderbufferSamples,
		// Token: 0x04007C90 RID: 31888
		RenderbufferSamplesAngle = 36011,
		// Token: 0x04007C91 RID: 31889
		RenderbufferSamplesApple = 36011,
		// Token: 0x04007C92 RID: 31890
		RenderbufferSamplesExt = 36011,
		// Token: 0x04007C93 RID: 31891
		RenderbufferSamplesNv = 36011,
		// Token: 0x04007C94 RID: 31892
		DepthComponent32f,
		// Token: 0x04007C95 RID: 31893
		Depth32fStencil8,
		// Token: 0x04007C96 RID: 31894
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04007C97 RID: 31895
		FramebufferAttachmentObjectName,
		// Token: 0x04007C98 RID: 31896
		FramebufferAttachmentTextureLevel,
		// Token: 0x04007C99 RID: 31897
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04007C9A RID: 31898
		FramebufferAttachmentTexture3DZoffsetOes,
		// Token: 0x04007C9B RID: 31899
		FramebufferAttachmentTextureLayer = 36052,
		// Token: 0x04007C9C RID: 31900
		FramebufferComplete,
		// Token: 0x04007C9D RID: 31901
		FramebufferIncompleteAttachment,
		// Token: 0x04007C9E RID: 31902
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04007C9F RID: 31903
		FramebufferIncompleteDimensions = 36057,
		// Token: 0x04007CA0 RID: 31904
		FramebufferUnsupported = 36061,
		// Token: 0x04007CA1 RID: 31905
		MaxColorAttachments = 36063,
		// Token: 0x04007CA2 RID: 31906
		MaxColorAttachmentsExt = 36063,
		// Token: 0x04007CA3 RID: 31907
		MaxColorAttachmentsNv = 36063,
		// Token: 0x04007CA4 RID: 31908
		ColorAttachment0,
		// Token: 0x04007CA5 RID: 31909
		ColorAttachment0Ext = 36064,
		// Token: 0x04007CA6 RID: 31910
		ColorAttachment0Nv = 36064,
		// Token: 0x04007CA7 RID: 31911
		ColorAttachment1,
		// Token: 0x04007CA8 RID: 31912
		ColorAttachment1Ext = 36065,
		// Token: 0x04007CA9 RID: 31913
		ColorAttachment1Nv = 36065,
		// Token: 0x04007CAA RID: 31914
		ColorAttachment2,
		// Token: 0x04007CAB RID: 31915
		ColorAttachment2Ext = 36066,
		// Token: 0x04007CAC RID: 31916
		ColorAttachment2Nv = 36066,
		// Token: 0x04007CAD RID: 31917
		ColorAttachment3,
		// Token: 0x04007CAE RID: 31918
		ColorAttachment3Ext = 36067,
		// Token: 0x04007CAF RID: 31919
		ColorAttachment3Nv = 36067,
		// Token: 0x04007CB0 RID: 31920
		ColorAttachment4,
		// Token: 0x04007CB1 RID: 31921
		ColorAttachment4Ext = 36068,
		// Token: 0x04007CB2 RID: 31922
		ColorAttachment4Nv = 36068,
		// Token: 0x04007CB3 RID: 31923
		ColorAttachment5,
		// Token: 0x04007CB4 RID: 31924
		ColorAttachment5Ext = 36069,
		// Token: 0x04007CB5 RID: 31925
		ColorAttachment5Nv = 36069,
		// Token: 0x04007CB6 RID: 31926
		ColorAttachment6,
		// Token: 0x04007CB7 RID: 31927
		ColorAttachment6Ext = 36070,
		// Token: 0x04007CB8 RID: 31928
		ColorAttachment6Nv = 36070,
		// Token: 0x04007CB9 RID: 31929
		ColorAttachment7,
		// Token: 0x04007CBA RID: 31930
		ColorAttachment7Ext = 36071,
		// Token: 0x04007CBB RID: 31931
		ColorAttachment7Nv = 36071,
		// Token: 0x04007CBC RID: 31932
		ColorAttachment8,
		// Token: 0x04007CBD RID: 31933
		ColorAttachment8Ext = 36072,
		// Token: 0x04007CBE RID: 31934
		ColorAttachment8Nv = 36072,
		// Token: 0x04007CBF RID: 31935
		ColorAttachment9,
		// Token: 0x04007CC0 RID: 31936
		ColorAttachment9Ext = 36073,
		// Token: 0x04007CC1 RID: 31937
		ColorAttachment9Nv = 36073,
		// Token: 0x04007CC2 RID: 31938
		ColorAttachment10,
		// Token: 0x04007CC3 RID: 31939
		ColorAttachment10Ext = 36074,
		// Token: 0x04007CC4 RID: 31940
		ColorAttachment10Nv = 36074,
		// Token: 0x04007CC5 RID: 31941
		ColorAttachment11,
		// Token: 0x04007CC6 RID: 31942
		ColorAttachment11Ext = 36075,
		// Token: 0x04007CC7 RID: 31943
		ColorAttachment11Nv = 36075,
		// Token: 0x04007CC8 RID: 31944
		ColorAttachment12,
		// Token: 0x04007CC9 RID: 31945
		ColorAttachment12Ext = 36076,
		// Token: 0x04007CCA RID: 31946
		ColorAttachment12Nv = 36076,
		// Token: 0x04007CCB RID: 31947
		ColorAttachment13,
		// Token: 0x04007CCC RID: 31948
		ColorAttachment13Ext = 36077,
		// Token: 0x04007CCD RID: 31949
		ColorAttachment13Nv = 36077,
		// Token: 0x04007CCE RID: 31950
		ColorAttachment14,
		// Token: 0x04007CCF RID: 31951
		ColorAttachment14Ext = 36078,
		// Token: 0x04007CD0 RID: 31952
		ColorAttachment14Nv = 36078,
		// Token: 0x04007CD1 RID: 31953
		ColorAttachment15,
		// Token: 0x04007CD2 RID: 31954
		ColorAttachment15Ext = 36079,
		// Token: 0x04007CD3 RID: 31955
		ColorAttachment15Nv = 36079,
		// Token: 0x04007CD4 RID: 31956
		DepthAttachment = 36096,
		// Token: 0x04007CD5 RID: 31957
		StencilAttachment = 36128,
		// Token: 0x04007CD6 RID: 31958
		Framebuffer = 36160,
		// Token: 0x04007CD7 RID: 31959
		Renderbuffer,
		// Token: 0x04007CD8 RID: 31960
		RenderbufferWidth,
		// Token: 0x04007CD9 RID: 31961
		RenderbufferHeight,
		// Token: 0x04007CDA RID: 31962
		RenderbufferInternalFormat,
		// Token: 0x04007CDB RID: 31963
		StencilIndex1Oes = 36166,
		// Token: 0x04007CDC RID: 31964
		StencilIndex4Oes,
		// Token: 0x04007CDD RID: 31965
		StencilIndex8,
		// Token: 0x04007CDE RID: 31966
		StencilIndex8Oes = 36168,
		// Token: 0x04007CDF RID: 31967
		RenderbufferRedSize = 36176,
		// Token: 0x04007CE0 RID: 31968
		RenderbufferGreenSize,
		// Token: 0x04007CE1 RID: 31969
		RenderbufferBlueSize,
		// Token: 0x04007CE2 RID: 31970
		RenderbufferAlphaSize,
		// Token: 0x04007CE3 RID: 31971
		RenderbufferDepthSize,
		// Token: 0x04007CE4 RID: 31972
		RenderbufferStencilSize,
		// Token: 0x04007CE5 RID: 31973
		FramebufferIncompleteMultisample,
		// Token: 0x04007CE6 RID: 31974
		FramebufferIncompleteMultisampleAngle = 36182,
		// Token: 0x04007CE7 RID: 31975
		FramebufferIncompleteMultisampleApple = 36182,
		// Token: 0x04007CE8 RID: 31976
		FramebufferIncompleteMultisampleExt = 36182,
		// Token: 0x04007CE9 RID: 31977
		FramebufferIncompleteMultisampleNv = 36182,
		// Token: 0x04007CEA RID: 31978
		MaxSamples,
		// Token: 0x04007CEB RID: 31979
		MaxSamplesAngle = 36183,
		// Token: 0x04007CEC RID: 31980
		MaxSamplesApple = 36183,
		// Token: 0x04007CED RID: 31981
		MaxSamplesExt = 36183,
		// Token: 0x04007CEE RID: 31982
		MaxSamplesNv = 36183,
		// Token: 0x04007CEF RID: 31983
		HalfFloatOes = 36193,
		// Token: 0x04007CF0 RID: 31984
		Rgb565Oes,
		// Token: 0x04007CF1 RID: 31985
		Rgb565 = 36194,
		// Token: 0x04007CF2 RID: 31986
		Etc1Rgb8Oes = 36196,
		// Token: 0x04007CF3 RID: 31987
		TextureExternalOes,
		// Token: 0x04007CF4 RID: 31988
		SamplerExternalOes,
		// Token: 0x04007CF5 RID: 31989
		TextureBindingExternalOes,
		// Token: 0x04007CF6 RID: 31990
		RequiredTextureImageUnitsOes,
		// Token: 0x04007CF7 RID: 31991
		PrimitiveRestartFixedIndex,
		// Token: 0x04007CF8 RID: 31992
		AnySamplesPassedConservative,
		// Token: 0x04007CF9 RID: 31993
		AnySamplesPassedConservativeExt = 36202,
		// Token: 0x04007CFA RID: 31994
		MaxElementIndex,
		// Token: 0x04007CFB RID: 31995
		FramebufferAttachmentTextureSamplesExt,
		// Token: 0x04007CFC RID: 31996
		Rgba32ui = 36208,
		// Token: 0x04007CFD RID: 31997
		Rgb32ui,
		// Token: 0x04007CFE RID: 31998
		Rgba16ui = 36214,
		// Token: 0x04007CFF RID: 31999
		Rgb16ui,
		// Token: 0x04007D00 RID: 32000
		Rgba8ui = 36220,
		// Token: 0x04007D01 RID: 32001
		Rgb8ui,
		// Token: 0x04007D02 RID: 32002
		Rgba32i = 36226,
		// Token: 0x04007D03 RID: 32003
		Rgb32i,
		// Token: 0x04007D04 RID: 32004
		Rgba16i = 36232,
		// Token: 0x04007D05 RID: 32005
		Rgb16i,
		// Token: 0x04007D06 RID: 32006
		Rgba8i = 36238,
		// Token: 0x04007D07 RID: 32007
		Rgb8i,
		// Token: 0x04007D08 RID: 32008
		RedInteger = 36244,
		// Token: 0x04007D09 RID: 32009
		RgbInteger = 36248,
		// Token: 0x04007D0A RID: 32010
		RgbaInteger,
		// Token: 0x04007D0B RID: 32011
		Int2101010Rev = 36255,
		// Token: 0x04007D0C RID: 32012
		FramebufferAttachmentLayeredExt = 36263,
		// Token: 0x04007D0D RID: 32013
		FramebufferIncompleteLayerTargetsExt,
		// Token: 0x04007D0E RID: 32014
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x04007D0F RID: 32015
		FramebufferSrgbExt = 36281,
		// Token: 0x04007D10 RID: 32016
		Sampler2DArray = 36289,
		// Token: 0x04007D11 RID: 32017
		SamplerBufferExt,
		// Token: 0x04007D12 RID: 32018
		Sampler2DArrayShadow = 36292,
		// Token: 0x04007D13 RID: 32019
		Sampler2DArrayShadowNv = 36292,
		// Token: 0x04007D14 RID: 32020
		SamplerCubeShadow,
		// Token: 0x04007D15 RID: 32021
		SamplerCubeShadowNv = 36293,
		// Token: 0x04007D16 RID: 32022
		UnsignedIntVec2,
		// Token: 0x04007D17 RID: 32023
		UnsignedIntVec3,
		// Token: 0x04007D18 RID: 32024
		UnsignedIntVec4,
		// Token: 0x04007D19 RID: 32025
		IntSampler2D = 36298,
		// Token: 0x04007D1A RID: 32026
		IntSampler3D,
		// Token: 0x04007D1B RID: 32027
		IntSamplerCube,
		// Token: 0x04007D1C RID: 32028
		IntSampler2DArray = 36303,
		// Token: 0x04007D1D RID: 32029
		IntSamplerBufferExt,
		// Token: 0x04007D1E RID: 32030
		UnsignedIntSampler2D = 36306,
		// Token: 0x04007D1F RID: 32031
		UnsignedIntSampler3D,
		// Token: 0x04007D20 RID: 32032
		UnsignedIntSamplerCube,
		// Token: 0x04007D21 RID: 32033
		UnsignedIntSampler2DArray = 36311,
		// Token: 0x04007D22 RID: 32034
		UnsignedIntSamplerBufferExt,
		// Token: 0x04007D23 RID: 32035
		GeometryShaderExt,
		// Token: 0x04007D24 RID: 32036
		MaxGeometryUniformComponentsExt = 36319,
		// Token: 0x04007D25 RID: 32037
		MaxGeometryOutputVerticesExt,
		// Token: 0x04007D26 RID: 32038
		MaxGeometryTotalOutputComponentsExt,
		// Token: 0x04007D27 RID: 32039
		LowFloat = 36336,
		// Token: 0x04007D28 RID: 32040
		MediumFloat,
		// Token: 0x04007D29 RID: 32041
		HighFloat,
		// Token: 0x04007D2A RID: 32042
		LowInt,
		// Token: 0x04007D2B RID: 32043
		MediumInt,
		// Token: 0x04007D2C RID: 32044
		HighInt,
		// Token: 0x04007D2D RID: 32045
		UnsignedInt1010102Oes,
		// Token: 0x04007D2E RID: 32046
		Int1010102Oes,
		// Token: 0x04007D2F RID: 32047
		ShaderBinaryFormats,
		// Token: 0x04007D30 RID: 32048
		NumShaderBinaryFormats,
		// Token: 0x04007D31 RID: 32049
		ShaderCompiler,
		// Token: 0x04007D32 RID: 32050
		MaxVertexUniformVectors,
		// Token: 0x04007D33 RID: 32051
		MaxVaryingVectors,
		// Token: 0x04007D34 RID: 32052
		MaxFragmentUniformVectors,
		// Token: 0x04007D35 RID: 32053
		MaxCombinedTessControlUniformComponentsExt = 36382,
		// Token: 0x04007D36 RID: 32054
		MaxCombinedTessEvaluationUniformComponentsExt,
		// Token: 0x04007D37 RID: 32055
		TransformFeedback = 36386,
		// Token: 0x04007D38 RID: 32056
		TransformFeedbackPaused,
		// Token: 0x04007D39 RID: 32057
		TransformFeedbackActive,
		// Token: 0x04007D3A RID: 32058
		TransformFeedbackBinding,
		// Token: 0x04007D3B RID: 32059
		TimestampExt = 36392,
		// Token: 0x04007D3C RID: 32060
		DepthComponent16NonlinearNv = 36396,
		// Token: 0x04007D3D RID: 32061
		TextureSwizzleR = 36418,
		// Token: 0x04007D3E RID: 32062
		TextureSwizzleG,
		// Token: 0x04007D3F RID: 32063
		TextureSwizzleB,
		// Token: 0x04007D40 RID: 32064
		TextureSwizzleA,
		// Token: 0x04007D41 RID: 32065
		FirstVertexConventionExt = 36429,
		// Token: 0x04007D42 RID: 32066
		LastVertexConventionExt,
		// Token: 0x04007D43 RID: 32067
		MaxGeometryShaderInvocationsExt = 36442,
		// Token: 0x04007D44 RID: 32068
		MinFragmentInterpolationOffsetOes,
		// Token: 0x04007D45 RID: 32069
		MaxFragmentInterpolationOffsetOes,
		// Token: 0x04007D46 RID: 32070
		FragmentInterpolationOffsetBitsOes,
		// Token: 0x04007D47 RID: 32071
		PatchVerticesExt = 36466,
		// Token: 0x04007D48 RID: 32072
		TessControlOutputVerticesExt = 36469,
		// Token: 0x04007D49 RID: 32073
		TessGenModeExt,
		// Token: 0x04007D4A RID: 32074
		TessGenSpacingExt,
		// Token: 0x04007D4B RID: 32075
		TessGenVertexOrderExt,
		// Token: 0x04007D4C RID: 32076
		TessGenPointModeExt,
		// Token: 0x04007D4D RID: 32077
		IsolinesExt,
		// Token: 0x04007D4E RID: 32078
		FractionalOddExt,
		// Token: 0x04007D4F RID: 32079
		FractionalEvenExt,
		// Token: 0x04007D50 RID: 32080
		MaxPatchVerticesExt,
		// Token: 0x04007D51 RID: 32081
		MaxTessGenLevelExt,
		// Token: 0x04007D52 RID: 32082
		MaxTessControlUniformComponentsExt,
		// Token: 0x04007D53 RID: 32083
		MaxTessEvaluationUniformComponentsExt,
		// Token: 0x04007D54 RID: 32084
		MaxTessControlTextureImageUnitsExt,
		// Token: 0x04007D55 RID: 32085
		MaxTessEvaluationTextureImageUnitsExt,
		// Token: 0x04007D56 RID: 32086
		MaxTessControlOutputComponentsExt,
		// Token: 0x04007D57 RID: 32087
		MaxTessPatchComponentsExt,
		// Token: 0x04007D58 RID: 32088
		MaxTessControlTotalOutputComponentsExt,
		// Token: 0x04007D59 RID: 32089
		MaxTessEvaluationOutputComponentsExt,
		// Token: 0x04007D5A RID: 32090
		TessEvaluationShaderExt,
		// Token: 0x04007D5B RID: 32091
		TessControlShaderExt,
		// Token: 0x04007D5C RID: 32092
		MaxTessControlUniformBlocksExt,
		// Token: 0x04007D5D RID: 32093
		MaxTessEvaluationUniformBlocksExt,
		// Token: 0x04007D5E RID: 32094
		CoverageComponentNv = 36560,
		// Token: 0x04007D5F RID: 32095
		CoverageComponent4Nv,
		// Token: 0x04007D60 RID: 32096
		CoverageAttachmentNv,
		// Token: 0x04007D61 RID: 32097
		CoverageBuffersNv,
		// Token: 0x04007D62 RID: 32098
		CoverageSamplesNv,
		// Token: 0x04007D63 RID: 32099
		CoverageAllFragmentsNv,
		// Token: 0x04007D64 RID: 32100
		CoverageEdgeFragmentsNv,
		// Token: 0x04007D65 RID: 32101
		CoverageAutomaticNv,
		// Token: 0x04007D66 RID: 32102
		CopyReadBuffer = 36662,
		// Token: 0x04007D67 RID: 32103
		CopyReadBufferBinding = 36662,
		// Token: 0x04007D68 RID: 32104
		CopyReadBufferNv = 36662,
		// Token: 0x04007D69 RID: 32105
		CopyWriteBuffer,
		// Token: 0x04007D6A RID: 32106
		CopyWriteBufferBinding = 36663,
		// Token: 0x04007D6B RID: 32107
		CopyWriteBufferNv = 36663,
		// Token: 0x04007D6C RID: 32108
		MaliShaderBinaryArm = 36704,
		// Token: 0x04007D6D RID: 32109
		MaliProgramBinaryArm,
		// Token: 0x04007D6E RID: 32110
		MaxShaderPixelLocalStorageFastSizeExt = 36707,
		// Token: 0x04007D6F RID: 32111
		ShaderPixelLocalStorageExt,
		// Token: 0x04007D70 RID: 32112
		FetchPerSampleArm,
		// Token: 0x04007D71 RID: 32113
		FragmentShaderFramebufferFetchMrtArm,
		// Token: 0x04007D72 RID: 32114
		MaxShaderPixelLocalStorageSizeExt,
		// Token: 0x04007D73 RID: 32115
		R8Snorm = 36756,
		// Token: 0x04007D74 RID: 32116
		Rg8Snorm,
		// Token: 0x04007D75 RID: 32117
		Rgb8Snorm,
		// Token: 0x04007D76 RID: 32118
		Rgba8Snorm,
		// Token: 0x04007D77 RID: 32119
		SignedNormalized = 36764,
		// Token: 0x04007D78 RID: 32120
		PerfmonGlobalModeQcom = 36768,
		// Token: 0x04007D79 RID: 32121
		BinningControlHintQcom = 36784,
		// Token: 0x04007D7A RID: 32122
		CpuOptimizedQcom,
		// Token: 0x04007D7B RID: 32123
		GpuOptimizedQcom,
		// Token: 0x04007D7C RID: 32124
		RenderDirectToFramebufferQcom,
		// Token: 0x04007D7D RID: 32125
		GpuDisjointExt = 36795,
		// Token: 0x04007D7E RID: 32126
		ShaderBinaryViv = 36804,
		// Token: 0x04007D7F RID: 32127
		TextureCubeMapArrayExt = 36873,
		// Token: 0x04007D80 RID: 32128
		TextureBindingCubeMapArrayExt,
		// Token: 0x04007D81 RID: 32129
		SamplerCubeMapArrayExt = 36876,
		// Token: 0x04007D82 RID: 32130
		SamplerCubeMapArrayShadowExt,
		// Token: 0x04007D83 RID: 32131
		IntSamplerCubeMapArrayExt,
		// Token: 0x04007D84 RID: 32132
		UnsignedIntSamplerCubeMapArrayExt,
		// Token: 0x04007D85 RID: 32133
		ImageBufferExt = 36945,
		// Token: 0x04007D86 RID: 32134
		ImageCubeMapArrayExt = 36948,
		// Token: 0x04007D87 RID: 32135
		IntImageBufferExt = 36956,
		// Token: 0x04007D88 RID: 32136
		IntImageCubeMapArrayExt = 36959,
		// Token: 0x04007D89 RID: 32137
		UnsignedIntImageBufferExt = 36967,
		// Token: 0x04007D8A RID: 32138
		UnsignedIntImageCubeMapArrayExt = 36970,
		// Token: 0x04007D8B RID: 32139
		Rgb10A2ui = 36975,
		// Token: 0x04007D8C RID: 32140
		MaxTessControlImageUniformsExt = 37067,
		// Token: 0x04007D8D RID: 32141
		MaxTessEvaluationImageUniformsExt,
		// Token: 0x04007D8E RID: 32142
		MaxGeometryImageUniformsExt,
		// Token: 0x04007D8F RID: 32143
		MaxGeometryShaderStorageBlocksExt = 37079,
		// Token: 0x04007D90 RID: 32144
		MaxTessControlShaderStorageBlocksExt,
		// Token: 0x04007D91 RID: 32145
		MaxTessEvaluationShaderStorageBlocksExt,
		// Token: 0x04007D92 RID: 32146
		ColorAttachmentExt = 37104,
		// Token: 0x04007D93 RID: 32147
		MultiviewExt,
		// Token: 0x04007D94 RID: 32148
		MaxMultiviewBuffersExt,
		// Token: 0x04007D95 RID: 32149
		ContextRobustAccessExt,
		// Token: 0x04007D96 RID: 32150
		Texture2DMultisampleArrayOes = 37122,
		// Token: 0x04007D97 RID: 32151
		TextureBinding2DMultisampleArrayOes = 37125,
		// Token: 0x04007D98 RID: 32152
		Sampler2DMultisampleArrayOes = 37131,
		// Token: 0x04007D99 RID: 32153
		IntSampler2DMultisampleArrayOes,
		// Token: 0x04007D9A RID: 32154
		UnsignedIntSampler2DMultisampleArrayOes,
		// Token: 0x04007D9B RID: 32155
		MaxServerWaitTimeout = 37137,
		// Token: 0x04007D9C RID: 32156
		MaxServerWaitTimeoutApple = 37137,
		// Token: 0x04007D9D RID: 32157
		ObjectType,
		// Token: 0x04007D9E RID: 32158
		ObjectTypeApple = 37138,
		// Token: 0x04007D9F RID: 32159
		SyncCondition,
		// Token: 0x04007DA0 RID: 32160
		SyncConditionApple = 37139,
		// Token: 0x04007DA1 RID: 32161
		SyncStatus,
		// Token: 0x04007DA2 RID: 32162
		SyncStatusApple = 37140,
		// Token: 0x04007DA3 RID: 32163
		SyncFlags,
		// Token: 0x04007DA4 RID: 32164
		SyncFlagsApple = 37141,
		// Token: 0x04007DA5 RID: 32165
		SyncFence,
		// Token: 0x04007DA6 RID: 32166
		SyncFenceApple = 37142,
		// Token: 0x04007DA7 RID: 32167
		SyncGpuCommandsComplete,
		// Token: 0x04007DA8 RID: 32168
		SyncGpuCommandsCompleteApple = 37143,
		// Token: 0x04007DA9 RID: 32169
		Unsignaled,
		// Token: 0x04007DAA RID: 32170
		UnsignaledApple = 37144,
		// Token: 0x04007DAB RID: 32171
		Signaled,
		// Token: 0x04007DAC RID: 32172
		SignaledApple = 37145,
		// Token: 0x04007DAD RID: 32173
		AlreadySignaled,
		// Token: 0x04007DAE RID: 32174
		AlreadySignaledApple = 37146,
		// Token: 0x04007DAF RID: 32175
		TimeoutExpired,
		// Token: 0x04007DB0 RID: 32176
		TimeoutExpiredApple = 37147,
		// Token: 0x04007DB1 RID: 32177
		ConditionSatisfied,
		// Token: 0x04007DB2 RID: 32178
		ConditionSatisfiedApple = 37148,
		// Token: 0x04007DB3 RID: 32179
		WaitFailed,
		// Token: 0x04007DB4 RID: 32180
		WaitFailedApple = 37149,
		// Token: 0x04007DB5 RID: 32181
		BufferAccessFlags = 37151,
		// Token: 0x04007DB6 RID: 32182
		BufferMapLength,
		// Token: 0x04007DB7 RID: 32183
		BufferMapOffset,
		// Token: 0x04007DB8 RID: 32184
		MaxVertexOutputComponents,
		// Token: 0x04007DB9 RID: 32185
		MaxGeometryInputComponentsExt,
		// Token: 0x04007DBA RID: 32186
		MaxGeometryOutputComponentsExt,
		// Token: 0x04007DBB RID: 32187
		MaxFragmentInputComponents,
		// Token: 0x04007DBC RID: 32188
		TextureImmutableFormat = 37167,
		// Token: 0x04007DBD RID: 32189
		TextureImmutableFormatExt = 37167,
		// Token: 0x04007DBE RID: 32190
		SgxProgramBinaryImg,
		// Token: 0x04007DBF RID: 32191
		RenderbufferSamplesImg = 37171,
		// Token: 0x04007DC0 RID: 32192
		FramebufferIncompleteMultisampleImg,
		// Token: 0x04007DC1 RID: 32193
		MaxSamplesImg,
		// Token: 0x04007DC2 RID: 32194
		TextureSamplesImg,
		// Token: 0x04007DC3 RID: 32195
		CompressedRgbaPvrtc2Bppv2Img,
		// Token: 0x04007DC4 RID: 32196
		CompressedRgbaPvrtc4Bppv2Img,
		// Token: 0x04007DC5 RID: 32197
		MaxDebugMessageLength = 37187,
		// Token: 0x04007DC6 RID: 32198
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04007DC7 RID: 32199
		MaxDebugLoggedMessages,
		// Token: 0x04007DC8 RID: 32200
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04007DC9 RID: 32201
		DebugLoggedMessages,
		// Token: 0x04007DCA RID: 32202
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x04007DCB RID: 32203
		DebugSeverityHigh,
		// Token: 0x04007DCC RID: 32204
		DebugSeverityHighKhr = 37190,
		// Token: 0x04007DCD RID: 32205
		DebugSeverityMedium,
		// Token: 0x04007DCE RID: 32206
		DebugSeverityMediumKhr = 37191,
		// Token: 0x04007DCF RID: 32207
		DebugSeverityLow,
		// Token: 0x04007DD0 RID: 32208
		DebugSeverityLowKhr = 37192,
		// Token: 0x04007DD1 RID: 32209
		BufferObjectExt = 37201,
		// Token: 0x04007DD2 RID: 32210
		QueryObjectExt = 37203,
		// Token: 0x04007DD3 RID: 32211
		VertexArrayObjectExt,
		// Token: 0x04007DD4 RID: 32212
		TextureBufferOffsetExt = 37277,
		// Token: 0x04007DD5 RID: 32213
		TextureBufferSizeExt,
		// Token: 0x04007DD6 RID: 32214
		TextureBufferOffsetAlignmentExt,
		// Token: 0x04007DD7 RID: 32215
		ShaderBinaryDmp = 37456,
		// Token: 0x04007DD8 RID: 32216
		GccsoShaderBinaryFj = 37472,
		// Token: 0x04007DD9 RID: 32217
		CompressedR11Eac = 37488,
		// Token: 0x04007DDA RID: 32218
		CompressedSignedR11Eac,
		// Token: 0x04007DDB RID: 32219
		CompressedRg11Eac,
		// Token: 0x04007DDC RID: 32220
		CompressedSignedRg11Eac,
		// Token: 0x04007DDD RID: 32221
		CompressedRgb8Etc2,
		// Token: 0x04007DDE RID: 32222
		CompressedSrgb8Etc2,
		// Token: 0x04007DDF RID: 32223
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x04007DE0 RID: 32224
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x04007DE1 RID: 32225
		CompressedRgba8Etc2Eac,
		// Token: 0x04007DE2 RID: 32226
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x04007DE3 RID: 32227
		BlendPremultipliedSrcNv = 37504,
		// Token: 0x04007DE4 RID: 32228
		BlendOverlapNv,
		// Token: 0x04007DE5 RID: 32229
		UncorrelatedNv,
		// Token: 0x04007DE6 RID: 32230
		DisjointNv,
		// Token: 0x04007DE7 RID: 32231
		ConjointNv,
		// Token: 0x04007DE8 RID: 32232
		BlendAdvancedCoherentKhr,
		// Token: 0x04007DE9 RID: 32233
		BlendAdvancedCoherentNv = 37509,
		// Token: 0x04007DEA RID: 32234
		SrcNv,
		// Token: 0x04007DEB RID: 32235
		DstNv,
		// Token: 0x04007DEC RID: 32236
		SrcOverNv,
		// Token: 0x04007DED RID: 32237
		DstOverNv,
		// Token: 0x04007DEE RID: 32238
		SrcInNv,
		// Token: 0x04007DEF RID: 32239
		DstInNv,
		// Token: 0x04007DF0 RID: 32240
		SrcOutNv,
		// Token: 0x04007DF1 RID: 32241
		DstOutNv,
		// Token: 0x04007DF2 RID: 32242
		SrcAtopNv,
		// Token: 0x04007DF3 RID: 32243
		DstAtopNv,
		// Token: 0x04007DF4 RID: 32244
		PlusNv = 37521,
		// Token: 0x04007DF5 RID: 32245
		PlusDarkerNv,
		// Token: 0x04007DF6 RID: 32246
		MultiplyKhr = 37524,
		// Token: 0x04007DF7 RID: 32247
		MultiplyNv = 37524,
		// Token: 0x04007DF8 RID: 32248
		ScreenKhr,
		// Token: 0x04007DF9 RID: 32249
		ScreenNv = 37525,
		// Token: 0x04007DFA RID: 32250
		OverlayKhr,
		// Token: 0x04007DFB RID: 32251
		OverlayNv = 37526,
		// Token: 0x04007DFC RID: 32252
		DarkenKhr,
		// Token: 0x04007DFD RID: 32253
		DarkenNv = 37527,
		// Token: 0x04007DFE RID: 32254
		LightenKhr,
		// Token: 0x04007DFF RID: 32255
		LightenNv = 37528,
		// Token: 0x04007E00 RID: 32256
		ColordodgeKhr,
		// Token: 0x04007E01 RID: 32257
		ColordodgeNv = 37529,
		// Token: 0x04007E02 RID: 32258
		ColorburnKhr,
		// Token: 0x04007E03 RID: 32259
		ColorburnNv = 37530,
		// Token: 0x04007E04 RID: 32260
		HardlightKhr,
		// Token: 0x04007E05 RID: 32261
		HardlightNv = 37531,
		// Token: 0x04007E06 RID: 32262
		SoftlightKhr,
		// Token: 0x04007E07 RID: 32263
		SoftlightNv = 37532,
		// Token: 0x04007E08 RID: 32264
		DifferenceKhr = 37534,
		// Token: 0x04007E09 RID: 32265
		DifferenceNv = 37534,
		// Token: 0x04007E0A RID: 32266
		MinusNv,
		// Token: 0x04007E0B RID: 32267
		ExclusionKhr,
		// Token: 0x04007E0C RID: 32268
		ExclusionNv = 37536,
		// Token: 0x04007E0D RID: 32269
		ContrastNv,
		// Token: 0x04007E0E RID: 32270
		InvertRgbNv = 37539,
		// Token: 0x04007E0F RID: 32271
		LineardodgeNv,
		// Token: 0x04007E10 RID: 32272
		LinearburnNv,
		// Token: 0x04007E11 RID: 32273
		VividlightNv,
		// Token: 0x04007E12 RID: 32274
		LinearlightNv,
		// Token: 0x04007E13 RID: 32275
		PinlightNv,
		// Token: 0x04007E14 RID: 32276
		HardmixNv,
		// Token: 0x04007E15 RID: 32277
		HslHueKhr = 37549,
		// Token: 0x04007E16 RID: 32278
		HslHueNv = 37549,
		// Token: 0x04007E17 RID: 32279
		HslSaturationKhr,
		// Token: 0x04007E18 RID: 32280
		HslSaturationNv = 37550,
		// Token: 0x04007E19 RID: 32281
		HslColorKhr,
		// Token: 0x04007E1A RID: 32282
		HslColorNv = 37551,
		// Token: 0x04007E1B RID: 32283
		HslLuminosityKhr,
		// Token: 0x04007E1C RID: 32284
		HslLuminosityNv = 37552,
		// Token: 0x04007E1D RID: 32285
		PlusClampedNv,
		// Token: 0x04007E1E RID: 32286
		PlusClampedAlphaNv,
		// Token: 0x04007E1F RID: 32287
		MinusClampedNv,
		// Token: 0x04007E20 RID: 32288
		InvertOvgNv,
		// Token: 0x04007E21 RID: 32289
		PrimitiveBoundingBoxExt = 37566,
		// Token: 0x04007E22 RID: 32290
		MaxTessControlAtomicCounterBuffersExt = 37581,
		// Token: 0x04007E23 RID: 32291
		MaxTessEvaluationAtomicCounterBuffersExt,
		// Token: 0x04007E24 RID: 32292
		MaxGeometryAtomicCounterBuffersExt,
		// Token: 0x04007E25 RID: 32293
		MaxTessControlAtomicCountersExt = 37587,
		// Token: 0x04007E26 RID: 32294
		MaxTessEvaluationAtomicCountersExt,
		// Token: 0x04007E27 RID: 32295
		MaxGeometryAtomicCountersExt,
		// Token: 0x04007E28 RID: 32296
		DebugOutput = 37600,
		// Token: 0x04007E29 RID: 32297
		DebugOutputKhr = 37600,
		// Token: 0x04007E2A RID: 32298
		IsPerPatchExt = 37607,
		// Token: 0x04007E2B RID: 32299
		ReferencedByTessControlShaderExt = 37639,
		// Token: 0x04007E2C RID: 32300
		ReferencedByTessEvaluationShaderExt,
		// Token: 0x04007E2D RID: 32301
		ReferencedByGeometryShaderExt,
		// Token: 0x04007E2E RID: 32302
		FramebufferDefaultLayersExt = 37650,
		// Token: 0x04007E2F RID: 32303
		MaxFramebufferLayersExt = 37655,
		// Token: 0x04007E30 RID: 32304
		NumSampleCounts = 37760,
		// Token: 0x04007E31 RID: 32305
		TranslatedShaderSourceLengthAngle = 37792,
		// Token: 0x04007E32 RID: 32306
		Bgra8Ext,
		// Token: 0x04007E33 RID: 32307
		TextureUsageAngle,
		// Token: 0x04007E34 RID: 32308
		FramebufferAttachmentAngle,
		// Token: 0x04007E35 RID: 32309
		PackReverseRowOrderAngle,
		// Token: 0x04007E36 RID: 32310
		ProgramBinaryAngle = 37798,
		// Token: 0x04007E37 RID: 32311
		CompressedRgbaAstc4X4Khr = 37808,
		// Token: 0x04007E38 RID: 32312
		CompressedRgbaAstc5X4Khr,
		// Token: 0x04007E39 RID: 32313
		CompressedRgbaAstc5X5Khr,
		// Token: 0x04007E3A RID: 32314
		CompressedRgbaAstc6X5Khr,
		// Token: 0x04007E3B RID: 32315
		CompressedRgbaAstc6X6Khr,
		// Token: 0x04007E3C RID: 32316
		CompressedRgbaAstc8X5Khr,
		// Token: 0x04007E3D RID: 32317
		CompressedRgbaAstc8X6Khr,
		// Token: 0x04007E3E RID: 32318
		CompressedRgbaAstc8X8Khr,
		// Token: 0x04007E3F RID: 32319
		CompressedRgbaAstc10X5Khr,
		// Token: 0x04007E40 RID: 32320
		CompressedRgbaAstc10X6Khr,
		// Token: 0x04007E41 RID: 32321
		CompressedRgbaAstc10X8Khr,
		// Token: 0x04007E42 RID: 32322
		CompressedRgbaAstc10X10Khr,
		// Token: 0x04007E43 RID: 32323
		CompressedRgbaAstc12X10Khr,
		// Token: 0x04007E44 RID: 32324
		CompressedRgbaAstc12X12Khr,
		// Token: 0x04007E45 RID: 32325
		CompressedRgbaAstc3X3x3Oes = 37824,
		// Token: 0x04007E46 RID: 32326
		CompressedRgbaAstc4X3x3Oes,
		// Token: 0x04007E47 RID: 32327
		CompressedRgbaAstc4X4x3Oes,
		// Token: 0x04007E48 RID: 32328
		CompressedRgbaAstc4X4x4Oes,
		// Token: 0x04007E49 RID: 32329
		CompressedRgbaAstc5X4x4Oes,
		// Token: 0x04007E4A RID: 32330
		CompressedRgbaAstc5X5x4Oes,
		// Token: 0x04007E4B RID: 32331
		CompressedRgbaAstc5X5x5Oes,
		// Token: 0x04007E4C RID: 32332
		CompressedRgbaAstc6X5x5Oes,
		// Token: 0x04007E4D RID: 32333
		CompressedRgbaAstc6X6x5Oes,
		// Token: 0x04007E4E RID: 32334
		CompressedRgbaAstc6X6x6Oes,
		// Token: 0x04007E4F RID: 32335
		CompressedSrgb8Alpha8Astc4X4Khr = 37840,
		// Token: 0x04007E50 RID: 32336
		CompressedSrgb8Alpha8Astc5X4Khr,
		// Token: 0x04007E51 RID: 32337
		CompressedSrgb8Alpha8Astc5X5Khr,
		// Token: 0x04007E52 RID: 32338
		CompressedSrgb8Alpha8Astc6X5Khr,
		// Token: 0x04007E53 RID: 32339
		CompressedSrgb8Alpha8Astc6X6Khr,
		// Token: 0x04007E54 RID: 32340
		CompressedSrgb8Alpha8Astc8X5Khr,
		// Token: 0x04007E55 RID: 32341
		CompressedSrgb8Alpha8Astc8X6Khr,
		// Token: 0x04007E56 RID: 32342
		CompressedSrgb8Alpha8Astc8X8Khr,
		// Token: 0x04007E57 RID: 32343
		CompressedSrgb8Alpha8Astc10X5Khr,
		// Token: 0x04007E58 RID: 32344
		CompressedSrgb8Alpha8Astc10X6Khr,
		// Token: 0x04007E59 RID: 32345
		CompressedSrgb8Alpha8Astc10X8Khr,
		// Token: 0x04007E5A RID: 32346
		CompressedSrgb8Alpha8Astc10X10Khr,
		// Token: 0x04007E5B RID: 32347
		CompressedSrgb8Alpha8Astc12X10Khr,
		// Token: 0x04007E5C RID: 32348
		CompressedSrgb8Alpha8Astc12X12Khr,
		// Token: 0x04007E5D RID: 32349
		CompressedSrgb8Alpha8Astc3X3x3Oes = 37856,
		// Token: 0x04007E5E RID: 32350
		CompressedSrgb8Alpha8Astc4X3x3Oes,
		// Token: 0x04007E5F RID: 32351
		CompressedSrgb8Alpha8Astc4X4x3Oes,
		// Token: 0x04007E60 RID: 32352
		CompressedSrgb8Alpha8Astc4X4x4Oes,
		// Token: 0x04007E61 RID: 32353
		CompressedSrgb8Alpha8Astc5X4x4Oes,
		// Token: 0x04007E62 RID: 32354
		CompressedSrgb8Alpha8Astc5X5x4Oes,
		// Token: 0x04007E63 RID: 32355
		CompressedSrgb8Alpha8Astc5X5x5Oes,
		// Token: 0x04007E64 RID: 32356
		CompressedSrgb8Alpha8Astc6X5x5Oes,
		// Token: 0x04007E65 RID: 32357
		CompressedSrgb8Alpha8Astc6X6x5Oes,
		// Token: 0x04007E66 RID: 32358
		CompressedSrgb8Alpha8Astc6X6x6Oes,
		// Token: 0x04007E67 RID: 32359
		CompressedSrgbAlphaPvrtc2Bppv2Img = 37872,
		// Token: 0x04007E68 RID: 32360
		CompressedSrgbAlphaPvrtc4Bppv2Img,
		// Token: 0x04007E69 RID: 32361
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x04007E6A RID: 32362
		PerfqueryCounterDurationNormIntel,
		// Token: 0x04007E6B RID: 32363
		PerfqueryCounterDurationRawIntel,
		// Token: 0x04007E6C RID: 32364
		PerfqueryCounterThroughputIntel,
		// Token: 0x04007E6D RID: 32365
		PerfqueryCounterRawIntel,
		// Token: 0x04007E6E RID: 32366
		PerfqueryCounterTimestampIntel,
		// Token: 0x04007E6F RID: 32367
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x04007E70 RID: 32368
		PerfqueryCounterDataUint64Intel,
		// Token: 0x04007E71 RID: 32369
		PerfqueryCounterDataFloatIntel,
		// Token: 0x04007E72 RID: 32370
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x04007E73 RID: 32371
		PerfqueryCounterDataBool32Intel,
		// Token: 0x04007E74 RID: 32372
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x04007E75 RID: 32373
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x04007E76 RID: 32374
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x04007E77 RID: 32375
		PerfqueryGpaExtendedCountersIntel,
		// Token: 0x04007E78 RID: 32376
		AllAttribBits = -1,
		// Token: 0x04007E79 RID: 32377
		AllBarrierBits = -1,
		// Token: 0x04007E7A RID: 32378
		AllBarrierBitsExt = -1,
		// Token: 0x04007E7B RID: 32379
		AllShaderBits = -1,
		// Token: 0x04007E7C RID: 32380
		AllShaderBitsExt = -1,
		// Token: 0x04007E7D RID: 32381
		ClientAllAttribBits = -1,
		// Token: 0x04007E7E RID: 32382
		InvalidIndex = -1,
		// Token: 0x04007E7F RID: 32383
		QueryAllEventBitsAmd = -1,
		// Token: 0x04007E80 RID: 32384
		TimeoutIgnored = -1,
		// Token: 0x04007E81 RID: 32385
		TimeoutIgnoredApple = -1,
		// Token: 0x04007E82 RID: 32386
		LayoutLinearIntel = 1,
		// Token: 0x04007E83 RID: 32387
		One = 1,
		// Token: 0x04007E84 RID: 32388
		True = 1,
		// Token: 0x04007E85 RID: 32389
		LayoutLinearCpuCachedIntel
	}
}
