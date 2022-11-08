using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002F RID: 47
	[Serializable]
	public class PngjUnsupportedException : Exception
	{
		// Token: 0x06000161 RID: 353 RVA: 0x0000671D File Offset: 0x0000491D
		public PngjUnsupportedException()
		{
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000066FB File Offset: 0x000048FB
		public PngjUnsupportedException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006705 File Offset: 0x00004905
		public PngjUnsupportedException(string message) : base(message)
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000670E File Offset: 0x0000490E
		public PngjUnsupportedException(Exception cause) : base(cause.Message, cause)
		{
		}

		// Token: 0x04000096 RID: 150
		private const long serialVersionUID = 1L;
	}
}
