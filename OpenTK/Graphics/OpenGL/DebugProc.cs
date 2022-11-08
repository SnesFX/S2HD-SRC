using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004CE RID: 1230
	// (Invoke) Token: 0x06003081 RID: 12417
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProc(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
}
