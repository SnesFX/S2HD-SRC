using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020001C7 RID: 455
	public enum ActiveUniformType
	{
		// Token: 0x04001274 RID: 4724
		Int = 5124,
		// Token: 0x04001275 RID: 4725
		UnsignedInt,
		// Token: 0x04001276 RID: 4726
		Float,
		// Token: 0x04001277 RID: 4727
		Double = 5130,
		// Token: 0x04001278 RID: 4728
		FloatVec2 = 35664,
		// Token: 0x04001279 RID: 4729
		FloatVec3,
		// Token: 0x0400127A RID: 4730
		FloatVec4,
		// Token: 0x0400127B RID: 4731
		IntVec2,
		// Token: 0x0400127C RID: 4732
		IntVec3,
		// Token: 0x0400127D RID: 4733
		IntVec4,
		// Token: 0x0400127E RID: 4734
		Bool,
		// Token: 0x0400127F RID: 4735
		BoolVec2,
		// Token: 0x04001280 RID: 4736
		BoolVec3,
		// Token: 0x04001281 RID: 4737
		BoolVec4,
		// Token: 0x04001282 RID: 4738
		FloatMat2,
		// Token: 0x04001283 RID: 4739
		FloatMat3,
		// Token: 0x04001284 RID: 4740
		FloatMat4,
		// Token: 0x04001285 RID: 4741
		Sampler1D,
		// Token: 0x04001286 RID: 4742
		Sampler2D,
		// Token: 0x04001287 RID: 4743
		Sampler3D,
		// Token: 0x04001288 RID: 4744
		SamplerCube,
		// Token: 0x04001289 RID: 4745
		Sampler1DShadow,
		// Token: 0x0400128A RID: 4746
		Sampler2DShadow,
		// Token: 0x0400128B RID: 4747
		Sampler2DRect,
		// Token: 0x0400128C RID: 4748
		Sampler2DRectShadow,
		// Token: 0x0400128D RID: 4749
		FloatMat2x3,
		// Token: 0x0400128E RID: 4750
		FloatMat2x4,
		// Token: 0x0400128F RID: 4751
		FloatMat3x2,
		// Token: 0x04001290 RID: 4752
		FloatMat3x4,
		// Token: 0x04001291 RID: 4753
		FloatMat4x2,
		// Token: 0x04001292 RID: 4754
		FloatMat4x3,
		// Token: 0x04001293 RID: 4755
		Sampler1DArray = 36288,
		// Token: 0x04001294 RID: 4756
		Sampler2DArray,
		// Token: 0x04001295 RID: 4757
		SamplerBuffer,
		// Token: 0x04001296 RID: 4758
		Sampler1DArrayShadow,
		// Token: 0x04001297 RID: 4759
		Sampler2DArrayShadow,
		// Token: 0x04001298 RID: 4760
		SamplerCubeShadow,
		// Token: 0x04001299 RID: 4761
		UnsignedIntVec2,
		// Token: 0x0400129A RID: 4762
		UnsignedIntVec3,
		// Token: 0x0400129B RID: 4763
		UnsignedIntVec4,
		// Token: 0x0400129C RID: 4764
		IntSampler1D,
		// Token: 0x0400129D RID: 4765
		IntSampler2D,
		// Token: 0x0400129E RID: 4766
		IntSampler3D,
		// Token: 0x0400129F RID: 4767
		IntSamplerCube,
		// Token: 0x040012A0 RID: 4768
		IntSampler2DRect,
		// Token: 0x040012A1 RID: 4769
		IntSampler1DArray,
		// Token: 0x040012A2 RID: 4770
		IntSampler2DArray,
		// Token: 0x040012A3 RID: 4771
		IntSamplerBuffer,
		// Token: 0x040012A4 RID: 4772
		UnsignedIntSampler1D,
		// Token: 0x040012A5 RID: 4773
		UnsignedIntSampler2D,
		// Token: 0x040012A6 RID: 4774
		UnsignedIntSampler3D,
		// Token: 0x040012A7 RID: 4775
		UnsignedIntSamplerCube,
		// Token: 0x040012A8 RID: 4776
		UnsignedIntSampler2DRect,
		// Token: 0x040012A9 RID: 4777
		UnsignedIntSampler1DArray,
		// Token: 0x040012AA RID: 4778
		UnsignedIntSampler2DArray,
		// Token: 0x040012AB RID: 4779
		UnsignedIntSamplerBuffer,
		// Token: 0x040012AC RID: 4780
		DoubleVec2 = 36860,
		// Token: 0x040012AD RID: 4781
		DoubleVec3,
		// Token: 0x040012AE RID: 4782
		DoubleVec4,
		// Token: 0x040012AF RID: 4783
		SamplerCubeMapArray = 36876,
		// Token: 0x040012B0 RID: 4784
		SamplerCubeMapArrayShadow,
		// Token: 0x040012B1 RID: 4785
		IntSamplerCubeMapArray,
		// Token: 0x040012B2 RID: 4786
		UnsignedIntSamplerCubeMapArray,
		// Token: 0x040012B3 RID: 4787
		Image1D = 36940,
		// Token: 0x040012B4 RID: 4788
		Image2D,
		// Token: 0x040012B5 RID: 4789
		Image3D,
		// Token: 0x040012B6 RID: 4790
		Image2DRect,
		// Token: 0x040012B7 RID: 4791
		ImageCube,
		// Token: 0x040012B8 RID: 4792
		ImageBuffer,
		// Token: 0x040012B9 RID: 4793
		Image1DArray,
		// Token: 0x040012BA RID: 4794
		Image2DArray,
		// Token: 0x040012BB RID: 4795
		ImageCubeMapArray,
		// Token: 0x040012BC RID: 4796
		Image2DMultisample,
		// Token: 0x040012BD RID: 4797
		Image2DMultisampleArray,
		// Token: 0x040012BE RID: 4798
		IntImage1D,
		// Token: 0x040012BF RID: 4799
		IntImage2D,
		// Token: 0x040012C0 RID: 4800
		IntImage3D,
		// Token: 0x040012C1 RID: 4801
		IntImage2DRect,
		// Token: 0x040012C2 RID: 4802
		IntImageCube,
		// Token: 0x040012C3 RID: 4803
		IntImageBuffer,
		// Token: 0x040012C4 RID: 4804
		IntImage1DArray,
		// Token: 0x040012C5 RID: 4805
		IntImage2DArray,
		// Token: 0x040012C6 RID: 4806
		IntImageCubeMapArray,
		// Token: 0x040012C7 RID: 4807
		IntImage2DMultisample,
		// Token: 0x040012C8 RID: 4808
		IntImage2DMultisampleArray,
		// Token: 0x040012C9 RID: 4809
		UnsignedIntImage1D,
		// Token: 0x040012CA RID: 4810
		UnsignedIntImage2D,
		// Token: 0x040012CB RID: 4811
		UnsignedIntImage3D,
		// Token: 0x040012CC RID: 4812
		UnsignedIntImage2DRect,
		// Token: 0x040012CD RID: 4813
		UnsignedIntImageCube,
		// Token: 0x040012CE RID: 4814
		UnsignedIntImageBuffer,
		// Token: 0x040012CF RID: 4815
		UnsignedIntImage1DArray,
		// Token: 0x040012D0 RID: 4816
		UnsignedIntImage2DArray,
		// Token: 0x040012D1 RID: 4817
		UnsignedIntImageCubeMapArray,
		// Token: 0x040012D2 RID: 4818
		UnsignedIntImage2DMultisample,
		// Token: 0x040012D3 RID: 4819
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x040012D4 RID: 4820
		Sampler2DMultisample = 37128,
		// Token: 0x040012D5 RID: 4821
		IntSampler2DMultisample,
		// Token: 0x040012D6 RID: 4822
		UnsignedIntSampler2DMultisample,
		// Token: 0x040012D7 RID: 4823
		Sampler2DMultisampleArray,
		// Token: 0x040012D8 RID: 4824
		IntSampler2DMultisampleArray,
		// Token: 0x040012D9 RID: 4825
		UnsignedIntSampler2DMultisampleArray,
		// Token: 0x040012DA RID: 4826
		UnsignedIntAtomicCounter = 37595
	}
}
