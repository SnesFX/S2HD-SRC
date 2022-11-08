using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005D3 RID: 1491
	internal struct MouseWheelEvent
	{
		// Token: 0x04005557 RID: 21847
		public const uint TouchMouseID = 4294967295U;

		// Token: 0x04005558 RID: 21848
		public MouseWheelEvent.EventType Type;

		// Token: 0x04005559 RID: 21849
		public uint Timestamp;

		// Token: 0x0400555A RID: 21850
		public uint WindowID;

		// Token: 0x0400555B RID: 21851
		public uint Which;

		// Token: 0x0400555C RID: 21852
		public int X;

		// Token: 0x0400555D RID: 21853
		public int Y;

		// Token: 0x020005D4 RID: 1492
		public enum EventType : uint
		{
			// Token: 0x0400555F RID: 21855
			FingerDown = 1792U,
			// Token: 0x04005560 RID: 21856
			FingerUp,
			// Token: 0x04005561 RID: 21857
			FingerMotion,
			// Token: 0x04005562 RID: 21858
			DollarGesture = 2048U,
			// Token: 0x04005563 RID: 21859
			DollarRecord,
			// Token: 0x04005564 RID: 21860
			MultiGesture
		}
	}
}
