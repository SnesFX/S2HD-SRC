using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200029C RID: 668
	public enum BeginMode
	{
		// Token: 0x04002D32 RID: 11570
		Points,
		// Token: 0x04002D33 RID: 11571
		Lines,
		// Token: 0x04002D34 RID: 11572
		LineLoop,
		// Token: 0x04002D35 RID: 11573
		LineStrip,
		// Token: 0x04002D36 RID: 11574
		Triangles,
		// Token: 0x04002D37 RID: 11575
		TriangleStrip,
		// Token: 0x04002D38 RID: 11576
		TriangleFan,
		// Token: 0x04002D39 RID: 11577
		Quads,
		// Token: 0x04002D3A RID: 11578
		QuadStrip,
		// Token: 0x04002D3B RID: 11579
		Polygon,
		// Token: 0x04002D3C RID: 11580
		Patches = 14,
		// Token: 0x04002D3D RID: 11581
		LinesAdjacency = 10,
		// Token: 0x04002D3E RID: 11582
		LineStripAdjacency,
		// Token: 0x04002D3F RID: 11583
		TrianglesAdjacency,
		// Token: 0x04002D40 RID: 11584
		TriangleStripAdjacency
	}
}
