using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public class NonPositiveDefiniteMatrixException : Exception
	{
		// Token: 0x0600010C RID: 268 RVA: 0x0000280C File Offset: 0x0000180C
		public NonPositiveDefiniteMatrixException()
		{
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00002814 File Offset: 0x00001814
		public NonPositiveDefiniteMatrixException(string message) : base(message)
		{
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000281D File Offset: 0x0000181D
		public NonPositiveDefiniteMatrixException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002827 File Offset: 0x00001827
		protected NonPositiveDefiniteMatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
