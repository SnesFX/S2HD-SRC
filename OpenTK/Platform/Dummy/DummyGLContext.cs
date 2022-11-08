using System;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Graphics.ES20;
using OpenTK.Graphics.ES30;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Platform.Dummy
{
	// Token: 0x0200006B RID: 107
	internal sealed class DummyGLContext : DesktopGraphicsContext
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x00018130 File Offset: 0x00016330
		public DummyGLContext()
		{
			this.Handle = new ContextHandle(new IntPtr(Interlocked.Increment(ref DummyGLContext.handle_count)));
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00018154 File Offset: 0x00016354
		public DummyGLContext(ContextHandle handle, GraphicsContext.GetAddressDelegate loader) : this()
		{
			if (handle != ContextHandle.Zero)
			{
				this.Handle = handle;
			}
			this.Loader = loader;
			this.Mode = new GraphicsMode(new IntPtr?(new IntPtr(2)), 32, 16, 0, 0, 0, 2, false);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x000181AC File Offset: 0x000163AC
		public override void SwapBuffers()
		{
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x000181B0 File Offset: 0x000163B0
		public override void MakeCurrent(IWindowInfo info)
		{
			Thread currentThread = Thread.CurrentThread;
			if (this.current_thread != null && currentThread != this.current_thread)
			{
				throw new GraphicsContextException("Cannot make context current on two threads at the same time");
			}
			if (info != null)
			{
				this.current_thread = Thread.CurrentThread;
				return;
			}
			this.current_thread = null;
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x000181F8 File Offset: 0x000163F8
		public override bool IsCurrent
		{
			get
			{
				return this.current_thread != null && this.current_thread == Thread.CurrentThread;
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00018214 File Offset: 0x00016414
		public override IntPtr GetAddress(IntPtr function)
		{
			string function2 = Marshal.PtrToStringAnsi(function);
			return this.Loader(function2);
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x00018234 File Offset: 0x00016434
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x0001823C File Offset: 0x0001643C
		public override int SwapInterval
		{
			get
			{
				return this.swap_interval;
			}
			set
			{
				this.swap_interval = value;
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00018248 File Offset: 0x00016448
		public override void Update(IWindowInfo window)
		{
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0001824C File Offset: 0x0001644C
		public override void LoadAll()
		{
			new OpenTK.Graphics.OpenGL.GL().LoadEntryPoints();
			new OpenTK.Graphics.OpenGL4.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES11.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES20.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES30.GL().LoadEntryPoints();
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00018280 File Offset: 0x00016480
		public override void Dispose()
		{
			base.IsDisposed = true;
		}

		// Token: 0x040001CA RID: 458
		private readonly GraphicsContext.GetAddressDelegate Loader;

		// Token: 0x040001CB RID: 459
		private int swap_interval;

		// Token: 0x040001CC RID: 460
		private static int handle_count;

		// Token: 0x040001CD RID: 461
		private Thread current_thread;
	}
}
