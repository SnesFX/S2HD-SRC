using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005CC RID: 1484
	internal struct JoyHatEvent
	{
		// Token: 0x0400552F RID: 21807
		public EventType Type;

		// Token: 0x04005530 RID: 21808
		public uint Timestamp;

		// Token: 0x04005531 RID: 21809
		public int Which;

		// Token: 0x04005532 RID: 21810
		public byte Hat;

		// Token: 0x04005533 RID: 21811
		public HatPosition Value;

		// Token: 0x04005534 RID: 21812
		private byte padding1;

		// Token: 0x04005535 RID: 21813
		private byte padding2;
	}
}
