using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200063C RID: 1596
	public enum ArbSeparateShaderObjects
	{
		// Token: 0x040061AF RID: 25007
		VertexShaderBit = 1,
		// Token: 0x040061B0 RID: 25008
		FragmentShaderBit,
		// Token: 0x040061B1 RID: 25009
		GeometryShaderBit = 4,
		// Token: 0x040061B2 RID: 25010
		TessControlShaderBit = 8,
		// Token: 0x040061B3 RID: 25011
		TessEvaluationShaderBit = 16,
		// Token: 0x040061B4 RID: 25012
		ProgramSeparable = 33368,
		// Token: 0x040061B5 RID: 25013
		ActiveProgram,
		// Token: 0x040061B6 RID: 25014
		ProgramPipelineBinding,
		// Token: 0x040061B7 RID: 25015
		AllShaderBits = -1
	}
}
