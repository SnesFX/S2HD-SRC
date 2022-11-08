using System;

namespace System.Collections.Immutable
{
	// Token: 0x02000016 RID: 22
	internal interface IStrongEnumerable<out T, TEnumerator> where TEnumerator : struct, IStrongEnumerator<T>
	{
		// Token: 0x06000099 RID: 153
		TEnumerator GetEnumerator();
	}
}
