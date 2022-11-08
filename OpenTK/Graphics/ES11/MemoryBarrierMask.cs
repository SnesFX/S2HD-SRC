using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A79 RID: 2681
	[Flags]
	public enum MemoryBarrierMask
	{
		// Token: 0x0400AF7C RID: 44924
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x0400AF7D RID: 44925
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x0400AF7E RID: 44926
		ElementArrayBarrierBit = 2,
		// Token: 0x0400AF7F RID: 44927
		ElementArrayBarrierBitExt = 2,
		// Token: 0x0400AF80 RID: 44928
		UniformBarrierBit = 4,
		// Token: 0x0400AF81 RID: 44929
		UniformBarrierBitExt = 4,
		// Token: 0x0400AF82 RID: 44930
		TextureFetchBarrierBit = 8,
		// Token: 0x0400AF83 RID: 44931
		TextureFetchBarrierBitExt = 8,
		// Token: 0x0400AF84 RID: 44932
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x0400AF85 RID: 44933
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x0400AF86 RID: 44934
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x0400AF87 RID: 44935
		CommandBarrierBit = 64,
		// Token: 0x0400AF88 RID: 44936
		CommandBarrierBitExt = 64,
		// Token: 0x0400AF89 RID: 44937
		PixelBufferBarrierBit = 128,
		// Token: 0x0400AF8A RID: 44938
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400AF8B RID: 44939
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400AF8C RID: 44940
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400AF8D RID: 44941
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400AF8E RID: 44942
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x0400AF8F RID: 44943
		FramebufferBarrierBit = 1024,
		// Token: 0x0400AF90 RID: 44944
		FramebufferBarrierBitExt = 1024,
		// Token: 0x0400AF91 RID: 44945
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400AF92 RID: 44946
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x0400AF93 RID: 44947
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400AF94 RID: 44948
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x0400AF95 RID: 44949
		ShaderStorageBarrierBit = 8192,
		// Token: 0x0400AF96 RID: 44950
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x0400AF97 RID: 44951
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400AF98 RID: 44952
		AllBarrierBits = -1,
		// Token: 0x0400AF99 RID: 44953
		AllBarrierBitsExt = -1
	}
}
