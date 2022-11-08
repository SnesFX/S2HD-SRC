using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020008CA RID: 2250
	public enum WaitSyncStatus
	{
		// Token: 0x04008F3C RID: 36668
		AlreadySignaled = 37146,
		// Token: 0x04008F3D RID: 36669
		AlreadySignaledApple = 37146,
		// Token: 0x04008F3E RID: 36670
		TimeoutExpired,
		// Token: 0x04008F3F RID: 36671
		TimeoutExpiredApple = 37147,
		// Token: 0x04008F40 RID: 36672
		ConditionSatisfied,
		// Token: 0x04008F41 RID: 36673
		ConditionSatisfiedApple = 37148,
		// Token: 0x04008F42 RID: 36674
		WaitFailed,
		// Token: 0x04008F43 RID: 36675
		WaitFailedApple = 37149
	}
}
