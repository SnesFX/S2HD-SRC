using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005D2 RID: 1490
	internal struct MouseMotionEvent
	{
		// Token: 0x0400554E RID: 21838
		public EventType Type;

		// Token: 0x0400554F RID: 21839
		public uint Timestamp;

		// Token: 0x04005550 RID: 21840
		public uint WindowID;

		// Token: 0x04005551 RID: 21841
		public uint Which;

		// Token: 0x04005552 RID: 21842
		public ButtonFlags State;

		// Token: 0x04005553 RID: 21843
		public int X;

		// Token: 0x04005554 RID: 21844
		public int Y;

		// Token: 0x04005555 RID: 21845
		public int Xrel;

		// Token: 0x04005556 RID: 21846
		public int Yrel;
	}
}
