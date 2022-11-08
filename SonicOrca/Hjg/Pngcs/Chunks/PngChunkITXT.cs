using System;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004F RID: 79
	public class PngChunkITXT : PngChunkTextVar
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		public PngChunkITXT(ImageInfo info) : base("iTXt", info)
		{
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		public override ChunkRaw CreateRawChunk()
		{
			if (this.key.Length == 0)
			{
				throw new PngjException("Text chunk key must be non empty");
			}
			MemoryStream memoryStream = new MemoryStream();
			ChunkHelper.WriteBytesToStream(memoryStream, ChunkHelper.ToBytes(this.key));
			memoryStream.WriteByte(0);
			memoryStream.WriteByte(this.compressed ? 1 : 0);
			memoryStream.WriteByte(0);
			ChunkHelper.WriteBytesToStream(memoryStream, ChunkHelper.ToBytes(this.langTag));
			memoryStream.WriteByte(0);
			ChunkHelper.WriteBytesToStream(memoryStream, ChunkHelper.ToBytesUTF8(this.translatedTag));
			memoryStream.WriteByte(0);
			byte[] array = ChunkHelper.ToBytesUTF8(this.val);
			if (this.compressed)
			{
				array = ChunkHelper.compressBytes(array, true);
			}
			ChunkHelper.WriteBytesToStream(memoryStream, array);
			byte[] array2 = memoryStream.ToArray();
			ChunkRaw chunkRaw = base.createEmptyChunk(array2.Length, false);
			chunkRaw.Data = array2;
			return chunkRaw;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000AE8C File Offset: 0x0000908C
		public override void ParseFromRaw(ChunkRaw c)
		{
			int num = 0;
			int[] array = new int[3];
			for (int i = 0; i < c.Data.Length; i++)
			{
				if (c.Data[i] == 0)
				{
					array[num] = i;
					num++;
					if (num == 1)
					{
						i += 2;
					}
					if (num == 3)
					{
						break;
					}
				}
			}
			if (num != 3)
			{
				throw new PngjException("Bad formed PngChunkITXT chunk");
			}
			this.key = ChunkHelper.ToString(c.Data, 0, array[0]);
			int num2 = array[0] + 1;
			this.compressed = (c.Data[num2] != 0);
			num2++;
			if (this.compressed && c.Data[num2] != 0)
			{
				throw new PngjException("Bad formed PngChunkITXT chunk - bad compression method ");
			}
			this.langTag = ChunkHelper.ToString(c.Data, num2, array[1] - num2);
			this.translatedTag = ChunkHelper.ToStringUTF8(c.Data, array[1] + 1, array[2] - array[1] - 1);
			num2 = array[2] + 1;
			if (this.compressed)
			{
				byte[] x = ChunkHelper.compressBytes(c.Data, num2, c.Data.Length - num2, false);
				this.val = ChunkHelper.ToStringUTF8(x);
				return;
			}
			this.val = ChunkHelper.ToStringUTF8(c.Data, num2, c.Data.Length - num2);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000AFBC File Offset: 0x000091BC
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkITXT pngChunkITXT = (PngChunkITXT)other;
			this.key = pngChunkITXT.key;
			this.val = pngChunkITXT.val;
			this.compressed = pngChunkITXT.compressed;
			this.langTag = pngChunkITXT.langTag;
			this.translatedTag = pngChunkITXT.translatedTag;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000B00C File Offset: 0x0000920C
		public bool IsCompressed()
		{
			return this.compressed;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000B014 File Offset: 0x00009214
		public void SetCompressed(bool compressed)
		{
			this.compressed = compressed;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000B01D File Offset: 0x0000921D
		public string GetLangtag()
		{
			return this.langTag;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000B025 File Offset: 0x00009225
		public void SetLangtag(string langtag)
		{
			this.langTag = langtag;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000B02E File Offset: 0x0000922E
		public string GetTranslatedTag()
		{
			return this.translatedTag;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000B036 File Offset: 0x00009236
		public void SetTranslatedTag(string translatedTag)
		{
			this.translatedTag = translatedTag;
		}

		// Token: 0x0400014D RID: 333
		public const string ID = "iTXt";

		// Token: 0x0400014E RID: 334
		private bool compressed;

		// Token: 0x0400014F RID: 335
		private string langTag = "";

		// Token: 0x04000150 RID: 336
		private string translatedTag = "";
	}
}
