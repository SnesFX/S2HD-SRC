using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200037F RID: 895
	public enum KhrDebug
	{
		// Token: 0x04003856 RID: 14422
		ContextFlagDebugBit = 2,
		// Token: 0x04003857 RID: 14423
		ContextFlagDebugBitKhr = 2,
		// Token: 0x04003858 RID: 14424
		StackOverflow = 1283,
		// Token: 0x04003859 RID: 14425
		StackOverflowKhr = 1283,
		// Token: 0x0400385A RID: 14426
		StackUnderflow,
		// Token: 0x0400385B RID: 14427
		StackUnderflowKhr = 1284,
		// Token: 0x0400385C RID: 14428
		VertexArray = 32884,
		// Token: 0x0400385D RID: 14429
		VertexArrayKhr = 32884,
		// Token: 0x0400385E RID: 14430
		DebugOutputSynchronous = 33346,
		// Token: 0x0400385F RID: 14431
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x04003860 RID: 14432
		DebugNextLoggedMessageLength,
		// Token: 0x04003861 RID: 14433
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x04003862 RID: 14434
		DebugCallbackFunction,
		// Token: 0x04003863 RID: 14435
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x04003864 RID: 14436
		DebugCallbackUserParam,
		// Token: 0x04003865 RID: 14437
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x04003866 RID: 14438
		DebugSourceApi,
		// Token: 0x04003867 RID: 14439
		DebugSourceApiKhr = 33350,
		// Token: 0x04003868 RID: 14440
		DebugSourceWindowSystem,
		// Token: 0x04003869 RID: 14441
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x0400386A RID: 14442
		DebugSourceShaderCompiler,
		// Token: 0x0400386B RID: 14443
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x0400386C RID: 14444
		DebugSourceThirdParty,
		// Token: 0x0400386D RID: 14445
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x0400386E RID: 14446
		DebugSourceApplication,
		// Token: 0x0400386F RID: 14447
		DebugSourceApplicationKhr = 33354,
		// Token: 0x04003870 RID: 14448
		DebugSourceOther,
		// Token: 0x04003871 RID: 14449
		DebugSourceOtherKhr = 33355,
		// Token: 0x04003872 RID: 14450
		DebugTypeError,
		// Token: 0x04003873 RID: 14451
		DebugTypeErrorKhr = 33356,
		// Token: 0x04003874 RID: 14452
		DebugTypeDeprecatedBehavior,
		// Token: 0x04003875 RID: 14453
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04003876 RID: 14454
		DebugTypeUndefinedBehavior,
		// Token: 0x04003877 RID: 14455
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x04003878 RID: 14456
		DebugTypePortability,
		// Token: 0x04003879 RID: 14457
		DebugTypePortabilityKhr = 33359,
		// Token: 0x0400387A RID: 14458
		DebugTypePerformance,
		// Token: 0x0400387B RID: 14459
		DebugTypePerformanceKhr = 33360,
		// Token: 0x0400387C RID: 14460
		DebugTypeOther,
		// Token: 0x0400387D RID: 14461
		DebugTypeOtherKhr = 33361,
		// Token: 0x0400387E RID: 14462
		DebugTypeMarker = 33384,
		// Token: 0x0400387F RID: 14463
		DebugTypeMarkerKhr = 33384,
		// Token: 0x04003880 RID: 14464
		DebugTypePushGroup,
		// Token: 0x04003881 RID: 14465
		DebugTypePushGroupKhr = 33385,
		// Token: 0x04003882 RID: 14466
		DebugTypePopGroup,
		// Token: 0x04003883 RID: 14467
		DebugTypePopGroupKhr = 33386,
		// Token: 0x04003884 RID: 14468
		DebugSeverityNotification,
		// Token: 0x04003885 RID: 14469
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x04003886 RID: 14470
		MaxDebugGroupStackDepth,
		// Token: 0x04003887 RID: 14471
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x04003888 RID: 14472
		DebugGroupStackDepth,
		// Token: 0x04003889 RID: 14473
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x0400388A RID: 14474
		Buffer = 33504,
		// Token: 0x0400388B RID: 14475
		BufferKhr = 33504,
		// Token: 0x0400388C RID: 14476
		Shader,
		// Token: 0x0400388D RID: 14477
		ShaderKhr = 33505,
		// Token: 0x0400388E RID: 14478
		Program,
		// Token: 0x0400388F RID: 14479
		ProgramKhr = 33506,
		// Token: 0x04003890 RID: 14480
		Query,
		// Token: 0x04003891 RID: 14481
		QueryKhr = 33507,
		// Token: 0x04003892 RID: 14482
		ProgramPipeline,
		// Token: 0x04003893 RID: 14483
		Sampler = 33510,
		// Token: 0x04003894 RID: 14484
		SamplerKhr = 33510,
		// Token: 0x04003895 RID: 14485
		DisplayList,
		// Token: 0x04003896 RID: 14486
		MaxLabelLength,
		// Token: 0x04003897 RID: 14487
		MaxLabelLengthKhr = 33512,
		// Token: 0x04003898 RID: 14488
		MaxDebugMessageLength = 37187,
		// Token: 0x04003899 RID: 14489
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x0400389A RID: 14490
		MaxDebugLoggedMessages,
		// Token: 0x0400389B RID: 14491
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x0400389C RID: 14492
		DebugLoggedMessages,
		// Token: 0x0400389D RID: 14493
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x0400389E RID: 14494
		DebugSeverityHigh,
		// Token: 0x0400389F RID: 14495
		DebugSeverityHighKhr = 37190,
		// Token: 0x040038A0 RID: 14496
		DebugSeverityMedium,
		// Token: 0x040038A1 RID: 14497
		DebugSeverityMediumKhr = 37191,
		// Token: 0x040038A2 RID: 14498
		DebugSeverityLow,
		// Token: 0x040038A3 RID: 14499
		DebugSeverityLowKhr = 37192,
		// Token: 0x040038A4 RID: 14500
		DebugOutput = 37600,
		// Token: 0x040038A5 RID: 14501
		DebugOutputKhr = 37600
	}
}
