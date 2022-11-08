using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004A RID: 74
	public class PngChunkHIST : PngChunkSingle
	{
		// Token: 0x06000283 RID: 643 RVA: 0x0000A82A File Offset: 0x00008A2A
		public PngChunkHIST(ImageInfo info) : base(PngChunkHIST.ID, info)
		{
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000A201 File Offset: 0x00008401
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000A844 File Offset: 0x00008A44
		public override ChunkRaw CreateRawChunk()
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed images accept a HIST chunk");
			}
			ChunkRaw chunkRaw = base.createEmptyChunk(this.hist.Length * 2, true);
			for (int i = 0; i < this.hist.Length; i++)
			{
				PngHelperInternal.WriteInt2tobytes(this.hist[i], chunkRaw.Data, i * 2);
			}
			return chunkRaw;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000A8A8 File Offset: 0x00008AA8
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed images accept a HIST chunk");
			}
			int num = c.Data.Length / 2;
			this.hist = new int[num];
			for (int i = 0; i < this.hist.Length; i++)
			{
				this.hist[i] = PngHelperInternal.ReadInt2fromBytes(c.Data, i * 2);
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000A910 File Offset: 0x00008B10
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkHIST pngChunkHIST = (PngChunkHIST)other;
			this.hist = new int[pngChunkHIST.hist.Length];
			Array.Copy(pngChunkHIST.hist, 0, this.hist, 0, pngChunkHIST.hist.Length);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000A952 File Offset: 0x00008B52
		public int[] GetHist()
		{
			return this.hist;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000A95A File Offset: 0x00008B5A
		public void SetHist(int[] hist)
		{
			this.hist = hist;
		}

		// Token: 0x0400013E RID: 318
		public static readonly string ID = "hIST";

		// Token: 0x0400013F RID: 319
		private int[] hist = new int[0];
	}
}
