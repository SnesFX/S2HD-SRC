using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200049A RID: 1178
	public enum Version20
	{
		// Token: 0x0400469B RID: 18075
		BlendEquationRgb = 32777,
		// Token: 0x0400469C RID: 18076
		VertexAttribArrayEnabled = 34338,
		// Token: 0x0400469D RID: 18077
		VertexAttribArraySize,
		// Token: 0x0400469E RID: 18078
		VertexAttribArrayStride,
		// Token: 0x0400469F RID: 18079
		VertexAttribArrayType,
		// Token: 0x040046A0 RID: 18080
		CurrentVertexAttrib,
		// Token: 0x040046A1 RID: 18081
		VertexProgramPointSize = 34370,
		// Token: 0x040046A2 RID: 18082
		VertexProgramTwoSide,
		// Token: 0x040046A3 RID: 18083
		VertexAttribArrayPointer = 34373,
		// Token: 0x040046A4 RID: 18084
		StencilBackFunc = 34816,
		// Token: 0x040046A5 RID: 18085
		StencilBackFail,
		// Token: 0x040046A6 RID: 18086
		StencilBackPassDepthFail,
		// Token: 0x040046A7 RID: 18087
		StencilBackPassDepthPass,
		// Token: 0x040046A8 RID: 18088
		MaxDrawBuffers = 34852,
		// Token: 0x040046A9 RID: 18089
		DrawBuffer0,
		// Token: 0x040046AA RID: 18090
		DrawBuffer1,
		// Token: 0x040046AB RID: 18091
		DrawBuffer2,
		// Token: 0x040046AC RID: 18092
		DrawBuffer3,
		// Token: 0x040046AD RID: 18093
		DrawBuffer4,
		// Token: 0x040046AE RID: 18094
		DrawBuffer5,
		// Token: 0x040046AF RID: 18095
		DrawBuffer6,
		// Token: 0x040046B0 RID: 18096
		DrawBuffer7,
		// Token: 0x040046B1 RID: 18097
		DrawBuffer8,
		// Token: 0x040046B2 RID: 18098
		DrawBuffer9,
		// Token: 0x040046B3 RID: 18099
		DrawBuffer10,
		// Token: 0x040046B4 RID: 18100
		DrawBuffer11,
		// Token: 0x040046B5 RID: 18101
		DrawBuffer12,
		// Token: 0x040046B6 RID: 18102
		DrawBuffer13,
		// Token: 0x040046B7 RID: 18103
		DrawBuffer14,
		// Token: 0x040046B8 RID: 18104
		DrawBuffer15,
		// Token: 0x040046B9 RID: 18105
		BlendEquationAlpha = 34877,
		// Token: 0x040046BA RID: 18106
		PointSprite = 34913,
		// Token: 0x040046BB RID: 18107
		CoordReplace,
		// Token: 0x040046BC RID: 18108
		MaxVertexAttribs = 34921,
		// Token: 0x040046BD RID: 18109
		VertexAttribArrayNormalized,
		// Token: 0x040046BE RID: 18110
		MaxTextureCoords = 34929,
		// Token: 0x040046BF RID: 18111
		MaxTextureImageUnits,
		// Token: 0x040046C0 RID: 18112
		FragmentShader = 35632,
		// Token: 0x040046C1 RID: 18113
		VertexShader,
		// Token: 0x040046C2 RID: 18114
		MaxFragmentUniformComponents = 35657,
		// Token: 0x040046C3 RID: 18115
		MaxVertexUniformComponents,
		// Token: 0x040046C4 RID: 18116
		MaxVaryingFloats,
		// Token: 0x040046C5 RID: 18117
		MaxVertexTextureImageUnits,
		// Token: 0x040046C6 RID: 18118
		MaxCombinedTextureImageUnits,
		// Token: 0x040046C7 RID: 18119
		ShaderType = 35663,
		// Token: 0x040046C8 RID: 18120
		FloatVec2,
		// Token: 0x040046C9 RID: 18121
		FloatVec3,
		// Token: 0x040046CA RID: 18122
		FloatVec4,
		// Token: 0x040046CB RID: 18123
		IntVec2,
		// Token: 0x040046CC RID: 18124
		IntVec3,
		// Token: 0x040046CD RID: 18125
		IntVec4,
		// Token: 0x040046CE RID: 18126
		Bool,
		// Token: 0x040046CF RID: 18127
		BoolVec2,
		// Token: 0x040046D0 RID: 18128
		BoolVec3,
		// Token: 0x040046D1 RID: 18129
		BoolVec4,
		// Token: 0x040046D2 RID: 18130
		FloatMat2,
		// Token: 0x040046D3 RID: 18131
		FloatMat3,
		// Token: 0x040046D4 RID: 18132
		FloatMat4,
		// Token: 0x040046D5 RID: 18133
		Sampler1D,
		// Token: 0x040046D6 RID: 18134
		Sampler2D,
		// Token: 0x040046D7 RID: 18135
		Sampler3D,
		// Token: 0x040046D8 RID: 18136
		SamplerCube,
		// Token: 0x040046D9 RID: 18137
		Sampler1DShadow,
		// Token: 0x040046DA RID: 18138
		Sampler2DShadow,
		// Token: 0x040046DB RID: 18139
		DeleteStatus = 35712,
		// Token: 0x040046DC RID: 18140
		CompileStatus,
		// Token: 0x040046DD RID: 18141
		LinkStatus,
		// Token: 0x040046DE RID: 18142
		ValidateStatus,
		// Token: 0x040046DF RID: 18143
		InfoLogLength,
		// Token: 0x040046E0 RID: 18144
		AttachedShaders,
		// Token: 0x040046E1 RID: 18145
		ActiveUniforms,
		// Token: 0x040046E2 RID: 18146
		ActiveUniformMaxLength,
		// Token: 0x040046E3 RID: 18147
		ShaderSourceLength,
		// Token: 0x040046E4 RID: 18148
		ActiveAttributes,
		// Token: 0x040046E5 RID: 18149
		ActiveAttributeMaxLength,
		// Token: 0x040046E6 RID: 18150
		FragmentShaderDerivativeHint,
		// Token: 0x040046E7 RID: 18151
		ShadingLanguageVersion,
		// Token: 0x040046E8 RID: 18152
		CurrentProgram,
		// Token: 0x040046E9 RID: 18153
		PointSpriteCoordOrigin = 36000,
		// Token: 0x040046EA RID: 18154
		LowerLeft,
		// Token: 0x040046EB RID: 18155
		UpperLeft,
		// Token: 0x040046EC RID: 18156
		StencilBackRef,
		// Token: 0x040046ED RID: 18157
		StencilBackValueMask,
		// Token: 0x040046EE RID: 18158
		StencilBackWritemask
	}
}
