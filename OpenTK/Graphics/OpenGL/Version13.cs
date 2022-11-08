using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000497 RID: 1175
	public enum Version13
	{
		// Token: 0x040045D6 RID: 17878
		MultisampleBit = 536870912,
		// Token: 0x040045D7 RID: 17879
		Multisample = 32925,
		// Token: 0x040045D8 RID: 17880
		SampleAlphaToCoverage,
		// Token: 0x040045D9 RID: 17881
		SampleAlphaToOne,
		// Token: 0x040045DA RID: 17882
		SampleCoverage,
		// Token: 0x040045DB RID: 17883
		SampleBuffers = 32936,
		// Token: 0x040045DC RID: 17884
		Samples,
		// Token: 0x040045DD RID: 17885
		SampleCoverageValue,
		// Token: 0x040045DE RID: 17886
		SampleCoverageInvert,
		// Token: 0x040045DF RID: 17887
		ClampToBorder = 33069,
		// Token: 0x040045E0 RID: 17888
		Texture0 = 33984,
		// Token: 0x040045E1 RID: 17889
		Texture1,
		// Token: 0x040045E2 RID: 17890
		Texture2,
		// Token: 0x040045E3 RID: 17891
		Texture3,
		// Token: 0x040045E4 RID: 17892
		Texture4,
		// Token: 0x040045E5 RID: 17893
		Texture5,
		// Token: 0x040045E6 RID: 17894
		Texture6,
		// Token: 0x040045E7 RID: 17895
		Texture7,
		// Token: 0x040045E8 RID: 17896
		Texture8,
		// Token: 0x040045E9 RID: 17897
		Texture9,
		// Token: 0x040045EA RID: 17898
		Texture10,
		// Token: 0x040045EB RID: 17899
		Texture11,
		// Token: 0x040045EC RID: 17900
		Texture12,
		// Token: 0x040045ED RID: 17901
		Texture13,
		// Token: 0x040045EE RID: 17902
		Texture14,
		// Token: 0x040045EF RID: 17903
		Texture15,
		// Token: 0x040045F0 RID: 17904
		Texture16,
		// Token: 0x040045F1 RID: 17905
		Texture17,
		// Token: 0x040045F2 RID: 17906
		Texture18,
		// Token: 0x040045F3 RID: 17907
		Texture19,
		// Token: 0x040045F4 RID: 17908
		Texture20,
		// Token: 0x040045F5 RID: 17909
		Texture21,
		// Token: 0x040045F6 RID: 17910
		Texture22,
		// Token: 0x040045F7 RID: 17911
		Texture23,
		// Token: 0x040045F8 RID: 17912
		Texture24,
		// Token: 0x040045F9 RID: 17913
		Texture25,
		// Token: 0x040045FA RID: 17914
		Texture26,
		// Token: 0x040045FB RID: 17915
		Texture27,
		// Token: 0x040045FC RID: 17916
		Texture28,
		// Token: 0x040045FD RID: 17917
		Texture29,
		// Token: 0x040045FE RID: 17918
		Texture30,
		// Token: 0x040045FF RID: 17919
		Texture31,
		// Token: 0x04004600 RID: 17920
		ActiveTexture,
		// Token: 0x04004601 RID: 17921
		ClientActiveTexture,
		// Token: 0x04004602 RID: 17922
		MaxTextureUnits,
		// Token: 0x04004603 RID: 17923
		TransposeModelviewMatrix,
		// Token: 0x04004604 RID: 17924
		TransposeProjectionMatrix,
		// Token: 0x04004605 RID: 17925
		TransposeTextureMatrix,
		// Token: 0x04004606 RID: 17926
		TransposeColorMatrix,
		// Token: 0x04004607 RID: 17927
		Subtract,
		// Token: 0x04004608 RID: 17928
		CompressedAlpha = 34025,
		// Token: 0x04004609 RID: 17929
		CompressedLuminance,
		// Token: 0x0400460A RID: 17930
		CompressedLuminanceAlpha,
		// Token: 0x0400460B RID: 17931
		CompressedIntensity,
		// Token: 0x0400460C RID: 17932
		CompressedRgb,
		// Token: 0x0400460D RID: 17933
		CompressedRgba,
		// Token: 0x0400460E RID: 17934
		TextureCompressionHint,
		// Token: 0x0400460F RID: 17935
		NormalMap = 34065,
		// Token: 0x04004610 RID: 17936
		ReflectionMap,
		// Token: 0x04004611 RID: 17937
		TextureCubeMap,
		// Token: 0x04004612 RID: 17938
		TextureBindingCubeMap,
		// Token: 0x04004613 RID: 17939
		TextureCubeMapPositiveX,
		// Token: 0x04004614 RID: 17940
		TextureCubeMapNegativeX,
		// Token: 0x04004615 RID: 17941
		TextureCubeMapPositiveY,
		// Token: 0x04004616 RID: 17942
		TextureCubeMapNegativeY,
		// Token: 0x04004617 RID: 17943
		TextureCubeMapPositiveZ,
		// Token: 0x04004618 RID: 17944
		TextureCubeMapNegativeZ,
		// Token: 0x04004619 RID: 17945
		ProxyTextureCubeMap,
		// Token: 0x0400461A RID: 17946
		MaxCubeMapTextureSize,
		// Token: 0x0400461B RID: 17947
		Combine = 34160,
		// Token: 0x0400461C RID: 17948
		CombineRgb,
		// Token: 0x0400461D RID: 17949
		CombineAlpha,
		// Token: 0x0400461E RID: 17950
		RgbScale,
		// Token: 0x0400461F RID: 17951
		AddSigned,
		// Token: 0x04004620 RID: 17952
		Interpolate,
		// Token: 0x04004621 RID: 17953
		Constant,
		// Token: 0x04004622 RID: 17954
		PrimaryColor,
		// Token: 0x04004623 RID: 17955
		Previous,
		// Token: 0x04004624 RID: 17956
		Source0Rgb = 34176,
		// Token: 0x04004625 RID: 17957
		Source1Rgb,
		// Token: 0x04004626 RID: 17958
		Source2Rgb,
		// Token: 0x04004627 RID: 17959
		Source0Alpha = 34184,
		// Token: 0x04004628 RID: 17960
		Source1Alpha,
		// Token: 0x04004629 RID: 17961
		Source2Alpha,
		// Token: 0x0400462A RID: 17962
		Operand0Rgb = 34192,
		// Token: 0x0400462B RID: 17963
		Operand1Rgb,
		// Token: 0x0400462C RID: 17964
		Operand2Rgb,
		// Token: 0x0400462D RID: 17965
		Operand0Alpha = 34200,
		// Token: 0x0400462E RID: 17966
		Operand1Alpha,
		// Token: 0x0400462F RID: 17967
		Operand2Alpha,
		// Token: 0x04004630 RID: 17968
		TextureCompressedImageSize = 34464,
		// Token: 0x04004631 RID: 17969
		TextureCompressed,
		// Token: 0x04004632 RID: 17970
		NumCompressedTextureFormats,
		// Token: 0x04004633 RID: 17971
		CompressedTextureFormats,
		// Token: 0x04004634 RID: 17972
		Dot3Rgb = 34478,
		// Token: 0x04004635 RID: 17973
		Dot3Rgba
	}
}
