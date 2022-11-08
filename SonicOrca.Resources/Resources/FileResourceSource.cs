using System;
using System.IO;

namespace SonicOrca.Resources
{
	// Token: 0x02000003 RID: 3
	public class FileResourceSource : ResourceSource
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002195 File Offset: 0x00000395
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000219D File Offset: 0x0000039D
		public long Offset
		{
			get
			{
				return this._offset;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000021A5 File Offset: 0x000003A5
		public override long Size
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021AD File Offset: 0x000003AD
		public FileResourceSource(string path, long offset, long size, bool compressed = false) : base(compressed)
		{
			this._path = path;
			this._offset = offset;
			this._size = size;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021CC File Offset: 0x000003CC
		public override System.IO.Stream Read()
		{
			return new FileResourceSource.Stream(this);
		}

		// Token: 0x04000001 RID: 1
		private readonly string _path;

		// Token: 0x04000002 RID: 2
		private readonly long _offset;

		// Token: 0x04000003 RID: 3
		private readonly long _size;

		// Token: 0x02000013 RID: 19
		public class Stream : System.IO.Stream
		{
			// Token: 0x06000077 RID: 119 RVA: 0x00003988 File Offset: 0x00001B88
			public Stream(FileResourceSource source)
			{
				this._offset = source._offset;
				this._size = source._size;
				this._fileStream = new FileStream(source._path, FileMode.Open, FileAccess.Read);
				if (this._fileStream.Length < this._offset + this._size)
				{
					this._fileStream.Dispose();
					throw new FileLoadException("File not large enough to contain resource.");
				}
				this._fileStream.Position = source._offset;
			}

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000078 RID: 120 RVA: 0x00003966 File Offset: 0x00001B66
			public override bool CanRead
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000079 RID: 121 RVA: 0x00003966 File Offset: 0x00001B66
			public override bool CanSeek
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600007A RID: 122 RVA: 0x00003911 File Offset: 0x00001B11
			public override bool CanWrite
			{
				get
				{
					return false;
				}
			}

			// Token: 0x0600007B RID: 123 RVA: 0x00003A07 File Offset: 0x00001C07
			public override void Flush()
			{
				throw new NotImplementedException();
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00003A0E File Offset: 0x00001C0E
			public override long Length
			{
				get
				{
					return this._size;
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600007D RID: 125 RVA: 0x00003A16 File Offset: 0x00001C16
			// (set) Token: 0x0600007E RID: 126 RVA: 0x00003A2A File Offset: 0x00001C2A
			public override long Position
			{
				get
				{
					return this._fileStream.Position - this._offset;
				}
				set
				{
					if (value > this._size)
					{
						throw new ArgumentException("Position greater than resource size.");
					}
					this._fileStream.Position = value - this._offset;
				}
			}

			// Token: 0x0600007F RID: 127 RVA: 0x00003A53 File Offset: 0x00001C53
			public override int Read(byte[] buffer, int offset, int count)
			{
				count = (int)Math.Min((long)count, this._size - this.Position);
				if (count > 0)
				{
					return this._fileStream.Read(buffer, offset, count);
				}
				return 0;
			}

			// Token: 0x06000080 RID: 128 RVA: 0x00003A80 File Offset: 0x00001C80
			public override long Seek(long offset, SeekOrigin origin)
			{
				long num;
				switch (origin)
				{
				case SeekOrigin.Begin:
					num = this._offset + offset;
					break;
				case SeekOrigin.Current:
					num = this.Position + offset;
					break;
				case SeekOrigin.End:
					num = this._offset + this._size - offset;
					break;
				default:
					throw new ArgumentException("Invalid seek origin", "origin");
				}
				if (num < this._offset || num > this._offset + this._size)
				{
					throw new IOException("Invalid position to seek to");
				}
				this.Position = num;
				return num;
			}

			// Token: 0x06000081 RID: 129 RVA: 0x00003A07 File Offset: 0x00001C07
			public override void SetLength(long value)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000082 RID: 130 RVA: 0x00003A07 File Offset: 0x00001C07
			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotImplementedException();
			}

			// Token: 0x04000039 RID: 57
			private readonly FileStream _fileStream;

			// Token: 0x0400003A RID: 58
			private readonly long _offset;

			// Token: 0x0400003B RID: 59
			private readonly long _size;
		}
	}
}
