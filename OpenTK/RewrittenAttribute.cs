using System;

namespace OpenTK
{
	// Token: 0x02000AF5 RID: 2805
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	internal class RewrittenAttribute : Attribute
	{
		// Token: 0x0600590F RID: 22799 RVA: 0x000F24D8 File Offset: 0x000F06D8
		public RewrittenAttribute(bool rewritten)
		{
			this.Rewritten = rewritten;
		}

		// Token: 0x0400B486 RID: 46214
		internal bool Rewritten;
	}
}
