using System;

namespace OpenTK.Platform.Dummy
{
	// Token: 0x0200006A RID: 106
	internal class DummyWindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x060006FF RID: 1791 RVA: 0x0001811C File Offset: 0x0001631C
		public void Dispose()
		{
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x00018120 File Offset: 0x00016320
		public IntPtr Handle
		{
			get
			{
				return IntPtr.Zero;
			}
		}
	}
}
