using System;
using System.Runtime.InteropServices;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004CC RID: 1228
	// (Invoke) Token: 0x06003079 RID: 12409
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DebugProcAmd(int id, AmdDebugOutput category, AmdDebugOutput severity, int length, IntPtr message, IntPtr userParam);
}
