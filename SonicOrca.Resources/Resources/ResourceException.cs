using System;
using System.Runtime.Serialization;

namespace SonicOrca.Resources
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class ResourceException : Exception
	{
		// Token: 0x0600001F RID: 31 RVA: 0x000025C5 File Offset: 0x000007C5
		public ResourceException()
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000025CD File Offset: 0x000007CD
		public ResourceException(string message) : base(message)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000025D6 File Offset: 0x000007D6
		public ResourceException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025E0 File Offset: 0x000007E0
		protected ResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
