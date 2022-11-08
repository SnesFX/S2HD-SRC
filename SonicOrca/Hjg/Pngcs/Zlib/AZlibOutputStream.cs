using System;
using System.IO;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x02000035 RID: 53
	public abstract class AZlibOutputStream : Stream
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00008CA8 File Offset: 0x00006EA8
		public AZlibOutputStream(Stream st, int compressLevel, EDeflateCompressStrategy strat, bool leaveOpen)
		{
			this.rawStream = st;
			this.leaveOpen = leaveOpen;
			this.strategy = strat;
			this.compressLevel = compressLevel;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00008CA1 File Offset: 0x00006EA1
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override long Position
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanTimeout
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001F2 RID: 498
		public abstract string getImplementationId();

		// Token: 0x040000CF RID: 207
		protected readonly Stream rawStream;

		// Token: 0x040000D0 RID: 208
		protected readonly bool leaveOpen;

		// Token: 0x040000D1 RID: 209
		protected int compressLevel;

		// Token: 0x040000D2 RID: 210
		protected EDeflateCompressStrategy strategy;
	}
}
