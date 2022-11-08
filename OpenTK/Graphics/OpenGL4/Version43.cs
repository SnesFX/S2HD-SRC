using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000764 RID: 1892
	public enum Version43
	{
		// Token: 0x040073FC RID: 29692
		ContextFlagDebugBit = 2,
		// Token: 0x040073FD RID: 29693
		ComputeShaderBit = 32,
		// Token: 0x040073FE RID: 29694
		ShaderStorageBarrierBit = 8192,
		// Token: 0x040073FF RID: 29695
		StackOverflow = 1283,
		// Token: 0x04007400 RID: 29696
		StackUnderflow,
		// Token: 0x04007401 RID: 29697
		VertexArray = 32884,
		// Token: 0x04007402 RID: 29698
		DebugOutputSynchronous = 33346,
		// Token: 0x04007403 RID: 29699
		DebugNextLoggedMessageLength,
		// Token: 0x04007404 RID: 29700
		DebugCallbackFunction,
		// Token: 0x04007405 RID: 29701
		DebugCallbackUserParam,
		// Token: 0x04007406 RID: 29702
		DebugSourceApi,
		// Token: 0x04007407 RID: 29703
		DebugSourceWindowSystem,
		// Token: 0x04007408 RID: 29704
		DebugSourceShaderCompiler,
		// Token: 0x04007409 RID: 29705
		DebugSourceThirdParty,
		// Token: 0x0400740A RID: 29706
		DebugSourceApplication,
		// Token: 0x0400740B RID: 29707
		DebugSourceOther,
		// Token: 0x0400740C RID: 29708
		DebugTypeError,
		// Token: 0x0400740D RID: 29709
		DebugTypeDeprecatedBehavior,
		// Token: 0x0400740E RID: 29710
		DebugTypeUndefinedBehavior,
		// Token: 0x0400740F RID: 29711
		DebugTypePortability,
		// Token: 0x04007410 RID: 29712
		DebugTypePerformance,
		// Token: 0x04007411 RID: 29713
		DebugTypeOther,
		// Token: 0x04007412 RID: 29714
		MaxComputeSharedMemorySize = 33378,
		// Token: 0x04007413 RID: 29715
		MaxComputeUniformComponents,
		// Token: 0x04007414 RID: 29716
		MaxComputeAtomicCounterBuffers,
		// Token: 0x04007415 RID: 29717
		MaxComputeAtomicCounters,
		// Token: 0x04007416 RID: 29718
		MaxCombinedComputeUniformComponents,
		// Token: 0x04007417 RID: 29719
		ComputeWorkGroupSize,
		// Token: 0x04007418 RID: 29720
		DebugTypeMarker,
		// Token: 0x04007419 RID: 29721
		DebugTypePushGroup,
		// Token: 0x0400741A RID: 29722
		DebugTypePopGroup,
		// Token: 0x0400741B RID: 29723
		DebugSeverityNotification,
		// Token: 0x0400741C RID: 29724
		MaxDebugGroupStackDepth,
		// Token: 0x0400741D RID: 29725
		DebugGroupStackDepth,
		// Token: 0x0400741E RID: 29726
		MaxUniformLocations,
		// Token: 0x0400741F RID: 29727
		InternalformatSupported,
		// Token: 0x04007420 RID: 29728
		InternalformatPreferred,
		// Token: 0x04007421 RID: 29729
		InternalformatRedSize,
		// Token: 0x04007422 RID: 29730
		InternalformatGreenSize,
		// Token: 0x04007423 RID: 29731
		InternalformatBlueSize,
		// Token: 0x04007424 RID: 29732
		InternalformatAlphaSize,
		// Token: 0x04007425 RID: 29733
		InternalformatDepthSize,
		// Token: 0x04007426 RID: 29734
		InternalformatStencilSize,
		// Token: 0x04007427 RID: 29735
		InternalformatSharedSize,
		// Token: 0x04007428 RID: 29736
		InternalformatRedType,
		// Token: 0x04007429 RID: 29737
		InternalformatGreenType,
		// Token: 0x0400742A RID: 29738
		InternalformatBlueType,
		// Token: 0x0400742B RID: 29739
		InternalformatAlphaType,
		// Token: 0x0400742C RID: 29740
		InternalformatDepthType,
		// Token: 0x0400742D RID: 29741
		InternalformatStencilType,
		// Token: 0x0400742E RID: 29742
		MaxWidth,
		// Token: 0x0400742F RID: 29743
		MaxHeight,
		// Token: 0x04007430 RID: 29744
		MaxDepth,
		// Token: 0x04007431 RID: 29745
		MaxLayers,
		// Token: 0x04007432 RID: 29746
		MaxCombinedDimensions,
		// Token: 0x04007433 RID: 29747
		ColorComponents,
		// Token: 0x04007434 RID: 29748
		DepthComponents,
		// Token: 0x04007435 RID: 29749
		StencilComponents,
		// Token: 0x04007436 RID: 29750
		ColorRenderable,
		// Token: 0x04007437 RID: 29751
		DepthRenderable,
		// Token: 0x04007438 RID: 29752
		StencilRenderable,
		// Token: 0x04007439 RID: 29753
		FramebufferRenderable,
		// Token: 0x0400743A RID: 29754
		FramebufferRenderableLayered,
		// Token: 0x0400743B RID: 29755
		FramebufferBlend,
		// Token: 0x0400743C RID: 29756
		ReadPixels,
		// Token: 0x0400743D RID: 29757
		ReadPixelsFormat,
		// Token: 0x0400743E RID: 29758
		ReadPixelsType,
		// Token: 0x0400743F RID: 29759
		TextureImageFormat,
		// Token: 0x04007440 RID: 29760
		TextureImageType,
		// Token: 0x04007441 RID: 29761
		GetTextureImageFormat,
		// Token: 0x04007442 RID: 29762
		GetTextureImageType,
		// Token: 0x04007443 RID: 29763
		Mipmap,
		// Token: 0x04007444 RID: 29764
		ManualGenerateMipmap,
		// Token: 0x04007445 RID: 29765
		AutoGenerateMipmap,
		// Token: 0x04007446 RID: 29766
		ColorEncoding,
		// Token: 0x04007447 RID: 29767
		SrgbRead,
		// Token: 0x04007448 RID: 29768
		SrgbWrite,
		// Token: 0x04007449 RID: 29769
		Filter = 33434,
		// Token: 0x0400744A RID: 29770
		VertexTexture,
		// Token: 0x0400744B RID: 29771
		TessControlTexture,
		// Token: 0x0400744C RID: 29772
		TessEvaluationTexture,
		// Token: 0x0400744D RID: 29773
		GeometryTexture,
		// Token: 0x0400744E RID: 29774
		FragmentTexture,
		// Token: 0x0400744F RID: 29775
		ComputeTexture,
		// Token: 0x04007450 RID: 29776
		TextureShadow,
		// Token: 0x04007451 RID: 29777
		TextureGather,
		// Token: 0x04007452 RID: 29778
		TextureGatherShadow,
		// Token: 0x04007453 RID: 29779
		ShaderImageLoad,
		// Token: 0x04007454 RID: 29780
		ShaderImageStore,
		// Token: 0x04007455 RID: 29781
		ShaderImageAtomic,
		// Token: 0x04007456 RID: 29782
		ImageTexelSize,
		// Token: 0x04007457 RID: 29783
		ImageCompatibilityClass,
		// Token: 0x04007458 RID: 29784
		ImagePixelFormat,
		// Token: 0x04007459 RID: 29785
		ImagePixelType,
		// Token: 0x0400745A RID: 29786
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x0400745B RID: 29787
		SimultaneousTextureAndStencilTest,
		// Token: 0x0400745C RID: 29788
		SimultaneousTextureAndDepthWrite,
		// Token: 0x0400745D RID: 29789
		SimultaneousTextureAndStencilWrite,
		// Token: 0x0400745E RID: 29790
		TextureCompressedBlockWidth = 33457,
		// Token: 0x0400745F RID: 29791
		TextureCompressedBlockHeight,
		// Token: 0x04007460 RID: 29792
		TextureCompressedBlockSize,
		// Token: 0x04007461 RID: 29793
		ClearBuffer,
		// Token: 0x04007462 RID: 29794
		TextureView,
		// Token: 0x04007463 RID: 29795
		ViewCompatibilityClass,
		// Token: 0x04007464 RID: 29796
		FullSupport,
		// Token: 0x04007465 RID: 29797
		CaveatSupport,
		// Token: 0x04007466 RID: 29798
		ImageClass4X32,
		// Token: 0x04007467 RID: 29799
		ImageClass2X32,
		// Token: 0x04007468 RID: 29800
		ImageClass1X32,
		// Token: 0x04007469 RID: 29801
		ImageClass4X16,
		// Token: 0x0400746A RID: 29802
		ImageClass2X16,
		// Token: 0x0400746B RID: 29803
		ImageClass1X16,
		// Token: 0x0400746C RID: 29804
		ImageClass4X8,
		// Token: 0x0400746D RID: 29805
		ImageClass2X8,
		// Token: 0x0400746E RID: 29806
		ImageClass1X8,
		// Token: 0x0400746F RID: 29807
		ImageClass111110,
		// Token: 0x04007470 RID: 29808
		ImageClass1010102,
		// Token: 0x04007471 RID: 29809
		ViewClass128Bits,
		// Token: 0x04007472 RID: 29810
		ViewClass96Bits,
		// Token: 0x04007473 RID: 29811
		ViewClass64Bits,
		// Token: 0x04007474 RID: 29812
		ViewClass48Bits,
		// Token: 0x04007475 RID: 29813
		ViewClass32Bits,
		// Token: 0x04007476 RID: 29814
		ViewClass24Bits,
		// Token: 0x04007477 RID: 29815
		ViewClass16Bits,
		// Token: 0x04007478 RID: 29816
		ViewClass8Bits,
		// Token: 0x04007479 RID: 29817
		ViewClassS3tcDxt1Rgb,
		// Token: 0x0400747A RID: 29818
		ViewClassS3tcDxt1Rgba,
		// Token: 0x0400747B RID: 29819
		ViewClassS3tcDxt3Rgba,
		// Token: 0x0400747C RID: 29820
		ViewClassS3tcDxt5Rgba,
		// Token: 0x0400747D RID: 29821
		ViewClassRgtc1Red,
		// Token: 0x0400747E RID: 29822
		ViewClassRgtc2Rg,
		// Token: 0x0400747F RID: 29823
		ViewClassBptcUnorm,
		// Token: 0x04007480 RID: 29824
		ViewClassBptcFloat,
		// Token: 0x04007481 RID: 29825
		VertexAttribBinding,
		// Token: 0x04007482 RID: 29826
		VertexAttribRelativeOffset,
		// Token: 0x04007483 RID: 29827
		VertexBindingDivisor,
		// Token: 0x04007484 RID: 29828
		VertexBindingOffset,
		// Token: 0x04007485 RID: 29829
		VertexBindingStride,
		// Token: 0x04007486 RID: 29830
		MaxVertexAttribRelativeOffset,
		// Token: 0x04007487 RID: 29831
		MaxVertexAttribBindings,
		// Token: 0x04007488 RID: 29832
		TextureViewMinLevel,
		// Token: 0x04007489 RID: 29833
		TextureViewNumLevels,
		// Token: 0x0400748A RID: 29834
		TextureViewMinLayer,
		// Token: 0x0400748B RID: 29835
		TextureViewNumLayers,
		// Token: 0x0400748C RID: 29836
		TextureImmutableLevels,
		// Token: 0x0400748D RID: 29837
		Buffer,
		// Token: 0x0400748E RID: 29838
		Shader,
		// Token: 0x0400748F RID: 29839
		Program,
		// Token: 0x04007490 RID: 29840
		Query,
		// Token: 0x04007491 RID: 29841
		ProgramPipeline,
		// Token: 0x04007492 RID: 29842
		Sampler = 33510,
		// Token: 0x04007493 RID: 29843
		DisplayList,
		// Token: 0x04007494 RID: 29844
		MaxLabelLength,
		// Token: 0x04007495 RID: 29845
		NumShadingLanguageVersions,
		// Token: 0x04007496 RID: 29846
		VertexAttribArrayLong = 34638,
		// Token: 0x04007497 RID: 29847
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x04007498 RID: 29848
		AnySamplesPassedConservative,
		// Token: 0x04007499 RID: 29849
		MaxElementIndex,
		// Token: 0x0400749A RID: 29850
		MaxCombinedShaderOutputResources = 36665,
		// Token: 0x0400749B RID: 29851
		VertexBindingBuffer = 36687,
		// Token: 0x0400749C RID: 29852
		ShaderStorageBuffer = 37074,
		// Token: 0x0400749D RID: 29853
		ShaderStorageBufferBinding,
		// Token: 0x0400749E RID: 29854
		ShaderStorageBufferStart,
		// Token: 0x0400749F RID: 29855
		ShaderStorageBufferSize,
		// Token: 0x040074A0 RID: 29856
		MaxVertexShaderStorageBlocks,
		// Token: 0x040074A1 RID: 29857
		MaxGeometryShaderStorageBlocks,
		// Token: 0x040074A2 RID: 29858
		MaxTessControlShaderStorageBlocks,
		// Token: 0x040074A3 RID: 29859
		MaxTessEvaluationShaderStorageBlocks,
		// Token: 0x040074A4 RID: 29860
		MaxFragmentShaderStorageBlocks,
		// Token: 0x040074A5 RID: 29861
		MaxComputeShaderStorageBlocks,
		// Token: 0x040074A6 RID: 29862
		MaxCombinedShaderStorageBlocks,
		// Token: 0x040074A7 RID: 29863
		MaxShaderStorageBufferBindings,
		// Token: 0x040074A8 RID: 29864
		MaxShaderStorageBlockSize,
		// Token: 0x040074A9 RID: 29865
		ShaderStorageBufferOffsetAlignment,
		// Token: 0x040074AA RID: 29866
		DepthStencilTextureMode = 37098,
		// Token: 0x040074AB RID: 29867
		MaxComputeWorkGroupInvocations,
		// Token: 0x040074AC RID: 29868
		UniformBlockReferencedByComputeShader,
		// Token: 0x040074AD RID: 29869
		AtomicCounterBufferReferencedByComputeShader,
		// Token: 0x040074AE RID: 29870
		DispatchIndirectBuffer,
		// Token: 0x040074AF RID: 29871
		DispatchIndirectBufferBinding,
		// Token: 0x040074B0 RID: 29872
		MaxDebugMessageLength = 37187,
		// Token: 0x040074B1 RID: 29873
		MaxDebugLoggedMessages,
		// Token: 0x040074B2 RID: 29874
		DebugLoggedMessages,
		// Token: 0x040074B3 RID: 29875
		DebugSeverityHigh,
		// Token: 0x040074B4 RID: 29876
		DebugSeverityMedium,
		// Token: 0x040074B5 RID: 29877
		DebugSeverityLow,
		// Token: 0x040074B6 RID: 29878
		TextureBufferOffset = 37277,
		// Token: 0x040074B7 RID: 29879
		TextureBufferSize,
		// Token: 0x040074B8 RID: 29880
		TextureBufferOffsetAlignment,
		// Token: 0x040074B9 RID: 29881
		ComputeShader = 37305,
		// Token: 0x040074BA RID: 29882
		MaxComputeUniformBlocks = 37307,
		// Token: 0x040074BB RID: 29883
		MaxComputeTextureImageUnits,
		// Token: 0x040074BC RID: 29884
		MaxComputeImageUniforms,
		// Token: 0x040074BD RID: 29885
		MaxComputeWorkGroupCount,
		// Token: 0x040074BE RID: 29886
		MaxComputeWorkGroupSize,
		// Token: 0x040074BF RID: 29887
		CompressedR11Eac = 37488,
		// Token: 0x040074C0 RID: 29888
		CompressedSignedR11Eac,
		// Token: 0x040074C1 RID: 29889
		CompressedRg11Eac,
		// Token: 0x040074C2 RID: 29890
		CompressedSignedRg11Eac,
		// Token: 0x040074C3 RID: 29891
		CompressedRgb8Etc2,
		// Token: 0x040074C4 RID: 29892
		CompressedSrgb8Etc2,
		// Token: 0x040074C5 RID: 29893
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x040074C6 RID: 29894
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x040074C7 RID: 29895
		CompressedRgba8Etc2Eac,
		// Token: 0x040074C8 RID: 29896
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x040074C9 RID: 29897
		DebugOutput = 37600,
		// Token: 0x040074CA RID: 29898
		Uniform,
		// Token: 0x040074CB RID: 29899
		UniformBlock,
		// Token: 0x040074CC RID: 29900
		ProgramInput,
		// Token: 0x040074CD RID: 29901
		ProgramOutput,
		// Token: 0x040074CE RID: 29902
		BufferVariable,
		// Token: 0x040074CF RID: 29903
		ShaderStorageBlock,
		// Token: 0x040074D0 RID: 29904
		IsPerPatch,
		// Token: 0x040074D1 RID: 29905
		VertexSubroutine,
		// Token: 0x040074D2 RID: 29906
		TessControlSubroutine,
		// Token: 0x040074D3 RID: 29907
		TessEvaluationSubroutine,
		// Token: 0x040074D4 RID: 29908
		GeometrySubroutine,
		// Token: 0x040074D5 RID: 29909
		FragmentSubroutine,
		// Token: 0x040074D6 RID: 29910
		ComputeSubroutine,
		// Token: 0x040074D7 RID: 29911
		VertexSubroutineUniform,
		// Token: 0x040074D8 RID: 29912
		TessControlSubroutineUniform,
		// Token: 0x040074D9 RID: 29913
		TessEvaluationSubroutineUniform,
		// Token: 0x040074DA RID: 29914
		GeometrySubroutineUniform,
		// Token: 0x040074DB RID: 29915
		FragmentSubroutineUniform,
		// Token: 0x040074DC RID: 29916
		ComputeSubroutineUniform,
		// Token: 0x040074DD RID: 29917
		TransformFeedbackVarying,
		// Token: 0x040074DE RID: 29918
		ActiveResources,
		// Token: 0x040074DF RID: 29919
		MaxNameLength,
		// Token: 0x040074E0 RID: 29920
		MaxNumActiveVariables,
		// Token: 0x040074E1 RID: 29921
		MaxNumCompatibleSubroutines,
		// Token: 0x040074E2 RID: 29922
		NameLength,
		// Token: 0x040074E3 RID: 29923
		Type,
		// Token: 0x040074E4 RID: 29924
		ArraySize,
		// Token: 0x040074E5 RID: 29925
		Offset,
		// Token: 0x040074E6 RID: 29926
		BlockIndex,
		// Token: 0x040074E7 RID: 29927
		ArrayStride,
		// Token: 0x040074E8 RID: 29928
		MatrixStride,
		// Token: 0x040074E9 RID: 29929
		IsRowMajor,
		// Token: 0x040074EA RID: 29930
		AtomicCounterBufferIndex,
		// Token: 0x040074EB RID: 29931
		BufferBinding,
		// Token: 0x040074EC RID: 29932
		BufferDataSize,
		// Token: 0x040074ED RID: 29933
		NumActiveVariables,
		// Token: 0x040074EE RID: 29934
		ActiveVariables,
		// Token: 0x040074EF RID: 29935
		ReferencedByVertexShader,
		// Token: 0x040074F0 RID: 29936
		ReferencedByTessControlShader,
		// Token: 0x040074F1 RID: 29937
		ReferencedByTessEvaluationShader,
		// Token: 0x040074F2 RID: 29938
		ReferencedByGeometryShader,
		// Token: 0x040074F3 RID: 29939
		ReferencedByFragmentShader,
		// Token: 0x040074F4 RID: 29940
		ReferencedByComputeShader,
		// Token: 0x040074F5 RID: 29941
		TopLevelArraySize,
		// Token: 0x040074F6 RID: 29942
		TopLevelArrayStride,
		// Token: 0x040074F7 RID: 29943
		Location,
		// Token: 0x040074F8 RID: 29944
		LocationIndex,
		// Token: 0x040074F9 RID: 29945
		FramebufferDefaultWidth,
		// Token: 0x040074FA RID: 29946
		FramebufferDefaultHeight,
		// Token: 0x040074FB RID: 29947
		FramebufferDefaultLayers,
		// Token: 0x040074FC RID: 29948
		FramebufferDefaultSamples,
		// Token: 0x040074FD RID: 29949
		FramebufferDefaultFixedSampleLocations,
		// Token: 0x040074FE RID: 29950
		MaxFramebufferWidth,
		// Token: 0x040074FF RID: 29951
		MaxFramebufferHeight,
		// Token: 0x04007500 RID: 29952
		MaxFramebufferLayers,
		// Token: 0x04007501 RID: 29953
		MaxFramebufferSamples
	}
}
