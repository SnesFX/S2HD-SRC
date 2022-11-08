using System;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000027 RID: 39
	internal class ImmutableListBuilderDebuggerProxy<T>
	{
		// Token: 0x06000259 RID: 601 RVA: 0x00007142 File Offset: 0x00005342
		public ImmutableListBuilderDebuggerProxy(ImmutableList<T>.Builder builder)
		{
			Requires.NotNull<ImmutableList<T>.Builder>(builder, "builder");
			this._list = builder;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000715C File Offset: 0x0000535C
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

		// Token: 0x0400001D RID: 29
		private readonly ImmutableList<T>.Builder _list;

		// Token: 0x0400001E RID: 30
		private T[] _cachedContents;
	}
}
