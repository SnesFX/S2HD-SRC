using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B8C RID: 2956
	// (Invoke) Token: 0x06005C1C RID: 23580
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int OpenRestrictedCallback(IntPtr path, int flags, IntPtr data);
}
