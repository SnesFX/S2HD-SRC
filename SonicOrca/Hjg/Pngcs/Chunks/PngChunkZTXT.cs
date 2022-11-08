using System;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005F RID: 95
	public class PngChunkZTXT : PngChunkTextVar
	{
		// Token: 0x0600033E RID: 830 RVA: 0x0000C54C File Offset: 0x0000A74C
		public PngChunkZTXT(ImageInfo info) : base("zTXt", info)
		{
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000C55C File Offset: 0x0000A75C
		public override ChunkRaw CreateRawChunk()
		{
			if (this.key.Length == 0)
			{
				throw new PngjException("Text chunk key must be non empty");
			}
			MemoryStream memoryStream = new MemoryStream();
			ChunkHelper.WriteBytesToStream(memoryStream, ChunkHelper.ToBytes(this.key));
			memoryStream.WriteByte(0);
			memoryStream.WriteByte(0);
			byte[] bytes = ChunkHelper.compressBytes(ChunkHelper.ToBytes(this.val), true);
			ChunkHelper.WriteBytesToStream(memoryStream, bytes);
			byte[] array = memoryStream.ToArray();
			ChunkRaw chunkRaw = base.createEmptyChunk(array.Length, false);
			chunkRaw.Data = array;
			return chunkRaw;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000C5D8 File Offset: 0x0000A7D8
		public override void ParseFromRaw(ChunkRaw c)
		{
			int num = -1;
			for (int i = 0; i < c.Data.Length; i++)
			{
				if (c.Data[i] == 0)
				{
					num = i;
					break;
				}
			}
			if (num < 0 || num > c.Data.Length - 2)
			{
				throw new PngjException("bad zTXt chunk: no separator found");
			}
			this.key = ChunkHelper.ToString(c.Data, 0, num);
			if (c.Data[num + 1] != 0)
			{
				throw new PngjException("bad zTXt chunk: unknown compression method");
			}
			byte[] x = ChunkHelper.compressBytes(c.Data, num + 2, c.Data.Length - num - 2, false);
			this.val = ChunkHelper.ToString(x);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000C678 File Offset: 0x0000A878
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkZTXT pngChunkZTXT = (PngChunkZTXT)other;
			this.key = pngChunkZTXT.key;
			this.val = pngChunkZTXT.val;
		}

		// Token: 0x04000189 RID: 393
		public const string ID = "zTXt";
	}
}
