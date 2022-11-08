using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000601 RID: 1537
	public enum ActiveUniformType
	{
		// Token: 0x040055F6 RID: 22006
		Int = 5124,
		// Token: 0x040055F7 RID: 22007
		UnsignedInt,
		// Token: 0x040055F8 RID: 22008
		Float,
		// Token: 0x040055F9 RID: 22009
		Double = 5130,
		// Token: 0x040055FA RID: 22010
		FloatVec2 = 35664,
		// Token: 0x040055FB RID: 22011
		FloatVec3,
		// Token: 0x040055FC RID: 22012
		FloatVec4,
		// Token: 0x040055FD RID: 22013
		IntVec2,
		// Token: 0x040055FE RID: 22014
		IntVec3,
		// Token: 0x040055FF RID: 22015
		IntVec4,
		// Token: 0x04005600 RID: 22016
		Bool,
		// Token: 0x04005601 RID: 22017
		BoolVec2,
		// Token: 0x04005602 RID: 22018
		BoolVec3,
		// Token: 0x04005603 RID: 22019
		BoolVec4,
		// Token: 0x04005604 RID: 22020
		FloatMat2,
		// Token: 0x04005605 RID: 22021
		FloatMat3,
		// Token: 0x04005606 RID: 22022
		FloatMat4,
		// Token: 0x04005607 RID: 22023
		Sampler1D,
		// Token: 0x04005608 RID: 22024
		Sampler2D,
		// Token: 0x04005609 RID: 22025
		Sampler3D,
		// Token: 0x0400560A RID: 22026
		SamplerCube,
		// Token: 0x0400560B RID: 22027
		Sampler1DShadow,
		// Token: 0x0400560C RID: 22028
		Sampler2DShadow,
		// Token: 0x0400560D RID: 22029
		Sampler2DRect,
		// Token: 0x0400560E RID: 22030
		Sampler2DRectShadow,
		// Token: 0x0400560F RID: 22031
		FloatMat2x3,
		// Token: 0x04005610 RID: 22032
		FloatMat2x4,
		// Token: 0x04005611 RID: 22033
		FloatMat3x2,
		// Token: 0x04005612 RID: 22034
		FloatMat3x4,
		// Token: 0x04005613 RID: 22035
		FloatMat4x2,
		// Token: 0x04005614 RID: 22036
		FloatMat4x3,
		// Token: 0x04005615 RID: 22037
		Sampler1DArray = 36288,
		// Token: 0x04005616 RID: 22038
		Sampler2DArray,
		// Token: 0x04005617 RID: 22039
		SamplerBuffer,
		// Token: 0x04005618 RID: 22040
		Sampler1DArrayShadow,
		// Token: 0x04005619 RID: 22041
		Sampler2DArrayShadow,
		// Token: 0x0400561A RID: 22042
		SamplerCubeShadow,
		// Token: 0x0400561B RID: 22043
		UnsignedIntVec2,
		// Token: 0x0400561C RID: 22044
		UnsignedIntVec3,
		// Token: 0x0400561D RID: 22045
		UnsignedIntVec4,
		// Token: 0x0400561E RID: 22046
		IntSampler1D,
		// Token: 0x0400561F RID: 22047
		IntSampler2D,
		// Token: 0x04005620 RID: 22048
		IntSampler3D,
		// Token: 0x04005621 RID: 22049
		IntSamplerCube,
		// Token: 0x04005622 RID: 22050
		IntSampler2DRect,
		// Token: 0x04005623 RID: 22051
		IntSampler1DArray,
		// Token: 0x04005624 RID: 22052
		IntSampler2DArray,
		// Token: 0x04005625 RID: 22053
		IntSamplerBuffer,
		// Token: 0x04005626 RID: 22054
		UnsignedIntSampler1D,
		// Token: 0x04005627 RID: 22055
		UnsignedIntSampler2D,
		// Token: 0x04005628 RID: 22056
		UnsignedIntSampler3D,
		// Token: 0x04005629 RID: 22057
		UnsignedIntSamplerCube,
		// Token: 0x0400562A RID: 22058
		UnsignedIntSampler2DRect,
		// Token: 0x0400562B RID: 22059
		UnsignedIntSampler1DArray,
		// Token: 0x0400562C RID: 22060
		UnsignedIntSampler2DArray,
		// Token: 0x0400562D RID: 22061
		UnsignedIntSamplerBuffer,
		// Token: 0x0400562E RID: 22062
		DoubleVec2 = 36860,
		// Token: 0x0400562F RID: 22063
		DoubleVec3,
		// Token: 0x04005630 RID: 22064
		DoubleVec4,
		// Token: 0x04005631 RID: 22065
		SamplerCubeMapArray = 36876,
		// Token: 0x04005632 RID: 22066
		SamplerCubeMapArrayShadow,
		// Token: 0x04005633 RID: 22067
		IntSamplerCubeMapArray,
		// Token: 0x04005634 RID: 22068
		UnsignedIntSamplerCubeMapArray,
		// Token: 0x04005635 RID: 22069
		Image1D = 36940,
		// Token: 0x04005636 RID: 22070
		Image2D,
		// Token: 0x04005637 RID: 22071
		Image3D,
		// Token: 0x04005638 RID: 22072
		Image2DRect,
		// Token: 0x04005639 RID: 22073
		ImageCube,
		// Token: 0x0400563A RID: 22074
		ImageBuffer,
		// Token: 0x0400563B RID: 22075
		Image1DArray,
		// Token: 0x0400563C RID: 22076
		Image2DArray,
		// Token: 0x0400563D RID: 22077
		ImageCubeMapArray,
		// Token: 0x0400563E RID: 22078
		Image2DMultisample,
		// Token: 0x0400563F RID: 22079
		Image2DMultisampleArray,
		// Token: 0x04005640 RID: 22080
		IntImage1D,
		// Token: 0x04005641 RID: 22081
		IntImage2D,
		// Token: 0x04005642 RID: 22082
		IntImage3D,
		// Token: 0x04005643 RID: 22083
		IntImage2DRect,
		// Token: 0x04005644 RID: 22084
		IntImageCube,
		// Token: 0x04005645 RID: 22085
		IntImageBuffer,
		// Token: 0x04005646 RID: 22086
		IntImage1DArray,
		// Token: 0x04005647 RID: 22087
		IntImage2DArray,
		// Token: 0x04005648 RID: 22088
		IntImageCubeMapArray,
		// Token: 0x04005649 RID: 22089
		IntImage2DMultisample,
		// Token: 0x0400564A RID: 22090
		IntImage2DMultisampleArray,
		// Token: 0x0400564B RID: 22091
		UnsignedIntImage1D,
		// Token: 0x0400564C RID: 22092
		UnsignedIntImage2D,
		// Token: 0x0400564D RID: 22093
		UnsignedIntImage3D,
		// Token: 0x0400564E RID: 22094
		UnsignedIntImage2DRect,
		// Token: 0x0400564F RID: 22095
		UnsignedIntImageCube,
		// Token: 0x04005650 RID: 22096
		UnsignedIntImageBuffer,
		// Token: 0x04005651 RID: 22097
		UnsignedIntImage1DArray,
		// Token: 0x04005652 RID: 22098
		UnsignedIntImage2DArray,
		// Token: 0x04005653 RID: 22099
		UnsignedIntImageCubeMapArray,
		// Token: 0x04005654 RID: 22100
		UnsignedIntImage2DMultisample,
		// Token: 0x04005655 RID: 22101
		UnsignedIntImage2DMultisampleArray,
		// Token: 0x04005656 RID: 22102
		Sampler2DMultisample = 37128,
		// Token: 0x04005657 RID: 22103
		IntSampler2DMultisample,
		// Token: 0x04005658 RID: 22104
		UnsignedIntSampler2DMultisample,
		// Token: 0x04005659 RID: 22105
		Sampler2DMultisampleArray,
		// Token: 0x0400565A RID: 22106
		IntSampler2DMultisampleArray,
		// Token: 0x0400565B RID: 22107
		UnsignedIntSampler2DMultisampleArray,
		// Token: 0x0400565C RID: 22108
		UnsignedIntAtomicCounter = 37595
	}
}
