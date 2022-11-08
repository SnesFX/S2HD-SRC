using System;
using System.IO;
using System.Text;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs
{
	// Token: 0x02000027 RID: 39
	public class PngHelperInternal
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00005E9C File Offset: 0x0000409C
		public static CRC32 GetCRC()
		{
			if (PngHelperInternal.crc32Engine == null)
			{
				PngHelperInternal.crc32Engine = new CRC32();
			}
			return PngHelperInternal.crc32Engine;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005EB4 File Offset: 0x000040B4
		public static int DoubleToInt100000(double d)
		{
			return (int)(d * 100000.0 + 0.5);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00005ECC File Offset: 0x000040CC
		public static double IntToDouble100000(int i)
		{
			return (double)i / 100000.0;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005EDC File Offset: 0x000040DC
		public static void WriteInt2(Stream os, int n)
		{
			byte[] b = new byte[]
			{
				(byte)(n >> 8 & 255),
				(byte)(n & 255)
			};
			PngHelperInternal.WriteBytes(os, b);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005F10 File Offset: 0x00004110
		public static int ReadInt2(Stream mask0)
		{
			int result;
			try
			{
				int num = mask0.ReadByte();
				int num2 = mask0.ReadByte();
				if (num == -1 || num2 == -1)
				{
					result = -1;
				}
				else
				{
					result = (num << 8) + num2;
				}
			}
			catch (IOException cause)
			{
				throw new PngjInputException("error reading readInt2", cause);
			}
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005F60 File Offset: 0x00004160
		public static int ReadInt4(Stream mask0)
		{
			int result;
			try
			{
				int num = mask0.ReadByte();
				int num2 = mask0.ReadByte();
				int num3 = mask0.ReadByte();
				int num4 = mask0.ReadByte();
				if (num == -1 || num2 == -1 || num3 == -1 || num4 == -1)
				{
					result = -1;
				}
				else
				{
					result = (num << 24) + (num2 << 16) + (num3 << 8) + num4;
				}
			}
			catch (IOException cause)
			{
				throw new PngjInputException("error reading readInt4", cause);
			}
			return result;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005FD4 File Offset: 0x000041D4
		public static int ReadInt1fromByte(byte[] b, int offset)
		{
			return (int)(b[offset] & byte.MaxValue);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00005FDF File Offset: 0x000041DF
		public static int ReadInt2fromBytes(byte[] b, int offset)
		{
			return (int)(b[offset] & byte.MaxValue) << 16 | (int)(b[offset + 1] & byte.MaxValue);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00005FF9 File Offset: 0x000041F9
		public static int ReadInt4fromBytes(byte[] b, int offset)
		{
			return (int)(b[offset] & byte.MaxValue) << 24 | (int)(b[offset + 1] & byte.MaxValue) << 16 | (int)(b[offset + 2] & byte.MaxValue) << 8 | (int)(b[offset + 3] & byte.MaxValue);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006030 File Offset: 0x00004230
		public static void WriteInt2tobytes(int n, byte[] b, int offset)
		{
			b[offset] = (byte)(n >> 8 & 255);
			b[offset + 1] = (byte)(n & 255);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000604C File Offset: 0x0000424C
		public static void WriteInt4tobytes(int n, byte[] b, int offset)
		{
			b[offset] = (byte)(n >> 24 & 255);
			b[offset + 1] = (byte)(n >> 16 & 255);
			b[offset + 2] = (byte)(n >> 8 & 255);
			b[offset + 3] = (byte)(n & 255);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006088 File Offset: 0x00004288
		public static void WriteInt4(Stream os, int n)
		{
			byte[] b = new byte[4];
			PngHelperInternal.WriteInt4tobytes(n, b, 0);
			PngHelperInternal.WriteBytes(os, b);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000060AC File Offset: 0x000042AC
		public static void ReadBytes(Stream mask0, byte[] b, int offset, int len)
		{
			if (len == 0)
			{
				return;
			}
			try
			{
				int num;
				for (int i = 0; i < len; i += num)
				{
					num = mask0.Read(b, offset + i, len - i);
					if (num < 1)
					{
						throw new Exception(string.Concat(new object[]
						{
							"error reading, ",
							num,
							" !=",
							len
						}));
					}
				}
			}
			catch (IOException cause)
			{
				throw new PngjInputException("error reading", cause);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006130 File Offset: 0x00004330
		public static void SkipBytes(Stream ist, int len)
		{
			byte[] array = new byte[32768];
			int i = len;
			try
			{
				while (i > 0)
				{
					int num = ist.Read(array, 0, (i > array.Length) ? array.Length : i);
					if (num < 0)
					{
						throw new PngjInputException("error reading (skipping) : EOF");
					}
					i -= num;
				}
			}
			catch (IOException cause)
			{
				throw new PngjInputException("error reading (skipping)", cause);
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006198 File Offset: 0x00004398
		public static void WriteBytes(Stream os, byte[] b)
		{
			try
			{
				os.Write(b, 0, b.Length);
			}
			catch (IOException cause)
			{
				throw new PngjOutputException(cause);
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000061C8 File Offset: 0x000043C8
		public static void WriteBytes(Stream os, byte[] b, int offset, int n)
		{
			try
			{
				os.Write(b, offset, n);
			}
			catch (IOException cause)
			{
				throw new PngjOutputException(cause);
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000061F8 File Offset: 0x000043F8
		public static int ReadByte(Stream mask0)
		{
			int result;
			try
			{
				result = mask0.ReadByte();
			}
			catch (IOException cause)
			{
				throw new PngjOutputException(cause);
			}
			return result;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006228 File Offset: 0x00004428
		public static void WriteByte(Stream os, byte b)
		{
			try
			{
				os.WriteByte(b);
			}
			catch (IOException cause)
			{
				throw new PngjOutputException(cause);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00006254 File Offset: 0x00004454
		public static int UnfilterRowPaeth(int r, int a, int b, int c)
		{
			return r + PngHelperInternal.FilterPaethPredictor(a, b, c) & 255;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006268 File Offset: 0x00004468
		public static int FilterPaethPredictor(int a, int b, int c)
		{
			int num = a + b - c;
			int num2 = (num >= a) ? (num - a) : (a - num);
			int num3 = (num >= b) ? (num - b) : (b - num);
			int num4 = (num >= c) ? (num - c) : (c - num);
			if (num2 <= num3 && num2 <= num4)
			{
				return a;
			}
			if (num3 <= num4)
			{
				return b;
			}
			return c;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000062B3 File Offset: 0x000044B3
		public static void Logdebug(string msg)
		{
			if (PngHelperInternal.DEBUG)
			{
				Console.Out.WriteLine(msg);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000062C7 File Offset: 0x000044C7
		public static void InitCrcForTests(PngReader pngr)
		{
			pngr.InitCrctest();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000062CF File Offset: 0x000044CF
		public static long GetCrctestVal(PngReader pngr)
		{
			return pngr.GetCrctestVal();
		}

		// Token: 0x04000080 RID: 128
		[ThreadStatic]
		private static CRC32 crc32Engine = null;

		// Token: 0x04000081 RID: 129
		public static readonly byte[] PNG_ID_SIGNATURE = new byte[]
		{
			137,
			80,
			78,
			71,
			13,
			10,
			26,
			10
		};

		// Token: 0x04000082 RID: 130
		public static Encoding charsetLatin1 = Encoding.GetEncoding("ISO-8859-1");

		// Token: 0x04000083 RID: 131
		public static Encoding charsetUtf8 = Encoding.GetEncoding("UTF-8");

		// Token: 0x04000084 RID: 132
		public static bool DEBUG = false;
	}
}
