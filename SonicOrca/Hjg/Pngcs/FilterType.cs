using System;

namespace Hjg.Pngcs
{
	// Token: 0x0200001F RID: 31
	public enum FilterType
	{
		// Token: 0x04000037 RID: 55
		FILTER_NONE,
		// Token: 0x04000038 RID: 56
		FILTER_SUB,
		// Token: 0x04000039 RID: 57
		FILTER_UP,
		// Token: 0x0400003A RID: 58
		FILTER_AVERAGE,
		// Token: 0x0400003B RID: 59
		FILTER_PAETH,
		// Token: 0x0400003C RID: 60
		FILTER_DEFAULT = -1,
		// Token: 0x0400003D RID: 61
		FILTER_AGGRESSIVE = -2,
		// Token: 0x0400003E RID: 62
		FILTER_VERYAGGRESSIVE = -3,
		// Token: 0x0400003F RID: 63
		FILTER_CYCLIC = -50,
		// Token: 0x04000040 RID: 64
		FILTER_UNKNOWN = -100
	}
}
