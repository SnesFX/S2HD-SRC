using System;
using System.Collections.Generic;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000045 RID: 69
	public class ChunksListForWrite : ChunksList
	{
		// Token: 0x06000244 RID: 580 RVA: 0x00009ADC File Offset: 0x00007CDC
		internal ChunksListForWrite(ImageInfo info) : base(info)
		{
			this.queuedChunks = new List<PngChunk>();
			this.alreadyWrittenKeys = new Dictionary<string, int>();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00009AFB File Offset: 0x00007CFB
		public List<PngChunk> GetQueuedById(string id)
		{
			return this.GetQueuedById(id, null);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00009B05 File Offset: 0x00007D05
		public List<PngChunk> GetQueuedById(string id, string innerid)
		{
			return ChunksList.GetXById(this.queuedChunks, id, innerid);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00009B14 File Offset: 0x00007D14
		public PngChunk GetQueuedById1(string id, string innerid, bool failIfMultiple)
		{
			List<PngChunk> queuedById = this.GetQueuedById(id, innerid);
			if (queuedById.Count == 0)
			{
				return null;
			}
			if (queuedById.Count > 1 && (failIfMultiple || !queuedById[0].AllowsMultiple()))
			{
				throw new PngjException("unexpected multiple chunks id=" + id);
			}
			return queuedById[queuedById.Count - 1];
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00009B6D File Offset: 0x00007D6D
		public PngChunk GetQueuedById1(string id, bool failIfMultiple)
		{
			return this.GetQueuedById1(id, null, failIfMultiple);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00009B78 File Offset: 0x00007D78
		public PngChunk GetQueuedById1(string id)
		{
			return this.GetQueuedById1(id, false);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00009B82 File Offset: 0x00007D82
		public bool RemoveChunk(PngChunk c)
		{
			return this.queuedChunks.Remove(c);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009B90 File Offset: 0x00007D90
		public bool Queue(PngChunk chunk)
		{
			this.queuedChunks.Add(chunk);
			return true;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00009BA0 File Offset: 0x00007DA0
		private static bool shouldWrite(PngChunk c, int currentGroup)
		{
			if (currentGroup == 2)
			{
				return c.Id.Equals("PLTE");
			}
			if (currentGroup % 2 == 0)
			{
				throw new PngjOutputException("bad chunk group?");
			}
			int num2;
			int num;
			if (c.mustGoBeforePLTE())
			{
				num = (num2 = 1);
			}
			else if (c.mustGoBeforeIDAT())
			{
				num = 3;
				num2 = (c.mustGoAfterPLTE() ? 3 : 1);
			}
			else
			{
				num = 5;
				num2 = 1;
			}
			int num3 = num;
			if (c.Priority)
			{
				num3 = num2;
			}
			if (ChunkHelper.IsUnknown(c) && c.ChunkGroup > 0)
			{
				num3 = c.ChunkGroup;
			}
			return currentGroup == num3 || (currentGroup > num3 && currentGroup <= num);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00009C34 File Offset: 0x00007E34
		internal int writeChunks(Stream os, int currentGroup)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < this.queuedChunks.Count; i++)
			{
				PngChunk pngChunk = this.queuedChunks[i];
				if (ChunksListForWrite.shouldWrite(pngChunk, currentGroup))
				{
					if (ChunkHelper.IsCritical(pngChunk.Id) && !pngChunk.Id.Equals("PLTE"))
					{
						throw new PngjOutputException("bad chunk queued: " + pngChunk);
					}
					if (this.alreadyWrittenKeys.ContainsKey(pngChunk.Id) && !pngChunk.AllowsMultiple())
					{
						throw new PngjOutputException("duplicated chunk does not allow multiple: " + pngChunk);
					}
					pngChunk.write(os);
					this.chunks.Add(pngChunk);
					this.alreadyWrittenKeys[pngChunk.Id] = (this.alreadyWrittenKeys.ContainsKey(pngChunk.Id) ? (this.alreadyWrittenKeys[pngChunk.Id] + 1) : 1);
					list.Add(i);
					pngChunk.ChunkGroup = currentGroup;
				}
			}
			for (int j = list.Count - 1; j >= 0; j--)
			{
				this.queuedChunks.RemoveAt(list[j]);
			}
			return list.Count;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00009D5E File Offset: 0x00007F5E
		internal List<PngChunk> GetQueuedChunks()
		{
			return this.queuedChunks;
		}

		// Token: 0x04000121 RID: 289
		private List<PngChunk> queuedChunks;

		// Token: 0x04000122 RID: 290
		private Dictionary<string, int> alreadyWrittenKeys;
	}
}
