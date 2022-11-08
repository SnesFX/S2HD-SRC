using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200049C RID: 1180
	public enum Version30
	{
		// Token: 0x04004708 RID: 18184
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x04004709 RID: 18185
		MapReadBit = 1,
		// Token: 0x0400470A RID: 18186
		MapWriteBit,
		// Token: 0x0400470B RID: 18187
		MapInvalidateRangeBit = 4,
		// Token: 0x0400470C RID: 18188
		MapInvalidateBufferBit = 8,
		// Token: 0x0400470D RID: 18189
		MapFlushExplicitBit = 16,
		// Token: 0x0400470E RID: 18190
		MapUnsynchronizedBit = 32,
		// Token: 0x0400470F RID: 18191
		InvalidFramebufferOperation = 1286,
		// Token: 0x04004710 RID: 18192
		MaxClipDistances = 3378,
		// Token: 0x04004711 RID: 18193
		HalfFloat = 5131,
		// Token: 0x04004712 RID: 18194
		ClipDistance0 = 12288,
		// Token: 0x04004713 RID: 18195
		ClipDistance1,
		// Token: 0x04004714 RID: 18196
		ClipDistance2,
		// Token: 0x04004715 RID: 18197
		ClipDistance3,
		// Token: 0x04004716 RID: 18198
		ClipDistance4,
		// Token: 0x04004717 RID: 18199
		ClipDistance5,
		// Token: 0x04004718 RID: 18200
		ClipDistance6,
		// Token: 0x04004719 RID: 18201
		ClipDistance7,
		// Token: 0x0400471A RID: 18202
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x0400471B RID: 18203
		FramebufferAttachmentComponentType,
		// Token: 0x0400471C RID: 18204
		FramebufferAttachmentRedSize,
		// Token: 0x0400471D RID: 18205
		FramebufferAttachmentGreenSize,
		// Token: 0x0400471E RID: 18206
		FramebufferAttachmentBlueSize,
		// Token: 0x0400471F RID: 18207
		FramebufferAttachmentAlphaSize,
		// Token: 0x04004720 RID: 18208
		FramebufferAttachmentDepthSize,
		// Token: 0x04004721 RID: 18209
		FramebufferAttachmentStencilSize,
		// Token: 0x04004722 RID: 18210
		FramebufferDefault,
		// Token: 0x04004723 RID: 18211
		FramebufferUndefined,
		// Token: 0x04004724 RID: 18212
		DepthStencilAttachment,
		// Token: 0x04004725 RID: 18213
		MajorVersion,
		// Token: 0x04004726 RID: 18214
		MinorVersion,
		// Token: 0x04004727 RID: 18215
		NumExtensions,
		// Token: 0x04004728 RID: 18216
		ContextFlags,
		// Token: 0x04004729 RID: 18217
		Index = 33314,
		// Token: 0x0400472A RID: 18218
		CompressedRed = 33317,
		// Token: 0x0400472B RID: 18219
		CompressedRg,
		// Token: 0x0400472C RID: 18220
		Rg,
		// Token: 0x0400472D RID: 18221
		RgInteger,
		// Token: 0x0400472E RID: 18222
		R8,
		// Token: 0x0400472F RID: 18223
		R16,
		// Token: 0x04004730 RID: 18224
		Rg8,
		// Token: 0x04004731 RID: 18225
		Rg16,
		// Token: 0x04004732 RID: 18226
		R16f,
		// Token: 0x04004733 RID: 18227
		R32f,
		// Token: 0x04004734 RID: 18228
		Rg16f,
		// Token: 0x04004735 RID: 18229
		Rg32f,
		// Token: 0x04004736 RID: 18230
		R8i,
		// Token: 0x04004737 RID: 18231
		R8ui,
		// Token: 0x04004738 RID: 18232
		R16i,
		// Token: 0x04004739 RID: 18233
		R16ui,
		// Token: 0x0400473A RID: 18234
		R32i,
		// Token: 0x0400473B RID: 18235
		R32ui,
		// Token: 0x0400473C RID: 18236
		Rg8i,
		// Token: 0x0400473D RID: 18237
		Rg8ui,
		// Token: 0x0400473E RID: 18238
		Rg16i,
		// Token: 0x0400473F RID: 18239
		Rg16ui,
		// Token: 0x04004740 RID: 18240
		Rg32i,
		// Token: 0x04004741 RID: 18241
		Rg32ui,
		// Token: 0x04004742 RID: 18242
		MaxRenderbufferSize = 34024,
		// Token: 0x04004743 RID: 18243
		DepthStencil = 34041,
		// Token: 0x04004744 RID: 18244
		UnsignedInt248,
		// Token: 0x04004745 RID: 18245
		VertexArrayBinding = 34229,
		// Token: 0x04004746 RID: 18246
		Rgba32f = 34836,
		// Token: 0x04004747 RID: 18247
		Rgb32f,
		// Token: 0x04004748 RID: 18248
		Rgba16f = 34842,
		// Token: 0x04004749 RID: 18249
		Rgb16f,
		// Token: 0x0400474A RID: 18250
		CompareRefToTexture = 34894,
		// Token: 0x0400474B RID: 18251
		Depth24Stencil8 = 35056,
		// Token: 0x0400474C RID: 18252
		TextureStencilSize,
		// Token: 0x0400474D RID: 18253
		VertexAttribArrayInteger = 35069,
		// Token: 0x0400474E RID: 18254
		MaxArrayTextureLayers = 35071,
		// Token: 0x0400474F RID: 18255
		MinProgramTexelOffset = 35076,
		// Token: 0x04004750 RID: 18256
		MaxProgramTexelOffset,
		// Token: 0x04004751 RID: 18257
		ClampVertexColor = 35098,
		// Token: 0x04004752 RID: 18258
		ClampFragmentColor,
		// Token: 0x04004753 RID: 18259
		ClampReadColor,
		// Token: 0x04004754 RID: 18260
		FixedOnly,
		// Token: 0x04004755 RID: 18261
		MaxVaryingComponents = 35659,
		// Token: 0x04004756 RID: 18262
		TextureRedType = 35856,
		// Token: 0x04004757 RID: 18263
		TextureGreenType,
		// Token: 0x04004758 RID: 18264
		TextureBlueType,
		// Token: 0x04004759 RID: 18265
		TextureAlphaType,
		// Token: 0x0400475A RID: 18266
		TextureLuminanceType,
		// Token: 0x0400475B RID: 18267
		TextureIntensityType,
		// Token: 0x0400475C RID: 18268
		TextureDepthType,
		// Token: 0x0400475D RID: 18269
		UnsignedNormalized,
		// Token: 0x0400475E RID: 18270
		Texture1DArray,
		// Token: 0x0400475F RID: 18271
		ProxyTexture1DArray,
		// Token: 0x04004760 RID: 18272
		Texture2DArray,
		// Token: 0x04004761 RID: 18273
		ProxyTexture2DArray,
		// Token: 0x04004762 RID: 18274
		TextureBinding1DArray,
		// Token: 0x04004763 RID: 18275
		TextureBinding2DArray,
		// Token: 0x04004764 RID: 18276
		R11fG11fB10f = 35898,
		// Token: 0x04004765 RID: 18277
		UnsignedInt10F11F11FRev,
		// Token: 0x04004766 RID: 18278
		Rgb9E5 = 35901,
		// Token: 0x04004767 RID: 18279
		UnsignedInt5999Rev,
		// Token: 0x04004768 RID: 18280
		TextureSharedSize,
		// Token: 0x04004769 RID: 18281
		TransformFeedbackVaryingMaxLength = 35958,
		// Token: 0x0400476A RID: 18282
		TransformFeedbackBufferMode = 35967,
		// Token: 0x0400476B RID: 18283
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x0400476C RID: 18284
		TransformFeedbackVaryings = 35971,
		// Token: 0x0400476D RID: 18285
		TransformFeedbackBufferStart,
		// Token: 0x0400476E RID: 18286
		TransformFeedbackBufferSize,
		// Token: 0x0400476F RID: 18287
		PrimitivesGenerated = 35975,
		// Token: 0x04004770 RID: 18288
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04004771 RID: 18289
		RasterizerDiscard,
		// Token: 0x04004772 RID: 18290
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x04004773 RID: 18291
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x04004774 RID: 18292
		InterleavedAttribs,
		// Token: 0x04004775 RID: 18293
		SeparateAttribs,
		// Token: 0x04004776 RID: 18294
		TransformFeedbackBuffer,
		// Token: 0x04004777 RID: 18295
		TransformFeedbackBufferBinding,
		// Token: 0x04004778 RID: 18296
		DrawFramebufferBinding = 36006,
		// Token: 0x04004779 RID: 18297
		FramebufferBinding = 36006,
		// Token: 0x0400477A RID: 18298
		RenderbufferBinding,
		// Token: 0x0400477B RID: 18299
		ReadFramebuffer,
		// Token: 0x0400477C RID: 18300
		DrawFramebuffer,
		// Token: 0x0400477D RID: 18301
		ReadFramebufferBinding,
		// Token: 0x0400477E RID: 18302
		RenderbufferSamples,
		// Token: 0x0400477F RID: 18303
		DepthComponent32f,
		// Token: 0x04004780 RID: 18304
		Depth32fStencil8,
		// Token: 0x04004781 RID: 18305
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04004782 RID: 18306
		FramebufferAttachmentObjectName,
		// Token: 0x04004783 RID: 18307
		FramebufferAttachmentTextureLevel,
		// Token: 0x04004784 RID: 18308
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04004785 RID: 18309
		FramebufferAttachmentTextureLayer,
		// Token: 0x04004786 RID: 18310
		FramebufferComplete,
		// Token: 0x04004787 RID: 18311
		FramebufferIncompleteAttachment,
		// Token: 0x04004788 RID: 18312
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04004789 RID: 18313
		FramebufferIncompleteDrawBuffer = 36059,
		// Token: 0x0400478A RID: 18314
		FramebufferIncompleteReadBuffer,
		// Token: 0x0400478B RID: 18315
		FramebufferUnsupported,
		// Token: 0x0400478C RID: 18316
		MaxColorAttachments = 36063,
		// Token: 0x0400478D RID: 18317
		ColorAttachment0,
		// Token: 0x0400478E RID: 18318
		ColorAttachment1,
		// Token: 0x0400478F RID: 18319
		ColorAttachment2,
		// Token: 0x04004790 RID: 18320
		ColorAttachment3,
		// Token: 0x04004791 RID: 18321
		ColorAttachment4,
		// Token: 0x04004792 RID: 18322
		ColorAttachment5,
		// Token: 0x04004793 RID: 18323
		ColorAttachment6,
		// Token: 0x04004794 RID: 18324
		ColorAttachment7,
		// Token: 0x04004795 RID: 18325
		ColorAttachment8,
		// Token: 0x04004796 RID: 18326
		ColorAttachment9,
		// Token: 0x04004797 RID: 18327
		ColorAttachment10,
		// Token: 0x04004798 RID: 18328
		ColorAttachment11,
		// Token: 0x04004799 RID: 18329
		ColorAttachment12,
		// Token: 0x0400479A RID: 18330
		ColorAttachment13,
		// Token: 0x0400479B RID: 18331
		ColorAttachment14,
		// Token: 0x0400479C RID: 18332
		ColorAttachment15,
		// Token: 0x0400479D RID: 18333
		DepthAttachment = 36096,
		// Token: 0x0400479E RID: 18334
		StencilAttachment = 36128,
		// Token: 0x0400479F RID: 18335
		Framebuffer = 36160,
		// Token: 0x040047A0 RID: 18336
		Renderbuffer,
		// Token: 0x040047A1 RID: 18337
		RenderbufferWidth,
		// Token: 0x040047A2 RID: 18338
		RenderbufferHeight,
		// Token: 0x040047A3 RID: 18339
		RenderbufferInternalFormat,
		// Token: 0x040047A4 RID: 18340
		StencilIndex1 = 36166,
		// Token: 0x040047A5 RID: 18341
		StencilIndex4,
		// Token: 0x040047A6 RID: 18342
		StencilIndex8,
		// Token: 0x040047A7 RID: 18343
		StencilIndex16,
		// Token: 0x040047A8 RID: 18344
		RenderbufferRedSize = 36176,
		// Token: 0x040047A9 RID: 18345
		RenderbufferGreenSize,
		// Token: 0x040047AA RID: 18346
		RenderbufferBlueSize,
		// Token: 0x040047AB RID: 18347
		RenderbufferAlphaSize,
		// Token: 0x040047AC RID: 18348
		RenderbufferDepthSize,
		// Token: 0x040047AD RID: 18349
		RenderbufferStencilSize,
		// Token: 0x040047AE RID: 18350
		FramebufferIncompleteMultisample,
		// Token: 0x040047AF RID: 18351
		MaxSamples,
		// Token: 0x040047B0 RID: 18352
		Rgba32ui = 36208,
		// Token: 0x040047B1 RID: 18353
		Rgb32ui,
		// Token: 0x040047B2 RID: 18354
		Rgba16ui = 36214,
		// Token: 0x040047B3 RID: 18355
		Rgb16ui,
		// Token: 0x040047B4 RID: 18356
		Rgba8ui = 36220,
		// Token: 0x040047B5 RID: 18357
		Rgb8ui,
		// Token: 0x040047B6 RID: 18358
		Rgba32i = 36226,
		// Token: 0x040047B7 RID: 18359
		Rgb32i,
		// Token: 0x040047B8 RID: 18360
		Rgba16i = 36232,
		// Token: 0x040047B9 RID: 18361
		Rgb16i,
		// Token: 0x040047BA RID: 18362
		Rgba8i = 36238,
		// Token: 0x040047BB RID: 18363
		Rgb8i,
		// Token: 0x040047BC RID: 18364
		RedInteger = 36244,
		// Token: 0x040047BD RID: 18365
		GreenInteger,
		// Token: 0x040047BE RID: 18366
		BlueInteger,
		// Token: 0x040047BF RID: 18367
		AlphaInteger,
		// Token: 0x040047C0 RID: 18368
		RgbInteger,
		// Token: 0x040047C1 RID: 18369
		RgbaInteger,
		// Token: 0x040047C2 RID: 18370
		BgrInteger,
		// Token: 0x040047C3 RID: 18371
		BgraInteger,
		// Token: 0x040047C4 RID: 18372
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x040047C5 RID: 18373
		FramebufferSrgb = 36281,
		// Token: 0x040047C6 RID: 18374
		CompressedRedRgtc1 = 36283,
		// Token: 0x040047C7 RID: 18375
		CompressedSignedRedRgtc1,
		// Token: 0x040047C8 RID: 18376
		CompressedRgRgtc2,
		// Token: 0x040047C9 RID: 18377
		CompressedSignedRgRgtc2,
		// Token: 0x040047CA RID: 18378
		Sampler1DArray = 36288,
		// Token: 0x040047CB RID: 18379
		Sampler2DArray,
		// Token: 0x040047CC RID: 18380
		Sampler1DArrayShadow = 36291,
		// Token: 0x040047CD RID: 18381
		Sampler2DArrayShadow,
		// Token: 0x040047CE RID: 18382
		SamplerCubeShadow,
		// Token: 0x040047CF RID: 18383
		UnsignedIntVec2,
		// Token: 0x040047D0 RID: 18384
		UnsignedIntVec3,
		// Token: 0x040047D1 RID: 18385
		UnsignedIntVec4,
		// Token: 0x040047D2 RID: 18386
		IntSampler1D,
		// Token: 0x040047D3 RID: 18387
		IntSampler2D,
		// Token: 0x040047D4 RID: 18388
		IntSampler3D,
		// Token: 0x040047D5 RID: 18389
		IntSamplerCube,
		// Token: 0x040047D6 RID: 18390
		IntSampler1DArray = 36302,
		// Token: 0x040047D7 RID: 18391
		IntSampler2DArray,
		// Token: 0x040047D8 RID: 18392
		UnsignedIntSampler1D = 36305,
		// Token: 0x040047D9 RID: 18393
		UnsignedIntSampler2D,
		// Token: 0x040047DA RID: 18394
		UnsignedIntSampler3D,
		// Token: 0x040047DB RID: 18395
		UnsignedIntSamplerCube,
		// Token: 0x040047DC RID: 18396
		UnsignedIntSampler1DArray = 36310,
		// Token: 0x040047DD RID: 18397
		UnsignedIntSampler2DArray,
		// Token: 0x040047DE RID: 18398
		QueryWait = 36371,
		// Token: 0x040047DF RID: 18399
		QueryNoWait,
		// Token: 0x040047E0 RID: 18400
		QueryByRegionWait,
		// Token: 0x040047E1 RID: 18401
		QueryByRegionNoWait,
		// Token: 0x040047E2 RID: 18402
		BufferAccessFlags = 37151,
		// Token: 0x040047E3 RID: 18403
		BufferMapLength,
		// Token: 0x040047E4 RID: 18404
		BufferMapOffset
	}
}
