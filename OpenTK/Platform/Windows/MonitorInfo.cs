using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A1 RID: 161
	internal struct MonitorInfo
	{
		// Token: 0x040003E0 RID: 992
		public int Size;

		// Token: 0x040003E1 RID: 993
		public Win32Rectangle Monitor;

		// Token: 0x040003E2 RID: 994
		public Win32Rectangle Work;

		// Token: 0x040003E3 RID: 995
		public int Flags;

		// Token: 0x040003E4 RID: 996
		public static readonly int SizeInBytes = Marshal.SizeOf(default(MonitorInfo));
	}
}
