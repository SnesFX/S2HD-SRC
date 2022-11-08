using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005A RID: 90
	public class PngChunkTEXT : PngChunkTextVar
	{
		// Token: 0x06000318 RID: 792 RVA: 0x0000BD44 File Offset: 0x00009F44
		public PngChunkTEXT(ImageInfo info) : base("tEXt", info)
		{
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000BD54 File Offset: 0x00009F54
		public override ChunkRaw CreateRawChunk()
		{
			if (this.key.Length == 0)
			{
				throw new PngjException("Text chunk key must be non empty");
			}
			byte[] bytes = PngHelperInternal.charsetLatin1.GetBytes(this.key);
			byte[] bytes2 = PngHelperInternal.charsetLatin1.GetBytes(this.val);
			ChunkRaw chunkRaw = base.createEmptyChunk(bytes.Length + bytes2.Length + 1, true);
			Array.Copy(bytes, 0, chunkRaw.Data, 0, bytes.Length);
			chunkRaw.Data[bytes.Length] = 0;
			Array.Copy(bytes2, 0, chunkRaw.Data, bytes.Length + 1, bytes2.Length);
			return chunkRaw;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000BDE0 File Offset: 0x00009FE0
		public override void ParseFromRaw(ChunkRaw c)
		{
			int num = 0;
			while (num < c.Data.Length && c.Data[num] != 0)
			{
				num++;
			}
			this.key = PngHelperInternal.charsetLatin1.GetString(c.Data, 0, num);
			num++;
			this.val = ((num < c.Data.Length) ? PngHelperInternal.charsetLatin1.GetString(c.Data, num, c.Data.Length - num) : "");
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000BE5C File Offset: 0x0000A05C
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkTEXT pngChunkTEXT = (PngChunkTEXT)other;
			this.key = pngChunkTEXT.key;
			this.val = pngChunkTEXT.val;
		}

		// Token: 0x0400016E RID: 366
		public const string ID = "tEXt";
	}
}
