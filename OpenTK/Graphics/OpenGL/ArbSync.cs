using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000253 RID: 595
	public enum ArbSync
	{
		// Token: 0x040029F6 RID: 10742
		SyncFlushCommandsBit = 1,
		// Token: 0x040029F7 RID: 10743
		MaxServerWaitTimeout = 37137,
		// Token: 0x040029F8 RID: 10744
		ObjectType,
		// Token: 0x040029F9 RID: 10745
		SyncCondition,
		// Token: 0x040029FA RID: 10746
		SyncStatus,
		// Token: 0x040029FB RID: 10747
		SyncFlags,
		// Token: 0x040029FC RID: 10748
		SyncFence,
		// Token: 0x040029FD RID: 10749
		SyncGpuCommandsComplete,
		// Token: 0x040029FE RID: 10750
		Unsignaled,
		// Token: 0x040029FF RID: 10751
		Signaled,
		// Token: 0x04002A00 RID: 10752
		AlreadySignaled,
		// Token: 0x04002A01 RID: 10753
		TimeoutExpired,
		// Token: 0x04002A02 RID: 10754
		ConditionSatisfied,
		// Token: 0x04002A03 RID: 10755
		WaitFailed,
		// Token: 0x04002A04 RID: 10756
		TimeoutIgnored = -1
	}
}
