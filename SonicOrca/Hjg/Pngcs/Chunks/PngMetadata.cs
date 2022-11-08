using System;
using System.Collections.Generic;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000060 RID: 96
	public class PngMetadata
	{
		// Token: 0x06000342 RID: 834 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
		internal PngMetadata(ChunksList chunks)
		{
			this.chunkList = chunks;
			if (chunks is ChunksListForWrite)
			{
				this.ReadOnly = false;
				return;
			}
			this.ReadOnly = true;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000C6CC File Offset: 0x0000A8CC
		public void QueueChunk(PngChunk chunk, bool lazyOverwrite)
		{
			ChunksListForWrite chunkListW = this.getChunkListW();
			if (this.ReadOnly)
			{
				throw new PngjException("cannot set chunk : readonly metadata");
			}
			if (lazyOverwrite)
			{
				ChunkHelper.TrimList(chunkListW.GetQueuedChunks(), new ChunkPredicateEquiv(chunk));
			}
			chunkListW.Queue(chunk);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000C710 File Offset: 0x0000A910
		public void QueueChunk(PngChunk chunk)
		{
			this.QueueChunk(chunk, true);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000C71A File Offset: 0x0000A91A
		private ChunksListForWrite getChunkListW()
		{
			return (ChunksListForWrite)this.chunkList;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000C728 File Offset: 0x0000A928
		public double[] GetDpi()
		{
			PngChunk byId = this.chunkList.GetById1("pHYs", true);
			if (byId == null)
			{
				return new double[]
				{
					-1.0,
					-1.0
				};
			}
			return ((PngChunkPHYS)byId).GetAsDpi2();
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000C774 File Offset: 0x0000A974
		public void SetDpi(double dpix, double dpiy)
		{
			PngChunkPHYS pngChunkPHYS = new PngChunkPHYS(this.chunkList.imageInfo);
			pngChunkPHYS.SetAsDpi2(dpix, dpiy);
			this.QueueChunk(pngChunkPHYS);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000C7A1 File Offset: 0x0000A9A1
		public void SetDpi(double dpi)
		{
			this.SetDpi(dpi, dpi);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000C7AC File Offset: 0x0000A9AC
		public PngChunkTIME SetTimeNow(int nsecs)
		{
			PngChunkTIME pngChunkTIME = new PngChunkTIME(this.chunkList.imageInfo);
			pngChunkTIME.SetNow(nsecs);
			this.QueueChunk(pngChunkTIME);
			return pngChunkTIME;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000C7D9 File Offset: 0x0000A9D9
		public PngChunkTIME SetTimeNow()
		{
			return this.SetTimeNow(0);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000C7E4 File Offset: 0x0000A9E4
		public PngChunkTIME SetTimeYMDHMS(int year, int mon, int day, int hour, int min, int sec)
		{
			PngChunkTIME pngChunkTIME = new PngChunkTIME(this.chunkList.imageInfo);
			pngChunkTIME.SetYMDHMS(year, mon, day, hour, min, sec);
			this.QueueChunk(pngChunkTIME, true);
			return pngChunkTIME;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000C81A File Offset: 0x0000AA1A
		public PngChunkTIME GetTime()
		{
			return (PngChunkTIME)this.chunkList.GetById1("tIME");
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000C834 File Offset: 0x0000AA34
		public string GetTimeAsString()
		{
			PngChunkTIME time = this.GetTime();
			if (time != null)
			{
				return time.GetAsString();
			}
			return "";
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000C858 File Offset: 0x0000AA58
		public PngChunkTextVar SetText(string key, string val, bool useLatin1, bool compress)
		{
			if (compress && !useLatin1)
			{
				throw new PngjException("cannot compress non latin text");
			}
			PngChunkTextVar pngChunkTextVar;
			if (useLatin1)
			{
				if (compress)
				{
					pngChunkTextVar = new PngChunkZTXT(this.chunkList.imageInfo);
				}
				else
				{
					pngChunkTextVar = new PngChunkTEXT(this.chunkList.imageInfo);
				}
			}
			else
			{
				pngChunkTextVar = new PngChunkITXT(this.chunkList.imageInfo);
				((PngChunkITXT)pngChunkTextVar).SetLangtag(key);
			}
			pngChunkTextVar.SetKeyVal(key, val);
			this.QueueChunk(pngChunkTextVar, true);
			return pngChunkTextVar;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000C8D2 File Offset: 0x0000AAD2
		public PngChunkTextVar SetText(string key, string val)
		{
			return this.SetText(key, val, false, false);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000C8E0 File Offset: 0x0000AAE0
		public List<PngChunkTextVar> GetTxtsForKey(string key)
		{
			List<PngChunkTextVar> list = new List<PngChunkTextVar>();
			foreach (PngChunk pngChunk in this.chunkList.GetById("tEXt", key))
			{
				list.Add((PngChunkTextVar)pngChunk);
			}
			foreach (PngChunk pngChunk2 in this.chunkList.GetById("zTXt", key))
			{
				list.Add((PngChunkTextVar)pngChunk2);
			}
			foreach (PngChunk pngChunk3 in this.chunkList.GetById("iTXt", key))
			{
				list.Add((PngChunkTextVar)pngChunk3);
			}
			return list;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000C9F0 File Offset: 0x0000ABF0
		public string GetTxtForKey(string key)
		{
			string text = "";
			List<PngChunkTextVar> txtsForKey = this.GetTxtsForKey(key);
			if (txtsForKey.Count == 0)
			{
				return text;
			}
			foreach (PngChunkTextVar pngChunkTextVar in txtsForKey)
			{
				text = text + pngChunkTextVar.GetVal() + "\n";
			}
			return text.Trim();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000CA68 File Offset: 0x0000AC68
		public PngChunkPLTE GetPLTE()
		{
			return (PngChunkPLTE)this.chunkList.GetById1("PLTE");
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000CA80 File Offset: 0x0000AC80
		public PngChunkPLTE CreatePLTEChunk()
		{
			PngChunkPLTE pngChunkPLTE = new PngChunkPLTE(this.chunkList.imageInfo);
			this.QueueChunk(pngChunkPLTE);
			return pngChunkPLTE;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000CAA6 File Offset: 0x0000ACA6
		public PngChunkTRNS GetTRNS()
		{
			return (PngChunkTRNS)this.chunkList.GetById1("tRNS");
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000CAC0 File Offset: 0x0000ACC0
		public PngChunkTRNS CreateTRNSChunk()
		{
			PngChunkTRNS pngChunkTRNS = new PngChunkTRNS(this.chunkList.imageInfo);
			this.QueueChunk(pngChunkTRNS);
			return pngChunkTRNS;
		}

		// Token: 0x0400018A RID: 394
		private readonly ChunksList chunkList;

		// Token: 0x0400018B RID: 395
		private readonly bool ReadOnly;
	}
}
