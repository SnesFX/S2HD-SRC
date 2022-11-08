using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007DB RID: 2011
	public enum ExtRobustness
	{
		// Token: 0x040083DA RID: 33754
		NoError,
		// Token: 0x040083DB RID: 33755
		LoseContextOnResetExt = 33362,
		// Token: 0x040083DC RID: 33756
		GuiltyContextResetExt,
		// Token: 0x040083DD RID: 33757
		InnocentContextResetExt,
		// Token: 0x040083DE RID: 33758
		UnknownContextResetExt,
		// Token: 0x040083DF RID: 33759
		ResetNotificationStrategyExt,
		// Token: 0x040083E0 RID: 33760
		NoResetNotificationExt = 33377,
		// Token: 0x040083E1 RID: 33761
		ContextRobustAccessExt = 37107
	}
}
