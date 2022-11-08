using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C2 RID: 1474
	internal struct ControllerButtonEvent
	{
		// Token: 0x040054ED RID: 21741
		public EventType Type;

		// Token: 0x040054EE RID: 21742
		public uint Timestamp;

		// Token: 0x040054EF RID: 21743
		public int Which;

		// Token: 0x040054F0 RID: 21744
		public GameControllerButton Button;

		// Token: 0x040054F1 RID: 21745
		public State State;

		// Token: 0x040054F2 RID: 21746
		private byte padding1;

		// Token: 0x040054F3 RID: 21747
		private byte padding2;
	}
}
