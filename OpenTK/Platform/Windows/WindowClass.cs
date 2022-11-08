using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200008D RID: 141
	internal struct WindowClass
	{
		// Token: 0x0400036B RID: 875
		internal ClassStyle Style;

		// Token: 0x0400036C RID: 876
		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal WindowProcedure WindowProcedure;

		// Token: 0x0400036D RID: 877
		internal int ClassExtraBytes;

		// Token: 0x0400036E RID: 878
		internal int WindowExtraBytes;

		// Token: 0x0400036F RID: 879
		internal IntPtr Instance;

		// Token: 0x04000370 RID: 880
		internal IntPtr Icon;

		// Token: 0x04000371 RID: 881
		internal IntPtr Cursor;

		// Token: 0x04000372 RID: 882
		internal IntPtr BackgroundBrush;

		// Token: 0x04000373 RID: 883
		internal IntPtr MenuName;

		// Token: 0x04000374 RID: 884
		[MarshalAs(UnmanagedType.LPTStr)]
		internal string ClassName;

		// Token: 0x04000375 RID: 885
		internal static int SizeInBytes = Marshal.SizeOf(default(WindowClass));
	}
}
