using System;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x02000036 RID: 54
	public class CRC32
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x00008CCD File Offset: 0x00006ECD
		public CRC32() : this(3988292384U, uint.MaxValue)
		{
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008CDB File Offset: 0x00006EDB
		public CRC32(uint polynomial, uint seed)
		{
			this.table = CRC32.InitializeTable(polynomial);
			this.seed = seed;
			this.hash = seed;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008CFD File Offset: 0x00006EFD
		public void Update(byte[] buffer)
		{
			this.Update(buffer, 0, buffer.Length);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00008D0C File Offset: 0x00006F0C
		public void Update(byte[] buffer, int start, int length)
		{
			int i = 0;
			int num = start;
			while (i < length)
			{
				this.hash = (this.hash >> 8 ^ this.table[(int)((uint)buffer[num] ^ (this.hash & 255U))]);
				i++;
				num++;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00008D51 File Offset: 0x00006F51
		public uint GetValue()
		{
			return ~this.hash;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00008D5A File Offset: 0x00006F5A
		public void Reset()
		{
			this.hash = this.seed;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00008D68 File Offset: 0x00006F68
		private static uint[] InitializeTable(uint polynomial)
		{
			if (polynomial == 3988292384U && CRC32.defaultTable != null)
			{
				return CRC32.defaultTable;
			}
			uint[] array = new uint[256];
			for (int i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					if ((num & 1U) == 1U)
					{
						num = (num >> 1 ^ polynomial);
					}
					else
					{
						num >>= 1;
					}
				}
				array[i] = num;
			}
			if (polynomial == 3988292384U)
			{
				CRC32.defaultTable = array;
			}
			return array;
		}

		// Token: 0x040000D3 RID: 211
		private const uint defaultPolynomial = 3988292384U;

		// Token: 0x040000D4 RID: 212
		private const uint defaultSeed = 4294967295U;

		// Token: 0x040000D5 RID: 213
		private static uint[] defaultTable;

		// Token: 0x040000D6 RID: 214
		private uint hash;

		// Token: 0x040000D7 RID: 215
		private uint seed;

		// Token: 0x040000D8 RID: 216
		private uint[] table;
	}
}
