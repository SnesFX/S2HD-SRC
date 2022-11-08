using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000186 RID: 390
	internal struct XWMHints
	{
		// Token: 0x04001007 RID: 4103
		public IntPtr flags;

		// Token: 0x04001008 RID: 4104
		public bool input;

		// Token: 0x04001009 RID: 4105
		public XInitialState initial_state;

		// Token: 0x0400100A RID: 4106
		public IntPtr icon_pixmap;

		// Token: 0x0400100B RID: 4107
		public IntPtr icon_window;

		// Token: 0x0400100C RID: 4108
		public int icon_x;

		// Token: 0x0400100D RID: 4109
		public int icon_y;

		// Token: 0x0400100E RID: 4110
		public IntPtr icon_mask;

		// Token: 0x0400100F RID: 4111
		public IntPtr window_group;
	}
}
