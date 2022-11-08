using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B52 RID: 2898
	internal struct XkbKeyAlias
	{
		// Token: 0x0400B76D RID: 46957
		[FixedBuffer(typeof(byte), 4)]
		internal XkbKeyAlias.<real>e__FixedBuffer6 real;

		// Token: 0x0400B76E RID: 46958
		[FixedBuffer(typeof(byte), 4)]
		internal XkbKeyAlias.<alias>e__FixedBuffer7 alias;

		// Token: 0x02000B53 RID: 2899
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 4)]
		public struct <real>e__FixedBuffer6
		{
			// Token: 0x0400B76F RID: 46959
			public byte FixedElementField;
		}

		// Token: 0x02000B54 RID: 2900
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 4)]
		public struct <alias>e__FixedBuffer7
		{
			// Token: 0x0400B770 RID: 46960
			public byte FixedElementField;
		}
	}
}
