using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000150 RID: 336
	internal struct XColormapEvent
	{
		// Token: 0x04000D59 RID: 3417
		public XEventName type;

		// Token: 0x04000D5A RID: 3418
		public IntPtr serial;

		// Token: 0x04000D5B RID: 3419
		public bool send_event;

		// Token: 0x04000D5C RID: 3420
		public IntPtr display;

		// Token: 0x04000D5D RID: 3421
		public IntPtr window;

		// Token: 0x04000D5E RID: 3422
		public IntPtr colormap;

		// Token: 0x04000D5F RID: 3423
		public bool c_new;

		// Token: 0x04000D60 RID: 3424
		public int state;
	}
}
