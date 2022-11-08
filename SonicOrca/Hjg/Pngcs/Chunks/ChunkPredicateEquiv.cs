using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000040 RID: 64
	internal class ChunkPredicateEquiv : ChunkPredicate
	{
		// Token: 0x0600022A RID: 554 RVA: 0x000095DB File Offset: 0x000077DB
		public ChunkPredicateEquiv(PngChunk chunk)
		{
			this.chunk = chunk;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000095EA File Offset: 0x000077EA
		public bool Matches(PngChunk c)
		{
			return ChunkHelper.Equivalent(c, this.chunk);
		}

		// Token: 0x04000110 RID: 272
		private readonly PngChunk chunk;
	}
}
