using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x02000020 RID: 32
	internal class ImmutableEnumerableDebuggerProxy<T>
	{
		// Token: 0x06000180 RID: 384 RVA: 0x000050A7 File Offset: 0x000032A7
		public ImmutableEnumerableDebuggerProxy(IEnumerable<T> enumerable)
		{
			Requires.NotNull<IEnumerable<T>>(enumerable, "enumerable");
			this._enumerable = enumerable;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000181 RID: 385 RVA: 0x000050C4 File Offset: 0x000032C4
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Contents
		{
			get
			{
				T[] result;
				if ((result = this._cachedContents) == null)
				{
					result = (this._cachedContents = this._enumerable.ToArray<T>());
				}
				return result;
			}
		}

		// Token: 0x04000014 RID: 20
		private readonly IEnumerable<T> _enumerable;

		// Token: 0x04000015 RID: 21
		private T[] _cachedContents;
	}
}
