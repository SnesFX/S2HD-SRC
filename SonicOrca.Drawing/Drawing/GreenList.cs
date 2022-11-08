using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Drawing
{
	// Token: 0x02000004 RID: 4
	internal class GreenList<T>
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021A8 File Offset: 0x000003A8
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021B0 File Offset: 0x000003B0
		public int Count { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021B9 File Offset: 0x000003B9
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000021C1 File Offset: 0x000003C1
		public int Capacity { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000021CA File Offset: 0x000003CA
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000021D2 File Offset: 0x000003D2
		public int GrowFactor { get; set; }

		// Token: 0x06000017 RID: 23 RVA: 0x000021DC File Offset: 0x000003DC
		public GreenList(int initialCapacity, int growFactor)
		{
			this.Capacity = initialCapacity;
			this.GrowFactor = growFactor;
			this._items = new T[initialCapacity];
			if (typeof(T).IsClass)
			{
				for (int i = 0; i < initialCapacity; i++)
				{
					this._items[i] = Activator.CreateInstance<T>();
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002238 File Offset: 0x00000438
		public void EnsureCapacity(int targetCapacity)
		{
			if (this.Capacity < targetCapacity)
			{
				Array.Resize<T>(ref this._items, targetCapacity);
				if (typeof(T).IsClass)
				{
					for (int i = targetCapacity - this.Capacity; i < targetCapacity; i++)
					{
						this._items[i] = Activator.CreateInstance<T>();
					}
				}
				this.Capacity = targetCapacity;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002298 File Offset: 0x00000498
		public void Add(T item)
		{
			if (this.Count == this.Capacity)
			{
				this.EnsureCapacity(this.Capacity + this.GrowFactor);
			}
			T[] items = this._items;
			int count = this.Count;
			this.Count = count + 1;
			items[count] = item;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000022E4 File Offset: 0x000004E4
		public void AddRange(IEnumerable<T> items)
		{
			T[] array = items as T[];
			if (array != null)
			{
				this.AddRange(array);
				return;
			}
			IReadOnlyCollection<T> readOnlyCollection = items as IReadOnlyCollection<T>;
			if (readOnlyCollection != null)
			{
				this.AddRange(readOnlyCollection);
				return;
			}
			this.AddRange(items.ToArray<T>());
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002324 File Offset: 0x00000524
		public void AddRange(IReadOnlyCollection<T> items)
		{
			int count = items.Count;
			int num = this.Capacity - this.Count;
			int num2 = count - num;
			if (num2 > 0)
			{
				int targetCapacity = this.Capacity + (num2 + (this.GrowFactor - 1)) / this.GrowFactor;
				this.EnsureCapacity(targetCapacity);
			}
			foreach (T t in items)
			{
				T[] items2 = this._items;
				int count2 = this.Count;
				this.Count = count2 + 1;
				items2[count2] = t;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023C4 File Offset: 0x000005C4
		public void AddRange(T[] items)
		{
			int num = this.Capacity - this.Count;
			int num2 = items.Length - num;
			if (num2 > 0)
			{
				int targetCapacity = this.Capacity + (num2 + (this.GrowFactor - 1)) / this.GrowFactor;
				this.EnsureCapacity(targetCapacity);
			}
			Array.Copy(items, 0, this._items, this.Count, items.Length);
			this.Count += items.Length;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000242F File Offset: 0x0000062F
		public void Clear()
		{
			this.Count = 0;
		}

		// Token: 0x17000004 RID: 4
		public T this[int index]
		{
			get
			{
				return this._items[index];
			}
			set
			{
				this._items[index] = value;
			}
		}

		// Token: 0x04000002 RID: 2
		private T[] _items;
	}
}
