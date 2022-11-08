using System;
using libffmpeg;

namespace Accord.Video.FFMPEG
{
	// Token: 0x0200015A RID: 346
	internal class ReaderPrivateData
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x000015F0 File Offset: 0x000009F0
		public ReaderPrivateData()
		{
			this.FormatContext = null;
			this.VideoStream = null;
			this.CodecContext = null;
			this.VideoFrame = null;
			this.ConvertContext = null;
			this.Packet = null;
			this.uint8_tsRemaining = 0;
		}

		// Token: 0x04000263 RID: 611
		public unsafe AVFormatContext* FormatContext;

		// Token: 0x04000264 RID: 612
		public unsafe AVStream* VideoStream;

		// Token: 0x04000265 RID: 613
		public unsafe AVCodecContext* CodecContext;

		// Token: 0x04000266 RID: 614
		public unsafe AVFrame* VideoFrame;

		// Token: 0x04000267 RID: 615
		public unsafe SwsContext* ConvertContext;

		// Token: 0x04000268 RID: 616
		public unsafe AVPacket* Packet;

		// Token: 0x04000269 RID: 617
		public int uint8_tsRemaining;
	}
}
