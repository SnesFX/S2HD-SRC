using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std
{
	// Token: 0x020001A1 RID: 417
	[NativeCppClass]
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	internal struct exception_ptr
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x000012E8 File Offset: 0x000006E8
		public unsafe static void <MarshalCopy>(exception_ptr* A_0, exception_ptr* A_1)
		{
			<Module>.__ExceptionPtrCopy((void*)A_0, (void*)A_1);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000012FC File Offset: 0x000006FC
		public unsafe static void <MarshalDestroy>(exception_ptr* A_0)
		{
			<Module>.__ExceptionPtrDestroy((void*)A_0);
		}

		// Token: 0x04000283 RID: 643
		private long <alignment\u0020member>;
	}
}
