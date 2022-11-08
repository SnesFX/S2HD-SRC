using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006BF RID: 1727
	public enum FramebufferErrorCode
	{
		// Token: 0x0400660B RID: 26123
		FramebufferUndefined = 33305,
		// Token: 0x0400660C RID: 26124
		FramebufferComplete = 36053,
		// Token: 0x0400660D RID: 26125
		FramebufferCompleteExt = 36053,
		// Token: 0x0400660E RID: 26126
		FramebufferIncompleteAttachment,
		// Token: 0x0400660F RID: 26127
		FramebufferIncompleteAttachmentExt = 36054,
		// Token: 0x04006610 RID: 26128
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04006611 RID: 26129
		FramebufferIncompleteMissingAttachmentExt = 36055,
		// Token: 0x04006612 RID: 26130
		FramebufferIncompleteDimensionsExt = 36057,
		// Token: 0x04006613 RID: 26131
		FramebufferIncompleteFormatsExt,
		// Token: 0x04006614 RID: 26132
		FramebufferIncompleteDrawBuffer,
		// Token: 0x04006615 RID: 26133
		FramebufferIncompleteDrawBufferExt = 36059,
		// Token: 0x04006616 RID: 26134
		FramebufferIncompleteReadBuffer,
		// Token: 0x04006617 RID: 26135
		FramebufferIncompleteReadBufferExt = 36060,
		// Token: 0x04006618 RID: 26136
		FramebufferUnsupported,
		// Token: 0x04006619 RID: 26137
		FramebufferUnsupportedExt = 36061,
		// Token: 0x0400661A RID: 26138
		FramebufferIncompleteMultisample = 36182,
		// Token: 0x0400661B RID: 26139
		FramebufferIncompleteLayerTargets = 36264,
		// Token: 0x0400661C RID: 26140
		FramebufferIncompleteLayerCount
	}
}
