using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000A3D RID: 2621
	public enum ExtRobustness
	{
		// Token: 0x0400ABC8 RID: 43976
		NoError,
		// Token: 0x0400ABC9 RID: 43977
		LoseContextOnResetExt = 33362,
		// Token: 0x0400ABCA RID: 43978
		GuiltyContextResetExt,
		// Token: 0x0400ABCB RID: 43979
		InnocentContextResetExt,
		// Token: 0x0400ABCC RID: 43980
		UnknownContextResetExt,
		// Token: 0x0400ABCD RID: 43981
		ResetNotificationStrategyExt,
		// Token: 0x0400ABCE RID: 43982
		NoResetNotificationExt = 33377,
		// Token: 0x0400ABCF RID: 43983
		ContextRobustAccessExt = 37107
	}
}
