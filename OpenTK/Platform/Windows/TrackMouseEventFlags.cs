using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000CB RID: 203
	[Flags]
	internal enum TrackMouseEventFlags : uint
	{
		// Token: 0x040006C3 RID: 1731
		HOVER = 1U,
		// Token: 0x040006C4 RID: 1732
		LEAVE = 2U,
		// Token: 0x040006C5 RID: 1733
		NONCLIENT = 16U,
		// Token: 0x040006C6 RID: 1734
		QUERY = 1073741824U,
		// Token: 0x040006C7 RID: 1735
		CANCEL = 2147483648U
	}
}
