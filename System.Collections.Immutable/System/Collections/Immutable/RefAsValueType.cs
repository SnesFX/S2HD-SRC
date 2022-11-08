using System;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000036 RID: 54
	[DebuggerDisplay("{Value,nq}")]
	internal struct RefAsValueType<T>
	{
		// Token: 0x06000343 RID: 835 RVA: 0x00008C3C File Offset: 0x00006E3C
		internal RefAsValueType(T value)
		{
			this.Value = value;
		}

		// Token: 0x04000037 RID: 55
		internal T Value;
	}
}
