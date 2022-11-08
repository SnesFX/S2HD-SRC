using System;

namespace Hjg.Pngcs
{
	// Token: 0x02000022 RID: 34
	public class ImageLine
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000048B8 File Offset: 0x00002AB8
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000048C0 File Offset: 0x00002AC0
		public ImageInfo ImgInfo { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000048C9 File Offset: 0x00002AC9
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000048D1 File Offset: 0x00002AD1
		public int[] Scanline { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000048DA File Offset: 0x00002ADA
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000048E2 File Offset: 0x00002AE2
		public byte[] ScanlineB { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000048EB File Offset: 0x00002AEB
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000048F3 File Offset: 0x00002AF3
		public int Rown { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000048FC File Offset: 0x00002AFC
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00004904 File Offset: 0x00002B04
		public int ElementsPerRow { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000490D File Offset: 0x00002B0D
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00004915 File Offset: 0x00002B15
		public int maxSampleVal { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000491E File Offset: 0x00002B1E
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00004926 File Offset: 0x00002B26
		public ImageLine.ESampleType SampleType { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000492F File Offset: 0x00002B2F
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00004937 File Offset: 0x00002B37
		public bool SamplesUnpacked { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004940 File Offset: 0x00002B40
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004948 File Offset: 0x00002B48
		public FilterType FilterUsed { get; set; }

		// Token: 0x060000C9 RID: 201 RVA: 0x00004951 File Offset: 0x00002B51
		public ImageLine(ImageInfo imgInfo) : this(imgInfo, ImageLine.ESampleType.INT, false)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000495C File Offset: 0x00002B5C
		public ImageLine(ImageInfo imgInfo, ImageLine.ESampleType stype) : this(imgInfo, stype, false)
		{
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004967 File Offset: 0x00002B67
		public ImageLine(ImageInfo imgInfo, ImageLine.ESampleType stype, bool unpackedMode) : this(imgInfo, stype, unpackedMode, null, null)
		{
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004974 File Offset: 0x00002B74
		internal ImageLine(ImageInfo imgInfo, ImageLine.ESampleType stype, bool unpackedMode, int[] sci, byte[] scb)
		{
			this.ImgInfo = imgInfo;
			this.channels = imgInfo.Channels;
			this.bitDepth = imgInfo.BitDepth;
			this.FilterUsed = FilterType.FILTER_UNKNOWN;
			this.SampleType = stype;
			this.SamplesUnpacked = (unpackedMode || !imgInfo.Packed);
			this.ElementsPerRow = (this.SamplesUnpacked ? imgInfo.SamplesPerRow : imgInfo.SamplesPerRowPacked);
			if (stype == ImageLine.ESampleType.INT)
			{
				this.Scanline = ((sci != null) ? sci : new int[this.ElementsPerRow]);
				this.ScanlineB = null;
				this.maxSampleVal = ((this.bitDepth == 16) ? 65535 : ImageLine.GetMaskForPackedFormatsLs(this.bitDepth));
			}
			else
			{
				if (stype != ImageLine.ESampleType.BYTE)
				{
					throw new PngjExceptionInternal("bad ImageLine initialization");
				}
				this.ScanlineB = ((scb != null) ? scb : new byte[this.ElementsPerRow]);
				this.Scanline = null;
				this.maxSampleVal = ((this.bitDepth == 16) ? 255 : ImageLine.GetMaskForPackedFormatsLs(this.bitDepth));
			}
			this.Rown = -1;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004A88 File Offset: 0x00002C88
		internal static void unpackInplaceInt(ImageInfo iminfo, int[] src, int[] dst, bool Scale)
		{
			int num = iminfo.BitDepth;
			if (num >= 8)
			{
				return;
			}
			int maskForPackedFormatsLs = ImageLine.GetMaskForPackedFormatsLs(num);
			int num2 = 8 - num;
			int num3 = 8 * iminfo.SamplesPerRowPacked - num * iminfo.SamplesPerRow;
			int num4;
			int num5;
			if (num3 != 8)
			{
				num4 = maskForPackedFormatsLs << num3;
				num5 = num3;
			}
			else
			{
				num4 = maskForPackedFormatsLs;
				num5 = 0;
			}
			int i = iminfo.SamplesPerRow - 1;
			int num6 = iminfo.SamplesPerRowPacked - 1;
			while (i >= 0)
			{
				int num7 = (src[num6] & num4) >> num5;
				if (Scale)
				{
					num7 <<= num2;
				}
				dst[i] = num7;
				num4 <<= num;
				num5 += num;
				if (num5 == 8)
				{
					num4 = maskForPackedFormatsLs;
					num5 = 0;
					num6--;
				}
				i--;
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004B38 File Offset: 0x00002D38
		internal static void packInplaceInt(ImageInfo iminfo, int[] src, int[] dst, bool scaled)
		{
			int num = iminfo.BitDepth;
			if (num >= 8)
			{
				return;
			}
			int maskForPackedFormatsLs = ImageLine.GetMaskForPackedFormatsLs(num);
			int num2 = 8 - num;
			int num3 = 8 - num;
			int num4 = 8 - num;
			int num5 = src[0];
			dst[0] = 0;
			if (scaled)
			{
				num5 >>= num2;
			}
			num5 = (num5 & maskForPackedFormatsLs) << num4;
			int num6 = 0;
			for (int i = 0; i < iminfo.SamplesPerRow; i++)
			{
				int num7 = src[i];
				if (scaled)
				{
					num7 >>= num2;
				}
				dst[num6] |= (num7 & maskForPackedFormatsLs) << num4;
				num4 -= num;
				if (num4 < 0)
				{
					num4 = num3;
					num6++;
					dst[num6] = 0;
				}
			}
			dst[0] |= num5;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004BEC File Offset: 0x00002DEC
		internal static void unpackInplaceByte(ImageInfo iminfo, byte[] src, byte[] dst, bool scale)
		{
			int num = iminfo.BitDepth;
			if (num >= 8)
			{
				return;
			}
			int maskForPackedFormatsLs = ImageLine.GetMaskForPackedFormatsLs(num);
			int num2 = 8 - num;
			int num3 = 8 * iminfo.SamplesPerRowPacked - num * iminfo.SamplesPerRow;
			int num4;
			int num5;
			if (num3 != 8)
			{
				num4 = maskForPackedFormatsLs << num3;
				num5 = num3;
			}
			else
			{
				num4 = maskForPackedFormatsLs;
				num5 = 0;
			}
			int i = iminfo.SamplesPerRow - 1;
			int num6 = iminfo.SamplesPerRowPacked - 1;
			while (i >= 0)
			{
				int num7 = ((int)src[num6] & num4) >> num5;
				if (scale)
				{
					num7 <<= num2;
				}
				dst[i] = (byte)num7;
				num4 <<= num;
				num5 += num;
				if (num5 == 8)
				{
					num4 = maskForPackedFormatsLs;
					num5 = 0;
					num6--;
				}
				i--;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004C9C File Offset: 0x00002E9C
		internal static void packInplaceByte(ImageInfo iminfo, byte[] src, byte[] dst, bool scaled)
		{
			int num = iminfo.BitDepth;
			if (num >= 8)
			{
				return;
			}
			byte b = (byte)ImageLine.GetMaskForPackedFormatsLs(num);
			byte b2 = (byte)(8 - num);
			byte b3 = (byte)(8 - num);
			int num2 = 8 - num;
			byte b4 = src[0];
			dst[0] = 0;
			if (scaled)
			{
				b4 = (byte)(b4 >> (int)b2);
			}
			b4 = (byte)((b4 & b) << num2);
			int num3 = 0;
			for (int i = 0; i < iminfo.SamplesPerRow; i++)
			{
				byte b5 = src[i];
				if (scaled)
				{
					b5 = (byte)(b5 >> (int)b2);
				}
				int num4 = num3;
				dst[num4] |= (byte)((b5 & b) << num2);
				num2 -= num;
				if (num2 < 0)
				{
					num2 = (int)b3;
					num3++;
					dst[num3] = 0;
				}
			}
			int num5 = 0;
			dst[num5] |= b4;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004D59 File Offset: 0x00002F59
		internal void SetScanLine(int[] b)
		{
			Array.Copy(b, 0, this.Scanline, 0, this.Scanline.Length);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004D71 File Offset: 0x00002F71
		internal int[] GetScanLineCopy(int[] b)
		{
			if (b == null || b.Length < this.Scanline.Length)
			{
				b = new int[this.Scanline.Length];
			}
			Array.Copy(this.Scanline, 0, b, 0, this.Scanline.Length);
			return b;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004DAC File Offset: 0x00002FAC
		public ImageLine unpackToNewImageLine()
		{
			ImageLine imageLine = new ImageLine(this.ImgInfo, this.SampleType, true);
			if (this.SampleType == ImageLine.ESampleType.INT)
			{
				ImageLine.unpackInplaceInt(this.ImgInfo, this.Scanline, imageLine.Scanline, false);
			}
			else
			{
				ImageLine.unpackInplaceByte(this.ImgInfo, this.ScanlineB, imageLine.ScanlineB, false);
			}
			return imageLine;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004E08 File Offset: 0x00003008
		public ImageLine packToNewImageLine()
		{
			ImageLine imageLine = new ImageLine(this.ImgInfo, this.SampleType, false);
			if (this.SampleType == ImageLine.ESampleType.INT)
			{
				ImageLine.packInplaceInt(this.ImgInfo, this.Scanline, imageLine.Scanline, false);
			}
			else
			{
				ImageLine.packInplaceByte(this.ImgInfo, this.ScanlineB, imageLine.ScanlineB, false);
			}
			return imageLine;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004E63 File Offset: 0x00003063
		public int[] GetScanlineInt()
		{
			return this.Scanline;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004E6B File Offset: 0x0000306B
		public byte[] GetScanlineByte()
		{
			return this.ScanlineB;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004E73 File Offset: 0x00003073
		public bool IsInt()
		{
			return this.SampleType == ImageLine.ESampleType.INT;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004E7E File Offset: 0x0000307E
		public bool IsByte()
		{
			return this.SampleType == ImageLine.ESampleType.BYTE;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004E8C File Offset: 0x0000308C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"row=",
				this.Rown,
				" cols=",
				this.ImgInfo.Cols,
				" bpc=",
				this.ImgInfo.BitDepth,
				" size=",
				this.Scanline.Length
			});
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004F08 File Offset: 0x00003108
		internal static int GetMaskForPackedFormats(int bitDepth)
		{
			if (bitDepth == 4)
			{
				return 240;
			}
			if (bitDepth == 2)
			{
				return 192;
			}
			if (bitDepth == 1)
			{
				return 128;
			}
			return 255;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004F2D File Offset: 0x0000312D
		internal static int GetMaskForPackedFormatsLs(int bitDepth)
		{
			if (bitDepth == 4)
			{
				return 15;
			}
			if (bitDepth == 2)
			{
				return 3;
			}
			if (bitDepth == 1)
			{
				return 1;
			}
			return 255;
		}

		// Token: 0x0400005D RID: 93
		internal readonly int channels;

		// Token: 0x0400005E RID: 94
		internal readonly int bitDepth;

		// Token: 0x020001AE RID: 430
		public enum ESampleType
		{
			// Token: 0x04000A41 RID: 2625
			INT,
			// Token: 0x04000A42 RID: 2626
			BYTE
		}
	}
}
