using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class ConnectionLostException : Exception
	{
		// Token: 0x06000056 RID: 86 RVA: 0x0000280C File Offset: 0x0000180C
		public ConnectionLostException()
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002814 File Offset: 0x00001814
		public ConnectionLostException(string message) : base(message)
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000281D File Offset: 0x0000181D
		public ConnectionLostException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002827 File Offset: 0x00001827
		public ConnectionLostException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
