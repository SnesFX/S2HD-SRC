using System;
using System.Diagnostics;

namespace Accord.Diagnostics
{
	// Token: 0x02000060 RID: 96
	public static class Debug
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000633D File Offset: 0x0000533D
		[Conditional("DEBUG")]
		public static void Assert(bool condition, string message = "Internal framework error.")
		{
			if (!condition)
			{
				throw new Exception(message);
			}
		}
	}
}
