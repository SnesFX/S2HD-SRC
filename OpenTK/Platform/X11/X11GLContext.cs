using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Graphics;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000134 RID: 308
	internal sealed class X11GLContext : DesktopGraphicsContext
	{
		// Token: 0x06000AF4 RID: 2804 RVA: 0x00025440 File Offset: 0x00023640
		static X11GLContext()
		{
			new Glx().LoadEntryPoints();
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0002544C File Offset: 0x0002364C
		public unsafe X11GLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shared, bool direct, int major, int minor, GraphicsContextFlags flags)
		{
			if (mode == null)
			{
				throw new ArgumentNullException("mode");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.Display = ((X11WindowInfo)window).Display;
			using (new XLock(this.Display))
			{
				int num;
				int num2;
				bool flag = Glx.QueryExtension(this.Display, out num, out num2);
				int num3;
				int num4;
				if (!(flag & Glx.QueryVersion(this.Display, out num3, out num4)))
				{
					throw new NotSupportedException("[X11] GLX extension is not supported.");
				}
			}
			this.Mode = this.ModeSelector.SelectGraphicsMode(mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo);
			this.currentWindow = (X11WindowInfo)window;
			this.currentWindow.VisualInfo = this.SelectVisual(this.Mode, this.currentWindow);
			ContextHandle contextHandle = (shared != null) ? (shared as IGraphicsContextInternal).Context : ((ContextHandle)IntPtr.Zero);
			if (major * 10 + minor >= 30 && this.SupportsCreateContextAttribs(this.Display, this.currentWindow))
			{
				IntPtr dpy = this.Display;
				int screen = this.currentWindow.Screen;
				int[] array = new int[3];
				array[0] = 32779;
				array[1] = (int)this.Mode.Index.Value;
				int num5;
				IntPtr* ptr = Glx.ChooseFBConfig(dpy, screen, array, out num5);
				if (num5 > 0)
				{
					List<int> list = new List<int>();
					list.Add(8337);
					list.Add(major);
					list.Add(8338);
					list.Add(minor);
					if (flags != GraphicsContextFlags.Default)
					{
						list.Add(8340);
						list.Add((int)this.GetARBContextFlags(flags));
						list.Add(37158);
						list.Add((int)this.GetARBProfileFlags(flags));
					}
					list.Add(0);
					list.Add(0);
					using (new XLock(this.Display))
					{
						this.Handle = new ContextHandle(Glx.Arb.CreateContextAttribs(this.Display, *ptr, contextHandle.Handle, direct, list.ToArray()));
						if (this.Handle == ContextHandle.Zero)
						{
							this.Handle = new ContextHandle(Glx.Arb.CreateContextAttribs(this.Display, *ptr, contextHandle.Handle, !direct, list.ToArray()));
						}
					}
					this.Handle == ContextHandle.Zero;
					using (new XLock(this.Display))
					{
						Functions.XFree((IntPtr)((void*)ptr));
					}
				}
			}
			if (this.Handle == ContextHandle.Zero)
			{
				XVisualInfo visualInfo = this.currentWindow.VisualInfo;
				using (new XLock(this.Display))
				{
					this.Handle = new ContextHandle(Glx.CreateContext(this.Display, ref visualInfo, contextHandle.Handle, direct));
					if (this.Handle == ContextHandle.Zero)
					{
						this.Handle = new ContextHandle(Glx.CreateContext(this.Display, ref visualInfo, IntPtr.Zero, !direct));
					}
				}
			}
			if (!(this.Handle != ContextHandle.Zero))
			{
				throw new GraphicsContextException("Failed to create OpenGL context. Glx.CreateContext call returned 0.");
			}
			using (new XLock(this.Display))
			{
				Glx.IsDirect(this.Display, this.Handle.Handle);
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0002584C File Offset: 0x00023A4C
		public X11GLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shared, bool direct, int major, int minor, GraphicsContextFlags flags)
		{
			if (handle == ContextHandle.Zero)
			{
				throw new ArgumentException("handle");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.Handle = handle;
			this.currentWindow = (X11WindowInfo)window;
			this.Display = this.currentWindow.Display;
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x000258BC File Offset: 0x00023ABC
		// (set) Token: 0x06000AF8 RID: 2808 RVA: 0x000258C4 File Offset: 0x00023AC4
		private IntPtr Display
		{
			get
			{
				return this.display;
			}
			set
			{
				if (value == IntPtr.Zero)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (this.display != IntPtr.Zero)
				{
					throw new InvalidOperationException("The display connection may not be changed after being set.");
				}
				this.display = value;
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00025900 File Offset: 0x00023B00
		private XVisualInfo SelectVisual(GraphicsMode mode, X11WindowInfo currentWindow)
		{
			XVisualInfo result = default(XVisualInfo);
			result.VisualID = mode.Index.Value;
			result.Screen = currentWindow.Screen;
			lock (API.Lock)
			{
				int num;
				IntPtr intPtr = Functions.XGetVisualInfo(this.Display, XVisualInfoMask.ID | XVisualInfoMask.Screen, ref result, out num);
				if (num == 0)
				{
					throw new GraphicsModeException(string.Format("Invalid GraphicsMode specified ({0}).", mode));
				}
				result = (XVisualInfo)Marshal.PtrToStructure(intPtr, typeof(XVisualInfo));
				Functions.XFree(intPtr);
			}
			return result;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x000259A4 File Offset: 0x00023BA4
		private ArbCreateContext GetARBContextFlags(GraphicsContextFlags flags)
		{
			ArbCreateContext arbCreateContext = (ArbCreateContext)0;
			return arbCreateContext | (((flags & GraphicsContextFlags.Debug) != GraphicsContextFlags.Default) ? ArbCreateContext.DebugBit : ((ArbCreateContext)0));
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x000259C0 File Offset: 0x00023BC0
		private ArbCreateContext GetARBProfileFlags(GraphicsContextFlags flags)
		{
			ArbCreateContext arbCreateContext = (ArbCreateContext)0;
			return arbCreateContext | (((flags & GraphicsContextFlags.ForwardCompatible) != GraphicsContextFlags.Default) ? ArbCreateContext.DebugBit : ArbCreateContext.ForwardCompatibleBit);
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000259DC File Offset: 0x00023BDC
		private bool SupportsExtension(IntPtr display, X11WindowInfo window, string e)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (window.Display != display)
			{
				throw new InvalidOperationException();
			}
			if (string.IsNullOrEmpty(this.extensions))
			{
				using (new XLock(display))
				{
					this.extensions = Glx.QueryExtensionsString(display, window.Screen);
				}
			}
			return !string.IsNullOrEmpty(this.extensions) && this.extensions.Contains(e);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00025A7C File Offset: 0x00023C7C
		private bool SupportsCreateContextAttribs(IntPtr display, X11WindowInfo window)
		{
			return this.SupportsExtension(display, window, "GLX_ARB_create_context") && this.SupportsExtension(display, window, "GLX_ARB_create_context_profile");
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00025A9C File Offset: 0x00023C9C
		public override void SwapBuffers()
		{
			if (this.Display == IntPtr.Zero || this.currentWindow.Handle == IntPtr.Zero)
			{
				throw new InvalidOperationException(string.Format("Window is invalid. Display ({0}), Handle ({1}).", this.Display, this.currentWindow.Handle));
			}
			using (new XLock(this.Display))
			{
				Glx.SwapBuffers(this.Display, this.currentWindow.Handle);
			}
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00025B40 File Offset: 0x00023D40
		public override void MakeCurrent(IWindowInfo window)
		{
			if (window == this.currentWindow && this.IsCurrent)
			{
				return;
			}
			if (window != null && ((X11WindowInfo)window).Display != this.Display)
			{
				throw new InvalidOperationException("MakeCurrent() may only be called on windows originating from the same display that spawned this GL context.");
			}
			if (window == null)
			{
				using (new XLock(this.Display))
				{
					bool flag = Glx.MakeCurrent(this.Display, IntPtr.Zero, IntPtr.Zero);
					if (flag)
					{
						this.currentWindow = null;
					}
					goto IL_10F;
				}
			}
			X11WindowInfo x11WindowInfo = (X11WindowInfo)window;
			if (this.Display == IntPtr.Zero || x11WindowInfo.Handle == IntPtr.Zero || this.Handle == ContextHandle.Zero)
			{
				throw new InvalidOperationException("Invalid display, window or context.");
			}
			bool flag2;
			using (new XLock(this.Display))
			{
				flag2 = Glx.MakeCurrent(this.Display, x11WindowInfo.Handle, this.Handle);
				if (flag2)
				{
					this.currentWindow = x11WindowInfo;
				}
			}
			if (!flag2)
			{
				throw new GraphicsContextException("Failed to make context current.");
			}
			IL_10F:
			this.currentWindow = (X11WindowInfo)window;
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x00025C84 File Offset: 0x00023E84
		public override bool IsCurrent
		{
			get
			{
				bool result;
				using (new XLock(this.Display))
				{
					result = (Glx.GetCurrentContext() == this.Handle.Handle);
				}
				return result;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x00025CD4 File Offset: 0x00023ED4
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x00025D6C File Offset: 0x00023F6C
		public override int SwapInterval
		{
			get
			{
				if (this.currentWindow == null)
				{
					throw new InvalidOperationException();
				}
				int result;
				using (new XLock(this.display))
				{
					if (this.vsync_ext_supported)
					{
						int num;
						Glx.QueryDrawable(this.Display, this.currentWindow.Handle, GLXAttribute.SWAP_INTERVAL_EXT, out num);
						result = num;
					}
					else if (this.vsync_mesa_supported)
					{
						result = Glx.Mesa.GetSwapInterval();
					}
					else if (this.vsync_sgi_supported)
					{
						result = this.sgi_swap_interval;
					}
					else
					{
						result = 0;
					}
				}
				return result;
			}
			set
			{
				if (this.currentWindow == null)
				{
					throw new InvalidOperationException();
				}
				if (value < 0 && !this.vsync_tear_supported)
				{
					value = 1;
				}
				ErrorCode errorCode = ErrorCode.NO_ERROR;
				using (new XLock(this.Display))
				{
					if (this.vsync_ext_supported)
					{
						Glx.Ext.SwapInterval(this.Display, this.currentWindow.Handle, value);
					}
					else if (this.vsync_mesa_supported)
					{
						errorCode = Glx.Mesa.SwapInterval(value);
					}
					else if (this.vsync_sgi_supported)
					{
						errorCode = Glx.Sgi.SwapInterval(value);
					}
				}
				if (errorCode == ErrorCode.NO_ERROR)
				{
					this.sgi_swap_interval = value;
				}
			}
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00025E10 File Offset: 0x00024010
		public override void LoadAll()
		{
			this.vsync_ext_supported = this.SupportsExtension(this.display, this.currentWindow, "GLX_EXT_swap_control");
			this.vsync_mesa_supported = this.SupportsExtension(this.display, this.currentWindow, "GLX_MESA_swap_control");
			this.vsync_sgi_supported = this.SupportsExtension(this.display, this.currentWindow, "GLX_SGI_swap_control");
			this.vsync_tear_supported = this.SupportsExtension(this.display, this.currentWindow, "GLX_EXT_swap_control_tear");
			base.LoadAll();
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00025E98 File Offset: 0x00024098
		public override IntPtr GetAddress(IntPtr function)
		{
			IntPtr procAddress;
			using (new XLock(this.Display))
			{
				procAddress = Glx.GetProcAddress(function);
			}
			return procAddress;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00025EDC File Offset: 0x000240DC
		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00025EEC File Offset: 0x000240EC
		private void Dispose(bool manuallyCalled)
		{
			if (!base.IsDisposed && manuallyCalled)
			{
				IntPtr dpy = this.Display;
				if (this.IsCurrent)
				{
					using (new XLock(dpy))
					{
						Glx.MakeCurrent(dpy, IntPtr.Zero, IntPtr.Zero);
					}
				}
				using (new XLock(dpy))
				{
					Glx.DestroyContext(dpy, this.Handle);
				}
			}
			base.IsDisposed = true;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00025F84 File Offset: 0x00024184
		~X11GLContext()
		{
			this.Dispose(false);
		}

		// Token: 0x04000C34 RID: 3124
		private IntPtr display;

		// Token: 0x04000C35 RID: 3125
		private X11WindowInfo currentWindow;

		// Token: 0x04000C36 RID: 3126
		private bool vsync_ext_supported;

		// Token: 0x04000C37 RID: 3127
		private bool vsync_mesa_supported;

		// Token: 0x04000C38 RID: 3128
		private bool vsync_sgi_supported;

		// Token: 0x04000C39 RID: 3129
		private bool vsync_tear_supported;

		// Token: 0x04000C3A RID: 3130
		private int sgi_swap_interval = 1;

		// Token: 0x04000C3B RID: 3131
		private readonly X11GraphicsMode ModeSelector = new X11GraphicsMode();

		// Token: 0x04000C3C RID: 3132
		private string extensions;
	}
}
