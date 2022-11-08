using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B65 RID: 2917
	// (Invoke) Token: 0x06005B64 RID: 23396
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void VBlankCallback(int fd, int sequence, int tv_sec, int tv_usec, IntPtr user_data);
}
