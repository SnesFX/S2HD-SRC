using System;
using System.IO;
using Hjg.Pngcs.Chunks;

namespace Hjg.Pngcs
{
	// Token: 0x02000029 RID: 41
	internal class PngIDatChunkOutputStream : ProgressiveOutputStream
	{
		// Token: 0x0600014D RID: 333 RVA: 0x0000668E File Offset: 0x0000488E
		public PngIDatChunkOutputStream(Stream outputStream_0) : this(outputStream_0, 32768)
		{
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000669C File Offset: 0x0000489C
		public PngIDatChunkOutputStream(Stream outputStream_0, int size) : base((size > 8) ? size : 32768)
		{
			this.outputStream = outputStream_0;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000066B7 File Offset: 0x000048B7
		protected override void FlushBuffer(byte[] b, int len)
		{
			new ChunkRaw(len, ChunkHelper.b_IDAT, false)
			{
				Data = b
			}.WriteChunk(this.outputStream);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000066D7 File Offset: 0x000048D7
		public override void Close()
		{
			this.Flush();
		}

		// Token: 0x0400008F RID: 143
		private const int SIZE_DEFAULT = 32768;

		// Token: 0x04000090 RID: 144
		private readonly Stream outputStream;
	}
}
