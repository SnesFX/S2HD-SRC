using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000348 RID: 840
	public enum FramebufferErrorCode
	{
		// Token: 0x0400337C RID: 13180
		FramebufferUndefined = 33305,
		// Token: 0x0400337D RID: 13181
		FramebufferComplete = 36053,
		// Token: 0x0400337E RID: 13182
		FramebufferCompleteExt = 36053,
		// Token: 0x0400337F RID: 13183
		FramebufferIncompleteAttachment,
		// Token: 0x04003380 RID: 13184
		FramebufferIncompleteAttachmentExt = 36054,
		// Token: 0x04003381 RID: 13185
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04003382 RID: 13186
		FramebufferIncompleteMissingAttachmentExt = 36055,
		// Token: 0x04003383 RID: 13187
		FramebufferIncompleteDimensionsExt = 36057,
		// Token: 0x04003384 RID: 13188
		FramebufferIncompleteFormatsExt,
		// Token: 0x04003385 RID: 13189
		FramebufferIncompleteDrawBuffer,
		// Token: 0x04003386 RID: 13190
		FramebufferIncompleteDrawBufferExt = 36059,
		// Token: 0x04003387 RID: 13191
		FramebufferIncompleteReadBuffer,
		// Token: 0x04003388 RID: 13192
		FramebufferIncompleteReadBufferExt = 36060,
		// Token: 0x04003389 RID: 13193
		FramebufferUnsupported,
		// Token: 0x0400338A RID: 13194
		FramebufferUnsupportedExt = 36061,
		// Token: 0x0400338B RID: 13195
		FramebufferIncompleteMultisample = 36182,
		// Token: 0x0400338C RID: 13196
		FramebufferIncompleteLayerTargets = 36264,
		// Token: 0x0400338D RID: 13197
		FramebufferIncompleteLayerCount
	}
}
