using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B6D RID: 2925
	internal struct ModeCrtc
	{
		// Token: 0x0400B805 RID: 47109
		public int crtc_id;

		// Token: 0x0400B806 RID: 47110
		public int buffer_id;

		// Token: 0x0400B807 RID: 47111
		public int x;

		// Token: 0x0400B808 RID: 47112
		public int y;

		// Token: 0x0400B809 RID: 47113
		public int width;

		// Token: 0x0400B80A RID: 47114
		public int height;

		// Token: 0x0400B80B RID: 47115
		public int mode_valid;

		// Token: 0x0400B80C RID: 47116
		public ModeInfo mode;

		// Token: 0x0400B80D RID: 47117
		public int gamma_size;
	}
}
