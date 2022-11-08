using System;
using System.IO;
using System.IO.Compression;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x0200003A RID: 58
	internal class ZlibOutputStreamMs : AZlibOutputStream
	{
		// Token: 0x06000202 RID: 514 RVA: 0x00008FC7 File Offset: 0x000071C7
		public ZlibOutputStreamMs(Stream st, int compressLevel, EDeflateCompressStrategy strat, bool leaveOpen) : base(st, compressLevel, strat, leaveOpen)
		{
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00008FDF File Offset: 0x000071DF
		public override void WriteByte(byte value)
		{
			if (!this.initdone)
			{
				this.doInit();
			}
			if (this.deflateStream == null)
			{
				this.initStream();
			}
			base.WriteByte(value);
			this.adler32.Update(value);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00009010 File Offset: 0x00007210
		public override void Write(byte[] array, int offset, int count)
		{
			if (count == 0)
			{
				return;
			}
			if (!this.initdone)
			{
				this.doInit();
			}
			if (this.deflateStream == null)
			{
				this.initStream();
			}
			this.deflateStream.Write(array, offset, count);
			this.adler32.Update(array, offset, count);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00009050 File Offset: 0x00007250
		public override void Close()
		{
			if (!this.initdone)
			{
				this.doInit();
			}
			if (this.closed)
			{
				return;
			}
			this.closed = true;
			if (this.deflateStream != null)
			{
				this.deflateStream.Close();
			}
			else
			{
				this.rawStream.WriteByte(3);
				this.rawStream.WriteByte(0);
			}
			uint value = this.adler32.GetValue();
			this.rawStream.WriteByte((byte)(value >> 24 & 255U));
			this.rawStream.WriteByte((byte)(value >> 16 & 255U));
			this.rawStream.WriteByte((byte)(value >> 8 & 255U));
			this.rawStream.WriteByte((byte)(value & 255U));
			if (!this.leaveOpen)
			{
				this.rawStream.Close();
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000911C File Offset: 0x0000731C
		private void initStream()
		{
			if (this.deflateStream != null)
			{
				return;
			}
			CompressionLevel compressionLevel = CompressionLevel.Optimal;
			if (this.compressLevel >= 1 && this.compressLevel <= 5)
			{
				compressionLevel = CompressionLevel.Fastest;
			}
			else if (this.compressLevel == 0)
			{
				compressionLevel = CompressionLevel.NoCompression;
			}
			this.deflateStream = new DeflateStream(this.rawStream, compressionLevel, true);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00009168 File Offset: 0x00007368
		private void doInit()
		{
			if (this.initdone)
			{
				return;
			}
			this.initdone = true;
			int num = 120;
			int num2 = 218;
			if (this.compressLevel >= 5 && this.compressLevel <= 6)
			{
				num2 = 156;
			}
			else if (this.compressLevel >= 3 && this.compressLevel <= 4)
			{
				num2 = 94;
			}
			else if (this.compressLevel <= 2)
			{
				num2 = 1;
			}
			num2 -= (num * 256 + num2) % 31;
			if (num2 < 0)
			{
				num2 += 31;
			}
			this.rawStream.WriteByte((byte)num);
			this.rawStream.WriteByte((byte)num2);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000091FC File Offset: 0x000073FC
		public override void Flush()
		{
			if (this.deflateStream != null)
			{
				this.deflateStream.Flush();
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00009211 File Offset: 0x00007411
		public override string getImplementationId()
		{
			return "Zlib deflater: .Net CLR 4.5";
		}

		// Token: 0x040000E8 RID: 232
		private DeflateStream deflateStream;

		// Token: 0x040000E9 RID: 233
		private Adler32 adler32 = new Adler32();

		// Token: 0x040000EA RID: 234
		private bool initdone;

		// Token: 0x040000EB RID: 235
		private bool closed;
	}
}
