using System;

namespace Accord.Collections
{
	// Token: 0x02000068 RID: 104
	public class TreeNode<TNode> where TNode : TreeNode<TNode>
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00006C55 File Offset: 0x00005C55
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00006C5D File Offset: 0x00005C5D
		public TNode Parent { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00006C66 File Offset: 0x00005C66
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00006C6E File Offset: 0x00005C6E
		public int Index { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00006C77 File Offset: 0x00005C77
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00006C7F File Offset: 0x00005C7F
		public TNode[] Children { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00006C88 File Offset: 0x00005C88
		public TNode Next
		{
			get
			{
				if (this.Parent == null)
				{
					return default(TNode);
				}
				if (this.Index + 1 >= this.Parent.Children.Length)
				{
					return default(TNode);
				}
				return this.Parent.Children[this.Index + 1];
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00006CF0 File Offset: 0x00005CF0
		public TNode Previous
		{
			get
			{
				if (this.Index == 0)
				{
					return default(TNode);
				}
				return this.Parent.Children[this.Index - 1];
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00006D2C File Offset: 0x00005D2C
		public bool IsLeaf
		{
			get
			{
				return this.Children == null || this.Children.Length == 0;
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00006D42 File Offset: 0x00005D42
		public TreeNode(int index)
		{
			this.Index = index;
		}
	}
}
