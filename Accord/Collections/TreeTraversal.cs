using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x0200006B RID: 107
	public static class TreeTraversal
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x00006D51 File Offset: 0x00005D51
		public static IEnumerator<TNode> BreadthFirst<TNode>(BinaryTree<TNode> tree) where TNode : BinaryNode<TNode>, new()
		{
			if (tree.Root == null)
			{
				yield break;
			}
			Queue<TNode> queue = new Queue<TNode>(new TNode[]
			{
				tree.Root
			});
			while (queue.Count != 0)
			{
				TNode current = queue.Dequeue();
				yield return current;
				if (current.Left != null)
				{
					queue.Enqueue(current.Left);
				}
				if (current.Right != null)
				{
					queue.Enqueue(current.Right);
				}
				current = default(TNode);
			}
			yield break;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00006D60 File Offset: 0x00005D60
		public static IEnumerator<TNode> PreOrder<TNode>(BinaryTree<TNode> tree) where TNode : BinaryNode<TNode>, new()
		{
			if (tree.Root == null)
			{
				yield break;
			}
			Stack<TNode> stack = new Stack<TNode>();
			TNode current = tree.Root;
			while (stack.Count != 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					yield return current;
					current = current.Left;
				}
				else
				{
					current = stack.Pop();
					current = current.Right;
				}
			}
			yield break;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00006D6F File Offset: 0x00005D6F
		public static IEnumerator<TNode> InOrder<TNode>(BinaryTree<TNode> tree) where TNode : BinaryNode<TNode>, new()
		{
			if (tree.Root == null)
			{
				yield break;
			}
			Stack<TNode> stack = new Stack<TNode>();
			TNode current = tree.Root;
			while (stack.Count != 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.Left;
				}
				else
				{
					current = stack.Pop();
					yield return current;
					current = current.Right;
				}
			}
			yield break;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00006D7E File Offset: 0x00005D7E
		public static IEnumerator<TNode> PostOrder<TNode>(BinaryTree<TNode> tree) where TNode : BinaryNode<TNode>, new()
		{
			if (tree.Root == null)
			{
				yield break;
			}
			Stack<TNode> stack = new Stack<TNode>(new TNode[]
			{
				tree.Root
			});
			TNode previous = tree.Root;
			while (stack.Count != 0)
			{
				TNode current = stack.Peek();
				if (previous == current || previous.Left == current || previous.Right == current)
				{
					if (current.Left != null)
					{
						stack.Push(current.Left);
					}
					else if (current.Right != null)
					{
						stack.Push(current.Right);
					}
					else
					{
						yield return stack.Pop();
					}
				}
				else if (current.Left == previous)
				{
					if (current.Right != null)
					{
						stack.Push(current.Right);
					}
					else
					{
						yield return stack.Pop();
					}
				}
				else
				{
					if (current.Right != previous)
					{
						throw new InvalidOperationException();
					}
					yield return stack.Pop();
				}
				previous = current;
				current = default(TNode);
			}
			yield break;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00006D8D File Offset: 0x00005D8D
		public static IEnumerator<TNode> DepthFirst<TNode>(Tree<TNode> tree) where TNode : TreeNode<TNode>
		{
			if (tree.Root == null)
			{
				yield break;
			}
			TNode node = tree.Root;
			while (node != null)
			{
				yield return node;
				if (node.IsLeaf)
				{
					while (node.Next == null && node.Parent != null)
					{
						node = node.Parent;
					}
					node = node.Next;
				}
				else
				{
					node = node.Children[0];
				}
			}
			yield break;
		}
	}
}
