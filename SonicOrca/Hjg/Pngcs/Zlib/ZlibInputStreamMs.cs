using System;
using System.IO;
using System.IO.Compression;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x02000039 RID: 57
	internal class ZlibInputStreamMs : AZlibInputStream
	{
		// Token: 0x060001FB RID: 507 RVA: 0x00008DD8 File Offset: 0x00006FD8
		public ZlibInputStreamMs(Stream st, bool leaveOpen) : base(st, leaveOpen)
		{
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00008DE4 File Offset: 0x00006FE4
		public override int Read(byte[] array, int offset, int count)
		{
			if (!this.initdone)
			{
				this.doInit();
			}
			if (this.deflateStream == null && count > 0)
			{
				this.initStream();
			}
			int num = this.deflateStream.Read(array, offset, count);
			if (num < 1 && this.crcread == null)
			{
				this.crcread = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					this.crcread[i] = (byte)this.rawStream.ReadByte();
				}
			}
			return num;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00008E5C File Offset: 0x0000705C
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
			if (this.crcread == null)
			{
				this.crcread = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					this.crcread[i] = (byte)this.rawStream.ReadByte();
				}
			}
			if (!this.leaveOpen)
			{
				this.rawStream.Close();
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00008EE1 File Offset: 0x000070E1
		private void initStream()
		{
			if (this.deflateStream != null)
			{
				return;
			}
			this.deflateStream = new DeflateStream(this.rawStream, CompressionMode.Decompress, true);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00008F00 File Offset: 0x00007100
		private void doInit()
		{
			if (this.initdone)
			{
				return;
			}
			this.initdone = true;
			int num = this.rawStream.ReadByte();
			int num2 = this.rawStream.ReadByte();
			if (num == -1 || num2 == -1)
			{
				return;
			}
			if ((num & 15) != 8)
			{
				throw new Exception("Bad compression method for ZLIB header: cmf=" + num);
			}
			this.cmdinfo = (num & 240) >> 8;
			this.fdict = ((num2 & 32) != 0);
			if (this.fdict)
			{
				this.dictid = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					this.dictid[i] = (byte)this.rawStream.ReadByte();
				}
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00008FAB File Offset: 0x000071AB
		public override void Flush()
		{
			if (this.deflateStream != null)
			{
				this.deflateStream.Flush();
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00008FC0 File Offset: 0x000071C0
		public override string getImplementationId()
		{
			return "Zlib inflater: .Net CLR 4.5";
		}

		// Token: 0x040000E1 RID: 225
		private DeflateStream deflateStream;

		// Token: 0x040000E2 RID: 226
		private bool initdone;

		// Token: 0x040000E3 RID: 227
		private bool closed;

		// Token: 0x040000E4 RID: 228
		private bool fdict;

		// Token: 0x040000E5 RID: 229
		private int cmdinfo;

		// Token: 0x040000E6 RID: 230
		private byte[] dictid;

		// Token: 0x040000E7 RID: 231
		private byte[] crcread;
	}
}
