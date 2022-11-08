using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000052 RID: 82
	public class PngChunkPHYS : PngChunkSingle
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000B1B7 File Offset: 0x000093B7
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0000B1BF File Offset: 0x000093BF
		public long PixelsxUnitX { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000B1C8 File Offset: 0x000093C8
		// (set) Token: 0x060002CC RID: 716 RVA: 0x0000B1D0 File Offset: 0x000093D0
		public long PixelsxUnitY { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002CD RID: 717 RVA: 0x0000B1D9 File Offset: 0x000093D9
		// (set) Token: 0x060002CE RID: 718 RVA: 0x0000B1E1 File Offset: 0x000093E1
		public int Units { get; set; }

		// Token: 0x060002CF RID: 719 RVA: 0x0000B1EA File Offset: 0x000093EA
		public PngChunkPHYS(ImageInfo info) : base("pHYs", info)
		{
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000B057 File Offset: 0x00009257
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_IDAT;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000B1F8 File Offset: 0x000093F8
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(9, true);
			PngHelperInternal.WriteInt4tobytes((int)this.PixelsxUnitX, chunkRaw.Data, 0);
			PngHelperInternal.WriteInt4tobytes((int)this.PixelsxUnitY, chunkRaw.Data, 4);
			chunkRaw.Data[8] = (byte)this.Units;
			return chunkRaw;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B248 File Offset: 0x00009448
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkPHYS pngChunkPHYS = (PngChunkPHYS)other;
			this.PixelsxUnitX = pngChunkPHYS.PixelsxUnitX;
			this.PixelsxUnitY = pngChunkPHYS.PixelsxUnitY;
			this.Units = pngChunkPHYS.Units;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B280 File Offset: 0x00009480
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			if (chunk.Length != 9)
			{
				throw new PngjException("bad chunk length " + chunk);
			}
			this.PixelsxUnitX = (long)PngHelperInternal.ReadInt4fromBytes(chunk.Data, 0);
			if (this.PixelsxUnitX < 0L)
			{
				this.PixelsxUnitX += 4294967296L;
			}
			this.PixelsxUnitY = (long)PngHelperInternal.ReadInt4fromBytes(chunk.Data, 4);
			if (this.PixelsxUnitY < 0L)
			{
				this.PixelsxUnitY += 4294967296L;
			}
			this.Units = PngHelperInternal.ReadInt1fromByte(chunk.Data, 8);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B320 File Offset: 0x00009520
		public double GetAsDpi()
		{
			if (this.Units != 1 || this.PixelsxUnitX != this.PixelsxUnitY)
			{
				return -1.0;
			}
			return (double)this.PixelsxUnitX * 0.0254;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000B354 File Offset: 0x00009554
		public double[] GetAsDpi2()
		{
			if (this.Units != 1)
			{
				return new double[]
				{
					-1.0,
					-1.0
				};
			}
			return new double[]
			{
				(double)this.PixelsxUnitX * 0.0254,
				(double)this.PixelsxUnitY * 0.0254
			};
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B3B7 File Offset: 0x000095B7
		public void SetAsDpi(double dpi)
		{
			this.Units = 1;
			this.PixelsxUnitX = (long)(dpi / 0.0254 + 0.5);
			this.PixelsxUnitY = this.PixelsxUnitX;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000B3E8 File Offset: 0x000095E8
		public void SetAsDpi2(double dpix, double dpiy)
		{
			this.Units = 1;
			this.PixelsxUnitX = (long)(dpix / 0.0254 + 0.5);
			this.PixelsxUnitY = (long)(dpiy / 0.0254 + 0.5);
		}

		// Token: 0x04000155 RID: 341
		public const string ID = "pHYs";
	}
}
