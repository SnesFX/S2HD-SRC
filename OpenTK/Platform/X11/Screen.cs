using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200011A RID: 282
	internal struct Screen
	{
		// Token: 0x040009E6 RID: 2534
		private XExtData ext_data;

		// Token: 0x040009E7 RID: 2535
		private IntPtr display;

		// Token: 0x040009E8 RID: 2536
		private IntPtr root;

		// Token: 0x040009E9 RID: 2537
		private int width;

		// Token: 0x040009EA RID: 2538
		private int height;

		// Token: 0x040009EB RID: 2539
		private int mwidth;

		// Token: 0x040009EC RID: 2540
		private int mheight;

		// Token: 0x040009ED RID: 2541
		private int ndepths;

		// Token: 0x040009EE RID: 2542
		private int root_depth;

		// Token: 0x040009EF RID: 2543
		private IntPtr default_gc;

		// Token: 0x040009F0 RID: 2544
		private IntPtr cmap;

		// Token: 0x040009F1 RID: 2545
		private UIntPtr white_pixel;

		// Token: 0x040009F2 RID: 2546
		private UIntPtr black_pixel;

		// Token: 0x040009F3 RID: 2547
		private int max_maps;

		// Token: 0x040009F4 RID: 2548
		private int min_maps;

		// Token: 0x040009F5 RID: 2549
		private int backing_store;

		// Token: 0x040009F6 RID: 2550
		private bool save_unders;

		// Token: 0x040009F7 RID: 2551
		private long root_input_mask;
	}
}
