using System;
using System.IO;

namespace SonicOrca.Original
{
	// Token: 0x020000A0 RID: 160
	internal class BitWriter
	{
		// Token: 0x06000558 RID: 1368 RVA: 0x0001A3D8 File Offset: 0x000185D8
		public BitWriter(Stream stream, int blockSize)
		{
			this._stream = stream;
			this._blockSize = blockSize;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001A3EE File Offset: 0x000185EE
		public void WriteBits(int value, int count)
		{
			while (count-- > 0)
			{
				this.WriteBit(value >> count & 1);
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001A40C File Offset: 0x0001860C
		public void WriteBit(int bit)
		{
			int num = 1;
			int num2 = this._blockSize * 8 - 1;
			int bitIndex = this._bitIndex;
			this._bitIndex = bitIndex + 1;
			int num3 = num << num2 - bitIndex;
			if (bit != 0)
			{
				this._data |= num3;
			}
			else
			{
				this._data &= ~num3;
			}
			if (this._bitIndex >= this._blockSize * 8)
			{
				this.WriteBlock();
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001A474 File Offset: 0x00018674
		private void WriteBlock()
		{
			switch (this._blockSize)
			{
			case 1:
				this._stream.WriteByte((byte)(this._data & 255));
				break;
			case 2:
				this._stream.WriteByte((byte)(this._data & 255));
				this._stream.WriteByte((byte)(this._data >> 8 & 255));
				break;
			case 3:
				this._stream.WriteByte((byte)(this._data & 255));
				this._stream.WriteByte((byte)(this._data >> 8 & 255));
				this._stream.WriteByte((byte)(this._data >> 16 & 255));
				break;
			case 4:
				this._stream.WriteByte((byte)(this._data & 255));
				this._stream.WriteByte((byte)(this._data >> 8 & 255));
				this._stream.WriteByte((byte)(this._data >> 16 & 255));
				this._stream.WriteByte((byte)(this._data >> 24 & 255));
				break;
			default:
				throw new InvalidOperationException();
			}
			this._bitIndex = 0;
			this._data = 0;
		}

		// Token: 0x04000339 RID: 825
		private readonly Stream _stream;

		// Token: 0x0400033A RID: 826
		private readonly int _blockSize;

		// Token: 0x0400033B RID: 827
		private int _data;

		// Token: 0x0400033C RID: 828
		private int _bitIndex;
	}
}
