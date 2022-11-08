using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000074 RID: 116
	[Serializable]
	public class RedBlackTree<T> : BinaryTree<RedBlackTreeNode<T>>, ICollection<RedBlackTreeNode<T>>, IEnumerable<RedBlackTreeNode<T>>, IEnumerable, ICollection<T>, IEnumerable<T>
	{
		// Token: 0x0600032C RID: 812 RVA: 0x00007847 File Offset: 0x00006847
		public RedBlackTree()
		{
			this.compare = Comparer<T>.Default;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000785A File Offset: 0x0000685A
		public RedBlackTree(IComparer<T> comparer)
		{
			this.compare = comparer;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00007869 File Offset: 0x00006869
		public RedBlackTree(bool allowDuplicates)
		{
			this.compare = Comparer<T>.Default;
			this.duplicates = allowDuplicates;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00007883 File Offset: 0x00006883
		public RedBlackTree(IComparer<T> comparer, bool allowDuplicates)
		{
			this.compare = comparer;
			this.duplicates = allowDuplicates;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00007899 File Offset: 0x00006899
		public int Count
		{
			get
			{
				return this.count;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000331 RID: 817 RVA: 0x000078A1 File Offset: 0x000068A1
		public IComparer<T> Comparer
		{
			get
			{
				return this.compare;
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000078A9 File Offset: 0x000068A9
		public void Clear()
		{
			this.root = null;
			this.count = 0;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x000078BC File Offset: 0x000068BC
		public RedBlackTreeNode<T> Add(T item)
		{
			RedBlackTreeNode<T> redBlackTreeNode = new RedBlackTreeNode<T>(item);
			this.Add(redBlackTreeNode);
			return redBlackTreeNode;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000078D8 File Offset: 0x000068D8
		void ICollection<!0>.Add(T item)
		{
			this.Add(new RedBlackTreeNode<T>(item));
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000078E8 File Offset: 0x000068E8
		public void Add(RedBlackTreeNode<T> item)
		{
			T value = item.Value;
			RedBlackTreeNode<T> redBlackTreeNode = this.root;
			item.Color = RedBlackTreeNodeType.Red;
			item.Parent = null;
			item.Left = null;
			item.Right = null;
			if (redBlackTreeNode == null)
			{
				this.root = item;
				item.Color = RedBlackTreeNodeType.Black;
				this.count++;
				return;
			}
			for (;;)
			{
				int num = this.compare.Compare(value, redBlackTreeNode.Value);
				if (!this.duplicates && num == 0)
				{
					goto Block_3;
				}
				if (num <= 0)
				{
					if (redBlackTreeNode.Left == null)
					{
						goto IL_8A;
					}
					redBlackTreeNode = redBlackTreeNode.Left;
				}
				else
				{
					if (redBlackTreeNode.Right == null)
					{
						goto IL_AB;
					}
					redBlackTreeNode = redBlackTreeNode.Right;
				}
			}
			IL_B9:
			while (item.Parent.Color == RedBlackTreeNodeType.Red)
			{
				RedBlackTreeNode<T> redBlackTreeNode2 = (redBlackTreeNode == redBlackTreeNode.Parent.Left) ? redBlackTreeNode.Parent.Right : redBlackTreeNode.Parent.Left;
				if (redBlackTreeNode2 != null && redBlackTreeNode2.Color == RedBlackTreeNodeType.Red)
				{
					redBlackTreeNode.Color = (redBlackTreeNode2.Color = RedBlackTreeNodeType.Black);
					item = redBlackTreeNode.Parent;
					if ((redBlackTreeNode = item.Parent) == null)
					{
						break;
					}
					item.Color = RedBlackTreeNodeType.Red;
				}
				else
				{
					if (item == redBlackTreeNode.Right && redBlackTreeNode == redBlackTreeNode.Parent.Left)
					{
						this.rotate_left(redBlackTreeNode);
						redBlackTreeNode = item;
						item = item.Left;
					}
					else if (item == redBlackTreeNode.Left && redBlackTreeNode == redBlackTreeNode.Parent.Right)
					{
						this.rotate_right(redBlackTreeNode);
						redBlackTreeNode = item;
						item = item.Right;
					}
					redBlackTreeNode.Color = RedBlackTreeNodeType.Black;
					redBlackTreeNode.Parent.Color = RedBlackTreeNodeType.Red;
					if (item == redBlackTreeNode.Left && redBlackTreeNode == redBlackTreeNode.Parent.Left)
					{
						this.rotate_right(redBlackTreeNode.Parent);
						break;
					}
					if (item == redBlackTreeNode.Right && redBlackTreeNode == redBlackTreeNode.Parent.Right)
					{
						this.rotate_left(redBlackTreeNode.Parent);
						break;
					}
					break;
				}
			}
			this.count++;
			return;
			Block_3:
			redBlackTreeNode.Value = item.Value;
			return;
			IL_8A:
			redBlackTreeNode.Left = item;
			item.Parent = redBlackTreeNode;
			goto IL_B9;
			IL_AB:
			redBlackTreeNode.Right = item;
			item.Parent = redBlackTreeNode;
			goto IL_B9;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00007ADC File Offset: 0x00006ADC
		bool ICollection<!0>.Remove(T item)
		{
			RedBlackTreeNode<T> redBlackTreeNode = this.Find(item);
			return redBlackTreeNode != null && this.Remove(redBlackTreeNode) != null;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00007B00 File Offset: 0x00006B00
		bool ICollection<RedBlackTreeNode<!0>>.Remove(RedBlackTreeNode<T> item)
		{
			return this.Remove(item) != null;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00007B0C File Offset: 0x00006B0C
		public RedBlackTreeNode<T> Remove(T item)
		{
			RedBlackTreeNode<T> redBlackTreeNode = this.Find(item);
			if (redBlackTreeNode == null)
			{
				return null;
			}
			return this.Remove(redBlackTreeNode);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00007B30 File Offset: 0x00006B30
		public RedBlackTreeNode<T> Remove(RedBlackTreeNode<T> node)
		{
			T value = node.Value;
			if (node.Left != null && node.Right != null)
			{
				RedBlackTreeNode<T> redBlackTreeNode = node.Left;
				while (redBlackTreeNode.Right != null)
				{
					redBlackTreeNode = redBlackTreeNode.Right;
				}
				node.Value = redBlackTreeNode.Value;
				node = redBlackTreeNode;
			}
			RedBlackTreeNode<T> redBlackTreeNode2 = (node.Left != null) ? node.Left : node.Right;
			if (node.Parent != null)
			{
				if (node.Parent.Right == node)
				{
					node.Parent.Right = redBlackTreeNode2;
				}
				else
				{
					node.Parent.Left = redBlackTreeNode2;
				}
			}
			else
			{
				this.root = redBlackTreeNode2;
			}
			RedBlackTreeNode<T> parent = node.Parent;
			if (redBlackTreeNode2 != null)
			{
				redBlackTreeNode2.Parent = parent;
			}
			if (node.Color == RedBlackTreeNodeType.Black)
			{
				if (redBlackTreeNode2 != null && redBlackTreeNode2.Color == RedBlackTreeNodeType.Red)
				{
					redBlackTreeNode2.Color = RedBlackTreeNodeType.Black;
				}
				else
				{
					while (parent != null)
					{
						RedBlackTreeNode<T> redBlackTreeNode3 = (redBlackTreeNode2 == parent.Left) ? parent.Right : parent.Left;
						if (redBlackTreeNode3.Color == RedBlackTreeNodeType.Red)
						{
							parent.Color = RedBlackTreeNodeType.Red;
							redBlackTreeNode3.Color = RedBlackTreeNodeType.Black;
							if (redBlackTreeNode2 == parent.Left)
							{
								this.rotate_left(parent);
							}
							else
							{
								this.rotate_right(parent);
							}
							redBlackTreeNode3 = ((redBlackTreeNode2 == parent.Left) ? parent.Right : parent.Left);
						}
						if (parent.Color == RedBlackTreeNodeType.Black && redBlackTreeNode3.Color == RedBlackTreeNodeType.Black && (redBlackTreeNode3.Left == null || redBlackTreeNode3.Left.Color == RedBlackTreeNodeType.Black) && (redBlackTreeNode3.Right == null || redBlackTreeNode3.Right.Color == RedBlackTreeNodeType.Black))
						{
							if (redBlackTreeNode3 != null)
							{
								redBlackTreeNode3.Color = RedBlackTreeNodeType.Red;
							}
							redBlackTreeNode2 = parent;
							parent = redBlackTreeNode2.Parent;
						}
						else
						{
							if (parent.Color == RedBlackTreeNodeType.Red && redBlackTreeNode3.Color == RedBlackTreeNodeType.Black && (redBlackTreeNode3.Left == null || redBlackTreeNode3.Left.Color == RedBlackTreeNodeType.Black) && (redBlackTreeNode3.Right == null || redBlackTreeNode3.Right.Color == RedBlackTreeNodeType.Black))
							{
								if (redBlackTreeNode3 != null)
								{
									redBlackTreeNode3.Color = RedBlackTreeNodeType.Red;
								}
								parent.Color = RedBlackTreeNodeType.Black;
								break;
							}
							if (redBlackTreeNode2 == parent.Left && redBlackTreeNode3.Color == RedBlackTreeNodeType.Black && redBlackTreeNode3.Left != null && redBlackTreeNode3.Left.Color == RedBlackTreeNodeType.Red && (redBlackTreeNode3.Right == null || redBlackTreeNode3.Right.Color == RedBlackTreeNodeType.Black))
							{
								redBlackTreeNode3.Color = RedBlackTreeNodeType.Red;
								redBlackTreeNode3.Left.Color = RedBlackTreeNodeType.Black;
								this.rotate_right(redBlackTreeNode3);
								redBlackTreeNode3 = ((redBlackTreeNode2 == parent.Left) ? parent.Right : parent.Left);
							}
							else if (redBlackTreeNode2 == parent.Right && redBlackTreeNode3.Color == RedBlackTreeNodeType.Black && redBlackTreeNode3.Right != null && redBlackTreeNode3.Right.Color == RedBlackTreeNodeType.Red && (redBlackTreeNode3.Left == null || redBlackTreeNode3.Left.Color == RedBlackTreeNodeType.Black))
							{
								redBlackTreeNode3.Color = RedBlackTreeNodeType.Red;
								redBlackTreeNode3.Right.Color = RedBlackTreeNodeType.Black;
								this.rotate_left(redBlackTreeNode3);
								redBlackTreeNode3 = ((redBlackTreeNode2 == parent.Left) ? parent.Right : parent.Left);
							}
							redBlackTreeNode3.Color = parent.Color;
							parent.Color = RedBlackTreeNodeType.Black;
							if (redBlackTreeNode2 == parent.Left)
							{
								redBlackTreeNode3.Right.Color = RedBlackTreeNodeType.Black;
								this.rotate_left(parent);
								break;
							}
							redBlackTreeNode3.Left.Color = RedBlackTreeNodeType.Black;
							this.rotate_right(parent);
							break;
						}
					}
				}
			}
			this.count--;
			node.Value = value;
			return node;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00007E70 File Offset: 0x00006E70
		public void CopyTo(RedBlackTreeNode<T>[] array, int arrayIndex)
		{
			foreach (RedBlackTreeNode<T> redBlackTreeNode in this)
			{
				array[arrayIndex++] = redBlackTreeNode;
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00007EBC File Offset: 0x00006EBC
		public void CopyTo(T[] array, int arrayIndex)
		{
			foreach (RedBlackTreeNode<T> redBlackTreeNode in this)
			{
				array[arrayIndex++] = redBlackTreeNode.Value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00005BDC File Offset: 0x00004BDC
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00007F10 File Offset: 0x00006F10
		public override IEnumerator<RedBlackTreeNode<T>> GetEnumerator()
		{
			RedBlackTreeNode<T> node = this.root;
			RedBlackTreeNode<T> redBlackTreeNode = null;
			while (node != null)
			{
				if (redBlackTreeNode == node.Parent)
				{
					if (node.Left != null)
					{
						redBlackTreeNode = node;
						node = node.Left;
						continue;
					}
					redBlackTreeNode = null;
				}
				if (redBlackTreeNode == node.Left)
				{
					yield return node;
					if (node.Right != null)
					{
						redBlackTreeNode = node;
						node = node.Right;
						continue;
					}
					redBlackTreeNode = null;
				}
				if (redBlackTreeNode == node.Right)
				{
					redBlackTreeNode = node;
					node = node.Parent;
				}
			}
			yield break;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00007F1F File Offset: 0x00006F1F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00007F27 File Offset: 0x00006F27
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			foreach (RedBlackTreeNode<T> redBlackTreeNode in this)
			{
				yield return redBlackTreeNode.Value;
			}
			IEnumerator<RedBlackTreeNode<T>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00007F36 File Offset: 0x00006F36
		public bool Contains(T item)
		{
			return this.Find(item) != null;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00007F42 File Offset: 0x00006F42
		public bool Contains(RedBlackTreeNode<T> item)
		{
			return this.Find(item.Value) != null;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00007F54 File Offset: 0x00006F54
		public RedBlackTreeNode<T> Find(T item)
		{
			int num;
			for (RedBlackTreeNode<T> redBlackTreeNode = this.root; redBlackTreeNode != null; redBlackTreeNode = ((num <= 0) ? redBlackTreeNode.Left : redBlackTreeNode.Right))
			{
				num = this.compare.Compare(item, redBlackTreeNode.Value);
				if (num == 0)
				{
					return redBlackTreeNode;
				}
			}
			return null;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00007F9C File Offset: 0x00006F9C
		public RedBlackTreeNode<T> FindLessThanOrEqualTo(RedBlackTreeNode<T> node, T value)
		{
			while (node != null)
			{
				if (this.compare.Compare(node.Value, value) <= 0)
				{
					RedBlackTreeNode<T> redBlackTreeNode = this.FindLessThanOrEqualTo(node.Right, value);
					if (redBlackTreeNode != null)
					{
						return redBlackTreeNode;
					}
					return node;
				}
				else
				{
					node = node.Left;
				}
			}
			return null;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00007FE1 File Offset: 0x00006FE1
		public RedBlackTreeNode<T> FindLessThanOrEqualTo(T value)
		{
			return this.FindLessThanOrEqualTo(this.root, value);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00007FF0 File Offset: 0x00006FF0
		public RedBlackTreeNode<T> FindLessThan(RedBlackTreeNode<T> node, T value)
		{
			while (node != null)
			{
				if (this.compare.Compare(node.Value, value) < 0)
				{
					RedBlackTreeNode<T> redBlackTreeNode = this.FindLessThan(node.Right, value);
					if (redBlackTreeNode != null)
					{
						return redBlackTreeNode;
					}
					return node;
				}
				else
				{
					node = node.Left;
				}
			}
			return null;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00008035 File Offset: 0x00007035
		public RedBlackTreeNode<T> FindLessThan(T value)
		{
			return this.FindLessThan(this.root, value);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00008044 File Offset: 0x00007044
		public RedBlackTreeNode<T> FindGreaterThan(RedBlackTreeNode<T> node, T value)
		{
			while (node != null)
			{
				if (this.compare.Compare(node.Value, value) > 0)
				{
					RedBlackTreeNode<T> redBlackTreeNode = this.FindGreaterThan(node.Left, value);
					if (redBlackTreeNode != null)
					{
						return redBlackTreeNode;
					}
					return node;
				}
				else
				{
					node = node.Right;
				}
			}
			return null;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00008089 File Offset: 0x00007089
		public RedBlackTreeNode<T> FindGreaterThan(T value)
		{
			return this.FindGreaterThan(this.root, value);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00008098 File Offset: 0x00007098
		public RedBlackTreeNode<T> Min()
		{
			RedBlackTreeNode<T> left = this.root;
			while (left != null && left.Left != null)
			{
				left = left.Left;
			}
			return left;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000080C4 File Offset: 0x000070C4
		public RedBlackTreeNode<T> Max()
		{
			RedBlackTreeNode<T> right = this.root;
			while (right != null && right.Right != null)
			{
				right = right.Right;
			}
			return right;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000080F0 File Offset: 0x000070F0
		public RedBlackTreeNode<T> GetNextNode(RedBlackTreeNode<T> node)
		{
			if (node == null)
			{
				return null;
			}
			if (node.Right == null)
			{
				RedBlackTreeNode<T> redBlackTreeNode;
				do
				{
					redBlackTreeNode = node;
					node = node.Parent;
					if (node == null)
					{
						break;
					}
				}
				while (redBlackTreeNode == node.Right);
			}
			else
			{
				node = node.Right;
				while (node.Left != null)
				{
					node = node.Left;
				}
			}
			return node;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00008140 File Offset: 0x00007140
		public RedBlackTreeNode<T> GetPreviousNode(RedBlackTreeNode<T> node)
		{
			if (node == null)
			{
				return null;
			}
			if (node.Left == null)
			{
				RedBlackTreeNode<T> redBlackTreeNode;
				do
				{
					redBlackTreeNode = node;
					node = node.Parent;
					if (node == null)
					{
						break;
					}
				}
				while (redBlackTreeNode == node.Left);
			}
			else
			{
				node = node.Left;
				while (node.Right != null)
				{
					node = node.Right;
				}
			}
			return node;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000818D File Offset: 0x0000718D
		public RedBlackTreeNode<T> Resort(RedBlackTreeNode<T> node)
		{
			node = this.Remove(node);
			this.Add(node);
			return node;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000081A0 File Offset: 0x000071A0
		private void rotate_left(RedBlackTreeNode<T> p)
		{
			RedBlackTreeNode<T> right = p.Right;
			p.Right = right.Left;
			right.Left = p;
			if (p.Parent != null)
			{
				if (p == p.Parent.Left)
				{
					p.Parent.Left = right;
				}
				else
				{
					p.Parent.Right = right;
				}
			}
			else
			{
				this.root = right;
			}
			right.Parent = p.Parent;
			p.Parent = right;
			if (p.Right != null)
			{
				p.Right.Parent = p;
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00008228 File Offset: 0x00007228
		private void rotate_right(RedBlackTreeNode<T> p)
		{
			RedBlackTreeNode<T> left = p.Left;
			p.Left = left.Right;
			left.Right = p;
			if (p.Parent != null)
			{
				if (p == p.Parent.Left)
				{
					p.Parent.Left = left;
				}
				else
				{
					p.Parent.Right = left;
				}
			}
			else
			{
				this.root = left;
			}
			left.Parent = p.Parent;
			p.Parent = left;
			if (p.Left != null)
			{
				p.Left.Parent = p;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000082B0 File Offset: 0x000072B0
		internal bool check_node(RedBlackTreeNode<T> n, ref int nblack)
		{
			int num = 0;
			int num2 = 0;
			if (n == null)
			{
				nblack = 0;
				return true;
			}
			if (n.Right != null && n.Right.Parent != n)
			{
				return false;
			}
			if (n.Right != null && this.compare.Compare(n.Right.Value, n.Value) < 0)
			{
				return false;
			}
			if (n.Left != null && n.Left.Parent != n)
			{
				return false;
			}
			if (n.Left != null && this.compare.Compare(n.Left.Value, n.Value) > 0)
			{
				return false;
			}
			if (n.Color == RedBlackTreeNodeType.Red)
			{
				if (n.Right != null && n.Right.Color == RedBlackTreeNodeType.Red)
				{
					return false;
				}
				if (n.Left != null && n.Left.Color == RedBlackTreeNodeType.Red)
				{
					return false;
				}
			}
			if (!this.check_node(n.Right, ref num) || !this.check_node(n.Left, ref num2))
			{
				return false;
			}
			if (num != num2)
			{
				return false;
			}
			nblack = num + ((n.Color == RedBlackTreeNodeType.Black) ? 1 : 0);
			return true;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000083BC File Offset: 0x000073BC
		internal bool check()
		{
			int num = 0;
			return this.root == null || (this.root.Color == RedBlackTreeNodeType.Black && this.check_node(this.root, ref num));
		}

		// Token: 0x04000050 RID: 80
		private IComparer<T> compare;

		// Token: 0x04000051 RID: 81
		private RedBlackTreeNode<T> root;

		// Token: 0x04000052 RID: 82
		private int count;

		// Token: 0x04000053 RID: 83
		private bool duplicates;
	}
}
