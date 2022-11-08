using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B6F RID: 2927
	internal struct ModeInfo
	{
		// Token: 0x0400B813 RID: 47123
		public uint clock;

		// Token: 0x0400B814 RID: 47124
		public ushort hdisplay;

		// Token: 0x0400B815 RID: 47125
		public ushort hsync_start;

		// Token: 0x0400B816 RID: 47126
		public ushort hsync_end;

		// Token: 0x0400B817 RID: 47127
		public ushort htotal;

		// Token: 0x0400B818 RID: 47128
		public ushort hskew;

		// Token: 0x0400B819 RID: 47129
		public ushort vdisplay;

		// Token: 0x0400B81A RID: 47130
		public ushort vsync_start;

		// Token: 0x0400B81B RID: 47131
		public ushort vsync_end;

		// Token: 0x0400B81C RID: 47132
		public ushort vtotal;

		// Token: 0x0400B81D RID: 47133
		public ushort vscan;

		// Token: 0x0400B81E RID: 47134
		public int vrefresh;

		// Token: 0x0400B81F RID: 47135
		public uint flags;

		// Token: 0x0400B820 RID: 47136
		public uint type;

		// Token: 0x0400B821 RID: 47137
		[FixedBuffer(typeof(sbyte), 32)]
		public ModeInfo.<name>e__FixedBuffer9 name;

		// Token: 0x02000B70 RID: 2928
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <name>e__FixedBuffer9
		{
			// Token: 0x0400B822 RID: 47138
			public sbyte FixedElementField;
		}
	}
}
