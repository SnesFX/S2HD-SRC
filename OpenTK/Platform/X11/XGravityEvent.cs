using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000147 RID: 327
	internal struct XGravityEvent
	{
		// Token: 0x04000D0C RID: 3340
		public XEventName type;

		// Token: 0x04000D0D RID: 3341
		public IntPtr serial;

		// Token: 0x04000D0E RID: 3342
		public bool send_event;

		// Token: 0x04000D0F RID: 3343
		public IntPtr display;

		// Token: 0x04000D10 RID: 3344
		public IntPtr xevent;

		// Token: 0x04000D11 RID: 3345
		public IntPtr window;

		// Token: 0x04000D12 RID: 3346
		public int x;

		// Token: 0x04000D13 RID: 3347
		public int y;
	}
}
