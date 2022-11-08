using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004CD RID: 1229
	// (Invoke) Token: 0x0600307D RID: 12413
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcArb(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
