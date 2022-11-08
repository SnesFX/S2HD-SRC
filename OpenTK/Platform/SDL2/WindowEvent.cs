using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005E3 RID: 1507
	internal struct WindowEvent
	{
		// Token: 0x0400558E RID: 21902
		public EventType Type;

		// Token: 0x0400558F RID: 21903
		public uint Timestamp;

		// Token: 0x04005590 RID: 21904
		public uint WindowID;

		// Token: 0x04005591 RID: 21905
		public WindowEventID Event;

		// Token: 0x04005592 RID: 21906
		private byte padding1;

		// Token: 0x04005593 RID: 21907
		private byte padding2;

		// Token: 0x04005594 RID: 21908
		private byte padding3;

		// Token: 0x04005595 RID: 21909
		public int Data1;

		// Token: 0x04005596 RID: 21910
		public int Data2;
	}
}
