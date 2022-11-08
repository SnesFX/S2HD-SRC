using System;
using System.Collections.Generic;
using System.Text;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000044 RID: 68
	public class ChunksList
	{
		// Token: 0x06000237 RID: 567 RVA: 0x000098B5 File Offset: 0x00007AB5
		internal ChunksList(ImageInfo imfinfo)
		{
			this.chunks = new List<PngChunk>();
			this.imageInfo = imfinfo;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000098D0 File Offset: 0x00007AD0
		public Dictionary<string, int> GetChunksKeys()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (PngChunk pngChunk in this.chunks)
			{
				dictionary[pngChunk.Id] = (dictionary.ContainsKey(pngChunk.Id) ? (dictionary[pngChunk.Id] + 1) : 1);
			}
			return dictionary;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00009950 File Offset: 0x00007B50
		public List<PngChunk> GetChunks()
		{
			return new List<PngChunk>(this.chunks);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000995D File Offset: 0x00007B5D
		internal static List<PngChunk> GetXById(List<PngChunk> list, string id, string innerid)
		{
			if (innerid == null)
			{
				return ChunkHelper.FilterList(list, new ChunkPredicateId(id));
			}
			return ChunkHelper.FilterList(list, new ChunkPredicateId2(id, innerid));
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000997C File Offset: 0x00007B7C
		public void AppendReadChunk(PngChunk chunk, int chunkGroup)
		{
			chunk.ChunkGroup = chunkGroup;
			this.chunks.Add(chunk);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00009991 File Offset: 0x00007B91
		public List<PngChunk> GetById(string id)
		{
			return this.GetById(id, null);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000999B File Offset: 0x00007B9B
		public List<PngChunk> GetById(string id, string innerid)
		{
			return ChunksList.GetXById(this.chunks, id, innerid);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000099AA File Offset: 0x00007BAA
		public PngChunk GetById1(string id)
		{
			return this.GetById1(id, false);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000099B4 File Offset: 0x00007BB4
		public PngChunk GetById1(string id, bool failIfMultiple)
		{
			return this.GetById1(id, null, failIfMultiple);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000099C0 File Offset: 0x00007BC0
		public PngChunk GetById1(string id, string innerid, bool failIfMultiple)
		{
			List<PngChunk> byId = this.GetById(id, innerid);
			if (byId.Count == 0)
			{
				return null;
			}
			if (byId.Count > 1 && (failIfMultiple || !byId[0].AllowsMultiple()))
			{
				throw new PngjException("unexpected multiple chunks id=" + id);
			}
			return byId[byId.Count - 1];
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00009A19 File Offset: 0x00007C19
		public List<PngChunk> GetEquivalent(PngChunk chunk)
		{
			return ChunkHelper.FilterList(this.chunks, new ChunkPredicateEquiv(chunk));
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009A2C File Offset: 0x00007C2C
		public override string ToString()
		{
			return "ChunkList: read: " + this.chunks.Count;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009A48 File Offset: 0x00007C48
		public string ToStringFull()
		{
			StringBuilder stringBuilder = new StringBuilder(this.ToString());
			stringBuilder.Append("\n Read:\n");
			foreach (PngChunk pngChunk in this.chunks)
			{
				stringBuilder.Append(pngChunk).Append(" G=" + pngChunk.ChunkGroup + "\n");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000118 RID: 280
		internal const int CHUNK_GROUP_0_IDHR = 0;

		// Token: 0x04000119 RID: 281
		internal const int CHUNK_GROUP_1_AFTERIDHR = 1;

		// Token: 0x0400011A RID: 282
		internal const int CHUNK_GROUP_2_PLTE = 2;

		// Token: 0x0400011B RID: 283
		internal const int CHUNK_GROUP_3_AFTERPLTE = 3;

		// Token: 0x0400011C RID: 284
		internal const int CHUNK_GROUP_4_IDAT = 4;

		// Token: 0x0400011D RID: 285
		internal const int CHUNK_GROUP_5_AFTERIDAT = 5;

		// Token: 0x0400011E RID: 286
		internal const int CHUNK_GROUP_6_END = 6;

		// Token: 0x0400011F RID: 287
		protected List<PngChunk> chunks;

		// Token: 0x04000120 RID: 288
		internal readonly ImageInfo imageInfo;
	}
}
