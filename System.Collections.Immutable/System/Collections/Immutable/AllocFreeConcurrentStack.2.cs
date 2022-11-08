using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000009 RID: 9
	internal static class AllocFreeConcurrentStack
	{
		// Token: 0x04000005 RID: 5
		[ThreadStatic]
		internal static Dictionary<Type, object> t_stacks;
	}
}
