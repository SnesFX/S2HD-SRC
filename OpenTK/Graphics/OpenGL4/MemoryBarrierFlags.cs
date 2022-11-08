using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006F4 RID: 1780
	public enum MemoryBarrierFlags
	{
		// Token: 0x04006AF0 RID: 27376
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04006AF1 RID: 27377
		ElementArrayBarrierBit,
		// Token: 0x04006AF2 RID: 27378
		UniformBarrierBit = 4,
		// Token: 0x04006AF3 RID: 27379
		TextureFetchBarrierBit = 8,
		// Token: 0x04006AF4 RID: 27380
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04006AF5 RID: 27381
		CommandBarrierBit = 64,
		// Token: 0x04006AF6 RID: 27382
		PixelBufferBarrierBit = 128,
		// Token: 0x04006AF7 RID: 27383
		TextureUpdateBarrierBit = 256,
		// Token: 0x04006AF8 RID: 27384
		BufferUpdateBarrierBit = 512,
		// Token: 0x04006AF9 RID: 27385
		FramebufferBarrierBit = 1024,
		// Token: 0x04006AFA RID: 27386
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x04006AFB RID: 27387
		AtomicCounterBarrierBit = 4096,
		// Token: 0x04006AFC RID: 27388
		ShaderStorageBarrierBit = 8192,
		// Token: 0x04006AFD RID: 27389
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x04006AFE RID: 27390
		QueryBufferBarrierBit = 32768,
		// Token: 0x04006AFF RID: 27391
		AllBarrierBits = -1
	}
}
