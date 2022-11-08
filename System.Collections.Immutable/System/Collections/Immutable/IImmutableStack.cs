using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000015 RID: 21
	public interface IImmutableStack<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000094 RID: 148
		bool IsEmpty { get; }

		// Token: 0x06000095 RID: 149
		IImmutableStack<T> Clear();

		// Token: 0x06000096 RID: 150
		IImmutableStack<T> Push(T value);

		// Token: 0x06000097 RID: 151
		IImmutableStack<T> Pop();

		// Token: 0x06000098 RID: 152
		T Peek();
	}
}
