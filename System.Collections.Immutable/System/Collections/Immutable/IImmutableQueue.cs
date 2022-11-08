using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000013 RID: 19
	public interface IImmutableQueue<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000080 RID: 128
		bool IsEmpty { get; }

		// Token: 0x06000081 RID: 129
		IImmutableQueue<T> Clear();

		// Token: 0x06000082 RID: 130
		T Peek();

		// Token: 0x06000083 RID: 131
		IImmutableQueue<T> Enqueue(T value);

		// Token: 0x06000084 RID: 132
		IImmutableQueue<T> Dequeue();
	}
}
