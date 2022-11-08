using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200013A RID: 314
	internal struct XFocusChangeEvent
	{
		// Token: 0x04000C80 RID: 3200
		public XEventName type;

		// Token: 0x04000C81 RID: 3201
		public IntPtr serial;

		// Token: 0x04000C82 RID: 3202
		public bool send_event;

		// Token: 0x04000C83 RID: 3203
		public IntPtr display;

		// Token: 0x04000C84 RID: 3204
		public IntPtr window;

		// Token: 0x04000C85 RID: 3205
		public int mode;

		// Token: 0x04000C86 RID: 3206
		public NotifyDetail detail;
	}
}
