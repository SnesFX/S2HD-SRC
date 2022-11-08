using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace System.Collections.Immutable
{
	// Token: 0x0200003B RID: 59
	[DebuggerDisplay("{_key} = {_value}")]
	internal sealed class SortedInt32KeyNode<TValue> : IBinaryTree
	{
		// Token: 0x06000351 RID: 849 RVA: 0x00008D71 File Offset: 0x00006F71
		private SortedInt32KeyNode()
		{
			this._frozen = true;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00008D80 File Offset: 0x00006F80
		private SortedInt32KeyNode(int key, TValue value, SortedInt32KeyNode<TValue> left, SortedInt32KeyNode<TValue> right, bool frozen = false)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(left, "left");
			Requires.NotNull<SortedInt32KeyNode<TValue>>(right, "right");
			this._key = key;
			this._value = value;
			this._left = left;
			this._right = right;
			this._frozen = frozen;
			this._height = checked(1 + Math.Max(left._height, right._height));
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00008DEA File Offset: 0x00006FEA
		public bool IsEmpty
		{
			get
			{
				return this._left == null;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00008DF5 File Offset: 0x00006FF5
		public int Height
		{
			get
			{
				return (int)this._height;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00008DFD File Offset: 0x00006FFD
		public SortedInt32KeyNode<TValue> Left
		{
			get
			{
				return this._left;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00008E05 File Offset: 0x00007005
		public SortedInt32KeyNode<TValue> Right
		{
			get
			{
				return this._right;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00008DFD File Offset: 0x00006FFD
		IBinaryTree IBinaryTree.Left
		{
			get
			{
				return this._left;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00008E05 File Offset: 0x00007005
		IBinaryTree IBinaryTree.Right
		{
			get
			{
				return this._right;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000359 RID: 857 RVA: 0x0000317B File Offset: 0x0000137B
		int IBinaryTree.Count
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00008E0D File Offset: 0x0000700D
		public KeyValuePair<int, TValue> Value
		{
			get
			{
				return new KeyValuePair<int, TValue>(this._key, this._value);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00008E20 File Offset: 0x00007020
		internal IEnumerable<TValue> Values
		{
			get
			{
				foreach (KeyValuePair<int, TValue> keyValuePair in this)
				{
					yield return keyValuePair.Value;
				}
				SortedInt32KeyNode<TValue>.Enumerator enumerator = default(SortedInt32KeyNode<TValue>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00008E3D File Offset: 0x0000703D
		public SortedInt32KeyNode<TValue>.Enumerator GetEnumerator()
		{
			return new SortedInt32KeyNode<TValue>.Enumerator(this);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00008E45 File Offset: 0x00007045
		internal SortedInt32KeyNode<TValue> SetItem(int key, TValue value, IEqualityComparer<TValue> valueComparer, out bool replacedExistingValue, out bool mutated)
		{
			Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
			return this.SetOrAdd(key, value, valueComparer, true, out replacedExistingValue, out mutated);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00008E60 File Offset: 0x00007060
		internal SortedInt32KeyNode<TValue> Remove(int key, out bool mutated)
		{
			return this.RemoveRecursive(key, out mutated);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00008E6C File Offset: 0x0000706C
		internal TValue GetValueOrDefault(int key)
		{
			SortedInt32KeyNode<TValue> sortedInt32KeyNode = this.Search(key);
			if (!sortedInt32KeyNode.IsEmpty)
			{
				return sortedInt32KeyNode._value;
			}
			return default(TValue);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00008E9C File Offset: 0x0000709C
		internal bool TryGetValue(int key, out TValue value)
		{
			SortedInt32KeyNode<TValue> sortedInt32KeyNode = this.Search(key);
			if (sortedInt32KeyNode.IsEmpty)
			{
				value = default(TValue);
				return false;
			}
			value = sortedInt32KeyNode._value;
			return true;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00008ED0 File Offset: 0x000070D0
		internal void Freeze(Action<KeyValuePair<int, TValue>> freezeAction = null)
		{
			if (!this._frozen)
			{
				if (freezeAction != null)
				{
					freezeAction(new KeyValuePair<int, TValue>(this._key, this._value));
				}
				this._left.Freeze(freezeAction);
				this._right.Freeze(freezeAction);
				this._frozen = true;
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00008F20 File Offset: 0x00007120
		private static SortedInt32KeyNode<TValue> RotateLeft(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			if (tree._right.IsEmpty)
			{
				return tree;
			}
			SortedInt32KeyNode<TValue> right = tree._right;
			return right.Mutate(tree.Mutate(null, right._left), null);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00008F64 File Offset: 0x00007164
		private static SortedInt32KeyNode<TValue> RotateRight(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			if (tree._left.IsEmpty)
			{
				return tree;
			}
			SortedInt32KeyNode<TValue> left = tree._left;
			return left.Mutate(null, tree.Mutate(left._right, null));
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00008FA8 File Offset: 0x000071A8
		private static SortedInt32KeyNode<TValue> DoubleLeft(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			if (tree._right.IsEmpty)
			{
				return tree;
			}
			SortedInt32KeyNode<TValue> tree2 = tree.Mutate(null, SortedInt32KeyNode<TValue>.RotateRight(tree._right));
			return SortedInt32KeyNode<TValue>.RotateLeft(tree2);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00008FE8 File Offset: 0x000071E8
		private static SortedInt32KeyNode<TValue> DoubleRight(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			if (tree._left.IsEmpty)
			{
				return tree;
			}
			SortedInt32KeyNode<TValue> tree2 = tree.Mutate(SortedInt32KeyNode<TValue>.RotateLeft(tree._left), null);
			return SortedInt32KeyNode<TValue>.RotateRight(tree2);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00009028 File Offset: 0x00007228
		private static int Balance(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			return (int)(tree._right._height - tree._left._height);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000904C File Offset: 0x0000724C
		private static bool IsRightHeavy(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			return SortedInt32KeyNode<TValue>.Balance(tree) >= 2;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00009065 File Offset: 0x00007265
		private static bool IsLeftHeavy(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			return SortedInt32KeyNode<TValue>.Balance(tree) <= -2;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00009080 File Offset: 0x00007280
		private static SortedInt32KeyNode<TValue> MakeBalanced(SortedInt32KeyNode<TValue> tree)
		{
			Requires.NotNull<SortedInt32KeyNode<TValue>>(tree, "tree");
			if (SortedInt32KeyNode<TValue>.IsRightHeavy(tree))
			{
				if (SortedInt32KeyNode<TValue>.Balance(tree._right) >= 0)
				{
					return SortedInt32KeyNode<TValue>.RotateLeft(tree);
				}
				return SortedInt32KeyNode<TValue>.DoubleLeft(tree);
			}
			else
			{
				if (!SortedInt32KeyNode<TValue>.IsLeftHeavy(tree))
				{
					return tree;
				}
				if (SortedInt32KeyNode<TValue>.Balance(tree._left) <= 0)
				{
					return SortedInt32KeyNode<TValue>.RotateRight(tree);
				}
				return SortedInt32KeyNode<TValue>.DoubleRight(tree);
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000090E4 File Offset: 0x000072E4
		private SortedInt32KeyNode<TValue> SetOrAdd(int key, TValue value, IEqualityComparer<TValue> valueComparer, bool overwriteExistingValue, out bool replacedExistingValue, out bool mutated)
		{
			replacedExistingValue = false;
			if (this.IsEmpty)
			{
				mutated = true;
				return new SortedInt32KeyNode<TValue>(key, value, this, this, false);
			}
			SortedInt32KeyNode<TValue> sortedInt32KeyNode = this;
			if (key > this._key)
			{
				SortedInt32KeyNode<TValue> right = this._right.SetOrAdd(key, value, valueComparer, overwriteExistingValue, out replacedExistingValue, out mutated);
				if (mutated)
				{
					sortedInt32KeyNode = this.Mutate(null, right);
				}
			}
			else if (key < this._key)
			{
				SortedInt32KeyNode<TValue> left = this._left.SetOrAdd(key, value, valueComparer, overwriteExistingValue, out replacedExistingValue, out mutated);
				if (mutated)
				{
					sortedInt32KeyNode = this.Mutate(left, null);
				}
			}
			else
			{
				if (valueComparer.Equals(this._value, value))
				{
					mutated = false;
					return this;
				}
				if (!overwriteExistingValue)
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
					{
						key
					}));
				}
				mutated = true;
				replacedExistingValue = true;
				sortedInt32KeyNode = new SortedInt32KeyNode<TValue>(key, value, this._left, this._right, false);
			}
			if (!mutated)
			{
				return sortedInt32KeyNode;
			}
			return SortedInt32KeyNode<TValue>.MakeBalanced(sortedInt32KeyNode);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000091DC File Offset: 0x000073DC
		private SortedInt32KeyNode<TValue> RemoveRecursive(int key, out bool mutated)
		{
			if (this.IsEmpty)
			{
				mutated = false;
				return this;
			}
			SortedInt32KeyNode<TValue> sortedInt32KeyNode = this;
			if (key == this._key)
			{
				mutated = true;
				if (this._right.IsEmpty && this._left.IsEmpty)
				{
					sortedInt32KeyNode = SortedInt32KeyNode<TValue>.EmptyNode;
				}
				else if (this._right.IsEmpty && !this._left.IsEmpty)
				{
					sortedInt32KeyNode = this._left;
				}
				else if (!this._right.IsEmpty && this._left.IsEmpty)
				{
					sortedInt32KeyNode = this._right;
				}
				else
				{
					SortedInt32KeyNode<TValue> sortedInt32KeyNode2 = this._right;
					while (!sortedInt32KeyNode2._left.IsEmpty)
					{
						sortedInt32KeyNode2 = sortedInt32KeyNode2._left;
					}
					bool flag;
					SortedInt32KeyNode<TValue> right = this._right.Remove(sortedInt32KeyNode2._key, out flag);
					sortedInt32KeyNode = sortedInt32KeyNode2.Mutate(this._left, right);
				}
			}
			else if (key < this._key)
			{
				SortedInt32KeyNode<TValue> left = this._left.Remove(key, out mutated);
				if (mutated)
				{
					sortedInt32KeyNode = this.Mutate(left, null);
				}
			}
			else
			{
				SortedInt32KeyNode<TValue> right2 = this._right.Remove(key, out mutated);
				if (mutated)
				{
					sortedInt32KeyNode = this.Mutate(null, right2);
				}
			}
			if (!sortedInt32KeyNode.IsEmpty)
			{
				return SortedInt32KeyNode<TValue>.MakeBalanced(sortedInt32KeyNode);
			}
			return sortedInt32KeyNode;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00009310 File Offset: 0x00007510
		private SortedInt32KeyNode<TValue> Mutate(SortedInt32KeyNode<TValue> left = null, SortedInt32KeyNode<TValue> right = null)
		{
			if (this._frozen)
			{
				return new SortedInt32KeyNode<TValue>(this._key, this._value, left ?? this._left, right ?? this._right, false);
			}
			if (left != null)
			{
				this._left = left;
			}
			if (right != null)
			{
				this._right = right;
			}
			this._height = checked(1 + Math.Max(this._left._height, this._right._height));
			return this;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00009387 File Offset: 0x00007587
		private SortedInt32KeyNode<TValue> Search(int key)
		{
			if (this.IsEmpty || key == this._key)
			{
				return this;
			}
			if (key > this._key)
			{
				return this._right.Search(key);
			}
			return this._left.Search(key);
		}

		// Token: 0x0400003C RID: 60
		internal static readonly SortedInt32KeyNode<TValue> EmptyNode = new SortedInt32KeyNode<TValue>();

		// Token: 0x0400003D RID: 61
		private readonly int _key;

		// Token: 0x0400003E RID: 62
		private TValue _value;

		// Token: 0x0400003F RID: 63
		private bool _frozen;

		// Token: 0x04000040 RID: 64
		private byte _height;

		// Token: 0x04000041 RID: 65
		private SortedInt32KeyNode<TValue> _left;

		// Token: 0x04000042 RID: 66
		private SortedInt32KeyNode<TValue> _right;

		// Token: 0x0200006C RID: 108
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<KeyValuePair<int, TValue>>, IEnumerator, IDisposable, ISecurePooledObjectUser
		{
			// Token: 0x060005F6 RID: 1526 RVA: 0x000102A4 File Offset: 0x0000E4A4
			internal Enumerator(SortedInt32KeyNode<TValue> root)
			{
				Requires.NotNull<SortedInt32KeyNode<TValue>>(root, "root");
				this._root = root;
				this._current = null;
				this._poolUserId = SecureObjectPool.NewId();
				this._stack = null;
				if (!this._root.IsEmpty)
				{
					if (!SortedInt32KeyNode<TValue>.Enumerator.s_enumeratingStacks.TryTake(this, out this._stack))
					{
						this._stack = SortedInt32KeyNode<TValue>.Enumerator.s_enumeratingStacks.PrepNew(this, new Stack<RefAsValueType<SortedInt32KeyNode<TValue>>>(root.Height));
					}
					this.PushLeft(this._root);
				}
			}

			// Token: 0x1700013D RID: 317
			// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0001032E File Offset: 0x0000E52E
			public KeyValuePair<int, TValue> Current
			{
				get
				{
					this.ThrowIfDisposed();
					if (this._current != null)
					{
						return this._current.Value;
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x1700013E RID: 318
			// (get) Token: 0x060005F8 RID: 1528 RVA: 0x0001034F File Offset: 0x0000E54F
			int ISecurePooledObjectUser.PoolUserId
			{
				get
				{
					return this._poolUserId;
				}
			}

			// Token: 0x1700013F RID: 319
			// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00010357 File Offset: 0x0000E557
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060005FA RID: 1530 RVA: 0x00010364 File Offset: 0x0000E564
			public void Dispose()
			{
				this._root = null;
				this._current = null;
				Stack<RefAsValueType<SortedInt32KeyNode<TValue>>> stack;
				if (this._stack != null && this._stack.TryUse<SortedInt32KeyNode<TValue>.Enumerator>(ref this, out stack))
				{
					stack.ClearFastWhenEmpty<RefAsValueType<SortedInt32KeyNode<TValue>>>();
					SortedInt32KeyNode<TValue>.Enumerator.s_enumeratingStacks.TryAdd(this, this._stack);
				}
				this._stack = null;
			}

			// Token: 0x060005FB RID: 1531 RVA: 0x000103BC File Offset: 0x0000E5BC
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				if (this._stack != null)
				{
					Stack<RefAsValueType<SortedInt32KeyNode<TValue>>> stack = this._stack.Use<SortedInt32KeyNode<TValue>.Enumerator>(ref this);
					if (stack.Count > 0)
					{
						SortedInt32KeyNode<TValue> value = stack.Pop().Value;
						this._current = value;
						this.PushLeft(value.Right);
						return true;
					}
				}
				this._current = null;
				return false;
			}

			// Token: 0x060005FC RID: 1532 RVA: 0x00010418 File Offset: 0x0000E618
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._current = null;
				if (this._stack != null)
				{
					Stack<RefAsValueType<SortedInt32KeyNode<TValue>>> stack = this._stack.Use<SortedInt32KeyNode<TValue>.Enumerator>(ref this);
					stack.ClearFastWhenEmpty<RefAsValueType<SortedInt32KeyNode<TValue>>>();
					this.PushLeft(this._root);
				}
			}

			// Token: 0x060005FD RID: 1533 RVA: 0x00010459 File Offset: 0x0000E659
			internal void ThrowIfDisposed()
			{
				if (this._root == null || (this._stack != null && !this._stack.IsOwned<SortedInt32KeyNode<TValue>.Enumerator>(ref this)))
				{
					Requires.FailObjectDisposed<SortedInt32KeyNode<TValue>.Enumerator>(this);
				}
			}

			// Token: 0x060005FE RID: 1534 RVA: 0x00010484 File Offset: 0x0000E684
			private void PushLeft(SortedInt32KeyNode<TValue> node)
			{
				Requires.NotNull<SortedInt32KeyNode<TValue>>(node, "node");
				Stack<RefAsValueType<SortedInt32KeyNode<TValue>>> stack = this._stack.Use<SortedInt32KeyNode<TValue>.Enumerator>(ref this);
				while (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<SortedInt32KeyNode<TValue>>(node));
					node = node.Left;
				}
			}

			// Token: 0x040000F1 RID: 241
			private static readonly SecureObjectPool<Stack<RefAsValueType<SortedInt32KeyNode<TValue>>>, SortedInt32KeyNode<TValue>.Enumerator> s_enumeratingStacks = new SecureObjectPool<Stack<RefAsValueType<SortedInt32KeyNode<TValue>>>, SortedInt32KeyNode<TValue>.Enumerator>();

			// Token: 0x040000F2 RID: 242
			private readonly int _poolUserId;

			// Token: 0x040000F3 RID: 243
			private SortedInt32KeyNode<TValue> _root;

			// Token: 0x040000F4 RID: 244
			private SecurePooledObject<Stack<RefAsValueType<SortedInt32KeyNode<TValue>>>> _stack;

			// Token: 0x040000F5 RID: 245
			private SortedInt32KeyNode<TValue> _current;
		}
	}
}
