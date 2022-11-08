using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x0200002D RID: 45
	internal class ImmutableSortedDictionaryBuilderDebuggerProxy<TKey, TValue>
	{
		// Token: 0x060002C3 RID: 707 RVA: 0x00007D4E File Offset: 0x00005F4E
		public ImmutableSortedDictionaryBuilderDebuggerProxy(ImmutableSortedDictionary<TKey, TValue>.Builder map)
		{
			Requires.NotNull<ImmutableSortedDictionary<TKey, TValue>.Builder>(map, "map");
			this._map = map;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00007D68 File Offset: 0x00005F68
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<TKey, TValue>[] Contents
		{
			get
			{
				if (this._contents == null)
				{
					this._contents = this._map.ToArray(this._map.Count);
				}
				return this._contents;
			}
		}

		// Token: 0x0400002A RID: 42
		private readonly ImmutableSortedDictionary<TKey, TValue>.Builder _map;

		// Token: 0x0400002B RID: 43
		private KeyValuePair<TKey, TValue>[] _contents;
	}
}
