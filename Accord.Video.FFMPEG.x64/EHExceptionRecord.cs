using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x020002DF RID: 735
[NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 64)]
internal struct EHExceptionRecord
{
	// Token: 0x0400038E RID: 910
	private long <alignment\u0020member>;

	// Token: 0x020002E0 RID: 736
	[CLSCompliant(false)]
	[NativeCppClass]
	[StructLayout(LayoutKind.Sequential, Size = 32)]
	public struct EHParameters
	{
		// Token: 0x0400038F RID: 911
		private long <alignment\u0020member>;
	}
}
