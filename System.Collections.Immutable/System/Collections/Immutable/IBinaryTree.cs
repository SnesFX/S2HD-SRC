using System;

namespace System.Collections.Immutable
{
	// Token: 0x0200000C RID: 12
	internal interface IBinaryTree
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004B RID: 75
		int Height { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004C RID: 76
		bool IsEmpty { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004D RID: 77
		int Count { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004E RID: 78
		IBinaryTree Left { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004F RID: 79
		IBinaryTree Right { get; }
	}
}
