using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	public class NotConnectedException : Exception
	{
		// Token: 0x0600005A RID: 90 RVA: 0x0000280C File Offset: 0x0000180C
		public NotConnectedException()
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002814 File Offset: 0x00001814
		public NotConnectedException(string message) : base(message)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000281D File Offset: 0x0000181D
		public NotConnectedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002827 File Offset: 0x00001827
		public NotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
