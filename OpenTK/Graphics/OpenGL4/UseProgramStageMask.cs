using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000754 RID: 1876
	[Flags]
	public enum UseProgramStageMask
	{
		// Token: 0x04006FE1 RID: 28641
		VertexShaderBit = 1,
		// Token: 0x04006FE2 RID: 28642
		VertexShaderBitExt = 1,
		// Token: 0x04006FE3 RID: 28643
		FragmentShaderBit = 2,
		// Token: 0x04006FE4 RID: 28644
		FragmentShaderBitExt = 2,
		// Token: 0x04006FE5 RID: 28645
		GeometryShaderBit = 4,
		// Token: 0x04006FE6 RID: 28646
		GeometryShaderBitExt = 4,
		// Token: 0x04006FE7 RID: 28647
		TessControlShaderBit = 8,
		// Token: 0x04006FE8 RID: 28648
		TessControlShaderBitExt = 8,
		// Token: 0x04006FE9 RID: 28649
		TessEvaluationShaderBit = 16,
		// Token: 0x04006FEA RID: 28650
		TessEvaluationShaderBitExt = 16,
		// Token: 0x04006FEB RID: 28651
		ComputeShaderBit = 32,
		// Token: 0x04006FEC RID: 28652
		AllShaderBits = -1,
		// Token: 0x04006FED RID: 28653
		AllShaderBitsExt = -1
	}
}
