using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200023E RID: 574
	public enum ArbSeparateShaderObjects
	{
		// Token: 0x04002929 RID: 10537
		VertexShaderBit = 1,
		// Token: 0x0400292A RID: 10538
		FragmentShaderBit,
		// Token: 0x0400292B RID: 10539
		GeometryShaderBit = 4,
		// Token: 0x0400292C RID: 10540
		TessControlShaderBit = 8,
		// Token: 0x0400292D RID: 10541
		TessEvaluationShaderBit = 16,
		// Token: 0x0400292E RID: 10542
		ProgramSeparable = 33368,
		// Token: 0x0400292F RID: 10543
		ActiveProgram,
		// Token: 0x04002930 RID: 10544
		ProgramPipelineBinding,
		// Token: 0x04002931 RID: 10545
		AllShaderBits = -1
	}
}
