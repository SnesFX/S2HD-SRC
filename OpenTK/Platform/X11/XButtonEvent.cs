using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000137 RID: 311
	internal struct XButtonEvent
	{
		// Token: 0x04000C51 RID: 3153
		public XEventName type;

		// Token: 0x04000C52 RID: 3154
		public IntPtr serial;

		// Token: 0x04000C53 RID: 3155
		public bool send_event;

		// Token: 0x04000C54 RID: 3156
		public IntPtr display;

		// Token: 0x04000C55 RID: 3157
		public IntPtr window;

		// Token: 0x04000C56 RID: 3158
		public IntPtr root;

		// Token: 0x04000C57 RID: 3159
		public IntPtr subwindow;

		// Token: 0x04000C58 RID: 3160
		public IntPtr time;

		// Token: 0x04000C59 RID: 3161
		public int x;

		// Token: 0x04000C5A RID: 3162
		public int y;

		// Token: 0x04000C5B RID: 3163
		public int x_root;

		// Token: 0x04000C5C RID: 3164
		public int y_root;

		// Token: 0x04000C5D RID: 3165
		public int state;

		// Token: 0x04000C5E RID: 3166
		public int button;

		// Token: 0x04000C5F RID: 3167
		public bool same_screen;
	}
}
