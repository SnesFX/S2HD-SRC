using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000139 RID: 313
	internal struct XCrossingEvent
	{
		// Token: 0x04000C6F RID: 3183
		public XEventName type;

		// Token: 0x04000C70 RID: 3184
		public IntPtr serial;

		// Token: 0x04000C71 RID: 3185
		public bool send_event;

		// Token: 0x04000C72 RID: 3186
		public IntPtr display;

		// Token: 0x04000C73 RID: 3187
		public IntPtr window;

		// Token: 0x04000C74 RID: 3188
		public IntPtr root;

		// Token: 0x04000C75 RID: 3189
		public IntPtr subwindow;

		// Token: 0x04000C76 RID: 3190
		public IntPtr time;

		// Token: 0x04000C77 RID: 3191
		public int x;

		// Token: 0x04000C78 RID: 3192
		public int y;

		// Token: 0x04000C79 RID: 3193
		public int x_root;

		// Token: 0x04000C7A RID: 3194
		public int y_root;

		// Token: 0x04000C7B RID: 3195
		public NotifyMode mode;

		// Token: 0x04000C7C RID: 3196
		public NotifyDetail detail;

		// Token: 0x04000C7D RID: 3197
		public bool same_screen;

		// Token: 0x04000C7E RID: 3198
		public bool focus;

		// Token: 0x04000C7F RID: 3199
		public int state;
	}
}
