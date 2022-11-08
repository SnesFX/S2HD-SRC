using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014F RID: 335
	internal struct XSelectionEvent
	{
		// Token: 0x04000D50 RID: 3408
		public XEventName type;

		// Token: 0x04000D51 RID: 3409
		public IntPtr serial;

		// Token: 0x04000D52 RID: 3410
		public bool send_event;

		// Token: 0x04000D53 RID: 3411
		public IntPtr display;

		// Token: 0x04000D54 RID: 3412
		public IntPtr requestor;

		// Token: 0x04000D55 RID: 3413
		public IntPtr selection;

		// Token: 0x04000D56 RID: 3414
		public IntPtr target;

		// Token: 0x04000D57 RID: 3415
		public IntPtr property;

		// Token: 0x04000D58 RID: 3416
		public IntPtr time;
	}
}
