using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A5B RID: 2651
	public enum HintTarget
	{
		// Token: 0x0400AE32 RID: 44594
		PerspectiveCorrectionHint = 3152,
		// Token: 0x0400AE33 RID: 44595
		PointSmoothHint,
		// Token: 0x0400AE34 RID: 44596
		LineSmoothHint,
		// Token: 0x0400AE35 RID: 44597
		PolygonSmoothHint,
		// Token: 0x0400AE36 RID: 44598
		FogHint,
		// Token: 0x0400AE37 RID: 44599
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x0400AE38 RID: 44600
		ConserveMemoryHintPgi = 107005,
		// Token: 0x0400AE39 RID: 44601
		ReclaimMemoryHintPgi,
		// Token: 0x0400AE3A RID: 44602
		NativeGraphicsBeginHintPgi = 107011,
		// Token: 0x0400AE3B RID: 44603
		NativeGraphicsEndHintPgi,
		// Token: 0x0400AE3C RID: 44604
		AlwaysFastHintPgi = 107020,
		// Token: 0x0400AE3D RID: 44605
		AlwaysSoftHintPgi,
		// Token: 0x0400AE3E RID: 44606
		AllowDrawObjHintPgi,
		// Token: 0x0400AE3F RID: 44607
		AllowDrawWinHintPgi,
		// Token: 0x0400AE40 RID: 44608
		AllowDrawFrgHintPgi,
		// Token: 0x0400AE41 RID: 44609
		AllowDrawMemHintPgi,
		// Token: 0x0400AE42 RID: 44610
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x0400AE43 RID: 44611
		StrictLightingHintPgi,
		// Token: 0x0400AE44 RID: 44612
		StrictScissorHintPgi,
		// Token: 0x0400AE45 RID: 44613
		FullStippleHintPgi,
		// Token: 0x0400AE46 RID: 44614
		ClipNearHintPgi = 107040,
		// Token: 0x0400AE47 RID: 44615
		ClipFarHintPgi,
		// Token: 0x0400AE48 RID: 44616
		WideLineHintPgi,
		// Token: 0x0400AE49 RID: 44617
		BackNormalsHintPgi,
		// Token: 0x0400AE4A RID: 44618
		VertexDataHintPgi = 107050,
		// Token: 0x0400AE4B RID: 44619
		VertexConsistentHintPgi,
		// Token: 0x0400AE4C RID: 44620
		MaterialSideHintPgi,
		// Token: 0x0400AE4D RID: 44621
		MaxVertexHintPgi,
		// Token: 0x0400AE4E RID: 44622
		PackCmykHintExt = 32782,
		// Token: 0x0400AE4F RID: 44623
		UnpackCmykHintExt,
		// Token: 0x0400AE50 RID: 44624
		PhongHintWin = 33003,
		// Token: 0x0400AE51 RID: 44625
		ClipVolumeClippingHintExt = 33008,
		// Token: 0x0400AE52 RID: 44626
		TextureMultiBufferHintSgix = 33070,
		// Token: 0x0400AE53 RID: 44627
		GenerateMipmapHint = 33170,
		// Token: 0x0400AE54 RID: 44628
		GenerateMipmapHintSgis = 33170,
		// Token: 0x0400AE55 RID: 44629
		ProgramBinaryRetrievableHint = 33367,
		// Token: 0x0400AE56 RID: 44630
		ConvolutionHintSgix = 33558,
		// Token: 0x0400AE57 RID: 44631
		ScalebiasHintSgix = 33570,
		// Token: 0x0400AE58 RID: 44632
		LineQualityHintSgix = 33627,
		// Token: 0x0400AE59 RID: 44633
		VertexPreclipSgix = 33774,
		// Token: 0x0400AE5A RID: 44634
		VertexPreclipHintSgix,
		// Token: 0x0400AE5B RID: 44635
		TextureCompressionHint = 34031,
		// Token: 0x0400AE5C RID: 44636
		TextureCompressionHintArb = 34031,
		// Token: 0x0400AE5D RID: 44637
		VertexArrayStorageHintApple = 34079,
		// Token: 0x0400AE5E RID: 44638
		MultisampleFilterHintNv = 34100,
		// Token: 0x0400AE5F RID: 44639
		TransformHintApple = 34225,
		// Token: 0x0400AE60 RID: 44640
		TextureStorageHintApple = 34236,
		// Token: 0x0400AE61 RID: 44641
		FragmentShaderDerivativeHint = 35723,
		// Token: 0x0400AE62 RID: 44642
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x0400AE63 RID: 44643
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x0400AE64 RID: 44644
		BinningControlHintQcom = 36784
	}
}
