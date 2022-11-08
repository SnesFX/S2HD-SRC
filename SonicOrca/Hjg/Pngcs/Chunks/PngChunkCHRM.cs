using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000048 RID: 72
	public class PngChunkCHRM : PngChunkSingle
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000A48F File Offset: 0x0000868F
		public PngChunkCHRM(ImageInfo info) : base("cHRM", info)
		{
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A201 File Offset: 0x00008401
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A4A0 File Offset: 0x000086A0
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(32, true);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.whitex), chunkRaw.Data, 0);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.whitey), chunkRaw.Data, 4);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.redx), chunkRaw.Data, 8);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.redy), chunkRaw.Data, 12);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.greenx), chunkRaw.Data, 16);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.greeny), chunkRaw.Data, 20);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.bluex), chunkRaw.Data, 24);
			PngHelperInternal.WriteInt4tobytes(PngHelperInternal.DoubleToInt100000(this.bluey), chunkRaw.Data, 28);
			return chunkRaw;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A578 File Offset: 0x00008778
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (c.Length != 32)
			{
				throw new PngjException("bad chunk " + c);
			}
			this.whitex = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 0));
			this.whitey = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 4));
			this.redx = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 8));
			this.redy = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 12));
			this.greenx = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 16));
			this.greeny = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 20));
			this.bluex = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 24));
			this.bluey = PngHelperInternal.IntToDouble100000(PngHelperInternal.ReadInt4fromBytes(c.Data, 28));
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000A660 File Offset: 0x00008860
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkCHRM pngChunkCHRM = (PngChunkCHRM)other;
			this.whitex = pngChunkCHRM.whitex;
			this.whitey = pngChunkCHRM.whitex;
			this.redx = pngChunkCHRM.redx;
			this.redy = pngChunkCHRM.redy;
			this.greenx = pngChunkCHRM.greenx;
			this.greeny = pngChunkCHRM.greeny;
			this.bluex = pngChunkCHRM.bluex;
			this.bluey = pngChunkCHRM.bluey;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A6D4 File Offset: 0x000088D4
		public void SetChromaticities(double whitex, double whitey, double redx, double redy, double greenx, double greeny, double bluex, double bluey)
		{
			this.whitex = whitex;
			this.redx = redx;
			this.greenx = greenx;
			this.bluex = bluex;
			this.whitey = whitey;
			this.redy = redy;
			this.greeny = greeny;
			this.bluey = bluey;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000A714 File Offset: 0x00008914
		public double[] GetChromaticities()
		{
			return new double[]
			{
				this.whitex,
				this.whitey,
				this.redx,
				this.redy,
				this.greenx,
				this.greeny,
				this.bluex,
				this.bluey
			};
		}

		// Token: 0x04000133 RID: 307
		public const string ID = "cHRM";

		// Token: 0x04000134 RID: 308
		private double whitex;

		// Token: 0x04000135 RID: 309
		private double whitey;

		// Token: 0x04000136 RID: 310
		private double redx;

		// Token: 0x04000137 RID: 311
		private double redy;

		// Token: 0x04000138 RID: 312
		private double greenx;

		// Token: 0x04000139 RID: 313
		private double greeny;

		// Token: 0x0400013A RID: 314
		private double bluex;

		// Token: 0x0400013B RID: 315
		private double bluey;
	}
}
