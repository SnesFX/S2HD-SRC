using System;

namespace csogg
{
	// Token: 0x0200008B RID: 139
	public class csBuffer
	{
		// Token: 0x06000473 RID: 1139 RVA: 0x00016CA0 File Offset: 0x00014EA0
		public void writeinit()
		{
			this.buffer = new byte[csBuffer.BUFFER_INCREMENT];
			this.ptr = 0;
			this.buffer[0] = 0;
			this.storage = csBuffer.BUFFER_INCREMENT;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00016CD0 File Offset: 0x00014ED0
		public void write(byte[] s)
		{
			int num = 0;
			while (num < s.Length && s[num] != 0)
			{
				this.write((int)s[num], 8);
				num++;
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00016CFC File Offset: 0x00014EFC
		public void read(byte[] s, int bytes)
		{
			int num = 0;
			while (bytes-- != 0)
			{
				s[num++] = (byte)this.read(8);
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00016D24 File Offset: 0x00014F24
		private void reset()
		{
			this.ptr = 0;
			this.buffer[0] = 0;
			this.endbit = (this.endbyte = 0);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00016D51 File Offset: 0x00014F51
		public void writeclear()
		{
			this.buffer = null;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00016D5C File Offset: 0x00014F5C
		public void readinit(byte[] buf, int start, int bytes)
		{
			this.ptr = start;
			this.buffer = buf;
			this.endbit = (this.endbyte = 0);
			this.storage = bytes;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00016D90 File Offset: 0x00014F90
		public void write(int vvalue, int bits)
		{
			if (this.endbyte + 4 >= this.storage)
			{
				byte[] destinationArray = new byte[this.storage + csBuffer.BUFFER_INCREMENT];
				Array.Copy(this.buffer, 0, destinationArray, 0, this.storage);
				this.buffer = destinationArray;
				this.storage += csBuffer.BUFFER_INCREMENT;
			}
			vvalue &= (int)csBuffer.mask[bits];
			bits += this.endbit;
			byte[] array = this.buffer;
			int num = this.ptr;
			array[num] |= (byte)(vvalue << this.endbit);
			if (bits >= 8)
			{
				this.buffer[this.ptr + 1] = (byte)((uint)vvalue >> 8 - this.endbit);
				if (bits >= 16)
				{
					this.buffer[this.ptr + 2] = (byte)((uint)vvalue >> 16 - this.endbit);
					if (bits >= 24)
					{
						this.buffer[this.ptr + 3] = (byte)((uint)vvalue >> 24 - this.endbit);
						if (bits >= 32)
						{
							if (this.endbit > 0)
							{
								this.buffer[this.ptr + 4] = (byte)((uint)vvalue >> 32 - this.endbit);
							}
							else
							{
								this.buffer[this.ptr + 4] = 0;
							}
						}
					}
				}
			}
			this.endbyte += bits / 8;
			this.ptr += bits / 8;
			this.endbit = (bits & 7);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00016EF4 File Offset: 0x000150F4
		public int look(int bits)
		{
			uint num = csBuffer.mask[bits];
			bits += this.endbit;
			if (this.endbyte + 4 >= this.storage && this.endbyte + (bits - 1) / 8 >= this.storage)
			{
				return -1;
			}
			int num2 = (this.buffer[this.ptr] & byte.MaxValue) >> this.endbit;
			if (bits > 8)
			{
				num2 |= (int)(this.buffer[this.ptr + 1] & byte.MaxValue) << 8 - this.endbit;
				if (bits > 16)
				{
					num2 |= (int)(this.buffer[this.ptr + 2] & byte.MaxValue) << 16 - this.endbit;
					if (bits > 24)
					{
						num2 |= (int)(this.buffer[this.ptr + 3] & byte.MaxValue) << 24 - this.endbit;
						if (bits > 32 && this.endbit != 0)
						{
							num2 |= (int)(this.buffer[this.ptr + 4] & byte.MaxValue) << 32 - this.endbit;
						}
					}
				}
			}
			return (int)((ulong)num & (ulong)((long)num2));
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00017013 File Offset: 0x00015213
		public int look1()
		{
			if (this.endbyte >= this.storage)
			{
				return -1;
			}
			return this.buffer[this.ptr] >> this.endbit & 1;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001703E File Offset: 0x0001523E
		public void adv(int bits)
		{
			bits += this.endbit;
			this.ptr += bits / 8;
			this.endbyte += bits / 8;
			this.endbit = (bits & 7);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00017073 File Offset: 0x00015273
		public void adv1()
		{
			this.endbit++;
			if (this.endbit > 7)
			{
				this.endbit = 0;
				this.ptr++;
				this.endbyte++;
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000170B0 File Offset: 0x000152B0
		public int read(int bits)
		{
			uint num = csBuffer.mask[bits];
			bits += this.endbit;
			int num2;
			if (this.endbyte + 4 >= this.storage)
			{
				num2 = -1;
				if (this.endbyte + (bits - 1) / 8 >= this.storage)
				{
					this.ptr += bits / 8;
					this.endbyte += bits / 8;
					this.endbit = (bits & 7);
					return num2;
				}
			}
			num2 = (this.buffer[this.ptr] & byte.MaxValue) >> this.endbit;
			if (bits > 8)
			{
				num2 |= (int)(this.buffer[this.ptr + 1] & byte.MaxValue) << 8 - this.endbit;
				if (bits > 16)
				{
					num2 |= (int)(this.buffer[this.ptr + 2] & byte.MaxValue) << 16 - this.endbit;
					if (bits > 24)
					{
						num2 |= (int)(this.buffer[this.ptr + 3] & byte.MaxValue) << 24 - this.endbit;
						if (bits > 32 && this.endbit != 0)
						{
							num2 |= (int)(this.buffer[this.ptr + 4] & byte.MaxValue) << 32 - this.endbit;
						}
					}
				}
			}
			num2 &= (int)num;
			this.ptr += bits / 8;
			this.endbyte += bits / 8;
			this.endbit = (bits & 7);
			return num2;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00017220 File Offset: 0x00015420
		public int read1()
		{
			if (this.endbyte >= this.storage)
			{
				int result = -1;
				this.endbit++;
				if (this.endbit > 7)
				{
					this.endbit = 0;
					this.ptr++;
					this.endbyte++;
				}
				return result;
			}
			int result2 = this.buffer[this.ptr] >> this.endbit & 1;
			this.endbit++;
			if (this.endbit > 7)
			{
				this.endbit = 0;
				this.ptr++;
				this.endbyte++;
			}
			return result2;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000172CA File Offset: 0x000154CA
		public int bytes()
		{
			return this.endbyte + (this.endbit + 7) / 8;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x000172DD File Offset: 0x000154DD
		public int bits()
		{
			return this.endbyte * 8 + this.endbit;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000172F0 File Offset: 0x000154F0
		public static int ilog(int v)
		{
			int num = 0;
			while (v > 0)
			{
				num++;
				v >>= 1;
			}
			return num;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001730F File Offset: 0x0001550F
		public byte[] buf()
		{
			return this.buffer;
		}

		// Token: 0x040002C8 RID: 712
		private static int BUFFER_INCREMENT = 256;

		// Token: 0x040002C9 RID: 713
		private static uint[] mask = new uint[]
		{
			0U,
			1U,
			3U,
			7U,
			15U,
			31U,
			63U,
			127U,
			255U,
			511U,
			1023U,
			2047U,
			4095U,
			8191U,
			16383U,
			32767U,
			65535U,
			131071U,
			262143U,
			524287U,
			1048575U,
			2097151U,
			4194303U,
			8388607U,
			16777215U,
			33554431U,
			67108863U,
			134217727U,
			268435455U,
			536870911U,
			1073741823U,
			2147483647U,
			uint.MaxValue
		};

		// Token: 0x040002CA RID: 714
		private int ptr;

		// Token: 0x040002CB RID: 715
		private byte[] buffer;

		// Token: 0x040002CC RID: 716
		private int endbit;

		// Token: 0x040002CD RID: 717
		private int endbyte;

		// Token: 0x040002CE RID: 718
		private int storage;
	}
}
