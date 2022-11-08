using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200037B RID: 891
	public enum IntelPerformanceQuery
	{
		// Token: 0x040037B0 RID: 14256
		PerfquerySingleContextIntel,
		// Token: 0x040037B1 RID: 14257
		PerfqueryGlobalContextIntel,
		// Token: 0x040037B2 RID: 14258
		PerfqueryDonotFlushIntel = 33785,
		// Token: 0x040037B3 RID: 14259
		PerfqueryFlushIntel,
		// Token: 0x040037B4 RID: 14260
		PerfqueryWaitIntel,
		// Token: 0x040037B5 RID: 14261
		PerfqueryCounterEventIntel = 38128,
		// Token: 0x040037B6 RID: 14262
		PerfqueryCounterDurationNormIntel,
		// Token: 0x040037B7 RID: 14263
		PerfqueryCounterDurationRawIntel,
		// Token: 0x040037B8 RID: 14264
		PerfqueryCounterThroughputIntel,
		// Token: 0x040037B9 RID: 14265
		PerfqueryCounterRawIntel,
		// Token: 0x040037BA RID: 14266
		PerfqueryCounterTimestampIntel,
		// Token: 0x040037BB RID: 14267
		PerfqueryCounterDataUint32Intel = 38136,
		// Token: 0x040037BC RID: 14268
		PerfqueryCounterDataUint64Intel,
		// Token: 0x040037BD RID: 14269
		PerfqueryCounterDataFloatIntel,
		// Token: 0x040037BE RID: 14270
		PerfqueryCounterDataDoubleIntel,
		// Token: 0x040037BF RID: 14271
		PerfqueryCounterDataBool32Intel,
		// Token: 0x040037C0 RID: 14272
		PerfqueryQueryNameLengthMaxIntel,
		// Token: 0x040037C1 RID: 14273
		PerfqueryCounterNameLengthMaxIntel,
		// Token: 0x040037C2 RID: 14274
		PerfqueryCounterDescLengthMaxIntel,
		// Token: 0x040037C3 RID: 14275
		PerfqueryGpaExtendedCountersIntel
	}
}
