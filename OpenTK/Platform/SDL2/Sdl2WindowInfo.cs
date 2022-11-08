using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A9 RID: 1449
	internal class Sdl2WindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x0600466C RID: 18028 RVA: 0x000C32D8 File Offset: 0x000C14D8
		// (set) Token: 0x0600466D RID: 18029 RVA: 0x000C32E0 File Offset: 0x000C14E0
		public IntPtr Handle { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x0600466E RID: 18030 RVA: 0x000C32EC File Offset: 0x000C14EC
		// (set) Token: 0x0600466F RID: 18031 RVA: 0x000C32F4 File Offset: 0x000C14F4
		public Sdl2WindowInfo Parent { get; set; }

		// Token: 0x06004670 RID: 18032 RVA: 0x000C3300 File Offset: 0x000C1500
		public Sdl2WindowInfo()
		{
		}

		// Token: 0x06004671 RID: 18033 RVA: 0x000C3308 File Offset: 0x000C1508
		public Sdl2WindowInfo(IntPtr handle, Sdl2WindowInfo parent)
		{
			this.Handle = handle;
			this.Parent = parent;
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x000C3320 File Offset: 0x000C1520
		// (set) Token: 0x06004673 RID: 18035 RVA: 0x000C3328 File Offset: 0x000C1528
		public IntPtr WindowHandle
		{
			get
			{
				return this.Handle;
			}
			set
			{
				this.Handle = value;
			}
		}

		// Token: 0x06004674 RID: 18036 RVA: 0x000C3334 File Offset: 0x000C1534
		public void Dispose()
		{
		}
	}
}
