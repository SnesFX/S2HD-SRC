using System;

namespace Hjg.Pngcs
{
	// Token: 0x02000024 RID: 36
	public class ImageLines
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000553B File Offset: 0x0000373B
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00005543 File Offset: 0x00003743
		public ImageInfo ImgInfo { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000554C File Offset: 0x0000374C
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00005554 File Offset: 0x00003754
		public ImageLine.ESampleType sampleType { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000555D File Offset: 0x0000375D
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00005565 File Offset: 0x00003765
		public bool SamplesUnpacked { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000556E File Offset: 0x0000376E
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00005576 File Offset: 0x00003776
		public int RowOffset { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000FC RID: 252 RVA: 0x0000557F File Offset: 0x0000377F
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00005587 File Offset: 0x00003787
		public int Nrows { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00005590 File Offset: 0x00003790
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00005598 File Offset: 0x00003798
		public int RowStep { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000100 RID: 256 RVA: 0x000055A1 File Offset: 0x000037A1
		// (set) Token: 0x06000101 RID: 257 RVA: 0x000055A9 File Offset: 0x000037A9
		public int[][] Scanlines { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000102 RID: 258 RVA: 0x000055B2 File Offset: 0x000037B2
		// (set) Token: 0x06000103 RID: 259 RVA: 0x000055BA File Offset: 0x000037BA
		public byte[][] ScanlinesB { get; private set; }

		// Token: 0x06000104 RID: 260 RVA: 0x000055C4 File Offset: 0x000037C4
		public ImageLines(ImageInfo ImgInfo, ImageLine.ESampleType sampleType, bool unpackedMode, int rowOffset, int nRows, int rowStep)
		{
			this.ImgInfo = ImgInfo;
			this.channels = ImgInfo.Channels;
			this.bitDepth = ImgInfo.BitDepth;
			this.sampleType = sampleType;
			this.SamplesUnpacked = (unpackedMode || !ImgInfo.Packed);
			this.RowOffset = rowOffset;
			this.Nrows = nRows;
			this.RowStep = rowStep;
			this.elementsPerRow = (unpackedMode ? ImgInfo.SamplesPerRow : ImgInfo.SamplesPerRowPacked);
			if (sampleType == ImageLine.ESampleType.INT)
			{
				this.Scanlines = new int[nRows][];
				for (int i = 0; i < nRows; i++)
				{
					this.Scanlines[i] = new int[this.elementsPerRow];
				}
				this.ScanlinesB = null;
				return;
			}
			if (sampleType == ImageLine.ESampleType.BYTE)
			{
				this.ScanlinesB = new byte[nRows][];
				for (int j = 0; j < nRows; j++)
				{
					this.ScanlinesB[j] = new byte[this.elementsPerRow];
				}
				this.Scanlines = null;
				return;
			}
			throw new PngjExceptionInternal("bad ImageLine initialization");
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000056BC File Offset: 0x000038BC
		public int ImageRowToMatrixRow(int imrow)
		{
			int num = (imrow - this.RowOffset) / this.RowStep;
			if (num < 0)
			{
				return 0;
			}
			if (num >= this.Nrows)
			{
				return this.Nrows - 1;
			}
			return num;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000056F4 File Offset: 0x000038F4
		public int ImageRowToMatrixRowStrict(int imrow)
		{
			imrow -= this.RowOffset;
			int num = (imrow >= 0 && imrow % this.RowStep == 0) ? (imrow / this.RowStep) : -1;
			if (num >= this.Nrows)
			{
				return -1;
			}
			return num;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005731 File Offset: 0x00003931
		public int MatrixRowToImageRow(int mrow)
		{
			return mrow * this.RowStep + this.RowOffset;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005744 File Offset: 0x00003944
		public ImageLine GetImageLineAtMatrixRow(int mrow)
		{
			if (mrow < 0 || mrow > this.Nrows)
			{
				throw new PngjException(string.Concat(new object[]
				{
					"Bad row ",
					mrow,
					". Should be positive and less than ",
					this.Nrows
				}));
			}
			ImageLine imageLine = (this.sampleType == ImageLine.ESampleType.INT) ? new ImageLine(this.ImgInfo, this.sampleType, this.SamplesUnpacked, this.Scanlines[mrow], null) : new ImageLine(this.ImgInfo, this.sampleType, this.SamplesUnpacked, null, this.ScanlinesB[mrow]);
			imageLine.Rown = this.MatrixRowToImageRow(mrow);
			return imageLine;
		}

		// Token: 0x0400006A RID: 106
		internal readonly int channels;

		// Token: 0x0400006B RID: 107
		internal readonly int bitDepth;

		// Token: 0x0400006C RID: 108
		internal readonly int elementsPerRow;
	}
}
