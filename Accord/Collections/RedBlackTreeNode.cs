using System;

namespace Accord.Collections
{
	// Token: 0x02000072 RID: 114
	[Serializable]
	public class RedBlackTreeNode<T> : BinaryNode<RedBlackTreeNode<T>>
	{
		// Token: 0x06000320 RID: 800 RVA: 0x0000778A File Offset: 0x0000678A
		public RedBlackTreeNode()
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00007792 File Offset: 0x00006792
		public RedBlackTreeNode(T value)
		{
			this.value = value;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000322 RID: 802 RVA: 0x000077A1 File Offset: 0x000067A1
		// (set) Token: 0x06000323 RID: 803 RVA: 0x000077A9 File Offset: 0x000067A9
		public RedBlackTreeNode<T> Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000324 RID: 804 RVA: 0x000077B2 File Offset: 0x000067B2
		// (set) Token: 0x06000325 RID: 805 RVA: 0x000077BA File Offset: 0x000067BA
		public RedBlackTreeNodeType Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000077C3 File Offset: 0x000067C3
		// (set) Token: 0x06000327 RID: 807 RVA: 0x000077CB File Offset: 0x000067CB
		public T Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000077D4 File Offset: 0x000067D4
		public override string ToString()
		{
			if (this.color == RedBlackTreeNodeType.Black)
			{
				return "Black: {0)".Format(new object[]
				{
					this.Value
				});
			}
			return "Red: {0)".Format(new object[]
			{
				this.Value
			});
		}

		// Token: 0x0400004D RID: 77
		private RedBlackTreeNode<T> parent;

		// Token: 0x0400004E RID: 78
		private RedBlackTreeNodeType color;

		// Token: 0x0400004F RID: 79
		private T value;
	}
}
