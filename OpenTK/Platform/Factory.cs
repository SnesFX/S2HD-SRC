using System;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform.Egl;
using OpenTK.Platform.Linux;
using OpenTK.Platform.MacOS;
using OpenTK.Platform.SDL2;
using OpenTK.Platform.Windows;
using OpenTK.Platform.X11;

namespace OpenTK.Platform
{
	// Token: 0x02000060 RID: 96
	internal sealed class Factory : IPlatformFactory, IDisposable
	{
		// Token: 0x0600069D RID: 1693 RVA: 0x00017908 File Offset: 0x00015B08
		static Factory()
		{
			Toolkit.Init();
			if (Configuration.RunningOnSdl2)
			{
				Factory.Default = new Sdl2Factory();
			}
			else if (Configuration.RunningOnX11)
			{
				Factory.Default = new X11Factory();
			}
			else if (Configuration.RunningOnLinux)
			{
				Factory.Default = new LinuxFactory();
			}
			else if (Configuration.RunningOnWindows)
			{
				Factory.Default = new WinFactory();
			}
			else if (Configuration.RunningOnMacOS)
			{
				Factory.Default = new MacOSFactory();
			}
			else
			{
				Factory.Default = new Factory.UnsupportedPlatform();
			}
			if (Configuration.RunningOnSdl2)
			{
				Factory.Embedded = Factory.Default;
			}
			else if (Egl.IsSupported)
			{
				if (Configuration.RunningOnLinux)
				{
					Factory.Embedded = Factory.Default;
				}
				else if (Configuration.RunningOnX11)
				{
					Factory.Embedded = new EglX11PlatformFactory();
				}
				else if (Configuration.RunningOnWindows)
				{
					Factory.Embedded = new EglWinPlatformFactory();
				}
				else if (Configuration.RunningOnMacOS)
				{
					Factory.Embedded = new EglMacPlatformFactory();
				}
				else
				{
					Factory.Embedded = new Factory.UnsupportedPlatform();
				}
			}
			else
			{
				Factory.Embedded = new Factory.UnsupportedPlatform();
			}
			if (Factory.Default is Factory.UnsupportedPlatform && !(Factory.Embedded is Factory.UnsupportedPlatform))
			{
				Factory.Default = Factory.Embedded;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x00017A24 File Offset: 0x00015C24
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x00017A2C File Offset: 0x00015C2C
		public static IPlatformFactory Default
		{
			get
			{
				return Factory.default_implementation;
			}
			private set
			{
				Factory.default_implementation = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x00017A34 File Offset: 0x00015C34
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x00017A3C File Offset: 0x00015C3C
		public static IPlatformFactory Embedded
		{
			get
			{
				return Factory.embedded_implementation;
			}
			private set
			{
				Factory.embedded_implementation = value;
			}
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00017A44 File Offset: 0x00015C44
		public INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			return Factory.default_implementation.CreateNativeWindow(x, y, width, height, title, mode, options, device);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00017A68 File Offset: 0x00015C68
		public IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return Factory.default_implementation.CreateDisplayDeviceDriver();
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00017A74 File Offset: 0x00015C74
		public IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return Factory.default_implementation.CreateGLContext(mode, window, shareContext, directRendering, major, minor, flags);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00017A8C File Offset: 0x00015C8C
		public IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return Factory.default_implementation.CreateGLContext(handle, window, shareContext, directRendering, major, minor, flags);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00017AA4 File Offset: 0x00015CA4
		public GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return Factory.default_implementation.CreateGetCurrentGraphicsContext();
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00017AB0 File Offset: 0x00015CB0
		public IKeyboardDriver2 CreateKeyboardDriver()
		{
			return Factory.default_implementation.CreateKeyboardDriver();
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00017ABC File Offset: 0x00015CBC
		public IMouseDriver2 CreateMouseDriver()
		{
			return Factory.default_implementation.CreateMouseDriver();
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00017AC8 File Offset: 0x00015CC8
		public IGamePadDriver CreateGamePadDriver()
		{
			return Factory.default_implementation.CreateGamePadDriver();
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00017AD4 File Offset: 0x00015CD4
		public IJoystickDriver2 CreateJoystickDriver()
		{
			return Factory.default_implementation.CreateJoystickDriver();
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00017AE0 File Offset: 0x00015CE0
		public IJoystickDriver CreateLegacyJoystickDriver()
		{
			return Factory.default_implementation.CreateLegacyJoystickDriver();
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00017AEC File Offset: 0x00015CEC
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (manual)
				{
					Factory.Default.Dispose();
					if (Factory.Embedded != Factory.Default)
					{
						Factory.Embedded.Dispose();
					}
				}
				this.disposed = true;
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00017B20 File Offset: 0x00015D20
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00017B30 File Offset: 0x00015D30
		~Factory()
		{
			this.Dispose(false);
		}

		// Token: 0x040001C4 RID: 452
		private bool disposed;

		// Token: 0x040001C5 RID: 453
		private static IPlatformFactory default_implementation;

		// Token: 0x040001C6 RID: 454
		private static IPlatformFactory embedded_implementation;

		// Token: 0x02000061 RID: 97
		private class UnsupportedPlatform : PlatformFactoryBase
		{
			// Token: 0x060006B0 RID: 1712 RVA: 0x00017B68 File Offset: 0x00015D68
			public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B1 RID: 1713 RVA: 0x00017B74 File Offset: 0x00015D74
			public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B2 RID: 1714 RVA: 0x00017B80 File Offset: 0x00015D80
			public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B3 RID: 1715 RVA: 0x00017B8C File Offset: 0x00015D8C
			public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B4 RID: 1716 RVA: 0x00017B98 File Offset: 0x00015D98
			public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B5 RID: 1717 RVA: 0x00017BA4 File Offset: 0x00015DA4
			public override IKeyboardDriver2 CreateKeyboardDriver()
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B6 RID: 1718 RVA: 0x00017BB0 File Offset: 0x00015DB0
			public override IMouseDriver2 CreateMouseDriver()
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x060006B7 RID: 1719 RVA: 0x00017BBC File Offset: 0x00015DBC
			public override IJoystickDriver2 CreateJoystickDriver()
			{
				throw new PlatformNotSupportedException(Factory.UnsupportedPlatform.error_string);
			}

			// Token: 0x040001C7 RID: 455
			private static readonly string error_string = "Please, refer to http://www.opentk.com for more information.";
		}
	}
}
