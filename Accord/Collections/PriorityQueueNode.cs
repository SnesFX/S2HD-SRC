using System;

namespace Accord.Collections
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public struct PriorityQueueNode<T> : IComparable<PriorityQueueNode<T>>, IEquatable<PriorityQueueNode<T>>
	{
		// Token: 0x06000295 RID: 661 RVA: 0x00006946 File Offset: 0x00005946
		public PriorityQueueNode(T value, double priority, int index, long insertionIndex)
		{
			this.priority = priority;
			this.value = value;
			this.insertionIndex = insertionIndex;
			this.queueIndex = new PriorityQueueNode<T>.Reference
			{
				Value = index
			};
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00006970 File Offset: 0x00005970
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00006978 File Offset: 0x00005978
		public double Priority
		{
			get
			{
				return this.priority;
			}
			internal set
			{
				this.priority = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00006981 File Offset: 0x00005981
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00006989 File Offset: 0x00005989
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

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00006992 File Offset: 0x00005992
		public long InsertionIndex
		{
			get
			{
				return this.insertionIndex;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000699A File Offset: 0x0000599A
		// (set) Token: 0x0600029C RID: 668 RVA: 0x000069A7 File Offset: 0x000059A7
		public int QueueIndex
		{
			get
			{
				return this.queueIndex.Value;
			}
			internal set
			{
				this.queueIndex.Value = value;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000069B5 File Offset: 0x000059B5
		public override bool Equals(object obj)
		{
			return obj is PriorityQueueNode<T> && this.Equals((PriorityQueueNode<T>)obj);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000069D0 File Offset: 0x000059D0
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 23 + this.priority.GetHashCode();
			num = num * 23 + this.value.GetHashCode();
			num = num * 23 + this.insertionIndex.GetHashCode();
			return num * 23 + this.queueIndex.Value.GetHashCode();
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00006A30 File Offset: 0x00005A30
		public bool IsEmpty
		{
			get
			{
				return this.queueIndex == null;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00006A3C File Offset: 0x00005A3C
		public bool Equals(PriorityQueueNode<T> other)
		{
			T t = this.Value;
			return t.Equals(other.value);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00006A68 File Offset: 0x00005A68
		public int CompareTo(PriorityQueueNode<T> other)
		{
			int num = this.Priority.CompareTo(other.Priority);
			if (num == 0)
			{
				num = this.InsertionIndex.CompareTo(other.InsertionIndex);
			}
			return num;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00006AA8 File Offset: 0x00005AA8
		public static bool operator ==(PriorityQueueNode<T> a, PriorityQueueNode<T> b)
		{
			if (a.priority == b.priority && a.InsertionIndex == b.InsertionIndex)
			{
				T t = a.Value;
				return t.Equals(b.Value);
			}
			return false;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00006AF8 File Offset: 0x00005AF8
		public static bool operator !=(PriorityQueueNode<T> a, PriorityQueueNode<T> b)
		{
			if (a.priority == b.priority && a.InsertionIndex == b.InsertionIndex)
			{
				T t = a.Value;
				return !t.Equals(b.Value);
			}
			return true;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00006B49 File Offset: 0x00005B49
		public static bool operator >(PriorityQueueNode<T> a, PriorityQueueNode<T> b)
		{
			if (a.Priority == b.Priority)
			{
				return a.InsertionIndex > b.InsertionIndex;
			}
			return a.Priority > b.Priority;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00006B7C File Offset: 0x00005B7C
		public static bool operator <(PriorityQueueNode<T> a, PriorityQueueNode<T> b)
		{
			if (a.Priority == b.Priority)
			{
				return a.InsertionIndex < b.InsertionIndex;
			}
			return a.Priority < b.Priority;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00006BB0 File Offset: 0x00005BB0
		public override string ToString()
		{
			if (this == PriorityQueueNode<T>.Empty)
			{
				return "None";
			}
			return string.Format("Priority: {0}, Value: {1}, Order: {2}, Index: {3}", new object[]
			{
				this.priority,
				this.value,
				this.insertionIndex,
				this.queueIndex.Value
			});
		}

		// Token: 0x04000039 RID: 57
		private double priority;

		// Token: 0x0400003A RID: 58
		private T value;

		// Token: 0x0400003B RID: 59
		private long insertionIndex;

		// Token: 0x0400003C RID: 60
		private PriorityQueueNode<T>.Reference queueIndex;

		// Token: 0x0400003D RID: 61
		public static readonly PriorityQueueNode<T> Empty;

		// Token: 0x0200007F RID: 127
		[Serializable]
		private class Reference
		{
			// Token: 0x04000079 RID: 121
			public int Value;
		}
	}
}
