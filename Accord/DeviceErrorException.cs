using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	public class DeviceErrorException : Exception
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000280C File Offset: 0x0000180C
		public DeviceErrorException()
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002814 File Offset: 0x00001814
		public DeviceErrorException(string message) : base(message)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000281D File Offset: 0x0000181D
		public DeviceErrorException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002827 File Offset: 0x00001827
		public DeviceErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
