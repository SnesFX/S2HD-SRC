using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000167 RID: 359
	internal struct XScreen
	{
		// Token: 0x04000ECC RID: 3788
		public IntPtr ext_data;

		// Token: 0x04000ECD RID: 3789
		public IntPtr display;

		// Token: 0x04000ECE RID: 3790
		public IntPtr root;

		// Token: 0x04000ECF RID: 3791
		public int width;

		// Token: 0x04000ED0 RID: 3792
		public int height;

		// Token: 0x04000ED1 RID: 3793
		public int mwidth;

		// Token: 0x04000ED2 RID: 3794
		public int mheight;

		// Token: 0x04000ED3 RID: 3795
		public int ndepths;

		// Token: 0x04000ED4 RID: 3796
		public IntPtr depths;

		// Token: 0x04000ED5 RID: 3797
		public int root_depth;

		// Token: 0x04000ED6 RID: 3798
		public IntPtr root_visual;

		// Token: 0x04000ED7 RID: 3799
		public IntPtr default_gc;

		// Token: 0x04000ED8 RID: 3800
		public IntPtr cmap;

		// Token: 0x04000ED9 RID: 3801
		public IntPtr white_pixel;

		// Token: 0x04000EDA RID: 3802
		public IntPtr black_pixel;

		// Token: 0x04000EDB RID: 3803
		public int max_maps;

		// Token: 0x04000EDC RID: 3804
		public int min_maps;

		// Token: 0x04000EDD RID: 3805
		public int backing_store;

		// Token: 0x04000EDE RID: 3806
		public bool save_unders;

		// Token: 0x04000EDF RID: 3807
		public IntPtr root_input_mask;
	}
}
