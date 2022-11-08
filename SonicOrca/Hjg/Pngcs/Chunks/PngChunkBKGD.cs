using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000047 RID: 71
	public class PngChunkBKGD : PngChunkSingle
	{
		// Token: 0x0600026A RID: 618 RVA: 0x0000A1F3 File Offset: 0x000083F3
		public PngChunkBKGD(ImageInfo info) : base("bKGD", info)
		{
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000A201 File Offset: 0x00008401
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000A204 File Offset: 0x00008404
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw;
			if (this.ImgInfo.Greyscale)
			{
				chunkRaw = base.createEmptyChunk(2, true);
				PngHelperInternal.WriteInt2tobytes(this.gray, chunkRaw.Data, 0);
			}
			else if (this.ImgInfo.Indexed)
			{
				chunkRaw = base.createEmptyChunk(1, true);
				chunkRaw.Data[0] = (byte)this.paletteIndex;
			}
			else
			{
				chunkRaw = base.createEmptyChunk(6, true);
				PngHelperInternal.WriteInt2tobytes(this.red, chunkRaw.Data, 0);
				PngHelperInternal.WriteInt2tobytes(this.green, chunkRaw.Data, 0);
				PngHelperInternal.WriteInt2tobytes(this.blue, chunkRaw.Data, 0);
			}
			return chunkRaw;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A2A4 File Offset: 0x000084A4
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (this.ImgInfo.Greyscale)
			{
				this.gray = PngHelperInternal.ReadInt2fromBytes(c.Data, 0);
				return;
			}
			if (this.ImgInfo.Indexed)
			{
				this.paletteIndex = (int)(c.Data[0] & byte.MaxValue);
				return;
			}
			this.red = PngHelperInternal.ReadInt2fromBytes(c.Data, 0);
			this.green = PngHelperInternal.ReadInt2fromBytes(c.Data, 2);
			this.blue = PngHelperInternal.ReadInt2fromBytes(c.Data, 4);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000A32C File Offset: 0x0000852C
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkBKGD pngChunkBKGD = (PngChunkBKGD)other;
			this.gray = pngChunkBKGD.gray;
			this.red = pngChunkBKGD.red;
			this.green = pngChunkBKGD.red;
			this.blue = pngChunkBKGD.red;
			this.paletteIndex = pngChunkBKGD.paletteIndex;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000A37C File Offset: 0x0000857C
		public void SetGray(int gray)
		{
			if (!this.ImgInfo.Greyscale)
			{
				throw new PngjException("only gray images support this");
			}
			this.gray = gray;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000A39D File Offset: 0x0000859D
		public int GetGray()
		{
			if (!this.ImgInfo.Greyscale)
			{
				throw new PngjException("only gray images support this");
			}
			return this.gray;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A3BD File Offset: 0x000085BD
		public void SetPaletteIndex(int index)
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed (pallete) images support this");
			}
			this.paletteIndex = index;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A3DE File Offset: 0x000085DE
		public int GetPaletteIndex()
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed (pallete) images support this");
			}
			return this.paletteIndex;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A3FE File Offset: 0x000085FE
		public void SetRGB(int r, int g, int b)
		{
			if (this.ImgInfo.Greyscale || this.ImgInfo.Indexed)
			{
				throw new PngjException("only rgb or rgba images support this");
			}
			this.red = r;
			this.green = g;
			this.blue = b;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000A43C File Offset: 0x0000863C
		public int[] GetRGB()
		{
			if (this.ImgInfo.Greyscale || this.ImgInfo.Indexed)
			{
				throw new PngjException("only rgb or rgba images support this");
			}
			return new int[]
			{
				this.red,
				this.green,
				this.blue
			};
		}

		// Token: 0x0400012D RID: 301
		public const string ID = "bKGD";

		// Token: 0x0400012E RID: 302
		private int gray;

		// Token: 0x0400012F RID: 303
		private int red;

		// Token: 0x04000130 RID: 304
		private int green;

		// Token: 0x04000131 RID: 305
		private int blue;

		// Token: 0x04000132 RID: 306
		private int paletteIndex;
	}
}
