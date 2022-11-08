using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public class BinaryTree<TNode> : IEnumerable<TNode>, IEnumerable where TNode : BinaryNode<TNode>, new()
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00006395 File Offset: 0x00005395
		// (set) Token: 0x06000276 RID: 630 RVA: 0x0000639D File Offset: 0x0000539D
		public TNode Root { get; protected set; }

		// Token: 0x06000277 RID: 631 RVA: 0x000063A6 File Offset: 0x000053A6
		public virtual IEnumerator<TNode> GetEnumerator()
		{
			if (this.Root == null)
			{
				yield break;
			}
			Stack<TNode> stack = new Stack<TNode>(new TNode[]
			{
				this.Root
			});
			while (stack.Count != 0)
			{
				TNode current = stack.Pop();
				yield return current;
				if (current.Left != null)
				{
					stack.Push(current.Left);
				}
				if (current.Right != null)
				{
					stack.Push(current.Right);
				}
				current = default(TNode);
			}
			yield break;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000063B5 File Offset: 0x000053B5
		public IEnumerable<TNode> Traverse(BinaryTraversalMethod<TNode> method)
		{
			return new BinaryTree<TNode>.BinaryTreeTraversal(this, method);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000063BE File Offset: 0x000053BE
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0200007C RID: 124
		private class BinaryTreeTraversal : IEnumerable<TNode>, IEnumerable
		{
			// Token: 0x06000377 RID: 887 RVA: 0x000087F4 File Offset: 0x000077F4
			public BinaryTreeTraversal(BinaryTree<TNode> tree, BinaryTraversalMethod<TNode> method)
			{
				this.tree = tree;
				this.method = method;
			}

			// Token: 0x06000378 RID: 888 RVA: 0x0000880A File Offset: 0x0000780A
			public IEnumerator<TNode> GetEnumerator()
			{
				return this.method(this.tree);
			}

			// Token: 0x06000379 RID: 889 RVA: 0x0000880A File Offset: 0x0000780A
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.method(this.tree);
			}

			// Token: 0x0400006E RID: 110
			private BinaryTree<TNode> tree;

			// Token: 0x0400006F RID: 111
			private BinaryTraversalMethod<TNode> method;
		}
	}
}
