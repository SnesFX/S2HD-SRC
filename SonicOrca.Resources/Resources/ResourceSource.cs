using System;
using System.IO;
using System.IO.Compression;

namespace SonicOrca.Resources
{
	// Token: 0x0200000D RID: 13
	public abstract class ResourceSource
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000318F File Offset: 0x0000138F
		public bool Compressed
		{
			get
			{
				return this._compressed;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000047 RID: 71
		public abstract long Size { get; }

		// Token: 0x06000048 RID: 72 RVA: 0x00003197 File Offset: 0x00001397
		protected ResourceSource(bool compressed = false)
		{
			this._compressed = compressed;
		}

		// Token: 0x06000049 RID: 73
		public abstract Stream Read();

		// Token: 0x0600004A RID: 74 RVA: 0x000031A8 File Offset: 0x000013A8
		private byte[] GetData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				this.Read().CopyTo(memoryStream);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000031EC File Offset: 0x000013EC
		public Stream ReadCompressed()
		{
			if (this._compressed)
			{
				return this.Read();
			}
			Stream result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					this.Read().CopyTo(gzipStream);
				}
				result = new MemoryStream(memoryStream.ToArray());
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003264 File Offset: 0x00001464
		private static byte[] Compress(byte[] uncompressedData)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (MemoryStream memoryStream2 = new MemoryStream(uncompressedData))
				{
					using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
					{
						memoryStream2.CopyTo(gzipStream);
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000032E0 File Offset: 0x000014E0
		private static byte[] Uncompress(byte[] compressedData)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (MemoryStream memoryStream2 = new MemoryStream(compressedData))
				{
					using (GZipStream gzipStream = new GZipStream(memoryStream2, CompressionMode.Decompress))
					{
						gzipStream.CopyTo(memoryStream);
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000335C File Offset: 0x0000155C
		public Stream ReadUncompressed()
		{
			if (this._compressed)
			{
				return new GZipStream(this.Read(), CompressionMode.Decompress);
			}
			return this.Read();
		}

		// Token: 0x04000032 RID: 50
		private readonly bool _compressed;
	}
}
