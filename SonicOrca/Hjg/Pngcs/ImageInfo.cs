using System;

namespace Hjg.Pngcs
{
	// Token: 0x02000021 RID: 33
	public class ImageInfo
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00004463 File Offset: 0x00002663
		public ImageInfo(int cols, int rows, int bitdepth, bool alpha) : this(cols, rows, bitdepth, alpha, false, false)
		{
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004474 File Offset: 0x00002674
		public ImageInfo(int cols, int rows, int bitdepth, bool alpha, bool grayscale, bool palette)
		{
			this.Cols = cols;
			this.Rows = rows;
			this.Alpha = alpha;
			this.Indexed = palette;
			this.Greyscale = grayscale;
			if (this.Greyscale && palette)
			{
				throw new PngjException("palette and greyscale are exclusive");
			}
			this.Channels = ((grayscale || palette) ? (alpha ? 2 : 1) : (alpha ? 4 : 3));
			this.BitDepth = bitdepth;
			this.Packed = (bitdepth < 8);
			this.BitspPixel = this.Channels * this.BitDepth;
			this.BytesPixel = (this.BitspPixel + 7) / 8;
			this.BytesPerRow = (this.BitspPixel * cols + 7) / 8;
			this.SamplesPerRow = this.Channels * this.Cols;
			this.SamplesPerRowPacked = (this.Packed ? this.BytesPerRow : this.SamplesPerRow);
			int bitDepth = this.BitDepth;
			if (bitDepth <= 4)
			{
				if (bitDepth - 1 <= 1 || bitDepth == 4)
				{
					if (!this.Indexed && !this.Greyscale)
					{
						throw new PngjException("only indexed or grayscale can have bitdepth=" + this.BitDepth);
					}
					goto IL_161;
				}
			}
			else
			{
				if (bitDepth == 8)
				{
					goto IL_161;
				}
				if (bitDepth == 16)
				{
					if (this.Indexed)
					{
						throw new PngjException("indexed can't have bitdepth=" + this.BitDepth);
					}
					goto IL_161;
				}
			}
			throw new PngjException("invalid bitdepth=" + this.BitDepth);
			IL_161:
			if (cols < 1 || cols > 400000)
			{
				throw new PngjException("invalid cols=" + cols + " ???");
			}
			if (rows < 1 || rows > 400000)
			{
				throw new PngjException("invalid rows=" + rows + " ???");
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004630 File Offset: 0x00002830
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"ImageInfo [cols=",
				this.Cols,
				", rows=",
				this.Rows,
				", bitDepth=",
				this.BitDepth,
				", channels=",
				this.Channels,
				", bitspPixel=",
				this.BitspPixel,
				", bytesPixel=",
				this.BytesPixel,
				", bytesPerRow=",
				this.BytesPerRow,
				", samplesPerRow=",
				this.SamplesPerRow,
				", samplesPerRowP=",
				this.SamplesPerRowPacked,
				", alpha=",
				this.Alpha.ToString(),
				", greyscale=",
				this.Greyscale.ToString(),
				", indexed=",
				this.Indexed.ToString(),
				", packed=",
				this.Packed.ToString(),
				"]"
			});
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004790 File Offset: 0x00002990
		public override int GetHashCode()
		{
			int num = 31;
			int num2 = 1;
			num2 = num * num2 + (this.Alpha ? 1231 : 1237);
			num2 = num * num2 + this.BitDepth;
			num2 = num * num2 + this.Channels;
			num2 = num * num2 + this.Cols;
			num2 = num * num2 + (this.Greyscale ? 1231 : 1237);
			num2 = num * num2 + (this.Indexed ? 1231 : 1237);
			return num * num2 + this.Rows;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004818 File Offset: 0x00002A18
		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj == null)
			{
				return false;
			}
			if (base.GetType() != obj.GetType())
			{
				return false;
			}
			ImageInfo imageInfo = (ImageInfo)obj;
			return this.Alpha == imageInfo.Alpha && this.BitDepth == imageInfo.BitDepth && this.Channels == imageInfo.Channels && this.Cols == imageInfo.Cols && this.Greyscale == imageInfo.Greyscale && this.Indexed == imageInfo.Indexed && this.Rows == imageInfo.Rows;
		}

		// Token: 0x0400004B RID: 75
		private const int MAX_COLS_ROWS_VAL = 400000;

		// Token: 0x0400004C RID: 76
		public readonly int Cols;

		// Token: 0x0400004D RID: 77
		public readonly int Rows;

		// Token: 0x0400004E RID: 78
		public readonly int BitDepth;

		// Token: 0x0400004F RID: 79
		public readonly int Channels;

		// Token: 0x04000050 RID: 80
		public readonly int BitspPixel;

		// Token: 0x04000051 RID: 81
		public readonly int BytesPixel;

		// Token: 0x04000052 RID: 82
		public readonly int BytesPerRow;

		// Token: 0x04000053 RID: 83
		public readonly int SamplesPerRow;

		// Token: 0x04000054 RID: 84
		public readonly int SamplesPerRowPacked;

		// Token: 0x04000055 RID: 85
		public readonly bool Alpha;

		// Token: 0x04000056 RID: 86
		public readonly bool Greyscale;

		// Token: 0x04000057 RID: 87
		public readonly bool Indexed;

		// Token: 0x04000058 RID: 88
		public readonly bool Packed;
	}
}
