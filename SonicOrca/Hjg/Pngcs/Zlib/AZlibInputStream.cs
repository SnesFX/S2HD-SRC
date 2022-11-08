using System;
using System.IO;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x02000034 RID: 52
	public abstract class AZlibInputStream : Stream
	{
		// Token: 0x060001DB RID: 475 RVA: 0x00008C8B File Offset: 0x00006E8B
		public AZlibInputStream(Stream st, bool leaveOpen)
		{
			this.rawStream = st;
			this.leaveOpen = leaveOpen;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00008CA1 File Offset: 0x00006EA1
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00008CA1 File Offset: 0x00006EA1
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

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanTimeout
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001E6 RID: 486
		public abstract string getImplementationId();

		// Token: 0x040000CD RID: 205
		protected readonly Stream rawStream;

		// Token: 0x040000CE RID: 206
		protected readonly bool leaveOpen;
	}
}
