using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200062B RID: 1579
	public enum ArbInternalformatQuery2
	{
		// Token: 0x040060DC RID: 24796
		Texture1D = 3552,
		// Token: 0x040060DD RID: 24797
		Texture2D,
		// Token: 0x040060DE RID: 24798
		Texture3D = 32879,
		// Token: 0x040060DF RID: 24799
		Samples = 32937,
		// Token: 0x040060E0 RID: 24800
		InternalformatSupported = 33391,
		// Token: 0x040060E1 RID: 24801
		InternalformatPreferred,
		// Token: 0x040060E2 RID: 24802
		InternalformatRedSize,
		// Token: 0x040060E3 RID: 24803
		InternalformatGreenSize,
		// Token: 0x040060E4 RID: 24804
		InternalformatBlueSize,
		// Token: 0x040060E5 RID: 24805
		InternalformatAlphaSize,
		// Token: 0x040060E6 RID: 24806
		InternalformatDepthSize,
		// Token: 0x040060E7 RID: 24807
		InternalformatStencilSize,
		// Token: 0x040060E8 RID: 24808
		InternalformatSharedSize,
		// Token: 0x040060E9 RID: 24809
		InternalformatRedType,
		// Token: 0x040060EA RID: 24810
		InternalformatGreenType,
		// Token: 0x040060EB RID: 24811
		InternalformatBlueType,
		// Token: 0x040060EC RID: 24812
		InternalformatAlphaType,
		// Token: 0x040060ED RID: 24813
		InternalformatDepthType,
		// Token: 0x040060EE RID: 24814
		InternalformatStencilType,
		// Token: 0x040060EF RID: 24815
		MaxWidth,
		// Token: 0x040060F0 RID: 24816
		MaxHeight,
		// Token: 0x040060F1 RID: 24817
		MaxDepth,
		// Token: 0x040060F2 RID: 24818
		MaxLayers,
		// Token: 0x040060F3 RID: 24819
		MaxCombinedDimensions,
		// Token: 0x040060F4 RID: 24820
		ColorComponents,
		// Token: 0x040060F5 RID: 24821
		DepthComponents,
		// Token: 0x040060F6 RID: 24822
		StencilComponents,
		// Token: 0x040060F7 RID: 24823
		ColorRenderable,
		// Token: 0x040060F8 RID: 24824
		DepthRenderable,
		// Token: 0x040060F9 RID: 24825
		StencilRenderable,
		// Token: 0x040060FA RID: 24826
		FramebufferRenderable,
		// Token: 0x040060FB RID: 24827
		FramebufferRenderableLayered,
		// Token: 0x040060FC RID: 24828
		FramebufferBlend,
		// Token: 0x040060FD RID: 24829
		ReadPixels,
		// Token: 0x040060FE RID: 24830
		ReadPixelsFormat,
		// Token: 0x040060FF RID: 24831
		ReadPixelsType,
		// Token: 0x04006100 RID: 24832
		TextureImageFormat,
		// Token: 0x04006101 RID: 24833
		TextureImageType,
		// Token: 0x04006102 RID: 24834
		GetTextureImageFormat,
		// Token: 0x04006103 RID: 24835
		GetTextureImageType,
		// Token: 0x04006104 RID: 24836
		Mipmap,
		// Token: 0x04006105 RID: 24837
		ManualGenerateMipmap,
		// Token: 0x04006106 RID: 24838
		AutoGenerateMipmap,
		// Token: 0x04006107 RID: 24839
		ColorEncoding,
		// Token: 0x04006108 RID: 24840
		SrgbRead,
		// Token: 0x04006109 RID: 24841
		SrgbWrite,
		// Token: 0x0400610A RID: 24842
		SrgbDecodeArb,
		// Token: 0x0400610B RID: 24843
		Filter,
		// Token: 0x0400610C RID: 24844
		VertexTexture,
		// Token: 0x0400610D RID: 24845
		TessControlTexture,
		// Token: 0x0400610E RID: 24846
		TessEvaluationTexture,
		// Token: 0x0400610F RID: 24847
		GeometryTexture,
		// Token: 0x04006110 RID: 24848
		FragmentTexture,
		// Token: 0x04006111 RID: 24849
		ComputeTexture,
		// Token: 0x04006112 RID: 24850
		TextureShadow,
		// Token: 0x04006113 RID: 24851
		TextureGather,
		// Token: 0x04006114 RID: 24852
		TextureGatherShadow,
		// Token: 0x04006115 RID: 24853
		ShaderImageLoad,
		// Token: 0x04006116 RID: 24854
		ShaderImageStore,
		// Token: 0x04006117 RID: 24855
		ShaderImageAtomic,
		// Token: 0x04006118 RID: 24856
		ImageTexelSize,
		// Token: 0x04006119 RID: 24857
		ImageCompatibilityClass,
		// Token: 0x0400611A RID: 24858
		ImagePixelFormat,
		// Token: 0x0400611B RID: 24859
		ImagePixelType,
		// Token: 0x0400611C RID: 24860
		SimultaneousTextureAndDepthTest = 33452,
		// Token: 0x0400611D RID: 24861
		SimultaneousTextureAndStencilTest,
		// Token: 0x0400611E RID: 24862
		SimultaneousTextureAndDepthWrite,
		// Token: 0x0400611F RID: 24863
		SimultaneousTextureAndStencilWrite,
		// Token: 0x04006120 RID: 24864
		TextureCompressedBlockWidth = 33457,
		// Token: 0x04006121 RID: 24865
		TextureCompressedBlockHeight,
		// Token: 0x04006122 RID: 24866
		TextureCompressedBlockSize,
		// Token: 0x04006123 RID: 24867
		ClearBuffer,
		// Token: 0x04006124 RID: 24868
		TextureView,
		// Token: 0x04006125 RID: 24869
		ViewCompatibilityClass,
		// Token: 0x04006126 RID: 24870
		FullSupport,
		// Token: 0x04006127 RID: 24871
		CaveatSupport,
		// Token: 0x04006128 RID: 24872
		ImageClass4X32,
		// Token: 0x04006129 RID: 24873
		ImageClass2X32,
		// Token: 0x0400612A RID: 24874
		ImageClass1X32,
		// Token: 0x0400612B RID: 24875
		ImageClass4X16,
		// Token: 0x0400612C RID: 24876
		ImageClass2X16,
		// Token: 0x0400612D RID: 24877
		ImageClass1X16,
		// Token: 0x0400612E RID: 24878
		ImageClass4X8,
		// Token: 0x0400612F RID: 24879
		ImageClass2X8,
		// Token: 0x04006130 RID: 24880
		ImageClass1X8,
		// Token: 0x04006131 RID: 24881
		ImageClass111110,
		// Token: 0x04006132 RID: 24882
		ImageClass1010102,
		// Token: 0x04006133 RID: 24883
		ViewClass128Bits,
		// Token: 0x04006134 RID: 24884
		ViewClass96Bits,
		// Token: 0x04006135 RID: 24885
		ViewClass64Bits,
		// Token: 0x04006136 RID: 24886
		ViewClass48Bits,
		// Token: 0x04006137 RID: 24887
		ViewClass32Bits,
		// Token: 0x04006138 RID: 24888
		ViewClass24Bits,
		// Token: 0x04006139 RID: 24889
		ViewClass16Bits,
		// Token: 0x0400613A RID: 24890
		ViewClass8Bits,
		// Token: 0x0400613B RID: 24891
		ViewClassS3tcDxt1Rgb,
		// Token: 0x0400613C RID: 24892
		ViewClassS3tcDxt1Rgba,
		// Token: 0x0400613D RID: 24893
		ViewClassS3tcDxt3Rgba,
		// Token: 0x0400613E RID: 24894
		ViewClassS3tcDxt5Rgba,
		// Token: 0x0400613F RID: 24895
		ViewClassRgtc1Red,
		// Token: 0x04006140 RID: 24896
		ViewClassRgtc2Rg,
		// Token: 0x04006141 RID: 24897
		ViewClassBptcUnorm,
		// Token: 0x04006142 RID: 24898
		ViewClassBptcFloat,
		// Token: 0x04006143 RID: 24899
		TextureRectangle = 34037,
		// Token: 0x04006144 RID: 24900
		TextureCubeMap = 34067,
		// Token: 0x04006145 RID: 24901
		TextureCompressed = 34465,
		// Token: 0x04006146 RID: 24902
		Texture1DArray = 35864,
		// Token: 0x04006147 RID: 24903
		Texture2DArray = 35866,
		// Token: 0x04006148 RID: 24904
		TextureBuffer = 35882,
		// Token: 0x04006149 RID: 24905
		Renderbuffer = 36161,
		// Token: 0x0400614A RID: 24906
		TextureCubeMapArray = 36873,
		// Token: 0x0400614B RID: 24907
		ImageFormatCompatibilityType = 37063,
		// Token: 0x0400614C RID: 24908
		Texture2DMultisample = 37120,
		// Token: 0x0400614D RID: 24909
		Texture2DMultisampleArray = 37122,
		// Token: 0x0400614E RID: 24910
		NumSampleCounts = 37760
	}
}
