using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000216 RID: 534
	public enum ArbFragmentProgram
	{
		// Token: 0x040026D3 RID: 9939
		ProgramLengthArb = 34343,
		// Token: 0x040026D4 RID: 9940
		ProgramStringArb,
		// Token: 0x040026D5 RID: 9941
		MaxProgramMatrixStackDepthArb = 34350,
		// Token: 0x040026D6 RID: 9942
		MaxProgramMatricesArb,
		// Token: 0x040026D7 RID: 9943
		CurrentMatrixStackDepthArb = 34368,
		// Token: 0x040026D8 RID: 9944
		CurrentMatrixArb,
		// Token: 0x040026D9 RID: 9945
		ProgramErrorPositionArb = 34379,
		// Token: 0x040026DA RID: 9946
		ProgramBindingArb = 34423,
		// Token: 0x040026DB RID: 9947
		FragmentProgramArb = 34820,
		// Token: 0x040026DC RID: 9948
		ProgramAluInstructionsArb,
		// Token: 0x040026DD RID: 9949
		ProgramTexInstructionsArb,
		// Token: 0x040026DE RID: 9950
		ProgramTexIndirectionsArb,
		// Token: 0x040026DF RID: 9951
		ProgramNativeAluInstructionsArb,
		// Token: 0x040026E0 RID: 9952
		ProgramNativeTexInstructionsArb,
		// Token: 0x040026E1 RID: 9953
		ProgramNativeTexIndirectionsArb,
		// Token: 0x040026E2 RID: 9954
		MaxProgramAluInstructionsArb,
		// Token: 0x040026E3 RID: 9955
		MaxProgramTexInstructionsArb,
		// Token: 0x040026E4 RID: 9956
		MaxProgramTexIndirectionsArb,
		// Token: 0x040026E5 RID: 9957
		MaxProgramNativeAluInstructionsArb,
		// Token: 0x040026E6 RID: 9958
		MaxProgramNativeTexInstructionsArb,
		// Token: 0x040026E7 RID: 9959
		MaxProgramNativeTexIndirectionsArb,
		// Token: 0x040026E8 RID: 9960
		MaxTextureCoordsArb = 34929,
		// Token: 0x040026E9 RID: 9961
		MaxTextureImageUnitsArb,
		// Token: 0x040026EA RID: 9962
		ProgramErrorStringArb = 34932,
		// Token: 0x040026EB RID: 9963
		ProgramFormatAsciiArb,
		// Token: 0x040026EC RID: 9964
		ProgramFormatArb,
		// Token: 0x040026ED RID: 9965
		ProgramInstructionsArb = 34976,
		// Token: 0x040026EE RID: 9966
		MaxProgramInstructionsArb,
		// Token: 0x040026EF RID: 9967
		ProgramNativeInstructionsArb,
		// Token: 0x040026F0 RID: 9968
		MaxProgramNativeInstructionsArb,
		// Token: 0x040026F1 RID: 9969
		ProgramTemporariesArb,
		// Token: 0x040026F2 RID: 9970
		MaxProgramTemporariesArb,
		// Token: 0x040026F3 RID: 9971
		ProgramNativeTemporariesArb,
		// Token: 0x040026F4 RID: 9972
		MaxProgramNativeTemporariesArb,
		// Token: 0x040026F5 RID: 9973
		ProgramParametersArb,
		// Token: 0x040026F6 RID: 9974
		MaxProgramParametersArb,
		// Token: 0x040026F7 RID: 9975
		ProgramNativeParametersArb,
		// Token: 0x040026F8 RID: 9976
		MaxProgramNativeParametersArb,
		// Token: 0x040026F9 RID: 9977
		ProgramAttribsArb,
		// Token: 0x040026FA RID: 9978
		MaxProgramAttribsArb,
		// Token: 0x040026FB RID: 9979
		ProgramNativeAttribsArb,
		// Token: 0x040026FC RID: 9980
		MaxProgramNativeAttribsArb,
		// Token: 0x040026FD RID: 9981
		MaxProgramLocalParametersArb = 34996,
		// Token: 0x040026FE RID: 9982
		MaxProgramEnvParametersArb,
		// Token: 0x040026FF RID: 9983
		ProgramUnderNativeLimitsArb,
		// Token: 0x04002700 RID: 9984
		TransposeCurrentMatrixArb,
		// Token: 0x04002701 RID: 9985
		Matrix0Arb = 35008,
		// Token: 0x04002702 RID: 9986
		Matrix1Arb,
		// Token: 0x04002703 RID: 9987
		Matrix2Arb,
		// Token: 0x04002704 RID: 9988
		Matrix3Arb,
		// Token: 0x04002705 RID: 9989
		Matrix4Arb,
		// Token: 0x04002706 RID: 9990
		Matrix5Arb,
		// Token: 0x04002707 RID: 9991
		Matrix6Arb,
		// Token: 0x04002708 RID: 9992
		Matrix7Arb,
		// Token: 0x04002709 RID: 9993
		Matrix8Arb,
		// Token: 0x0400270A RID: 9994
		Matrix9Arb,
		// Token: 0x0400270B RID: 9995
		Matrix10Arb,
		// Token: 0x0400270C RID: 9996
		Matrix11Arb,
		// Token: 0x0400270D RID: 9997
		Matrix12Arb,
		// Token: 0x0400270E RID: 9998
		Matrix13Arb,
		// Token: 0x0400270F RID: 9999
		Matrix14Arb,
		// Token: 0x04002710 RID: 10000
		Matrix15Arb,
		// Token: 0x04002711 RID: 10001
		Matrix16Arb,
		// Token: 0x04002712 RID: 10002
		Matrix17Arb,
		// Token: 0x04002713 RID: 10003
		Matrix18Arb,
		// Token: 0x04002714 RID: 10004
		Matrix19Arb,
		// Token: 0x04002715 RID: 10005
		Matrix20Arb,
		// Token: 0x04002716 RID: 10006
		Matrix21Arb,
		// Token: 0x04002717 RID: 10007
		Matrix22Arb,
		// Token: 0x04002718 RID: 10008
		Matrix23Arb,
		// Token: 0x04002719 RID: 10009
		Matrix24Arb,
		// Token: 0x0400271A RID: 10010
		Matrix25Arb,
		// Token: 0x0400271B RID: 10011
		Matrix26Arb,
		// Token: 0x0400271C RID: 10012
		Matrix27Arb,
		// Token: 0x0400271D RID: 10013
		Matrix28Arb,
		// Token: 0x0400271E RID: 10014
		Matrix29Arb,
		// Token: 0x0400271F RID: 10015
		Matrix30Arb,
		// Token: 0x04002720 RID: 10016
		Matrix31Arb
	}
}
