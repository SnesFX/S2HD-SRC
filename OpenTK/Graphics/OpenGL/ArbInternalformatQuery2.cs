using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000226 RID: 550
	public enum ArbInternalformatQuery2
	{
		// Token: 0x0400280A RID: 10250
		Texture1D = 3552,
		// Token: 0x0400280B RID: 10251
		Texture2D,
		// Token: 0x0400280C RID: 10252
		Texture3D = 32879,
		// Token: 0x0400280D RID: 10253
		Samples = 32937,
		// Token: 0x0400280E RID: 10254
		InternalformatSupported = 33391,
		// Token: 0x0400280F RID: 10255
		InternalformatPreferred,
		// Token: 0x04002810 RID: 10256
		InternalformatRedSize,
		// Token: 0x04002811 RID: 10257
		InternalformatGreenSize,
		// Token: 0x04002812 RID: 10258
		InternalformatBlueSize,
		// Token: 0x04002813 RID: 10259
		InternalformatAlphaSize,
		// Token: 0x04002814 RID: 10260
		InternalformatDepthSize,
		// Token: 0x04002815 RID: 10261
		InternalformatStencilSize,
		// Token: 0x04002816 RID: 10262
		InternalformatSharedSize,
		// Token: 0x04002817 RID: 10263
		InternalformatRedType,
		// Token: 0x04002818 RID: 10264
		InternalformatGreenType,
		// Token: 0x04002819 RID: 10265
		InternalformatBlueType,
		// Token: 0x0400281A RID: 10266
		InternalformatAlphaType,
		// Token: 0x0400281B RID: 10267
		InternalformatDepthType,
		// Token: 0x0400281C RID: 10268
		InternalformatStencilType,
		// Token: 0x0400281D RID: 10269
		MaxWidth,
		// Token: 0x0400281E RID: 10270
		MaxHeight,
		// Token: 0x0400281F RID: 10271
		MaxDepth,
		// Token: 0x04002820 RID: 10272
		MaxLayers,
		// Token: 0x04002821 RID: 10273
		MaxCombinedDimensions,
		// Token: 0x04002822 RID: 10274
		ColorComponents,
		// Token: 0x04002823 RID: 10275
		DepthComponents,
		// Token: 0x04002824 RID: 10276
		StencilComponents,
		// Token: 0x04002825 RID: 10277
		ColorRenderable,
		// Token: 0x04002826 RID: 10278
		DepthRenderable,
		// Token: 0x04002827 RID: 10279
		StencilRenderable,
		// Token: 0x04002828 RID: 10280
		FramebufferRenderable,
		// Token: 0x04002829 RID: 10281
		FramebufferRenderableLayered,
		// Token: 0x0400282A RID: 10282
		FramebufferBlend,
		// Token: 0x0400282B RID: 10283
		ReadPixels,
		// Token: 0x0400282C RID: 10284
		ReadPixelsFormat,
		// Token: 0x0400282D RID: 10285
		ReadPixelsType,
		// Token: 0x0400282E RID: 10286
		TextureImageFormat,
		// Token: 0x0400282F RID: 10287
		TextureImageType,
		// Token: 0x04002830 RID: 10288
		GetTextureImageFormat,
		// Token: 0x04002831 RID: 10289
		GetTextureImageType,
		// Token: 0x04002832 RID: 10290
		Mipmap,
		// Token: 0x04002833 RID: 10291
		ManualGenerateMipmap,
		// Token: 0x04002834 RID: 10292
		AutoGenerateMipmap,
		// Token: 0x04002835 RID: 10293
		ColorEncoding,
		// Token: 0x04002836 RID: 10294
		SrgbRead,
		// Token: 0x04002837 RID: 10295
		SrgbWrite,
		// Token: 0x04002838 RID: 10296
		SrgbDecodeArb,
		// Token: 0x04002839 RID: 10297
		Filter,
		// Token: 0x0400283A RID: 10298
		VertexTexture,
		// Token: 0x0400283B RID: 10299
		TessControlTexture,
		// Token: 0x0400283C RID: 10300
		TessEvaluationTexture,
		// Token: 0x0400283D RID: 10301
		GeometryTexture,
		// Token: 0x0400283E RID: 10302
		FragmentTexture,
		// Token: 0x0400283F RID: 10303
		ComputeTexture,
		// Token: 0x04002840 RID: 10304
		TextureShadow,
		// Token: 0x04002841 RID: 10305
		TextureGather,
		// Token: 0x04002842 RID: 10306
		TextureGatherShadow,
		// Token: 0x04002843 RID: 10307
		ShaderImageLoad,
		// Token: 0x04002844 RID: 10308
		ShaderImageStore,
		// Token: 0x04002845 RID: 10309
		ShaderImageAtomic,
		// Token: 0x04002846 RID: 10310
		ImageTexelSize,
		// Token: 0x04002847 RID: 10311
		ImageCompatibilityClass,
		// Token: 0x04002848 RID: 10312
		ImagePixelFormat,
		// Token: 0x04002849 RID: 10313
		ImagePixelType,
		// Token: 0x0400284A RID: 10314
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x0400284B RID: 10315
		SimultaneousTextureAndStencilTest,
		// Token: 0x0400284C RID: 10316
		SimultaneousTextureAndDepthWrite,
		// Token: 0x0400284D RID: 10317
		SimultaneousTextureAndStencilWrite,
		// Token: 0x0400284E RID: 10318
		TextureCompressedBlockWidth = 33457,
		// Token: 0x0400284F RID: 10319
		TextureCompressedBlockHeight,
		// Token: 0x04002850 RID: 10320
		TextureCompressedBlockSize,
		// Token: 0x04002851 RID: 10321
		ClearBuffer,
		// Token: 0x04002852 RID: 10322
		TextureView,
		// Token: 0x04002853 RID: 10323
		ViewCompatibilityClass,
		// Token: 0x04002854 RID: 10324
		FullSupport,
		// Token: 0x04002855 RID: 10325
		CaveatSupport,
		// Token: 0x04002856 RID: 10326
		ImageClass4X32,
		// Token: 0x04002857 RID: 10327
		ImageClass2X32,
		// Token: 0x04002858 RID: 10328
		ImageClass1X32,
		// Token: 0x04002859 RID: 10329
		ImageClass4X16,
		// Token: 0x0400285A RID: 10330
		ImageClass2X16,
		// Token: 0x0400285B RID: 10331
		ImageClass1X16,
		// Token: 0x0400285C RID: 10332
		ImageClass4X8,
		// Token: 0x0400285D RID: 10333
		ImageClass2X8,
		// Token: 0x0400285E RID: 10334
		ImageClass1X8,
		// Token: 0x0400285F RID: 10335
		ImageClass111110,
		// Token: 0x04002860 RID: 10336
		ImageClass1010102,
		// Token: 0x04002861 RID: 10337
		ViewClass128Bits,
		// Token: 0x04002862 RID: 10338
		ViewClass96Bits,
		// Token: 0x04002863 RID: 10339
		ViewClass64Bits,
		// Token: 0x04002864 RID: 10340
		ViewClass48Bits,
		// Token: 0x04002865 RID: 10341
		ViewClass32Bits,
		// Token: 0x04002866 RID: 10342
		ViewClass24Bits,
		// Token: 0x04002867 RID: 10343
		ViewClass16Bits,
		// Token: 0x04002868 RID: 10344
		ViewClass8Bits,
		// Token: 0x04002869 RID: 10345
		ViewClassS3tcDxt1Rgb,
		// Token: 0x0400286A RID: 10346
		ViewClassS3tcDxt1Rgba,
		// Token: 0x0400286B RID: 10347
		ViewClassS3tcDxt3Rgba,
		// Token: 0x0400286C RID: 10348
		ViewClassS3tcDxt5Rgba,
		// Token: 0x0400286D RID: 10349
		ViewClassRgtc1Red,
		// Token: 0x0400286E RID: 10350
		ViewClassRgtc2Rg,
		// Token: 0x0400286F RID: 10351
		ViewClassBptcUnorm,
		// Token: 0x04002870 RID: 10352
		ViewClassBptcFloat,
		// Token: 0x04002871 RID: 10353
		TextureRectangle = 34037,
		// Token: 0x04002872 RID: 10354
		TextureCubeMap = 34067,
		// Token: 0x04002873 RID: 10355
		TextureCompressed = 34465,
		// Token: 0x04002874 RID: 10356
		Texture1DArray = 35864,
		// Token: 0x04002875 RID: 10357
		Texture2DArray = 35866,
		// Token: 0x04002876 RID: 10358
		TextureBuffer = 35882,
		// Token: 0x04002877 RID: 10359
		Renderbuffer = 36161,
		// Token: 0x04002878 RID: 10360
		TextureCubeMapArray = 36873,
		// Token: 0x04002879 RID: 10361
		ImageFormatCompatibilityType = 37063,
		// Token: 0x0400287A RID: 10362
		Texture2DMultisample = 37120,
		// Token: 0x0400287B RID: 10363
		Texture2DMultisampleArray = 37122,
		// Token: 0x0400287C RID: 10364
		NumSampleCounts = 37760
	}
}
