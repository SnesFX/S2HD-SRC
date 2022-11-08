using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C8 RID: 1480
	internal struct JoyAxisEvent
	{
		// Token: 0x04005513 RID: 21779
		public EventType Type;

		// Token: 0x04005514 RID: 21780
		public uint Timestamp;

		// Token: 0x04005515 RID: 21781
		public int Which;

		// Token: 0x04005516 RID: 21782
		public byte Axis;

		// Token: 0x04005517 RID: 21783
		private byte padding1;

		// Token: 0x04005518 RID: 21784
		private byte padding2;

		// Token: 0x04005519 RID: 21785
		private byte padding3;

		// Token: 0x0400551A RID: 21786
		public short Value;

		// Token: 0x0400551B RID: 21787
		private ushort padding4;
	}
}
