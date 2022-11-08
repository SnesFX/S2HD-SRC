using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000151 RID: 337
	internal struct XClientMessageEvent
	{
		// Token: 0x04000D61 RID: 3425
		public XEventName type;

		// Token: 0x04000D62 RID: 3426
		public IntPtr serial;

		// Token: 0x04000D63 RID: 3427
		public bool send_event;

		// Token: 0x04000D64 RID: 3428
		public IntPtr display;

		// Token: 0x04000D65 RID: 3429
		public IntPtr window;

		// Token: 0x04000D66 RID: 3430
		public IntPtr message_type;

		// Token: 0x04000D67 RID: 3431
		public int format;

		// Token: 0x04000D68 RID: 3432
		public IntPtr ptr1;

		// Token: 0x04000D69 RID: 3433
		public IntPtr ptr2;

		// Token: 0x04000D6A RID: 3434
		public IntPtr ptr3;

		// Token: 0x04000D6B RID: 3435
		public IntPtr ptr4;

		// Token: 0x04000D6C RID: 3436
		public IntPtr ptr5;
	}
}
