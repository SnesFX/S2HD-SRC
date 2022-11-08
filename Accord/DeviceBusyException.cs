using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	public class DeviceBusyException : Exception
	{
		// Token: 0x0600005E RID: 94 RVA: 0x0000280C File Offset: 0x0000180C
		public DeviceBusyException()
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002814 File Offset: 0x00001814
		public DeviceBusyException(string message) : base(message)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000281D File Offset: 0x0000181D
		public DeviceBusyException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002827 File Offset: 0x00001827
		public DeviceBusyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
