using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000415 RID: 1045
	[Flags]
	public enum ProgramStageMask
	{
		// Token: 0x04003F89 RID: 16265
		VertexShaderBit = 1,
		// Token: 0x04003F8A RID: 16266
		FragmentShaderBit = 2,
		// Token: 0x04003F8B RID: 16267
		GeometryShaderBit = 4,
		// Token: 0x04003F8C RID: 16268
		TessControlShaderBit = 8,
		// Token: 0x04003F8D RID: 16269
		TessEvaluationShaderBit = 16,
		// Token: 0x04003F8E RID: 16270
		ComputeShaderBit = 32,
		// Token: 0x04003F8F RID: 16271
		AllShaderBits = -1
	}
}
