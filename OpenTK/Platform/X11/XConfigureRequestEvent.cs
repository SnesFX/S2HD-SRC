using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000149 RID: 329
	internal struct XConfigureRequestEvent
	{
		// Token: 0x04000D1B RID: 3355
		public XEventName type;

		// Token: 0x04000D1C RID: 3356
		public IntPtr serial;

		// Token: 0x04000D1D RID: 3357
		public bool send_event;

		// Token: 0x04000D1E RID: 3358
		public IntPtr display;

		// Token: 0x04000D1F RID: 3359
		public IntPtr parent;

		// Token: 0x04000D20 RID: 3360
		public IntPtr window;

		// Token: 0x04000D21 RID: 3361
		public int x;

		// Token: 0x04000D22 RID: 3362
		public int y;

		// Token: 0x04000D23 RID: 3363
		public int width;

		// Token: 0x04000D24 RID: 3364
		public int height;

		// Token: 0x04000D25 RID: 3365
		public int border_width;

		// Token: 0x04000D26 RID: 3366
		public IntPtr above;

		// Token: 0x04000D27 RID: 3367
		public int detail;

		// Token: 0x04000D28 RID: 3368
		public IntPtr value_mask;
	}
}
