using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020003DB RID: 987
	public enum NvTextureShader
	{
		// Token: 0x04003BE3 RID: 15331
		OffsetTextureRectangleNv = 34380,
		// Token: 0x04003BE4 RID: 15332
		OffsetTextureRectangleScaleNv,
		// Token: 0x04003BE5 RID: 15333
		DotProductTextureRectangleNv,
		// Token: 0x04003BE6 RID: 15334
		RgbaUnsignedDotProductMappingNv = 34521,
		// Token: 0x04003BE7 RID: 15335
		UnsignedIntS8S888Nv,
		// Token: 0x04003BE8 RID: 15336
		UnsignedInt88S8S8RevNv,
		// Token: 0x04003BE9 RID: 15337
		DsdtMagIntensityNv,
		// Token: 0x04003BEA RID: 15338
		ShaderConsistentNv,
		// Token: 0x04003BEB RID: 15339
		TextureShaderNv,
		// Token: 0x04003BEC RID: 15340
		ShaderOperationNv,
		// Token: 0x04003BED RID: 15341
		CullModesNv,
		// Token: 0x04003BEE RID: 15342
		OffsetTexture2DMatrixNv,
		// Token: 0x04003BEF RID: 15343
		OffsetTextureMatrixNv = 34529,
		// Token: 0x04003BF0 RID: 15344
		OffsetTexture2DScaleNv,
		// Token: 0x04003BF1 RID: 15345
		OffsetTextureScaleNv = 34530,
		// Token: 0x04003BF2 RID: 15346
		OffsetTexture2DBiasNv,
		// Token: 0x04003BF3 RID: 15347
		OffsetTextureBiasNv = 34531,
		// Token: 0x04003BF4 RID: 15348
		PreviousTextureInputNv,
		// Token: 0x04003BF5 RID: 15349
		ConstEyeNv,
		// Token: 0x04003BF6 RID: 15350
		PassThroughNv,
		// Token: 0x04003BF7 RID: 15351
		CullFragmentNv,
		// Token: 0x04003BF8 RID: 15352
		OffsetTexture2DNv,
		// Token: 0x04003BF9 RID: 15353
		DependentArTexture2DNv,
		// Token: 0x04003BFA RID: 15354
		DependentGbTexture2DNv,
		// Token: 0x04003BFB RID: 15355
		DotProductNv = 34540,
		// Token: 0x04003BFC RID: 15356
		DotProductDepthReplaceNv,
		// Token: 0x04003BFD RID: 15357
		DotProductTexture2DNv,
		// Token: 0x04003BFE RID: 15358
		DotProductTextureCubeMapNv = 34544,
		// Token: 0x04003BFF RID: 15359
		DotProductDiffuseCubeMapNv,
		// Token: 0x04003C00 RID: 15360
		DotProductReflectCubeMapNv,
		// Token: 0x04003C01 RID: 15361
		DotProductConstEyeReflectCubeMapNv,
		// Token: 0x04003C02 RID: 15362
		HiloNv,
		// Token: 0x04003C03 RID: 15363
		DsdtNv,
		// Token: 0x04003C04 RID: 15364
		DsdtMagNv,
		// Token: 0x04003C05 RID: 15365
		DsdtMagVibNv,
		// Token: 0x04003C06 RID: 15366
		Hilo16Nv,
		// Token: 0x04003C07 RID: 15367
		SignedHiloNv,
		// Token: 0x04003C08 RID: 15368
		SignedHilo16Nv,
		// Token: 0x04003C09 RID: 15369
		SignedRgbaNv,
		// Token: 0x04003C0A RID: 15370
		SignedRgba8Nv,
		// Token: 0x04003C0B RID: 15371
		SignedRgbNv = 34558,
		// Token: 0x04003C0C RID: 15372
		SignedRgb8Nv,
		// Token: 0x04003C0D RID: 15373
		SignedLuminanceNv = 34561,
		// Token: 0x04003C0E RID: 15374
		SignedLuminance8Nv,
		// Token: 0x04003C0F RID: 15375
		SignedLuminanceAlphaNv,
		// Token: 0x04003C10 RID: 15376
		SignedLuminance8Alpha8Nv,
		// Token: 0x04003C11 RID: 15377
		SignedAlphaNv,
		// Token: 0x04003C12 RID: 15378
		SignedAlpha8Nv,
		// Token: 0x04003C13 RID: 15379
		SignedIntensityNv,
		// Token: 0x04003C14 RID: 15380
		SignedIntensity8Nv,
		// Token: 0x04003C15 RID: 15381
		Dsdt8Nv,
		// Token: 0x04003C16 RID: 15382
		Dsdt8Mag8Nv,
		// Token: 0x04003C17 RID: 15383
		Dsdt8Mag8Intensity8Nv,
		// Token: 0x04003C18 RID: 15384
		SignedRgbUnsignedAlphaNv,
		// Token: 0x04003C19 RID: 15385
		SignedRgb8UnsignedAlpha8Nv,
		// Token: 0x04003C1A RID: 15386
		HiScaleNv,
		// Token: 0x04003C1B RID: 15387
		LoScaleNv,
		// Token: 0x04003C1C RID: 15388
		DsScaleNv,
		// Token: 0x04003C1D RID: 15389
		DtScaleNv,
		// Token: 0x04003C1E RID: 15390
		MagnitudeScaleNv,
		// Token: 0x04003C1F RID: 15391
		VibranceScaleNv,
		// Token: 0x04003C20 RID: 15392
		HiBiasNv,
		// Token: 0x04003C21 RID: 15393
		LoBiasNv,
		// Token: 0x04003C22 RID: 15394
		DsBiasNv,
		// Token: 0x04003C23 RID: 15395
		DtBiasNv,
		// Token: 0x04003C24 RID: 15396
		MagnitudeBiasNv,
		// Token: 0x04003C25 RID: 15397
		VibranceBiasNv,
		// Token: 0x04003C26 RID: 15398
		TextureBorderValuesNv,
		// Token: 0x04003C27 RID: 15399
		TextureHiSizeNv,
		// Token: 0x04003C28 RID: 15400
		TextureLoSizeNv,
		// Token: 0x04003C29 RID: 15401
		TextureDsSizeNv,
		// Token: 0x04003C2A RID: 15402
		TextureDtSizeNv,
		// Token: 0x04003C2B RID: 15403
		TextureMagSizeNv
	}
}
