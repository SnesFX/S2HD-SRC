using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C9 RID: 1481
	internal struct JoyBallEvent
	{
		// Token: 0x0400551C RID: 21788
		public EventType Type;

		// Token: 0x0400551D RID: 21789
		public uint Timestamp;

		// Token: 0x0400551E RID: 21790
		public int Which;

		// Token: 0x0400551F RID: 21791
		public byte Ball;

		// Token: 0x04005520 RID: 21792
		private byte padding1;

		// Token: 0x04005521 RID: 21793
		private byte padding2;

		// Token: 0x04005522 RID: 21794
		private byte padding3;

		// Token: 0x04005523 RID: 21795
		public short Xrel;

		// Token: 0x04005524 RID: 21796
		public short Yrel;
	}
}
