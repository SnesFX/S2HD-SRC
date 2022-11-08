using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000CD RID: 205
	public class TextRenderInfo
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001D594 File Offset: 0x0001B794
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x0001D59C File Offset: 0x0001B79C
		public Font Font { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0001D5A5 File Offset: 0x0001B7A5
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x0001D5AD File Offset: 0x0001B7AD
		public Rectangle Bounds { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x0001D5B6 File Offset: 0x0001B7B6
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x0001D5BE File Offset: 0x0001B7BE
		public FontAlignment Alignment { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0001D5C7 File Offset: 0x0001B7C7
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x0001D5CF File Offset: 0x0001B7CF
		public Colour Colour { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0001D5D8 File Offset: 0x0001B7D8
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0001D5E0 File Offset: 0x0001B7E0
		public int? Overlay { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0001D5E9 File Offset: 0x0001B7E9
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0001D5F1 File Offset: 0x0001B7F1
		public string Text { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x0001D5FA File Offset: 0x0001B7FA
		// (set) Token: 0x060006E4 RID: 1764 RVA: 0x0001D602 File Offset: 0x0001B802
		public Vector2 Shadow { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x0001D60B File Offset: 0x0001B80B
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x0001D613 File Offset: 0x0001B813
		public Colour ShadowColour { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x0001D61C File Offset: 0x0001B81C
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0001D624 File Offset: 0x0001B824
		public int? ShadowOverlay { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x0001D62D File Offset: 0x0001B82D
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x0001D635 File Offset: 0x0001B835
		public float SizeMultiplier { get; set; }

		// Token: 0x060006EB RID: 1771 RVA: 0x0001D63E File Offset: 0x0001B83E
		public TextRenderInfo()
		{
			this.Colour = Colours.White;
		}
	}
}
