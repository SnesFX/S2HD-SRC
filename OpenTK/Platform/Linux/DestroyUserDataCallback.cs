using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B74 RID: 2932
	// (Invoke) Token: 0x06005BAA RID: 23466
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void DestroyUserDataCallback(BufferObject bo, IntPtr data);
}
