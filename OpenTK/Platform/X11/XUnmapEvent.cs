using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000142 RID: 322
	internal struct XUnmapEvent
	{
		// Token: 0x04000CE1 RID: 3297
		public XEventName type;

		// Token: 0x04000CE2 RID: 3298
		public IntPtr serial;

		// Token: 0x04000CE3 RID: 3299
		public bool send_event;

		// Token: 0x04000CE4 RID: 3300
		public IntPtr display;

		// Token: 0x04000CE5 RID: 3301
		public IntPtr xevent;

		// Token: 0x04000CE6 RID: 3302
		public IntPtr window;

		// Token: 0x04000CE7 RID: 3303
		public bool from_configure;
	}
}
