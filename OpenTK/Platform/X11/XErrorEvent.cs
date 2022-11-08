using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000153 RID: 339
	internal struct XErrorEvent
	{
		// Token: 0x04000D75 RID: 3445
		public XEventName type;

		// Token: 0x04000D76 RID: 3446
		public IntPtr display;

		// Token: 0x04000D77 RID: 3447
		public IntPtr resourceid;

		// Token: 0x04000D78 RID: 3448
		public IntPtr serial;

		// Token: 0x04000D79 RID: 3449
		public byte error_code;

		// Token: 0x04000D7A RID: 3450
		public XRequest request_code;

		// Token: 0x04000D7B RID: 3451
		public byte minor_code;
	}
}
