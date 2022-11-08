using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014A RID: 330
	internal struct XCirculateEvent
	{
		// Token: 0x04000D29 RID: 3369
		public XEventName type;

		// Token: 0x04000D2A RID: 3370
		public IntPtr serial;

		// Token: 0x04000D2B RID: 3371
		public bool send_event;

		// Token: 0x04000D2C RID: 3372
		public IntPtr display;

		// Token: 0x04000D2D RID: 3373
		public IntPtr xevent;

		// Token: 0x04000D2E RID: 3374
		public IntPtr window;

		// Token: 0x04000D2F RID: 3375
		public int place;
	}
}
