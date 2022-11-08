using System;

namespace csogg
{
	// Token: 0x0200008D RID: 141
	public class Page
	{
		// Token: 0x06000487 RID: 1159 RVA: 0x0001733C File Offset: 0x0001553C
		private static uint crc_entry(uint index)
		{
			uint num = index << 24;
			for (int i = 0; i < 8; i++)
			{
				if ((num & 2147483648U) != 0U)
				{
					num = (num << 1 ^ 79764919U);
				}
				else
				{
					num <<= 1;
				}
			}
			return num & uint.MaxValue;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00017376 File Offset: 0x00015576
		internal int version()
		{
			return (int)(this.header_base[this.header + 4] & byte.MaxValue);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001738D File Offset: 0x0001558D
		internal int continued()
		{
			return (int)(this.header_base[this.header + 5] & 1);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000173A0 File Offset: 0x000155A0
		public int bos()
		{
			return (int)(this.header_base[this.header + 5] & 2);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000173B3 File Offset: 0x000155B3
		public int eos()
		{
			return (int)(this.header_base[this.header + 5] & 4);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000173C8 File Offset: 0x000155C8
		public long granulepos()
		{
			return (((((((long)(this.header_base[this.header + 13] & byte.MaxValue) << 8 | (long)((ulong)(this.header_base[this.header + 12] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 11] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 10] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 9] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 8] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 7] & byte.MaxValue))) << 8 | (long)((ulong)(this.header_base[this.header + 6] & byte.MaxValue));
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000174A0 File Offset: 0x000156A0
		public int serialno()
		{
			return (int)(this.header_base[this.header + 14] & byte.MaxValue) | (int)(this.header_base[this.header + 15] & byte.MaxValue) << 8 | (int)(this.header_base[this.header + 16] & byte.MaxValue) << 16 | (int)(this.header_base[this.header + 17] & byte.MaxValue) << 24;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00017510 File Offset: 0x00015710
		internal int pageno()
		{
			return (int)(this.header_base[this.header + 18] & byte.MaxValue) | (int)(this.header_base[this.header + 19] & byte.MaxValue) << 8 | (int)(this.header_base[this.header + 20] & byte.MaxValue) << 16 | (int)(this.header_base[this.header + 21] & byte.MaxValue) << 24;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00017580 File Offset: 0x00015780
		internal void checksum()
		{
			uint num = 0U;
			for (int i = 0; i < this.header_len; i++)
			{
				uint num2 = (uint)(this.header_base[this.header + i] & byte.MaxValue);
				uint num3 = num >> 24 & 255U;
				num = (num << 8 ^ Page.crc_lookup[(int)(num2 ^ num3)]);
			}
			for (int j = 0; j < this.body_len; j++)
			{
				uint num2 = (uint)(this.body_base[this.body + j] & byte.MaxValue);
				uint num3 = num >> 24 & 255U;
				num = (num << 8 ^ Page.crc_lookup[(int)(num2 ^ num3)]);
			}
			this.header_base[this.header + 22] = (byte)num;
			this.header_base[this.header + 23] = (byte)(num >> 8);
			this.header_base[this.header + 24] = (byte)(num >> 16);
			this.header_base[this.header + 25] = (byte)(num >> 24);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00017664 File Offset: 0x00015864
		public Page()
		{
			uint num = 0U;
			while ((ulong)num < (ulong)((long)Page.crc_lookup.Length))
			{
				Page.crc_lookup[(int)num] = Page.crc_entry(num);
				num += 1U;
			}
		}

		// Token: 0x040002D6 RID: 726
		private static uint[] crc_lookup = new uint[256];

		// Token: 0x040002D7 RID: 727
		public byte[] header_base;

		// Token: 0x040002D8 RID: 728
		public int header;

		// Token: 0x040002D9 RID: 729
		public int header_len;

		// Token: 0x040002DA RID: 730
		public byte[] body_base;

		// Token: 0x040002DB RID: 731
		public int body;

		// Token: 0x040002DC RID: 732
		public int body_len;
	}
}
