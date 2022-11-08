using System;

namespace OpenTK.Graphics
{
	// Token: 0x020000E8 RID: 232
	internal interface IGraphicsMode
	{
		// Token: 0x06000983 RID: 2435
		GraphicsMode SelectGraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo);
	}
}
