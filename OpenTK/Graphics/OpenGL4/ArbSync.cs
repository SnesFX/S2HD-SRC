using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200064C RID: 1612
	public enum ArbSync
	{
		// Token: 0x04006250 RID: 25168
		SyncFlushCommandsBit = 1,
		// Token: 0x04006251 RID: 25169
		MaxServerWaitTimeout = 37137,
		// Token: 0x04006252 RID: 25170
		ObjectType,
		// Token: 0x04006253 RID: 25171
		SyncCondition,
		// Token: 0x04006254 RID: 25172
		SyncStatus,
		// Token: 0x04006255 RID: 25173
		SyncFlags,
		// Token: 0x04006256 RID: 25174
		SyncFence,
		// Token: 0x04006257 RID: 25175
		SyncGpuCommandsComplete,
		// Token: 0x04006258 RID: 25176
		Unsignaled,
		// Token: 0x04006259 RID: 25177
		Signaled,
		// Token: 0x0400625A RID: 25178
		AlreadySignaled,
		// Token: 0x0400625B RID: 25179
		TimeoutExpired,
		// Token: 0x0400625C RID: 25180
		ConditionSatisfied,
		// Token: 0x0400625D RID: 25181
		WaitFailed,
		// Token: 0x0400625E RID: 25182
		TimeoutIgnored = -1
	}
}
