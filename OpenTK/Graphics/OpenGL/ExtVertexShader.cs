using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000336 RID: 822
	public enum ExtVertexShader
	{
		// Token: 0x04003284 RID: 12932
		VertexShaderExt = 34688,
		// Token: 0x04003285 RID: 12933
		VertexShaderBindingExt,
		// Token: 0x04003286 RID: 12934
		OpIndexExt,
		// Token: 0x04003287 RID: 12935
		OpNegateExt,
		// Token: 0x04003288 RID: 12936
		OpDot3Ext,
		// Token: 0x04003289 RID: 12937
		OpDot4Ext,
		// Token: 0x0400328A RID: 12938
		OpMulExt,
		// Token: 0x0400328B RID: 12939
		OpAddExt,
		// Token: 0x0400328C RID: 12940
		OpMaddExt,
		// Token: 0x0400328D RID: 12941
		OpFracExt,
		// Token: 0x0400328E RID: 12942
		OpMaxExt,
		// Token: 0x0400328F RID: 12943
		OpMinExt,
		// Token: 0x04003290 RID: 12944
		OpSetGeExt,
		// Token: 0x04003291 RID: 12945
		OpSetLtExt,
		// Token: 0x04003292 RID: 12946
		OpClampExt,
		// Token: 0x04003293 RID: 12947
		OpFloorExt,
		// Token: 0x04003294 RID: 12948
		OpRoundExt,
		// Token: 0x04003295 RID: 12949
		OpExpBase2Ext,
		// Token: 0x04003296 RID: 12950
		OpLogBase2Ext,
		// Token: 0x04003297 RID: 12951
		OpPowerExt,
		// Token: 0x04003298 RID: 12952
		OpRecipExt,
		// Token: 0x04003299 RID: 12953
		OpRecipSqrtExt,
		// Token: 0x0400329A RID: 12954
		OpSubExt,
		// Token: 0x0400329B RID: 12955
		OpCrossProductExt,
		// Token: 0x0400329C RID: 12956
		OpMultiplyMatrixExt,
		// Token: 0x0400329D RID: 12957
		OpMovExt,
		// Token: 0x0400329E RID: 12958
		OutputVertexExt,
		// Token: 0x0400329F RID: 12959
		OutputColor0Ext,
		// Token: 0x040032A0 RID: 12960
		OutputColor1Ext,
		// Token: 0x040032A1 RID: 12961
		OutputTextureCoord0Ext,
		// Token: 0x040032A2 RID: 12962
		OutputTextureCoord1Ext,
		// Token: 0x040032A3 RID: 12963
		OutputTextureCoord2Ext,
		// Token: 0x040032A4 RID: 12964
		OutputTextureCoord3Ext,
		// Token: 0x040032A5 RID: 12965
		OutputTextureCoord4Ext,
		// Token: 0x040032A6 RID: 12966
		OutputTextureCoord5Ext,
		// Token: 0x040032A7 RID: 12967
		OutputTextureCoord6Ext,
		// Token: 0x040032A8 RID: 12968
		OutputTextureCoord7Ext,
		// Token: 0x040032A9 RID: 12969
		OutputTextureCoord8Ext,
		// Token: 0x040032AA RID: 12970
		OutputTextureCoord9Ext,
		// Token: 0x040032AB RID: 12971
		OutputTextureCoord10Ext,
		// Token: 0x040032AC RID: 12972
		OutputTextureCoord11Ext,
		// Token: 0x040032AD RID: 12973
		OutputTextureCoord12Ext,
		// Token: 0x040032AE RID: 12974
		OutputTextureCoord13Ext,
		// Token: 0x040032AF RID: 12975
		OutputTextureCoord14Ext,
		// Token: 0x040032B0 RID: 12976
		OutputTextureCoord15Ext,
		// Token: 0x040032B1 RID: 12977
		OutputTextureCoord16Ext,
		// Token: 0x040032B2 RID: 12978
		OutputTextureCoord17Ext,
		// Token: 0x040032B3 RID: 12979
		OutputTextureCoord18Ext,
		// Token: 0x040032B4 RID: 12980
		OutputTextureCoord19Ext,
		// Token: 0x040032B5 RID: 12981
		OutputTextureCoord20Ext,
		// Token: 0x040032B6 RID: 12982
		OutputTextureCoord21Ext,
		// Token: 0x040032B7 RID: 12983
		OutputTextureCoord22Ext,
		// Token: 0x040032B8 RID: 12984
		OutputTextureCoord23Ext,
		// Token: 0x040032B9 RID: 12985
		OutputTextureCoord24Ext,
		// Token: 0x040032BA RID: 12986
		OutputTextureCoord25Ext,
		// Token: 0x040032BB RID: 12987
		OutputTextureCoord26Ext,
		// Token: 0x040032BC RID: 12988
		OutputTextureCoord27Ext,
		// Token: 0x040032BD RID: 12989
		OutputTextureCoord28Ext,
		// Token: 0x040032BE RID: 12990
		OutputTextureCoord29Ext,
		// Token: 0x040032BF RID: 12991
		OutputTextureCoord30Ext,
		// Token: 0x040032C0 RID: 12992
		OutputTextureCoord31Ext,
		// Token: 0x040032C1 RID: 12993
		OutputFogExt,
		// Token: 0x040032C2 RID: 12994
		ScalarExt,
		// Token: 0x040032C3 RID: 12995
		VectorExt,
		// Token: 0x040032C4 RID: 12996
		MatrixExt,
		// Token: 0x040032C5 RID: 12997
		VariantExt,
		// Token: 0x040032C6 RID: 12998
		InvariantExt,
		// Token: 0x040032C7 RID: 12999
		LocalConstantExt,
		// Token: 0x040032C8 RID: 13000
		LocalExt,
		// Token: 0x040032C9 RID: 13001
		MaxVertexShaderInstructionsExt,
		// Token: 0x040032CA RID: 13002
		MaxVertexShaderVariantsExt,
		// Token: 0x040032CB RID: 13003
		MaxVertexShaderInvariantsExt,
		// Token: 0x040032CC RID: 13004
		MaxVertexShaderLocalConstantsExt,
		// Token: 0x040032CD RID: 13005
		MaxVertexShaderLocalsExt,
		// Token: 0x040032CE RID: 13006
		MaxOptimizedVertexShaderInstructionsExt,
		// Token: 0x040032CF RID: 13007
		MaxOptimizedVertexShaderVariantsExt,
		// Token: 0x040032D0 RID: 13008
		MaxOptimizedVertexShaderLocalConstantsExt,
		// Token: 0x040032D1 RID: 13009
		MaxOptimizedVertexShaderInvariantsExt,
		// Token: 0x040032D2 RID: 13010
		MaxOptimizedVertexShaderLocalsExt,
		// Token: 0x040032D3 RID: 13011
		VertexShaderInstructionsExt,
		// Token: 0x040032D4 RID: 13012
		VertexShaderVariantsExt,
		// Token: 0x040032D5 RID: 13013
		VertexShaderInvariantsExt,
		// Token: 0x040032D6 RID: 13014
		VertexShaderLocalConstantsExt,
		// Token: 0x040032D7 RID: 13015
		VertexShaderLocalsExt,
		// Token: 0x040032D8 RID: 13016
		VertexShaderOptimizedExt,
		// Token: 0x040032D9 RID: 13017
		XExt,
		// Token: 0x040032DA RID: 13018
		YExt,
		// Token: 0x040032DB RID: 13019
		ZExt,
		// Token: 0x040032DC RID: 13020
		WExt,
		// Token: 0x040032DD RID: 13021
		NegativeXExt,
		// Token: 0x040032DE RID: 13022
		NegativeYExt,
		// Token: 0x040032DF RID: 13023
		NegativeZExt,
		// Token: 0x040032E0 RID: 13024
		NegativeWExt,
		// Token: 0x040032E1 RID: 13025
		ZeroExt,
		// Token: 0x040032E2 RID: 13026
		OneExt,
		// Token: 0x040032E3 RID: 13027
		NegativeOneExt,
		// Token: 0x040032E4 RID: 13028
		NormalizedRangeExt,
		// Token: 0x040032E5 RID: 13029
		FullRangeExt,
		// Token: 0x040032E6 RID: 13030
		CurrentVertexExt,
		// Token: 0x040032E7 RID: 13031
		MvpMatrixExt,
		// Token: 0x040032E8 RID: 13032
		VariantValueExt,
		// Token: 0x040032E9 RID: 13033
		VariantDatatypeExt,
		// Token: 0x040032EA RID: 13034
		VariantArrayStrideExt,
		// Token: 0x040032EB RID: 13035
		VariantArrayTypeExt,
		// Token: 0x040032EC RID: 13036
		VariantArrayExt,
		// Token: 0x040032ED RID: 13037
		VariantArrayPointerExt,
		// Token: 0x040032EE RID: 13038
		InvariantValueExt,
		// Token: 0x040032EF RID: 13039
		InvariantDatatypeExt,
		// Token: 0x040032F0 RID: 13040
		LocalConstantValueExt,
		// Token: 0x040032F1 RID: 13041
		LocalConstantDatatypeExt
	}
}
