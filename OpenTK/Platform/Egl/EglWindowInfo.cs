using System;
using OpenTK.Graphics;

namespace OpenTK.Platform.Egl
{
	// Token: 0x02000071 RID: 113
	internal class EglWindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x06000737 RID: 1847 RVA: 0x000188D8 File Offset: 0x00016AD8
		public EglWindowInfo(IntPtr handle, IntPtr display) : this(handle, display, IntPtr.Zero)
		{
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000188E8 File Offset: 0x00016AE8
		public EglWindowInfo(IntPtr handle, IntPtr display, IntPtr surface)
		{
			this.Handle = handle;
			this.Surface = surface;
			if (display == IntPtr.Zero)
			{
				display = Egl.GetDisplay(IntPtr.Zero);
			}
			this.Display = display;
			int num;
			int num2;
			if (!Egl.Initialize(this.Display, out num, out num2))
			{
				throw new GraphicsContextException(string.Format("Failed to initialize EGL, error {0}.", Egl.GetError()));
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x00018954 File Offset: 0x00016B54
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x0001895C File Offset: 0x00016B5C
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

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x00018968 File Offset: 0x00016B68
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x00018970 File Offset: 0x00016B70
		public IntPtr Display
		{
			get
			{
				return this.display;
			}
			private set
			{
				this.display = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x0001897C File Offset: 0x00016B7C
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x00018984 File Offset: 0x00016B84
		public IntPtr Surface
		{
			get
			{
				return this.surface;
			}
			private set
			{
				this.surface = value;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00018990 File Offset: 0x00016B90
		public void CreateWindowSurface(IntPtr config)
		{
			this.Surface = Egl.CreateWindowSurface(this.Display, config, this.Handle, IntPtr.Zero);
			if (this.Surface == IntPtr.Zero)
			{
				throw new GraphicsContextException(string.Format("[EGL] Failed to create window surface, error {0}.", Egl.GetError()));
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x000189E8 File Offset: 0x00016BE8
		public void DestroySurface()
		{
			if (this.Surface != IntPtr.Zero)
			{
				Egl.DestroySurface(this.Display, this.Surface);
			}
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00018A10 File Offset: 0x00016C10
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00018A20 File Offset: 0x00016C20
		private void Dispose(bool manual)
		{
			if (!this.disposed && manual)
			{
				this.DestroySurface();
				this.disposed = true;
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00018A3C File Offset: 0x00016C3C
		~EglWindowInfo()
		{
			this.Dispose(false);
		}

		// Token: 0x040001D7 RID: 471
		private IntPtr handle;

		// Token: 0x040001D8 RID: 472
		private IntPtr display;

		// Token: 0x040001D9 RID: 473
		private IntPtr surface;

		// Token: 0x040001DA RID: 474
		private bool disposed;
	}
}
