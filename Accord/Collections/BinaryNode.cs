using System;

namespace Accord.Collections
{
	// Token: 0x02000062 RID: 98
	public class BinaryNode<TNode> : IEquatable<TNode> where TNode : BinaryNode<TNode>
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00006349 File Offset: 0x00005349
		// (set) Token: 0x0600026F RID: 623 RVA: 0x00006351 File Offset: 0x00005351
		public TNode Left { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000635A File Offset: 0x0000535A
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00006362 File Offset: 0x00005362
		public TNode Right { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000636B File Offset: 0x0000536B
		public bool IsLeaf
		{
			get
			{
				return this.Left == null && this.Right == null;
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000638A File Offset: 0x0000538A
		public bool Equals(TNode other)
		{
			return this == other;
		}
	}
}
