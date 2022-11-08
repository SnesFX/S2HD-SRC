using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000155 RID: 341
	internal struct XGenericEvent
	{
		// Token: 0x04000D94 RID: 3476
		public int type;

		// Token: 0x04000D95 RID: 3477
		public IntPtr serial;

		// Token: 0x04000D96 RID: 3478
		public bool send_event;

		// Token: 0x04000D97 RID: 3479
		public IntPtr display;

		// Token: 0x04000D98 RID: 3480
		public int extension;

		// Token: 0x04000D99 RID: 3481
		public int evtype;
	}
}
