using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200011B RID: 283
	internal class XExtData
	{
		// Token: 0x040009F8 RID: 2552
		private int number;

		// Token: 0x040009F9 RID: 2553
		private XExtData next;

		// Token: 0x040009FA RID: 2554
		private XExtData.FreePrivateDelegate FreePrivate;

		// Token: 0x040009FB RID: 2555
		private IntPtr private_data;

		// Token: 0x0200011C RID: 284
		// (Invoke) Token: 0x06000A96 RID: 2710
		private delegate int FreePrivateDelegate(XExtData extension);
	}
}
