using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	public class PngjExceptionInternal : Exception
	{
		// Token: 0x06000157 RID: 343 RVA: 0x0000671D File Offset: 0x0000491D
		public PngjExceptionInternal()
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000066FB File Offset: 0x000048FB
		public PngjExceptionInternal(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00006705 File Offset: 0x00004905
		public PngjExceptionInternal(string message) : base(message)
		{
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000670E File Offset: 0x0000490E
		public PngjExceptionInternal(Exception cause) : base(cause.Message, cause)
		{
		}

		// Token: 0x04000093 RID: 147
		private const long serialVersionUID = 1L;
	}
}
