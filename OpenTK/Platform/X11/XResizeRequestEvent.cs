using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000148 RID: 328
	internal struct XResizeRequestEvent
	{
		// Token: 0x04000D14 RID: 3348
		public XEventName type;

		// Token: 0x04000D15 RID: 3349
		public IntPtr serial;

		// Token: 0x04000D16 RID: 3350
		public bool send_event;

		// Token: 0x04000D17 RID: 3351
		public IntPtr display;

		// Token: 0x04000D18 RID: 3352
		public IntPtr window;

		// Token: 0x04000D19 RID: 3353
		public int width;

		// Token: 0x04000D1A RID: 3354
		public int height;
	}
}
