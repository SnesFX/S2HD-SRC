using System;

namespace Accord
{
	// Token: 0x02000029 RID: 41
	public interface IRange<T> : IFormattable
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000118 RID: 280
		// (set) Token: 0x06000119 RID: 281
		T Min { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600011A RID: 282
		// (set) Token: 0x0600011B RID: 283
		T Max { get; set; }
	}
}
