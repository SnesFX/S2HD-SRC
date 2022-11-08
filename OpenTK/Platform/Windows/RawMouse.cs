using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000098 RID: 152
	[StructLayout(LayoutKind.Explicit)]
	internal struct RawMouse
	{
		// Token: 0x040003B4 RID: 948
		[FieldOffset(0)]
		public RawMouseFlags Flags;

		// Token: 0x040003B5 RID: 949
		[FieldOffset(4)]
		public RawInputMouseState ButtonFlags;

		// Token: 0x040003B6 RID: 950
		[FieldOffset(6)]
		public ushort ButtonData;

		// Token: 0x040003B7 RID: 951
		[FieldOffset(8)]
		public uint RawButtons;

		// Token: 0x040003B8 RID: 952
		[FieldOffset(12)]
		public int LastX;

		// Token: 0x040003B9 RID: 953
		[FieldOffset(16)]
		public int LastY;

		// Token: 0x040003BA RID: 954
		[FieldOffset(20)]
		public uint ExtraInformation;
	}
}
