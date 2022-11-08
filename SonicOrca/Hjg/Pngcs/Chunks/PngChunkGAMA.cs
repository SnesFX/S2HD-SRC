using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000049 RID: 73
	public class PngChunkGAMA : PngChunkSingle
	{
		// Token: 0x0600027C RID: 636 RVA: 0x0000A76F File Offset: 0x0000896F
		public PngChunkGAMA(ImageInfo info) : base("gAMA", info)
		{
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00006340 File Offset: 0x00004540
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A780 File Offset: 0x00008980
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(4, true);
			PngHelperInternal.WriteInt4tobytes((int)(this.gamma * 100000.0 + 0.5), chunkRaw.Data, 0);
			return chunkRaw;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000A7C0 File Offset: 0x000089C0
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			if (chunk.Length != 4)
			{
				throw new PngjException("bad chunk " + chunk);
			}
			int num = PngHelperInternal.ReadInt4fromBytes(chunk.Data, 0);
			this.gamma = (double)num / 100000.0;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000A806 File Offset: 0x00008A06
		public override void CloneDataFromRead(PngChunk other)
		{
			this.gamma = ((PngChunkGAMA)other).gamma;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000A819 File Offset: 0x00008A19
		public double GetGamma()
		{
			return this.gamma;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A821 File Offset: 0x00008A21
		public void SetGamma(double gamma)
		{
			this.gamma = gamma;
		}

		// Token: 0x0400013C RID: 316
		public const string ID = "gAMA";

		// Token: 0x0400013D RID: 317
		private double gamma;
	}
}
