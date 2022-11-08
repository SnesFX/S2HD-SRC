using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000971 RID: 2417
	public enum KhrDebug
	{
		// Token: 0x04009EF3 RID: 40691
		ContextFlagDebugBit = 2,
		// Token: 0x04009EF4 RID: 40692
		ContextFlagDebugBitKhr = 2,
		// Token: 0x04009EF5 RID: 40693
		StackOverflow = 1283,
		// Token: 0x04009EF6 RID: 40694
		StackOverflowKhr = 1283,
		// Token: 0x04009EF7 RID: 40695
		StackUnderflow,
		// Token: 0x04009EF8 RID: 40696
		StackUnderflowKhr = 1284,
		// Token: 0x04009EF9 RID: 40697
		VertexArray = 32884,
		// Token: 0x04009EFA RID: 40698
		VertexArrayKhr = 32884,
		// Token: 0x04009EFB RID: 40699
		DebugOutputSynchronous = 33346,
		// Token: 0x04009EFC RID: 40700
		DebugOutputSynchronousKhr = 33346,
		// Token: 0x04009EFD RID: 40701
		DebugNextLoggedMessageLength,
		// Token: 0x04009EFE RID: 40702
		DebugNextLoggedMessageLengthKhr = 33347,
		// Token: 0x04009EFF RID: 40703
		DebugCallbackFunction,
		// Token: 0x04009F00 RID: 40704
		DebugCallbackFunctionKhr = 33348,
		// Token: 0x04009F01 RID: 40705
		DebugCallbackUserParam,
		// Token: 0x04009F02 RID: 40706
		DebugCallbackUserParamKhr = 33349,
		// Token: 0x04009F03 RID: 40707
		DebugSourceApi,
		// Token: 0x04009F04 RID: 40708
		DebugSourceApiKhr = 33350,
		// Token: 0x04009F05 RID: 40709
		DebugSourceWindowSystem,
		// Token: 0x04009F06 RID: 40710
		DebugSourceWindowSystemKhr = 33351,
		// Token: 0x04009F07 RID: 40711
		DebugSourceShaderCompiler,
		// Token: 0x04009F08 RID: 40712
		DebugSourceShaderCompilerKhr = 33352,
		// Token: 0x04009F09 RID: 40713
		DebugSourceThirdParty,
		// Token: 0x04009F0A RID: 40714
		DebugSourceThirdPartyKhr = 33353,
		// Token: 0x04009F0B RID: 40715
		DebugSourceApplication,
		// Token: 0x04009F0C RID: 40716
		DebugSourceApplicationKhr = 33354,
		// Token: 0x04009F0D RID: 40717
		DebugSourceOther,
		// Token: 0x04009F0E RID: 40718
		DebugSourceOtherKhr = 33355,
		// Token: 0x04009F0F RID: 40719
		DebugTypeError,
		// Token: 0x04009F10 RID: 40720
		DebugTypeErrorKhr = 33356,
		// Token: 0x04009F11 RID: 40721
		DebugTypeDeprecatedBehavior,
		// Token: 0x04009F12 RID: 40722
		DebugTypeDeprecatedBehaviorKhr = 33357,
		// Token: 0x04009F13 RID: 40723
		DebugTypeUndefinedBehavior,
		// Token: 0x04009F14 RID: 40724
		DebugTypeUndefinedBehaviorKhr = 33358,
		// Token: 0x04009F15 RID: 40725
		DebugTypePortability,
		// Token: 0x04009F16 RID: 40726
		DebugTypePortabilityKhr = 33359,
		// Token: 0x04009F17 RID: 40727
		DebugTypePerformance,
		// Token: 0x04009F18 RID: 40728
		DebugTypePerformanceKhr = 33360,
		// Token: 0x04009F19 RID: 40729
		DebugTypeOther,
		// Token: 0x04009F1A RID: 40730
		DebugTypeOtherKhr = 33361,
		// Token: 0x04009F1B RID: 40731
		DebugTypeMarker = 33384,
		// Token: 0x04009F1C RID: 40732
		DebugTypeMarkerKhr = 33384,
		// Token: 0x04009F1D RID: 40733
		DebugTypePushGroup,
		// Token: 0x04009F1E RID: 40734
		DebugTypePushGroupKhr = 33385,
		// Token: 0x04009F1F RID: 40735
		DebugTypePopGroup,
		// Token: 0x04009F20 RID: 40736
		DebugTypePopGroupKhr = 33386,
		// Token: 0x04009F21 RID: 40737
		DebugSeverityNotification,
		// Token: 0x04009F22 RID: 40738
		DebugSeverityNotificationKhr = 33387,
		// Token: 0x04009F23 RID: 40739
		MaxDebugGroupStackDepth,
		// Token: 0x04009F24 RID: 40740
		MaxDebugGroupStackDepthKhr = 33388,
		// Token: 0x04009F25 RID: 40741
		DebugGroupStackDepth,
		// Token: 0x04009F26 RID: 40742
		DebugGroupStackDepthKhr = 33389,
		// Token: 0x04009F27 RID: 40743
		Buffer = 33504,
		// Token: 0x04009F28 RID: 40744
		BufferKhr = 33504,
		// Token: 0x04009F29 RID: 40745
		Shader,
		// Token: 0x04009F2A RID: 40746
		ShaderKhr = 33505,
		// Token: 0x04009F2B RID: 40747
		Program,
		// Token: 0x04009F2C RID: 40748
		ProgramKhr = 33506,
		// Token: 0x04009F2D RID: 40749
		Query,
		// Token: 0x04009F2E RID: 40750
		QueryKhr = 33507,
		// Token: 0x04009F2F RID: 40751
		ProgramPipeline,
		// Token: 0x04009F30 RID: 40752
		Sampler = 33510,
		// Token: 0x04009F31 RID: 40753
		SamplerKhr = 33510,
		// Token: 0x04009F32 RID: 40754
		DisplayList,
		// Token: 0x04009F33 RID: 40755
		MaxLabelLength,
		// Token: 0x04009F34 RID: 40756
		MaxLabelLengthKhr = 33512,
		// Token: 0x04009F35 RID: 40757
		MaxDebugMessageLength = 37187,
		// Token: 0x04009F36 RID: 40758
		MaxDebugMessageLengthKhr = 37187,
		// Token: 0x04009F37 RID: 40759
		MaxDebugLoggedMessages,
		// Token: 0x04009F38 RID: 40760
		MaxDebugLoggedMessagesKhr = 37188,
		// Token: 0x04009F39 RID: 40761
		DebugLoggedMessages,
		// Token: 0x04009F3A RID: 40762
		DebugLoggedMessagesKhr = 37189,
		// Token: 0x04009F3B RID: 40763
		DebugSeverityHigh,
		// Token: 0x04009F3C RID: 40764
		DebugSeverityHighKhr = 37190,
		// Token: 0x04009F3D RID: 40765
		DebugSeverityMedium,
		// Token: 0x04009F3E RID: 40766
		DebugSeverityMediumKhr = 37191,
		// Token: 0x04009F3F RID: 40767
		DebugSeverityLow,
		// Token: 0x04009F40 RID: 40768
		DebugSeverityLowKhr = 37192,
		// Token: 0x04009F41 RID: 40769
		DebugOutput = 37600,
		// Token: 0x04009F42 RID: 40770
		DebugOutputKhr = 37600
	}
}
