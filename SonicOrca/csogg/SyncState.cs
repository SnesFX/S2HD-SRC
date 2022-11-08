using System;

namespace csogg
{
	// Token: 0x0200008F RID: 143
	public class SyncState
	{
		// Token: 0x060004A1 RID: 1185 RVA: 0x000181ED File Offset: 0x000163ED
		public int clear()
		{
			this.data = null;
			return 0;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x000181F8 File Offset: 0x000163F8
		public int buffer(int size)
		{
			if (this.returned != 0)
			{
				this.fill -= this.returned;
				if (this.fill > 0)
				{
					Array.Copy(this.data, this.returned, this.data, 0, this.fill);
				}
				this.returned = 0;
			}
			if (size > this.storage - this.fill)
			{
				int num = size + this.fill + 4096;
				if (this.data != null)
				{
					byte[] destinationArray = new byte[num];
					Array.Copy(this.data, 0, destinationArray, 0, this.data.Length);
					this.data = destinationArray;
				}
				else
				{
					this.data = new byte[num];
				}
				this.storage = num;
			}
			return this.fill;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x000182B4 File Offset: 0x000164B4
		public int wrote(int bytes)
		{
			if (this.fill + bytes > this.storage)
			{
				return -1;
			}
			this.fill += bytes;
			return 0;
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000182D8 File Offset: 0x000164D8
		public int pageseek(Page og)
		{
			int num = this.returned;
			int num2 = this.fill - this.returned;
			if (this.headerbytes == 0)
			{
				if (num2 < 27)
				{
					return 0;
				}
				if (this.data[num] != 79 || this.data[num + 1] != 103 || this.data[num + 2] != 103 || this.data[num + 3] != 83)
				{
					this.headerbytes = 0;
					this.bodybytes = 0;
					int num3 = 0;
					for (int i = 0; i < num2 - 1; i++)
					{
						if (this.data[num + 1 + i] == 79)
						{
							num3 = num + 1 + i;
							break;
						}
					}
					if (num3 == 0)
					{
						num3 = this.fill;
					}
					this.returned = num3;
					return -(num3 - num);
				}
				int num4 = (int)((this.data[num + 26] & byte.MaxValue) + 27);
				if (num2 < num4)
				{
					return 0;
				}
				for (int j = 0; j < (int)(this.data[num + 26] & 255); j++)
				{
					this.bodybytes += (int)(this.data[num + 27 + j] & byte.MaxValue);
				}
				this.headerbytes = num4;
			}
			if (this.bodybytes + this.headerbytes > num2)
			{
				return 0;
			}
			byte[] obj = this.chksum;
			lock (obj)
			{
				Array.Copy(this.data, num + 22, this.chksum, 0, 4);
				this.data[num + 22] = 0;
				this.data[num + 23] = 0;
				this.data[num + 24] = 0;
				this.data[num + 25] = 0;
				Page page = this.pageseek_p;
				page.header_base = this.data;
				page.header = num;
				page.header_len = this.headerbytes;
				page.body_base = this.data;
				page.body = num + this.headerbytes;
				page.body_len = this.bodybytes;
				page.checksum();
				if (this.chksum[0] != this.data[num + 22] || this.chksum[1] != this.data[num + 23] || this.chksum[2] != this.data[num + 24] || this.chksum[3] != this.data[num + 25])
				{
					Array.Copy(this.chksum, 0, this.data, num + 22, 4);
					this.headerbytes = 0;
					this.bodybytes = 0;
					int num3 = 0;
					for (int k = 0; k < num2 - 1; k++)
					{
						if (this.data[num + 1 + k] == 79)
						{
							num3 = num + 1 + k;
							break;
						}
					}
					if (num3 == 0)
					{
						num3 = this.fill;
					}
					this.returned = num3;
					return -(num3 - num);
				}
			}
			num = this.returned;
			if (og != null)
			{
				og.header_base = this.data;
				og.header = num;
				og.header_len = this.headerbytes;
				og.body_base = this.data;
				og.body = num + this.headerbytes;
				og.body_len = this.bodybytes;
			}
			this.unsynced = 0;
			this.returned += (num2 = this.headerbytes + this.bodybytes);
			this.headerbytes = 0;
			this.bodybytes = 0;
			return num2;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00018628 File Offset: 0x00016828
		public int pageout(Page og)
		{
			for (;;)
			{
				int num = this.pageseek(og);
				if (num > 0)
				{
					break;
				}
				if (num == 0)
				{
					return 0;
				}
				if (this.unsynced == 0)
				{
					goto Block_2;
				}
			}
			return 1;
			Block_2:
			this.unsynced = 1;
			return -1;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00018658 File Offset: 0x00016858
		public int reset()
		{
			this.fill = 0;
			this.returned = 0;
			this.unsynced = 0;
			this.headerbytes = 0;
			this.bodybytes = 0;
			return 0;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00006325 File Offset: 0x00004525
		public void init()
		{
		}

		// Token: 0x040002EF RID: 751
		public byte[] data;

		// Token: 0x040002F0 RID: 752
		private int storage;

		// Token: 0x040002F1 RID: 753
		private int fill;

		// Token: 0x040002F2 RID: 754
		private int returned;

		// Token: 0x040002F3 RID: 755
		private int unsynced;

		// Token: 0x040002F4 RID: 756
		private int headerbytes;

		// Token: 0x040002F5 RID: 757
		private int bodybytes;

		// Token: 0x040002F6 RID: 758
		private Page pageseek_p = new Page();

		// Token: 0x040002F7 RID: 759
		private byte[] chksum = new byte[4];
	}
}
