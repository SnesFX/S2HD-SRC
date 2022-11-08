﻿using System;
using Hjg.Pngcs.Chunks;

namespace Hjg.Pngcs
{
	// Token: 0x02000023 RID: 35
	public class ImageLineHelper
	{
		// Token: 0x060000DC RID: 220 RVA: 0x00004F48 File Offset: 0x00003148
		public static int[] Palette2rgb(ImageLine line, PngChunkPLTE pal, PngChunkTRNS trns, int[] buf)
		{
			bool flag = trns != null;
			int num = flag ? 4 : 3;
			int num2 = line.ImgInfo.Cols * num;
			if (buf == null || buf.Length < num2)
			{
				buf = new int[num2];
			}
			if (!line.SamplesUnpacked)
			{
				line = line.unpackToNewImageLine();
			}
			bool flag2 = line.SampleType == ImageLine.ESampleType.BYTE;
			int num3 = (trns != null) ? trns.GetPalletteAlpha().Length : 0;
			for (int i = 0; i < line.ImgInfo.Cols; i++)
			{
				int num4 = flag2 ? ((int)(line.ScanlineB[i] & byte.MaxValue)) : line.Scanline[i];
				pal.GetEntryRgb(num4, buf, i * num);
				if (flag)
				{
					int num5 = (num4 < num3) ? trns.GetPalletteAlpha()[num4] : 255;
					buf[i * num + 3] = num5;
				}
			}
			return buf;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005017 File Offset: 0x00003217
		public static int[] Palette2rgb(ImageLine line, PngChunkPLTE pal, int[] buf)
		{
			return ImageLineHelper.Palette2rgb(line, pal, null, buf);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005022 File Offset: 0x00003222
		public static int ToARGB8(int r, int g, int b)
		{
			return -16777216 | r << 16 | g << 8 | b;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005034 File Offset: 0x00003234
		public static int ToARGB8(int r, int g, int b, int a)
		{
			return a << 24 | r << 16 | g << 8 | b;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005045 File Offset: 0x00003245
		public static int ToARGB8(int[] buff, int offset, bool alpha)
		{
			if (!alpha)
			{
				return ImageLineHelper.ToARGB8(buff[offset++], buff[offset++], buff[offset]);
			}
			return ImageLineHelper.ToARGB8(buff[offset++], buff[offset++], buff[offset++], buff[offset]);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005083 File Offset: 0x00003283
		public static int ToARGB8(byte[] buff, int offset, bool alpha)
		{
			if (!alpha)
			{
				return ImageLineHelper.ToARGB8((int)buff[offset++], (int)buff[offset++], (int)buff[offset]);
			}
			return ImageLineHelper.ToARGB8((int)buff[offset++], (int)buff[offset++], (int)buff[offset++], (int)buff[offset]);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000050C4 File Offset: 0x000032C4
		public static void FromARGB8(int val, int[] buff, int offset, bool alpha)
		{
			buff[offset++] = (val >> 16 & 255);
			buff[offset++] = (val >> 8 & 255);
			buff[offset] = (val & 255);
			if (alpha)
			{
				buff[offset + 1] = (val >> 24 & 255);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005110 File Offset: 0x00003310
		public static void FromARGB8(int val, byte[] buff, int offset, bool alpha)
		{
			buff[offset++] = (byte)(val >> 16 & 255);
			buff[offset++] = (byte)(val >> 8 & 255);
			buff[offset] = (byte)(val & 255);
			if (alpha)
			{
				buff[offset + 1] = (byte)(val >> 24 & 255);
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005160 File Offset: 0x00003360
		public static int GetPixelToARGB8(ImageLine line, int column)
		{
			if (line.IsInt())
			{
				return ImageLineHelper.ToARGB8(line.Scanline, column * line.channels, line.ImgInfo.Alpha);
			}
			return ImageLineHelper.ToARGB8(line.ScanlineB, column * line.channels, line.ImgInfo.Alpha);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000051B4 File Offset: 0x000033B4
		public static void SetPixelFromARGB8(ImageLine line, int column, int argb)
		{
			if (line.IsInt())
			{
				ImageLineHelper.FromARGB8(argb, line.Scanline, column * line.channels, line.ImgInfo.Alpha);
				return;
			}
			ImageLineHelper.FromARGB8(argb, line.ScanlineB, column * line.channels, line.ImgInfo.Alpha);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005208 File Offset: 0x00003408
		public static void SetPixel(ImageLine line, int col, int r, int g, int b, int a)
		{
			int num = col * line.channels;
			if (line.IsInt())
			{
				line.Scanline[num++] = r;
				line.Scanline[num++] = g;
				line.Scanline[num] = b;
				if (line.ImgInfo.Alpha)
				{
					line.Scanline[num + 1] = a;
					return;
				}
			}
			else
			{
				line.ScanlineB[num++] = (byte)r;
				line.ScanlineB[num++] = (byte)g;
				line.ScanlineB[num] = (byte)b;
				if (line.ImgInfo.Alpha)
				{
					line.ScanlineB[num + 1] = (byte)a;
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000052A5 File Offset: 0x000034A5
		public static void SetPixel(ImageLine line, int col, int r, int g, int b)
		{
			ImageLineHelper.SetPixel(line, col, r, g, b, line.maxSampleVal);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000052B8 File Offset: 0x000034B8
		public static double ReadDouble(ImageLine line, int pos)
		{
			if (line.IsInt())
			{
				return (double)line.Scanline[pos] / ((double)line.maxSampleVal + 0.9);
			}
			return (double)line.ScanlineB[pos] / ((double)line.maxSampleVal + 0.9);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005304 File Offset: 0x00003504
		public static void WriteDouble(ImageLine line, double d, int pos)
		{
			if (line.IsInt())
			{
				line.Scanline[pos] = (int)(d * ((double)line.maxSampleVal + 0.99));
				return;
			}
			line.ScanlineB[pos] = (byte)(d * ((double)line.maxSampleVal + 0.99));
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005354 File Offset: 0x00003554
		public static int Interpol(int a, int b, int c, int d, double dx, double dy)
		{
			double num = (double)a * (1.0 - dx) + (double)b * dx;
			double num2 = (double)c * (1.0 - dx) + (double)d * dx;
			return (int)(num * (1.0 - dy) + num2 * dy + 0.5);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000053A9 File Offset: 0x000035A9
		public static int ClampTo_0_255(int i)
		{
			if (i > 255)
			{
				return 255;
			}
			if (i >= 0)
			{
				return i;
			}
			return 0;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000053C0 File Offset: 0x000035C0
		public static double ClampDouble(double i)
		{
			if (i < 0.0)
			{
				return 0.0;
			}
			if (i < 1.0)
			{
				return i;
			}
			return 0.999999;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000053EF File Offset: 0x000035EF
		public static int ClampTo_0_65535(int i)
		{
			if (i > 65535)
			{
				return 65535;
			}
			if (i >= 0)
			{
				return i;
			}
			return 0;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005406 File Offset: 0x00003606
		public static int ClampTo_128_127(int x)
		{
			if (x > 127)
			{
				return 127;
			}
			if (x >= -128)
			{
				return x;
			}
			return -128;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000541C File Offset: 0x0000361C
		public static int[] Unpack(ImageInfo imgInfo, int[] src, int[] dst, bool scale)
		{
			int samplesPerRow = imgInfo.SamplesPerRow;
			int samplesPerRowPacked = imgInfo.SamplesPerRowPacked;
			if (dst == null || dst.Length < samplesPerRow)
			{
				dst = new int[samplesPerRow];
			}
			if (imgInfo.Packed)
			{
				ImageLine.unpackInplaceInt(imgInfo, src, dst, scale);
			}
			else
			{
				Array.Copy(src, 0, dst, 0, samplesPerRowPacked);
			}
			return dst;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005468 File Offset: 0x00003668
		public static byte[] Unpack(ImageInfo imgInfo, byte[] src, byte[] dst, bool scale)
		{
			int samplesPerRow = imgInfo.SamplesPerRow;
			int samplesPerRowPacked = imgInfo.SamplesPerRowPacked;
			if (dst == null || dst.Length < samplesPerRow)
			{
				dst = new byte[samplesPerRow];
			}
			if (imgInfo.Packed)
			{
				ImageLine.unpackInplaceByte(imgInfo, src, dst, scale);
			}
			else
			{
				Array.Copy(src, 0, dst, 0, samplesPerRowPacked);
			}
			return dst;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000054B4 File Offset: 0x000036B4
		public static int[] Pack(ImageInfo imgInfo, int[] src, int[] dst, bool scale)
		{
			int samplesPerRowPacked = imgInfo.SamplesPerRowPacked;
			if (dst == null || dst.Length < samplesPerRowPacked)
			{
				dst = new int[samplesPerRowPacked];
			}
			if (imgInfo.Packed)
			{
				ImageLine.packInplaceInt(imgInfo, src, dst, scale);
			}
			else
			{
				Array.Copy(src, 0, dst, 0, samplesPerRowPacked);
			}
			return dst;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000054F8 File Offset: 0x000036F8
		public static byte[] Pack(ImageInfo imgInfo, byte[] src, byte[] dst, bool scale)
		{
			int samplesPerRowPacked = imgInfo.SamplesPerRowPacked;
			if (dst == null || dst.Length < samplesPerRowPacked)
			{
				dst = new byte[samplesPerRowPacked];
			}
			if (imgInfo.Packed)
			{
				ImageLine.packInplaceByte(imgInfo, src, dst, scale);
			}
			else
			{
				Array.Copy(src, 0, dst, 0, samplesPerRowPacked);
			}
			return dst;
		}
	}
}
