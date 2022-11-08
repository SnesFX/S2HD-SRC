using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020005F4 RID: 1524
	// (Invoke) Token: 0x06005003 RID: 20483
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcKhr(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
