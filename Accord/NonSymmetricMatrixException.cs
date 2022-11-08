using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class NonSymmetricMatrixException : InvalidOperationException
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00003E96 File Offset: 0x00002E96
		public NonSymmetricMatrixException()
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00003E9E File Offset: 0x00002E9E
		public NonSymmetricMatrixException(string message) : base(message)
		{
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00003EA7 File Offset: 0x00002EA7
		public NonSymmetricMatrixException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00003EB1 File Offset: 0x00002EB1
		protected NonSymmetricMatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
