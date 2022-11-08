using System;
using System.Collections.Generic;
using System.IO;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200003D RID: 61
	public class ChunkHelper
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000929A File Offset: 0x0000749A
		public static byte[] ToBytes(string x)
		{
			return PngHelperInternal.charsetLatin1.GetBytes(x);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000092A7 File Offset: 0x000074A7
		public static string ToString(byte[] x)
		{
			return PngHelperInternal.charsetLatin1.GetString(x);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000092B4 File Offset: 0x000074B4
		public static string ToString(byte[] x, int offset, int len)
		{
			return PngHelperInternal.charsetLatin1.GetString(x, offset, len);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000092C3 File Offset: 0x000074C3
		public static byte[] ToBytesUTF8(string x)
		{
			return PngHelperInternal.charsetUtf8.GetBytes(x);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000092D0 File Offset: 0x000074D0
		public static string ToStringUTF8(byte[] x)
		{
			return PngHelperInternal.charsetUtf8.GetString(x);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000092DD File Offset: 0x000074DD
		public static string ToStringUTF8(byte[] x, int offset, int len)
		{
			return PngHelperInternal.charsetUtf8.GetString(x, offset, len);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000092EC File Offset: 0x000074EC
		public static void WriteBytesToStream(Stream stream, byte[] bytes)
		{
			stream.Write(bytes, 0, bytes.Length);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000092F9 File Offset: 0x000074F9
		public static bool IsCritical(string id)
		{
			return char.IsUpper(id[0]);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00009307 File Offset: 0x00007507
		public static bool IsPublic(string id)
		{
			return char.IsUpper(id[1]);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00009315 File Offset: 0x00007515
		public static bool IsSafeToCopy(string id)
		{
			return !char.IsUpper(id[3]);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00009326 File Offset: 0x00007526
		public static bool IsUnknown(PngChunk chunk)
		{
			return chunk is PngChunkUNKNOWN;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00009334 File Offset: 0x00007534
		public static int PosNullByte(byte[] bytes)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] == 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00009358 File Offset: 0x00007558
		public static bool ShouldLoad(string id, ChunkLoadBehaviour behav)
		{
			if (ChunkHelper.IsCritical(id))
			{
				return true;
			}
			bool flag = PngChunk.isKnown(id);
			switch (behav)
			{
			case ChunkLoadBehaviour.LOAD_CHUNK_NEVER:
				return false;
			case ChunkLoadBehaviour.LOAD_CHUNK_KNOWN:
				return flag;
			case ChunkLoadBehaviour.LOAD_CHUNK_IF_SAFE:
				return flag || ChunkHelper.IsSafeToCopy(id);
			case ChunkLoadBehaviour.LOAD_CHUNK_ALWAYS:
				return true;
			default:
				return false;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000093A1 File Offset: 0x000075A1
		internal static byte[] compressBytes(byte[] ori, bool compress)
		{
			return ChunkHelper.compressBytes(ori, 0, ori.Length, compress);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000093B0 File Offset: 0x000075B0
		internal static byte[] compressBytes(byte[] ori, int offset, int len, bool compress)
		{
			byte[] result;
			try
			{
				MemoryStream memoryStream = new MemoryStream(ori, offset, len);
				Stream stream = memoryStream;
				if (!compress)
				{
					stream = ZlibStreamFactory.createZlibInputStream(memoryStream);
				}
				MemoryStream memoryStream2 = new MemoryStream();
				Stream stream2 = memoryStream2;
				if (compress)
				{
					stream2 = ZlibStreamFactory.createZlibOutputStream(memoryStream2);
				}
				ChunkHelper.shovelInToOut(stream, stream2);
				stream.Close();
				stream2.Close();
				result = memoryStream2.ToArray();
			}
			catch (Exception cause)
			{
				throw new PngjException(cause);
			}
			return result;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000941C File Offset: 0x0000761C
		private static void shovelInToOut(Stream inx, Stream outx)
		{
			byte[] buffer = new byte[1024];
			int count;
			while ((count = inx.Read(buffer, 0, 1024)) > 0)
			{
				outx.Write(buffer, 0, count);
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00009451 File Offset: 0x00007651
		internal static bool maskMatch(int v, int mask)
		{
			return (v & mask) != 0;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000945C File Offset: 0x0000765C
		public static List<PngChunk> FilterList(List<PngChunk> list, ChunkPredicate predicateKeep)
		{
			List<PngChunk> list2 = new List<PngChunk>();
			foreach (PngChunk pngChunk in list)
			{
				if (predicateKeep.Matches(pngChunk))
				{
					list2.Add(pngChunk);
				}
			}
			return list2;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000094BC File Offset: 0x000076BC
		public static int TrimList(List<PngChunk> list, ChunkPredicate predicateRemove)
		{
			int num = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (predicateRemove.Matches(list[i]))
				{
					list.RemoveAt(i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000094FC File Offset: 0x000076FC
		public static bool Equivalent(PngChunk c1, PngChunk c2)
		{
			if (c1 == c2)
			{
				return true;
			}
			if (c1 == null || c2 == null || !c1.Id.Equals(c2.Id))
			{
				return false;
			}
			if (c1.GetType() != c2.GetType())
			{
				return false;
			}
			if (!c2.AllowsMultiple())
			{
				return true;
			}
			if (c1 is PngChunkTextVar)
			{
				return ((PngChunkTextVar)c1).GetKey().Equals(((PngChunkTextVar)c2).GetKey());
			}
			return c1 is PngChunkSPLT && ((PngChunkSPLT)c1).PalName.Equals(((PngChunkSPLT)c2).PalName);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00009592 File Offset: 0x00007792
		public static bool IsText(PngChunk c)
		{
			return c is PngChunkTextVar;
		}

		// Token: 0x040000F5 RID: 245
		internal const string IHDR = "IHDR";

		// Token: 0x040000F6 RID: 246
		internal const string PLTE = "PLTE";

		// Token: 0x040000F7 RID: 247
		internal const string IDAT = "IDAT";

		// Token: 0x040000F8 RID: 248
		internal const string IEND = "IEND";

		// Token: 0x040000F9 RID: 249
		internal const string cHRM = "cHRM";

		// Token: 0x040000FA RID: 250
		internal const string gAMA = "gAMA";

		// Token: 0x040000FB RID: 251
		internal const string iCCP = "iCCP";

		// Token: 0x040000FC RID: 252
		internal const string sBIT = "sBIT";

		// Token: 0x040000FD RID: 253
		internal const string sRGB = "sRGB";

		// Token: 0x040000FE RID: 254
		internal const string bKGD = "bKGD";

		// Token: 0x040000FF RID: 255
		internal const string hIST = "hIST";

		// Token: 0x04000100 RID: 256
		internal const string tRNS = "tRNS";

		// Token: 0x04000101 RID: 257
		internal const string pHYs = "pHYs";

		// Token: 0x04000102 RID: 258
		internal const string sPLT = "sPLT";

		// Token: 0x04000103 RID: 259
		internal const string tIME = "tIME";

		// Token: 0x04000104 RID: 260
		internal const string iTXt = "iTXt";

		// Token: 0x04000105 RID: 261
		internal const string tEXt = "tEXt";

		// Token: 0x04000106 RID: 262
		internal const string zTXt = "zTXt";

		// Token: 0x04000107 RID: 263
		internal static readonly byte[] b_IHDR = ChunkHelper.ToBytes("IHDR");

		// Token: 0x04000108 RID: 264
		internal static readonly byte[] b_PLTE = ChunkHelper.ToBytes("PLTE");

		// Token: 0x04000109 RID: 265
		internal static readonly byte[] b_IDAT = ChunkHelper.ToBytes("IDAT");

		// Token: 0x0400010A RID: 266
		internal static readonly byte[] b_IEND = ChunkHelper.ToBytes("IEND");
	}
}
