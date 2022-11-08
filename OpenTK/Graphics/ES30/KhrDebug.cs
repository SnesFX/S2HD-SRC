using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000824 RID: 2084
	public enum KhrDebug
	{
		// Token: 0x04008869 RID: 34921
		ContextFlagDebugBit = 2,
		// Token: 0x0400886A RID: 34922
		ContextFlagDebugBitKhr = 2,
		// Token: 0x0400886B RID: 34923
		StackOverflow = 1283,
		// Token: 0x0400886C RID: 34924
		StackOverflowKhr = 1283,
		// Token: 0x0400886D RID: 34925
		StackUnderflow,
		// Token: 0x0400886E RID: 34926
		StackUnderflowKhr = 1284,
		// Token: 0x0400886F RID: 34927
		VertexArray = 32884,
		// Token: 0x04008870 RID: 34928
		VertexArrayKhr = 32884,
		// Token: 0x04008871 RID: 34929
		DebugOutputSynchronous = 33346,
		// Token: 0x04008872 RID: 34930
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x04008873 RID: 34931
		DebugNextLoggedMessageLength,
		// Token: 0x04008874 RID: 34932
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x04008875 RID: 34933
		DebugCallbackFunction,
		// Token: 0x04008876 RID: 34934
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x04008877 RID: 34935
		DebugCallbackUserParam,
		// Token: 0x04008878 RID: 34936
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x04008879 RID: 34937
		DebugSourceApi,
		// Token: 0x0400887A RID: 34938
		DebugSourceApiKhr = 33350,
		// Token: 0x0400887B RID: 34939
		DebugSourceWindowSystem,
		// Token: 0x0400887C RID: 34940
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x0400887D RID: 34941
		DebugSourceShaderCompiler,
		// Token: 0x0400887E RID: 34942
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x0400887F RID: 34943
		DebugSourceThirdParty,
		// Token: 0x04008880 RID: 34944
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x04008881 RID: 34945
		DebugSourceApplication,
		// Token: 0x04008882 RID: 34946
		DebugSourceApplicationKhr = 33354,
		// Token: 0x04008883 RID: 34947
		DebugSourceOther,
		// Token: 0x04008884 RID: 34948
		DebugSourceOtherKhr = 33355,
		// Token: 0x04008885 RID: 34949
		DebugTypeError,
		// Token: 0x04008886 RID: 34950
		DebugTypeErrorKhr = 33356,
		// Token: 0x04008887 RID: 34951
		DebugTypeDeprecatedBehavior,
		// Token: 0x04008888 RID: 34952
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04008889 RID: 34953
		DebugTypeUndefinedBehavior,
		// Token: 0x0400888A RID: 34954
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x0400888B RID: 34955
		DebugTypePortability,
		// Token: 0x0400888C RID: 34956
		DebugTypePortabilityKhr = 33359,
		// Token: 0x0400888D RID: 34957
		DebugTypePerformance,
		// Token: 0x0400888E RID: 34958
		DebugTypePerformanceKhr = 33360,
		// Token: 0x0400888F RID: 34959
		DebugTypeOther,
		// Token: 0x04008890 RID: 34960
		DebugTypeOtherKhr = 33361,
		// Token: 0x04008891 RID: 34961
		DebugTypeMarker = 33384,
		// Token: 0x04008892 RID: 34962
		DebugTypeMarkerKhr = 33384,
		// Token: 0x04008893 RID: 34963
		DebugTypePushGroup,
		// Token: 0x04008894 RID: 34964
		DebugTypePushGroupKhr = 33385,
		// Token: 0x04008895 RID: 34965
		DebugTypePopGroup,
		// Token: 0x04008896 RID: 34966
		DebugTypePopGroupKhr = 33386,
		// Token: 0x04008897 RID: 34967
		DebugSeverityNotification,
		// Token: 0x04008898 RID: 34968
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x04008899 RID: 34969
		MaxDebugGroupStackDepth,
		// Token: 0x0400889A RID: 34970
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x0400889B RID: 34971
		DebugGroupStackDepth,
		// Token: 0x0400889C RID: 34972
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x0400889D RID: 34973
		Buffer = 33504,
		// Token: 0x0400889E RID: 34974
		BufferKhr = 33504,
		// Token: 0x0400889F RID: 34975
		Shader,
		// Token: 0x040088A0 RID: 34976
		ShaderKhr = 33505,
		// Token: 0x040088A1 RID: 34977
		Program,
		// Token: 0x040088A2 RID: 34978
		ProgramKhr = 33506,
		// Token: 0x040088A3 RID: 34979
		Query,
		// Token: 0x040088A4 RID: 34980
		QueryKhr = 33507,
		// Token: 0x040088A5 RID: 34981
		ProgramPipeline,
		// Token: 0x040088A6 RID: 34982
		Sampler = 33510,
		// Token: 0x040088A7 RID: 34983
		SamplerKhr = 33510,
		// Token: 0x040088A8 RID: 34984
		DisplayList,
		// Token: 0x040088A9 RID: 34985
		MaxLabelLength,
		// Token: 0x040088AA RID: 34986
		MaxLabelLengthKhr = 33512,
		// Token: 0x040088AB RID: 34987
		MaxDebugMessageLength = 37187,
		// Token: 0x040088AC RID: 34988
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x040088AD RID: 34989
		MaxDebugLoggedMessages,
		// Token: 0x040088AE RID: 34990
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x040088AF RID: 34991
		DebugLoggedMessages,
		// Token: 0x040088B0 RID: 34992
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x040088B1 RID: 34993
		DebugSeverityHigh,
		// Token: 0x040088B2 RID: 34994
		DebugSeverityHighKhr = 37190,
		// Token: 0x040088B3 RID: 34995
		DebugSeverityMedium,
		// Token: 0x040088B4 RID: 34996
		DebugSeverityMediumKhr = 37191,
		// Token: 0x040088B5 RID: 34997
		DebugSeverityLow,
		// Token: 0x040088B6 RID: 34998
		DebugSeverityLowKhr = 37192,
		// Token: 0x040088B7 RID: 34999
		DebugOutput = 37600,
		// Token: 0x040088B8 RID: 35000
		DebugOutputKhr = 37600
	}
}
