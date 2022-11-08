using System;
using OpenTK.Graphics;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A3 RID: 1443
	internal class Sdl2GraphicsMode : IGraphicsMode
	{
		// Token: 0x06004620 RID: 17952 RVA: 0x000C13C0 File Offset: 0x000BF5C0
		public GraphicsMode SelectGraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			return new GraphicsMode(new IntPtr?(IntPtr.Zero), color, depth, stencil, samples, accum, buffers, stereo);
		}
	}
}
