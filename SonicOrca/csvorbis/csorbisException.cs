using System;

namespace csvorbis
{
	// Token: 0x02000066 RID: 102
	public class csorbisException : Exception
	{
		// Token: 0x06000380 RID: 896 RVA: 0x0000671D File Offset: 0x0000491D
		public csorbisException()
		{
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000DCBE File Offset: 0x0000BEBE
		public csorbisException(string s) : base("csorbis: " + s)
		{
		}
	}
}
