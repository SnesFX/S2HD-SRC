using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000243 RID: 579
	public enum ArbShaderImageLoadStore
	{
		// Token: 0x04002954 RID: 10580
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04002955 RID: 10581
		ElementArrayBarrierBit,
		// Token: 0x04002956 RID: 10582
		UniformBarrierBit = 4,
		// Token: 0x04002957 RID: 10583
		TextureFetchBarrierBit = 8,
		// Token: 0x04002958 RID: 10584
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04002959 RID: 10585
		CommandBarrierBit = 64,
		// Token: 0x0400295A RID: 10586
		PixelBufferBarrierBit = 128,
		// Token: 0x0400295B RID: 10587
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400295C RID: 10588
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400295D RID: 10589
		FramebufferBarrierBit = 1024,
		// Token: 0x0400295E RID: 10590
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400295F RID: 10591
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04002960 RID: 10592
		MaxImageUnits = 36664,
		// Token: 0x04002961 RID: 10593
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x04002962 RID: 10594
		ImageBindingName,
		// Token: 0x04002963 RID: 10595
		ImageBindingLevel,
		// Token: 0x04002964 RID: 10596
		ImageBindingLayered,
		// Token: 0x04002965 RID: 10597
		ImageBindingLayer,
		// Token: 0x04002966 RID: 10598
		ImageBindingAccess,
		// Token: 0x04002967 RID: 10599
		Image1D = 36940,
		// Token: 0x04002968 RID: 10600
		Image2D,
		// Token: 0x04002969 RID: 10601
		Image3D,
		// Token: 0x0400296A RID: 10602
		Image2DRect,
		// Token: 0x0400296B RID: 10603
		ImageCube,
		// Token: 0x0400296C RID: 10604
		ImageBuffer,
		// Token: 0x0400296D RID: 10605
		Image1DArray,
		// Token: 0x0400296E RID: 10606
		Image2DArray,
		// Token: 0x0400296F RID: 10607
		ImageCubeMapArray,
		// Token: 0x04002970 RID: 10608
		Image2DMultisample,
		// Token: 0x04002971 RID: 10609
		Image2DMultisampleArray,
		// Token: 0x04002972 RID: 10610
		IntImage1D,
		// Token: 0x04002973 RID: 10611
		IntImage2D,
		// Token: 0x04002974 RID: 10612
		IntImage3D,
		// Token: 0x04002975 RID: 10613
		IntImage2DRect,
		// Token: 0x04002976 RID: 10614
		IntImageCube,
		// Token: 0x04002977 RID: 10615
		IntImageBuffer,
		// Token: 0x04002978 RID: 10616
		IntImage1DArray,
		// Token: 0x04002979 RID: 10617
		IntImage2DArray,
		// Token: 0x0400297A RID: 10618
		IntImageCubeMapArray,
		// Token: 0x0400297B RID: 10619
		IntImage2DMultisample,
		// Token: 0x0400297C RID: 10620
		IntImage2DMultisampleArray,
		// Token: 0x0400297D RID: 10621
		UnsignedIntImage1D,
		// Token: 0x0400297E RID: 10622
		UnsignedIntImage2D,
		// Token: 0x0400297F RID: 10623
		UnsignedIntImage3D,
		// Token: 0x04002980 RID: 10624
		UnsignedIntImage2DRect,
		// Token: 0x04002981 RID: 10625
		UnsignedIntImageCube,
		// Token: 0x04002982 RID: 10626
		UnsignedIntImageBuffer,
		// Token: 0x04002983 RID: 10627
		UnsignedIntImage1DArray,
		// Token: 0x04002984 RID: 10628
		UnsignedIntImage2DArray,
		// Token: 0x04002985 RID: 10629
		UnsignedIntImageCubeMapArray,
		// Token: 0x04002986 RID: 10630
		UnsignedIntImage2DMultisample,
		// Token: 0x04002987 RID: 10631
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x04002988 RID: 10632
		MaxImageSamples,
		// Token: 0x04002989 RID: 10633
		ImageBindingFormat,
		// Token: 0x0400298A RID: 10634
		ImageFormatCompatibilityType = 37063,
		// Token: 0x0400298B RID: 10635
		ImageFormatCompatibilityBySize,
		// Token: 0x0400298C RID: 10636
		ImageFormatCompatibilityByClass,
		// Token: 0x0400298D RID: 10637
		MaxVertexImageUniforms,
		// Token: 0x0400298E RID: 10638
		MaxTessControlImageUniforms,
		// Token: 0x0400298F RID: 10639
		MaxTessEvaluationImageUniforms,
		// Token: 0x04002990 RID: 10640
		MaxGeometryImageUniforms,
		// Token: 0x04002991 RID: 10641
		MaxFragmentImageUniforms,
		// Token: 0x04002992 RID: 10642
		MaxCombinedImageUniforms,
		// Token: 0x04002993 RID: 10643
		AllBarrierBits = -1
	}
}
