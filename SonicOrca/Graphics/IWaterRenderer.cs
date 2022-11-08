using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C2 RID: 194
	public interface IWaterRenderer : IRenderer, IDisposable
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000699 RID: 1689
		// (set) Token: 0x0600069A RID: 1690
		double HueTarget { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600069B RID: 1691
		// (set) Token: 0x0600069C RID: 1692
		double HueAmount { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600069D RID: 1693
		// (set) Token: 0x0600069E RID: 1694
		double SaturationChange { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600069F RID: 1695
		// (set) Token: 0x060006A0 RID: 1696
		double LuminosityChange { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060006A1 RID: 1697
		// (set) Token: 0x060006A2 RID: 1698
		double WavePhase { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060006A3 RID: 1699
		// (set) Token: 0x060006A4 RID: 1700
		double NumWaves { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060006A5 RID: 1701
		// (set) Token: 0x060006A6 RID: 1702
		double WaveSize { get; set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060006A7 RID: 1703
		// (set) Token: 0x060006A8 RID: 1704
		float Time { get; set; }

		// Token: 0x060006A9 RID: 1705
		void Render(Rectanglei bounds);
	}
}
