using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000636 RID: 1590
	public enum ArbRobustness
	{
		// Token: 0x0400619C RID: 24988
		NoError,
		// Token: 0x0400619D RID: 24989
		ContextFlagRobustAccessBitArb = 4,
		// Token: 0x0400619E RID: 24990
		LoseContextOnResetArb = 33362,
		// Token: 0x0400619F RID: 24991
		GuiltyContextResetArb,
		// Token: 0x040061A0 RID: 24992
		InnocentContextResetArb,
		// Token: 0x040061A1 RID: 24993
		UnknownContextResetArb,
		// Token: 0x040061A2 RID: 24994
		ResetNotificationStrategyArb,
		// Token: 0x040061A3 RID: 24995
		NoResetNotificationArb = 33377
	}
}
