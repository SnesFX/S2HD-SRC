using System;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000030 RID: 48
	internal class ImmutableSortedSetBuilderDebuggerProxy<T>
	{
		// Token: 0x06000319 RID: 793 RVA: 0x00008847 File Offset: 0x00006A47
		public ImmutableSortedSetBuilderDebuggerProxy(ImmutableSortedSet<T>.Builder builder)
		{
			Requires.NotNull<ImmutableSortedSet<T>.Builder>(builder, "builder");
			this._set = builder;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00008861 File Offset: 0x00006A61
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Contents
		{
			get
			{
				if (this._contents == null)
				{
					this._contents = this._set.ToArray(this._set.Count);
				}
				return this._contents;
			}
		}

		// Token: 0x04000030 RID: 48
		private readonly ImmutableSortedSet<T>.Builder _set;

		// Token: 0x04000031 RID: 49
		private T[] _contents;
	}
}
