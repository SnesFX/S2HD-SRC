using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200006E RID: 110
	internal class WinFactory : PlatformFactoryBase
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00018444 File Offset: 0x00016644
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x0001844C File Offset: 0x0001664C
		internal static IntPtr OpenGLHandle { get; private set; }

		// Token: 0x06000720 RID: 1824 RVA: 0x00018454 File Offset: 0x00016654
		public WinFactory()
		{
			if (Environment.OSVersion.Version.Major <= 4)
			{
				throw new PlatformNotSupportedException("OpenTK requires Windows XP or higher");
			}
			WinFactory.LoadOpenGL();
			if (Environment.OSVersion.Version.Major >= 6 && Toolkit.Options.EnableHighResolution)
			{
				Functions.SetProcessDPIAware();
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000184B8 File Offset: 0x000166B8
		private static void LoadOpenGL()
		{
			WinFactory.OpenGLHandle = Functions.LoadLibrary("OPENGL32.DLL");
			if (WinFactory.OpenGLHandle == IntPtr.Zero)
			{
				throw new ApplicationException(string.Format("LoadLibrary(\"{0}\") call failed with code {1}", "OPENGL32.DLL", Marshal.GetLastWin32Error()));
			}
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00018504 File Offset: 0x00016704
		public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			return new WinGLNative(x, y, width, height, title, options, device);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00018518 File Offset: 0x00016718
		public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return new WinDisplayDeviceDriver();
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00018520 File Offset: 0x00016720
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new WinGLContext(mode, (WinWindowInfo)window, shareContext, major, minor, flags);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00018538 File Offset: 0x00016738
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new WinGLContext(handle, (WinWindowInfo)window, shareContext, major, minor, flags);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00018550 File Offset: 0x00016750
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(Wgl.GetCurrentContext());
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00018570 File Offset: 0x00016770
		public override IKeyboardDriver2 CreateKeyboardDriver()
		{
			return this.InputDriver.KeyboardDriver;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00018580 File Offset: 0x00016780
		public override IMouseDriver2 CreateMouseDriver()
		{
			return this.InputDriver.MouseDriver;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00018590 File Offset: 0x00016790
		public override IGamePadDriver CreateGamePadDriver()
		{
			return this.InputDriver.GamePadDriver;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x000185A0 File Offset: 0x000167A0
		public override IJoystickDriver2 CreateJoystickDriver()
		{
			return this.InputDriver.JoystickDriver;
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x000185B0 File Offset: 0x000167B0
		private IInputDriver2 InputDriver
		{
			get
			{
				IInputDriver2 result;
				lock (this.SyncRoot)
				{
					if (this.inputDriver == null)
					{
						this.inputDriver = new WinRawInput();
					}
					result = this.inputDriver;
				}
				return result;
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00018600 File Offset: 0x00016800
		protected override void Dispose(bool manual)
		{
			if (!this.IsDisposed)
			{
				if (manual)
				{
					this.InputDriver.Dispose();
				}
				base.Dispose(manual);
			}
		}

		// Token: 0x040001D1 RID: 465
		private const string OpenGLName = "OPENGL32.DLL";

		// Token: 0x040001D2 RID: 466
		private readonly object SyncRoot = new object();

		// Token: 0x040001D3 RID: 467
		private IInputDriver2 inputDriver;
	}
}
