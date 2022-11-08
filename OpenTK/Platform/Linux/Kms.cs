using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000BA8 RID: 2984
	internal class Kms
	{
		// Token: 0x06005CA1 RID: 23713
		[DllImport("libkms", CallingConvention = CallingConvention.Cdecl, EntryPoint = "kms_bo_map")]
		public static extern int MapBuffer(IntPtr bo, out IntPtr @out);

		// Token: 0x06005CA2 RID: 23714
		[DllImport("libkms", CallingConvention = CallingConvention.Cdecl, EntryPoint = "kms_bo_unmap")]
		public static extern int UnmapBuffer(IntPtr bo);

		// Token: 0x0400B9C2 RID: 47554
		private const string lib = "libkms";
	}
}
