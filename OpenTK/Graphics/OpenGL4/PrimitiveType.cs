using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200070F RID: 1807
	public enum PrimitiveType
	{
		// Token: 0x04006CCB RID: 27851
		Points,
		// Token: 0x04006CCC RID: 27852
		Lines,
		// Token: 0x04006CCD RID: 27853
		LineLoop,
		// Token: 0x04006CCE RID: 27854
		LineStrip,
		// Token: 0x04006CCF RID: 27855
		Triangles,
		// Token: 0x04006CD0 RID: 27856
		TriangleStrip,
		// Token: 0x04006CD1 RID: 27857
		TriangleFan,
		// Token: 0x04006CD2 RID: 27858
		Quads,
		// Token: 0x04006CD3 RID: 27859
		QuadsExt = 7,
		// Token: 0x04006CD4 RID: 27860
		LinesAdjacency = 10,
		// Token: 0x04006CD5 RID: 27861
		LinesAdjacencyArb = 10,
		// Token: 0x04006CD6 RID: 27862
		LinesAdjacencyExt = 10,
		// Token: 0x04006CD7 RID: 27863
		LineStripAdjacency,
		// Token: 0x04006CD8 RID: 27864
		LineStripAdjacencyArb = 11,
		// Token: 0x04006CD9 RID: 27865
		LineStripAdjacencyExt = 11,
		// Token: 0x04006CDA RID: 27866
		TrianglesAdjacency,
		// Token: 0x04006CDB RID: 27867
		TrianglesAdjacencyArb = 12,
		// Token: 0x04006CDC RID: 27868
		TrianglesAdjacencyExt = 12,
		// Token: 0x04006CDD RID: 27869
		TriangleStripAdjacency,
		// Token: 0x04006CDE RID: 27870
		TriangleStripAdjacencyArb = 13,
		// Token: 0x04006CDF RID: 27871
		TriangleStripAdjacencyExt = 13,
		// Token: 0x04006CE0 RID: 27872
		Patches,
		// Token: 0x04006CE1 RID: 27873
		PatchesExt = 14
	}
}
