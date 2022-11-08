using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200003C RID: 60
	public class ChunkCopyBehaviour
	{
		// Token: 0x040000EC RID: 236
		public static readonly int COPY_NONE = 0;

		// Token: 0x040000ED RID: 237
		public static readonly int COPY_PALETTE = 1;

		// Token: 0x040000EE RID: 238
		public static readonly int COPY_ALL_SAFE = 4;

		// Token: 0x040000EF RID: 239
		public static readonly int COPY_ALL = 8;

		// Token: 0x040000F0 RID: 240
		public static readonly int COPY_PHYS = 16;

		// Token: 0x040000F1 RID: 241
		public static readonly int COPY_TEXTUAL = 32;

		// Token: 0x040000F2 RID: 242
		public static readonly int COPY_TRANSPARENCY = 64;

		// Token: 0x040000F3 RID: 243
		public static readonly int COPY_UNKNOWN = 128;

		// Token: 0x040000F4 RID: 244
		public static readonly int COPY_ALMOSTALL = 256;
	}
}
