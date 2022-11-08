using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000145 RID: 325
	internal struct XReparentEvent
	{
		// Token: 0x04000CF5 RID: 3317
		public XEventName type;

		// Token: 0x04000CF6 RID: 3318
		public IntPtr serial;

		// Token: 0x04000CF7 RID: 3319
		public bool send_event;

		// Token: 0x04000CF8 RID: 3320
		public IntPtr display;

		// Token: 0x04000CF9 RID: 3321
		public IntPtr xevent;

		// Token: 0x04000CFA RID: 3322
		public IntPtr window;

		// Token: 0x04000CFB RID: 3323
		public IntPtr parent;

		// Token: 0x04000CFC RID: 3324
		public int x;

		// Token: 0x04000CFD RID: 3325
		public int y;

		// Token: 0x04000CFE RID: 3326
		public bool override_redirect;
	}
}
