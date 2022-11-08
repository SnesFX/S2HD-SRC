using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000056 RID: 86
	internal class PngChunkSkipped : PngChunk
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0000B8FA File Offset: 0x00009AFA
		internal PngChunkSkipped(string id, ImageInfo imgInfo, int clen) : base(id, imgInfo)
		{
			base.Length = clen;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00006340 File Offset: 0x00004540
		public sealed override bool AllowsMultiple()
		{
			return true;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000B90B File Offset: 0x00009B0B
		public sealed override ChunkRaw CreateRawChunk()
		{
			throw new PngjException("Non supported for a skipped chunk");
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000B90B File Offset: 0x00009B0B
		public sealed override void ParseFromRaw(ChunkRaw c)
		{
			throw new PngjException("Non supported for a skipped chunk");
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000B90B File Offset: 0x00009B0B
		public sealed override void CloneDataFromRead(PngChunk other)
		{
			throw new PngjException("Non supported for a skipped chunk");
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000225B File Offset: 0x0000045B
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NONE;
		}
	}
}
