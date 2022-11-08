using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000AF1 RID: 2801
	[Flags]
	public enum UseProgramStageMask
	{
		// Token: 0x0400B325 RID: 45861
		VertexShaderBit = 1,
		// Token: 0x0400B326 RID: 45862
		VertexShaderBitExt = 1,
		// Token: 0x0400B327 RID: 45863
		FragmentShaderBit = 2,
		// Token: 0x0400B328 RID: 45864
		FragmentShaderBitExt = 2,
		// Token: 0x0400B329 RID: 45865
		GeometryShaderBit = 4,
		// Token: 0x0400B32A RID: 45866
		GeometryShaderBitExt = 4,
		// Token: 0x0400B32B RID: 45867
		TessControlShaderBit = 8,
		// Token: 0x0400B32C RID: 45868
		TessControlShaderBitExt = 8,
		// Token: 0x0400B32D RID: 45869
		TessEvaluationShaderBit = 16,
		// Token: 0x0400B32E RID: 45870
		TessEvaluationShaderBitExt = 16,
		// Token: 0x0400B32F RID: 45871
		ComputeShaderBit = 32,
		// Token: 0x0400B330 RID: 45872
		AllShaderBits = -1,
		// Token: 0x0400B331 RID: 45873
		AllShaderBitsExt = -1
	}
}
