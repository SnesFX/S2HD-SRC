using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x0200096D RID: 2413
	public enum IntelPerformanceQuery
	{
		// Token: 0x04009E84 RID: 40580
		PerfquerySingleContextIntel,
		// Token: 0x04009E85 RID: 40581
		PerfqueryGlobalContextIntel,
		// Token: 0x04009E86 RID: 40582
		PerfqueryDonotFlushIntel = 33785,
		// Token: 0x04009E87 RID: 40583
		PerfqueryFlushIntel,
		// Token: 0x04009E88 RID: 40584
		PerfqueryWaitIntel,
		// Token: 0x04009E89 RID: 40585
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x04009E8A RID: 40586
		PerfqueryCounterDurationNormIntel,
		// Token: 0x04009E8B RID: 40587
		PerfqueryCounterDurationRawIntel,
		// Token: 0x04009E8C RID: 40588
		PerfqueryCounterThroughputIntel,
		// Token: 0x04009E8D RID: 40589
		PerfqueryCounterRawIntel,
		// Token: 0x04009E8E RID: 40590
		PerfqueryCounterTimestampIntel,
		// Token: 0x04009E8F RID: 40591
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x04009E90 RID: 40592
		PerfqueryCounterDataUint64Intel,
		// Token: 0x04009E91 RID: 40593
		PerfqueryCounterDataFloatIntel,
		// Token: 0x04009E92 RID: 40594
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x04009E93 RID: 40595
		PerfqueryCounterDataBool32Intel,
		// Token: 0x04009E94 RID: 40596
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x04009E95 RID: 40597
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x04009E96 RID: 40598
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x04009E97 RID: 40599
		PerfqueryGpaExtendedCountersIntel
	}
}
