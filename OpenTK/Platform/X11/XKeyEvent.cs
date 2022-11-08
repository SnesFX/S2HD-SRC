using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000136 RID: 310
	internal struct XKeyEvent
	{
		// Token: 0x04000C42 RID: 3138
		public XEventName type;

		// Token: 0x04000C43 RID: 3139
		public IntPtr serial;

		// Token: 0x04000C44 RID: 3140
		public bool send_event;

		// Token: 0x04000C45 RID: 3141
		public IntPtr display;

		// Token: 0x04000C46 RID: 3142
		public IntPtr window;

		// Token: 0x04000C47 RID: 3143
		public IntPtr root;

		// Token: 0x04000C48 RID: 3144
		public IntPtr subwindow;

		// Token: 0x04000C49 RID: 3145
		public IntPtr time;

		// Token: 0x04000C4A RID: 3146
		public int x;

		// Token: 0x04000C4B RID: 3147
		public int y;

		// Token: 0x04000C4C RID: 3148
		public int x_root;

		// Token: 0x04000C4D RID: 3149
		public int y_root;

		// Token: 0x04000C4E RID: 3150
		public int state;

		// Token: 0x04000C4F RID: 3151
		public int keycode;

		// Token: 0x04000C50 RID: 3152
		public bool same_screen;
	}
}
