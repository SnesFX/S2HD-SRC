using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200003F RID: 63
	public interface ChunkPredicate
	{
		// Token: 0x06000229 RID: 553
		bool Matches(PngChunk chunk);
	}
}
