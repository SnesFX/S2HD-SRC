using System;

namespace Accord
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class ConnectionFailedException : Exception
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000280C File Offset: 0x0000180C
		public ConnectionFailedException()
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002814 File Offset: 0x00001814
		public ConnectionFailedException(string message) : base(message)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000281D File Offset: 0x0000181D
		public ConnectionFailedException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
