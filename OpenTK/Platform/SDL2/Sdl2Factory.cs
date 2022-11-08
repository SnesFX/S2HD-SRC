using System;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A1 RID: 1441
	internal class Sdl2Factory : PlatformFactoryBase
	{
		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060045FF RID: 17919 RVA: 0x000C0CC4 File Offset: 0x000BEEC4
		// (set) Token: 0x06004600 RID: 17920 RVA: 0x000C0CCC File Offset: 0x000BEECC
		public static bool UseFullscreenDesktop { get; set; }

		// Token: 0x06004601 RID: 17921 RVA: 0x000C0CD4 File Offset: 0x000BEED4
		public Sdl2Factory()
		{
			Sdl2Factory.UseFullscreenDesktop = true;
		}

		// Token: 0x06004602 RID: 17922 RVA: 0x000C0CF0 File Offset: 0x000BEEF0
		public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			return new Sdl2NativeWindow(x, y, width, height, title, options, device);
		}

		// Token: 0x06004603 RID: 17923 RVA: 0x000C0D04 File Offset: 0x000BEF04
		public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return new Sdl2DisplayDeviceDriver();
		}

		// Token: 0x06004604 RID: 17924 RVA: 0x000C0D0C File Offset: 0x000BEF0C
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new Sdl2GraphicsContext(mode, window, shareContext, major, minor, flags);
		}

		// Token: 0x06004605 RID: 17925 RVA: 0x000C0D1C File Offset: 0x000BEF1C
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004606 RID: 17926 RVA: 0x000C0D24 File Offset: 0x000BEF24
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => Sdl2GraphicsContext.GetCurrentContext();
		}

		// Token: 0x06004607 RID: 17927 RVA: 0x000C0D44 File Offset: 0x000BEF44
		public override IKeyboardDriver2 CreateKeyboardDriver()
		{
			return this.InputDriver.KeyboardDriver;
		}

		// Token: 0x06004608 RID: 17928 RVA: 0x000C0D54 File Offset: 0x000BEF54
		public override IMouseDriver2 CreateMouseDriver()
		{
			return this.InputDriver.MouseDriver;
		}

		// Token: 0x06004609 RID: 17929 RVA: 0x000C0D64 File Offset: 0x000BEF64
		public override IJoystickDriver2 CreateJoystickDriver()
		{
			return this.InputDriver.JoystickDriver;
		}

		// Token: 0x0600460A RID: 17930 RVA: 0x000C0D74 File Offset: 0x000BEF74
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

		// Token: 0x04005210 RID: 21008
		private readonly Sdl2InputDriver InputDriver = new Sdl2InputDriver();
	}
}
