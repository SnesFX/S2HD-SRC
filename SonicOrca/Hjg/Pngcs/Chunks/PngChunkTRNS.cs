using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005D RID: 93
	public class PngChunkTRNS : PngChunkSingle
	{
		// Token: 0x0600032A RID: 810 RVA: 0x0000C165 File Offset: 0x0000A365
		public PngChunkTRNS(ImageInfo info) : base("tRNS", info)
		{
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000A201 File Offset: 0x00008401
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000C174 File Offset: 0x0000A374
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
				chunkRaw = base.createEmptyChunk(this.paletteAlpha.Length, true);
				for (int i = 0; i < chunkRaw.Length; i++)
				{
					chunkRaw.Data[i] = (byte)this.paletteAlpha[i];
				}
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

		// Token: 0x0600032D RID: 813 RVA: 0x0000C234 File Offset: 0x0000A434
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (this.ImgInfo.Greyscale)
			{
				this.gray = PngHelperInternal.ReadInt2fromBytes(c.Data, 0);
				return;
			}
			if (this.ImgInfo.Indexed)
			{
				int num = c.Data.Length;
				this.paletteAlpha = new int[num];
				for (int i = 0; i < num; i++)
				{
					this.paletteAlpha[i] = (int)(c.Data[i] & byte.MaxValue);
				}
				return;
			}
			this.red = PngHelperInternal.ReadInt2fromBytes(c.Data, 0);
			this.green = PngHelperInternal.ReadInt2fromBytes(c.Data, 2);
			this.blue = PngHelperInternal.ReadInt2fromBytes(c.Data, 4);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000C2DC File Offset: 0x0000A4DC
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkTRNS pngChunkTRNS = (PngChunkTRNS)other;
			this.gray = pngChunkTRNS.gray;
			this.red = pngChunkTRNS.red;
			this.green = pngChunkTRNS.green;
			this.blue = pngChunkTRNS.blue;
			if (pngChunkTRNS.paletteAlpha != null)
			{
				this.paletteAlpha = new int[pngChunkTRNS.paletteAlpha.Length];
				Array.Copy(pngChunkTRNS.paletteAlpha, 0, this.paletteAlpha, 0, this.paletteAlpha.Length);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000C356 File Offset: 0x0000A556
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

		// Token: 0x06000330 RID: 816 RVA: 0x0000C394 File Offset: 0x0000A594
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

		// Token: 0x06000331 RID: 817 RVA: 0x0000C3E7 File Offset: 0x0000A5E7
		public void SetGray(int g)
		{
			if (!this.ImgInfo.Greyscale)
			{
				throw new PngjException("only grayscale images support this");
			}
			this.gray = g;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000C408 File Offset: 0x0000A608
		public int GetGray()
		{
			if (!this.ImgInfo.Greyscale)
			{
				throw new PngjException("only grayscale images support this");
			}
			return this.gray;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000C428 File Offset: 0x0000A628
		public void SetPalletteAlpha(int[] palAlpha)
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed images support this");
			}
			this.paletteAlpha = palAlpha;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000C44C File Offset: 0x0000A64C
		public void setIndexEntryAsTransparent(int palAlphaIndex)
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed images support this");
			}
			this.paletteAlpha = new int[]
			{
				palAlphaIndex + 1
			};
			for (int i = 0; i < palAlphaIndex; i++)
			{
				this.paletteAlpha[i] = 255;
			}
			this.paletteAlpha[palAlphaIndex] = 0;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000C4A5 File Offset: 0x0000A6A5
		public int[] GetPalletteAlpha()
		{
			if (!this.ImgInfo.Indexed)
			{
				throw new PngjException("only indexed images support this");
			}
			return this.paletteAlpha;
		}

		// Token: 0x04000182 RID: 386
		public const string ID = "tRNS";

		// Token: 0x04000183 RID: 387
		private int gray;

		// Token: 0x04000184 RID: 388
		private int red;

		// Token: 0x04000185 RID: 389
		private int green;

		// Token: 0x04000186 RID: 390
		private int blue;

		// Token: 0x04000187 RID: 391
		private int[] paletteAlpha;
	}
}
