using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000159 RID: 345
	internal struct XWindowAttributes
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x000260B0 File Offset: 0x000242B0
		public override string ToString()
		{
			return XEvent.ToString(this);
		}

		// Token: 0x04000DD4 RID: 3540
		public int x;

		// Token: 0x04000DD5 RID: 3541
		public int y;

		// Token: 0x04000DD6 RID: 3542
		public int width;

		// Token: 0x04000DD7 RID: 3543
		public int height;

		// Token: 0x04000DD8 RID: 3544
		public int border_width;

		// Token: 0x04000DD9 RID: 3545
		public int depth;

		// Token: 0x04000DDA RID: 3546
		public IntPtr visual;

		// Token: 0x04000DDB RID: 3547
		public IntPtr root;

		// Token: 0x04000DDC RID: 3548
		public int c_class;

		// Token: 0x04000DDD RID: 3549
		public Gravity bit_gravity;

		// Token: 0x04000DDE RID: 3550
		public Gravity win_gravity;

		// Token: 0x04000DDF RID: 3551
		public int backing_store;

		// Token: 0x04000DE0 RID: 3552
		public IntPtr backing_planes;

		// Token: 0x04000DE1 RID: 3553
		public IntPtr backing_pixel;

		// Token: 0x04000DE2 RID: 3554
		public bool save_under;

		// Token: 0x04000DE3 RID: 3555
		public IntPtr colormap;

		// Token: 0x04000DE4 RID: 3556
		public bool map_installed;

		// Token: 0x04000DE5 RID: 3557
		public MapState map_state;

		// Token: 0x04000DE6 RID: 3558
		public IntPtr all_event_masks;

		// Token: 0x04000DE7 RID: 3559
		public IntPtr your_event_mask;

		// Token: 0x04000DE8 RID: 3560
		public IntPtr do_not_propagate_mask;

		// Token: 0x04000DE9 RID: 3561
		public bool override_direct;

		// Token: 0x04000DEA RID: 3562
		public IntPtr screen;
	}
}
