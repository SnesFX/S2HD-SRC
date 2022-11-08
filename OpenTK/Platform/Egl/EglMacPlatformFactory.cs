using System;
using OpenTK.Graphics;
using OpenTK.Platform.MacOS;

namespace OpenTK.Platform.Egl
{
	// Token: 0x02000077 RID: 119
	internal class EglMacPlatformFactory : MacOSFactory
	{
		// Token: 0x06000775 RID: 1909 RVA: 0x00018BAC File Offset: 0x00016DAC
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00018BB4 File Offset: 0x00016DB4
		public override IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			throw new NotImplementedException();
		}
	}
}
