using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x02000837 RID: 2103
	[Flags]
	public enum MemoryBarrierMask
	{
		// Token: 0x0400897D RID: 35197
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x0400897E RID: 35198
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x0400897F RID: 35199
		ElementArrayBarrierBit = 2,
		// Token: 0x04008980 RID: 35200
		ElementArrayBarrierBitExt = 2,
		// Token: 0x04008981 RID: 35201
		UniformBarrierBit = 4,
		// Token: 0x04008982 RID: 35202
		UniformBarrierBitExt = 4,
		// Token: 0x04008983 RID: 35203
		TextureFetchBarrierBit = 8,
		// Token: 0x04008984 RID: 35204
		TextureFetchBarrierBitExt = 8,
		// Token: 0x04008985 RID: 35205
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x04008986 RID: 35206
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04008987 RID: 35207
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04008988 RID: 35208
		CommandBarrierBit = 64,
		// Token: 0x04008989 RID: 35209
		CommandBarrierBitExt = 64,
		// Token: 0x0400898A RID: 35210
		PixelBufferBarrierBit = 128,
		// Token: 0x0400898B RID: 35211
		PixelBufferBarrierBitExt = 128,
		// Token: 0x0400898C RID: 35212
		TextureUpdateBarrierBit = 256,
		// Token: 0x0400898D RID: 35213
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x0400898E RID: 35214
		BufferUpdateBarrierBit = 512,
		// Token: 0x0400898F RID: 35215
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x04008990 RID: 35216
		FramebufferBarrierBit = 1024,
		// Token: 0x04008991 RID: 35217
		FramebufferBarrierBitExt = 1024,
		// Token: 0x04008992 RID: 35218
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04008993 RID: 35219
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x04008994 RID: 35220
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04008995 RID: 35221
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x04008996 RID: 35222
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04008997 RID: 35223
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04008998 RID: 35224
		QueryBufferBarrierBit = 32768,
		// Token: 0x04008999 RID: 35225
		AllBarrierBits = -1,
		// Token: 0x0400899A RID: 35226
		AllBarrierBitsExt = -1
	}
}
