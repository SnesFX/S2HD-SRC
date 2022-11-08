using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A3 RID: 163
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct SHFILEINFO
	{
		// Token: 0x040003E9 RID: 1001
		public IntPtr hIcon;

		// Token: 0x040003EA RID: 1002
		public int iIcon;

		// Token: 0x040003EB RID: 1003
		public uint dwAttributes;

		// Token: 0x040003EC RID: 1004
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;

		// Token: 0x040003ED RID: 1005
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}
}
