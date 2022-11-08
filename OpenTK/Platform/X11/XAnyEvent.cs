using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000135 RID: 309
	internal struct XAnyEvent
	{
		// Token: 0x04000C3D RID: 3133
		public XEventName type;

		// Token: 0x04000C3E RID: 3134
		public IntPtr serial;

		// Token: 0x04000C3F RID: 3135
		public bool send_event;

		// Token: 0x04000C40 RID: 3136
		public IntPtr display;

		// Token: 0x04000C41 RID: 3137
		public IntPtr window;
	}
}
