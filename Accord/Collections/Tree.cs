using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000067 RID: 103
	[Serializable]
	public class Tree<TNode> : IEnumerable<TNode>, IEnumerable where TNode : TreeNode<TNode>
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00006C24 File Offset: 0x00005C24
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00006C2C File Offset: 0x00005C2C
		public TNode Root { get; protected set; }

		// Token: 0x060002AA RID: 682 RVA: 0x00006C35 File Offset: 0x00005C35
		public IEnumerator<TNode> GetEnumerator()
		{
			foreach (TNode tnode in this.Traverse(new TraversalMethod<TNode>(TreeTraversal.DepthFirst<TNode>)))
			{
				yield return tnode;
			}
			IEnumerator<TNode> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00006C44 File Offset: 0x00005C44
		public IEnumerable<TNode> Traverse(TraversalMethod<TNode> method)
		{
			return new Tree<TNode>.InnerTreeTraversal(this, method);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00006C4D File Offset: 0x00005C4D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x02000080 RID: 128
		private class InnerTreeTraversal : IEnumerable<TNode>, IEnumerable
		{
			// Token: 0x06000387 RID: 903 RVA: 0x000089EB File Offset: 0x000079EB
			public InnerTreeTraversal(Tree<TNode> tree, TraversalMethod<TNode> method)
			{
				this.tree = tree;
				this.method = method;
			}

			// Token: 0x06000388 RID: 904 RVA: 0x00008A01 File Offset: 0x00007A01
			public IEnumerator<TNode> GetEnumerator()
			{
				return this.method(this.tree);
			}

			// Token: 0x06000389 RID: 905 RVA: 0x00008A01 File Offset: 0x00007A01
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.method(this.tree);
			}

			// Token: 0x0400007A RID: 122
			private Tree<TNode> tree;

			// Token: 0x0400007B RID: 123
			private TraversalMethod<TNode> method;
		}
	}
}
