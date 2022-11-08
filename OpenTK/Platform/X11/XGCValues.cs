using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200017B RID: 379
	internal struct XGCValues
	{
		// Token: 0x04000F53 RID: 3923
		public GXFunction function;

		// Token: 0x04000F54 RID: 3924
		public IntPtr plane_mask;

		// Token: 0x04000F55 RID: 3925
		public IntPtr foreground;

		// Token: 0x04000F56 RID: 3926
		public IntPtr background;

		// Token: 0x04000F57 RID: 3927
		public int line_width;

		// Token: 0x04000F58 RID: 3928
		public GCLineStyle line_style;

		// Token: 0x04000F59 RID: 3929
		public GCCapStyle cap_style;

		// Token: 0x04000F5A RID: 3930
		public GCJoinStyle join_style;

		// Token: 0x04000F5B RID: 3931
		public GCFillStyle fill_style;

		// Token: 0x04000F5C RID: 3932
		public GCFillRule fill_rule;

		// Token: 0x04000F5D RID: 3933
		public GCArcMode arc_mode;

		// Token: 0x04000F5E RID: 3934
		public IntPtr tile;

		// Token: 0x04000F5F RID: 3935
		public IntPtr stipple;

		// Token: 0x04000F60 RID: 3936
		public int ts_x_origin;

		// Token: 0x04000F61 RID: 3937
		public int ts_y_origin;

		// Token: 0x04000F62 RID: 3938
		public IntPtr font;

		// Token: 0x04000F63 RID: 3939
		public GCSubwindowMode subwindow_mode;

		// Token: 0x04000F64 RID: 3940
		public bool graphics_exposures;

		// Token: 0x04000F65 RID: 3941
		public int clip_x_origin;

		// Token: 0x04000F66 RID: 3942
		public int clib_y_origin;

		// Token: 0x04000F67 RID: 3943
		public IntPtr clip_mask;

		// Token: 0x04000F68 RID: 3944
		public int dash_offset;

		// Token: 0x04000F69 RID: 3945
		public byte dashes;
	}
}
