using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014D RID: 333
	internal struct XSelectionClearEvent
	{
		// Token: 0x04000D3F RID: 3391
		public XEventName type;

		// Token: 0x04000D40 RID: 3392
		public IntPtr serial;

		// Token: 0x04000D41 RID: 3393
		public bool send_event;

		// Token: 0x04000D42 RID: 3394
		public IntPtr display;

		// Token: 0x04000D43 RID: 3395
		public IntPtr window;

		// Token: 0x04000D44 RID: 3396
		public IntPtr selection;

		// Token: 0x04000D45 RID: 3397
		public IntPtr time;
	}
}
