using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenTK.Platform
{
	// Token: 0x02000BA4 RID: 2980
	internal class DeviceCollection<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x06005C93 RID: 23699 RVA: 0x000FAD7C File Offset: 0x000F8F7C
		public IEnumerator<T> GetEnumerator()
		{
			return this.Devices.GetEnumerator();
		}

		// Token: 0x06005C94 RID: 23700 RVA: 0x000FAD90 File Offset: 0x000F8F90
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06005C95 RID: 23701 RVA: 0x000FAD98 File Offset: 0x000F8F98
		public void Add(int id, T device)
		{
			if (!this.Map.ContainsKey(id))
			{
				int index = this.GetIndex();
				this.Map.Add(id, index);
			}
			this.Devices[this.Map[id]] = device;
		}

		// Token: 0x06005C96 RID: 23702 RVA: 0x000FADE0 File Offset: 0x000F8FE0
		public void Remove(int id)
		{
			this.TryRemove(id);
		}

		// Token: 0x06005C97 RID: 23703 RVA: 0x000FADEC File Offset: 0x000F8FEC
		public bool TryRemove(int id)
		{
			if (!this.Map.ContainsKey(id))
			{
				return false;
			}
			this.Devices[this.Map[id]] = default(T);
			this.Map.Remove(id);
			return true;
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x000FAE38 File Offset: 0x000F9038
		public T FromIndex(int index)
		{
			if (index >= 0 && index < this.Devices.Count)
			{
				return this.Devices[index];
			}
			return default(T);
		}

		// Token: 0x06005C99 RID: 23705 RVA: 0x000FAE70 File Offset: 0x000F9070
		public T FromHardwareId(int id)
		{
			if (this.Map.ContainsKey(id))
			{
				return this.FromIndex(this.Map[id]);
			}
			return default(T);
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06005C9A RID: 23706 RVA: 0x000FAEA8 File Offset: 0x000F90A8
		public int Count
		{
			get
			{
				return this.Map.Count;
			}
		}

		// Token: 0x06005C9B RID: 23707 RVA: 0x000FAEB8 File Offset: 0x000F90B8
		private int GetIndex()
		{
			for (int i = 0; i < this.Devices.Count; i++)
			{
				if (this.Devices[i] == null)
				{
					return i;
				}
			}
			this.Devices.Add(default(T));
			return this.Devices.Count - 1;
		}

		// Token: 0x0400B973 RID: 47475
		private readonly Dictionary<int, int> Map = new Dictionary<int, int>();

		// Token: 0x0400B974 RID: 47476
		private readonly List<T> Devices = new List<T>();
	}
}
