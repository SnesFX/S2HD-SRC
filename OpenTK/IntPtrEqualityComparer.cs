using System;
using System.Collections.Generic;

namespace OpenTK
{
	// Token: 0x0200059E RID: 1438
	internal class IntPtrEqualityComparer : IEqualityComparer<IntPtr>
	{
		// Token: 0x060045F7 RID: 17911 RVA: 0x000C0B30 File Offset: 0x000BED30
		public bool Equals(IntPtr x, IntPtr y)
		{
			return x == y;
		}

		// Token: 0x060045F8 RID: 17912 RVA: 0x000C0B3C File Offset: 0x000BED3C
		public int GetHashCode(IntPtr obj)
		{
			return obj.GetHashCode();
		}
	}
}
