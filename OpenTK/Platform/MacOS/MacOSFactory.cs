using System;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000076 RID: 118
	internal class MacOSFactory : PlatformFactoryBase
	{
		// Token: 0x06000769 RID: 1897 RVA: 0x00018ADC File Offset: 0x00016CDC
		public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			return new CocoaNativeWindow(x, y, width, height, title, mode, options, device);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00018AF0 File Offset: 0x00016CF0
		public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return new QuartzDisplayDeviceDriver();
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00018AF8 File Offset: 0x00016CF8
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new CocoaContext(mode, window, shareContext, major, minor);
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00018B08 File Offset: 0x00016D08
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new CocoaContext(handle, window, shareContext, major, minor);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00018B18 File Offset: 0x00016D18
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(CocoaContext.CurrentContext);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00018B38 File Offset: 0x00016D38
		public override IKeyboardDriver2 CreateKeyboardDriver()
		{
			return this.InputDriver.KeyboardDriver;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00018B48 File Offset: 0x00016D48
		public override IMouseDriver2 CreateMouseDriver()
		{
			return this.InputDriver.MouseDriver;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00018B58 File Offset: 0x00016D58
		public override IJoystickDriver2 CreateJoystickDriver()
		{
			return this.InputDriver.JoystickDriver;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00018B68 File Offset: 0x00016D68
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

		// Token: 0x04000261 RID: 609
		internal const float ScrollFactor = 0.1f;

		// Token: 0x04000262 RID: 610
		internal static bool ExclusiveFullscreen;

		// Token: 0x04000263 RID: 611
		private readonly IInputDriver2 InputDriver = new HIDInput();
	}
}
