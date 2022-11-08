using System;

namespace csvorbis
{
	// Token: 0x02000071 RID: 113
	internal class LookFloor1
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x00011EE8 File Offset: 0x000100E8
		private void free()
		{
			this.sorted_index = null;
			this.forward_index = null;
			this.reverse_index = null;
			this.hineighbor = null;
			this.loneighbor = null;
		}

		// Token: 0x04000209 RID: 521
		private static int VIF_POSIT = 63;

		// Token: 0x0400020A RID: 522
		internal int[] sorted_index = new int[LookFloor1.VIF_POSIT + 2];

		// Token: 0x0400020B RID: 523
		internal int[] forward_index = new int[LookFloor1.VIF_POSIT + 2];

		// Token: 0x0400020C RID: 524
		internal int[] reverse_index = new int[LookFloor1.VIF_POSIT + 2];

		// Token: 0x0400020D RID: 525
		internal int[] hineighbor = new int[LookFloor1.VIF_POSIT];

		// Token: 0x0400020E RID: 526
		internal int[] loneighbor = new int[LookFloor1.VIF_POSIT];

		// Token: 0x0400020F RID: 527
		internal int posts;

		// Token: 0x04000210 RID: 528
		internal int n;

		// Token: 0x04000211 RID: 529
		internal int quant_q;

		// Token: 0x04000212 RID: 530
		internal InfoFloor1 vi;
	}
}
