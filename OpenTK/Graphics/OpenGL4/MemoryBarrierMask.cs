using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006F5 RID: 1781
	[Flags]
	public enum MemoryBarrierMask
	{
		// Token: 0x04006B01 RID: 27393
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04006B02 RID: 27394
		VertexAttribArrayBarrierBitExt = 1,
		// Token: 0x04006B03 RID: 27395
		ElementArrayBarrierBit = 2,
		// Token: 0x04006B04 RID: 27396
		ElementArrayBarrierBitExt = 2,
		// Token: 0x04006B05 RID: 27397
		UniformBarrierBit = 4,
		// Token: 0x04006B06 RID: 27398
		UniformBarrierBitExt = 4,
		// Token: 0x04006B07 RID: 27399
		TextureFetchBarrierBit = 8,
		// Token: 0x04006B08 RID: 27400
		TextureFetchBarrierBitExt = 8,
		// Token: 0x04006B09 RID: 27401
		ShaderGlobalAccessBarrierBitNv = 16,
		// Token: 0x04006B0A RID: 27402
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04006B0B RID: 27403
		ShaderImageAccessBarrierBitExt = 32,
		// Token: 0x04006B0C RID: 27404
		CommandBarrierBit = 64,
		// Token: 0x04006B0D RID: 27405
		CommandBarrierBitExt = 64,
		// Token: 0x04006B0E RID: 27406
		PixelBufferBarrierBit = 128,
		// Token: 0x04006B0F RID: 27407
		PixelBufferBarrierBitExt = 128,
		// Token: 0x04006B10 RID: 27408
		TextureUpdateBarrierBit = 256,
		// Token: 0x04006B11 RID: 27409
		TextureUpdateBarrierBitExt = 256,
		// Token: 0x04006B12 RID: 27410
		BufferUpdateBarrierBit = 512,
		// Token: 0x04006B13 RID: 27411
		BufferUpdateBarrierBitExt = 512,
		// Token: 0x04006B14 RID: 27412
		FramebufferBarrierBit = 1024,
		// Token: 0x04006B15 RID: 27413
		FramebufferBarrierBitExt = 1024,
		// Token: 0x04006B16 RID: 27414
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04006B17 RID: 27415
		TransformFeedbackBarrierBitExt = 2048,
		// Token: 0x04006B18 RID: 27416
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04006B19 RID: 27417
		AtomicCounterBarrierBitExt = 4096,
		// Token: 0x04006B1A RID: 27418
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04006B1B RID: 27419
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04006B1C RID: 27420
		QueryBufferBarrierBit = 32768,
		// Token: 0x04006B1D RID: 27421
		AllBarrierBits = -1,
		// Token: 0x04006B1E RID: 27422
		AllBarrierBitsExt = -1
	}
}
