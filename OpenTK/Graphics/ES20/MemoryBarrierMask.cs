using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000984 RID: 2436
	[Flags]
	public enum MemoryBarrierMask
	{
		// Token: 0x0400A007 RID: 40967
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x0400A008 RID: 40968
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x0400A009 RID: 40969
		ElementArrayBarrierBit = 2,
		// Token: 0x0400A00A RID: 40970
		ElementArrayBarrierBitExt = 2,
		// Token: 0x0400A00B RID: 40971
		UniformBarrierBit = 4,
		// Token: 0x0400A00C RID: 40972
		UniformBarrierBitExt = 4,
		// Token: 0x0400A00D RID: 40973
		TextureFetchBarrierBit = 8,
		// Token: 0x0400A00E RID: 40974
		TextureFetchBarrierBitExt = 8,
		// Token: 0x0400A00F RID: 40975
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x0400A010 RID: 40976
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x0400A011 RID: 40977
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x0400A012 RID: 40978
		CommandBarrierBit = 64,
		// Token: 0x0400A013 RID: 40979
		CommandBarrierBitExt = 64,
		// Token: 0x0400A014 RID: 40980
		PixelBufferBarrierBit = 128,
		// Token: 0x0400A015 RID: 40981
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400A016 RID: 40982
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400A017 RID: 40983
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400A018 RID: 40984
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400A019 RID: 40985
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x0400A01A RID: 40986
		FramebufferBarrierBit = 1024,
		// Token: 0x0400A01B RID: 40987
		FramebufferBarrierBitExt = 1024,
		// Token: 0x0400A01C RID: 40988
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400A01D RID: 40989
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x0400A01E RID: 40990
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400A01F RID: 40991
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x0400A020 RID: 40992
		ShaderStorageBarrierBit = 8192,
		// Token: 0x0400A021 RID: 40993
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x0400A022 RID: 40994
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400A023 RID: 40995
		AllBarrierBits = -1,
		// Token: 0x0400A024 RID: 40996
		AllBarrierBitsExt = -1
	}
}
