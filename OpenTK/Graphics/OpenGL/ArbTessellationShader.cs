using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000254 RID: 596
	public enum ArbTessellationShader
	{
		// Token: 0x04002A06 RID: 10758
		Triangles = 4,
		// Token: 0x04002A07 RID: 10759
		Quads = 7,
		// Token: 0x04002A08 RID: 10760
		Patches = 14,
		// Token: 0x04002A09 RID: 10761
		Equal = 514,
		// Token: 0x04002A0A RID: 10762
		Cw = 2304,
		// Token: 0x04002A0B RID: 10763
		Ccw,
		// Token: 0x04002A0C RID: 10764
		UniformBlockReferencedByTessControlShader = 34032,
		// Token: 0x04002A0D RID: 10765
		UniformBlockReferencedByTessEvaluationShader,
		// Token: 0x04002A0E RID: 10766
		MaxTessControlInputComponents = 34924,
		// Token: 0x04002A0F RID: 10767
		MaxTessEvaluationInputComponents,
		// Token: 0x04002A10 RID: 10768
		MaxCombinedTessControlUniformComponents = 36382,
		// Token: 0x04002A11 RID: 10769
		MaxCombinedTessEvaluationUniformComponents,
		// Token: 0x04002A12 RID: 10770
		PatchVertices = 36466,
		// Token: 0x04002A13 RID: 10771
		PatchDefaultInnerLevel,
		// Token: 0x04002A14 RID: 10772
		PatchDefaultOuterLevel,
		// Token: 0x04002A15 RID: 10773
		TessControlOutputVertices,
		// Token: 0x04002A16 RID: 10774
		TessGenMode,
		// Token: 0x04002A17 RID: 10775
		TessGenSpacing,
		// Token: 0x04002A18 RID: 10776
		TessGenVertexOrder,
		// Token: 0x04002A19 RID: 10777
		TessGenPointMode,
		// Token: 0x04002A1A RID: 10778
		Isolines,
		// Token: 0x04002A1B RID: 10779
		FractionalOdd,
		// Token: 0x04002A1C RID: 10780
		FractionalEven,
		// Token: 0x04002A1D RID: 10781
		MaxPatchVertices,
		// Token: 0x04002A1E RID: 10782
		MaxTessGenLevel,
		// Token: 0x04002A1F RID: 10783
		MaxTessControlUniformComponents,
		// Token: 0x04002A20 RID: 10784
		MaxTessEvaluationUniformComponents,
		// Token: 0x04002A21 RID: 10785
		MaxTessControlTextureImageUnits,
		// Token: 0x04002A22 RID: 10786
		MaxTessEvaluationTextureImageUnits,
		// Token: 0x04002A23 RID: 10787
		MaxTessControlOutputComponents,
		// Token: 0x04002A24 RID: 10788
		MaxTessPatchComponents,
		// Token: 0x04002A25 RID: 10789
		MaxTessControlTotalOutputComponents,
		// Token: 0x04002A26 RID: 10790
		MaxTessEvaluationOutputComponents,
		// Token: 0x04002A27 RID: 10791
		TessEvaluationShader,
		// Token: 0x04002A28 RID: 10792
		TessControlShader,
		// Token: 0x04002A29 RID: 10793
		MaxTessControlUniformBlocks,
		// Token: 0x04002A2A RID: 10794
		MaxTessEvaluationUniformBlocks
	}
}
