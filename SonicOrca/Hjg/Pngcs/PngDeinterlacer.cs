using System;

namespace Hjg.Pngcs
{
	// Token: 0x02000026 RID: 38
	internal class PngDeinterlacer
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00005844 File Offset: 0x00003A44
		internal PngDeinterlacer(ImageInfo iminfo)
		{
			this.imi = iminfo;
			this.pass = 0;
			if (this.imi.Packed)
			{
				this.packedValsPerPixel = 8 / this.imi.BitDepth;
				this.packedShift = this.imi.BitDepth;
				if (this.imi.BitDepth == 1)
				{
					this.packedMask = 128;
				}
				else if (this.imi.BitDepth == 2)
				{
					this.packedMask = 192;
				}
				else
				{
					this.packedMask = 240;
				}
			}
			else
			{
				this.packedMask = (this.packedShift = (this.packedValsPerPixel = 1));
			}
			this.setPass(1);
			this.setRow(0);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005910 File Offset: 0x00003B10
		internal void setRow(int n)
		{
			this.currRowSubimg = n;
			this.currRowReal = n * this.dY + this.oY;
			if (this.currRowReal < 0 || this.currRowReal >= this.imi.Rows)
			{
				throw new PngjExceptionInternal("bad row - this should not happen");
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005960 File Offset: 0x00003B60
		internal void setPass(int p)
		{
			if (this.pass == p)
			{
				return;
			}
			this.pass = p;
			switch (this.pass)
			{
			case 1:
				this.dY = (this.dX = 8);
				this.oX = (this.oY = 0);
				break;
			case 2:
				this.dY = (this.dX = 8);
				this.oX = 4;
				this.oY = 0;
				break;
			case 3:
				this.dX = 4;
				this.dY = 8;
				this.oX = 0;
				this.oY = 4;
				break;
			case 4:
				this.dX = (this.dY = 4);
				this.oX = 2;
				this.oY = 0;
				break;
			case 5:
				this.dX = 2;
				this.dY = 4;
				this.oX = 0;
				this.oY = 2;
				break;
			case 6:
				this.dX = (this.dY = 2);
				this.oX = 1;
				this.oY = 0;
				break;
			case 7:
				this.dX = 1;
				this.dY = 2;
				this.oX = 0;
				this.oY = 1;
				break;
			default:
				throw new PngjExceptionInternal("bad interlace pass" + this.pass);
			}
			this.rows = (this.imi.Rows - this.oY) / this.dY + 1;
			if ((this.rows - 1) * this.dY + this.oY >= this.imi.Rows)
			{
				this.rows--;
			}
			this.cols = (this.imi.Cols - this.oX) / this.dX + 1;
			if ((this.cols - 1) * this.dX + this.oX >= this.imi.Cols)
			{
				this.cols--;
			}
			if (this.cols == 0)
			{
				this.rows = 0;
			}
			this.dXsamples = this.dX * this.imi.Channels;
			this.oXsamples = this.oX * this.imi.Channels;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005B94 File Offset: 0x00003D94
		internal void deinterlaceInt(int[] src, int[] dst, bool readInPackedFormat)
		{
			if (!this.imi.Packed || !readInPackedFormat)
			{
				int i = 0;
				int num = this.oXsamples;
				while (i < this.cols * this.imi.Channels)
				{
					for (int j = 0; j < this.imi.Channels; j++)
					{
						dst[num + j] = src[i + j];
					}
					i += this.imi.Channels;
					num += this.dXsamples;
				}
				return;
			}
			this.deinterlaceIntPacked(src, dst);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005C10 File Offset: 0x00003E10
		private void deinterlaceIntPacked(int[] src, int[] dst)
		{
			int num = this.packedMask;
			int num2 = -1;
			int i = 0;
			int num3 = this.oX;
			while (i < this.cols)
			{
				int num4 = i / this.packedValsPerPixel;
				num2++;
				if (num2 >= this.packedValsPerPixel)
				{
					num2 = 0;
				}
				num >>= this.packedShift;
				if (num2 == 0)
				{
					num = this.packedMask;
				}
				int num5 = num3 / this.packedValsPerPixel;
				int num6 = num3 % this.packedValsPerPixel;
				int num7 = src[num4] & num;
				int num8 = num6 - num2;
				if (num8 > 0)
				{
					num7 >>= num8 * this.packedShift;
				}
				else if (num8 < 0)
				{
					num7 <<= -num8 * this.packedShift;
				}
				dst[num5] |= num7;
				i++;
				num3 += this.dX;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005CE0 File Offset: 0x00003EE0
		internal void deinterlaceByte(byte[] src, byte[] dst, bool readInPackedFormat)
		{
			if (!this.imi.Packed || !readInPackedFormat)
			{
				int i = 0;
				int num = this.oXsamples;
				while (i < this.cols * this.imi.Channels)
				{
					for (int j = 0; j < this.imi.Channels; j++)
					{
						dst[num + j] = src[i + j];
					}
					i += this.imi.Channels;
					num += this.dXsamples;
				}
				return;
			}
			this.deinterlacePackedByte(src, dst);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005D5C File Offset: 0x00003F5C
		private void deinterlacePackedByte(byte[] src, byte[] dst)
		{
			int num = this.packedMask;
			int num2 = -1;
			int i = 0;
			int num3 = this.oX;
			while (i < this.cols)
			{
				int num4 = i / this.packedValsPerPixel;
				num2++;
				if (num2 >= this.packedValsPerPixel)
				{
					num2 = 0;
				}
				num >>= this.packedShift;
				if (num2 == 0)
				{
					num = this.packedMask;
				}
				int num5 = num3 / this.packedValsPerPixel;
				int num6 = num3 % this.packedValsPerPixel;
				int num7 = (int)src[num4] & num;
				int num8 = num6 - num2;
				if (num8 > 0)
				{
					num7 >>= num8 * this.packedShift;
				}
				else if (num8 < 0)
				{
					num7 <<= -num8 * this.packedShift;
				}
				int num9 = num5;
				dst[num9] |= (byte)num7;
				i++;
				num3 += this.dX;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005E2D File Offset: 0x0000402D
		internal bool isAtLastRow()
		{
			return this.pass == 7 && this.currRowSubimg == this.rows - 1;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005E4A File Offset: 0x0000404A
		internal int getCurrRowSubimg()
		{
			return this.currRowSubimg;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005E52 File Offset: 0x00004052
		internal int getCurrRowReal()
		{
			return this.currRowReal;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00005E5A File Offset: 0x0000405A
		internal int getPass()
		{
			return this.pass;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005E62 File Offset: 0x00004062
		internal int getRows()
		{
			return this.rows;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005E6A File Offset: 0x0000406A
		internal int getCols()
		{
			return this.cols;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005E72 File Offset: 0x00004072
		internal int getPixelsToRead()
		{
			return this.getCols();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005E7A File Offset: 0x0000407A
		internal int[][] getImageInt()
		{
			return this.imageInt;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005E82 File Offset: 0x00004082
		internal void setImageInt(int[][] imageInt)
		{
			this.imageInt = imageInt;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005E8B File Offset: 0x0000408B
		internal byte[][] getImageByte()
		{
			return this.imageByte;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00005E93 File Offset: 0x00004093
		internal void setImageByte(byte[][] imageByte)
		{
			this.imageByte = imageByte;
		}

		// Token: 0x0400006F RID: 111
		private readonly ImageInfo imi;

		// Token: 0x04000070 RID: 112
		private int pass;

		// Token: 0x04000071 RID: 113
		private int rows;

		// Token: 0x04000072 RID: 114
		private int cols;

		// Token: 0x04000073 RID: 115
		private int dY;

		// Token: 0x04000074 RID: 116
		private int dX;

		// Token: 0x04000075 RID: 117
		private int oY;

		// Token: 0x04000076 RID: 118
		private int oX;

		// Token: 0x04000077 RID: 119
		private int oXsamples;

		// Token: 0x04000078 RID: 120
		private int dXsamples;

		// Token: 0x04000079 RID: 121
		private int currRowSubimg = -1;

		// Token: 0x0400007A RID: 122
		private int currRowReal = -1;

		// Token: 0x0400007B RID: 123
		private readonly int packedValsPerPixel;

		// Token: 0x0400007C RID: 124
		private readonly int packedMask;

		// Token: 0x0400007D RID: 125
		private readonly int packedShift;

		// Token: 0x0400007E RID: 126
		private int[][] imageInt;

		// Token: 0x0400007F RID: 127
		private byte[][] imageByte;
	}
}
