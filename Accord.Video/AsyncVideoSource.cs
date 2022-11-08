using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Accord.Video
{
	// Token: 0x02000002 RID: 2
	public class AsyncVideoSource : IVideoSource
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		// (remove) Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00001088
		public event NewFrameEventHandler NewFrame;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000003 RID: 3 RVA: 0x000020BD File Offset: 0x000010BD
		// (remove) Token: 0x06000004 RID: 4 RVA: 0x000020CB File Offset: 0x000010CB
		public event VideoSourceErrorEventHandler VideoSourceError
		{
			add
			{
				this.nestedVideoSource.VideoSourceError += value;
			}
			remove
			{
				this.nestedVideoSource.VideoSourceError -= value;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000005 RID: 5 RVA: 0x000020D9 File Offset: 0x000010D9
		// (remove) Token: 0x06000006 RID: 6 RVA: 0x000020E7 File Offset: 0x000010E7
		public event PlayingFinishedEventHandler PlayingFinished
		{
			add
			{
				this.nestedVideoSource.PlayingFinished += value;
			}
			remove
			{
				this.nestedVideoSource.PlayingFinished -= value;
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020F5 File Offset: 0x000010F5
		public IVideoSource NestedVideoSource
		{
			get
			{
				return this.nestedVideoSource;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020FD File Offset: 0x000010FD
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002105 File Offset: 0x00001105
		public bool SkipFramesIfBusy
		{
			get
			{
				return this.skipFramesIfBusy;
			}
			set
			{
				this.skipFramesIfBusy = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000210E File Offset: 0x0000110E
		public string Source
		{
			get
			{
				return this.nestedVideoSource.Source;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000211B File Offset: 0x0000111B
		public int FramesReceived
		{
			get
			{
				return this.nestedVideoSource.FramesReceived;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002128 File Offset: 0x00001128
		public long BytesReceived
		{
			get
			{
				return this.nestedVideoSource.BytesReceived;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002138 File Offset: 0x00001138
		public int FramesProcessed
		{
			get
			{
				int result = this.framesProcessed;
				this.framesProcessed = 0;
				return result;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002154 File Offset: 0x00001154
		public bool IsRunning
		{
			get
			{
				bool isRunning = this.nestedVideoSource.IsRunning;
				if (!isRunning)
				{
					this.Free();
				}
				return isRunning;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002177 File Offset: 0x00001177
		public AsyncVideoSource(IVideoSource nestedVideoSource)
		{
			this.nestedVideoSource = nestedVideoSource;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002186 File Offset: 0x00001186
		public AsyncVideoSource(IVideoSource nestedVideoSource, bool skipFramesIfBusy)
		{
			this.nestedVideoSource = nestedVideoSource;
			this.skipFramesIfBusy = skipFramesIfBusy;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000219C File Offset: 0x0000119C
		public void Start()
		{
			if (!this.IsRunning)
			{
				this.framesProcessed = 0;
				this.isNewFrameAvailable = new AutoResetEvent(false);
				this.isProcessingThreadAvailable = new AutoResetEvent(true);
				this.imageProcessingThread = new Thread(new ThreadStart(this.imageProcessingThread_Worker));
				this.imageProcessingThread.Start();
				this.nestedVideoSource.NewFrame += this.nestedVideoSource_NewFrame;
				this.nestedVideoSource.Start();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002214 File Offset: 0x00001214
		public void SignalToStop()
		{
			this.nestedVideoSource.SignalToStop();
			this.Free();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002227 File Offset: 0x00001227
		public void WaitForStop()
		{
			this.nestedVideoSource.WaitForStop();
			this.Free();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000223A File Offset: 0x0000123A
		public void Stop()
		{
			this.nestedVideoSource.Stop();
			this.Free();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002250 File Offset: 0x00001250
		private void Free()
		{
			if (this.imageProcessingThread != null)
			{
				this.nestedVideoSource.NewFrame -= this.nestedVideoSource_NewFrame;
				this.isProcessingThreadAvailable.WaitOne();
				this.lastVideoFrame = null;
				this.isNewFrameAvailable.Set();
				this.imageProcessingThread.Join();
				this.imageProcessingThread = null;
				this.isNewFrameAvailable.Close();
				this.isNewFrameAvailable = null;
				this.isProcessingThreadAvailable.Close();
				this.isProcessingThreadAvailable = null;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022D4 File Offset: 0x000012D4
		private void nestedVideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			if (this.NewFrame == null)
			{
				return;
			}
			if (this.skipFramesIfBusy)
			{
				if (!this.isProcessingThreadAvailable.WaitOne(0, false))
				{
					return;
				}
			}
			else
			{
				this.isProcessingThreadAvailable.WaitOne();
			}
			this.lastVideoFrame = AsyncVideoSource.CloneImage(eventArgs.Frame);
			this.isNewFrameAvailable.Set();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000232C File Offset: 0x0000132C
		private void imageProcessingThread_Worker()
		{
			for (;;)
			{
				this.isNewFrameAvailable.WaitOne();
				if (this.lastVideoFrame == null)
				{
					break;
				}
				if (this.NewFrame != null)
				{
					this.NewFrame(this, new NewFrameEventArgs(this.lastVideoFrame));
				}
				this.lastVideoFrame.Dispose();
				this.lastVideoFrame = null;
				this.framesProcessed++;
				this.isProcessingThreadAvailable.Set();
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000239C File Offset: 0x0000139C
		private static Bitmap CloneImage(Bitmap source)
		{
			BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
			Bitmap bitmap = AsyncVideoSource.CloneImage(bitmapData);
			source.UnlockBits(bitmapData);
			if (source.PixelFormat == PixelFormat.Format1bppIndexed || source.PixelFormat == PixelFormat.Format4bppIndexed || source.PixelFormat == PixelFormat.Format8bppIndexed || source.PixelFormat == PixelFormat.Indexed)
			{
				ColorPalette palette = source.Palette;
				ColorPalette palette2 = bitmap.Palette;
				int num = palette.Entries.Length;
				for (int i = 0; i < num; i++)
				{
					palette2.Entries[i] = palette.Entries[i];
				}
				bitmap.Palette = palette2;
			}
			return bitmap;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002458 File Offset: 0x00001458
		private static Bitmap CloneImage(BitmapData sourceData)
		{
			int width = sourceData.Width;
			int height = sourceData.Height;
			Bitmap bitmap = new Bitmap(width, height, sourceData.PixelFormat);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			SystemTools.CopyUnmanagedMemory(bitmapData.Scan0, sourceData.Scan0, height * sourceData.Stride);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		// Token: 0x04000001 RID: 1
		private readonly IVideoSource nestedVideoSource;

		// Token: 0x04000002 RID: 2
		private Bitmap lastVideoFrame;

		// Token: 0x04000003 RID: 3
		private Thread imageProcessingThread;

		// Token: 0x04000004 RID: 4
		private AutoResetEvent isNewFrameAvailable;

		// Token: 0x04000005 RID: 5
		private AutoResetEvent isProcessingThreadAvailable;

		// Token: 0x04000006 RID: 6
		private bool skipFramesIfBusy;

		// Token: 0x04000007 RID: 7
		private int framesProcessed;
	}
}
