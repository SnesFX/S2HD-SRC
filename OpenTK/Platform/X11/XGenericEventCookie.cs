using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000156 RID: 342
	internal struct XGenericEventCookie
	{
		// Token: 0x04000D9A RID: 3482
		public int type;

		// Token: 0x04000D9B RID: 3483
		public IntPtr serial;

		// Token: 0x04000D9C RID: 3484
		public bool send_event;

		// Token: 0x04000D9D RID: 3485
		public IntPtr display;

		// Token: 0x04000D9E RID: 3486
		public int extension;

		// Token: 0x04000D9F RID: 3487
		public int evtype;

		// Token: 0x04000DA0 RID: 3488
		public uint cookie;

		// Token: 0x04000DA1 RID: 3489
		public IntPtr data;
	}
}
