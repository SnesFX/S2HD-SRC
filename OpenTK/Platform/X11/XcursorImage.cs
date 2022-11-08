using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000111 RID: 273
	internal struct XcursorImage
	{
		// Token: 0x040009A6 RID: 2470
		public uint version;

		// Token: 0x040009A7 RID: 2471
		public uint size;

		// Token: 0x040009A8 RID: 2472
		public uint width;

		// Token: 0x040009A9 RID: 2473
		public uint height;

		// Token: 0x040009AA RID: 2474
		public uint xhot;

		// Token: 0x040009AB RID: 2475
		public uint yhot;

		// Token: 0x040009AC RID: 2476
		public uint delay;

		// Token: 0x040009AD RID: 2477
		public unsafe uint* pixels;
	}
}
