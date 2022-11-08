using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020005F8 RID: 1528
	// (Invoke) Token: 0x060058FE RID: 22782
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProc(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
