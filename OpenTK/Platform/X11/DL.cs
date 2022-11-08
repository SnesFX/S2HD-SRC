using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000043 RID: 67
	internal class DL
	{
		// Token: 0x060004E7 RID: 1255
		[DllImport("dl", EntryPoint = "dlopen")]
		internal static extern IntPtr Open(string filename, DLOpenFlags flags);

		// Token: 0x060004E8 RID: 1256
		[DllImport("dl", EntryPoint = "dlclose")]
		internal static extern int Close(IntPtr handle);

		// Token: 0x060004E9 RID: 1257
		[DllImport("dl", EntryPoint = "dlsym")]
		internal static extern IntPtr Symbol(IntPtr handle, IntPtr name);

		// Token: 0x04000115 RID: 277
		private const string lib = "dl";
	}
}
