using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000144 RID: 324
	internal struct XMapRequestEvent
	{
		// Token: 0x04000CEF RID: 3311
		public XEventName type;

		// Token: 0x04000CF0 RID: 3312
		public IntPtr serial;

		// Token: 0x04000CF1 RID: 3313
		public bool send_event;

		// Token: 0x04000CF2 RID: 3314
		public IntPtr display;

		// Token: 0x04000CF3 RID: 3315
		public IntPtr parent;

		// Token: 0x04000CF4 RID: 3316
		public IntPtr window;
	}
}
