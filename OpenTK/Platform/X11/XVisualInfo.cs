using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000115 RID: 277
	internal struct XVisualInfo
	{
		// Token: 0x06000A91 RID: 2705 RVA: 0x00020DA8 File Offset: 0x0001EFA8
		public override string ToString()
		{
			return string.Format("id ({0}), screen ({1}), depth ({2}), class ({3})", new object[]
			{
				this.VisualID,
				this.Screen,
				this.Depth,
				this.Class
			});
		}

		// Token: 0x040009B7 RID: 2487
		public IntPtr Visual;

		// Token: 0x040009B8 RID: 2488
		public IntPtr VisualID;

		// Token: 0x040009B9 RID: 2489
		public int Screen;

		// Token: 0x040009BA RID: 2490
		public int Depth;

		// Token: 0x040009BB RID: 2491
		public XVisualClass Class;

		// Token: 0x040009BC RID: 2492
		public long RedMask;

		// Token: 0x040009BD RID: 2493
		public long GreenMask;

		// Token: 0x040009BE RID: 2494
		public long blueMask;

		// Token: 0x040009BF RID: 2495
		public int ColormapSize;

		// Token: 0x040009C0 RID: 2496
		public int BitsPerRgb;
	}
}
