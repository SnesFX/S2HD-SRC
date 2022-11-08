using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000622 RID: 1570
	public enum ArbFramebufferObject
	{
		// Token: 0x0400601E RID: 24606
		InvalidFramebufferOperation = 1286,
		// Token: 0x0400601F RID: 24607
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x04006020 RID: 24608
		FramebufferAttachmentComponentType,
		// Token: 0x04006021 RID: 24609
		FramebufferAttachmentRedSize,
		// Token: 0x04006022 RID: 24610
		FramebufferAttachmentGreenSize,
		// Token: 0x04006023 RID: 24611
		FramebufferAttachmentBlueSize,
		// Token: 0x04006024 RID: 24612
		FramebufferAttachmentAlphaSize,
		// Token: 0x04006025 RID: 24613
		FramebufferAttachmentDepthSize,
		// Token: 0x04006026 RID: 24614
		FramebufferAttachmentStencilSize,
		// Token: 0x04006027 RID: 24615
		FramebufferDefault,
		// Token: 0x04006028 RID: 24616
		FramebufferUndefined,
		// Token: 0x04006029 RID: 24617
		DepthStencilAttachment,
		// Token: 0x0400602A RID: 24618
		Index = 33314,
		// Token: 0x0400602B RID: 24619
		MaxRenderbufferSize = 34024,
		// Token: 0x0400602C RID: 24620
		DepthStencil = 34041,
		// Token: 0x0400602D RID: 24621
		UnsignedInt248,
		// Token: 0x0400602E RID: 24622
		Depth24Stencil8 = 35056,
		// Token: 0x0400602F RID: 24623
		TextureStencilSize,
		// Token: 0x04006030 RID: 24624
		TextureRedType = 35856,
		// Token: 0x04006031 RID: 24625
		TextureGreenType,
		// Token: 0x04006032 RID: 24626
		TextureBlueType,
		// Token: 0x04006033 RID: 24627
		TextureAlphaType,
		// Token: 0x04006034 RID: 24628
		TextureDepthType = 35862,
		// Token: 0x04006035 RID: 24629
		UnsignedNormalized,
		// Token: 0x04006036 RID: 24630
		DrawFramebufferBinding = 36006,
		// Token: 0x04006037 RID: 24631
		FramebufferBinding = 36006,
		// Token: 0x04006038 RID: 24632
		RenderbufferBinding,
		// Token: 0x04006039 RID: 24633
		ReadFramebuffer,
		// Token: 0x0400603A RID: 24634
		DrawFramebuffer,
		// Token: 0x0400603B RID: 24635
		ReadFramebufferBinding,
		// Token: 0x0400603C RID: 24636
		RenderbufferSamples,
		// Token: 0x0400603D RID: 24637
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x0400603E RID: 24638
		FramebufferAttachmentObjectName,
		// Token: 0x0400603F RID: 24639
		FramebufferAttachmentTextureLevel,
		// Token: 0x04006040 RID: 24640
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x04006041 RID: 24641
		FramebufferAttachmentTextureLayer,
		// Token: 0x04006042 RID: 24642
		FramebufferComplete,
		// Token: 0x04006043 RID: 24643
		FramebufferIncompleteAttachment,
		// Token: 0x04006044 RID: 24644
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04006045 RID: 24645
		FramebufferIncompleteDrawBuffer = 36059,
		// Token: 0x04006046 RID: 24646
		FramebufferIncompleteReadBuffer,
		// Token: 0x04006047 RID: 24647
		FramebufferUnsupported,
		// Token: 0x04006048 RID: 24648
		MaxColorAttachments = 36063,
		// Token: 0x04006049 RID: 24649
		ColorAttachment0,
		// Token: 0x0400604A RID: 24650
		ColorAttachment1,
		// Token: 0x0400604B RID: 24651
		ColorAttachment2,
		// Token: 0x0400604C RID: 24652
		ColorAttachment3,
		// Token: 0x0400604D RID: 24653
		ColorAttachment4,
		// Token: 0x0400604E RID: 24654
		ColorAttachment5,
		// Token: 0x0400604F RID: 24655
		ColorAttachment6,
		// Token: 0x04006050 RID: 24656
		ColorAttachment7,
		// Token: 0x04006051 RID: 24657
		ColorAttachment8,
		// Token: 0x04006052 RID: 24658
		ColorAttachment9,
		// Token: 0x04006053 RID: 24659
		ColorAttachment10,
		// Token: 0x04006054 RID: 24660
		ColorAttachment11,
		// Token: 0x04006055 RID: 24661
		ColorAttachment12,
		// Token: 0x04006056 RID: 24662
		ColorAttachment13,
		// Token: 0x04006057 RID: 24663
		ColorAttachment14,
		// Token: 0x04006058 RID: 24664
		ColorAttachment15,
		// Token: 0x04006059 RID: 24665
		DepthAttachment = 36096,
		// Token: 0x0400605A RID: 24666
		StencilAttachment = 36128,
		// Token: 0x0400605B RID: 24667
		Framebuffer = 36160,
		// Token: 0x0400605C RID: 24668
		Renderbuffer,
		// Token: 0x0400605D RID: 24669
		RenderbufferWidth,
		// Token: 0x0400605E RID: 24670
		RenderbufferHeight,
		// Token: 0x0400605F RID: 24671
		RenderbufferInternalFormat,
		// Token: 0x04006060 RID: 24672
		StencilIndex1 = 36166,
		// Token: 0x04006061 RID: 24673
		StencilIndex4,
		// Token: 0x04006062 RID: 24674
		StencilIndex8,
		// Token: 0x04006063 RID: 24675
		StencilIndex16,
		// Token: 0x04006064 RID: 24676
		RenderbufferRedSize = 36176,
		// Token: 0x04006065 RID: 24677
		RenderbufferGreenSize,
		// Token: 0x04006066 RID: 24678
		RenderbufferBlueSize,
		// Token: 0x04006067 RID: 24679
		RenderbufferAlphaSize,
		// Token: 0x04006068 RID: 24680
		RenderbufferDepthSize,
		// Token: 0x04006069 RID: 24681
		RenderbufferStencilSize,
		// Token: 0x0400606A RID: 24682
		FramebufferIncompleteMultisample,
		// Token: 0x0400606B RID: 24683
		MaxSamples
	}
}
