using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B71 RID: 2929
	internal struct ModeRes
	{
		// Token: 0x0400B823 RID: 47139
		public int count_fbs;

		// Token: 0x0400B824 RID: 47140
		public unsafe int* fbs;

		// Token: 0x0400B825 RID: 47141
		public int count_crtcs;

		// Token: 0x0400B826 RID: 47142
		public unsafe int* crtcs;

		// Token: 0x0400B827 RID: 47143
		public int count_connectors;

		// Token: 0x0400B828 RID: 47144
		public unsafe int* connectors;

		// Token: 0x0400B829 RID: 47145
		public int count_encoders;

		// Token: 0x0400B82A RID: 47146
		public unsafe int* encoders;

		// Token: 0x0400B82B RID: 47147
		public int min_width;

		// Token: 0x0400B82C RID: 47148
		public int max_width;

		// Token: 0x0400B82D RID: 47149
		public int min_height;

		// Token: 0x0400B82E RID: 47150
		public int max_height;
	}
}
