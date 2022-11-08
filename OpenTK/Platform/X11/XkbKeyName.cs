using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B55 RID: 2901
	internal struct XkbKeyName
	{
		// Token: 0x0400B771 RID: 46961
		[FixedBuffer(typeof(byte), 4)]
		internal XkbKeyName.<name>e__FixedBuffer8 name;

		// Token: 0x02000B56 RID: 2902
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 4)]
		public struct <name>e__FixedBuffer8
		{
			// Token: 0x0400B772 RID: 46962
			public byte FixedElementField;
		}
	}
}
