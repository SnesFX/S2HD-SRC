using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000F RID: 15
	internal static class RenderingHelpers
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00004CEB File Offset: 0x00002EEB
		public static void RenderToFramebuffer(Renderer renderer, IFramebuffer source, IFramebuffer destination, BlendMode blend = BlendMode.Alpha)
		{
			RenderingHelpers.RenderToFramebuffer(renderer, source.Textures[0], destination, new Rectangle(0.0, 0.0, (double)destination.Width, (double)destination.Height), blend);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004D26 File Offset: 0x00002F26
		public static void RenderToFramebuffer(Renderer renderer, ITexture source, IFramebuffer destination, BlendMode blend = BlendMode.Alpha)
		{
			RenderingHelpers.RenderToFramebuffer(renderer, source, destination, new Rectangle(0.0, 0.0, (double)destination.Width, (double)destination.Height), blend);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004D58 File Offset: 0x00002F58
		public static void RenderToFramebuffer(Renderer renderer, ITexture source, IFramebuffer destination, Rectangle destinationRect, BlendMode blend)
		{
			destination.Activate();
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = blend;
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.ClipRectangle = destinationRect;
			i2dRenderer.ModelMatrix = Matrix4.Identity;
			i2dRenderer.RenderTexture(source, new Rectangle(0.0, 0.0, (double)source.Width, (double)source.Height), destinationRect, false, true);
			i2dRenderer.Deactivate();
		}
	}
}
