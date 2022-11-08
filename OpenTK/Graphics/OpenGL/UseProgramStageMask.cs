using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000493 RID: 1171
	[Flags]
	public enum UseProgramStageMask
	{
		// Token: 0x0400438C RID: 17292
		VertexShaderBit = 1,
		// Token: 0x0400438D RID: 17293
		VertexShaderBitExt = 1,
		// Token: 0x0400438E RID: 17294
		FragmentShaderBit = 2,
		// Token: 0x0400438F RID: 17295
		FragmentShaderBitExt = 2,
		// Token: 0x04004390 RID: 17296
		GeometryShaderBit = 4,
		// Token: 0x04004391 RID: 17297
		GeometryShaderBitExt = 4,
		// Token: 0x04004392 RID: 17298
		TessControlShaderBit = 8,
		// Token: 0x04004393 RID: 17299
		TessControlShaderBitExt = 8,
		// Token: 0x04004394 RID: 17300
		TessEvaluationShaderBit = 16,
		// Token: 0x04004395 RID: 17301
		TessEvaluationShaderBitExt = 16,
		// Token: 0x04004396 RID: 17302
		ComputeShaderBit = 32,
		// Token: 0x04004397 RID: 17303
		AllShaderBits = -1,
		// Token: 0x04004398 RID: 17304
		AllShaderBitsExt = -1
	}
}
