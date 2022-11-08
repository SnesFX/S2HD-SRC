using System;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x02000037 RID: 55
	internal class SecureObjectPool
	{
		// Token: 0x06000344 RID: 836 RVA: 0x00008C48 File Offset: 0x00006E48
		internal static int NewId()
		{
			int num;
			do
			{
				num = Interlocked.Increment(ref SecureObjectPool.s_poolUserIdCounter);
			}
			while (num == -1);
			return num;
		}

		// Token: 0x04000038 RID: 56
		private static int s_poolUserIdCounter;

		// Token: 0x04000039 RID: 57
		internal const int UnassignedId = -1;
	}
}
