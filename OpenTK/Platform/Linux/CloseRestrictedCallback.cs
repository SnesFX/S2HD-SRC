using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B8D RID: 2957
	// (Invoke) Token: 0x06005C20 RID: 23584
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void CloseRestrictedCallback(int fd, IntPtr data);
}
