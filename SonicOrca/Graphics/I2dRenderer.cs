using System;
using System.Collections.Generic;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000E0 RID: 224
	public interface I2dRenderer : IDisposable, IRenderer
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000794 RID: 1940
		// (set) Token: 0x06000795 RID: 1941
		BlendMode BlendMode { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000796 RID: 1942
		// (set) Token: 0x06000797 RID: 1943
		Rectangle ClipRectangle { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000798 RID: 1944
		// (set) Token: 0x06000799 RID: 1945
		Colour Colour { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600079A RID: 1946
		// (set) Token: 0x0600079B RID: 1947
		Colour AdditiveColour { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600079C RID: 1948
		// (set) Token: 0x0600079D RID: 1949
		Matrix4 ModelMatrix { get; set; }

		// Token: 0x0600079E RID: 1950
		IDisposable BeginMatixState();

		// Token: 0x0600079F RID: 1951
		void RenderQuad(Colour colour, Rectangle destination);

		// Token: 0x060007A0 RID: 1952
		void RenderEllipse(Colour colour, Vector2 centre, double innerRadius, double outerRadius, int sectors);

		// Token: 0x060007A1 RID: 1953
		void RenderRectangle(Colour colour, Rectangle destination, double tickness);

		// Token: 0x060007A2 RID: 1954
		void RenderLine(Colour colour, Vector2 a, Vector2 b, double thickness);

		// Token: 0x060007A3 RID: 1955
		void RenderTexture(ITexture texture, Rectangle destination, bool flipx = false, bool flipy = false);

		// Token: 0x060007A4 RID: 1956
		void RenderTexture(ITexture texture, Vector2 destination, bool flipx = false, bool flipy = false);

		// Token: 0x060007A5 RID: 1957
		void RenderTexture(ITexture texture, Rectangle source, Rectangle destination, bool flipx = false, bool flipy = false);

		// Token: 0x060007A6 RID: 1958
		void RenderTexture(IEnumerable<ITexture> texture, Rectangle source, Rectangle destination, bool flipx = false, bool flipy = false);

		// Token: 0x060007A7 RID: 1959
		Rectangle RenderText(TextRenderInfo textRenderInfo);

		// Token: 0x060007A8 RID: 1960
		Rectangle MeasureText(TextRenderInfo textRenderInfo);
	}
}
