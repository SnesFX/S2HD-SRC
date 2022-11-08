using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BA RID: 186
	public interface IFontRenderer
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600062D RID: 1581
		// (set) Token: 0x0600062E RID: 1582
		FontAlignment Alignment { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600062F RID: 1583
		// (set) Token: 0x06000630 RID: 1584
		Rectangle Boundary { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000631 RID: 1585
		// (set) Token: 0x06000632 RID: 1586
		Colour Colour { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000633 RID: 1587
		// (set) Token: 0x06000634 RID: 1588
		Font Font { get; set; }

		// Token: 0x06000635 RID: 1589
		Rectangle Measure();

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000636 RID: 1590
		// (set) Token: 0x06000637 RID: 1591
		int Overlay { get; set; }

		// Token: 0x06000638 RID: 1592
		void Render();

		// Token: 0x06000639 RID: 1593
		void RenderString(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay = null);

		// Token: 0x0600063A RID: 1594
		void RenderString(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, int overlay);

		// Token: 0x0600063B RID: 1595
		void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay = null);

		// Token: 0x0600063C RID: 1596
		void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay, Vector2i? shadow, Colour shadowColour, int? shadowOverlay = null);

		// Token: 0x0600063D RID: 1597
		void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, int overlay);

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600063E RID: 1598
		// (set) Token: 0x0600063F RID: 1599
		Vector2 Shadow { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000640 RID: 1600
		// (set) Token: 0x06000641 RID: 1601
		string Text { get; set; }
	}
}
