using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B66 RID: 2918
	// (Invoke) Token: 0x06005B68 RID: 23400
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PageFlipCallback(int fd, int sequence, int tv_sec, int tv_usec, IntPtr user_data);
}
