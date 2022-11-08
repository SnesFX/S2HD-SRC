using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200013E RID: 318
	internal struct XNoExposeEvent
	{
		// Token: 0x04000CC2 RID: 3266
		public XEventName type;

		// Token: 0x04000CC3 RID: 3267
		public IntPtr serial;

		// Token: 0x04000CC4 RID: 3268
		public bool send_event;

		// Token: 0x04000CC5 RID: 3269
		public IntPtr display;

		// Token: 0x04000CC6 RID: 3270
		public IntPtr drawable;

		// Token: 0x04000CC7 RID: 3271
		public int major_code;

		// Token: 0x04000CC8 RID: 3272
		public int minor_code;
	}
}
