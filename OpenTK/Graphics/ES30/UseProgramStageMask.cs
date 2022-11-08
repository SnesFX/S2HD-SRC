using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020008C2 RID: 2242
	[Flags]
	public enum UseProgramStageMask
	{
		// Token: 0x04008F06 RID: 36614
		VertexShaderBit = 1,
		// Token: 0x04008F07 RID: 36615
		VertexShaderBitExt = 1,
		// Token: 0x04008F08 RID: 36616
		FragmentShaderBit = 2,
		// Token: 0x04008F09 RID: 36617
		FragmentShaderBitExt = 2,
		// Token: 0x04008F0A RID: 36618
		GeometryShaderBit = 4,
		// Token: 0x04008F0B RID: 36619
		GeometryShaderBitExt = 4,
		// Token: 0x04008F0C RID: 36620
		TessControlShaderBit = 8,
		// Token: 0x04008F0D RID: 36621
		TessControlShaderBitExt = 8,
		// Token: 0x04008F0E RID: 36622
		TessEvaluationShaderBit = 16,
		// Token: 0x04008F0F RID: 36623
		TessEvaluationShaderBitExt = 16,
		// Token: 0x04008F10 RID: 36624
		ComputeShaderBit = 32,
		// Token: 0x04008F11 RID: 36625
		AllShaderBits = -1,
		// Token: 0x04008F12 RID: 36626
		AllShaderBitsExt = -1
	}
}
