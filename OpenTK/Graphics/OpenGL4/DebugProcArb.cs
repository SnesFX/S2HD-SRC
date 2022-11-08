using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020005F9 RID: 1529
	// (Invoke) Token: 0x06005902 RID: 22786
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcArb(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
