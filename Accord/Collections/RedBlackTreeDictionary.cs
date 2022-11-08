using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class RedBlackTreeDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable
	{
		// Token: 0x06000306 RID: 774 RVA: 0x00007348 File Offset: 0x00006348
		public RedBlackTreeDictionary()
		{
			this.init(Comparer<TKey>.Default);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000735B File Offset: 0x0000635B
		public RedBlackTreeDictionary(IComparer<TKey> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			this.init(comparer);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00007378 File Offset: 0x00006378
		private void init(IComparer<TKey> comparer)
		{
			KeyValuePairComparer<TKey, TValue> comparer2 = new KeyValuePairComparer<TKey, TValue>(comparer);
			this.tree = new RedBlackTree<TKey, TValue>(comparer2, false);
			this.values = new RedBlackTreeDictionary<TKey, TValue>.ValueCollection(this.tree);
			this.keys = new RedBlackTreeDictionary<TKey, TValue>.KeyCollection(this.tree);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000073BB File Offset: 0x000063BB
		public void Add(TKey key, TValue value)
		{
			this.tree.Add(new RedBlackTreeNode<TKey, TValue>(key, value));
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000073CF File Offset: 0x000063CF
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.tree.Add(new RedBlackTreeNode<TKey, TValue>(item));
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000073E4 File Offset: 0x000063E4
		public bool Remove(TKey key)
		{
			return this.Remove(new KeyValuePair<TKey, TValue>(key, default(TValue)));
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00007408 File Offset: 0x00006408
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = this.tree.Find(item);
			if (redBlackTreeNode == null)
			{
				return false;
			}
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode2 = this.tree.Remove(redBlackTreeNode);
			return redBlackTreeNode2 != null;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00007438 File Offset: 0x00006438
		public bool ContainsKey(TKey key)
		{
			return this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue))) != null;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00007464 File Offset: 0x00006464
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = this.tree.Find(item);
			if (redBlackTreeNode != null)
			{
				TValue value = item.Value;
				return value.Equals(redBlackTreeNode.Value);
			}
			return false;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600030F RID: 783 RVA: 0x000074A3 File Offset: 0x000064A3
		public ICollection<TKey> Keys
		{
			get
			{
				return this.keys;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000074AB File Offset: 0x000064AB
		public ICollection<TValue> Values
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000074B4 File Offset: 0x000064B4
		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = this.tree.Find(new KeyValuePair<TKey, TValue>(key, value));
			if (redBlackTreeNode == null)
			{
				return false;
			}
			value = redBlackTreeNode.Value.Value;
			return true;
		}

		// Token: 0x1700005D RID: 93
		public TValue this[TKey key]
		{
			get
			{
				RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
				if (redBlackTreeNode == null)
				{
					throw new KeyNotFoundException("The requested key was not found in the present tree.");
				}
				return redBlackTreeNode.Value.Value;
			}
			set
			{
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
				RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = this.tree.Find(keyValuePair);
				if (redBlackTreeNode != null)
				{
					redBlackTreeNode.Value = keyValuePair;
					return;
				}
				this.Add(keyValuePair);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00007575 File Offset: 0x00006575
		public void Clear()
		{
			this.tree.Clear();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00007584 File Offset: 0x00006584
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.tree)
			{
				array[arrayIndex++] = redBlackTreeNode.Value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000316 RID: 790 RVA: 0x000075DC File Offset: 0x000065DC
		public int Count
		{
			get
			{
				return this.tree.Count;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00005BDC File Offset: 0x00004BDC
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000075E9 File Offset: 0x000065E9
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.tree)
			{
				yield return redBlackTreeNode.Value;
			}
			IEnumerator<RedBlackTreeNode<KeyValuePair<TKey, TValue>>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000075F8 File Offset: 0x000065F8
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00007600 File Offset: 0x00006600
		public KeyValuePair<TKey, TValue> Min()
		{
			if (this.tree.Count == 0)
			{
				throw new InvalidOperationException("The dictionary is empty.");
			}
			return this.tree.Min().Value;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000762A File Offset: 0x0000662A
		public KeyValuePair<TKey, TValue> Max()
		{
			if (this.tree.Count == 0)
			{
				throw new InvalidOperationException("The dictionary is empty.");
			}
			return this.tree.Max().Value;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00007654 File Offset: 0x00006654
		public KeyValuePair<TKey, TValue> GetPrevious(TKey key)
		{
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> node = this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> previousNode = this.tree.GetPreviousNode(node);
			if (previousNode != null)
			{
				return previousNode.Value;
			}
			throw new KeyNotFoundException("There are no ancestor keys in the dictionary.");
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000076A0 File Offset: 0x000066A0
		public bool TryGetPrevious(TKey key, out KeyValuePair<TKey, TValue> prev)
		{
			prev = default(KeyValuePair<TKey, TValue>);
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> node = this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> previousNode = this.tree.GetPreviousNode(node);
			if (previousNode != null)
			{
				prev = previousNode.Value;
				return true;
			}
			return false;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000076F0 File Offset: 0x000066F0
		public KeyValuePair<TKey, TValue> GetNext(TKey key)
		{
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> node = this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> nextNode = this.tree.GetNextNode(node);
			if (nextNode != null)
			{
				return nextNode.Value;
			}
			throw new KeyNotFoundException("There are no successor keys in the dictionary.");
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000773C File Offset: 0x0000673C
		public bool TryGetNext(TKey key, out KeyValuePair<TKey, TValue> next)
		{
			next = default(KeyValuePair<TKey, TValue>);
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> node = this.tree.Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
			RedBlackTreeNode<KeyValuePair<TKey, TValue>> nextNode = this.tree.GetNextNode(node);
			if (nextNode != null)
			{
				next = nextNode.Value;
				return true;
			}
			return false;
		}

		// Token: 0x04000047 RID: 71
		private RedBlackTree<TKey, TValue> tree;

		// Token: 0x04000048 RID: 72
		private RedBlackTreeDictionary<TKey, TValue>.ValueCollection values;

		// Token: 0x04000049 RID: 73
		private RedBlackTreeDictionary<TKey, TValue>.KeyCollection keys;

		// Token: 0x02000088 RID: 136
		[Serializable]
		internal class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable
		{
			// Token: 0x060003CF RID: 975 RVA: 0x000095F3 File Offset: 0x000085F3
			public ValueCollection(RedBlackTree<KeyValuePair<TKey, TValue>> owner)
			{
				this.owner = owner;
			}

			// Token: 0x060003D0 RID: 976 RVA: 0x00009604 File Offset: 0x00008604
			public bool Contains(TValue item)
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					if (item.Equals(redBlackTreeNode.Value.Value))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060003D1 RID: 977 RVA: 0x00009674 File Offset: 0x00008674
			public void CopyTo(TValue[] array, int arrayIndex)
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					array[arrayIndex++] = redBlackTreeNode.Value.Value;
				}
			}

			// Token: 0x1700008F RID: 143
			// (get) Token: 0x060003D2 RID: 978 RVA: 0x000096D4 File Offset: 0x000086D4
			public int Count
			{
				get
				{
					return this.owner.Count;
				}
			}

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x060003D3 RID: 979 RVA: 0x00005C0B File Offset: 0x00004C0B
			public bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x000084BC File Offset: 0x000074BC
			public void Add(TValue item)
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003D5 RID: 981 RVA: 0x000084BC File Offset: 0x000074BC
			public void Clear()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x000084BC File Offset: 0x000074BC
			public bool Remove(TValue item)
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x000096E1 File Offset: 0x000086E1
			public IEnumerator<TValue> GetEnumerator()
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					yield return redBlackTreeNode.Value.Value;
				}
				IEnumerator<RedBlackTreeNode<KeyValuePair<TKey, TValue>>> enumerator = null;
				yield break;
				yield break;
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x000096F0 File Offset: 0x000086F0
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x0400009A RID: 154
			private RedBlackTree<KeyValuePair<TKey, TValue>> owner;
		}

		// Token: 0x02000089 RID: 137
		[Serializable]
		internal class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable
		{
			// Token: 0x060003D9 RID: 985 RVA: 0x000096F8 File Offset: 0x000086F8
			public KeyCollection(RedBlackTree<KeyValuePair<TKey, TValue>> owner)
			{
				this.owner = owner;
			}

			// Token: 0x060003DA RID: 986 RVA: 0x00009708 File Offset: 0x00008708
			public bool Contains(TKey item)
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					if (item.Equals(redBlackTreeNode.Value.Key))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060003DB RID: 987 RVA: 0x00009778 File Offset: 0x00008778
			public void CopyTo(TKey[] array, int arrayIndex)
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					array[arrayIndex++] = redBlackTreeNode.Value.Key;
				}
			}

			// Token: 0x17000091 RID: 145
			// (get) Token: 0x060003DC RID: 988 RVA: 0x000097D8 File Offset: 0x000087D8
			public int Count
			{
				get
				{
					return this.owner.Count;
				}
			}

			// Token: 0x17000092 RID: 146
			// (get) Token: 0x060003DD RID: 989 RVA: 0x00005C0B File Offset: 0x00004C0B
			public bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060003DE RID: 990 RVA: 0x000084BC File Offset: 0x000074BC
			public void Add(TKey item)
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003DF RID: 991 RVA: 0x000084BC File Offset: 0x000074BC
			public void Clear()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003E0 RID: 992 RVA: 0x000084BC File Offset: 0x000074BC
			public bool Remove(TKey item)
			{
				throw new NotSupportedException();
			}

			// Token: 0x060003E1 RID: 993 RVA: 0x000097E5 File Offset: 0x000087E5
			public IEnumerator<TKey> GetEnumerator()
			{
				foreach (RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode in this.owner)
				{
					yield return redBlackTreeNode.Value.Key;
				}
				IEnumerator<RedBlackTreeNode<KeyValuePair<TKey, TValue>>> enumerator = null;
				yield break;
				yield break;
			}

			// Token: 0x060003E2 RID: 994 RVA: 0x000097F4 File Offset: 0x000087F4
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x0400009B RID: 155
			private RedBlackTree<KeyValuePair<TKey, TValue>> owner;
		}
	}
}
