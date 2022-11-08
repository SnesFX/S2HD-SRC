using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000069 RID: 105
	// (Invoke) Token: 0x060002B9 RID: 697
	public delegate IEnumerator<TNode> BinaryTraversalMethod<TNode>(BinaryTree<TNode> tree) where TNode : BinaryNode<TNode>, new();
}
