using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014E RID: 334
	internal struct XSelectionRequestEvent
	{
		// Token: 0x04000D46 RID: 3398
		public XEventName type;

		// Token: 0x04000D47 RID: 3399
		public IntPtr serial;

		// Token: 0x04000D48 RID: 3400
		public bool send_event;

		// Token: 0x04000D49 RID: 3401
		public IntPtr display;

		// Token: 0x04000D4A RID: 3402
		public IntPtr owner;

		// Token: 0x04000D4B RID: 3403
		public IntPtr requestor;

		// Token: 0x04000D4C RID: 3404
		public IntPtr selection;

		// Token: 0x04000D4D RID: 3405
		public IntPtr target;

		// Token: 0x04000D4E RID: 3406
		public IntPtr property;

		// Token: 0x04000D4F RID: 3407
		public IntPtr time;
	}
}
