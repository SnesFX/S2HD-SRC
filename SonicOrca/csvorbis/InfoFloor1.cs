using System;

namespace csvorbis
{
	// Token: 0x02000070 RID: 112
	internal class InfoFloor1
	{
		// Token: 0x060003C2 RID: 962 RVA: 0x00011D04 File Offset: 0x0000FF04
		internal InfoFloor1()
		{
			for (int i = 0; i < this.class_subbook.Length; i++)
			{
				this.class_subbook[i] = new int[8];
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00011D86 File Offset: 0x0000FF86
		internal void free()
		{
			this.partitionclass = null;
			this.class_dim = null;
			this.class_subs = null;
			this.class_book = null;
			this.class_subbook = null;
			this.postlist = null;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		internal object copy_info()
		{
			InfoFloor1 infoFloor = new InfoFloor1();
			infoFloor.partitions = this.partitions;
			Array.Copy(this.partitionclass, 0, infoFloor.partitionclass, 0, 31);
			Array.Copy(this.class_dim, 0, infoFloor.class_dim, 0, 16);
			Array.Copy(this.class_subs, 0, infoFloor.class_subs, 0, 16);
			Array.Copy(this.class_book, 0, infoFloor.class_book, 0, 16);
			for (int i = 0; i < 16; i++)
			{
				Array.Copy(this.class_subbook[i], 0, infoFloor.class_subbook[i], 0, 8);
			}
			infoFloor.mult = this.mult;
			Array.Copy(this.postlist, 0, infoFloor.postlist, 0, 65);
			infoFloor.maxover = this.maxover;
			infoFloor.maxunder = this.maxunder;
			infoFloor.maxerr = this.maxerr;
			infoFloor.twofitminsize = this.twofitminsize;
			infoFloor.twofitminused = this.twofitminused;
			infoFloor.twofitweight = this.twofitweight;
			infoFloor.twofitatten = this.twofitatten;
			infoFloor.unusedminsize = this.unusedminsize;
			infoFloor.unusedmin_n = this.unusedmin_n;
			infoFloor.n = this.n;
			return infoFloor;
		}

		// Token: 0x040001F4 RID: 500
		private const int VIF_POSIT = 63;

		// Token: 0x040001F5 RID: 501
		private const int VIF_CLASS = 16;

		// Token: 0x040001F6 RID: 502
		private const int VIF_PARTS = 31;

		// Token: 0x040001F7 RID: 503
		internal int partitions;

		// Token: 0x040001F8 RID: 504
		internal int[] partitionclass = new int[31];

		// Token: 0x040001F9 RID: 505
		internal int[] class_dim = new int[16];

		// Token: 0x040001FA RID: 506
		internal int[] class_subs = new int[16];

		// Token: 0x040001FB RID: 507
		internal int[] class_book = new int[16];

		// Token: 0x040001FC RID: 508
		internal int[][] class_subbook = new int[16][];

		// Token: 0x040001FD RID: 509
		internal int mult;

		// Token: 0x040001FE RID: 510
		internal int[] postlist = new int[65];

		// Token: 0x040001FF RID: 511
		internal float maxover;

		// Token: 0x04000200 RID: 512
		internal float maxunder;

		// Token: 0x04000201 RID: 513
		internal float maxerr;

		// Token: 0x04000202 RID: 514
		internal int twofitminsize;

		// Token: 0x04000203 RID: 515
		internal int twofitminused;

		// Token: 0x04000204 RID: 516
		internal int twofitweight;

		// Token: 0x04000205 RID: 517
		internal float twofitatten;

		// Token: 0x04000206 RID: 518
		internal int unusedminsize;

		// Token: 0x04000207 RID: 519
		internal int unusedmin_n;

		// Token: 0x04000208 RID: 520
		internal int n;
	}
}
