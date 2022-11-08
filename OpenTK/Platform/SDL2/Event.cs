using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005C5 RID: 1477
	[StructLayout(LayoutKind.Explicit)]
	internal struct Event
	{
		// Token: 0x040054FC RID: 21756
		[FieldOffset(0)]
		public EventType Type;

		// Token: 0x040054FD RID: 21757
		[FieldOffset(0)]
		public WindowEvent Window;

		// Token: 0x040054FE RID: 21758
		[FieldOffset(0)]
		public KeyboardEvent Key;

		// Token: 0x040054FF RID: 21759
		[FieldOffset(0)]
		public TextEditingEvent Edit;

		// Token: 0x04005500 RID: 21760
		[FieldOffset(0)]
		public TextInputEvent Text;

		// Token: 0x04005501 RID: 21761
		[FieldOffset(0)]
		public MouseMotionEvent Motion;

		// Token: 0x04005502 RID: 21762
		[FieldOffset(0)]
		public MouseButtonEvent Button;

		// Token: 0x04005503 RID: 21763
		[FieldOffset(0)]
		public MouseWheelEvent Wheel;

		// Token: 0x04005504 RID: 21764
		[FieldOffset(0)]
		public JoyAxisEvent JoyAxis;

		// Token: 0x04005505 RID: 21765
		[FieldOffset(0)]
		public JoyBallEvent JoyBall;

		// Token: 0x04005506 RID: 21766
		[FieldOffset(0)]
		public JoyHatEvent JoyHat;

		// Token: 0x04005507 RID: 21767
		[FieldOffset(0)]
		public JoyButtonEvent JoyButton;

		// Token: 0x04005508 RID: 21768
		[FieldOffset(0)]
		public JoyDeviceEvent JoyDevice;

		// Token: 0x04005509 RID: 21769
		[FieldOffset(0)]
		public ControllerAxisEvent ControllerAxis;

		// Token: 0x0400550A RID: 21770
		[FieldOffset(0)]
		public ControllerButtonEvent ControllerButton;

		// Token: 0x0400550B RID: 21771
		[FieldOffset(0)]
		public ControllerDeviceEvent ControllerDevice;

		// Token: 0x0400550C RID: 21772
		[FixedBuffer(typeof(byte), 128)]
		[FieldOffset(0)]
		private Event.<reserved>e__FixedBuffer2 reserved;

		// Token: 0x020005C6 RID: 1478
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <reserved>e__FixedBuffer2
		{
			// Token: 0x0400550D RID: 21773
			public byte FixedElementField;
		}
	}
}
