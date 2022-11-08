using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020005F3 RID: 1523
	// (Invoke) Token: 0x06004FFF RID: 20479
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProc(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
