using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200021A RID: 538
	public enum ArbFramebufferObject
	{
		// Token: 0x04002731 RID: 10033
		InvalidFramebufferOperation = 1286,
		// Token: 0x04002732 RID: 10034
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x04002733 RID: 10035
		FramebufferAttachmentComponentType,
		// Token: 0x04002734 RID: 10036
		FramebufferAttachmentRedSize,
		// Token: 0x04002735 RID: 10037
		FramebufferAttachmentGreenSize,
		// Token: 0x04002736 RID: 10038
		FramebufferAttachmentBlueSize,
		// Token: 0x04002737 RID: 10039
		FramebufferAttachmentAlphaSize,
		// Token: 0x04002738 RID: 10040
		FramebufferAttachmentDepthSize,
		// Token: 0x04002739 RID: 10041
		FramebufferAttachmentStencilSize,
		// Token: 0x0400273A RID: 10042
		FramebufferDefault,
		// Token: 0x0400273B RID: 10043
		FramebufferUndefined,
		// Token: 0x0400273C RID: 10044
		DepthStencilAttachment,
		// Token: 0x0400273D RID: 10045
		Index = 33314,
		// Token: 0x0400273E RID: 10046
		MaxRenderbufferSize = 34024,
		// Token: 0x0400273F RID: 10047
		DepthStencil = 34041,
		// Token: 0x04002740 RID: 10048
		UnsignedInt248,
		// Token: 0x04002741 RID: 10049
		Depth24Stencil8 = 35056,
		// Token: 0x04002742 RID: 10050
		TextureStencilSize,
		// Token: 0x04002743 RID: 10051
		TextureRedType = 35856,
		// Token: 0x04002744 RID: 10052
		TextureGreenType,
		// Token: 0x04002745 RID: 10053
		TextureBlueType,
		// Token: 0x04002746 RID: 10054
		TextureAlphaType,
		// Token: 0x04002747 RID: 10055
		TextureLuminanceType,
		// Token: 0x04002748 RID: 10056
		TextureIntensityType,
		// Token: 0x04002749 RID: 10057
		TextureDepthType,
		// Token: 0x0400274A RID: 10058
		UnsignedNormalized,
		// Token: 0x0400274B RID: 10059
		DrawFramebufferBinding = 36006,
		// Token: 0x0400274C RID: 10060
		FramebufferBinding = 36006,
		// Token: 0x0400274D RID: 10061
		RenderbufferBinding,
		// Token: 0x0400274E RID: 10062
		ReadFramebuffer,
		// Token: 0x0400274F RID: 10063
		DrawFramebuffer,
		// Token: 0x04002750 RID: 10064
		ReadFramebufferBinding,
		// Token: 0x04002751 RID: 10065
		RenderbufferSamples,
		// Token: 0x04002752 RID: 10066
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04002753 RID: 10067
		FramebufferAttachmentObjectName,
		// Token: 0x04002754 RID: 10068
		FramebufferAttachmentTextureLevel,
		// Token: 0x04002755 RID: 10069
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04002756 RID: 10070
		FramebufferAttachmentTextureLayer,
		// Token: 0x04002757 RID: 10071
		FramebufferComplete,
		// Token: 0x04002758 RID: 10072
		FramebufferIncompleteAttachment,
		// Token: 0x04002759 RID: 10073
		FramebufferIncompleteMissingAttachment,
		// Token: 0x0400275A RID: 10074
		FramebufferIncompleteDrawBuffer = 36059,
		// Token: 0x0400275B RID: 10075
		FramebufferIncompleteReadBuffer,
		// Token: 0x0400275C RID: 10076
		FramebufferUnsupported,
		// Token: 0x0400275D RID: 10077
		MaxColorAttachments = 36063,
		// Token: 0x0400275E RID: 10078
		ColorAttachment0,
		// Token: 0x0400275F RID: 10079
		ColorAttachment1,
		// Token: 0x04002760 RID: 10080
		ColorAttachment2,
		// Token: 0x04002761 RID: 10081
		ColorAttachment3,
		// Token: 0x04002762 RID: 10082
		ColorAttachment4,
		// Token: 0x04002763 RID: 10083
		ColorAttachment5,
		// Token: 0x04002764 RID: 10084
		ColorAttachment6,
		// Token: 0x04002765 RID: 10085
		ColorAttachment7,
		// Token: 0x04002766 RID: 10086
		ColorAttachment8,
		// Token: 0x04002767 RID: 10087
		ColorAttachment9,
		// Token: 0x04002768 RID: 10088
		ColorAttachment10,
		// Token: 0x04002769 RID: 10089
		ColorAttachment11,
		// Token: 0x0400276A RID: 10090
		ColorAttachment12,
		// Token: 0x0400276B RID: 10091
		ColorAttachment13,
		// Token: 0x0400276C RID: 10092
		ColorAttachment14,
		// Token: 0x0400276D RID: 10093
		ColorAttachment15,
		// Token: 0x0400276E RID: 10094
		DepthAttachment = 36096,
		// Token: 0x0400276F RID: 10095
		StencilAttachment = 36128,
		// Token: 0x04002770 RID: 10096
		Framebuffer = 36160,
		// Token: 0x04002771 RID: 10097
		Renderbuffer,
		// Token: 0x04002772 RID: 10098
		RenderbufferWidth,
		// Token: 0x04002773 RID: 10099
		RenderbufferHeight,
		// Token: 0x04002774 RID: 10100
		RenderbufferInternalFormat,
		// Token: 0x04002775 RID: 10101
		StencilIndex1 = 36166,
		// Token: 0x04002776 RID: 10102
		StencilIndex4,
		// Token: 0x04002777 RID: 10103
		StencilIndex8,
		// Token: 0x04002778 RID: 10104
		StencilIndex16,
		// Token: 0x04002779 RID: 10105
		RenderbufferRedSize = 36176,
		// Token: 0x0400277A RID: 10106
		RenderbufferGreenSize,
		// Token: 0x0400277B RID: 10107
		RenderbufferBlueSize,
		// Token: 0x0400277C RID: 10108
		RenderbufferAlphaSize,
		// Token: 0x0400277D RID: 10109
		RenderbufferDepthSize,
		// Token: 0x0400277E RID: 10110
		RenderbufferStencilSize,
		// Token: 0x0400277F RID: 10111
		FramebufferIncompleteMultisample,
		// Token: 0x04002780 RID: 10112
		MaxSamples
	}
}
