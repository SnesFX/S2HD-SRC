using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using <CppImplementationDetails>;
using Accord.Math;
using libffmpeg;

namespace Accord.Video.FFMPEG
{
	// Token: 0x02000285 RID: 645
	public class VideoFileWriter : IDisposable
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00002BAC File Offset: 0x00001FAC
		private void CheckIfVideoFileIsOpen()
		{
			if (this.data == null)
			{
				throw new IOException("Video file is not open, so can not access its properties.");
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00002BCC File Offset: 0x00001FCC
		private void CheckIfDisposed()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000372C File Offset: 0x00002B2C
		private unsafe void AddAudioSamples(WriterPrivateData data, byte* soundBuffer, int soundBufferSize)
		{
			AVStream* audioStream = data.AudioStream;
			if (audioStream != null)
			{
				AVCodecContext* ptr = *(long*)(audioStream + 8L / (long)sizeof(AVStream));
				cpblk((long)data.AudioBufferSizeCurrent / (long)sizeof(sbyte) + data.AudioBuffer, soundBuffer, (long)soundBufferSize);
				int num = data.AudioBufferSizeCurrent + soundBufferSize;
				data.AudioBufferSizeCurrent = num;
				byte* ptr2 = (byte*)data.AudioBuffer;
				int num2 = num;
				int num3 = data.Channels * data.AudioInputSampleSize * 2;
				if (num2 >= num3)
				{
					do
					{
						AVPacket avpacket;
						<Module>.av_init_packet(&avpacket);
						*(ref avpacket + 32) = <Module>.avcodec_encode_audio2(ptr, (AVPacket*)data.AudioEncodeBuffer, data.AudioEncodeBufferSize, (int*)ptr2);
						*(ref avpacket + 40) = (*(ref avpacket + 40) | 1);
						*(ref avpacket + 36) = *(int*)data.AudioStream;
						*(ref avpacket + 24) = data.AudioEncodeBuffer;
						if (<Module>.av_interleaved_write_frame(data.FormatContext, &avpacket) != null)
						{
							break;
						}
						<Module>.av_free_packet(&avpacket);
						num2 -= num3;
						ptr2 = num3 + ptr2;
					}
					while (num2 >= num3);
				}
				sbyte* audioBuffer = data.AudioBuffer;
				cpblk(audioBuffer, (long)data.AudioBufferSizeCurrent / (long)sizeof(sbyte) + (audioBuffer - (long)num2 / (long)sizeof(sbyte)), (long)num2);
				data.AudioBufferSizeCurrent = num2;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003A68 File Offset: 0x00002E68
		private void !VideoFileWriter()
		{
			this.Close();
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00002BEC File Offset: 0x00001FEC
		public int Width
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_width;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00002C14 File Offset: 0x00002014
		public int Height
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_height;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00002C3C File Offset: 0x0000203C
		public Rational FrameRate
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_frameRate;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00002C68 File Offset: 0x00002068
		public int BitRate
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_bitRate;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00002C90 File Offset: 0x00002090
		public VideoCodec Codec
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_codec;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00002CB8 File Offset: 0x000020B8
		public bool IsOpen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((this.data != null) ? 1 : 0) != 0;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000033A8 File Offset: 0x000027A8
		public VideoFileWriter()
		{
			<Module>.av_register_all();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003A7C File Offset: 0x00002E7C
		private void ~VideoFileWriter()
		{
			this.Close();
			this.disposed = true;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003AF8 File Offset: 0x00002EF8
		public unsafe void Open(string fileName, int width, int height, Rational frameRate, VideoCodec codec, int bitRate, AudioCodec audioCodec, int audioBitrate, int sampleRate, int channels)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
			this.Close();
			this.data = new WriterPrivateData();
			bool flag = false;
			if (((width | height) & 1) == 0)
			{
				if (codec >= VideoCodec.Default && codec < (VideoCodec)<Module>.CODECS_COUNT)
				{
					this.m_width = width;
					this.m_height = height;
					this.m_codec = codec;
					this.m_frameRate = frameRate;
					this.m_bitRate = bitRate;
					this.m_framesCount = 0U;
					this.m_audiocodec = audioCodec;
					try
					{
						char* ptr = (char*)Marshal.StringToHGlobalUni(fileName).ToPointer();
						int num = <Module>.WideCharToMultiByte(65001U, 0, (char*)ptr, -1, null, 0, null, null);
						sbyte* ptr2 = <Module>.new[]((ulong)((long)num));
						<Module>.WideCharToMultiByte(65001U, 0, (char*)ptr, -1, ptr2, num, null, null);
						AVOutputFormat* ptr3 = <Module>.av_guess_format(null, (sbyte*)ptr2, null);
						if (ptr3 == null)
						{
							ptr3 = <Module>.av_guess_format((sbyte*)(&<Module>.??_C@_08KMNKOELM@matroska?$AA@), null, null);
							if (ptr3 == null)
							{
								throw new VideoException("Cannot find suitable output format.");
							}
						}
						this.data.FormatContext = <Module>.avformat_alloc_context();
						AVFormatContext* formatContext = this.data.FormatContext;
						if (formatContext == null)
						{
							throw new VideoException("Cannot allocate format context.");
						}
						*(long*)(formatContext + 16L / (long)sizeof(AVFormatContext)) = ptr3;
						AVPixelFormat pixelFormat;
						AVCodecID codecId;
						if (codec == VideoCodec.Default)
						{
							pixelFormat = (AVPixelFormat)0;
							codecId = (AVCodecID)(*(int*)(ptr3 + 36L / (long)sizeof(AVOutputFormat)));
						}
						else
						{
							long num2 = (long)codec * 4L;
							pixelFormat = (AVPixelFormat)(*(num2 + ref <Module>.pixel_formats));
							codecId = (AVCodecID)(*(num2 + ref <Module>.video_codecs));
						}
						<Module>.Accord.Video.FFMPEG.add_video_stream(this.data, width, height, frameRate, bitRate, codecId, pixelFormat);
						if (audioCodec != AudioCodec.None)
						{
							this.data.SampleRate = sampleRate;
							this.data.BitRate = audioBitrate;
							this.data.Channels = channels;
							<Module>.Accord.Video.FFMPEG.add_audio_stream(this.data, (AVCodecID)(*((long)audioCodec * 4L + ref <Module>.audio_codecs)));
						}
						<Module>.Accord.Video.FFMPEG.open_video(this.data);
						if (audioCodec != AudioCodec.None)
						{
							<Module>.Accord.Video.FFMPEG.open_audio(this.data);
						}
						if ((*(int*)(ptr3 + 44L / (long)sizeof(AVOutputFormat)) & 1) == 0)
						{
							int num3 = <Module>.avio_open((AVIOContext**)(this.data.FormatContext + 32L / (long)sizeof(AVFormatContext)), (sbyte*)ptr2, 2);
							if (num3 < 0)
							{
								string errorMessage = this.GetErrorMessage(num3, fileName);
								throw new IOException("Cannot open the video file. Error code: " + num3 + ". Message: " + errorMessage + " when trying to access: " + fileName);
							}
						}
						<Module>.avformat_write_header(this.data.FormatContext, null);
						flag = true;
						return;
					}
					finally
					{
						if (!flag)
						{
							this.Close();
						}
					}
				}
				throw new ArgumentException("Invalid video codec is specified.");
			}
			throw new ArgumentException("Video file resolution must be a multiple of two.");
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003D8C File Offset: 0x0000318C
		public void Open(string fileName, int width, int height, Rational frameRate, VideoCodec codec, int bitRate)
		{
			this.Open(fileName, width, height, frameRate, codec, bitRate, AudioCodec.None, 0, 0, 0);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00003DC8 File Offset: 0x000031C8
		public void Open(string fileName, int width, int height, Rational frameRate, VideoCodec codec)
		{
			this.Open(fileName, width, height, frameRate, codec, 400000, AudioCodec.None, 0, 0, 0);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00003DEC File Offset: 0x000031EC
		public void Open(string fileName, int width, int height, Rational frameRate)
		{
			this.Open(fileName, width, height, frameRate, VideoCodec.Default, 400000, AudioCodec.None, 0, 0, 0);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00003E10 File Offset: 0x00003210
		public void Open(string fileName, int width, int height)
		{
			Rational frameRate = 25;
			this.Open(fileName, width, height, frameRate, VideoCodec.Default, 400000, AudioCodec.None, 0, 0, 0);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00003840 File Offset: 0x00002C40
		public void WriteVideoFrame(Bitmap frame, TimeSpan timestamp)
		{
			this.WriteVideoFrame(frame, (uint)(this.m_frameRate.Value * timestamp.TotalSeconds));
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00003564 File Offset: 0x00002964
		public unsafe void WriteVideoFrame(Bitmap frame, uint frameIndex)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
			if (this.data == null)
			{
				throw new IOException("A video file was not opened yet.");
			}
			if (frame.PixelFormat != PixelFormat.Format24bppRgb && frame.PixelFormat != PixelFormat.Format32bppArgb && frame.PixelFormat != PixelFormat.Format32bppPArgb && frame.PixelFormat != PixelFormat.Format32bppRgb && frame.PixelFormat != PixelFormat.Format8bppIndexed)
			{
				throw new ArgumentException("The provided bitmap must be 24 or 32 bpp color image or 8 bpp grayscale image.");
			}
			if (frame.Width == this.m_width && frame.Height == this.m_height)
			{
				PixelFormat format = (frame.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
				Rectangle rect = new Rectangle(0, 0, this.m_width, this.m_height);
				BitmapData bitmapData = frame.LockBits(rect, ImageLockMode.ReadOnly, format);
				IntPtr scan = bitmapData.Scan0;
				$ArrayType$$$BY03PEAE $ArrayType$$$BY03PEAE = (void*)scan;
				*(ref $ArrayType$$$BY03PEAE + 8) = 0L;
				*(ref $ArrayType$$$BY03PEAE + 16) = 0L;
				*(ref $ArrayType$$$BY03PEAE + 24) = 0L;
				$ArrayType$$$BY03H stride = bitmapData.Stride;
				*(ref stride + 4) = 0;
				*(ref stride + 8) = 0;
				*(ref stride + 12) = 0;
				if (frame.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					WriterPrivateData writerPrivateData = this.data;
					AVFrame* videoFrame = writerPrivateData.VideoFrame;
					SwsContext* convertContextGrayscale = writerPrivateData.ConvertContextGrayscale;
					int num = 0;
					int height = this.m_height;
					AVFrame* ptr = videoFrame;
					<Module>.sws_scale(convertContextGrayscale, ref $ArrayType$$$BY03PEAE, ref stride, num, height, ptr, ptr + 64L / (long)sizeof(AVFrame));
				}
				else
				{
					WriterPrivateData writerPrivateData = this.data;
					AVFrame* videoFrame = writerPrivateData.VideoFrame;
					SwsContext* convertContext = writerPrivateData.ConvertContext;
					int num2 = 0;
					int height2 = this.m_height;
					AVFrame* ptr2 = videoFrame;
					<Module>.sws_scale(convertContext, ref $ArrayType$$$BY03PEAE, ref stride, num2, height2, ptr2, ptr2 + 64L / (long)sizeof(AVFrame));
				}
				frame.UnlockBits(bitmapData);
				*(long*)(this.data.VideoFrame + 136L / (long)sizeof(AVFrame)) = (long)frameIndex;
				<Module>.Accord.Video.FFMPEG.write_video_frame(this.data);
				this.m_framesCount += 1U;
				return;
			}
			throw new ArgumentException("Bitmap size must be of the same as video size, which was specified on opening video file.");
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00003824 File Offset: 0x00002C24
		public void WriteVideoFrame(Bitmap frame)
		{
			this.WriteVideoFrame(frame, this.m_framesCount);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00003A1C File Offset: 0x00002E1C
		public void WriteAudioFrame(byte[] buffer)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
			if (this.data == null)
			{
				throw new IOException("A video file was not opened yet.");
			}
			ref byte soundBuffer = ref buffer[0];
			this.AddAudioSamples(this.data, ref soundBuffer, buffer.Length);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000033F8 File Offset: 0x000027F8
		public unsafe void Flush()
		{
			WriterPrivateData writerPrivateData = this.data;
			if (writerPrivateData != null)
			{
				AVCodecContext* ptr = *(long*)(writerPrivateData.VideoStream + 8L / (long)sizeof(AVStream));
				AVPacket avpacket;
				<Module>.av_init_packet(&avpacket);
				*(ref avpacket + 24) = 0L;
				*(ref avpacket + 32) = 0;
				int num;
				if (<Module>.avcodec_encode_video2(ptr, &avpacket, null, &num) >= 0)
				{
					while (num != 0)
					{
						if (*(ref avpacket + 8) != -9223372036854775808L)
						{
							*(ref avpacket + 8) = <Module>.av_rescale_q(*(ref avpacket + 8), *(AVRational*)(ptr + 140L / (long)sizeof(AVCodecContext)), *(AVRational*)(this.data.VideoStream + 48L / (long)sizeof(AVStream)));
						}
						if (*(ref avpacket + 16) != -9223372036854775808L)
						{
							*(ref avpacket + 16) = <Module>.av_rescale_q(*(ref avpacket + 16), *(AVRational*)(ptr + 140L / (long)sizeof(AVCodecContext)), *(AVRational*)(this.data.VideoStream + 48L / (long)sizeof(AVStream)));
						}
						if (*(*(long*)(ptr + 888L / (long)sizeof(AVCodecContext)) + 120L) != 0)
						{
							*(ref avpacket + 40) = (*(ref avpacket + 40) | 1);
						}
						writerPrivateData = this.data;
						*(ref avpacket + 36) = *(int*)writerPrivateData.VideoStream;
						if (<Module>.av_interleaved_write_frame(writerPrivateData.FormatContext, &avpacket) != null)
						{
							throw new VideoException("Error while writing video frame.");
						}
						<Module>.av_init_packet(&avpacket);
						*(ref avpacket + 24) = 0L;
						*(ref avpacket + 32) = 0;
						if (<Module>.avcodec_encode_video2(ptr, &avpacket, null, &num) < 0)
						{
							goto IL_132;
						}
					}
					<Module>.avcodec_flush_buffers(*(long*)(this.data.VideoStream + 8L / (long)sizeof(AVStream)));
					return;
				}
				IL_132:
				throw new VideoException("Error while encoding (flush)video frame");
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00003868 File Offset: 0x00002C68
		public unsafe void Close()
		{
			if (this.data != null)
			{
				this.Flush();
				AVFormatContext* formatContext = this.data.FormatContext;
				if (formatContext != null)
				{
					if (*(long*)(formatContext + 32L / (long)sizeof(AVFormatContext)) != 0L)
					{
						<Module>.av_write_trailer(formatContext);
					}
					AVStream* videoStream = this.data.VideoStream;
					if (videoStream != null)
					{
						<Module>.avcodec_close(*(long*)(videoStream + 8L / (long)sizeof(AVStream)));
					}
					AVStream* audioStream = this.data.AudioStream;
					if (audioStream != null)
					{
						<Module>.avcodec_close(*(long*)(audioStream + 8L / (long)sizeof(AVStream)));
					}
					AVFrame* videoFrame = this.data.VideoFrame;
					if (videoFrame != null)
					{
						<Module>.av_free(*(long*)videoFrame);
						<Module>.av_free((void*)this.data.VideoFrame);
					}
					byte* videoOutputBuffer = this.data.VideoOutputBuffer;
					if (videoOutputBuffer != null)
					{
						<Module>.av_free((void*)videoOutputBuffer);
					}
					sbyte* audioBuffer = this.data.AudioBuffer;
					if (audioBuffer != null)
					{
						<Module>.delete[]((void*)audioBuffer);
						this.data.AudioBuffer = null;
					}
					uint num = 0U;
					if (0 < *(int*)(this.data.FormatContext + 44L / (long)sizeof(AVFormatContext)))
					{
						do
						{
							long num2 = (long)((ulong)num * 8UL);
							<Module>.av_freep((void*)(*(*(long*)(this.data.FormatContext + 48L / (long)sizeof(AVFormatContext)) + num2) + (byte*)8L));
							<Module>.av_freep(*(long*)(this.data.FormatContext + 48L / (long)sizeof(AVFormatContext)) + num2);
							num += 1U;
						}
						while (num < (uint)(*(int*)(this.data.FormatContext + 44L / (long)sizeof(AVFormatContext))));
					}
					ulong num3 = (ulong)(*(long*)(this.data.FormatContext + 32L / (long)sizeof(AVFormatContext)));
					if (num3 != 0UL)
					{
						<Module>.avio_close(num3);
					}
					<Module>.av_free((void*)this.data.FormatContext);
				}
				SwsContext* convertContext = this.data.ConvertContext;
				if (convertContext != null)
				{
					<Module>.sws_freeContext(convertContext);
				}
				SwsContext* convertContextGrayscale = this.data.ConvertContextGrayscale;
				if (convertContextGrayscale != null)
				{
					<Module>.sws_freeContext(convertContextGrayscale);
				}
				this.data = null;
				this.m_width = 0;
				this.m_height = 0;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000033D0 File Offset: 0x000027D0
		private unsafe string GetErrorMessage(int err, string fileName)
		{
			$ArrayType$$$BY0EA@D $ArrayType$$$BY0EA@D;
			<Module>.av_strerror(err, (sbyte*)(&$ArrayType$$$BY0EA@D), 64UL);
			return Marshal.PtrToStringAnsi((IntPtr)((void*)(&$ArrayType$$$BY0EA@D)));
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00003A98 File Offset: 0x00002E98
		[HandleProcessCorruptedStateExceptions]
		protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
		{
			if (A_0)
			{
				this.Close();
				this.disposed = true;
			}
			else
			{
				try
				{
					this.Close();
				}
				finally
				{
					base.Finalize();
				}
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00003DAC File Offset: 0x000031AC
		public sealed void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00003AE4 File Offset: 0x00002EE4
		protected override void Finalize()
		{
			this.Dispose(false);
		}

		// Token: 0x04000328 RID: 808
		private int m_width;

		// Token: 0x04000329 RID: 809
		private int m_height;

		// Token: 0x0400032A RID: 810
		private Rational m_frameRate;

		// Token: 0x0400032B RID: 811
		private int m_bitRate;

		// Token: 0x0400032C RID: 812
		private VideoCodec m_codec;

		// Token: 0x0400032D RID: 813
		private uint m_framesCount;

		// Token: 0x0400032E RID: 814
		private AudioCodec m_audiocodec;

		// Token: 0x0400032F RID: 815
		private WriterPrivateData data = null;

		// Token: 0x04000330 RID: 816
		private bool disposed = false;
	}
}
