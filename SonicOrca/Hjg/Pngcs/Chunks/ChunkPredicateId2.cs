using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000042 RID: 66
	internal class ChunkPredicateId2 : ChunkPredicate
	{
		// Token: 0x0600022E RID: 558 RVA: 0x0000961A File Offset: 0x0000781A
		public ChunkPredicateId2(string id, string inner)
		{
			this.id = id;
			this.innerid = inner;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00009630 File Offset: 0x00007830
		public bool Matches(PngChunk c)
		{
			return c.Id.Equals(this.id) && (!(c is PngChunkTextVar) || ((PngChunkTextVar)c).GetKey().Equals(this.innerid)) && (!(c is PngChunkSPLT) || ((PngChunkSPLT)c).PalName.Equals(this.innerid));
		}

		// Token: 0x04000112 RID: 274
		private readonly string id;

		// Token: 0x04000113 RID: 275
		private readonly string innerid;
	}
}
