using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	public class DimensionMismatchException : ArgumentException
	{
		// Token: 0x06000107 RID: 263 RVA: 0x00003E62 File Offset: 0x00002E62
		public DimensionMismatchException()
		{
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003E6A File Offset: 0x00002E6A
		public DimensionMismatchException(string paramName) : base(paramName, "Array dimensions must match.")
		{
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003E78 File Offset: 0x00002E78
		public DimensionMismatchException(string paramName, string message) : base(message, paramName)
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003E82 File Offset: 0x00002E82
		public DimensionMismatchException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003E8C File Offset: 0x00002E8C
		protected DimensionMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
