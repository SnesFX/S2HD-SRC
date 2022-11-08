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
	// Token: 0x02000159 RID: 345
	public class VideoFileReader : IDisposable
	{
		// Token: 0x060000CD RID: 205 RVA: 0x000016FC File Offset: 0x00000AFC
		private unsafe Bitmap DecodeVideoFrame()
		{
			AVCodecContext* codecContext = this.data.CodecContext;
			Bitmap bitmap = new Bitmap(*(int*)(codecContext + 156L / (long)sizeof(AVCodecContext)), *(int*)(codecContext + 160L / (long)sizeof(AVCodecContext)), PixelFormat.Format24bppRgb);
			AVCodecContext* codecContext2 = this.data.CodecContext;
			Rectangle rect = new Rectangle(0, 0, *(int*)(codecContext2 + 156L / (long)sizeof(AVCodecContext)), *(int*)(codecContext2 + 160L / (long)sizeof(AVCodecContext)));
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			IntPtr scan = bitmapData.Scan0;
			$ArrayType$$$BY03PEAE $ArrayType$$$BY03PEAE = (void*)scan;
			*(ref $ArrayType$$$BY03PEAE + 8) = 0L;
			*(ref $ArrayType$$$BY03PEAE + 16) = 0L;
			*(ref $ArrayType$$$BY03PEAE + 24) = 0L;
			$ArrayType$$$BY03H stride = bitmapData.Stride;
			*(ref stride + 4) = 0;
			*(ref stride + 8) = 0;
			*(ref stride + 12) = 0;
			ReaderPrivateData readerPrivateData = this.data;
			AVFrame* videoFrame = readerPrivateData.VideoFrame;
			SwsContext* convertContext = readerPrivateData.ConvertContext;
			AVFrame* ptr = videoFrame;
			<Module>.sws_scale(convertContext, ptr, ptr + 64L / (long)sizeof(AVFrame), 0, *(int*)(readerPrivateData.CodecContext + 160L / (long)sizeof(AVCodecContext)), ref $ArrayType$$$BY03PEAE, ref stride);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00001120 File Offset: 0x00000520
		private void CheckIfVideoFileIsOpen()
		{
			if (this.data == null)
			{
				throw new IOException("Video file is not open, so can not access its properties.");
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00001140 File Offset: 0x00000540
		private void CheckIfDisposed()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000019A8 File Offset: 0x00000DA8
		private void !VideoFileReader()
		{
			this.Close();
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00001160 File Offset: 0x00000560
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

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00001188 File Offset: 0x00000588
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000011B0 File Offset: 0x000005B0
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

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000011DC File Offset: 0x000005DC
		public long FrameCount
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_framesCount;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00001204 File Offset: 0x00000604
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000122C File Offset: 0x0000062C
		public string CodecName
		{
			get
			{
				if (this.data == null)
				{
					throw new IOException("Video file is not open, so can not access its properties.");
				}
				return this.m_codecName;
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00001254 File Offset: 0x00000654
		public bool IsOpen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((this.data != null) ? 1 : 0) != 0;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000163C File Offset: 0x00000A3C
		public VideoFileReader()
		{
			<Module>.av_register_all();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000019BC File Offset: 0x00000DBC
		private void ~VideoFileReader()
		{
			this.Close();
			this.disposed = true;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00001AA4 File Offset: 0x00000EA4
		public unsafe void Open(string fileName)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
			this.Close();
			this.data = new ReaderPrivateData();
			AVPacket* ptr = <Module>.@new(88UL);
			AVPacket* packet;
			if (ptr != null)
			{
				initblk(ptr, 0, 88L);
				packet = ptr;
			}
			else
			{
				packet = null;
			}
			this.data.Packet = packet;
			*(long*)(this.data.Packet + 24L / (long)sizeof(AVPacket)) = 0L;
			bool flag = false;
			try
			{
				char* ptr2 = (char*)Marshal.StringToHGlobalUni(fileName).ToPointer();
				int num = <Module>.WideCharToMultiByte(65001U, 0, (char*)ptr2, -1, null, 0, null, null);
				sbyte* ptr3 = <Module>.new[]((ulong)((long)num));
				<Module>.WideCharToMultiByte(65001U, 0, (char*)ptr2, -1, ptr3, num, null, null);
				this.data.FormatContext = <Module>.Accord.Video.FFMPEG.?A0xcf40973a.open_file((sbyte*)ptr3);
				AVFormatContext* formatContext = this.data.FormatContext;
				if (formatContext == null)
				{
					throw new IOException("Cannot open the video file.");
				}
				if (<Module>.avformat_find_stream_info(formatContext, null) < 0)
				{
					throw new VideoException("Cannot find stream information.");
				}
				uint num2 = 0U;
				ReaderPrivateData readerPrivateData;
				long num3;
				long num4;
				for (;;)
				{
					readerPrivateData = this.data;
					formatContext = readerPrivateData.FormatContext;
					if (num2 >= (uint)(*(int*)(formatContext + 44L / (long)sizeof(AVFormatContext))))
					{
						goto IL_15A;
					}
					num3 = (long)((ulong)num2 * 8UL);
					num4 = *(*(*(long*)(formatContext + 48L / (long)sizeof(AVFormatContext)) + num3) + 8L);
					if (*(num4 + 12L) == 0)
					{
						break;
					}
					num2 += 1U;
				}
				readerPrivateData.CodecContext = num4;
				readerPrivateData = this.data;
				ReaderPrivateData readerPrivateData2 = readerPrivateData;
				readerPrivateData2.VideoStream = *(*(long*)(readerPrivateData2.FormatContext + 48L / (long)sizeof(AVFormatContext)) + num3);
				IL_15A:
				ReaderPrivateData readerPrivateData3 = this.data;
				if (readerPrivateData3.VideoStream == null)
				{
					throw new VideoException("Cannot find video stream in the specified file.");
				}
				AVCodec* ptr4 = <Module>.avcodec_find_decoder((AVCodecID)(*(int*)(readerPrivateData3.CodecContext + 56L / (long)sizeof(AVCodecContext))));
				if (ptr4 == null)
				{
					throw new VideoException("Cannot find codec to decode the video stream.");
				}
				if (<Module>.avcodec_open2(this.data.CodecContext, (AVCodec*)ptr4, null) < 0)
				{
					throw new VideoException("Cannot open video codec.");
				}
				this.data.VideoFrame = <Module>.av_frame_alloc();
				AVCodecContext* codecContext = this.data.CodecContext;
				int num5 = *(int*)(codecContext + 160L / (long)sizeof(AVCodecContext));
				int num6 = *(int*)(codecContext + 156L / (long)sizeof(AVCodecContext));
				this.data.ConvertContext = <Module>.sws_getContext(num6, num5, (AVPixelFormat)(*(int*)(codecContext + 176L / (long)sizeof(AVCodecContext))), num6, num5, (AVPixelFormat)3, 4, null, null, null);
				ReaderPrivateData readerPrivateData4 = this.data;
				if (readerPrivateData4.ConvertContext == null)
				{
					throw new VideoException("Cannot initialize frames conversion context.");
				}
				this.m_width = *(int*)(readerPrivateData4.CodecContext + 156L / (long)sizeof(AVCodecContext));
				this.m_height = *(int*)(readerPrivateData4.CodecContext + 160L / (long)sizeof(AVCodecContext));
				AVRational numerator = <Module>.av_stream_get_r_frame_rate((AVStream*)readerPrivateData4.VideoStream);
				Rational frameRate = new Rational(numerator, *(ref numerator + 4));
				this.m_frameRate = frameRate;
				this.m_codecName = new string(*(*(long*)(this.data.CodecContext + 16L / (long)sizeof(AVCodecContext))));
				ReaderPrivateData readerPrivateData5 = this.data;
				this.m_framesCount = *(long*)(readerPrivateData5.VideoStream + 72L / (long)sizeof(AVStream));
				this.m_bitRate = (int)(*(long*)(readerPrivateData5.CodecContext + 96L / (long)sizeof(AVCodecContext)));
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					this.Close();
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00001DAC File Offset: 0x000011AC
		public unsafe Bitmap ReadVideoFrame()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException("The object was already disposed.");
			}
			if (this.data == null)
			{
				throw new IOException("Cannot read video frames since video file is not open.");
			}
			Bitmap result = null;
			ReaderPrivateData readerPrivateData;
			int num2;
			AVPacket* packet;
			for (;;)
			{
				readerPrivateData = this.data;
				if (readerPrivateData.uint8_tsRemaining > 0)
				{
					do
					{
						int num = <Module>.avcodec_decode_video2(readerPrivateData.CodecContext, readerPrivateData.VideoFrame, &num2, (AVPacket*)readerPrivateData.Packet);
						if (num < 0)
						{
							goto IL_104;
						}
						readerPrivateData = this.data;
						readerPrivateData.uint8_tsRemaining -= num;
						if (num2 != 0)
						{
							goto IL_10F;
						}
						readerPrivateData = this.data;
					}
					while (readerPrivateData.uint8_tsRemaining > 0);
				}
				do
				{
					packet = this.data.Packet;
					if (*(long*)(packet + 24L / (long)sizeof(AVPacket)) != 0L)
					{
						<Module>.av_free_packet(packet);
						*(long*)(this.data.Packet + 24L / (long)sizeof(AVPacket)) = 0L;
					}
					readerPrivateData = this.data;
					if (<Module>.av_read_frame(readerPrivateData.FormatContext, readerPrivateData.Packet) < 0)
					{
						goto IL_116;
					}
					readerPrivateData = this.data;
				}
				while (*(int*)(readerPrivateData.Packet + 36L / (long)sizeof(AVPacket)) != *(int*)readerPrivateData.VideoStream);
				readerPrivateData = this.data;
				ReaderPrivateData readerPrivateData2 = readerPrivateData;
				readerPrivateData2.uint8_tsRemaining = *(int*)(readerPrivateData2.Packet + 32L / (long)sizeof(AVPacket));
			}
			IL_104:
			throw new VideoException("Error while decoding frame.");
			IL_10F:
			return this.DecodeVideoFrame();
			IL_116:
			readerPrivateData = this.data;
			<Module>.avcodec_decode_video2(readerPrivateData.CodecContext, readerPrivateData.VideoFrame, &num2, (AVPacket*)readerPrivateData.Packet);
			packet = this.data.Packet;
			if (*(long*)(packet + 24L / (long)sizeof(AVPacket)) != 0L)
			{
				<Module>.av_free_packet(packet);
				*(long*)(this.data.Packet + 24L / (long)sizeof(AVPacket)) = 0L;
			}
			if (num2 != 0)
			{
				result = this.DecodeVideoFrame();
			}
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00001664 File Offset: 0x00000A64
		public unsafe void Close()
		{
			ReaderPrivateData readerPrivateData = this.data;
			if (readerPrivateData != null)
			{
				AVFrame* videoFrame = readerPrivateData.VideoFrame;
				if (videoFrame != null)
				{
					<Module>.av_free((void*)videoFrame);
				}
				AVCodecContext* codecContext = this.data.CodecContext;
				if (codecContext != null)
				{
					<Module>.avcodec_close(codecContext);
				}
				AVFormatContext* formatContext = this.data.FormatContext;
				if (formatContext != null)
				{
					AVFormatContext* ptr = formatContext;
					<Module>.avformat_close_input(&ptr);
				}
				SwsContext* convertContext = this.data.ConvertContext;
				if (convertContext != null)
				{
					<Module>.sws_freeContext(convertContext);
				}
				AVPacket* packet = this.data.Packet;
				if (*(long*)(packet + 24L / (long)sizeof(AVPacket)) != 0L)
				{
					<Module>.av_free_packet(packet);
				}
				this.data = null;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000019D8 File Offset: 0x00000DD8
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

		// Token: 0x060000DE RID: 222 RVA: 0x000020BC File Offset: 0x000014BC
		public sealed void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00001A24 File Offset: 0x00000E24
		protected override void Finalize()
		{
			this.Dispose(false);
		}

		// Token: 0x0400025B RID: 603
		private int m_width;

		// Token: 0x0400025C RID: 604
		private int m_height;

		// Token: 0x0400025D RID: 605
		private Rational m_frameRate;

		// Token: 0x0400025E RID: 606
		private string m_codecName;

		// Token: 0x0400025F RID: 607
		private long m_framesCount;

		// Token: 0x04000260 RID: 608
		private int m_bitRate;

		// Token: 0x04000261 RID: 609
		private ReaderPrivateData data = null;

		// Token: 0x04000262 RID: 610
		private bool disposed = false;
	}
}
