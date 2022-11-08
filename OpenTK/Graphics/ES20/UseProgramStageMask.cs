using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000A07 RID: 2567
	[Flags]
	public enum UseProgramStageMask
	{
		// Token: 0x0400A41B RID: 42011
		VertexShaderBit = 1,
		// Token: 0x0400A41C RID: 42012
		VertexShaderBitExt = 1,
		// Token: 0x0400A41D RID: 42013
		FragmentShaderBit = 2,
		// Token: 0x0400A41E RID: 42014
		FragmentShaderBitExt = 2,
		// Token: 0x0400A41F RID: 42015
		GeometryShaderBit = 4,
		// Token: 0x0400A420 RID: 42016
		GeometryShaderBitExt = 4,
		// Token: 0x0400A421 RID: 42017
		TessControlShaderBit = 8,
		// Token: 0x0400A422 RID: 42018
		TessControlShaderBitExt = 8,
		// Token: 0x0400A423 RID: 42019
		TessEvaluationShaderBit = 16,
		// Token: 0x0400A424 RID: 42020
		TessEvaluationShaderBitExt = 16,
		// Token: 0x0400A425 RID: 42021
		ComputeShaderBit = 32,
		// Token: 0x0400A426 RID: 42022
		AllShaderBits = -1,
		// Token: 0x0400A427 RID: 42023
		AllShaderBitsExt = -1
	}
}
