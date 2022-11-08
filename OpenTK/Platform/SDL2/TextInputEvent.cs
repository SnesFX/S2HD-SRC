using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005E0 RID: 1504
	internal struct TextInputEvent
	{
		// Token: 0x04005585 RID: 21893
		public const int TextSize = 32;

		// Token: 0x04005586 RID: 21894
		public EventType Type;

		// Token: 0x04005587 RID: 21895
		public uint Timestamp;

		// Token: 0x04005588 RID: 21896
		public uint WindowID;

		// Token: 0x04005589 RID: 21897
		[FixedBuffer(typeof(byte), 32)]
		public TextInputEvent.<Text>e__FixedBuffer5 Text;

		// Token: 0x020005E1 RID: 1505
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <Text>e__FixedBuffer5
		{
			// Token: 0x0400558A RID: 21898
			public byte FixedElementField;
		}
	}
}
