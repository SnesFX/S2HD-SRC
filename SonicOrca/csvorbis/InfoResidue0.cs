using System;

namespace csvorbis
{
	// Token: 0x02000085 RID: 133
	internal class InfoResidue0
	{
		// Token: 0x04000289 RID: 649
		internal int begin;

		// Token: 0x0400028A RID: 650
		internal int end;

		// Token: 0x0400028B RID: 651
		internal int grouping;

		// Token: 0x0400028C RID: 652
		internal int partitions;

		// Token: 0x0400028D RID: 653
		internal int groupbook;

		// Token: 0x0400028E RID: 654
		internal int[] secondstages = new int[64];

		// Token: 0x0400028F RID: 655
		internal int[] booklist = new int[256];

		// Token: 0x04000290 RID: 656
		internal float[] entmax = new float[64];

		// Token: 0x04000291 RID: 657
		internal float[] ampmax = new float[64];

		// Token: 0x04000292 RID: 658
		internal int[] subgrp = new int[64];

		// Token: 0x04000293 RID: 659
		internal int[] blimit = new int[64];
	}
}
