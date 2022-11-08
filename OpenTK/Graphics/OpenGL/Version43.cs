using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004A3 RID: 1187
	public enum Version43
	{
		// Token: 0x04004956 RID: 18774
		ContextFlagDebugBit = 2,
		// Token: 0x04004957 RID: 18775
		ComputeShaderBit = 32,
		// Token: 0x04004958 RID: 18776
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04004959 RID: 18777
		StackOverflow = 1283,
		// Token: 0x0400495A RID: 18778
		StackUnderflow,
		// Token: 0x0400495B RID: 18779
		VertexArray = 32884,
		// Token: 0x0400495C RID: 18780
		DebugOutputSynchronous = 33346,
		// Token: 0x0400495D RID: 18781
		DebugNextLoggedMessageLength,
		// Token: 0x0400495E RID: 18782
		DebugCallbackFunction,
		// Token: 0x0400495F RID: 18783
		DebugCallbackUserParam,
		// Token: 0x04004960 RID: 18784
		DebugSourceApi,
		// Token: 0x04004961 RID: 18785
		DebugSourceWindowSystem,
		// Token: 0x04004962 RID: 18786
		DebugSourceShaderCompiler,
		// Token: 0x04004963 RID: 18787
		DebugSourceThirdParty,
		// Token: 0x04004964 RID: 18788
		DebugSourceApplication,
		// Token: 0x04004965 RID: 18789
		DebugSourceOther,
		// Token: 0x04004966 RID: 18790
		DebugTypeError,
		// Token: 0x04004967 RID: 18791
		DebugTypeDeprecatedBehavior,
		// Token: 0x04004968 RID: 18792
		DebugTypeUndefinedBehavior,
		// Token: 0x04004969 RID: 18793
		DebugTypePortability,
		// Token: 0x0400496A RID: 18794
		DebugTypePerformance,
		// Token: 0x0400496B RID: 18795
		DebugTypeOther,
		// Token: 0x0400496C RID: 18796
		MaxComputeSharedMemorySize = 33378,
		// Token: 0x0400496D RID: 18797
		MaxComputeUniformComponents,
		// Token: 0x0400496E RID: 18798
		MaxComputeAtomicCounterBuffers,
		// Token: 0x0400496F RID: 18799
		MaxComputeAtomicCounters,
		// Token: 0x04004970 RID: 18800
		MaxCombinedComputeUniformComponents,
		// Token: 0x04004971 RID: 18801
		ComputeWorkGroupSize,
		// Token: 0x04004972 RID: 18802
		DebugTypeMarker,
		// Token: 0x04004973 RID: 18803
		DebugTypePushGroup,
		// Token: 0x04004974 RID: 18804
		DebugTypePopGroup,
		// Token: 0x04004975 RID: 18805
		DebugSeverityNotification,
		// Token: 0x04004976 RID: 18806
		MaxDebugGroupStackDepth,
		// Token: 0x04004977 RID: 18807
		DebugGroupStackDepth,
		// Token: 0x04004978 RID: 18808
		MaxUniformLocations,
		// Token: 0x04004979 RID: 18809
		InternalformatSupported,
		// Token: 0x0400497A RID: 18810
		InternalformatPreferred,
		// Token: 0x0400497B RID: 18811
		InternalformatRedSize,
		// Token: 0x0400497C RID: 18812
		InternalformatGreenSize,
		// Token: 0x0400497D RID: 18813
		InternalformatBlueSize,
		// Token: 0x0400497E RID: 18814
		InternalformatAlphaSize,
		// Token: 0x0400497F RID: 18815
		InternalformatDepthSize,
		// Token: 0x04004980 RID: 18816
		InternalformatStencilSize,
		// Token: 0x04004981 RID: 18817
		InternalformatSharedSize,
		// Token: 0x04004982 RID: 18818
		InternalformatRedType,
		// Token: 0x04004983 RID: 18819
		InternalformatGreenType,
		// Token: 0x04004984 RID: 18820
		InternalformatBlueType,
		// Token: 0x04004985 RID: 18821
		InternalformatAlphaType,
		// Token: 0x04004986 RID: 18822
		InternalformatDepthType,
		// Token: 0x04004987 RID: 18823
		InternalformatStencilType,
		// Token: 0x04004988 RID: 18824
		MaxWidth,
		// Token: 0x04004989 RID: 18825
		MaxHeight,
		// Token: 0x0400498A RID: 18826
		MaxDepth,
		// Token: 0x0400498B RID: 18827
		MaxLayers,
		// Token: 0x0400498C RID: 18828
		MaxCombinedDimensions,
		// Token: 0x0400498D RID: 18829
		ColorComponents,
		// Token: 0x0400498E RID: 18830
		DepthComponents,
		// Token: 0x0400498F RID: 18831
		StencilComponents,
		// Token: 0x04004990 RID: 18832
		ColorRenderable,
		// Token: 0x04004991 RID: 18833
		DepthRenderable,
		// Token: 0x04004992 RID: 18834
		StencilRenderable,
		// Token: 0x04004993 RID: 18835
		FramebufferRenderable,
		// Token: 0x04004994 RID: 18836
		FramebufferRenderableLayered,
		// Token: 0x04004995 RID: 18837
		FramebufferBlend,
		// Token: 0x04004996 RID: 18838
		ReadPixels,
		// Token: 0x04004997 RID: 18839
		ReadPixelsFormat,
		// Token: 0x04004998 RID: 18840
		ReadPixelsType,
		// Token: 0x04004999 RID: 18841
		TextureImageFormat,
		// Token: 0x0400499A RID: 18842
		TextureImageType,
		// Token: 0x0400499B RID: 18843
		GetTextureImageFormat,
		// Token: 0x0400499C RID: 18844
		GetTextureImageType,
		// Token: 0x0400499D RID: 18845
		Mipmap,
		// Token: 0x0400499E RID: 18846
		ManualGenerateMipmap,
		// Token: 0x0400499F RID: 18847
		AutoGenerateMipmap,
		// Token: 0x040049A0 RID: 18848
		ColorEncoding,
		// Token: 0x040049A1 RID: 18849
		SrgbRead,
		// Token: 0x040049A2 RID: 18850
		SrgbWrite,
		// Token: 0x040049A3 RID: 18851
		Filter = 33434,
		// Token: 0x040049A4 RID: 18852
		VertexTexture,
		// Token: 0x040049A5 RID: 18853
		TessControlTexture,
		// Token: 0x040049A6 RID: 18854
		TessEvaluationTexture,
		// Token: 0x040049A7 RID: 18855
		GeometryTexture,
		// Token: 0x040049A8 RID: 18856
		FragmentTexture,
		// Token: 0x040049A9 RID: 18857
		ComputeTexture,
		// Token: 0x040049AA RID: 18858
		TextureShadow,
		// Token: 0x040049AB RID: 18859
		TextureGather,
		// Token: 0x040049AC RID: 18860
		TextureGatherShadow,
		// Token: 0x040049AD RID: 18861
		ShaderImageLoad,
		// Token: 0x040049AE RID: 18862
		ShaderImageStore,
		// Token: 0x040049AF RID: 18863
		ShaderImageAtomic,
		// Token: 0x040049B0 RID: 18864
		ImageTexelSize,
		// Token: 0x040049B1 RID: 18865
		ImageCompatibilityClass,
		// Token: 0x040049B2 RID: 18866
		ImagePixelFormat,
		// Token: 0x040049B3 RID: 18867
		ImagePixelType,
		// Token: 0x040049B4 RID: 18868
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x040049B5 RID: 18869
		SimultaneousTextureAndStencilTest,
		// Token: 0x040049B6 RID: 18870
		SimultaneousTextureAndDepthWrite,
		// Token: 0x040049B7 RID: 18871
		SimultaneousTextureAndStencilWrite,
		// Token: 0x040049B8 RID: 18872
		TextureCompressedBlockWidth = 33457,
		// Token: 0x040049B9 RID: 18873
		TextureCompressedBlockHeight,
		// Token: 0x040049BA RID: 18874
		TextureCompressedBlockSize,
		// Token: 0x040049BB RID: 18875
		ClearBuffer,
		// Token: 0x040049BC RID: 18876
		TextureView,
		// Token: 0x040049BD RID: 18877
		ViewCompatibilityClass,
		// Token: 0x040049BE RID: 18878
		FullSupport,
		// Token: 0x040049BF RID: 18879
		CaveatSupport,
		// Token: 0x040049C0 RID: 18880
		ImageClass4X32,
		// Token: 0x040049C1 RID: 18881
		ImageClass2X32,
		// Token: 0x040049C2 RID: 18882
		ImageClass1X32,
		// Token: 0x040049C3 RID: 18883
		ImageClass4X16,
		// Token: 0x040049C4 RID: 18884
		ImageClass2X16,
		// Token: 0x040049C5 RID: 18885
		ImageClass1X16,
		// Token: 0x040049C6 RID: 18886
		ImageClass4X8,
		// Token: 0x040049C7 RID: 18887
		ImageClass2X8,
		// Token: 0x040049C8 RID: 18888
		ImageClass1X8,
		// Token: 0x040049C9 RID: 18889
		ImageClass111110,
		// Token: 0x040049CA RID: 18890
		ImageClass1010102,
		// Token: 0x040049CB RID: 18891
		ViewClass128Bits,
		// Token: 0x040049CC RID: 18892
		ViewClass96Bits,
		// Token: 0x040049CD RID: 18893
		ViewClass64Bits,
		// Token: 0x040049CE RID: 18894
		ViewClass48Bits,
		// Token: 0x040049CF RID: 18895
		ViewClass32Bits,
		// Token: 0x040049D0 RID: 18896
		ViewClass24Bits,
		// Token: 0x040049D1 RID: 18897
		ViewClass16Bits,
		// Token: 0x040049D2 RID: 18898
		ViewClass8Bits,
		// Token: 0x040049D3 RID: 18899
		ViewClassS3tcDxt1Rgb,
		// Token: 0x040049D4 RID: 18900
		ViewClassS3tcDxt1Rgba,
		// Token: 0x040049D5 RID: 18901
		ViewClassS3tcDxt3Rgba,
		// Token: 0x040049D6 RID: 18902
		ViewClassS3tcDxt5Rgba,
		// Token: 0x040049D7 RID: 18903
		ViewClassRgtc1Red,
		// Token: 0x040049D8 RID: 18904
		ViewClassRgtc2Rg,
		// Token: 0x040049D9 RID: 18905
		ViewClassBptcUnorm,
		// Token: 0x040049DA RID: 18906
		ViewClassBptcFloat,
		// Token: 0x040049DB RID: 18907
		VertexAttribBinding,
		// Token: 0x040049DC RID: 18908
		VertexAttribRelativeOffset,
		// Token: 0x040049DD RID: 18909
		VertexBindingDivisor,
		// Token: 0x040049DE RID: 18910
		VertexBindingOffset,
		// Token: 0x040049DF RID: 18911
		VertexBindingStride,
		// Token: 0x040049E0 RID: 18912
		MaxVertexAttribRelativeOffset,
		// Token: 0x040049E1 RID: 18913
		MaxVertexAttribBindings,
		// Token: 0x040049E2 RID: 18914
		TextureViewMinLevel,
		// Token: 0x040049E3 RID: 18915
		TextureViewNumLevels,
		// Token: 0x040049E4 RID: 18916
		TextureViewMinLayer,
		// Token: 0x040049E5 RID: 18917
		TextureViewNumLayers,
		// Token: 0x040049E6 RID: 18918
		TextureImmutableLevels,
		// Token: 0x040049E7 RID: 18919
		Buffer,
		// Token: 0x040049E8 RID: 18920
		Shader,
		// Token: 0x040049E9 RID: 18921
		Program,
		// Token: 0x040049EA RID: 18922
		Query,
		// Token: 0x040049EB RID: 18923
		ProgramPipeline,
		// Token: 0x040049EC RID: 18924
		Sampler = 33510,
		// Token: 0x040049ED RID: 18925
		DisplayList,
		// Token: 0x040049EE RID: 18926
		MaxLabelLength,
		// Token: 0x040049EF RID: 18927
		NumShadingLanguageVersions,
		// Token: 0x040049F0 RID: 18928
		VertexAttribArrayLong = 34638,
		// Token: 0x040049F1 RID: 18929
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x040049F2 RID: 18930
		AnySamplesPassedConservative,
		// Token: 0x040049F3 RID: 18931
		MaxElementIndex,
		// Token: 0x040049F4 RID: 18932
		MaxCombinedShaderOutputResources = 36665,
		// Token: 0x040049F5 RID: 18933
		VertexBindingBuffer = 36687,
		// Token: 0x040049F6 RID: 18934
		ShaderStorageBuffer = 37074,
		// Token: 0x040049F7 RID: 18935
		ShaderStorageBufferBinding,
		// Token: 0x040049F8 RID: 18936
		ShaderStorageBufferStart,
		// Token: 0x040049F9 RID: 18937
		ShaderStorageBufferSize,
		// Token: 0x040049FA RID: 18938
		MaxVertexShaderStorageBlocks,
		// Token: 0x040049FB RID: 18939
		MaxGeometryShaderStorageBlocks,
		// Token: 0x040049FC RID: 18940
		MaxTessControlShaderStorageBlocks,
		// Token: 0x040049FD RID: 18941
		MaxTessEvaluationShaderStorageBlocks,
		// Token: 0x040049FE RID: 18942
		MaxFragmentShaderStorageBlocks,
		// Token: 0x040049FF RID: 18943
		MaxComputeShaderStorageBlocks,
		// Token: 0x04004A00 RID: 18944
		MaxCombinedShaderStorageBlocks,
		// Token: 0x04004A01 RID: 18945
		MaxShaderStorageBufferBindings,
		// Token: 0x04004A02 RID: 18946
		MaxShaderStorageBlockSize,
		// Token: 0x04004A03 RID: 18947
		ShaderStorageBufferOffsetAlignment,
		// Token: 0x04004A04 RID: 18948
		DepthStencilTextureMode = 37098,
		// Token: 0x04004A05 RID: 18949
		MaxComputeWorkGroupInvocations,
		// Token: 0x04004A06 RID: 18950
		UniformBlockReferencedByComputeShader,
		// Token: 0x04004A07 RID: 18951
		AtomicCounterBufferReferencedByComputeShader,
		// Token: 0x04004A08 RID: 18952
		DispatchIndirectBuffer,
		// Token: 0x04004A09 RID: 18953
		DispatchIndirectBufferBinding,
		// Token: 0x04004A0A RID: 18954
		MaxDebugMessageLength = 37187,
		// Token: 0x04004A0B RID: 18955
		MaxDebugLoggedMessages,
		// Token: 0x04004A0C RID: 18956
		DebugLoggedMessages,
		// Token: 0x04004A0D RID: 18957
		DebugSeverityHigh,
		// Token: 0x04004A0E RID: 18958
		DebugSeverityMedium,
		// Token: 0x04004A0F RID: 18959
		DebugSeverityLow,
		// Token: 0x04004A10 RID: 18960
		TextureBufferOffset = 37277,
		// Token: 0x04004A11 RID: 18961
		TextureBufferSize,
		// Token: 0x04004A12 RID: 18962
		TextureBufferOffsetAlignment,
		// Token: 0x04004A13 RID: 18963
		ComputeShader = 37305,
		// Token: 0x04004A14 RID: 18964
		MaxComputeUniformBlocks = 37307,
		// Token: 0x04004A15 RID: 18965
		MaxComputeTextureImageUnits,
		// Token: 0x04004A16 RID: 18966
		MaxComputeImageUniforms,
		// Token: 0x04004A17 RID: 18967
		MaxComputeWorkGroupCount,
		// Token: 0x04004A18 RID: 18968
		MaxComputeWorkGroupSize,
		// Token: 0x04004A19 RID: 18969
		CompressedR11Eac = 37488,
		// Token: 0x04004A1A RID: 18970
		CompressedSignedR11Eac,
		// Token: 0x04004A1B RID: 18971
		CompressedRg11Eac,
		// Token: 0x04004A1C RID: 18972
		CompressedSignedRg11Eac,
		// Token: 0x04004A1D RID: 18973
		CompressedRgb8Etc2,
		// Token: 0x04004A1E RID: 18974
		CompressedSrgb8Etc2,
		// Token: 0x04004A1F RID: 18975
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x04004A20 RID: 18976
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x04004A21 RID: 18977
		CompressedRgba8Etc2Eac,
		// Token: 0x04004A22 RID: 18978
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x04004A23 RID: 18979
		DebugOutput = 37600,
		// Token: 0x04004A24 RID: 18980
		Uniform,
		// Token: 0x04004A25 RID: 18981
		UniformBlock,
		// Token: 0x04004A26 RID: 18982
		ProgramInput,
		// Token: 0x04004A27 RID: 18983
		ProgramOutput,
		// Token: 0x04004A28 RID: 18984
		BufferVariable,
		// Token: 0x04004A29 RID: 18985
		ShaderStorageBlock,
		// Token: 0x04004A2A RID: 18986
		IsPerPatch,
		// Token: 0x04004A2B RID: 18987
		VertexSubroutine,
		// Token: 0x04004A2C RID: 18988
		TessControlSubroutine,
		// Token: 0x04004A2D RID: 18989
		TessEvaluationSubroutine,
		// Token: 0x04004A2E RID: 18990
		GeometrySubroutine,
		// Token: 0x04004A2F RID: 18991
		FragmentSubroutine,
		// Token: 0x04004A30 RID: 18992
		ComputeSubroutine,
		// Token: 0x04004A31 RID: 18993
		VertexSubroutineUniform,
		// Token: 0x04004A32 RID: 18994
		TessControlSubroutineUniform,
		// Token: 0x04004A33 RID: 18995
		TessEvaluationSubroutineUniform,
		// Token: 0x04004A34 RID: 18996
		GeometrySubroutineUniform,
		// Token: 0x04004A35 RID: 18997
		FragmentSubroutineUniform,
		// Token: 0x04004A36 RID: 18998
		ComputeSubroutineUniform,
		// Token: 0x04004A37 RID: 18999
		TransformFeedbackVarying,
		// Token: 0x04004A38 RID: 19000
		ActiveResources,
		// Token: 0x04004A39 RID: 19001
		MaxNameLength,
		// Token: 0x04004A3A RID: 19002
		MaxNumActiveVariables,
		// Token: 0x04004A3B RID: 19003
		MaxNumCompatibleSubroutines,
		// Token: 0x04004A3C RID: 19004
		NameLength,
		// Token: 0x04004A3D RID: 19005
		Type,
		// Token: 0x04004A3E RID: 19006
		ArraySize,
		// Token: 0x04004A3F RID: 19007
		Offset,
		// Token: 0x04004A40 RID: 19008
		BlockIndex,
		// Token: 0x04004A41 RID: 19009
		ArrayStride,
		// Token: 0x04004A42 RID: 19010
		MatrixStride,
		// Token: 0x04004A43 RID: 19011
		IsRowMajor,
		// Token: 0x04004A44 RID: 19012
		AtomicCounterBufferIndex,
		// Token: 0x04004A45 RID: 19013
		BufferBinding,
		// Token: 0x04004A46 RID: 19014
		BufferDataSize,
		// Token: 0x04004A47 RID: 19015
		NumActiveVariables,
		// Token: 0x04004A48 RID: 19016
		ActiveVariables,
		// Token: 0x04004A49 RID: 19017
		ReferencedByVertexShader,
		// Token: 0x04004A4A RID: 19018
		ReferencedByTessControlShader,
		// Token: 0x04004A4B RID: 19019
		ReferencedByTessEvaluationShader,
		// Token: 0x04004A4C RID: 19020
		ReferencedByGeometryShader,
		// Token: 0x04004A4D RID: 19021
		ReferencedByFragmentShader,
		// Token: 0x04004A4E RID: 19022
		ReferencedByComputeShader,
		// Token: 0x04004A4F RID: 19023
		TopLevelArraySize,
		// Token: 0x04004A50 RID: 19024
		TopLevelArrayStride,
		// Token: 0x04004A51 RID: 19025
		Location,
		// Token: 0x04004A52 RID: 19026
		LocationIndex,
		// Token: 0x04004A53 RID: 19027
		FramebufferDefaultWidth,
		// Token: 0x04004A54 RID: 19028
		FramebufferDefaultHeight,
		// Token: 0x04004A55 RID: 19029
		FramebufferDefaultLayers,
		// Token: 0x04004A56 RID: 19030
		FramebufferDefaultSamples,
		// Token: 0x04004A57 RID: 19031
		FramebufferDefaultFixedSampleLocations,
		// Token: 0x04004A58 RID: 19032
		MaxFramebufferWidth,
		// Token: 0x04004A59 RID: 19033
		MaxFramebufferHeight,
		// Token: 0x04004A5A RID: 19034
		MaxFramebufferLayers,
		// Token: 0x04004A5B RID: 19035
		MaxFramebufferSamples
	}
}
