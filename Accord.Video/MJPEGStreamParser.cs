using System;
using System.Drawing;
using System.IO;

namespace Accord.Video
{
	// Token: 0x02000006 RID: 6
	public class MJPEGStreamParser
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002758 File Offset: 0x00001758
		public MJPEGStreamParser(Boundary boundary, byte[] header, int bufferSize = 1048576)
		{
			this._header = header;
			this._boundary = boundary;
			this._buffer = new byte[bufferSize];
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002788 File Offset: 0x00001788
		public byte[] Content
		{
			get
			{
				return this._buffer;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002790 File Offset: 0x00001790
		private int RemainingBytes
		{
			get
			{
				return this._totalReadBytes - this._position;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000279F File Offset: 0x0000179F
		private bool HasStart
		{
			get
			{
				return this._imageHeaderIndex != -1;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000027AD File Offset: 0x000017AD
		private bool HasEnd
		{
			get
			{
				return this._imageBoundaryIndex != -1;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000027BB File Offset: 0x000017BB
		public bool HasFrame
		{
			get
			{
				return this.HasStart && this.HasEnd;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000027CD File Offset: 0x000017CD
		private void Add(byte[] content, int readBytes)
		{
			Array.Copy(content, 0, this._buffer, this._totalReadBytes, readBytes);
			this._totalReadBytes += readBytes;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000027F4 File Offset: 0x000017F4
		public int Read(Stream stream)
		{
			this.EnsurePositionInRange();
			byte[] array = new byte[1024];
			int totalReadBytes = this._totalReadBytes;
			int num = stream.Read(array, 0, 1024);
			if (num == 0)
			{
				throw new ApplicationException();
			}
			this.Add(array, num);
			return num;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000283C File Offset: 0x0000183C
		private void EnsurePositionInRange()
		{
			bool flag = this._totalReadBytes > 1047552;
			if (flag)
			{
				this._position = 0;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002864 File Offset: 0x00001864
		public void DetectFrame()
		{
			if (!this.HasStart && this.CanRead(this._header))
			{
				this._imageHeaderIndex = this.FindHeader();
				if (this.HasStart)
				{
					this.PositionAfterHeader();
				}
				else
				{
					this.PositionAtEnd();
				}
			}
			while (this.HasStart && !this.HasEnd && this.CanRead(this._boundary))
			{
				this._imageBoundaryIndex = this.FindBoundary();
				if (!this.HasEnd)
				{
					this.PositionAtEnd();
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000028E4 File Offset: 0x000018E4
		public Bitmap GetFrame()
		{
			if (this.HasFrame)
			{
				this.PositionAtImageEnd();
				int count = this._imageBoundaryIndex - this._imageHeaderIndex;
				Stream stream = new MemoryStream(this._buffer, this._imageHeaderIndex, count);
				return (Bitmap)Image.FromStream(stream);
			}
			throw new InvalidOperationException("No frame detected in buffer.");
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002938 File Offset: 0x00001938
		public void RemoveFrame()
		{
			if (this.HasFrame)
			{
				this._position = this._imageBoundaryIndex + this._boundary.Length;
				Array.Copy(this._buffer, this._position, this._buffer, 0, this.RemainingBytes);
				this._totalReadBytes = this.RemainingBytes;
				this._position = 0;
				this._imageHeaderIndex = -1;
				this._imageBoundaryIndex = -1;
				return;
			}
			throw new InvalidOperationException("No frame detected in buffer.");
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000029B0 File Offset: 0x000019B0
		private void PositionAtEnd()
		{
			if (this._boundary.HasValue)
			{
				int num = this._boundary.Length - 1;
				this._position = this._totalReadBytes - num;
				return;
			}
			this._position = this._totalReadBytes;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000029F3 File Offset: 0x000019F3
		private int FindHeader()
		{
			return ByteArrayUtils.Find(this._buffer, this._header, this._position, this.RemainingBytes);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002A14 File Offset: 0x00001A14
		private int FindBoundary()
		{
			byte[] needle;
			if (this._boundary.Length != 0)
			{
				needle = (byte[])this._boundary;
			}
			else
			{
				needle = this._header;
			}
			return ByteArrayUtils.Find(this._buffer, needle, this._position, this.RemainingBytes);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002A5B File Offset: 0x00001A5B
		internal int FindImageBoundary()
		{
			return ByteArrayUtils.Find(this._buffer, (byte[])this._boundary, 0, this.RemainingBytes);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A7A File Offset: 0x00001A7A
		private void PositionAtImageEnd()
		{
			this._position = this._imageBoundaryIndex;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A88 File Offset: 0x00001A88
		private void PositionAfterHeader()
		{
			this._position = this._imageHeaderIndex + this._header.Length;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002AA0 File Offset: 0x00001AA0
		internal bool CanRead(Boundary boundary)
		{
			byte[] target = (byte[])boundary;
			return this.CanRead(target);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002ABB File Offset: 0x00001ABB
		internal bool CanRead(byte[] target)
		{
			return this.RemainingBytes != 0 && this.RemainingBytes >= target.Length;
		}

		// Token: 0x0400000C RID: 12
		private const int READ_SIZE = 1024;

		// Token: 0x0400000D RID: 13
		private const int BUFFER_SIZE = 1048576;

		// Token: 0x0400000E RID: 14
		private readonly byte[] _buffer;

		// Token: 0x0400000F RID: 15
		private int _position;

		// Token: 0x04000010 RID: 16
		private int _totalReadBytes;

		// Token: 0x04000011 RID: 17
		private int _imageHeaderIndex = -1;

		// Token: 0x04000012 RID: 18
		private int _imageBoundaryIndex = -1;

		// Token: 0x04000013 RID: 19
		private readonly byte[] _header;

		// Token: 0x04000014 RID: 20
		private readonly Boundary _boundary;
	}
}
