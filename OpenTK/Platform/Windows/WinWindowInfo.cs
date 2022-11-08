using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000D6 RID: 214
	internal sealed class WinWindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x0001E058 File Offset: 0x0001C258
		public WinWindowInfo()
		{
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0001E060 File Offset: 0x0001C260
		public WinWindowInfo(IntPtr handle, WinWindowInfo parent)
		{
			this.handle = handle;
			this.parent = parent;
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0001E078 File Offset: 0x0001C278
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x0001E080 File Offset: 0x0001C280
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
			set
			{
				this.handle = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0001E08C File Offset: 0x0001C28C
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x0001E094 File Offset: 0x0001C294
		public WinWindowInfo Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0001E0A0 File Offset: 0x0001C2A0
		public IntPtr DeviceContext
		{
			get
			{
				if (this.dc == IntPtr.Zero)
				{
					this.dc = Functions.GetDC(this.Handle);
				}
				return this.dc;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x0001E0CC File Offset: 0x0001C2CC
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x0001E0D4 File Offset: 0x0001C2D4
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

		// Token: 0x0600091B RID: 2331 RVA: 0x0001E0E0 File Offset: 0x0001C2E0
		public override string ToString()
		{
			return string.Format("Windows.WindowInfo: Handle {0}, Parent ({1})", this.Handle, (this.Parent != null) ? this.Parent.ToString() : "null");
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0001E114 File Offset: 0x0001C314
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.GetType() != obj.GetType())
			{
				return false;
			}
			WinWindowInfo winWindowInfo = (WinWindowInfo)obj;
			return winWindowInfo != null && this.handle.Equals(winWindowInfo.handle);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0001E160 File Offset: 0x0001C360
		public override int GetHashCode()
		{
			return this.handle.GetHashCode();
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0001E174 File Offset: 0x0001C374
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0001E184 File Offset: 0x0001C384
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (this.dc != IntPtr.Zero)
				{
					Functions.ReleaseDC(this.handle, this.dc);
				}
				if (manual && this.parent != null)
				{
					this.parent.Dispose();
				}
				this.disposed = true;
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0001E1DC File Offset: 0x0001C3DC
		~WinWindowInfo()
		{
			this.Dispose(false);
		}

		// Token: 0x0400073E RID: 1854
		private IntPtr handle;

		// Token: 0x0400073F RID: 1855
		private IntPtr dc;

		// Token: 0x04000740 RID: 1856
		private WinWindowInfo parent;

		// Token: 0x04000741 RID: 1857
		private bool disposed;
	}
}
