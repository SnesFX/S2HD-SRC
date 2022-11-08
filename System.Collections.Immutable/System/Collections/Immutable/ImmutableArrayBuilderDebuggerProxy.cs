using System;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x0200001B RID: 27
	internal sealed class ImmutableArrayBuilderDebuggerProxy<T>
	{
		// Token: 0x0600011C RID: 284 RVA: 0x000043E9 File Offset: 0x000025E9
		public ImmutableArrayBuilderDebuggerProxy(ImmutableArray<T>.Builder builder)
		{
			this._builder = builder;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000043F8 File Offset: 0x000025F8
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] A
		{
			get
			{
				return this._builder.ToArray();
			}
		}

		// Token: 0x0400000C RID: 12
		private readonly ImmutableArray<T>.Builder _builder;
	}
}
