using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000394 RID: 916
	[Flags]
	public enum MemoryBarrierMask
	{
		// Token: 0x040039A1 RID: 14753
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x040039A2 RID: 14754
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x040039A3 RID: 14755
		ElementArrayBarrierBit = 2,
		// Token: 0x040039A4 RID: 14756
		ElementArrayBarrierBitExt = 2,
		// Token: 0x040039A5 RID: 14757
		UniformBarrierBit = 4,
		// Token: 0x040039A6 RID: 14758
		UniformBarrierBitExt = 4,
		// Token: 0x040039A7 RID: 14759
		TextureFetchBarrierBit = 8,
		// Token: 0x040039A8 RID: 14760
		TextureFetchBarrierBitExt = 8,
		// Token: 0x040039A9 RID: 14761
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x040039AA RID: 14762
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x040039AB RID: 14763
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x040039AC RID: 14764
		CommandBarrierBit = 64,
		// Token: 0x040039AD RID: 14765
		CommandBarrierBitExt = 64,
		// Token: 0x040039AE RID: 14766
		PixelBufferBarrierBit = 128,
		// Token: 0x040039AF RID: 14767
		PixelBufferBarrierBitExt = 128,
		// Token: 0x040039B0 RID: 14768
		TextureUpdateBarrierBit = 256,
		// Token: 0x040039B1 RID: 14769
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x040039B2 RID: 14770
		BufferUpdateBarrierBit = 512,
		// Token: 0x040039B3 RID: 14771
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x040039B4 RID: 14772
		FramebufferBarrierBit = 1024,
		// Token: 0x040039B5 RID: 14773
		FramebufferBarrierBitExt = 1024,
		// Token: 0x040039B6 RID: 14774
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x040039B7 RID: 14775
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x040039B8 RID: 14776
		AtomicCounterBarrierBit = 4096,
		// Token: 0x040039B9 RID: 14777
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x040039BA RID: 14778
		ShaderStorageBarrierBit = 8192,
		// Token: 0x040039BB RID: 14779
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x040039BC RID: 14780
		QueryBufferBarrierBit = 32768,
		// Token: 0x040039BD RID: 14781
		AllBarrierBits = -1,
		// Token: 0x040039BE RID: 14782
		AllBarrierBitsExt = -1
	}
}
