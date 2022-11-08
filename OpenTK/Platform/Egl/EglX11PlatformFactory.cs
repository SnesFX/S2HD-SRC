using System;
using OpenTK.Graphics;
using OpenTK.Platform.X11;

namespace OpenTK.Platform.Egl
{
	// Token: 0x0200006D RID: 109
	internal class EglX11PlatformFactory : X11Factory
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x00018398 File Offset: 0x00016598
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			X11WindowInfo x11WindowInfo = (X11WindowInfo)window;
			EglWindowInfo window2 = new EglWindowInfo(x11WindowInfo.Handle, Egl.GetDisplay(x11WindowInfo.Display));
			return new EglUnixContext(mode, window2, shareContext, major, minor, flags);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000183D4 File Offset: 0x000165D4
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			X11WindowInfo x11WindowInfo = (X11WindowInfo)window;
			EglWindowInfo window2 = new EglWindowInfo(x11WindowInfo.Handle, Egl.GetDisplay(x11WindowInfo.Display));
			return new EglUnixContext(handle, window2, shareContext, major, minor, flags);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00018410 File Offset: 0x00016610
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(Egl.GetCurrentContext());
		}
	}
}
