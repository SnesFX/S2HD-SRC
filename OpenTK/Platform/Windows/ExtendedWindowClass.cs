using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200008E RID: 142
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct ExtendedWindowClass
	{
		// Token: 0x04000376 RID: 886
		public uint Size;

		// Token: 0x04000377 RID: 887
		public ClassStyle Style;

		// Token: 0x04000378 RID: 888
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WindowProcedure WndProc;

		// Token: 0x04000379 RID: 889
		public int cbClsExtra;

		// Token: 0x0400037A RID: 890
		public int cbWndExtra;

		// Token: 0x0400037B RID: 891
		public IntPtr Instance;

		// Token: 0x0400037C RID: 892
		public IntPtr Icon;

		// Token: 0x0400037D RID: 893
		public IntPtr Cursor;

		// Token: 0x0400037E RID: 894
		public IntPtr Background;

		// Token: 0x0400037F RID: 895
		public IntPtr MenuName;

		// Token: 0x04000380 RID: 896
		public IntPtr ClassName;

		// Token: 0x04000381 RID: 897
		public IntPtr IconSm;

		// Token: 0x04000382 RID: 898
		public static uint SizeInBytes = (uint)Marshal.SizeOf(default(ExtendedWindowClass));
	}
}
