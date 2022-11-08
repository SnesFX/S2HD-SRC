using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class RedBlackTree<TKey, TValue> : RedBlackTree<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x060002C5 RID: 709 RVA: 0x00006D9C File Offset: 0x00005D9C
		public RedBlackTree() : base(KeyValuePairComparer<TKey, TValue>.Default)
		{
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00006DA9 File Offset: 0x00005DA9
		public RedBlackTree(IComparer<KeyValuePair<TKey, TValue>> comparer) : base(comparer)
		{
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00006DB2 File Offset: 0x00005DB2
		public RedBlackTree(bool allowDuplicates) : base(KeyValuePairComparer<TKey, TValue>.Default, allowDuplicates)
		{
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00006DC0 File Offset: 0x00005DC0
		public RedBlackTree(IComparer<KeyValuePair<TKey, TValue>> comparer, bool allowDuplicates) : base(comparer, allowDuplicates)
		{
		}
	}
}
