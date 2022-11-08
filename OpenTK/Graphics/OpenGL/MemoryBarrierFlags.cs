using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000393 RID: 915
	public enum MemoryBarrierFlags
	{
		// Token: 0x04003990 RID: 14736
		VertexAttribArrayBarrierBit = 1,
		// Token: 0x04003991 RID: 14737
		ElementArrayBarrierBit,
		// Token: 0x04003992 RID: 14738
		UniformBarrierBit = 4,
		// Token: 0x04003993 RID: 14739
		TextureFetchBarrierBit = 8,
		// Token: 0x04003994 RID: 14740
		ShaderImageAccessBarrierBit = 32,
		// Token: 0x04003995 RID: 14741
		CommandBarrierBit = 64,
		// Token: 0x04003996 RID: 14742
		PixelBufferBarrierBit = 128,
		// Token: 0x04003997 RID: 14743
		TextureUpdateBarrierBit = 256,
		// Token: 0x04003998 RID: 14744
		BufferUpdateBarrierBit = 512,
		// Token: 0x04003999 RID: 14745
		FramebufferBarrierBit = 1024,
		// Token: 0x0400399A RID: 14746
		TransformFeedbackBarrierBit = 2048,
		// Token: 0x0400399B RID: 14747
		AtomicCounterBarrierBit = 4096,
		// Token: 0x0400399C RID: 14748
		ShaderStorageBarrierBit = 8192,
		// Token: 0x0400399D RID: 14749
		ClientMappedBufferBarrierBit = 16384,
		// Token: 0x0400399E RID: 14750
		QueryBufferBarrierBit = 32768,
		// Token: 0x0400399F RID: 14751
		AllBarrierBits = -1
	}
}
