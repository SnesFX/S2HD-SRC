using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004CF RID: 1231
	// (Invoke) Token: 0x06003085 RID: 12421
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcKhr(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
