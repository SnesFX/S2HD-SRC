using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004A2 RID: 1186
	public enum Version42
	{
		// Token: 0x040048E9 RID: 18665
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x040048EA RID: 18666
		ElementArrayBarrierBit,
		// Token: 0x040048EB RID: 18667
		UniformBarrierBit = 4,
		// Token: 0x040048EC RID: 18668
		TextureFetchBarrierBit = 8,
		// Token: 0x040048ED RID: 18669
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x040048EE RID: 18670
		CommandBarrierBit = 64,
		// Token: 0x040048EF RID: 18671
		PixelBufferBarrierBit = 128,
		// Token: 0x040048F0 RID: 18672
		TextureUpdateBarrierBit = 256,
		// Token: 0x040048F1 RID: 18673
		BufferUpdateBarrierBit = 512,
		// Token: 0x040048F2 RID: 18674
		FramebufferBarrierBit = 1024,
		// Token: 0x040048F3 RID: 18675
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x040048F4 RID: 18676
		AtomicCounterBarrierBit = 4096,
		// Token: 0x040048F5 RID: 18677
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x040048F6 RID: 18678
		CompressedSrgbAlphaBptcUnorm,
		// Token: 0x040048F7 RID: 18679
		CompressedRgbBptcSignedFloat,
		// Token: 0x040048F8 RID: 18680
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x040048F9 RID: 18681
		MaxImageUnits = 36664,
		// Token: 0x040048FA RID: 18682
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x040048FB RID: 18683
		ImageBindingName,
		// Token: 0x040048FC RID: 18684
		ImageBindingLevel,
		// Token: 0x040048FD RID: 18685
		ImageBindingLayered,
		// Token: 0x040048FE RID: 18686
		ImageBindingLayer,
		// Token: 0x040048FF RID: 18687
		ImageBindingAccess,
		// Token: 0x04004900 RID: 18688
		Image1D = 36940,
		// Token: 0x04004901 RID: 18689
		Image2D,
		// Token: 0x04004902 RID: 18690
		Image3D,
		// Token: 0x04004903 RID: 18691
		Image2DRect,
		// Token: 0x04004904 RID: 18692
		ImageCube,
		// Token: 0x04004905 RID: 18693
		ImageBuffer,
		// Token: 0x04004906 RID: 18694
		Image1DArray,
		// Token: 0x04004907 RID: 18695
		Image2DArray,
		// Token: 0x04004908 RID: 18696
		ImageCubeMapArray,
		// Token: 0x04004909 RID: 18697
		Image2DMultisample,
		// Token: 0x0400490A RID: 18698
		Image2DMultisampleArray,
		// Token: 0x0400490B RID: 18699
		IntImage1D,
		// Token: 0x0400490C RID: 18700
		IntImage2D,
		// Token: 0x0400490D RID: 18701
		IntImage3D,
		// Token: 0x0400490E RID: 18702
		IntImage2DRect,
		// Token: 0x0400490F RID: 18703
		IntImageCube,
		// Token: 0x04004910 RID: 18704
		IntImageBuffer,
		// Token: 0x04004911 RID: 18705
		IntImage1DArray,
		// Token: 0x04004912 RID: 18706
		IntImage2DArray,
		// Token: 0x04004913 RID: 18707
		IntImageCubeMapArray,
		// Token: 0x04004914 RID: 18708
		IntImage2DMultisample,
		// Token: 0x04004915 RID: 18709
		IntImage2DMultisampleArray,
		// Token: 0x04004916 RID: 18710
		UnsignedIntImage1D,
		// Token: 0x04004917 RID: 18711
		UnsignedIntImage2D,
		// Token: 0x04004918 RID: 18712
		UnsignedIntImage3D,
		// Token: 0x04004919 RID: 18713
		UnsignedIntImage2DRect,
		// Token: 0x0400491A RID: 18714
		UnsignedIntImageCube,
		// Token: 0x0400491B RID: 18715
		UnsignedIntImageBuffer,
		// Token: 0x0400491C RID: 18716
		UnsignedIntImage1DArray,
		// Token: 0x0400491D RID: 18717
		UnsignedIntImage2DArray,
		// Token: 0x0400491E RID: 18718
		UnsignedIntImageCubeMapArray,
		// Token: 0x0400491F RID: 18719
		UnsignedIntImage2DMultisample,
		// Token: 0x04004920 RID: 18720
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x04004921 RID: 18721
		MaxImageSamples,
		// Token: 0x04004922 RID: 18722
		ImageBindingFormat,
		// Token: 0x04004923 RID: 18723
		MinMapBufferAlignment = 37052,
		// Token: 0x04004924 RID: 18724
		ImageFormatCompatibilityType = 37063,
		// Token: 0x04004925 RID: 18725
		ImageFormatCompatibilityBySize,
		// Token: 0x04004926 RID: 18726
		ImageFormatCompatibilityByClass,
		// Token: 0x04004927 RID: 18727
		MaxVertexImageUniforms,
		// Token: 0x04004928 RID: 18728
		MaxTessControlImageUniforms,
		// Token: 0x04004929 RID: 18729
		MaxTessEvaluationImageUniforms,
		// Token: 0x0400492A RID: 18730
		MaxGeometryImageUniforms,
		// Token: 0x0400492B RID: 18731
		MaxFragmentImageUniforms,
		// Token: 0x0400492C RID: 18732
		MaxCombinedImageUniforms,
		// Token: 0x0400492D RID: 18733
		UnpackCompressedBlockWidth = 37159,
		// Token: 0x0400492E RID: 18734
		UnpackCompressedBlockHeight,
		// Token: 0x0400492F RID: 18735
		UnpackCompressedBlockDepth,
		// Token: 0x04004930 RID: 18736
		UnpackCompressedBlockSize,
		// Token: 0x04004931 RID: 18737
		PackCompressedBlockWidth,
		// Token: 0x04004932 RID: 18738
		PackCompressedBlockHeight,
		// Token: 0x04004933 RID: 18739
		PackCompressedBlockDepth,
		// Token: 0x04004934 RID: 18740
		PackCompressedBlockSize,
		// Token: 0x04004935 RID: 18741
		TextureImmutableFormat,
		// Token: 0x04004936 RID: 18742
		AtomicCounterBuffer = 37568,
		// Token: 0x04004937 RID: 18743
		AtomicCounterBufferBinding,
		// Token: 0x04004938 RID: 18744
		AtomicCounterBufferStart,
		// Token: 0x04004939 RID: 18745
		AtomicCounterBufferSize,
		// Token: 0x0400493A RID: 18746
		AtomicCounterBufferDataSize,
		// Token: 0x0400493B RID: 18747
		AtomicCounterBufferActiveAtomicCounters,
		// Token: 0x0400493C RID: 18748
		AtomicCounterBufferActiveAtomicCounterIndices,
		// Token: 0x0400493D RID: 18749
		AtomicCounterBufferReferencedByVertexShader,
		// Token: 0x0400493E RID: 18750
		AtomicCounterBufferReferencedByTessControlShader,
		// Token: 0x0400493F RID: 18751
		AtomicCounterBufferReferencedByTessEvaluationShader,
		// Token: 0x04004940 RID: 18752
		AtomicCounterBufferReferencedByGeometryShader,
		// Token: 0x04004941 RID: 18753
		AtomicCounterBufferReferencedByFragmentShader,
		// Token: 0x04004942 RID: 18754
		MaxVertexAtomicCounterBuffers,
		// Token: 0x04004943 RID: 18755
		MaxTessControlAtomicCounterBuffers,
		// Token: 0x04004944 RID: 18756
		MaxTessEvaluationAtomicCounterBuffers,
		// Token: 0x04004945 RID: 18757
		MaxGeometryAtomicCounterBuffers,
		// Token: 0x04004946 RID: 18758
		MaxFragmentAtomicCounterBuffers,
		// Token: 0x04004947 RID: 18759
		MaxCombinedAtomicCounterBuffers,
		// Token: 0x04004948 RID: 18760
		MaxVertexAtomicCounters,
		// Token: 0x04004949 RID: 18761
		MaxTessControlAtomicCounters,
		// Token: 0x0400494A RID: 18762
		MaxTessEvaluationAtomicCounters,
		// Token: 0x0400494B RID: 18763
		MaxGeometryAtomicCounters,
		// Token: 0x0400494C RID: 18764
		MaxFragmentAtomicCounters,
		// Token: 0x0400494D RID: 18765
		MaxCombinedAtomicCounters,
		// Token: 0x0400494E RID: 18766
		MaxAtomicCounterBufferSize,
		// Token: 0x0400494F RID: 18767
		ActiveAtomicCounterBuffers,
		// Token: 0x04004950 RID: 18768
		UniformAtomicCounterBufferIndex,
		// Token: 0x04004951 RID: 18769
		UnsignedIntAtomicCounter,
		// Token: 0x04004952 RID: 18770
		MaxAtomicCounterBufferBindings,
		// Token: 0x04004953 RID: 18771
		NumSampleCounts = 37760,
		// Token: 0x04004954 RID: 18772
		AllBarrierBits = -1
	}
}
