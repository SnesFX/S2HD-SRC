using System;
using System.Text;

namespace csogg
{
	// Token: 0x0200008E RID: 142
	public class StreamState
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x000176A9 File Offset: 0x000158A9
		private StreamState(int serialno) : this()
		{
			this.init(serialno);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000176B8 File Offset: 0x000158B8
		public StreamState()
		{
			this.init();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000176D8 File Offset: 0x000158D8
		private void init()
		{
			this.body_storage = 16384;
			this.body_data = new byte[this.body_storage];
			this.lacing_storage = 1024;
			this.lacing_vals = new int[this.lacing_storage];
			this.granule_vals = new long[this.lacing_storage];
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00017730 File Offset: 0x00015930
		public void init(int serialno)
		{
			if (this.body_data == null)
			{
				this.init();
			}
			else
			{
				for (int i = 0; i < this.body_data.Length; i++)
				{
					this.body_data[i] = 0;
				}
				for (int j = 0; j < this.lacing_vals.Length; j++)
				{
					this.lacing_vals[j] = 0;
				}
				for (int k = 0; k < this.granule_vals.Length; k++)
				{
					this.granule_vals[k] = 0L;
				}
			}
			this.serialno = serialno;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000177A9 File Offset: 0x000159A9
		public void clear()
		{
			this.body_data = null;
			this.lacing_vals = null;
			this.granule_vals = null;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x000177C0 File Offset: 0x000159C0
		private void destroy()
		{
			this.clear();
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000177C8 File Offset: 0x000159C8
		private void body_expand(int needed)
		{
			if (this.body_storage <= this.body_fill + needed)
			{
				this.body_storage += needed + 1024;
				byte[] destinationArray = new byte[this.body_storage];
				Array.Copy(this.body_data, 0, destinationArray, 0, this.body_data.Length);
				this.body_data = destinationArray;
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00017824 File Offset: 0x00015A24
		private void lacing_expand(int needed)
		{
			if (this.lacing_storage <= this.lacing_fill + needed)
			{
				this.lacing_storage += needed + 32;
				int[] destinationArray = new int[this.lacing_storage];
				Array.Copy(this.lacing_vals, 0, destinationArray, 0, this.lacing_vals.Length);
				this.lacing_vals = destinationArray;
				long[] destinationArray2 = new long[this.lacing_storage];
				Array.Copy(this.granule_vals, 0, destinationArray2, 0, this.granule_vals.Length);
				this.granule_vals = destinationArray2;
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000178A4 File Offset: 0x00015AA4
		public int packetin(Packet op)
		{
			int num = op.bytes / 255 + 1;
			if (this.body_returned != 0)
			{
				this.body_fill -= this.body_returned;
				if (this.body_fill != 0)
				{
					Array.Copy(this.body_data, this.body_returned, this.body_data, 0, this.body_fill);
				}
				this.body_returned = 0;
			}
			this.body_expand(op.bytes);
			this.lacing_expand(num);
			Array.Copy(op.packet_base, op.packet, this.body_data, this.body_fill, op.bytes);
			this.body_fill += op.bytes;
			int i;
			for (i = 0; i < num - 1; i++)
			{
				this.lacing_vals[this.lacing_fill + i] = 255;
				this.granule_vals[this.lacing_fill + i] = this.granulepos;
			}
			this.lacing_vals[this.lacing_fill + i] = op.bytes % 255;
			this.granulepos = (this.granule_vals[this.lacing_fill + i] = op.granulepos);
			this.lacing_vals[this.lacing_fill] |= 256;
			this.lacing_fill += num;
			this.packetno += 1L;
			if (op.e_o_s != 0)
			{
				this.e_o_s = 1;
			}
			return 0;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00017A08 File Offset: 0x00015C08
		public int packetout(Packet op)
		{
			int num = this.lacing_returned;
			if (this.lacing_packet <= num)
			{
				return 0;
			}
			if ((this.lacing_vals[num] & 1024) != 0)
			{
				this.lacing_returned++;
				this.packetno += 1L;
				return -1;
			}
			int num2 = this.lacing_vals[num] & 255;
			int num3 = 0;
			op.packet_base = this.body_data;
			op.packet = this.body_returned;
			op.e_o_s = (this.lacing_vals[num] & 512);
			op.b_o_s = (this.lacing_vals[num] & 256);
			num3 += num2;
			while (num2 == 255)
			{
				int num4 = this.lacing_vals[++num];
				num2 = (num4 & 255);
				if ((num4 & 512) != 0)
				{
					op.e_o_s = 512;
				}
				num3 += num2;
			}
			op.packetno = this.packetno;
			op.granulepos = this.granule_vals[num];
			op.bytes = num3;
			this.body_returned += num3;
			this.lacing_returned = num + 1;
			this.packetno += 1L;
			return 1;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00017B28 File Offset: 0x00015D28
		public int pagein(Page og)
		{
			byte[] header_base = og.header_base;
			int num = og.header;
			byte[] body_base = og.body_base;
			int num2 = og.body;
			int num3 = og.body_len;
			int i = 0;
			int num4 = og.version();
			int num5 = og.continued();
			int num6 = og.bos();
			int num7 = og.eos();
			long num8 = og.granulepos();
			int num9 = og.serialno();
			int num10 = og.pageno();
			int num11 = (int)(header_base[num + 26] & byte.MaxValue);
			int num12 = this.lacing_returned;
			int num13 = this.body_returned;
			if (num13 != 0)
			{
				this.body_fill -= num13;
				if (this.body_fill != 0)
				{
					Array.Copy(this.body_data, num13, this.body_data, 0, this.body_fill);
				}
				this.body_returned = 0;
			}
			if (num12 != 0)
			{
				if (this.lacing_fill - num12 != 0)
				{
					Array.Copy(this.lacing_vals, num12, this.lacing_vals, 0, this.lacing_fill - num12);
					Array.Copy(this.granule_vals, num12, this.granule_vals, 0, this.lacing_fill - num12);
				}
				this.lacing_fill -= num12;
				this.lacing_packet -= num12;
				this.lacing_returned = 0;
			}
			if (num9 != this.serialno)
			{
				return -1;
			}
			if (num4 > 0)
			{
				return -1;
			}
			this.lacing_expand(num11 + 1);
			if (num10 != this.pageno)
			{
				for (int j = this.lacing_packet; j < this.lacing_fill; j++)
				{
					this.body_fill -= (this.lacing_vals[j] & 255);
				}
				this.lacing_fill = this.lacing_packet;
				if (this.pageno != -1)
				{
					int[] array = this.lacing_vals;
					int num14 = this.lacing_fill;
					this.lacing_fill = num14 + 1;
					array[num14] = 1024;
					this.lacing_packet++;
				}
				if (num5 != 0)
				{
					num6 = 0;
					while (i < num11)
					{
						int num15 = (int)(header_base[num + 27 + i] & byte.MaxValue);
						num2 += num15;
						num3 -= num15;
						if (num15 < 255)
						{
							i++;
							break;
						}
						i++;
					}
				}
			}
			if (num3 != 0)
			{
				this.body_expand(num3);
				Array.Copy(body_base, num2, this.body_data, this.body_fill, num3);
				this.body_fill += num3;
			}
			int num16 = -1;
			while (i < num11)
			{
				int num17 = (int)(header_base[num + 27 + i] & byte.MaxValue);
				this.lacing_vals[this.lacing_fill] = num17;
				this.granule_vals[this.lacing_fill] = -1L;
				if (num6 != 0)
				{
					this.lacing_vals[this.lacing_fill] |= 256;
					num6 = 0;
				}
				if (num17 < 255)
				{
					num16 = this.lacing_fill;
				}
				this.lacing_fill++;
				i++;
				if (num17 < 255)
				{
					this.lacing_packet = this.lacing_fill;
				}
			}
			if (num16 != -1)
			{
				this.granule_vals[num16] = num8;
			}
			if (num7 != 0)
			{
				this.e_o_s = 1;
				if (this.lacing_fill > 0)
				{
					this.lacing_vals[this.lacing_fill - 1] |= 512;
				}
			}
			this.pageno = num10 + 1;
			return 0;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00017E58 File Offset: 0x00016058
		public int flush(Page og)
		{
			int num = (this.lacing_fill > 255) ? 255 : this.lacing_fill;
			int num2 = 0;
			int num3 = 0;
			long num4 = this.granule_vals[0];
			if (num == 0)
			{
				return 0;
			}
			int i;
			if (this.b_o_s == 0)
			{
				num4 = 0L;
				for (i = 0; i < num; i++)
				{
					if ((this.lacing_vals[i] & 255) < 255)
					{
						i++;
						break;
					}
				}
			}
			else
			{
				i = 0;
				while (i < num && num3 <= 4096)
				{
					num3 += (this.lacing_vals[i] & 255);
					num4 = this.granule_vals[i];
					i++;
				}
			}
			string s = "OggS";
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			Array.Copy(bytes, 0, this.header, 0, bytes.Length);
			this.header[4] = 0;
			this.header[5] = 0;
			if ((this.lacing_vals[0] & 256) == 0)
			{
				byte[] array = this.header;
				int num5 = 5;
				array[num5] |= 1;
			}
			if (this.b_o_s == 0)
			{
				byte[] array2 = this.header;
				int num6 = 5;
				array2[num6] |= 2;
			}
			if (this.e_o_s != 0 && this.lacing_fill == i)
			{
				byte[] array3 = this.header;
				int num7 = 5;
				array3[num7] |= 4;
			}
			this.b_o_s = 1;
			for (int j = 6; j < 14; j++)
			{
				this.header[j] = (byte)num4;
				num4 >>= 8;
			}
			int num8 = this.serialno;
			for (int j = 14; j < 18; j++)
			{
				this.header[j] = (byte)num8;
				num8 >>= 8;
			}
			if (this.pageno == -1)
			{
				this.pageno = 0;
			}
			int num9 = this.pageno;
			this.pageno = num9 + 1;
			int num10 = num9;
			for (int j = 18; j < 22; j++)
			{
				this.header[j] = (byte)num10;
				num10 >>= 8;
			}
			this.header[22] = 0;
			this.header[23] = 0;
			this.header[24] = 0;
			this.header[25] = 0;
			this.header[26] = (byte)i;
			for (int j = 0; j < i; j++)
			{
				this.header[j + 27] = (byte)this.lacing_vals[j];
				num2 += (int)(this.header[j + 27] & byte.MaxValue);
			}
			og.header_base = this.header;
			og.header = 0;
			og.header_len = (this.header_fill = i + 27);
			og.body_base = this.body_data;
			og.body = this.body_returned;
			og.body_len = num2;
			this.lacing_fill -= i;
			Array.Copy(this.lacing_vals, i, this.lacing_vals, 0, this.lacing_fill * 4);
			Array.Copy(this.granule_vals, i, this.granule_vals, 0, this.lacing_fill * 8);
			this.body_returned += num2;
			og.checksum();
			return 1;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00018130 File Offset: 0x00016330
		public int pageout(Page og)
		{
			if ((this.e_o_s != 0 && this.lacing_fill != 0) || this.body_fill - this.body_returned > 4096 || this.lacing_fill >= 255 || (this.lacing_fill != 0 && this.b_o_s == 0))
			{
				return this.flush(og);
			}
			return 0;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00018187 File Offset: 0x00016387
		public int eof()
		{
			return this.e_o_s;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00018190 File Offset: 0x00016390
		public int reset()
		{
			this.body_fill = 0;
			this.body_returned = 0;
			this.lacing_fill = 0;
			this.lacing_packet = 0;
			this.lacing_returned = 0;
			this.header_fill = 0;
			this.e_o_s = 0;
			this.b_o_s = 0;
			this.pageno = -1;
			this.packetno = 0L;
			this.granulepos = 0L;
			return 0;
		}

		// Token: 0x040002DD RID: 733
		private byte[] body_data;

		// Token: 0x040002DE RID: 734
		private int body_storage;

		// Token: 0x040002DF RID: 735
		private int body_fill;

		// Token: 0x040002E0 RID: 736
		private int body_returned;

		// Token: 0x040002E1 RID: 737
		private int[] lacing_vals;

		// Token: 0x040002E2 RID: 738
		private long[] granule_vals;

		// Token: 0x040002E3 RID: 739
		private int lacing_storage;

		// Token: 0x040002E4 RID: 740
		private int lacing_fill;

		// Token: 0x040002E5 RID: 741
		private int lacing_packet;

		// Token: 0x040002E6 RID: 742
		private int lacing_returned;

		// Token: 0x040002E7 RID: 743
		private byte[] header = new byte[282];

		// Token: 0x040002E8 RID: 744
		private int header_fill;

		// Token: 0x040002E9 RID: 745
		public int e_o_s;

		// Token: 0x040002EA RID: 746
		private int b_o_s;

		// Token: 0x040002EB RID: 747
		private int serialno;

		// Token: 0x040002EC RID: 748
		private int pageno;

		// Token: 0x040002ED RID: 749
		private long packetno;

		// Token: 0x040002EE RID: 750
		private long granulepos;
	}
}
