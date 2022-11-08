using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000D0 RID: 208
	[CLSCompliant(false)]
	internal struct MSG
	{
		// Token: 0x06000845 RID: 2117 RVA: 0x0001AC68 File Offset: 0x00018E68
		public override string ToString()
		{
			return string.Format("msg=0x{0:x} ({1}) hwnd=0x{2:x} wparam=0x{3:x} lparam=0x{4:x} pt=0x{5:x}", new object[]
			{
				(int)this.Message,
				this.Message.ToString(),
				this.HWnd.ToInt32(),
				this.WParam.ToInt32(),
				this.LParam.ToInt32(),
				this.Point
			});
		}

		// Token: 0x040006D7 RID: 1751
		internal IntPtr HWnd;

		// Token: 0x040006D8 RID: 1752
		internal WindowMessage Message;

		// Token: 0x040006D9 RID: 1753
		internal IntPtr WParam;

		// Token: 0x040006DA RID: 1754
		internal IntPtr LParam;

		// Token: 0x040006DB RID: 1755
		internal uint Time;

		// Token: 0x040006DC RID: 1756
		internal POINT Point;
	}
}
