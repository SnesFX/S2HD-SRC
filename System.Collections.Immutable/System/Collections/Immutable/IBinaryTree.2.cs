using System;

namespace System.Collections.Immutable
{
	// Token: 0x0200000D RID: 13
	internal interface IBinaryTree<out T> : IBinaryTree
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000050 RID: 80
		T Value { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000051 RID: 81
		IBinaryTree<T> Left { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000052 RID: 82
		IBinaryTree<T> Right { get; }
	}
}
