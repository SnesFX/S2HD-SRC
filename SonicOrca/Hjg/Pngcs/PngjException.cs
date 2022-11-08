using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	public class PngjException : Exception
	{
		// Token: 0x06000154 RID: 340 RVA: 0x000066FB File Offset: 0x000048FB
		public PngjException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00006705 File Offset: 0x00004905
		public PngjException(string message) : base(message)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000670E File Offset: 0x0000490E
		public PngjException(Exception cause) : base(cause.Message, cause)
		{
		}

		// Token: 0x04000092 RID: 146
		private const long serialVersionUID = 1L;
	}
}
