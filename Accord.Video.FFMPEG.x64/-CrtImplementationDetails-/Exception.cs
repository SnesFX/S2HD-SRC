using System;
using System.Runtime.Serialization;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000291 RID: 657
	[Serializable]
	internal class Exception : Exception
	{
		// Token: 0x0600011A RID: 282 RVA: 0x0000503C File Offset: 0x0000443C
		protected Exception(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005024 File Offset: 0x00004424
		public Exception(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005010 File Offset: 0x00004410
		public Exception(string message) : base(message)
		{
		}
	}
}
