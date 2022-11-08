using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000041 RID: 65
	internal class ChunkPredicateId : ChunkPredicate
	{
		// Token: 0x0600022C RID: 556 RVA: 0x000095F8 File Offset: 0x000077F8
		public ChunkPredicateId(string id)
		{
			this.id = id;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00009607 File Offset: 0x00007807
		public bool Matches(PngChunk c)
		{
			return c.Id.Equals(this.id);
		}

		// Token: 0x04000111 RID: 273
		private readonly string id;
	}
}
