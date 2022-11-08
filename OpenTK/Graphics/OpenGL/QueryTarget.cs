using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000419 RID: 1049
	public enum QueryTarget
	{
		// Token: 0x04003F9C RID: 16284
		TimeElapsed = 35007,
		// Token: 0x04003F9D RID: 16285
		SamplesPassed = 35092,
		// Token: 0x04003F9E RID: 16286
		AnySamplesPassed = 35887,
		// Token: 0x04003F9F RID: 16287
		PrimitivesGenerated = 35975,
		// Token: 0x04003FA0 RID: 16288
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04003FA1 RID: 16289
		AnySamplesPassedConservative = 36202,
		// Token: 0x04003FA2 RID: 16290
		Timestamp = 36392
	}
}
