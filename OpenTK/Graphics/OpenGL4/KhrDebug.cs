using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006E0 RID: 1760
	public enum KhrDebug
	{
		// Token: 0x040069C9 RID: 27081
		ContextFlagDebugBit = 2,
		// Token: 0x040069CA RID: 27082
		ContextFlagDebugBitKhr = 2,
		// Token: 0x040069CB RID: 27083
		StackOverflow = 1283,
		// Token: 0x040069CC RID: 27084
		StackOverflowKhr = 1283,
		// Token: 0x040069CD RID: 27085
		StackUnderflow,
		// Token: 0x040069CE RID: 27086
		StackUnderflowKhr = 1284,
		// Token: 0x040069CF RID: 27087
		VertexArray = 32884,
		// Token: 0x040069D0 RID: 27088
		VertexArrayKhr = 32884,
		// Token: 0x040069D1 RID: 27089
		DebugOutputSynchronous = 33346,
		// Token: 0x040069D2 RID: 27090
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x040069D3 RID: 27091
		DebugNextLoggedMessageLength,
		// Token: 0x040069D4 RID: 27092
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x040069D5 RID: 27093
		DebugCallbackFunction,
		// Token: 0x040069D6 RID: 27094
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x040069D7 RID: 27095
		DebugCallbackUserParam,
		// Token: 0x040069D8 RID: 27096
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x040069D9 RID: 27097
		DebugSourceApi,
		// Token: 0x040069DA RID: 27098
		DebugSourceApiKhr = 33350,
		// Token: 0x040069DB RID: 27099
		DebugSourceWindowSystem,
		// Token: 0x040069DC RID: 27100
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x040069DD RID: 27101
		DebugSourceShaderCompiler,
		// Token: 0x040069DE RID: 27102
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x040069DF RID: 27103
		DebugSourceThirdParty,
		// Token: 0x040069E0 RID: 27104
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x040069E1 RID: 27105
		DebugSourceApplication,
		// Token: 0x040069E2 RID: 27106
		DebugSourceApplicationKhr = 33354,
		// Token: 0x040069E3 RID: 27107
		DebugSourceOther,
		// Token: 0x040069E4 RID: 27108
		DebugSourceOtherKhr = 33355,
		// Token: 0x040069E5 RID: 27109
		DebugTypeError,
		// Token: 0x040069E6 RID: 27110
		DebugTypeErrorKhr = 33356,
		// Token: 0x040069E7 RID: 27111
		DebugTypeDeprecatedBehavior,
		// Token: 0x040069E8 RID: 27112
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x040069E9 RID: 27113
		DebugTypeUndefinedBehavior,
		// Token: 0x040069EA RID: 27114
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x040069EB RID: 27115
		DebugTypePortability,
		// Token: 0x040069EC RID: 27116
		DebugTypePortabilityKhr = 33359,
		// Token: 0x040069ED RID: 27117
		DebugTypePerformance,
		// Token: 0x040069EE RID: 27118
		DebugTypePerformanceKhr = 33360,
		// Token: 0x040069EF RID: 27119
		DebugTypeOther,
		// Token: 0x040069F0 RID: 27120
		DebugTypeOtherKhr = 33361,
		// Token: 0x040069F1 RID: 27121
		DebugTypeMarker = 33384,
		// Token: 0x040069F2 RID: 27122
		DebugTypeMarkerKhr = 33384,
		// Token: 0x040069F3 RID: 27123
		DebugTypePushGroup,
		// Token: 0x040069F4 RID: 27124
		DebugTypePushGroupKhr = 33385,
		// Token: 0x040069F5 RID: 27125
		DebugTypePopGroup,
		// Token: 0x040069F6 RID: 27126
		DebugTypePopGroupKhr = 33386,
		// Token: 0x040069F7 RID: 27127
		DebugSeverityNotification,
		// Token: 0x040069F8 RID: 27128
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x040069F9 RID: 27129
		MaxDebugGroupStackDepth,
		// Token: 0x040069FA RID: 27130
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x040069FB RID: 27131
		DebugGroupStackDepth,
		// Token: 0x040069FC RID: 27132
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x040069FD RID: 27133
		Buffer = 33504,
		// Token: 0x040069FE RID: 27134
		BufferKhr = 33504,
		// Token: 0x040069FF RID: 27135
		Shader,
		// Token: 0x04006A00 RID: 27136
		ShaderKhr = 33505,
		// Token: 0x04006A01 RID: 27137
		Program,
		// Token: 0x04006A02 RID: 27138
		ProgramKhr = 33506,
		// Token: 0x04006A03 RID: 27139
		Query,
		// Token: 0x04006A04 RID: 27140
		QueryKhr = 33507,
		// Token: 0x04006A05 RID: 27141
		ProgramPipeline,
		// Token: 0x04006A06 RID: 27142
		Sampler = 33510,
		// Token: 0x04006A07 RID: 27143
		SamplerKhr = 33510,
		// Token: 0x04006A08 RID: 27144
		DisplayList,
		// Token: 0x04006A09 RID: 27145
		MaxLabelLength,
		// Token: 0x04006A0A RID: 27146
		MaxLabelLengthKhr = 33512,
		// Token: 0x04006A0B RID: 27147
		MaxDebugMessageLength = 37187,
		// Token: 0x04006A0C RID: 27148
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04006A0D RID: 27149
		MaxDebugLoggedMessages,
		// Token: 0x04006A0E RID: 27150
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04006A0F RID: 27151
		DebugLoggedMessages,
		// Token: 0x04006A10 RID: 27152
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x04006A11 RID: 27153
		DebugSeverityHigh,
		// Token: 0x04006A12 RID: 27154
		DebugSeverityHighKhr = 37190,
		// Token: 0x04006A13 RID: 27155
		DebugSeverityMedium,
		// Token: 0x04006A14 RID: 27156
		DebugSeverityMediumKhr = 37191,
		// Token: 0x04006A15 RID: 27157
		DebugSeverityLow,
		// Token: 0x04006A16 RID: 27158
		DebugSeverityLowKhr = 37192,
		// Token: 0x04006A17 RID: 27159
		DebugOutput = 37600,
		// Token: 0x04006A18 RID: 27160
		DebugOutputKhr = 37600
	}
}
