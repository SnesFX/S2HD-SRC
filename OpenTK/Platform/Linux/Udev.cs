using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B8B RID: 2955
	internal class Udev
	{
		// Token: 0x06005C18 RID: 23576
		[DllImport("libudev", CallingConvention = CallingConvention.Cdecl, EntryPoint = "udev_new")]
		public static extern IntPtr New();

		// Token: 0x06005C19 RID: 23577
		[DllImport("libudev", CallingConvention = CallingConvention.Cdecl, EntryPoint = "udev_destroy")]
		public static extern void Destroy(IntPtr Udev);

		// Token: 0x0400B8DD RID: 47325
		private const string lib = "libudev";
	}
}
