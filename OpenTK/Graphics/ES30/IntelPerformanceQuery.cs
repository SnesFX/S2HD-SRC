using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x0200081F RID: 2079
	public enum IntelPerformanceQuery
	{
		// Token: 0x040087F7 RID: 34807
		PerfquerySingleContextIntel,
		// Token: 0x040087F8 RID: 34808
		PerfqueryGlobalContextIntel,
		// Token: 0x040087F9 RID: 34809
		PerfqueryDonotFlushIntel = 33785,
		// Token: 0x040087FA RID: 34810
		PerfqueryFlushIntel,
		// Token: 0x040087FB RID: 34811
		PerfqueryWaitIntel,
		// Token: 0x040087FC RID: 34812
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x040087FD RID: 34813
		PerfqueryCounterDurationNormIntel,
		// Token: 0x040087FE RID: 34814
		PerfqueryCounterDurationRawIntel,
		// Token: 0x040087FF RID: 34815
		PerfqueryCounterThroughputIntel,
		// Token: 0x04008800 RID: 34816
		PerfqueryCounterRawIntel,
		// Token: 0x04008801 RID: 34817
		PerfqueryCounterTimestampIntel,
		// Token: 0x04008802 RID: 34818
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x04008803 RID: 34819
		PerfqueryCounterDataUint64Intel,
		// Token: 0x04008804 RID: 34820
		PerfqueryCounterDataFloatIntel,
		// Token: 0x04008805 RID: 34821
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x04008806 RID: 34822
		PerfqueryCounterDataBool32Intel,
		// Token: 0x04008807 RID: 34823
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x04008808 RID: 34824
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x04008809 RID: 34825
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x0400880A RID: 34826
		PerfqueryGpaExtendedCountersIntel
	}
}
