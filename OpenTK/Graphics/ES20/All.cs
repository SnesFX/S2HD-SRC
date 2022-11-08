using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x020008CE RID: 2254
	public enum All
	{
		// Token: 0x04008F65 RID: 36709
		False,
		// Token: 0x04008F66 RID: 36710
		LayoutDefaultIntel = 0,
		// Token: 0x04008F67 RID: 36711
		NoError = 0,
		// Token: 0x04008F68 RID: 36712
		None = 0,
		// Token: 0x04008F69 RID: 36713
		NoneOes = 0,
		// Token: 0x04008F6A RID: 36714
		Zero = 0,
		// Token: 0x04008F6B RID: 36715
		Points = 0,
		// Token: 0x04008F6C RID: 36716
		PerfquerySingleContextIntel = 0,
		// Token: 0x04008F6D RID: 36717
		ClientPixelStoreBit,
		// Token: 0x04008F6E RID: 36718
		ColorBufferBit0Qcom = 1,
		// Token: 0x04008F6F RID: 36719
		ContextCoreProfileBit = 1,
		// Token: 0x04008F70 RID: 36720
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x04008F71 RID: 36721
		CurrentBit = 1,
		// Token: 0x04008F72 RID: 36722
		PerfqueryGlobalContextIntel = 1,
		// Token: 0x04008F73 RID: 36723
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x04008F74 RID: 36724
		SyncFlushCommandsBitApple = 1,
		// Token: 0x04008F75 RID: 36725
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04008F76 RID: 36726
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x04008F77 RID: 36727
		VertexShaderBit = 1,
		// Token: 0x04008F78 RID: 36728
		VertexShaderBitExt = 1,
		// Token: 0x04008F79 RID: 36729
		ClientVertexArrayBit,
		// Token: 0x04008F7A RID: 36730
		ColorBufferBit1Qcom = 2,
		// Token: 0x04008F7B RID: 36731
		ContextCompatibilityProfileBit = 2,
		// Token: 0x04008F7C RID: 36732
		ContextFlagDebugBit = 2,
		// Token: 0x04008F7D RID: 36733
		ContextFlagDebugBitKhr = 2,
		// Token: 0x04008F7E RID: 36734
		ElementArrayBarrierBit = 2,
		// Token: 0x04008F7F RID: 36735
		ElementArrayBarrierBitExt = 2,
		// Token: 0x04008F80 RID: 36736
		FragmentShaderBit = 2,
		// Token: 0x04008F81 RID: 36737
		FragmentShaderBitExt = 2,
		// Token: 0x04008F82 RID: 36738
		PointBit = 2,
		// Token: 0x04008F83 RID: 36739
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04008F84 RID: 36740
		ColorBufferBit2Qcom = 4,
		// Token: 0x04008F85 RID: 36741
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x04008F86 RID: 36742
		GeometryShaderBit = 4,
		// Token: 0x04008F87 RID: 36743
		GeometryShaderBitExt = 4,
		// Token: 0x04008F88 RID: 36744
		LineBit = 4,
		// Token: 0x04008F89 RID: 36745
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x04008F8A RID: 36746
		UniformBarrierBit = 4,
		// Token: 0x04008F8B RID: 36747
		UniformBarrierBitExt = 4,
		// Token: 0x04008F8C RID: 36748
		ColorBufferBit3Qcom = 8,
		// Token: 0x04008F8D RID: 36749
		PolygonBit = 8,
		// Token: 0x04008F8E RID: 36750
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04008F8F RID: 36751
		TessControlShaderBit = 8,
		// Token: 0x04008F90 RID: 36752
		TessControlShaderBitExt = 8,
		// Token: 0x04008F91 RID: 36753
		TextureFetchBarrierBit = 8,
		// Token: 0x04008F92 RID: 36754
		TextureFetchBarrierBitExt = 8,
		// Token: 0x04008F93 RID: 36755
		ColorBufferBit4Qcom = 16,
		// Token: 0x04008F94 RID: 36756
		PolygonStippleBit = 16,
		// Token: 0x04008F95 RID: 36757
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x04008F96 RID: 36758
		TessEvaluationShaderBit = 16,
		// Token: 0x04008F97 RID: 36759
		TessEvaluationShaderBitExt = 16,
		// Token: 0x04008F98 RID: 36760
		ColorBufferBit5Qcom = 32,
		// Token: 0x04008F99 RID: 36761
		ComputeShaderBit = 32,
		// Token: 0x04008F9A RID: 36762
		PixelModeBit = 32,
		// Token: 0x04008F9B RID: 36763
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04008F9C RID: 36764
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04008F9D RID: 36765
		ColorBufferBit6Qcom = 64,
		// Token: 0x04008F9E RID: 36766
		CommandBarrierBit = 64,
		// Token: 0x04008F9F RID: 36767
		CommandBarrierBitExt = 64,
		// Token: 0x04008FA0 RID: 36768
		LightingBit = 64,
		// Token: 0x04008FA1 RID: 36769
		ColorBufferBit7Qcom = 128,
		// Token: 0x04008FA2 RID: 36770
		FogBit = 128,
		// Token: 0x04008FA3 RID: 36771
		PixelBufferBarrierBit = 128,
		// Token: 0x04008FA4 RID: 36772
		PixelBufferBarrierBitExt = 128,
		// Token: 0x04008FA5 RID: 36773
		DepthBufferBit = 256,
		// Token: 0x04008FA6 RID: 36774
		DepthBufferBit0Qcom = 256,
		// Token: 0x04008FA7 RID: 36775
		TextureUpdateBarrierBit = 256,
		// Token: 0x04008FA8 RID: 36776
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x04008FA9 RID: 36777
		AccumBufferBit = 512,
		// Token: 0x04008FAA RID: 36778
		BufferUpdateBarrierBit = 512,
		// Token: 0x04008FAB RID: 36779
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x04008FAC RID: 36780
		DepthBufferBit1Qcom = 512,
		// Token: 0x04008FAD RID: 36781
		DepthBufferBit2Qcom = 1024,
		// Token: 0x04008FAE RID: 36782
		FramebufferBarrierBit = 1024,
		// Token: 0x04008FAF RID: 36783
		FramebufferBarrierBitExt = 1024,
		// Token: 0x04008FB0 RID: 36784
		StencilBufferBit = 1024,
		// Token: 0x04008FB1 RID: 36785
		DepthBufferBit3Qcom = 2048,
		// Token: 0x04008FB2 RID: 36786
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04008FB3 RID: 36787
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x04008FB4 RID: 36788
		ViewportBit = 2048,
		// Token: 0x04008FB5 RID: 36789
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04008FB6 RID: 36790
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x04008FB7 RID: 36791
		DepthBufferBit4Qcom = 4096,
		// Token: 0x04008FB8 RID: 36792
		TransformBit = 4096,
		// Token: 0x04008FB9 RID: 36793
		DepthBufferBit5Qcom = 8192,
		// Token: 0x04008FBA RID: 36794
		EnableBit = 8192,
		// Token: 0x04008FBB RID: 36795
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04008FBC RID: 36796
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04008FBD RID: 36797
		ColorBufferBit = 16384,
		// Token: 0x04008FBE RID: 36798
		DepthBufferBit6Qcom = 16384,
		// Token: 0x04008FBF RID: 36799
		CoverageBufferBitNv = 32768,
		// Token: 0x04008FC0 RID: 36800
		DepthBufferBit7Qcom = 32768,
		// Token: 0x04008FC1 RID: 36801
		HintBit = 32768,
		// Token: 0x04008FC2 RID: 36802
		QueryBufferBarrierBit = 32768,
		// Token: 0x04008FC3 RID: 36803
		MapReadBit = 1,
		// Token: 0x04008FC4 RID: 36804
		MapReadBitExt = 1,
		// Token: 0x04008FC5 RID: 36805
		Lines = 1,
		// Token: 0x04008FC6 RID: 36806
		EvalBit = 65536,
		// Token: 0x04008FC7 RID: 36807
		StencilBufferBit0Qcom = 65536,
		// Token: 0x04008FC8 RID: 36808
		LineLoop = 2,
		// Token: 0x04008FC9 RID: 36809
		MapWriteBit = 2,
		// Token: 0x04008FCA RID: 36810
		MapWriteBitExt = 2,
		// Token: 0x04008FCB RID: 36811
		ListBit = 131072,
		// Token: 0x04008FCC RID: 36812
		StencilBufferBit1Qcom = 131072,
		// Token: 0x04008FCD RID: 36813
		LineStrip = 3,
		// Token: 0x04008FCE RID: 36814
		MapInvalidateRangeBit,
		// Token: 0x04008FCF RID: 36815
		MapInvalidateRangeBitExt = 4,
		// Token: 0x04008FD0 RID: 36816
		Triangles = 4,
		// Token: 0x04008FD1 RID: 36817
		StencilBufferBit2Qcom = 262144,
		// Token: 0x04008FD2 RID: 36818
		TextureBit = 262144,
		// Token: 0x04008FD3 RID: 36819
		TriangleStrip = 5,
		// Token: 0x04008FD4 RID: 36820
		TriangleFan,
		// Token: 0x04008FD5 RID: 36821
		Quads,
		// Token: 0x04008FD6 RID: 36822
		QuadsExt = 7,
		// Token: 0x04008FD7 RID: 36823
		MapInvalidateBufferBit,
		// Token: 0x04008FD8 RID: 36824
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04008FD9 RID: 36825
		QuadStrip = 8,
		// Token: 0x04008FDA RID: 36826
		ScissorBit = 524288,
		// Token: 0x04008FDB RID: 36827
		StencilBufferBit3Qcom = 524288,
		// Token: 0x04008FDC RID: 36828
		Polygon = 9,
		// Token: 0x04008FDD RID: 36829
		LinesAdjacency,
		// Token: 0x04008FDE RID: 36830
		LinesAdjacencyArb = 10,
		// Token: 0x04008FDF RID: 36831
		LinesAdjacencyExt = 10,
		// Token: 0x04008FE0 RID: 36832
		LineStripAdjacency,
		// Token: 0x04008FE1 RID: 36833
		LineStripAdjacencyArb = 11,
		// Token: 0x04008FE2 RID: 36834
		LineStripAdjacencyExt = 11,
		// Token: 0x04008FE3 RID: 36835
		TrianglesAdjacency,
		// Token: 0x04008FE4 RID: 36836
		TrianglesAdjacencyArb = 12,
		// Token: 0x04008FE5 RID: 36837
		TrianglesAdjacencyExt = 12,
		// Token: 0x04008FE6 RID: 36838
		TriangleStripAdjacency,
		// Token: 0x04008FE7 RID: 36839
		TriangleStripAdjacencyArb = 13,
		// Token: 0x04008FE8 RID: 36840
		TriangleStripAdjacencyExt = 13,
		// Token: 0x04008FE9 RID: 36841
		Patches,
		// Token: 0x04008FEA RID: 36842
		PatchesExt = 14,
		// Token: 0x04008FEB RID: 36843
		MapFlushExplicitBit = 16,
		// Token: 0x04008FEC RID: 36844
		MapFlushExplicitBitExt = 16,
		// Token: 0x04008FED RID: 36845
		StencilBufferBit4Qcom = 1048576,
		// Token: 0x04008FEE RID: 36846
		MapUnsynchronizedBit = 32,
		// Token: 0x04008FEF RID: 36847
		MapUnsynchronizedBitExt = 32,
		// Token: 0x04008FF0 RID: 36848
		StencilBufferBit5Qcom = 2097152,
		// Token: 0x04008FF1 RID: 36849
		MapPersistentBit = 64,
		// Token: 0x04008FF2 RID: 36850
		StencilBufferBit6Qcom = 4194304,
		// Token: 0x04008FF3 RID: 36851
		MapCoherentBit = 128,
		// Token: 0x04008FF4 RID: 36852
		StencilBufferBit7Qcom = 8388608,
		// Token: 0x04008FF5 RID: 36853
		Accum = 256,
		// Token: 0x04008FF6 RID: 36854
		DynamicStorageBit = 256,
		// Token: 0x04008FF7 RID: 36855
		MultisampleBufferBit0Qcom = 16777216,
		// Token: 0x04008FF8 RID: 36856
		Load = 257,
		// Token: 0x04008FF9 RID: 36857
		Return,
		// Token: 0x04008FFA RID: 36858
		Mult,
		// Token: 0x04008FFB RID: 36859
		Add,
		// Token: 0x04008FFC RID: 36860
		ClientStorageBit = 512,
		// Token: 0x04008FFD RID: 36861
		Never = 512,
		// Token: 0x04008FFE RID: 36862
		MultisampleBufferBit1Qcom = 33554432,
		// Token: 0x04008FFF RID: 36863
		Less = 513,
		// Token: 0x04009000 RID: 36864
		Equal,
		// Token: 0x04009001 RID: 36865
		Lequal,
		// Token: 0x04009002 RID: 36866
		Greater,
		// Token: 0x04009003 RID: 36867
		Notequal,
		// Token: 0x04009004 RID: 36868
		Gequal,
		// Token: 0x04009005 RID: 36869
		Always,
		// Token: 0x04009006 RID: 36870
		SrcColor = 768,
		// Token: 0x04009007 RID: 36871
		OneMinusSrcColor,
		// Token: 0x04009008 RID: 36872
		SrcAlpha,
		// Token: 0x04009009 RID: 36873
		OneMinusSrcAlpha,
		// Token: 0x0400900A RID: 36874
		DstAlpha,
		// Token: 0x0400900B RID: 36875
		OneMinusDstAlpha,
		// Token: 0x0400900C RID: 36876
		DstColor,
		// Token: 0x0400900D RID: 36877
		OneMinusDstColor,
		// Token: 0x0400900E RID: 36878
		SrcAlphaSaturate,
		// Token: 0x0400900F RID: 36879
		FrontLeft = 1024,
		// Token: 0x04009010 RID: 36880
		MultisampleBufferBit2Qcom = 67108864,
		// Token: 0x04009011 RID: 36881
		FrontRight = 1025,
		// Token: 0x04009012 RID: 36882
		BackLeft,
		// Token: 0x04009013 RID: 36883
		BackRight,
		// Token: 0x04009014 RID: 36884
		Front,
		// Token: 0x04009015 RID: 36885
		Back,
		// Token: 0x04009016 RID: 36886
		Left,
		// Token: 0x04009017 RID: 36887
		Right,
		// Token: 0x04009018 RID: 36888
		FrontAndBack,
		// Token: 0x04009019 RID: 36889
		Aux0,
		// Token: 0x0400901A RID: 36890
		Aux1,
		// Token: 0x0400901B RID: 36891
		Aux2,
		// Token: 0x0400901C RID: 36892
		Aux3,
		// Token: 0x0400901D RID: 36893
		InvalidEnum = 1280,
		// Token: 0x0400901E RID: 36894
		InvalidValue,
		// Token: 0x0400901F RID: 36895
		InvalidOperation,
		// Token: 0x04009020 RID: 36896
		StackOverflow,
		// Token: 0x04009021 RID: 36897
		StackOverflowKhr = 1283,
		// Token: 0x04009022 RID: 36898
		StackUnderflow,
		// Token: 0x04009023 RID: 36899
		StackUnderflowKhr = 1284,
		// Token: 0x04009024 RID: 36900
		OutOfMemory,
		// Token: 0x04009025 RID: 36901
		InvalidFramebufferOperation,
		// Token: 0x04009026 RID: 36902
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x04009027 RID: 36903
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x04009028 RID: 36904
		Gl2D = 1536,
		// Token: 0x04009029 RID: 36905
		Gl3D,
		// Token: 0x0400902A RID: 36906
		Gl3DColor,
		// Token: 0x0400902B RID: 36907
		Gl3DColorTexture,
		// Token: 0x0400902C RID: 36908
		Gl4DColorTexture,
		// Token: 0x0400902D RID: 36909
		PassThroughToken = 1792,
		// Token: 0x0400902E RID: 36910
		PointToken,
		// Token: 0x0400902F RID: 36911
		LineToken,
		// Token: 0x04009030 RID: 36912
		PolygonToken,
		// Token: 0x04009031 RID: 36913
		BitmapToken,
		// Token: 0x04009032 RID: 36914
		DrawPixelToken,
		// Token: 0x04009033 RID: 36915
		CopyPixelToken,
		// Token: 0x04009034 RID: 36916
		LineResetToken,
		// Token: 0x04009035 RID: 36917
		Exp = 2048,
		// Token: 0x04009036 RID: 36918
		MultisampleBufferBit3Qcom = 134217728,
		// Token: 0x04009037 RID: 36919
		Exp2 = 2049,
		// Token: 0x04009038 RID: 36920
		Cw = 2304,
		// Token: 0x04009039 RID: 36921
		Ccw,
		// Token: 0x0400903A RID: 36922
		Coeff = 2560,
		// Token: 0x0400903B RID: 36923
		Order,
		// Token: 0x0400903C RID: 36924
		Domain,
		// Token: 0x0400903D RID: 36925
		CurrentColor = 2816,
		// Token: 0x0400903E RID: 36926
		CurrentIndex,
		// Token: 0x0400903F RID: 36927
		CurrentNormal,
		// Token: 0x04009040 RID: 36928
		CurrentTextureCoords,
		// Token: 0x04009041 RID: 36929
		CurrentRasterColor,
		// Token: 0x04009042 RID: 36930
		CurrentRasterIndex,
		// Token: 0x04009043 RID: 36931
		CurrentRasterTextureCoords,
		// Token: 0x04009044 RID: 36932
		CurrentRasterPosition,
		// Token: 0x04009045 RID: 36933
		CurrentRasterPositionValid,
		// Token: 0x04009046 RID: 36934
		CurrentRasterDistance,
		// Token: 0x04009047 RID: 36935
		PointSmooth = 2832,
		// Token: 0x04009048 RID: 36936
		PointSize,
		// Token: 0x04009049 RID: 36937
		PointSizeRange,
		// Token: 0x0400904A RID: 36938
		SmoothPointSizeRange = 2834,
		// Token: 0x0400904B RID: 36939
		PointSizeGranularity,
		// Token: 0x0400904C RID: 36940
		SmoothPointSizeGranularity = 2835,
		// Token: 0x0400904D RID: 36941
		LineSmooth = 2848,
		// Token: 0x0400904E RID: 36942
		LineWidth,
		// Token: 0x0400904F RID: 36943
		LineWidthRange,
		// Token: 0x04009050 RID: 36944
		SmoothLineWidthRange = 2850,
		// Token: 0x04009051 RID: 36945
		LineWidthGranularity,
		// Token: 0x04009052 RID: 36946
		SmoothLineWidthGranularity = 2851,
		// Token: 0x04009053 RID: 36947
		LineStipple,
		// Token: 0x04009054 RID: 36948
		LineStipplePattern,
		// Token: 0x04009055 RID: 36949
		LineStippleRepeat,
		// Token: 0x04009056 RID: 36950
		ListMode = 2864,
		// Token: 0x04009057 RID: 36951
		MaxListNesting,
		// Token: 0x04009058 RID: 36952
		ListBase,
		// Token: 0x04009059 RID: 36953
		ListIndex,
		// Token: 0x0400905A RID: 36954
		PolygonMode = 2880,
		// Token: 0x0400905B RID: 36955
		PolygonSmooth,
		// Token: 0x0400905C RID: 36956
		PolygonStipple,
		// Token: 0x0400905D RID: 36957
		EdgeFlag,
		// Token: 0x0400905E RID: 36958
		CullFace,
		// Token: 0x0400905F RID: 36959
		CullFaceMode,
		// Token: 0x04009060 RID: 36960
		FrontFace,
		// Token: 0x04009061 RID: 36961
		Lighting = 2896,
		// Token: 0x04009062 RID: 36962
		LightModelLocalViewer,
		// Token: 0x04009063 RID: 36963
		LightModelTwoSide,
		// Token: 0x04009064 RID: 36964
		LightModelAmbient,
		// Token: 0x04009065 RID: 36965
		ShadeModel,
		// Token: 0x04009066 RID: 36966
		ColorMaterialFace,
		// Token: 0x04009067 RID: 36967
		ColorMaterialParameter,
		// Token: 0x04009068 RID: 36968
		ColorMaterial,
		// Token: 0x04009069 RID: 36969
		Fog = 2912,
		// Token: 0x0400906A RID: 36970
		FogIndex,
		// Token: 0x0400906B RID: 36971
		FogDensity,
		// Token: 0x0400906C RID: 36972
		FogStart,
		// Token: 0x0400906D RID: 36973
		FogEnd,
		// Token: 0x0400906E RID: 36974
		FogMode,
		// Token: 0x0400906F RID: 36975
		FogColor,
		// Token: 0x04009070 RID: 36976
		DepthRange = 2928,
		// Token: 0x04009071 RID: 36977
		DepthTest,
		// Token: 0x04009072 RID: 36978
		DepthWritemask,
		// Token: 0x04009073 RID: 36979
		DepthClearValue,
		// Token: 0x04009074 RID: 36980
		DepthFunc,
		// Token: 0x04009075 RID: 36981
		AccumClearValue = 2944,
		// Token: 0x04009076 RID: 36982
		StencilTest = 2960,
		// Token: 0x04009077 RID: 36983
		StencilClearValue,
		// Token: 0x04009078 RID: 36984
		StencilFunc,
		// Token: 0x04009079 RID: 36985
		StencilValueMask,
		// Token: 0x0400907A RID: 36986
		StencilFail,
		// Token: 0x0400907B RID: 36987
		StencilPassDepthFail,
		// Token: 0x0400907C RID: 36988
		StencilPassDepthPass,
		// Token: 0x0400907D RID: 36989
		StencilRef,
		// Token: 0x0400907E RID: 36990
		StencilWritemask,
		// Token: 0x0400907F RID: 36991
		MatrixMode = 2976,
		// Token: 0x04009080 RID: 36992
		Normalize,
		// Token: 0x04009081 RID: 36993
		Viewport,
		// Token: 0x04009082 RID: 36994
		Modelview0StackDepthExt,
		// Token: 0x04009083 RID: 36995
		ModelviewStackDepth = 2979,
		// Token: 0x04009084 RID: 36996
		ProjectionStackDepth,
		// Token: 0x04009085 RID: 36997
		TextureStackDepth,
		// Token: 0x04009086 RID: 36998
		Modelview0MatrixExt,
		// Token: 0x04009087 RID: 36999
		ModelviewMatrix = 2982,
		// Token: 0x04009088 RID: 37000
		ProjectionMatrix,
		// Token: 0x04009089 RID: 37001
		TextureMatrix,
		// Token: 0x0400908A RID: 37002
		AttribStackDepth = 2992,
		// Token: 0x0400908B RID: 37003
		ClientAttribStackDepth,
		// Token: 0x0400908C RID: 37004
		AlphaTest = 3008,
		// Token: 0x0400908D RID: 37005
		AlphaTestQcom = 3008,
		// Token: 0x0400908E RID: 37006
		AlphaTestFunc,
		// Token: 0x0400908F RID: 37007
		AlphaTestFuncQcom = 3009,
		// Token: 0x04009090 RID: 37008
		AlphaTestRef,
		// Token: 0x04009091 RID: 37009
		AlphaTestRefQcom = 3010,
		// Token: 0x04009092 RID: 37010
		Dither = 3024,
		// Token: 0x04009093 RID: 37011
		BlendDst = 3040,
		// Token: 0x04009094 RID: 37012
		BlendSrc,
		// Token: 0x04009095 RID: 37013
		Blend,
		// Token: 0x04009096 RID: 37014
		LogicOpMode = 3056,
		// Token: 0x04009097 RID: 37015
		IndexLogicOp,
		// Token: 0x04009098 RID: 37016
		LogicOp = 3057,
		// Token: 0x04009099 RID: 37017
		ColorLogicOp,
		// Token: 0x0400909A RID: 37018
		AuxBuffers = 3072,
		// Token: 0x0400909B RID: 37019
		DrawBuffer,
		// Token: 0x0400909C RID: 37020
		DrawBufferExt = 3073,
		// Token: 0x0400909D RID: 37021
		ReadBuffer,
		// Token: 0x0400909E RID: 37022
		ReadBufferExt = 3074,
		// Token: 0x0400909F RID: 37023
		ReadBufferNv = 3074,
		// Token: 0x040090A0 RID: 37024
		ScissorBox = 3088,
		// Token: 0x040090A1 RID: 37025
		ScissorTest,
		// Token: 0x040090A2 RID: 37026
		IndexClearValue = 3104,
		// Token: 0x040090A3 RID: 37027
		IndexWritemask,
		// Token: 0x040090A4 RID: 37028
		ColorClearValue,
		// Token: 0x040090A5 RID: 37029
		ColorWritemask,
		// Token: 0x040090A6 RID: 37030
		IndexMode = 3120,
		// Token: 0x040090A7 RID: 37031
		RgbaMode,
		// Token: 0x040090A8 RID: 37032
		Doublebuffer,
		// Token: 0x040090A9 RID: 37033
		Stereo,
		// Token: 0x040090AA RID: 37034
		RenderMode = 3136,
		// Token: 0x040090AB RID: 37035
		PerspectiveCorrectionHint = 3152,
		// Token: 0x040090AC RID: 37036
		PointSmoothHint,
		// Token: 0x040090AD RID: 37037
		LineSmoothHint,
		// Token: 0x040090AE RID: 37038
		PolygonSmoothHint,
		// Token: 0x040090AF RID: 37039
		FogHint,
		// Token: 0x040090B0 RID: 37040
		TextureGenS = 3168,
		// Token: 0x040090B1 RID: 37041
		TextureGenT,
		// Token: 0x040090B2 RID: 37042
		TextureGenR,
		// Token: 0x040090B3 RID: 37043
		TextureGenQ,
		// Token: 0x040090B4 RID: 37044
		PixelMapIToI = 3184,
		// Token: 0x040090B5 RID: 37045
		PixelMapSToS,
		// Token: 0x040090B6 RID: 37046
		PixelMapIToR,
		// Token: 0x040090B7 RID: 37047
		PixelMapIToG,
		// Token: 0x040090B8 RID: 37048
		PixelMapIToB,
		// Token: 0x040090B9 RID: 37049
		PixelMapIToA,
		// Token: 0x040090BA RID: 37050
		PixelMapRToR,
		// Token: 0x040090BB RID: 37051
		PixelMapGToG,
		// Token: 0x040090BC RID: 37052
		PixelMapBToB,
		// Token: 0x040090BD RID: 37053
		PixelMapAToA,
		// Token: 0x040090BE RID: 37054
		PixelMapIToISize = 3248,
		// Token: 0x040090BF RID: 37055
		PixelMapSToSSize,
		// Token: 0x040090C0 RID: 37056
		PixelMapIToRSize,
		// Token: 0x040090C1 RID: 37057
		PixelMapIToGSize,
		// Token: 0x040090C2 RID: 37058
		PixelMapIToBSize,
		// Token: 0x040090C3 RID: 37059
		PixelMapIToASize,
		// Token: 0x040090C4 RID: 37060
		PixelMapRToRSize,
		// Token: 0x040090C5 RID: 37061
		PixelMapGToGSize,
		// Token: 0x040090C6 RID: 37062
		PixelMapBToBSize,
		// Token: 0x040090C7 RID: 37063
		PixelMapAToASize,
		// Token: 0x040090C8 RID: 37064
		UnpackSwapBytes = 3312,
		// Token: 0x040090C9 RID: 37065
		UnpackLsbFirst,
		// Token: 0x040090CA RID: 37066
		UnpackRowLength,
		// Token: 0x040090CB RID: 37067
		UnpackRowLengthExt = 3314,
		// Token: 0x040090CC RID: 37068
		UnpackSkipRows,
		// Token: 0x040090CD RID: 37069
		UnpackSkipRowsExt = 3315,
		// Token: 0x040090CE RID: 37070
		UnpackSkipPixels,
		// Token: 0x040090CF RID: 37071
		UnpackSkipPixelsExt = 3316,
		// Token: 0x040090D0 RID: 37072
		UnpackAlignment,
		// Token: 0x040090D1 RID: 37073
		PackSwapBytes = 3328,
		// Token: 0x040090D2 RID: 37074
		PackLsbFirst,
		// Token: 0x040090D3 RID: 37075
		PackRowLength,
		// Token: 0x040090D4 RID: 37076
		PackSkipRows,
		// Token: 0x040090D5 RID: 37077
		PackSkipPixels,
		// Token: 0x040090D6 RID: 37078
		PackAlignment,
		// Token: 0x040090D7 RID: 37079
		MapColor = 3344,
		// Token: 0x040090D8 RID: 37080
		MapStencil,
		// Token: 0x040090D9 RID: 37081
		IndexShift,
		// Token: 0x040090DA RID: 37082
		IndexOffset,
		// Token: 0x040090DB RID: 37083
		RedScale,
		// Token: 0x040090DC RID: 37084
		RedBias,
		// Token: 0x040090DD RID: 37085
		ZoomX,
		// Token: 0x040090DE RID: 37086
		ZoomY,
		// Token: 0x040090DF RID: 37087
		GreenScale,
		// Token: 0x040090E0 RID: 37088
		GreenBias,
		// Token: 0x040090E1 RID: 37089
		BlueScale,
		// Token: 0x040090E2 RID: 37090
		BlueBias,
		// Token: 0x040090E3 RID: 37091
		AlphaScale,
		// Token: 0x040090E4 RID: 37092
		AlphaBias,
		// Token: 0x040090E5 RID: 37093
		DepthScale,
		// Token: 0x040090E6 RID: 37094
		DepthBias,
		// Token: 0x040090E7 RID: 37095
		MaxEvalOrder = 3376,
		// Token: 0x040090E8 RID: 37096
		MaxLights,
		// Token: 0x040090E9 RID: 37097
		MaxClipDistances,
		// Token: 0x040090EA RID: 37098
		MaxClipPlanes = 3378,
		// Token: 0x040090EB RID: 37099
		MaxTextureSize,
		// Token: 0x040090EC RID: 37100
		MaxPixelMapTable,
		// Token: 0x040090ED RID: 37101
		MaxAttribStackDepth,
		// Token: 0x040090EE RID: 37102
		MaxModelviewStackDepth,
		// Token: 0x040090EF RID: 37103
		MaxNameStackDepth,
		// Token: 0x040090F0 RID: 37104
		MaxProjectionStackDepth,
		// Token: 0x040090F1 RID: 37105
		MaxTextureStackDepth,
		// Token: 0x040090F2 RID: 37106
		MaxViewportDims,
		// Token: 0x040090F3 RID: 37107
		MaxClientAttribStackDepth,
		// Token: 0x040090F4 RID: 37108
		SubpixelBits = 3408,
		// Token: 0x040090F5 RID: 37109
		IndexBits,
		// Token: 0x040090F6 RID: 37110
		RedBits,
		// Token: 0x040090F7 RID: 37111
		GreenBits,
		// Token: 0x040090F8 RID: 37112
		BlueBits,
		// Token: 0x040090F9 RID: 37113
		AlphaBits,
		// Token: 0x040090FA RID: 37114
		DepthBits,
		// Token: 0x040090FB RID: 37115
		StencilBits,
		// Token: 0x040090FC RID: 37116
		AccumRedBits,
		// Token: 0x040090FD RID: 37117
		AccumGreenBits,
		// Token: 0x040090FE RID: 37118
		AccumBlueBits,
		// Token: 0x040090FF RID: 37119
		AccumAlphaBits,
		// Token: 0x04009100 RID: 37120
		NameStackDepth = 3440,
		// Token: 0x04009101 RID: 37121
		AutoNormal = 3456,
		// Token: 0x04009102 RID: 37122
		Map1Color4 = 3472,
		// Token: 0x04009103 RID: 37123
		Map1Index,
		// Token: 0x04009104 RID: 37124
		Map1Normal,
		// Token: 0x04009105 RID: 37125
		Map1TextureCoord1,
		// Token: 0x04009106 RID: 37126
		Map1TextureCoord2,
		// Token: 0x04009107 RID: 37127
		Map1TextureCoord3,
		// Token: 0x04009108 RID: 37128
		Map1TextureCoord4,
		// Token: 0x04009109 RID: 37129
		Map1Vertex3,
		// Token: 0x0400910A RID: 37130
		Map1Vertex4,
		// Token: 0x0400910B RID: 37131
		Map2Color4 = 3504,
		// Token: 0x0400910C RID: 37132
		Map2Index,
		// Token: 0x0400910D RID: 37133
		Map2Normal,
		// Token: 0x0400910E RID: 37134
		Map2TextureCoord1,
		// Token: 0x0400910F RID: 37135
		Map2TextureCoord2,
		// Token: 0x04009110 RID: 37136
		Map2TextureCoord3,
		// Token: 0x04009111 RID: 37137
		Map2TextureCoord4,
		// Token: 0x04009112 RID: 37138
		Map2Vertex3,
		// Token: 0x04009113 RID: 37139
		Map2Vertex4,
		// Token: 0x04009114 RID: 37140
		Map1GridDomain = 3536,
		// Token: 0x04009115 RID: 37141
		Map1GridSegments,
		// Token: 0x04009116 RID: 37142
		Map2GridDomain,
		// Token: 0x04009117 RID: 37143
		Map2GridSegments,
		// Token: 0x04009118 RID: 37144
		Texture1D = 3552,
		// Token: 0x04009119 RID: 37145
		Texture2D,
		// Token: 0x0400911A RID: 37146
		FeedbackBufferPointer = 3568,
		// Token: 0x0400911B RID: 37147
		FeedbackBufferSize,
		// Token: 0x0400911C RID: 37148
		FeedbackBufferType,
		// Token: 0x0400911D RID: 37149
		SelectionBufferPointer,
		// Token: 0x0400911E RID: 37150
		SelectionBufferSize,
		// Token: 0x0400911F RID: 37151
		TextureWidth = 4096,
		// Token: 0x04009120 RID: 37152
		MultisampleBufferBit4Qcom = 268435456,
		// Token: 0x04009121 RID: 37153
		TextureHeight = 4097,
		// Token: 0x04009122 RID: 37154
		TextureComponents = 4099,
		// Token: 0x04009123 RID: 37155
		TextureInternalFormat = 4099,
		// Token: 0x04009124 RID: 37156
		TextureBorderColor,
		// Token: 0x04009125 RID: 37157
		TextureBorderColorExt = 4100,
		// Token: 0x04009126 RID: 37158
		TextureBorderColorNv = 4100,
		// Token: 0x04009127 RID: 37159
		TextureBorder,
		// Token: 0x04009128 RID: 37160
		DontCare = 4352,
		// Token: 0x04009129 RID: 37161
		Fastest,
		// Token: 0x0400912A RID: 37162
		Nicest,
		// Token: 0x0400912B RID: 37163
		Ambient = 4608,
		// Token: 0x0400912C RID: 37164
		Diffuse,
		// Token: 0x0400912D RID: 37165
		Specular,
		// Token: 0x0400912E RID: 37166
		Position,
		// Token: 0x0400912F RID: 37167
		SpotDirection,
		// Token: 0x04009130 RID: 37168
		SpotExponent,
		// Token: 0x04009131 RID: 37169
		SpotCutoff,
		// Token: 0x04009132 RID: 37170
		ConstantAttenuation,
		// Token: 0x04009133 RID: 37171
		LinearAttenuation,
		// Token: 0x04009134 RID: 37172
		QuadraticAttenuation,
		// Token: 0x04009135 RID: 37173
		Compile = 4864,
		// Token: 0x04009136 RID: 37174
		CompileAndExecute,
		// Token: 0x04009137 RID: 37175
		Byte = 5120,
		// Token: 0x04009138 RID: 37176
		UnsignedByte,
		// Token: 0x04009139 RID: 37177
		Short,
		// Token: 0x0400913A RID: 37178
		UnsignedShort,
		// Token: 0x0400913B RID: 37179
		Int,
		// Token: 0x0400913C RID: 37180
		UnsignedInt,
		// Token: 0x0400913D RID: 37181
		Float,
		// Token: 0x0400913E RID: 37182
		Gl2Bytes,
		// Token: 0x0400913F RID: 37183
		Gl3Bytes,
		// Token: 0x04009140 RID: 37184
		Gl4Bytes,
		// Token: 0x04009141 RID: 37185
		Double,
		// Token: 0x04009142 RID: 37186
		Fixed = 5132,
		// Token: 0x04009143 RID: 37187
		Clear = 5376,
		// Token: 0x04009144 RID: 37188
		And,
		// Token: 0x04009145 RID: 37189
		AndReverse,
		// Token: 0x04009146 RID: 37190
		Copy,
		// Token: 0x04009147 RID: 37191
		AndInverted,
		// Token: 0x04009148 RID: 37192
		Noop,
		// Token: 0x04009149 RID: 37193
		Xor,
		// Token: 0x0400914A RID: 37194
		XorNv = 5382,
		// Token: 0x0400914B RID: 37195
		Or,
		// Token: 0x0400914C RID: 37196
		Nor,
		// Token: 0x0400914D RID: 37197
		Equiv,
		// Token: 0x0400914E RID: 37198
		Invert,
		// Token: 0x0400914F RID: 37199
		OrReverse,
		// Token: 0x04009150 RID: 37200
		CopyInverted,
		// Token: 0x04009151 RID: 37201
		OrInverted,
		// Token: 0x04009152 RID: 37202
		Nand,
		// Token: 0x04009153 RID: 37203
		Set,
		// Token: 0x04009154 RID: 37204
		Emission = 5632,
		// Token: 0x04009155 RID: 37205
		Shininess,
		// Token: 0x04009156 RID: 37206
		AmbientAndDiffuse,
		// Token: 0x04009157 RID: 37207
		ColorIndexes,
		// Token: 0x04009158 RID: 37208
		Modelview = 5888,
		// Token: 0x04009159 RID: 37209
		Modelview0Ext = 5888,
		// Token: 0x0400915A RID: 37210
		Projection,
		// Token: 0x0400915B RID: 37211
		Texture,
		// Token: 0x0400915C RID: 37212
		Color = 6144,
		// Token: 0x0400915D RID: 37213
		ColorExt = 6144,
		// Token: 0x0400915E RID: 37214
		Depth,
		// Token: 0x0400915F RID: 37215
		DepthExt = 6145,
		// Token: 0x04009160 RID: 37216
		Stencil,
		// Token: 0x04009161 RID: 37217
		StencilExt = 6146,
		// Token: 0x04009162 RID: 37218
		ColorIndex = 6400,
		// Token: 0x04009163 RID: 37219
		StencilIndex,
		// Token: 0x04009164 RID: 37220
		StencilIndexOes = 6401,
		// Token: 0x04009165 RID: 37221
		DepthComponent,
		// Token: 0x04009166 RID: 37222
		Red,
		// Token: 0x04009167 RID: 37223
		RedExt = 6403,
		// Token: 0x04009168 RID: 37224
		RedNv = 6403,
		// Token: 0x04009169 RID: 37225
		Green,
		// Token: 0x0400916A RID: 37226
		GreenNv = 6404,
		// Token: 0x0400916B RID: 37227
		Blue,
		// Token: 0x0400916C RID: 37228
		BlueNv = 6405,
		// Token: 0x0400916D RID: 37229
		Alpha,
		// Token: 0x0400916E RID: 37230
		Rgb,
		// Token: 0x0400916F RID: 37231
		Rgba,
		// Token: 0x04009170 RID: 37232
		Luminance,
		// Token: 0x04009171 RID: 37233
		LuminanceAlpha,
		// Token: 0x04009172 RID: 37234
		Bitmap = 6656,
		// Token: 0x04009173 RID: 37235
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x04009174 RID: 37236
		ConserveMemoryHintPgi = 107005,
		// Token: 0x04009175 RID: 37237
		ReclaimMemoryHintPgi,
		// Token: 0x04009176 RID: 37238
		NativeGraphicsBeginHintPgi = 107011,
		// Token: 0x04009177 RID: 37239
		NativeGraphicsEndHintPgi,
		// Token: 0x04009178 RID: 37240
		AlwaysFastHintPgi = 107020,
		// Token: 0x04009179 RID: 37241
		AlwaysSoftHintPgi,
		// Token: 0x0400917A RID: 37242
		AllowDrawObjHintPgi,
		// Token: 0x0400917B RID: 37243
		AllowDrawWinHintPgi,
		// Token: 0x0400917C RID: 37244
		AllowDrawFrgHintPgi,
		// Token: 0x0400917D RID: 37245
		AllowDrawMemHintPgi,
		// Token: 0x0400917E RID: 37246
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x0400917F RID: 37247
		StrictLightingHintPgi,
		// Token: 0x04009180 RID: 37248
		StrictScissorHintPgi,
		// Token: 0x04009181 RID: 37249
		FullStippleHintPgi,
		// Token: 0x04009182 RID: 37250
		ClipNearHintPgi = 107040,
		// Token: 0x04009183 RID: 37251
		ClipFarHintPgi,
		// Token: 0x04009184 RID: 37252
		WideLineHintPgi,
		// Token: 0x04009185 RID: 37253
		BackNormalsHintPgi,
		// Token: 0x04009186 RID: 37254
		VertexDataHintPgi = 107050,
		// Token: 0x04009187 RID: 37255
		VertexConsistentHintPgi,
		// Token: 0x04009188 RID: 37256
		MaterialSideHintPgi,
		// Token: 0x04009189 RID: 37257
		MaxVertexHintPgi,
		// Token: 0x0400918A RID: 37258
		Point = 6912,
		// Token: 0x0400918B RID: 37259
		Line,
		// Token: 0x0400918C RID: 37260
		Fill,
		// Token: 0x0400918D RID: 37261
		Render = 7168,
		// Token: 0x0400918E RID: 37262
		Feedback,
		// Token: 0x0400918F RID: 37263
		Select,
		// Token: 0x04009190 RID: 37264
		Flat = 7424,
		// Token: 0x04009191 RID: 37265
		Smooth,
		// Token: 0x04009192 RID: 37266
		Keep = 7680,
		// Token: 0x04009193 RID: 37267
		Replace,
		// Token: 0x04009194 RID: 37268
		Incr,
		// Token: 0x04009195 RID: 37269
		Decr,
		// Token: 0x04009196 RID: 37270
		Vendor = 7936,
		// Token: 0x04009197 RID: 37271
		Renderer,
		// Token: 0x04009198 RID: 37272
		Version,
		// Token: 0x04009199 RID: 37273
		Extensions,
		// Token: 0x0400919A RID: 37274
		S = 8192,
		// Token: 0x0400919B RID: 37275
		MultisampleBit = 536870912,
		// Token: 0x0400919C RID: 37276
		MultisampleBit3Dfx = 536870912,
		// Token: 0x0400919D RID: 37277
		MultisampleBitArb = 536870912,
		// Token: 0x0400919E RID: 37278
		MultisampleBitExt = 536870912,
		// Token: 0x0400919F RID: 37279
		MultisampleBufferBit5Qcom = 536870912,
		// Token: 0x040091A0 RID: 37280
		T = 8193,
		// Token: 0x040091A1 RID: 37281
		R,
		// Token: 0x040091A2 RID: 37282
		Q,
		// Token: 0x040091A3 RID: 37283
		Modulate = 8448,
		// Token: 0x040091A4 RID: 37284
		Decal,
		// Token: 0x040091A5 RID: 37285
		TextureEnvMode = 8704,
		// Token: 0x040091A6 RID: 37286
		TextureEnvColor,
		// Token: 0x040091A7 RID: 37287
		TextureEnv = 8960,
		// Token: 0x040091A8 RID: 37288
		EyeLinear = 9216,
		// Token: 0x040091A9 RID: 37289
		ObjectLinear,
		// Token: 0x040091AA RID: 37290
		SphereMap,
		// Token: 0x040091AB RID: 37291
		TextureGenMode = 9472,
		// Token: 0x040091AC RID: 37292
		ObjectPlane,
		// Token: 0x040091AD RID: 37293
		EyePlane,
		// Token: 0x040091AE RID: 37294
		Nearest = 9728,
		// Token: 0x040091AF RID: 37295
		Linear,
		// Token: 0x040091B0 RID: 37296
		NearestMipmapNearest = 9984,
		// Token: 0x040091B1 RID: 37297
		LinearMipmapNearest,
		// Token: 0x040091B2 RID: 37298
		NearestMipmapLinear,
		// Token: 0x040091B3 RID: 37299
		LinearMipmapLinear,
		// Token: 0x040091B4 RID: 37300
		TextureMagFilter = 10240,
		// Token: 0x040091B5 RID: 37301
		TextureMinFilter,
		// Token: 0x040091B6 RID: 37302
		TextureWrapS,
		// Token: 0x040091B7 RID: 37303
		TextureWrapT,
		// Token: 0x040091B8 RID: 37304
		Clamp = 10496,
		// Token: 0x040091B9 RID: 37305
		Repeat,
		// Token: 0x040091BA RID: 37306
		PolygonOffsetUnits = 10752,
		// Token: 0x040091BB RID: 37307
		PolygonOffsetPoint,
		// Token: 0x040091BC RID: 37308
		PolygonOffsetLine,
		// Token: 0x040091BD RID: 37309
		R3G3B2 = 10768,
		// Token: 0x040091BE RID: 37310
		V2f = 10784,
		// Token: 0x040091BF RID: 37311
		V3f,
		// Token: 0x040091C0 RID: 37312
		C4ubV2f,
		// Token: 0x040091C1 RID: 37313
		C4ubV3f,
		// Token: 0x040091C2 RID: 37314
		C3fV3f,
		// Token: 0x040091C3 RID: 37315
		N3fV3f,
		// Token: 0x040091C4 RID: 37316
		C4fN3fV3f,
		// Token: 0x040091C5 RID: 37317
		T2fV3f,
		// Token: 0x040091C6 RID: 37318
		T4fV4f,
		// Token: 0x040091C7 RID: 37319
		T2fC4ubV3f,
		// Token: 0x040091C8 RID: 37320
		T2fC3fV3f,
		// Token: 0x040091C9 RID: 37321
		T2fN3fV3f,
		// Token: 0x040091CA RID: 37322
		T2fC4fN3fV3f,
		// Token: 0x040091CB RID: 37323
		T4fC4fN3fV4f,
		// Token: 0x040091CC RID: 37324
		ClipDistance0 = 12288,
		// Token: 0x040091CD RID: 37325
		ClipPlane0 = 12288,
		// Token: 0x040091CE RID: 37326
		ClipDistance1,
		// Token: 0x040091CF RID: 37327
		ClipPlane1 = 12289,
		// Token: 0x040091D0 RID: 37328
		ClipDistance2,
		// Token: 0x040091D1 RID: 37329
		ClipPlane2 = 12290,
		// Token: 0x040091D2 RID: 37330
		ClipDistance3,
		// Token: 0x040091D3 RID: 37331
		ClipPlane3 = 12291,
		// Token: 0x040091D4 RID: 37332
		ClipDistance4,
		// Token: 0x040091D5 RID: 37333
		ClipPlane4 = 12292,
		// Token: 0x040091D6 RID: 37334
		ClipDistance5,
		// Token: 0x040091D7 RID: 37335
		ClipPlane5 = 12293,
		// Token: 0x040091D8 RID: 37336
		ClipDistance6,
		// Token: 0x040091D9 RID: 37337
		ClipDistance7,
		// Token: 0x040091DA RID: 37338
		Light0 = 16384,
		// Token: 0x040091DB RID: 37339
		MultisampleBufferBit6Qcom = 1073741824,
		// Token: 0x040091DC RID: 37340
		Light1 = 16385,
		// Token: 0x040091DD RID: 37341
		Light2,
		// Token: 0x040091DE RID: 37342
		Light3,
		// Token: 0x040091DF RID: 37343
		Light4,
		// Token: 0x040091E0 RID: 37344
		Light5,
		// Token: 0x040091E1 RID: 37345
		Light6,
		// Token: 0x040091E2 RID: 37346
		Light7,
		// Token: 0x040091E3 RID: 37347
		AbgrExt = 32768,
		// Token: 0x040091E4 RID: 37348
		MultisampleBufferBit7Qcom = -2147483648,
		// Token: 0x040091E5 RID: 37349
		ConstantColor = 32769,
		// Token: 0x040091E6 RID: 37350
		ConstantColorExt = 32769,
		// Token: 0x040091E7 RID: 37351
		OneMinusConstantColor,
		// Token: 0x040091E8 RID: 37352
		OneMinusConstantColorExt = 32770,
		// Token: 0x040091E9 RID: 37353
		ConstantAlpha,
		// Token: 0x040091EA RID: 37354
		ConstantAlphaExt = 32771,
		// Token: 0x040091EB RID: 37355
		OneMinusConstantAlpha,
		// Token: 0x040091EC RID: 37356
		OneMinusConstantAlphaExt = 32772,
		// Token: 0x040091ED RID: 37357
		BlendColor,
		// Token: 0x040091EE RID: 37358
		BlendColorExt = 32773,
		// Token: 0x040091EF RID: 37359
		FuncAdd,
		// Token: 0x040091F0 RID: 37360
		FuncAddExt = 32774,
		// Token: 0x040091F1 RID: 37361
		Min,
		// Token: 0x040091F2 RID: 37362
		MinExt = 32775,
		// Token: 0x040091F3 RID: 37363
		Max,
		// Token: 0x040091F4 RID: 37364
		MaxExt = 32776,
		// Token: 0x040091F5 RID: 37365
		BlendEquation,
		// Token: 0x040091F6 RID: 37366
		BlendEquationExt = 32777,
		// Token: 0x040091F7 RID: 37367
		BlendEquationRgb = 32777,
		// Token: 0x040091F8 RID: 37368
		FuncSubtract,
		// Token: 0x040091F9 RID: 37369
		FuncSubtractExt = 32778,
		// Token: 0x040091FA RID: 37370
		FuncReverseSubtract,
		// Token: 0x040091FB RID: 37371
		FuncReverseSubtractExt = 32779,
		// Token: 0x040091FC RID: 37372
		CmykExt,
		// Token: 0x040091FD RID: 37373
		CmykaExt,
		// Token: 0x040091FE RID: 37374
		PackCmykHintExt,
		// Token: 0x040091FF RID: 37375
		UnpackCmykHintExt,
		// Token: 0x04009200 RID: 37376
		Convolution1D,
		// Token: 0x04009201 RID: 37377
		Convolution1DExt = 32784,
		// Token: 0x04009202 RID: 37378
		Convolution2D,
		// Token: 0x04009203 RID: 37379
		Convolution2DExt = 32785,
		// Token: 0x04009204 RID: 37380
		Separable2D,
		// Token: 0x04009205 RID: 37381
		Separable2DExt = 32786,
		// Token: 0x04009206 RID: 37382
		ConvolutionBorderMode,
		// Token: 0x04009207 RID: 37383
		ConvolutionBorderModeExt = 32787,
		// Token: 0x04009208 RID: 37384
		ConvolutionFilterScale,
		// Token: 0x04009209 RID: 37385
		ConvolutionFilterScaleExt = 32788,
		// Token: 0x0400920A RID: 37386
		ConvolutionFilterBias,
		// Token: 0x0400920B RID: 37387
		ConvolutionFilterBiasExt = 32789,
		// Token: 0x0400920C RID: 37388
		Reduce,
		// Token: 0x0400920D RID: 37389
		ReduceExt = 32790,
		// Token: 0x0400920E RID: 37390
		ConvolutionFormatExt,
		// Token: 0x0400920F RID: 37391
		ConvolutionWidthExt,
		// Token: 0x04009210 RID: 37392
		ConvolutionHeightExt,
		// Token: 0x04009211 RID: 37393
		MaxConvolutionWidthExt,
		// Token: 0x04009212 RID: 37394
		MaxConvolutionHeightExt,
		// Token: 0x04009213 RID: 37395
		PostConvolutionRedScale,
		// Token: 0x04009214 RID: 37396
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x04009215 RID: 37397
		PostConvolutionGreenScale,
		// Token: 0x04009216 RID: 37398
		PostConvolutionGreenScaleExt = 32797,
		// Token: 0x04009217 RID: 37399
		PostConvolutionBlueScale,
		// Token: 0x04009218 RID: 37400
		PostConvolutionBlueScaleExt = 32798,
		// Token: 0x04009219 RID: 37401
		PostConvolutionAlphaScale,
		// Token: 0x0400921A RID: 37402
		PostConvolutionAlphaScaleExt = 32799,
		// Token: 0x0400921B RID: 37403
		PostConvolutionRedBias,
		// Token: 0x0400921C RID: 37404
		PostConvolutionRedBiasExt = 32800,
		// Token: 0x0400921D RID: 37405
		PostConvolutionGreenBias,
		// Token: 0x0400921E RID: 37406
		PostConvolutionGreenBiasExt = 32801,
		// Token: 0x0400921F RID: 37407
		PostConvolutionBlueBias,
		// Token: 0x04009220 RID: 37408
		PostConvolutionBlueBiasExt = 32802,
		// Token: 0x04009221 RID: 37409
		PostConvolutionAlphaBias,
		// Token: 0x04009222 RID: 37410
		PostConvolutionAlphaBiasExt = 32803,
		// Token: 0x04009223 RID: 37411
		Histogram,
		// Token: 0x04009224 RID: 37412
		HistogramExt = 32804,
		// Token: 0x04009225 RID: 37413
		ProxyHistogram,
		// Token: 0x04009226 RID: 37414
		ProxyHistogramExt = 32805,
		// Token: 0x04009227 RID: 37415
		HistogramWidthExt,
		// Token: 0x04009228 RID: 37416
		HistogramFormatExt,
		// Token: 0x04009229 RID: 37417
		HistogramRedSizeExt,
		// Token: 0x0400922A RID: 37418
		HistogramGreenSizeExt,
		// Token: 0x0400922B RID: 37419
		HistogramBlueSizeExt,
		// Token: 0x0400922C RID: 37420
		HistogramAlphaSizeExt,
		// Token: 0x0400922D RID: 37421
		HistogramLuminanceSizeExt,
		// Token: 0x0400922E RID: 37422
		HistogramSinkExt,
		// Token: 0x0400922F RID: 37423
		Minmax,
		// Token: 0x04009230 RID: 37424
		MinmaxExt = 32814,
		// Token: 0x04009231 RID: 37425
		MinmaxFormat,
		// Token: 0x04009232 RID: 37426
		MinmaxFormatExt = 32815,
		// Token: 0x04009233 RID: 37427
		MinmaxSink,
		// Token: 0x04009234 RID: 37428
		MinmaxSinkExt = 32816,
		// Token: 0x04009235 RID: 37429
		TableTooLarge,
		// Token: 0x04009236 RID: 37430
		TableTooLargeExt = 32817,
		// Token: 0x04009237 RID: 37431
		UnsignedByte332,
		// Token: 0x04009238 RID: 37432
		UnsignedByte332Ext = 32818,
		// Token: 0x04009239 RID: 37433
		UnsignedShort4444,
		// Token: 0x0400923A RID: 37434
		UnsignedShort4444Ext = 32819,
		// Token: 0x0400923B RID: 37435
		UnsignedShort5551,
		// Token: 0x0400923C RID: 37436
		UnsignedShort5551Ext = 32820,
		// Token: 0x0400923D RID: 37437
		UnsignedInt8888,
		// Token: 0x0400923E RID: 37438
		UnsignedInt8888Ext = 32821,
		// Token: 0x0400923F RID: 37439
		UnsignedInt1010102,
		// Token: 0x04009240 RID: 37440
		UnsignedInt1010102Ext = 32822,
		// Token: 0x04009241 RID: 37441
		PolygonOffsetFill,
		// Token: 0x04009242 RID: 37442
		PolygonOffsetFactor,
		// Token: 0x04009243 RID: 37443
		PolygonOffsetBiasExt,
		// Token: 0x04009244 RID: 37444
		RescaleNormalExt,
		// Token: 0x04009245 RID: 37445
		Alpha4,
		// Token: 0x04009246 RID: 37446
		Alpha8,
		// Token: 0x04009247 RID: 37447
		Alpha8Ext = 32828,
		// Token: 0x04009248 RID: 37448
		Alpha8Oes = 32828,
		// Token: 0x04009249 RID: 37449
		Alpha12,
		// Token: 0x0400924A RID: 37450
		Alpha16,
		// Token: 0x0400924B RID: 37451
		Luminance4,
		// Token: 0x0400924C RID: 37452
		Luminance8,
		// Token: 0x0400924D RID: 37453
		Luminance8Ext = 32832,
		// Token: 0x0400924E RID: 37454
		Luminance8Oes = 32832,
		// Token: 0x0400924F RID: 37455
		Luminance12,
		// Token: 0x04009250 RID: 37456
		Luminance16,
		// Token: 0x04009251 RID: 37457
		Luminance4Alpha4,
		// Token: 0x04009252 RID: 37458
		Luminance4Alpha4Oes = 32835,
		// Token: 0x04009253 RID: 37459
		Luminance6Alpha2,
		// Token: 0x04009254 RID: 37460
		Luminance8Alpha8,
		// Token: 0x04009255 RID: 37461
		Luminance8Alpha8Ext = 32837,
		// Token: 0x04009256 RID: 37462
		Luminance8Alpha8Oes = 32837,
		// Token: 0x04009257 RID: 37463
		Luminance12Alpha4,
		// Token: 0x04009258 RID: 37464
		Luminance12Alpha12,
		// Token: 0x04009259 RID: 37465
		Luminance16Alpha16,
		// Token: 0x0400925A RID: 37466
		Intensity,
		// Token: 0x0400925B RID: 37467
		Intensity4,
		// Token: 0x0400925C RID: 37468
		Intensity8,
		// Token: 0x0400925D RID: 37469
		Intensity12,
		// Token: 0x0400925E RID: 37470
		Intensity16,
		// Token: 0x0400925F RID: 37471
		Rgb2Ext,
		// Token: 0x04009260 RID: 37472
		Rgb4,
		// Token: 0x04009261 RID: 37473
		Rgb5,
		// Token: 0x04009262 RID: 37474
		Rgb8,
		// Token: 0x04009263 RID: 37475
		Rgb8Oes = 32849,
		// Token: 0x04009264 RID: 37476
		Rgb10,
		// Token: 0x04009265 RID: 37477
		Rgb10Ext = 32850,
		// Token: 0x04009266 RID: 37478
		Rgb12,
		// Token: 0x04009267 RID: 37479
		Rgb16,
		// Token: 0x04009268 RID: 37480
		Rgba2,
		// Token: 0x04009269 RID: 37481
		Rgba4Oes,
		// Token: 0x0400926A RID: 37482
		Rgba4 = 32854,
		// Token: 0x0400926B RID: 37483
		Rgb5A1,
		// Token: 0x0400926C RID: 37484
		Rgb5A1Oes = 32855,
		// Token: 0x0400926D RID: 37485
		Rgba8,
		// Token: 0x0400926E RID: 37486
		Rgba8Oes = 32856,
		// Token: 0x0400926F RID: 37487
		Rgb10A2,
		// Token: 0x04009270 RID: 37488
		Rgb10A2Ext = 32857,
		// Token: 0x04009271 RID: 37489
		Rgba12,
		// Token: 0x04009272 RID: 37490
		Rgba16,
		// Token: 0x04009273 RID: 37491
		TextureRedSize,
		// Token: 0x04009274 RID: 37492
		TextureGreenSize,
		// Token: 0x04009275 RID: 37493
		TextureBlueSize,
		// Token: 0x04009276 RID: 37494
		TextureAlphaSize,
		// Token: 0x04009277 RID: 37495
		TextureLuminanceSize,
		// Token: 0x04009278 RID: 37496
		TextureIntensitySize,
		// Token: 0x04009279 RID: 37497
		ReplaceExt,
		// Token: 0x0400927A RID: 37498
		ProxyTexture1D,
		// Token: 0x0400927B RID: 37499
		ProxyTexture1DExt = 32867,
		// Token: 0x0400927C RID: 37500
		ProxyTexture2D,
		// Token: 0x0400927D RID: 37501
		ProxyTexture2DExt = 32868,
		// Token: 0x0400927E RID: 37502
		TextureTooLargeExt,
		// Token: 0x0400927F RID: 37503
		TexturePriority,
		// Token: 0x04009280 RID: 37504
		TexturePriorityExt = 32870,
		// Token: 0x04009281 RID: 37505
		TextureResident,
		// Token: 0x04009282 RID: 37506
		TextureBinding1D,
		// Token: 0x04009283 RID: 37507
		TextureBinding2D,
		// Token: 0x04009284 RID: 37508
		Texture3DBindingExt,
		// Token: 0x04009285 RID: 37509
		TextureBinding3D = 32874,
		// Token: 0x04009286 RID: 37510
		TextureBinding3DOes = 32874,
		// Token: 0x04009287 RID: 37511
		PackSkipImages,
		// Token: 0x04009288 RID: 37512
		PackSkipImagesExt = 32875,
		// Token: 0x04009289 RID: 37513
		PackImageHeight,
		// Token: 0x0400928A RID: 37514
		PackImageHeightExt = 32876,
		// Token: 0x0400928B RID: 37515
		UnpackSkipImages,
		// Token: 0x0400928C RID: 37516
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400928D RID: 37517
		UnpackImageHeight,
		// Token: 0x0400928E RID: 37518
		UnpackImageHeightExt = 32878,
		// Token: 0x0400928F RID: 37519
		Texture3D,
		// Token: 0x04009290 RID: 37520
		Texture3DExt = 32879,
		// Token: 0x04009291 RID: 37521
		Texture3DOes = 32879,
		// Token: 0x04009292 RID: 37522
		ProxyTexture3D,
		// Token: 0x04009293 RID: 37523
		ProxyTexture3DExt = 32880,
		// Token: 0x04009294 RID: 37524
		TextureDepthExt,
		// Token: 0x04009295 RID: 37525
		TextureWrapR,
		// Token: 0x04009296 RID: 37526
		TextureWrapRExt = 32882,
		// Token: 0x04009297 RID: 37527
		TextureWrapROes = 32882,
		// Token: 0x04009298 RID: 37528
		Max3DTextureSizeExt,
		// Token: 0x04009299 RID: 37529
		Max3DTextureSizeOes = 32883,
		// Token: 0x0400929A RID: 37530
		VertexArray,
		// Token: 0x0400929B RID: 37531
		VertexArrayKhr = 32884,
		// Token: 0x0400929C RID: 37532
		NormalArray,
		// Token: 0x0400929D RID: 37533
		ColorArray,
		// Token: 0x0400929E RID: 37534
		IndexArray,
		// Token: 0x0400929F RID: 37535
		TextureCoordArray,
		// Token: 0x040092A0 RID: 37536
		EdgeFlagArray,
		// Token: 0x040092A1 RID: 37537
		VertexArraySize,
		// Token: 0x040092A2 RID: 37538
		VertexArrayType,
		// Token: 0x040092A3 RID: 37539
		VertexArrayStride,
		// Token: 0x040092A4 RID: 37540
		VertexArrayCountExt,
		// Token: 0x040092A5 RID: 37541
		NormalArrayType,
		// Token: 0x040092A6 RID: 37542
		NormalArrayStride,
		// Token: 0x040092A7 RID: 37543
		NormalArrayCountExt,
		// Token: 0x040092A8 RID: 37544
		ColorArraySize,
		// Token: 0x040092A9 RID: 37545
		ColorArrayType,
		// Token: 0x040092AA RID: 37546
		ColorArrayStride,
		// Token: 0x040092AB RID: 37547
		ColorArrayCountExt,
		// Token: 0x040092AC RID: 37548
		IndexArrayType,
		// Token: 0x040092AD RID: 37549
		IndexArrayStride,
		// Token: 0x040092AE RID: 37550
		IndexArrayCountExt,
		// Token: 0x040092AF RID: 37551
		TextureCoordArraySize,
		// Token: 0x040092B0 RID: 37552
		TextureCoordArrayType,
		// Token: 0x040092B1 RID: 37553
		TextureCoordArrayStride,
		// Token: 0x040092B2 RID: 37554
		TextureCoordArrayCountExt,
		// Token: 0x040092B3 RID: 37555
		EdgeFlagArrayStride,
		// Token: 0x040092B4 RID: 37556
		EdgeFlagArrayCountExt,
		// Token: 0x040092B5 RID: 37557
		VertexArrayPointer,
		// Token: 0x040092B6 RID: 37558
		VertexArrayPointerExt = 32910,
		// Token: 0x040092B7 RID: 37559
		NormalArrayPointer,
		// Token: 0x040092B8 RID: 37560
		NormalArrayPointerExt = 32911,
		// Token: 0x040092B9 RID: 37561
		ColorArrayPointer,
		// Token: 0x040092BA RID: 37562
		ColorArrayPointerExt = 32912,
		// Token: 0x040092BB RID: 37563
		IndexArrayPointer,
		// Token: 0x040092BC RID: 37564
		IndexArrayPointerExt = 32913,
		// Token: 0x040092BD RID: 37565
		TextureCoordArrayPointer,
		// Token: 0x040092BE RID: 37566
		TextureCoordArrayPointerExt = 32914,
		// Token: 0x040092BF RID: 37567
		EdgeFlagArrayPointer,
		// Token: 0x040092C0 RID: 37568
		EdgeFlagArrayPointerExt = 32915,
		// Token: 0x040092C1 RID: 37569
		InterlaceSgix,
		// Token: 0x040092C2 RID: 37570
		DetailTexture2DSgis,
		// Token: 0x040092C3 RID: 37571
		DetailTexture2DBindingSgis,
		// Token: 0x040092C4 RID: 37572
		LinearDetailSgis,
		// Token: 0x040092C5 RID: 37573
		LinearDetailAlphaSgis,
		// Token: 0x040092C6 RID: 37574
		LinearDetailColorSgis,
		// Token: 0x040092C7 RID: 37575
		DetailTextureLevelSgis,
		// Token: 0x040092C8 RID: 37576
		DetailTextureModeSgis,
		// Token: 0x040092C9 RID: 37577
		DetailTextureFuncPointsSgis,
		// Token: 0x040092CA RID: 37578
		MultisampleSgis,
		// Token: 0x040092CB RID: 37579
		SampleAlphaToCoverage,
		// Token: 0x040092CC RID: 37580
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x040092CD RID: 37581
		SampleAlphaToOneSgis,
		// Token: 0x040092CE RID: 37582
		SampleCoverage,
		// Token: 0x040092CF RID: 37583
		SampleMaskSgis = 32928,
		// Token: 0x040092D0 RID: 37584
		Gl1PassExt,
		// Token: 0x040092D1 RID: 37585
		Gl1PassSgis = 32929,
		// Token: 0x040092D2 RID: 37586
		Gl2Pass0Ext,
		// Token: 0x040092D3 RID: 37587
		Gl2Pass0Sgis = 32930,
		// Token: 0x040092D4 RID: 37588
		Gl2Pass1Ext,
		// Token: 0x040092D5 RID: 37589
		Gl2Pass1Sgis = 32931,
		// Token: 0x040092D6 RID: 37590
		Gl4Pass0Ext,
		// Token: 0x040092D7 RID: 37591
		Gl4Pass0Sgis = 32932,
		// Token: 0x040092D8 RID: 37592
		Gl4Pass1Ext,
		// Token: 0x040092D9 RID: 37593
		Gl4Pass1Sgis = 32933,
		// Token: 0x040092DA RID: 37594
		Gl4Pass2Ext,
		// Token: 0x040092DB RID: 37595
		Gl4Pass2Sgis = 32934,
		// Token: 0x040092DC RID: 37596
		Gl4Pass3Ext,
		// Token: 0x040092DD RID: 37597
		Gl4Pass3Sgis = 32935,
		// Token: 0x040092DE RID: 37598
		SampleBuffers,
		// Token: 0x040092DF RID: 37599
		SampleBuffersSgis = 32936,
		// Token: 0x040092E0 RID: 37600
		SamplesSgis,
		// Token: 0x040092E1 RID: 37601
		Samples = 32937,
		// Token: 0x040092E2 RID: 37602
		SampleCoverageValue,
		// Token: 0x040092E3 RID: 37603
		SampleMaskValueSgis = 32938,
		// Token: 0x040092E4 RID: 37604
		SampleCoverageInvert,
		// Token: 0x040092E5 RID: 37605
		SampleMaskInvertSgis = 32939,
		// Token: 0x040092E6 RID: 37606
		SamplePatternSgis,
		// Token: 0x040092E7 RID: 37607
		LinearSharpenSgis,
		// Token: 0x040092E8 RID: 37608
		LinearSharpenAlphaSgis,
		// Token: 0x040092E9 RID: 37609
		LinearSharpenColorSgis,
		// Token: 0x040092EA RID: 37610
		SharpenTextureFuncPointsSgis,
		// Token: 0x040092EB RID: 37611
		ColorMatrixSgi,
		// Token: 0x040092EC RID: 37612
		ColorMatrixStackDepthSgi,
		// Token: 0x040092ED RID: 37613
		MaxColorMatrixStackDepthSgi,
		// Token: 0x040092EE RID: 37614
		PostColorMatrixRedScale,
		// Token: 0x040092EF RID: 37615
		PostColorMatrixRedScaleSgi = 32948,
		// Token: 0x040092F0 RID: 37616
		PostColorMatrixGreenScale,
		// Token: 0x040092F1 RID: 37617
		PostColorMatrixGreenScaleSgi = 32949,
		// Token: 0x040092F2 RID: 37618
		PostColorMatrixBlueScale,
		// Token: 0x040092F3 RID: 37619
		PostColorMatrixBlueScaleSgi = 32950,
		// Token: 0x040092F4 RID: 37620
		PostColorMatrixAlphaScale,
		// Token: 0x040092F5 RID: 37621
		PostColorMatrixAlphaScaleSgi = 32951,
		// Token: 0x040092F6 RID: 37622
		PostColorMatrixRedBias,
		// Token: 0x040092F7 RID: 37623
		PostColorMatrixRedBiasSgi = 32952,
		// Token: 0x040092F8 RID: 37624
		PostColorMatrixGreenBias,
		// Token: 0x040092F9 RID: 37625
		PostColorMatrixGreenBiasSgi = 32953,
		// Token: 0x040092FA RID: 37626
		PostColorMatrixBlueBias,
		// Token: 0x040092FB RID: 37627
		PostColorMatrixBlueBiasSgi = 32954,
		// Token: 0x040092FC RID: 37628
		PostColorMatrixAlphaBias,
		// Token: 0x040092FD RID: 37629
		PostColorMatrixAlphaBiasSgi = 32955,
		// Token: 0x040092FE RID: 37630
		TextureColorTableSgi,
		// Token: 0x040092FF RID: 37631
		ProxyTextureColorTableSgi,
		// Token: 0x04009300 RID: 37632
		TextureEnvBiasSgix,
		// Token: 0x04009301 RID: 37633
		ShadowAmbientSgix,
		// Token: 0x04009302 RID: 37634
		BlendDstRgb = 32968,
		// Token: 0x04009303 RID: 37635
		BlendSrcRgb,
		// Token: 0x04009304 RID: 37636
		BlendDstAlpha,
		// Token: 0x04009305 RID: 37637
		BlendSrcAlpha,
		// Token: 0x04009306 RID: 37638
		ColorTable = 32976,
		// Token: 0x04009307 RID: 37639
		ColorTableSgi = 32976,
		// Token: 0x04009308 RID: 37640
		PostConvolutionColorTable,
		// Token: 0x04009309 RID: 37641
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x0400930A RID: 37642
		PostColorMatrixColorTable,
		// Token: 0x0400930B RID: 37643
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x0400930C RID: 37644
		ProxyColorTable,
		// Token: 0x0400930D RID: 37645
		ProxyColorTableSgi = 32979,
		// Token: 0x0400930E RID: 37646
		ProxyPostConvolutionColorTable,
		// Token: 0x0400930F RID: 37647
		ProxyPostConvolutionColorTableSgi = 32980,
		// Token: 0x04009310 RID: 37648
		ProxyPostColorMatrixColorTable,
		// Token: 0x04009311 RID: 37649
		ProxyPostColorMatrixColorTableSgi = 32981,
		// Token: 0x04009312 RID: 37650
		ColorTableScale,
		// Token: 0x04009313 RID: 37651
		ColorTableScaleSgi = 32982,
		// Token: 0x04009314 RID: 37652
		ColorTableBias,
		// Token: 0x04009315 RID: 37653
		ColorTableBiasSgi = 32983,
		// Token: 0x04009316 RID: 37654
		ColorTableFormatSgi,
		// Token: 0x04009317 RID: 37655
		ColorTableWidthSgi,
		// Token: 0x04009318 RID: 37656
		ColorTableRedSizeSgi,
		// Token: 0x04009319 RID: 37657
		ColorTableGreenSizeSgi,
		// Token: 0x0400931A RID: 37658
		ColorTableBlueSizeSgi,
		// Token: 0x0400931B RID: 37659
		ColorTableAlphaSizeSgi,
		// Token: 0x0400931C RID: 37660
		ColorTableLuminanceSizeSgi,
		// Token: 0x0400931D RID: 37661
		ColorTableIntensitySizeSgi,
		// Token: 0x0400931E RID: 37662
		BgraExt = 32993,
		// Token: 0x0400931F RID: 37663
		BgraImg = 32993,
		// Token: 0x04009320 RID: 37664
		PhongHintWin = 33003,
		// Token: 0x04009321 RID: 37665
		ClipVolumeClippingHintExt = 33008,
		// Token: 0x04009322 RID: 37666
		DualAlpha4Sgis = 33040,
		// Token: 0x04009323 RID: 37667
		DualAlpha8Sgis,
		// Token: 0x04009324 RID: 37668
		DualAlpha12Sgis,
		// Token: 0x04009325 RID: 37669
		DualAlpha16Sgis,
		// Token: 0x04009326 RID: 37670
		DualLuminance4Sgis,
		// Token: 0x04009327 RID: 37671
		DualLuminance8Sgis,
		// Token: 0x04009328 RID: 37672
		DualLuminance12Sgis,
		// Token: 0x04009329 RID: 37673
		DualLuminance16Sgis,
		// Token: 0x0400932A RID: 37674
		DualIntensity4Sgis,
		// Token: 0x0400932B RID: 37675
		DualIntensity8Sgis,
		// Token: 0x0400932C RID: 37676
		DualIntensity12Sgis,
		// Token: 0x0400932D RID: 37677
		DualIntensity16Sgis,
		// Token: 0x0400932E RID: 37678
		DualLuminanceAlpha4Sgis,
		// Token: 0x0400932F RID: 37679
		DualLuminanceAlpha8Sgis,
		// Token: 0x04009330 RID: 37680
		QuadAlpha4Sgis,
		// Token: 0x04009331 RID: 37681
		QuadAlpha8Sgis,
		// Token: 0x04009332 RID: 37682
		QuadLuminance4Sgis,
		// Token: 0x04009333 RID: 37683
		QuadLuminance8Sgis,
		// Token: 0x04009334 RID: 37684
		QuadIntensity4Sgis,
		// Token: 0x04009335 RID: 37685
		QuadIntensity8Sgis,
		// Token: 0x04009336 RID: 37686
		DualTextureSelectSgis,
		// Token: 0x04009337 RID: 37687
		QuadTextureSelectSgis,
		// Token: 0x04009338 RID: 37688
		PointSizeMin,
		// Token: 0x04009339 RID: 37689
		PointSizeMinArb = 33062,
		// Token: 0x0400933A RID: 37690
		PointSizeMinExt = 33062,
		// Token: 0x0400933B RID: 37691
		PointSizeMinSgis = 33062,
		// Token: 0x0400933C RID: 37692
		PointSizeMax,
		// Token: 0x0400933D RID: 37693
		PointSizeMaxArb = 33063,
		// Token: 0x0400933E RID: 37694
		PointSizeMaxExt = 33063,
		// Token: 0x0400933F RID: 37695
		PointSizeMaxSgis = 33063,
		// Token: 0x04009340 RID: 37696
		PointFadeThresholdSize,
		// Token: 0x04009341 RID: 37697
		PointFadeThresholdSizeArb = 33064,
		// Token: 0x04009342 RID: 37698
		PointFadeThresholdSizeExt = 33064,
		// Token: 0x04009343 RID: 37699
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x04009344 RID: 37700
		DistanceAttenuationExt,
		// Token: 0x04009345 RID: 37701
		DistanceAttenuationSgis = 33065,
		// Token: 0x04009346 RID: 37702
		PointDistanceAttenuation = 33065,
		// Token: 0x04009347 RID: 37703
		PointDistanceAttenuationArb = 33065,
		// Token: 0x04009348 RID: 37704
		FogFuncSgis,
		// Token: 0x04009349 RID: 37705
		FogFuncPointsSgis,
		// Token: 0x0400934A RID: 37706
		MaxFogFuncPointsSgis,
		// Token: 0x0400934B RID: 37707
		ClampToBorder,
		// Token: 0x0400934C RID: 37708
		ClampToBorderArb = 33069,
		// Token: 0x0400934D RID: 37709
		ClampToBorderExt = 33069,
		// Token: 0x0400934E RID: 37710
		ClampToBorderNv = 33069,
		// Token: 0x0400934F RID: 37711
		ClampToBorderSgis = 33069,
		// Token: 0x04009350 RID: 37712
		TextureMultiBufferHintSgix,
		// Token: 0x04009351 RID: 37713
		ClampToEdge,
		// Token: 0x04009352 RID: 37714
		ClampToEdgeSgis = 33071,
		// Token: 0x04009353 RID: 37715
		PackSkipVolumesSgis,
		// Token: 0x04009354 RID: 37716
		PackImageDepthSgis,
		// Token: 0x04009355 RID: 37717
		UnpackSkipVolumesSgis,
		// Token: 0x04009356 RID: 37718
		UnpackImageDepthSgis,
		// Token: 0x04009357 RID: 37719
		Texture4DSgis,
		// Token: 0x04009358 RID: 37720
		ProxyTexture4DSgis,
		// Token: 0x04009359 RID: 37721
		Texture4DsizeSgis,
		// Token: 0x0400935A RID: 37722
		TextureWrapQSgis,
		// Token: 0x0400935B RID: 37723
		Max4DTextureSizeSgis,
		// Token: 0x0400935C RID: 37724
		PixelTexGenSgix,
		// Token: 0x0400935D RID: 37725
		TextureMinLod,
		// Token: 0x0400935E RID: 37726
		TextureMinLodSgis = 33082,
		// Token: 0x0400935F RID: 37727
		TextureMaxLod,
		// Token: 0x04009360 RID: 37728
		TextureMaxLodSgis = 33083,
		// Token: 0x04009361 RID: 37729
		TextureBaseLevel,
		// Token: 0x04009362 RID: 37730
		TextureBaseLevelSgis = 33084,
		// Token: 0x04009363 RID: 37731
		TextureMaxLevel,
		// Token: 0x04009364 RID: 37732
		TextureMaxLevelApple = 33085,
		// Token: 0x04009365 RID: 37733
		TextureMaxLevelSgis = 33085,
		// Token: 0x04009366 RID: 37734
		PixelTileBestAlignmentSgix,
		// Token: 0x04009367 RID: 37735
		PixelTileCacheIncrementSgix,
		// Token: 0x04009368 RID: 37736
		PixelTileWidthSgix,
		// Token: 0x04009369 RID: 37737
		PixelTileHeightSgix,
		// Token: 0x0400936A RID: 37738
		PixelTileGridWidthSgix,
		// Token: 0x0400936B RID: 37739
		PixelTileGridHeightSgix,
		// Token: 0x0400936C RID: 37740
		PixelTileGridDepthSgix,
		// Token: 0x0400936D RID: 37741
		PixelTileCacheSizeSgix,
		// Token: 0x0400936E RID: 37742
		Filter4Sgis,
		// Token: 0x0400936F RID: 37743
		TextureFilter4SizeSgis,
		// Token: 0x04009370 RID: 37744
		SpriteSgix,
		// Token: 0x04009371 RID: 37745
		SpriteModeSgix,
		// Token: 0x04009372 RID: 37746
		SpriteAxisSgix,
		// Token: 0x04009373 RID: 37747
		SpriteTranslationSgix,
		// Token: 0x04009374 RID: 37748
		Texture4DBindingSgis = 33103,
		// Token: 0x04009375 RID: 37749
		LinearClipmapLinearSgix = 33136,
		// Token: 0x04009376 RID: 37750
		TextureClipmapCenterSgix,
		// Token: 0x04009377 RID: 37751
		TextureClipmapFrameSgix,
		// Token: 0x04009378 RID: 37752
		TextureClipmapOffsetSgix,
		// Token: 0x04009379 RID: 37753
		TextureClipmapVirtualDepthSgix,
		// Token: 0x0400937A RID: 37754
		TextureClipmapLodOffsetSgix,
		// Token: 0x0400937B RID: 37755
		TextureClipmapDepthSgix,
		// Token: 0x0400937C RID: 37756
		MaxClipmapDepthSgix,
		// Token: 0x0400937D RID: 37757
		MaxClipmapVirtualDepthSgix,
		// Token: 0x0400937E RID: 37758
		PostTextureFilterBiasSgix,
		// Token: 0x0400937F RID: 37759
		PostTextureFilterScaleSgix,
		// Token: 0x04009380 RID: 37760
		PostTextureFilterBiasRangeSgix,
		// Token: 0x04009381 RID: 37761
		PostTextureFilterScaleRangeSgix,
		// Token: 0x04009382 RID: 37762
		ReferencePlaneSgix,
		// Token: 0x04009383 RID: 37763
		ReferencePlaneEquationSgix,
		// Token: 0x04009384 RID: 37764
		IrInstrument1Sgix,
		// Token: 0x04009385 RID: 37765
		InstrumentBufferPointerSgix,
		// Token: 0x04009386 RID: 37766
		InstrumentMeasurementsSgix,
		// Token: 0x04009387 RID: 37767
		ListPrioritySgix,
		// Token: 0x04009388 RID: 37768
		CalligraphicFragmentSgix,
		// Token: 0x04009389 RID: 37769
		PixelTexGenQCeilingSgix,
		// Token: 0x0400938A RID: 37770
		PixelTexGenQRoundSgix,
		// Token: 0x0400938B RID: 37771
		PixelTexGenQFloorSgix,
		// Token: 0x0400938C RID: 37772
		PixelTexGenAlphaReplaceSgix,
		// Token: 0x0400938D RID: 37773
		PixelTexGenAlphaNoReplaceSgix,
		// Token: 0x0400938E RID: 37774
		PixelTexGenAlphaLsSgix,
		// Token: 0x0400938F RID: 37775
		PixelTexGenAlphaMsSgix,
		// Token: 0x04009390 RID: 37776
		FramezoomSgix,
		// Token: 0x04009391 RID: 37777
		FramezoomFactorSgix,
		// Token: 0x04009392 RID: 37778
		MaxFramezoomFactorSgix,
		// Token: 0x04009393 RID: 37779
		TextureLodBiasSSgix,
		// Token: 0x04009394 RID: 37780
		TextureLodBiasTSgix,
		// Token: 0x04009395 RID: 37781
		TextureLodBiasRSgix,
		// Token: 0x04009396 RID: 37782
		GenerateMipmap,
		// Token: 0x04009397 RID: 37783
		GenerateMipmapSgis = 33169,
		// Token: 0x04009398 RID: 37784
		GenerateMipmapHint,
		// Token: 0x04009399 RID: 37785
		GenerateMipmapHintSgis = 33170,
		// Token: 0x0400939A RID: 37786
		GeometryDeformationSgix = 33172,
		// Token: 0x0400939B RID: 37787
		TextureDeformationSgix,
		// Token: 0x0400939C RID: 37788
		DeformationsMaskSgix,
		// Token: 0x0400939D RID: 37789
		FogOffsetSgix = 33176,
		// Token: 0x0400939E RID: 37790
		FogOffsetValueSgix,
		// Token: 0x0400939F RID: 37791
		TextureCompareSgix,
		// Token: 0x040093A0 RID: 37792
		TextureCompareOperatorSgix,
		// Token: 0x040093A1 RID: 37793
		TextureLequalRSgix,
		// Token: 0x040093A2 RID: 37794
		TextureGequalRSgix,
		// Token: 0x040093A3 RID: 37795
		DepthComponent16 = 33189,
		// Token: 0x040093A4 RID: 37796
		DepthComponent16Oes = 33189,
		// Token: 0x040093A5 RID: 37797
		DepthComponent16Sgix = 33189,
		// Token: 0x040093A6 RID: 37798
		DepthComponent24Oes,
		// Token: 0x040093A7 RID: 37799
		DepthComponent24Sgix = 33190,
		// Token: 0x040093A8 RID: 37800
		DepthComponent32Oes,
		// Token: 0x040093A9 RID: 37801
		DepthComponent32Sgix = 33191,
		// Token: 0x040093AA RID: 37802
		Ycrcb422Sgix = 33211,
		// Token: 0x040093AB RID: 37803
		Ycrcb444Sgix,
		// Token: 0x040093AC RID: 37804
		EyeDistanceToPointSgis = 33264,
		// Token: 0x040093AD RID: 37805
		ObjectDistanceToPointSgis,
		// Token: 0x040093AE RID: 37806
		EyeDistanceToLineSgis,
		// Token: 0x040093AF RID: 37807
		ObjectDistanceToLineSgis,
		// Token: 0x040093B0 RID: 37808
		EyePointSgis,
		// Token: 0x040093B1 RID: 37809
		ObjectPointSgis,
		// Token: 0x040093B2 RID: 37810
		EyeLineSgis,
		// Token: 0x040093B3 RID: 37811
		ObjectLineSgis,
		// Token: 0x040093B4 RID: 37812
		LightModelColorControl,
		// Token: 0x040093B5 RID: 37813
		LightModelColorControlExt = 33272,
		// Token: 0x040093B6 RID: 37814
		SingleColor,
		// Token: 0x040093B7 RID: 37815
		SingleColorExt = 33273,
		// Token: 0x040093B8 RID: 37816
		SeparateSpecularColor,
		// Token: 0x040093B9 RID: 37817
		SeparateSpecularColorExt = 33274,
		// Token: 0x040093BA RID: 37818
		SharedTexturePaletteExt,
		// Token: 0x040093BB RID: 37819
		FramebufferAttachmentColorEncodingExt = 33296,
		// Token: 0x040093BC RID: 37820
		FramebufferAttachmentComponentTypeExt,
		// Token: 0x040093BD RID: 37821
		FramebufferUndefinedOes = 33305,
		// Token: 0x040093BE RID: 37822
		PrimitiveRestartForPatchesSupported = 33313,
		// Token: 0x040093BF RID: 37823
		RgExt = 33319,
		// Token: 0x040093C0 RID: 37824
		R8Ext = 33321,
		// Token: 0x040093C1 RID: 37825
		Rg8Ext = 33323,
		// Token: 0x040093C2 RID: 37826
		R16fExt = 33325,
		// Token: 0x040093C3 RID: 37827
		R32fExt,
		// Token: 0x040093C4 RID: 37828
		Rg16fExt,
		// Token: 0x040093C5 RID: 37829
		Rg32fExt,
		// Token: 0x040093C6 RID: 37830
		DebugOutputSynchronous = 33346,
		// Token: 0x040093C7 RID: 37831
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x040093C8 RID: 37832
		DebugNextLoggedMessageLength,
		// Token: 0x040093C9 RID: 37833
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x040093CA RID: 37834
		DebugCallbackFunction,
		// Token: 0x040093CB RID: 37835
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x040093CC RID: 37836
		DebugCallbackUserParam,
		// Token: 0x040093CD RID: 37837
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x040093CE RID: 37838
		DebugSourceApi,
		// Token: 0x040093CF RID: 37839
		DebugSourceApiKhr = 33350,
		// Token: 0x040093D0 RID: 37840
		DebugSourceWindowSystem,
		// Token: 0x040093D1 RID: 37841
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x040093D2 RID: 37842
		DebugSourceShaderCompiler,
		// Token: 0x040093D3 RID: 37843
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x040093D4 RID: 37844
		DebugSourceThirdParty,
		// Token: 0x040093D5 RID: 37845
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x040093D6 RID: 37846
		DebugSourceApplication,
		// Token: 0x040093D7 RID: 37847
		DebugSourceApplicationKhr = 33354,
		// Token: 0x040093D8 RID: 37848
		DebugSourceOther,
		// Token: 0x040093D9 RID: 37849
		DebugSourceOtherKhr = 33355,
		// Token: 0x040093DA RID: 37850
		DebugTypeError,
		// Token: 0x040093DB RID: 37851
		DebugTypeErrorKhr = 33356,
		// Token: 0x040093DC RID: 37852
		DebugTypeDeprecatedBehavior,
		// Token: 0x040093DD RID: 37853
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x040093DE RID: 37854
		DebugTypeUndefinedBehavior,
		// Token: 0x040093DF RID: 37855
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x040093E0 RID: 37856
		DebugTypePortability,
		// Token: 0x040093E1 RID: 37857
		DebugTypePortabilityKhr = 33359,
		// Token: 0x040093E2 RID: 37858
		DebugTypePerformance,
		// Token: 0x040093E3 RID: 37859
		DebugTypePerformanceKhr = 33360,
		// Token: 0x040093E4 RID: 37860
		DebugTypeOther,
		// Token: 0x040093E5 RID: 37861
		DebugTypeOtherKhr = 33361,
		// Token: 0x040093E6 RID: 37862
		LoseContextOnResetExt,
		// Token: 0x040093E7 RID: 37863
		GuiltyContextResetExt,
		// Token: 0x040093E8 RID: 37864
		InnocentContextResetExt,
		// Token: 0x040093E9 RID: 37865
		UnknownContextResetExt,
		// Token: 0x040093EA RID: 37866
		ResetNotificationStrategyExt,
		// Token: 0x040093EB RID: 37867
		ProgramBinaryRetrievableHint,
		// Token: 0x040093EC RID: 37868
		ProgramSeparableExt,
		// Token: 0x040093ED RID: 37869
		ActiveProgramExt,
		// Token: 0x040093EE RID: 37870
		ProgramPipelineBindingExt,
		// Token: 0x040093EF RID: 37871
		LayerProvokingVertexExt = 33374,
		// Token: 0x040093F0 RID: 37872
		UndefinedVertexExt = 33376,
		// Token: 0x040093F1 RID: 37873
		NoResetNotificationExt,
		// Token: 0x040093F2 RID: 37874
		DebugTypeMarker = 33384,
		// Token: 0x040093F3 RID: 37875
		DebugTypeMarkerKhr = 33384,
		// Token: 0x040093F4 RID: 37876
		DebugTypePushGroup,
		// Token: 0x040093F5 RID: 37877
		DebugTypePushGroupKhr = 33385,
		// Token: 0x040093F6 RID: 37878
		DebugTypePopGroup,
		// Token: 0x040093F7 RID: 37879
		DebugTypePopGroupKhr = 33386,
		// Token: 0x040093F8 RID: 37880
		DebugSeverityNotification,
		// Token: 0x040093F9 RID: 37881
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x040093FA RID: 37882
		MaxDebugGroupStackDepth,
		// Token: 0x040093FB RID: 37883
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x040093FC RID: 37884
		DebugGroupStackDepth,
		// Token: 0x040093FD RID: 37885
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x040093FE RID: 37886
		TextureViewMinLevelExt = 33499,
		// Token: 0x040093FF RID: 37887
		TextureViewNumLevelsExt,
		// Token: 0x04009400 RID: 37888
		TextureViewMinLayerExt,
		// Token: 0x04009401 RID: 37889
		TextureViewNumLayersExt,
		// Token: 0x04009402 RID: 37890
		TextureImmutableLevels,
		// Token: 0x04009403 RID: 37891
		Buffer,
		// Token: 0x04009404 RID: 37892
		BufferKhr = 33504,
		// Token: 0x04009405 RID: 37893
		Shader,
		// Token: 0x04009406 RID: 37894
		ShaderKhr = 33505,
		// Token: 0x04009407 RID: 37895
		Program,
		// Token: 0x04009408 RID: 37896
		ProgramKhr = 33506,
		// Token: 0x04009409 RID: 37897
		Query,
		// Token: 0x0400940A RID: 37898
		QueryKhr = 33507,
		// Token: 0x0400940B RID: 37899
		ProgramPipeline,
		// Token: 0x0400940C RID: 37900
		Sampler = 33510,
		// Token: 0x0400940D RID: 37901
		SamplerKhr = 33510,
		// Token: 0x0400940E RID: 37902
		DisplayList,
		// Token: 0x0400940F RID: 37903
		MaxLabelLength,
		// Token: 0x04009410 RID: 37904
		MaxLabelLengthKhr = 33512,
		// Token: 0x04009411 RID: 37905
		ConvolutionHintSgix = 33558,
		// Token: 0x04009412 RID: 37906
		AlphaMinSgix = 33568,
		// Token: 0x04009413 RID: 37907
		AlphaMaxSgix,
		// Token: 0x04009414 RID: 37908
		ScalebiasHintSgix,
		// Token: 0x04009415 RID: 37909
		AsyncMarkerSgix = 33577,
		// Token: 0x04009416 RID: 37910
		PixelTexGenModeSgix = 33579,
		// Token: 0x04009417 RID: 37911
		AsyncHistogramSgix,
		// Token: 0x04009418 RID: 37912
		MaxAsyncHistogramSgix,
		// Token: 0x04009419 RID: 37913
		PixelTextureSgis = 33619,
		// Token: 0x0400941A RID: 37914
		PixelFragmentRgbSourceSgis,
		// Token: 0x0400941B RID: 37915
		PixelFragmentAlphaSourceSgis,
		// Token: 0x0400941C RID: 37916
		LineQualityHintSgix = 33627,
		// Token: 0x0400941D RID: 37917
		AsyncTexImageSgix,
		// Token: 0x0400941E RID: 37918
		AsyncDrawPixelsSgix,
		// Token: 0x0400941F RID: 37919
		AsyncReadPixelsSgix,
		// Token: 0x04009420 RID: 37920
		MaxAsyncTexImageSgix,
		// Token: 0x04009421 RID: 37921
		MaxAsyncDrawPixelsSgix,
		// Token: 0x04009422 RID: 37922
		MaxAsyncReadPixelsSgix,
		// Token: 0x04009423 RID: 37923
		UnsignedShort565 = 33635,
		// Token: 0x04009424 RID: 37924
		UnsignedShort4444RevExt = 33637,
		// Token: 0x04009425 RID: 37925
		UnsignedShort4444RevImg = 33637,
		// Token: 0x04009426 RID: 37926
		UnsignedShort1555RevExt,
		// Token: 0x04009427 RID: 37927
		UnsignedInt2101010RevExt = 33640,
		// Token: 0x04009428 RID: 37928
		TextureMaxClampSSgix,
		// Token: 0x04009429 RID: 37929
		TextureMaxClampTSgix,
		// Token: 0x0400942A RID: 37930
		TextureMaxClampRSgix,
		// Token: 0x0400942B RID: 37931
		MirroredRepeat = 33648,
		// Token: 0x0400942C RID: 37932
		VertexPreclipSgix = 33774,
		// Token: 0x0400942D RID: 37933
		VertexPreclipHintSgix,
		// Token: 0x0400942E RID: 37934
		CompressedRgbS3tcDxt1Ext,
		// Token: 0x0400942F RID: 37935
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x04009430 RID: 37936
		CompressedRgbaS3tcDxt3Angle,
		// Token: 0x04009431 RID: 37937
		CompressedRgbaS3tcDxt3Ext = 33778,
		// Token: 0x04009432 RID: 37938
		CompressedRgbaS3tcDxt5Angle,
		// Token: 0x04009433 RID: 37939
		CompressedRgbaS3tcDxt5Ext = 33779,
		// Token: 0x04009434 RID: 37940
		PerfqueryDonotFlushIntel = 33785,
		// Token: 0x04009435 RID: 37941
		PerfqueryFlushIntel,
		// Token: 0x04009436 RID: 37942
		PerfqueryWaitIntel,
		// Token: 0x04009437 RID: 37943
		FragmentLightingSgix = 33792,
		// Token: 0x04009438 RID: 37944
		FragmentColorMaterialSgix,
		// Token: 0x04009439 RID: 37945
		FragmentColorMaterialFaceSgix,
		// Token: 0x0400943A RID: 37946
		FragmentColorMaterialParameterSgix,
		// Token: 0x0400943B RID: 37947
		MaxFragmentLightsSgix,
		// Token: 0x0400943C RID: 37948
		MaxActiveLightsSgix,
		// Token: 0x0400943D RID: 37949
		LightEnvModeSgix = 33799,
		// Token: 0x0400943E RID: 37950
		FragmentLightModelLocalViewerSgix,
		// Token: 0x0400943F RID: 37951
		FragmentLightModelTwoSideSgix,
		// Token: 0x04009440 RID: 37952
		FragmentLightModelAmbientSgix,
		// Token: 0x04009441 RID: 37953
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x04009442 RID: 37954
		FragmentLight0Sgix,
		// Token: 0x04009443 RID: 37955
		FragmentLight1Sgix,
		// Token: 0x04009444 RID: 37956
		FragmentLight2Sgix,
		// Token: 0x04009445 RID: 37957
		FragmentLight3Sgix,
		// Token: 0x04009446 RID: 37958
		FragmentLight4Sgix,
		// Token: 0x04009447 RID: 37959
		FragmentLight5Sgix,
		// Token: 0x04009448 RID: 37960
		FragmentLight6Sgix,
		// Token: 0x04009449 RID: 37961
		FragmentLight7Sgix,
		// Token: 0x0400944A RID: 37962
		PackResampleSgix = 33836,
		// Token: 0x0400944B RID: 37963
		UnpackResampleSgix,
		// Token: 0x0400944C RID: 37964
		ResampleReplicateSgix,
		// Token: 0x0400944D RID: 37965
		ResampleZeroFillSgix,
		// Token: 0x0400944E RID: 37966
		ResampleDecimateSgix,
		// Token: 0x0400944F RID: 37967
		NearestClipmapNearestSgix = 33869,
		// Token: 0x04009450 RID: 37968
		NearestClipmapLinearSgix,
		// Token: 0x04009451 RID: 37969
		LinearClipmapNearestSgix,
		// Token: 0x04009452 RID: 37970
		AliasedPointSizeRange = 33901,
		// Token: 0x04009453 RID: 37971
		AliasedLineWidthRange,
		// Token: 0x04009454 RID: 37972
		Texture0 = 33984,
		// Token: 0x04009455 RID: 37973
		Texture1,
		// Token: 0x04009456 RID: 37974
		Texture2,
		// Token: 0x04009457 RID: 37975
		Texture3,
		// Token: 0x04009458 RID: 37976
		Texture4,
		// Token: 0x04009459 RID: 37977
		Texture5,
		// Token: 0x0400945A RID: 37978
		Texture6,
		// Token: 0x0400945B RID: 37979
		Texture7,
		// Token: 0x0400945C RID: 37980
		Texture8,
		// Token: 0x0400945D RID: 37981
		Texture9,
		// Token: 0x0400945E RID: 37982
		Texture10,
		// Token: 0x0400945F RID: 37983
		Texture11,
		// Token: 0x04009460 RID: 37984
		Texture12,
		// Token: 0x04009461 RID: 37985
		Texture13,
		// Token: 0x04009462 RID: 37986
		Texture14,
		// Token: 0x04009463 RID: 37987
		Texture15,
		// Token: 0x04009464 RID: 37988
		Texture16,
		// Token: 0x04009465 RID: 37989
		Texture17,
		// Token: 0x04009466 RID: 37990
		Texture18,
		// Token: 0x04009467 RID: 37991
		Texture19,
		// Token: 0x04009468 RID: 37992
		Texture20,
		// Token: 0x04009469 RID: 37993
		Texture21,
		// Token: 0x0400946A RID: 37994
		Texture22,
		// Token: 0x0400946B RID: 37995
		Texture23,
		// Token: 0x0400946C RID: 37996
		Texture24,
		// Token: 0x0400946D RID: 37997
		Texture25,
		// Token: 0x0400946E RID: 37998
		Texture26,
		// Token: 0x0400946F RID: 37999
		Texture27,
		// Token: 0x04009470 RID: 38000
		Texture28,
		// Token: 0x04009471 RID: 38001
		Texture29,
		// Token: 0x04009472 RID: 38002
		Texture30,
		// Token: 0x04009473 RID: 38003
		Texture31,
		// Token: 0x04009474 RID: 38004
		ActiveTexture,
		// Token: 0x04009475 RID: 38005
		MaxRenderbufferSize = 34024,
		// Token: 0x04009476 RID: 38006
		TextureCompressionHint = 34031,
		// Token: 0x04009477 RID: 38007
		TextureCompressionHintArb = 34031,
		// Token: 0x04009478 RID: 38008
		AllCompletedNv = 34034,
		// Token: 0x04009479 RID: 38009
		FenceStatusNv,
		// Token: 0x0400947A RID: 38010
		FenceConditionNv,
		// Token: 0x0400947B RID: 38011
		DepthStencilOes = 34041,
		// Token: 0x0400947C RID: 38012
		UnsignedInt248Oes,
		// Token: 0x0400947D RID: 38013
		TextureMaxAnisotropyExt = 34046,
		// Token: 0x0400947E RID: 38014
		MaxTextureMaxAnisotropyExt,
		// Token: 0x0400947F RID: 38015
		IncrWrap = 34055,
		// Token: 0x04009480 RID: 38016
		DecrWrap,
		// Token: 0x04009481 RID: 38017
		TextureCubeMap = 34067,
		// Token: 0x04009482 RID: 38018
		TextureBindingCubeMap,
		// Token: 0x04009483 RID: 38019
		TextureCubeMapPositiveX,
		// Token: 0x04009484 RID: 38020
		TextureCubeMapNegativeX,
		// Token: 0x04009485 RID: 38021
		TextureCubeMapPositiveY,
		// Token: 0x04009486 RID: 38022
		TextureCubeMapNegativeY,
		// Token: 0x04009487 RID: 38023
		TextureCubeMapPositiveZ,
		// Token: 0x04009488 RID: 38024
		TextureCubeMapNegativeZ,
		// Token: 0x04009489 RID: 38025
		MaxCubeMapTextureSize = 34076,
		// Token: 0x0400948A RID: 38026
		VertexArrayStorageHintApple = 34079,
		// Token: 0x0400948B RID: 38027
		MultisampleFilterHintNv = 34100,
		// Token: 0x0400948C RID: 38028
		PackSubsampleRateSgix = 34208,
		// Token: 0x0400948D RID: 38029
		UnpackSubsampleRateSgix,
		// Token: 0x0400948E RID: 38030
		PixelSubsample4444Sgix,
		// Token: 0x0400948F RID: 38031
		PixelSubsample2424Sgix,
		// Token: 0x04009490 RID: 38032
		PixelSubsample4242Sgix,
		// Token: 0x04009491 RID: 38033
		TransformHintApple = 34225,
		// Token: 0x04009492 RID: 38034
		VertexArrayBindingOes = 34229,
		// Token: 0x04009493 RID: 38035
		UnsignedShort88Apple = 34234,
		// Token: 0x04009494 RID: 38036
		UnsignedShort88RevApple,
		// Token: 0x04009495 RID: 38037
		TextureStorageHintApple,
		// Token: 0x04009496 RID: 38038
		VertexAttribArrayEnabled = 34338,
		// Token: 0x04009497 RID: 38039
		VertexAttribArraySize,
		// Token: 0x04009498 RID: 38040
		VertexAttribArrayStride,
		// Token: 0x04009499 RID: 38041
		VertexAttribArrayType,
		// Token: 0x0400949A RID: 38042
		CurrentVertexAttrib,
		// Token: 0x0400949B RID: 38043
		VertexAttribArrayPointer = 34373,
		// Token: 0x0400949C RID: 38044
		NumCompressedTextureFormats = 34466,
		// Token: 0x0400949D RID: 38045
		CompressedTextureFormats,
		// Token: 0x0400949E RID: 38046
		Z400BinaryAmd = 34624,
		// Token: 0x0400949F RID: 38047
		ProgramBinaryLengthOes,
		// Token: 0x040094A0 RID: 38048
		BufferSize = 34660,
		// Token: 0x040094A1 RID: 38049
		BufferUsage,
		// Token: 0x040094A2 RID: 38050
		AtcRgbaInterpolatedAlphaAmd = 34798,
		// Token: 0x040094A3 RID: 38051
		Gl3DcXAmd = 34809,
		// Token: 0x040094A4 RID: 38052
		Gl3DcXyAmd,
		// Token: 0x040094A5 RID: 38053
		NumProgramBinaryFormatsOes = 34814,
		// Token: 0x040094A6 RID: 38054
		ProgramBinaryFormatsOes,
		// Token: 0x040094A7 RID: 38055
		StencilBackFunc,
		// Token: 0x040094A8 RID: 38056
		StencilBackFail,
		// Token: 0x040094A9 RID: 38057
		StencilBackPassDepthFail,
		// Token: 0x040094AA RID: 38058
		StencilBackPassDepthPass,
		// Token: 0x040094AB RID: 38059
		Rgba32fExt = 34836,
		// Token: 0x040094AC RID: 38060
		Rgb32fExt,
		// Token: 0x040094AD RID: 38061
		Alpha32fExt,
		// Token: 0x040094AE RID: 38062
		Luminance32fExt = 34840,
		// Token: 0x040094AF RID: 38063
		LuminanceAlpha32fExt,
		// Token: 0x040094B0 RID: 38064
		Rgba16fExt,
		// Token: 0x040094B1 RID: 38065
		Rgb16fExt,
		// Token: 0x040094B2 RID: 38066
		Alpha16fExt,
		// Token: 0x040094B3 RID: 38067
		Luminance16fExt = 34846,
		// Token: 0x040094B4 RID: 38068
		LuminanceAlpha16fExt,
		// Token: 0x040094B5 RID: 38069
		WriteonlyRenderingQcom = 34851,
		// Token: 0x040094B6 RID: 38070
		MaxDrawBuffersExt,
		// Token: 0x040094B7 RID: 38071
		MaxDrawBuffersNv = 34852,
		// Token: 0x040094B8 RID: 38072
		DrawBuffer0Ext,
		// Token: 0x040094B9 RID: 38073
		DrawBuffer0Nv = 34853,
		// Token: 0x040094BA RID: 38074
		DrawBuffer1Ext,
		// Token: 0x040094BB RID: 38075
		DrawBuffer1Nv = 34854,
		// Token: 0x040094BC RID: 38076
		DrawBuffer2Ext,
		// Token: 0x040094BD RID: 38077
		DrawBuffer2Nv = 34855,
		// Token: 0x040094BE RID: 38078
		DrawBuffer3Ext,
		// Token: 0x040094BF RID: 38079
		DrawBuffer3Nv = 34856,
		// Token: 0x040094C0 RID: 38080
		DrawBuffer4Ext,
		// Token: 0x040094C1 RID: 38081
		DrawBuffer4Nv = 34857,
		// Token: 0x040094C2 RID: 38082
		DrawBuffer5Ext,
		// Token: 0x040094C3 RID: 38083
		DrawBuffer5Nv = 34858,
		// Token: 0x040094C4 RID: 38084
		DrawBuffer6Ext,
		// Token: 0x040094C5 RID: 38085
		DrawBuffer6Nv = 34859,
		// Token: 0x040094C6 RID: 38086
		DrawBuffer7Ext,
		// Token: 0x040094C7 RID: 38087
		DrawBuffer7Nv = 34860,
		// Token: 0x040094C8 RID: 38088
		DrawBuffer8Ext,
		// Token: 0x040094C9 RID: 38089
		DrawBuffer8Nv = 34861,
		// Token: 0x040094CA RID: 38090
		DrawBuffer9Ext,
		// Token: 0x040094CB RID: 38091
		DrawBuffer9Nv = 34862,
		// Token: 0x040094CC RID: 38092
		DrawBuffer10Ext,
		// Token: 0x040094CD RID: 38093
		DrawBuffer10Nv = 34863,
		// Token: 0x040094CE RID: 38094
		DrawBuffer11Ext,
		// Token: 0x040094CF RID: 38095
		DrawBuffer11Nv = 34864,
		// Token: 0x040094D0 RID: 38096
		DrawBuffer12Ext,
		// Token: 0x040094D1 RID: 38097
		DrawBuffer12Nv = 34865,
		// Token: 0x040094D2 RID: 38098
		DrawBuffer13Ext,
		// Token: 0x040094D3 RID: 38099
		DrawBuffer13Nv = 34866,
		// Token: 0x040094D4 RID: 38100
		DrawBuffer14Ext,
		// Token: 0x040094D5 RID: 38101
		DrawBuffer14Nv = 34867,
		// Token: 0x040094D6 RID: 38102
		DrawBuffer15Ext,
		// Token: 0x040094D7 RID: 38103
		DrawBuffer15Nv = 34868,
		// Token: 0x040094D8 RID: 38104
		BlendEquationAlpha = 34877,
		// Token: 0x040094D9 RID: 38105
		TextureCompareModeExt = 34892,
		// Token: 0x040094DA RID: 38106
		TextureCompareFuncExt,
		// Token: 0x040094DB RID: 38107
		CompareRefToTextureExt,
		// Token: 0x040094DC RID: 38108
		QueryCounterBitsExt = 34916,
		// Token: 0x040094DD RID: 38109
		CurrentQueryExt,
		// Token: 0x040094DE RID: 38110
		QueryResultExt,
		// Token: 0x040094DF RID: 38111
		QueryResultAvailableExt,
		// Token: 0x040094E0 RID: 38112
		MaxVertexAttribs = 34921,
		// Token: 0x040094E1 RID: 38113
		VertexAttribArrayNormalized,
		// Token: 0x040094E2 RID: 38114
		MaxTessControlInputComponentsExt = 34924,
		// Token: 0x040094E3 RID: 38115
		MaxTessEvaluationInputComponentsExt,
		// Token: 0x040094E4 RID: 38116
		MaxTextureImageUnits = 34930,
		// Token: 0x040094E5 RID: 38117
		GeometryShaderInvocationsExt = 34943,
		// Token: 0x040094E6 RID: 38118
		ArrayBuffer = 34962,
		// Token: 0x040094E7 RID: 38119
		ElementArrayBuffer,
		// Token: 0x040094E8 RID: 38120
		ArrayBufferBinding,
		// Token: 0x040094E9 RID: 38121
		ElementArrayBufferBinding,
		// Token: 0x040094EA RID: 38122
		VertexAttribArrayBufferBinding = 34975,
		// Token: 0x040094EB RID: 38123
		WriteOnlyOes = 35001,
		// Token: 0x040094EC RID: 38124
		BufferAccessOes = 35003,
		// Token: 0x040094ED RID: 38125
		BufferMappedOes,
		// Token: 0x040094EE RID: 38126
		BufferMapPointerOes,
		// Token: 0x040094EF RID: 38127
		TimeElapsedExt = 35007,
		// Token: 0x040094F0 RID: 38128
		StreamDraw = 35040,
		// Token: 0x040094F1 RID: 38129
		StaticDraw = 35044,
		// Token: 0x040094F2 RID: 38130
		DynamicDraw = 35048,
		// Token: 0x040094F3 RID: 38131
		Etc1Srgb8Nv = 35054,
		// Token: 0x040094F4 RID: 38132
		Depth24Stencil8Oes = 35056,
		// Token: 0x040094F5 RID: 38133
		VertexAttribArrayDivisorAngle = 35070,
		// Token: 0x040094F6 RID: 38134
		VertexAttribArrayDivisorExt = 35070,
		// Token: 0x040094F7 RID: 38135
		VertexAttribArrayDivisorNv = 35070,
		// Token: 0x040094F8 RID: 38136
		GeometryLinkedVerticesOutExt = 35094,
		// Token: 0x040094F9 RID: 38137
		GeometryLinkedInputTypeExt,
		// Token: 0x040094FA RID: 38138
		GeometryLinkedOutputTypeExt,
		// Token: 0x040094FB RID: 38139
		PackResampleOml = 35204,
		// Token: 0x040094FC RID: 38140
		UnpackResampleOml,
		// Token: 0x040094FD RID: 38141
		Rgb422Apple = 35359,
		// Token: 0x040094FE RID: 38142
		MaxGeometryUniformBlocksExt = 35372,
		// Token: 0x040094FF RID: 38143
		MaxCombinedGeometryUniformComponentsExt = 35378,
		// Token: 0x04009500 RID: 38144
		TextureSrgbDecodeExt = 35400,
		// Token: 0x04009501 RID: 38145
		DecodeExt,
		// Token: 0x04009502 RID: 38146
		SkipDecodeExt,
		// Token: 0x04009503 RID: 38147
		ProgramPipelineObjectExt = 35407,
		// Token: 0x04009504 RID: 38148
		RgbRaw422Apple = 35409,
		// Token: 0x04009505 RID: 38149
		FragmentShaderDiscardsSamplesExt,
		// Token: 0x04009506 RID: 38150
		SyncObjectApple,
		// Token: 0x04009507 RID: 38151
		CompressedSrgbPvrtc2Bppv1Ext,
		// Token: 0x04009508 RID: 38152
		CompressedSrgbPvrtc4Bppv1Ext,
		// Token: 0x04009509 RID: 38153
		CompressedSrgbAlphaPvrtc2Bppv1Ext,
		// Token: 0x0400950A RID: 38154
		CompressedSrgbAlphaPvrtc4Bppv1Ext,
		// Token: 0x0400950B RID: 38155
		FragmentShader = 35632,
		// Token: 0x0400950C RID: 38156
		VertexShader,
		// Token: 0x0400950D RID: 38157
		ProgramObjectExt = 35648,
		// Token: 0x0400950E RID: 38158
		ShaderObjectExt = 35656,
		// Token: 0x0400950F RID: 38159
		MaxVertexTextureImageUnits = 35660,
		// Token: 0x04009510 RID: 38160
		MaxCombinedTextureImageUnits,
		// Token: 0x04009511 RID: 38161
		ShaderType = 35663,
		// Token: 0x04009512 RID: 38162
		FloatVec2,
		// Token: 0x04009513 RID: 38163
		FloatVec3,
		// Token: 0x04009514 RID: 38164
		FloatVec4,
		// Token: 0x04009515 RID: 38165
		IntVec2,
		// Token: 0x04009516 RID: 38166
		IntVec3,
		// Token: 0x04009517 RID: 38167
		IntVec4,
		// Token: 0x04009518 RID: 38168
		Bool,
		// Token: 0x04009519 RID: 38169
		BoolVec2,
		// Token: 0x0400951A RID: 38170
		BoolVec3,
		// Token: 0x0400951B RID: 38171
		BoolVec4,
		// Token: 0x0400951C RID: 38172
		FloatMat2,
		// Token: 0x0400951D RID: 38173
		FloatMat3,
		// Token: 0x0400951E RID: 38174
		FloatMat4,
		// Token: 0x0400951F RID: 38175
		Sampler2D = 35678,
		// Token: 0x04009520 RID: 38176
		Sampler3DOes,
		// Token: 0x04009521 RID: 38177
		SamplerCube,
		// Token: 0x04009522 RID: 38178
		Sampler2DShadowExt = 35682,
		// Token: 0x04009523 RID: 38179
		FloatMat2x3Nv = 35685,
		// Token: 0x04009524 RID: 38180
		FloatMat2x4Nv,
		// Token: 0x04009525 RID: 38181
		FloatMat3x2Nv,
		// Token: 0x04009526 RID: 38182
		FloatMat3x4Nv,
		// Token: 0x04009527 RID: 38183
		FloatMat4x2Nv,
		// Token: 0x04009528 RID: 38184
		FloatMat4x3Nv,
		// Token: 0x04009529 RID: 38185
		DeleteStatus = 35712,
		// Token: 0x0400952A RID: 38186
		CompileStatus,
		// Token: 0x0400952B RID: 38187
		LinkStatus,
		// Token: 0x0400952C RID: 38188
		ValidateStatus,
		// Token: 0x0400952D RID: 38189
		InfoLogLength,
		// Token: 0x0400952E RID: 38190
		AttachedShaders,
		// Token: 0x0400952F RID: 38191
		ActiveUniforms,
		// Token: 0x04009530 RID: 38192
		ActiveUniformMaxLength,
		// Token: 0x04009531 RID: 38193
		ShaderSourceLength,
		// Token: 0x04009532 RID: 38194
		ActiveAttributes,
		// Token: 0x04009533 RID: 38195
		ActiveAttributeMaxLength,
		// Token: 0x04009534 RID: 38196
		FragmentShaderDerivativeHint,
		// Token: 0x04009535 RID: 38197
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x04009536 RID: 38198
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x04009537 RID: 38199
		ShadingLanguageVersion,
		// Token: 0x04009538 RID: 38200
		CurrentProgram,
		// Token: 0x04009539 RID: 38201
		Palette4Rgb8Oes = 35728,
		// Token: 0x0400953A RID: 38202
		Palette4Rgba8Oes,
		// Token: 0x0400953B RID: 38203
		Palette4R5G6B5Oes,
		// Token: 0x0400953C RID: 38204
		Palette4Rgba4Oes,
		// Token: 0x0400953D RID: 38205
		Palette4Rgb5A1Oes,
		// Token: 0x0400953E RID: 38206
		Palette8Rgb8Oes,
		// Token: 0x0400953F RID: 38207
		Palette8Rgba8Oes,
		// Token: 0x04009540 RID: 38208
		Palette8R5G6B5Oes,
		// Token: 0x04009541 RID: 38209
		Palette8Rgba4Oes,
		// Token: 0x04009542 RID: 38210
		Palette8Rgb5A1Oes,
		// Token: 0x04009543 RID: 38211
		ImplementationColorReadType,
		// Token: 0x04009544 RID: 38212
		ImplementationColorReadFormat,
		// Token: 0x04009545 RID: 38213
		CounterTypeAmd = 35776,
		// Token: 0x04009546 RID: 38214
		CounterRangeAmd,
		// Token: 0x04009547 RID: 38215
		UnsignedInt64Amd,
		// Token: 0x04009548 RID: 38216
		PercentageAmd,
		// Token: 0x04009549 RID: 38217
		PerfmonResultAvailableAmd,
		// Token: 0x0400954A RID: 38218
		PerfmonResultSizeAmd,
		// Token: 0x0400954B RID: 38219
		PerfmonResultAmd,
		// Token: 0x0400954C RID: 38220
		TextureWidthQcom = 35794,
		// Token: 0x0400954D RID: 38221
		TextureHeightQcom,
		// Token: 0x0400954E RID: 38222
		TextureDepthQcom,
		// Token: 0x0400954F RID: 38223
		TextureInternalFormatQcom,
		// Token: 0x04009550 RID: 38224
		TextureFormatQcom,
		// Token: 0x04009551 RID: 38225
		TextureTypeQcom,
		// Token: 0x04009552 RID: 38226
		TextureImageValidQcom,
		// Token: 0x04009553 RID: 38227
		TextureNumLevelsQcom,
		// Token: 0x04009554 RID: 38228
		TextureTargetQcom,
		// Token: 0x04009555 RID: 38229
		TextureObjectValidQcom,
		// Token: 0x04009556 RID: 38230
		StateRestore,
		// Token: 0x04009557 RID: 38231
		CompressedRgbPvrtc4Bppv1Img = 35840,
		// Token: 0x04009558 RID: 38232
		CompressedRgbPvrtc2Bppv1Img,
		// Token: 0x04009559 RID: 38233
		CompressedRgbaPvrtc4Bppv1Img,
		// Token: 0x0400955A RID: 38234
		CompressedRgbaPvrtc2Bppv1Img,
		// Token: 0x0400955B RID: 38235
		SgxBinaryImg = 35850,
		// Token: 0x0400955C RID: 38236
		UnsignedNormalizedExt = 35863,
		// Token: 0x0400955D RID: 38237
		MaxGeometryTextureImageUnitsExt = 35881,
		// Token: 0x0400955E RID: 38238
		TextureBufferBindingExt,
		// Token: 0x0400955F RID: 38239
		TextureBufferExt = 35882,
		// Token: 0x04009560 RID: 38240
		MaxTextureBufferSizeExt,
		// Token: 0x04009561 RID: 38241
		TextureBindingBufferExt,
		// Token: 0x04009562 RID: 38242
		TextureBufferDataStoreBindingExt,
		// Token: 0x04009563 RID: 38243
		AnySamplesPassedExt = 35887,
		// Token: 0x04009564 RID: 38244
		SampleShadingOes = 35894,
		// Token: 0x04009565 RID: 38245
		MinSampleShadingValueOes,
		// Token: 0x04009566 RID: 38246
		SrgbExt = 35904,
		// Token: 0x04009567 RID: 38247
		Srgb8Nv,
		// Token: 0x04009568 RID: 38248
		SrgbAlphaExt,
		// Token: 0x04009569 RID: 38249
		Srgb8Alpha8Ext,
		// Token: 0x0400956A RID: 38250
		SluminanceAlphaNv,
		// Token: 0x0400956B RID: 38251
		Sluminance8Alpha8Nv,
		// Token: 0x0400956C RID: 38252
		SluminanceNv,
		// Token: 0x0400956D RID: 38253
		Sluminance8Nv,
		// Token: 0x0400956E RID: 38254
		CompressedSrgbS3tcDxt1Nv = 35916,
		// Token: 0x0400956F RID: 38255
		CompressedSrgbAlphaS3tcDxt1Nv,
		// Token: 0x04009570 RID: 38256
		CompressedSrgbAlphaS3tcDxt3Nv,
		// Token: 0x04009571 RID: 38257
		CompressedSrgbAlphaS3tcDxt5Nv,
		// Token: 0x04009572 RID: 38258
		PrimitivesGeneratedExt = 35975,
		// Token: 0x04009573 RID: 38259
		AtcRgbAmd = 35986,
		// Token: 0x04009574 RID: 38260
		AtcRgbaExplicitAlphaAmd,
		// Token: 0x04009575 RID: 38261
		StencilBackRef = 36003,
		// Token: 0x04009576 RID: 38262
		StencilBackValueMask,
		// Token: 0x04009577 RID: 38263
		StencilBackWritemask,
		// Token: 0x04009578 RID: 38264
		DrawFramebufferBindingAngle,
		// Token: 0x04009579 RID: 38265
		DrawFramebufferBindingApple = 36006,
		// Token: 0x0400957A RID: 38266
		DrawFramebufferBindingNv = 36006,
		// Token: 0x0400957B RID: 38267
		FramebufferBinding = 36006,
		// Token: 0x0400957C RID: 38268
		RenderbufferBinding,
		// Token: 0x0400957D RID: 38269
		ReadFramebufferAngle,
		// Token: 0x0400957E RID: 38270
		ReadFramebufferApple = 36008,
		// Token: 0x0400957F RID: 38271
		ReadFramebufferNv = 36008,
		// Token: 0x04009580 RID: 38272
		DrawFramebufferAngle,
		// Token: 0x04009581 RID: 38273
		DrawFramebufferApple = 36009,
		// Token: 0x04009582 RID: 38274
		DrawFramebufferNv = 36009,
		// Token: 0x04009583 RID: 38275
		ReadFramebufferBindingAngle,
		// Token: 0x04009584 RID: 38276
		ReadFramebufferBindingApple = 36010,
		// Token: 0x04009585 RID: 38277
		ReadFramebufferBindingNv = 36010,
		// Token: 0x04009586 RID: 38278
		RenderbufferSamplesAngle,
		// Token: 0x04009587 RID: 38279
		RenderbufferSamplesApple = 36011,
		// Token: 0x04009588 RID: 38280
		RenderbufferSamplesExt = 36011,
		// Token: 0x04009589 RID: 38281
		RenderbufferSamplesNv = 36011,
		// Token: 0x0400958A RID: 38282
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x0400958B RID: 38283
		FramebufferAttachmentObjectName,
		// Token: 0x0400958C RID: 38284
		FramebufferAttachmentTextureLevel,
		// Token: 0x0400958D RID: 38285
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x0400958E RID: 38286
		FramebufferAttachmentTexture3DZoffsetOes,
		// Token: 0x0400958F RID: 38287
		FramebufferComplete,
		// Token: 0x04009590 RID: 38288
		FramebufferIncompleteAttachment,
		// Token: 0x04009591 RID: 38289
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04009592 RID: 38290
		FramebufferIncompleteDimensions = 36057,
		// Token: 0x04009593 RID: 38291
		FramebufferUnsupported = 36061,
		// Token: 0x04009594 RID: 38292
		MaxColorAttachmentsExt = 36063,
		// Token: 0x04009595 RID: 38293
		MaxColorAttachmentsNv = 36063,
		// Token: 0x04009596 RID: 38294
		ColorAttachment0,
		// Token: 0x04009597 RID: 38295
		ColorAttachment0Ext = 36064,
		// Token: 0x04009598 RID: 38296
		ColorAttachment0Nv = 36064,
		// Token: 0x04009599 RID: 38297
		ColorAttachment1Ext,
		// Token: 0x0400959A RID: 38298
		ColorAttachment1Nv = 36065,
		// Token: 0x0400959B RID: 38299
		ColorAttachment2Ext,
		// Token: 0x0400959C RID: 38300
		ColorAttachment2Nv = 36066,
		// Token: 0x0400959D RID: 38301
		ColorAttachment3Ext,
		// Token: 0x0400959E RID: 38302
		ColorAttachment3Nv = 36067,
		// Token: 0x0400959F RID: 38303
		ColorAttachment4Ext,
		// Token: 0x040095A0 RID: 38304
		ColorAttachment4Nv = 36068,
		// Token: 0x040095A1 RID: 38305
		ColorAttachment5Ext,
		// Token: 0x040095A2 RID: 38306
		ColorAttachment5Nv = 36069,
		// Token: 0x040095A3 RID: 38307
		ColorAttachment6Ext,
		// Token: 0x040095A4 RID: 38308
		ColorAttachment6Nv = 36070,
		// Token: 0x040095A5 RID: 38309
		ColorAttachment7Ext,
		// Token: 0x040095A6 RID: 38310
		ColorAttachment7Nv = 36071,
		// Token: 0x040095A7 RID: 38311
		ColorAttachment8Ext,
		// Token: 0x040095A8 RID: 38312
		ColorAttachment8Nv = 36072,
		// Token: 0x040095A9 RID: 38313
		ColorAttachment9Ext,
		// Token: 0x040095AA RID: 38314
		ColorAttachment9Nv = 36073,
		// Token: 0x040095AB RID: 38315
		ColorAttachment10Ext,
		// Token: 0x040095AC RID: 38316
		ColorAttachment10Nv = 36074,
		// Token: 0x040095AD RID: 38317
		ColorAttachment11Ext,
		// Token: 0x040095AE RID: 38318
		ColorAttachment11Nv = 36075,
		// Token: 0x040095AF RID: 38319
		ColorAttachment12Ext,
		// Token: 0x040095B0 RID: 38320
		ColorAttachment12Nv = 36076,
		// Token: 0x040095B1 RID: 38321
		ColorAttachment13Ext,
		// Token: 0x040095B2 RID: 38322
		ColorAttachment13Nv = 36077,
		// Token: 0x040095B3 RID: 38323
		ColorAttachment14Ext,
		// Token: 0x040095B4 RID: 38324
		ColorAttachment14Nv = 36078,
		// Token: 0x040095B5 RID: 38325
		ColorAttachment15Ext,
		// Token: 0x040095B6 RID: 38326
		ColorAttachment15Nv = 36079,
		// Token: 0x040095B7 RID: 38327
		DepthAttachment = 36096,
		// Token: 0x040095B8 RID: 38328
		StencilAttachment = 36128,
		// Token: 0x040095B9 RID: 38329
		Framebuffer = 36160,
		// Token: 0x040095BA RID: 38330
		Renderbuffer,
		// Token: 0x040095BB RID: 38331
		RenderbufferWidth,
		// Token: 0x040095BC RID: 38332
		RenderbufferHeight,
		// Token: 0x040095BD RID: 38333
		RenderbufferInternalFormat,
		// Token: 0x040095BE RID: 38334
		StencilIndex1Oes = 36166,
		// Token: 0x040095BF RID: 38335
		StencilIndex4Oes,
		// Token: 0x040095C0 RID: 38336
		StencilIndex8,
		// Token: 0x040095C1 RID: 38337
		StencilIndex8Oes = 36168,
		// Token: 0x040095C2 RID: 38338
		RenderbufferRedSize = 36176,
		// Token: 0x040095C3 RID: 38339
		RenderbufferGreenSize,
		// Token: 0x040095C4 RID: 38340
		RenderbufferBlueSize,
		// Token: 0x040095C5 RID: 38341
		RenderbufferAlphaSize,
		// Token: 0x040095C6 RID: 38342
		RenderbufferDepthSize,
		// Token: 0x040095C7 RID: 38343
		RenderbufferStencilSize,
		// Token: 0x040095C8 RID: 38344
		FramebufferIncompleteMultisampleAngle,
		// Token: 0x040095C9 RID: 38345
		FramebufferIncompleteMultisampleApple = 36182,
		// Token: 0x040095CA RID: 38346
		FramebufferIncompleteMultisampleExt = 36182,
		// Token: 0x040095CB RID: 38347
		FramebufferIncompleteMultisampleNv = 36182,
		// Token: 0x040095CC RID: 38348
		MaxSamplesAngle,
		// Token: 0x040095CD RID: 38349
		MaxSamplesApple = 36183,
		// Token: 0x040095CE RID: 38350
		MaxSamplesExt = 36183,
		// Token: 0x040095CF RID: 38351
		MaxSamplesNv = 36183,
		// Token: 0x040095D0 RID: 38352
		HalfFloatOes = 36193,
		// Token: 0x040095D1 RID: 38353
		Rgb565Oes,
		// Token: 0x040095D2 RID: 38354
		Rgb565 = 36194,
		// Token: 0x040095D3 RID: 38355
		Etc1Rgb8Oes = 36196,
		// Token: 0x040095D4 RID: 38356
		TextureExternalOes,
		// Token: 0x040095D5 RID: 38357
		SamplerExternalOes,
		// Token: 0x040095D6 RID: 38358
		TextureBindingExternalOes,
		// Token: 0x040095D7 RID: 38359
		RequiredTextureImageUnitsOes,
		// Token: 0x040095D8 RID: 38360
		AnySamplesPassedConservativeExt = 36202,
		// Token: 0x040095D9 RID: 38361
		FramebufferAttachmentTextureSamplesExt = 36204,
		// Token: 0x040095DA RID: 38362
		FramebufferAttachmentLayeredExt = 36263,
		// Token: 0x040095DB RID: 38363
		FramebufferIncompleteLayerTargetsExt,
		// Token: 0x040095DC RID: 38364
		FramebufferSrgbExt = 36281,
		// Token: 0x040095DD RID: 38365
		SamplerBufferExt = 36290,
		// Token: 0x040095DE RID: 38366
		Sampler2DArrayShadowNv = 36292,
		// Token: 0x040095DF RID: 38367
		SamplerCubeShadowNv,
		// Token: 0x040095E0 RID: 38368
		IntSamplerBufferExt = 36304,
		// Token: 0x040095E1 RID: 38369
		UnsignedIntSamplerBufferExt = 36312,
		// Token: 0x040095E2 RID: 38370
		GeometryShaderExt,
		// Token: 0x040095E3 RID: 38371
		MaxGeometryUniformComponentsExt = 36319,
		// Token: 0x040095E4 RID: 38372
		MaxGeometryOutputVerticesExt,
		// Token: 0x040095E5 RID: 38373
		MaxGeometryTotalOutputComponentsExt,
		// Token: 0x040095E6 RID: 38374
		LowFloat = 36336,
		// Token: 0x040095E7 RID: 38375
		MediumFloat,
		// Token: 0x040095E8 RID: 38376
		HighFloat,
		// Token: 0x040095E9 RID: 38377
		LowInt,
		// Token: 0x040095EA RID: 38378
		MediumInt,
		// Token: 0x040095EB RID: 38379
		HighInt,
		// Token: 0x040095EC RID: 38380
		UnsignedInt1010102Oes,
		// Token: 0x040095ED RID: 38381
		Int1010102Oes,
		// Token: 0x040095EE RID: 38382
		ShaderBinaryFormats,
		// Token: 0x040095EF RID: 38383
		NumShaderBinaryFormats,
		// Token: 0x040095F0 RID: 38384
		ShaderCompiler,
		// Token: 0x040095F1 RID: 38385
		MaxVertexUniformVectors,
		// Token: 0x040095F2 RID: 38386
		MaxVaryingVectors,
		// Token: 0x040095F3 RID: 38387
		MaxFragmentUniformVectors,
		// Token: 0x040095F4 RID: 38388
		MaxCombinedTessControlUniformComponentsExt = 36382,
		// Token: 0x040095F5 RID: 38389
		MaxCombinedTessEvaluationUniformComponentsExt,
		// Token: 0x040095F6 RID: 38390
		TransformFeedback = 36386,
		// Token: 0x040095F7 RID: 38391
		TimestampExt = 36392,
		// Token: 0x040095F8 RID: 38392
		DepthComponent16NonlinearNv = 36396,
		// Token: 0x040095F9 RID: 38393
		FirstVertexConventionExt = 36429,
		// Token: 0x040095FA RID: 38394
		LastVertexConventionExt,
		// Token: 0x040095FB RID: 38395
		MaxGeometryShaderInvocationsExt = 36442,
		// Token: 0x040095FC RID: 38396
		MinFragmentInterpolationOffsetOes,
		// Token: 0x040095FD RID: 38397
		MaxFragmentInterpolationOffsetOes,
		// Token: 0x040095FE RID: 38398
		FragmentInterpolationOffsetBitsOes,
		// Token: 0x040095FF RID: 38399
		PatchVerticesExt = 36466,
		// Token: 0x04009600 RID: 38400
		TessControlOutputVerticesExt = 36469,
		// Token: 0x04009601 RID: 38401
		TessGenModeExt,
		// Token: 0x04009602 RID: 38402
		TessGenSpacingExt,
		// Token: 0x04009603 RID: 38403
		TessGenVertexOrderExt,
		// Token: 0x04009604 RID: 38404
		TessGenPointModeExt,
		// Token: 0x04009605 RID: 38405
		IsolinesExt,
		// Token: 0x04009606 RID: 38406
		FractionalOddExt,
		// Token: 0x04009607 RID: 38407
		FractionalEvenExt,
		// Token: 0x04009608 RID: 38408
		MaxPatchVerticesExt,
		// Token: 0x04009609 RID: 38409
		MaxTessGenLevelExt,
		// Token: 0x0400960A RID: 38410
		MaxTessControlUniformComponentsExt,
		// Token: 0x0400960B RID: 38411
		MaxTessEvaluationUniformComponentsExt,
		// Token: 0x0400960C RID: 38412
		MaxTessControlTextureImageUnitsExt,
		// Token: 0x0400960D RID: 38413
		MaxTessEvaluationTextureImageUnitsExt,
		// Token: 0x0400960E RID: 38414
		MaxTessControlOutputComponentsExt,
		// Token: 0x0400960F RID: 38415
		MaxTessPatchComponentsExt,
		// Token: 0x04009610 RID: 38416
		MaxTessControlTotalOutputComponentsExt,
		// Token: 0x04009611 RID: 38417
		MaxTessEvaluationOutputComponentsExt,
		// Token: 0x04009612 RID: 38418
		TessEvaluationShaderExt,
		// Token: 0x04009613 RID: 38419
		TessControlShaderExt,
		// Token: 0x04009614 RID: 38420
		MaxTessControlUniformBlocksExt,
		// Token: 0x04009615 RID: 38421
		MaxTessEvaluationUniformBlocksExt,
		// Token: 0x04009616 RID: 38422
		CoverageComponentNv = 36560,
		// Token: 0x04009617 RID: 38423
		CoverageComponent4Nv,
		// Token: 0x04009618 RID: 38424
		CoverageAttachmentNv,
		// Token: 0x04009619 RID: 38425
		CoverageBuffersNv,
		// Token: 0x0400961A RID: 38426
		CoverageSamplesNv,
		// Token: 0x0400961B RID: 38427
		CoverageAllFragmentsNv,
		// Token: 0x0400961C RID: 38428
		CoverageEdgeFragmentsNv,
		// Token: 0x0400961D RID: 38429
		CoverageAutomaticNv,
		// Token: 0x0400961E RID: 38430
		CopyReadBufferNv = 36662,
		// Token: 0x0400961F RID: 38431
		CopyWriteBufferNv,
		// Token: 0x04009620 RID: 38432
		MaliShaderBinaryArm = 36704,
		// Token: 0x04009621 RID: 38433
		MaliProgramBinaryArm,
		// Token: 0x04009622 RID: 38434
		MaxShaderPixelLocalStorageFastSizeExt = 36707,
		// Token: 0x04009623 RID: 38435
		ShaderPixelLocalStorageExt,
		// Token: 0x04009624 RID: 38436
		FetchPerSampleArm,
		// Token: 0x04009625 RID: 38437
		FragmentShaderFramebufferFetchMrtArm,
		// Token: 0x04009626 RID: 38438
		MaxShaderPixelLocalStorageSizeExt,
		// Token: 0x04009627 RID: 38439
		PerfmonGlobalModeQcom = 36768,
		// Token: 0x04009628 RID: 38440
		BinningControlHintQcom = 36784,
		// Token: 0x04009629 RID: 38441
		CpuOptimizedQcom,
		// Token: 0x0400962A RID: 38442
		GpuOptimizedQcom,
		// Token: 0x0400962B RID: 38443
		RenderDirectToFramebufferQcom,
		// Token: 0x0400962C RID: 38444
		GpuDisjointExt = 36795,
		// Token: 0x0400962D RID: 38445
		ShaderBinaryViv = 36804,
		// Token: 0x0400962E RID: 38446
		TextureCubeMapArrayExt = 36873,
		// Token: 0x0400962F RID: 38447
		TextureBindingCubeMapArrayExt,
		// Token: 0x04009630 RID: 38448
		SamplerCubeMapArrayExt = 36876,
		// Token: 0x04009631 RID: 38449
		SamplerCubeMapArrayShadowExt,
		// Token: 0x04009632 RID: 38450
		IntSamplerCubeMapArrayExt,
		// Token: 0x04009633 RID: 38451
		UnsignedIntSamplerCubeMapArrayExt,
		// Token: 0x04009634 RID: 38452
		ImageBufferExt = 36945,
		// Token: 0x04009635 RID: 38453
		ImageCubeMapArrayExt = 36948,
		// Token: 0x04009636 RID: 38454
		IntImageBufferExt = 36956,
		// Token: 0x04009637 RID: 38455
		IntImageCubeMapArrayExt = 36959,
		// Token: 0x04009638 RID: 38456
		UnsignedIntImageBufferExt = 36967,
		// Token: 0x04009639 RID: 38457
		UnsignedIntImageCubeMapArrayExt = 36970,
		// Token: 0x0400963A RID: 38458
		MaxTessControlImageUniformsExt = 37067,
		// Token: 0x0400963B RID: 38459
		MaxTessEvaluationImageUniformsExt,
		// Token: 0x0400963C RID: 38460
		MaxGeometryImageUniformsExt,
		// Token: 0x0400963D RID: 38461
		MaxGeometryShaderStorageBlocksExt = 37079,
		// Token: 0x0400963E RID: 38462
		MaxTessControlShaderStorageBlocksExt,
		// Token: 0x0400963F RID: 38463
		MaxTessEvaluationShaderStorageBlocksExt,
		// Token: 0x04009640 RID: 38464
		ColorAttachmentExt = 37104,
		// Token: 0x04009641 RID: 38465
		MultiviewExt,
		// Token: 0x04009642 RID: 38466
		MaxMultiviewBuffersExt,
		// Token: 0x04009643 RID: 38467
		ContextRobustAccessExt,
		// Token: 0x04009644 RID: 38468
		Texture2DMultisampleArrayOes = 37122,
		// Token: 0x04009645 RID: 38469
		TextureBinding2DMultisampleArrayOes = 37125,
		// Token: 0x04009646 RID: 38470
		Sampler2DMultisampleArrayOes = 37131,
		// Token: 0x04009647 RID: 38471
		IntSampler2DMultisampleArrayOes,
		// Token: 0x04009648 RID: 38472
		UnsignedIntSampler2DMultisampleArrayOes,
		// Token: 0x04009649 RID: 38473
		MaxServerWaitTimeoutApple = 37137,
		// Token: 0x0400964A RID: 38474
		ObjectTypeApple,
		// Token: 0x0400964B RID: 38475
		SyncConditionApple,
		// Token: 0x0400964C RID: 38476
		SyncStatusApple,
		// Token: 0x0400964D RID: 38477
		SyncFlagsApple,
		// Token: 0x0400964E RID: 38478
		SyncFenceApple,
		// Token: 0x0400964F RID: 38479
		SyncGpuCommandsCompleteApple,
		// Token: 0x04009650 RID: 38480
		UnsignaledApple,
		// Token: 0x04009651 RID: 38481
		SignaledApple,
		// Token: 0x04009652 RID: 38482
		AlreadySignaledApple,
		// Token: 0x04009653 RID: 38483
		TimeoutExpiredApple,
		// Token: 0x04009654 RID: 38484
		ConditionSatisfiedApple,
		// Token: 0x04009655 RID: 38485
		WaitFailedApple,
		// Token: 0x04009656 RID: 38486
		MaxGeometryInputComponentsExt = 37155,
		// Token: 0x04009657 RID: 38487
		MaxGeometryOutputComponentsExt,
		// Token: 0x04009658 RID: 38488
		TextureImmutableFormatExt = 37167,
		// Token: 0x04009659 RID: 38489
		SgxProgramBinaryImg,
		// Token: 0x0400965A RID: 38490
		RenderbufferSamplesImg = 37171,
		// Token: 0x0400965B RID: 38491
		FramebufferIncompleteMultisampleImg,
		// Token: 0x0400965C RID: 38492
		MaxSamplesImg,
		// Token: 0x0400965D RID: 38493
		TextureSamplesImg,
		// Token: 0x0400965E RID: 38494
		CompressedRgbaPvrtc2Bppv2Img,
		// Token: 0x0400965F RID: 38495
		CompressedRgbaPvrtc4Bppv2Img,
		// Token: 0x04009660 RID: 38496
		MaxDebugMessageLength = 37187,
		// Token: 0x04009661 RID: 38497
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04009662 RID: 38498
		MaxDebugLoggedMessages,
		// Token: 0x04009663 RID: 38499
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04009664 RID: 38500
		DebugLoggedMessages,
		// Token: 0x04009665 RID: 38501
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x04009666 RID: 38502
		DebugSeverityHigh,
		// Token: 0x04009667 RID: 38503
		DebugSeverityHighKhr = 37190,
		// Token: 0x04009668 RID: 38504
		DebugSeverityMedium,
		// Token: 0x04009669 RID: 38505
		DebugSeverityMediumKhr = 37191,
		// Token: 0x0400966A RID: 38506
		DebugSeverityLow,
		// Token: 0x0400966B RID: 38507
		DebugSeverityLowKhr = 37192,
		// Token: 0x0400966C RID: 38508
		BufferObjectExt = 37201,
		// Token: 0x0400966D RID: 38509
		QueryObjectExt = 37203,
		// Token: 0x0400966E RID: 38510
		VertexArrayObjectExt,
		// Token: 0x0400966F RID: 38511
		TextureBufferOffsetExt = 37277,
		// Token: 0x04009670 RID: 38512
		TextureBufferSizeExt,
		// Token: 0x04009671 RID: 38513
		TextureBufferOffsetAlignmentExt,
		// Token: 0x04009672 RID: 38514
		ShaderBinaryDmp = 37456,
		// Token: 0x04009673 RID: 38515
		GccsoShaderBinaryFj = 37472,
		// Token: 0x04009674 RID: 38516
		BlendPremultipliedSrcNv = 37504,
		// Token: 0x04009675 RID: 38517
		BlendOverlapNv,
		// Token: 0x04009676 RID: 38518
		UncorrelatedNv,
		// Token: 0x04009677 RID: 38519
		DisjointNv,
		// Token: 0x04009678 RID: 38520
		ConjointNv,
		// Token: 0x04009679 RID: 38521
		BlendAdvancedCoherentKhr,
		// Token: 0x0400967A RID: 38522
		BlendAdvancedCoherentNv = 37509,
		// Token: 0x0400967B RID: 38523
		SrcNv,
		// Token: 0x0400967C RID: 38524
		DstNv,
		// Token: 0x0400967D RID: 38525
		SrcOverNv,
		// Token: 0x0400967E RID: 38526
		DstOverNv,
		// Token: 0x0400967F RID: 38527
		SrcInNv,
		// Token: 0x04009680 RID: 38528
		DstInNv,
		// Token: 0x04009681 RID: 38529
		SrcOutNv,
		// Token: 0x04009682 RID: 38530
		DstOutNv,
		// Token: 0x04009683 RID: 38531
		SrcAtopNv,
		// Token: 0x04009684 RID: 38532
		DstAtopNv,
		// Token: 0x04009685 RID: 38533
		PlusNv = 37521,
		// Token: 0x04009686 RID: 38534
		PlusDarkerNv,
		// Token: 0x04009687 RID: 38535
		MultiplyKhr = 37524,
		// Token: 0x04009688 RID: 38536
		MultiplyNv = 37524,
		// Token: 0x04009689 RID: 38537
		ScreenKhr,
		// Token: 0x0400968A RID: 38538
		ScreenNv = 37525,
		// Token: 0x0400968B RID: 38539
		OverlayKhr,
		// Token: 0x0400968C RID: 38540
		OverlayNv = 37526,
		// Token: 0x0400968D RID: 38541
		DarkenKhr,
		// Token: 0x0400968E RID: 38542
		DarkenNv = 37527,
		// Token: 0x0400968F RID: 38543
		LightenKhr,
		// Token: 0x04009690 RID: 38544
		LightenNv = 37528,
		// Token: 0x04009691 RID: 38545
		ColordodgeKhr,
		// Token: 0x04009692 RID: 38546
		ColordodgeNv = 37529,
		// Token: 0x04009693 RID: 38547
		ColorburnKhr,
		// Token: 0x04009694 RID: 38548
		ColorburnNv = 37530,
		// Token: 0x04009695 RID: 38549
		HardlightKhr,
		// Token: 0x04009696 RID: 38550
		HardlightNv = 37531,
		// Token: 0x04009697 RID: 38551
		SoftlightKhr,
		// Token: 0x04009698 RID: 38552
		SoftlightNv = 37532,
		// Token: 0x04009699 RID: 38553
		DifferenceKhr = 37534,
		// Token: 0x0400969A RID: 38554
		DifferenceNv = 37534,
		// Token: 0x0400969B RID: 38555
		MinusNv,
		// Token: 0x0400969C RID: 38556
		ExclusionKhr,
		// Token: 0x0400969D RID: 38557
		ExclusionNv = 37536,
		// Token: 0x0400969E RID: 38558
		ContrastNv,
		// Token: 0x0400969F RID: 38559
		InvertRgbNv = 37539,
		// Token: 0x040096A0 RID: 38560
		LineardodgeNv,
		// Token: 0x040096A1 RID: 38561
		LinearburnNv,
		// Token: 0x040096A2 RID: 38562
		VividlightNv,
		// Token: 0x040096A3 RID: 38563
		LinearlightNv,
		// Token: 0x040096A4 RID: 38564
		PinlightNv,
		// Token: 0x040096A5 RID: 38565
		HardmixNv,
		// Token: 0x040096A6 RID: 38566
		HslHueKhr = 37549,
		// Token: 0x040096A7 RID: 38567
		HslHueNv = 37549,
		// Token: 0x040096A8 RID: 38568
		HslSaturationKhr,
		// Token: 0x040096A9 RID: 38569
		HslSaturationNv = 37550,
		// Token: 0x040096AA RID: 38570
		HslColorKhr,
		// Token: 0x040096AB RID: 38571
		HslColorNv = 37551,
		// Token: 0x040096AC RID: 38572
		HslLuminosityKhr,
		// Token: 0x040096AD RID: 38573
		HslLuminosityNv = 37552,
		// Token: 0x040096AE RID: 38574
		PlusClampedNv,
		// Token: 0x040096AF RID: 38575
		PlusClampedAlphaNv,
		// Token: 0x040096B0 RID: 38576
		MinusClampedNv,
		// Token: 0x040096B1 RID: 38577
		InvertOvgNv,
		// Token: 0x040096B2 RID: 38578
		PrimitiveBoundingBoxExt = 37566,
		// Token: 0x040096B3 RID: 38579
		MaxTessControlAtomicCounterBuffersExt = 37581,
		// Token: 0x040096B4 RID: 38580
		MaxTessEvaluationAtomicCounterBuffersExt,
		// Token: 0x040096B5 RID: 38581
		MaxGeometryAtomicCounterBuffersExt,
		// Token: 0x040096B6 RID: 38582
		MaxTessControlAtomicCountersExt = 37587,
		// Token: 0x040096B7 RID: 38583
		MaxTessEvaluationAtomicCountersExt,
		// Token: 0x040096B8 RID: 38584
		MaxGeometryAtomicCountersExt,
		// Token: 0x040096B9 RID: 38585
		DebugOutput = 37600,
		// Token: 0x040096BA RID: 38586
		DebugOutputKhr = 37600,
		// Token: 0x040096BB RID: 38587
		IsPerPatchExt = 37607,
		// Token: 0x040096BC RID: 38588
		ReferencedByTessControlShaderExt = 37639,
		// Token: 0x040096BD RID: 38589
		ReferencedByTessEvaluationShaderExt,
		// Token: 0x040096BE RID: 38590
		ReferencedByGeometryShaderExt,
		// Token: 0x040096BF RID: 38591
		FramebufferDefaultLayersExt = 37650,
		// Token: 0x040096C0 RID: 38592
		MaxFramebufferLayersExt = 37655,
		// Token: 0x040096C1 RID: 38593
		TranslatedShaderSourceLengthAngle = 37792,
		// Token: 0x040096C2 RID: 38594
		Bgra8Ext,
		// Token: 0x040096C3 RID: 38595
		TextureUsageAngle,
		// Token: 0x040096C4 RID: 38596
		FramebufferAttachmentAngle,
		// Token: 0x040096C5 RID: 38597
		PackReverseRowOrderAngle,
		// Token: 0x040096C6 RID: 38598
		ProgramBinaryAngle = 37798,
		// Token: 0x040096C7 RID: 38599
		CompressedRgbaAstc4X4Khr = 37808,
		// Token: 0x040096C8 RID: 38600
		CompressedRgbaAstc5X4Khr,
		// Token: 0x040096C9 RID: 38601
		CompressedRgbaAstc5X5Khr,
		// Token: 0x040096CA RID: 38602
		CompressedRgbaAstc6X5Khr,
		// Token: 0x040096CB RID: 38603
		CompressedRgbaAstc6X6Khr,
		// Token: 0x040096CC RID: 38604
		CompressedRgbaAstc8X5Khr,
		// Token: 0x040096CD RID: 38605
		CompressedRgbaAstc8X6Khr,
		// Token: 0x040096CE RID: 38606
		CompressedRgbaAstc8X8Khr,
		// Token: 0x040096CF RID: 38607
		CompressedRgbaAstc10X5Khr,
		// Token: 0x040096D0 RID: 38608
		CompressedRgbaAstc10X6Khr,
		// Token: 0x040096D1 RID: 38609
		CompressedRgbaAstc10X8Khr,
		// Token: 0x040096D2 RID: 38610
		CompressedRgbaAstc10X10Khr,
		// Token: 0x040096D3 RID: 38611
		CompressedRgbaAstc12X10Khr,
		// Token: 0x040096D4 RID: 38612
		CompressedRgbaAstc12X12Khr,
		// Token: 0x040096D5 RID: 38613
		CompressedRgbaAstc3X3x3Oes = 37824,
		// Token: 0x040096D6 RID: 38614
		CompressedRgbaAstc4X3x3Oes,
		// Token: 0x040096D7 RID: 38615
		CompressedRgbaAstc4X4x3Oes,
		// Token: 0x040096D8 RID: 38616
		CompressedRgbaAstc4X4x4Oes,
		// Token: 0x040096D9 RID: 38617
		CompressedRgbaAstc5X4x4Oes,
		// Token: 0x040096DA RID: 38618
		CompressedRgbaAstc5X5x4Oes,
		// Token: 0x040096DB RID: 38619
		CompressedRgbaAstc5X5x5Oes,
		// Token: 0x040096DC RID: 38620
		CompressedRgbaAstc6X5x5Oes,
		// Token: 0x040096DD RID: 38621
		CompressedRgbaAstc6X6x5Oes,
		// Token: 0x040096DE RID: 38622
		CompressedRgbaAstc6X6x6Oes,
		// Token: 0x040096DF RID: 38623
		CompressedSrgb8Alpha8Astc4X4Khr = 37840,
		// Token: 0x040096E0 RID: 38624
		CompressedSrgb8Alpha8Astc5X4Khr,
		// Token: 0x040096E1 RID: 38625
		CompressedSrgb8Alpha8Astc5X5Khr,
		// Token: 0x040096E2 RID: 38626
		CompressedSrgb8Alpha8Astc6X5Khr,
		// Token: 0x040096E3 RID: 38627
		CompressedSrgb8Alpha8Astc6X6Khr,
		// Token: 0x040096E4 RID: 38628
		CompressedSrgb8Alpha8Astc8X5Khr,
		// Token: 0x040096E5 RID: 38629
		CompressedSrgb8Alpha8Astc8X6Khr,
		// Token: 0x040096E6 RID: 38630
		CompressedSrgb8Alpha8Astc8X8Khr,
		// Token: 0x040096E7 RID: 38631
		CompressedSrgb8Alpha8Astc10X5Khr,
		// Token: 0x040096E8 RID: 38632
		CompressedSrgb8Alpha8Astc10X6Khr,
		// Token: 0x040096E9 RID: 38633
		CompressedSrgb8Alpha8Astc10X8Khr,
		// Token: 0x040096EA RID: 38634
		CompressedSrgb8Alpha8Astc10X10Khr,
		// Token: 0x040096EB RID: 38635
		CompressedSrgb8Alpha8Astc12X10Khr,
		// Token: 0x040096EC RID: 38636
		CompressedSrgb8Alpha8Astc12X12Khr,
		// Token: 0x040096ED RID: 38637
		CompressedSrgb8Alpha8Astc3X3x3Oes = 37856,
		// Token: 0x040096EE RID: 38638
		CompressedSrgb8Alpha8Astc4X3x3Oes,
		// Token: 0x040096EF RID: 38639
		CompressedSrgb8Alpha8Astc4X4x3Oes,
		// Token: 0x040096F0 RID: 38640
		CompressedSrgb8Alpha8Astc4X4x4Oes,
		// Token: 0x040096F1 RID: 38641
		CompressedSrgb8Alpha8Astc5X4x4Oes,
		// Token: 0x040096F2 RID: 38642
		CompressedSrgb8Alpha8Astc5X5x4Oes,
		// Token: 0x040096F3 RID: 38643
		CompressedSrgb8Alpha8Astc5X5x5Oes,
		// Token: 0x040096F4 RID: 38644
		CompressedSrgb8Alpha8Astc6X5x5Oes,
		// Token: 0x040096F5 RID: 38645
		CompressedSrgb8Alpha8Astc6X6x5Oes,
		// Token: 0x040096F6 RID: 38646
		CompressedSrgb8Alpha8Astc6X6x6Oes,
		// Token: 0x040096F7 RID: 38647
		CompressedSrgbAlphaPvrtc2Bppv2Img = 37872,
		// Token: 0x040096F8 RID: 38648
		CompressedSrgbAlphaPvrtc4Bppv2Img,
		// Token: 0x040096F9 RID: 38649
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x040096FA RID: 38650
		PerfqueryCounterDurationNormIntel,
		// Token: 0x040096FB RID: 38651
		PerfqueryCounterDurationRawIntel,
		// Token: 0x040096FC RID: 38652
		PerfqueryCounterThroughputIntel,
		// Token: 0x040096FD RID: 38653
		PerfqueryCounterRawIntel,
		// Token: 0x040096FE RID: 38654
		PerfqueryCounterTimestampIntel,
		// Token: 0x040096FF RID: 38655
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x04009700 RID: 38656
		PerfqueryCounterDataUint64Intel,
		// Token: 0x04009701 RID: 38657
		PerfqueryCounterDataFloatIntel,
		// Token: 0x04009702 RID: 38658
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x04009703 RID: 38659
		PerfqueryCounterDataBool32Intel,
		// Token: 0x04009704 RID: 38660
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x04009705 RID: 38661
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x04009706 RID: 38662
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x04009707 RID: 38663
		PerfqueryGpaExtendedCountersIntel,
		// Token: 0x04009708 RID: 38664
		AllAttribBits = -1,
		// Token: 0x04009709 RID: 38665
		AllBarrierBits = -1,
		// Token: 0x0400970A RID: 38666
		AllBarrierBitsExt = -1,
		// Token: 0x0400970B RID: 38667
		AllShaderBits = -1,
		// Token: 0x0400970C RID: 38668
		AllShaderBitsExt = -1,
		// Token: 0x0400970D RID: 38669
		ClientAllAttribBits = -1,
		// Token: 0x0400970E RID: 38670
		QueryAllEventBitsAmd = -1,
		// Token: 0x0400970F RID: 38671
		TimeoutIgnoredApple = -1,
		// Token: 0x04009710 RID: 38672
		LayoutLinearIntel = 1,
		// Token: 0x04009711 RID: 38673
		One = 1,
		// Token: 0x04009712 RID: 38674
		True = 1,
		// Token: 0x04009713 RID: 38675
		LayoutLinearCpuCachedIntel
	}
}
