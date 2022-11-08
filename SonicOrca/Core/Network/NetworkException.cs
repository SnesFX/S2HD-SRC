using System;
using System.Runtime.Serialization;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000176 RID: 374
	[Serializable]
	internal class NetworkException : Exception
	{
		// Token: 0x06001086 RID: 4230 RVA: 0x0000671D File Offset: 0x0000491D
		public NetworkException()
		{
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x00006705 File Offset: 0x00004905
		public NetworkException(string message) : base(message)
		{
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x000066FB File Offset: 0x000048FB
		public NetworkException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0001AAE3 File Offset: 0x00018CE3
		protected NetworkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
