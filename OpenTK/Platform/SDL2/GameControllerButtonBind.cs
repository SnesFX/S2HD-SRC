using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C7 RID: 1479
	[StructLayout(LayoutKind.Explicit)]
	internal struct GameControllerButtonBind
	{
		// Token: 0x0400550E RID: 21774
		[FieldOffset(0)]
		public GameControllerBindType BindType;

		// Token: 0x0400550F RID: 21775
		[FieldOffset(4)]
		public Button Button;

		// Token: 0x04005510 RID: 21776
		[FieldOffset(4)]
		public GameControllerAxis Axis;

		// Token: 0x04005511 RID: 21777
		[FieldOffset(4)]
		public int Hat;

		// Token: 0x04005512 RID: 21778
		[FieldOffset(8)]
		public int HatMask;
	}
}
