using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Accord.Math;

namespace Accord.Video.FFMPEG
{
	// Token: 0x0200027D RID: 637
	public class VideoFileSource : IVideoSource
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00002908 File Offset: 0x00001D08
		private void Free()
		{
			this.m_workerThread = null;
			this.m_needToStop.Close();
			this.m_needToStop = null;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002930 File Offset: 0x00001D30
		private void WorkerThreadHandler()
		{
			ReasonToFinishPlaying value = ReasonToFinishPlaying.StoppedByUser;
			VideoFileReader videoFileReader = new VideoFileReader();
			try
			{
				videoFileReader.Open(this.m_fileName);
				int num;
				if (this.m_frameIntervalFromSource)
				{
					Rational y = 0;
					Rational y2;
					if (videoFileReader.FrameRate == y)
					{
						y2 = 25;
					}
					else
					{
						y2 = videoFileReader.FrameRate;
					}
					num = (int)(1000 / y2);
				}
				else
				{
					num = this.m_frameInterval;
				}
				int num2 = num;
				while (!this.m_needToStop.WaitOne(0, false))
				{
					DateTime now = DateTime.Now;
					Bitmap bitmap = videoFileReader.ReadVideoFrame();
					if (bitmap == null)
					{
						value = ReasonToFinishPlaying.EndOfStreamReached;
						break;
					}
					this.m_framesReceived++;
					int num3 = Image.GetPixelFormatSize(bitmap.PixelFormat) >> 3;
					int num4 = bitmap.Width * num3;
					int num5 = bitmap.Height * num4;
					this.m_bytessReceived += num5;
					this.raise_NewFrame(this, new NewFrameEventArgs(bitmap));
					((IDisposable)bitmap).Dispose();
					if (num2 > 0)
					{
						ValueType valueType = DateTime.Now.Subtract(now);
						int num6 = num2 - (int)((TimeSpan)valueType).TotalMilliseconds;
						if (num6 > 0 && this.m_needToStop.WaitOne(num6, false))
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.raise_VideoSourceError(this, new VideoSourceErrorEventArgs(ex.Message));
			}
			videoFileReader.Close();
			this.raise_PlayingFinished(this, value);
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000E7 RID: 231 RVA: 0x000026CC File Offset: 0x00001ACC
		// (remove) Token: 0x060000E8 RID: 232 RVA: 0x000026F0 File Offset: 0x00001AF0
		public virtual event NewFrameEventHandler NewFrame
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.<backing_store>NewFrame = (NewFrameEventHandler)Delegate.Combine(this.<backing_store>NewFrame, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.<backing_store>NewFrame = (NewFrameEventHandler)Delegate.Remove(this.<backing_store>NewFrame, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000EA RID: 234 RVA: 0x00002734 File Offset: 0x00001B34
		// (remove) Token: 0x060000EB RID: 235 RVA: 0x00002758 File Offset: 0x00001B58
		public virtual event VideoSourceErrorEventHandler VideoSourceError
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.<backing_store>VideoSourceError = (VideoSourceErrorEventHandler)Delegate.Combine(this.<backing_store>VideoSourceError, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.<backing_store>VideoSourceError = (VideoSourceErrorEventHandler)Delegate.Remove(this.<backing_store>VideoSourceError, value);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000ED RID: 237 RVA: 0x0000279C File Offset: 0x00001B9C
		// (remove) Token: 0x060000EE RID: 238 RVA: 0x000027C0 File Offset: 0x00001BC0
		public virtual event PlayingFinishedEventHandler PlayingFinished
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.<backing_store>PlayingFinished = (PlayingFinishedEventHandler)Delegate.Combine(this.<backing_store>PlayingFinished, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.<backing_store>PlayingFinished = (PlayingFinishedEventHandler)Delegate.Remove(this.<backing_store>PlayingFinished, value);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00002808 File Offset: 0x00001C08
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x0000281C File Offset: 0x00001C1C
		public virtual string Source
		{
			get
			{
				return this.m_fileName;
			}
			set
			{
				this.m_fileName = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00002830 File Offset: 0x00001C30
		public virtual int FramesReceived
		{
			get
			{
				int framesReceived = this.m_framesReceived;
				this.m_framesReceived = 0;
				return framesReceived;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000284C File Offset: 0x00001C4C
		public virtual long BytesReceived
		{
			get
			{
				return 0L;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00002ABC File Offset: 0x00001EBC
		public virtual bool IsRunning
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				Thread workerThread = this.m_workerThread;
				if (workerThread != null)
				{
					if (!workerThread.Join(0))
					{
						return true;
					}
					this.Free();
				}
				return false;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000285C File Offset: 0x00001C5C
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00002870 File Offset: 0x00001C70
		public int FrameInterval
		{
			get
			{
				return this.m_frameInterval;
			}
			set
			{
				this.m_frameInterval = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00002884 File Offset: 0x00001C84
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00002898 File Offset: 0x00001C98
		public bool FrameIntervalFromSource
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_frameIntervalFromSource;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.m_frameIntervalFromSource = value;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000028AC File Offset: 0x00001CAC
		public VideoFileSource(string fileName)
		{
			this.m_fileName = fileName;
			this.m_workerThread = null;
			this.m_needToStop = null;
			this.m_frameIntervalFromSource = true;
			this.m_frameInterval = 0;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00002AE8 File Offset: 0x00001EE8
		public virtual void Start()
		{
			if (!this.IsRunning)
			{
				if (string.IsNullOrEmpty(this.m_fileName))
				{
					throw new ArgumentException("Video file name is not specified.");
				}
				this.m_framesReceived = 0;
				this.m_bytessReceived = 0;
				this.m_needToStop = new ManualResetEvent(false);
				Thread thread = new Thread(new ThreadStart(this.WorkerThreadHandler));
				this.m_workerThread = thread;
				thread.Name = this.m_fileName;
				this.m_workerThread.Start();
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000028E4 File Offset: 0x00001CE4
		public virtual void SignalToStop()
		{
			if (this.m_workerThread != null)
			{
				this.m_needToStop.Set();
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00002B60 File Offset: 0x00001F60
		public virtual void WaitForStop()
		{
			Thread workerThread = this.m_workerThread;
			if (workerThread != null)
			{
				workerThread.Join();
				this.Free();
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00002B84 File Offset: 0x00001F84
		public virtual void Stop()
		{
			if (this.IsRunning)
			{
				this.m_workerThread.Abort();
				this.WaitForStop();
			}
		}

		// Token: 0x04000317 RID: 791
		private string m_fileName;

		// Token: 0x04000318 RID: 792
		private Thread m_workerThread;

		// Token: 0x04000319 RID: 793
		private ManualResetEvent m_needToStop;

		// Token: 0x0400031A RID: 794
		private int m_framesReceived;

		// Token: 0x0400031B RID: 795
		private int m_bytessReceived;

		// Token: 0x0400031C RID: 796
		private bool m_frameIntervalFromSource;

		// Token: 0x0400031D RID: 797
		private int m_frameInterval;

		// Token: 0x0400031E RID: 798
		private NewFrameEventHandler <backing_store>NewFrame;

		// Token: 0x0400031F RID: 799
		private VideoSourceErrorEventHandler <backing_store>VideoSourceError;

		// Token: 0x04000320 RID: 800
		private PlayingFinishedEventHandler <backing_store>PlayingFinished;
	}
}
