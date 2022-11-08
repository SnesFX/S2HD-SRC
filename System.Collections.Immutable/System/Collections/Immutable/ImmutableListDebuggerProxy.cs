using System;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000028 RID: 40
	internal class ImmutableListDebuggerProxy<T>
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00007188 File Offset: 0x00005388
		public ImmutableListDebuggerProxy(ImmutableList<T> list)
		{
			Requires.NotNull<ImmutableList<T>>(list, "list");
			this._list = list;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000071A2 File Offset: 0x000053A2
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Contents
		{
			get
			{
				if (this._cachedContents == null)
				{
					this._cachedContents = this._list.ToArray(this._list.Count);
				}
				return this._cachedContents;
			}
		}

		// Token: 0x0400001F RID: 31
		private readonly ImmutableList<T> _list;

		// Token: 0x04000020 RID: 32
		private T[] _cachedContents;
	}
}
