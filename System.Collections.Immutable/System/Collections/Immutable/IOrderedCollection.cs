using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000018 RID: 24
	internal interface IOrderedCollection<out T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600009C RID: 156
		int Count { get; }

		// Token: 0x1700001F RID: 31
		T this[int index]
		{
			get;
		}
	}
}
