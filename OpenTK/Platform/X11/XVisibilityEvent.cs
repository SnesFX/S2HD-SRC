using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200013F RID: 319
	internal struct XVisibilityEvent
	{
		// Token: 0x04000CC9 RID: 3273
		public XEventName type;

		// Token: 0x04000CCA RID: 3274
		public IntPtr serial;

		// Token: 0x04000CCB RID: 3275
		public bool send_event;

		// Token: 0x04000CCC RID: 3276
		public IntPtr display;

		// Token: 0x04000CCD RID: 3277
		public IntPtr window;

		// Token: 0x04000CCE RID: 3278
		public int state;
	}
}
