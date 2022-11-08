using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Accord.Video
{
	// Token: 0x0200000B RID: 11
	public class ScreenCaptureStream : IVideoSource
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000B5 RID: 181 RVA: 0x00003B38 File Offset: 0x00002B38
		// (remove) Token: 0x060000B6 RID: 182 RVA: 0x00003B70 File Offset: 0x00002B70
		public event NewFrameEventHandler NewFrame;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000B7 RID: 183 RVA: 0x00003BA8 File Offset: 0x00002BA8
		// (remove) Token: 0x060000B8 RID: 184 RVA: 0x00003BE0 File Offset: 0x00002BE0
		public event VideoSourceErrorEventHandler VideoSourceError;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000B9 RID: 185 RVA: 0x00003C18 File Offset: 0x00002C18
		// (remove) Token: 0x060000BA RID: 186 RVA: 0x00003C50 File Offset: 0x00002C50
		public event PlayingFinishedEventHandler PlayingFinished;

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003C85 File Offset: 0x00002C85
		public virtual string Source
		{
			get
			{
				return "Screen Capture";
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00003C8C File Offset: 0x00002C8C
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00003C94 File Offset: 0x00002C94
		public Rectangle Region
		{
			get
			{
				return this.region;
			}
			set
			{
				this.region = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003C9D File Offset: 0x00002C9D
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003CA5 File Offset: 0x00002CA5
		public int FrameInterval
		{
			get
			{
				return this.frameInterval;
			}
			set
			{
				this.frameInterval = Math.Max(0, value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003CB4 File Offset: 0x00002CB4
		public int FramesReceived
		{
			get
			{
				int result = this.framesReceived;
				this.framesReceived = 0;
				return result;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003CD0 File Offset: 0x00002CD0
		public long BytesReceived
		{
			get
			{
				return 0L;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003CD4 File Offset: 0x00002CD4
		public bool IsRunning
		{
			get
			{
				if (this.thread != null)
				{
					if (!this.thread.Join(0))
					{
						return true;
					}
					this.Free();
				}
				return false;
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003CF5 File Offset: 0x00002CF5
		public ScreenCaptureStream(Rectangle region)
		{
			this.region = region;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003D0C File Offset: 0x00002D0C
		public ScreenCaptureStream(Rectangle region, int frameInterval)
		{
			this.region = region;
			this.FrameInterval = frameInterval;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003D2C File Offset: 0x00002D2C
		public void Start()
		{
			if (!this.IsRunning)
			{
				this.framesReceived = 0;
				this.stopEvent = new ManualResetEvent(false);
				this.thread = new Thread(new ThreadStart(this.WorkerThread));
				this.thread.Name = this.Source;
				this.thread.Start();
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003D87 File Offset: 0x00002D87
		public void SignalToStop()
		{
			if (this.thread != null)
			{
				this.stopEvent.Set();
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003D9D File Offset: 0x00002D9D
		public void WaitForStop()
		{
			if (this.thread != null)
			{
				this.thread.Join();
				this.Free();
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003DB8 File Offset: 0x00002DB8
		public void Stop()
		{
			if (this.IsRunning)
			{
				this.stopEvent.Set();
				this.thread.Abort();
				this.WaitForStop();
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003DDF File Offset: 0x00002DDF
		private void Free()
		{
			this.thread = null;
			this.stopEvent.Close();
			this.stopEvent = null;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003DFC File Offset: 0x00002DFC
		private void WorkerThread()
		{
			int width = this.region.Width;
			int height = this.region.Height;
			int x = this.region.Location.X;
			int y = this.region.Location.Y;
			Size size = this.region.Size;
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			while (!this.stopEvent.WaitOne(0, false))
			{
				DateTime now = DateTime.Now;
				try
				{
					graphics.CopyFromScreen(x, y, 0, 0, size, CopyPixelOperation.SourceCopy);
					this.framesReceived++;
					if (this.NewFrame != null)
					{
						this.NewFrame(this, new NewFrameEventArgs(bitmap));
					}
					if (this.frameInterval > 0)
					{
						TimeSpan timeSpan = DateTime.Now.Subtract(now);
						int num = this.frameInterval - (int)timeSpan.TotalMilliseconds;
						if (num > 0 && this.stopEvent.WaitOne(num, false))
						{
							break;
						}
					}
				}
				catch (ThreadAbortException)
				{
					break;
				}
				catch (Exception ex)
				{
					if (this.VideoSourceError != null)
					{
						this.VideoSourceError(this, new VideoSourceErrorEventArgs(ex.Message));
					}
					Thread.Sleep(250);
				}
				if (this.stopEvent.WaitOne(0, false))
				{
					break;
				}
			}
			graphics.Dispose();
			bitmap.Dispose();
			if (this.PlayingFinished != null)
			{
				this.PlayingFinished(this, ReasonToFinishPlaying.StoppedByUser);
			}
		}

		// Token: 0x0400003E RID: 62
		private Rectangle region;

		// Token: 0x0400003F RID: 63
		private int frameInterval = 100;

		// Token: 0x04000040 RID: 64
		private int framesReceived;

		// Token: 0x04000041 RID: 65
		private Thread thread;

		// Token: 0x04000042 RID: 66
		private ManualResetEvent stopEvent;
	}
}
