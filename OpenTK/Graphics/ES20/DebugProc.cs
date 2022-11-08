using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x0200050F RID: 1295
	// (Invoke) Token: 0x06003D18 RID: 15640
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProc(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
