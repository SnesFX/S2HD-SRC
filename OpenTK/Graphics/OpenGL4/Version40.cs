using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000761 RID: 1889
	public enum Version40
	{
		// Token: 0x0400731C RID: 29468
		Quads = 7,
		// Token: 0x0400731D RID: 29469
		Patches = 14,
		// Token: 0x0400731E RID: 29470
		UniformBlockReferencedByTessControlShader = 34032,
		// Token: 0x0400731F RID: 29471
		UniformBlockReferencedByTessEvaluationShader,
		// Token: 0x04007320 RID: 29472
		MaxTessControlInputComponents = 34924,
		// Token: 0x04007321 RID: 29473
		MaxTessEvaluationInputComponents,
		// Token: 0x04007322 RID: 29474
		GeometryShaderInvocations = 34943,
		// Token: 0x04007323 RID: 29475
		SampleShading = 35894,
		// Token: 0x04007324 RID: 29476
		MinSampleShadingValue,
		// Token: 0x04007325 RID: 29477
		ActiveSubroutines = 36325,
		// Token: 0x04007326 RID: 29478
		ActiveSubroutineUniforms,
		// Token: 0x04007327 RID: 29479
		MaxSubroutines,
		// Token: 0x04007328 RID: 29480
		MaxSubroutineUniformLocations,
		// Token: 0x04007329 RID: 29481
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x0400732A RID: 29482
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x0400732B RID: 29483
		TransformFeedback = 36386,
		// Token: 0x0400732C RID: 29484
		TransformFeedbackBufferPaused,
		// Token: 0x0400732D RID: 29485
		TransformFeedbackBufferActive,
		// Token: 0x0400732E RID: 29486
		TransformFeedbackBinding,
		// Token: 0x0400732F RID: 29487
		ActiveSubroutineUniformLocations = 36423,
		// Token: 0x04007330 RID: 29488
		ActiveSubroutineMaxLength,
		// Token: 0x04007331 RID: 29489
		ActiveSubroutineUniformMaxLength,
		// Token: 0x04007332 RID: 29490
		NumCompatibleSubroutines,
		// Token: 0x04007333 RID: 29491
		CompatibleSubroutines,
		// Token: 0x04007334 RID: 29492
		MaxGeometryShaderInvocations = 36442,
		// Token: 0x04007335 RID: 29493
		MinFragmentInterpolationOffset,
		// Token: 0x04007336 RID: 29494
		MaxFragmentInterpolationOffset,
		// Token: 0x04007337 RID: 29495
		FragmentInterpolationOffsetBits,
		// Token: 0x04007338 RID: 29496
		MinProgramTextureGatherOffset,
		// Token: 0x04007339 RID: 29497
		MaxProgramTextureGatherOffset,
		// Token: 0x0400733A RID: 29498
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x0400733B RID: 29499
		MaxVertexStreams,
		// Token: 0x0400733C RID: 29500
		PatchVertices,
		// Token: 0x0400733D RID: 29501
		PatchDefaultInnerLevel,
		// Token: 0x0400733E RID: 29502
		PatchDefaultOuterLevel,
		// Token: 0x0400733F RID: 29503
		TessControlOutputVertices,
		// Token: 0x04007340 RID: 29504
		TessGenMode,
		// Token: 0x04007341 RID: 29505
		TessGenSpacing,
		// Token: 0x04007342 RID: 29506
		TessGenVertexOrder,
		// Token: 0x04007343 RID: 29507
		TessGenPointMode,
		// Token: 0x04007344 RID: 29508
		Isolines,
		// Token: 0x04007345 RID: 29509
		FractionalOdd,
		// Token: 0x04007346 RID: 29510
		FractionalEven,
		// Token: 0x04007347 RID: 29511
		MaxPatchVertices,
		// Token: 0x04007348 RID: 29512
		MaxTessGenLevel,
		// Token: 0x04007349 RID: 29513
		MaxTessControlUniformComponents,
		// Token: 0x0400734A RID: 29514
		MaxTessEvaluationUniformComponents,
		// Token: 0x0400734B RID: 29515
		MaxTessControlTextureImageUnits,
		// Token: 0x0400734C RID: 29516
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x0400734D RID: 29517
		MaxTessControlOutputComponents,
		// Token: 0x0400734E RID: 29518
		MaxTessPatchComponents,
		// Token: 0x0400734F RID: 29519
		MaxTessControlTotalOutputComponents,
		// Token: 0x04007350 RID: 29520
		MaxTessEvaluationOutputComponents,
		// Token: 0x04007351 RID: 29521
		TessEvaluationShader,
		// Token: 0x04007352 RID: 29522
		TessControlShader,
		// Token: 0x04007353 RID: 29523
		MaxTessControlUniformBlocks,
		// Token: 0x04007354 RID: 29524
		MaxTessEvaluationUniformBlocks,
		// Token: 0x04007355 RID: 29525
		DrawIndirectBuffer = 36671,
		// Token: 0x04007356 RID: 29526
		DrawIndirectBufferBinding = 36675,
		// Token: 0x04007357 RID: 29527
		DoubleMat2 = 36678,
		// Token: 0x04007358 RID: 29528
		DoubleMat3,
		// Token: 0x04007359 RID: 29529
		DoubleMat4,
		// Token: 0x0400735A RID: 29530
		DoubleMat2x3,
		// Token: 0x0400735B RID: 29531
		DoubleMat2x4,
		// Token: 0x0400735C RID: 29532
		DoubleMat3x2,
		// Token: 0x0400735D RID: 29533
		DoubleMat3x4,
		// Token: 0x0400735E RID: 29534
		DoubleMat4x2,
		// Token: 0x0400735F RID: 29535
		DoubleMat4x3,
		// Token: 0x04007360 RID: 29536
		DoubleVec2 = 36860,
		// Token: 0x04007361 RID: 29537
		DoubleVec3,
		// Token: 0x04007362 RID: 29538
		DoubleVec4,
		// Token: 0x04007363 RID: 29539
		TextureCubeMapArray = 36873,
		// Token: 0x04007364 RID: 29540
		TextureBindingCubeMapArray,
		// Token: 0x04007365 RID: 29541
		ProxyTextureCubeMapArray,
		// Token: 0x04007366 RID: 29542
		SamplerCubeMapArray,
		// Token: 0x04007367 RID: 29543
		SamplerCubeMapArrayShadow,
		// Token: 0x04007368 RID: 29544
		IntSamplerCubeMapArray,
		// Token: 0x04007369 RID: 29545
		UnsignedIntSamplerCubeMapArray
	}
}
