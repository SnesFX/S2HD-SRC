using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000763 RID: 1891
	public enum Version42
	{
		// Token: 0x0400738F RID: 29583
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04007390 RID: 29584
		ElementArrayBarrierBit,
		// Token: 0x04007391 RID: 29585
		UniformBarrierBit = 4,
		// Token: 0x04007392 RID: 29586
		TextureFetchBarrierBit = 8,
		// Token: 0x04007393 RID: 29587
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04007394 RID: 29588
		CommandBarrierBit = 64,
		// Token: 0x04007395 RID: 29589
		PixelBufferBarrierBit = 128,
		// Token: 0x04007396 RID: 29590
		TextureUpdateBarrierBit = 256,
		// Token: 0x04007397 RID: 29591
		BufferUpdateBarrierBit = 512,
		// Token: 0x04007398 RID: 29592
		FramebufferBarrierBit = 1024,
		// Token: 0x04007399 RID: 29593
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400739A RID: 29594
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400739B RID: 29595
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x0400739C RID: 29596
		CompressedSrgbAlphaBptcUnorm,
		// Token: 0x0400739D RID: 29597
		CompressedRgbBptcSignedFloat,
		// Token: 0x0400739E RID: 29598
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x0400739F RID: 29599
		MaxImageUnits = 36664,
		// Token: 0x040073A0 RID: 29600
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x040073A1 RID: 29601
		ImageBindingName,
		// Token: 0x040073A2 RID: 29602
		ImageBindingLevel,
		// Token: 0x040073A3 RID: 29603
		ImageBindingLayered,
		// Token: 0x040073A4 RID: 29604
		ImageBindingLayer,
		// Token: 0x040073A5 RID: 29605
		ImageBindingAccess,
		// Token: 0x040073A6 RID: 29606
		Image1D = 36940,
		// Token: 0x040073A7 RID: 29607
		Image2D,
		// Token: 0x040073A8 RID: 29608
		Image3D,
		// Token: 0x040073A9 RID: 29609
		Image2DRect,
		// Token: 0x040073AA RID: 29610
		ImageCube,
		// Token: 0x040073AB RID: 29611
		ImageBuffer,
		// Token: 0x040073AC RID: 29612
		Image1DArray,
		// Token: 0x040073AD RID: 29613
		Image2DArray,
		// Token: 0x040073AE RID: 29614
		ImageCubeMapArray,
		// Token: 0x040073AF RID: 29615
		Image2DMultisample,
		// Token: 0x040073B0 RID: 29616
		Image2DMultisampleArray,
		// Token: 0x040073B1 RID: 29617
		IntImage1D,
		// Token: 0x040073B2 RID: 29618
		IntImage2D,
		// Token: 0x040073B3 RID: 29619
		IntImage3D,
		// Token: 0x040073B4 RID: 29620
		IntImage2DRect,
		// Token: 0x040073B5 RID: 29621
		IntImageCube,
		// Token: 0x040073B6 RID: 29622
		IntImageBuffer,
		// Token: 0x040073B7 RID: 29623
		IntImage1DArray,
		// Token: 0x040073B8 RID: 29624
		IntImage2DArray,
		// Token: 0x040073B9 RID: 29625
		IntImageCubeMapArray,
		// Token: 0x040073BA RID: 29626
		IntImage2DMultisample,
		// Token: 0x040073BB RID: 29627
		IntImage2DMultisampleArray,
		// Token: 0x040073BC RID: 29628
		UnsignedIntImage1D,
		// Token: 0x040073BD RID: 29629
		UnsignedIntImage2D,
		// Token: 0x040073BE RID: 29630
		UnsignedIntImage3D,
		// Token: 0x040073BF RID: 29631
		UnsignedIntImage2DRect,
		// Token: 0x040073C0 RID: 29632
		UnsignedIntImageCube,
		// Token: 0x040073C1 RID: 29633
		UnsignedIntImageBuffer,
		// Token: 0x040073C2 RID: 29634
		UnsignedIntImage1DArray,
		// Token: 0x040073C3 RID: 29635
		UnsignedIntImage2DArray,
		// Token: 0x040073C4 RID: 29636
		UnsignedIntImageCubeMapArray,
		// Token: 0x040073C5 RID: 29637
		UnsignedIntImage2DMultisample,
		// Token: 0x040073C6 RID: 29638
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x040073C7 RID: 29639
		MaxImageSamples,
		// Token: 0x040073C8 RID: 29640
		ImageBindingFormat,
		// Token: 0x040073C9 RID: 29641
		MinMapBufferAlignment = 37052,
		// Token: 0x040073CA RID: 29642
		ImageFormatCompatibilityType = 37063,
		// Token: 0x040073CB RID: 29643
		ImageFormatCompatibilityBySize,
		// Token: 0x040073CC RID: 29644
		ImageFormatCompatibilityByClass,
		// Token: 0x040073CD RID: 29645
		MaxVertexImageUniforms,
		// Token: 0x040073CE RID: 29646
		MaxTessControlImageUniforms,
		// Token: 0x040073CF RID: 29647
		MaxTessEvaluationImageUniforms,
		// Token: 0x040073D0 RID: 29648
		MaxGeometryImageUniforms,
		// Token: 0x040073D1 RID: 29649
		MaxFragmentImageUniforms,
		// Token: 0x040073D2 RID: 29650
		MaxCombinedImageUniforms,
		// Token: 0x040073D3 RID: 29651
		UnpackCompressedBlockWidth = 37159,
		// Token: 0x040073D4 RID: 29652
		UnpackCompressedBlockHeight,
		// Token: 0x040073D5 RID: 29653
		UnpackCompressedBlockDepth,
		// Token: 0x040073D6 RID: 29654
		UnpackCompressedBlockSize,
		// Token: 0x040073D7 RID: 29655
		PackCompressedBlockWidth,
		// Token: 0x040073D8 RID: 29656
		PackCompressedBlockHeight,
		// Token: 0x040073D9 RID: 29657
		PackCompressedBlockDepth,
		// Token: 0x040073DA RID: 29658
		PackCompressedBlockSize,
		// Token: 0x040073DB RID: 29659
		TextureImmutableFormat,
		// Token: 0x040073DC RID: 29660
		AtomicCounterBuffer = 37568,
		// Token: 0x040073DD RID: 29661
		AtomicCounterBufferBinding,
		// Token: 0x040073DE RID: 29662
		AtomicCounterBufferStart,
		// Token: 0x040073DF RID: 29663
		AtomicCounterBufferSize,
		// Token: 0x040073E0 RID: 29664
		AtomicCounterBufferDataSize,
		// Token: 0x040073E1 RID: 29665
		AtomicCounterBufferActiveAtomicCounters,
		// Token: 0x040073E2 RID: 29666
		AtomicCounterBufferActiveAtomicCounterIndices,
		// Token: 0x040073E3 RID: 29667
		AtomicCounterBufferReferencedByVertexShader,
		// Token: 0x040073E4 RID: 29668
		AtomicCounterBufferReferencedByTessControlShader,
		// Token: 0x040073E5 RID: 29669
		AtomicCounterBufferReferencedByTessEvaluationShader,
		// Token: 0x040073E6 RID: 29670
		AtomicCounterBufferReferencedByGeometryShader,
		// Token: 0x040073E7 RID: 29671
		AtomicCounterBufferReferencedByFragmentShader,
		// Token: 0x040073E8 RID: 29672
		MaxVertexAtomicCounterBuffers,
		// Token: 0x040073E9 RID: 29673
		MaxTessControlAtomicCounterBuffers,
		// Token: 0x040073EA RID: 29674
		MaxTessEvaluationAtomicCounterBuffers,
		// Token: 0x040073EB RID: 29675
		MaxGeometryAtomicCounterBuffers,
		// Token: 0x040073EC RID: 29676
		MaxFragmentAtomicCounterBuffers,
		// Token: 0x040073ED RID: 29677
		MaxCombinedAtomicCounterBuffers,
		// Token: 0x040073EE RID: 29678
		MaxVertexAtomicCounters,
		// Token: 0x040073EF RID: 29679
		MaxTessControlAtomicCounters,
		// Token: 0x040073F0 RID: 29680
		MaxTessEvaluationAtomicCounters,
		// Token: 0x040073F1 RID: 29681
		MaxGeometryAtomicCounters,
		// Token: 0x040073F2 RID: 29682
		MaxFragmentAtomicCounters,
		// Token: 0x040073F3 RID: 29683
		MaxCombinedAtomicCounters,
		// Token: 0x040073F4 RID: 29684
		MaxAtomicCounterBufferSize,
		// Token: 0x040073F5 RID: 29685
		ActiveAtomicCounterBuffers,
		// Token: 0x040073F6 RID: 29686
		UniformAtomicCounterBufferIndex,
		// Token: 0x040073F7 RID: 29687
		UnsignedIntAtomicCounter,
		// Token: 0x040073F8 RID: 29688
		MaxAtomicCounterBufferBindings,
		// Token: 0x040073F9 RID: 29689
		NumSampleCounts = 37760,
		// Token: 0x040073FA RID: 29690
		AllBarrierBits = -1
	}
}
