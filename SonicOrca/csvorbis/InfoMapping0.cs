using System;

namespace csvorbis
{
	// Token: 0x0200007E RID: 126
	internal class InfoMapping0
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x00013B9F File Offset: 0x00011D9F
		internal void free()
		{
			this.chmuxlist = null;
			this.timesubmap = null;
			this.floorsubmap = null;
			this.residuesubmap = null;
			this.psysubmap = null;
			this.coupling_mag = null;
			this.coupling_ang = null;
		}

		// Token: 0x04000251 RID: 593
		internal int submaps;

		// Token: 0x04000252 RID: 594
		internal int[] chmuxlist = new int[256];

		// Token: 0x04000253 RID: 595
		internal int[] timesubmap = new int[16];

		// Token: 0x04000254 RID: 596
		internal int[] floorsubmap = new int[16];

		// Token: 0x04000255 RID: 597
		internal int[] residuesubmap = new int[16];

		// Token: 0x04000256 RID: 598
		internal int[] psysubmap = new int[16];

		// Token: 0x04000257 RID: 599
		internal int coupling_steps;

		// Token: 0x04000258 RID: 600
		internal int[] coupling_mag = new int[256];

		// Token: 0x04000259 RID: 601
		internal int[] coupling_ang = new int[256];
	}
}
