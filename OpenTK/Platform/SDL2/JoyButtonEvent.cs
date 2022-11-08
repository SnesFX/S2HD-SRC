using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005CA RID: 1482
	internal struct JoyButtonEvent
	{
		// Token: 0x04005525 RID: 21797
		public EventType Type;

		// Token: 0x04005526 RID: 21798
		public uint Timestamp;

		// Token: 0x04005527 RID: 21799
		public int Which;

		// Token: 0x04005528 RID: 21800
		public byte Button;

		// Token: 0x04005529 RID: 21801
		public State State;

		// Token: 0x0400552A RID: 21802
		private byte padding1;

		// Token: 0x0400552B RID: 21803
		private byte padding2;
	}
}
