using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000717 RID: 1815
	[Flags]
	public enum ProgramStageMask
	{
		// Token: 0x04006D47 RID: 27975
		VertexShaderBit = 1,
		// Token: 0x04006D48 RID: 27976
		FragmentShaderBit = 2,
		// Token: 0x04006D49 RID: 27977
		GeometryShaderBit = 4,
		// Token: 0x04006D4A RID: 27978
		TessControlShaderBit = 8,
		// Token: 0x04006D4B RID: 27979
		TessEvaluationShaderBit = 16,
		// Token: 0x04006D4C RID: 27980
		ComputeShaderBit = 32,
		// Token: 0x04006D4D RID: 27981
		AllShaderBits = -1
	}
}
