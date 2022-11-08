using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200014C RID: 332
	internal struct XPropertyEvent
	{
		// Token: 0x04000D37 RID: 3383
		public XEventName type;

		// Token: 0x04000D38 RID: 3384
		public IntPtr serial;

		// Token: 0x04000D39 RID: 3385
		public bool send_event;

		// Token: 0x04000D3A RID: 3386
		public IntPtr display;

		// Token: 0x04000D3B RID: 3387
		public IntPtr window;

		// Token: 0x04000D3C RID: 3388
		public IntPtr atom;

		// Token: 0x04000D3D RID: 3389
		public IntPtr time;

		// Token: 0x04000D3E RID: 3390
		public int state;
	}
}
