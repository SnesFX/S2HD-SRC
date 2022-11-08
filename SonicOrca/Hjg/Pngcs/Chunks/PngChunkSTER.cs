using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000059 RID: 89
	public class PngChunkSTER : PngChunkSingle
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000BCC0 File Offset: 0x00009EC0
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0000BCC8 File Offset: 0x00009EC8
		public byte Mode { get; set; }

		// Token: 0x06000313 RID: 787 RVA: 0x0000BCD1 File Offset: 0x00009ED1
		public PngChunkSTER(ImageInfo info) : base("sTER", info)
		{
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000B057 File Offset: 0x00009257
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_IDAT;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000BCDF File Offset: 0x00009EDF
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(1, true);
			chunkRaw.Data[0] = this.Mode;
			return chunkRaw;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000BCF7 File Offset: 0x00009EF7
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			if (chunk.Length != 1)
			{
				throw new PngjException("bad chunk length " + chunk);
			}
			this.Mode = chunk.Data[0];
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000BD24 File Offset: 0x00009F24
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkSTER pngChunkSTER = (PngChunkSTER)other;
			this.Mode = pngChunkSTER.Mode;
		}

		// Token: 0x0400016C RID: 364
		public const string ID = "sTER";
	}
}
