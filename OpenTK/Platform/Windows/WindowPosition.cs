using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000090 RID: 144
	internal struct WindowPosition
	{
		// Token: 0x04000388 RID: 904
		internal IntPtr hwnd;

		// Token: 0x04000389 RID: 905
		internal IntPtr hwndInsertAfter;

		// Token: 0x0400038A RID: 906
		internal int x;

		// Token: 0x0400038B RID: 907
		internal int y;

		// Token: 0x0400038C RID: 908
		internal int cx;

		// Token: 0x0400038D RID: 909
		internal int cy;

		// Token: 0x0400038E RID: 910
		[MarshalAs(UnmanagedType.U4)]
		internal SetWindowPosFlags flags;
	}
}
