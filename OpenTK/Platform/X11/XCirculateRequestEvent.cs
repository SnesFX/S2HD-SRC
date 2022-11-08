using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014B RID: 331
	internal struct XCirculateRequestEvent
	{
		// Token: 0x04000D30 RID: 3376
		public XEventName type;

		// Token: 0x04000D31 RID: 3377
		public IntPtr serial;

		// Token: 0x04000D32 RID: 3378
		public bool send_event;

		// Token: 0x04000D33 RID: 3379
		public IntPtr display;

		// Token: 0x04000D34 RID: 3380
		public IntPtr parent;

		// Token: 0x04000D35 RID: 3381
		public IntPtr window;

		// Token: 0x04000D36 RID: 3382
		public int place;
	}
}
