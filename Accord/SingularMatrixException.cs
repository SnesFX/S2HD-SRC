using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	public class SingularMatrixException : Exception
	{
		// Token: 0x06000114 RID: 276 RVA: 0x0000280C File Offset: 0x0000180C
		public SingularMatrixException()
		{
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00002814 File Offset: 0x00001814
		public SingularMatrixException(string message) : base(message)
		{
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000281D File Offset: 0x0000181D
		public SingularMatrixException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00002827 File Offset: 0x00001827
		protected SingularMatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
