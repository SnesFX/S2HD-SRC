using System;

namespace System.Collections.Immutable
{
	// Token: 0x02000017 RID: 23
	internal interface IStrongEnumerator<T>
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600009A RID: 154
		T Current { get; }

		// Token: 0x0600009B RID: 155
		bool MoveNext();
	}
}
