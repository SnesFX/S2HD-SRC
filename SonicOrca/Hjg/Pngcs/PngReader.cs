using System;
using System.Collections.Generic;
using System.IO;
using Hjg.Pngcs.Chunks;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs
{
	// Token: 0x02000030 RID: 48
	public class PngReader
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006725 File Offset: 0x00004925
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000672D File Offset: 0x0000492D
		public ImageInfo ImgInfo { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006736 File Offset: 0x00004936
		// (set) Token: 0x06000168 RID: 360 RVA: 0x0000673E File Offset: 0x0000493E
		public ChunkLoadBehaviour ChunkLoadBehaviour { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00006747 File Offset: 0x00004947
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000674F File Offset: 0x0000494F
		public bool ShouldCloseStream { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00006758 File Offset: 0x00004958
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00006760 File Offset: 0x00004960
		public long MaxBytesMetadata { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00006769 File Offset: 0x00004969
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00006771 File Offset: 0x00004971
		public long MaxTotalBytesRead { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600016F RID: 367 RVA: 0x0000677A File Offset: 0x0000497A
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00006782 File Offset: 0x00004982
		public int SkipChunkMaxSize { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000171 RID: 369 RVA: 0x0000678B File Offset: 0x0000498B
		// (set) Token: 0x06000172 RID: 370 RVA: 0x00006793 File Offset: 0x00004993
		public string[] SkipChunkIds { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000173 RID: 371 RVA: 0x0000679C File Offset: 0x0000499C
		// (set) Token: 0x06000174 RID: 372 RVA: 0x000067A4 File Offset: 0x000049A4
		public int CurrentChunkGroup { get; private set; }

		// Token: 0x06000175 RID: 373 RVA: 0x000067AD File Offset: 0x000049AD
		public PngReader(Stream inputStream) : this(inputStream, "[NO FILENAME AVAILABLE]")
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000067BC File Offset: 0x000049BC
		public PngReader(Stream inputStream, string filename)
		{
			this.filename = ((filename == null) ? "" : filename);
			this.inputStream = inputStream;
			this.chunksList = new ChunksList(null);
			this.metadata = new PngMetadata(this.chunksList);
			this.offset = 0L;
			this.CurrentChunkGroup = -1;
			this.ShouldCloseStream = true;
			this.MaxBytesMetadata = 5242880L;
			this.MaxTotalBytesRead = 209715200L;
			this.SkipChunkMaxSize = 2097152;
			this.SkipChunkIds = new string[]
			{
				"fdAT"
			};
			this.ChunkLoadBehaviour = ChunkLoadBehaviour.LOAD_CHUNK_ALWAYS;
			byte[] array = new byte[8];
			PngHelperInternal.ReadBytes(inputStream, array, 0, array.Length);
			this.offset += (long)array.Length;
			if (!PngCsUtils.arraysEqual(array, PngHelperInternal.PNG_ID_SIGNATURE))
			{
				throw new PngjInputException("Bad PNG signature");
			}
			this.CurrentChunkGroup = 0;
			int num = PngHelperInternal.ReadInt4(inputStream);
			this.offset += 4L;
			if (num != 13)
			{
				throw new Exception("IDHR chunk len != 13 ?? " + num);
			}
			byte[] array2 = new byte[4];
			PngHelperInternal.ReadBytes(inputStream, array2, 0, 4);
			if (!PngCsUtils.arraysEqual4(array2, ChunkHelper.b_IHDR))
			{
				throw new PngjInputException("IHDR not found as first chunk??? [" + ChunkHelper.ToString(array2) + "]");
			}
			this.offset += 4L;
			PngChunkIHDR pngChunkIHDR = (PngChunkIHDR)this.ReadChunk(array2, num, false);
			bool alpha = (pngChunkIHDR.Colormodel & 4) != 0;
			bool palette = (pngChunkIHDR.Colormodel & 1) != 0;
			bool grayscale = pngChunkIHDR.Colormodel == 0 || pngChunkIHDR.Colormodel == 4;
			this.ImgInfo = new ImageInfo(pngChunkIHDR.Cols, pngChunkIHDR.Rows, pngChunkIHDR.Bitspc, alpha, grayscale, palette);
			this.rowb = new byte[this.ImgInfo.BytesPerRow + 1];
			this.rowbprev = new byte[this.rowb.Length];
			this.rowbfilter = new byte[this.rowb.Length];
			this.interlaced = (pngChunkIHDR.Interlaced == 1);
			this.deinterlacer = (this.interlaced ? new PngDeinterlacer(this.ImgInfo) : null);
			if (pngChunkIHDR.Filmeth != 0 || pngChunkIHDR.Compmeth != 0 || (pngChunkIHDR.Interlaced & 65534) != 0)
			{
				throw new PngjInputException("compmethod or filtermethod or interlaced unrecognized");
			}
			if (pngChunkIHDR.Colormodel < 0 || pngChunkIHDR.Colormodel > 6 || pngChunkIHDR.Colormodel == 1 || pngChunkIHDR.Colormodel == 5)
			{
				throw new PngjInputException("Invalid colormodel " + pngChunkIHDR.Colormodel);
			}
			if (pngChunkIHDR.Bitspc != 1 && pngChunkIHDR.Bitspc != 2 && pngChunkIHDR.Bitspc != 4 && pngChunkIHDR.Bitspc != 8 && pngChunkIHDR.Bitspc != 16)
			{
				throw new PngjInputException("Invalid bit depth " + pngChunkIHDR.Bitspc);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006A9C File Offset: 0x00004C9C
		private bool FirstChunksNotYetRead()
		{
			return this.CurrentChunkGroup < 1;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006AA8 File Offset: 0x00004CA8
		private void ReadLastAndClose()
		{
			if (this.CurrentChunkGroup < 5)
			{
				try
				{
					this.idatIstream.Close();
				}
				catch (Exception)
				{
				}
				this.ReadLastChunks();
			}
			this.Close();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00006AEC File Offset: 0x00004CEC
		private void Close()
		{
			if (this.CurrentChunkGroup < 6)
			{
				try
				{
					this.idatIstream.Close();
				}
				catch (Exception)
				{
				}
				this.CurrentChunkGroup = 6;
			}
			if (this.ShouldCloseStream)
			{
				this.inputStream.Close();
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006B3C File Offset: 0x00004D3C
		private void UnfilterRow(int nbytes)
		{
			int num = (int)this.rowbfilter[0];
			switch (num)
			{
			case 0:
				this.UnfilterRowNone(nbytes);
				break;
			case 1:
				this.UnfilterRowSub(nbytes);
				break;
			case 2:
				this.UnfilterRowUp(nbytes);
				break;
			case 3:
				this.UnfilterRowAverage(nbytes);
				break;
			case 4:
				this.UnfilterRowPaeth(nbytes);
				break;
			default:
				throw new PngjInputException("Filter type " + num + " not implemented");
			}
			if (this.crctest != null)
			{
				this.crctest.Update(this.rowb, 1, nbytes);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006BD4 File Offset: 0x00004DD4
		private void UnfilterRowAverage(int nbytes)
		{
			int num = 1 - this.ImgInfo.BytesPixel;
			int i = 1;
			while (i <= nbytes)
			{
				int num2 = (int)((num > 0) ? this.rowb[num] : 0);
				this.rowb[i] = (byte)((int)this.rowbfilter[i] + (num2 + (int)(this.rowbprev[i] & byte.MaxValue)) / 2);
				i++;
				num++;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006C34 File Offset: 0x00004E34
		private void UnfilterRowNone(int nbytes)
		{
			for (int i = 1; i <= nbytes; i++)
			{
				this.rowb[i] = this.rowbfilter[i];
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006C60 File Offset: 0x00004E60
		private void UnfilterRowPaeth(int nbytes)
		{
			int num = 1 - this.ImgInfo.BytesPixel;
			int i = 1;
			while (i <= nbytes)
			{
				int a = (int)((num > 0) ? this.rowb[num] : 0);
				int c = (int)((num > 0) ? this.rowbprev[num] : 0);
				this.rowb[i] = (byte)((int)this.rowbfilter[i] + PngHelperInternal.FilterPaethPredictor(a, (int)this.rowbprev[i], c));
				i++;
				num++;
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00006CCC File Offset: 0x00004ECC
		private void UnfilterRowSub(int nbytes)
		{
			int i;
			for (i = 1; i <= this.ImgInfo.BytesPixel; i++)
			{
				this.rowb[i] = this.rowbfilter[i];
			}
			int num = 1;
			i = this.ImgInfo.BytesPixel + 1;
			while (i <= nbytes)
			{
				this.rowb[i] = this.rowbfilter[i] + this.rowb[num];
				i++;
				num++;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00006D38 File Offset: 0x00004F38
		private void UnfilterRowUp(int nbytes)
		{
			for (int i = 1; i <= nbytes; i++)
			{
				this.rowb[i] = this.rowbfilter[i] + this.rowbprev[i];
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006D6C File Offset: 0x00004F6C
		private void ReadFirstChunks()
		{
			if (!this.FirstChunksNotYetRead())
			{
				return;
			}
			int num = 0;
			bool flag = false;
			byte[] array = new byte[4];
			this.CurrentChunkGroup = 1;
			while (!flag)
			{
				num = PngHelperInternal.ReadInt4(this.inputStream);
				this.offset += 4L;
				if (num < 0)
				{
					break;
				}
				PngHelperInternal.ReadBytes(this.inputStream, array, 0, 4);
				this.offset += 4L;
				if (PngCsUtils.arraysEqual4(array, ChunkHelper.b_IDAT))
				{
					flag = true;
					this.CurrentChunkGroup = 4;
					this.chunksList.AppendReadChunk(new PngChunkIDAT(this.ImgInfo, num, this.offset - 8L), this.CurrentChunkGroup);
					break;
				}
				if (PngCsUtils.arraysEqual4(array, ChunkHelper.b_IEND))
				{
					throw new PngjInputException("END chunk found before image data (IDAT) at offset=" + this.offset);
				}
				string text = ChunkHelper.ToString(array);
				if (text.Equals("PLTE"))
				{
					this.CurrentChunkGroup = 2;
				}
				this.ReadChunk(array, num, false);
				if (text.Equals("PLTE"))
				{
					this.CurrentChunkGroup = 3;
				}
			}
			int num2 = flag ? num : -1;
			if (num2 < 0)
			{
				throw new PngjInputException("first idat chunk not found!");
			}
			this.iIdatCstream = new PngIDatChunkInputStream(this.inputStream, num2, this.offset);
			this.idatIstream = ZlibStreamFactory.createZlibInputStream(this.iIdatCstream, true);
			if (!this.crcEnabled)
			{
				this.iIdatCstream.DisableCrcCheck();
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00006ED0 File Offset: 0x000050D0
		private void ReadLastChunks()
		{
			this.CurrentChunkGroup = 5;
			if (!this.iIdatCstream.IsEnded())
			{
				this.iIdatCstream.ForceChunkEnd();
			}
			int num = this.iIdatCstream.GetLenLastChunk();
			byte[] idLastChunk = this.iIdatCstream.GetIdLastChunk();
			bool flag = false;
			bool flag2 = true;
			while (!flag)
			{
				bool skipforced = false;
				if (!flag2)
				{
					num = PngHelperInternal.ReadInt4(this.inputStream);
					this.offset += 4L;
					if (num < 0)
					{
						throw new PngjInputException("bad len " + num);
					}
					PngHelperInternal.ReadBytes(this.inputStream, idLastChunk, 0, 4);
					this.offset += 4L;
				}
				flag2 = false;
				if (PngCsUtils.arraysEqual4(idLastChunk, ChunkHelper.b_IDAT))
				{
					skipforced = true;
				}
				else if (PngCsUtils.arraysEqual4(idLastChunk, ChunkHelper.b_IEND))
				{
					this.CurrentChunkGroup = 6;
					flag = true;
				}
				this.ReadChunk(idLastChunk, num, skipforced);
			}
			if (!flag)
			{
				throw new PngjInputException("end chunk not found - offset=" + this.offset);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00006FD4 File Offset: 0x000051D4
		private PngChunk ReadChunk(byte[] chunkid, int clen, bool skipforced)
		{
			if (clen < 0)
			{
				throw new PngjInputException("invalid chunk lenght: " + clen);
			}
			if (this.skipChunkIdsSet == null && this.CurrentChunkGroup > 0)
			{
				this.skipChunkIdsSet = new Dictionary<string, int>();
				if (this.SkipChunkIds != null)
				{
					foreach (string key in this.SkipChunkIds)
					{
						this.skipChunkIdsSet.Add(key, 1);
					}
				}
			}
			string text = ChunkHelper.ToString(chunkid);
			bool flag = ChunkHelper.IsCritical(text);
			bool flag2 = skipforced;
			if (this.MaxTotalBytesRead > 0L && (long)clen + this.offset > this.MaxTotalBytesRead)
			{
				throw new PngjInputException(string.Concat(new object[]
				{
					"Maximum total bytes to read exceeeded: ",
					this.MaxTotalBytesRead,
					" offset:",
					this.offset,
					" clen=",
					clen
				}));
			}
			if (this.CurrentChunkGroup > 0 && !ChunkHelper.IsCritical(text))
			{
				flag2 = (flag2 || (this.SkipChunkMaxSize > 0 && clen >= this.SkipChunkMaxSize) || this.skipChunkIdsSet.ContainsKey(text) || (this.MaxBytesMetadata > 0L && (long)clen > this.MaxBytesMetadata - (long)this.bytesChunksLoaded) || !ChunkHelper.ShouldLoad(text, this.ChunkLoadBehaviour));
			}
			PngChunk pngChunk;
			if (flag2)
			{
				PngHelperInternal.SkipBytes(this.inputStream, clen);
				PngHelperInternal.ReadInt4(this.inputStream);
				pngChunk = new PngChunkSkipped(text, this.ImgInfo, clen);
			}
			else
			{
				ChunkRaw chunkRaw = new ChunkRaw(clen, chunkid, true);
				chunkRaw.ReadChunkData(this.inputStream, this.crcEnabled || flag);
				pngChunk = PngChunk.Factory(chunkRaw, this.ImgInfo);
				if (!pngChunk.Crit)
				{
					this.bytesChunksLoaded += chunkRaw.Length;
				}
			}
			pngChunk.Offset = this.offset - 8L;
			this.chunksList.AppendReadChunk(pngChunk, this.CurrentChunkGroup);
			this.offset += (long)clen + 4L;
			return pngChunk;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000071D6 File Offset: 0x000053D6
		internal void logWarn(string warn)
		{
			Console.Error.WriteLine(warn);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000071E3 File Offset: 0x000053E3
		public ChunksList GetChunksList()
		{
			if (this.FirstChunksNotYetRead())
			{
				this.ReadFirstChunks();
			}
			return this.chunksList;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000071F9 File Offset: 0x000053F9
		public PngMetadata GetMetadata()
		{
			if (this.FirstChunksNotYetRead())
			{
				this.ReadFirstChunks();
			}
			return this.metadata;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000720F File Offset: 0x0000540F
		public ImageLine ReadRow(int nrow)
		{
			if (this.imgLine != null && this.imgLine.SampleType == ImageLine.ESampleType.BYTE)
			{
				return this.ReadRowByte(nrow);
			}
			return this.ReadRowInt(nrow);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00007238 File Offset: 0x00005438
		public ImageLine ReadRowInt(int nrow)
		{
			if (this.imgLine == null)
			{
				this.imgLine = new ImageLine(this.ImgInfo, ImageLine.ESampleType.INT, this.unpackedMode);
			}
			if (this.imgLine.Rown == nrow)
			{
				return this.imgLine;
			}
			this.ReadRowInt(this.imgLine.Scanline, nrow);
			this.imgLine.FilterUsed = (FilterType)this.rowbfilter[0];
			this.imgLine.Rown = nrow;
			return this.imgLine;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000072B4 File Offset: 0x000054B4
		public ImageLine ReadRowByte(int nrow)
		{
			if (this.imgLine == null)
			{
				this.imgLine = new ImageLine(this.ImgInfo, ImageLine.ESampleType.BYTE, this.unpackedMode);
			}
			if (this.imgLine.Rown == nrow)
			{
				return this.imgLine;
			}
			this.ReadRowByte(this.imgLine.ScanlineB, nrow);
			this.imgLine.FilterUsed = (FilterType)this.rowbfilter[0];
			this.imgLine.Rown = nrow;
			return this.imgLine;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000732E File Offset: 0x0000552E
		public int[] ReadRow(int[] buffer, int nrow)
		{
			return this.ReadRowInt(buffer, nrow);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007338 File Offset: 0x00005538
		public int[] ReadRowInt(int[] buffer, int nrow)
		{
			if (buffer == null)
			{
				buffer = new int[this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked];
			}
			if (!this.interlaced)
			{
				if (nrow <= this.rowNum)
				{
					throw new PngjInputException("rows must be read in increasing order: " + nrow);
				}
				int bytesRead = 0;
				while (this.rowNum < nrow)
				{
					bytesRead = this.ReadRowRaw(this.rowNum + 1);
				}
				this.decodeLastReadRowToInt(buffer, bytesRead);
			}
			else
			{
				if (this.deinterlacer.getImageInt() == null)
				{
					this.deinterlacer.setImageInt(this.ReadRowsInt().Scanlines);
				}
				Array.Copy(this.deinterlacer.getImageInt()[nrow], 0, buffer, 0, this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked);
			}
			return buffer;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007418 File Offset: 0x00005618
		public byte[] ReadRowByte(byte[] buffer, int nrow)
		{
			if (buffer == null)
			{
				buffer = new byte[this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked];
			}
			if (!this.interlaced)
			{
				if (nrow <= this.rowNum)
				{
					throw new PngjInputException("rows must be read in increasing order: " + nrow);
				}
				int bytesRead = 0;
				while (this.rowNum < nrow)
				{
					bytesRead = this.ReadRowRaw(this.rowNum + 1);
				}
				this.decodeLastReadRowToByte(buffer, bytesRead);
			}
			else
			{
				if (this.deinterlacer.getImageByte() == null)
				{
					this.deinterlacer.setImageByte(this.ReadRowsByte().ScanlinesB);
				}
				Array.Copy(this.deinterlacer.getImageByte()[nrow], 0, buffer, 0, this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked);
			}
			return buffer;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000074F5 File Offset: 0x000056F5
		[Obsolete("GetRow is deprecated,  use ReadRow/ReadRowInt/ReadRowByte instead.")]
		public ImageLine GetRow(int nrow)
		{
			return this.ReadRow(nrow);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00007500 File Offset: 0x00005700
		private void decodeLastReadRowToInt(int[] buffer, int bytesRead)
		{
			if (this.ImgInfo.BitDepth <= 8)
			{
				int i = 0;
				int num = 1;
				while (i < bytesRead)
				{
					buffer[i] = (int)this.rowb[num++];
					i++;
				}
			}
			else
			{
				int num2 = 0;
				int j = 1;
				while (j < bytesRead)
				{
					buffer[num2] = ((int)this.rowb[j++] << 8) + (int)this.rowb[j++];
					num2++;
				}
			}
			if (this.ImgInfo.Packed && this.unpackedMode)
			{
				ImageLine.unpackInplaceInt(this.ImgInfo, buffer, buffer, false);
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000758C File Offset: 0x0000578C
		private void decodeLastReadRowToByte(byte[] buffer, int bytesRead)
		{
			if (this.ImgInfo.BitDepth <= 8)
			{
				Array.Copy(this.rowb, 1, buffer, 0, bytesRead);
			}
			else
			{
				int num = 0;
				for (int i = 1; i < bytesRead; i += 2)
				{
					buffer[num] = this.rowb[i];
					num++;
				}
			}
			if (this.ImgInfo.Packed && this.unpackedMode)
			{
				ImageLine.unpackInplaceByte(this.ImgInfo, buffer, buffer, false);
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x000075F8 File Offset: 0x000057F8
		public ImageLines ReadRowsInt(int rowOffset, int nRows, int rowStep)
		{
			if (nRows < 0)
			{
				nRows = (this.ImgInfo.Rows - rowOffset) / rowStep;
			}
			if (rowStep < 1 || rowOffset < 0 || nRows * rowStep + rowOffset > this.ImgInfo.Rows)
			{
				throw new PngjInputException("bad args");
			}
			ImageLines imageLines = new ImageLines(this.ImgInfo, ImageLine.ESampleType.INT, this.unpackedMode, rowOffset, nRows, rowStep);
			if (!this.interlaced)
			{
				for (int i = 0; i < this.ImgInfo.Rows; i++)
				{
					int bytesRead = this.ReadRowRaw(i);
					int num = imageLines.ImageRowToMatrixRowStrict(i);
					if (num >= 0)
					{
						this.decodeLastReadRowToInt(imageLines.Scanlines[num], bytesRead);
					}
				}
			}
			else
			{
				int[] array = new int[this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked];
				for (int j = 1; j <= 7; j++)
				{
					this.deinterlacer.setPass(j);
					for (int k = 0; k < this.deinterlacer.getRows(); k++)
					{
						int bytesRead2 = this.ReadRowRaw(k);
						int currRowReal = this.deinterlacer.getCurrRowReal();
						int num2 = imageLines.ImageRowToMatrixRowStrict(currRowReal);
						if (num2 >= 0)
						{
							this.decodeLastReadRowToInt(array, bytesRead2);
							this.deinterlacer.deinterlaceInt(array, imageLines.Scanlines[num2], !this.unpackedMode);
						}
					}
				}
			}
			this.End();
			return imageLines;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007752 File Offset: 0x00005952
		public ImageLines ReadRowsInt()
		{
			return this.ReadRowsInt(0, this.ImgInfo.Rows, 1);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007768 File Offset: 0x00005968
		public ImageLines ReadRowsByte(int rowOffset, int nRows, int rowStep)
		{
			if (nRows < 0)
			{
				nRows = (this.ImgInfo.Rows - rowOffset) / rowStep;
			}
			if (rowStep < 1 || rowOffset < 0 || nRows * rowStep + rowOffset > this.ImgInfo.Rows)
			{
				throw new PngjInputException("bad args");
			}
			ImageLines imageLines = new ImageLines(this.ImgInfo, ImageLine.ESampleType.BYTE, this.unpackedMode, rowOffset, nRows, rowStep);
			if (!this.interlaced)
			{
				for (int i = 0; i < this.ImgInfo.Rows; i++)
				{
					int bytesRead = this.ReadRowRaw(i);
					int num = imageLines.ImageRowToMatrixRowStrict(i);
					if (num >= 0)
					{
						this.decodeLastReadRowToByte(imageLines.ScanlinesB[num], bytesRead);
					}
				}
			}
			else
			{
				byte[] array = new byte[this.unpackedMode ? this.ImgInfo.SamplesPerRow : this.ImgInfo.SamplesPerRowPacked];
				for (int j = 1; j <= 7; j++)
				{
					this.deinterlacer.setPass(j);
					for (int k = 0; k < this.deinterlacer.getRows(); k++)
					{
						int bytesRead2 = this.ReadRowRaw(k);
						int currRowReal = this.deinterlacer.getCurrRowReal();
						int num2 = imageLines.ImageRowToMatrixRowStrict(currRowReal);
						if (num2 >= 0)
						{
							this.decodeLastReadRowToByte(array, bytesRead2);
							this.deinterlacer.deinterlaceByte(array, imageLines.ScanlinesB[num2], !this.unpackedMode);
						}
					}
				}
			}
			this.End();
			return imageLines;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000078C2 File Offset: 0x00005AC2
		public ImageLines ReadRowsByte()
		{
			return this.ReadRowsByte(0, this.ImgInfo.Rows, 1);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000078D8 File Offset: 0x00005AD8
		private int ReadRowRaw(int nrow)
		{
			if (nrow == 0 && this.FirstChunksNotYetRead())
			{
				this.ReadFirstChunks();
			}
			if (nrow == 0 && this.interlaced)
			{
				Array.Clear(this.rowb, 0, this.rowb.Length);
			}
			int num = this.ImgInfo.BytesPerRow;
			if (this.interlaced)
			{
				if (nrow < 0 || nrow > this.deinterlacer.getRows() || (nrow != 0 && nrow != this.deinterlacer.getCurrRowSubimg() + 1))
				{
					throw new PngjInputException("invalid row in interlaced mode: " + nrow);
				}
				this.deinterlacer.setRow(nrow);
				num = (this.ImgInfo.BitspPixel * this.deinterlacer.getPixelsToRead() + 7) / 8;
				if (num < 1)
				{
					throw new PngjExceptionInternal("wtf??");
				}
			}
			else if (nrow < 0 || nrow >= this.ImgInfo.Rows || nrow != this.rowNum + 1)
			{
				throw new PngjInputException("invalid row: " + nrow);
			}
			this.rowNum = nrow;
			byte[] array = this.rowb;
			this.rowb = this.rowbprev;
			this.rowbprev = array;
			PngHelperInternal.ReadBytes(this.idatIstream, this.rowbfilter, 0, num + 1);
			this.offset = this.iIdatCstream.GetOffset();
			if (this.offset < 0L)
			{
				throw new PngjExceptionInternal("bad offset ??" + this.offset);
			}
			if (this.MaxTotalBytesRead > 0L && this.offset >= this.MaxTotalBytesRead)
			{
				throw new PngjInputException(string.Concat(new object[]
				{
					"Reading IDAT: Maximum total bytes to read exceeeded: ",
					this.MaxTotalBytesRead,
					" offset:",
					this.offset
				}));
			}
			this.rowb[0] = 0;
			this.UnfilterRow(num);
			this.rowb[0] = this.rowbfilter[0];
			if ((this.rowNum == this.ImgInfo.Rows - 1 && !this.interlaced) || (this.interlaced && this.deinterlacer.isAtLastRow()))
			{
				this.ReadLastAndClose();
			}
			return num;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00007AE8 File Offset: 0x00005CE8
		public void ReadSkippingAllRows()
		{
			if (this.FirstChunksNotYetRead())
			{
				this.ReadFirstChunks();
			}
			this.iIdatCstream.DisableCrcCheck();
			try
			{
				int num;
				do
				{
					num = this.iIdatCstream.Read(this.rowbfilter, 0, this.rowbfilter.Length);
				}
				while (num >= 0);
			}
			catch (IOException cause)
			{
				throw new PngjInputException("error in raw read of IDAT", cause);
			}
			this.offset = this.iIdatCstream.GetOffset();
			if (this.offset < 0L)
			{
				throw new PngjExceptionInternal("bad offset ??" + this.offset);
			}
			if (this.MaxTotalBytesRead > 0L && this.offset >= this.MaxTotalBytesRead)
			{
				throw new PngjInputException(string.Concat(new object[]
				{
					"Reading IDAT: Maximum total bytes to read exceeeded: ",
					this.MaxTotalBytesRead,
					" offset:",
					this.offset
				}));
			}
			this.ReadLastAndClose();
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00007BE0 File Offset: 0x00005DE0
		public override string ToString()
		{
			return "filename=" + this.filename + " " + this.ImgInfo.ToString();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00007C02 File Offset: 0x00005E02
		public void End()
		{
			if (this.CurrentChunkGroup < 6)
			{
				this.Close();
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007C13 File Offset: 0x00005E13
		public bool IsInterlaced()
		{
			return this.interlaced;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007C1B File Offset: 0x00005E1B
		public void SetUnpackedMode(bool unPackedMode)
		{
			this.unpackedMode = unPackedMode;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007C24 File Offset: 0x00005E24
		public bool IsUnpackedMode()
		{
			return this.unpackedMode;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00007C2C File Offset: 0x00005E2C
		public void SetCrcCheckDisabled()
		{
			this.crcEnabled = false;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00007C35 File Offset: 0x00005E35
		internal long GetCrctestVal()
		{
			return (long)((ulong)this.crctest.GetValue());
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007C43 File Offset: 0x00005E43
		internal void InitCrctest()
		{
			this.crctest = new Adler32();
		}

		// Token: 0x04000098 RID: 152
		protected readonly string filename;

		// Token: 0x0400009F RID: 159
		private Dictionary<string, int> skipChunkIdsSet;

		// Token: 0x040000A0 RID: 160
		private readonly PngMetadata metadata;

		// Token: 0x040000A1 RID: 161
		private readonly ChunksList chunksList;

		// Token: 0x040000A2 RID: 162
		protected ImageLine imgLine;

		// Token: 0x040000A3 RID: 163
		protected byte[] rowb;

		// Token: 0x040000A4 RID: 164
		protected byte[] rowbprev;

		// Token: 0x040000A5 RID: 165
		protected byte[] rowbfilter;

		// Token: 0x040000A6 RID: 166
		public readonly bool interlaced;

		// Token: 0x040000A7 RID: 167
		private readonly PngDeinterlacer deinterlacer;

		// Token: 0x040000A8 RID: 168
		private bool crcEnabled = true;

		// Token: 0x040000A9 RID: 169
		private bool unpackedMode;

		// Token: 0x040000AB RID: 171
		protected int rowNum = -1;

		// Token: 0x040000AC RID: 172
		private long offset;

		// Token: 0x040000AD RID: 173
		private int bytesChunksLoaded;

		// Token: 0x040000AE RID: 174
		private readonly Stream inputStream;

		// Token: 0x040000AF RID: 175
		internal AZlibInputStream idatIstream;

		// Token: 0x040000B0 RID: 176
		internal PngIDatChunkInputStream iIdatCstream;

		// Token: 0x040000B1 RID: 177
		protected Adler32 crctest;
	}
}
