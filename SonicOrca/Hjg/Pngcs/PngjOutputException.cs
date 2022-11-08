using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public class PngjOutputException : PngjException
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000066DF File Offset: 0x000048DF
		public PngjOutputException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000066E9 File Offset: 0x000048E9
		public PngjOutputException(string message) : base(message)
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000066F2 File Offset: 0x000048F2
		public PngjOutputException(Exception cause) : base(cause)
		{
		}

		// Token: 0x04000095 RID: 149
		private const long serialVersionUID = 1L;
	}
}
