using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Accord.Video
{
	// Token: 0x02000007 RID: 7
	public class TimeoutStream : Stream
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00002AD5 File Offset: 0x00001AD5
		public TimeoutStream(Stream stream)
		{
			this._baseStream = stream;
			this._source = new CancellationTokenSource();
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002B05 File Offset: 0x00001B05
		public Stream BaseStream
		{
			get
			{
				return this._baseStream;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002B0D File Offset: 0x00001B0D
		public override bool CanRead
		{
			get
			{
				return this._baseStream.CanRead;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002B1A File Offset: 0x00001B1A
		public override bool CanSeek
		{
			get
			{
				return this._baseStream.CanSeek;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002B27 File Offset: 0x00001B27
		public override bool CanWrite
		{
			get
			{
				return this._baseStream.CanWrite;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002B34 File Offset: 0x00001B34
		public override long Length
		{
			get
			{
				return this._baseStream.Length;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002B41 File Offset: 0x00001B41
		public override bool CanTimeout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002B44 File Offset: 0x00001B44
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002B4C File Offset: 0x00001B4C
		public override int ReadTimeout
		{
			get
			{
				return this._readTimeout;
			}
			set
			{
				this._readTimeout = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002B55 File Offset: 0x00001B55
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002B5D File Offset: 0x00001B5D
		public override int WriteTimeout
		{
			get
			{
				return this._writeTimeout;
			}
			set
			{
				this._writeTimeout = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002B66 File Offset: 0x00001B66
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002B73 File Offset: 0x00001B73
		public override long Position
		{
			get
			{
				return this._baseStream.Position;
			}
			set
			{
				this._baseStream.Position = value;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002B81 File Offset: 0x00001B81
		public override void Flush()
		{
			this._baseStream.Flush();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002B90 File Offset: 0x00001B90
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this._baseStream.CanRead && !this._baseStream.CanTimeout)
			{
				try
				{
					this._source.CancelAfter(this._readTimeout);
					Task<int> task = this._baseStream.ReadAsync(buffer, offset, count, this._source.Token);
					return task.Result;
				}
				catch (AggregateException)
				{
					this._source = new CancellationTokenSource();
					throw new TimeoutException("The operation timed out.");
				}
			}
			return this._baseStream.Read(buffer, offset, count);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002C24 File Offset: 0x00001C24
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this._baseStream.Seek(offset, origin);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002C33 File Offset: 0x00001C33
		public override void SetLength(long value)
		{
			this._baseStream.SetLength(value);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C44 File Offset: 0x00001C44
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this._baseStream.CanWrite && !this._baseStream.CanTimeout)
			{
				try
				{
					this._source.CancelAfter(this._readTimeout);
					Task task = this._baseStream.WriteAsync(buffer, offset, count, this._source.Token);
					task.Wait();
					return;
				}
				catch (AggregateException)
				{
					this._source = new CancellationTokenSource();
					throw new TimeoutException("The operation timed out.");
				}
			}
			this._baseStream.Write(buffer, offset, count);
		}

		// Token: 0x04000015 RID: 21
		private const int DEFAULT_TIMEOUT_READ = 30000;

		// Token: 0x04000016 RID: 22
		private const int DEFAULT_TIMEOUT_WRITE = 30000;

		// Token: 0x04000017 RID: 23
		private Stream _baseStream;

		// Token: 0x04000018 RID: 24
		private CancellationTokenSource _source;

		// Token: 0x04000019 RID: 25
		private int _readTimeout = 30000;

		// Token: 0x0400001A RID: 26
		private int _writeTimeout = 30000;
	}
}
