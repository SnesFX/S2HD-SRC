using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BF RID: 191
	public interface IMaskRenderer : IDisposable
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000676 RID: 1654
		// (set) Token: 0x06000677 RID: 1655
		ITexture Texture { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000678 RID: 1656
		// (set) Token: 0x06000679 RID: 1657
		Rectanglei Source { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600067A RID: 1658
		// (set) Token: 0x0600067B RID: 1659
		Rectanglei Destination { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600067C RID: 1660
		// (set) Token: 0x0600067D RID: 1661
		ITexture MaskTexture { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600067E RID: 1662
		// (set) Token: 0x0600067F RID: 1663
		Rectanglei MaskSource { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000680 RID: 1664
		// (set) Token: 0x06000681 RID: 1665
		Rectanglei MaskDestination { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000682 RID: 1666
		// (set) Token: 0x06000683 RID: 1667
		BlendMode BlendMode { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000684 RID: 1668
		// (set) Token: 0x06000685 RID: 1669
		Colour Colour { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000686 RID: 1670
		// (set) Token: 0x06000687 RID: 1671
		Matrix4 IntersectionModelMatrix { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000688 RID: 1672
		// (set) Token: 0x06000689 RID: 1673
		Matrix4 TargetModelMatrix { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600068A RID: 1674
		// (set) Token: 0x0600068B RID: 1675
		Matrix4 MaskModelMatrix { get; set; }

		// Token: 0x0600068C RID: 1676
		IDisposable BeginMatixState();

		// Token: 0x0600068D RID: 1677
		void Render(bool maskColorMultiply = false);
	}
}
