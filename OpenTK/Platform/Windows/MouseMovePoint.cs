using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A7 RID: 167
	public struct MouseMovePoint
	{
		// Token: 0x040003FB RID: 1019
		public int X;

		// Token: 0x040003FC RID: 1020
		public int Y;

		// Token: 0x040003FD RID: 1021
		public int Time;

		// Token: 0x040003FE RID: 1022
		public IntPtr ExtraInfo;

		// Token: 0x040003FF RID: 1023
		public static readonly int SizeInBytes = Marshal.SizeOf(default(MouseMovePoint));
	}
}
