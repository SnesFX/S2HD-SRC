using System;

namespace Hjg.Pngcs.Zlib
{
	// Token: 0x02000033 RID: 51
	public class Adler32
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x00008B50 File Offset: 0x00006D50
		public void Update(byte data)
		{
			if (this.pend >= 5550)
			{
				this.updateModulus();
			}
			this.a += (uint)data;
			this.b += this.a;
			this.pend++;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00008B9F File Offset: 0x00006D9F
		public void Update(byte[] data)
		{
			this.Update(data, 0, data.Length);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00008BAC File Offset: 0x00006DAC
		public void Update(byte[] data, int offset, int length)
		{
			int num = 5550 - this.pend;
			for (int i = 0; i < length; i++)
			{
				if (i == num)
				{
					this.updateModulus();
					num = i + 5550;
				}
				this.a += (uint)data[i + offset];
				this.b += this.a;
				this.pend++;
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00008C17 File Offset: 0x00006E17
		public void Reset()
		{
			this.a = 1U;
			this.b = 0U;
			this.pend = 0;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00008C2E File Offset: 0x00006E2E
		private void updateModulus()
		{
			this.a %= 65521U;
			this.b %= 65521U;
			this.pend = 0;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00008C5B File Offset: 0x00006E5B
		public uint GetValue()
		{
			if (this.pend > 0)
			{
				this.updateModulus();
			}
			return this.b << 16 | this.a;
		}

		// Token: 0x040000C8 RID: 200
		private uint a = 1U;

		// Token: 0x040000C9 RID: 201
		private uint b;

		// Token: 0x040000CA RID: 202
		private const int _base = 65521;

		// Token: 0x040000CB RID: 203
		private const int _nmax = 5550;

		// Token: 0x040000CC RID: 204
		private int pend;
	}
}
