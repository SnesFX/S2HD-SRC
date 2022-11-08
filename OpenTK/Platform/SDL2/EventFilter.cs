using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005AC RID: 1452
	// (Invoke) Token: 0x060046DB RID: 18139
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int EventFilter(IntPtr userdata, IntPtr @event);
}
