using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002D RID: 45
	[Serializable]
	public class PngjInputException : PngjException
	{
		// Token: 0x0600015B RID: 347 RVA: 0x000066DF File Offset: 0x000048DF
		public PngjInputException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000066E9 File Offset: 0x000048E9
		public PngjInputException(string message) : base(message)
		{
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000066F2 File Offset: 0x000048F2
		public PngjInputException(Exception cause) : base(cause)
		{
		}

		// Token: 0x04000094 RID: 148
		private const long serialVersionUID = 1L;
	}
}
