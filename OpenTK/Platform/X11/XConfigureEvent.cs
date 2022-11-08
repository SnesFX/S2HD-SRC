using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000146 RID: 326
	internal struct XConfigureEvent
	{
		// Token: 0x04000CFF RID: 3327
		public XEventName type;

		// Token: 0x04000D00 RID: 3328
		public IntPtr serial;

		// Token: 0x04000D01 RID: 3329
		public bool send_event;

		// Token: 0x04000D02 RID: 3330
		public IntPtr display;

		// Token: 0x04000D03 RID: 3331
		public IntPtr xevent;

		// Token: 0x04000D04 RID: 3332
		public IntPtr window;

		// Token: 0x04000D05 RID: 3333
		public int x;

		// Token: 0x04000D06 RID: 3334
		public int y;

		// Token: 0x04000D07 RID: 3335
		public int width;

		// Token: 0x04000D08 RID: 3336
		public int height;

		// Token: 0x04000D09 RID: 3337
		public int border_width;

		// Token: 0x04000D0A RID: 3338
		public IntPtr above;

		// Token: 0x04000D0B RID: 3339
		public bool override_redirect;
	}
}
