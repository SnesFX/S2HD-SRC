using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000673 RID: 1651
	public enum BeginMode
	{
		// Token: 0x04006398 RID: 25496
		Points,
		// Token: 0x04006399 RID: 25497
		Lines,
		// Token: 0x0400639A RID: 25498
		LineLoop,
		// Token: 0x0400639B RID: 25499
		LineStrip,
		// Token: 0x0400639C RID: 25500
		Triangles,
		// Token: 0x0400639D RID: 25501
		TriangleStrip,
		// Token: 0x0400639E RID: 25502
		TriangleFan,
		// Token: 0x0400639F RID: 25503
		Quads,
		// Token: 0x040063A0 RID: 25504
		QuadStrip,
		// Token: 0x040063A1 RID: 25505
		Polygon,
		// Token: 0x040063A2 RID: 25506
		Patches = 14,
		// Token: 0x040063A3 RID: 25507
		LinesAdjacency = 10,
		// Token: 0x040063A4 RID: 25508
		LineStripAdjacency,
		// Token: 0x040063A5 RID: 25509
		TrianglesAdjacency,
		// Token: 0x040063A6 RID: 25510
		TriangleStripAdjacency
	}
}
