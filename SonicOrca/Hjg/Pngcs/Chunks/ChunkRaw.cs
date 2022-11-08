using System;
using System.IO;
using Hjg.Pngcs.Zlib;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000043 RID: 67
	public class ChunkRaw
	{
		// Token: 0x06000230 RID: 560 RVA: 0x00009698 File Offset: 0x00007898
		internal ChunkRaw(int length, byte[] idbytes, bool alloc)
		{
			this.IdBytes = new byte[4];
			this.Data = null;
			this.crcval = 0;
			this.Length = length;
			Array.Copy(idbytes, 0, this.IdBytes, 0, 4);
			if (alloc)
			{
				this.AllocData();
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000096E4 File Offset: 0x000078E4
		private int ComputeCrc()
		{
			CRC32 crc = PngHelperInternal.GetCRC();
			crc.Reset();
			crc.Update(this.IdBytes, 0, 4);
			if (this.Length > 0)
			{
				crc.Update(this.Data, 0, this.Length);
			}
			return (int)crc.GetValue();
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00009730 File Offset: 0x00007930
		internal void WriteChunk(Stream os)
		{
			if (this.IdBytes.Length != 4)
			{
				throw new PngjOutputException("bad chunkid [" + ChunkHelper.ToString(this.IdBytes) + "]");
			}
			this.crcval = this.ComputeCrc();
			PngHelperInternal.WriteInt4(os, this.Length);
			PngHelperInternal.WriteBytes(os, this.IdBytes);
			if (this.Length > 0)
			{
				PngHelperInternal.WriteBytes(os, this.Data, 0, this.Length);
			}
			PngHelperInternal.WriteInt4(os, this.crcval);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000097B4 File Offset: 0x000079B4
		internal int ReadChunkData(Stream stream, bool checkCrc)
		{
			PngHelperInternal.ReadBytes(stream, this.Data, 0, this.Length);
			this.crcval = PngHelperInternal.ReadInt4(stream);
			if (checkCrc)
			{
				int num = this.ComputeCrc();
				if (num != this.crcval)
				{
					throw new PngjBadCrcException(string.Concat(new object[]
					{
						"crc invalid for chunk ",
						this.ToString(),
						" calc=",
						num,
						" read=",
						this.crcval
					}));
				}
			}
			return this.Length + 4;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00009844 File Offset: 0x00007A44
		internal MemoryStream GetAsByteStream()
		{
			return new MemoryStream(this.Data);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00009851 File Offset: 0x00007A51
		private void AllocData()
		{
			if (this.Data == null || this.Data.Length < this.Length)
			{
				this.Data = new byte[this.Length];
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000987C File Offset: 0x00007A7C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"chunkid=",
				ChunkHelper.ToString(this.IdBytes),
				" len=",
				this.Length
			});
		}

		// Token: 0x04000114 RID: 276
		public readonly int Length;

		// Token: 0x04000115 RID: 277
		public readonly byte[] IdBytes;

		// Token: 0x04000116 RID: 278
		public byte[] Data;

		// Token: 0x04000117 RID: 279
		private int crcval;
	}
}
