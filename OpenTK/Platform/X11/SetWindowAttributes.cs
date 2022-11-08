using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000116 RID: 278
	[Obsolete("Use XSetWindowAttributes instead")]
	[StructLayout(LayoutKind.Sequential)]
	internal class SetWindowAttributes
	{
		// Token: 0x040009C1 RID: 2497
		public IntPtr background_pixmap;

		// Token: 0x040009C2 RID: 2498
		public long background_pixel;

		// Token: 0x040009C3 RID: 2499
		public IntPtr border_pixmap;

		// Token: 0x040009C4 RID: 2500
		public long border_pixel;

		// Token: 0x040009C5 RID: 2501
		public int bit_gravity;

		// Token: 0x040009C6 RID: 2502
		public int win_gravity;

		// Token: 0x040009C7 RID: 2503
		public int backing_store;

		// Token: 0x040009C8 RID: 2504
		public long backing_planes;

		// Token: 0x040009C9 RID: 2505
		public long backing_pixel;

		// Token: 0x040009CA RID: 2506
		public bool save_under;

		// Token: 0x040009CB RID: 2507
		public EventMask event_mask;

		// Token: 0x040009CC RID: 2508
		public long do_not_propagate_mask;

		// Token: 0x040009CD RID: 2509
		public bool override_redirect;

		// Token: 0x040009CE RID: 2510
		public IntPtr colormap;

		// Token: 0x040009CF RID: 2511
		public IntPtr cursor;
	}
}
