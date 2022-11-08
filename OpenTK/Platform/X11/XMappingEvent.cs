using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000152 RID: 338
	internal struct XMappingEvent
	{
		// Token: 0x04000D6D RID: 3437
		public XEventName type;

		// Token: 0x04000D6E RID: 3438
		public IntPtr serial;

		// Token: 0x04000D6F RID: 3439
		public bool send_event;

		// Token: 0x04000D70 RID: 3440
		public IntPtr display;

		// Token: 0x04000D71 RID: 3441
		public IntPtr window;

		// Token: 0x04000D72 RID: 3442
		public int request;

		// Token: 0x04000D73 RID: 3443
		public int first_keycode;

		// Token: 0x04000D74 RID: 3444
		public int count;
	}
}
