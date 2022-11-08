using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x0200092B RID: 2347
	public enum ExtRobustness
	{
		// Token: 0x04009AF4 RID: 39668
		NoError,
		// Token: 0x04009AF5 RID: 39669
		LoseContextOnResetExt = 33362,
		// Token: 0x04009AF6 RID: 39670
		GuiltyContextResetExt,
		// Token: 0x04009AF7 RID: 39671
		InnocentContextResetExt,
		// Token: 0x04009AF8 RID: 39672
		UnknownContextResetExt,
		// Token: 0x04009AF9 RID: 39673
		ResetNotificationStrategyExt,
		// Token: 0x04009AFA RID: 39674
		NoResetNotificationExt = 33377,
		// Token: 0x04009AFB RID: 39675
		ContextRobustAccessExt = 37107
	}
}
