using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000073 RID: 115
	[Serializable]
	public class RedBlackTreeNode<TKey, TValue> : RedBlackTreeNode<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00007827 File Offset: 0x00006827
		public RedBlackTreeNode()
		{
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000782F File Offset: 0x0000682F
		public RedBlackTreeNode(TKey key, TValue value) : base(new KeyValuePair<TKey, TValue>(key, value))
		{
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000783E File Offset: 0x0000683E
		public RedBlackTreeNode(KeyValuePair<TKey, TValue> item) : base(item)
		{
		}
	}
}
