using System;

namespace SonicOrca.Core
{
	// Token: 0x0200011F RID: 287
	public class LayerRowDefinition
	{
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x000297FB File Offset: 0x000279FB
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x00029803 File Offset: 0x00027A03
		public int Width { get; set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x0002980C File Offset: 0x00027A0C
		// (set) Token: 0x06000AA3 RID: 2723 RVA: 0x00029814 File Offset: 0x00027A14
		public int Height { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x0002981D File Offset: 0x00027A1D
		// (set) Token: 0x06000AA5 RID: 2725 RVA: 0x00029825 File Offset: 0x00027A25
		public int InitialOffset { get; set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x0002982E File Offset: 0x00027A2E
		// (set) Token: 0x06000AA7 RID: 2727 RVA: 0x00029836 File Offset: 0x00027A36
		public double CurrentOffset { get; set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x0002983F File Offset: 0x00027A3F
		// (set) Token: 0x06000AA9 RID: 2729 RVA: 0x00029847 File Offset: 0x00027A47
		public double Parallax { get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x00029850 File Offset: 0x00027A50
		// (set) Token: 0x06000AAB RID: 2731 RVA: 0x00029858 File Offset: 0x00027A58
		public double Velocity { get; set; }

		// Token: 0x06000AAC RID: 2732 RVA: 0x00029861 File Offset: 0x00027A61
		public LayerRowDefinition()
		{
			this.Parallax = 1.0;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00029878 File Offset: 0x00027A78
		public void Animate()
		{
			this.CurrentOffset += this.Velocity;
		}
	}
}
