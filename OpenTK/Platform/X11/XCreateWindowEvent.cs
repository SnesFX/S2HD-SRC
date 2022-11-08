using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000140 RID: 320
	internal struct XCreateWindowEvent
	{
		// Token: 0x04000CCF RID: 3279
		public XEventName type;

		// Token: 0x04000CD0 RID: 3280
		public IntPtr serial;

		// Token: 0x04000CD1 RID: 3281
		public bool send_event;

		// Token: 0x04000CD2 RID: 3282
		public IntPtr display;

		// Token: 0x04000CD3 RID: 3283
		public IntPtr parent;

		// Token: 0x04000CD4 RID: 3284
		public IntPtr window;

		// Token: 0x04000CD5 RID: 3285
		public int x;

		// Token: 0x04000CD6 RID: 3286
		public int y;

		// Token: 0x04000CD7 RID: 3287
		public int width;

		// Token: 0x04000CD8 RID: 3288
		public int height;

		// Token: 0x04000CD9 RID: 3289
		public int border_width;

		// Token: 0x04000CDA RID: 3290
		public bool override_redirect;
	}
}
