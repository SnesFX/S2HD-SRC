using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Objects
{
	// Token: 0x0200015B RID: 347
	public class ObjectEntryTable : ICollection<ObjectEntry>, IEnumerable<ObjectEntry>, IEnumerable
	{
		// Token: 0x06000EA5 RID: 3749 RVA: 0x000375D7 File Offset: 0x000357D7
		public ObjectEntryTable(Level level)
		{
			this._level = level;
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x000375F4 File Offset: 0x000357F4
		public void Initialise(LevelBinding binding)
		{
			this._entries.Clear();
			foreach (ObjectPlacement item in binding.ObjectPlacements)
			{
				this.Add(item);
			}
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0003764C File Offset: 0x0003584C
		public void RemoveFinishedEntries()
		{
			this._entries.RemoveAll((ObjectEntry x) => x.FinishedForever);
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x00037679 File Offset: 0x00035879
		public void Add(ObjectPlacement item)
		{
			this.Add(new ObjectEntry(this._level, item));
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00037690 File Offset: 0x00035890
		public IEnumerable<ObjectEntry> GetAllInRegion(Rectanglei region)
		{
			return from x in this._entries
			where !x.FinishedForever && region.IntersectsWith(x.LifetimeArea)
			select x;
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x000376C1 File Offset: 0x000358C1
		public IEnumerable<ObjectEntry> GetAll()
		{
			return this._entries;
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x000376C9 File Offset: 0x000358C9
		public int GetRingCount()
		{
			return this._entries.Count((ObjectEntry x) => x.Type.Classification == ObjectClassification.Ring);
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x000376F5 File Offset: 0x000358F5
		public int GetRingCountInRegion(Rectanglei region)
		{
			return this.GetAllInRegion(region).Count((ObjectEntry x) => x.Type.Classification == ObjectClassification.Ring);
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00037724 File Offset: 0x00035924
		public override string ToString()
		{
			return string.Format("{0} entries, {1} loaded.", this._entries.Count, this._entries.Count((ObjectEntry x) => x.Active != null));
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x0003777A File Offset: 0x0003597A
		public void Add(ObjectEntry item)
		{
			this._entries.Add(item);
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00037788 File Offset: 0x00035988
		public void Clear()
		{
			this._entries.Clear();
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00037795 File Offset: 0x00035995
		public bool Contains(ObjectEntry item)
		{
			return this._entries.Contains(item);
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x000377A3 File Offset: 0x000359A3
		public void CopyTo(ObjectEntry[] array, int arrayIndex)
		{
			this._entries.CopyTo(array, arrayIndex);
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x000377B2 File Offset: 0x000359B2
		public int Count
		{
			get
			{
				return this._entries.Count;
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x0000225B File Offset: 0x0000045B
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000377BF File Offset: 0x000359BF
		public bool Remove(ObjectEntry item)
		{
			return this._entries.Remove(item);
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x000377CD File Offset: 0x000359CD
		public IEnumerator<ObjectEntry> GetEnumerator()
		{
			return this._entries.GetEnumerator();
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x000377CD File Offset: 0x000359CD
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._entries.GetEnumerator();
		}

		// Token: 0x04000846 RID: 2118
		private readonly List<ObjectEntry> _entries = new List<ObjectEntry>();

		// Token: 0x04000847 RID: 2119
		private readonly Level _level;
	}
}
