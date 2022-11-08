using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200013D RID: 317
	internal struct XGraphicsExposeEvent
	{
		// Token: 0x04000CB6 RID: 3254
		public XEventName type;

		// Token: 0x04000CB7 RID: 3255
		public IntPtr serial;

		// Token: 0x04000CB8 RID: 3256
		public bool send_event;

		// Token: 0x04000CB9 RID: 3257
		public IntPtr display;

		// Token: 0x04000CBA RID: 3258
		public IntPtr drawable;

		// Token: 0x04000CBB RID: 3259
		public int x;

		// Token: 0x04000CBC RID: 3260
		public int y;

		// Token: 0x04000CBD RID: 3261
		public int width;

		// Token: 0x04000CBE RID: 3262
		public int height;

		// Token: 0x04000CBF RID: 3263
		public int count;

		// Token: 0x04000CC0 RID: 3264
		public int major_code;

		// Token: 0x04000CC1 RID: 3265
		public int minor_code;
	}
}
