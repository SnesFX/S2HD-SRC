using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000113 RID: 275
	internal struct XcursorCursors
	{
		// Token: 0x040009B1 RID: 2481
		public IntPtr dpy;

		// Token: 0x040009B2 RID: 2482
		public int refcount;

		// Token: 0x040009B3 RID: 2483
		public int ncursor;

		// Token: 0x040009B4 RID: 2484
		public unsafe IntPtr* cursors;
	}
}
