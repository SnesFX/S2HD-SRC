using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000165 RID: 357
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct XColor
	{
		// Token: 0x04000E7F RID: 3711
		public IntPtr pixel;

		// Token: 0x04000E80 RID: 3712
		public ushort red;

		// Token: 0x04000E81 RID: 3713
		public ushort green;

		// Token: 0x04000E82 RID: 3714
		public ushort blue;

		// Token: 0x04000E83 RID: 3715
		public byte flags;

		// Token: 0x04000E84 RID: 3716
		public byte pad;
	}
}
