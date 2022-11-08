using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200013C RID: 316
	internal struct XExposeEvent
	{
		// Token: 0x04000CAC RID: 3244
		public XEventName type;

		// Token: 0x04000CAD RID: 3245
		public IntPtr serial;

		// Token: 0x04000CAE RID: 3246
		public bool send_event;

		// Token: 0x04000CAF RID: 3247
		public IntPtr display;

		// Token: 0x04000CB0 RID: 3248
		public IntPtr window;

		// Token: 0x04000CB1 RID: 3249
		public int x;

		// Token: 0x04000CB2 RID: 3250
		public int y;

		// Token: 0x04000CB3 RID: 3251
		public int width;

		// Token: 0x04000CB4 RID: 3252
		public int height;

		// Token: 0x04000CB5 RID: 3253
		public int count;
	}
}
