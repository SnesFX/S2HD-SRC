using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000CF RID: 207
	// (Invoke) Token: 0x06000842 RID: 2114
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[SuppressUnmanagedCodeSecurity]
	internal delegate IntPtr WindowProcedure(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam);
}
