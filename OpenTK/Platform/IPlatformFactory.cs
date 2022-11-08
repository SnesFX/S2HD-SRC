using System;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x0200005F RID: 95
	internal interface IPlatformFactory : IDisposable
	{
		// Token: 0x06000693 RID: 1683
		INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device);

		// Token: 0x06000694 RID: 1684
		IDisplayDeviceDriver CreateDisplayDeviceDriver();

		// Token: 0x06000695 RID: 1685
		IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags);

		// Token: 0x06000696 RID: 1686
		IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags);

		// Token: 0x06000697 RID: 1687
		GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext();

		// Token: 0x06000698 RID: 1688
		IKeyboardDriver2 CreateKeyboardDriver();

		// Token: 0x06000699 RID: 1689
		IMouseDriver2 CreateMouseDriver();

		// Token: 0x0600069A RID: 1690
		IGamePadDriver CreateGamePadDriver();

		// Token: 0x0600069B RID: 1691
		IJoystickDriver2 CreateJoystickDriver();

		// Token: 0x0600069C RID: 1692
		IJoystickDriver CreateLegacyJoystickDriver();
	}
}
