using System;
using System.IO;

namespace SonicOrca.Original
{
	// Token: 0x0200009F RID: 159
	internal class BitReader
	{
		// Token: 0x06000554 RID: 1364 RVA: 0x0001A26E File Offset: 0x0001846E
		public BitReader(Stream stream, int blockSize)
		{
			this._stream = stream;
			this._blockSize = blockSize;
			this.ReadBlock();
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001A28C File Offset: 0x0001848C
		public int ReadBits(int count)
		{
			int num = 0;
			while (count-- > 0)
			{
				if (this.ReadBit())
				{
					num = (num << 1 | 1);
				}
			}
			return num;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001A2B8 File Offset: 0x000184B8
		public bool ReadBit()
		{
			int data = this._data;
			int num = 1;
			int bitIndex = this._bitIndex;
			this._bitIndex = bitIndex + 1;
			bool result = (data & num << bitIndex) != 0;
			if (this._bitIndex >= this._blockSize * 8)
			{
				this.ReadBlock();
			}
			return result;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001A2FC File Offset: 0x000184FC
		private void ReadBlock()
		{
			this._bitIndex = 0;
			switch (this._blockSize)
			{
			case 1:
				this._data = this._stream.ReadByte();
				return;
			case 2:
				this._data = (this._stream.ReadByte() | this._stream.ReadByte() << 8);
				return;
			case 3:
				this._data = (this._stream.ReadByte() | this._stream.ReadByte() << 8 | this._stream.ReadByte() << 16);
				return;
			case 4:
				this._data = (this._stream.ReadByte() | this._stream.ReadByte() << 8 | this._stream.ReadByte() << 16 | this._stream.ReadByte() << 24);
				return;
			default:
				throw new InvalidOperationException();
			}
		}

		// Token: 0x04000335 RID: 821
		private readonly Stream _stream;

		// Token: 0x04000336 RID: 822
		private readonly int _blockSize;

		// Token: 0x04000337 RID: 823
		private int _data;

		// Token: 0x04000338 RID: 824
		private int _bitIndex;
	}
}
