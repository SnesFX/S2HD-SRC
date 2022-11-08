using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B95 RID: 2965
	[StructLayout(LayoutKind.Sequential)]
	internal class InputInterface
	{
		// Token: 0x06005C40 RID: 23616 RVA: 0x000F9F84 File Offset: 0x000F8184
		public InputInterface(OpenRestrictedCallback open_restricted, CloseRestrictedCallback close_restricted)
		{
			if (open_restricted == null || close_restricted == null)
			{
				throw new ArgumentNullException();
			}
			this.open = Marshal.GetFunctionPointerForDelegate(open_restricted);
			this.close = Marshal.GetFunctionPointerForDelegate(close_restricted);
		}

		// Token: 0x0400B8FB RID: 47355
		internal readonly IntPtr open;

		// Token: 0x0400B8FC RID: 47356
		internal readonly IntPtr close;
	}
}
