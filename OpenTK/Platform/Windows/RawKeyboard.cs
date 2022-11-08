using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000097 RID: 151
	internal struct RawKeyboard
	{
		// Token: 0x040003AE RID: 942
		internal short MakeCode;

		// Token: 0x040003AF RID: 943
		internal RawInputKeyboardDataFlags Flags;

		// Token: 0x040003B0 RID: 944
		private ushort Reserved;

		// Token: 0x040003B1 RID: 945
		internal VirtualKeys VKey;

		// Token: 0x040003B2 RID: 946
		internal int Message;

		// Token: 0x040003B3 RID: 947
		internal int ExtraInformation;
	}
}
