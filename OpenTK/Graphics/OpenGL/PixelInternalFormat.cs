using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000400 RID: 1024
	public enum PixelInternalFormat
	{
		// Token: 0x04003DA5 RID: 15781
		DepthComponent = 6402,
		// Token: 0x04003DA6 RID: 15782
		Alpha = 6406,
		// Token: 0x04003DA7 RID: 15783
		Rgb,
		// Token: 0x04003DA8 RID: 15784
		Rgba,
		// Token: 0x04003DA9 RID: 15785
		Luminance,
		// Token: 0x04003DAA RID: 15786
		LuminanceAlpha,
		// Token: 0x04003DAB RID: 15787
		R3G3B2 = 10768,
		// Token: 0x04003DAC RID: 15788
		Alpha4 = 32827,
		// Token: 0x04003DAD RID: 15789
		Alpha8,
		// Token: 0x04003DAE RID: 15790
		Alpha12,
		// Token: 0x04003DAF RID: 15791
		Alpha16,
		// Token: 0x04003DB0 RID: 15792
		Luminance4,
		// Token: 0x04003DB1 RID: 15793
		Luminance8,
		// Token: 0x04003DB2 RID: 15794
		Luminance12,
		// Token: 0x04003DB3 RID: 15795
		Luminance16,
		// Token: 0x04003DB4 RID: 15796
		Luminance4Alpha4,
		// Token: 0x04003DB5 RID: 15797
		Luminance6Alpha2,
		// Token: 0x04003DB6 RID: 15798
		Luminance8Alpha8,
		// Token: 0x04003DB7 RID: 15799
		Luminance12Alpha4,
		// Token: 0x04003DB8 RID: 15800
		Luminance12Alpha12,
		// Token: 0x04003DB9 RID: 15801
		Luminance16Alpha16,
		// Token: 0x04003DBA RID: 15802
		Intensity,
		// Token: 0x04003DBB RID: 15803
		Intensity4,
		// Token: 0x04003DBC RID: 15804
		Intensity8,
		// Token: 0x04003DBD RID: 15805
		Intensity12,
		// Token: 0x04003DBE RID: 15806
		Intensity16,
		// Token: 0x04003DBF RID: 15807
		Rgb2Ext,
		// Token: 0x04003DC0 RID: 15808
		Rgb4,
		// Token: 0x04003DC1 RID: 15809
		Rgb5,
		// Token: 0x04003DC2 RID: 15810
		Rgb8,
		// Token: 0x04003DC3 RID: 15811
		Rgb10,
		// Token: 0x04003DC4 RID: 15812
		Rgb12,
		// Token: 0x04003DC5 RID: 15813
		Rgb16,
		// Token: 0x04003DC6 RID: 15814
		Rgba2,
		// Token: 0x04003DC7 RID: 15815
		Rgba4,
		// Token: 0x04003DC8 RID: 15816
		Rgb5A1,
		// Token: 0x04003DC9 RID: 15817
		Rgba8,
		// Token: 0x04003DCA RID: 15818
		Rgb10A2,
		// Token: 0x04003DCB RID: 15819
		Rgba12,
		// Token: 0x04003DCC RID: 15820
		Rgba16,
		// Token: 0x04003DCD RID: 15821
		DualAlpha4Sgis = 33040,
		// Token: 0x04003DCE RID: 15822
		DualAlpha8Sgis,
		// Token: 0x04003DCF RID: 15823
		DualAlpha12Sgis,
		// Token: 0x04003DD0 RID: 15824
		DualAlpha16Sgis,
		// Token: 0x04003DD1 RID: 15825
		DualLuminance4Sgis,
		// Token: 0x04003DD2 RID: 15826
		DualLuminance8Sgis,
		// Token: 0x04003DD3 RID: 15827
		DualLuminance12Sgis,
		// Token: 0x04003DD4 RID: 15828
		DualLuminance16Sgis,
		// Token: 0x04003DD5 RID: 15829
		DualIntensity4Sgis,
		// Token: 0x04003DD6 RID: 15830
		DualIntensity8Sgis,
		// Token: 0x04003DD7 RID: 15831
		DualIntensity12Sgis,
		// Token: 0x04003DD8 RID: 15832
		DualIntensity16Sgis,
		// Token: 0x04003DD9 RID: 15833
		DualLuminanceAlpha4Sgis,
		// Token: 0x04003DDA RID: 15834
		DualLuminanceAlpha8Sgis,
		// Token: 0x04003DDB RID: 15835
		QuadAlpha4Sgis,
		// Token: 0x04003DDC RID: 15836
		QuadAlpha8Sgis,
		// Token: 0x04003DDD RID: 15837
		QuadLuminance4Sgis,
		// Token: 0x04003DDE RID: 15838
		QuadLuminance8Sgis,
		// Token: 0x04003DDF RID: 15839
		QuadIntensity4Sgis,
		// Token: 0x04003DE0 RID: 15840
		QuadIntensity8Sgis,
		// Token: 0x04003DE1 RID: 15841
		DepthComponent16 = 33189,
		// Token: 0x04003DE2 RID: 15842
		DepthComponent16Sgix = 33189,
		// Token: 0x04003DE3 RID: 15843
		DepthComponent24,
		// Token: 0x04003DE4 RID: 15844
		DepthComponent24Sgix = 33190,
		// Token: 0x04003DE5 RID: 15845
		DepthComponent32,
		// Token: 0x04003DE6 RID: 15846
		DepthComponent32Sgix = 33191,
		// Token: 0x04003DE7 RID: 15847
		CompressedRed = 33317,
		// Token: 0x04003DE8 RID: 15848
		CompressedRg,
		// Token: 0x04003DE9 RID: 15849
		R8 = 33321,
		// Token: 0x04003DEA RID: 15850
		R16,
		// Token: 0x04003DEB RID: 15851
		Rg8,
		// Token: 0x04003DEC RID: 15852
		Rg16,
		// Token: 0x04003DED RID: 15853
		R16f,
		// Token: 0x04003DEE RID: 15854
		R32f,
		// Token: 0x04003DEF RID: 15855
		Rg16f,
		// Token: 0x04003DF0 RID: 15856
		Rg32f,
		// Token: 0x04003DF1 RID: 15857
		R8i,
		// Token: 0x04003DF2 RID: 15858
		R8ui,
		// Token: 0x04003DF3 RID: 15859
		R16i,
		// Token: 0x04003DF4 RID: 15860
		R16ui,
		// Token: 0x04003DF5 RID: 15861
		R32i,
		// Token: 0x04003DF6 RID: 15862
		R32ui,
		// Token: 0x04003DF7 RID: 15863
		Rg8i,
		// Token: 0x04003DF8 RID: 15864
		Rg8ui,
		// Token: 0x04003DF9 RID: 15865
		Rg16i,
		// Token: 0x04003DFA RID: 15866
		Rg16ui,
		// Token: 0x04003DFB RID: 15867
		Rg32i,
		// Token: 0x04003DFC RID: 15868
		Rg32ui,
		// Token: 0x04003DFD RID: 15869
		CompressedRgbS3tcDxt1Ext = 33776,
		// Token: 0x04003DFE RID: 15870
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x04003DFF RID: 15871
		CompressedRgbaS3tcDxt3Ext,
		// Token: 0x04003E00 RID: 15872
		CompressedRgbaS3tcDxt5Ext,
		// Token: 0x04003E01 RID: 15873
		RgbIccSgix = 33888,
		// Token: 0x04003E02 RID: 15874
		RgbaIccSgix,
		// Token: 0x04003E03 RID: 15875
		AlphaIccSgix,
		// Token: 0x04003E04 RID: 15876
		LuminanceIccSgix,
		// Token: 0x04003E05 RID: 15877
		IntensityIccSgix,
		// Token: 0x04003E06 RID: 15878
		LuminanceAlphaIccSgix,
		// Token: 0x04003E07 RID: 15879
		R5G6B5IccSgix,
		// Token: 0x04003E08 RID: 15880
		R5G6B5A8IccSgix,
		// Token: 0x04003E09 RID: 15881
		Alpha16IccSgix,
		// Token: 0x04003E0A RID: 15882
		Luminance16IccSgix,
		// Token: 0x04003E0B RID: 15883
		Intensity16IccSgix,
		// Token: 0x04003E0C RID: 15884
		Luminance16Alpha8IccSgix,
		// Token: 0x04003E0D RID: 15885
		CompressedAlpha = 34025,
		// Token: 0x04003E0E RID: 15886
		CompressedLuminance,
		// Token: 0x04003E0F RID: 15887
		CompressedLuminanceAlpha,
		// Token: 0x04003E10 RID: 15888
		CompressedIntensity,
		// Token: 0x04003E11 RID: 15889
		CompressedRgb,
		// Token: 0x04003E12 RID: 15890
		CompressedRgba,
		// Token: 0x04003E13 RID: 15891
		DepthStencil = 34041,
		// Token: 0x04003E14 RID: 15892
		Rgba32f = 34836,
		// Token: 0x04003E15 RID: 15893
		Rgb32f,
		// Token: 0x04003E16 RID: 15894
		Rgba16f = 34842,
		// Token: 0x04003E17 RID: 15895
		Rgb16f,
		// Token: 0x04003E18 RID: 15896
		Depth24Stencil8 = 35056,
		// Token: 0x04003E19 RID: 15897
		R11fG11fB10f = 35898,
		// Token: 0x04003E1A RID: 15898
		Rgb9E5 = 35901,
		// Token: 0x04003E1B RID: 15899
		Srgb = 35904,
		// Token: 0x04003E1C RID: 15900
		Srgb8,
		// Token: 0x04003E1D RID: 15901
		SrgbAlpha,
		// Token: 0x04003E1E RID: 15902
		Srgb8Alpha8,
		// Token: 0x04003E1F RID: 15903
		SluminanceAlpha,
		// Token: 0x04003E20 RID: 15904
		Sluminance8Alpha8,
		// Token: 0x04003E21 RID: 15905
		Sluminance,
		// Token: 0x04003E22 RID: 15906
		Sluminance8,
		// Token: 0x04003E23 RID: 15907
		CompressedSrgb,
		// Token: 0x04003E24 RID: 15908
		CompressedSrgbAlpha,
		// Token: 0x04003E25 RID: 15909
		CompressedSluminance,
		// Token: 0x04003E26 RID: 15910
		CompressedSluminanceAlpha,
		// Token: 0x04003E27 RID: 15911
		CompressedSrgbS3tcDxt1Ext,
		// Token: 0x04003E28 RID: 15912
		CompressedSrgbAlphaS3tcDxt1Ext,
		// Token: 0x04003E29 RID: 15913
		CompressedSrgbAlphaS3tcDxt3Ext,
		// Token: 0x04003E2A RID: 15914
		CompressedSrgbAlphaS3tcDxt5Ext,
		// Token: 0x04003E2B RID: 15915
		DepthComponent32f = 36012,
		// Token: 0x04003E2C RID: 15916
		Depth32fStencil8,
		// Token: 0x04003E2D RID: 15917
		Rgba32ui = 36208,
		// Token: 0x04003E2E RID: 15918
		Rgb32ui,
		// Token: 0x04003E2F RID: 15919
		Rgba16ui = 36214,
		// Token: 0x04003E30 RID: 15920
		Rgb16ui,
		// Token: 0x04003E31 RID: 15921
		Rgba8ui = 36220,
		// Token: 0x04003E32 RID: 15922
		Rgb8ui,
		// Token: 0x04003E33 RID: 15923
		Rgba32i = 36226,
		// Token: 0x04003E34 RID: 15924
		Rgb32i,
		// Token: 0x04003E35 RID: 15925
		Rgba16i = 36232,
		// Token: 0x04003E36 RID: 15926
		Rgb16i,
		// Token: 0x04003E37 RID: 15927
		Rgba8i = 36238,
		// Token: 0x04003E38 RID: 15928
		Rgb8i,
		// Token: 0x04003E39 RID: 15929
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x04003E3A RID: 15930
		CompressedRedRgtc1 = 36283,
		// Token: 0x04003E3B RID: 15931
		CompressedSignedRedRgtc1,
		// Token: 0x04003E3C RID: 15932
		CompressedRgRgtc2,
		// Token: 0x04003E3D RID: 15933
		CompressedSignedRgRgtc2,
		// Token: 0x04003E3E RID: 15934
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x04003E3F RID: 15935
		CompressedRgbBptcSignedFloat = 36494,
		// Token: 0x04003E40 RID: 15936
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x04003E41 RID: 15937
		R8Snorm = 36756,
		// Token: 0x04003E42 RID: 15938
		Rg8Snorm,
		// Token: 0x04003E43 RID: 15939
		Rgb8Snorm,
		// Token: 0x04003E44 RID: 15940
		Rgba8Snorm,
		// Token: 0x04003E45 RID: 15941
		R16Snorm,
		// Token: 0x04003E46 RID: 15942
		Rg16Snorm,
		// Token: 0x04003E47 RID: 15943
		Rgb16Snorm,
		// Token: 0x04003E48 RID: 15944
		Rgba16Snorm,
		// Token: 0x04003E49 RID: 15945
		Rgb10A2ui = 36975,
		// Token: 0x04003E4A RID: 15946
		One = 1,
		// Token: 0x04003E4B RID: 15947
		Two,
		// Token: 0x04003E4C RID: 15948
		Three,
		// Token: 0x04003E4D RID: 15949
		Four
	}
}
