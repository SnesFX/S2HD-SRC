using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020001C8 RID: 456
	public enum All
	{
		// Token: 0x040012DC RID: 4828
		False,
		// Token: 0x040012DD RID: 4829
		LayoutDefaultIntel = 0,
		// Token: 0x040012DE RID: 4830
		NoError = 0,
		// Token: 0x040012DF RID: 4831
		None = 0,
		// Token: 0x040012E0 RID: 4832
		NoneOes = 0,
		// Token: 0x040012E1 RID: 4833
		Zero = 0,
		// Token: 0x040012E2 RID: 4834
		ClosePathNv = 0,
		// Token: 0x040012E3 RID: 4835
		Points = 0,
		// Token: 0x040012E4 RID: 4836
		PerfquerySingleContextIntel = 0,
		// Token: 0x040012E5 RID: 4837
		ClientPixelStoreBit,
		// Token: 0x040012E6 RID: 4838
		ContextCoreProfileBit = 1,
		// Token: 0x040012E7 RID: 4839
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x040012E8 RID: 4840
		CurrentBit = 1,
		// Token: 0x040012E9 RID: 4841
		Gl2XBitAti = 1,
		// Token: 0x040012EA RID: 4842
		PerfqueryGlobalContextIntel = 1,
		// Token: 0x040012EB RID: 4843
		QueryDepthPassEventBitAmd = 1,
		// Token: 0x040012EC RID: 4844
		RedBitAti = 1,
		// Token: 0x040012ED RID: 4845
		SyncFlushCommandsBit = 1,
		// Token: 0x040012EE RID: 4846
		TextureDeformationBitSgix = 1,
		// Token: 0x040012EF RID: 4847
		TextureStorageSparseBitAmd = 1,
		// Token: 0x040012F0 RID: 4848
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x040012F1 RID: 4849
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x040012F2 RID: 4850
		VertexShaderBit = 1,
		// Token: 0x040012F3 RID: 4851
		VertexShaderBitExt = 1,
		// Token: 0x040012F4 RID: 4852
		ClientVertexArrayBit,
		// Token: 0x040012F5 RID: 4853
		CompBitAti = 2,
		// Token: 0x040012F6 RID: 4854
		ContextCompatibilityProfileBit = 2,
		// Token: 0x040012F7 RID: 4855
		ContextFlagDebugBit = 2,
		// Token: 0x040012F8 RID: 4856
		ContextFlagDebugBitKhr = 2,
		// Token: 0x040012F9 RID: 4857
		ElementArrayBarrierBit = 2,
		// Token: 0x040012FA RID: 4858
		ElementArrayBarrierBitExt = 2,
		// Token: 0x040012FB RID: 4859
		FragmentShaderBit = 2,
		// Token: 0x040012FC RID: 4860
		FragmentShaderBitExt = 2,
		// Token: 0x040012FD RID: 4861
		GeometryDeformationBitSgix = 2,
		// Token: 0x040012FE RID: 4862
		Gl4XBitAti = 2,
		// Token: 0x040012FF RID: 4863
		GreenBitAti = 2,
		// Token: 0x04001300 RID: 4864
		PointBit = 2,
		// Token: 0x04001301 RID: 4865
		QueryDepthFailEventBitAmd = 2,
		// Token: 0x04001302 RID: 4866
		BlueBitAti = 4,
		// Token: 0x04001303 RID: 4867
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x04001304 RID: 4868
		GeometryShaderBit = 4,
		// Token: 0x04001305 RID: 4869
		GeometryShaderBitExt = 4,
		// Token: 0x04001306 RID: 4870
		Gl8XBitAti = 4,
		// Token: 0x04001307 RID: 4871
		LineBit = 4,
		// Token: 0x04001308 RID: 4872
		NegateBitAti = 4,
		// Token: 0x04001309 RID: 4873
		QueryStencilFailEventBitAmd = 4,
		// Token: 0x0400130A RID: 4874
		UniformBarrierBit = 4,
		// Token: 0x0400130B RID: 4875
		UniformBarrierBitExt = 4,
		// Token: 0x0400130C RID: 4876
		Vertex23BitPgi = 4,
		// Token: 0x0400130D RID: 4877
		BiasBitAti = 8,
		// Token: 0x0400130E RID: 4878
		HalfBitAti = 8,
		// Token: 0x0400130F RID: 4879
		PolygonBit = 8,
		// Token: 0x04001310 RID: 4880
		QueryDepthBoundsFailEventBitAmd = 8,
		// Token: 0x04001311 RID: 4881
		TessControlShaderBit = 8,
		// Token: 0x04001312 RID: 4882
		TessControlShaderBitExt = 8,
		// Token: 0x04001313 RID: 4883
		TextureFetchBarrierBit = 8,
		// Token: 0x04001314 RID: 4884
		TextureFetchBarrierBitExt = 8,
		// Token: 0x04001315 RID: 4885
		Vertex4BitPgi = 8,
		// Token: 0x04001316 RID: 4886
		PolygonStippleBit = 16,
		// Token: 0x04001317 RID: 4887
		QuarterBitAti = 16,
		// Token: 0x04001318 RID: 4888
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x04001319 RID: 4889
		TessEvaluationShaderBit = 16,
		// Token: 0x0400131A RID: 4890
		TessEvaluationShaderBitExt = 16,
		// Token: 0x0400131B RID: 4891
		ComputeShaderBit = 32,
		// Token: 0x0400131C RID: 4892
		EighthBitAti = 32,
		// Token: 0x0400131D RID: 4893
		PixelModeBit = 32,
		// Token: 0x0400131E RID: 4894
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x0400131F RID: 4895
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04001320 RID: 4896
		CommandBarrierBit = 64,
		// Token: 0x04001321 RID: 4897
		CommandBarrierBitExt = 64,
		// Token: 0x04001322 RID: 4898
		LightingBit = 64,
		// Token: 0x04001323 RID: 4899
		SaturateBitAti = 64,
		// Token: 0x04001324 RID: 4900
		FogBit = 128,
		// Token: 0x04001325 RID: 4901
		PixelBufferBarrierBit = 128,
		// Token: 0x04001326 RID: 4902
		PixelBufferBarrierBitExt = 128,
		// Token: 0x04001327 RID: 4903
		DepthBufferBit = 256,
		// Token: 0x04001328 RID: 4904
		TextureUpdateBarrierBit = 256,
		// Token: 0x04001329 RID: 4905
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400132A RID: 4906
		AccumBufferBit = 512,
		// Token: 0x0400132B RID: 4907
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400132C RID: 4908
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x0400132D RID: 4909
		FramebufferBarrierBit = 1024,
		// Token: 0x0400132E RID: 4910
		FramebufferBarrierBitExt = 1024,
		// Token: 0x0400132F RID: 4911
		StencilBufferBit = 1024,
		// Token: 0x04001330 RID: 4912
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04001331 RID: 4913
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x04001332 RID: 4914
		ViewportBit = 2048,
		// Token: 0x04001333 RID: 4915
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04001334 RID: 4916
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x04001335 RID: 4917
		TransformBit = 4096,
		// Token: 0x04001336 RID: 4918
		EnableBit = 8192,
		// Token: 0x04001337 RID: 4919
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04001338 RID: 4920
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04001339 RID: 4921
		ColorBufferBit = 16384,
		// Token: 0x0400133A RID: 4922
		CoverageBufferBitNv = 32768,
		// Token: 0x0400133B RID: 4923
		HintBit = 32768,
		// Token: 0x0400133C RID: 4924
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400133D RID: 4925
		Lines = 1,
		// Token: 0x0400133E RID: 4926
		MapReadBit = 1,
		// Token: 0x0400133F RID: 4927
		MapReadBitExt = 1,
		// Token: 0x04001340 RID: 4928
		RestartSun = 1,
		// Token: 0x04001341 RID: 4929
		Color3BitPgi = 65536,
		// Token: 0x04001342 RID: 4930
		EvalBit = 65536,
		// Token: 0x04001343 RID: 4931
		FontXMinBoundsBitNv = 65536,
		// Token: 0x04001344 RID: 4932
		LineLoop = 2,
		// Token: 0x04001345 RID: 4933
		MapWriteBit = 2,
		// Token: 0x04001346 RID: 4934
		MapWriteBitExt = 2,
		// Token: 0x04001347 RID: 4935
		ReplaceMiddleSun = 2,
		// Token: 0x04001348 RID: 4936
		Color4BitPgi = 131072,
		// Token: 0x04001349 RID: 4937
		FontYMinBoundsBitNv = 131072,
		// Token: 0x0400134A RID: 4938
		ListBit = 131072,
		// Token: 0x0400134B RID: 4939
		LineStrip = 3,
		// Token: 0x0400134C RID: 4940
		ReplaceOldestSun = 3,
		// Token: 0x0400134D RID: 4941
		MapInvalidateRangeBit,
		// Token: 0x0400134E RID: 4942
		MapInvalidateRangeBitExt = 4,
		// Token: 0x0400134F RID: 4943
		Triangles = 4,
		// Token: 0x04001350 RID: 4944
		EdgeflagBitPgi = 262144,
		// Token: 0x04001351 RID: 4945
		FontXMaxBoundsBitNv = 262144,
		// Token: 0x04001352 RID: 4946
		TextureBit = 262144,
		// Token: 0x04001353 RID: 4947
		TriangleStrip = 5,
		// Token: 0x04001354 RID: 4948
		TriangleFan,
		// Token: 0x04001355 RID: 4949
		Quads,
		// Token: 0x04001356 RID: 4950
		QuadsExt = 7,
		// Token: 0x04001357 RID: 4951
		MapInvalidateBufferBit,
		// Token: 0x04001358 RID: 4952
		MapInvalidateBufferBitExt = 8,
		// Token: 0x04001359 RID: 4953
		QuadStrip = 8,
		// Token: 0x0400135A RID: 4954
		FontYMaxBoundsBitNv = 524288,
		// Token: 0x0400135B RID: 4955
		IndexBitPgi = 524288,
		// Token: 0x0400135C RID: 4956
		ScissorBit = 524288,
		// Token: 0x0400135D RID: 4957
		Polygon = 9,
		// Token: 0x0400135E RID: 4958
		LinesAdjacency,
		// Token: 0x0400135F RID: 4959
		LinesAdjacencyArb = 10,
		// Token: 0x04001360 RID: 4960
		LinesAdjacencyExt = 10,
		// Token: 0x04001361 RID: 4961
		LineStripAdjacency,
		// Token: 0x04001362 RID: 4962
		LineStripAdjacencyArb = 11,
		// Token: 0x04001363 RID: 4963
		LineStripAdjacencyExt = 11,
		// Token: 0x04001364 RID: 4964
		TrianglesAdjacency,
		// Token: 0x04001365 RID: 4965
		TrianglesAdjacencyArb = 12,
		// Token: 0x04001366 RID: 4966
		TrianglesAdjacencyExt = 12,
		// Token: 0x04001367 RID: 4967
		TriangleStripAdjacency,
		// Token: 0x04001368 RID: 4968
		TriangleStripAdjacencyArb = 13,
		// Token: 0x04001369 RID: 4969
		TriangleStripAdjacencyExt = 13,
		// Token: 0x0400136A RID: 4970
		Patches,
		// Token: 0x0400136B RID: 4971
		PatchesExt = 14,
		// Token: 0x0400136C RID: 4972
		MapFlushExplicitBit = 16,
		// Token: 0x0400136D RID: 4973
		MapFlushExplicitBitExt = 16,
		// Token: 0x0400136E RID: 4974
		FontUnitsPerEmBitNv = 1048576,
		// Token: 0x0400136F RID: 4975
		MatAmbientBitPgi = 1048576,
		// Token: 0x04001370 RID: 4976
		MapUnsynchronizedBit = 32,
		// Token: 0x04001371 RID: 4977
		MapUnsynchronizedBitExt = 32,
		// Token: 0x04001372 RID: 4978
		FontAscenderBitNv = 2097152,
		// Token: 0x04001373 RID: 4979
		MatAmbientAndDiffuseBitPgi = 2097152,
		// Token: 0x04001374 RID: 4980
		MapPersistentBit = 64,
		// Token: 0x04001375 RID: 4981
		FontDescenderBitNv = 4194304,
		// Token: 0x04001376 RID: 4982
		MatDiffuseBitPgi = 4194304,
		// Token: 0x04001377 RID: 4983
		MapCoherentBit = 128,
		// Token: 0x04001378 RID: 4984
		FontHeightBitNv = 8388608,
		// Token: 0x04001379 RID: 4985
		MatEmissionBitPgi = 8388608,
		// Token: 0x0400137A RID: 4986
		BoldBitNv = 1,
		// Token: 0x0400137B RID: 4987
		GlyphWidthBitNv = 1,
		// Token: 0x0400137C RID: 4988
		Accum = 256,
		// Token: 0x0400137D RID: 4989
		DynamicStorageBit = 256,
		// Token: 0x0400137E RID: 4990
		FontMaxAdvanceWidthBitNv = 16777216,
		// Token: 0x0400137F RID: 4991
		MatColorIndexesBitPgi = 16777216,
		// Token: 0x04001380 RID: 4992
		Load = 257,
		// Token: 0x04001381 RID: 4993
		Return,
		// Token: 0x04001382 RID: 4994
		Mult,
		// Token: 0x04001383 RID: 4995
		Add,
		// Token: 0x04001384 RID: 4996
		GlyphHeightBitNv = 2,
		// Token: 0x04001385 RID: 4997
		ItalicBitNv = 2,
		// Token: 0x04001386 RID: 4998
		MoveToNv = 2,
		// Token: 0x04001387 RID: 4999
		ClientStorageBit = 512,
		// Token: 0x04001388 RID: 5000
		Never = 512,
		// Token: 0x04001389 RID: 5001
		FontMaxAdvanceHeightBitNv = 33554432,
		// Token: 0x0400138A RID: 5002
		MatShininessBitPgi = 33554432,
		// Token: 0x0400138B RID: 5003
		Less = 513,
		// Token: 0x0400138C RID: 5004
		Equal,
		// Token: 0x0400138D RID: 5005
		Lequal,
		// Token: 0x0400138E RID: 5006
		Greater,
		// Token: 0x0400138F RID: 5007
		Notequal,
		// Token: 0x04001390 RID: 5008
		Gequal,
		// Token: 0x04001391 RID: 5009
		Always,
		// Token: 0x04001392 RID: 5010
		RelativeMoveToNv = 3,
		// Token: 0x04001393 RID: 5011
		SrcColor = 768,
		// Token: 0x04001394 RID: 5012
		OneMinusSrcColor,
		// Token: 0x04001395 RID: 5013
		SrcAlpha,
		// Token: 0x04001396 RID: 5014
		OneMinusSrcAlpha,
		// Token: 0x04001397 RID: 5015
		DstAlpha,
		// Token: 0x04001398 RID: 5016
		OneMinusDstAlpha,
		// Token: 0x04001399 RID: 5017
		DstColor,
		// Token: 0x0400139A RID: 5018
		OneMinusDstColor,
		// Token: 0x0400139B RID: 5019
		SrcAlphaSaturate,
		// Token: 0x0400139C RID: 5020
		GlyphHorizontalBearingXBitNv = 4,
		// Token: 0x0400139D RID: 5021
		LineToNv = 4,
		// Token: 0x0400139E RID: 5022
		FrontLeft = 1024,
		// Token: 0x0400139F RID: 5023
		FontUnderlinePositionBitNv = 67108864,
		// Token: 0x040013A0 RID: 5024
		MatSpecularBitPgi = 67108864,
		// Token: 0x040013A1 RID: 5025
		FrontRight = 1025,
		// Token: 0x040013A2 RID: 5026
		BackLeft,
		// Token: 0x040013A3 RID: 5027
		BackRight,
		// Token: 0x040013A4 RID: 5028
		Front,
		// Token: 0x040013A5 RID: 5029
		Back,
		// Token: 0x040013A6 RID: 5030
		Left,
		// Token: 0x040013A7 RID: 5031
		Right,
		// Token: 0x040013A8 RID: 5032
		FrontAndBack,
		// Token: 0x040013A9 RID: 5033
		Aux0,
		// Token: 0x040013AA RID: 5034
		Aux1,
		// Token: 0x040013AB RID: 5035
		Aux2,
		// Token: 0x040013AC RID: 5036
		Aux3,
		// Token: 0x040013AD RID: 5037
		RelativeLineToNv = 5,
		// Token: 0x040013AE RID: 5038
		InvalidEnum = 1280,
		// Token: 0x040013AF RID: 5039
		InvalidValue,
		// Token: 0x040013B0 RID: 5040
		InvalidOperation,
		// Token: 0x040013B1 RID: 5041
		StackOverflow,
		// Token: 0x040013B2 RID: 5042
		StackOverflowKhr = 1283,
		// Token: 0x040013B3 RID: 5043
		StackUnderflow,
		// Token: 0x040013B4 RID: 5044
		StackUnderflowKhr = 1284,
		// Token: 0x040013B5 RID: 5045
		OutOfMemory,
		// Token: 0x040013B6 RID: 5046
		InvalidFramebufferOperation,
		// Token: 0x040013B7 RID: 5047
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x040013B8 RID: 5048
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x040013B9 RID: 5049
		HorizontalLineToNv = 6,
		// Token: 0x040013BA RID: 5050
		Gl2D = 1536,
		// Token: 0x040013BB RID: 5051
		Gl3D,
		// Token: 0x040013BC RID: 5052
		Gl3DColor,
		// Token: 0x040013BD RID: 5053
		Gl3DColorTexture,
		// Token: 0x040013BE RID: 5054
		Gl4DColorTexture,
		// Token: 0x040013BF RID: 5055
		RelativeHorizontalLineToNv = 7,
		// Token: 0x040013C0 RID: 5056
		PassThroughToken = 1792,
		// Token: 0x040013C1 RID: 5057
		PointToken,
		// Token: 0x040013C2 RID: 5058
		LineToken,
		// Token: 0x040013C3 RID: 5059
		PolygonToken,
		// Token: 0x040013C4 RID: 5060
		BitmapToken,
		// Token: 0x040013C5 RID: 5061
		DrawPixelToken,
		// Token: 0x040013C6 RID: 5062
		CopyPixelToken,
		// Token: 0x040013C7 RID: 5063
		LineResetToken,
		// Token: 0x040013C8 RID: 5064
		GlyphHorizontalBearingYBitNv = 8,
		// Token: 0x040013C9 RID: 5065
		VerticalLineToNv = 8,
		// Token: 0x040013CA RID: 5066
		Exp = 2048,
		// Token: 0x040013CB RID: 5067
		FontUnderlineThicknessBitNv = 134217728,
		// Token: 0x040013CC RID: 5068
		NormalBitPgi = 134217728,
		// Token: 0x040013CD RID: 5069
		Exp2 = 2049,
		// Token: 0x040013CE RID: 5070
		RelativeVerticalLineToNv = 9,
		// Token: 0x040013CF RID: 5071
		Cw = 2304,
		// Token: 0x040013D0 RID: 5072
		Ccw,
		// Token: 0x040013D1 RID: 5073
		QuadraticCurveToNv = 10,
		// Token: 0x040013D2 RID: 5074
		Coeff = 2560,
		// Token: 0x040013D3 RID: 5075
		Order,
		// Token: 0x040013D4 RID: 5076
		Domain,
		// Token: 0x040013D5 RID: 5077
		RelativeQuadraticCurveToNv = 11,
		// Token: 0x040013D6 RID: 5078
		CurrentColor = 2816,
		// Token: 0x040013D7 RID: 5079
		CurrentIndex,
		// Token: 0x040013D8 RID: 5080
		CurrentNormal,
		// Token: 0x040013D9 RID: 5081
		CurrentTextureCoords,
		// Token: 0x040013DA RID: 5082
		CurrentRasterColor,
		// Token: 0x040013DB RID: 5083
		CurrentRasterIndex,
		// Token: 0x040013DC RID: 5084
		CurrentRasterTextureCoords,
		// Token: 0x040013DD RID: 5085
		CurrentRasterPosition,
		// Token: 0x040013DE RID: 5086
		CurrentRasterPositionValid,
		// Token: 0x040013DF RID: 5087
		CurrentRasterDistance,
		// Token: 0x040013E0 RID: 5088
		PointSmooth = 2832,
		// Token: 0x040013E1 RID: 5089
		PointSize,
		// Token: 0x040013E2 RID: 5090
		PointSizeRange,
		// Token: 0x040013E3 RID: 5091
		SmoothPointSizeRange = 2834,
		// Token: 0x040013E4 RID: 5092
		PointSizeGranularity,
		// Token: 0x040013E5 RID: 5093
		SmoothPointSizeGranularity = 2835,
		// Token: 0x040013E6 RID: 5094
		LineSmooth = 2848,
		// Token: 0x040013E7 RID: 5095
		LineWidth,
		// Token: 0x040013E8 RID: 5096
		LineWidthRange,
		// Token: 0x040013E9 RID: 5097
		SmoothLineWidthRange = 2850,
		// Token: 0x040013EA RID: 5098
		LineWidthGranularity,
		// Token: 0x040013EB RID: 5099
		SmoothLineWidthGranularity = 2851,
		// Token: 0x040013EC RID: 5100
		LineStipple,
		// Token: 0x040013ED RID: 5101
		LineStipplePattern,
		// Token: 0x040013EE RID: 5102
		LineStippleRepeat,
		// Token: 0x040013EF RID: 5103
		ListMode = 2864,
		// Token: 0x040013F0 RID: 5104
		MaxListNesting,
		// Token: 0x040013F1 RID: 5105
		ListBase,
		// Token: 0x040013F2 RID: 5106
		ListIndex,
		// Token: 0x040013F3 RID: 5107
		PolygonMode = 2880,
		// Token: 0x040013F4 RID: 5108
		PolygonSmooth,
		// Token: 0x040013F5 RID: 5109
		PolygonStipple,
		// Token: 0x040013F6 RID: 5110
		EdgeFlag,
		// Token: 0x040013F7 RID: 5111
		CullFace,
		// Token: 0x040013F8 RID: 5112
		CullFaceMode,
		// Token: 0x040013F9 RID: 5113
		FrontFace,
		// Token: 0x040013FA RID: 5114
		Lighting = 2896,
		// Token: 0x040013FB RID: 5115
		LightModelLocalViewer,
		// Token: 0x040013FC RID: 5116
		LightModelTwoSide,
		// Token: 0x040013FD RID: 5117
		LightModelAmbient,
		// Token: 0x040013FE RID: 5118
		ShadeModel,
		// Token: 0x040013FF RID: 5119
		ColorMaterialFace,
		// Token: 0x04001400 RID: 5120
		ColorMaterialParameter,
		// Token: 0x04001401 RID: 5121
		ColorMaterial,
		// Token: 0x04001402 RID: 5122
		Fog = 2912,
		// Token: 0x04001403 RID: 5123
		FogIndex,
		// Token: 0x04001404 RID: 5124
		FogDensity,
		// Token: 0x04001405 RID: 5125
		FogStart,
		// Token: 0x04001406 RID: 5126
		FogEnd,
		// Token: 0x04001407 RID: 5127
		FogMode,
		// Token: 0x04001408 RID: 5128
		FogColor,
		// Token: 0x04001409 RID: 5129
		DepthRange = 2928,
		// Token: 0x0400140A RID: 5130
		DepthTest,
		// Token: 0x0400140B RID: 5131
		DepthWritemask,
		// Token: 0x0400140C RID: 5132
		DepthClearValue,
		// Token: 0x0400140D RID: 5133
		DepthFunc,
		// Token: 0x0400140E RID: 5134
		AccumClearValue = 2944,
		// Token: 0x0400140F RID: 5135
		StencilTest = 2960,
		// Token: 0x04001410 RID: 5136
		StencilClearValue,
		// Token: 0x04001411 RID: 5137
		StencilFunc,
		// Token: 0x04001412 RID: 5138
		StencilValueMask,
		// Token: 0x04001413 RID: 5139
		StencilFail,
		// Token: 0x04001414 RID: 5140
		StencilPassDepthFail,
		// Token: 0x04001415 RID: 5141
		StencilPassDepthPass,
		// Token: 0x04001416 RID: 5142
		StencilRef,
		// Token: 0x04001417 RID: 5143
		StencilWritemask,
		// Token: 0x04001418 RID: 5144
		MatrixMode = 2976,
		// Token: 0x04001419 RID: 5145
		Normalize,
		// Token: 0x0400141A RID: 5146
		Viewport,
		// Token: 0x0400141B RID: 5147
		Modelview0StackDepthExt,
		// Token: 0x0400141C RID: 5148
		ModelviewStackDepth = 2979,
		// Token: 0x0400141D RID: 5149
		ProjectionStackDepth,
		// Token: 0x0400141E RID: 5150
		TextureStackDepth,
		// Token: 0x0400141F RID: 5151
		Modelview0MatrixExt,
		// Token: 0x04001420 RID: 5152
		ModelviewMatrix = 2982,
		// Token: 0x04001421 RID: 5153
		ProjectionMatrix,
		// Token: 0x04001422 RID: 5154
		TextureMatrix,
		// Token: 0x04001423 RID: 5155
		AttribStackDepth = 2992,
		// Token: 0x04001424 RID: 5156
		ClientAttribStackDepth,
		// Token: 0x04001425 RID: 5157
		AlphaTest = 3008,
		// Token: 0x04001426 RID: 5158
		AlphaTestQcom = 3008,
		// Token: 0x04001427 RID: 5159
		AlphaTestFunc,
		// Token: 0x04001428 RID: 5160
		AlphaTestFuncQcom = 3009,
		// Token: 0x04001429 RID: 5161
		AlphaTestRef,
		// Token: 0x0400142A RID: 5162
		AlphaTestRefQcom = 3010,
		// Token: 0x0400142B RID: 5163
		Dither = 3024,
		// Token: 0x0400142C RID: 5164
		BlendDst = 3040,
		// Token: 0x0400142D RID: 5165
		BlendSrc,
		// Token: 0x0400142E RID: 5166
		Blend,
		// Token: 0x0400142F RID: 5167
		LogicOpMode = 3056,
		// Token: 0x04001430 RID: 5168
		IndexLogicOp,
		// Token: 0x04001431 RID: 5169
		LogicOp = 3057,
		// Token: 0x04001432 RID: 5170
		ColorLogicOp,
		// Token: 0x04001433 RID: 5171
		CubicCurveToNv = 12,
		// Token: 0x04001434 RID: 5172
		AuxBuffers = 3072,
		// Token: 0x04001435 RID: 5173
		DrawBuffer,
		// Token: 0x04001436 RID: 5174
		DrawBufferExt = 3073,
		// Token: 0x04001437 RID: 5175
		ReadBuffer,
		// Token: 0x04001438 RID: 5176
		ReadBufferExt = 3074,
		// Token: 0x04001439 RID: 5177
		ReadBufferNv = 3074,
		// Token: 0x0400143A RID: 5178
		ScissorBox = 3088,
		// Token: 0x0400143B RID: 5179
		ScissorTest,
		// Token: 0x0400143C RID: 5180
		IndexClearValue = 3104,
		// Token: 0x0400143D RID: 5181
		IndexWritemask,
		// Token: 0x0400143E RID: 5182
		ColorClearValue,
		// Token: 0x0400143F RID: 5183
		ColorWritemask,
		// Token: 0x04001440 RID: 5184
		IndexMode = 3120,
		// Token: 0x04001441 RID: 5185
		RgbaMode,
		// Token: 0x04001442 RID: 5186
		Doublebuffer,
		// Token: 0x04001443 RID: 5187
		Stereo,
		// Token: 0x04001444 RID: 5188
		RenderMode = 3136,
		// Token: 0x04001445 RID: 5189
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04001446 RID: 5190
		PointSmoothHint,
		// Token: 0x04001447 RID: 5191
		LineSmoothHint,
		// Token: 0x04001448 RID: 5192
		PolygonSmoothHint,
		// Token: 0x04001449 RID: 5193
		FogHint,
		// Token: 0x0400144A RID: 5194
		TextureGenS = 3168,
		// Token: 0x0400144B RID: 5195
		TextureGenT,
		// Token: 0x0400144C RID: 5196
		TextureGenR,
		// Token: 0x0400144D RID: 5197
		TextureGenQ,
		// Token: 0x0400144E RID: 5198
		PixelMapIToI = 3184,
		// Token: 0x0400144F RID: 5199
		PixelMapSToS,
		// Token: 0x04001450 RID: 5200
		PixelMapIToR,
		// Token: 0x04001451 RID: 5201
		PixelMapIToG,
		// Token: 0x04001452 RID: 5202
		PixelMapIToB,
		// Token: 0x04001453 RID: 5203
		PixelMapIToA,
		// Token: 0x04001454 RID: 5204
		PixelMapRToR,
		// Token: 0x04001455 RID: 5205
		PixelMapGToG,
		// Token: 0x04001456 RID: 5206
		PixelMapBToB,
		// Token: 0x04001457 RID: 5207
		PixelMapAToA,
		// Token: 0x04001458 RID: 5208
		PixelMapIToISize = 3248,
		// Token: 0x04001459 RID: 5209
		PixelMapSToSSize,
		// Token: 0x0400145A RID: 5210
		PixelMapIToRSize,
		// Token: 0x0400145B RID: 5211
		PixelMapIToGSize,
		// Token: 0x0400145C RID: 5212
		PixelMapIToBSize,
		// Token: 0x0400145D RID: 5213
		PixelMapIToASize,
		// Token: 0x0400145E RID: 5214
		PixelMapRToRSize,
		// Token: 0x0400145F RID: 5215
		PixelMapGToGSize,
		// Token: 0x04001460 RID: 5216
		PixelMapBToBSize,
		// Token: 0x04001461 RID: 5217
		PixelMapAToASize,
		// Token: 0x04001462 RID: 5218
		UnpackSwapBytes = 3312,
		// Token: 0x04001463 RID: 5219
		UnpackLsbFirst,
		// Token: 0x04001464 RID: 5220
		UnpackRowLength,
		// Token: 0x04001465 RID: 5221
		UnpackRowLengthExt = 3314,
		// Token: 0x04001466 RID: 5222
		UnpackSkipRows,
		// Token: 0x04001467 RID: 5223
		UnpackSkipRowsExt = 3315,
		// Token: 0x04001468 RID: 5224
		UnpackSkipPixels,
		// Token: 0x04001469 RID: 5225
		UnpackSkipPixelsExt = 3316,
		// Token: 0x0400146A RID: 5226
		UnpackAlignment,
		// Token: 0x0400146B RID: 5227
		RelativeCubicCurveToNv = 13,
		// Token: 0x0400146C RID: 5228
		PackSwapBytes = 3328,
		// Token: 0x0400146D RID: 5229
		PackLsbFirst,
		// Token: 0x0400146E RID: 5230
		PackRowLength,
		// Token: 0x0400146F RID: 5231
		PackSkipRows,
		// Token: 0x04001470 RID: 5232
		PackSkipPixels,
		// Token: 0x04001471 RID: 5233
		PackAlignment,
		// Token: 0x04001472 RID: 5234
		MapColor = 3344,
		// Token: 0x04001473 RID: 5235
		MapStencil,
		// Token: 0x04001474 RID: 5236
		IndexShift,
		// Token: 0x04001475 RID: 5237
		IndexOffset,
		// Token: 0x04001476 RID: 5238
		RedScale,
		// Token: 0x04001477 RID: 5239
		RedBias,
		// Token: 0x04001478 RID: 5240
		ZoomX,
		// Token: 0x04001479 RID: 5241
		ZoomY,
		// Token: 0x0400147A RID: 5242
		GreenScale,
		// Token: 0x0400147B RID: 5243
		GreenBias,
		// Token: 0x0400147C RID: 5244
		BlueScale,
		// Token: 0x0400147D RID: 5245
		BlueBias,
		// Token: 0x0400147E RID: 5246
		AlphaScale,
		// Token: 0x0400147F RID: 5247
		AlphaBias,
		// Token: 0x04001480 RID: 5248
		DepthScale,
		// Token: 0x04001481 RID: 5249
		DepthBias,
		// Token: 0x04001482 RID: 5250
		MaxEvalOrder = 3376,
		// Token: 0x04001483 RID: 5251
		MaxLights,
		// Token: 0x04001484 RID: 5252
		MaxClipDistances,
		// Token: 0x04001485 RID: 5253
		MaxClipPlanes = 3378,
		// Token: 0x04001486 RID: 5254
		MaxTextureSize,
		// Token: 0x04001487 RID: 5255
		MaxPixelMapTable,
		// Token: 0x04001488 RID: 5256
		MaxAttribStackDepth,
		// Token: 0x04001489 RID: 5257
		MaxModelviewStackDepth,
		// Token: 0x0400148A RID: 5258
		MaxNameStackDepth,
		// Token: 0x0400148B RID: 5259
		MaxProjectionStackDepth,
		// Token: 0x0400148C RID: 5260
		MaxTextureStackDepth,
		// Token: 0x0400148D RID: 5261
		MaxViewportDims,
		// Token: 0x0400148E RID: 5262
		MaxClientAttribStackDepth,
		// Token: 0x0400148F RID: 5263
		SubpixelBits = 3408,
		// Token: 0x04001490 RID: 5264
		IndexBits,
		// Token: 0x04001491 RID: 5265
		RedBits,
		// Token: 0x04001492 RID: 5266
		GreenBits,
		// Token: 0x04001493 RID: 5267
		BlueBits,
		// Token: 0x04001494 RID: 5268
		AlphaBits,
		// Token: 0x04001495 RID: 5269
		DepthBits,
		// Token: 0x04001496 RID: 5270
		StencilBits,
		// Token: 0x04001497 RID: 5271
		AccumRedBits,
		// Token: 0x04001498 RID: 5272
		AccumGreenBits,
		// Token: 0x04001499 RID: 5273
		AccumBlueBits,
		// Token: 0x0400149A RID: 5274
		AccumAlphaBits,
		// Token: 0x0400149B RID: 5275
		NameStackDepth = 3440,
		// Token: 0x0400149C RID: 5276
		AutoNormal = 3456,
		// Token: 0x0400149D RID: 5277
		Map1Color4 = 3472,
		// Token: 0x0400149E RID: 5278
		Map1Index,
		// Token: 0x0400149F RID: 5279
		Map1Normal,
		// Token: 0x040014A0 RID: 5280
		Map1TextureCoord1,
		// Token: 0x040014A1 RID: 5281
		Map1TextureCoord2,
		// Token: 0x040014A2 RID: 5282
		Map1TextureCoord3,
		// Token: 0x040014A3 RID: 5283
		Map1TextureCoord4,
		// Token: 0x040014A4 RID: 5284
		Map1Vertex3,
		// Token: 0x040014A5 RID: 5285
		Map1Vertex4,
		// Token: 0x040014A6 RID: 5286
		Map2Color4 = 3504,
		// Token: 0x040014A7 RID: 5287
		Map2Index,
		// Token: 0x040014A8 RID: 5288
		Map2Normal,
		// Token: 0x040014A9 RID: 5289
		Map2TextureCoord1,
		// Token: 0x040014AA RID: 5290
		Map2TextureCoord2,
		// Token: 0x040014AB RID: 5291
		Map2TextureCoord3,
		// Token: 0x040014AC RID: 5292
		Map2TextureCoord4,
		// Token: 0x040014AD RID: 5293
		Map2Vertex3,
		// Token: 0x040014AE RID: 5294
		Map2Vertex4,
		// Token: 0x040014AF RID: 5295
		Map1GridDomain = 3536,
		// Token: 0x040014B0 RID: 5296
		Map1GridSegments,
		// Token: 0x040014B1 RID: 5297
		Map2GridDomain,
		// Token: 0x040014B2 RID: 5298
		Map2GridSegments,
		// Token: 0x040014B3 RID: 5299
		Texture1D = 3552,
		// Token: 0x040014B4 RID: 5300
		Texture2D,
		// Token: 0x040014B5 RID: 5301
		FeedbackBufferPointer = 3568,
		// Token: 0x040014B6 RID: 5302
		FeedbackBufferSize,
		// Token: 0x040014B7 RID: 5303
		FeedbackBufferType,
		// Token: 0x040014B8 RID: 5304
		SelectionBufferPointer,
		// Token: 0x040014B9 RID: 5305
		SelectionBufferSize,
		// Token: 0x040014BA RID: 5306
		SmoothQuadraticCurveToNv = 14,
		// Token: 0x040014BB RID: 5307
		RelativeSmoothQuadraticCurveToNv,
		// Token: 0x040014BC RID: 5308
		GlyphHorizontalBearingAdvanceBitNv,
		// Token: 0x040014BD RID: 5309
		SmoothCubicCurveToNv = 16,
		// Token: 0x040014BE RID: 5310
		GlyphHasKerningBitNv = 256,
		// Token: 0x040014BF RID: 5311
		TextureWidth = 4096,
		// Token: 0x040014C0 RID: 5312
		FontHasKerningBitNv = 268435456,
		// Token: 0x040014C1 RID: 5313
		Texcoord1BitPgi = 268435456,
		// Token: 0x040014C2 RID: 5314
		TextureHeight = 4097,
		// Token: 0x040014C3 RID: 5315
		TextureComponents = 4099,
		// Token: 0x040014C4 RID: 5316
		TextureInternalFormat = 4099,
		// Token: 0x040014C5 RID: 5317
		TextureBorderColor,
		// Token: 0x040014C6 RID: 5318
		TextureBorderColorNv = 4100,
		// Token: 0x040014C7 RID: 5319
		TextureBorder,
		// Token: 0x040014C8 RID: 5320
		RelativeSmoothCubicCurveToNv = 17,
		// Token: 0x040014C9 RID: 5321
		DontCare = 4352,
		// Token: 0x040014CA RID: 5322
		Fastest,
		// Token: 0x040014CB RID: 5323
		Nicest,
		// Token: 0x040014CC RID: 5324
		SmallCcwArcToNv = 18,
		// Token: 0x040014CD RID: 5325
		Ambient = 4608,
		// Token: 0x040014CE RID: 5326
		Diffuse,
		// Token: 0x040014CF RID: 5327
		Specular,
		// Token: 0x040014D0 RID: 5328
		Position,
		// Token: 0x040014D1 RID: 5329
		SpotDirection,
		// Token: 0x040014D2 RID: 5330
		SpotExponent,
		// Token: 0x040014D3 RID: 5331
		SpotCutoff,
		// Token: 0x040014D4 RID: 5332
		ConstantAttenuation,
		// Token: 0x040014D5 RID: 5333
		LinearAttenuation,
		// Token: 0x040014D6 RID: 5334
		QuadraticAttenuation,
		// Token: 0x040014D7 RID: 5335
		RelativeSmallCcwArcToNv = 19,
		// Token: 0x040014D8 RID: 5336
		Compile = 4864,
		// Token: 0x040014D9 RID: 5337
		CompileAndExecute,
		// Token: 0x040014DA RID: 5338
		SmallCwArcToNv = 20,
		// Token: 0x040014DB RID: 5339
		Byte = 5120,
		// Token: 0x040014DC RID: 5340
		UnsignedByte,
		// Token: 0x040014DD RID: 5341
		Short,
		// Token: 0x040014DE RID: 5342
		UnsignedShort,
		// Token: 0x040014DF RID: 5343
		Int,
		// Token: 0x040014E0 RID: 5344
		UnsignedInt,
		// Token: 0x040014E1 RID: 5345
		Float,
		// Token: 0x040014E2 RID: 5346
		Gl2Bytes,
		// Token: 0x040014E3 RID: 5347
		Gl3Bytes,
		// Token: 0x040014E4 RID: 5348
		Gl4Bytes,
		// Token: 0x040014E5 RID: 5349
		Double,
		// Token: 0x040014E6 RID: 5350
		HalfApple,
		// Token: 0x040014E7 RID: 5351
		HalfFloat = 5131,
		// Token: 0x040014E8 RID: 5352
		HalfFloatArb = 5131,
		// Token: 0x040014E9 RID: 5353
		HalfFloatNv = 5131,
		// Token: 0x040014EA RID: 5354
		Fixed,
		// Token: 0x040014EB RID: 5355
		FixedOes = 5132,
		// Token: 0x040014EC RID: 5356
		Int64Nv = 5134,
		// Token: 0x040014ED RID: 5357
		UnsignedInt64Arb,
		// Token: 0x040014EE RID: 5358
		UnsignedInt64Nv = 5135,
		// Token: 0x040014EF RID: 5359
		RelativeSmallCwArcToNv = 21,
		// Token: 0x040014F0 RID: 5360
		Clear = 5376,
		// Token: 0x040014F1 RID: 5361
		And,
		// Token: 0x040014F2 RID: 5362
		AndReverse,
		// Token: 0x040014F3 RID: 5363
		Copy,
		// Token: 0x040014F4 RID: 5364
		AndInverted,
		// Token: 0x040014F5 RID: 5365
		Noop,
		// Token: 0x040014F6 RID: 5366
		Xor,
		// Token: 0x040014F7 RID: 5367
		XorNv = 5382,
		// Token: 0x040014F8 RID: 5368
		Or,
		// Token: 0x040014F9 RID: 5369
		Nor,
		// Token: 0x040014FA RID: 5370
		Equiv,
		// Token: 0x040014FB RID: 5371
		Invert,
		// Token: 0x040014FC RID: 5372
		OrReverse,
		// Token: 0x040014FD RID: 5373
		CopyInverted,
		// Token: 0x040014FE RID: 5374
		OrInverted,
		// Token: 0x040014FF RID: 5375
		Nand,
		// Token: 0x04001500 RID: 5376
		Set,
		// Token: 0x04001501 RID: 5377
		LargeCcwArcToNv = 22,
		// Token: 0x04001502 RID: 5378
		Emission = 5632,
		// Token: 0x04001503 RID: 5379
		Shininess,
		// Token: 0x04001504 RID: 5380
		AmbientAndDiffuse,
		// Token: 0x04001505 RID: 5381
		ColorIndexes,
		// Token: 0x04001506 RID: 5382
		RelativeLargeCcwArcToNv = 23,
		// Token: 0x04001507 RID: 5383
		Modelview = 5888,
		// Token: 0x04001508 RID: 5384
		Modelview0Arb = 5888,
		// Token: 0x04001509 RID: 5385
		Modelview0Ext = 5888,
		// Token: 0x0400150A RID: 5386
		Projection,
		// Token: 0x0400150B RID: 5387
		Texture,
		// Token: 0x0400150C RID: 5388
		LargeCwArcToNv = 24,
		// Token: 0x0400150D RID: 5389
		Color = 6144,
		// Token: 0x0400150E RID: 5390
		ColorExt = 6144,
		// Token: 0x0400150F RID: 5391
		Depth,
		// Token: 0x04001510 RID: 5392
		DepthExt = 6145,
		// Token: 0x04001511 RID: 5393
		Stencil,
		// Token: 0x04001512 RID: 5394
		StencilExt = 6146,
		// Token: 0x04001513 RID: 5395
		RelativeLargeCwArcToNv = 25,
		// Token: 0x04001514 RID: 5396
		ColorIndex = 6400,
		// Token: 0x04001515 RID: 5397
		StencilIndex,
		// Token: 0x04001516 RID: 5398
		DepthComponent,
		// Token: 0x04001517 RID: 5399
		Red,
		// Token: 0x04001518 RID: 5400
		RedExt = 6403,
		// Token: 0x04001519 RID: 5401
		RedNv = 6403,
		// Token: 0x0400151A RID: 5402
		Green,
		// Token: 0x0400151B RID: 5403
		GreenNv = 6404,
		// Token: 0x0400151C RID: 5404
		Blue,
		// Token: 0x0400151D RID: 5405
		BlueNv = 6405,
		// Token: 0x0400151E RID: 5406
		Alpha,
		// Token: 0x0400151F RID: 5407
		Rgb,
		// Token: 0x04001520 RID: 5408
		Rgba,
		// Token: 0x04001521 RID: 5409
		Luminance,
		// Token: 0x04001522 RID: 5410
		LuminanceAlpha,
		// Token: 0x04001523 RID: 5411
		RasterPositionUnclippedIbm = 103010,
		// Token: 0x04001524 RID: 5412
		Bitmap = 6656,
		// Token: 0x04001525 RID: 5413
		PreferDoublebufferHintPgi = 107000,
		// Token: 0x04001526 RID: 5414
		ConserveMemoryHintPgi = 107005,
		// Token: 0x04001527 RID: 5415
		ReclaimMemoryHintPgi,
		// Token: 0x04001528 RID: 5416
		NativeGraphicsHandlePgi = 107010,
		// Token: 0x04001529 RID: 5417
		NativeGraphicsBeginHintPgi,
		// Token: 0x0400152A RID: 5418
		NativeGraphicsEndHintPgi,
		// Token: 0x0400152B RID: 5419
		AlwaysFastHintPgi = 107020,
		// Token: 0x0400152C RID: 5420
		AlwaysSoftHintPgi,
		// Token: 0x0400152D RID: 5421
		AllowDrawObjHintPgi,
		// Token: 0x0400152E RID: 5422
		AllowDrawWinHintPgi,
		// Token: 0x0400152F RID: 5423
		AllowDrawFrgHintPgi,
		// Token: 0x04001530 RID: 5424
		AllowDrawMemHintPgi,
		// Token: 0x04001531 RID: 5425
		StrictDepthfuncHintPgi = 107030,
		// Token: 0x04001532 RID: 5426
		StrictLightingHintPgi,
		// Token: 0x04001533 RID: 5427
		StrictScissorHintPgi,
		// Token: 0x04001534 RID: 5428
		FullStippleHintPgi,
		// Token: 0x04001535 RID: 5429
		ClipNearHintPgi = 107040,
		// Token: 0x04001536 RID: 5430
		ClipFarHintPgi,
		// Token: 0x04001537 RID: 5431
		WideLineHintPgi,
		// Token: 0x04001538 RID: 5432
		BackNormalsHintPgi,
		// Token: 0x04001539 RID: 5433
		VertexDataHintPgi = 107050,
		// Token: 0x0400153A RID: 5434
		VertexConsistentHintPgi,
		// Token: 0x0400153B RID: 5435
		MaterialSideHintPgi,
		// Token: 0x0400153C RID: 5436
		MaxVertexHintPgi,
		// Token: 0x0400153D RID: 5437
		Point = 6912,
		// Token: 0x0400153E RID: 5438
		Line,
		// Token: 0x0400153F RID: 5439
		Fill,
		// Token: 0x04001540 RID: 5440
		Render = 7168,
		// Token: 0x04001541 RID: 5441
		Feedback,
		// Token: 0x04001542 RID: 5442
		Select,
		// Token: 0x04001543 RID: 5443
		Flat = 7424,
		// Token: 0x04001544 RID: 5444
		Smooth,
		// Token: 0x04001545 RID: 5445
		Keep = 7680,
		// Token: 0x04001546 RID: 5446
		Replace,
		// Token: 0x04001547 RID: 5447
		Incr,
		// Token: 0x04001548 RID: 5448
		Decr,
		// Token: 0x04001549 RID: 5449
		Vendor = 7936,
		// Token: 0x0400154A RID: 5450
		Renderer,
		// Token: 0x0400154B RID: 5451
		Version,
		// Token: 0x0400154C RID: 5452
		Extensions,
		// Token: 0x0400154D RID: 5453
		GlyphVerticalBearingXBitNv = 32,
		// Token: 0x0400154E RID: 5454
		S = 8192,
		// Token: 0x0400154F RID: 5455
		MultisampleBit = 536870912,
		// Token: 0x04001550 RID: 5456
		MultisampleBit3Dfx = 536870912,
		// Token: 0x04001551 RID: 5457
		MultisampleBitArb = 536870912,
		// Token: 0x04001552 RID: 5458
		MultisampleBitExt = 536870912,
		// Token: 0x04001553 RID: 5459
		Texcoord2BitPgi = 536870912,
		// Token: 0x04001554 RID: 5460
		T = 8193,
		// Token: 0x04001555 RID: 5461
		R,
		// Token: 0x04001556 RID: 5462
		Q,
		// Token: 0x04001557 RID: 5463
		Modulate = 8448,
		// Token: 0x04001558 RID: 5464
		Decal,
		// Token: 0x04001559 RID: 5465
		TextureEnvMode = 8704,
		// Token: 0x0400155A RID: 5466
		TextureEnvColor,
		// Token: 0x0400155B RID: 5467
		TextureEnv = 8960,
		// Token: 0x0400155C RID: 5468
		EyeLinear = 9216,
		// Token: 0x0400155D RID: 5469
		ObjectLinear,
		// Token: 0x0400155E RID: 5470
		SphereMap,
		// Token: 0x0400155F RID: 5471
		TextureGenMode = 9472,
		// Token: 0x04001560 RID: 5472
		ObjectPlane,
		// Token: 0x04001561 RID: 5473
		EyePlane,
		// Token: 0x04001562 RID: 5474
		Nearest = 9728,
		// Token: 0x04001563 RID: 5475
		Linear,
		// Token: 0x04001564 RID: 5476
		NearestMipmapNearest = 9984,
		// Token: 0x04001565 RID: 5477
		LinearMipmapNearest,
		// Token: 0x04001566 RID: 5478
		NearestMipmapLinear,
		// Token: 0x04001567 RID: 5479
		LinearMipmapLinear,
		// Token: 0x04001568 RID: 5480
		TextureMagFilter = 10240,
		// Token: 0x04001569 RID: 5481
		TextureMinFilter,
		// Token: 0x0400156A RID: 5482
		TextureWrapS,
		// Token: 0x0400156B RID: 5483
		TextureWrapT,
		// Token: 0x0400156C RID: 5484
		Clamp = 10496,
		// Token: 0x0400156D RID: 5485
		Repeat,
		// Token: 0x0400156E RID: 5486
		PolygonOffsetUnits = 10752,
		// Token: 0x0400156F RID: 5487
		PolygonOffsetPoint,
		// Token: 0x04001570 RID: 5488
		PolygonOffsetLine,
		// Token: 0x04001571 RID: 5489
		R3G3B2 = 10768,
		// Token: 0x04001572 RID: 5490
		V2f = 10784,
		// Token: 0x04001573 RID: 5491
		V3f,
		// Token: 0x04001574 RID: 5492
		C4ubV2f,
		// Token: 0x04001575 RID: 5493
		C4ubV3f,
		// Token: 0x04001576 RID: 5494
		C3fV3f,
		// Token: 0x04001577 RID: 5495
		N3fV3f,
		// Token: 0x04001578 RID: 5496
		C4fN3fV3f,
		// Token: 0x04001579 RID: 5497
		T2fV3f,
		// Token: 0x0400157A RID: 5498
		T4fV4f,
		// Token: 0x0400157B RID: 5499
		T2fC4ubV3f,
		// Token: 0x0400157C RID: 5500
		T2fC3fV3f,
		// Token: 0x0400157D RID: 5501
		T2fN3fV3f,
		// Token: 0x0400157E RID: 5502
		T2fC4fN3fV3f,
		// Token: 0x0400157F RID: 5503
		T4fC4fN3fV4f,
		// Token: 0x04001580 RID: 5504
		ClipDistance0 = 12288,
		// Token: 0x04001581 RID: 5505
		ClipPlane0 = 12288,
		// Token: 0x04001582 RID: 5506
		ClipDistance1,
		// Token: 0x04001583 RID: 5507
		ClipPlane1 = 12289,
		// Token: 0x04001584 RID: 5508
		ClipDistance2,
		// Token: 0x04001585 RID: 5509
		ClipPlane2 = 12290,
		// Token: 0x04001586 RID: 5510
		ClipDistance3,
		// Token: 0x04001587 RID: 5511
		ClipPlane3 = 12291,
		// Token: 0x04001588 RID: 5512
		ClipDistance4,
		// Token: 0x04001589 RID: 5513
		ClipPlane4 = 12292,
		// Token: 0x0400158A RID: 5514
		ClipDistance5,
		// Token: 0x0400158B RID: 5515
		ClipPlane5 = 12293,
		// Token: 0x0400158C RID: 5516
		ClipDistance6,
		// Token: 0x0400158D RID: 5517
		ClipDistance7,
		// Token: 0x0400158E RID: 5518
		GlyphVerticalBearingYBitNv = 64,
		// Token: 0x0400158F RID: 5519
		Light0 = 16384,
		// Token: 0x04001590 RID: 5520
		Texcoord3BitPgi = 1073741824,
		// Token: 0x04001591 RID: 5521
		Light1 = 16385,
		// Token: 0x04001592 RID: 5522
		Light2,
		// Token: 0x04001593 RID: 5523
		Light3,
		// Token: 0x04001594 RID: 5524
		Light4,
		// Token: 0x04001595 RID: 5525
		Light5,
		// Token: 0x04001596 RID: 5526
		Light6,
		// Token: 0x04001597 RID: 5527
		Light7,
		// Token: 0x04001598 RID: 5528
		GlyphVerticalBearingAdvanceBitNv = 128,
		// Token: 0x04001599 RID: 5529
		AbgrExt = 32768,
		// Token: 0x0400159A RID: 5530
		Texcoord4BitPgi = -2147483648,
		// Token: 0x0400159B RID: 5531
		ConstantColor = 32769,
		// Token: 0x0400159C RID: 5532
		ConstantColorExt = 32769,
		// Token: 0x0400159D RID: 5533
		OneMinusConstantColor,
		// Token: 0x0400159E RID: 5534
		OneMinusConstantColorExt = 32770,
		// Token: 0x0400159F RID: 5535
		ConstantAlpha,
		// Token: 0x040015A0 RID: 5536
		ConstantAlphaExt = 32771,
		// Token: 0x040015A1 RID: 5537
		OneMinusConstantAlpha,
		// Token: 0x040015A2 RID: 5538
		OneMinusConstantAlphaExt = 32772,
		// Token: 0x040015A3 RID: 5539
		BlendColor,
		// Token: 0x040015A4 RID: 5540
		BlendColorExt = 32773,
		// Token: 0x040015A5 RID: 5541
		FuncAdd,
		// Token: 0x040015A6 RID: 5542
		FuncAddExt = 32774,
		// Token: 0x040015A7 RID: 5543
		Min,
		// Token: 0x040015A8 RID: 5544
		MinExt = 32775,
		// Token: 0x040015A9 RID: 5545
		Max,
		// Token: 0x040015AA RID: 5546
		MaxExt = 32776,
		// Token: 0x040015AB RID: 5547
		BlendEquation,
		// Token: 0x040015AC RID: 5548
		BlendEquationExt = 32777,
		// Token: 0x040015AD RID: 5549
		BlendEquationRgb = 32777,
		// Token: 0x040015AE RID: 5550
		BlendEquationRgbExt = 32777,
		// Token: 0x040015AF RID: 5551
		FuncSubtract,
		// Token: 0x040015B0 RID: 5552
		FuncSubtractExt = 32778,
		// Token: 0x040015B1 RID: 5553
		FuncReverseSubtract,
		// Token: 0x040015B2 RID: 5554
		FuncReverseSubtractExt = 32779,
		// Token: 0x040015B3 RID: 5555
		CmykExt,
		// Token: 0x040015B4 RID: 5556
		CmykaExt,
		// Token: 0x040015B5 RID: 5557
		PackCmykHintExt,
		// Token: 0x040015B6 RID: 5558
		UnpackCmykHintExt,
		// Token: 0x040015B7 RID: 5559
		Convolution1D,
		// Token: 0x040015B8 RID: 5560
		Convolution1DExt = 32784,
		// Token: 0x040015B9 RID: 5561
		Convolution2D,
		// Token: 0x040015BA RID: 5562
		Convolution2DExt = 32785,
		// Token: 0x040015BB RID: 5563
		Separable2D,
		// Token: 0x040015BC RID: 5564
		Separable2DExt = 32786,
		// Token: 0x040015BD RID: 5565
		ConvolutionBorderMode,
		// Token: 0x040015BE RID: 5566
		ConvolutionBorderModeExt = 32787,
		// Token: 0x040015BF RID: 5567
		ConvolutionFilterScale,
		// Token: 0x040015C0 RID: 5568
		ConvolutionFilterScaleExt = 32788,
		// Token: 0x040015C1 RID: 5569
		ConvolutionFilterBias,
		// Token: 0x040015C2 RID: 5570
		ConvolutionFilterBiasExt = 32789,
		// Token: 0x040015C3 RID: 5571
		Reduce,
		// Token: 0x040015C4 RID: 5572
		ReduceExt = 32790,
		// Token: 0x040015C5 RID: 5573
		ConvolutionFormat,
		// Token: 0x040015C6 RID: 5574
		ConvolutionFormatExt = 32791,
		// Token: 0x040015C7 RID: 5575
		ConvolutionWidth,
		// Token: 0x040015C8 RID: 5576
		ConvolutionWidthExt = 32792,
		// Token: 0x040015C9 RID: 5577
		ConvolutionHeight,
		// Token: 0x040015CA RID: 5578
		ConvolutionHeightExt = 32793,
		// Token: 0x040015CB RID: 5579
		MaxConvolutionWidth,
		// Token: 0x040015CC RID: 5580
		MaxConvolutionWidthExt = 32794,
		// Token: 0x040015CD RID: 5581
		MaxConvolutionHeight,
		// Token: 0x040015CE RID: 5582
		MaxConvolutionHeightExt = 32795,
		// Token: 0x040015CF RID: 5583
		PostConvolutionRedScale,
		// Token: 0x040015D0 RID: 5584
		PostConvolutionRedScaleExt = 32796,
		// Token: 0x040015D1 RID: 5585
		PostConvolutionGreenScale,
		// Token: 0x040015D2 RID: 5586
		PostConvolutionGreenScaleExt = 32797,
		// Token: 0x040015D3 RID: 5587
		PostConvolutionBlueScale,
		// Token: 0x040015D4 RID: 5588
		PostConvolutionBlueScaleExt = 32798,
		// Token: 0x040015D5 RID: 5589
		PostConvolutionAlphaScale,
		// Token: 0x040015D6 RID: 5590
		PostConvolutionAlphaScaleExt = 32799,
		// Token: 0x040015D7 RID: 5591
		PostConvolutionRedBias,
		// Token: 0x040015D8 RID: 5592
		PostConvolutionRedBiasExt = 32800,
		// Token: 0x040015D9 RID: 5593
		PostConvolutionGreenBias,
		// Token: 0x040015DA RID: 5594
		PostConvolutionGreenBiasExt = 32801,
		// Token: 0x040015DB RID: 5595
		PostConvolutionBlueBias,
		// Token: 0x040015DC RID: 5596
		PostConvolutionBlueBiasExt = 32802,
		// Token: 0x040015DD RID: 5597
		PostConvolutionAlphaBias,
		// Token: 0x040015DE RID: 5598
		PostConvolutionAlphaBiasExt = 32803,
		// Token: 0x040015DF RID: 5599
		Histogram,
		// Token: 0x040015E0 RID: 5600
		HistogramExt = 32804,
		// Token: 0x040015E1 RID: 5601
		ProxyHistogram,
		// Token: 0x040015E2 RID: 5602
		ProxyHistogramExt = 32805,
		// Token: 0x040015E3 RID: 5603
		HistogramWidth,
		// Token: 0x040015E4 RID: 5604
		HistogramWidthExt = 32806,
		// Token: 0x040015E5 RID: 5605
		HistogramFormat,
		// Token: 0x040015E6 RID: 5606
		HistogramFormatExt = 32807,
		// Token: 0x040015E7 RID: 5607
		HistogramRedSize,
		// Token: 0x040015E8 RID: 5608
		HistogramRedSizeExt = 32808,
		// Token: 0x040015E9 RID: 5609
		HistogramGreenSize,
		// Token: 0x040015EA RID: 5610
		HistogramGreenSizeExt = 32809,
		// Token: 0x040015EB RID: 5611
		HistogramBlueSize,
		// Token: 0x040015EC RID: 5612
		HistogramBlueSizeExt = 32810,
		// Token: 0x040015ED RID: 5613
		HistogramAlphaSize,
		// Token: 0x040015EE RID: 5614
		HistogramAlphaSizeExt = 32811,
		// Token: 0x040015EF RID: 5615
		HistogramLuminanceSize,
		// Token: 0x040015F0 RID: 5616
		HistogramLuminanceSizeExt = 32812,
		// Token: 0x040015F1 RID: 5617
		HistogramSink,
		// Token: 0x040015F2 RID: 5618
		HistogramSinkExt = 32813,
		// Token: 0x040015F3 RID: 5619
		Minmax,
		// Token: 0x040015F4 RID: 5620
		MinmaxExt = 32814,
		// Token: 0x040015F5 RID: 5621
		MinmaxFormat,
		// Token: 0x040015F6 RID: 5622
		MinmaxFormatExt = 32815,
		// Token: 0x040015F7 RID: 5623
		MinmaxSink,
		// Token: 0x040015F8 RID: 5624
		MinmaxSinkExt = 32816,
		// Token: 0x040015F9 RID: 5625
		TableTooLarge,
		// Token: 0x040015FA RID: 5626
		TableTooLargeExt = 32817,
		// Token: 0x040015FB RID: 5627
		UnsignedByte332,
		// Token: 0x040015FC RID: 5628
		UnsignedByte332Ext = 32818,
		// Token: 0x040015FD RID: 5629
		UnsignedShort4444,
		// Token: 0x040015FE RID: 5630
		UnsignedShort4444Ext = 32819,
		// Token: 0x040015FF RID: 5631
		UnsignedShort5551,
		// Token: 0x04001600 RID: 5632
		UnsignedShort5551Ext = 32820,
		// Token: 0x04001601 RID: 5633
		UnsignedInt8888,
		// Token: 0x04001602 RID: 5634
		UnsignedInt8888Ext = 32821,
		// Token: 0x04001603 RID: 5635
		UnsignedInt1010102,
		// Token: 0x04001604 RID: 5636
		UnsignedInt1010102Ext = 32822,
		// Token: 0x04001605 RID: 5637
		PolygonOffsetExt,
		// Token: 0x04001606 RID: 5638
		PolygonOffsetFill = 32823,
		// Token: 0x04001607 RID: 5639
		PolygonOffsetFactor,
		// Token: 0x04001608 RID: 5640
		PolygonOffsetFactorExt = 32824,
		// Token: 0x04001609 RID: 5641
		PolygonOffsetBiasExt,
		// Token: 0x0400160A RID: 5642
		RescaleNormal,
		// Token: 0x0400160B RID: 5643
		RescaleNormalExt = 32826,
		// Token: 0x0400160C RID: 5644
		Alpha4,
		// Token: 0x0400160D RID: 5645
		Alpha4Ext = 32827,
		// Token: 0x0400160E RID: 5646
		Alpha8,
		// Token: 0x0400160F RID: 5647
		Alpha8Ext = 32828,
		// Token: 0x04001610 RID: 5648
		Alpha12,
		// Token: 0x04001611 RID: 5649
		Alpha12Ext = 32829,
		// Token: 0x04001612 RID: 5650
		Alpha16,
		// Token: 0x04001613 RID: 5651
		Alpha16Ext = 32830,
		// Token: 0x04001614 RID: 5652
		Luminance4,
		// Token: 0x04001615 RID: 5653
		Luminance4Ext = 32831,
		// Token: 0x04001616 RID: 5654
		Luminance8,
		// Token: 0x04001617 RID: 5655
		Luminance8Ext = 32832,
		// Token: 0x04001618 RID: 5656
		Luminance12,
		// Token: 0x04001619 RID: 5657
		Luminance12Ext = 32833,
		// Token: 0x0400161A RID: 5658
		Luminance16,
		// Token: 0x0400161B RID: 5659
		Luminance16Ext = 32834,
		// Token: 0x0400161C RID: 5660
		Luminance4Alpha4,
		// Token: 0x0400161D RID: 5661
		Luminance4Alpha4Ext = 32835,
		// Token: 0x0400161E RID: 5662
		Luminance6Alpha2,
		// Token: 0x0400161F RID: 5663
		Luminance6Alpha2Ext = 32836,
		// Token: 0x04001620 RID: 5664
		Luminance8Alpha8,
		// Token: 0x04001621 RID: 5665
		Luminance8Alpha8Ext = 32837,
		// Token: 0x04001622 RID: 5666
		Luminance12Alpha4,
		// Token: 0x04001623 RID: 5667
		Luminance12Alpha4Ext = 32838,
		// Token: 0x04001624 RID: 5668
		Luminance12Alpha12,
		// Token: 0x04001625 RID: 5669
		Luminance12Alpha12Ext = 32839,
		// Token: 0x04001626 RID: 5670
		Luminance16Alpha16,
		// Token: 0x04001627 RID: 5671
		Luminance16Alpha16Ext = 32840,
		// Token: 0x04001628 RID: 5672
		Intensity,
		// Token: 0x04001629 RID: 5673
		IntensityExt = 32841,
		// Token: 0x0400162A RID: 5674
		Intensity4,
		// Token: 0x0400162B RID: 5675
		Intensity4Ext = 32842,
		// Token: 0x0400162C RID: 5676
		Intensity8,
		// Token: 0x0400162D RID: 5677
		Intensity8Ext = 32843,
		// Token: 0x0400162E RID: 5678
		Intensity12,
		// Token: 0x0400162F RID: 5679
		Intensity12Ext = 32844,
		// Token: 0x04001630 RID: 5680
		Intensity16,
		// Token: 0x04001631 RID: 5681
		Intensity16Ext = 32845,
		// Token: 0x04001632 RID: 5682
		Rgb2Ext,
		// Token: 0x04001633 RID: 5683
		Rgb4,
		// Token: 0x04001634 RID: 5684
		Rgb4Ext = 32847,
		// Token: 0x04001635 RID: 5685
		Rgb5,
		// Token: 0x04001636 RID: 5686
		Rgb5Ext = 32848,
		// Token: 0x04001637 RID: 5687
		Rgb8,
		// Token: 0x04001638 RID: 5688
		Rgb8Ext = 32849,
		// Token: 0x04001639 RID: 5689
		Rgb10,
		// Token: 0x0400163A RID: 5690
		Rgb10Ext = 32850,
		// Token: 0x0400163B RID: 5691
		Rgb12,
		// Token: 0x0400163C RID: 5692
		Rgb12Ext = 32851,
		// Token: 0x0400163D RID: 5693
		Rgb16,
		// Token: 0x0400163E RID: 5694
		Rgb16Ext = 32852,
		// Token: 0x0400163F RID: 5695
		Rgba2,
		// Token: 0x04001640 RID: 5696
		Rgba2Ext = 32853,
		// Token: 0x04001641 RID: 5697
		Rgba4,
		// Token: 0x04001642 RID: 5698
		Rgba4Ext = 32854,
		// Token: 0x04001643 RID: 5699
		Rgb5A1,
		// Token: 0x04001644 RID: 5700
		Rgb5A1Ext = 32855,
		// Token: 0x04001645 RID: 5701
		Rgba8,
		// Token: 0x04001646 RID: 5702
		Rgba8Ext = 32856,
		// Token: 0x04001647 RID: 5703
		Rgb10A2,
		// Token: 0x04001648 RID: 5704
		Rgb10A2Ext = 32857,
		// Token: 0x04001649 RID: 5705
		Rgba12,
		// Token: 0x0400164A RID: 5706
		Rgba12Ext = 32858,
		// Token: 0x0400164B RID: 5707
		Rgba16,
		// Token: 0x0400164C RID: 5708
		Rgba16Ext = 32859,
		// Token: 0x0400164D RID: 5709
		TextureRedSize,
		// Token: 0x0400164E RID: 5710
		TextureRedSizeExt = 32860,
		// Token: 0x0400164F RID: 5711
		TextureGreenSize,
		// Token: 0x04001650 RID: 5712
		TextureGreenSizeExt = 32861,
		// Token: 0x04001651 RID: 5713
		TextureBlueSize,
		// Token: 0x04001652 RID: 5714
		TextureBlueSizeExt = 32862,
		// Token: 0x04001653 RID: 5715
		TextureAlphaSize,
		// Token: 0x04001654 RID: 5716
		TextureAlphaSizeExt = 32863,
		// Token: 0x04001655 RID: 5717
		TextureLuminanceSize,
		// Token: 0x04001656 RID: 5718
		TextureLuminanceSizeExt = 32864,
		// Token: 0x04001657 RID: 5719
		TextureIntensitySize,
		// Token: 0x04001658 RID: 5720
		TextureIntensitySizeExt = 32865,
		// Token: 0x04001659 RID: 5721
		ReplaceExt,
		// Token: 0x0400165A RID: 5722
		ProxyTexture1D,
		// Token: 0x0400165B RID: 5723
		ProxyTexture1DExt = 32867,
		// Token: 0x0400165C RID: 5724
		ProxyTexture2D,
		// Token: 0x0400165D RID: 5725
		ProxyTexture2DExt = 32868,
		// Token: 0x0400165E RID: 5726
		TextureTooLargeExt,
		// Token: 0x0400165F RID: 5727
		TexturePriority,
		// Token: 0x04001660 RID: 5728
		TexturePriorityExt = 32870,
		// Token: 0x04001661 RID: 5729
		TextureResident,
		// Token: 0x04001662 RID: 5730
		TextureResidentExt = 32871,
		// Token: 0x04001663 RID: 5731
		Texture1DBindingExt,
		// Token: 0x04001664 RID: 5732
		TextureBinding1D = 32872,
		// Token: 0x04001665 RID: 5733
		Texture2DBindingExt,
		// Token: 0x04001666 RID: 5734
		TextureBinding2D = 32873,
		// Token: 0x04001667 RID: 5735
		Texture3DBindingExt,
		// Token: 0x04001668 RID: 5736
		TextureBinding3D = 32874,
		// Token: 0x04001669 RID: 5737
		PackSkipImages,
		// Token: 0x0400166A RID: 5738
		PackSkipImagesExt = 32875,
		// Token: 0x0400166B RID: 5739
		PackImageHeight,
		// Token: 0x0400166C RID: 5740
		PackImageHeightExt = 32876,
		// Token: 0x0400166D RID: 5741
		UnpackSkipImages,
		// Token: 0x0400166E RID: 5742
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400166F RID: 5743
		UnpackImageHeight,
		// Token: 0x04001670 RID: 5744
		UnpackImageHeightExt = 32878,
		// Token: 0x04001671 RID: 5745
		Texture3D,
		// Token: 0x04001672 RID: 5746
		Texture3DExt = 32879,
		// Token: 0x04001673 RID: 5747
		Texture3DOes = 32879,
		// Token: 0x04001674 RID: 5748
		ProxyTexture3D,
		// Token: 0x04001675 RID: 5749
		ProxyTexture3DExt = 32880,
		// Token: 0x04001676 RID: 5750
		TextureDepth,
		// Token: 0x04001677 RID: 5751
		TextureDepthExt = 32881,
		// Token: 0x04001678 RID: 5752
		TextureWrapR,
		// Token: 0x04001679 RID: 5753
		TextureWrapRExt = 32882,
		// Token: 0x0400167A RID: 5754
		TextureWrapROes = 32882,
		// Token: 0x0400167B RID: 5755
		Max3DTextureSize,
		// Token: 0x0400167C RID: 5756
		Max3DTextureSizeExt = 32883,
		// Token: 0x0400167D RID: 5757
		VertexArray,
		// Token: 0x0400167E RID: 5758
		VertexArrayExt = 32884,
		// Token: 0x0400167F RID: 5759
		VertexArrayKhr = 32884,
		// Token: 0x04001680 RID: 5760
		NormalArray,
		// Token: 0x04001681 RID: 5761
		NormalArrayExt = 32885,
		// Token: 0x04001682 RID: 5762
		ColorArray,
		// Token: 0x04001683 RID: 5763
		ColorArrayExt = 32886,
		// Token: 0x04001684 RID: 5764
		IndexArray,
		// Token: 0x04001685 RID: 5765
		IndexArrayExt = 32887,
		// Token: 0x04001686 RID: 5766
		TextureCoordArray,
		// Token: 0x04001687 RID: 5767
		TextureCoordArrayExt = 32888,
		// Token: 0x04001688 RID: 5768
		EdgeFlagArray,
		// Token: 0x04001689 RID: 5769
		EdgeFlagArrayExt = 32889,
		// Token: 0x0400168A RID: 5770
		VertexArraySize,
		// Token: 0x0400168B RID: 5771
		VertexArraySizeExt = 32890,
		// Token: 0x0400168C RID: 5772
		VertexArrayType,
		// Token: 0x0400168D RID: 5773
		VertexArrayTypeExt = 32891,
		// Token: 0x0400168E RID: 5774
		VertexArrayStride,
		// Token: 0x0400168F RID: 5775
		VertexArrayStrideExt = 32892,
		// Token: 0x04001690 RID: 5776
		VertexArrayCountExt,
		// Token: 0x04001691 RID: 5777
		NormalArrayType,
		// Token: 0x04001692 RID: 5778
		NormalArrayTypeExt = 32894,
		// Token: 0x04001693 RID: 5779
		NormalArrayStride,
		// Token: 0x04001694 RID: 5780
		NormalArrayStrideExt = 32895,
		// Token: 0x04001695 RID: 5781
		NormalArrayCountExt,
		// Token: 0x04001696 RID: 5782
		ColorArraySize,
		// Token: 0x04001697 RID: 5783
		ColorArraySizeExt = 32897,
		// Token: 0x04001698 RID: 5784
		ColorArrayType,
		// Token: 0x04001699 RID: 5785
		ColorArrayTypeExt = 32898,
		// Token: 0x0400169A RID: 5786
		ColorArrayStride,
		// Token: 0x0400169B RID: 5787
		ColorArrayStrideExt = 32899,
		// Token: 0x0400169C RID: 5788
		ColorArrayCountExt,
		// Token: 0x0400169D RID: 5789
		IndexArrayType,
		// Token: 0x0400169E RID: 5790
		IndexArrayTypeExt = 32901,
		// Token: 0x0400169F RID: 5791
		IndexArrayStride,
		// Token: 0x040016A0 RID: 5792
		IndexArrayStrideExt = 32902,
		// Token: 0x040016A1 RID: 5793
		IndexArrayCountExt,
		// Token: 0x040016A2 RID: 5794
		TextureCoordArraySize,
		// Token: 0x040016A3 RID: 5795
		TextureCoordArraySizeExt = 32904,
		// Token: 0x040016A4 RID: 5796
		TextureCoordArrayType,
		// Token: 0x040016A5 RID: 5797
		TextureCoordArrayTypeExt = 32905,
		// Token: 0x040016A6 RID: 5798
		TextureCoordArrayStride,
		// Token: 0x040016A7 RID: 5799
		TextureCoordArrayStrideExt = 32906,
		// Token: 0x040016A8 RID: 5800
		TextureCoordArrayCountExt,
		// Token: 0x040016A9 RID: 5801
		EdgeFlagArrayStride,
		// Token: 0x040016AA RID: 5802
		EdgeFlagArrayStrideExt = 32908,
		// Token: 0x040016AB RID: 5803
		EdgeFlagArrayCountExt,
		// Token: 0x040016AC RID: 5804
		VertexArrayPointer,
		// Token: 0x040016AD RID: 5805
		VertexArrayPointerExt = 32910,
		// Token: 0x040016AE RID: 5806
		NormalArrayPointer,
		// Token: 0x040016AF RID: 5807
		NormalArrayPointerExt = 32911,
		// Token: 0x040016B0 RID: 5808
		ColorArrayPointer,
		// Token: 0x040016B1 RID: 5809
		ColorArrayPointerExt = 32912,
		// Token: 0x040016B2 RID: 5810
		IndexArrayPointer,
		// Token: 0x040016B3 RID: 5811
		IndexArrayPointerExt = 32913,
		// Token: 0x040016B4 RID: 5812
		TextureCoordArrayPointer,
		// Token: 0x040016B5 RID: 5813
		TextureCoordArrayPointerExt = 32914,
		// Token: 0x040016B6 RID: 5814
		EdgeFlagArrayPointer,
		// Token: 0x040016B7 RID: 5815
		EdgeFlagArrayPointerExt = 32915,
		// Token: 0x040016B8 RID: 5816
		InterlaceSgix,
		// Token: 0x040016B9 RID: 5817
		DetailTexture2DSgis,
		// Token: 0x040016BA RID: 5818
		DetailTexture2DBindingSgis,
		// Token: 0x040016BB RID: 5819
		LinearDetailSgis,
		// Token: 0x040016BC RID: 5820
		LinearDetailAlphaSgis,
		// Token: 0x040016BD RID: 5821
		LinearDetailColorSgis,
		// Token: 0x040016BE RID: 5822
		DetailTextureLevelSgis,
		// Token: 0x040016BF RID: 5823
		DetailTextureModeSgis,
		// Token: 0x040016C0 RID: 5824
		DetailTextureFuncPointsSgis,
		// Token: 0x040016C1 RID: 5825
		Multisample,
		// Token: 0x040016C2 RID: 5826
		MultisampleArb = 32925,
		// Token: 0x040016C3 RID: 5827
		MultisampleExt = 32925,
		// Token: 0x040016C4 RID: 5828
		MultisampleSgis = 32925,
		// Token: 0x040016C5 RID: 5829
		SampleAlphaToCoverage,
		// Token: 0x040016C6 RID: 5830
		SampleAlphaToCoverageArb = 32926,
		// Token: 0x040016C7 RID: 5831
		SampleAlphaToMaskExt = 32926,
		// Token: 0x040016C8 RID: 5832
		SampleAlphaToMaskSgis = 32926,
		// Token: 0x040016C9 RID: 5833
		SampleAlphaToOne,
		// Token: 0x040016CA RID: 5834
		SampleAlphaToOneArb = 32927,
		// Token: 0x040016CB RID: 5835
		SampleAlphaToOneExt = 32927,
		// Token: 0x040016CC RID: 5836
		SampleAlphaToOneSgis = 32927,
		// Token: 0x040016CD RID: 5837
		SampleCoverage,
		// Token: 0x040016CE RID: 5838
		SampleCoverageArb = 32928,
		// Token: 0x040016CF RID: 5839
		SampleMaskExt = 32928,
		// Token: 0x040016D0 RID: 5840
		SampleMaskSgis = 32928,
		// Token: 0x040016D1 RID: 5841
		Gl1PassExt,
		// Token: 0x040016D2 RID: 5842
		Gl1PassSgis = 32929,
		// Token: 0x040016D3 RID: 5843
		Gl2Pass0Ext,
		// Token: 0x040016D4 RID: 5844
		Gl2Pass0Sgis = 32930,
		// Token: 0x040016D5 RID: 5845
		Gl2Pass1Ext,
		// Token: 0x040016D6 RID: 5846
		Gl2Pass1Sgis = 32931,
		// Token: 0x040016D7 RID: 5847
		Gl4Pass0Ext,
		// Token: 0x040016D8 RID: 5848
		Gl4Pass0Sgis = 32932,
		// Token: 0x040016D9 RID: 5849
		Gl4Pass1Ext,
		// Token: 0x040016DA RID: 5850
		Gl4Pass1Sgis = 32933,
		// Token: 0x040016DB RID: 5851
		Gl4Pass2Ext,
		// Token: 0x040016DC RID: 5852
		Gl4Pass2Sgis = 32934,
		// Token: 0x040016DD RID: 5853
		Gl4Pass3Ext,
		// Token: 0x040016DE RID: 5854
		Gl4Pass3Sgis = 32935,
		// Token: 0x040016DF RID: 5855
		SampleBuffers,
		// Token: 0x040016E0 RID: 5856
		SampleBuffersArb = 32936,
		// Token: 0x040016E1 RID: 5857
		SampleBuffersExt = 32936,
		// Token: 0x040016E2 RID: 5858
		SampleBuffersSgis = 32936,
		// Token: 0x040016E3 RID: 5859
		Samples,
		// Token: 0x040016E4 RID: 5860
		SamplesArb = 32937,
		// Token: 0x040016E5 RID: 5861
		SamplesExt = 32937,
		// Token: 0x040016E6 RID: 5862
		SamplesSgis = 32937,
		// Token: 0x040016E7 RID: 5863
		SampleCoverageValue,
		// Token: 0x040016E8 RID: 5864
		SampleCoverageValueArb = 32938,
		// Token: 0x040016E9 RID: 5865
		SampleMaskValueExt = 32938,
		// Token: 0x040016EA RID: 5866
		SampleMaskValueSgis = 32938,
		// Token: 0x040016EB RID: 5867
		SampleCoverageInvert,
		// Token: 0x040016EC RID: 5868
		SampleCoverageInvertArb = 32939,
		// Token: 0x040016ED RID: 5869
		SampleMaskInvertExt = 32939,
		// Token: 0x040016EE RID: 5870
		SampleMaskInvertSgis = 32939,
		// Token: 0x040016EF RID: 5871
		SamplePatternExt,
		// Token: 0x040016F0 RID: 5872
		SamplePatternSgis = 32940,
		// Token: 0x040016F1 RID: 5873
		LinearSharpenSgis,
		// Token: 0x040016F2 RID: 5874
		LinearSharpenAlphaSgis,
		// Token: 0x040016F3 RID: 5875
		LinearSharpenColorSgis,
		// Token: 0x040016F4 RID: 5876
		SharpenTextureFuncPointsSgis,
		// Token: 0x040016F5 RID: 5877
		ColorMatrix,
		// Token: 0x040016F6 RID: 5878
		ColorMatrixSgi = 32945,
		// Token: 0x040016F7 RID: 5879
		ColorMatrixStackDepth,
		// Token: 0x040016F8 RID: 5880
		ColorMatrixStackDepthSgi = 32946,
		// Token: 0x040016F9 RID: 5881
		MaxColorMatrixStackDepth,
		// Token: 0x040016FA RID: 5882
		MaxColorMatrixStackDepthSgi = 32947,
		// Token: 0x040016FB RID: 5883
		PostColorMatrixRedScale,
		// Token: 0x040016FC RID: 5884
		PostColorMatrixRedScaleSgi = 32948,
		// Token: 0x040016FD RID: 5885
		PostColorMatrixGreenScale,
		// Token: 0x040016FE RID: 5886
		PostColorMatrixGreenScaleSgi = 32949,
		// Token: 0x040016FF RID: 5887
		PostColorMatrixBlueScale,
		// Token: 0x04001700 RID: 5888
		PostColorMatrixBlueScaleSgi = 32950,
		// Token: 0x04001701 RID: 5889
		PostColorMatrixAlphaScale,
		// Token: 0x04001702 RID: 5890
		PostColorMatrixAlphaScaleSgi = 32951,
		// Token: 0x04001703 RID: 5891
		PostColorMatrixRedBias,
		// Token: 0x04001704 RID: 5892
		PostColorMatrixRedBiasSgi = 32952,
		// Token: 0x04001705 RID: 5893
		PostColorMatrixGreenBias,
		// Token: 0x04001706 RID: 5894
		PostColorMatrixGreenBiasSgi = 32953,
		// Token: 0x04001707 RID: 5895
		PostColorMatrixBlueBias,
		// Token: 0x04001708 RID: 5896
		PostColorMatrixBlueBiasSgi = 32954,
		// Token: 0x04001709 RID: 5897
		PostColorMatrixAlphaBias,
		// Token: 0x0400170A RID: 5898
		PostColorMatrixAlphaBiasSgi = 32955,
		// Token: 0x0400170B RID: 5899
		TextureColorTableSgi,
		// Token: 0x0400170C RID: 5900
		ProxyTextureColorTableSgi,
		// Token: 0x0400170D RID: 5901
		TextureEnvBiasSgix,
		// Token: 0x0400170E RID: 5902
		ShadowAmbientSgix,
		// Token: 0x0400170F RID: 5903
		TextureCompareFailValue = 32959,
		// Token: 0x04001710 RID: 5904
		TextureCompareFailValueArb = 32959,
		// Token: 0x04001711 RID: 5905
		BlendDstRgb = 32968,
		// Token: 0x04001712 RID: 5906
		BlendDstRgbExt = 32968,
		// Token: 0x04001713 RID: 5907
		BlendSrcRgb,
		// Token: 0x04001714 RID: 5908
		BlendSrcRgbExt = 32969,
		// Token: 0x04001715 RID: 5909
		BlendDstAlpha,
		// Token: 0x04001716 RID: 5910
		BlendDstAlphaExt = 32970,
		// Token: 0x04001717 RID: 5911
		BlendSrcAlpha,
		// Token: 0x04001718 RID: 5912
		BlendSrcAlphaExt = 32971,
		// Token: 0x04001719 RID: 5913
		Gl422Ext,
		// Token: 0x0400171A RID: 5914
		Gl422RevExt,
		// Token: 0x0400171B RID: 5915
		Gl422AverageExt,
		// Token: 0x0400171C RID: 5916
		Gl422RevAverageExt,
		// Token: 0x0400171D RID: 5917
		ColorTable,
		// Token: 0x0400171E RID: 5918
		ColorTableSgi = 32976,
		// Token: 0x0400171F RID: 5919
		PostConvolutionColorTable,
		// Token: 0x04001720 RID: 5920
		PostConvolutionColorTableSgi = 32977,
		// Token: 0x04001721 RID: 5921
		PostColorMatrixColorTable,
		// Token: 0x04001722 RID: 5922
		PostColorMatrixColorTableSgi = 32978,
		// Token: 0x04001723 RID: 5923
		ProxyColorTable,
		// Token: 0x04001724 RID: 5924
		ProxyColorTableSgi = 32979,
		// Token: 0x04001725 RID: 5925
		ProxyPostConvolutionColorTable,
		// Token: 0x04001726 RID: 5926
		ProxyPostConvolutionColorTableSgi = 32980,
		// Token: 0x04001727 RID: 5927
		ProxyPostColorMatrixColorTable,
		// Token: 0x04001728 RID: 5928
		ProxyPostColorMatrixColorTableSgi = 32981,
		// Token: 0x04001729 RID: 5929
		ColorTableScale,
		// Token: 0x0400172A RID: 5930
		ColorTableScaleSgi = 32982,
		// Token: 0x0400172B RID: 5931
		ColorTableBias,
		// Token: 0x0400172C RID: 5932
		ColorTableBiasSgi = 32983,
		// Token: 0x0400172D RID: 5933
		ColorTableFormat,
		// Token: 0x0400172E RID: 5934
		ColorTableFormatSgi = 32984,
		// Token: 0x0400172F RID: 5935
		ColorTableWidth,
		// Token: 0x04001730 RID: 5936
		ColorTableWidthSgi = 32985,
		// Token: 0x04001731 RID: 5937
		ColorTableRedSize,
		// Token: 0x04001732 RID: 5938
		ColorTableRedSizeSgi = 32986,
		// Token: 0x04001733 RID: 5939
		ColorTableGreenSize,
		// Token: 0x04001734 RID: 5940
		ColorTableGreenSizeSgi = 32987,
		// Token: 0x04001735 RID: 5941
		ColorTableBlueSize,
		// Token: 0x04001736 RID: 5942
		ColorTableBlueSizeSgi = 32988,
		// Token: 0x04001737 RID: 5943
		ColorTableAlphaSize,
		// Token: 0x04001738 RID: 5944
		ColorTableAlphaSizeSgi = 32989,
		// Token: 0x04001739 RID: 5945
		ColorTableLuminanceSize,
		// Token: 0x0400173A RID: 5946
		ColorTableLuminanceSizeSgi = 32990,
		// Token: 0x0400173B RID: 5947
		ColorTableIntensitySize,
		// Token: 0x0400173C RID: 5948
		ColorTableIntensitySizeSgi = 32991,
		// Token: 0x0400173D RID: 5949
		Bgr,
		// Token: 0x0400173E RID: 5950
		BgrExt = 32992,
		// Token: 0x0400173F RID: 5951
		Bgra,
		// Token: 0x04001740 RID: 5952
		BgraExt = 32993,
		// Token: 0x04001741 RID: 5953
		ColorIndex1Ext,
		// Token: 0x04001742 RID: 5954
		ColorIndex2Ext,
		// Token: 0x04001743 RID: 5955
		ColorIndex4Ext,
		// Token: 0x04001744 RID: 5956
		ColorIndex8Ext,
		// Token: 0x04001745 RID: 5957
		ColorIndex12Ext,
		// Token: 0x04001746 RID: 5958
		ColorIndex16Ext,
		// Token: 0x04001747 RID: 5959
		MaxElementsVertices,
		// Token: 0x04001748 RID: 5960
		MaxElementsVerticesExt = 33000,
		// Token: 0x04001749 RID: 5961
		MaxElementsIndices,
		// Token: 0x0400174A RID: 5962
		MaxElementsIndicesExt = 33001,
		// Token: 0x0400174B RID: 5963
		PhongWin,
		// Token: 0x0400174C RID: 5964
		PhongHintWin,
		// Token: 0x0400174D RID: 5965
		FogSpecularTextureWin,
		// Token: 0x0400174E RID: 5966
		TextureIndexSizeExt,
		// Token: 0x0400174F RID: 5967
		ParameterBufferArb,
		// Token: 0x04001750 RID: 5968
		ParameterBufferBindingArb,
		// Token: 0x04001751 RID: 5969
		ClipVolumeClippingHintExt,
		// Token: 0x04001752 RID: 5970
		DualAlpha4Sgis = 33040,
		// Token: 0x04001753 RID: 5971
		DualAlpha8Sgis,
		// Token: 0x04001754 RID: 5972
		DualAlpha12Sgis,
		// Token: 0x04001755 RID: 5973
		DualAlpha16Sgis,
		// Token: 0x04001756 RID: 5974
		DualLuminance4Sgis,
		// Token: 0x04001757 RID: 5975
		DualLuminance8Sgis,
		// Token: 0x04001758 RID: 5976
		DualLuminance12Sgis,
		// Token: 0x04001759 RID: 5977
		DualLuminance16Sgis,
		// Token: 0x0400175A RID: 5978
		DualIntensity4Sgis,
		// Token: 0x0400175B RID: 5979
		DualIntensity8Sgis,
		// Token: 0x0400175C RID: 5980
		DualIntensity12Sgis,
		// Token: 0x0400175D RID: 5981
		DualIntensity16Sgis,
		// Token: 0x0400175E RID: 5982
		DualLuminanceAlpha4Sgis,
		// Token: 0x0400175F RID: 5983
		DualLuminanceAlpha8Sgis,
		// Token: 0x04001760 RID: 5984
		QuadAlpha4Sgis,
		// Token: 0x04001761 RID: 5985
		QuadAlpha8Sgis,
		// Token: 0x04001762 RID: 5986
		QuadLuminance4Sgis,
		// Token: 0x04001763 RID: 5987
		QuadLuminance8Sgis,
		// Token: 0x04001764 RID: 5988
		QuadIntensity4Sgis,
		// Token: 0x04001765 RID: 5989
		QuadIntensity8Sgis,
		// Token: 0x04001766 RID: 5990
		DualTextureSelectSgis,
		// Token: 0x04001767 RID: 5991
		QuadTextureSelectSgis,
		// Token: 0x04001768 RID: 5992
		PointSizeMin,
		// Token: 0x04001769 RID: 5993
		PointSizeMinArb = 33062,
		// Token: 0x0400176A RID: 5994
		PointSizeMinExt = 33062,
		// Token: 0x0400176B RID: 5995
		PointSizeMinSgis = 33062,
		// Token: 0x0400176C RID: 5996
		PointSizeMax,
		// Token: 0x0400176D RID: 5997
		PointSizeMaxArb = 33063,
		// Token: 0x0400176E RID: 5998
		PointSizeMaxExt = 33063,
		// Token: 0x0400176F RID: 5999
		PointSizeMaxSgis = 33063,
		// Token: 0x04001770 RID: 6000
		PointFadeThresholdSize,
		// Token: 0x04001771 RID: 6001
		PointFadeThresholdSizeArb = 33064,
		// Token: 0x04001772 RID: 6002
		PointFadeThresholdSizeExt = 33064,
		// Token: 0x04001773 RID: 6003
		PointFadeThresholdSizeSgis = 33064,
		// Token: 0x04001774 RID: 6004
		DistanceAttenuationExt,
		// Token: 0x04001775 RID: 6005
		DistanceAttenuationSgis = 33065,
		// Token: 0x04001776 RID: 6006
		PointDistanceAttenuation = 33065,
		// Token: 0x04001777 RID: 6007
		PointDistanceAttenuationArb = 33065,
		// Token: 0x04001778 RID: 6008
		FogFuncSgis,
		// Token: 0x04001779 RID: 6009
		FogFuncPointsSgis,
		// Token: 0x0400177A RID: 6010
		MaxFogFuncPointsSgis,
		// Token: 0x0400177B RID: 6011
		ClampToBorder,
		// Token: 0x0400177C RID: 6012
		ClampToBorderArb = 33069,
		// Token: 0x0400177D RID: 6013
		ClampToBorderNv = 33069,
		// Token: 0x0400177E RID: 6014
		ClampToBorderSgis = 33069,
		// Token: 0x0400177F RID: 6015
		TextureMultiBufferHintSgix,
		// Token: 0x04001780 RID: 6016
		ClampToEdge,
		// Token: 0x04001781 RID: 6017
		ClampToEdgeSgis = 33071,
		// Token: 0x04001782 RID: 6018
		PackSkipVolumesSgis,
		// Token: 0x04001783 RID: 6019
		PackImageDepthSgis,
		// Token: 0x04001784 RID: 6020
		UnpackSkipVolumesSgis,
		// Token: 0x04001785 RID: 6021
		UnpackImageDepthSgis,
		// Token: 0x04001786 RID: 6022
		Texture4DSgis,
		// Token: 0x04001787 RID: 6023
		ProxyTexture4DSgis,
		// Token: 0x04001788 RID: 6024
		Texture4DsizeSgis,
		// Token: 0x04001789 RID: 6025
		TextureWrapQSgis,
		// Token: 0x0400178A RID: 6026
		Max4DTextureSizeSgis,
		// Token: 0x0400178B RID: 6027
		PixelTexGenSgix,
		// Token: 0x0400178C RID: 6028
		TextureMinLod,
		// Token: 0x0400178D RID: 6029
		TextureMinLodSgis = 33082,
		// Token: 0x0400178E RID: 6030
		TextureMaxLod,
		// Token: 0x0400178F RID: 6031
		TextureMaxLodSgis = 33083,
		// Token: 0x04001790 RID: 6032
		TextureBaseLevel,
		// Token: 0x04001791 RID: 6033
		TextureBaseLevelSgis = 33084,
		// Token: 0x04001792 RID: 6034
		TextureMaxLevel,
		// Token: 0x04001793 RID: 6035
		TextureMaxLevelSgis = 33085,
		// Token: 0x04001794 RID: 6036
		PixelTileBestAlignmentSgix,
		// Token: 0x04001795 RID: 6037
		PixelTileCacheIncrementSgix,
		// Token: 0x04001796 RID: 6038
		PixelTileWidthSgix,
		// Token: 0x04001797 RID: 6039
		PixelTileHeightSgix,
		// Token: 0x04001798 RID: 6040
		PixelTileGridWidthSgix,
		// Token: 0x04001799 RID: 6041
		PixelTileGridHeightSgix,
		// Token: 0x0400179A RID: 6042
		PixelTileGridDepthSgix,
		// Token: 0x0400179B RID: 6043
		PixelTileCacheSizeSgix,
		// Token: 0x0400179C RID: 6044
		Filter4Sgis,
		// Token: 0x0400179D RID: 6045
		TextureFilter4SizeSgis,
		// Token: 0x0400179E RID: 6046
		SpriteSgix,
		// Token: 0x0400179F RID: 6047
		SpriteModeSgix,
		// Token: 0x040017A0 RID: 6048
		SpriteAxisSgix,
		// Token: 0x040017A1 RID: 6049
		SpriteTranslationSgix,
		// Token: 0x040017A2 RID: 6050
		SpriteAxialSgix,
		// Token: 0x040017A3 RID: 6051
		SpriteObjectAlignedSgix,
		// Token: 0x040017A4 RID: 6052
		SpriteEyeAlignedSgix,
		// Token: 0x040017A5 RID: 6053
		Texture4DBindingSgis,
		// Token: 0x040017A6 RID: 6054
		IgnoreBorderHp,
		// Token: 0x040017A7 RID: 6055
		ConstantBorder,
		// Token: 0x040017A8 RID: 6056
		ConstantBorderHp = 33105,
		// Token: 0x040017A9 RID: 6057
		ReplicateBorder = 33107,
		// Token: 0x040017AA RID: 6058
		ReplicateBorderHp = 33107,
		// Token: 0x040017AB RID: 6059
		ConvolutionBorderColor,
		// Token: 0x040017AC RID: 6060
		ConvolutionBorderColorHp = 33108,
		// Token: 0x040017AD RID: 6061
		ImageScaleXHp,
		// Token: 0x040017AE RID: 6062
		ImageScaleYHp,
		// Token: 0x040017AF RID: 6063
		ImageTranslateXHp,
		// Token: 0x040017B0 RID: 6064
		ImageTranslateYHp,
		// Token: 0x040017B1 RID: 6065
		ImageRotateAngleHp,
		// Token: 0x040017B2 RID: 6066
		ImageRotateOriginXHp,
		// Token: 0x040017B3 RID: 6067
		ImageRotateOriginYHp,
		// Token: 0x040017B4 RID: 6068
		ImageMagFilterHp,
		// Token: 0x040017B5 RID: 6069
		ImageMinFilterHp,
		// Token: 0x040017B6 RID: 6070
		ImageCubicWeightHp,
		// Token: 0x040017B7 RID: 6071
		CubicHp,
		// Token: 0x040017B8 RID: 6072
		AverageHp,
		// Token: 0x040017B9 RID: 6073
		ImageTransform2DHp,
		// Token: 0x040017BA RID: 6074
		PostImageTransformColorTableHp,
		// Token: 0x040017BB RID: 6075
		ProxyPostImageTransformColorTableHp,
		// Token: 0x040017BC RID: 6076
		OcclusionTestHp = 33125,
		// Token: 0x040017BD RID: 6077
		OcclusionTestResultHp,
		// Token: 0x040017BE RID: 6078
		TextureLightingModeHp,
		// Token: 0x040017BF RID: 6079
		TexturePostSpecularHp,
		// Token: 0x040017C0 RID: 6080
		TexturePreSpecularHp,
		// Token: 0x040017C1 RID: 6081
		LinearClipmapLinearSgix = 33136,
		// Token: 0x040017C2 RID: 6082
		TextureClipmapCenterSgix,
		// Token: 0x040017C3 RID: 6083
		TextureClipmapFrameSgix,
		// Token: 0x040017C4 RID: 6084
		TextureClipmapOffsetSgix,
		// Token: 0x040017C5 RID: 6085
		TextureClipmapVirtualDepthSgix,
		// Token: 0x040017C6 RID: 6086
		TextureClipmapLodOffsetSgix,
		// Token: 0x040017C7 RID: 6087
		TextureClipmapDepthSgix,
		// Token: 0x040017C8 RID: 6088
		MaxClipmapDepthSgix,
		// Token: 0x040017C9 RID: 6089
		MaxClipmapVirtualDepthSgix,
		// Token: 0x040017CA RID: 6090
		PostTextureFilterBiasSgix,
		// Token: 0x040017CB RID: 6091
		PostTextureFilterScaleSgix,
		// Token: 0x040017CC RID: 6092
		PostTextureFilterBiasRangeSgix,
		// Token: 0x040017CD RID: 6093
		PostTextureFilterScaleRangeSgix,
		// Token: 0x040017CE RID: 6094
		ReferencePlaneSgix,
		// Token: 0x040017CF RID: 6095
		ReferencePlaneEquationSgix,
		// Token: 0x040017D0 RID: 6096
		IrInstrument1Sgix,
		// Token: 0x040017D1 RID: 6097
		InstrumentBufferPointerSgix,
		// Token: 0x040017D2 RID: 6098
		InstrumentMeasurementsSgix,
		// Token: 0x040017D3 RID: 6099
		ListPrioritySgix,
		// Token: 0x040017D4 RID: 6100
		CalligraphicFragmentSgix,
		// Token: 0x040017D5 RID: 6101
		PixelTexGenQCeilingSgix,
		// Token: 0x040017D6 RID: 6102
		PixelTexGenQRoundSgix,
		// Token: 0x040017D7 RID: 6103
		PixelTexGenQFloorSgix,
		// Token: 0x040017D8 RID: 6104
		PixelTexGenAlphaReplaceSgix,
		// Token: 0x040017D9 RID: 6105
		PixelTexGenAlphaNoReplaceSgix,
		// Token: 0x040017DA RID: 6106
		PixelTexGenAlphaLsSgix,
		// Token: 0x040017DB RID: 6107
		PixelTexGenAlphaMsSgix,
		// Token: 0x040017DC RID: 6108
		FramezoomSgix,
		// Token: 0x040017DD RID: 6109
		FramezoomFactorSgix,
		// Token: 0x040017DE RID: 6110
		MaxFramezoomFactorSgix,
		// Token: 0x040017DF RID: 6111
		TextureLodBiasSSgix,
		// Token: 0x040017E0 RID: 6112
		TextureLodBiasTSgix,
		// Token: 0x040017E1 RID: 6113
		TextureLodBiasRSgix,
		// Token: 0x040017E2 RID: 6114
		GenerateMipmap,
		// Token: 0x040017E3 RID: 6115
		GenerateMipmapSgis = 33169,
		// Token: 0x040017E4 RID: 6116
		GenerateMipmapHint,
		// Token: 0x040017E5 RID: 6117
		GenerateMipmapHintSgis = 33170,
		// Token: 0x040017E6 RID: 6118
		GeometryDeformationSgix = 33172,
		// Token: 0x040017E7 RID: 6119
		TextureDeformationSgix,
		// Token: 0x040017E8 RID: 6120
		DeformationsMaskSgix,
		// Token: 0x040017E9 RID: 6121
		MaxDeformationOrderSgix,
		// Token: 0x040017EA RID: 6122
		FogOffsetSgix,
		// Token: 0x040017EB RID: 6123
		FogOffsetValueSgix,
		// Token: 0x040017EC RID: 6124
		TextureCompareSgix,
		// Token: 0x040017ED RID: 6125
		TextureCompareOperatorSgix,
		// Token: 0x040017EE RID: 6126
		TextureLequalRSgix,
		// Token: 0x040017EF RID: 6127
		TextureGequalRSgix,
		// Token: 0x040017F0 RID: 6128
		DepthComponent16 = 33189,
		// Token: 0x040017F1 RID: 6129
		DepthComponent16Arb = 33189,
		// Token: 0x040017F2 RID: 6130
		DepthComponent16Sgix = 33189,
		// Token: 0x040017F3 RID: 6131
		DepthComponent24,
		// Token: 0x040017F4 RID: 6132
		DepthComponent24Arb = 33190,
		// Token: 0x040017F5 RID: 6133
		DepthComponent24Sgix = 33190,
		// Token: 0x040017F6 RID: 6134
		DepthComponent32,
		// Token: 0x040017F7 RID: 6135
		DepthComponent32Arb = 33191,
		// Token: 0x040017F8 RID: 6136
		DepthComponent32Sgix = 33191,
		// Token: 0x040017F9 RID: 6137
		ArrayElementLockFirstExt,
		// Token: 0x040017FA RID: 6138
		ArrayElementLockCountExt,
		// Token: 0x040017FB RID: 6139
		CullVertexExt,
		// Token: 0x040017FC RID: 6140
		CullVertexEyePositionExt,
		// Token: 0x040017FD RID: 6141
		CullVertexObjectPositionExt,
		// Token: 0x040017FE RID: 6142
		IuiV2fExt,
		// Token: 0x040017FF RID: 6143
		IuiV3fExt,
		// Token: 0x04001800 RID: 6144
		IuiN3fV2fExt,
		// Token: 0x04001801 RID: 6145
		IuiN3fV3fExt,
		// Token: 0x04001802 RID: 6146
		T2fIuiV2fExt,
		// Token: 0x04001803 RID: 6147
		T2fIuiV3fExt,
		// Token: 0x04001804 RID: 6148
		T2fIuiN3fV2fExt,
		// Token: 0x04001805 RID: 6149
		T2fIuiN3fV3fExt,
		// Token: 0x04001806 RID: 6150
		IndexTestExt,
		// Token: 0x04001807 RID: 6151
		IndexTestFuncExt,
		// Token: 0x04001808 RID: 6152
		IndexTestRefExt,
		// Token: 0x04001809 RID: 6153
		IndexMaterialExt,
		// Token: 0x0400180A RID: 6154
		IndexMaterialParameterExt,
		// Token: 0x0400180B RID: 6155
		IndexMaterialFaceExt,
		// Token: 0x0400180C RID: 6156
		Ycrcb422Sgix,
		// Token: 0x0400180D RID: 6157
		Ycrcb444Sgix,
		// Token: 0x0400180E RID: 6158
		WrapBorderSun = 33236,
		// Token: 0x0400180F RID: 6159
		UnpackConstantDataSunx,
		// Token: 0x04001810 RID: 6160
		TextureConstantDataSunx,
		// Token: 0x04001811 RID: 6161
		TriangleListSun,
		// Token: 0x04001812 RID: 6162
		ReplacementCodeSun,
		// Token: 0x04001813 RID: 6163
		GlobalAlphaSun,
		// Token: 0x04001814 RID: 6164
		GlobalAlphaFactorSun,
		// Token: 0x04001815 RID: 6165
		TextureColorWritemaskSgis = 33263,
		// Token: 0x04001816 RID: 6166
		EyeDistanceToPointSgis,
		// Token: 0x04001817 RID: 6167
		ObjectDistanceToPointSgis,
		// Token: 0x04001818 RID: 6168
		EyeDistanceToLineSgis,
		// Token: 0x04001819 RID: 6169
		ObjectDistanceToLineSgis,
		// Token: 0x0400181A RID: 6170
		EyePointSgis,
		// Token: 0x0400181B RID: 6171
		ObjectPointSgis,
		// Token: 0x0400181C RID: 6172
		EyeLineSgis,
		// Token: 0x0400181D RID: 6173
		ObjectLineSgis,
		// Token: 0x0400181E RID: 6174
		LightModelColorControl,
		// Token: 0x0400181F RID: 6175
		LightModelColorControlExt = 33272,
		// Token: 0x04001820 RID: 6176
		SingleColor,
		// Token: 0x04001821 RID: 6177
		SingleColorExt = 33273,
		// Token: 0x04001822 RID: 6178
		SeparateSpecularColor,
		// Token: 0x04001823 RID: 6179
		SeparateSpecularColorExt = 33274,
		// Token: 0x04001824 RID: 6180
		SharedTexturePaletteExt,
		// Token: 0x04001825 RID: 6181
		TextFragmentShaderAti = 33280,
		// Token: 0x04001826 RID: 6182
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x04001827 RID: 6183
		FramebufferAttachmentComponentType,
		// Token: 0x04001828 RID: 6184
		FramebufferAttachmentRedSize,
		// Token: 0x04001829 RID: 6185
		FramebufferAttachmentGreenSize,
		// Token: 0x0400182A RID: 6186
		FramebufferAttachmentBlueSize,
		// Token: 0x0400182B RID: 6187
		FramebufferAttachmentAlphaSize,
		// Token: 0x0400182C RID: 6188
		FramebufferAttachmentDepthSize,
		// Token: 0x0400182D RID: 6189
		FramebufferAttachmentStencilSize,
		// Token: 0x0400182E RID: 6190
		FramebufferDefault,
		// Token: 0x0400182F RID: 6191
		FramebufferUndefined,
		// Token: 0x04001830 RID: 6192
		DepthStencilAttachment,
		// Token: 0x04001831 RID: 6193
		MajorVersion,
		// Token: 0x04001832 RID: 6194
		MinorVersion,
		// Token: 0x04001833 RID: 6195
		NumExtensions,
		// Token: 0x04001834 RID: 6196
		ContextFlags,
		// Token: 0x04001835 RID: 6197
		BufferImmutableStorage,
		// Token: 0x04001836 RID: 6198
		BufferStorageFlags,
		// Token: 0x04001837 RID: 6199
		PrimitiveRestartForPatchesSupported,
		// Token: 0x04001838 RID: 6200
		Index,
		// Token: 0x04001839 RID: 6201
		CompressedRed = 33317,
		// Token: 0x0400183A RID: 6202
		CompressedRg,
		// Token: 0x0400183B RID: 6203
		Rg,
		// Token: 0x0400183C RID: 6204
		RgInteger,
		// Token: 0x0400183D RID: 6205
		R8,
		// Token: 0x0400183E RID: 6206
		R16,
		// Token: 0x0400183F RID: 6207
		Rg8,
		// Token: 0x04001840 RID: 6208
		Rg16,
		// Token: 0x04001841 RID: 6209
		R16f,
		// Token: 0x04001842 RID: 6210
		R32f,
		// Token: 0x04001843 RID: 6211
		Rg16f,
		// Token: 0x04001844 RID: 6212
		Rg32f,
		// Token: 0x04001845 RID: 6213
		R8i,
		// Token: 0x04001846 RID: 6214
		R8ui,
		// Token: 0x04001847 RID: 6215
		R16i,
		// Token: 0x04001848 RID: 6216
		R16ui,
		// Token: 0x04001849 RID: 6217
		R32i,
		// Token: 0x0400184A RID: 6218
		R32ui,
		// Token: 0x0400184B RID: 6219
		Rg8i,
		// Token: 0x0400184C RID: 6220
		Rg8ui,
		// Token: 0x0400184D RID: 6221
		Rg16i,
		// Token: 0x0400184E RID: 6222
		Rg16ui,
		// Token: 0x0400184F RID: 6223
		Rg32i,
		// Token: 0x04001850 RID: 6224
		Rg32ui,
		// Token: 0x04001851 RID: 6225
		SyncClEventArb = 33344,
		// Token: 0x04001852 RID: 6226
		SyncClEventCompleteArb,
		// Token: 0x04001853 RID: 6227
		DebugOutputSynchronous,
		// Token: 0x04001854 RID: 6228
		DebugOutputSynchronousArb = 33346,
		// Token: 0x04001855 RID: 6229
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x04001856 RID: 6230
		DebugNextLoggedMessageLength,
		// Token: 0x04001857 RID: 6231
		DebugNextLoggedMessageLengthArb = 33347,
		// Token: 0x04001858 RID: 6232
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x04001859 RID: 6233
		DebugCallbackFunction,
		// Token: 0x0400185A RID: 6234
		DebugCallbackFunctionArb = 33348,
		// Token: 0x0400185B RID: 6235
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x0400185C RID: 6236
		DebugCallbackUserParam,
		// Token: 0x0400185D RID: 6237
		DebugCallbackUserParamArb = 33349,
		// Token: 0x0400185E RID: 6238
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x0400185F RID: 6239
		DebugSourceApi,
		// Token: 0x04001860 RID: 6240
		DebugSourceApiArb = 33350,
		// Token: 0x04001861 RID: 6241
		DebugSourceApiKhr = 33350,
		// Token: 0x04001862 RID: 6242
		DebugSourceWindowSystem,
		// Token: 0x04001863 RID: 6243
		DebugSourceWindowSystemArb = 33351,
		// Token: 0x04001864 RID: 6244
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x04001865 RID: 6245
		DebugSourceShaderCompiler,
		// Token: 0x04001866 RID: 6246
		DebugSourceShaderCompilerArb = 33352,
		// Token: 0x04001867 RID: 6247
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x04001868 RID: 6248
		DebugSourceThirdParty,
		// Token: 0x04001869 RID: 6249
		DebugSourceThirdPartyArb = 33353,
		// Token: 0x0400186A RID: 6250
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x0400186B RID: 6251
		DebugSourceApplication,
		// Token: 0x0400186C RID: 6252
		DebugSourceApplicationArb = 33354,
		// Token: 0x0400186D RID: 6253
		DebugSourceApplicationKhr = 33354,
		// Token: 0x0400186E RID: 6254
		DebugSourceOther,
		// Token: 0x0400186F RID: 6255
		DebugSourceOtherArb = 33355,
		// Token: 0x04001870 RID: 6256
		DebugSourceOtherKhr = 33355,
		// Token: 0x04001871 RID: 6257
		DebugTypeError,
		// Token: 0x04001872 RID: 6258
		DebugTypeErrorArb = 33356,
		// Token: 0x04001873 RID: 6259
		DebugTypeErrorKhr = 33356,
		// Token: 0x04001874 RID: 6260
		DebugTypeDeprecatedBehavior,
		// Token: 0x04001875 RID: 6261
		DebugTypeDeprecatedBehaviorArb = 33357,
		// Token: 0x04001876 RID: 6262
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04001877 RID: 6263
		DebugTypeUndefinedBehavior,
		// Token: 0x04001878 RID: 6264
		DebugTypeUndefinedBehaviorArb = 33358,
		// Token: 0x04001879 RID: 6265
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x0400187A RID: 6266
		DebugTypePortability,
		// Token: 0x0400187B RID: 6267
		DebugTypePortabilityArb = 33359,
		// Token: 0x0400187C RID: 6268
		DebugTypePortabilityKhr = 33359,
		// Token: 0x0400187D RID: 6269
		DebugTypePerformance,
		// Token: 0x0400187E RID: 6270
		DebugTypePerformanceArb = 33360,
		// Token: 0x0400187F RID: 6271
		DebugTypePerformanceKhr = 33360,
		// Token: 0x04001880 RID: 6272
		DebugTypeOther,
		// Token: 0x04001881 RID: 6273
		DebugTypeOtherArb = 33361,
		// Token: 0x04001882 RID: 6274
		DebugTypeOtherKhr = 33361,
		// Token: 0x04001883 RID: 6275
		LoseContextOnResetArb,
		// Token: 0x04001884 RID: 6276
		GuiltyContextResetArb,
		// Token: 0x04001885 RID: 6277
		InnocentContextResetArb,
		// Token: 0x04001886 RID: 6278
		UnknownContextResetArb,
		// Token: 0x04001887 RID: 6279
		ResetNotificationStrategyArb,
		// Token: 0x04001888 RID: 6280
		ProgramBinaryRetrievableHint,
		// Token: 0x04001889 RID: 6281
		ProgramSeparable,
		// Token: 0x0400188A RID: 6282
		ProgramSeparableExt = 33368,
		// Token: 0x0400188B RID: 6283
		ActiveProgram,
		// Token: 0x0400188C RID: 6284
		ProgramPipelineBinding,
		// Token: 0x0400188D RID: 6285
		ProgramPipelineBindingExt = 33370,
		// Token: 0x0400188E RID: 6286
		MaxViewports,
		// Token: 0x0400188F RID: 6287
		ViewportSubpixelBits,
		// Token: 0x04001890 RID: 6288
		ViewportBoundsRange,
		// Token: 0x04001891 RID: 6289
		LayerProvokingVertex,
		// Token: 0x04001892 RID: 6290
		ViewportIndexProvokingVertex,
		// Token: 0x04001893 RID: 6291
		UndefinedVertex,
		// Token: 0x04001894 RID: 6292
		NoResetNotificationArb,
		// Token: 0x04001895 RID: 6293
		MaxComputeSharedMemorySize,
		// Token: 0x04001896 RID: 6294
		MaxComputeUniformComponents,
		// Token: 0x04001897 RID: 6295
		MaxComputeAtomicCounterBuffers,
		// Token: 0x04001898 RID: 6296
		MaxComputeAtomicCounters,
		// Token: 0x04001899 RID: 6297
		MaxCombinedComputeUniformComponents,
		// Token: 0x0400189A RID: 6298
		ComputeWorkGroupSize,
		// Token: 0x0400189B RID: 6299
		DebugTypeMarker,
		// Token: 0x0400189C RID: 6300
		DebugTypeMarkerKhr = 33384,
		// Token: 0x0400189D RID: 6301
		DebugTypePushGroup,
		// Token: 0x0400189E RID: 6302
		DebugTypePushGroupKhr = 33385,
		// Token: 0x0400189F RID: 6303
		DebugTypePopGroup,
		// Token: 0x040018A0 RID: 6304
		DebugTypePopGroupKhr = 33386,
		// Token: 0x040018A1 RID: 6305
		DebugSeverityNotification,
		// Token: 0x040018A2 RID: 6306
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x040018A3 RID: 6307
		MaxDebugGroupStackDepth,
		// Token: 0x040018A4 RID: 6308
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x040018A5 RID: 6309
		DebugGroupStackDepth,
		// Token: 0x040018A6 RID: 6310
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x040018A7 RID: 6311
		MaxUniformLocations,
		// Token: 0x040018A8 RID: 6312
		InternalformatSupported,
		// Token: 0x040018A9 RID: 6313
		InternalformatPreferred,
		// Token: 0x040018AA RID: 6314
		InternalformatRedSize,
		// Token: 0x040018AB RID: 6315
		InternalformatGreenSize,
		// Token: 0x040018AC RID: 6316
		InternalformatBlueSize,
		// Token: 0x040018AD RID: 6317
		InternalformatAlphaSize,
		// Token: 0x040018AE RID: 6318
		InternalformatDepthSize,
		// Token: 0x040018AF RID: 6319
		InternalformatStencilSize,
		// Token: 0x040018B0 RID: 6320
		InternalformatSharedSize,
		// Token: 0x040018B1 RID: 6321
		InternalformatRedType,
		// Token: 0x040018B2 RID: 6322
		InternalformatGreenType,
		// Token: 0x040018B3 RID: 6323
		InternalformatBlueType,
		// Token: 0x040018B4 RID: 6324
		InternalformatAlphaType,
		// Token: 0x040018B5 RID: 6325
		InternalformatDepthType,
		// Token: 0x040018B6 RID: 6326
		InternalformatStencilType,
		// Token: 0x040018B7 RID: 6327
		MaxWidth,
		// Token: 0x040018B8 RID: 6328
		MaxHeight,
		// Token: 0x040018B9 RID: 6329
		MaxDepth,
		// Token: 0x040018BA RID: 6330
		MaxLayers,
		// Token: 0x040018BB RID: 6331
		MaxCombinedDimensions,
		// Token: 0x040018BC RID: 6332
		ColorComponents,
		// Token: 0x040018BD RID: 6333
		DepthComponents,
		// Token: 0x040018BE RID: 6334
		StencilComponents,
		// Token: 0x040018BF RID: 6335
		ColorRenderable,
		// Token: 0x040018C0 RID: 6336
		DepthRenderable,
		// Token: 0x040018C1 RID: 6337
		StencilRenderable,
		// Token: 0x040018C2 RID: 6338
		FramebufferRenderable,
		// Token: 0x040018C3 RID: 6339
		FramebufferRenderableLayered,
		// Token: 0x040018C4 RID: 6340
		FramebufferBlend,
		// Token: 0x040018C5 RID: 6341
		ReadPixels,
		// Token: 0x040018C6 RID: 6342
		ReadPixelsFormat,
		// Token: 0x040018C7 RID: 6343
		ReadPixelsType,
		// Token: 0x040018C8 RID: 6344
		TextureImageFormat,
		// Token: 0x040018C9 RID: 6345
		TextureImageType,
		// Token: 0x040018CA RID: 6346
		GetTextureImageFormat,
		// Token: 0x040018CB RID: 6347
		GetTextureImageType,
		// Token: 0x040018CC RID: 6348
		Mipmap,
		// Token: 0x040018CD RID: 6349
		ManualGenerateMipmap,
		// Token: 0x040018CE RID: 6350
		AutoGenerateMipmap,
		// Token: 0x040018CF RID: 6351
		ColorEncoding,
		// Token: 0x040018D0 RID: 6352
		SrgbRead,
		// Token: 0x040018D1 RID: 6353
		SrgbWrite,
		// Token: 0x040018D2 RID: 6354
		SrgbDecodeArb,
		// Token: 0x040018D3 RID: 6355
		Filter,
		// Token: 0x040018D4 RID: 6356
		VertexTexture,
		// Token: 0x040018D5 RID: 6357
		TessControlTexture,
		// Token: 0x040018D6 RID: 6358
		TessEvaluationTexture,
		// Token: 0x040018D7 RID: 6359
		GeometryTexture,
		// Token: 0x040018D8 RID: 6360
		FragmentTexture,
		// Token: 0x040018D9 RID: 6361
		ComputeTexture,
		// Token: 0x040018DA RID: 6362
		TextureShadow,
		// Token: 0x040018DB RID: 6363
		TextureGather,
		// Token: 0x040018DC RID: 6364
		TextureGatherShadow,
		// Token: 0x040018DD RID: 6365
		ShaderImageLoad,
		// Token: 0x040018DE RID: 6366
		ShaderImageStore,
		// Token: 0x040018DF RID: 6367
		ShaderImageAtomic,
		// Token: 0x040018E0 RID: 6368
		ImageTexelSize,
		// Token: 0x040018E1 RID: 6369
		ImageCompatibilityClass,
		// Token: 0x040018E2 RID: 6370
		ImagePixelFormat,
		// Token: 0x040018E3 RID: 6371
		ImagePixelType,
		// Token: 0x040018E4 RID: 6372
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x040018E5 RID: 6373
		SimultaneousTextureAndStencilTest,
		// Token: 0x040018E6 RID: 6374
		SimultaneousTextureAndDepthWrite,
		// Token: 0x040018E7 RID: 6375
		SimultaneousTextureAndStencilWrite,
		// Token: 0x040018E8 RID: 6376
		TextureCompressedBlockWidth = 33457,
		// Token: 0x040018E9 RID: 6377
		TextureCompressedBlockHeight,
		// Token: 0x040018EA RID: 6378
		TextureCompressedBlockSize,
		// Token: 0x040018EB RID: 6379
		ClearBuffer,
		// Token: 0x040018EC RID: 6380
		TextureView,
		// Token: 0x040018ED RID: 6381
		ViewCompatibilityClass,
		// Token: 0x040018EE RID: 6382
		FullSupport,
		// Token: 0x040018EF RID: 6383
		CaveatSupport,
		// Token: 0x040018F0 RID: 6384
		ImageClass4X32,
		// Token: 0x040018F1 RID: 6385
		ImageClass2X32,
		// Token: 0x040018F2 RID: 6386
		ImageClass1X32,
		// Token: 0x040018F3 RID: 6387
		ImageClass4X16,
		// Token: 0x040018F4 RID: 6388
		ImageClass2X16,
		// Token: 0x040018F5 RID: 6389
		ImageClass1X16,
		// Token: 0x040018F6 RID: 6390
		ImageClass4X8,
		// Token: 0x040018F7 RID: 6391
		ImageClass2X8,
		// Token: 0x040018F8 RID: 6392
		ImageClass1X8,
		// Token: 0x040018F9 RID: 6393
		ImageClass111110,
		// Token: 0x040018FA RID: 6394
		ImageClass1010102,
		// Token: 0x040018FB RID: 6395
		ViewClass128Bits,
		// Token: 0x040018FC RID: 6396
		ViewClass96Bits,
		// Token: 0x040018FD RID: 6397
		ViewClass64Bits,
		// Token: 0x040018FE RID: 6398
		ViewClass48Bits,
		// Token: 0x040018FF RID: 6399
		ViewClass32Bits,
		// Token: 0x04001900 RID: 6400
		ViewClass24Bits,
		// Token: 0x04001901 RID: 6401
		ViewClass16Bits,
		// Token: 0x04001902 RID: 6402
		ViewClass8Bits,
		// Token: 0x04001903 RID: 6403
		ViewClassS3tcDxt1Rgb,
		// Token: 0x04001904 RID: 6404
		ViewClassS3tcDxt1Rgba,
		// Token: 0x04001905 RID: 6405
		ViewClassS3tcDxt3Rgba,
		// Token: 0x04001906 RID: 6406
		ViewClassS3tcDxt5Rgba,
		// Token: 0x04001907 RID: 6407
		ViewClassRgtc1Red,
		// Token: 0x04001908 RID: 6408
		ViewClassRgtc2Rg,
		// Token: 0x04001909 RID: 6409
		ViewClassBptcUnorm,
		// Token: 0x0400190A RID: 6410
		ViewClassBptcFloat,
		// Token: 0x0400190B RID: 6411
		VertexAttribBinding,
		// Token: 0x0400190C RID: 6412
		VertexAttribRelativeOffset,
		// Token: 0x0400190D RID: 6413
		VertexBindingDivisor,
		// Token: 0x0400190E RID: 6414
		VertexBindingOffset,
		// Token: 0x0400190F RID: 6415
		VertexBindingStride,
		// Token: 0x04001910 RID: 6416
		MaxVertexAttribRelativeOffset,
		// Token: 0x04001911 RID: 6417
		MaxVertexAttribBindings,
		// Token: 0x04001912 RID: 6418
		TextureViewMinLevel,
		// Token: 0x04001913 RID: 6419
		TextureViewNumLevels,
		// Token: 0x04001914 RID: 6420
		TextureViewMinLayer,
		// Token: 0x04001915 RID: 6421
		TextureViewNumLayers,
		// Token: 0x04001916 RID: 6422
		TextureImmutableLevels,
		// Token: 0x04001917 RID: 6423
		Buffer,
		// Token: 0x04001918 RID: 6424
		BufferKhr = 33504,
		// Token: 0x04001919 RID: 6425
		Shader,
		// Token: 0x0400191A RID: 6426
		ShaderKhr = 33505,
		// Token: 0x0400191B RID: 6427
		Program,
		// Token: 0x0400191C RID: 6428
		ProgramKhr = 33506,
		// Token: 0x0400191D RID: 6429
		Query,
		// Token: 0x0400191E RID: 6430
		QueryKhr = 33507,
		// Token: 0x0400191F RID: 6431
		ProgramPipeline,
		// Token: 0x04001920 RID: 6432
		MaxVertexAttribStride,
		// Token: 0x04001921 RID: 6433
		Sampler,
		// Token: 0x04001922 RID: 6434
		SamplerKhr = 33510,
		// Token: 0x04001923 RID: 6435
		DisplayList,
		// Token: 0x04001924 RID: 6436
		MaxLabelLength,
		// Token: 0x04001925 RID: 6437
		MaxLabelLengthKhr = 33512,
		// Token: 0x04001926 RID: 6438
		NumShadingLanguageVersions,
		// Token: 0x04001927 RID: 6439
		ConvolutionHintSgix = 33558,
		// Token: 0x04001928 RID: 6440
		YcrcbSgix = 33560,
		// Token: 0x04001929 RID: 6441
		YcrcbaSgix,
		// Token: 0x0400192A RID: 6442
		AlphaMinSgix = 33568,
		// Token: 0x0400192B RID: 6443
		AlphaMaxSgix,
		// Token: 0x0400192C RID: 6444
		ScalebiasHintSgix,
		// Token: 0x0400192D RID: 6445
		AsyncMarkerSgix = 33577,
		// Token: 0x0400192E RID: 6446
		PixelTexGenModeSgix = 33579,
		// Token: 0x0400192F RID: 6447
		AsyncHistogramSgix,
		// Token: 0x04001930 RID: 6448
		MaxAsyncHistogramSgix,
		// Token: 0x04001931 RID: 6449
		PixelTransform2DExt = 33584,
		// Token: 0x04001932 RID: 6450
		PixelMagFilterExt,
		// Token: 0x04001933 RID: 6451
		PixelMinFilterExt,
		// Token: 0x04001934 RID: 6452
		PixelCubicWeightExt,
		// Token: 0x04001935 RID: 6453
		CubicExt,
		// Token: 0x04001936 RID: 6454
		AverageExt,
		// Token: 0x04001937 RID: 6455
		PixelTransform2DStackDepthExt,
		// Token: 0x04001938 RID: 6456
		MaxPixelTransform2DStackDepthExt,
		// Token: 0x04001939 RID: 6457
		PixelTransform2DMatrixExt,
		// Token: 0x0400193A RID: 6458
		FragmentMaterialExt = 33609,
		// Token: 0x0400193B RID: 6459
		FragmentNormalExt,
		// Token: 0x0400193C RID: 6460
		FragmentColorExt = 33612,
		// Token: 0x0400193D RID: 6461
		AttenuationExt,
		// Token: 0x0400193E RID: 6462
		ShadowAttenuationExt,
		// Token: 0x0400193F RID: 6463
		TextureApplicationModeExt,
		// Token: 0x04001940 RID: 6464
		TextureLightExt,
		// Token: 0x04001941 RID: 6465
		TextureMaterialFaceExt,
		// Token: 0x04001942 RID: 6466
		TextureMaterialParameterExt,
		// Token: 0x04001943 RID: 6467
		PixelTextureSgis,
		// Token: 0x04001944 RID: 6468
		PixelFragmentRgbSourceSgis,
		// Token: 0x04001945 RID: 6469
		PixelFragmentAlphaSourceSgis,
		// Token: 0x04001946 RID: 6470
		PixelGroupColorSgis,
		// Token: 0x04001947 RID: 6471
		LineQualityHintSgix = 33627,
		// Token: 0x04001948 RID: 6472
		AsyncTexImageSgix,
		// Token: 0x04001949 RID: 6473
		AsyncDrawPixelsSgix,
		// Token: 0x0400194A RID: 6474
		AsyncReadPixelsSgix,
		// Token: 0x0400194B RID: 6475
		MaxAsyncTexImageSgix,
		// Token: 0x0400194C RID: 6476
		MaxAsyncDrawPixelsSgix,
		// Token: 0x0400194D RID: 6477
		MaxAsyncReadPixelsSgix,
		// Token: 0x0400194E RID: 6478
		UnsignedByte233Rev,
		// Token: 0x0400194F RID: 6479
		UnsignedByte233Reversed = 33634,
		// Token: 0x04001950 RID: 6480
		UnsignedShort565,
		// Token: 0x04001951 RID: 6481
		UnsignedShort565Rev,
		// Token: 0x04001952 RID: 6482
		UnsignedShort565Reversed = 33636,
		// Token: 0x04001953 RID: 6483
		UnsignedShort4444Rev,
		// Token: 0x04001954 RID: 6484
		UnsignedShort4444Reversed = 33637,
		// Token: 0x04001955 RID: 6485
		UnsignedShort1555Rev,
		// Token: 0x04001956 RID: 6486
		UnsignedShort1555Reversed = 33638,
		// Token: 0x04001957 RID: 6487
		UnsignedInt8888Rev,
		// Token: 0x04001958 RID: 6488
		UnsignedInt8888Reversed = 33639,
		// Token: 0x04001959 RID: 6489
		UnsignedInt2101010Rev,
		// Token: 0x0400195A RID: 6490
		UnsignedInt2101010Reversed = 33640,
		// Token: 0x0400195B RID: 6491
		TextureMaxClampSSgix,
		// Token: 0x0400195C RID: 6492
		TextureMaxClampTSgix,
		// Token: 0x0400195D RID: 6493
		TextureMaxClampRSgix,
		// Token: 0x0400195E RID: 6494
		MirroredRepeat = 33648,
		// Token: 0x0400195F RID: 6495
		MirroredRepeatArb = 33648,
		// Token: 0x04001960 RID: 6496
		MirroredRepeatIbm = 33648,
		// Token: 0x04001961 RID: 6497
		RgbS3tc = 33696,
		// Token: 0x04001962 RID: 6498
		Rgb4S3tc,
		// Token: 0x04001963 RID: 6499
		RgbaS3tc,
		// Token: 0x04001964 RID: 6500
		Rgba4S3tc,
		// Token: 0x04001965 RID: 6501
		RgbaDxt5S3tc,
		// Token: 0x04001966 RID: 6502
		Rgba4Dxt5S3tc,
		// Token: 0x04001967 RID: 6503
		VertexPreclipSgix = 33774,
		// Token: 0x04001968 RID: 6504
		VertexPreclipHintSgix,
		// Token: 0x04001969 RID: 6505
		CompressedRgbS3tcDxt1Ext,
		// Token: 0x0400196A RID: 6506
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x0400196B RID: 6507
		CompressedRgbaS3tcDxt3Ext,
		// Token: 0x0400196C RID: 6508
		CompressedRgbaS3tcDxt5Ext,
		// Token: 0x0400196D RID: 6509
		ParallelArraysIntel,
		// Token: 0x0400196E RID: 6510
		VertexArrayParallelPointersIntel,
		// Token: 0x0400196F RID: 6511
		NormalArrayParallelPointersIntel,
		// Token: 0x04001970 RID: 6512
		ColorArrayParallelPointersIntel,
		// Token: 0x04001971 RID: 6513
		TextureCoordArrayParallelPointersIntel,
		// Token: 0x04001972 RID: 6514
		PerfqueryDonotFlushIntel,
		// Token: 0x04001973 RID: 6515
		PerfqueryFlushIntel,
		// Token: 0x04001974 RID: 6516
		PerfqueryWaitIntel,
		// Token: 0x04001975 RID: 6517
		TextureMemoryLayoutIntel = 33791,
		// Token: 0x04001976 RID: 6518
		FragmentLightingSgix,
		// Token: 0x04001977 RID: 6519
		FragmentColorMaterialSgix,
		// Token: 0x04001978 RID: 6520
		FragmentColorMaterialFaceSgix,
		// Token: 0x04001979 RID: 6521
		FragmentColorMaterialParameterSgix,
		// Token: 0x0400197A RID: 6522
		MaxFragmentLightsSgix,
		// Token: 0x0400197B RID: 6523
		MaxActiveLightsSgix,
		// Token: 0x0400197C RID: 6524
		CurrentRasterNormalSgix,
		// Token: 0x0400197D RID: 6525
		LightEnvModeSgix,
		// Token: 0x0400197E RID: 6526
		FragmentLightModelLocalViewerSgix,
		// Token: 0x0400197F RID: 6527
		FragmentLightModelTwoSideSgix,
		// Token: 0x04001980 RID: 6528
		FragmentLightModelAmbientSgix,
		// Token: 0x04001981 RID: 6529
		FragmentLightModelNormalInterpolationSgix,
		// Token: 0x04001982 RID: 6530
		FragmentLight0Sgix,
		// Token: 0x04001983 RID: 6531
		FragmentLight1Sgix,
		// Token: 0x04001984 RID: 6532
		FragmentLight2Sgix,
		// Token: 0x04001985 RID: 6533
		FragmentLight3Sgix,
		// Token: 0x04001986 RID: 6534
		FragmentLight4Sgix,
		// Token: 0x04001987 RID: 6535
		FragmentLight5Sgix,
		// Token: 0x04001988 RID: 6536
		FragmentLight6Sgix,
		// Token: 0x04001989 RID: 6537
		FragmentLight7Sgix,
		// Token: 0x0400198A RID: 6538
		PackResampleSgix = 33836,
		// Token: 0x0400198B RID: 6539
		UnpackResampleSgix,
		// Token: 0x0400198C RID: 6540
		ResampleReplicateSgix,
		// Token: 0x0400198D RID: 6541
		ResampleZeroFillSgix,
		// Token: 0x0400198E RID: 6542
		ResampleDecimateSgix,
		// Token: 0x0400198F RID: 6543
		TangentArrayExt = 33849,
		// Token: 0x04001990 RID: 6544
		BinormalArrayExt,
		// Token: 0x04001991 RID: 6545
		CurrentTangentExt,
		// Token: 0x04001992 RID: 6546
		CurrentBinormalExt,
		// Token: 0x04001993 RID: 6547
		TangentArrayTypeExt = 33854,
		// Token: 0x04001994 RID: 6548
		TangentArrayStrideExt,
		// Token: 0x04001995 RID: 6549
		BinormalArrayTypeExt,
		// Token: 0x04001996 RID: 6550
		BinormalArrayStrideExt,
		// Token: 0x04001997 RID: 6551
		TangentArrayPointerExt,
		// Token: 0x04001998 RID: 6552
		BinormalArrayPointerExt,
		// Token: 0x04001999 RID: 6553
		Map1TangentExt,
		// Token: 0x0400199A RID: 6554
		Map2TangentExt,
		// Token: 0x0400199B RID: 6555
		Map1BinormalExt,
		// Token: 0x0400199C RID: 6556
		Map2BinormalExt,
		// Token: 0x0400199D RID: 6557
		NearestClipmapNearestSgix = 33869,
		// Token: 0x0400199E RID: 6558
		NearestClipmapLinearSgix,
		// Token: 0x0400199F RID: 6559
		LinearClipmapNearestSgix,
		// Token: 0x040019A0 RID: 6560
		FogCoordinateSource,
		// Token: 0x040019A1 RID: 6561
		FogCoordinateSourceExt = 33872,
		// Token: 0x040019A2 RID: 6562
		FogCoordSrc = 33872,
		// Token: 0x040019A3 RID: 6563
		FogCoord,
		// Token: 0x040019A4 RID: 6564
		FogCoordinate = 33873,
		// Token: 0x040019A5 RID: 6565
		FogCoordinateExt = 33873,
		// Token: 0x040019A6 RID: 6566
		FragmentDepth,
		// Token: 0x040019A7 RID: 6567
		FragmentDepthExt = 33874,
		// Token: 0x040019A8 RID: 6568
		CurrentFogCoord,
		// Token: 0x040019A9 RID: 6569
		CurrentFogCoordinate = 33875,
		// Token: 0x040019AA RID: 6570
		CurrentFogCoordinateExt = 33875,
		// Token: 0x040019AB RID: 6571
		FogCoordArrayType,
		// Token: 0x040019AC RID: 6572
		FogCoordinateArrayType = 33876,
		// Token: 0x040019AD RID: 6573
		FogCoordinateArrayTypeExt = 33876,
		// Token: 0x040019AE RID: 6574
		FogCoordArrayStride,
		// Token: 0x040019AF RID: 6575
		FogCoordinateArrayStride = 33877,
		// Token: 0x040019B0 RID: 6576
		FogCoordinateArrayStrideExt = 33877,
		// Token: 0x040019B1 RID: 6577
		FogCoordArrayPointer,
		// Token: 0x040019B2 RID: 6578
		FogCoordinateArrayPointer = 33878,
		// Token: 0x040019B3 RID: 6579
		FogCoordinateArrayPointerExt = 33878,
		// Token: 0x040019B4 RID: 6580
		FogCoordArray,
		// Token: 0x040019B5 RID: 6581
		FogCoordinateArray = 33879,
		// Token: 0x040019B6 RID: 6582
		FogCoordinateArrayExt = 33879,
		// Token: 0x040019B7 RID: 6583
		ColorSum,
		// Token: 0x040019B8 RID: 6584
		ColorSumArb = 33880,
		// Token: 0x040019B9 RID: 6585
		ColorSumExt = 33880,
		// Token: 0x040019BA RID: 6586
		CurrentSecondaryColor,
		// Token: 0x040019BB RID: 6587
		CurrentSecondaryColorExt = 33881,
		// Token: 0x040019BC RID: 6588
		SecondaryColorArraySize,
		// Token: 0x040019BD RID: 6589
		SecondaryColorArraySizeExt = 33882,
		// Token: 0x040019BE RID: 6590
		SecondaryColorArrayType,
		// Token: 0x040019BF RID: 6591
		SecondaryColorArrayTypeExt = 33883,
		// Token: 0x040019C0 RID: 6592
		SecondaryColorArrayStride,
		// Token: 0x040019C1 RID: 6593
		SecondaryColorArrayStrideExt = 33884,
		// Token: 0x040019C2 RID: 6594
		SecondaryColorArrayPointer,
		// Token: 0x040019C3 RID: 6595
		SecondaryColorArrayPointerExt = 33885,
		// Token: 0x040019C4 RID: 6596
		SecondaryColorArray,
		// Token: 0x040019C5 RID: 6597
		SecondaryColorArrayExt = 33886,
		// Token: 0x040019C6 RID: 6598
		CurrentRasterSecondaryColor,
		// Token: 0x040019C7 RID: 6599
		RgbIccSgix,
		// Token: 0x040019C8 RID: 6600
		RgbaIccSgix,
		// Token: 0x040019C9 RID: 6601
		AlphaIccSgix,
		// Token: 0x040019CA RID: 6602
		LuminanceIccSgix,
		// Token: 0x040019CB RID: 6603
		IntensityIccSgix,
		// Token: 0x040019CC RID: 6604
		LuminanceAlphaIccSgix,
		// Token: 0x040019CD RID: 6605
		R5G6B5IccSgix,
		// Token: 0x040019CE RID: 6606
		R5G6B5A8IccSgix,
		// Token: 0x040019CF RID: 6607
		Alpha16IccSgix,
		// Token: 0x040019D0 RID: 6608
		Luminance16IccSgix,
		// Token: 0x040019D1 RID: 6609
		Intensity16IccSgix,
		// Token: 0x040019D2 RID: 6610
		Luminance16Alpha8IccSgix,
		// Token: 0x040019D3 RID: 6611
		AliasedPointSizeRange = 33901,
		// Token: 0x040019D4 RID: 6612
		AliasedLineWidthRange,
		// Token: 0x040019D5 RID: 6613
		ScreenCoordinatesRend = 33936,
		// Token: 0x040019D6 RID: 6614
		InvertedScreenWRend,
		// Token: 0x040019D7 RID: 6615
		Texture0 = 33984,
		// Token: 0x040019D8 RID: 6616
		Texture0Arb = 33984,
		// Token: 0x040019D9 RID: 6617
		Texture1,
		// Token: 0x040019DA RID: 6618
		Texture1Arb = 33985,
		// Token: 0x040019DB RID: 6619
		Texture2,
		// Token: 0x040019DC RID: 6620
		Texture2Arb = 33986,
		// Token: 0x040019DD RID: 6621
		Texture3,
		// Token: 0x040019DE RID: 6622
		Texture3Arb = 33987,
		// Token: 0x040019DF RID: 6623
		Texture4,
		// Token: 0x040019E0 RID: 6624
		Texture4Arb = 33988,
		// Token: 0x040019E1 RID: 6625
		Texture5,
		// Token: 0x040019E2 RID: 6626
		Texture5Arb = 33989,
		// Token: 0x040019E3 RID: 6627
		Texture6,
		// Token: 0x040019E4 RID: 6628
		Texture6Arb = 33990,
		// Token: 0x040019E5 RID: 6629
		Texture7,
		// Token: 0x040019E6 RID: 6630
		Texture7Arb = 33991,
		// Token: 0x040019E7 RID: 6631
		Texture8,
		// Token: 0x040019E8 RID: 6632
		Texture8Arb = 33992,
		// Token: 0x040019E9 RID: 6633
		Texture9,
		// Token: 0x040019EA RID: 6634
		Texture9Arb = 33993,
		// Token: 0x040019EB RID: 6635
		Texture10,
		// Token: 0x040019EC RID: 6636
		Texture10Arb = 33994,
		// Token: 0x040019ED RID: 6637
		Texture11,
		// Token: 0x040019EE RID: 6638
		Texture11Arb = 33995,
		// Token: 0x040019EF RID: 6639
		Texture12,
		// Token: 0x040019F0 RID: 6640
		Texture12Arb = 33996,
		// Token: 0x040019F1 RID: 6641
		Texture13,
		// Token: 0x040019F2 RID: 6642
		Texture13Arb = 33997,
		// Token: 0x040019F3 RID: 6643
		Texture14,
		// Token: 0x040019F4 RID: 6644
		Texture14Arb = 33998,
		// Token: 0x040019F5 RID: 6645
		Texture15,
		// Token: 0x040019F6 RID: 6646
		Texture15Arb = 33999,
		// Token: 0x040019F7 RID: 6647
		Texture16,
		// Token: 0x040019F8 RID: 6648
		Texture16Arb = 34000,
		// Token: 0x040019F9 RID: 6649
		Texture17,
		// Token: 0x040019FA RID: 6650
		Texture17Arb = 34001,
		// Token: 0x040019FB RID: 6651
		Texture18,
		// Token: 0x040019FC RID: 6652
		Texture18Arb = 34002,
		// Token: 0x040019FD RID: 6653
		Texture19,
		// Token: 0x040019FE RID: 6654
		Texture19Arb = 34003,
		// Token: 0x040019FF RID: 6655
		Texture20,
		// Token: 0x04001A00 RID: 6656
		Texture20Arb = 34004,
		// Token: 0x04001A01 RID: 6657
		Texture21,
		// Token: 0x04001A02 RID: 6658
		Texture21Arb = 34005,
		// Token: 0x04001A03 RID: 6659
		Texture22,
		// Token: 0x04001A04 RID: 6660
		Texture22Arb = 34006,
		// Token: 0x04001A05 RID: 6661
		Texture23,
		// Token: 0x04001A06 RID: 6662
		Texture23Arb = 34007,
		// Token: 0x04001A07 RID: 6663
		Texture24,
		// Token: 0x04001A08 RID: 6664
		Texture24Arb = 34008,
		// Token: 0x04001A09 RID: 6665
		Texture25,
		// Token: 0x04001A0A RID: 6666
		Texture25Arb = 34009,
		// Token: 0x04001A0B RID: 6667
		Texture26,
		// Token: 0x04001A0C RID: 6668
		Texture26Arb = 34010,
		// Token: 0x04001A0D RID: 6669
		Texture27,
		// Token: 0x04001A0E RID: 6670
		Texture27Arb = 34011,
		// Token: 0x04001A0F RID: 6671
		Texture28,
		// Token: 0x04001A10 RID: 6672
		Texture28Arb = 34012,
		// Token: 0x04001A11 RID: 6673
		Texture29,
		// Token: 0x04001A12 RID: 6674
		Texture29Arb = 34013,
		// Token: 0x04001A13 RID: 6675
		Texture30,
		// Token: 0x04001A14 RID: 6676
		Texture30Arb = 34014,
		// Token: 0x04001A15 RID: 6677
		Texture31,
		// Token: 0x04001A16 RID: 6678
		Texture31Arb = 34015,
		// Token: 0x04001A17 RID: 6679
		ActiveTexture,
		// Token: 0x04001A18 RID: 6680
		ActiveTextureArb = 34016,
		// Token: 0x04001A19 RID: 6681
		ClientActiveTexture,
		// Token: 0x04001A1A RID: 6682
		ClientActiveTextureArb = 34017,
		// Token: 0x04001A1B RID: 6683
		MaxTextureUnits,
		// Token: 0x04001A1C RID: 6684
		MaxTextureUnitsArb = 34018,
		// Token: 0x04001A1D RID: 6685
		TransposeModelviewMatrix,
		// Token: 0x04001A1E RID: 6686
		TransposeModelviewMatrixArb = 34019,
		// Token: 0x04001A1F RID: 6687
		TransposeProjectionMatrix,
		// Token: 0x04001A20 RID: 6688
		TransposeProjectionMatrixArb = 34020,
		// Token: 0x04001A21 RID: 6689
		TransposeTextureMatrix,
		// Token: 0x04001A22 RID: 6690
		TransposeTextureMatrixArb = 34021,
		// Token: 0x04001A23 RID: 6691
		TransposeColorMatrix,
		// Token: 0x04001A24 RID: 6692
		TransposeColorMatrixArb = 34022,
		// Token: 0x04001A25 RID: 6693
		Subtract,
		// Token: 0x04001A26 RID: 6694
		SubtractArb = 34023,
		// Token: 0x04001A27 RID: 6695
		MaxRenderbufferSize,
		// Token: 0x04001A28 RID: 6696
		MaxRenderbufferSizeExt = 34024,
		// Token: 0x04001A29 RID: 6697
		CompressedAlpha,
		// Token: 0x04001A2A RID: 6698
		CompressedAlphaArb = 34025,
		// Token: 0x04001A2B RID: 6699
		CompressedLuminance,
		// Token: 0x04001A2C RID: 6700
		CompressedLuminanceArb = 34026,
		// Token: 0x04001A2D RID: 6701
		CompressedLuminanceAlpha,
		// Token: 0x04001A2E RID: 6702
		CompressedLuminanceAlphaArb = 34027,
		// Token: 0x04001A2F RID: 6703
		CompressedIntensity,
		// Token: 0x04001A30 RID: 6704
		CompressedIntensityArb = 34028,
		// Token: 0x04001A31 RID: 6705
		CompressedRgb,
		// Token: 0x04001A32 RID: 6706
		CompressedRgbArb = 34029,
		// Token: 0x04001A33 RID: 6707
		CompressedRgba,
		// Token: 0x04001A34 RID: 6708
		CompressedRgbaArb = 34030,
		// Token: 0x04001A35 RID: 6709
		TextureCompressionHint,
		// Token: 0x04001A36 RID: 6710
		TextureCompressionHintArb = 34031,
		// Token: 0x04001A37 RID: 6711
		UniformBlockReferencedByTessControlShader,
		// Token: 0x04001A38 RID: 6712
		UniformBlockReferencedByTessEvaluationShader,
		// Token: 0x04001A39 RID: 6713
		AllCompletedNv,
		// Token: 0x04001A3A RID: 6714
		FenceStatusNv,
		// Token: 0x04001A3B RID: 6715
		FenceConditionNv,
		// Token: 0x04001A3C RID: 6716
		TextureRectangle,
		// Token: 0x04001A3D RID: 6717
		TextureRectangleArb = 34037,
		// Token: 0x04001A3E RID: 6718
		TextureRectangleNv = 34037,
		// Token: 0x04001A3F RID: 6719
		TextureBindingRectangle,
		// Token: 0x04001A40 RID: 6720
		TextureBindingRectangleArb = 34038,
		// Token: 0x04001A41 RID: 6721
		TextureBindingRectangleNv = 34038,
		// Token: 0x04001A42 RID: 6722
		ProxyTextureRectangle,
		// Token: 0x04001A43 RID: 6723
		ProxyTextureRectangleArb = 34039,
		// Token: 0x04001A44 RID: 6724
		ProxyTextureRectangleNv = 34039,
		// Token: 0x04001A45 RID: 6725
		MaxRectangleTextureSize,
		// Token: 0x04001A46 RID: 6726
		MaxRectangleTextureSizeArb = 34040,
		// Token: 0x04001A47 RID: 6727
		MaxRectangleTextureSizeNv = 34040,
		// Token: 0x04001A48 RID: 6728
		DepthStencil,
		// Token: 0x04001A49 RID: 6729
		DepthStencilExt = 34041,
		// Token: 0x04001A4A RID: 6730
		DepthStencilNv = 34041,
		// Token: 0x04001A4B RID: 6731
		UnsignedInt248,
		// Token: 0x04001A4C RID: 6732
		UnsignedInt248Ext = 34042,
		// Token: 0x04001A4D RID: 6733
		UnsignedInt248Nv = 34042,
		// Token: 0x04001A4E RID: 6734
		MaxTextureLodBias = 34045,
		// Token: 0x04001A4F RID: 6735
		MaxTextureLodBiasExt = 34045,
		// Token: 0x04001A50 RID: 6736
		TextureMaxAnisotropyExt,
		// Token: 0x04001A51 RID: 6737
		MaxTextureMaxAnisotropyExt,
		// Token: 0x04001A52 RID: 6738
		TextureFilterControl,
		// Token: 0x04001A53 RID: 6739
		TextureFilterControlExt = 34048,
		// Token: 0x04001A54 RID: 6740
		TextureLodBias,
		// Token: 0x04001A55 RID: 6741
		TextureLodBiasExt = 34049,
		// Token: 0x04001A56 RID: 6742
		Modelview1StackDepthExt,
		// Token: 0x04001A57 RID: 6743
		Combine4Nv,
		// Token: 0x04001A58 RID: 6744
		MaxShininessNv,
		// Token: 0x04001A59 RID: 6745
		MaxSpotExponentNv,
		// Token: 0x04001A5A RID: 6746
		Modelview1MatrixExt,
		// Token: 0x04001A5B RID: 6747
		IncrWrap,
		// Token: 0x04001A5C RID: 6748
		IncrWrapExt = 34055,
		// Token: 0x04001A5D RID: 6749
		DecrWrap,
		// Token: 0x04001A5E RID: 6750
		DecrWrapExt = 34056,
		// Token: 0x04001A5F RID: 6751
		VertexWeightingExt,
		// Token: 0x04001A60 RID: 6752
		Modelview1Arb,
		// Token: 0x04001A61 RID: 6753
		Modelview1Ext = 34058,
		// Token: 0x04001A62 RID: 6754
		CurrentVertexWeightExt,
		// Token: 0x04001A63 RID: 6755
		VertexWeightArrayExt,
		// Token: 0x04001A64 RID: 6756
		VertexWeightArraySizeExt,
		// Token: 0x04001A65 RID: 6757
		VertexWeightArrayTypeExt,
		// Token: 0x04001A66 RID: 6758
		VertexWeightArrayStrideExt,
		// Token: 0x04001A67 RID: 6759
		VertexWeightArrayPointerExt,
		// Token: 0x04001A68 RID: 6760
		NormalMap,
		// Token: 0x04001A69 RID: 6761
		NormalMapArb = 34065,
		// Token: 0x04001A6A RID: 6762
		NormalMapExt = 34065,
		// Token: 0x04001A6B RID: 6763
		NormalMapNv = 34065,
		// Token: 0x04001A6C RID: 6764
		ReflectionMap,
		// Token: 0x04001A6D RID: 6765
		ReflectionMapArb = 34066,
		// Token: 0x04001A6E RID: 6766
		ReflectionMapExt = 34066,
		// Token: 0x04001A6F RID: 6767
		ReflectionMapNv = 34066,
		// Token: 0x04001A70 RID: 6768
		TextureCubeMap,
		// Token: 0x04001A71 RID: 6769
		TextureCubeMapArb = 34067,
		// Token: 0x04001A72 RID: 6770
		TextureCubeMapExt = 34067,
		// Token: 0x04001A73 RID: 6771
		TextureBindingCubeMap,
		// Token: 0x04001A74 RID: 6772
		TextureBindingCubeMapArb = 34068,
		// Token: 0x04001A75 RID: 6773
		TextureBindingCubeMapExt = 34068,
		// Token: 0x04001A76 RID: 6774
		TextureCubeMapPositiveX,
		// Token: 0x04001A77 RID: 6775
		TextureCubeMapPositiveXArb = 34069,
		// Token: 0x04001A78 RID: 6776
		TextureCubeMapPositiveXExt = 34069,
		// Token: 0x04001A79 RID: 6777
		TextureCubeMapNegativeX,
		// Token: 0x04001A7A RID: 6778
		TextureCubeMapNegativeXArb = 34070,
		// Token: 0x04001A7B RID: 6779
		TextureCubeMapNegativeXExt = 34070,
		// Token: 0x04001A7C RID: 6780
		TextureCubeMapPositiveY,
		// Token: 0x04001A7D RID: 6781
		TextureCubeMapPositiveYArb = 34071,
		// Token: 0x04001A7E RID: 6782
		TextureCubeMapPositiveYExt = 34071,
		// Token: 0x04001A7F RID: 6783
		TextureCubeMapNegativeY,
		// Token: 0x04001A80 RID: 6784
		TextureCubeMapNegativeYArb = 34072,
		// Token: 0x04001A81 RID: 6785
		TextureCubeMapNegativeYExt = 34072,
		// Token: 0x04001A82 RID: 6786
		TextureCubeMapPositiveZ,
		// Token: 0x04001A83 RID: 6787
		TextureCubeMapPositiveZArb = 34073,
		// Token: 0x04001A84 RID: 6788
		TextureCubeMapPositiveZExt = 34073,
		// Token: 0x04001A85 RID: 6789
		TextureCubeMapNegativeZ,
		// Token: 0x04001A86 RID: 6790
		TextureCubeMapNegativeZArb = 34074,
		// Token: 0x04001A87 RID: 6791
		TextureCubeMapNegativeZExt = 34074,
		// Token: 0x04001A88 RID: 6792
		ProxyTextureCubeMap,
		// Token: 0x04001A89 RID: 6793
		ProxyTextureCubeMapArb = 34075,
		// Token: 0x04001A8A RID: 6794
		ProxyTextureCubeMapExt = 34075,
		// Token: 0x04001A8B RID: 6795
		MaxCubeMapTextureSize,
		// Token: 0x04001A8C RID: 6796
		MaxCubeMapTextureSizeArb = 34076,
		// Token: 0x04001A8D RID: 6797
		MaxCubeMapTextureSizeExt = 34076,
		// Token: 0x04001A8E RID: 6798
		VertexArrayRangeApple,
		// Token: 0x04001A8F RID: 6799
		VertexArrayRangeNv = 34077,
		// Token: 0x04001A90 RID: 6800
		VertexArrayRangeLengthApple,
		// Token: 0x04001A91 RID: 6801
		VertexArrayRangeLengthNv = 34078,
		// Token: 0x04001A92 RID: 6802
		VertexArrayRangeValidNv,
		// Token: 0x04001A93 RID: 6803
		VertexArrayStorageHintApple = 34079,
		// Token: 0x04001A94 RID: 6804
		MaxVertexArrayRangeElementNv,
		// Token: 0x04001A95 RID: 6805
		VertexArrayRangePointerApple,
		// Token: 0x04001A96 RID: 6806
		VertexArrayRangePointerNv = 34081,
		// Token: 0x04001A97 RID: 6807
		RegisterCombinersNv,
		// Token: 0x04001A98 RID: 6808
		VariableANv,
		// Token: 0x04001A99 RID: 6809
		VariableBNv,
		// Token: 0x04001A9A RID: 6810
		VariableCNv,
		// Token: 0x04001A9B RID: 6811
		VariableDNv,
		// Token: 0x04001A9C RID: 6812
		VariableENv,
		// Token: 0x04001A9D RID: 6813
		VariableFNv,
		// Token: 0x04001A9E RID: 6814
		VariableGNv,
		// Token: 0x04001A9F RID: 6815
		ConstantColor0Nv,
		// Token: 0x04001AA0 RID: 6816
		ConstantColor1Nv,
		// Token: 0x04001AA1 RID: 6817
		PrimaryColorNv,
		// Token: 0x04001AA2 RID: 6818
		SecondaryColorNv,
		// Token: 0x04001AA3 RID: 6819
		Spare0Nv,
		// Token: 0x04001AA4 RID: 6820
		Spare1Nv,
		// Token: 0x04001AA5 RID: 6821
		DiscardNv,
		// Token: 0x04001AA6 RID: 6822
		ETimesFNv,
		// Token: 0x04001AA7 RID: 6823
		Spare0PlusSecondaryColorNv,
		// Token: 0x04001AA8 RID: 6824
		VertexArrayRangeWithoutFlushNv,
		// Token: 0x04001AA9 RID: 6825
		MultisampleFilterHintNv,
		// Token: 0x04001AAA RID: 6826
		PerStageConstantsNv,
		// Token: 0x04001AAB RID: 6827
		UnsignedIdentityNv,
		// Token: 0x04001AAC RID: 6828
		UnsignedInvertNv,
		// Token: 0x04001AAD RID: 6829
		ExpandNormalNv,
		// Token: 0x04001AAE RID: 6830
		ExpandNegateNv,
		// Token: 0x04001AAF RID: 6831
		HalfBiasNormalNv,
		// Token: 0x04001AB0 RID: 6832
		HalfBiasNegateNv,
		// Token: 0x04001AB1 RID: 6833
		SignedIdentityNv,
		// Token: 0x04001AB2 RID: 6834
		SignedNegateNv,
		// Token: 0x04001AB3 RID: 6835
		ScaleByTwoNv,
		// Token: 0x04001AB4 RID: 6836
		ScaleByFourNv,
		// Token: 0x04001AB5 RID: 6837
		ScaleByOneHalfNv,
		// Token: 0x04001AB6 RID: 6838
		BiasByNegativeOneHalfNv,
		// Token: 0x04001AB7 RID: 6839
		CombinerInputNv,
		// Token: 0x04001AB8 RID: 6840
		CombinerMappingNv,
		// Token: 0x04001AB9 RID: 6841
		CombinerComponentUsageNv,
		// Token: 0x04001ABA RID: 6842
		CombinerAbDotProductNv,
		// Token: 0x04001ABB RID: 6843
		CombinerCdDotProductNv,
		// Token: 0x04001ABC RID: 6844
		CombinerMuxSumNv,
		// Token: 0x04001ABD RID: 6845
		CombinerScaleNv,
		// Token: 0x04001ABE RID: 6846
		CombinerBiasNv,
		// Token: 0x04001ABF RID: 6847
		CombinerAbOutputNv,
		// Token: 0x04001AC0 RID: 6848
		CombinerCdOutputNv,
		// Token: 0x04001AC1 RID: 6849
		CombinerSumOutputNv,
		// Token: 0x04001AC2 RID: 6850
		MaxGeneralCombinersNv,
		// Token: 0x04001AC3 RID: 6851
		NumGeneralCombinersNv,
		// Token: 0x04001AC4 RID: 6852
		ColorSumClampNv,
		// Token: 0x04001AC5 RID: 6853
		Combiner0Nv,
		// Token: 0x04001AC6 RID: 6854
		Combiner1Nv,
		// Token: 0x04001AC7 RID: 6855
		Combiner2Nv,
		// Token: 0x04001AC8 RID: 6856
		Combiner3Nv,
		// Token: 0x04001AC9 RID: 6857
		Combiner4Nv,
		// Token: 0x04001ACA RID: 6858
		Combiner5Nv,
		// Token: 0x04001ACB RID: 6859
		Combiner6Nv,
		// Token: 0x04001ACC RID: 6860
		Combiner7Nv,
		// Token: 0x04001ACD RID: 6861
		PrimitiveRestartNv,
		// Token: 0x04001ACE RID: 6862
		PrimitiveRestartIndexNv,
		// Token: 0x04001ACF RID: 6863
		FogDistanceModeNv,
		// Token: 0x04001AD0 RID: 6864
		EyeRadialNv,
		// Token: 0x04001AD1 RID: 6865
		EyePlaneAbsoluteNv,
		// Token: 0x04001AD2 RID: 6866
		EmbossLightNv,
		// Token: 0x04001AD3 RID: 6867
		EmbossConstantNv,
		// Token: 0x04001AD4 RID: 6868
		EmbossMapNv,
		// Token: 0x04001AD5 RID: 6869
		RedMinClampIngr,
		// Token: 0x04001AD6 RID: 6870
		GreenMinClampIngr,
		// Token: 0x04001AD7 RID: 6871
		BlueMinClampIngr,
		// Token: 0x04001AD8 RID: 6872
		AlphaMinClampIngr,
		// Token: 0x04001AD9 RID: 6873
		RedMaxClampIngr,
		// Token: 0x04001ADA RID: 6874
		GreenMaxClampIngr,
		// Token: 0x04001ADB RID: 6875
		BlueMaxClampIngr,
		// Token: 0x04001ADC RID: 6876
		AlphaMaxClampIngr,
		// Token: 0x04001ADD RID: 6877
		InterlaceReadIngr,
		// Token: 0x04001ADE RID: 6878
		Combine = 34160,
		// Token: 0x04001ADF RID: 6879
		CombineArb = 34160,
		// Token: 0x04001AE0 RID: 6880
		CombineExt = 34160,
		// Token: 0x04001AE1 RID: 6881
		CombineRgb,
		// Token: 0x04001AE2 RID: 6882
		CombineRgbArb = 34161,
		// Token: 0x04001AE3 RID: 6883
		CombineRgbExt = 34161,
		// Token: 0x04001AE4 RID: 6884
		CombineAlpha,
		// Token: 0x04001AE5 RID: 6885
		CombineAlphaArb = 34162,
		// Token: 0x04001AE6 RID: 6886
		CombineAlphaExt = 34162,
		// Token: 0x04001AE7 RID: 6887
		RgbScale,
		// Token: 0x04001AE8 RID: 6888
		RgbScaleArb = 34163,
		// Token: 0x04001AE9 RID: 6889
		RgbScaleExt = 34163,
		// Token: 0x04001AEA RID: 6890
		AddSigned,
		// Token: 0x04001AEB RID: 6891
		AddSignedArb = 34164,
		// Token: 0x04001AEC RID: 6892
		AddSignedExt = 34164,
		// Token: 0x04001AED RID: 6893
		Interpolate,
		// Token: 0x04001AEE RID: 6894
		InterpolateArb = 34165,
		// Token: 0x04001AEF RID: 6895
		InterpolateExt = 34165,
		// Token: 0x04001AF0 RID: 6896
		Constant,
		// Token: 0x04001AF1 RID: 6897
		ConstantArb = 34166,
		// Token: 0x04001AF2 RID: 6898
		ConstantExt = 34166,
		// Token: 0x04001AF3 RID: 6899
		PrimaryColor,
		// Token: 0x04001AF4 RID: 6900
		PrimaryColorArb = 34167,
		// Token: 0x04001AF5 RID: 6901
		PrimaryColorExt = 34167,
		// Token: 0x04001AF6 RID: 6902
		Previous,
		// Token: 0x04001AF7 RID: 6903
		PreviousArb = 34168,
		// Token: 0x04001AF8 RID: 6904
		PreviousExt = 34168,
		// Token: 0x04001AF9 RID: 6905
		Source0Rgb = 34176,
		// Token: 0x04001AFA RID: 6906
		Source0RgbArb = 34176,
		// Token: 0x04001AFB RID: 6907
		Source0RgbExt = 34176,
		// Token: 0x04001AFC RID: 6908
		Src0Rgb = 34176,
		// Token: 0x04001AFD RID: 6909
		Source1Rgb,
		// Token: 0x04001AFE RID: 6910
		Source1RgbArb = 34177,
		// Token: 0x04001AFF RID: 6911
		Source1RgbExt = 34177,
		// Token: 0x04001B00 RID: 6912
		Src1Rgb = 34177,
		// Token: 0x04001B01 RID: 6913
		Source2Rgb,
		// Token: 0x04001B02 RID: 6914
		Source2RgbArb = 34178,
		// Token: 0x04001B03 RID: 6915
		Source2RgbExt = 34178,
		// Token: 0x04001B04 RID: 6916
		Src2Rgb = 34178,
		// Token: 0x04001B05 RID: 6917
		Source3RgbNv,
		// Token: 0x04001B06 RID: 6918
		Source0Alpha = 34184,
		// Token: 0x04001B07 RID: 6919
		Source0AlphaArb = 34184,
		// Token: 0x04001B08 RID: 6920
		Source0AlphaExt = 34184,
		// Token: 0x04001B09 RID: 6921
		Src0Alpha = 34184,
		// Token: 0x04001B0A RID: 6922
		Source1Alpha,
		// Token: 0x04001B0B RID: 6923
		Source1AlphaArb = 34185,
		// Token: 0x04001B0C RID: 6924
		Source1AlphaExt = 34185,
		// Token: 0x04001B0D RID: 6925
		Src1Alpha = 34185,
		// Token: 0x04001B0E RID: 6926
		Source2Alpha,
		// Token: 0x04001B0F RID: 6927
		Source2AlphaArb = 34186,
		// Token: 0x04001B10 RID: 6928
		Source2AlphaExt = 34186,
		// Token: 0x04001B11 RID: 6929
		Src2Alpha = 34186,
		// Token: 0x04001B12 RID: 6930
		Source3AlphaNv,
		// Token: 0x04001B13 RID: 6931
		Operand0Rgb = 34192,
		// Token: 0x04001B14 RID: 6932
		Operand0RgbArb = 34192,
		// Token: 0x04001B15 RID: 6933
		Operand0RgbExt = 34192,
		// Token: 0x04001B16 RID: 6934
		Operand1Rgb,
		// Token: 0x04001B17 RID: 6935
		Operand1RgbArb = 34193,
		// Token: 0x04001B18 RID: 6936
		Operand1RgbExt = 34193,
		// Token: 0x04001B19 RID: 6937
		Operand2Rgb,
		// Token: 0x04001B1A RID: 6938
		Operand2RgbArb = 34194,
		// Token: 0x04001B1B RID: 6939
		Operand2RgbExt = 34194,
		// Token: 0x04001B1C RID: 6940
		Operand3RgbNv,
		// Token: 0x04001B1D RID: 6941
		Operand0Alpha = 34200,
		// Token: 0x04001B1E RID: 6942
		Operand0AlphaArb = 34200,
		// Token: 0x04001B1F RID: 6943
		Operand0AlphaExt = 34200,
		// Token: 0x04001B20 RID: 6944
		Operand1Alpha,
		// Token: 0x04001B21 RID: 6945
		Operand1AlphaArb = 34201,
		// Token: 0x04001B22 RID: 6946
		Operand1AlphaExt = 34201,
		// Token: 0x04001B23 RID: 6947
		Operand2Alpha,
		// Token: 0x04001B24 RID: 6948
		Operand2AlphaArb = 34202,
		// Token: 0x04001B25 RID: 6949
		Operand2AlphaExt = 34202,
		// Token: 0x04001B26 RID: 6950
		Operand3AlphaNv,
		// Token: 0x04001B27 RID: 6951
		PackSubsampleRateSgix = 34208,
		// Token: 0x04001B28 RID: 6952
		UnpackSubsampleRateSgix,
		// Token: 0x04001B29 RID: 6953
		PixelSubsample4444Sgix,
		// Token: 0x04001B2A RID: 6954
		PixelSubsample2424Sgix,
		// Token: 0x04001B2B RID: 6955
		PixelSubsample4242Sgix,
		// Token: 0x04001B2C RID: 6956
		PerturbExt = 34222,
		// Token: 0x04001B2D RID: 6957
		TextureNormalExt,
		// Token: 0x04001B2E RID: 6958
		LightModelSpecularVectorApple,
		// Token: 0x04001B2F RID: 6959
		TransformHintApple,
		// Token: 0x04001B30 RID: 6960
		UnpackClientStorageApple,
		// Token: 0x04001B31 RID: 6961
		BufferObjectApple,
		// Token: 0x04001B32 RID: 6962
		StorageClientApple,
		// Token: 0x04001B33 RID: 6963
		VertexArrayBinding,
		// Token: 0x04001B34 RID: 6964
		VertexArrayBindingApple = 34229,
		// Token: 0x04001B35 RID: 6965
		TextureRangeLengthApple = 34231,
		// Token: 0x04001B36 RID: 6966
		TextureRangePointerApple,
		// Token: 0x04001B37 RID: 6967
		Ycbcr422Apple,
		// Token: 0x04001B38 RID: 6968
		UnsignedShort88Apple,
		// Token: 0x04001B39 RID: 6969
		UnsignedShort88Mesa = 34234,
		// Token: 0x04001B3A RID: 6970
		UnsignedShort88RevApple,
		// Token: 0x04001B3B RID: 6971
		UnsignedShort88RevMesa = 34235,
		// Token: 0x04001B3C RID: 6972
		TextureStorageHintApple,
		// Token: 0x04001B3D RID: 6973
		StoragePrivateApple,
		// Token: 0x04001B3E RID: 6974
		StorageCachedApple,
		// Token: 0x04001B3F RID: 6975
		StorageSharedApple,
		// Token: 0x04001B40 RID: 6976
		ReplacementCodeArraySun,
		// Token: 0x04001B41 RID: 6977
		ReplacementCodeArrayTypeSun,
		// Token: 0x04001B42 RID: 6978
		ReplacementCodeArrayStrideSun,
		// Token: 0x04001B43 RID: 6979
		ReplacementCodeArrayPointerSun,
		// Token: 0x04001B44 RID: 6980
		R1uiV3fSun,
		// Token: 0x04001B45 RID: 6981
		R1uiC4ubV3fSun,
		// Token: 0x04001B46 RID: 6982
		R1uiC3fV3fSun,
		// Token: 0x04001B47 RID: 6983
		R1uiN3fV3fSun,
		// Token: 0x04001B48 RID: 6984
		R1uiC4fN3fV3fSun,
		// Token: 0x04001B49 RID: 6985
		R1uiT2fV3fSun,
		// Token: 0x04001B4A RID: 6986
		R1uiT2fN3fV3fSun,
		// Token: 0x04001B4B RID: 6987
		R1uiT2fC4fN3fV3fSun,
		// Token: 0x04001B4C RID: 6988
		SliceAccumSun,
		// Token: 0x04001B4D RID: 6989
		QuadMeshSun = 34324,
		// Token: 0x04001B4E RID: 6990
		TriangleMeshSun,
		// Token: 0x04001B4F RID: 6991
		VertexProgram = 34336,
		// Token: 0x04001B50 RID: 6992
		VertexProgramArb = 34336,
		// Token: 0x04001B51 RID: 6993
		VertexProgramNv = 34336,
		// Token: 0x04001B52 RID: 6994
		VertexStateProgramNv,
		// Token: 0x04001B53 RID: 6995
		ArrayEnabled,
		// Token: 0x04001B54 RID: 6996
		VertexAttribArrayEnabled = 34338,
		// Token: 0x04001B55 RID: 6997
		VertexAttribArrayEnabledArb = 34338,
		// Token: 0x04001B56 RID: 6998
		AttribArraySizeNv,
		// Token: 0x04001B57 RID: 6999
		VertexAttribArraySize = 34339,
		// Token: 0x04001B58 RID: 7000
		VertexAttribArraySizeArb = 34339,
		// Token: 0x04001B59 RID: 7001
		AttribArrayStrideNv,
		// Token: 0x04001B5A RID: 7002
		VertexAttribArrayStride = 34340,
		// Token: 0x04001B5B RID: 7003
		VertexAttribArrayStrideArb = 34340,
		// Token: 0x04001B5C RID: 7004
		ArrayType,
		// Token: 0x04001B5D RID: 7005
		AttribArrayTypeNv = 34341,
		// Token: 0x04001B5E RID: 7006
		VertexAttribArrayType = 34341,
		// Token: 0x04001B5F RID: 7007
		VertexAttribArrayTypeArb = 34341,
		// Token: 0x04001B60 RID: 7008
		CurrentAttribNv,
		// Token: 0x04001B61 RID: 7009
		CurrentVertexAttrib = 34342,
		// Token: 0x04001B62 RID: 7010
		CurrentVertexAttribArb = 34342,
		// Token: 0x04001B63 RID: 7011
		ProgramLength,
		// Token: 0x04001B64 RID: 7012
		ProgramLengthArb = 34343,
		// Token: 0x04001B65 RID: 7013
		ProgramLengthNv = 34343,
		// Token: 0x04001B66 RID: 7014
		ProgramString,
		// Token: 0x04001B67 RID: 7015
		ProgramStringArb = 34344,
		// Token: 0x04001B68 RID: 7016
		ProgramStringNv = 34344,
		// Token: 0x04001B69 RID: 7017
		ModelviewProjectionNv,
		// Token: 0x04001B6A RID: 7018
		IdentityNv,
		// Token: 0x04001B6B RID: 7019
		InverseNv,
		// Token: 0x04001B6C RID: 7020
		TransposeNv,
		// Token: 0x04001B6D RID: 7021
		InverseTransposeNv,
		// Token: 0x04001B6E RID: 7022
		MaxProgramMatrixStackDepthArb,
		// Token: 0x04001B6F RID: 7023
		MaxTrackMatrixStackDepthNv = 34350,
		// Token: 0x04001B70 RID: 7024
		MaxProgramMatricesArb,
		// Token: 0x04001B71 RID: 7025
		MaxTrackMatricesNv = 34351,
		// Token: 0x04001B72 RID: 7026
		Matrix0Nv,
		// Token: 0x04001B73 RID: 7027
		Matrix1Nv,
		// Token: 0x04001B74 RID: 7028
		Matrix2Nv,
		// Token: 0x04001B75 RID: 7029
		Matrix3Nv,
		// Token: 0x04001B76 RID: 7030
		Matrix4Nv,
		// Token: 0x04001B77 RID: 7031
		Matrix5Nv,
		// Token: 0x04001B78 RID: 7032
		Matrix6Nv,
		// Token: 0x04001B79 RID: 7033
		Matrix7Nv,
		// Token: 0x04001B7A RID: 7034
		CurrentMatrixStackDepthArb = 34368,
		// Token: 0x04001B7B RID: 7035
		CurrentMatrixStackDepthNv = 34368,
		// Token: 0x04001B7C RID: 7036
		CurrentMatrixArb,
		// Token: 0x04001B7D RID: 7037
		CurrentMatrixNv = 34369,
		// Token: 0x04001B7E RID: 7038
		ProgramPointSize,
		// Token: 0x04001B7F RID: 7039
		ProgramPointSizeArb = 34370,
		// Token: 0x04001B80 RID: 7040
		ProgramPointSizeExt = 34370,
		// Token: 0x04001B81 RID: 7041
		VertexProgramPointSize = 34370,
		// Token: 0x04001B82 RID: 7042
		VertexProgramPointSizeArb = 34370,
		// Token: 0x04001B83 RID: 7043
		VertexProgramPointSizeNv = 34370,
		// Token: 0x04001B84 RID: 7044
		VertexProgramTwoSide,
		// Token: 0x04001B85 RID: 7045
		VertexProgramTwoSideArb = 34371,
		// Token: 0x04001B86 RID: 7046
		VertexProgramTwoSideNv = 34371,
		// Token: 0x04001B87 RID: 7047
		ProgramParameterNv,
		// Token: 0x04001B88 RID: 7048
		ArrayPointer,
		// Token: 0x04001B89 RID: 7049
		AttribArrayPointerNv = 34373,
		// Token: 0x04001B8A RID: 7050
		VertexAttribArrayPointer = 34373,
		// Token: 0x04001B8B RID: 7051
		VertexAttribArrayPointerArb = 34373,
		// Token: 0x04001B8C RID: 7052
		ProgramTargetNv,
		// Token: 0x04001B8D RID: 7053
		ProgramResidentNv,
		// Token: 0x04001B8E RID: 7054
		TrackMatrixNv,
		// Token: 0x04001B8F RID: 7055
		TrackMatrixTransformNv,
		// Token: 0x04001B90 RID: 7056
		VertexProgramBindingNv,
		// Token: 0x04001B91 RID: 7057
		ProgramErrorPositionArb,
		// Token: 0x04001B92 RID: 7058
		ProgramErrorPositionNv = 34379,
		// Token: 0x04001B93 RID: 7059
		OffsetTextureRectangleNv,
		// Token: 0x04001B94 RID: 7060
		OffsetTextureRectangleScaleNv,
		// Token: 0x04001B95 RID: 7061
		DotProductTextureRectangleNv,
		// Token: 0x04001B96 RID: 7062
		DepthClamp,
		// Token: 0x04001B97 RID: 7063
		DepthClampNv = 34383,
		// Token: 0x04001B98 RID: 7064
		VertexAttribArray0Nv,
		// Token: 0x04001B99 RID: 7065
		VertexAttribArray1Nv,
		// Token: 0x04001B9A RID: 7066
		VertexAttribArray2Nv,
		// Token: 0x04001B9B RID: 7067
		VertexAttribArray3Nv,
		// Token: 0x04001B9C RID: 7068
		VertexAttribArray4Nv,
		// Token: 0x04001B9D RID: 7069
		VertexAttribArray5Nv,
		// Token: 0x04001B9E RID: 7070
		VertexAttribArray6Nv,
		// Token: 0x04001B9F RID: 7071
		VertexAttribArray7Nv,
		// Token: 0x04001BA0 RID: 7072
		VertexAttribArray8Nv,
		// Token: 0x04001BA1 RID: 7073
		VertexAttribArray9Nv,
		// Token: 0x04001BA2 RID: 7074
		VertexAttribArray10Nv,
		// Token: 0x04001BA3 RID: 7075
		VertexAttribArray11Nv,
		// Token: 0x04001BA4 RID: 7076
		VertexAttribArray12Nv,
		// Token: 0x04001BA5 RID: 7077
		VertexAttribArray13Nv,
		// Token: 0x04001BA6 RID: 7078
		VertexAttribArray14Nv,
		// Token: 0x04001BA7 RID: 7079
		VertexAttribArray15Nv,
		// Token: 0x04001BA8 RID: 7080
		Map1VertexAttrib04Nv,
		// Token: 0x04001BA9 RID: 7081
		Map1VertexAttrib14Nv,
		// Token: 0x04001BAA RID: 7082
		Map1VertexAttrib24Nv,
		// Token: 0x04001BAB RID: 7083
		Map1VertexAttrib34Nv,
		// Token: 0x04001BAC RID: 7084
		Map1VertexAttrib44Nv,
		// Token: 0x04001BAD RID: 7085
		Map1VertexAttrib54Nv,
		// Token: 0x04001BAE RID: 7086
		Map1VertexAttrib64Nv,
		// Token: 0x04001BAF RID: 7087
		Map1VertexAttrib74Nv,
		// Token: 0x04001BB0 RID: 7088
		Map1VertexAttrib84Nv,
		// Token: 0x04001BB1 RID: 7089
		Map1VertexAttrib94Nv,
		// Token: 0x04001BB2 RID: 7090
		Map1VertexAttrib104Nv,
		// Token: 0x04001BB3 RID: 7091
		Map1VertexAttrib114Nv,
		// Token: 0x04001BB4 RID: 7092
		Map1VertexAttrib124Nv,
		// Token: 0x04001BB5 RID: 7093
		Map1VertexAttrib134Nv,
		// Token: 0x04001BB6 RID: 7094
		Map1VertexAttrib144Nv,
		// Token: 0x04001BB7 RID: 7095
		Map1VertexAttrib154Nv,
		// Token: 0x04001BB8 RID: 7096
		Map2VertexAttrib04Nv,
		// Token: 0x04001BB9 RID: 7097
		Map2VertexAttrib14Nv,
		// Token: 0x04001BBA RID: 7098
		Map2VertexAttrib24Nv,
		// Token: 0x04001BBB RID: 7099
		Map2VertexAttrib34Nv,
		// Token: 0x04001BBC RID: 7100
		Map2VertexAttrib44Nv,
		// Token: 0x04001BBD RID: 7101
		Map2VertexAttrib54Nv,
		// Token: 0x04001BBE RID: 7102
		Map2VertexAttrib64Nv,
		// Token: 0x04001BBF RID: 7103
		Map2VertexAttrib74Nv,
		// Token: 0x04001BC0 RID: 7104
		ProgramBinding = 34423,
		// Token: 0x04001BC1 RID: 7105
		ProgramBindingArb = 34423,
		// Token: 0x04001BC2 RID: 7106
		Map2VertexAttrib84Nv,
		// Token: 0x04001BC3 RID: 7107
		Map2VertexAttrib94Nv,
		// Token: 0x04001BC4 RID: 7108
		Map2VertexAttrib104Nv,
		// Token: 0x04001BC5 RID: 7109
		Map2VertexAttrib114Nv,
		// Token: 0x04001BC6 RID: 7110
		Map2VertexAttrib124Nv,
		// Token: 0x04001BC7 RID: 7111
		Map2VertexAttrib134Nv,
		// Token: 0x04001BC8 RID: 7112
		Map2VertexAttrib144Nv,
		// Token: 0x04001BC9 RID: 7113
		Map2VertexAttrib154Nv,
		// Token: 0x04001BCA RID: 7114
		TextureCompressedImageSize = 34464,
		// Token: 0x04001BCB RID: 7115
		TextureCompressedImageSizeArb = 34464,
		// Token: 0x04001BCC RID: 7116
		TextureCompressed,
		// Token: 0x04001BCD RID: 7117
		TextureCompressedArb = 34465,
		// Token: 0x04001BCE RID: 7118
		NumCompressedTextureFormats,
		// Token: 0x04001BCF RID: 7119
		NumCompressedTextureFormatsArb = 34466,
		// Token: 0x04001BD0 RID: 7120
		CompressedTextureFormats,
		// Token: 0x04001BD1 RID: 7121
		CompressedTextureFormatsArb = 34467,
		// Token: 0x04001BD2 RID: 7122
		MaxVertexUnitsArb,
		// Token: 0x04001BD3 RID: 7123
		ActiveVertexUnitsArb,
		// Token: 0x04001BD4 RID: 7124
		WeightSumUnityArb,
		// Token: 0x04001BD5 RID: 7125
		VertexBlendArb,
		// Token: 0x04001BD6 RID: 7126
		CurrentWeightArb,
		// Token: 0x04001BD7 RID: 7127
		WeightArrayTypeArb,
		// Token: 0x04001BD8 RID: 7128
		WeightArrayStrideArb,
		// Token: 0x04001BD9 RID: 7129
		WeightArraySizeArb,
		// Token: 0x04001BDA RID: 7130
		WeightArrayPointerArb,
		// Token: 0x04001BDB RID: 7131
		WeightArrayArb,
		// Token: 0x04001BDC RID: 7132
		Dot3Rgb,
		// Token: 0x04001BDD RID: 7133
		Dot3RgbArb = 34478,
		// Token: 0x04001BDE RID: 7134
		Dot3Rgba,
		// Token: 0x04001BDF RID: 7135
		Dot3RgbaArb = 34479,
		// Token: 0x04001BE0 RID: 7136
		CompressedRgbFxt13Dfx,
		// Token: 0x04001BE1 RID: 7137
		CompressedRgbaFxt13Dfx,
		// Token: 0x04001BE2 RID: 7138
		Multisample3Dfx,
		// Token: 0x04001BE3 RID: 7139
		SampleBuffers3Dfx,
		// Token: 0x04001BE4 RID: 7140
		Samples3Dfx,
		// Token: 0x04001BE5 RID: 7141
		Eval2DNv = 34496,
		// Token: 0x04001BE6 RID: 7142
		EvalTriangular2DNv,
		// Token: 0x04001BE7 RID: 7143
		MapTessellationNv,
		// Token: 0x04001BE8 RID: 7144
		MapAttribUOrderNv,
		// Token: 0x04001BE9 RID: 7145
		MapAttribVOrderNv,
		// Token: 0x04001BEA RID: 7146
		EvalFractionalTessellationNv,
		// Token: 0x04001BEB RID: 7147
		EvalVertexAttrib0Nv,
		// Token: 0x04001BEC RID: 7148
		EvalVertexAttrib1Nv,
		// Token: 0x04001BED RID: 7149
		EvalVertexAttrib2Nv,
		// Token: 0x04001BEE RID: 7150
		EvalVertexAttrib3Nv,
		// Token: 0x04001BEF RID: 7151
		EvalVertexAttrib4Nv,
		// Token: 0x04001BF0 RID: 7152
		EvalVertexAttrib5Nv,
		// Token: 0x04001BF1 RID: 7153
		EvalVertexAttrib6Nv,
		// Token: 0x04001BF2 RID: 7154
		EvalVertexAttrib7Nv,
		// Token: 0x04001BF3 RID: 7155
		EvalVertexAttrib8Nv,
		// Token: 0x04001BF4 RID: 7156
		EvalVertexAttrib9Nv,
		// Token: 0x04001BF5 RID: 7157
		EvalVertexAttrib10Nv,
		// Token: 0x04001BF6 RID: 7158
		EvalVertexAttrib11Nv,
		// Token: 0x04001BF7 RID: 7159
		EvalVertexAttrib12Nv,
		// Token: 0x04001BF8 RID: 7160
		EvalVertexAttrib13Nv,
		// Token: 0x04001BF9 RID: 7161
		EvalVertexAttrib14Nv,
		// Token: 0x04001BFA RID: 7162
		EvalVertexAttrib15Nv,
		// Token: 0x04001BFB RID: 7163
		MaxMapTessellationNv,
		// Token: 0x04001BFC RID: 7164
		MaxRationalEvalOrderNv,
		// Token: 0x04001BFD RID: 7165
		MaxProgramPatchAttribsNv,
		// Token: 0x04001BFE RID: 7166
		RgbaUnsignedDotProductMappingNv,
		// Token: 0x04001BFF RID: 7167
		UnsignedIntS8S888Nv,
		// Token: 0x04001C00 RID: 7168
		UnsignedInt88S8S8RevNv,
		// Token: 0x04001C01 RID: 7169
		DsdtMagIntensityNv,
		// Token: 0x04001C02 RID: 7170
		ShaderConsistentNv,
		// Token: 0x04001C03 RID: 7171
		TextureShaderNv,
		// Token: 0x04001C04 RID: 7172
		ShaderOperationNv,
		// Token: 0x04001C05 RID: 7173
		CullModesNv,
		// Token: 0x04001C06 RID: 7174
		OffsetTexture2DMatrixNv,
		// Token: 0x04001C07 RID: 7175
		OffsetTextureMatrixNv = 34529,
		// Token: 0x04001C08 RID: 7176
		OffsetTexture2DScaleNv,
		// Token: 0x04001C09 RID: 7177
		OffsetTextureScaleNv = 34530,
		// Token: 0x04001C0A RID: 7178
		OffsetTexture2DBiasNv,
		// Token: 0x04001C0B RID: 7179
		OffsetTextureBiasNv = 34531,
		// Token: 0x04001C0C RID: 7180
		PreviousTextureInputNv,
		// Token: 0x04001C0D RID: 7181
		ConstEyeNv,
		// Token: 0x04001C0E RID: 7182
		PassThroughNv,
		// Token: 0x04001C0F RID: 7183
		CullFragmentNv,
		// Token: 0x04001C10 RID: 7184
		OffsetTexture2DNv,
		// Token: 0x04001C11 RID: 7185
		DependentArTexture2DNv,
		// Token: 0x04001C12 RID: 7186
		DependentGbTexture2DNv,
		// Token: 0x04001C13 RID: 7187
		SurfaceStateNv,
		// Token: 0x04001C14 RID: 7188
		DotProductNv,
		// Token: 0x04001C15 RID: 7189
		DotProductDepthReplaceNv,
		// Token: 0x04001C16 RID: 7190
		DotProductTexture2DNv,
		// Token: 0x04001C17 RID: 7191
		DotProductTexture3DNv,
		// Token: 0x04001C18 RID: 7192
		DotProductTextureCubeMapNv,
		// Token: 0x04001C19 RID: 7193
		DotProductDiffuseCubeMapNv,
		// Token: 0x04001C1A RID: 7194
		DotProductReflectCubeMapNv,
		// Token: 0x04001C1B RID: 7195
		DotProductConstEyeReflectCubeMapNv,
		// Token: 0x04001C1C RID: 7196
		HiloNv,
		// Token: 0x04001C1D RID: 7197
		DsdtNv,
		// Token: 0x04001C1E RID: 7198
		DsdtMagNv,
		// Token: 0x04001C1F RID: 7199
		DsdtMagVibNv,
		// Token: 0x04001C20 RID: 7200
		Hilo16Nv,
		// Token: 0x04001C21 RID: 7201
		SignedHiloNv,
		// Token: 0x04001C22 RID: 7202
		SignedHilo16Nv,
		// Token: 0x04001C23 RID: 7203
		SignedRgbaNv,
		// Token: 0x04001C24 RID: 7204
		SignedRgba8Nv,
		// Token: 0x04001C25 RID: 7205
		SurfaceRegisteredNv,
		// Token: 0x04001C26 RID: 7206
		SignedRgbNv,
		// Token: 0x04001C27 RID: 7207
		SignedRgb8Nv,
		// Token: 0x04001C28 RID: 7208
		SurfaceMappedNv,
		// Token: 0x04001C29 RID: 7209
		SignedLuminanceNv,
		// Token: 0x04001C2A RID: 7210
		SignedLuminance8Nv,
		// Token: 0x04001C2B RID: 7211
		SignedLuminanceAlphaNv,
		// Token: 0x04001C2C RID: 7212
		SignedLuminance8Alpha8Nv,
		// Token: 0x04001C2D RID: 7213
		SignedAlphaNv,
		// Token: 0x04001C2E RID: 7214
		SignedAlpha8Nv,
		// Token: 0x04001C2F RID: 7215
		SignedIntensityNv,
		// Token: 0x04001C30 RID: 7216
		SignedIntensity8Nv,
		// Token: 0x04001C31 RID: 7217
		Dsdt8Nv,
		// Token: 0x04001C32 RID: 7218
		Dsdt8Mag8Nv,
		// Token: 0x04001C33 RID: 7219
		Dsdt8Mag8Intensity8Nv,
		// Token: 0x04001C34 RID: 7220
		SignedRgbUnsignedAlphaNv,
		// Token: 0x04001C35 RID: 7221
		SignedRgb8UnsignedAlpha8Nv,
		// Token: 0x04001C36 RID: 7222
		HiScaleNv,
		// Token: 0x04001C37 RID: 7223
		LoScaleNv,
		// Token: 0x04001C38 RID: 7224
		DsScaleNv,
		// Token: 0x04001C39 RID: 7225
		DtScaleNv,
		// Token: 0x04001C3A RID: 7226
		MagnitudeScaleNv,
		// Token: 0x04001C3B RID: 7227
		VibranceScaleNv,
		// Token: 0x04001C3C RID: 7228
		HiBiasNv,
		// Token: 0x04001C3D RID: 7229
		LoBiasNv,
		// Token: 0x04001C3E RID: 7230
		DsBiasNv,
		// Token: 0x04001C3F RID: 7231
		DtBiasNv,
		// Token: 0x04001C40 RID: 7232
		MagnitudeBiasNv,
		// Token: 0x04001C41 RID: 7233
		VibranceBiasNv,
		// Token: 0x04001C42 RID: 7234
		TextureBorderValuesNv,
		// Token: 0x04001C43 RID: 7235
		TextureHiSizeNv,
		// Token: 0x04001C44 RID: 7236
		TextureLoSizeNv,
		// Token: 0x04001C45 RID: 7237
		TextureDsSizeNv,
		// Token: 0x04001C46 RID: 7238
		TextureDtSizeNv,
		// Token: 0x04001C47 RID: 7239
		TextureMagSizeNv,
		// Token: 0x04001C48 RID: 7240
		Modelview2Arb = 34594,
		// Token: 0x04001C49 RID: 7241
		Modelview3Arb,
		// Token: 0x04001C4A RID: 7242
		Modelview4Arb,
		// Token: 0x04001C4B RID: 7243
		Modelview5Arb,
		// Token: 0x04001C4C RID: 7244
		Modelview6Arb,
		// Token: 0x04001C4D RID: 7245
		Modelview7Arb,
		// Token: 0x04001C4E RID: 7246
		Modelview8Arb,
		// Token: 0x04001C4F RID: 7247
		Modelview9Arb,
		// Token: 0x04001C50 RID: 7248
		Modelview10Arb,
		// Token: 0x04001C51 RID: 7249
		Modelview11Arb,
		// Token: 0x04001C52 RID: 7250
		Modelview12Arb,
		// Token: 0x04001C53 RID: 7251
		Modelview13Arb,
		// Token: 0x04001C54 RID: 7252
		Modelview14Arb,
		// Token: 0x04001C55 RID: 7253
		Modelview15Arb,
		// Token: 0x04001C56 RID: 7254
		Modelview16Arb,
		// Token: 0x04001C57 RID: 7255
		Modelview17Arb,
		// Token: 0x04001C58 RID: 7256
		Modelview18Arb,
		// Token: 0x04001C59 RID: 7257
		Modelview19Arb,
		// Token: 0x04001C5A RID: 7258
		Modelview20Arb,
		// Token: 0x04001C5B RID: 7259
		Modelview21Arb,
		// Token: 0x04001C5C RID: 7260
		Modelview22Arb,
		// Token: 0x04001C5D RID: 7261
		Modelview23Arb,
		// Token: 0x04001C5E RID: 7262
		Modelview24Arb,
		// Token: 0x04001C5F RID: 7263
		Modelview25Arb,
		// Token: 0x04001C60 RID: 7264
		Modelview26Arb,
		// Token: 0x04001C61 RID: 7265
		Modelview27Arb,
		// Token: 0x04001C62 RID: 7266
		Modelview28Arb,
		// Token: 0x04001C63 RID: 7267
		Modelview29Arb,
		// Token: 0x04001C64 RID: 7268
		Modelview30Arb,
		// Token: 0x04001C65 RID: 7269
		Modelview31Arb,
		// Token: 0x04001C66 RID: 7270
		Dot3RgbExt,
		// Token: 0x04001C67 RID: 7271
		Dot3RgbaExt,
		// Token: 0x04001C68 RID: 7272
		ProgramBinaryLength = 34625,
		// Token: 0x04001C69 RID: 7273
		MirrorClampAti,
		// Token: 0x04001C6A RID: 7274
		MirrorClampExt = 34626,
		// Token: 0x04001C6B RID: 7275
		MirrorClampToEdge,
		// Token: 0x04001C6C RID: 7276
		MirrorClampToEdgeAti = 34627,
		// Token: 0x04001C6D RID: 7277
		MirrorClampToEdgeExt = 34627,
		// Token: 0x04001C6E RID: 7278
		ModulateAddAti,
		// Token: 0x04001C6F RID: 7279
		ModulateSignedAddAti,
		// Token: 0x04001C70 RID: 7280
		ModulateSubtractAti,
		// Token: 0x04001C71 RID: 7281
		SetAmd = 34634,
		// Token: 0x04001C72 RID: 7282
		ReplaceValueAmd,
		// Token: 0x04001C73 RID: 7283
		StencilOpValueAmd,
		// Token: 0x04001C74 RID: 7284
		StencilBackOpValueAmd,
		// Token: 0x04001C75 RID: 7285
		VertexAttribArrayLong,
		// Token: 0x04001C76 RID: 7286
		OcclusionQueryEventMaskAmd,
		// Token: 0x04001C77 RID: 7287
		YcbcrMesa = 34647,
		// Token: 0x04001C78 RID: 7288
		PackInvertMesa,
		// Token: 0x04001C79 RID: 7289
		Texture1DStackMesax,
		// Token: 0x04001C7A RID: 7290
		Texture2DStackMesax,
		// Token: 0x04001C7B RID: 7291
		ProxyTexture1DStackMesax,
		// Token: 0x04001C7C RID: 7292
		ProxyTexture2DStackMesax,
		// Token: 0x04001C7D RID: 7293
		Texture1DStackBindingMesax,
		// Token: 0x04001C7E RID: 7294
		Texture2DStackBindingMesax,
		// Token: 0x04001C7F RID: 7295
		StaticAti = 34656,
		// Token: 0x04001C80 RID: 7296
		DynamicAti,
		// Token: 0x04001C81 RID: 7297
		PreserveAti,
		// Token: 0x04001C82 RID: 7298
		DiscardAti,
		// Token: 0x04001C83 RID: 7299
		BufferSize,
		// Token: 0x04001C84 RID: 7300
		BufferSizeArb = 34660,
		// Token: 0x04001C85 RID: 7301
		ObjectBufferSizeAti = 34660,
		// Token: 0x04001C86 RID: 7302
		BufferUsage,
		// Token: 0x04001C87 RID: 7303
		BufferUsageArb = 34661,
		// Token: 0x04001C88 RID: 7304
		ObjectBufferUsageAti = 34661,
		// Token: 0x04001C89 RID: 7305
		ArrayObjectBufferAti,
		// Token: 0x04001C8A RID: 7306
		ArrayObjectOffsetAti,
		// Token: 0x04001C8B RID: 7307
		ElementArrayAti,
		// Token: 0x04001C8C RID: 7308
		ElementArrayTypeAti,
		// Token: 0x04001C8D RID: 7309
		ElementArrayPointerAti,
		// Token: 0x04001C8E RID: 7310
		MaxVertexStreamsAti,
		// Token: 0x04001C8F RID: 7311
		VertexStream0Ati,
		// Token: 0x04001C90 RID: 7312
		VertexStream1Ati,
		// Token: 0x04001C91 RID: 7313
		VertexStream2Ati,
		// Token: 0x04001C92 RID: 7314
		VertexStream3Ati,
		// Token: 0x04001C93 RID: 7315
		VertexStream4Ati,
		// Token: 0x04001C94 RID: 7316
		VertexStream5Ati,
		// Token: 0x04001C95 RID: 7317
		VertexStream6Ati,
		// Token: 0x04001C96 RID: 7318
		VertexStream7Ati,
		// Token: 0x04001C97 RID: 7319
		VertexSourceAti,
		// Token: 0x04001C98 RID: 7320
		BumpRotMatrixAti,
		// Token: 0x04001C99 RID: 7321
		BumpRotMatrixSizeAti,
		// Token: 0x04001C9A RID: 7322
		BumpNumTexUnitsAti,
		// Token: 0x04001C9B RID: 7323
		BumpTexUnitsAti,
		// Token: 0x04001C9C RID: 7324
		DudvAti,
		// Token: 0x04001C9D RID: 7325
		Du8Dv8Ati,
		// Token: 0x04001C9E RID: 7326
		BumpEnvmapAti,
		// Token: 0x04001C9F RID: 7327
		BumpTargetAti,
		// Token: 0x04001CA0 RID: 7328
		VertexShaderExt = 34688,
		// Token: 0x04001CA1 RID: 7329
		VertexShaderBindingExt,
		// Token: 0x04001CA2 RID: 7330
		OpIndexExt,
		// Token: 0x04001CA3 RID: 7331
		OpNegateExt,
		// Token: 0x04001CA4 RID: 7332
		OpDot3Ext,
		// Token: 0x04001CA5 RID: 7333
		OpDot4Ext,
		// Token: 0x04001CA6 RID: 7334
		OpMulExt,
		// Token: 0x04001CA7 RID: 7335
		OpAddExt,
		// Token: 0x04001CA8 RID: 7336
		OpMaddExt,
		// Token: 0x04001CA9 RID: 7337
		OpFracExt,
		// Token: 0x04001CAA RID: 7338
		OpMaxExt,
		// Token: 0x04001CAB RID: 7339
		OpMinExt,
		// Token: 0x04001CAC RID: 7340
		OpSetGeExt,
		// Token: 0x04001CAD RID: 7341
		OpSetLtExt,
		// Token: 0x04001CAE RID: 7342
		OpClampExt,
		// Token: 0x04001CAF RID: 7343
		OpFloorExt,
		// Token: 0x04001CB0 RID: 7344
		OpRoundExt,
		// Token: 0x04001CB1 RID: 7345
		OpExpBase2Ext,
		// Token: 0x04001CB2 RID: 7346
		OpLogBase2Ext,
		// Token: 0x04001CB3 RID: 7347
		OpPowerExt,
		// Token: 0x04001CB4 RID: 7348
		OpRecipExt,
		// Token: 0x04001CB5 RID: 7349
		OpRecipSqrtExt,
		// Token: 0x04001CB6 RID: 7350
		OpSubExt,
		// Token: 0x04001CB7 RID: 7351
		OpCrossProductExt,
		// Token: 0x04001CB8 RID: 7352
		OpMultiplyMatrixExt,
		// Token: 0x04001CB9 RID: 7353
		OpMovExt,
		// Token: 0x04001CBA RID: 7354
		OutputVertexExt,
		// Token: 0x04001CBB RID: 7355
		OutputColor0Ext,
		// Token: 0x04001CBC RID: 7356
		OutputColor1Ext,
		// Token: 0x04001CBD RID: 7357
		OutputTextureCoord0Ext,
		// Token: 0x04001CBE RID: 7358
		OutputTextureCoord1Ext,
		// Token: 0x04001CBF RID: 7359
		OutputTextureCoord2Ext,
		// Token: 0x04001CC0 RID: 7360
		OutputTextureCoord3Ext,
		// Token: 0x04001CC1 RID: 7361
		OutputTextureCoord4Ext,
		// Token: 0x04001CC2 RID: 7362
		OutputTextureCoord5Ext,
		// Token: 0x04001CC3 RID: 7363
		OutputTextureCoord6Ext,
		// Token: 0x04001CC4 RID: 7364
		OutputTextureCoord7Ext,
		// Token: 0x04001CC5 RID: 7365
		OutputTextureCoord8Ext,
		// Token: 0x04001CC6 RID: 7366
		OutputTextureCoord9Ext,
		// Token: 0x04001CC7 RID: 7367
		OutputTextureCoord10Ext,
		// Token: 0x04001CC8 RID: 7368
		OutputTextureCoord11Ext,
		// Token: 0x04001CC9 RID: 7369
		OutputTextureCoord12Ext,
		// Token: 0x04001CCA RID: 7370
		OutputTextureCoord13Ext,
		// Token: 0x04001CCB RID: 7371
		OutputTextureCoord14Ext,
		// Token: 0x04001CCC RID: 7372
		OutputTextureCoord15Ext,
		// Token: 0x04001CCD RID: 7373
		OutputTextureCoord16Ext,
		// Token: 0x04001CCE RID: 7374
		OutputTextureCoord17Ext,
		// Token: 0x04001CCF RID: 7375
		OutputTextureCoord18Ext,
		// Token: 0x04001CD0 RID: 7376
		OutputTextureCoord19Ext,
		// Token: 0x04001CD1 RID: 7377
		OutputTextureCoord20Ext,
		// Token: 0x04001CD2 RID: 7378
		OutputTextureCoord21Ext,
		// Token: 0x04001CD3 RID: 7379
		OutputTextureCoord22Ext,
		// Token: 0x04001CD4 RID: 7380
		OutputTextureCoord23Ext,
		// Token: 0x04001CD5 RID: 7381
		OutputTextureCoord24Ext,
		// Token: 0x04001CD6 RID: 7382
		OutputTextureCoord25Ext,
		// Token: 0x04001CD7 RID: 7383
		OutputTextureCoord26Ext,
		// Token: 0x04001CD8 RID: 7384
		OutputTextureCoord27Ext,
		// Token: 0x04001CD9 RID: 7385
		OutputTextureCoord28Ext,
		// Token: 0x04001CDA RID: 7386
		OutputTextureCoord29Ext,
		// Token: 0x04001CDB RID: 7387
		OutputTextureCoord30Ext,
		// Token: 0x04001CDC RID: 7388
		OutputTextureCoord31Ext,
		// Token: 0x04001CDD RID: 7389
		OutputFogExt,
		// Token: 0x04001CDE RID: 7390
		ScalarExt,
		// Token: 0x04001CDF RID: 7391
		VectorExt,
		// Token: 0x04001CE0 RID: 7392
		MatrixExt,
		// Token: 0x04001CE1 RID: 7393
		VariantExt,
		// Token: 0x04001CE2 RID: 7394
		InvariantExt,
		// Token: 0x04001CE3 RID: 7395
		LocalConstantExt,
		// Token: 0x04001CE4 RID: 7396
		LocalExt,
		// Token: 0x04001CE5 RID: 7397
		MaxVertexShaderInstructionsExt,
		// Token: 0x04001CE6 RID: 7398
		MaxVertexShaderVariantsExt,
		// Token: 0x04001CE7 RID: 7399
		MaxVertexShaderInvariantsExt,
		// Token: 0x04001CE8 RID: 7400
		MaxVertexShaderLocalConstantsExt,
		// Token: 0x04001CE9 RID: 7401
		MaxVertexShaderLocalsExt,
		// Token: 0x04001CEA RID: 7402
		MaxOptimizedVertexShaderInstructionsExt,
		// Token: 0x04001CEB RID: 7403
		MaxOptimizedVertexShaderVariantsExt,
		// Token: 0x04001CEC RID: 7404
		MaxOptimizedVertexShaderLocalConstantsExt,
		// Token: 0x04001CED RID: 7405
		MaxOptimizedVertexShaderInvariantsExt,
		// Token: 0x04001CEE RID: 7406
		MaxOptimizedVertexShaderLocalsExt,
		// Token: 0x04001CEF RID: 7407
		VertexShaderInstructionsExt,
		// Token: 0x04001CF0 RID: 7408
		VertexShaderVariantsExt,
		// Token: 0x04001CF1 RID: 7409
		VertexShaderInvariantsExt,
		// Token: 0x04001CF2 RID: 7410
		VertexShaderLocalConstantsExt,
		// Token: 0x04001CF3 RID: 7411
		VertexShaderLocalsExt,
		// Token: 0x04001CF4 RID: 7412
		VertexShaderOptimizedExt,
		// Token: 0x04001CF5 RID: 7413
		XExt,
		// Token: 0x04001CF6 RID: 7414
		YExt,
		// Token: 0x04001CF7 RID: 7415
		ZExt,
		// Token: 0x04001CF8 RID: 7416
		WExt,
		// Token: 0x04001CF9 RID: 7417
		NegativeXExt,
		// Token: 0x04001CFA RID: 7418
		NegativeYExt,
		// Token: 0x04001CFB RID: 7419
		NegativeZExt,
		// Token: 0x04001CFC RID: 7420
		NegativeWExt,
		// Token: 0x04001CFD RID: 7421
		ZeroExt,
		// Token: 0x04001CFE RID: 7422
		OneExt,
		// Token: 0x04001CFF RID: 7423
		NegativeOneExt,
		// Token: 0x04001D00 RID: 7424
		NormalizedRangeExt,
		// Token: 0x04001D01 RID: 7425
		FullRangeExt,
		// Token: 0x04001D02 RID: 7426
		CurrentVertexExt,
		// Token: 0x04001D03 RID: 7427
		MvpMatrixExt,
		// Token: 0x04001D04 RID: 7428
		VariantValueExt,
		// Token: 0x04001D05 RID: 7429
		VariantDatatypeExt,
		// Token: 0x04001D06 RID: 7430
		VariantArrayStrideExt,
		// Token: 0x04001D07 RID: 7431
		VariantArrayTypeExt,
		// Token: 0x04001D08 RID: 7432
		VariantArrayExt,
		// Token: 0x04001D09 RID: 7433
		VariantArrayPointerExt,
		// Token: 0x04001D0A RID: 7434
		InvariantValueExt,
		// Token: 0x04001D0B RID: 7435
		InvariantDatatypeExt,
		// Token: 0x04001D0C RID: 7436
		LocalConstantValueExt,
		// Token: 0x04001D0D RID: 7437
		LocalConstantDatatypeExt,
		// Token: 0x04001D0E RID: 7438
		PnTrianglesAti = 34800,
		// Token: 0x04001D0F RID: 7439
		MaxPnTrianglesTesselationLevelAti,
		// Token: 0x04001D10 RID: 7440
		PnTrianglesPointModeAti,
		// Token: 0x04001D11 RID: 7441
		PnTrianglesNormalModeAti,
		// Token: 0x04001D12 RID: 7442
		PnTrianglesTesselationLevelAti,
		// Token: 0x04001D13 RID: 7443
		PnTrianglesPointModeLinearAti,
		// Token: 0x04001D14 RID: 7444
		PnTrianglesPointModeCubicAti,
		// Token: 0x04001D15 RID: 7445
		PnTrianglesNormalModeLinearAti,
		// Token: 0x04001D16 RID: 7446
		PnTrianglesNormalModeQuadraticAti,
		// Token: 0x04001D17 RID: 7447
		VboFreeMemoryAti = 34811,
		// Token: 0x04001D18 RID: 7448
		TextureFreeMemoryAti,
		// Token: 0x04001D19 RID: 7449
		RenderbufferFreeMemoryAti,
		// Token: 0x04001D1A RID: 7450
		NumProgramBinaryFormats,
		// Token: 0x04001D1B RID: 7451
		ProgramBinaryFormats,
		// Token: 0x04001D1C RID: 7452
		StencilBackFunc,
		// Token: 0x04001D1D RID: 7453
		StencilBackFuncAti = 34816,
		// Token: 0x04001D1E RID: 7454
		StencilBackFail,
		// Token: 0x04001D1F RID: 7455
		StencilBackFailAti = 34817,
		// Token: 0x04001D20 RID: 7456
		StencilBackPassDepthFail,
		// Token: 0x04001D21 RID: 7457
		StencilBackPassDepthFailAti = 34818,
		// Token: 0x04001D22 RID: 7458
		StencilBackPassDepthPass,
		// Token: 0x04001D23 RID: 7459
		StencilBackPassDepthPassAti = 34819,
		// Token: 0x04001D24 RID: 7460
		FragmentProgram,
		// Token: 0x04001D25 RID: 7461
		FragmentProgramArb = 34820,
		// Token: 0x04001D26 RID: 7462
		ProgramAluInstructionsArb,
		// Token: 0x04001D27 RID: 7463
		ProgramTexInstructionsArb,
		// Token: 0x04001D28 RID: 7464
		ProgramTexIndirectionsArb,
		// Token: 0x04001D29 RID: 7465
		ProgramNativeAluInstructionsArb,
		// Token: 0x04001D2A RID: 7466
		ProgramNativeTexInstructionsArb,
		// Token: 0x04001D2B RID: 7467
		ProgramNativeTexIndirectionsArb,
		// Token: 0x04001D2C RID: 7468
		MaxProgramAluInstructionsArb,
		// Token: 0x04001D2D RID: 7469
		MaxProgramTexInstructionsArb,
		// Token: 0x04001D2E RID: 7470
		MaxProgramTexIndirectionsArb,
		// Token: 0x04001D2F RID: 7471
		MaxProgramNativeAluInstructionsArb,
		// Token: 0x04001D30 RID: 7472
		MaxProgramNativeTexInstructionsArb,
		// Token: 0x04001D31 RID: 7473
		MaxProgramNativeTexIndirectionsArb,
		// Token: 0x04001D32 RID: 7474
		Rgba32f = 34836,
		// Token: 0x04001D33 RID: 7475
		Rgba32fArb = 34836,
		// Token: 0x04001D34 RID: 7476
		RgbaFloat32Apple = 34836,
		// Token: 0x04001D35 RID: 7477
		RgbaFloat32Ati = 34836,
		// Token: 0x04001D36 RID: 7478
		Rgb32f,
		// Token: 0x04001D37 RID: 7479
		Rgb32fArb = 34837,
		// Token: 0x04001D38 RID: 7480
		RgbFloat32Apple = 34837,
		// Token: 0x04001D39 RID: 7481
		RgbFloat32Ati = 34837,
		// Token: 0x04001D3A RID: 7482
		Alpha32fArb,
		// Token: 0x04001D3B RID: 7483
		AlphaFloat32Apple = 34838,
		// Token: 0x04001D3C RID: 7484
		AlphaFloat32Ati = 34838,
		// Token: 0x04001D3D RID: 7485
		Intensity32fArb,
		// Token: 0x04001D3E RID: 7486
		IntensityFloat32Apple = 34839,
		// Token: 0x04001D3F RID: 7487
		IntensityFloat32Ati = 34839,
		// Token: 0x04001D40 RID: 7488
		Luminance32fArb,
		// Token: 0x04001D41 RID: 7489
		LuminanceFloat32Apple = 34840,
		// Token: 0x04001D42 RID: 7490
		LuminanceFloat32Ati = 34840,
		// Token: 0x04001D43 RID: 7491
		LuminanceAlpha32fArb,
		// Token: 0x04001D44 RID: 7492
		LuminanceAlphaFloat32Apple = 34841,
		// Token: 0x04001D45 RID: 7493
		LuminanceAlphaFloat32Ati = 34841,
		// Token: 0x04001D46 RID: 7494
		Rgba16f,
		// Token: 0x04001D47 RID: 7495
		Rgba16fArb = 34842,
		// Token: 0x04001D48 RID: 7496
		RgbaFloat16Apple = 34842,
		// Token: 0x04001D49 RID: 7497
		RgbaFloat16Ati = 34842,
		// Token: 0x04001D4A RID: 7498
		Rgb16f,
		// Token: 0x04001D4B RID: 7499
		Rgb16fArb = 34843,
		// Token: 0x04001D4C RID: 7500
		RgbFloat16Apple = 34843,
		// Token: 0x04001D4D RID: 7501
		RgbFloat16Ati = 34843,
		// Token: 0x04001D4E RID: 7502
		Alpha16fArb,
		// Token: 0x04001D4F RID: 7503
		AlphaFloat16Apple = 34844,
		// Token: 0x04001D50 RID: 7504
		AlphaFloat16Ati = 34844,
		// Token: 0x04001D51 RID: 7505
		Intensity16fArb,
		// Token: 0x04001D52 RID: 7506
		IntensityFloat16Apple = 34845,
		// Token: 0x04001D53 RID: 7507
		IntensityFloat16Ati = 34845,
		// Token: 0x04001D54 RID: 7508
		Luminance16fArb,
		// Token: 0x04001D55 RID: 7509
		LuminanceFloat16Apple = 34846,
		// Token: 0x04001D56 RID: 7510
		LuminanceFloat16Ati = 34846,
		// Token: 0x04001D57 RID: 7511
		LuminanceAlpha16fArb,
		// Token: 0x04001D58 RID: 7512
		LuminanceAlphaFloat16Apple = 34847,
		// Token: 0x04001D59 RID: 7513
		LuminanceAlphaFloat16Ati = 34847,
		// Token: 0x04001D5A RID: 7514
		RgbaFloatMode,
		// Token: 0x04001D5B RID: 7515
		RgbaFloatModeArb = 34848,
		// Token: 0x04001D5C RID: 7516
		RgbaFloatModeAti = 34848,
		// Token: 0x04001D5D RID: 7517
		MaxDrawBuffers = 34852,
		// Token: 0x04001D5E RID: 7518
		MaxDrawBuffersArb = 34852,
		// Token: 0x04001D5F RID: 7519
		MaxDrawBuffersAti = 34852,
		// Token: 0x04001D60 RID: 7520
		DrawBuffer0,
		// Token: 0x04001D61 RID: 7521
		DrawBuffer0Arb = 34853,
		// Token: 0x04001D62 RID: 7522
		DrawBuffer0Ati = 34853,
		// Token: 0x04001D63 RID: 7523
		DrawBuffer1,
		// Token: 0x04001D64 RID: 7524
		DrawBuffer1Arb = 34854,
		// Token: 0x04001D65 RID: 7525
		DrawBuffer1Ati = 34854,
		// Token: 0x04001D66 RID: 7526
		DrawBuffer2,
		// Token: 0x04001D67 RID: 7527
		DrawBuffer2Arb = 34855,
		// Token: 0x04001D68 RID: 7528
		DrawBuffer2Ati = 34855,
		// Token: 0x04001D69 RID: 7529
		DrawBuffer3,
		// Token: 0x04001D6A RID: 7530
		DrawBuffer3Arb = 34856,
		// Token: 0x04001D6B RID: 7531
		DrawBuffer3Ati = 34856,
		// Token: 0x04001D6C RID: 7532
		DrawBuffer4,
		// Token: 0x04001D6D RID: 7533
		DrawBuffer4Arb = 34857,
		// Token: 0x04001D6E RID: 7534
		DrawBuffer4Ati = 34857,
		// Token: 0x04001D6F RID: 7535
		DrawBuffer5,
		// Token: 0x04001D70 RID: 7536
		DrawBuffer5Arb = 34858,
		// Token: 0x04001D71 RID: 7537
		DrawBuffer5Ati = 34858,
		// Token: 0x04001D72 RID: 7538
		DrawBuffer6,
		// Token: 0x04001D73 RID: 7539
		DrawBuffer6Arb = 34859,
		// Token: 0x04001D74 RID: 7540
		DrawBuffer6Ati = 34859,
		// Token: 0x04001D75 RID: 7541
		DrawBuffer7,
		// Token: 0x04001D76 RID: 7542
		DrawBuffer7Arb = 34860,
		// Token: 0x04001D77 RID: 7543
		DrawBuffer7Ati = 34860,
		// Token: 0x04001D78 RID: 7544
		DrawBuffer8,
		// Token: 0x04001D79 RID: 7545
		DrawBuffer8Arb = 34861,
		// Token: 0x04001D7A RID: 7546
		DrawBuffer8Ati = 34861,
		// Token: 0x04001D7B RID: 7547
		DrawBuffer9,
		// Token: 0x04001D7C RID: 7548
		DrawBuffer9Arb = 34862,
		// Token: 0x04001D7D RID: 7549
		DrawBuffer9Ati = 34862,
		// Token: 0x04001D7E RID: 7550
		DrawBuffer10,
		// Token: 0x04001D7F RID: 7551
		DrawBuffer10Arb = 34863,
		// Token: 0x04001D80 RID: 7552
		DrawBuffer10Ati = 34863,
		// Token: 0x04001D81 RID: 7553
		DrawBuffer11,
		// Token: 0x04001D82 RID: 7554
		DrawBuffer11Arb = 34864,
		// Token: 0x04001D83 RID: 7555
		DrawBuffer11Ati = 34864,
		// Token: 0x04001D84 RID: 7556
		DrawBuffer12,
		// Token: 0x04001D85 RID: 7557
		DrawBuffer12Arb = 34865,
		// Token: 0x04001D86 RID: 7558
		DrawBuffer12Ati = 34865,
		// Token: 0x04001D87 RID: 7559
		DrawBuffer13,
		// Token: 0x04001D88 RID: 7560
		DrawBuffer13Arb = 34866,
		// Token: 0x04001D89 RID: 7561
		DrawBuffer13Ati = 34866,
		// Token: 0x04001D8A RID: 7562
		DrawBuffer14,
		// Token: 0x04001D8B RID: 7563
		DrawBuffer14Arb = 34867,
		// Token: 0x04001D8C RID: 7564
		DrawBuffer14Ati = 34867,
		// Token: 0x04001D8D RID: 7565
		DrawBuffer15,
		// Token: 0x04001D8E RID: 7566
		DrawBuffer15Arb = 34868,
		// Token: 0x04001D8F RID: 7567
		DrawBuffer15Ati = 34868,
		// Token: 0x04001D90 RID: 7568
		ColorClearUnclampedValueAti,
		// Token: 0x04001D91 RID: 7569
		BlendEquationAlpha = 34877,
		// Token: 0x04001D92 RID: 7570
		BlendEquationAlphaExt = 34877,
		// Token: 0x04001D93 RID: 7571
		SubsampleDistanceAmd = 34879,
		// Token: 0x04001D94 RID: 7572
		MatrixPaletteArb,
		// Token: 0x04001D95 RID: 7573
		MaxMatrixPaletteStackDepthArb,
		// Token: 0x04001D96 RID: 7574
		MaxPaletteMatricesArb,
		// Token: 0x04001D97 RID: 7575
		CurrentPaletteMatrixArb,
		// Token: 0x04001D98 RID: 7576
		MatrixIndexArrayArb,
		// Token: 0x04001D99 RID: 7577
		CurrentMatrixIndexArb,
		// Token: 0x04001D9A RID: 7578
		MatrixIndexArraySizeArb,
		// Token: 0x04001D9B RID: 7579
		MatrixIndexArrayTypeArb,
		// Token: 0x04001D9C RID: 7580
		MatrixIndexArrayStrideArb,
		// Token: 0x04001D9D RID: 7581
		MatrixIndexArrayPointerArb,
		// Token: 0x04001D9E RID: 7582
		TextureDepthSize,
		// Token: 0x04001D9F RID: 7583
		TextureDepthSizeArb = 34890,
		// Token: 0x04001DA0 RID: 7584
		DepthTextureMode,
		// Token: 0x04001DA1 RID: 7585
		DepthTextureModeArb = 34891,
		// Token: 0x04001DA2 RID: 7586
		TextureCompareMode,
		// Token: 0x04001DA3 RID: 7587
		TextureCompareModeArb = 34892,
		// Token: 0x04001DA4 RID: 7588
		TextureCompareFunc,
		// Token: 0x04001DA5 RID: 7589
		TextureCompareFuncArb = 34893,
		// Token: 0x04001DA6 RID: 7590
		CompareRefDepthToTextureExt,
		// Token: 0x04001DA7 RID: 7591
		CompareRefToTexture = 34894,
		// Token: 0x04001DA8 RID: 7592
		CompareRToTexture = 34894,
		// Token: 0x04001DA9 RID: 7593
		CompareRToTextureArb = 34894,
		// Token: 0x04001DAA RID: 7594
		TextureCubeMapSeamless,
		// Token: 0x04001DAB RID: 7595
		OffsetProjectiveTexture2DNv,
		// Token: 0x04001DAC RID: 7596
		OffsetProjectiveTexture2DScaleNv,
		// Token: 0x04001DAD RID: 7597
		OffsetProjectiveTextureRectangleNv,
		// Token: 0x04001DAE RID: 7598
		OffsetProjectiveTextureRectangleScaleNv,
		// Token: 0x04001DAF RID: 7599
		OffsetHiloTexture2DNv,
		// Token: 0x04001DB0 RID: 7600
		OffsetHiloTextureRectangleNv,
		// Token: 0x04001DB1 RID: 7601
		OffsetHiloProjectiveTexture2DNv,
		// Token: 0x04001DB2 RID: 7602
		OffsetHiloProjectiveTextureRectangleNv,
		// Token: 0x04001DB3 RID: 7603
		DependentHiloTexture2DNv,
		// Token: 0x04001DB4 RID: 7604
		DependentRgbTexture3DNv,
		// Token: 0x04001DB5 RID: 7605
		DependentRgbTextureCubeMapNv,
		// Token: 0x04001DB6 RID: 7606
		DotProductPassThroughNv,
		// Token: 0x04001DB7 RID: 7607
		DotProductTexture1DNv,
		// Token: 0x04001DB8 RID: 7608
		DotProductAffineDepthReplaceNv,
		// Token: 0x04001DB9 RID: 7609
		Hilo8Nv,
		// Token: 0x04001DBA RID: 7610
		SignedHilo8Nv,
		// Token: 0x04001DBB RID: 7611
		ForceBlueToOneNv,
		// Token: 0x04001DBC RID: 7612
		PointSprite,
		// Token: 0x04001DBD RID: 7613
		PointSpriteArb = 34913,
		// Token: 0x04001DBE RID: 7614
		PointSpriteNv = 34913,
		// Token: 0x04001DBF RID: 7615
		CoordReplace,
		// Token: 0x04001DC0 RID: 7616
		CoordReplaceArb = 34914,
		// Token: 0x04001DC1 RID: 7617
		CoordReplaceNv = 34914,
		// Token: 0x04001DC2 RID: 7618
		PointSpriteRModeNv,
		// Token: 0x04001DC3 RID: 7619
		PixelCounterBitsNv,
		// Token: 0x04001DC4 RID: 7620
		QueryCounterBits = 34916,
		// Token: 0x04001DC5 RID: 7621
		QueryCounterBitsArb = 34916,
		// Token: 0x04001DC6 RID: 7622
		CurrentOcclusionQueryIdNv,
		// Token: 0x04001DC7 RID: 7623
		CurrentQuery = 34917,
		// Token: 0x04001DC8 RID: 7624
		CurrentQueryArb = 34917,
		// Token: 0x04001DC9 RID: 7625
		PixelCountNv,
		// Token: 0x04001DCA RID: 7626
		QueryResult = 34918,
		// Token: 0x04001DCB RID: 7627
		QueryResultArb = 34918,
		// Token: 0x04001DCC RID: 7628
		PixelCountAvailableNv,
		// Token: 0x04001DCD RID: 7629
		QueryResultAvailable = 34919,
		// Token: 0x04001DCE RID: 7630
		QueryResultAvailableArb = 34919,
		// Token: 0x04001DCF RID: 7631
		MaxFragmentProgramLocalParametersNv,
		// Token: 0x04001DD0 RID: 7632
		MaxVertexAttribs,
		// Token: 0x04001DD1 RID: 7633
		MaxVertexAttribsArb = 34921,
		// Token: 0x04001DD2 RID: 7634
		ArrayNormalized,
		// Token: 0x04001DD3 RID: 7635
		VertexAttribArrayNormalized = 34922,
		// Token: 0x04001DD4 RID: 7636
		VertexAttribArrayNormalizedArb = 34922,
		// Token: 0x04001DD5 RID: 7637
		MaxTessControlInputComponents = 34924,
		// Token: 0x04001DD6 RID: 7638
		MaxTessEvaluationInputComponents,
		// Token: 0x04001DD7 RID: 7639
		DepthStencilToRgbaNv,
		// Token: 0x04001DD8 RID: 7640
		DepthStencilToBgraNv,
		// Token: 0x04001DD9 RID: 7641
		FragmentProgramNv,
		// Token: 0x04001DDA RID: 7642
		MaxTextureCoords,
		// Token: 0x04001DDB RID: 7643
		MaxTextureCoordsArb = 34929,
		// Token: 0x04001DDC RID: 7644
		MaxTextureCoordsNv = 34929,
		// Token: 0x04001DDD RID: 7645
		MaxTextureImageUnits,
		// Token: 0x04001DDE RID: 7646
		MaxTextureImageUnitsArb = 34930,
		// Token: 0x04001DDF RID: 7647
		MaxTextureImageUnitsNv = 34930,
		// Token: 0x04001DE0 RID: 7648
		FragmentProgramBindingNv,
		// Token: 0x04001DE1 RID: 7649
		ProgramErrorStringArb,
		// Token: 0x04001DE2 RID: 7650
		ProgramErrorStringNv = 34932,
		// Token: 0x04001DE3 RID: 7651
		ProgramFormatAsciiArb,
		// Token: 0x04001DE4 RID: 7652
		ProgramFormat,
		// Token: 0x04001DE5 RID: 7653
		ProgramFormatArb = 34934,
		// Token: 0x04001DE6 RID: 7654
		WritePixelDataRangeNv = 34936,
		// Token: 0x04001DE7 RID: 7655
		ReadPixelDataRangeNv,
		// Token: 0x04001DE8 RID: 7656
		WritePixelDataRangeLengthNv,
		// Token: 0x04001DE9 RID: 7657
		ReadPixelDataRangeLengthNv,
		// Token: 0x04001DEA RID: 7658
		WritePixelDataRangePointerNv,
		// Token: 0x04001DEB RID: 7659
		ReadPixelDataRangePointerNv,
		// Token: 0x04001DEC RID: 7660
		GeometryShaderInvocations = 34943,
		// Token: 0x04001DED RID: 7661
		FloatRNv,
		// Token: 0x04001DEE RID: 7662
		FloatRgNv,
		// Token: 0x04001DEF RID: 7663
		FloatRgbNv,
		// Token: 0x04001DF0 RID: 7664
		FloatRgbaNv,
		// Token: 0x04001DF1 RID: 7665
		FloatR16Nv,
		// Token: 0x04001DF2 RID: 7666
		FloatR32Nv,
		// Token: 0x04001DF3 RID: 7667
		FloatRg16Nv,
		// Token: 0x04001DF4 RID: 7668
		FloatRg32Nv,
		// Token: 0x04001DF5 RID: 7669
		FloatRgb16Nv,
		// Token: 0x04001DF6 RID: 7670
		FloatRgb32Nv,
		// Token: 0x04001DF7 RID: 7671
		FloatRgba16Nv,
		// Token: 0x04001DF8 RID: 7672
		FloatRgba32Nv,
		// Token: 0x04001DF9 RID: 7673
		TextureFloatComponentsNv,
		// Token: 0x04001DFA RID: 7674
		FloatClearColorValueNv,
		// Token: 0x04001DFB RID: 7675
		FloatRgbaModeNv,
		// Token: 0x04001DFC RID: 7676
		TextureUnsignedRemapModeNv,
		// Token: 0x04001DFD RID: 7677
		DepthBoundsTestExt,
		// Token: 0x04001DFE RID: 7678
		DepthBoundsExt,
		// Token: 0x04001DFF RID: 7679
		ArrayBuffer,
		// Token: 0x04001E00 RID: 7680
		ArrayBufferArb = 34962,
		// Token: 0x04001E01 RID: 7681
		ElementArrayBuffer,
		// Token: 0x04001E02 RID: 7682
		ElementArrayBufferArb = 34963,
		// Token: 0x04001E03 RID: 7683
		ArrayBufferBinding,
		// Token: 0x04001E04 RID: 7684
		ArrayBufferBindingArb = 34964,
		// Token: 0x04001E05 RID: 7685
		ElementArrayBufferBinding,
		// Token: 0x04001E06 RID: 7686
		ElementArrayBufferBindingArb = 34965,
		// Token: 0x04001E07 RID: 7687
		VertexArrayBufferBinding,
		// Token: 0x04001E08 RID: 7688
		VertexArrayBufferBindingArb = 34966,
		// Token: 0x04001E09 RID: 7689
		NormalArrayBufferBinding,
		// Token: 0x04001E0A RID: 7690
		NormalArrayBufferBindingArb = 34967,
		// Token: 0x04001E0B RID: 7691
		ColorArrayBufferBinding,
		// Token: 0x04001E0C RID: 7692
		ColorArrayBufferBindingArb = 34968,
		// Token: 0x04001E0D RID: 7693
		IndexArrayBufferBinding,
		// Token: 0x04001E0E RID: 7694
		IndexArrayBufferBindingArb = 34969,
		// Token: 0x04001E0F RID: 7695
		TextureCoordArrayBufferBinding,
		// Token: 0x04001E10 RID: 7696
		TextureCoordArrayBufferBindingArb = 34970,
		// Token: 0x04001E11 RID: 7697
		EdgeFlagArrayBufferBinding,
		// Token: 0x04001E12 RID: 7698
		EdgeFlagArrayBufferBindingArb = 34971,
		// Token: 0x04001E13 RID: 7699
		SecondaryColorArrayBufferBinding,
		// Token: 0x04001E14 RID: 7700
		SecondaryColorArrayBufferBindingArb = 34972,
		// Token: 0x04001E15 RID: 7701
		FogCoordArrayBufferBinding,
		// Token: 0x04001E16 RID: 7702
		FogCoordinateArrayBufferBinding = 34973,
		// Token: 0x04001E17 RID: 7703
		FogCoordinateArrayBufferBindingArb = 34973,
		// Token: 0x04001E18 RID: 7704
		WeightArrayBufferBinding,
		// Token: 0x04001E19 RID: 7705
		WeightArrayBufferBindingArb = 34974,
		// Token: 0x04001E1A RID: 7706
		VertexAttribArrayBufferBinding,
		// Token: 0x04001E1B RID: 7707
		VertexAttribArrayBufferBindingArb = 34975,
		// Token: 0x04001E1C RID: 7708
		ProgramInstruction,
		// Token: 0x04001E1D RID: 7709
		ProgramInstructionsArb = 34976,
		// Token: 0x04001E1E RID: 7710
		MaxProgramInstructions,
		// Token: 0x04001E1F RID: 7711
		MaxProgramInstructionsArb = 34977,
		// Token: 0x04001E20 RID: 7712
		ProgramNativeInstructions,
		// Token: 0x04001E21 RID: 7713
		ProgramNativeInstructionsArb = 34978,
		// Token: 0x04001E22 RID: 7714
		MaxProgramNativeInstructions,
		// Token: 0x04001E23 RID: 7715
		MaxProgramNativeInstructionsArb = 34979,
		// Token: 0x04001E24 RID: 7716
		ProgramTemporaries,
		// Token: 0x04001E25 RID: 7717
		ProgramTemporariesArb = 34980,
		// Token: 0x04001E26 RID: 7718
		MaxProgramTemporaries,
		// Token: 0x04001E27 RID: 7719
		MaxProgramTemporariesArb = 34981,
		// Token: 0x04001E28 RID: 7720
		ProgramNativeTemporaries,
		// Token: 0x04001E29 RID: 7721
		ProgramNativeTemporariesArb = 34982,
		// Token: 0x04001E2A RID: 7722
		MaxProgramNativeTemporaries,
		// Token: 0x04001E2B RID: 7723
		MaxProgramNativeTemporariesArb = 34983,
		// Token: 0x04001E2C RID: 7724
		ProgramParameters,
		// Token: 0x04001E2D RID: 7725
		ProgramParametersArb = 34984,
		// Token: 0x04001E2E RID: 7726
		MaxProgramParameters,
		// Token: 0x04001E2F RID: 7727
		MaxProgramParametersArb = 34985,
		// Token: 0x04001E30 RID: 7728
		ProgramNativeParameters,
		// Token: 0x04001E31 RID: 7729
		ProgramNativeParametersArb = 34986,
		// Token: 0x04001E32 RID: 7730
		MaxProgramNativeParameters,
		// Token: 0x04001E33 RID: 7731
		MaxProgramNativeParametersArb = 34987,
		// Token: 0x04001E34 RID: 7732
		ProgramAttribs,
		// Token: 0x04001E35 RID: 7733
		ProgramAttribsArb = 34988,
		// Token: 0x04001E36 RID: 7734
		MaxProgramAttribs,
		// Token: 0x04001E37 RID: 7735
		MaxProgramAttribsArb = 34989,
		// Token: 0x04001E38 RID: 7736
		ProgramNativeAttribs,
		// Token: 0x04001E39 RID: 7737
		ProgramNativeAttribsArb = 34990,
		// Token: 0x04001E3A RID: 7738
		MaxProgramNativeAttribs,
		// Token: 0x04001E3B RID: 7739
		MaxProgramNativeAttribsArb = 34991,
		// Token: 0x04001E3C RID: 7740
		ProgramAddressRegisters,
		// Token: 0x04001E3D RID: 7741
		ProgramAddressRegistersArb = 34992,
		// Token: 0x04001E3E RID: 7742
		MaxProgramAddressRegisters,
		// Token: 0x04001E3F RID: 7743
		MaxProgramAddressRegistersArb = 34993,
		// Token: 0x04001E40 RID: 7744
		ProgramNativeAddressRegisters,
		// Token: 0x04001E41 RID: 7745
		ProgramNativeAddressRegistersArb = 34994,
		// Token: 0x04001E42 RID: 7746
		MaxProgramNativeAddressRegisters,
		// Token: 0x04001E43 RID: 7747
		MaxProgramNativeAddressRegistersArb = 34995,
		// Token: 0x04001E44 RID: 7748
		MaxProgramLocalParameters,
		// Token: 0x04001E45 RID: 7749
		MaxProgramLocalParametersArb = 34996,
		// Token: 0x04001E46 RID: 7750
		MaxProgramEnvParameters,
		// Token: 0x04001E47 RID: 7751
		MaxProgramEnvParametersArb = 34997,
		// Token: 0x04001E48 RID: 7752
		ProgramUnderNativeLimits,
		// Token: 0x04001E49 RID: 7753
		ProgramUnderNativeLimitsArb = 34998,
		// Token: 0x04001E4A RID: 7754
		TransposeCurrentMatrixArb,
		// Token: 0x04001E4B RID: 7755
		ReadOnly,
		// Token: 0x04001E4C RID: 7756
		ReadOnlyArb = 35000,
		// Token: 0x04001E4D RID: 7757
		WriteOnly,
		// Token: 0x04001E4E RID: 7758
		WriteOnlyArb = 35001,
		// Token: 0x04001E4F RID: 7759
		ReadWrite,
		// Token: 0x04001E50 RID: 7760
		ReadWriteArb = 35002,
		// Token: 0x04001E51 RID: 7761
		BufferAccess,
		// Token: 0x04001E52 RID: 7762
		BufferAccessArb = 35003,
		// Token: 0x04001E53 RID: 7763
		BufferMapped,
		// Token: 0x04001E54 RID: 7764
		BufferMappedArb = 35004,
		// Token: 0x04001E55 RID: 7765
		BufferMapPointer,
		// Token: 0x04001E56 RID: 7766
		BufferMapPointerArb = 35005,
		// Token: 0x04001E57 RID: 7767
		WriteDiscardNv,
		// Token: 0x04001E58 RID: 7768
		TimeElapsed,
		// Token: 0x04001E59 RID: 7769
		TimeElapsedExt = 35007,
		// Token: 0x04001E5A RID: 7770
		Matrix0,
		// Token: 0x04001E5B RID: 7771
		Matrix0Arb = 35008,
		// Token: 0x04001E5C RID: 7772
		Matrix1,
		// Token: 0x04001E5D RID: 7773
		Matrix1Arb = 35009,
		// Token: 0x04001E5E RID: 7774
		Matrix2,
		// Token: 0x04001E5F RID: 7775
		Matrix2Arb = 35010,
		// Token: 0x04001E60 RID: 7776
		Matrix3,
		// Token: 0x04001E61 RID: 7777
		Matrix3Arb = 35011,
		// Token: 0x04001E62 RID: 7778
		Matrix4,
		// Token: 0x04001E63 RID: 7779
		Matrix4Arb = 35012,
		// Token: 0x04001E64 RID: 7780
		Matrix5,
		// Token: 0x04001E65 RID: 7781
		Matrix5Arb = 35013,
		// Token: 0x04001E66 RID: 7782
		Matrix6,
		// Token: 0x04001E67 RID: 7783
		Matrix6Arb = 35014,
		// Token: 0x04001E68 RID: 7784
		Matrix7,
		// Token: 0x04001E69 RID: 7785
		Matrix7Arb = 35015,
		// Token: 0x04001E6A RID: 7786
		Matrix8,
		// Token: 0x04001E6B RID: 7787
		Matrix8Arb = 35016,
		// Token: 0x04001E6C RID: 7788
		Matrix9,
		// Token: 0x04001E6D RID: 7789
		Matrix9Arb = 35017,
		// Token: 0x04001E6E RID: 7790
		Matrix10,
		// Token: 0x04001E6F RID: 7791
		Matrix10Arb = 35018,
		// Token: 0x04001E70 RID: 7792
		Matrix11,
		// Token: 0x04001E71 RID: 7793
		Matrix11Arb = 35019,
		// Token: 0x04001E72 RID: 7794
		Matrix12,
		// Token: 0x04001E73 RID: 7795
		Matrix12Arb = 35020,
		// Token: 0x04001E74 RID: 7796
		Matrix13,
		// Token: 0x04001E75 RID: 7797
		Matrix13Arb = 35021,
		// Token: 0x04001E76 RID: 7798
		Matrix14,
		// Token: 0x04001E77 RID: 7799
		Matrix14Arb = 35022,
		// Token: 0x04001E78 RID: 7800
		Matrix15,
		// Token: 0x04001E79 RID: 7801
		Matrix15Arb = 35023,
		// Token: 0x04001E7A RID: 7802
		Matrix16,
		// Token: 0x04001E7B RID: 7803
		Matrix16Arb = 35024,
		// Token: 0x04001E7C RID: 7804
		Matrix17,
		// Token: 0x04001E7D RID: 7805
		Matrix17Arb = 35025,
		// Token: 0x04001E7E RID: 7806
		Matrix18,
		// Token: 0x04001E7F RID: 7807
		Matrix18Arb = 35026,
		// Token: 0x04001E80 RID: 7808
		Matrix19,
		// Token: 0x04001E81 RID: 7809
		Matrix19Arb = 35027,
		// Token: 0x04001E82 RID: 7810
		Matrix20,
		// Token: 0x04001E83 RID: 7811
		Matrix20Arb = 35028,
		// Token: 0x04001E84 RID: 7812
		Matrix21,
		// Token: 0x04001E85 RID: 7813
		Matrix21Arb = 35029,
		// Token: 0x04001E86 RID: 7814
		Matrix22,
		// Token: 0x04001E87 RID: 7815
		Matrix22Arb = 35030,
		// Token: 0x04001E88 RID: 7816
		Matrix23,
		// Token: 0x04001E89 RID: 7817
		Matrix23Arb = 35031,
		// Token: 0x04001E8A RID: 7818
		Matrix24,
		// Token: 0x04001E8B RID: 7819
		Matrix24Arb = 35032,
		// Token: 0x04001E8C RID: 7820
		Matrix25,
		// Token: 0x04001E8D RID: 7821
		Matrix25Arb = 35033,
		// Token: 0x04001E8E RID: 7822
		Matrix26,
		// Token: 0x04001E8F RID: 7823
		Matrix26Arb = 35034,
		// Token: 0x04001E90 RID: 7824
		Matrix27,
		// Token: 0x04001E91 RID: 7825
		Matrix27Arb = 35035,
		// Token: 0x04001E92 RID: 7826
		Matrix28,
		// Token: 0x04001E93 RID: 7827
		Matrix28Arb = 35036,
		// Token: 0x04001E94 RID: 7828
		Matrix29,
		// Token: 0x04001E95 RID: 7829
		Matrix29Arb = 35037,
		// Token: 0x04001E96 RID: 7830
		Matrix30,
		// Token: 0x04001E97 RID: 7831
		Matrix30Arb = 35038,
		// Token: 0x04001E98 RID: 7832
		Matrix31,
		// Token: 0x04001E99 RID: 7833
		Matrix31Arb = 35039,
		// Token: 0x04001E9A RID: 7834
		StreamDraw,
		// Token: 0x04001E9B RID: 7835
		StreamDrawArb = 35040,
		// Token: 0x04001E9C RID: 7836
		StreamRead,
		// Token: 0x04001E9D RID: 7837
		StreamReadArb = 35041,
		// Token: 0x04001E9E RID: 7838
		StreamCopy,
		// Token: 0x04001E9F RID: 7839
		StreamCopyArb = 35042,
		// Token: 0x04001EA0 RID: 7840
		StaticDraw = 35044,
		// Token: 0x04001EA1 RID: 7841
		StaticDrawArb = 35044,
		// Token: 0x04001EA2 RID: 7842
		StaticRead,
		// Token: 0x04001EA3 RID: 7843
		StaticReadArb = 35045,
		// Token: 0x04001EA4 RID: 7844
		StaticCopy,
		// Token: 0x04001EA5 RID: 7845
		StaticCopyArb = 35046,
		// Token: 0x04001EA6 RID: 7846
		DynamicDraw = 35048,
		// Token: 0x04001EA7 RID: 7847
		DynamicDrawArb = 35048,
		// Token: 0x04001EA8 RID: 7848
		DynamicRead,
		// Token: 0x04001EA9 RID: 7849
		DynamicReadArb = 35049,
		// Token: 0x04001EAA RID: 7850
		DynamicCopy,
		// Token: 0x04001EAB RID: 7851
		DynamicCopyArb = 35050,
		// Token: 0x04001EAC RID: 7852
		PixelPackBuffer,
		// Token: 0x04001EAD RID: 7853
		PixelPackBufferArb = 35051,
		// Token: 0x04001EAE RID: 7854
		PixelPackBufferExt = 35051,
		// Token: 0x04001EAF RID: 7855
		PixelUnpackBuffer,
		// Token: 0x04001EB0 RID: 7856
		PixelUnpackBufferArb = 35052,
		// Token: 0x04001EB1 RID: 7857
		PixelUnpackBufferExt = 35052,
		// Token: 0x04001EB2 RID: 7858
		PixelPackBufferBinding,
		// Token: 0x04001EB3 RID: 7859
		PixelPackBufferBindingArb = 35053,
		// Token: 0x04001EB4 RID: 7860
		PixelPackBufferBindingExt = 35053,
		// Token: 0x04001EB5 RID: 7861
		PixelUnpackBufferBinding = 35055,
		// Token: 0x04001EB6 RID: 7862
		PixelUnpackBufferBindingArb = 35055,
		// Token: 0x04001EB7 RID: 7863
		PixelUnpackBufferBindingExt = 35055,
		// Token: 0x04001EB8 RID: 7864
		Depth24Stencil8,
		// Token: 0x04001EB9 RID: 7865
		Depth24Stencil8Ext = 35056,
		// Token: 0x04001EBA RID: 7866
		TextureStencilSize,
		// Token: 0x04001EBB RID: 7867
		TextureStencilSizeExt = 35057,
		// Token: 0x04001EBC RID: 7868
		StencilTagBitsExt,
		// Token: 0x04001EBD RID: 7869
		StencilClearTagValueExt,
		// Token: 0x04001EBE RID: 7870
		MaxProgramExecInstructionsNv,
		// Token: 0x04001EBF RID: 7871
		MaxProgramCallDepthNv,
		// Token: 0x04001EC0 RID: 7872
		MaxProgramIfDepthNv,
		// Token: 0x04001EC1 RID: 7873
		MaxProgramLoopDepthNv,
		// Token: 0x04001EC2 RID: 7874
		MaxProgramLoopCountNv,
		// Token: 0x04001EC3 RID: 7875
		Src1Color,
		// Token: 0x04001EC4 RID: 7876
		OneMinusSrc1Color,
		// Token: 0x04001EC5 RID: 7877
		OneMinusSrc1Alpha,
		// Token: 0x04001EC6 RID: 7878
		MaxDualSourceDrawBuffers,
		// Token: 0x04001EC7 RID: 7879
		VertexAttribArrayInteger,
		// Token: 0x04001EC8 RID: 7880
		VertexAttribArrayIntegerExt = 35069,
		// Token: 0x04001EC9 RID: 7881
		VertexAttribArrayIntegerNv = 35069,
		// Token: 0x04001ECA RID: 7882
		ArrayDivisor,
		// Token: 0x04001ECB RID: 7883
		VertexAttribArrayDivisor = 35070,
		// Token: 0x04001ECC RID: 7884
		VertexAttribArrayDivisorArb = 35070,
		// Token: 0x04001ECD RID: 7885
		MaxArrayTextureLayers,
		// Token: 0x04001ECE RID: 7886
		MaxArrayTextureLayersExt = 35071,
		// Token: 0x04001ECF RID: 7887
		MinProgramTexelOffset = 35076,
		// Token: 0x04001ED0 RID: 7888
		MinProgramTexelOffsetExt = 35076,
		// Token: 0x04001ED1 RID: 7889
		MinProgramTexelOffsetNv = 35076,
		// Token: 0x04001ED2 RID: 7890
		MaxProgramTexelOffset,
		// Token: 0x04001ED3 RID: 7891
		MaxProgramTexelOffsetExt = 35077,
		// Token: 0x04001ED4 RID: 7892
		MaxProgramTexelOffsetNv = 35077,
		// Token: 0x04001ED5 RID: 7893
		ProgramAttribComponentsNv,
		// Token: 0x04001ED6 RID: 7894
		ProgramResultComponentsNv,
		// Token: 0x04001ED7 RID: 7895
		MaxProgramAttribComponentsNv,
		// Token: 0x04001ED8 RID: 7896
		MaxProgramResultComponentsNv,
		// Token: 0x04001ED9 RID: 7897
		StencilTestTwoSideExt = 35088,
		// Token: 0x04001EDA RID: 7898
		ActiveStencilFaceExt,
		// Token: 0x04001EDB RID: 7899
		MirrorClampToBorderExt,
		// Token: 0x04001EDC RID: 7900
		SamplesPassed = 35092,
		// Token: 0x04001EDD RID: 7901
		SamplesPassedArb = 35092,
		// Token: 0x04001EDE RID: 7902
		GeometryVerticesOut = 35094,
		// Token: 0x04001EDF RID: 7903
		GeometryInputType,
		// Token: 0x04001EE0 RID: 7904
		GeometryOutputType,
		// Token: 0x04001EE1 RID: 7905
		SamplerBinding,
		// Token: 0x04001EE2 RID: 7906
		ClampVertexColor,
		// Token: 0x04001EE3 RID: 7907
		ClampVertexColorArb = 35098,
		// Token: 0x04001EE4 RID: 7908
		ClampFragmentColor,
		// Token: 0x04001EE5 RID: 7909
		ClampFragmentColorArb = 35099,
		// Token: 0x04001EE6 RID: 7910
		ClampReadColor,
		// Token: 0x04001EE7 RID: 7911
		ClampReadColorArb = 35100,
		// Token: 0x04001EE8 RID: 7912
		FixedOnly,
		// Token: 0x04001EE9 RID: 7913
		FixedOnlyArb = 35101,
		// Token: 0x04001EEA RID: 7914
		TessControlProgramNv,
		// Token: 0x04001EEB RID: 7915
		TessEvaluationProgramNv,
		// Token: 0x04001EEC RID: 7916
		FragmentShaderAti,
		// Token: 0x04001EED RID: 7917
		Reg0Ati,
		// Token: 0x04001EEE RID: 7918
		Reg1Ati,
		// Token: 0x04001EEF RID: 7919
		Reg2Ati,
		// Token: 0x04001EF0 RID: 7920
		Reg3Ati,
		// Token: 0x04001EF1 RID: 7921
		Reg4Ati,
		// Token: 0x04001EF2 RID: 7922
		Reg5Ati,
		// Token: 0x04001EF3 RID: 7923
		Reg6Ati,
		// Token: 0x04001EF4 RID: 7924
		Reg7Ati,
		// Token: 0x04001EF5 RID: 7925
		Reg8Ati,
		// Token: 0x04001EF6 RID: 7926
		Reg9Ati,
		// Token: 0x04001EF7 RID: 7927
		Reg10Ati,
		// Token: 0x04001EF8 RID: 7928
		Reg11Ati,
		// Token: 0x04001EF9 RID: 7929
		Reg12Ati,
		// Token: 0x04001EFA RID: 7930
		Reg13Ati,
		// Token: 0x04001EFB RID: 7931
		Reg14Ati,
		// Token: 0x04001EFC RID: 7932
		Reg15Ati,
		// Token: 0x04001EFD RID: 7933
		Reg16Ati,
		// Token: 0x04001EFE RID: 7934
		Reg17Ati,
		// Token: 0x04001EFF RID: 7935
		Reg18Ati,
		// Token: 0x04001F00 RID: 7936
		Reg19Ati,
		// Token: 0x04001F01 RID: 7937
		Reg20Ati,
		// Token: 0x04001F02 RID: 7938
		Reg21Ati,
		// Token: 0x04001F03 RID: 7939
		Reg22Ati,
		// Token: 0x04001F04 RID: 7940
		Reg23Ati,
		// Token: 0x04001F05 RID: 7941
		Reg24Ati,
		// Token: 0x04001F06 RID: 7942
		Reg25Ati,
		// Token: 0x04001F07 RID: 7943
		Reg26Ati,
		// Token: 0x04001F08 RID: 7944
		Reg27Ati,
		// Token: 0x04001F09 RID: 7945
		Reg28Ati,
		// Token: 0x04001F0A RID: 7946
		Reg29Ati,
		// Token: 0x04001F0B RID: 7947
		Reg30Ati,
		// Token: 0x04001F0C RID: 7948
		Reg31Ati,
		// Token: 0x04001F0D RID: 7949
		Con0Ati,
		// Token: 0x04001F0E RID: 7950
		Con1Ati,
		// Token: 0x04001F0F RID: 7951
		Con2Ati,
		// Token: 0x04001F10 RID: 7952
		Con3Ati,
		// Token: 0x04001F11 RID: 7953
		Con4Ati,
		// Token: 0x04001F12 RID: 7954
		Con5Ati,
		// Token: 0x04001F13 RID: 7955
		Con6Ati,
		// Token: 0x04001F14 RID: 7956
		Con7Ati,
		// Token: 0x04001F15 RID: 7957
		Con8Ati,
		// Token: 0x04001F16 RID: 7958
		Con9Ati,
		// Token: 0x04001F17 RID: 7959
		Con10Ati,
		// Token: 0x04001F18 RID: 7960
		Con11Ati,
		// Token: 0x04001F19 RID: 7961
		Con12Ati,
		// Token: 0x04001F1A RID: 7962
		Con13Ati,
		// Token: 0x04001F1B RID: 7963
		Con14Ati,
		// Token: 0x04001F1C RID: 7964
		Con15Ati,
		// Token: 0x04001F1D RID: 7965
		Con16Ati,
		// Token: 0x04001F1E RID: 7966
		Con17Ati,
		// Token: 0x04001F1F RID: 7967
		Con18Ati,
		// Token: 0x04001F20 RID: 7968
		Con19Ati,
		// Token: 0x04001F21 RID: 7969
		Con20Ati,
		// Token: 0x04001F22 RID: 7970
		Con21Ati,
		// Token: 0x04001F23 RID: 7971
		Con22Ati,
		// Token: 0x04001F24 RID: 7972
		Con23Ati,
		// Token: 0x04001F25 RID: 7973
		Con24Ati,
		// Token: 0x04001F26 RID: 7974
		Con25Ati,
		// Token: 0x04001F27 RID: 7975
		Con26Ati,
		// Token: 0x04001F28 RID: 7976
		Con27Ati,
		// Token: 0x04001F29 RID: 7977
		Con28Ati,
		// Token: 0x04001F2A RID: 7978
		Con29Ati,
		// Token: 0x04001F2B RID: 7979
		Con30Ati,
		// Token: 0x04001F2C RID: 7980
		Con31Ati,
		// Token: 0x04001F2D RID: 7981
		MovAti,
		// Token: 0x04001F2E RID: 7982
		AddAti = 35171,
		// Token: 0x04001F2F RID: 7983
		MulAti,
		// Token: 0x04001F30 RID: 7984
		SubAti,
		// Token: 0x04001F31 RID: 7985
		Dot3Ati,
		// Token: 0x04001F32 RID: 7986
		Dot4Ati,
		// Token: 0x04001F33 RID: 7987
		MadAti,
		// Token: 0x04001F34 RID: 7988
		LerpAti,
		// Token: 0x04001F35 RID: 7989
		CndAti,
		// Token: 0x04001F36 RID: 7990
		Cnd0Ati,
		// Token: 0x04001F37 RID: 7991
		Dot2AddAti,
		// Token: 0x04001F38 RID: 7992
		SecondaryInterpolatorAti,
		// Token: 0x04001F39 RID: 7993
		NumFragmentRegistersAti,
		// Token: 0x04001F3A RID: 7994
		NumFragmentConstantsAti,
		// Token: 0x04001F3B RID: 7995
		NumPassesAti,
		// Token: 0x04001F3C RID: 7996
		NumInstructionsPerPassAti,
		// Token: 0x04001F3D RID: 7997
		NumInstructionsTotalAti,
		// Token: 0x04001F3E RID: 7998
		NumInputInterpolatorComponentsAti,
		// Token: 0x04001F3F RID: 7999
		NumLoopbackComponentsAti,
		// Token: 0x04001F40 RID: 8000
		ColorAlphaPairingAti,
		// Token: 0x04001F41 RID: 8001
		SwizzleStrAti,
		// Token: 0x04001F42 RID: 8002
		SwizzleStqAti,
		// Token: 0x04001F43 RID: 8003
		SwizzleStrDrAti,
		// Token: 0x04001F44 RID: 8004
		SwizzleStqDqAti,
		// Token: 0x04001F45 RID: 8005
		SwizzleStrqAti,
		// Token: 0x04001F46 RID: 8006
		SwizzleStrqDqAti,
		// Token: 0x04001F47 RID: 8007
		InterlaceOml = 35200,
		// Token: 0x04001F48 RID: 8008
		InterlaceReadOml,
		// Token: 0x04001F49 RID: 8009
		FormatSubsample2424Oml,
		// Token: 0x04001F4A RID: 8010
		FormatSubsample244244Oml,
		// Token: 0x04001F4B RID: 8011
		PackResampleOml,
		// Token: 0x04001F4C RID: 8012
		UnpackResampleOml,
		// Token: 0x04001F4D RID: 8013
		ResampleReplicateOml,
		// Token: 0x04001F4E RID: 8014
		ResampleZeroFillOml,
		// Token: 0x04001F4F RID: 8015
		ResampleAverageOml,
		// Token: 0x04001F50 RID: 8016
		ResampleDecimateOml,
		// Token: 0x04001F51 RID: 8017
		VertexAttribMap1Apple = 35328,
		// Token: 0x04001F52 RID: 8018
		VertexAttribMap2Apple,
		// Token: 0x04001F53 RID: 8019
		VertexAttribMap1SizeApple,
		// Token: 0x04001F54 RID: 8020
		VertexAttribMap1CoeffApple,
		// Token: 0x04001F55 RID: 8021
		VertexAttribMap1OrderApple,
		// Token: 0x04001F56 RID: 8022
		VertexAttribMap1DomainApple,
		// Token: 0x04001F57 RID: 8023
		VertexAttribMap2SizeApple,
		// Token: 0x04001F58 RID: 8024
		VertexAttribMap2CoeffApple,
		// Token: 0x04001F59 RID: 8025
		VertexAttribMap2OrderApple,
		// Token: 0x04001F5A RID: 8026
		VertexAttribMap2DomainApple,
		// Token: 0x04001F5B RID: 8027
		DrawPixelsApple,
		// Token: 0x04001F5C RID: 8028
		FenceApple,
		// Token: 0x04001F5D RID: 8029
		ElementArrayApple,
		// Token: 0x04001F5E RID: 8030
		ElementArrayTypeApple,
		// Token: 0x04001F5F RID: 8031
		ElementArrayPointerApple,
		// Token: 0x04001F60 RID: 8032
		ColorFloatApple,
		// Token: 0x04001F61 RID: 8033
		UniformBuffer = 35345,
		// Token: 0x04001F62 RID: 8034
		BufferSerializedModifyApple,
		// Token: 0x04001F63 RID: 8035
		BufferFlushingUnmapApple,
		// Token: 0x04001F64 RID: 8036
		AuxDepthStencilApple,
		// Token: 0x04001F65 RID: 8037
		PackRowBytesApple,
		// Token: 0x04001F66 RID: 8038
		UnpackRowBytesApple,
		// Token: 0x04001F67 RID: 8039
		ReleasedApple = 35353,
		// Token: 0x04001F68 RID: 8040
		VolatileApple,
		// Token: 0x04001F69 RID: 8041
		RetainedApple,
		// Token: 0x04001F6A RID: 8042
		UndefinedApple,
		// Token: 0x04001F6B RID: 8043
		PurgeableApple,
		// Token: 0x04001F6C RID: 8044
		Rgb422Apple = 35359,
		// Token: 0x04001F6D RID: 8045
		UniformBufferBinding = 35368,
		// Token: 0x04001F6E RID: 8046
		UniformBufferStart,
		// Token: 0x04001F6F RID: 8047
		UniformBufferSize,
		// Token: 0x04001F70 RID: 8048
		MaxVertexUniformBlocks,
		// Token: 0x04001F71 RID: 8049
		MaxGeometryUniformBlocks,
		// Token: 0x04001F72 RID: 8050
		MaxFragmentUniformBlocks,
		// Token: 0x04001F73 RID: 8051
		MaxCombinedUniformBlocks,
		// Token: 0x04001F74 RID: 8052
		MaxUniformBufferBindings,
		// Token: 0x04001F75 RID: 8053
		MaxUniformBlockSize,
		// Token: 0x04001F76 RID: 8054
		MaxCombinedVertexUniformComponents,
		// Token: 0x04001F77 RID: 8055
		MaxCombinedGeometryUniformComponents,
		// Token: 0x04001F78 RID: 8056
		MaxCombinedFragmentUniformComponents,
		// Token: 0x04001F79 RID: 8057
		UniformBufferOffsetAlignment,
		// Token: 0x04001F7A RID: 8058
		ActiveUniformBlockMaxNameLength,
		// Token: 0x04001F7B RID: 8059
		ActiveUniformBlocks,
		// Token: 0x04001F7C RID: 8060
		UniformType,
		// Token: 0x04001F7D RID: 8061
		UniformSize,
		// Token: 0x04001F7E RID: 8062
		UniformNameLength,
		// Token: 0x04001F7F RID: 8063
		UniformBlockIndex,
		// Token: 0x04001F80 RID: 8064
		UniformOffset,
		// Token: 0x04001F81 RID: 8065
		UniformArrayStride,
		// Token: 0x04001F82 RID: 8066
		UniformMatrixStride,
		// Token: 0x04001F83 RID: 8067
		UniformIsRowMajor,
		// Token: 0x04001F84 RID: 8068
		UniformBlockBinding,
		// Token: 0x04001F85 RID: 8069
		UniformBlockDataSize,
		// Token: 0x04001F86 RID: 8070
		UniformBlockNameLength,
		// Token: 0x04001F87 RID: 8071
		UniformBlockActiveUniforms,
		// Token: 0x04001F88 RID: 8072
		UniformBlockActiveUniformIndices,
		// Token: 0x04001F89 RID: 8073
		UniformBlockReferencedByVertexShader,
		// Token: 0x04001F8A RID: 8074
		UniformBlockReferencedByGeometryShader,
		// Token: 0x04001F8B RID: 8075
		UniformBlockReferencedByFragmentShader,
		// Token: 0x04001F8C RID: 8076
		TextureSrgbDecodeExt = 35400,
		// Token: 0x04001F8D RID: 8077
		DecodeExt,
		// Token: 0x04001F8E RID: 8078
		SkipDecodeExt,
		// Token: 0x04001F8F RID: 8079
		ProgramPipelineObjectExt = 35407,
		// Token: 0x04001F90 RID: 8080
		RgbRaw422Apple = 35409,
		// Token: 0x04001F91 RID: 8081
		FragmentShader = 35632,
		// Token: 0x04001F92 RID: 8082
		FragmentShaderArb = 35632,
		// Token: 0x04001F93 RID: 8083
		VertexShader,
		// Token: 0x04001F94 RID: 8084
		VertexShaderArb = 35633,
		// Token: 0x04001F95 RID: 8085
		ProgramObjectArb = 35648,
		// Token: 0x04001F96 RID: 8086
		ProgramObjectExt = 35648,
		// Token: 0x04001F97 RID: 8087
		ShaderObjectArb = 35656,
		// Token: 0x04001F98 RID: 8088
		ShaderObjectExt = 35656,
		// Token: 0x04001F99 RID: 8089
		MaxFragmentUniformComponents,
		// Token: 0x04001F9A RID: 8090
		MaxFragmentUniformComponentsArb = 35657,
		// Token: 0x04001F9B RID: 8091
		MaxVertexUniformComponents,
		// Token: 0x04001F9C RID: 8092
		MaxVertexUniformComponentsArb = 35658,
		// Token: 0x04001F9D RID: 8093
		MaxVaryingComponents,
		// Token: 0x04001F9E RID: 8094
		MaxVaryingComponentsExt = 35659,
		// Token: 0x04001F9F RID: 8095
		MaxVaryingFloats = 35659,
		// Token: 0x04001FA0 RID: 8096
		MaxVaryingFloatsArb = 35659,
		// Token: 0x04001FA1 RID: 8097
		MaxVertexTextureImageUnits,
		// Token: 0x04001FA2 RID: 8098
		MaxVertexTextureImageUnitsArb = 35660,
		// Token: 0x04001FA3 RID: 8099
		MaxCombinedTextureImageUnits,
		// Token: 0x04001FA4 RID: 8100
		MaxCombinedTextureImageUnitsArb = 35661,
		// Token: 0x04001FA5 RID: 8101
		ObjectTypeArb,
		// Token: 0x04001FA6 RID: 8102
		ObjectSubtypeArb,
		// Token: 0x04001FA7 RID: 8103
		ShaderType = 35663,
		// Token: 0x04001FA8 RID: 8104
		FloatVec2,
		// Token: 0x04001FA9 RID: 8105
		FloatVec2Arb = 35664,
		// Token: 0x04001FAA RID: 8106
		FloatVec3,
		// Token: 0x04001FAB RID: 8107
		FloatVec3Arb = 35665,
		// Token: 0x04001FAC RID: 8108
		FloatVec4,
		// Token: 0x04001FAD RID: 8109
		FloatVec4Arb = 35666,
		// Token: 0x04001FAE RID: 8110
		IntVec2,
		// Token: 0x04001FAF RID: 8111
		IntVec2Arb = 35667,
		// Token: 0x04001FB0 RID: 8112
		IntVec3,
		// Token: 0x04001FB1 RID: 8113
		IntVec3Arb = 35668,
		// Token: 0x04001FB2 RID: 8114
		IntVec4,
		// Token: 0x04001FB3 RID: 8115
		IntVec4Arb = 35669,
		// Token: 0x04001FB4 RID: 8116
		Bool,
		// Token: 0x04001FB5 RID: 8117
		BoolArb = 35670,
		// Token: 0x04001FB6 RID: 8118
		BoolVec2,
		// Token: 0x04001FB7 RID: 8119
		BoolVec2Arb = 35671,
		// Token: 0x04001FB8 RID: 8120
		BoolVec3,
		// Token: 0x04001FB9 RID: 8121
		BoolVec3Arb = 35672,
		// Token: 0x04001FBA RID: 8122
		BoolVec4,
		// Token: 0x04001FBB RID: 8123
		BoolVec4Arb = 35673,
		// Token: 0x04001FBC RID: 8124
		FloatMat2,
		// Token: 0x04001FBD RID: 8125
		FloatMat2Arb = 35674,
		// Token: 0x04001FBE RID: 8126
		FloatMat3,
		// Token: 0x04001FBF RID: 8127
		FloatMat3Arb = 35675,
		// Token: 0x04001FC0 RID: 8128
		FloatMat4,
		// Token: 0x04001FC1 RID: 8129
		FloatMat4Arb = 35676,
		// Token: 0x04001FC2 RID: 8130
		Sampler1D,
		// Token: 0x04001FC3 RID: 8131
		Sampler1DArb = 35677,
		// Token: 0x04001FC4 RID: 8132
		Sampler2D,
		// Token: 0x04001FC5 RID: 8133
		Sampler2DArb = 35678,
		// Token: 0x04001FC6 RID: 8134
		Sampler3D,
		// Token: 0x04001FC7 RID: 8135
		Sampler3DArb = 35679,
		// Token: 0x04001FC8 RID: 8136
		SamplerCube,
		// Token: 0x04001FC9 RID: 8137
		SamplerCubeArb = 35680,
		// Token: 0x04001FCA RID: 8138
		Sampler1DShadow,
		// Token: 0x04001FCB RID: 8139
		Sampler1DShadowArb = 35681,
		// Token: 0x04001FCC RID: 8140
		Sampler2DShadow,
		// Token: 0x04001FCD RID: 8141
		Sampler2DShadowArb = 35682,
		// Token: 0x04001FCE RID: 8142
		Sampler2DRect,
		// Token: 0x04001FCF RID: 8143
		Sampler2DRectArb = 35683,
		// Token: 0x04001FD0 RID: 8144
		Sampler2DRectShadow,
		// Token: 0x04001FD1 RID: 8145
		Sampler2DRectShadowArb = 35684,
		// Token: 0x04001FD2 RID: 8146
		FloatMat2x3,
		// Token: 0x04001FD3 RID: 8147
		FloatMat2x4,
		// Token: 0x04001FD4 RID: 8148
		FloatMat3x2,
		// Token: 0x04001FD5 RID: 8149
		FloatMat3x4,
		// Token: 0x04001FD6 RID: 8150
		FloatMat4x2,
		// Token: 0x04001FD7 RID: 8151
		FloatMat4x3,
		// Token: 0x04001FD8 RID: 8152
		DeleteStatus = 35712,
		// Token: 0x04001FD9 RID: 8153
		ObjectDeleteStatusArb = 35712,
		// Token: 0x04001FDA RID: 8154
		CompileStatus,
		// Token: 0x04001FDB RID: 8155
		ObjectCompileStatusArb = 35713,
		// Token: 0x04001FDC RID: 8156
		LinkStatus,
		// Token: 0x04001FDD RID: 8157
		ObjectLinkStatusArb = 35714,
		// Token: 0x04001FDE RID: 8158
		ObjectValidateStatusArb,
		// Token: 0x04001FDF RID: 8159
		ValidateStatus = 35715,
		// Token: 0x04001FE0 RID: 8160
		InfoLogLength,
		// Token: 0x04001FE1 RID: 8161
		ObjectInfoLogLengthArb = 35716,
		// Token: 0x04001FE2 RID: 8162
		AttachedShaders,
		// Token: 0x04001FE3 RID: 8163
		ObjectAttachedObjectsArb = 35717,
		// Token: 0x04001FE4 RID: 8164
		ActiveUniforms,
		// Token: 0x04001FE5 RID: 8165
		ObjectActiveUniformsArb = 35718,
		// Token: 0x04001FE6 RID: 8166
		ActiveUniformMaxLength,
		// Token: 0x04001FE7 RID: 8167
		ObjectActiveUniformMaxLengthArb = 35719,
		// Token: 0x04001FE8 RID: 8168
		ObjectShaderSourceLengthArb,
		// Token: 0x04001FE9 RID: 8169
		ShaderSourceLength = 35720,
		// Token: 0x04001FEA RID: 8170
		ActiveAttributes,
		// Token: 0x04001FEB RID: 8171
		ObjectActiveAttributesArb = 35721,
		// Token: 0x04001FEC RID: 8172
		ActiveAttributeMaxLength,
		// Token: 0x04001FED RID: 8173
		ObjectActiveAttributeMaxLengthArb = 35722,
		// Token: 0x04001FEE RID: 8174
		FragmentShaderDerivativeHint,
		// Token: 0x04001FEF RID: 8175
		FragmentShaderDerivativeHintArb = 35723,
		// Token: 0x04001FF0 RID: 8176
		FragmentShaderDerivativeHintOes = 35723,
		// Token: 0x04001FF1 RID: 8177
		ShadingLanguageVersion,
		// Token: 0x04001FF2 RID: 8178
		ShadingLanguageVersionArb = 35724,
		// Token: 0x04001FF3 RID: 8179
		ActiveProgramExt,
		// Token: 0x04001FF4 RID: 8180
		CurrentProgram = 35725,
		// Token: 0x04001FF5 RID: 8181
		Palette4Rgb8Oes = 35728,
		// Token: 0x04001FF6 RID: 8182
		Palette4Rgba8Oes,
		// Token: 0x04001FF7 RID: 8183
		Palette4R5G6B5Oes,
		// Token: 0x04001FF8 RID: 8184
		Palette4Rgba4Oes,
		// Token: 0x04001FF9 RID: 8185
		Palette4Rgb5A1Oes,
		// Token: 0x04001FFA RID: 8186
		Palette8Rgb8Oes,
		// Token: 0x04001FFB RID: 8187
		Palette8Rgba8Oes,
		// Token: 0x04001FFC RID: 8188
		Palette8R5G6B5Oes,
		// Token: 0x04001FFD RID: 8189
		Palette8Rgba4Oes,
		// Token: 0x04001FFE RID: 8190
		Palette8Rgb5A1Oes,
		// Token: 0x04001FFF RID: 8191
		ImplementationColorReadType,
		// Token: 0x04002000 RID: 8192
		ImplementationColorReadTypeOes = 35738,
		// Token: 0x04002001 RID: 8193
		ImplementationColorReadFormat,
		// Token: 0x04002002 RID: 8194
		ImplementationColorReadFormatOes = 35739,
		// Token: 0x04002003 RID: 8195
		CounterTypeAmd = 35776,
		// Token: 0x04002004 RID: 8196
		CounterRangeAmd,
		// Token: 0x04002005 RID: 8197
		UnsignedInt64Amd,
		// Token: 0x04002006 RID: 8198
		PercentageAmd,
		// Token: 0x04002007 RID: 8199
		PerfmonResultAvailableAmd,
		// Token: 0x04002008 RID: 8200
		PerfmonResultSizeAmd,
		// Token: 0x04002009 RID: 8201
		PerfmonResultAmd,
		// Token: 0x0400200A RID: 8202
		TextureRedType = 35856,
		// Token: 0x0400200B RID: 8203
		TextureRedTypeArb = 35856,
		// Token: 0x0400200C RID: 8204
		TextureGreenType,
		// Token: 0x0400200D RID: 8205
		TextureGreenTypeArb = 35857,
		// Token: 0x0400200E RID: 8206
		TextureBlueType,
		// Token: 0x0400200F RID: 8207
		TextureBlueTypeArb = 35858,
		// Token: 0x04002010 RID: 8208
		TextureAlphaType,
		// Token: 0x04002011 RID: 8209
		TextureAlphaTypeArb = 35859,
		// Token: 0x04002012 RID: 8210
		TextureLuminanceType,
		// Token: 0x04002013 RID: 8211
		TextureLuminanceTypeArb = 35860,
		// Token: 0x04002014 RID: 8212
		TextureIntensityType,
		// Token: 0x04002015 RID: 8213
		TextureIntensityTypeArb = 35861,
		// Token: 0x04002016 RID: 8214
		TextureDepthType,
		// Token: 0x04002017 RID: 8215
		TextureDepthTypeArb = 35862,
		// Token: 0x04002018 RID: 8216
		UnsignedNormalized,
		// Token: 0x04002019 RID: 8217
		UnsignedNormalizedArb = 35863,
		// Token: 0x0400201A RID: 8218
		Texture1DArray,
		// Token: 0x0400201B RID: 8219
		Texture1DArrayExt = 35864,
		// Token: 0x0400201C RID: 8220
		ProxyTexture1DArray,
		// Token: 0x0400201D RID: 8221
		ProxyTexture1DArrayExt = 35865,
		// Token: 0x0400201E RID: 8222
		Texture2DArray,
		// Token: 0x0400201F RID: 8223
		Texture2DArrayExt = 35866,
		// Token: 0x04002020 RID: 8224
		ProxyTexture2DArray,
		// Token: 0x04002021 RID: 8225
		ProxyTexture2DArrayExt = 35867,
		// Token: 0x04002022 RID: 8226
		TextureBinding1DArray,
		// Token: 0x04002023 RID: 8227
		TextureBinding1DArrayExt = 35868,
		// Token: 0x04002024 RID: 8228
		TextureBinding2DArray,
		// Token: 0x04002025 RID: 8229
		TextureBinding2DArrayExt = 35869,
		// Token: 0x04002026 RID: 8230
		GeometryProgramNv = 35878,
		// Token: 0x04002027 RID: 8231
		MaxProgramOutputVerticesNv,
		// Token: 0x04002028 RID: 8232
		MaxProgramTotalOutputComponentsNv,
		// Token: 0x04002029 RID: 8233
		MaxGeometryTextureImageUnits,
		// Token: 0x0400202A RID: 8234
		MaxGeometryTextureImageUnitsArb = 35881,
		// Token: 0x0400202B RID: 8235
		MaxGeometryTextureImageUnitsExt = 35881,
		// Token: 0x0400202C RID: 8236
		TextureBuffer,
		// Token: 0x0400202D RID: 8237
		TextureBufferArb = 35882,
		// Token: 0x0400202E RID: 8238
		TextureBufferBinding = 35882,
		// Token: 0x0400202F RID: 8239
		TextureBufferExt = 35882,
		// Token: 0x04002030 RID: 8240
		MaxTextureBufferSize,
		// Token: 0x04002031 RID: 8241
		MaxTextureBufferSizeArb = 35883,
		// Token: 0x04002032 RID: 8242
		MaxTextureBufferSizeExt = 35883,
		// Token: 0x04002033 RID: 8243
		TextureBindingBuffer,
		// Token: 0x04002034 RID: 8244
		TextureBindingBufferArb = 35884,
		// Token: 0x04002035 RID: 8245
		TextureBindingBufferExt = 35884,
		// Token: 0x04002036 RID: 8246
		TextureBufferDataStoreBinding,
		// Token: 0x04002037 RID: 8247
		TextureBufferDataStoreBindingArb = 35885,
		// Token: 0x04002038 RID: 8248
		TextureBufferDataStoreBindingExt = 35885,
		// Token: 0x04002039 RID: 8249
		TextureBufferFormatArb,
		// Token: 0x0400203A RID: 8250
		TextureBufferFormatExt = 35886,
		// Token: 0x0400203B RID: 8251
		AnySamplesPassed,
		// Token: 0x0400203C RID: 8252
		SampleShading = 35894,
		// Token: 0x0400203D RID: 8253
		SampleShadingArb = 35894,
		// Token: 0x0400203E RID: 8254
		MinSampleShadingValue,
		// Token: 0x0400203F RID: 8255
		MinSampleShadingValueArb = 35895,
		// Token: 0x04002040 RID: 8256
		R11fG11fB10f = 35898,
		// Token: 0x04002041 RID: 8257
		R11fG11fB10fExt = 35898,
		// Token: 0x04002042 RID: 8258
		UnsignedInt10F11F11FRev,
		// Token: 0x04002043 RID: 8259
		UnsignedInt10F11F11FRevExt = 35899,
		// Token: 0x04002044 RID: 8260
		RgbaSignedComponentsExt,
		// Token: 0x04002045 RID: 8261
		Rgb9E5,
		// Token: 0x04002046 RID: 8262
		Rgb9E5Ext = 35901,
		// Token: 0x04002047 RID: 8263
		UnsignedInt5999Rev,
		// Token: 0x04002048 RID: 8264
		UnsignedInt5999RevExt = 35902,
		// Token: 0x04002049 RID: 8265
		TextureSharedSize,
		// Token: 0x0400204A RID: 8266
		TextureSharedSizeExt = 35903,
		// Token: 0x0400204B RID: 8267
		Srgb,
		// Token: 0x0400204C RID: 8268
		SrgbExt = 35904,
		// Token: 0x0400204D RID: 8269
		Srgb8,
		// Token: 0x0400204E RID: 8270
		Srgb8Ext = 35905,
		// Token: 0x0400204F RID: 8271
		SrgbAlpha,
		// Token: 0x04002050 RID: 8272
		SrgbAlphaExt = 35906,
		// Token: 0x04002051 RID: 8273
		Srgb8Alpha8,
		// Token: 0x04002052 RID: 8274
		Srgb8Alpha8Ext = 35907,
		// Token: 0x04002053 RID: 8275
		SluminanceAlpha,
		// Token: 0x04002054 RID: 8276
		SluminanceAlphaExt = 35908,
		// Token: 0x04002055 RID: 8277
		Sluminance8Alpha8,
		// Token: 0x04002056 RID: 8278
		Sluminance8Alpha8Ext = 35909,
		// Token: 0x04002057 RID: 8279
		Sluminance,
		// Token: 0x04002058 RID: 8280
		SluminanceExt = 35910,
		// Token: 0x04002059 RID: 8281
		Sluminance8,
		// Token: 0x0400205A RID: 8282
		Sluminance8Ext = 35911,
		// Token: 0x0400205B RID: 8283
		CompressedSrgb,
		// Token: 0x0400205C RID: 8284
		CompressedSrgbExt = 35912,
		// Token: 0x0400205D RID: 8285
		CompressedSrgbAlpha,
		// Token: 0x0400205E RID: 8286
		CompressedSrgbAlphaExt = 35913,
		// Token: 0x0400205F RID: 8287
		CompressedSluminance,
		// Token: 0x04002060 RID: 8288
		CompressedSluminanceExt = 35914,
		// Token: 0x04002061 RID: 8289
		CompressedSluminanceAlpha,
		// Token: 0x04002062 RID: 8290
		CompressedSluminanceAlphaExt = 35915,
		// Token: 0x04002063 RID: 8291
		CompressedSrgbS3tcDxt1Ext,
		// Token: 0x04002064 RID: 8292
		CompressedSrgbAlphaS3tcDxt1Ext,
		// Token: 0x04002065 RID: 8293
		CompressedSrgbAlphaS3tcDxt3Ext,
		// Token: 0x04002066 RID: 8294
		CompressedSrgbAlphaS3tcDxt5Ext,
		// Token: 0x04002067 RID: 8295
		CompressedLuminanceLatc1Ext = 35952,
		// Token: 0x04002068 RID: 8296
		CompressedSignedLuminanceLatc1Ext,
		// Token: 0x04002069 RID: 8297
		CompressedLuminanceAlphaLatc2Ext,
		// Token: 0x0400206A RID: 8298
		CompressedSignedLuminanceAlphaLatc2Ext,
		// Token: 0x0400206B RID: 8299
		TessControlProgramParameterBufferNv,
		// Token: 0x0400206C RID: 8300
		TessEvaluationProgramParameterBufferNv,
		// Token: 0x0400206D RID: 8301
		TransformFeedbackVaryingMaxLength,
		// Token: 0x0400206E RID: 8302
		TransformFeedbackVaryingMaxLengthExt = 35958,
		// Token: 0x0400206F RID: 8303
		BackPrimaryColorNv,
		// Token: 0x04002070 RID: 8304
		BackSecondaryColorNv,
		// Token: 0x04002071 RID: 8305
		TextureCoordNv,
		// Token: 0x04002072 RID: 8306
		ClipDistanceNv,
		// Token: 0x04002073 RID: 8307
		VertexIdNv,
		// Token: 0x04002074 RID: 8308
		PrimitiveIdNv,
		// Token: 0x04002075 RID: 8309
		GenericAttribNv,
		// Token: 0x04002076 RID: 8310
		TransformFeedbackAttribsNv,
		// Token: 0x04002077 RID: 8311
		TransformFeedbackBufferMode,
		// Token: 0x04002078 RID: 8312
		TransformFeedbackBufferModeExt = 35967,
		// Token: 0x04002079 RID: 8313
		TransformFeedbackBufferModeNv = 35967,
		// Token: 0x0400207A RID: 8314
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x0400207B RID: 8315
		MaxTransformFeedbackSeparateComponentsExt = 35968,
		// Token: 0x0400207C RID: 8316
		MaxTransformFeedbackSeparateComponentsNv = 35968,
		// Token: 0x0400207D RID: 8317
		ActiveVaryingsNv,
		// Token: 0x0400207E RID: 8318
		ActiveVaryingMaxLengthNv,
		// Token: 0x0400207F RID: 8319
		TransformFeedbackVaryings,
		// Token: 0x04002080 RID: 8320
		TransformFeedbackVaryingsExt = 35971,
		// Token: 0x04002081 RID: 8321
		TransformFeedbackVaryingsNv = 35971,
		// Token: 0x04002082 RID: 8322
		TransformFeedbackBufferStart,
		// Token: 0x04002083 RID: 8323
		TransformFeedbackBufferStartExt = 35972,
		// Token: 0x04002084 RID: 8324
		TransformFeedbackBufferStartNv = 35972,
		// Token: 0x04002085 RID: 8325
		TransformFeedbackBufferSize,
		// Token: 0x04002086 RID: 8326
		TransformFeedbackBufferSizeExt = 35973,
		// Token: 0x04002087 RID: 8327
		TransformFeedbackBufferSizeNv = 35973,
		// Token: 0x04002088 RID: 8328
		TransformFeedbackRecordNv,
		// Token: 0x04002089 RID: 8329
		PrimitivesGenerated,
		// Token: 0x0400208A RID: 8330
		PrimitivesGeneratedExt = 35975,
		// Token: 0x0400208B RID: 8331
		PrimitivesGeneratedNv = 35975,
		// Token: 0x0400208C RID: 8332
		TransformFeedbackPrimitivesWritten,
		// Token: 0x0400208D RID: 8333
		TransformFeedbackPrimitivesWrittenExt = 35976,
		// Token: 0x0400208E RID: 8334
		TransformFeedbackPrimitivesWrittenNv = 35976,
		// Token: 0x0400208F RID: 8335
		RasterizerDiscard,
		// Token: 0x04002090 RID: 8336
		RasterizerDiscardExt = 35977,
		// Token: 0x04002091 RID: 8337
		RasterizerDiscardNv = 35977,
		// Token: 0x04002092 RID: 8338
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x04002093 RID: 8339
		MaxTransformFeedbackInterleavedComponentsExt = 35978,
		// Token: 0x04002094 RID: 8340
		MaxTransformFeedbackInterleavedComponentsNv = 35978,
		// Token: 0x04002095 RID: 8341
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x04002096 RID: 8342
		MaxTransformFeedbackSeparateAttribsExt = 35979,
		// Token: 0x04002097 RID: 8343
		MaxTransformFeedbackSeparateAttribsNv = 35979,
		// Token: 0x04002098 RID: 8344
		InterleavedAttribs,
		// Token: 0x04002099 RID: 8345
		InterleavedAttribsExt = 35980,
		// Token: 0x0400209A RID: 8346
		InterleavedAttribsNv = 35980,
		// Token: 0x0400209B RID: 8347
		SeparateAttribs,
		// Token: 0x0400209C RID: 8348
		SeparateAttribsExt = 35981,
		// Token: 0x0400209D RID: 8349
		SeparateAttribsNv = 35981,
		// Token: 0x0400209E RID: 8350
		TransformFeedbackBuffer,
		// Token: 0x0400209F RID: 8351
		TransformFeedbackBufferExt = 35982,
		// Token: 0x040020A0 RID: 8352
		TransformFeedbackBufferNv = 35982,
		// Token: 0x040020A1 RID: 8353
		TransformFeedbackBufferBinding,
		// Token: 0x040020A2 RID: 8354
		TransformFeedbackBufferBindingExt = 35983,
		// Token: 0x040020A3 RID: 8355
		TransformFeedbackBufferBindingNv = 35983,
		// Token: 0x040020A4 RID: 8356
		PointSpriteCoordOrigin = 36000,
		// Token: 0x040020A5 RID: 8357
		LowerLeft,
		// Token: 0x040020A6 RID: 8358
		UpperLeft,
		// Token: 0x040020A7 RID: 8359
		StencilBackRef,
		// Token: 0x040020A8 RID: 8360
		StencilBackValueMask,
		// Token: 0x040020A9 RID: 8361
		StencilBackWritemask,
		// Token: 0x040020AA RID: 8362
		DrawFramebufferBinding,
		// Token: 0x040020AB RID: 8363
		DrawFramebufferBindingExt = 36006,
		// Token: 0x040020AC RID: 8364
		FramebufferBinding = 36006,
		// Token: 0x040020AD RID: 8365
		FramebufferBindingExt = 36006,
		// Token: 0x040020AE RID: 8366
		RenderbufferBinding,
		// Token: 0x040020AF RID: 8367
		RenderbufferBindingExt = 36007,
		// Token: 0x040020B0 RID: 8368
		ReadFramebuffer,
		// Token: 0x040020B1 RID: 8369
		ReadFramebufferExt = 36008,
		// Token: 0x040020B2 RID: 8370
		DrawFramebuffer,
		// Token: 0x040020B3 RID: 8371
		DrawFramebufferExt = 36009,
		// Token: 0x040020B4 RID: 8372
		ReadFramebufferBinding,
		// Token: 0x040020B5 RID: 8373
		ReadFramebufferBindingExt = 36010,
		// Token: 0x040020B6 RID: 8374
		RenderbufferCoverageSamplesNv,
		// Token: 0x040020B7 RID: 8375
		RenderbufferSamples = 36011,
		// Token: 0x040020B8 RID: 8376
		RenderbufferSamplesExt = 36011,
		// Token: 0x040020B9 RID: 8377
		DepthComponent32f,
		// Token: 0x040020BA RID: 8378
		Depth32fStencil8,
		// Token: 0x040020BB RID: 8379
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x040020BC RID: 8380
		FramebufferAttachmentObjectTypeExt = 36048,
		// Token: 0x040020BD RID: 8381
		FramebufferAttachmentObjectName,
		// Token: 0x040020BE RID: 8382
		FramebufferAttachmentObjectNameExt = 36049,
		// Token: 0x040020BF RID: 8383
		FramebufferAttachmentTextureLevel,
		// Token: 0x040020C0 RID: 8384
		FramebufferAttachmentTextureLevelExt = 36050,
		// Token: 0x040020C1 RID: 8385
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x040020C2 RID: 8386
		FramebufferAttachmentTextureCubeMapFaceExt = 36051,
		// Token: 0x040020C3 RID: 8387
		FramebufferAttachmentTexture3DZoffsetExt,
		// Token: 0x040020C4 RID: 8388
		FramebufferAttachmentTextureLayer = 36052,
		// Token: 0x040020C5 RID: 8389
		FramebufferAttachmentTextureLayerExt = 36052,
		// Token: 0x040020C6 RID: 8390
		FramebufferComplete,
		// Token: 0x040020C7 RID: 8391
		FramebufferCompleteExt = 36053,
		// Token: 0x040020C8 RID: 8392
		FramebufferIncompleteAttachment,
		// Token: 0x040020C9 RID: 8393
		FramebufferIncompleteAttachmentExt = 36054,
		// Token: 0x040020CA RID: 8394
		FramebufferIncompleteMissingAttachment,
		// Token: 0x040020CB RID: 8395
		FramebufferIncompleteMissingAttachmentExt = 36055,
		// Token: 0x040020CC RID: 8396
		FramebufferIncompleteDimensionsExt = 36057,
		// Token: 0x040020CD RID: 8397
		FramebufferIncompleteFormatsExt,
		// Token: 0x040020CE RID: 8398
		FramebufferIncompleteDrawBuffer,
		// Token: 0x040020CF RID: 8399
		FramebufferIncompleteDrawBufferExt = 36059,
		// Token: 0x040020D0 RID: 8400
		FramebufferIncompleteReadBuffer,
		// Token: 0x040020D1 RID: 8401
		FramebufferIncompleteReadBufferExt = 36060,
		// Token: 0x040020D2 RID: 8402
		FramebufferUnsupported,
		// Token: 0x040020D3 RID: 8403
		FramebufferUnsupportedExt = 36061,
		// Token: 0x040020D4 RID: 8404
		MaxColorAttachments = 36063,
		// Token: 0x040020D5 RID: 8405
		MaxColorAttachmentsExt = 36063,
		// Token: 0x040020D6 RID: 8406
		ColorAttachment0,
		// Token: 0x040020D7 RID: 8407
		ColorAttachment0Ext = 36064,
		// Token: 0x040020D8 RID: 8408
		ColorAttachment1,
		// Token: 0x040020D9 RID: 8409
		ColorAttachment1Ext = 36065,
		// Token: 0x040020DA RID: 8410
		ColorAttachment2,
		// Token: 0x040020DB RID: 8411
		ColorAttachment2Ext = 36066,
		// Token: 0x040020DC RID: 8412
		ColorAttachment3,
		// Token: 0x040020DD RID: 8413
		ColorAttachment3Ext = 36067,
		// Token: 0x040020DE RID: 8414
		ColorAttachment4,
		// Token: 0x040020DF RID: 8415
		ColorAttachment4Ext = 36068,
		// Token: 0x040020E0 RID: 8416
		ColorAttachment5,
		// Token: 0x040020E1 RID: 8417
		ColorAttachment5Ext = 36069,
		// Token: 0x040020E2 RID: 8418
		ColorAttachment6,
		// Token: 0x040020E3 RID: 8419
		ColorAttachment6Ext = 36070,
		// Token: 0x040020E4 RID: 8420
		ColorAttachment7,
		// Token: 0x040020E5 RID: 8421
		ColorAttachment7Ext = 36071,
		// Token: 0x040020E6 RID: 8422
		ColorAttachment8,
		// Token: 0x040020E7 RID: 8423
		ColorAttachment8Ext = 36072,
		// Token: 0x040020E8 RID: 8424
		ColorAttachment9,
		// Token: 0x040020E9 RID: 8425
		ColorAttachment9Ext = 36073,
		// Token: 0x040020EA RID: 8426
		ColorAttachment10,
		// Token: 0x040020EB RID: 8427
		ColorAttachment10Ext = 36074,
		// Token: 0x040020EC RID: 8428
		ColorAttachment11,
		// Token: 0x040020ED RID: 8429
		ColorAttachment11Ext = 36075,
		// Token: 0x040020EE RID: 8430
		ColorAttachment12,
		// Token: 0x040020EF RID: 8431
		ColorAttachment12Ext = 36076,
		// Token: 0x040020F0 RID: 8432
		ColorAttachment13,
		// Token: 0x040020F1 RID: 8433
		ColorAttachment13Ext = 36077,
		// Token: 0x040020F2 RID: 8434
		ColorAttachment14,
		// Token: 0x040020F3 RID: 8435
		ColorAttachment14Ext = 36078,
		// Token: 0x040020F4 RID: 8436
		ColorAttachment15,
		// Token: 0x040020F5 RID: 8437
		ColorAttachment15Ext = 36079,
		// Token: 0x040020F6 RID: 8438
		DepthAttachment = 36096,
		// Token: 0x040020F7 RID: 8439
		DepthAttachmentExt = 36096,
		// Token: 0x040020F8 RID: 8440
		StencilAttachment = 36128,
		// Token: 0x040020F9 RID: 8441
		StencilAttachmentExt = 36128,
		// Token: 0x040020FA RID: 8442
		Framebuffer = 36160,
		// Token: 0x040020FB RID: 8443
		FramebufferExt = 36160,
		// Token: 0x040020FC RID: 8444
		Renderbuffer,
		// Token: 0x040020FD RID: 8445
		RenderbufferExt = 36161,
		// Token: 0x040020FE RID: 8446
		RenderbufferWidth,
		// Token: 0x040020FF RID: 8447
		RenderbufferWidthExt = 36162,
		// Token: 0x04002100 RID: 8448
		RenderbufferHeight,
		// Token: 0x04002101 RID: 8449
		RenderbufferHeightExt = 36163,
		// Token: 0x04002102 RID: 8450
		RenderbufferInternalFormat,
		// Token: 0x04002103 RID: 8451
		RenderbufferInternalFormatExt = 36164,
		// Token: 0x04002104 RID: 8452
		StencilIndex1 = 36166,
		// Token: 0x04002105 RID: 8453
		StencilIndex1Ext = 36166,
		// Token: 0x04002106 RID: 8454
		StencilIndex4,
		// Token: 0x04002107 RID: 8455
		StencilIndex4Ext = 36167,
		// Token: 0x04002108 RID: 8456
		StencilIndex8,
		// Token: 0x04002109 RID: 8457
		StencilIndex8Ext = 36168,
		// Token: 0x0400210A RID: 8458
		StencilIndex16,
		// Token: 0x0400210B RID: 8459
		StencilIndex16Ext = 36169,
		// Token: 0x0400210C RID: 8460
		RenderbufferRedSize = 36176,
		// Token: 0x0400210D RID: 8461
		RenderbufferRedSizeExt = 36176,
		// Token: 0x0400210E RID: 8462
		RenderbufferGreenSize,
		// Token: 0x0400210F RID: 8463
		RenderbufferGreenSizeExt = 36177,
		// Token: 0x04002110 RID: 8464
		RenderbufferBlueSize,
		// Token: 0x04002111 RID: 8465
		RenderbufferBlueSizeExt = 36178,
		// Token: 0x04002112 RID: 8466
		RenderbufferAlphaSize,
		// Token: 0x04002113 RID: 8467
		RenderbufferAlphaSizeExt = 36179,
		// Token: 0x04002114 RID: 8468
		RenderbufferDepthSize,
		// Token: 0x04002115 RID: 8469
		RenderbufferDepthSizeExt = 36180,
		// Token: 0x04002116 RID: 8470
		RenderbufferStencilSize,
		// Token: 0x04002117 RID: 8471
		RenderbufferStencilSizeExt = 36181,
		// Token: 0x04002118 RID: 8472
		FramebufferIncompleteMultisample,
		// Token: 0x04002119 RID: 8473
		FramebufferIncompleteMultisampleExt = 36182,
		// Token: 0x0400211A RID: 8474
		MaxSamples,
		// Token: 0x0400211B RID: 8475
		MaxSamplesExt = 36183,
		// Token: 0x0400211C RID: 8476
		Rgb565 = 36194,
		// Token: 0x0400211D RID: 8477
		PrimitiveRestartFixedIndex = 36201,
		// Token: 0x0400211E RID: 8478
		AnySamplesPassedConservative,
		// Token: 0x0400211F RID: 8479
		MaxElementIndex,
		// Token: 0x04002120 RID: 8480
		Rgba32ui = 36208,
		// Token: 0x04002121 RID: 8481
		Rgba32uiExt = 36208,
		// Token: 0x04002122 RID: 8482
		Rgb32ui,
		// Token: 0x04002123 RID: 8483
		Rgb32uiExt = 36209,
		// Token: 0x04002124 RID: 8484
		Alpha32uiExt,
		// Token: 0x04002125 RID: 8485
		Intensity32uiExt,
		// Token: 0x04002126 RID: 8486
		Luminance32uiExt,
		// Token: 0x04002127 RID: 8487
		LuminanceAlpha32uiExt,
		// Token: 0x04002128 RID: 8488
		Rgba16ui,
		// Token: 0x04002129 RID: 8489
		Rgba16uiExt = 36214,
		// Token: 0x0400212A RID: 8490
		Rgb16ui,
		// Token: 0x0400212B RID: 8491
		Rgb16uiExt = 36215,
		// Token: 0x0400212C RID: 8492
		Alpha16uiExt,
		// Token: 0x0400212D RID: 8493
		Intensity16uiExt,
		// Token: 0x0400212E RID: 8494
		Luminance16uiExt,
		// Token: 0x0400212F RID: 8495
		LuminanceAlpha16uiExt,
		// Token: 0x04002130 RID: 8496
		Rgba8ui,
		// Token: 0x04002131 RID: 8497
		Rgba8uiExt = 36220,
		// Token: 0x04002132 RID: 8498
		Rgb8ui,
		// Token: 0x04002133 RID: 8499
		Rgb8uiExt = 36221,
		// Token: 0x04002134 RID: 8500
		Alpha8uiExt,
		// Token: 0x04002135 RID: 8501
		Intensity8uiExt,
		// Token: 0x04002136 RID: 8502
		Luminance8uiExt,
		// Token: 0x04002137 RID: 8503
		LuminanceAlpha8uiExt,
		// Token: 0x04002138 RID: 8504
		Rgba32i,
		// Token: 0x04002139 RID: 8505
		Rgba32iExt = 36226,
		// Token: 0x0400213A RID: 8506
		Rgb32i,
		// Token: 0x0400213B RID: 8507
		Rgb32iExt = 36227,
		// Token: 0x0400213C RID: 8508
		Alpha32iExt,
		// Token: 0x0400213D RID: 8509
		Intensity32iExt,
		// Token: 0x0400213E RID: 8510
		Luminance32iExt,
		// Token: 0x0400213F RID: 8511
		LuminanceAlpha32iExt,
		// Token: 0x04002140 RID: 8512
		Rgba16i,
		// Token: 0x04002141 RID: 8513
		Rgba16iExt = 36232,
		// Token: 0x04002142 RID: 8514
		Rgb16i,
		// Token: 0x04002143 RID: 8515
		Rgb16iExt = 36233,
		// Token: 0x04002144 RID: 8516
		Alpha16iExt,
		// Token: 0x04002145 RID: 8517
		Intensity16iExt,
		// Token: 0x04002146 RID: 8518
		Luminance16iExt,
		// Token: 0x04002147 RID: 8519
		LuminanceAlpha16iExt,
		// Token: 0x04002148 RID: 8520
		Rgba8i,
		// Token: 0x04002149 RID: 8521
		Rgba8iExt = 36238,
		// Token: 0x0400214A RID: 8522
		Rgb8i,
		// Token: 0x0400214B RID: 8523
		Rgb8iExt = 36239,
		// Token: 0x0400214C RID: 8524
		Alpha8iExt,
		// Token: 0x0400214D RID: 8525
		Intensity8iExt,
		// Token: 0x0400214E RID: 8526
		Luminance8iExt,
		// Token: 0x0400214F RID: 8527
		LuminanceAlpha8iExt,
		// Token: 0x04002150 RID: 8528
		RedInteger,
		// Token: 0x04002151 RID: 8529
		RedIntegerExt = 36244,
		// Token: 0x04002152 RID: 8530
		GreenInteger,
		// Token: 0x04002153 RID: 8531
		GreenIntegerExt = 36245,
		// Token: 0x04002154 RID: 8532
		BlueInteger,
		// Token: 0x04002155 RID: 8533
		BlueIntegerExt = 36246,
		// Token: 0x04002156 RID: 8534
		AlphaInteger,
		// Token: 0x04002157 RID: 8535
		AlphaIntegerExt = 36247,
		// Token: 0x04002158 RID: 8536
		RgbInteger,
		// Token: 0x04002159 RID: 8537
		RgbIntegerExt = 36248,
		// Token: 0x0400215A RID: 8538
		RgbaInteger,
		// Token: 0x0400215B RID: 8539
		RgbaIntegerExt = 36249,
		// Token: 0x0400215C RID: 8540
		BgrInteger,
		// Token: 0x0400215D RID: 8541
		BgrIntegerExt = 36250,
		// Token: 0x0400215E RID: 8542
		BgraInteger,
		// Token: 0x0400215F RID: 8543
		BgraIntegerExt = 36251,
		// Token: 0x04002160 RID: 8544
		LuminanceIntegerExt,
		// Token: 0x04002161 RID: 8545
		LuminanceAlphaIntegerExt,
		// Token: 0x04002162 RID: 8546
		RgbaIntegerModeExt,
		// Token: 0x04002163 RID: 8547
		Int2101010Rev,
		// Token: 0x04002164 RID: 8548
		MaxProgramParameterBufferBindingsNv,
		// Token: 0x04002165 RID: 8549
		MaxProgramParameterBufferSizeNv,
		// Token: 0x04002166 RID: 8550
		VertexProgramParameterBufferNv,
		// Token: 0x04002167 RID: 8551
		GeometryProgramParameterBufferNv,
		// Token: 0x04002168 RID: 8552
		FragmentProgramParameterBufferNv,
		// Token: 0x04002169 RID: 8553
		MaxProgramGenericAttribsNv,
		// Token: 0x0400216A RID: 8554
		MaxProgramGenericResultsNv,
		// Token: 0x0400216B RID: 8555
		FramebufferAttachmentLayered,
		// Token: 0x0400216C RID: 8556
		FramebufferAttachmentLayeredArb = 36263,
		// Token: 0x0400216D RID: 8557
		FramebufferAttachmentLayeredExt = 36263,
		// Token: 0x0400216E RID: 8558
		FramebufferIncompleteLayerTargets,
		// Token: 0x0400216F RID: 8559
		FramebufferIncompleteLayerTargetsArb = 36264,
		// Token: 0x04002170 RID: 8560
		FramebufferIncompleteLayerTargetsExt = 36264,
		// Token: 0x04002171 RID: 8561
		FramebufferIncompleteLayerCount,
		// Token: 0x04002172 RID: 8562
		FramebufferIncompleteLayerCountArb = 36265,
		// Token: 0x04002173 RID: 8563
		FramebufferIncompleteLayerCountExt = 36265,
		// Token: 0x04002174 RID: 8564
		LayerNv,
		// Token: 0x04002175 RID: 8565
		DepthComponent32fNv,
		// Token: 0x04002176 RID: 8566
		Depth32fStencil8Nv,
		// Token: 0x04002177 RID: 8567
		Float32UnsignedInt248Rev,
		// Token: 0x04002178 RID: 8568
		Float32UnsignedInt248RevNv = 36269,
		// Token: 0x04002179 RID: 8569
		ShaderIncludeArb,
		// Token: 0x0400217A RID: 8570
		DepthBufferFloatModeNv,
		// Token: 0x0400217B RID: 8571
		FramebufferSrgb = 36281,
		// Token: 0x0400217C RID: 8572
		FramebufferSrgbExt = 36281,
		// Token: 0x0400217D RID: 8573
		FramebufferSrgbCapableExt,
		// Token: 0x0400217E RID: 8574
		CompressedRedRgtc1,
		// Token: 0x0400217F RID: 8575
		CompressedRedRgtc1Ext = 36283,
		// Token: 0x04002180 RID: 8576
		CompressedSignedRedRgtc1,
		// Token: 0x04002181 RID: 8577
		CompressedSignedRedRgtc1Ext = 36284,
		// Token: 0x04002182 RID: 8578
		CompressedRedGreenRgtc2Ext,
		// Token: 0x04002183 RID: 8579
		CompressedRgRgtc2 = 36285,
		// Token: 0x04002184 RID: 8580
		CompressedSignedRedGreenRgtc2Ext,
		// Token: 0x04002185 RID: 8581
		CompressedSignedRgRgtc2 = 36286,
		// Token: 0x04002186 RID: 8582
		Sampler1DArray = 36288,
		// Token: 0x04002187 RID: 8583
		Sampler1DArrayExt = 36288,
		// Token: 0x04002188 RID: 8584
		Sampler2DArray,
		// Token: 0x04002189 RID: 8585
		Sampler2DArrayExt = 36289,
		// Token: 0x0400218A RID: 8586
		SamplerBuffer,
		// Token: 0x0400218B RID: 8587
		SamplerBufferExt = 36290,
		// Token: 0x0400218C RID: 8588
		Sampler1DArrayShadow,
		// Token: 0x0400218D RID: 8589
		Sampler1DArrayShadowExt = 36291,
		// Token: 0x0400218E RID: 8590
		Sampler2DArrayShadow,
		// Token: 0x0400218F RID: 8591
		Sampler2DArrayShadowExt = 36292,
		// Token: 0x04002190 RID: 8592
		SamplerCubeShadow,
		// Token: 0x04002191 RID: 8593
		SamplerCubeShadowExt = 36293,
		// Token: 0x04002192 RID: 8594
		UnsignedIntVec2,
		// Token: 0x04002193 RID: 8595
		UnsignedIntVec2Ext = 36294,
		// Token: 0x04002194 RID: 8596
		UnsignedIntVec3,
		// Token: 0x04002195 RID: 8597
		UnsignedIntVec3Ext = 36295,
		// Token: 0x04002196 RID: 8598
		UnsignedIntVec4,
		// Token: 0x04002197 RID: 8599
		UnsignedIntVec4Ext = 36296,
		// Token: 0x04002198 RID: 8600
		IntSampler1D,
		// Token: 0x04002199 RID: 8601
		IntSampler1DExt = 36297,
		// Token: 0x0400219A RID: 8602
		IntSampler2D,
		// Token: 0x0400219B RID: 8603
		IntSampler2DExt = 36298,
		// Token: 0x0400219C RID: 8604
		IntSampler3D,
		// Token: 0x0400219D RID: 8605
		IntSampler3DExt = 36299,
		// Token: 0x0400219E RID: 8606
		IntSamplerCube,
		// Token: 0x0400219F RID: 8607
		IntSamplerCubeExt = 36300,
		// Token: 0x040021A0 RID: 8608
		IntSampler2DRect,
		// Token: 0x040021A1 RID: 8609
		IntSampler2DRectExt = 36301,
		// Token: 0x040021A2 RID: 8610
		IntSampler1DArray,
		// Token: 0x040021A3 RID: 8611
		IntSampler1DArrayExt = 36302,
		// Token: 0x040021A4 RID: 8612
		IntSampler2DArray,
		// Token: 0x040021A5 RID: 8613
		IntSampler2DArrayExt = 36303,
		// Token: 0x040021A6 RID: 8614
		IntSamplerBuffer,
		// Token: 0x040021A7 RID: 8615
		IntSamplerBufferExt = 36304,
		// Token: 0x040021A8 RID: 8616
		UnsignedIntSampler1D,
		// Token: 0x040021A9 RID: 8617
		UnsignedIntSampler1DExt = 36305,
		// Token: 0x040021AA RID: 8618
		UnsignedIntSampler2D,
		// Token: 0x040021AB RID: 8619
		UnsignedIntSampler2DExt = 36306,
		// Token: 0x040021AC RID: 8620
		UnsignedIntSampler3D,
		// Token: 0x040021AD RID: 8621
		UnsignedIntSampler3DExt = 36307,
		// Token: 0x040021AE RID: 8622
		UnsignedIntSamplerCube,
		// Token: 0x040021AF RID: 8623
		UnsignedIntSamplerCubeExt = 36308,
		// Token: 0x040021B0 RID: 8624
		UnsignedIntSampler2DRect,
		// Token: 0x040021B1 RID: 8625
		UnsignedIntSampler2DRectExt = 36309,
		// Token: 0x040021B2 RID: 8626
		UnsignedIntSampler1DArray,
		// Token: 0x040021B3 RID: 8627
		UnsignedIntSampler1DArrayExt = 36310,
		// Token: 0x040021B4 RID: 8628
		UnsignedIntSampler2DArray,
		// Token: 0x040021B5 RID: 8629
		UnsignedIntSampler2DArrayExt = 36311,
		// Token: 0x040021B6 RID: 8630
		UnsignedIntSamplerBuffer,
		// Token: 0x040021B7 RID: 8631
		UnsignedIntSamplerBufferExt = 36312,
		// Token: 0x040021B8 RID: 8632
		GeometryShader,
		// Token: 0x040021B9 RID: 8633
		GeometryShaderArb = 36313,
		// Token: 0x040021BA RID: 8634
		GeometryShaderExt = 36313,
		// Token: 0x040021BB RID: 8635
		GeometryVerticesOutArb,
		// Token: 0x040021BC RID: 8636
		GeometryVerticesOutExt = 36314,
		// Token: 0x040021BD RID: 8637
		GeometryInputTypeArb,
		// Token: 0x040021BE RID: 8638
		GeometryInputTypeExt = 36315,
		// Token: 0x040021BF RID: 8639
		GeometryOutputTypeArb,
		// Token: 0x040021C0 RID: 8640
		GeometryOutputTypeExt = 36316,
		// Token: 0x040021C1 RID: 8641
		MaxGeometryVaryingComponents,
		// Token: 0x040021C2 RID: 8642
		MaxGeometryVaryingComponentsArb = 36317,
		// Token: 0x040021C3 RID: 8643
		MaxGeometryVaryingComponentsExt = 36317,
		// Token: 0x040021C4 RID: 8644
		MaxVertexVaryingComponents,
		// Token: 0x040021C5 RID: 8645
		MaxVertexVaryingComponentsArb = 36318,
		// Token: 0x040021C6 RID: 8646
		MaxVertexVaryingComponentsExt = 36318,
		// Token: 0x040021C7 RID: 8647
		MaxGeometryUniformComponents,
		// Token: 0x040021C8 RID: 8648
		MaxGeometryUniformComponentsArb = 36319,
		// Token: 0x040021C9 RID: 8649
		MaxGeometryUniformComponentsExt = 36319,
		// Token: 0x040021CA RID: 8650
		MaxGeometryOutputVertices,
		// Token: 0x040021CB RID: 8651
		MaxGeometryOutputVerticesArb = 36320,
		// Token: 0x040021CC RID: 8652
		MaxGeometryOutputVerticesExt = 36320,
		// Token: 0x040021CD RID: 8653
		MaxGeometryTotalOutputComponents,
		// Token: 0x040021CE RID: 8654
		MaxGeometryTotalOutputComponentsArb = 36321,
		// Token: 0x040021CF RID: 8655
		MaxGeometryTotalOutputComponentsExt = 36321,
		// Token: 0x040021D0 RID: 8656
		MaxVertexBindableUniformsExt,
		// Token: 0x040021D1 RID: 8657
		MaxFragmentBindableUniformsExt,
		// Token: 0x040021D2 RID: 8658
		MaxGeometryBindableUniformsExt,
		// Token: 0x040021D3 RID: 8659
		ActiveSubroutines,
		// Token: 0x040021D4 RID: 8660
		ActiveSubroutineUniforms,
		// Token: 0x040021D5 RID: 8661
		MaxSubroutines,
		// Token: 0x040021D6 RID: 8662
		MaxSubroutineUniformLocations,
		// Token: 0x040021D7 RID: 8663
		NamedStringLengthArb,
		// Token: 0x040021D8 RID: 8664
		NamedStringTypeArb,
		// Token: 0x040021D9 RID: 8665
		MaxBindableUniformSizeExt = 36333,
		// Token: 0x040021DA RID: 8666
		UniformBufferExt,
		// Token: 0x040021DB RID: 8667
		UniformBufferBindingExt,
		// Token: 0x040021DC RID: 8668
		LowFloat,
		// Token: 0x040021DD RID: 8669
		MediumFloat,
		// Token: 0x040021DE RID: 8670
		HighFloat,
		// Token: 0x040021DF RID: 8671
		LowInt,
		// Token: 0x040021E0 RID: 8672
		MediumInt,
		// Token: 0x040021E1 RID: 8673
		HighInt,
		// Token: 0x040021E2 RID: 8674
		ShaderBinaryFormats = 36344,
		// Token: 0x040021E3 RID: 8675
		NumShaderBinaryFormats,
		// Token: 0x040021E4 RID: 8676
		ShaderCompiler,
		// Token: 0x040021E5 RID: 8677
		MaxVertexUniformVectors,
		// Token: 0x040021E6 RID: 8678
		MaxVaryingVectors,
		// Token: 0x040021E7 RID: 8679
		MaxFragmentUniformVectors,
		// Token: 0x040021E8 RID: 8680
		RenderbufferColorSamplesNv = 36368,
		// Token: 0x040021E9 RID: 8681
		MaxMultisampleCoverageModesNv,
		// Token: 0x040021EA RID: 8682
		MultisampleCoverageModesNv,
		// Token: 0x040021EB RID: 8683
		QueryWait,
		// Token: 0x040021EC RID: 8684
		QueryWaitNv = 36371,
		// Token: 0x040021ED RID: 8685
		QueryNoWait,
		// Token: 0x040021EE RID: 8686
		QueryNoWaitNv = 36372,
		// Token: 0x040021EF RID: 8687
		QueryByRegionWait,
		// Token: 0x040021F0 RID: 8688
		QueryByRegionWaitNv = 36373,
		// Token: 0x040021F1 RID: 8689
		QueryByRegionNoWait,
		// Token: 0x040021F2 RID: 8690
		QueryByRegionNoWaitNv = 36374,
		// Token: 0x040021F3 RID: 8691
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x040021F4 RID: 8692
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x040021F5 RID: 8693
		ColorSamplesNv,
		// Token: 0x040021F6 RID: 8694
		TransformFeedback = 36386,
		// Token: 0x040021F7 RID: 8695
		TransformFeedbackNv = 36386,
		// Token: 0x040021F8 RID: 8696
		TransformFeedbackBufferPaused,
		// Token: 0x040021F9 RID: 8697
		TransformFeedbackBufferPausedNv = 36387,
		// Token: 0x040021FA RID: 8698
		TransformFeedbackPaused = 36387,
		// Token: 0x040021FB RID: 8699
		TransformFeedbackActive,
		// Token: 0x040021FC RID: 8700
		TransformFeedbackBufferActive = 36388,
		// Token: 0x040021FD RID: 8701
		TransformFeedbackBufferActiveNv = 36388,
		// Token: 0x040021FE RID: 8702
		TransformFeedbackBinding,
		// Token: 0x040021FF RID: 8703
		TransformFeedbackBindingNv = 36389,
		// Token: 0x04002200 RID: 8704
		FrameNv,
		// Token: 0x04002201 RID: 8705
		FieldsNv,
		// Token: 0x04002202 RID: 8706
		CurrentTimeNv,
		// Token: 0x04002203 RID: 8707
		Timestamp = 36392,
		// Token: 0x04002204 RID: 8708
		NumFillStreamsNv,
		// Token: 0x04002205 RID: 8709
		PresentTimeNv,
		// Token: 0x04002206 RID: 8710
		PresentDurationNv,
		// Token: 0x04002207 RID: 8711
		ProgramMatrixExt = 36397,
		// Token: 0x04002208 RID: 8712
		TransposeProgramMatrixExt,
		// Token: 0x04002209 RID: 8713
		ProgramMatrixStackDepthExt,
		// Token: 0x0400220A RID: 8714
		TextureSwizzleR = 36418,
		// Token: 0x0400220B RID: 8715
		TextureSwizzleRExt = 36418,
		// Token: 0x0400220C RID: 8716
		TextureSwizzleG,
		// Token: 0x0400220D RID: 8717
		TextureSwizzleGExt = 36419,
		// Token: 0x0400220E RID: 8718
		TextureSwizzleB,
		// Token: 0x0400220F RID: 8719
		TextureSwizzleBExt = 36420,
		// Token: 0x04002210 RID: 8720
		TextureSwizzleA,
		// Token: 0x04002211 RID: 8721
		TextureSwizzleAExt = 36421,
		// Token: 0x04002212 RID: 8722
		TextureSwizzleRgba,
		// Token: 0x04002213 RID: 8723
		TextureSwizzleRgbaExt = 36422,
		// Token: 0x04002214 RID: 8724
		ActiveSubroutineUniformLocations,
		// Token: 0x04002215 RID: 8725
		ActiveSubroutineMaxLength,
		// Token: 0x04002216 RID: 8726
		ActiveSubroutineUniformMaxLength,
		// Token: 0x04002217 RID: 8727
		NumCompatibleSubroutines,
		// Token: 0x04002218 RID: 8728
		CompatibleSubroutines,
		// Token: 0x04002219 RID: 8729
		QuadsFollowProvokingVertexConvention,
		// Token: 0x0400221A RID: 8730
		QuadsFollowProvokingVertexConventionExt = 36428,
		// Token: 0x0400221B RID: 8731
		FirstVertexConvention,
		// Token: 0x0400221C RID: 8732
		FirstVertexConventionExt = 36429,
		// Token: 0x0400221D RID: 8733
		LastVertexConvention,
		// Token: 0x0400221E RID: 8734
		LastVertexConventionExt = 36430,
		// Token: 0x0400221F RID: 8735
		ProvokingVertex,
		// Token: 0x04002220 RID: 8736
		ProvokingVertexExt = 36431,
		// Token: 0x04002221 RID: 8737
		SamplePosition,
		// Token: 0x04002222 RID: 8738
		SamplePositionNv = 36432,
		// Token: 0x04002223 RID: 8739
		SampleMask,
		// Token: 0x04002224 RID: 8740
		SampleMaskNv = 36433,
		// Token: 0x04002225 RID: 8741
		SampleMaskValue,
		// Token: 0x04002226 RID: 8742
		SampleMaskValueNv = 36434,
		// Token: 0x04002227 RID: 8743
		TextureBindingRenderbufferNv,
		// Token: 0x04002228 RID: 8744
		TextureRenderbufferDataStoreBindingNv,
		// Token: 0x04002229 RID: 8745
		TextureRenderbufferNv,
		// Token: 0x0400222A RID: 8746
		SamplerRenderbufferNv,
		// Token: 0x0400222B RID: 8747
		IntSamplerRenderbufferNv,
		// Token: 0x0400222C RID: 8748
		UnsignedIntSamplerRenderbufferNv,
		// Token: 0x0400222D RID: 8749
		MaxSampleMaskWords,
		// Token: 0x0400222E RID: 8750
		MaxSampleMaskWordsNv = 36441,
		// Token: 0x0400222F RID: 8751
		MaxGeometryProgramInvocationsNv,
		// Token: 0x04002230 RID: 8752
		MaxGeometryShaderInvocations = 36442,
		// Token: 0x04002231 RID: 8753
		MinFragmentInterpolationOffset,
		// Token: 0x04002232 RID: 8754
		MinFragmentInterpolationOffsetNv = 36443,
		// Token: 0x04002233 RID: 8755
		MaxFragmentInterpolationOffset,
		// Token: 0x04002234 RID: 8756
		MaxFragmentInterpolationOffsetNv = 36444,
		// Token: 0x04002235 RID: 8757
		FragmentInterpolationOffsetBits,
		// Token: 0x04002236 RID: 8758
		FragmentProgramInterpolationOffsetBitsNv = 36445,
		// Token: 0x04002237 RID: 8759
		MinProgramTextureGatherOffset,
		// Token: 0x04002238 RID: 8760
		MinProgramTextureGatherOffsetArb = 36446,
		// Token: 0x04002239 RID: 8761
		MinProgramTextureGatherOffsetNv = 36446,
		// Token: 0x0400223A RID: 8762
		MaxProgramTextureGatherOffset,
		// Token: 0x0400223B RID: 8763
		MaxProgramTextureGatherOffsetArb = 36447,
		// Token: 0x0400223C RID: 8764
		MaxProgramTextureGatherOffsetNv = 36447,
		// Token: 0x0400223D RID: 8765
		MaxTransformFeedbackBuffers = 36464,
		// Token: 0x0400223E RID: 8766
		MaxVertexStreams,
		// Token: 0x0400223F RID: 8767
		PatchVertices,
		// Token: 0x04002240 RID: 8768
		PatchDefaultInnerLevel,
		// Token: 0x04002241 RID: 8769
		PatchDefaultOuterLevel,
		// Token: 0x04002242 RID: 8770
		TessControlOutputVertices,
		// Token: 0x04002243 RID: 8771
		TessGenMode,
		// Token: 0x04002244 RID: 8772
		TessGenSpacing,
		// Token: 0x04002245 RID: 8773
		TessGenVertexOrder,
		// Token: 0x04002246 RID: 8774
		TessGenPointMode,
		// Token: 0x04002247 RID: 8775
		Isolines,
		// Token: 0x04002248 RID: 8776
		FractionalOdd,
		// Token: 0x04002249 RID: 8777
		FractionalEven,
		// Token: 0x0400224A RID: 8778
		MaxPatchVertices,
		// Token: 0x0400224B RID: 8779
		MaxTessGenLevel,
		// Token: 0x0400224C RID: 8780
		MaxTessControlUniformComponents,
		// Token: 0x0400224D RID: 8781
		MaxTessEvaluationUniformComponents,
		// Token: 0x0400224E RID: 8782
		MaxTessControlTextureImageUnits,
		// Token: 0x0400224F RID: 8783
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x04002250 RID: 8784
		MaxTessControlOutputComponents,
		// Token: 0x04002251 RID: 8785
		MaxTessPatchComponents,
		// Token: 0x04002252 RID: 8786
		MaxTessControlTotalOutputComponents,
		// Token: 0x04002253 RID: 8787
		MaxTessEvaluationOutputComponents,
		// Token: 0x04002254 RID: 8788
		TessEvaluationShader,
		// Token: 0x04002255 RID: 8789
		TessControlShader,
		// Token: 0x04002256 RID: 8790
		MaxTessControlUniformBlocks,
		// Token: 0x04002257 RID: 8791
		MaxTessEvaluationUniformBlocks,
		// Token: 0x04002258 RID: 8792
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x04002259 RID: 8793
		CompressedRgbaBptcUnormArb = 36492,
		// Token: 0x0400225A RID: 8794
		CompressedSrgbAlphaBptcUnorm,
		// Token: 0x0400225B RID: 8795
		CompressedSrgbAlphaBptcUnormArb = 36493,
		// Token: 0x0400225C RID: 8796
		CompressedRgbBptcSignedFloat,
		// Token: 0x0400225D RID: 8797
		CompressedRgbBptcSignedFloatArb = 36494,
		// Token: 0x0400225E RID: 8798
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x0400225F RID: 8799
		CompressedRgbBptcUnsignedFloatArb = 36495,
		// Token: 0x04002260 RID: 8800
		BufferGpuAddressNv = 36637,
		// Token: 0x04002261 RID: 8801
		VertexAttribArrayUnifiedNv,
		// Token: 0x04002262 RID: 8802
		ElementArrayUnifiedNv,
		// Token: 0x04002263 RID: 8803
		VertexAttribArrayAddressNv,
		// Token: 0x04002264 RID: 8804
		VertexArrayAddressNv,
		// Token: 0x04002265 RID: 8805
		NormalArrayAddressNv,
		// Token: 0x04002266 RID: 8806
		ColorArrayAddressNv,
		// Token: 0x04002267 RID: 8807
		IndexArrayAddressNv,
		// Token: 0x04002268 RID: 8808
		TextureCoordArrayAddressNv,
		// Token: 0x04002269 RID: 8809
		EdgeFlagArrayAddressNv,
		// Token: 0x0400226A RID: 8810
		SecondaryColorArrayAddressNv,
		// Token: 0x0400226B RID: 8811
		FogCoordArrayAddressNv,
		// Token: 0x0400226C RID: 8812
		ElementArrayAddressNv,
		// Token: 0x0400226D RID: 8813
		VertexAttribArrayLengthNv,
		// Token: 0x0400226E RID: 8814
		VertexArrayLengthNv,
		// Token: 0x0400226F RID: 8815
		NormalArrayLengthNv,
		// Token: 0x04002270 RID: 8816
		ColorArrayLengthNv,
		// Token: 0x04002271 RID: 8817
		IndexArrayLengthNv,
		// Token: 0x04002272 RID: 8818
		TextureCoordArrayLengthNv,
		// Token: 0x04002273 RID: 8819
		EdgeFlagArrayLengthNv,
		// Token: 0x04002274 RID: 8820
		SecondaryColorArrayLengthNv,
		// Token: 0x04002275 RID: 8821
		FogCoordArrayLengthNv,
		// Token: 0x04002276 RID: 8822
		ElementArrayLengthNv,
		// Token: 0x04002277 RID: 8823
		GpuAddressNv,
		// Token: 0x04002278 RID: 8824
		MaxShaderBufferAddressNv,
		// Token: 0x04002279 RID: 8825
		CopyReadBuffer,
		// Token: 0x0400227A RID: 8826
		CopyReadBufferBinding = 36662,
		// Token: 0x0400227B RID: 8827
		CopyWriteBuffer,
		// Token: 0x0400227C RID: 8828
		CopyWriteBufferBinding = 36663,
		// Token: 0x0400227D RID: 8829
		MaxImageUnits,
		// Token: 0x0400227E RID: 8830
		MaxImageUnitsExt = 36664,
		// Token: 0x0400227F RID: 8831
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x04002280 RID: 8832
		MaxCombinedImageUnitsAndFragmentOutputsExt = 36665,
		// Token: 0x04002281 RID: 8833
		MaxCombinedShaderOutputResources = 36665,
		// Token: 0x04002282 RID: 8834
		ImageBindingName,
		// Token: 0x04002283 RID: 8835
		ImageBindingNameExt = 36666,
		// Token: 0x04002284 RID: 8836
		ImageBindingLevel,
		// Token: 0x04002285 RID: 8837
		ImageBindingLevelExt = 36667,
		// Token: 0x04002286 RID: 8838
		ImageBindingLayered,
		// Token: 0x04002287 RID: 8839
		ImageBindingLayeredExt = 36668,
		// Token: 0x04002288 RID: 8840
		ImageBindingLayer,
		// Token: 0x04002289 RID: 8841
		ImageBindingLayerExt = 36669,
		// Token: 0x0400228A RID: 8842
		ImageBindingAccess,
		// Token: 0x0400228B RID: 8843
		ImageBindingAccessExt = 36670,
		// Token: 0x0400228C RID: 8844
		DrawIndirectBuffer,
		// Token: 0x0400228D RID: 8845
		DrawIndirectUnifiedNv,
		// Token: 0x0400228E RID: 8846
		DrawIndirectAddressNv,
		// Token: 0x0400228F RID: 8847
		DrawIndirectLengthNv,
		// Token: 0x04002290 RID: 8848
		DrawIndirectBufferBinding,
		// Token: 0x04002291 RID: 8849
		MaxProgramSubroutineParametersNv,
		// Token: 0x04002292 RID: 8850
		MaxProgramSubroutineNumNv,
		// Token: 0x04002293 RID: 8851
		DoubleMat2,
		// Token: 0x04002294 RID: 8852
		DoubleMat2Ext = 36678,
		// Token: 0x04002295 RID: 8853
		DoubleMat3,
		// Token: 0x04002296 RID: 8854
		DoubleMat3Ext = 36679,
		// Token: 0x04002297 RID: 8855
		DoubleMat4,
		// Token: 0x04002298 RID: 8856
		DoubleMat4Ext = 36680,
		// Token: 0x04002299 RID: 8857
		DoubleMat2x3,
		// Token: 0x0400229A RID: 8858
		DoubleMat2x3Ext = 36681,
		// Token: 0x0400229B RID: 8859
		DoubleMat2x4,
		// Token: 0x0400229C RID: 8860
		DoubleMat2x4Ext = 36682,
		// Token: 0x0400229D RID: 8861
		DoubleMat3x2,
		// Token: 0x0400229E RID: 8862
		DoubleMat3x2Ext = 36683,
		// Token: 0x0400229F RID: 8863
		DoubleMat3x4,
		// Token: 0x040022A0 RID: 8864
		DoubleMat3x4Ext = 36684,
		// Token: 0x040022A1 RID: 8865
		DoubleMat4x2,
		// Token: 0x040022A2 RID: 8866
		DoubleMat4x2Ext = 36685,
		// Token: 0x040022A3 RID: 8867
		DoubleMat4x3,
		// Token: 0x040022A4 RID: 8868
		DoubleMat4x3Ext = 36686,
		// Token: 0x040022A5 RID: 8869
		VertexBindingBuffer,
		// Token: 0x040022A6 RID: 8870
		RedSnorm = 36752,
		// Token: 0x040022A7 RID: 8871
		RgSnorm,
		// Token: 0x040022A8 RID: 8872
		RgbSnorm,
		// Token: 0x040022A9 RID: 8873
		RgbaSnorm,
		// Token: 0x040022AA RID: 8874
		R8Snorm,
		// Token: 0x040022AB RID: 8875
		Rg8Snorm,
		// Token: 0x040022AC RID: 8876
		Rgb8Snorm,
		// Token: 0x040022AD RID: 8877
		Rgba8Snorm,
		// Token: 0x040022AE RID: 8878
		R16Snorm,
		// Token: 0x040022AF RID: 8879
		Rg16Snorm,
		// Token: 0x040022B0 RID: 8880
		Rgb16Snorm,
		// Token: 0x040022B1 RID: 8881
		Rgba16Snorm,
		// Token: 0x040022B2 RID: 8882
		SignedNormalized,
		// Token: 0x040022B3 RID: 8883
		PrimitiveRestart,
		// Token: 0x040022B4 RID: 8884
		PrimitiveRestartIndex,
		// Token: 0x040022B5 RID: 8885
		MaxProgramTextureGatherComponentsArb,
		// Token: 0x040022B6 RID: 8886
		BinningControlHintQcom = 36784,
		// Token: 0x040022B7 RID: 8887
		Int8Nv = 36832,
		// Token: 0x040022B8 RID: 8888
		Int8Vec2Nv,
		// Token: 0x040022B9 RID: 8889
		Int8Vec3Nv,
		// Token: 0x040022BA RID: 8890
		Int8Vec4Nv,
		// Token: 0x040022BB RID: 8891
		Int16Nv,
		// Token: 0x040022BC RID: 8892
		Int16Vec2Nv,
		// Token: 0x040022BD RID: 8893
		Int16Vec3Nv,
		// Token: 0x040022BE RID: 8894
		Int16Vec4Nv,
		// Token: 0x040022BF RID: 8895
		Int64Vec2Nv = 36841,
		// Token: 0x040022C0 RID: 8896
		Int64Vec3Nv,
		// Token: 0x040022C1 RID: 8897
		Int64Vec4Nv,
		// Token: 0x040022C2 RID: 8898
		UnsignedInt8Nv,
		// Token: 0x040022C3 RID: 8899
		UnsignedInt8Vec2Nv,
		// Token: 0x040022C4 RID: 8900
		UnsignedInt8Vec3Nv,
		// Token: 0x040022C5 RID: 8901
		UnsignedInt8Vec4Nv,
		// Token: 0x040022C6 RID: 8902
		UnsignedInt16Nv,
		// Token: 0x040022C7 RID: 8903
		UnsignedInt16Vec2Nv,
		// Token: 0x040022C8 RID: 8904
		UnsignedInt16Vec3Nv,
		// Token: 0x040022C9 RID: 8905
		UnsignedInt16Vec4Nv,
		// Token: 0x040022CA RID: 8906
		UnsignedInt64Vec2Nv = 36853,
		// Token: 0x040022CB RID: 8907
		UnsignedInt64Vec3Nv,
		// Token: 0x040022CC RID: 8908
		UnsignedInt64Vec4Nv,
		// Token: 0x040022CD RID: 8909
		Float16Nv,
		// Token: 0x040022CE RID: 8910
		Float16Vec2Nv,
		// Token: 0x040022CF RID: 8911
		Float16Vec3Nv,
		// Token: 0x040022D0 RID: 8912
		Float16Vec4Nv,
		// Token: 0x040022D1 RID: 8913
		DoubleVec2,
		// Token: 0x040022D2 RID: 8914
		DoubleVec2Ext = 36860,
		// Token: 0x040022D3 RID: 8915
		DoubleVec3,
		// Token: 0x040022D4 RID: 8916
		DoubleVec3Ext = 36861,
		// Token: 0x040022D5 RID: 8917
		DoubleVec4,
		// Token: 0x040022D6 RID: 8918
		DoubleVec4Ext = 36862,
		// Token: 0x040022D7 RID: 8919
		SamplerBufferAmd = 36865,
		// Token: 0x040022D8 RID: 8920
		IntSamplerBufferAmd,
		// Token: 0x040022D9 RID: 8921
		UnsignedIntSamplerBufferAmd,
		// Token: 0x040022DA RID: 8922
		TessellationModeAmd,
		// Token: 0x040022DB RID: 8923
		TessellationFactorAmd,
		// Token: 0x040022DC RID: 8924
		DiscreteAmd,
		// Token: 0x040022DD RID: 8925
		ContinuousAmd,
		// Token: 0x040022DE RID: 8926
		TextureCubeMapArray = 36873,
		// Token: 0x040022DF RID: 8927
		TextureCubeMapArrayArb = 36873,
		// Token: 0x040022E0 RID: 8928
		TextureBindingCubeMapArray,
		// Token: 0x040022E1 RID: 8929
		TextureBindingCubeMapArrayArb = 36874,
		// Token: 0x040022E2 RID: 8930
		ProxyTextureCubeMapArray,
		// Token: 0x040022E3 RID: 8931
		ProxyTextureCubeMapArrayArb = 36875,
		// Token: 0x040022E4 RID: 8932
		SamplerCubeMapArray,
		// Token: 0x040022E5 RID: 8933
		SamplerCubeMapArrayArb = 36876,
		// Token: 0x040022E6 RID: 8934
		SamplerCubeMapArrayShadow,
		// Token: 0x040022E7 RID: 8935
		SamplerCubeMapArrayShadowArb = 36877,
		// Token: 0x040022E8 RID: 8936
		IntSamplerCubeMapArray,
		// Token: 0x040022E9 RID: 8937
		IntSamplerCubeMapArrayArb = 36878,
		// Token: 0x040022EA RID: 8938
		UnsignedIntSamplerCubeMapArray,
		// Token: 0x040022EB RID: 8939
		UnsignedIntSamplerCubeMapArrayArb = 36879,
		// Token: 0x040022EC RID: 8940
		AlphaSnorm,
		// Token: 0x040022ED RID: 8941
		LuminanceSnorm,
		// Token: 0x040022EE RID: 8942
		LuminanceAlphaSnorm,
		// Token: 0x040022EF RID: 8943
		IntensitySnorm,
		// Token: 0x040022F0 RID: 8944
		Alpha8Snorm,
		// Token: 0x040022F1 RID: 8945
		Luminance8Snorm,
		// Token: 0x040022F2 RID: 8946
		Luminance8Alpha8Snorm,
		// Token: 0x040022F3 RID: 8947
		Intensity8Snorm,
		// Token: 0x040022F4 RID: 8948
		Alpha16Snorm,
		// Token: 0x040022F5 RID: 8949
		Luminance16Snorm,
		// Token: 0x040022F6 RID: 8950
		Luminance16Alpha16Snorm,
		// Token: 0x040022F7 RID: 8951
		Intensity16Snorm,
		// Token: 0x040022F8 RID: 8952
		FactorMinAmd,
		// Token: 0x040022F9 RID: 8953
		FactorMaxAmd,
		// Token: 0x040022FA RID: 8954
		DepthClampNearAmd,
		// Token: 0x040022FB RID: 8955
		DepthClampFarAmd,
		// Token: 0x040022FC RID: 8956
		VideoBufferNv,
		// Token: 0x040022FD RID: 8957
		VideoBufferBindingNv,
		// Token: 0x040022FE RID: 8958
		FieldUpperNv,
		// Token: 0x040022FF RID: 8959
		FieldLowerNv,
		// Token: 0x04002300 RID: 8960
		NumVideoCaptureStreamsNv,
		// Token: 0x04002301 RID: 8961
		NextVideoCaptureBufferStatusNv,
		// Token: 0x04002302 RID: 8962
		VideoCaptureTo422SupportedNv,
		// Token: 0x04002303 RID: 8963
		LastVideoCaptureStatusNv,
		// Token: 0x04002304 RID: 8964
		VideoBufferPitchNv,
		// Token: 0x04002305 RID: 8965
		VideoColorConversionMatrixNv,
		// Token: 0x04002306 RID: 8966
		VideoColorConversionMaxNv,
		// Token: 0x04002307 RID: 8967
		VideoColorConversionMinNv,
		// Token: 0x04002308 RID: 8968
		VideoColorConversionOffsetNv,
		// Token: 0x04002309 RID: 8969
		VideoBufferInternalFormatNv,
		// Token: 0x0400230A RID: 8970
		PartialSuccessNv,
		// Token: 0x0400230B RID: 8971
		SuccessNv,
		// Token: 0x0400230C RID: 8972
		FailureNv,
		// Token: 0x0400230D RID: 8973
		Ycbycr8422Nv,
		// Token: 0x0400230E RID: 8974
		Ycbaycr8A4224Nv,
		// Token: 0x0400230F RID: 8975
		Z6y10z6cb10z6y10z6cr10422Nv,
		// Token: 0x04002310 RID: 8976
		Z6y10z6cb10z6A10z6y10z6cr10z6A104224Nv,
		// Token: 0x04002311 RID: 8977
		Z4y12z4cb12z4y12z4cr12422Nv,
		// Token: 0x04002312 RID: 8978
		Z4y12z4cb12z4A12z4y12z4cr12z4A124224Nv,
		// Token: 0x04002313 RID: 8979
		Z4y12z4cb12z4cr12444Nv,
		// Token: 0x04002314 RID: 8980
		VideoCaptureFrameWidthNv,
		// Token: 0x04002315 RID: 8981
		VideoCaptureFrameHeightNv,
		// Token: 0x04002316 RID: 8982
		VideoCaptureFieldUpperHeightNv,
		// Token: 0x04002317 RID: 8983
		VideoCaptureFieldLowerHeightNv,
		// Token: 0x04002318 RID: 8984
		VideoCaptureSurfaceOriginNv,
		// Token: 0x04002319 RID: 8985
		TextureCoverageSamplesNv = 36933,
		// Token: 0x0400231A RID: 8986
		TextureColorSamplesNv,
		// Token: 0x0400231B RID: 8987
		GpuMemoryInfoDedicatedVidmemNvx,
		// Token: 0x0400231C RID: 8988
		GpuMemoryInfoTotalAvailableMemoryNvx,
		// Token: 0x0400231D RID: 8989
		GpuMemoryInfoCurrentAvailableVidmemNvx,
		// Token: 0x0400231E RID: 8990
		GpuMemoryInfoEvictionCountNvx,
		// Token: 0x0400231F RID: 8991
		GpuMemoryInfoEvictedMemoryNvx,
		// Token: 0x04002320 RID: 8992
		Image1D,
		// Token: 0x04002321 RID: 8993
		Image1DExt = 36940,
		// Token: 0x04002322 RID: 8994
		Image2D,
		// Token: 0x04002323 RID: 8995
		Image2DExt = 36941,
		// Token: 0x04002324 RID: 8996
		Image3D,
		// Token: 0x04002325 RID: 8997
		Image3DExt = 36942,
		// Token: 0x04002326 RID: 8998
		Image2DRect,
		// Token: 0x04002327 RID: 8999
		Image2DRectExt = 36943,
		// Token: 0x04002328 RID: 9000
		ImageCube,
		// Token: 0x04002329 RID: 9001
		ImageCubeExt = 36944,
		// Token: 0x0400232A RID: 9002
		ImageBuffer,
		// Token: 0x0400232B RID: 9003
		ImageBufferExt = 36945,
		// Token: 0x0400232C RID: 9004
		Image1DArray,
		// Token: 0x0400232D RID: 9005
		Image1DArrayExt = 36946,
		// Token: 0x0400232E RID: 9006
		Image2DArray,
		// Token: 0x0400232F RID: 9007
		Image2DArrayExt = 36947,
		// Token: 0x04002330 RID: 9008
		ImageCubeMapArray,
		// Token: 0x04002331 RID: 9009
		ImageCubeMapArrayExt = 36948,
		// Token: 0x04002332 RID: 9010
		Image2DMultisample,
		// Token: 0x04002333 RID: 9011
		Image2DMultisampleExt = 36949,
		// Token: 0x04002334 RID: 9012
		Image2DMultisampleArray,
		// Token: 0x04002335 RID: 9013
		Image2DMultisampleArrayExt = 36950,
		// Token: 0x04002336 RID: 9014
		IntImage1D,
		// Token: 0x04002337 RID: 9015
		IntImage1DExt = 36951,
		// Token: 0x04002338 RID: 9016
		IntImage2D,
		// Token: 0x04002339 RID: 9017
		IntImage2DExt = 36952,
		// Token: 0x0400233A RID: 9018
		IntImage3D,
		// Token: 0x0400233B RID: 9019
		IntImage3DExt = 36953,
		// Token: 0x0400233C RID: 9020
		IntImage2DRect,
		// Token: 0x0400233D RID: 9021
		IntImage2DRectExt = 36954,
		// Token: 0x0400233E RID: 9022
		IntImageCube,
		// Token: 0x0400233F RID: 9023
		IntImageCubeExt = 36955,
		// Token: 0x04002340 RID: 9024
		IntImageBuffer,
		// Token: 0x04002341 RID: 9025
		IntImageBufferExt = 36956,
		// Token: 0x04002342 RID: 9026
		IntImage1DArray,
		// Token: 0x04002343 RID: 9027
		IntImage1DArrayExt = 36957,
		// Token: 0x04002344 RID: 9028
		IntImage2DArray,
		// Token: 0x04002345 RID: 9029
		IntImage2DArrayExt = 36958,
		// Token: 0x04002346 RID: 9030
		IntImageCubeMapArray,
		// Token: 0x04002347 RID: 9031
		IntImageCubeMapArrayExt = 36959,
		// Token: 0x04002348 RID: 9032
		IntImage2DMultisample,
		// Token: 0x04002349 RID: 9033
		IntImage2DMultisampleExt = 36960,
		// Token: 0x0400234A RID: 9034
		IntImage2DMultisampleArray,
		// Token: 0x0400234B RID: 9035
		IntImage2DMultisampleArrayExt = 36961,
		// Token: 0x0400234C RID: 9036
		UnsignedIntImage1D,
		// Token: 0x0400234D RID: 9037
		UnsignedIntImage1DExt = 36962,
		// Token: 0x0400234E RID: 9038
		UnsignedIntImage2D,
		// Token: 0x0400234F RID: 9039
		UnsignedIntImage2DExt = 36963,
		// Token: 0x04002350 RID: 9040
		UnsignedIntImage3D,
		// Token: 0x04002351 RID: 9041
		UnsignedIntImage3DExt = 36964,
		// Token: 0x04002352 RID: 9042
		UnsignedIntImage2DRect,
		// Token: 0x04002353 RID: 9043
		UnsignedIntImage2DRectExt = 36965,
		// Token: 0x04002354 RID: 9044
		UnsignedIntImageCube,
		// Token: 0x04002355 RID: 9045
		UnsignedIntImageCubeExt = 36966,
		// Token: 0x04002356 RID: 9046
		UnsignedIntImageBuffer,
		// Token: 0x04002357 RID: 9047
		UnsignedIntImageBufferExt = 36967,
		// Token: 0x04002358 RID: 9048
		UnsignedIntImage1DArray,
		// Token: 0x04002359 RID: 9049
		UnsignedIntImage1DArrayExt = 36968,
		// Token: 0x0400235A RID: 9050
		UnsignedIntImage2DArray,
		// Token: 0x0400235B RID: 9051
		UnsignedIntImage2DArrayExt = 36969,
		// Token: 0x0400235C RID: 9052
		UnsignedIntImageCubeMapArray,
		// Token: 0x0400235D RID: 9053
		UnsignedIntImageCubeMapArrayExt = 36970,
		// Token: 0x0400235E RID: 9054
		UnsignedIntImage2DMultisample,
		// Token: 0x0400235F RID: 9055
		UnsignedIntImage2DMultisampleExt = 36971,
		// Token: 0x04002360 RID: 9056
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x04002361 RID: 9057
		UnsignedIntImage2DMultisampleArrayExt = 36972,
		// Token: 0x04002362 RID: 9058
		MaxImageSamples,
		// Token: 0x04002363 RID: 9059
		MaxImageSamplesExt = 36973,
		// Token: 0x04002364 RID: 9060
		ImageBindingFormat,
		// Token: 0x04002365 RID: 9061
		ImageBindingFormatExt = 36974,
		// Token: 0x04002366 RID: 9062
		Rgb10A2ui,
		// Token: 0x04002367 RID: 9063
		PathFormatSvgNv,
		// Token: 0x04002368 RID: 9064
		PathFormatPsNv,
		// Token: 0x04002369 RID: 9065
		StandardFontNameNv,
		// Token: 0x0400236A RID: 9066
		SystemFontNameNv,
		// Token: 0x0400236B RID: 9067
		FileNameNv,
		// Token: 0x0400236C RID: 9068
		PathStrokeWidthNv,
		// Token: 0x0400236D RID: 9069
		PathEndCapsNv,
		// Token: 0x0400236E RID: 9070
		PathInitialEndCapNv,
		// Token: 0x0400236F RID: 9071
		PathTerminalEndCapNv,
		// Token: 0x04002370 RID: 9072
		PathJoinStyleNv,
		// Token: 0x04002371 RID: 9073
		PathMiterLimitNv,
		// Token: 0x04002372 RID: 9074
		PathDashCapsNv,
		// Token: 0x04002373 RID: 9075
		PathInitialDashCapNv,
		// Token: 0x04002374 RID: 9076
		PathTerminalDashCapNv,
		// Token: 0x04002375 RID: 9077
		PathDashOffsetNv,
		// Token: 0x04002376 RID: 9078
		PathClientLengthNv,
		// Token: 0x04002377 RID: 9079
		PathFillModeNv,
		// Token: 0x04002378 RID: 9080
		PathFillMaskNv,
		// Token: 0x04002379 RID: 9081
		PathFillCoverModeNv,
		// Token: 0x0400237A RID: 9082
		PathStrokeCoverModeNv,
		// Token: 0x0400237B RID: 9083
		PathStrokeMaskNv,
		// Token: 0x0400237C RID: 9084
		CountUpNv = 37000,
		// Token: 0x0400237D RID: 9085
		CountDownNv,
		// Token: 0x0400237E RID: 9086
		PathObjectBoundingBoxNv,
		// Token: 0x0400237F RID: 9087
		ConvexHullNv,
		// Token: 0x04002380 RID: 9088
		BoundingBoxNv = 37005,
		// Token: 0x04002381 RID: 9089
		TranslateXNv,
		// Token: 0x04002382 RID: 9090
		TranslateYNv,
		// Token: 0x04002383 RID: 9091
		Translate2DNv,
		// Token: 0x04002384 RID: 9092
		Translate3DNv,
		// Token: 0x04002385 RID: 9093
		Affine2DNv,
		// Token: 0x04002386 RID: 9094
		Affine3DNv = 37012,
		// Token: 0x04002387 RID: 9095
		TransposeAffine2DNv = 37014,
		// Token: 0x04002388 RID: 9096
		TransposeAffine3DNv = 37016,
		// Token: 0x04002389 RID: 9097
		Utf8Nv = 37018,
		// Token: 0x0400238A RID: 9098
		Utf16Nv,
		// Token: 0x0400238B RID: 9099
		BoundingBoxOfBoundingBoxesNv,
		// Token: 0x0400238C RID: 9100
		PathCommandCountNv,
		// Token: 0x0400238D RID: 9101
		PathCoordCountNv,
		// Token: 0x0400238E RID: 9102
		PathDashArrayCountNv,
		// Token: 0x0400238F RID: 9103
		PathComputedLengthNv,
		// Token: 0x04002390 RID: 9104
		PathFillBoundingBoxNv,
		// Token: 0x04002391 RID: 9105
		PathStrokeBoundingBoxNv,
		// Token: 0x04002392 RID: 9106
		SquareNv,
		// Token: 0x04002393 RID: 9107
		RoundNv,
		// Token: 0x04002394 RID: 9108
		TriangularNv,
		// Token: 0x04002395 RID: 9109
		BevelNv,
		// Token: 0x04002396 RID: 9110
		MiterRevertNv,
		// Token: 0x04002397 RID: 9111
		MiterTruncateNv,
		// Token: 0x04002398 RID: 9112
		SkipMissingGlyphNv,
		// Token: 0x04002399 RID: 9113
		UseMissingGlyphNv,
		// Token: 0x0400239A RID: 9114
		PathErrorPositionNv,
		// Token: 0x0400239B RID: 9115
		PathFogGenModeNv,
		// Token: 0x0400239C RID: 9116
		AccumAdjacentPairsNv,
		// Token: 0x0400239D RID: 9117
		AdjacentPairsNv,
		// Token: 0x0400239E RID: 9118
		FirstToRestNv,
		// Token: 0x0400239F RID: 9119
		PathGenModeNv,
		// Token: 0x040023A0 RID: 9120
		PathGenCoeffNv,
		// Token: 0x040023A1 RID: 9121
		PathGenColorFormatNv,
		// Token: 0x040023A2 RID: 9122
		PathGenComponentsNv,
		// Token: 0x040023A3 RID: 9123
		PathDashOffsetResetNv,
		// Token: 0x040023A4 RID: 9124
		MoveToResetsNv,
		// Token: 0x040023A5 RID: 9125
		MoveToContinuesNv,
		// Token: 0x040023A6 RID: 9126
		PathStencilFuncNv,
		// Token: 0x040023A7 RID: 9127
		PathStencilRefNv,
		// Token: 0x040023A8 RID: 9128
		PathStencilValueMaskNv,
		// Token: 0x040023A9 RID: 9129
		ScaledResolveFastestExt,
		// Token: 0x040023AA RID: 9130
		ScaledResolveNicestExt,
		// Token: 0x040023AB RID: 9131
		MinMapBufferAlignment,
		// Token: 0x040023AC RID: 9132
		PathStencilDepthOffsetFactorNv,
		// Token: 0x040023AD RID: 9133
		PathStencilDepthOffsetUnitsNv,
		// Token: 0x040023AE RID: 9134
		PathCoverDepthFuncNv,
		// Token: 0x040023AF RID: 9135
		ImageFormatCompatibilityType = 37063,
		// Token: 0x040023B0 RID: 9136
		ImageFormatCompatibilityBySize,
		// Token: 0x040023B1 RID: 9137
		ImageFormatCompatibilityByClass,
		// Token: 0x040023B2 RID: 9138
		MaxVertexImageUniforms,
		// Token: 0x040023B3 RID: 9139
		MaxTessControlImageUniforms,
		// Token: 0x040023B4 RID: 9140
		MaxTessEvaluationImageUniforms,
		// Token: 0x040023B5 RID: 9141
		MaxGeometryImageUniforms,
		// Token: 0x040023B6 RID: 9142
		MaxFragmentImageUniforms,
		// Token: 0x040023B7 RID: 9143
		MaxCombinedImageUniforms,
		// Token: 0x040023B8 RID: 9144
		MaxDeep3DTextureWidthHeightNv,
		// Token: 0x040023B9 RID: 9145
		MaxDeep3DTextureDepthNv,
		// Token: 0x040023BA RID: 9146
		ShaderStorageBuffer,
		// Token: 0x040023BB RID: 9147
		ShaderStorageBufferBinding,
		// Token: 0x040023BC RID: 9148
		ShaderStorageBufferStart,
		// Token: 0x040023BD RID: 9149
		ShaderStorageBufferSize,
		// Token: 0x040023BE RID: 9150
		MaxVertexShaderStorageBlocks,
		// Token: 0x040023BF RID: 9151
		MaxGeometryShaderStorageBlocks,
		// Token: 0x040023C0 RID: 9152
		MaxTessControlShaderStorageBlocks,
		// Token: 0x040023C1 RID: 9153
		MaxTessEvaluationShaderStorageBlocks,
		// Token: 0x040023C2 RID: 9154
		MaxFragmentShaderStorageBlocks,
		// Token: 0x040023C3 RID: 9155
		MaxComputeShaderStorageBlocks,
		// Token: 0x040023C4 RID: 9156
		MaxCombinedShaderStorageBlocks,
		// Token: 0x040023C5 RID: 9157
		MaxShaderStorageBufferBindings,
		// Token: 0x040023C6 RID: 9158
		MaxShaderStorageBlockSize,
		// Token: 0x040023C7 RID: 9159
		ShaderStorageBufferOffsetAlignment,
		// Token: 0x040023C8 RID: 9160
		SyncX11FenceExt = 37089,
		// Token: 0x040023C9 RID: 9161
		DepthStencilTextureMode = 37098,
		// Token: 0x040023CA RID: 9162
		MaxComputeFixedGroupInvocationsArb,
		// Token: 0x040023CB RID: 9163
		MaxComputeWorkGroupInvocations = 37099,
		// Token: 0x040023CC RID: 9164
		UniformBlockReferencedByComputeShader,
		// Token: 0x040023CD RID: 9165
		AtomicCounterBufferReferencedByComputeShader,
		// Token: 0x040023CE RID: 9166
		DispatchIndirectBuffer,
		// Token: 0x040023CF RID: 9167
		DispatchIndirectBufferBinding,
		// Token: 0x040023D0 RID: 9168
		ComputeProgramNv = 37115,
		// Token: 0x040023D1 RID: 9169
		ComputeProgramParameterBufferNv,
		// Token: 0x040023D2 RID: 9170
		Texture2DMultisample = 37120,
		// Token: 0x040023D3 RID: 9171
		ProxyTexture2DMultisample,
		// Token: 0x040023D4 RID: 9172
		Texture2DMultisampleArray,
		// Token: 0x040023D5 RID: 9173
		ProxyTexture2DMultisampleArray,
		// Token: 0x040023D6 RID: 9174
		TextureBinding2DMultisample,
		// Token: 0x040023D7 RID: 9175
		TextureBinding2DMultisampleArray,
		// Token: 0x040023D8 RID: 9176
		TextureSamples,
		// Token: 0x040023D9 RID: 9177
		TextureFixedSampleLocations,
		// Token: 0x040023DA RID: 9178
		Sampler2DMultisample,
		// Token: 0x040023DB RID: 9179
		IntSampler2DMultisample,
		// Token: 0x040023DC RID: 9180
		UnsignedIntSampler2DMultisample,
		// Token: 0x040023DD RID: 9181
		Sampler2DMultisampleArray,
		// Token: 0x040023DE RID: 9182
		IntSampler2DMultisampleArray,
		// Token: 0x040023DF RID: 9183
		UnsignedIntSampler2DMultisampleArray,
		// Token: 0x040023E0 RID: 9184
		MaxColorTextureSamples,
		// Token: 0x040023E1 RID: 9185
		MaxDepthTextureSamples,
		// Token: 0x040023E2 RID: 9186
		MaxIntegerSamples,
		// Token: 0x040023E3 RID: 9187
		MaxServerWaitTimeout,
		// Token: 0x040023E4 RID: 9188
		ObjectType,
		// Token: 0x040023E5 RID: 9189
		SyncCondition,
		// Token: 0x040023E6 RID: 9190
		SyncStatus,
		// Token: 0x040023E7 RID: 9191
		SyncFlags,
		// Token: 0x040023E8 RID: 9192
		SyncFence,
		// Token: 0x040023E9 RID: 9193
		SyncGpuCommandsComplete,
		// Token: 0x040023EA RID: 9194
		Unsignaled,
		// Token: 0x040023EB RID: 9195
		Signaled,
		// Token: 0x040023EC RID: 9196
		AlreadySignaled,
		// Token: 0x040023ED RID: 9197
		TimeoutExpired,
		// Token: 0x040023EE RID: 9198
		ConditionSatisfied,
		// Token: 0x040023EF RID: 9199
		WaitFailed,
		// Token: 0x040023F0 RID: 9200
		BufferAccessFlags = 37151,
		// Token: 0x040023F1 RID: 9201
		BufferMapLength,
		// Token: 0x040023F2 RID: 9202
		BufferMapOffset,
		// Token: 0x040023F3 RID: 9203
		MaxVertexOutputComponents,
		// Token: 0x040023F4 RID: 9204
		MaxGeometryInputComponents,
		// Token: 0x040023F5 RID: 9205
		MaxGeometryOutputComponents,
		// Token: 0x040023F6 RID: 9206
		MaxFragmentInputComponents,
		// Token: 0x040023F7 RID: 9207
		ContextProfileMask,
		// Token: 0x040023F8 RID: 9208
		UnpackCompressedBlockWidth,
		// Token: 0x040023F9 RID: 9209
		UnpackCompressedBlockHeight,
		// Token: 0x040023FA RID: 9210
		UnpackCompressedBlockDepth,
		// Token: 0x040023FB RID: 9211
		UnpackCompressedBlockSize,
		// Token: 0x040023FC RID: 9212
		PackCompressedBlockWidth,
		// Token: 0x040023FD RID: 9213
		PackCompressedBlockHeight,
		// Token: 0x040023FE RID: 9214
		PackCompressedBlockDepth,
		// Token: 0x040023FF RID: 9215
		PackCompressedBlockSize,
		// Token: 0x04002400 RID: 9216
		TextureImmutableFormat,
		// Token: 0x04002401 RID: 9217
		MaxDebugMessageLength = 37187,
		// Token: 0x04002402 RID: 9218
		MaxDebugMessageLengthAmd = 37187,
		// Token: 0x04002403 RID: 9219
		MaxDebugMessageLengthArb = 37187,
		// Token: 0x04002404 RID: 9220
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04002405 RID: 9221
		MaxDebugLoggedMessages,
		// Token: 0x04002406 RID: 9222
		MaxDebugLoggedMessagesAmd = 37188,
		// Token: 0x04002407 RID: 9223
		MaxDebugLoggedMessagesArb = 37188,
		// Token: 0x04002408 RID: 9224
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04002409 RID: 9225
		DebugLoggedMessages,
		// Token: 0x0400240A RID: 9226
		DebugLoggedMessagesAmd = 37189,
		// Token: 0x0400240B RID: 9227
		DebugLoggedMessagesArb = 37189,
		// Token: 0x0400240C RID: 9228
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x0400240D RID: 9229
		DebugSeverityHigh,
		// Token: 0x0400240E RID: 9230
		DebugSeverityHighAmd = 37190,
		// Token: 0x0400240F RID: 9231
		DebugSeverityHighArb = 37190,
		// Token: 0x04002410 RID: 9232
		DebugSeverityHighKhr = 37190,
		// Token: 0x04002411 RID: 9233
		DebugSeverityMedium,
		// Token: 0x04002412 RID: 9234
		DebugSeverityMediumAmd = 37191,
		// Token: 0x04002413 RID: 9235
		DebugSeverityMediumArb = 37191,
		// Token: 0x04002414 RID: 9236
		DebugSeverityMediumKhr = 37191,
		// Token: 0x04002415 RID: 9237
		DebugSeverityLow,
		// Token: 0x04002416 RID: 9238
		DebugSeverityLowAmd = 37192,
		// Token: 0x04002417 RID: 9239
		DebugSeverityLowArb = 37192,
		// Token: 0x04002418 RID: 9240
		DebugSeverityLowKhr = 37192,
		// Token: 0x04002419 RID: 9241
		DebugCategoryApiErrorAmd,
		// Token: 0x0400241A RID: 9242
		DebugCategoryWindowSystemAmd,
		// Token: 0x0400241B RID: 9243
		DebugCategoryDeprecationAmd,
		// Token: 0x0400241C RID: 9244
		DebugCategoryUndefinedBehaviorAmd,
		// Token: 0x0400241D RID: 9245
		DebugCategoryPerformanceAmd,
		// Token: 0x0400241E RID: 9246
		DebugCategoryShaderCompilerAmd,
		// Token: 0x0400241F RID: 9247
		DebugCategoryApplicationAmd,
		// Token: 0x04002420 RID: 9248
		DebugCategoryOtherAmd,
		// Token: 0x04002421 RID: 9249
		BufferObjectExt,
		// Token: 0x04002422 RID: 9250
		DataBufferAmd = 37201,
		// Token: 0x04002423 RID: 9251
		PerformanceMonitorAmd,
		// Token: 0x04002424 RID: 9252
		QueryObjectAmd,
		// Token: 0x04002425 RID: 9253
		QueryObjectExt = 37203,
		// Token: 0x04002426 RID: 9254
		VertexArrayObjectAmd,
		// Token: 0x04002427 RID: 9255
		VertexArrayObjectExt = 37204,
		// Token: 0x04002428 RID: 9256
		SamplerObjectAmd,
		// Token: 0x04002429 RID: 9257
		ExternalVirtualMemoryBufferAmd = 37216,
		// Token: 0x0400242A RID: 9258
		QueryBuffer = 37266,
		// Token: 0x0400242B RID: 9259
		QueryBufferAmd = 37266,
		// Token: 0x0400242C RID: 9260
		QueryBufferBinding,
		// Token: 0x0400242D RID: 9261
		QueryBufferBindingAmd = 37267,
		// Token: 0x0400242E RID: 9262
		QueryResultNoWait,
		// Token: 0x0400242F RID: 9263
		QueryResultNoWaitAmd = 37268,
		// Token: 0x04002430 RID: 9264
		VirtualPageSizeXAmd,
		// Token: 0x04002431 RID: 9265
		VirtualPageSizeXArb = 37269,
		// Token: 0x04002432 RID: 9266
		VirtualPageSizeYAmd,
		// Token: 0x04002433 RID: 9267
		VirtualPageSizeYArb = 37270,
		// Token: 0x04002434 RID: 9268
		VirtualPageSizeZAmd,
		// Token: 0x04002435 RID: 9269
		VirtualPageSizeZArb = 37271,
		// Token: 0x04002436 RID: 9270
		MaxSparseTextureSizeAmd,
		// Token: 0x04002437 RID: 9271
		MaxSparseTextureSizeArb = 37272,
		// Token: 0x04002438 RID: 9272
		MaxSparse3DTextureSizeAmd,
		// Token: 0x04002439 RID: 9273
		MaxSparse3DTextureSizeArb = 37273,
		// Token: 0x0400243A RID: 9274
		MaxSparseArrayTextureLayers,
		// Token: 0x0400243B RID: 9275
		MaxSparseArrayTextureLayersArb = 37274,
		// Token: 0x0400243C RID: 9276
		MinSparseLevelAmd,
		// Token: 0x0400243D RID: 9277
		MinSparseLevelArb = 37275,
		// Token: 0x0400243E RID: 9278
		MinLodWarningAmd,
		// Token: 0x0400243F RID: 9279
		TextureBufferOffset,
		// Token: 0x04002440 RID: 9280
		TextureBufferSize,
		// Token: 0x04002441 RID: 9281
		TextureBufferOffsetAlignment,
		// Token: 0x04002442 RID: 9282
		StreamRasterizationAmd,
		// Token: 0x04002443 RID: 9283
		VertexElementSwizzleAmd = 37284,
		// Token: 0x04002444 RID: 9284
		VertexIdSwizzleAmd,
		// Token: 0x04002445 RID: 9285
		TextureSparseArb,
		// Token: 0x04002446 RID: 9286
		VirtualPageSizeIndexArb,
		// Token: 0x04002447 RID: 9287
		NumVirtualPageSizesArb,
		// Token: 0x04002448 RID: 9288
		SparseTextureFullArrayCubeMipmapsArb,
		// Token: 0x04002449 RID: 9289
		ComputeShader = 37305,
		// Token: 0x0400244A RID: 9290
		MaxComputeUniformBlocks = 37307,
		// Token: 0x0400244B RID: 9291
		MaxComputeTextureImageUnits,
		// Token: 0x0400244C RID: 9292
		MaxComputeImageUniforms,
		// Token: 0x0400244D RID: 9293
		MaxComputeWorkGroupCount,
		// Token: 0x0400244E RID: 9294
		MaxComputeFixedGroupSizeArb,
		// Token: 0x0400244F RID: 9295
		MaxComputeWorkGroupSize = 37311,
		// Token: 0x04002450 RID: 9296
		CompressedR11Eac = 37488,
		// Token: 0x04002451 RID: 9297
		CompressedSignedR11Eac,
		// Token: 0x04002452 RID: 9298
		CompressedRg11Eac,
		// Token: 0x04002453 RID: 9299
		CompressedSignedRg11Eac,
		// Token: 0x04002454 RID: 9300
		CompressedRgb8Etc2,
		// Token: 0x04002455 RID: 9301
		CompressedSrgb8Etc2,
		// Token: 0x04002456 RID: 9302
		CompressedRgb8PunchthroughAlpha1Etc2,
		// Token: 0x04002457 RID: 9303
		CompressedSrgb8PunchthroughAlpha1Etc2,
		// Token: 0x04002458 RID: 9304
		CompressedRgba8Etc2Eac,
		// Token: 0x04002459 RID: 9305
		CompressedSrgb8Alpha8Etc2Eac,
		// Token: 0x0400245A RID: 9306
		BlendPremultipliedSrcNv = 37504,
		// Token: 0x0400245B RID: 9307
		BlendOverlapNv,
		// Token: 0x0400245C RID: 9308
		UncorrelatedNv,
		// Token: 0x0400245D RID: 9309
		DisjointNv,
		// Token: 0x0400245E RID: 9310
		ConjointNv,
		// Token: 0x0400245F RID: 9311
		BlendAdvancedCoherentNv,
		// Token: 0x04002460 RID: 9312
		SrcNv,
		// Token: 0x04002461 RID: 9313
		DstNv,
		// Token: 0x04002462 RID: 9314
		SrcOverNv,
		// Token: 0x04002463 RID: 9315
		DstOverNv,
		// Token: 0x04002464 RID: 9316
		SrcInNv,
		// Token: 0x04002465 RID: 9317
		DstInNv,
		// Token: 0x04002466 RID: 9318
		SrcOutNv,
		// Token: 0x04002467 RID: 9319
		DstOutNv,
		// Token: 0x04002468 RID: 9320
		SrcAtopNv,
		// Token: 0x04002469 RID: 9321
		DstAtopNv,
		// Token: 0x0400246A RID: 9322
		PlusNv = 37521,
		// Token: 0x0400246B RID: 9323
		PlusDarkerNv,
		// Token: 0x0400246C RID: 9324
		MultiplyNv = 37524,
		// Token: 0x0400246D RID: 9325
		ScreenNv,
		// Token: 0x0400246E RID: 9326
		OverlayNv,
		// Token: 0x0400246F RID: 9327
		DarkenNv,
		// Token: 0x04002470 RID: 9328
		LightenNv,
		// Token: 0x04002471 RID: 9329
		ColordodgeNv,
		// Token: 0x04002472 RID: 9330
		ColorburnNv,
		// Token: 0x04002473 RID: 9331
		HardlightNv,
		// Token: 0x04002474 RID: 9332
		SoftlightNv,
		// Token: 0x04002475 RID: 9333
		DifferenceNv = 37534,
		// Token: 0x04002476 RID: 9334
		MinusNv,
		// Token: 0x04002477 RID: 9335
		ExclusionNv,
		// Token: 0x04002478 RID: 9336
		ContrastNv,
		// Token: 0x04002479 RID: 9337
		InvertRgbNv = 37539,
		// Token: 0x0400247A RID: 9338
		LineardodgeNv,
		// Token: 0x0400247B RID: 9339
		LinearburnNv,
		// Token: 0x0400247C RID: 9340
		VividlightNv,
		// Token: 0x0400247D RID: 9341
		LinearlightNv,
		// Token: 0x0400247E RID: 9342
		PinlightNv,
		// Token: 0x0400247F RID: 9343
		HardmixNv,
		// Token: 0x04002480 RID: 9344
		HslHueNv = 37549,
		// Token: 0x04002481 RID: 9345
		HslSaturationNv,
		// Token: 0x04002482 RID: 9346
		HslColorNv,
		// Token: 0x04002483 RID: 9347
		HslLuminosityNv,
		// Token: 0x04002484 RID: 9348
		PlusClampedNv,
		// Token: 0x04002485 RID: 9349
		PlusClampedAlphaNv,
		// Token: 0x04002486 RID: 9350
		MinusClampedNv,
		// Token: 0x04002487 RID: 9351
		InvertOvgNv,
		// Token: 0x04002488 RID: 9352
		AtomicCounterBuffer = 37568,
		// Token: 0x04002489 RID: 9353
		AtomicCounterBufferBinding,
		// Token: 0x0400248A RID: 9354
		AtomicCounterBufferStart,
		// Token: 0x0400248B RID: 9355
		AtomicCounterBufferSize,
		// Token: 0x0400248C RID: 9356
		AtomicCounterBufferDataSize,
		// Token: 0x0400248D RID: 9357
		AtomicCounterBufferActiveAtomicCounters,
		// Token: 0x0400248E RID: 9358
		AtomicCounterBufferActiveAtomicCounterIndices,
		// Token: 0x0400248F RID: 9359
		AtomicCounterBufferReferencedByVertexShader,
		// Token: 0x04002490 RID: 9360
		AtomicCounterBufferReferencedByTessControlShader,
		// Token: 0x04002491 RID: 9361
		AtomicCounterBufferReferencedByTessEvaluationShader,
		// Token: 0x04002492 RID: 9362
		AtomicCounterBufferReferencedByGeometryShader,
		// Token: 0x04002493 RID: 9363
		AtomicCounterBufferReferencedByFragmentShader,
		// Token: 0x04002494 RID: 9364
		MaxVertexAtomicCounterBuffers,
		// Token: 0x04002495 RID: 9365
		MaxTessControlAtomicCounterBuffers,
		// Token: 0x04002496 RID: 9366
		MaxTessEvaluationAtomicCounterBuffers,
		// Token: 0x04002497 RID: 9367
		MaxGeometryAtomicCounterBuffers,
		// Token: 0x04002498 RID: 9368
		MaxFragmentAtomicCounterBuffers,
		// Token: 0x04002499 RID: 9369
		MaxCombinedAtomicCounterBuffers,
		// Token: 0x0400249A RID: 9370
		MaxVertexAtomicCounters,
		// Token: 0x0400249B RID: 9371
		MaxTessControlAtomicCounters,
		// Token: 0x0400249C RID: 9372
		MaxTessEvaluationAtomicCounters,
		// Token: 0x0400249D RID: 9373
		MaxGeometryAtomicCounters,
		// Token: 0x0400249E RID: 9374
		MaxFragmentAtomicCounters,
		// Token: 0x0400249F RID: 9375
		MaxCombinedAtomicCounters,
		// Token: 0x040024A0 RID: 9376
		MaxAtomicCounterBufferSize,
		// Token: 0x040024A1 RID: 9377
		ActiveAtomicCounterBuffers,
		// Token: 0x040024A2 RID: 9378
		UniformAtomicCounterBufferIndex,
		// Token: 0x040024A3 RID: 9379
		UnsignedIntAtomicCounter,
		// Token: 0x040024A4 RID: 9380
		MaxAtomicCounterBufferBindings,
		// Token: 0x040024A5 RID: 9381
		DebugOutput = 37600,
		// Token: 0x040024A6 RID: 9382
		DebugOutputKhr = 37600,
		// Token: 0x040024A7 RID: 9383
		Uniform,
		// Token: 0x040024A8 RID: 9384
		UniformBlock,
		// Token: 0x040024A9 RID: 9385
		ProgramInput,
		// Token: 0x040024AA RID: 9386
		ProgramOutput,
		// Token: 0x040024AB RID: 9387
		BufferVariable,
		// Token: 0x040024AC RID: 9388
		ShaderStorageBlock,
		// Token: 0x040024AD RID: 9389
		IsPerPatch,
		// Token: 0x040024AE RID: 9390
		VertexSubroutine,
		// Token: 0x040024AF RID: 9391
		TessControlSubroutine,
		// Token: 0x040024B0 RID: 9392
		TessEvaluationSubroutine,
		// Token: 0x040024B1 RID: 9393
		GeometrySubroutine,
		// Token: 0x040024B2 RID: 9394
		FragmentSubroutine,
		// Token: 0x040024B3 RID: 9395
		ComputeSubroutine,
		// Token: 0x040024B4 RID: 9396
		VertexSubroutineUniform,
		// Token: 0x040024B5 RID: 9397
		TessControlSubroutineUniform,
		// Token: 0x040024B6 RID: 9398
		TessEvaluationSubroutineUniform,
		// Token: 0x040024B7 RID: 9399
		GeometrySubroutineUniform,
		// Token: 0x040024B8 RID: 9400
		FragmentSubroutineUniform,
		// Token: 0x040024B9 RID: 9401
		ComputeSubroutineUniform,
		// Token: 0x040024BA RID: 9402
		TransformFeedbackVarying,
		// Token: 0x040024BB RID: 9403
		ActiveResources,
		// Token: 0x040024BC RID: 9404
		MaxNameLength,
		// Token: 0x040024BD RID: 9405
		MaxNumActiveVariables,
		// Token: 0x040024BE RID: 9406
		MaxNumCompatibleSubroutines,
		// Token: 0x040024BF RID: 9407
		NameLength,
		// Token: 0x040024C0 RID: 9408
		Type,
		// Token: 0x040024C1 RID: 9409
		ArraySize,
		// Token: 0x040024C2 RID: 9410
		Offset,
		// Token: 0x040024C3 RID: 9411
		BlockIndex,
		// Token: 0x040024C4 RID: 9412
		ArrayStride,
		// Token: 0x040024C5 RID: 9413
		MatrixStride,
		// Token: 0x040024C6 RID: 9414
		IsRowMajor,
		// Token: 0x040024C7 RID: 9415
		AtomicCounterBufferIndex,
		// Token: 0x040024C8 RID: 9416
		BufferBinding,
		// Token: 0x040024C9 RID: 9417
		BufferDataSize,
		// Token: 0x040024CA RID: 9418
		NumActiveVariables,
		// Token: 0x040024CB RID: 9419
		ActiveVariables,
		// Token: 0x040024CC RID: 9420
		ReferencedByVertexShader,
		// Token: 0x040024CD RID: 9421
		ReferencedByTessControlShader,
		// Token: 0x040024CE RID: 9422
		ReferencedByTessEvaluationShader,
		// Token: 0x040024CF RID: 9423
		ReferencedByGeometryShader,
		// Token: 0x040024D0 RID: 9424
		ReferencedByFragmentShader,
		// Token: 0x040024D1 RID: 9425
		ReferencedByComputeShader,
		// Token: 0x040024D2 RID: 9426
		TopLevelArraySize,
		// Token: 0x040024D3 RID: 9427
		TopLevelArrayStride,
		// Token: 0x040024D4 RID: 9428
		Location,
		// Token: 0x040024D5 RID: 9429
		LocationIndex,
		// Token: 0x040024D6 RID: 9430
		FramebufferDefaultWidth,
		// Token: 0x040024D7 RID: 9431
		FramebufferDefaultHeight,
		// Token: 0x040024D8 RID: 9432
		FramebufferDefaultLayers,
		// Token: 0x040024D9 RID: 9433
		FramebufferDefaultSamples,
		// Token: 0x040024DA RID: 9434
		FramebufferDefaultFixedSampleLocations,
		// Token: 0x040024DB RID: 9435
		MaxFramebufferWidth,
		// Token: 0x040024DC RID: 9436
		MaxFramebufferHeight,
		// Token: 0x040024DD RID: 9437
		MaxFramebufferLayers,
		// Token: 0x040024DE RID: 9438
		MaxFramebufferSamples,
		// Token: 0x040024DF RID: 9439
		WarpSizeNv = 37689,
		// Token: 0x040024E0 RID: 9440
		WarpsPerSmNv,
		// Token: 0x040024E1 RID: 9441
		SmCountNv,
		// Token: 0x040024E2 RID: 9442
		MaxComputeVariableGroupInvocationsArb = 37700,
		// Token: 0x040024E3 RID: 9443
		MaxComputeVariableGroupSizeArb,
		// Token: 0x040024E4 RID: 9444
		LocationComponent = 37706,
		// Token: 0x040024E5 RID: 9445
		TransformFeedbackBufferIndex,
		// Token: 0x040024E6 RID: 9446
		TransformFeedbackBufferStride,
		// Token: 0x040024E7 RID: 9447
		ClearTexture = 37733,
		// Token: 0x040024E8 RID: 9448
		NumSampleCounts = 37760,
		// Token: 0x040024E9 RID: 9449
		CompressedRgbaAstc4X4Khr = 37808,
		// Token: 0x040024EA RID: 9450
		CompressedRgbaAstc5X4Khr,
		// Token: 0x040024EB RID: 9451
		CompressedRgbaAstc5X5Khr,
		// Token: 0x040024EC RID: 9452
		CompressedRgbaAstc6X5Khr,
		// Token: 0x040024ED RID: 9453
		CompressedRgbaAstc6X6Khr,
		// Token: 0x040024EE RID: 9454
		CompressedRgbaAstc8X5Khr,
		// Token: 0x040024EF RID: 9455
		CompressedRgbaAstc8X6Khr,
		// Token: 0x040024F0 RID: 9456
		CompressedRgbaAstc8X8Khr,
		// Token: 0x040024F1 RID: 9457
		CompressedRgbaAstc10X5Khr,
		// Token: 0x040024F2 RID: 9458
		CompressedRgbaAstc10X6Khr,
		// Token: 0x040024F3 RID: 9459
		CompressedRgbaAstc10X8Khr,
		// Token: 0x040024F4 RID: 9460
		CompressedRgbaAstc10X10Khr,
		// Token: 0x040024F5 RID: 9461
		CompressedRgbaAstc12X10Khr,
		// Token: 0x040024F6 RID: 9462
		CompressedRgbaAstc12X12Khr,
		// Token: 0x040024F7 RID: 9463
		CompressedSrgb8Alpha8Astc4X4Khr = 37840,
		// Token: 0x040024F8 RID: 9464
		CompressedSrgb8Alpha8Astc5X4Khr,
		// Token: 0x040024F9 RID: 9465
		CompressedSrgb8Alpha8Astc5X5Khr,
		// Token: 0x040024FA RID: 9466
		CompressedSrgb8Alpha8Astc6X5Khr,
		// Token: 0x040024FB RID: 9467
		CompressedSrgb8Alpha8Astc6X6Khr,
		// Token: 0x040024FC RID: 9468
		CompressedSrgb8Alpha8Astc8X5Khr,
		// Token: 0x040024FD RID: 9469
		CompressedSrgb8Alpha8Astc8X6Khr,
		// Token: 0x040024FE RID: 9470
		CompressedSrgb8Alpha8Astc8X8Khr,
		// Token: 0x040024FF RID: 9471
		CompressedSrgb8Alpha8Astc10X5Khr,
		// Token: 0x04002500 RID: 9472
		CompressedSrgb8Alpha8Astc10X6Khr,
		// Token: 0x04002501 RID: 9473
		CompressedSrgb8Alpha8Astc10X8Khr,
		// Token: 0x04002502 RID: 9474
		CompressedSrgb8Alpha8Astc10X10Khr,
		// Token: 0x04002503 RID: 9475
		CompressedSrgb8Alpha8Astc12X10Khr,
		// Token: 0x04002504 RID: 9476
		CompressedSrgb8Alpha8Astc12X12Khr,
		// Token: 0x04002505 RID: 9477
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x04002506 RID: 9478
		PerfqueryCounterDurationNormIntel,
		// Token: 0x04002507 RID: 9479
		PerfqueryCounterDurationRawIntel,
		// Token: 0x04002508 RID: 9480
		PerfqueryCounterThroughputIntel,
		// Token: 0x04002509 RID: 9481
		PerfqueryCounterRawIntel,
		// Token: 0x0400250A RID: 9482
		PerfqueryCounterTimestampIntel,
		// Token: 0x0400250B RID: 9483
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x0400250C RID: 9484
		PerfqueryCounterDataUint64Intel,
		// Token: 0x0400250D RID: 9485
		PerfqueryCounterDataFloatIntel,
		// Token: 0x0400250E RID: 9486
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x0400250F RID: 9487
		PerfqueryCounterDataBool32Intel,
		// Token: 0x04002510 RID: 9488
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x04002511 RID: 9489
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x04002512 RID: 9490
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x04002513 RID: 9491
		PerfqueryGpaExtendedCountersIntel,
		// Token: 0x04002514 RID: 9492
		RestartPathNv = 240,
		// Token: 0x04002515 RID: 9493
		DupFirstCubicCurveToNv = 242,
		// Token: 0x04002516 RID: 9494
		DupLastCubicCurveToNv = 244,
		// Token: 0x04002517 RID: 9495
		RectNv = 246,
		// Token: 0x04002518 RID: 9496
		CircularCcwArcToNv = 248,
		// Token: 0x04002519 RID: 9497
		CircularCwArcToNv = 250,
		// Token: 0x0400251A RID: 9498
		CircularTangentArcToNv = 252,
		// Token: 0x0400251B RID: 9499
		ArcToNv = 254,
		// Token: 0x0400251C RID: 9500
		RelativeArcToNv,
		// Token: 0x0400251D RID: 9501
		AllAttribBits = -1,
		// Token: 0x0400251E RID: 9502
		AllBarrierBits = -1,
		// Token: 0x0400251F RID: 9503
		AllBarrierBitsExt = -1,
		// Token: 0x04002520 RID: 9504
		AllShaderBits = -1,
		// Token: 0x04002521 RID: 9505
		AllShaderBitsExt = -1,
		// Token: 0x04002522 RID: 9506
		ClientAllAttribBits = -1,
		// Token: 0x04002523 RID: 9507
		InvalidIndex = -1,
		// Token: 0x04002524 RID: 9508
		QueryAllEventBitsAmd = -1,
		// Token: 0x04002525 RID: 9509
		TimeoutIgnored = -1,
		// Token: 0x04002526 RID: 9510
		LayoutLinearIntel = 1,
		// Token: 0x04002527 RID: 9511
		One = 1,
		// Token: 0x04002528 RID: 9512
		True = 1,
		// Token: 0x04002529 RID: 9513
		CullVertexIbm = 103050,
		// Token: 0x0400252A RID: 9514
		AllStaticDataIbm = 103060,
		// Token: 0x0400252B RID: 9515
		StaticVertexArrayIbm,
		// Token: 0x0400252C RID: 9516
		VertexArrayListIbm = 103070,
		// Token: 0x0400252D RID: 9517
		NormalArrayListIbm,
		// Token: 0x0400252E RID: 9518
		ColorArrayListIbm,
		// Token: 0x0400252F RID: 9519
		IndexArrayListIbm,
		// Token: 0x04002530 RID: 9520
		TextureCoordArrayListIbm,
		// Token: 0x04002531 RID: 9521
		EdgeFlagArrayListIbm,
		// Token: 0x04002532 RID: 9522
		FogCoordinateArrayListIbm,
		// Token: 0x04002533 RID: 9523
		SecondaryColorArrayListIbm,
		// Token: 0x04002534 RID: 9524
		VertexArrayListStrideIbm = 103080,
		// Token: 0x04002535 RID: 9525
		NormalArrayListStrideIbm,
		// Token: 0x04002536 RID: 9526
		ColorArrayListStrideIbm,
		// Token: 0x04002537 RID: 9527
		IndexArrayListStrideIbm,
		// Token: 0x04002538 RID: 9528
		TextureCoordArrayListStrideIbm,
		// Token: 0x04002539 RID: 9529
		EdgeFlagArrayListStrideIbm,
		// Token: 0x0400253A RID: 9530
		FogCoordinateArrayListStrideIbm,
		// Token: 0x0400253B RID: 9531
		SecondaryColorArrayListStrideIbm,
		// Token: 0x0400253C RID: 9532
		LayoutLinearCpuCachedIntel = 2,
		// Token: 0x0400253D RID: 9533
		Two = 2,
		// Token: 0x0400253E RID: 9534
		NextBufferNv = -2,
		// Token: 0x0400253F RID: 9535
		Three = 3,
		// Token: 0x04002540 RID: 9536
		SkipComponents4Nv = -3,
		// Token: 0x04002541 RID: 9537
		Four = 4,
		// Token: 0x04002542 RID: 9538
		SkipComponents3Nv = -4,
		// Token: 0x04002543 RID: 9539
		SkipComponents2Nv = -5,
		// Token: 0x04002544 RID: 9540
		SkipComponents1Nv = -6
	}
}
