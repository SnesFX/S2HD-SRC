using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005D1 RID: 1489
	internal struct MouseButtonEvent
	{
		// Token: 0x04005544 RID: 21828
		public EventType Type;

		// Token: 0x04005545 RID: 21829
		public uint Timestamp;

		// Token: 0x04005546 RID: 21830
		public uint WindowID;

		// Token: 0x04005547 RID: 21831
		public uint Which;

		// Token: 0x04005548 RID: 21832
		public Button Button;

		// Token: 0x04005549 RID: 21833
		public State State;

		// Token: 0x0400554A RID: 21834
		public byte Clicks;

		// Token: 0x0400554B RID: 21835
		private byte padding1;

		// Token: 0x0400554C RID: 21836
		public int X;

		// Token: 0x0400554D RID: 21837
		public int Y;
	}
}
