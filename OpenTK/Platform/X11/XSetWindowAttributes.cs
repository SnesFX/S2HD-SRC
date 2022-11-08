using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000158 RID: 344
	internal struct XSetWindowAttributes
	{
		// Token: 0x04000DC5 RID: 3525
		public IntPtr background_pixmap;

		// Token: 0x04000DC6 RID: 3526
		public IntPtr background_pixel;

		// Token: 0x04000DC7 RID: 3527
		public IntPtr border_pixmap;

		// Token: 0x04000DC8 RID: 3528
		public IntPtr border_pixel;

		// Token: 0x04000DC9 RID: 3529
		public Gravity bit_gravity;

		// Token: 0x04000DCA RID: 3530
		public Gravity win_gravity;

		// Token: 0x04000DCB RID: 3531
		public int backing_store;

		// Token: 0x04000DCC RID: 3532
		public IntPtr backing_planes;

		// Token: 0x04000DCD RID: 3533
		public IntPtr backing_pixel;

		// Token: 0x04000DCE RID: 3534
		public bool save_under;

		// Token: 0x04000DCF RID: 3535
		public IntPtr event_mask;

		// Token: 0x04000DD0 RID: 3536
		public IntPtr do_not_propagate_mask;

		// Token: 0x04000DD1 RID: 3537
		public bool override_redirect;

		// Token: 0x04000DD2 RID: 3538
		public IntPtr colormap;

		// Token: 0x04000DD3 RID: 3539
		public IntPtr cursor;
	}
}
