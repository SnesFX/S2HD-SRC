using System;
using OpenTK.Graphics;
using OpenTK.Platform.Windows;

namespace OpenTK.Platform.Egl
{
	// Token: 0x0200006F RID: 111
	internal class EglWinPlatformFactory : WinFactory
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x0001862C File Offset: 0x0001682C
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			WinWindowInfo winWindowInfo = (WinWindowInfo)window;
			IntPtr display = this.GetDisplay(winWindowInfo.DeviceContext);
			EglWindowInfo window2 = new EglWindowInfo(winWindowInfo.Handle, display);
			return new EglWinContext(mode, window2, shareContext, major, minor, flags);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00018668 File Offset: 0x00016868
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			WinWindowInfo winWindowInfo = (WinWindowInfo)window;
			IntPtr display = this.GetDisplay(winWindowInfo.DeviceContext);
			EglWindowInfo window2 = new EglWindowInfo(winWindowInfo.Handle, display);
			return new EglWinContext(handle, window2, shareContext, major, minor, flags);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x000186A4 File Offset: 0x000168A4
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(Egl.GetCurrentContext());
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000186C4 File Offset: 0x000168C4
		private IntPtr GetDisplay(IntPtr dc)
		{
			IntPtr display = Egl.GetDisplay(dc);
			if (display == IntPtr.Zero)
			{
				display = Egl.GetDisplay(IntPtr.Zero);
			}
			return display;
		}
	}
}
