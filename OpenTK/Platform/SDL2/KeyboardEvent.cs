using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005CF RID: 1487
	internal struct KeyboardEvent
	{
		// Token: 0x04005538 RID: 21816
		public EventType Type;

		// Token: 0x04005539 RID: 21817
		public uint Timestamp;

		// Token: 0x0400553A RID: 21818
		public uint WindowID;

		// Token: 0x0400553B RID: 21819
		public State State;

		// Token: 0x0400553C RID: 21820
		public byte Repeat;

		// Token: 0x0400553D RID: 21821
		private byte padding2;

		// Token: 0x0400553E RID: 21822
		private byte padding3;

		// Token: 0x0400553F RID: 21823
		public Keysym Keysym;
	}
}
