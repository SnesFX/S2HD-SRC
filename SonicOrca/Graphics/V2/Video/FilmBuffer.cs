using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Accord.Video.FFMPEG;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000E8 RID: 232
	public class FilmBuffer : IFilmBuffer, IDisposable, ILoadedResource
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0001F5B1 File Offset: 0x0001D7B1
		public int Width
		{
			get
			{
				return this._width;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0001F5B9 File Offset: 0x0001D7B9
		public int Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0001F5C4 File Offset: 0x0001D7C4
		public double CurrentTime
		{
			get
			{
				return this._currentFrame / this._reader.FrameRate.Value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0001F5EC File Offset: 0x0001D7EC
		public double Duration
		{
			get
			{
				return this._numFrames / this._reader.FrameRate.Value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0001F613 File Offset: 0x0001D813
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x0001F61B File Offset: 0x0001D81B
		public Resource Resource { get; set; }

		// Token: 0x06000805 RID: 2053 RVA: 0x0001F624 File Offset: 0x0001D824
		public void Dispose()
		{
			this._reader.Close();
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001F634 File Offset: 0x0001D834
		public void OnLoaded()
		{
			try
			{
				this._reader.Open(this._path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			this._width = this._reader.Width;
			this._height = this._reader.Height;
			this._numFrames = (double)this._reader.FrameCount;
			this._currentFrame = 0.0;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0001F6B4 File Offset: 0x0001D8B4
		public FilmBuffer(string path)
		{
			this._path = path;
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0001F6DC File Offset: 0x0001D8DC
		public void Decode()
		{
			Bitmap bitmap = this._reader.ReadVideoFrame();
			if (bitmap != null)
			{
				this._currentFrame += 1.0;
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
				IntPtr scan = bitmapData.Scan0;
				int num = Math.Abs(bitmapData.Stride) * bitmap.Height;
				if (this._bytes == null)
				{
					this._bytes = new byte[num];
				}
				else if (num != this._bytes.Length)
				{
					this._bytes = new byte[num];
				}
				Marshal.Copy(scan, this._bytes, 0, num);
				bitmap.UnlockBits(bitmapData);
			}
			bitmap.Dispose();
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0001F794 File Offset: 0x0001D994
		public byte[] GetArgbData()
		{
			return this._bytes;
		}

		// Token: 0x040004EB RID: 1259
		private VideoFileReader _reader = new VideoFileReader();

		// Token: 0x040004EC RID: 1260
		private int _width;

		// Token: 0x040004ED RID: 1261
		private int _height;

		// Token: 0x040004EE RID: 1262
		private double _currentFrame;

		// Token: 0x040004EF RID: 1263
		private double _numFrames;

		// Token: 0x040004F1 RID: 1265
		private ImageConverter converter = new ImageConverter();

		// Token: 0x040004F2 RID: 1266
		private byte[] _bytes;

		// Token: 0x040004F3 RID: 1267
		private string _path;
	}
}
