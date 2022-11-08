using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004A0 RID: 1184
	public enum Version40
	{
		// Token: 0x04004876 RID: 18550
		Quads = 7,
		// Token: 0x04004877 RID: 18551
		Patches = 14,
		// Token: 0x04004878 RID: 18552
		UniformBlockReferencedByTessControlShader = 34032,
		// Token: 0x04004879 RID: 18553
		UniformBlockReferencedByTessEvaluationShader,
		// Token: 0x0400487A RID: 18554
		MaxTessControlInputComponents = 34924,
		// Token: 0x0400487B RID: 18555
		MaxTessEvaluationInputComponents,
		// Token: 0x0400487C RID: 18556
		GeometryShaderInvocations = 34943,
		// Token: 0x0400487D RID: 18557
		SampleShading = 35894,
		// Token: 0x0400487E RID: 18558
		MinSampleShadingValue,
		// Token: 0x0400487F RID: 18559
		ActiveSubroutines = 36325,
		// Token: 0x04004880 RID: 18560
		ActiveSubroutineUniforms,
		// Token: 0x04004881 RID: 18561
		MaxSubroutines,
		// Token: 0x04004882 RID: 18562
		MaxSubroutineUniformLocations,
		// Token: 0x04004883 RID: 18563
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x04004884 RID: 18564
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x04004885 RID: 18565
		TransformFeedback = 36386,
		// Token: 0x04004886 RID: 18566
		TransformFeedbackBufferPaused,
		// Token: 0x04004887 RID: 18567
		TransformFeedbackBufferActive,
		// Token: 0x04004888 RID: 18568
		TransformFeedbackBinding,
		// Token: 0x04004889 RID: 18569
		ActiveSubroutineUniformLocations = 36423,
		// Token: 0x0400488A RID: 18570
		ActiveSubroutineMaxLength,
		// Token: 0x0400488B RID: 18571
		ActiveSubroutineUniformMaxLength,
		// Token: 0x0400488C RID: 18572
		NumCompatibleSubroutines,
		// Token: 0x0400488D RID: 18573
		CompatibleSubroutines,
		// Token: 0x0400488E RID: 18574
		MaxGeometryShaderInvocations = 36442,
		// Token: 0x0400488F RID: 18575
		MinFragmentInterpolationOffset,
		// Token: 0x04004890 RID: 18576
		MaxFragmentInterpolationOffset,
		// Token: 0x04004891 RID: 18577
		FragmentInterpolationOffsetBits,
		// Token: 0x04004892 RID: 18578
		MinProgramTextureGatherOffset,
		// Token: 0x04004893 RID: 18579
		MaxProgramTextureGatherOffset,
		// Token: 0x04004894 RID: 18580
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x04004895 RID: 18581
		MaxVertexStreams,
		// Token: 0x04004896 RID: 18582
		PatchVertices,
		// Token: 0x04004897 RID: 18583
		PatchDefaultInnerLevel,
		// Token: 0x04004898 RID: 18584
		PatchDefaultOuterLevel,
		// Token: 0x04004899 RID: 18585
		TessControlOutputVertices,
		// Token: 0x0400489A RID: 18586
		TessGenMode,
		// Token: 0x0400489B RID: 18587
		TessGenSpacing,
		// Token: 0x0400489C RID: 18588
		TessGenVertexOrder,
		// Token: 0x0400489D RID: 18589
		TessGenPointMode,
		// Token: 0x0400489E RID: 18590
		Isolines,
		// Token: 0x0400489F RID: 18591
		FractionalOdd,
		// Token: 0x040048A0 RID: 18592
		FractionalEven,
		// Token: 0x040048A1 RID: 18593
		MaxPatchVertices,
		// Token: 0x040048A2 RID: 18594
		MaxTessGenLevel,
		// Token: 0x040048A3 RID: 18595
		MaxTessControlUniformComponents,
		// Token: 0x040048A4 RID: 18596
		MaxTessEvaluationUniformComponents,
		// Token: 0x040048A5 RID: 18597
		MaxTessControlTextureImageUnits,
		// Token: 0x040048A6 RID: 18598
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x040048A7 RID: 18599
		MaxTessControlOutputComponents,
		// Token: 0x040048A8 RID: 18600
		MaxTessPatchComponents,
		// Token: 0x040048A9 RID: 18601
		MaxTessControlTotalOutputComponents,
		// Token: 0x040048AA RID: 18602
		MaxTessEvaluationOutputComponents,
		// Token: 0x040048AB RID: 18603
		TessEvaluationShader,
		// Token: 0x040048AC RID: 18604
		TessControlShader,
		// Token: 0x040048AD RID: 18605
		MaxTessControlUniformBlocks,
		// Token: 0x040048AE RID: 18606
		MaxTessEvaluationUniformBlocks,
		// Token: 0x040048AF RID: 18607
		DrawIndirectBuffer = 36671,
		// Token: 0x040048B0 RID: 18608
		DrawIndirectBufferBinding = 36675,
		// Token: 0x040048B1 RID: 18609
		DoubleMat2 = 36678,
		// Token: 0x040048B2 RID: 18610
		DoubleMat3,
		// Token: 0x040048B3 RID: 18611
		DoubleMat4,
		// Token: 0x040048B4 RID: 18612
		DoubleMat2x3,
		// Token: 0x040048B5 RID: 18613
		DoubleMat2x4,
		// Token: 0x040048B6 RID: 18614
		DoubleMat3x2,
		// Token: 0x040048B7 RID: 18615
		DoubleMat3x4,
		// Token: 0x040048B8 RID: 18616
		DoubleMat4x2,
		// Token: 0x040048B9 RID: 18617
		DoubleMat4x3,
		// Token: 0x040048BA RID: 18618
		DoubleVec2 = 36860,
		// Token: 0x040048BB RID: 18619
		DoubleVec3,
		// Token: 0x040048BC RID: 18620
		DoubleVec4,
		// Token: 0x040048BD RID: 18621
		TextureCubeMapArray = 36873,
		// Token: 0x040048BE RID: 18622
		TextureBindingCubeMapArray,
		// Token: 0x040048BF RID: 18623
		ProxyTextureCubeMapArray,
		// Token: 0x040048C0 RID: 18624
		SamplerCubeMapArray,
		// Token: 0x040048C1 RID: 18625
		SamplerCubeMapArrayShadow,
		// Token: 0x040048C2 RID: 18626
		IntSamplerCubeMapArray,
		// Token: 0x040048C3 RID: 18627
		UnsignedIntSamplerCubeMapArray
	}
}
