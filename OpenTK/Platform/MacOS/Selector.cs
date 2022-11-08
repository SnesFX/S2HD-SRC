using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B1F RID: 2847
	internal static class Selector
	{
		// Token: 0x06005A7C RID: 23164
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_registerName")]
		public static extern IntPtr Get(string name);

		// Token: 0x0400B54E RID: 46414
		public static readonly IntPtr Init = Selector.Get("init");

		// Token: 0x0400B54F RID: 46415
		public static readonly IntPtr InitWithCoder = Selector.Get("initWithCoder:");

		// Token: 0x0400B550 RID: 46416
		public static readonly IntPtr Alloc = Selector.Get("alloc");

		// Token: 0x0400B551 RID: 46417
		public static readonly IntPtr Retain = Selector.Get("retain");

		// Token: 0x0400B552 RID: 46418
		public static readonly IntPtr Release = Selector.Get("release");

		// Token: 0x0400B553 RID: 46419
		public static readonly IntPtr Autorelease = Selector.Get("autorelease");
	}
}
