using System;

namespace SonicOrca.Core
{
	// Token: 0x02000120 RID: 288
	public class LayerViewOptions
	{
		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000AAE RID: 2734 RVA: 0x0002988D File Offset: 0x00027A8D
		// (set) Token: 0x06000AAF RID: 2735 RVA: 0x00029895 File Offset: 0x00027A95
		public bool ShowLandscape { get; set; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x0002989E File Offset: 0x00027A9E
		// (set) Token: 0x06000AB1 RID: 2737 RVA: 0x000298A6 File Offset: 0x00027AA6
		public bool ShowObjects { get; set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x000298AF File Offset: 0x00027AAF
		// (set) Token: 0x06000AB3 RID: 2739 RVA: 0x000298B7 File Offset: 0x00027AB7
		public bool ShowMarkers { get; set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x000298C0 File Offset: 0x00027AC0
		// (set) Token: 0x06000AB5 RID: 2741 RVA: 0x000298C8 File Offset: 0x00027AC8
		public bool ShowWater { get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x000298D1 File Offset: 0x00027AD1
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x000298D9 File Offset: 0x00027AD9
		public bool ShowLandscapeCollision { get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x000298E2 File Offset: 0x00027AE2
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x000298EA File Offset: 0x00027AEA
		public bool ShowObjectCollision { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x000298F3 File Offset: 0x00027AF3
		// (set) Token: 0x06000ABB RID: 2747 RVA: 0x000298FB File Offset: 0x00027AFB
		public bool Shadows { get; set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00029904 File Offset: 0x00027B04
		// (set) Token: 0x06000ABD RID: 2749 RVA: 0x0002990C File Offset: 0x00027B0C
		public int Filter { get; set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x00029915 File Offset: 0x00027B15
		// (set) Token: 0x06000ABF RID: 2751 RVA: 0x0002991D File Offset: 0x00027B1D
		public double FilterAmount { get; set; }

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00029926 File Offset: 0x00027B26
		public LayerViewOptions()
		{
			this.ShowLandscape = true;
			this.ShowObjects = true;
			this.ShowWater = true;
		}
	}
}
