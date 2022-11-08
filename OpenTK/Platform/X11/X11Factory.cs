using System;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200006C RID: 108
	internal class X11Factory : PlatformFactoryBase
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001828C File Offset: 0x0001648C
		private IInputDriver2 InputDriver
		{
			get
			{
				if (this.input_driver == null)
				{
					if (XI2MouseKeyboard.IsSupported(IntPtr.Zero))
					{
						this.input_driver = new XI2Input();
					}
					else
					{
						this.input_driver = new X11Input();
					}
				}
				return this.input_driver;
			}
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000182C0 File Offset: 0x000164C0
		public X11Factory()
		{
			Functions.XInitThreads();
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000182D0 File Offset: 0x000164D0
		public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			return new X11GLNative(x, y, width, height, title, mode, options, device);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000182E4 File Offset: 0x000164E4
		public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return new X11DisplayDevice();
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000182EC File Offset: 0x000164EC
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new X11GLContext(mode, window, shareContext, directRendering, major, minor, flags);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00018300 File Offset: 0x00016500
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new X11GLContext(handle, window, shareContext, directRendering, major, minor, flags);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00018314 File Offset: 0x00016514
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(Glx.GetCurrentContext());
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00018334 File Offset: 0x00016534
		public override IKeyboardDriver2 CreateKeyboardDriver()
		{
			return this.InputDriver.KeyboardDriver;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00018344 File Offset: 0x00016544
		public override IMouseDriver2 CreateMouseDriver()
		{
			return this.InputDriver.MouseDriver;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00018354 File Offset: 0x00016554
		public override IJoystickDriver2 CreateJoystickDriver()
		{
			return this.InputDriver.JoystickDriver;
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00018364 File Offset: 0x00016564
		protected override void Dispose(bool manual)
		{
			base.Dispose(manual);
			if (manual && this.input_driver != null)
			{
				this.input_driver.Dispose();
				this.input_driver = null;
			}
		}

		// Token: 0x040001CE RID: 462
		private IInputDriver2 input_driver;
	}
}
