using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C1 RID: 1473
	internal struct ControllerAxisEvent
	{
		// Token: 0x040054E4 RID: 21732
		public EventType Type;

		// Token: 0x040054E5 RID: 21733
		public uint Timestamp;

		// Token: 0x040054E6 RID: 21734
		public int Which;

		// Token: 0x040054E7 RID: 21735
		public GameControllerAxis Axis;

		// Token: 0x040054E8 RID: 21736
		private byte padding1;

		// Token: 0x040054E9 RID: 21737
		private byte padding2;

		// Token: 0x040054EA RID: 21738
		private byte padding3;

		// Token: 0x040054EB RID: 21739
		public short Value;

		// Token: 0x040054EC RID: 21740
		private ushort padding4;
	}
}
