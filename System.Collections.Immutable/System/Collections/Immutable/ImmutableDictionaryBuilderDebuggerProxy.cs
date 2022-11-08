using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x0200001E RID: 30
	internal class ImmutableDictionaryBuilderDebuggerProxy<TKey, TValue>
	{
		// Token: 0x0600017D RID: 381 RVA: 0x00005058 File Offset: 0x00003258
		public ImmutableDictionaryBuilderDebuggerProxy(ImmutableDictionary<TKey, TValue>.Builder map)
		{
			Requires.NotNull<ImmutableDictionary<TKey, TValue>.Builder>(map, "map");
			this._map = map;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00005072 File Offset: 0x00003272
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

		// Token: 0x04000012 RID: 18
		private readonly ImmutableDictionary<TKey, TValue>.Builder _map;

		// Token: 0x04000013 RID: 19
		private KeyValuePair<TKey, TValue>[] _contents;
	}
}
