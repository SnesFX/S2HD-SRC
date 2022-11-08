using System;
using System.IO;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x0200003B RID: 59
	public class ZlibStreamFactory
	{
		// Token: 0x0600020A RID: 522 RVA: 0x00009218 File Offset: 0x00007418
		public static AZlibInputStream createZlibInputStream(Stream st, bool leaveOpen)
		{
			return new ZlibInputStreamMs(st, leaveOpen);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00009221 File Offset: 0x00007421
		public static AZlibInputStream createZlibInputStream(Stream st)
		{
			return ZlibStreamFactory.createZlibInputStream(st, false);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000922A File Offset: 0x0000742A
		public static AZlibOutputStream createZlibOutputStream(Stream st, int compressLevel, EDeflateCompressStrategy strat, bool leaveOpen)
		{
			return new ZlibOutputStreamMs(st, compressLevel, strat, leaveOpen);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00009235 File Offset: 0x00007435
		public static AZlibOutputStream createZlibOutputStream(Stream st)
		{
			return ZlibStreamFactory.createZlibOutputStream(st, false);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000923E File Offset: 0x0000743E
		public static AZlibOutputStream createZlibOutputStream(Stream st, bool leaveOpen)
		{
			return ZlibStreamFactory.createZlibOutputStream(st, 6, EDeflateCompressStrategy.Default, leaveOpen);
		}
	}
}
