using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200015B RID: 347
	internal struct XClassHint
	{
		// Token: 0x04000DEF RID: 3567
		[MarshalAs(UnmanagedType.LPStr)]
		public string Name;

		// Token: 0x04000DF0 RID: 3568
		[MarshalAs(UnmanagedType.LPStr)]
		public string Class;
	}
}
