using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000138 RID: 312
	internal struct XMotionEvent
	{
		// Token: 0x04000C60 RID: 3168
		public XEventName type;

		// Token: 0x04000C61 RID: 3169
		public IntPtr serial;

		// Token: 0x04000C62 RID: 3170
		public bool send_event;

		// Token: 0x04000C63 RID: 3171
		public IntPtr display;

		// Token: 0x04000C64 RID: 3172
		public IntPtr window;

		// Token: 0x04000C65 RID: 3173
		public IntPtr root;

		// Token: 0x04000C66 RID: 3174
		public IntPtr subwindow;

		// Token: 0x04000C67 RID: 3175
		public IntPtr time;

		// Token: 0x04000C68 RID: 3176
		public int x;

		// Token: 0x04000C69 RID: 3177
		public int y;

		// Token: 0x04000C6A RID: 3178
		public int x_root;

		// Token: 0x04000C6B RID: 3179
		public int y_root;

		// Token: 0x04000C6C RID: 3180
		public int state;

		// Token: 0x04000C6D RID: 3181
		public byte is_hint;

		// Token: 0x04000C6E RID: 3182
		public bool same_screen;
	}
}
