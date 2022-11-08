using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200071B RID: 1819
	public enum QueryTarget
	{
		// Token: 0x04006D5A RID: 27994
		TimeElapsed = 35007,
		// Token: 0x04006D5B RID: 27995
		SamplesPassed = 35092,
		// Token: 0x04006D5C RID: 27996
		AnySamplesPassed = 35887,
		// Token: 0x04006D5D RID: 27997
		PrimitivesGenerated = 35975,
		// Token: 0x04006D5E RID: 27998
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04006D5F RID: 27999
		AnySamplesPassedConservative = 36202,
		// Token: 0x04006D60 RID: 28000
		Timestamp = 36392
	}
}
