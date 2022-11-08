using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A4 RID: 164
	internal struct TrackMouseEventStructure
	{
		// Token: 0x040003EE RID: 1006
		public int Size;

		// Token: 0x040003EF RID: 1007
		public TrackMouseEventFlags Flags;

		// Token: 0x040003F0 RID: 1008
		public IntPtr TrackWindowHandle;

		// Token: 0x040003F1 RID: 1009
		public int HoverTime;

		// Token: 0x040003F2 RID: 1010
		public static readonly int SizeInBytes = Marshal.SizeOf(typeof(TrackMouseEventStructure));
	}
}
