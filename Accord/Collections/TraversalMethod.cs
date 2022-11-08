using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x0200006A RID: 106
	// (Invoke) Token: 0x060002BD RID: 701
	public delegate IEnumerator<TNode> TraversalMethod<TNode>(Tree<TNode> tree) where TNode : TreeNode<TNode>;
}
