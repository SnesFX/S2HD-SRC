using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200027E RID: 638
	public enum ArbVertexProgram
	{
		// Token: 0x04002B83 RID: 11139
		ColorSumArb = 33880,
		// Token: 0x04002B84 RID: 11140
		VertexProgramArb = 34336,
		// Token: 0x04002B85 RID: 11141
		VertexAttribArrayEnabledArb = 34338,
		// Token: 0x04002B86 RID: 11142
		VertexAttribArraySizeArb,
		// Token: 0x04002B87 RID: 11143
		VertexAttribArrayStrideArb,
		// Token: 0x04002B88 RID: 11144
		VertexAttribArrayTypeArb,
		// Token: 0x04002B89 RID: 11145
		CurrentVertexAttribArb,
		// Token: 0x04002B8A RID: 11146
		ProgramLengthArb,
		// Token: 0x04002B8B RID: 11147
		ProgramStringArb,
		// Token: 0x04002B8C RID: 11148
		MaxProgramMatrixStackDepthArb = 34350,
		// Token: 0x04002B8D RID: 11149
		MaxProgramMatricesArb,
		// Token: 0x04002B8E RID: 11150
		CurrentMatrixStackDepthArb = 34368,
		// Token: 0x04002B8F RID: 11151
		CurrentMatrixArb,
		// Token: 0x04002B90 RID: 11152
		VertexProgramPointSizeArb,
		// Token: 0x04002B91 RID: 11153
		VertexProgramTwoSideArb,
		// Token: 0x04002B92 RID: 11154
		VertexAttribArrayPointerArb = 34373,
		// Token: 0x04002B93 RID: 11155
		ProgramErrorPositionArb = 34379,
		// Token: 0x04002B94 RID: 11156
		ProgramBindingArb = 34423,
		// Token: 0x04002B95 RID: 11157
		MaxVertexAttribsArb = 34921,
		// Token: 0x04002B96 RID: 11158
		VertexAttribArrayNormalizedArb,
		// Token: 0x04002B97 RID: 11159
		ProgramErrorStringArb = 34932,
		// Token: 0x04002B98 RID: 11160
		ProgramFormatAsciiArb,
		// Token: 0x04002B99 RID: 11161
		ProgramFormatArb,
		// Token: 0x04002B9A RID: 11162
		ProgramInstructionsArb = 34976,
		// Token: 0x04002B9B RID: 11163
		MaxProgramInstructionsArb,
		// Token: 0x04002B9C RID: 11164
		ProgramNativeInstructionsArb,
		// Token: 0x04002B9D RID: 11165
		MaxProgramNativeInstructionsArb,
		// Token: 0x04002B9E RID: 11166
		ProgramTemporariesArb,
		// Token: 0x04002B9F RID: 11167
		MaxProgramTemporariesArb,
		// Token: 0x04002BA0 RID: 11168
		ProgramNativeTemporariesArb,
		// Token: 0x04002BA1 RID: 11169
		MaxProgramNativeTemporariesArb,
		// Token: 0x04002BA2 RID: 11170
		ProgramParametersArb,
		// Token: 0x04002BA3 RID: 11171
		MaxProgramParametersArb,
		// Token: 0x04002BA4 RID: 11172
		ProgramNativeParametersArb,
		// Token: 0x04002BA5 RID: 11173
		MaxProgramNativeParametersArb,
		// Token: 0x04002BA6 RID: 11174
		ProgramAttribsArb,
		// Token: 0x04002BA7 RID: 11175
		MaxProgramAttribsArb,
		// Token: 0x04002BA8 RID: 11176
		ProgramNativeAttribsArb,
		// Token: 0x04002BA9 RID: 11177
		MaxProgramNativeAttribsArb,
		// Token: 0x04002BAA RID: 11178
		ProgramAddressRegistersArb,
		// Token: 0x04002BAB RID: 11179
		MaxProgramAddressRegistersArb,
		// Token: 0x04002BAC RID: 11180
		ProgramNativeAddressRegistersArb,
		// Token: 0x04002BAD RID: 11181
		MaxProgramNativeAddressRegistersArb,
		// Token: 0x04002BAE RID: 11182
		MaxProgramLocalParametersArb,
		// Token: 0x04002BAF RID: 11183
		MaxProgramEnvParametersArb,
		// Token: 0x04002BB0 RID: 11184
		ProgramUnderNativeLimitsArb,
		// Token: 0x04002BB1 RID: 11185
		TransposeCurrentMatrixArb,
		// Token: 0x04002BB2 RID: 11186
		Matrix0Arb = 35008,
		// Token: 0x04002BB3 RID: 11187
		Matrix1Arb,
		// Token: 0x04002BB4 RID: 11188
		Matrix2Arb,
		// Token: 0x04002BB5 RID: 11189
		Matrix3Arb,
		// Token: 0x04002BB6 RID: 11190
		Matrix4Arb,
		// Token: 0x04002BB7 RID: 11191
		Matrix5Arb,
		// Token: 0x04002BB8 RID: 11192
		Matrix6Arb,
		// Token: 0x04002BB9 RID: 11193
		Matrix7Arb,
		// Token: 0x04002BBA RID: 11194
		Matrix8Arb,
		// Token: 0x04002BBB RID: 11195
		Matrix9Arb,
		// Token: 0x04002BBC RID: 11196
		Matrix10Arb,
		// Token: 0x04002BBD RID: 11197
		Matrix11Arb,
		// Token: 0x04002BBE RID: 11198
		Matrix12Arb,
		// Token: 0x04002BBF RID: 11199
		Matrix13Arb,
		// Token: 0x04002BC0 RID: 11200
		Matrix14Arb,
		// Token: 0x04002BC1 RID: 11201
		Matrix15Arb,
		// Token: 0x04002BC2 RID: 11202
		Matrix16Arb,
		// Token: 0x04002BC3 RID: 11203
		Matrix17Arb,
		// Token: 0x04002BC4 RID: 11204
		Matrix18Arb,
		// Token: 0x04002BC5 RID: 11205
		Matrix19Arb,
		// Token: 0x04002BC6 RID: 11206
		Matrix20Arb,
		// Token: 0x04002BC7 RID: 11207
		Matrix21Arb,
		// Token: 0x04002BC8 RID: 11208
		Matrix22Arb,
		// Token: 0x04002BC9 RID: 11209
		Matrix23Arb,
		// Token: 0x04002BCA RID: 11210
		Matrix24Arb,
		// Token: 0x04002BCB RID: 11211
		Matrix25Arb,
		// Token: 0x04002BCC RID: 11212
		Matrix26Arb,
		// Token: 0x04002BCD RID: 11213
		Matrix27Arb,
		// Token: 0x04002BCE RID: 11214
		Matrix28Arb,
		// Token: 0x04002BCF RID: 11215
		Matrix29Arb,
		// Token: 0x04002BD0 RID: 11216
		Matrix30Arb,
		// Token: 0x04002BD1 RID: 11217
		Matrix31Arb
	}
}
