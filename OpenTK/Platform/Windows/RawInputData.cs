using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000095 RID: 149
	[StructLayout(LayoutKind.Explicit)]
	internal struct RawInputData
	{
		// Token: 0x040003A7 RID: 935
		[FieldOffset(0)]
		internal RawMouse Mouse;

		// Token: 0x040003A8 RID: 936
		[FieldOffset(0)]
		internal RawKeyboard Keyboard;

		// Token: 0x040003A9 RID: 937
		[FieldOffset(0)]
		internal RawHID HID;
	}
}
