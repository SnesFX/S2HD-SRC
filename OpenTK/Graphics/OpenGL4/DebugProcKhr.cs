using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020005FA RID: 1530
	// (Invoke) Token: 0x06005906 RID: 22790
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcKhr(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
