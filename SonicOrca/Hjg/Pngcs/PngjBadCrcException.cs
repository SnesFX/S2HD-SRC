using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	public class PngjBadCrcException : PngjException
	{
		// Token: 0x06000151 RID: 337 RVA: 0x000066DF File Offset: 0x000048DF
		public PngjBadCrcException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000066E9 File Offset: 0x000048E9
		public PngjBadCrcException(string message) : base(message)
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000066F2 File Offset: 0x000048F2
		public PngjBadCrcException(Exception cause) : base(cause)
		{
		}

		// Token: 0x04000091 RID: 145
		private const long serialVersionUID = 1L;
	}
}
