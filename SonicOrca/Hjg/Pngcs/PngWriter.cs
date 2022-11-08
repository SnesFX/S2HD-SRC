using System;
using System.Collections.Generic;
using System.IO;
using Hjg.Pngcs.Chunks;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs
{
	// Token: 0x02000031 RID: 49
	public class PngWriter
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00007C50 File Offset: 0x00005E50
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00007C58 File Offset: 0x00005E58
		public EDeflateCompressStrategy CompressionStrategy { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00007C61 File Offset: 0x00005E61
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00007C69 File Offset: 0x00005E69
		public int CompLevel { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00007C72 File Offset: 0x00005E72
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00007C7A File Offset: 0x00005E7A
		public bool ShouldCloseStream { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00007C83 File Offset: 0x00005E83
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00007C8B File Offset: 0x00005E8B
		public int IdatMaxSize { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00007C94 File Offset: 0x00005E94
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00007C9C File Offset: 0x00005E9C
		public int CurrentChunkGroup { get; private set; }

		// Token: 0x060001A7 RID: 423 RVA: 0x00007CA5 File Offset: 0x00005EA5
		public PngWriter(Stream outputStream, ImageInfo imgInfo) : this(outputStream, imgInfo, "[NO FILENAME AVAILABLE]")
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00007CB4 File Offset: 0x00005EB4
		public PngWriter(Stream outputStream, ImageInfo imgInfo, string filename)
		{
			this.filename = ((filename == null) ? "" : filename);
			this.outputStream = outputStream;
			this.ImgInfo = imgInfo;
			this.CompLevel = 6;
			this.ShouldCloseStream = true;
			this.IdatMaxSize = 0;
			this.CompressionStrategy = EDeflateCompressStrategy.Filtered;
			this.rowb = new byte[imgInfo.BytesPerRow + 1];
			this.rowbprev = new byte[this.rowb.Length];
			this.rowbfilter = new byte[this.rowb.Length];
			this.chunksList = new ChunksListForWrite(this.ImgInfo);
			this.metadata = new PngMetadata(this.chunksList);
			this.filterStrat = new FilterWriteStrategy(this.ImgInfo, FilterType.FILTER_DEFAULT);
			this.unpackedMode = false;
			this.needsPack = (this.unpackedMode && imgInfo.Packed);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00007DA4 File Offset: 0x00005FA4
		private void init()
		{
			this.datStream = new PngIDatChunkOutputStream(this.outputStream, this.IdatMaxSize);
			this.datStreamDeflated = ZlibStreamFactory.createZlibOutputStream(this.datStream, this.CompLevel, this.CompressionStrategy, true);
			this.WriteSignatureAndIHDR();
			this.WriteFirstChunks();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00007DF4 File Offset: 0x00005FF4
		private void reportResultsForFilter(int rown, FilterType type, bool tentative)
		{
			for (int i = 0; i < this.histox.Length; i++)
			{
				this.histox[i] = 0;
			}
			int num = 0;
			for (int j = 1; j <= this.ImgInfo.BytesPerRow; j++)
			{
				int num2 = (int)this.rowbfilter[j];
				if (num2 < 0)
				{
					num -= num2;
				}
				else
				{
					num += num2;
				}
				this.histox[num2 & 255]++;
			}
			this.filterStrat.fillResultsForFilter(rown, type, (double)num, this.histox, tentative);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00007E79 File Offset: 0x00006079
		private void WriteEndChunk()
		{
			new PngChunkIEND(this.ImgInfo).CreateRawChunk().WriteChunk(this.outputStream);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00007E98 File Offset: 0x00006098
		private void WriteFirstChunks()
		{
			this.CurrentChunkGroup = 1;
			this.chunksList.writeChunks(this.outputStream, this.CurrentChunkGroup);
			this.CurrentChunkGroup = 2;
			int num = this.chunksList.writeChunks(this.outputStream, this.CurrentChunkGroup);
			if (num > 0 && this.ImgInfo.Greyscale)
			{
				throw new PngjOutputException("cannot write palette for this format");
			}
			if (num == 0 && this.ImgInfo.Indexed)
			{
				throw new PngjOutputException("missing palette");
			}
			this.CurrentChunkGroup = 3;
			this.chunksList.writeChunks(this.outputStream, this.CurrentChunkGroup);
			this.CurrentChunkGroup = 4;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00007F40 File Offset: 0x00006140
		private void WriteLastChunks()
		{
			this.CurrentChunkGroup = 5;
			this.chunksList.writeChunks(this.outputStream, this.CurrentChunkGroup);
			List<PngChunk> queuedChunks = this.chunksList.GetQueuedChunks();
			if (queuedChunks.Count > 0)
			{
				throw new PngjOutputException(queuedChunks.Count + " chunks were not written! Eg: " + queuedChunks[0].ToString());
			}
			this.CurrentChunkGroup = 6;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00007FB0 File Offset: 0x000061B0
		private void WriteSignatureAndIHDR()
		{
			this.CurrentChunkGroup = 0;
			PngHelperInternal.WriteBytes(this.outputStream, PngHelperInternal.PNG_ID_SIGNATURE);
			PngChunkIHDR pngChunkIHDR = new PngChunkIHDR(this.ImgInfo);
			pngChunkIHDR.Cols = this.ImgInfo.Cols;
			pngChunkIHDR.Rows = this.ImgInfo.Rows;
			pngChunkIHDR.Bitspc = this.ImgInfo.BitDepth;
			int num = 0;
			if (this.ImgInfo.Alpha)
			{
				num += 4;
			}
			if (this.ImgInfo.Indexed)
			{
				num++;
			}
			if (!this.ImgInfo.Greyscale)
			{
				num += 2;
			}
			pngChunkIHDR.Colormodel = num;
			pngChunkIHDR.Compmeth = 0;
			pngChunkIHDR.Filmeth = 0;
			pngChunkIHDR.Interlaced = 0;
			pngChunkIHDR.CreateRawChunk().WriteChunk(this.outputStream);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00008074 File Offset: 0x00006274
		protected void encodeRowFromByte(byte[] row)
		{
			if (row.Length == this.ImgInfo.SamplesPerRowPacked && !this.needsPack)
			{
				int num = 1;
				if (this.ImgInfo.BitDepth <= 8)
				{
					foreach (byte b in row)
					{
						this.rowb[num++] = b;
					}
					return;
				}
				foreach (byte b2 in row)
				{
					this.rowb[num] = b2;
					num += 2;
				}
				return;
			}
			else
			{
				if (row.Length >= this.ImgInfo.SamplesPerRow && this.needsPack)
				{
					ImageLine.packInplaceByte(this.ImgInfo, row, row, false);
				}
				if (this.ImgInfo.BitDepth <= 8)
				{
					int j = 0;
					int num2 = 1;
					while (j < this.ImgInfo.SamplesPerRowPacked)
					{
						this.rowb[num2++] = row[j];
						j++;
					}
					return;
				}
				int k = 0;
				int num3 = 1;
				while (k < this.ImgInfo.SamplesPerRowPacked)
				{
					this.rowb[num3++] = row[k];
					this.rowb[num3++] = 0;
					k++;
				}
				return;
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00008194 File Offset: 0x00006394
		protected void encodeRowFromInt(int[] row)
		{
			if (row.Length == this.ImgInfo.SamplesPerRowPacked && !this.needsPack)
			{
				int num = 1;
				if (this.ImgInfo.BitDepth <= 8)
				{
					foreach (int num2 in row)
					{
						this.rowb[num++] = (byte)num2;
					}
					return;
				}
				foreach (int num3 in row)
				{
					this.rowb[num++] = (byte)(num3 >> 8);
					this.rowb[num++] = (byte)num3;
				}
				return;
			}
			else
			{
				if (row.Length >= this.ImgInfo.SamplesPerRow && this.needsPack)
				{
					ImageLine.packInplaceInt(this.ImgInfo, row, row, false);
				}
				if (this.ImgInfo.BitDepth <= 8)
				{
					int j = 0;
					int num4 = 1;
					while (j < this.ImgInfo.SamplesPerRowPacked)
					{
						this.rowb[num4++] = (byte)row[j];
						j++;
					}
					return;
				}
				int k = 0;
				int num5 = 1;
				while (k < this.ImgInfo.SamplesPerRowPacked)
				{
					this.rowb[num5++] = (byte)(row[k] >> 8);
					this.rowb[num5++] = (byte)row[k];
					k++;
				}
				return;
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000082CC File Offset: 0x000064CC
		private void FilterRow(int rown)
		{
			if (this.filterStrat.shouldTestAll(rown))
			{
				this.FilterRowNone();
				this.reportResultsForFilter(rown, FilterType.FILTER_NONE, true);
				this.FilterRowSub();
				this.reportResultsForFilter(rown, FilterType.FILTER_SUB, true);
				this.FilterRowUp();
				this.reportResultsForFilter(rown, FilterType.FILTER_UP, true);
				this.FilterRowAverage();
				this.reportResultsForFilter(rown, FilterType.FILTER_AVERAGE, true);
				this.FilterRowPaeth();
				this.reportResultsForFilter(rown, FilterType.FILTER_PAETH, true);
			}
			FilterType filterType = this.filterStrat.gimmeFilterType(rown, true);
			this.rowbfilter[0] = (byte)filterType;
			switch (filterType)
			{
			case FilterType.FILTER_NONE:
				this.FilterRowNone();
				break;
			case FilterType.FILTER_SUB:
				this.FilterRowSub();
				break;
			case FilterType.FILTER_UP:
				this.FilterRowUp();
				break;
			case FilterType.FILTER_AVERAGE:
				this.FilterRowAverage();
				break;
			case FilterType.FILTER_PAETH:
				this.FilterRowPaeth();
				break;
			default:
				throw new PngjOutputException("Filter type " + filterType + " not implemented");
			}
			this.reportResultsForFilter(rown, filterType, false);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000083B4 File Offset: 0x000065B4
		private void prepareEncodeRow(int rown)
		{
			if (this.datStream == null)
			{
				this.init();
			}
			this.rowNum++;
			if (rown >= 0 && this.rowNum != rown)
			{
				throw new PngjOutputException(string.Concat(new object[]
				{
					"rows must be written in order: expected:",
					this.rowNum,
					" passed:",
					rown
				}));
			}
			byte[] array = this.rowb;
			this.rowb = this.rowbprev;
			this.rowbprev = array;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000843C File Offset: 0x0000663C
		private void filterAndSend(int rown)
		{
			this.FilterRow(rown);
			this.datStreamDeflated.Write(this.rowbfilter, 0, this.ImgInfo.BytesPerRow + 1);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00008464 File Offset: 0x00006664
		private void FilterRowAverage()
		{
			int bytesPerRow = this.ImgInfo.BytesPerRow;
			int num = 1 - this.ImgInfo.BytesPixel;
			int i = 1;
			while (i <= bytesPerRow)
			{
				this.rowbfilter[i] = this.rowb[i] - (this.rowbprev[i] + ((num > 0) ? this.rowb[num] : 0)) / 2;
				i++;
				num++;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000084C8 File Offset: 0x000066C8
		private void FilterRowNone()
		{
			for (int i = 1; i <= this.ImgInfo.BytesPerRow; i++)
			{
				this.rowbfilter[i] = this.rowb[i];
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000084FC File Offset: 0x000066FC
		private void FilterRowPaeth()
		{
			int bytesPerRow = this.ImgInfo.BytesPerRow;
			int num = 1 - this.ImgInfo.BytesPixel;
			int i = 1;
			while (i <= bytesPerRow)
			{
				this.rowbfilter[i] = (byte)((int)this.rowb[i] - PngHelperInternal.FilterPaethPredictor((int)((num > 0) ? this.rowb[num] : 0), (int)this.rowbprev[i], (int)((num > 0) ? this.rowbprev[num] : 0)));
				i++;
				num++;
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00008570 File Offset: 0x00006770
		private void FilterRowSub()
		{
			int i;
			for (i = 1; i <= this.ImgInfo.BytesPixel; i++)
			{
				this.rowbfilter[i] = this.rowb[i];
			}
			int num = 1;
			i = this.ImgInfo.BytesPixel + 1;
			while (i <= this.ImgInfo.BytesPerRow)
			{
				this.rowbfilter[i] = this.rowb[i] - this.rowb[num];
				i++;
				num++;
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000085E8 File Offset: 0x000067E8
		private void FilterRowUp()
		{
			for (int i = 1; i <= this.ImgInfo.BytesPerRow; i++)
			{
				this.rowbfilter[i] = this.rowb[i] - this.rowbprev[i];
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008628 File Offset: 0x00006828
		private long SumRowbfilter()
		{
			long num = 0L;
			for (int i = 1; i <= this.ImgInfo.BytesPerRow; i++)
			{
				if (this.rowbfilter[i] < 0)
				{
					num -= (long)((ulong)this.rowbfilter[i]);
				}
				else
				{
					num += (long)((ulong)this.rowbfilter[i]);
				}
			}
			return num;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00008674 File Offset: 0x00006874
		private void CopyChunks(PngReader reader, int copy_mask, bool onlyAfterIdat)
		{
			bool flag = this.CurrentChunkGroup >= 4;
			if (onlyAfterIdat && reader.CurrentChunkGroup < 6)
			{
				throw new PngjException("tried to copy last chunks but reader has not ended");
			}
			foreach (PngChunk pngChunk in reader.GetChunksList().GetChunks())
			{
				if (pngChunk.ChunkGroup >= 4 || !flag)
				{
					bool flag2 = false;
					if (pngChunk.Crit)
					{
						if (pngChunk.Id.Equals("PLTE"))
						{
							if (this.ImgInfo.Indexed && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_PALETTE))
							{
								flag2 = true;
							}
							if (!this.ImgInfo.Greyscale && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_ALL))
							{
								flag2 = true;
							}
						}
					}
					else
					{
						bool flag3 = pngChunk is PngChunkTextVar;
						bool safe = pngChunk.Safe;
						if (ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_ALL))
						{
							flag2 = true;
						}
						if (safe && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_ALL_SAFE))
						{
							flag2 = true;
						}
						if (pngChunk.Id.Equals("tRNS") && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_TRANSPARENCY))
						{
							flag2 = true;
						}
						if (pngChunk.Id.Equals("pHYs") && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_PHYS))
						{
							flag2 = true;
						}
						if (flag3 && ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_TEXTUAL))
						{
							flag2 = true;
						}
						if (ChunkHelper.maskMatch(copy_mask, ChunkCopyBehaviour.COPY_ALMOSTALL) && (!ChunkHelper.IsUnknown(pngChunk) && !flag3) && !pngChunk.Id.Equals("hIST") && !pngChunk.Id.Equals("tIME"))
						{
							flag2 = true;
						}
						if (pngChunk is PngChunkSkipped)
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						this.chunksList.Queue(PngChunk.CloneChunk<PngChunk>(pngChunk, this.ImgInfo));
					}
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00008858 File Offset: 0x00006A58
		public void CopyChunksFirst(PngReader reader, int copy_mask)
		{
			this.CopyChunks(reader, copy_mask, false);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00008863 File Offset: 0x00006A63
		public void CopyChunksLast(PngReader reader, int copy_mask)
		{
			this.CopyChunks(reader, copy_mask, true);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00008870 File Offset: 0x00006A70
		public double ComputeCompressionRatio()
		{
			if (this.CurrentChunkGroup < 6)
			{
				throw new PngjException("must be called after End()");
			}
			double num = (double)this.datStream.GetCountFlushed();
			double num2 = (double)((this.ImgInfo.BytesPerRow + 1) * this.ImgInfo.Rows);
			return num / num2;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000088BC File Offset: 0x00006ABC
		public void End()
		{
			if (this.rowNum != this.ImgInfo.Rows - 1)
			{
				throw new PngjOutputException("all rows have not been written");
			}
			try
			{
				this.datStreamDeflated.Close();
				this.datStream.Close();
				this.WriteLastChunks();
				this.WriteEndChunk();
				if (this.ShouldCloseStream)
				{
					this.outputStream.Close();
				}
			}
			catch (IOException cause)
			{
				throw new PngjOutputException(cause);
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00008938 File Offset: 0x00006B38
		public string GetFilename()
		{
			return this.filename;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00008940 File Offset: 0x00006B40
		public void WriteRow(ImageLine imgline, int rownumber)
		{
			this.SetUseUnPackedMode(imgline.SamplesUnpacked);
			if (imgline.SampleType == ImageLine.ESampleType.INT)
			{
				this.WriteRowInt(imgline.Scanline, rownumber);
				return;
			}
			this.WriteRowByte(imgline.ScanlineB, rownumber);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00008971 File Offset: 0x00006B71
		public void WriteRow(int[] newrow)
		{
			this.WriteRow(newrow, -1);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000897B File Offset: 0x00006B7B
		public void WriteRow(int[] newrow, int rown)
		{
			this.WriteRowInt(newrow, rown);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00008985 File Offset: 0x00006B85
		public void WriteRowInt(int[] newrow, int rown)
		{
			this.prepareEncodeRow(rown);
			this.encodeRowFromInt(newrow);
			this.filterAndSend(rown);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000899C File Offset: 0x00006B9C
		public void WriteRowByte(byte[] newrow, int rown)
		{
			this.prepareEncodeRow(rown);
			this.encodeRowFromByte(newrow);
			this.filterAndSend(rown);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000089B4 File Offset: 0x00006BB4
		public void WriteRowsInt(int[][] image)
		{
			for (int i = 0; i < this.ImgInfo.Rows; i++)
			{
				this.WriteRowInt(image[i], i);
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000089E4 File Offset: 0x00006BE4
		public void WriteRowsByte(byte[][] image)
		{
			for (int i = 0; i < this.ImgInfo.Rows; i++)
			{
				this.WriteRowByte(image[i], i);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008A11 File Offset: 0x00006C11
		public PngMetadata GetMetadata()
		{
			return this.metadata;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00008A19 File Offset: 0x00006C19
		public ChunksListForWrite GetChunksList()
		{
			return this.chunksList;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00008A21 File Offset: 0x00006C21
		public void SetFilterType(FilterType filterType)
		{
			this.filterStrat = new FilterWriteStrategy(this.ImgInfo, filterType);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00008A35 File Offset: 0x00006C35
		public bool IsUnpackedMode()
		{
			return this.unpackedMode;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008A3D File Offset: 0x00006C3D
		public void SetUseUnPackedMode(bool useUnpackedMode)
		{
			this.unpackedMode = useUnpackedMode;
			this.needsPack = (this.unpackedMode && this.ImgInfo.Packed);
		}

		// Token: 0x040000B2 RID: 178
		public readonly ImageInfo ImgInfo;

		// Token: 0x040000B3 RID: 179
		protected readonly string filename;

		// Token: 0x040000B4 RID: 180
		private FilterWriteStrategy filterStrat;

		// Token: 0x040000B9 RID: 185
		private readonly PngMetadata metadata;

		// Token: 0x040000BA RID: 186
		private readonly ChunksListForWrite chunksList;

		// Token: 0x040000BB RID: 187
		protected byte[] rowb;

		// Token: 0x040000BC RID: 188
		protected byte[] rowbprev;

		// Token: 0x040000BD RID: 189
		protected byte[] rowbfilter;

		// Token: 0x040000BF RID: 191
		private int rowNum = -1;

		// Token: 0x040000C0 RID: 192
		private readonly Stream outputStream;

		// Token: 0x040000C1 RID: 193
		private PngIDatChunkOutputStream datStream;

		// Token: 0x040000C2 RID: 194
		private AZlibOutputStream datStreamDeflated;

		// Token: 0x040000C3 RID: 195
		private int[] histox = new int[256];

		// Token: 0x040000C4 RID: 196
		private bool unpackedMode;

		// Token: 0x040000C5 RID: 197
		private bool needsPack;
	}
}
