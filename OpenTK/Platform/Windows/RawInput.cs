using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000094 RID: 148
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct RawInput
	{
		// Token: 0x040003A5 RID: 933
		public RawInputHeader Header;

		// Token: 0x040003A6 RID: 934
		public RawInputData Data;
	}
}
