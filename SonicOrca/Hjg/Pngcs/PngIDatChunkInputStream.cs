using System;
using System.Collections.Generic;
using System.IO;
using Hjg.Pngcs.Chunks;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs
{
	// Token: 0x02000028 RID: 40
	internal class PngIDatChunkInputStream : Stream
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00006325 File Offset: 0x00004525
		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00006325 File Offset: 0x00004525
		public override void SetLength(long value)
		{
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00006327 File Offset: 0x00004527
		public override long Seek(long offset, SeekOrigin origin)
		{
			return -1L;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00006325 File Offset: 0x00004525
		public override void Flush()
		{
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600013B RID: 315 RVA: 0x0000632B File Offset: 0x0000452B
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00006333 File Offset: 0x00004533
		public override long Position { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000633C File Offset: 0x0000453C
		public override long Length
		{
			get
			{
				return 0L;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600013E RID: 318 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00006344 File Offset: 0x00004544
		public PngIDatChunkInputStream(Stream iStream, int lenFirstChunk, long offset_0)
		{
			this.idLastChunk = new byte[4];
			this.toReadThisChunk = 0;
			this.ended = false;
			this.foundChunksInfo = new List<PngIDatChunkInputStream.IdatChunkInfo>();
			this.offset = offset_0;
			this.checkCrc = true;
			this.inputStream = iStream;
			this.crcEngine = new CRC32();
			this.lenLastChunk = lenFirstChunk;
			this.toReadThisChunk = lenFirstChunk;
			Array.Copy(ChunkHelper.b_IDAT, 0, this.idLastChunk, 0, 4);
			this.crcEngine.Update(this.idLastChunk, 0, 4);
			this.foundChunksInfo.Add(new PngIDatChunkInputStream.IdatChunkInfo(this.lenLastChunk, offset_0 - 8L));
			if (this.lenLastChunk == 0)
			{
				this.EndChunkGoForNext();
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000063F8 File Offset: 0x000045F8
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00006400 File Offset: 0x00004600
		private void EndChunkGoForNext()
		{
			for (;;)
			{
				int num = PngHelperInternal.ReadInt4(this.inputStream);
				this.offset += 4L;
				if (this.checkCrc)
				{
					int value = (int)this.crcEngine.GetValue();
					if (this.lenLastChunk > 0 && num != value)
					{
						break;
					}
					this.crcEngine.Reset();
				}
				this.lenLastChunk = PngHelperInternal.ReadInt4(this.inputStream);
				if (this.lenLastChunk < 0)
				{
					goto Block_3;
				}
				this.toReadThisChunk = this.lenLastChunk;
				PngHelperInternal.ReadBytes(this.inputStream, this.idLastChunk, 0, 4);
				this.offset += 8L;
				this.ended = !PngCsUtils.arraysEqual4(this.idLastChunk, ChunkHelper.b_IDAT);
				if (!this.ended)
				{
					this.foundChunksInfo.Add(new PngIDatChunkInputStream.IdatChunkInfo(this.lenLastChunk, this.offset - 8L));
					if (this.checkCrc)
					{
						this.crcEngine.Update(this.idLastChunk, 0, 4);
					}
				}
				if (this.lenLastChunk != 0 || this.ended)
				{
					return;
				}
			}
			throw new PngjBadCrcException("error reading idat; offset: " + this.offset);
			Block_3:
			throw new PngjInputException("invalid len for chunk: " + this.lenLastChunk);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00006540 File Offset: 0x00004740
		public void ForceChunkEnd()
		{
			if (!this.ended)
			{
				byte[] array = new byte[this.toReadThisChunk];
				PngHelperInternal.ReadBytes(this.inputStream, array, 0, this.toReadThisChunk);
				if (this.checkCrc)
				{
					this.crcEngine.Update(array, 0, this.toReadThisChunk);
				}
				this.EndChunkGoForNext();
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006598 File Offset: 0x00004798
		public override int Read(byte[] b, int off, int len_0)
		{
			if (this.ended)
			{
				return -1;
			}
			if (this.toReadThisChunk == 0)
			{
				throw new Exception("this should not happen");
			}
			int num = this.inputStream.Read(b, off, (len_0 >= this.toReadThisChunk) ? this.toReadThisChunk : len_0);
			if (num == -1)
			{
				num = -2;
			}
			if (num > 0)
			{
				if (this.checkCrc)
				{
					this.crcEngine.Update(b, off, num);
				}
				this.offset += (long)num;
				this.toReadThisChunk -= num;
			}
			if (num >= 0 && this.toReadThisChunk == 0)
			{
				this.EndChunkGoForNext();
			}
			return num;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006633 File Offset: 0x00004833
		public int Read(byte[] b)
		{
			return this.Read(b, 0, b.Length);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00006640 File Offset: 0x00004840
		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (this.Read(array, 0, 1) >= 0)
			{
				return (int)array[0];
			}
			return -1;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00006665 File Offset: 0x00004865
		public int GetLenLastChunk()
		{
			return this.lenLastChunk;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000666D File Offset: 0x0000486D
		public byte[] GetIdLastChunk()
		{
			return this.idLastChunk;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00006675 File Offset: 0x00004875
		public long GetOffset()
		{
			return this.offset;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000667D File Offset: 0x0000487D
		public bool IsEnded()
		{
			return this.ended;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00006685 File Offset: 0x00004885
		internal void DisableCrcCheck()
		{
			this.checkCrc = false;
		}

		// Token: 0x04000085 RID: 133
		private readonly Stream inputStream;

		// Token: 0x04000086 RID: 134
		private readonly CRC32 crcEngine;

		// Token: 0x04000087 RID: 135
		private bool checkCrc;

		// Token: 0x04000088 RID: 136
		private int lenLastChunk;

		// Token: 0x04000089 RID: 137
		private byte[] idLastChunk;

		// Token: 0x0400008A RID: 138
		private int toReadThisChunk;

		// Token: 0x0400008B RID: 139
		private bool ended;

		// Token: 0x0400008C RID: 140
		private long offset;

		// Token: 0x0400008E RID: 142
		public IList<PngIDatChunkInputStream.IdatChunkInfo> foundChunksInfo;

		// Token: 0x020001AF RID: 431
		public class IdatChunkInfo
		{
			// Token: 0x0600126B RID: 4715 RVA: 0x000480ED File Offset: 0x000462ED
			public IdatChunkInfo(int len_0, long offset_1)
			{
				this.len = len_0;
				this.offset = offset_1;
			}

			// Token: 0x04000A43 RID: 2627
			public readonly int len;

			// Token: 0x04000A44 RID: 2628
			public readonly long offset;
		}
	}
}
