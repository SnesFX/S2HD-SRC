using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000084 RID: 132
	internal struct CreateStruct
	{
		// Token: 0x040002FF RID: 767
		internal IntPtr lpCreateParams;

		// Token: 0x04000300 RID: 768
		internal IntPtr hInstance;

		// Token: 0x04000301 RID: 769
		internal IntPtr hMenu;

		// Token: 0x04000302 RID: 770
		internal IntPtr hwndParent;

		// Token: 0x04000303 RID: 771
		internal int cy;

		// Token: 0x04000304 RID: 772
		internal int cx;

		// Token: 0x04000305 RID: 773
		internal int y;

		// Token: 0x04000306 RID: 774
		internal int x;

		// Token: 0x04000307 RID: 775
		internal int style;

		// Token: 0x04000308 RID: 776
		[MarshalAs(UnmanagedType.LPTStr)]
		internal string lpszName;

		// Token: 0x04000309 RID: 777
		[MarshalAs(UnmanagedType.LPTStr)]
		internal string lpszClass;

		// Token: 0x0400030A RID: 778
		internal int dwExStyle;
	}
}
