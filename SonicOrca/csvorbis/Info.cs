using System;
using System.Text;
using csogg;

namespace csvorbis
{
	// Token: 0x02000078 RID: 120
	public class Info
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x00011FEE File Offset: 0x000101EE
		public void init()
		{
			this.rate = 0;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00011FF8 File Offset: 0x000101F8
		public void clear()
		{
			for (int i = 0; i < this.modes; i++)
			{
				this.mode_param[i] = null;
			}
			this.mode_param = null;
			for (int j = 0; j < this.maps; j++)
			{
				FuncMapping.mapping_P[this.map_type[j]].free_info(this.map_param[j]);
			}
			this.map_param = null;
			for (int k = 0; k < this.times; k++)
			{
				FuncTime.time_P[this.time_type[k]].free_info(this.time_param[k]);
			}
			this.time_param = null;
			for (int l = 0; l < this.floors; l++)
			{
				FuncFloor.floor_P[this.floor_type[l]].free_info(this.floor_param[l]);
			}
			this.floor_param = null;
			for (int m = 0; m < this.residues; m++)
			{
				FuncResidue.residue_P[this.residue_type[m]].free_info(this.residue_param[m]);
			}
			this.residue_param = null;
			for (int n = 0; n < this.books; n++)
			{
				if (this.book_param[n] != null)
				{
					this.book_param[n].clear();
					this.book_param[n] = null;
				}
			}
			this.book_param = null;
			for (int num = 0; num < this.psys; num++)
			{
				this.psy_param[num].free();
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001215C File Offset: 0x0001035C
		private int unpack_info(csBuffer opb)
		{
			this.version = opb.read(32);
			if (this.version != 0)
			{
				return -1;
			}
			this.channels = opb.read(8);
			this.rate = opb.read(32);
			this.bitrate_upper = opb.read(32);
			this.bitrate_nominal = opb.read(32);
			this.bitrate_lower = opb.read(32);
			this.blocksizes[0] = 1 << opb.read(4);
			this.blocksizes[1] = 1 << opb.read(4);
			if (this.rate < 1 || this.channels < 1 || this.blocksizes[0] < 8 || this.blocksizes[1] < this.blocksizes[0] || opb.read(1) != 1)
			{
				this.clear();
				return -1;
			}
			return 0;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00012230 File Offset: 0x00010430
		private int unpack_books(csBuffer opb)
		{
			this.books = opb.read(8) + 1;
			if (this.book_param == null || this.book_param.Length != this.books)
			{
				this.book_param = new StaticCodeBook[this.books];
			}
			for (int i = 0; i < this.books; i++)
			{
				this.book_param[i] = new StaticCodeBook();
				if (this.book_param[i].unpack(opb) != 0)
				{
					this.clear();
					return -1;
				}
			}
			this.times = opb.read(6) + 1;
			if (this.time_type == null || this.time_type.Length != this.times)
			{
				this.time_type = new int[this.times];
			}
			if (this.time_param == null || this.time_param.Length != this.times)
			{
				this.time_param = new object[this.times];
			}
			for (int j = 0; j < this.times; j++)
			{
				this.time_type[j] = opb.read(16);
				if (this.time_type[j] < 0 || this.time_type[j] >= Info.VI_TIMEB)
				{
					this.clear();
					return -1;
				}
				this.time_param[j] = FuncTime.time_P[this.time_type[j]].unpack(this, opb);
				if (this.time_param[j] == null)
				{
					this.clear();
					return -1;
				}
			}
			this.floors = opb.read(6) + 1;
			if (this.floor_type == null || this.floor_type.Length != this.floors)
			{
				this.floor_type = new int[this.floors];
			}
			if (this.floor_param == null || this.floor_param.Length != this.floors)
			{
				this.floor_param = new object[this.floors];
			}
			for (int k = 0; k < this.floors; k++)
			{
				this.floor_type[k] = opb.read(16);
				if (this.floor_type[k] < 0 || this.floor_type[k] >= Info.VI_FLOORB)
				{
					this.clear();
					return -1;
				}
				this.floor_param[k] = FuncFloor.floor_P[this.floor_type[k]].unpack(this, opb);
				if (this.floor_param[k] == null)
				{
					this.clear();
					return -1;
				}
			}
			this.residues = opb.read(6) + 1;
			if (this.residue_type == null || this.residue_type.Length != this.residues)
			{
				this.residue_type = new int[this.residues];
			}
			if (this.residue_param == null || this.residue_param.Length != this.residues)
			{
				this.residue_param = new object[this.residues];
			}
			for (int l = 0; l < this.residues; l++)
			{
				this.residue_type[l] = opb.read(16);
				if (this.residue_type[l] < 0 || this.residue_type[l] >= Info.VI_RESB)
				{
					this.clear();
					return -1;
				}
				this.residue_param[l] = FuncResidue.residue_P[this.residue_type[l]].unpack(this, opb);
				if (this.residue_param[l] == null)
				{
					this.clear();
					return -1;
				}
			}
			this.maps = opb.read(6) + 1;
			if (this.map_type == null || this.map_type.Length != this.maps)
			{
				this.map_type = new int[this.maps];
			}
			if (this.map_param == null || this.map_param.Length != this.maps)
			{
				this.map_param = new object[this.maps];
			}
			for (int m = 0; m < this.maps; m++)
			{
				this.map_type[m] = opb.read(16);
				if (this.map_type[m] < 0 || this.map_type[m] >= Info.VI_MAPB)
				{
					this.clear();
					return -1;
				}
				this.map_param[m] = FuncMapping.mapping_P[this.map_type[m]].unpack(this, opb);
				if (this.map_param[m] == null)
				{
					this.clear();
					return -1;
				}
			}
			this.modes = opb.read(6) + 1;
			if (this.mode_param == null || this.mode_param.Length != this.modes)
			{
				this.mode_param = new InfoMode[this.modes];
			}
			for (int n = 0; n < this.modes; n++)
			{
				this.mode_param[n] = new InfoMode();
				this.mode_param[n].blockflag = opb.read(1);
				this.mode_param[n].windowtype = opb.read(16);
				this.mode_param[n].transformtype = opb.read(16);
				this.mode_param[n].mapping = opb.read(8);
				if (this.mode_param[n].windowtype >= Info.VI_WINDOWB || this.mode_param[n].transformtype >= Info.VI_WINDOWB || this.mode_param[n].mapping >= this.maps)
				{
					this.clear();
					return -1;
				}
			}
			if (opb.read(1) != 1)
			{
				this.clear();
				return -1;
			}
			return 0;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00012714 File Offset: 0x00010914
		public int synthesis_headerin(Comment vc, Packet op)
		{
			csBuffer csBuffer = new csBuffer();
			if (op != null)
			{
				csBuffer.readinit(op.packet_base, op.packet, op.bytes);
				byte[] array = new byte[6];
				int num = csBuffer.read(8);
				csBuffer.read(array, 6);
				if (array[0] != 118 || array[1] != 111 || array[2] != 114 || array[3] != 98 || array[4] != 105 || array[5] != 115)
				{
					return -1;
				}
				switch (num)
				{
				case 1:
					if (op.b_o_s == 0)
					{
						return -1;
					}
					if (this.rate != 0)
					{
						return -1;
					}
					return this.unpack_info(csBuffer);
				case 3:
					if (this.rate == 0)
					{
						return -1;
					}
					return vc.unpack(csBuffer);
				case 5:
					if (this.rate == 0 || vc.vendor == null)
					{
						return -1;
					}
					return this.unpack_books(csBuffer);
				}
			}
			return -1;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000127F0 File Offset: 0x000109F0
		private int pack_info(csBuffer opb)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Info._vorbis);
			opb.write(1, 8);
			opb.write(bytes);
			opb.write(0, 32);
			opb.write(this.channels, 8);
			opb.write(this.rate, 32);
			opb.write(this.bitrate_upper, 32);
			opb.write(this.bitrate_nominal, 32);
			opb.write(this.bitrate_lower, 32);
			opb.write(Info.ilog2(this.blocksizes[0]), 4);
			opb.write(Info.ilog2(this.blocksizes[1]), 4);
			opb.write(1, 1);
			return 0;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001289C File Offset: 0x00010A9C
		private int pack_books(csBuffer opb)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Info._vorbis);
			opb.write(5, 8);
			opb.write(bytes);
			opb.write(this.books - 1, 8);
			for (int i = 0; i < this.books; i++)
			{
				if (this.book_param[i].pack(opb) != 0)
				{
					return -1;
				}
			}
			opb.write(this.times - 1, 6);
			for (int j = 0; j < this.times; j++)
			{
				opb.write(this.time_type[j], 16);
				FuncTime.time_P[this.time_type[j]].pack(this.time_param[j], opb);
			}
			opb.write(this.floors - 1, 6);
			for (int k = 0; k < this.floors; k++)
			{
				opb.write(this.floor_type[k], 16);
				FuncFloor.floor_P[this.floor_type[k]].pack(this.floor_param[k], opb);
			}
			opb.write(this.residues - 1, 6);
			for (int l = 0; l < this.residues; l++)
			{
				opb.write(this.residue_type[l], 16);
				FuncResidue.residue_P[this.residue_type[l]].pack(this.residue_param[l], opb);
			}
			opb.write(this.maps - 1, 6);
			for (int m = 0; m < this.maps; m++)
			{
				opb.write(this.map_type[m], 16);
				FuncMapping.mapping_P[this.map_type[m]].pack(this, this.map_param[m], opb);
			}
			opb.write(this.modes - 1, 6);
			for (int n = 0; n < this.modes; n++)
			{
				opb.write(this.mode_param[n].blockflag, 1);
				opb.write(this.mode_param[n].windowtype, 16);
				opb.write(this.mode_param[n].transformtype, 16);
				opb.write(this.mode_param[n].mapping, 8);
			}
			opb.write(1, 1);
			return 0;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00012ABC File Offset: 0x00010CBC
		public int blocksize(Packet op)
		{
			csBuffer csBuffer = new csBuffer();
			csBuffer.readinit(op.packet_base, op.packet, op.bytes);
			if (csBuffer.read(1) != 0)
			{
				return Info.OV_ENOTAUDIO;
			}
			int num = 0;
			for (int i = this.modes; i > 1; i = (int)((uint)i >> 1))
			{
				num++;
			}
			int num2 = csBuffer.read(num);
			if (num2 == -1)
			{
				return Info.OV_EBADPACKET;
			}
			return this.blocksizes[this.mode_param[num2].blockflag];
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00012B34 File Offset: 0x00010D34
		private static int ilog2(int v)
		{
			int num = 0;
			while (v > 1)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00012B54 File Offset: 0x00010D54
		public string toString()
		{
			return string.Concat(new string[]
			{
				"version:",
				this.version.ToString(),
				", channels:",
				this.channels.ToString(),
				", rate:",
				this.rate.ToString(),
				", bitrate:",
				this.bitrate_upper.ToString(),
				",",
				this.bitrate_nominal.ToString(),
				",",
				this.bitrate_lower.ToString()
			});
		}

		// Token: 0x04000217 RID: 535
		private static int OV_EBADPACKET = -136;

		// Token: 0x04000218 RID: 536
		private static int OV_ENOTAUDIO = -135;

		// Token: 0x04000219 RID: 537
		private static string _vorbis = "vorbis";

		// Token: 0x0400021A RID: 538
		private static int VI_TIMEB = 1;

		// Token: 0x0400021B RID: 539
		private static int VI_FLOORB = 2;

		// Token: 0x0400021C RID: 540
		private static int VI_RESB = 3;

		// Token: 0x0400021D RID: 541
		private static int VI_MAPB = 1;

		// Token: 0x0400021E RID: 542
		private static int VI_WINDOWB = 1;

		// Token: 0x0400021F RID: 543
		public int version;

		// Token: 0x04000220 RID: 544
		public int channels;

		// Token: 0x04000221 RID: 545
		public int rate;

		// Token: 0x04000222 RID: 546
		internal int bitrate_upper;

		// Token: 0x04000223 RID: 547
		internal int bitrate_nominal;

		// Token: 0x04000224 RID: 548
		internal int bitrate_lower;

		// Token: 0x04000225 RID: 549
		internal int[] blocksizes = new int[2];

		// Token: 0x04000226 RID: 550
		internal int modes;

		// Token: 0x04000227 RID: 551
		internal int maps;

		// Token: 0x04000228 RID: 552
		internal int times;

		// Token: 0x04000229 RID: 553
		internal int floors;

		// Token: 0x0400022A RID: 554
		internal int residues;

		// Token: 0x0400022B RID: 555
		internal int books;

		// Token: 0x0400022C RID: 556
		internal int psys;

		// Token: 0x0400022D RID: 557
		internal InfoMode[] mode_param;

		// Token: 0x0400022E RID: 558
		internal int[] map_type;

		// Token: 0x0400022F RID: 559
		internal object[] map_param;

		// Token: 0x04000230 RID: 560
		internal int[] time_type;

		// Token: 0x04000231 RID: 561
		internal object[] time_param;

		// Token: 0x04000232 RID: 562
		internal int[] floor_type;

		// Token: 0x04000233 RID: 563
		internal object[] floor_param;

		// Token: 0x04000234 RID: 564
		internal int[] residue_type;

		// Token: 0x04000235 RID: 565
		internal object[] residue_param;

		// Token: 0x04000236 RID: 566
		internal StaticCodeBook[] book_param;

		// Token: 0x04000237 RID: 567
		internal PsyInfo[] psy_param = new PsyInfo[64];
	}
}
