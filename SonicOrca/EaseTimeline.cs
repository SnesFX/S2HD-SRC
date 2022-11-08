using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca
{
	// Token: 0x02000093 RID: 147
	public class EaseTimeline
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x000190D9 File Offset: 0x000172D9
		public IList<EaseTimeline.Entry> Entries
		{
			get
			{
				return this._entries;
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000190E1 File Offset: 0x000172E1
		public EaseTimeline()
		{
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000190F4 File Offset: 0x000172F4
		public EaseTimeline(params EaseTimeline.Entry[] entries) : this(entries)
		{
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000190FD File Offset: 0x000172FD
		public EaseTimeline(IEnumerable<EaseTimeline.Entry> entries)
		{
			this._entries.AddRange(entries);
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0001911C File Offset: 0x0001731C
		public int Length
		{
			get
			{
				if (this._entries.Count <= 0)
				{
					return 0;
				}
				return this._entries.Max((EaseTimeline.Entry x) => x.Time);
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00019158 File Offset: 0x00017358
		public double GetValueAt(int time)
		{
			EaseTimeline.Entry[] source = (from x in this._entries
			orderby x.Time
			select x).ToArray<EaseTimeline.Entry>();
			EaseTimeline.Entry entry = source.LastOrDefault((EaseTimeline.Entry x) => x.Time <= time);
			EaseTimeline.Entry entry2 = source.FirstOrDefault((EaseTimeline.Entry x) => x.Time >= time);
			if (entry == null)
			{
				entry = source.First<EaseTimeline.Entry>();
			}
			if (entry2 == null)
			{
				entry2 = source.Last<EaseTimeline.Entry>();
			}
			if (entry == entry2)
			{
				return entry.Value;
			}
			double num = (entry2.Value - entry.Value) / (double)(entry2.Time - entry.Time);
			return entry.Value + num * (double)(time - entry.Time);
		}

		// Token: 0x04000308 RID: 776
		private readonly List<EaseTimeline.Entry> _entries = new List<EaseTimeline.Entry>();

		// Token: 0x020001B4 RID: 436
		public class Entry
		{
			// Token: 0x170004F3 RID: 1267
			// (get) Token: 0x06001270 RID: 4720 RVA: 0x00048117 File Offset: 0x00046317
			public int Time
			{
				get
				{
					return this._time;
				}
			}

			// Token: 0x170004F4 RID: 1268
			// (get) Token: 0x06001271 RID: 4721 RVA: 0x0004811F File Offset: 0x0004631F
			public double Value
			{
				get
				{
					return this._value;
				}
			}

			// Token: 0x06001272 RID: 4722 RVA: 0x00048127 File Offset: 0x00046327
			public Entry(int time, double value)
			{
				this._time = time;
				this._value = value;
			}

			// Token: 0x06001273 RID: 4723 RVA: 0x0004813D File Offset: 0x0004633D
			public override string ToString()
			{
				return string.Format("Time = {0} Value = {1}", this._time, this._value);
			}

			// Token: 0x04000A58 RID: 2648
			private readonly int _time;

			// Token: 0x04000A59 RID: 2649
			private readonly double _value;
		}
	}
}
