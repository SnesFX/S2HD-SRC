using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class ConvergenceException : Exception
	{
		// Token: 0x06000103 RID: 259 RVA: 0x0000280C File Offset: 0x0000180C
		public ConvergenceException()
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00002814 File Offset: 0x00001814
		public ConvergenceException(string message) : base(message)
		{
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000281D File Offset: 0x0000181D
		public ConvergenceException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00002827 File Offset: 0x00001827
		protected ConvergenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
