using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A2 RID: 162
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct NcCalculateSize
	{
		// Token: 0x040003E5 RID: 997
		public Win32Rectangle NewBounds;

		// Token: 0x040003E6 RID: 998
		public Win32Rectangle OldBounds;

		// Token: 0x040003E7 RID: 999
		public Win32Rectangle OldClientRectangle;

		// Token: 0x040003E8 RID: 1000
		public unsafe WindowPosition* Position;
	}
}
