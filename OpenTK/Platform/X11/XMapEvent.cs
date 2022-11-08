using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000143 RID: 323
	internal struct XMapEvent
	{
		// Token: 0x04000CE8 RID: 3304
		public XEventName type;

		// Token: 0x04000CE9 RID: 3305
		public IntPtr serial;

		// Token: 0x04000CEA RID: 3306
		public bool send_event;

		// Token: 0x04000CEB RID: 3307
		public IntPtr display;

		// Token: 0x04000CEC RID: 3308
		public IntPtr xevent;

		// Token: 0x04000CED RID: 3309
		public IntPtr window;

		// Token: 0x04000CEE RID: 3310
		public bool override_redirect;
	}
}
