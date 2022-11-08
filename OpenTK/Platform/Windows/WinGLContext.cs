using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Graphics;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000D7 RID: 215
	internal sealed class WinGLContext : DesktopGraphicsContext
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x0001E20C File Offset: 0x0001C40C
		public WinGLContext(GraphicsMode format, WinWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags)
		{
			lock (WinGLContext.LoadLock)
			{
				if (window == null)
				{
					throw new ArgumentNullException("window", "Must point to a valid window.");
				}
				if (window.Handle == IntPtr.Zero)
				{
					throw new ArgumentException("window", "Must be a valid window.");
				}
				IntPtr currentContext = Wgl.GetCurrentContext();
				INativeWindow nativeWindow = null;
				WinGLContext.TemporaryContext temporaryContext = null;
				try
				{
					if (currentContext == IntPtr.Zero)
					{
						nativeWindow = new NativeWindow();
						temporaryContext = new WinGLContext.TemporaryContext(nativeWindow);
						currentContext = Wgl.GetCurrentContext();
						if (currentContext != IntPtr.Zero && currentContext == temporaryContext.Context.Handle)
						{
							new Wgl().LoadEntryPoints();
						}
					}
					this.ModeSelector = new WinGraphicsMode(window.DeviceContext);
					this.Mode = WinGLContext.SetGraphicsModePFD(this.ModeSelector, format, window);
					if (Wgl.SupportsFunction("wglCreateContextAttribsARB"))
					{
						try
						{
							List<int> list = new List<int>();
							list.Add(8337);
							list.Add(major);
							list.Add(8338);
							list.Add(minor);
							if (flags != GraphicsContextFlags.Default)
							{
								list.Add(8340);
								list.Add((int)WinGLContext.GetARBContextFlags(flags));
								list.Add(37158);
								list.Add((int)WinGLContext.GetARBContextProfile(flags));
							}
							list.Add(0);
							list.Add(0);
							this.Handle = new ContextHandle(Wgl.Arb.CreateContextAttribs(window.DeviceContext, (sharedContext != null) ? (sharedContext as IGraphicsContextInternal).Context.Handle : IntPtr.Zero, list.ToArray()));
							this.Handle == ContextHandle.Zero;
						}
						catch (Exception)
						{
						}
					}
					if (this.Handle == ContextHandle.Zero)
					{
						this.Handle = new ContextHandle(Wgl.CreateContext(window.DeviceContext));
						if (this.Handle == ContextHandle.Zero)
						{
							this.Handle = new ContextHandle(Wgl.CreateContext(window.DeviceContext));
						}
						if (this.Handle == ContextHandle.Zero)
						{
							throw new GraphicsContextException(string.Format("Context creation failed. Wgl.CreateContext() error: {0}.", Marshal.GetLastWin32Error()));
						}
					}
				}
				finally
				{
					if (temporaryContext != null)
					{
						temporaryContext.Dispose();
						temporaryContext = null;
					}
					if (nativeWindow != null)
					{
						nativeWindow.Dispose();
						nativeWindow = null;
					}
				}
			}
			this.MakeCurrent(window);
			new Wgl().LoadEntryPoints();
			if (sharedContext != null)
			{
				Marshal.GetLastWin32Error();
				Wgl.ShareLists((sharedContext as IGraphicsContextInternal).Context.Handle, this.Handle.Handle);
			}
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
		private static ArbCreateContext GetARBContextFlags(GraphicsContextFlags flags)
		{
			ArbCreateContext arbCreateContext = (ArbCreateContext)0;
			return arbCreateContext | (((flags & GraphicsContextFlags.ForwardCompatible) != GraphicsContextFlags.Default) ? ArbCreateContext.CoreProfileBit : ArbCreateContext.CompatibilityProfileBit);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001E4EC File Offset: 0x0001C6EC
		private static ArbCreateContext GetARBContextProfile(GraphicsContextFlags flags)
		{
			ArbCreateContext arbCreateContext = (ArbCreateContext)0;
			return arbCreateContext | (((flags & GraphicsContextFlags.Debug) != GraphicsContextFlags.Default) ? ArbCreateContext.CoreProfileBit : ((ArbCreateContext)0));
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0001E508 File Offset: 0x0001C708
		public WinGLContext(ContextHandle handle, WinWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags)
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
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0001E540 File Offset: 0x0001C740
		public override void SwapBuffers()
		{
			if (!Functions.SwapBuffers(this.DeviceContext))
			{
				throw new GraphicsContextException(string.Format("Failed to swap buffers for context {0} current. Error: {1}", this, Marshal.GetLastWin32Error()));
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001E56C File Offset: 0x0001C76C
		public override void MakeCurrent(IWindowInfo window)
		{
			lock (WinGLContext.LoadLock)
			{
				WinWindowInfo winWindowInfo = window as WinWindowInfo;
				bool flag;
				if (winWindowInfo != null)
				{
					if (winWindowInfo.Handle == IntPtr.Zero)
					{
						throw new ArgumentException("window", "Must point to a valid window.");
					}
					flag = Wgl.MakeCurrent(winWindowInfo.DeviceContext, this.Handle.Handle);
					this.device_context = winWindowInfo.DeviceContext;
				}
				else
				{
					flag = Wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
					this.device_context = IntPtr.Zero;
				}
				if (!flag)
				{
					throw new GraphicsContextException(string.Format("Failed to make context {0} current. Error: {1}", this, Marshal.GetLastWin32Error()));
				}
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0001E628 File Offset: 0x0001C828
		public override bool IsCurrent
		{
			get
			{
				return Wgl.GetCurrentContext() == this.Handle.Handle;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0001E640 File Offset: 0x0001C840
		// (set) Token: 0x06000929 RID: 2345 RVA: 0x0001E688 File Offset: 0x0001C888
		public override int SwapInterval
		{
			get
			{
				int result;
				lock (WinGLContext.LoadLock)
				{
					if (this.vsync_supported)
					{
						result = Wgl.Ext.GetSwapInterval();
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
				lock (WinGLContext.LoadLock)
				{
					if (this.vsync_supported)
					{
						if (value < 0 && !this.vsync_tear_supported)
						{
							value = 1;
						}
						Wgl.Ext.SwapInterval(value);
					}
				}
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0001E6D8 File Offset: 0x0001C8D8
		public override void LoadAll()
		{
			lock (WinGLContext.LoadLock)
			{
				new Wgl().LoadEntryPoints();
				this.vsync_supported = (Wgl.SupportsExtension(this.DeviceContext, "WGL_EXT_swap_control") && Wgl.SupportsFunction("wglGetSwapIntervalEXT") && Wgl.SupportsFunction("wglSwapIntervalEXT"));
				this.vsync_tear_supported = Wgl.SupportsExtension(this.DeviceContext, "WGL_EXT_swap_control_tear");
			}
			base.LoadAll();
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0001E764 File Offset: 0x0001C964
		public override IntPtr GetAddress(IntPtr function_string)
		{
			IntPtr procAddress = Wgl.GetProcAddress(function_string);
			if (!WinGLContext.IsValid(procAddress))
			{
				procAddress = Functions.GetProcAddress(WinFactory.OpenGLHandle, function_string);
			}
			return procAddress;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001E790 File Offset: 0x0001C990
		private static bool IsValid(IntPtr address)
		{
			long num = address.ToInt64();
			return num < -1L || num > 3L;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001E7B4 File Offset: 0x0001C9B4
		internal static GraphicsMode SetGraphicsModePFD(WinGraphicsMode mode_selector, GraphicsMode mode, WinWindowInfo window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window", "Must point to a valid window.");
			}
			if (mode.Index == null)
			{
				mode = mode_selector.SelectGraphicsMode(mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo);
			}
			PixelFormatDescriptor pixelFormatDescriptor = default(PixelFormatDescriptor);
			Functions.DescribePixelFormat(window.DeviceContext, (int)mode.Index.Value, (int)API.PixelFormatDescriptorSize, ref pixelFormatDescriptor);
			if (!Functions.SetPixelFormat(window.DeviceContext, (int)mode.Index.Value, ref pixelFormatDescriptor))
			{
				throw new GraphicsContextException(string.Format("Requested GraphicsMode not available. SetPixelFormat error: {0}", Marshal.GetLastWin32Error()));
			}
			return mode;
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x0001E884 File Offset: 0x0001CA84
		internal IntPtr DeviceContext
		{
			get
			{
				return this.device_context;
			}
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0001E88C File Offset: 0x0001CA8C
		public override string ToString()
		{
			return ((IGraphicsContextInternal)this).Context.ToString();
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0001E8B0 File Offset: 0x0001CAB0
		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0001E8C0 File Offset: 0x0001CAC0
		private void Dispose(bool calledManually)
		{
			if (!base.IsDisposed)
			{
				if (calledManually)
				{
					this.DestroyContext();
				}
				base.IsDisposed = true;
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001E8DC File Offset: 0x0001CADC
		~WinGLContext()
		{
			this.Dispose(false);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001E90C File Offset: 0x0001CB0C
		private void DestroyContext()
		{
			if (this.Handle != ContextHandle.Zero)
			{
				try
				{
					Wgl.DeleteContext(this.Handle.Handle);
				}
				catch (AccessViolationException)
				{
				}
				this.Handle = ContextHandle.Zero;
			}
		}

		// Token: 0x04000742 RID: 1858
		private static readonly object LoadLock = new object();

		// Token: 0x04000743 RID: 1859
		private IntPtr device_context;

		// Token: 0x04000744 RID: 1860
		private bool vsync_supported;

		// Token: 0x04000745 RID: 1861
		private bool vsync_tear_supported;

		// Token: 0x04000746 RID: 1862
		private readonly WinGraphicsMode ModeSelector;

		// Token: 0x020000D8 RID: 216
		private class TemporaryContext : IDisposable
		{
			// Token: 0x06000935 RID: 2357 RVA: 0x0001E968 File Offset: 0x0001CB68
			public TemporaryContext(INativeWindow native)
			{
				if (native == null)
				{
					throw new ArgumentNullException();
				}
				WinWindowInfo winWindowInfo = native.WindowInfo as WinWindowInfo;
				WinGraphicsMode mode_selector = new WinGraphicsMode(winWindowInfo.DeviceContext);
				WinGLContext.SetGraphicsModePFD(mode_selector, GraphicsMode.Default, winWindowInfo);
				bool flag = false;
				this.Context = new ContextHandle(Wgl.CreateContext(winWindowInfo.DeviceContext));
				if (this.Context != ContextHandle.Zero)
				{
					int num = 0;
					while (num < 5 && !flag)
					{
						flag = Wgl.MakeCurrent(winWindowInfo.DeviceContext, this.Context.Handle);
						if (!flag)
						{
							Thread.Sleep(10);
						}
						num++;
					}
				}
			}

			// Token: 0x06000936 RID: 2358 RVA: 0x0001EA08 File Offset: 0x0001CC08
			public void Dispose()
			{
				if (this.Context != ContextHandle.Zero)
				{
					Wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
					Wgl.DeleteContext(this.Context.Handle);
				}
			}

			// Token: 0x04000747 RID: 1863
			public ContextHandle Context;
		}
	}
}
