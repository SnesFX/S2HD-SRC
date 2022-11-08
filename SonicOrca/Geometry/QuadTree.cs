using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SonicOrca.Geometry
{
	// Token: 0x02000101 RID: 257
	public class QuadTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : IBounds
	{
		// Token: 0x060008D2 RID: 2258 RVA: 0x00023678 File Offset: 0x00021878
		public QuadTree(Rectanglei bounds, int minNodeSize = 4096, int subdivideTargetCount = 4)
		{
			this._minNodeSize = minNodeSize;
			this._subdivideTargetCount = subdivideTargetCount;
			this._bounds = bounds;
			this._root = new QuadTree<T>.Node(this, this._bounds);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x000236C4 File Offset: 0x000218C4
		public QuadTree(IEnumerable<T> items, int minNodeSize = 4096, int subdivideTargetCount = 4)
		{
			this._minNodeSize = minNodeSize;
			this._subdivideTargetCount = subdivideTargetCount;
			T[] array = items.ToArray<T>();
			if (array.Length == 0)
			{
				this._bounds = new Rectanglei(0, 0, minNodeSize, minNodeSize);
				this._root = new QuadTree<T>.Node(this, this._bounds);
				return;
			}
			int num = array.Min((T i) => i.Bounds.Left);
			int num2 = array.Min((T i) => i.Bounds.Top);
			int num3 = array.Max((T i) => i.Bounds.Right);
			int num4 = array.Max((T i) => i.Bounds.Bottom);
			this._bounds = new Rectanglei(num, num2, num3 - num, num4 - num2);
			this._root = new QuadTree<T>.Node(this, this._bounds);
			Trace.WriteLine("QuadTree bounds: " + this._bounds);
			foreach (T item in array)
			{
				this.Add(item);
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00023826 File Offset: 0x00021A26
		public IEnumerable<T> Query(Rectanglei queryBounds)
		{
			return this._root.Query(queryBounds);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00023834 File Offset: 0x00021A34
		public void AddRange(IEnumerable<T> items)
		{
			T[] array = items.ToArray<T>();
			if (array.Any((T x) => !this._bounds.Contains(x.Bounds)))
			{
				Trace.WriteLine("Resizing quad tree");
				foreach (T t in array)
				{
					this._bounds = this._bounds.Union(t.Bounds);
				}
				T[] array3 = this._root.Items.ToArray<T>();
				this._root = new QuadTree<T>.Node(this, this._bounds);
				foreach (T item in array3)
				{
					this._root.Add(item);
				}
			}
			foreach (T item2 in array)
			{
				this.Add(item2);
			}
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00023908 File Offset: 0x00021B08
		public int GetDepth()
		{
			return this._root.GetDepth();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00023918 File Offset: 0x00021B18
		public void Add(T item)
		{
			if (!this._root.Add(item))
			{
				Trace.WriteLine("Resizing quad tree");
				this._bounds = this._bounds.Union(item.Bounds);
				T[] array = this._root.Items.ToArray<T>();
				this._root = new QuadTree<T>.Node(this, this._bounds);
				foreach (T item2 in array)
				{
					this._root.Add(item2);
				}
				this._root.Add(item);
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x000239AE File Offset: 0x00021BAE
		public void Clear()
		{
			this._root = new QuadTree<T>.Node(this, this._bounds);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x000239C2 File Offset: 0x00021BC2
		public bool Contains(T item)
		{
			return this._root.Items.Contains(item);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000239D5 File Offset: 0x00021BD5
		public void CopyTo(T[] array, int arrayIndex)
		{
			this._root.Items.ToArray<T>().CopyTo(array, arrayIndex);
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x000239EE File Offset: 0x00021BEE
		public int Count
		{
			get
			{
				return this._root.Count;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0000225B File Offset: 0x0000045B
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x000239FB File Offset: 0x00021BFB
		public bool Remove(T item)
		{
			return this._root.Remove(item);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00023A09 File Offset: 0x00021C09
		public IEnumerator<T> GetEnumerator()
		{
			return this._root.Items.GetEnumerator();
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00023A09 File Offset: 0x00021C09
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._root.Items.GetEnumerator();
		}

		// Token: 0x04000563 RID: 1379
		private QuadTree<T>.Node _root;

		// Token: 0x04000564 RID: 1380
		private Rectanglei _bounds;

		// Token: 0x04000565 RID: 1381
		private readonly int _minNodeSize = 4096;

		// Token: 0x04000566 RID: 1382
		private readonly int _subdivideTargetCount = 4;

		// Token: 0x020001EB RID: 491
		private class Node
		{
			// Token: 0x1700051C RID: 1308
			// (get) Token: 0x06001338 RID: 4920 RVA: 0x0004A18D File Offset: 0x0004838D
			public Rectanglei Bounds
			{
				get
				{
					return this._bounds;
				}
			}

			// Token: 0x1700051D RID: 1309
			// (get) Token: 0x06001339 RID: 4921 RVA: 0x0004A198 File Offset: 0x00048398
			public int Count
			{
				get
				{
					int num = this._items.Count;
					foreach (QuadTree<T>.Node node in this._children)
					{
						num += node.Count;
					}
					return num;
				}
			}

			// Token: 0x1700051E RID: 1310
			// (get) Token: 0x0600133A RID: 4922 RVA: 0x0004A1D4 File Offset: 0x000483D4
			public IEnumerable<T> Items
			{
				get
				{
					foreach (T t in this._items)
					{
						yield return t;
					}
					List<T>.Enumerator enumerator = default(List<T>.Enumerator);
					foreach (QuadTree<T>.Node node in this._children)
					{
						foreach (T t2 in node.Items)
						{
							yield return t2;
						}
						IEnumerator<T> enumerator2 = null;
					}
					QuadTree<T>.Node[] array = null;
					yield break;
					yield break;
				}
			}

			// Token: 0x0600133B RID: 4923 RVA: 0x0004A1E4 File Offset: 0x000483E4
			public Node(QuadTree<T> quadTree, Rectanglei bounds)
			{
				this._quadTree = quadTree;
				this._bounds = bounds;
			}

			// Token: 0x0600133C RID: 4924 RVA: 0x0004A214 File Offset: 0x00048414
			public bool Add(T item)
			{
				if (!this._bounds.Contains(item.Bounds))
				{
					return false;
				}
				if (this._children.Length == 0)
				{
					if (this._items.Count <= this._quadTree._subdivideTargetCount)
					{
						this._items.Add(item);
						return true;
					}
					this.ReStructure();
				}
				foreach (QuadTree<T>.Node node in this._children)
				{
					if (node._bounds.Contains(item.Bounds))
					{
						Trace.Indent();
						bool result = node.Add(item);
						Trace.Unindent();
						return result;
					}
				}
				this._items.Add(item);
				return true;
			}

			// Token: 0x0600133D RID: 4925 RVA: 0x0004A2CC File Offset: 0x000484CC
			public bool Remove(T item)
			{
				if (this._items.Remove(item))
				{
					return true;
				}
				QuadTree<T>.Node[] children = this._children;
				for (int i = 0; i < children.Length; i++)
				{
					if (children[i].Remove(item))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x0600133E RID: 4926 RVA: 0x0004A30C File Offset: 0x0004850C
			public IEnumerable<T> Query(Rectanglei queryBounds)
			{
				foreach (T t in this._items)
				{
					Rectanglei bounds = t.Bounds;
					if (queryBounds.IntersectsWith(t.Bounds))
					{
						yield return t;
					}
				}
				List<T>.Enumerator enumerator = default(List<T>.Enumerator);
				foreach (QuadTree<T>.Node child in this._children)
				{
					if (child._items.Count != 0 || child._children.Length != 0)
					{
						if (child._bounds.Contains(queryBounds))
						{
							foreach (T t2 in child.Query(queryBounds))
							{
								yield return t2;
							}
							IEnumerator<T> enumerator2 = null;
							break;
						}
						if (queryBounds.Contains(child._bounds))
						{
							foreach (T t3 in child.Items)
							{
								yield return t3;
							}
							IEnumerator<T> enumerator2 = null;
						}
						else
						{
							if (child._bounds.IntersectsWith(queryBounds))
							{
								foreach (T t4 in child.Query(queryBounds))
								{
									yield return t4;
								}
								IEnumerator<T> enumerator2 = null;
							}
							child = null;
						}
					}
				}
				QuadTree<T>.Node[] array = null;
				yield break;
				yield break;
			}

			// Token: 0x0600133F RID: 4927 RVA: 0x0004A324 File Offset: 0x00048524
			private void ReStructure()
			{
				T[] array = this._items.ToArray();
				this._items.Clear();
				this.CreateChildren();
				foreach (T item in array)
				{
					this.Add(item);
				}
			}

			// Token: 0x06001340 RID: 4928 RVA: 0x0004A36C File Offset: 0x0004856C
			private void CreateChildren()
			{
				if (this._bounds.Area <= (long)this._quadTree._minNodeSize)
				{
					return;
				}
				int num = this._bounds.Width / 2;
				int num2 = this._bounds.Height / 2;
				this._children = new QuadTree<T>.Node[4];
				this._children[0] = new QuadTree<T>.Node(this._quadTree, new Rectanglei(this._bounds.X, this._bounds.Y, num, num2));
				this._children[1] = new QuadTree<T>.Node(this._quadTree, new Rectanglei(this._bounds.X, this._bounds.Y + num2, num, num2));
				this._children[2] = new QuadTree<T>.Node(this._quadTree, new Rectanglei(this._bounds.X + num, this._bounds.Y, num, num2));
				this._children[3] = new QuadTree<T>.Node(this._quadTree, new Rectanglei(this._bounds.X + num, this._bounds.Y + num2, num, num2));
			}

			// Token: 0x06001341 RID: 4929 RVA: 0x0004A4A4 File Offset: 0x000486A4
			public int GetDepth()
			{
				if (this._children.Length == 0)
				{
					return 1;
				}
				return (from x in this._children
				select x.GetDepth()).Max();
			}

			// Token: 0x06001342 RID: 4930 RVA: 0x0004A4E0 File Offset: 0x000486E0
			public override string ToString()
			{
				return string.Format("{0} items, {1} nodes", this._items.Count, this._children.Length);
			}

			// Token: 0x04000B1D RID: 2845
			private readonly QuadTree<T> _quadTree;

			// Token: 0x04000B1E RID: 2846
			private readonly Rectanglei _bounds;

			// Token: 0x04000B1F RID: 2847
			private readonly List<T> _items = new List<T>();

			// Token: 0x04000B20 RID: 2848
			private QuadTree<T>.Node[] _children = new QuadTree<T>.Node[0];
		}
	}
}
