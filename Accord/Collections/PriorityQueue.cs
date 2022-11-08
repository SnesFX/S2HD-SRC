using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Accord.Collections
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public sealed class PriorityQueue<T> : IEnumerable<PriorityQueueNode<T>>, IEnumerable
	{
		// Token: 0x0600027B RID: 635 RVA: 0x000063C6 File Offset: 0x000053C6
		public PriorityQueue(int capacity = 10, PriorityOrder order = PriorityOrder.Minimum)
		{
			this.numberOfNodes = 0;
			this.nodes = new PriorityQueueNode<T>[capacity + 1];
			this.counter = 0L;
			this.order = order;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600027C RID: 636 RVA: 0x000063F2 File Offset: 0x000053F2
		public int Count
		{
			get
			{
				return this.numberOfNodes;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600027D RID: 637 RVA: 0x000063FA File Offset: 0x000053FA
		public int Capacity
		{
			get
			{
				return this.nodes.Length - 1;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00006406 File Offset: 0x00005406
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000640E File Offset: 0x0000540E
		public PriorityOrder Order
		{
			get
			{
				return this.order;
			}
			set
			{
				this.order = value;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00006417 File Offset: 0x00005417
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			this.numberOfNodes = 0;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00006420 File Offset: 0x00005420
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(PriorityQueueNode<T> node)
		{
			return this.nodes[node.QueueIndex] == node;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000643C File Offset: 0x0000543C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public PriorityQueueNode<T> Enqueue(T value, double priority)
		{
			this.numberOfNodes++;
			if (this.numberOfNodes >= this.nodes.Length)
			{
				this.Resize(this.nodes.Length + (int)(0.1 * (double)this.nodes.Length));
			}
			int index = this.numberOfNodes;
			long num = this.counter;
			this.counter = num + 1L;
			PriorityQueueNode<T> priorityQueueNode = new PriorityQueueNode<T>(value, priority, index, num);
			this.nodes[this.numberOfNodes] = priorityQueueNode;
			this.cascadeUp(ref this.nodes[this.numberOfNodes]);
			return priorityQueueNode;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000064D5 File Offset: 0x000054D5
		[Conditional("DEBUG")]
		private void CheckQueue()
		{
			if (!this.IsValidQueue())
			{
				throw new InvalidOperationException("Queue has been corrupted (Did you update a node priority manually instead of calling UpdatePriority()?Or add the same node to two different queues?)");
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000064EC File Offset: 0x000054EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void swap(int i, int j)
		{
			PriorityQueueNode<T> priorityQueueNode = this.nodes[i];
			this.nodes[i] = this.nodes[j];
			this.nodes[j] = priorityQueueNode;
			this.nodes[i].QueueIndex = i;
			this.nodes[j].QueueIndex = j;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00006550 File Offset: 0x00005550
		private void cascadeUp(ref PriorityQueueNode<T> node)
		{
			int queueIndex = node.QueueIndex;
			int num = node.QueueIndex / 2;
			while (num >= 1 && !this.HasHigherPriority(num, queueIndex))
			{
				this.swap(queueIndex, num);
				queueIndex = this.nodes[num].QueueIndex;
				num = queueIndex / 2;
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000659C File Offset: 0x0000559C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void cascadeDown(ref PriorityQueueNode<T> node)
		{
			int num = node.QueueIndex;
			for (;;)
			{
				int num2 = this.nodes[num].QueueIndex;
				int num3 = 2 * num;
				if (num3 > this.numberOfNodes)
				{
					break;
				}
				if (this.HasHigherPriority(num3, num2))
				{
					num2 = num3;
				}
				int num4 = num3 + 1;
				if (num4 <= this.numberOfNodes && this.HasHigherPriority(num4, num2))
				{
					num2 = num4;
				}
				if (num2 == num)
				{
					break;
				}
				this.swap(num, num2);
				num = num2;
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00006604 File Offset: 0x00005604
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasHigherPriority(int i, int j)
		{
			PriorityQueueNode<T> priorityQueueNode = this.nodes[i];
			PriorityQueueNode<T> priorityQueueNode2 = this.nodes[j];
			if (this.order == PriorityOrder.Minimum)
			{
				return priorityQueueNode.Priority < priorityQueueNode2.Priority || (priorityQueueNode.Priority == priorityQueueNode2.Priority && priorityQueueNode.InsertionIndex < priorityQueueNode2.InsertionIndex);
			}
			return priorityQueueNode.Priority > priorityQueueNode2.Priority || (priorityQueueNode.Priority == priorityQueueNode2.Priority && priorityQueueNode.InsertionIndex < priorityQueueNode2.InsertionIndex);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000669C File Offset: 0x0000569C
		public PriorityQueueNode<T> Dequeue()
		{
			PriorityQueueNode<T> priorityQueueNode = this.nodes[1];
			this.Remove(priorityQueueNode);
			return priorityQueueNode;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000066C0 File Offset: 0x000056C0
		public void Resize(int capacity)
		{
			PriorityQueueNode<T>[] array = new PriorityQueueNode<T>[capacity + 1];
			int num = Math.Min(capacity, this.numberOfNodes);
			for (int i = 1; i <= num; i++)
			{
				array[i] = this.nodes[i];
			}
			this.nodes = array;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00006709 File Offset: 0x00005709
		public PriorityQueueNode<T> First
		{
			get
			{
				return this.nodes[1];
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00005BDC File Offset: 0x00004BDC
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00006717 File Offset: 0x00005717
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdatePriority(ref PriorityQueueNode<T> node, double priority)
		{
			node.Priority = priority;
			this.OnNodeUpdated(ref node);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00006728 File Offset: 0x00005728
		private void OnNodeUpdated(ref PriorityQueueNode<T> node)
		{
			int num = node.QueueIndex / 2;
			if (num > 0 && this.HasHigherPriority(node.QueueIndex, num))
			{
				this.cascadeUp(ref node);
				return;
			}
			this.cascadeDown(ref node);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00006760 File Offset: 0x00005760
		public void Remove(PriorityQueueNode<T> node)
		{
			if (node.QueueIndex == this.numberOfNodes)
			{
				this.nodes[this.numberOfNodes] = PriorityQueueNode<T>.Empty;
				this.numberOfNodes--;
				return;
			}
			int queueIndex = node.QueueIndex;
			this.swap(node.QueueIndex, this.numberOfNodes);
			this.nodes[this.numberOfNodes] = PriorityQueueNode<T>.Empty;
			this.numberOfNodes--;
			this.OnNodeUpdated(ref this.nodes[queueIndex]);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000067F2 File Offset: 0x000057F2
		public IEnumerator<PriorityQueueNode<T>> GetEnumerator()
		{
			int num;
			for (int i = 1; i <= this.numberOfNodes; i = num + 1)
			{
				yield return this.nodes[i];
				num = i;
			}
			yield break;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00006801 File Offset: 0x00005801
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000680C File Offset: 0x0000580C
		public PriorityQueueNode<T>[] ToArray(bool sorted = true)
		{
			PriorityQueueNode<T>[] array = new PriorityQueueNode<T>[this.numberOfNodes];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.nodes[i + 1];
			}
			if (sorted)
			{
				Array.Sort<PriorityQueueNode<T>>(array);
			}
			return array;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00006854 File Offset: 0x00005854
		public bool IsValidQueue()
		{
			for (int i = 1; i < this.nodes.Length; i++)
			{
				if (!this.nodes[i].IsEmpty)
				{
					if (this.checkChildren(i, 2 * i))
					{
						return false;
					}
					if (this.checkChildren(i, 2 * i + 1))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000068A6 File Offset: 0x000058A6
		private bool checkChildren(int currentIndex, int childIndex)
		{
			return childIndex < this.nodes.Length && !this.nodes[childIndex].IsEmpty && this.HasHigherPriority(childIndex, currentIndex);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000068D8 File Offset: 0x000058D8
		public override string ToString()
		{
			PriorityQueueNode<T>[] array = this.ToArray(true);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i]);
				if (i < array.Length - 1)
				{
					stringBuilder.AppendLine(", ");
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x04000035 RID: 53
		private int numberOfNodes;

		// Token: 0x04000036 RID: 54
		private PriorityQueueNode<T>[] nodes;

		// Token: 0x04000037 RID: 55
		private long counter;

		// Token: 0x04000038 RID: 56
		private PriorityOrder order;
	}
}
