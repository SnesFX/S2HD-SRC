using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B6B RID: 2923
	internal struct EventContext
	{
		// Token: 0x0400B7F2 RID: 47090
		public int version;

		// Token: 0x0400B7F3 RID: 47091
		public IntPtr vblank_handler;

		// Token: 0x0400B7F4 RID: 47092
		public IntPtr page_flip_handler;

		// Token: 0x0400B7F5 RID: 47093
		public static readonly int Version = 2;
	}
}
