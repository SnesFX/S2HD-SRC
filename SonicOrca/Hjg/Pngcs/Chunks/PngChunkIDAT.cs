using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004C RID: 76
	public class PngChunkIDAT : PngChunkMultiple
	{
		// Token: 0x06000295 RID: 661 RVA: 0x0000AB39 File Offset: 0x00008D39
		public PngChunkIDAT(ImageInfo i, int len, long offset) : base("IDAT", i)
		{
			base.Length = len;
			base.Offset = offset;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000AB55 File Offset: 0x00008D55
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NA;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000AB58 File Offset: 0x00008D58
		public override ChunkRaw CreateRawChunk()
		{
			return null;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00006325 File Offset: 0x00004525
		public override void ParseFromRaw(ChunkRaw c)
		{
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00006325 File Offset: 0x00004525
		public override void CloneDataFromRead(PngChunk other)
		{
		}

		// Token: 0x04000143 RID: 323
		public const string ID = "IDAT";
	}
}
