using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004D RID: 77
	public class PngChunkIEND : PngChunkSingle
	{
		// Token: 0x0600029A RID: 666 RVA: 0x0000AB5B File Offset: 0x00008D5B
		public PngChunkIEND(ImageInfo info) : base("IEND", info)
		{
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000AB55 File Offset: 0x00008D55
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NA;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000AB69 File Offset: 0x00008D69
		public override ChunkRaw CreateRawChunk()
		{
			return new ChunkRaw(0, ChunkHelper.b_IEND, false);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00006325 File Offset: 0x00004525
		public override void ParseFromRaw(ChunkRaw c)
		{
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00006325 File Offset: 0x00004525
		public override void CloneDataFromRead(PngChunk other)
		{
		}

		// Token: 0x04000144 RID: 324
		public const string ID = "IEND";
	}
}
