using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A0 RID: 160
	internal struct WindowInfo
	{
		// Token: 0x040003D6 RID: 982
		public int Size;

		// Token: 0x040003D7 RID: 983
		public Win32Rectangle Window;

		// Token: 0x040003D8 RID: 984
		public Win32Rectangle Client;

		// Token: 0x040003D9 RID: 985
		public WindowStyle Style;

		// Token: 0x040003DA RID: 986
		public ExtendedWindowStyle ExStyle;

		// Token: 0x040003DB RID: 987
		public int WindowStatus;

		// Token: 0x040003DC RID: 988
		public uint WindowBordersX;

		// Token: 0x040003DD RID: 989
		public uint WindowBordersY;

		// Token: 0x040003DE RID: 990
		public int WindowType;

		// Token: 0x040003DF RID: 991
		public short CreatorVersion;
	}
}
