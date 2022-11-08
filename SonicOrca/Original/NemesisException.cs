using System;
using System.Runtime.Serialization;

namespace SonicOrca.Original
{
	// Token: 0x020000A3 RID: 163
	[Serializable]
	public class NemesisException : Exception
	{
		// Token: 0x06000563 RID: 1379 RVA: 0x0000671D File Offset: 0x0000491D
		public NemesisException()
		{
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00006705 File Offset: 0x00004905
		public NemesisException(string message) : base(message)
		{
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000066FB File Offset: 0x000048FB
		public NemesisException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001AAE3 File Offset: 0x00018CE3
		protected NemesisException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
