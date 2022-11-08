using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000641 RID: 1601
	public enum ArbShaderImageLoadStore
	{
		// Token: 0x040061DA RID: 25050
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x040061DB RID: 25051
		ElementArrayBarrierBit,
		// Token: 0x040061DC RID: 25052
		UniformBarrierBit = 4,
		// Token: 0x040061DD RID: 25053
		TextureFetchBarrierBit = 8,
		// Token: 0x040061DE RID: 25054
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x040061DF RID: 25055
		CommandBarrierBit = 64,
		// Token: 0x040061E0 RID: 25056
		PixelBufferBarrierBit = 128,
		// Token: 0x040061E1 RID: 25057
		TextureUpdateBarrierBit = 256,
		// Token: 0x040061E2 RID: 25058
		BufferUpdateBarrierBit = 512,
		// Token: 0x040061E3 RID: 25059
		FramebufferBarrierBit = 1024,
		// Token: 0x040061E4 RID: 25060
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x040061E5 RID: 25061
		AtomicCounterBarrierBit = 4096,
		// Token: 0x040061E6 RID: 25062
		MaxImageUnits = 36664,
		// Token: 0x040061E7 RID: 25063
		MaxCombinedImageUnitsAndFragmentOutputs,
		// Token: 0x040061E8 RID: 25064
		ImageBindingName,
		// Token: 0x040061E9 RID: 25065
		ImageBindingLevel,
		// Token: 0x040061EA RID: 25066
		ImageBindingLayered,
		// Token: 0x040061EB RID: 25067
		ImageBindingLayer,
		// Token: 0x040061EC RID: 25068
		ImageBindingAccess,
		// Token: 0x040061ED RID: 25069
		Image1D = 36940,
		// Token: 0x040061EE RID: 25070
		Image2D,
		// Token: 0x040061EF RID: 25071
		Image3D,
		// Token: 0x040061F0 RID: 25072
		Image2DRect,
		// Token: 0x040061F1 RID: 25073
		ImageCube,
		// Token: 0x040061F2 RID: 25074
		ImageBuffer,
		// Token: 0x040061F3 RID: 25075
		Image1DArray,
		// Token: 0x040061F4 RID: 25076
		Image2DArray,
		// Token: 0x040061F5 RID: 25077
		ImageCubeMapArray,
		// Token: 0x040061F6 RID: 25078
		Image2DMultisample,
		// Token: 0x040061F7 RID: 25079
		Image2DMultisampleArray,
		// Token: 0x040061F8 RID: 25080
		IntImage1D,
		// Token: 0x040061F9 RID: 25081
		IntImage2D,
		// Token: 0x040061FA RID: 25082
		IntImage3D,
		// Token: 0x040061FB RID: 25083
		IntImage2DRect,
		// Token: 0x040061FC RID: 25084
		IntImageCube,
		// Token: 0x040061FD RID: 25085
		IntImageBuffer,
		// Token: 0x040061FE RID: 25086
		IntImage1DArray,
		// Token: 0x040061FF RID: 25087
		IntImage2DArray,
		// Token: 0x04006200 RID: 25088
		IntImageCubeMapArray,
		// Token: 0x04006201 RID: 25089
		IntImage2DMultisample,
		// Token: 0x04006202 RID: 25090
		IntImage2DMultisampleArray,
		// Token: 0x04006203 RID: 25091
		UnsignedIntImage1D,
		// Token: 0x04006204 RID: 25092
		UnsignedIntImage2D,
		// Token: 0x04006205 RID: 25093
		UnsignedIntImage3D,
		// Token: 0x04006206 RID: 25094
		UnsignedIntImage2DRect,
		// Token: 0x04006207 RID: 25095
		UnsignedIntImageCube,
		// Token: 0x04006208 RID: 25096
		UnsignedIntImageBuffer,
		// Token: 0x04006209 RID: 25097
		UnsignedIntImage1DArray,
		// Token: 0x0400620A RID: 25098
		UnsignedIntImage2DArray,
		// Token: 0x0400620B RID: 25099
		UnsignedIntImageCubeMapArray,
		// Token: 0x0400620C RID: 25100
		UnsignedIntImage2DMultisample,
		// Token: 0x0400620D RID: 25101
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x0400620E RID: 25102
		MaxImageSamples,
		// Token: 0x0400620F RID: 25103
		ImageBindingFormat,
		// Token: 0x04006210 RID: 25104
		ImageFormatCompatibilityType = 37063,
		// Token: 0x04006211 RID: 25105
		ImageFormatCompatibilityBySize,
		// Token: 0x04006212 RID: 25106
		ImageFormatCompatibilityByClass,
		// Token: 0x04006213 RID: 25107
		MaxVertexImageUniforms,
		// Token: 0x04006214 RID: 25108
		MaxTessControlImageUniforms,
		// Token: 0x04006215 RID: 25109
		MaxTessEvaluationImageUniforms,
		// Token: 0x04006216 RID: 25110
		MaxGeometryImageUniforms,
		// Token: 0x04006217 RID: 25111
		MaxFragmentImageUniforms,
		// Token: 0x04006218 RID: 25112
		MaxCombinedImageUniforms,
		// Token: 0x04006219 RID: 25113
		AllBarrierBits = -1
	}
}
