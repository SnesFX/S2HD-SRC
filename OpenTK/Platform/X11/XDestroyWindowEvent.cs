using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000141 RID: 321
	internal struct XDestroyWindowEvent
	{
		// Token: 0x04000CDB RID: 3291
		public XEventName type;

		// Token: 0x04000CDC RID: 3292
		public IntPtr serial;

		// Token: 0x04000CDD RID: 3293
		public bool send_event;

		// Token: 0x04000CDE RID: 3294
		public IntPtr display;

		// Token: 0x04000CDF RID: 3295
		public IntPtr xevent;

		// Token: 0x04000CE0 RID: 3296
		public IntPtr window;
	}
}
