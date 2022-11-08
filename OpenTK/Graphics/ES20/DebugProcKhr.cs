using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000510 RID: 1296
	// (Invoke) Token: 0x06003D1C RID: 15644
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcKhr(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
