using System;
using System.Runtime.Serialization;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000295 RID: 661
	[Serializable]
	internal class OpenMPWithMultipleAppdomainsException : Exception
	{
		// Token: 0x0600012A RID: 298 RVA: 0x000054F8 File Offset: 0x000048F8
		protected OpenMPWithMultipleAppdomainsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000054E4 File Offset: 0x000048E4
		public OpenMPWithMultipleAppdomainsException()
		{
		}
	}
}
