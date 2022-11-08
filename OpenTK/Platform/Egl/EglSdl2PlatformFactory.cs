using System;
using OpenTK.Graphics;
using OpenTK.Platform.SDL2;

namespace OpenTK.Platform.Egl
{
	// Token: 0x020005E4 RID: 1508
	internal class EglSdl2PlatformFactory : Sdl2Factory
	{
		// Token: 0x060046E0 RID: 18144 RVA: 0x000C3544 File Offset: 0x000C1744
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			flags |= GraphicsContextFlags.Embedded;
			return base.CreateGLContext(mode, window, shareContext, directRendering, major, minor, flags);
		}
	}
}
