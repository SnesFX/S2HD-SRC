using System;
using libffmpeg;

namespace Accord.Video.FFMPEG
{
	// Token: 0x02000286 RID: 646
	internal class WriterPrivateData
	{
		// Token: 0x06000119 RID: 281 RVA: 0x00002CEC File Offset: 0x000020EC
		public WriterPrivateData()
		{
			this.FormatContext = null;
			this.VideoStream = null;
			this.VideoFrame = null;
			this.ConvertContext = null;
			this.ConvertContextGrayscale = null;
			this.VideoOutputBuffer = null;
			this.AudioStream = null;
			this.AudioEncodeBuffer = null;
			this.AudioEncodeBufferSize = 0;
			this.AudioInputSampleSize = 0;
			this.AudioBufferSize = 16777216;
			this.AudioBuffer = <Module>.new[](16777216UL);
			this.AudioBufferSizeCurrent = 0;
		}

		// Token: 0x04000331 RID: 817
		public unsafe AVFormatContext* FormatContext;

		// Token: 0x04000332 RID: 818
		public unsafe AVStream* VideoStream;

		// Token: 0x04000333 RID: 819
		public unsafe AVFrame* VideoFrame;

		// Token: 0x04000334 RID: 820
		public unsafe SwsContext* ConvertContext;

		// Token: 0x04000335 RID: 821
		public unsafe SwsContext* ConvertContextGrayscale;

		// Token: 0x04000336 RID: 822
		public unsafe AVStream* AudioStream;

		// Token: 0x04000337 RID: 823
		public unsafe byte* AudioEncodeBuffer;

		// Token: 0x04000338 RID: 824
		public unsafe sbyte* AudioBuffer;

		// Token: 0x04000339 RID: 825
		public int AudioEncodeBufferSize;

		// Token: 0x0400033A RID: 826
		public int AudioInputSampleSize;

		// Token: 0x0400033B RID: 827
		public int AudioBufferSizeCurrent;

		// Token: 0x0400033C RID: 828
		public int AudioBufferSize;

		// Token: 0x0400033D RID: 829
		public int SampleRate;

		// Token: 0x0400033E RID: 830
		public int BitRate;

		// Token: 0x0400033F RID: 831
		public int Channels;

		// Token: 0x04000340 RID: 832
		public unsafe byte* VideoOutputBuffer;

		// Token: 0x04000341 RID: 833
		public int VideoOutputBufferSize;
	}
}
