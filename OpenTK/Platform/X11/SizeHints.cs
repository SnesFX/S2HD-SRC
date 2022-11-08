using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000117 RID: 279
	internal struct SizeHints
	{
		// Token: 0x040009D0 RID: 2512
		public long flags;

		// Token: 0x040009D1 RID: 2513
		public int x;

		// Token: 0x040009D2 RID: 2514
		public int y;

		// Token: 0x040009D3 RID: 2515
		public int width;

		// Token: 0x040009D4 RID: 2516
		public int height;

		// Token: 0x040009D5 RID: 2517
		public int min_width;

		// Token: 0x040009D6 RID: 2518
		public int min_height;

		// Token: 0x040009D7 RID: 2519
		public int max_width;

		// Token: 0x040009D8 RID: 2520
		public int max_height;

		// Token: 0x040009D9 RID: 2521
		public int width_inc;

		// Token: 0x040009DA RID: 2522
		public int height_inc;

		// Token: 0x040009DB RID: 2523
		public SizeHints.Rectangle min_aspect;

		// Token: 0x040009DC RID: 2524
		public SizeHints.Rectangle max_aspect;

		// Token: 0x040009DD RID: 2525
		public int base_width;

		// Token: 0x040009DE RID: 2526
		public int base_height;

		// Token: 0x040009DF RID: 2527
		public int win_gravity;

		// Token: 0x02000118 RID: 280
		internal struct Rectangle
		{
			// Token: 0x06000A93 RID: 2707 RVA: 0x00020E08 File Offset: 0x0001F008
			private void stop_the_compiler_warnings()
			{
				this.x = (this.y = 0);
			}

			// Token: 0x040009E0 RID: 2528
			public int x;

			// Token: 0x040009E1 RID: 2529
			public int y;
		}
	}
}
