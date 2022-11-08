using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005DE RID: 1502
	internal struct TextEditingEvent
	{
		// Token: 0x0400557D RID: 21885
		public const int TextSize = 32;

		// Token: 0x0400557E RID: 21886
		public EventType Type;

		// Token: 0x0400557F RID: 21887
		public uint Timestamp;

		// Token: 0x04005580 RID: 21888
		public uint WindowID;

		// Token: 0x04005581 RID: 21889
		[FixedBuffer(typeof(byte), 32)]
		public TextEditingEvent.<Text>e__FixedBuffer4 Text;

		// Token: 0x04005582 RID: 21890
		public int Start;

		// Token: 0x04005583 RID: 21891
		public int Length;

		// Token: 0x020005DF RID: 1503
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <Text>e__FixedBuffer4
		{
			// Token: 0x04005584 RID: 21892
			public byte FixedElementField;
		}
	}
}
