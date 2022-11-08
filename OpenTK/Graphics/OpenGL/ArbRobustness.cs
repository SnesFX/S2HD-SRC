using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000238 RID: 568
	public enum ArbRobustness
	{
		// Token: 0x04002916 RID: 10518
		NoError,
		// Token: 0x04002917 RID: 10519
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x04002918 RID: 10520
		LoseContextOnResetArb = 33362,
		// Token: 0x04002919 RID: 10521
		GuiltyContextResetArb,
		// Token: 0x0400291A RID: 10522
		InnocentContextResetArb,
		// Token: 0x0400291B RID: 10523
		UnknownContextResetArb,
		// Token: 0x0400291C RID: 10524
		ResetNotificationStrategyArb,
		// Token: 0x0400291D RID: 10525
		NoResetNotificationArb = 33377
	}
}
