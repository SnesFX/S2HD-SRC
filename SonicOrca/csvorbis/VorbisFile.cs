using System;
using System.IO;
using csogg;

namespace csvorbis
{
	// Token: 0x0200008A RID: 138
	public class VorbisFile
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x000154A9 File Offset: 0x000136A9
		private VorbisFile()
		{
			this.os = new StreamState();
			this.vd = new DspState();
			this.vb = new Block(this.vd);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000154E4 File Offset: 0x000136E4
		public VorbisFile(string file) : this()
		{
			FileStream iis = null;
			try
			{
				iis = new FileStream(file, FileMode.Open, FileAccess.Read);
			}
			catch (Exception ex)
			{
				throw new csorbisException("VorbisFile: " + ex.Message);
			}
			if (this.open(iis, null, 0) == -1)
			{
				throw new csorbisException("VorbisFile: open return -1");
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00015544 File Offset: 0x00013744
		public VorbisFile(FileStream inst, byte[] initial, int ibytes) : this()
		{
			this.open(inst, initial, ibytes);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00015558 File Offset: 0x00013758
		private int get_data()
		{
			int num = this.oy.buffer(VorbisFile.CHUNKSIZE);
			byte[] data = this.oy.data;
			int num2 = 0;
			try
			{
				num2 = this.datasource.Read(data, num, VorbisFile.CHUNKSIZE);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				return VorbisFile.OV_EREAD;
			}
			this.oy.wrote(num2);
			if (num2 == -1)
			{
				num2 = 0;
			}
			return num2;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000155DC File Offset: 0x000137DC
		private void seek_helper(long offst)
		{
			VorbisFile.fseek(this.datasource, offst, VorbisFile.SEEK_SET);
			this.offset = offst;
			this.oy.reset();
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00015604 File Offset: 0x00013804
		private int get_next_page(Page page, long boundary)
		{
			if (boundary > 0L)
			{
				boundary += this.offset;
			}
			while (boundary <= 0L || this.offset < boundary)
			{
				int num = this.oy.pageseek(page);
				if (num < 0)
				{
					this.offset -= (long)num;
				}
				else
				{
					if (num != 0)
					{
						int result = (int)this.offset;
						this.offset += (long)num;
						return result;
					}
					if (boundary == 0L)
					{
						return VorbisFile.OV_FALSE;
					}
					int data = this.get_data();
					if (data == 0)
					{
						return VorbisFile.OV_EOF;
					}
					if (data < 0)
					{
						return VorbisFile.OV_EREAD;
					}
				}
			}
			return VorbisFile.OV_FALSE;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00015694 File Offset: 0x00013894
		private int get_prev_page(Page page)
		{
			long num = this.offset;
			int num2 = -1;
			int num3;
			while (num2 == -1)
			{
				num -= (long)VorbisFile.CHUNKSIZE;
				if (num < 0L)
				{
					num = 0L;
				}
				this.seek_helper(num);
				while (this.offset < num + (long)VorbisFile.CHUNKSIZE)
				{
					num3 = this.get_next_page(page, num + (long)VorbisFile.CHUNKSIZE - this.offset);
					if (num3 == VorbisFile.OV_EREAD)
					{
						return VorbisFile.OV_EREAD;
					}
					if (num3 < 0)
					{
						break;
					}
					num2 = num3;
				}
			}
			this.seek_helper((long)num2);
			num3 = this.get_next_page(page, (long)VorbisFile.CHUNKSIZE);
			if (num3 < 0)
			{
				return VorbisFile.OV_EFAULT;
			}
			return num2;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00015728 File Offset: 0x00013928
		private int bisect_forward_serialno(long begin, long searched, long end, int currentno, int m)
		{
			long num = end;
			long num2 = end;
			Page page = new Page();
			int num4;
			while (searched < num)
			{
				long num3;
				if (num - searched < (long)VorbisFile.CHUNKSIZE)
				{
					num3 = searched;
				}
				else
				{
					num3 = (searched + num) / 2L;
				}
				this.seek_helper(num3);
				num4 = this.get_next_page(page, -1L);
				if (num4 == VorbisFile.OV_EREAD)
				{
					return VorbisFile.OV_EREAD;
				}
				if (num4 < 0 || page.serialno() != currentno)
				{
					num = num3;
					if (num4 >= 0)
					{
						num2 = (long)num4;
					}
				}
				else
				{
					searched = (long)(num4 + page.header_len + page.body_len);
				}
			}
			this.seek_helper(num2);
			num4 = this.get_next_page(page, -1L);
			if (num4 == VorbisFile.OV_EREAD)
			{
				return VorbisFile.OV_EREAD;
			}
			if (searched >= end || num4 == -1)
			{
				this.links = m + 1;
				this.offsets = new long[m + 2];
				this.offsets[m + 1] = searched;
			}
			else
			{
				num4 = this.bisect_forward_serialno(num2, this.offset, end, page.serialno(), m + 1);
				if (num4 == VorbisFile.OV_EREAD)
				{
					return VorbisFile.OV_EREAD;
				}
			}
			this.offsets[m] = begin;
			return 0;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0001582C File Offset: 0x00013A2C
		private int fetch_headers(Info vi, Comment vc, int[] serialno, Page og_ptr)
		{
			Page page = new Page();
			Packet op = new Packet();
			if (og_ptr == null)
			{
				int num = this.get_next_page(page, (long)VorbisFile.CHUNKSIZE);
				if (num == VorbisFile.OV_EREAD)
				{
					return VorbisFile.OV_EREAD;
				}
				if (num < 0)
				{
					return VorbisFile.OV_ENOTVORBIS;
				}
				og_ptr = page;
			}
			if (serialno != null)
			{
				serialno[0] = og_ptr.serialno();
			}
			this.os.init(og_ptr.serialno());
			vi.init();
			vc.init();
			int i = 0;
			while (i < 3)
			{
				this.os.pagein(og_ptr);
				while (i < 3)
				{
					int num2 = this.os.packetout(op);
					if (num2 == 0)
					{
						break;
					}
					if (num2 == -1)
					{
						Console.Error.WriteLine("Corrupt header in logical bitstream.");
						vi.clear();
						vc.clear();
						this.os.clear();
						return -1;
					}
					if (vi.synthesis_headerin(vc, op) != 0)
					{
						Console.Error.WriteLine("Illegal header in logical bitstream.");
						vi.clear();
						vc.clear();
						this.os.clear();
						return -1;
					}
					i++;
				}
				if (i < 3 && this.get_next_page(og_ptr, 1L) < 0)
				{
					Console.Error.WriteLine("Missing header in logical bitstream.");
					vi.clear();
					vc.clear();
					this.os.clear();
					return -1;
				}
			}
			return 0;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00015970 File Offset: 0x00013B70
		private void prefetch_all_headers(Info first_i, Comment first_c, int dataoffset)
		{
			Page page = new Page();
			this.vi = new Info[this.links];
			this.vc = new Comment[this.links];
			this.dataoffsets = new long[this.links];
			this.pcmlengths = new long[this.links];
			this.serialnos = new int[this.links];
			int i = 0;
			IL_179:
			while (i < this.links)
			{
				if (first_i != null && first_c != null && i == 0)
				{
					this.vi[i] = first_i;
					this.vc[i] = first_c;
					this.dataoffsets[i] = (long)dataoffset;
				}
				else
				{
					this.seek_helper(this.offsets[i]);
					if (this.fetch_headers(this.vi[i], this.vc[i], null, null) == -1)
					{
						Console.Error.WriteLine("Error opening logical bitstream #" + (i + 1) + "\n");
						this.dataoffsets[i] = -1L;
					}
					else
					{
						this.dataoffsets[i] = this.offset;
						this.os.clear();
					}
				}
				long offst = this.offsets[i + 1];
				this.seek_helper(offst);
				while (this.get_prev_page(page) != -1)
				{
					if (page.granulepos() != -1L)
					{
						this.serialnos[i] = page.serialno();
						this.pcmlengths[i] = page.granulepos();
						IL_175:
						i++;
						goto IL_179;
					}
				}
				Console.Error.WriteLine("Could not find last page of logical bitstream #" + i + "\n");
				this.vi[i].clear();
				this.vc[i].clear();
				goto IL_175;
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00015B02 File Offset: 0x00013D02
		private int make_decode_ready()
		{
			if (this.decode_ready)
			{
				Environment.Exit(1);
			}
			this.vd.synthesis_init(this.vi[0]);
			this.vb.init(this.vd);
			this.decode_ready = true;
			return 0;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00015B40 File Offset: 0x00013D40
		private int open_seekable()
		{
			Info first_i = new Info();
			Comment first_c = new Comment();
			Page page = new Page();
			int[] array = new int[1];
			int num = this.fetch_headers(first_i, first_c, array, null);
			int num2 = array[0];
			int dataoffset = (int)this.offset;
			this.os.clear();
			if (num == -1)
			{
				return -1;
			}
			this.skable = true;
			VorbisFile.fseek(this.datasource, 0L, VorbisFile.SEEK_END);
			this.offset = VorbisFile.ftell(this.datasource);
			long num3 = this.offset;
			num3 = (long)this.get_prev_page(page);
			if (page.serialno() != num2)
			{
				if (this.bisect_forward_serialno(0L, 0L, num3 + 1L, num2, 0) < 0)
				{
					this.clear();
					return VorbisFile.OV_EREAD;
				}
			}
			else if (this.bisect_forward_serialno(0L, num3, num3 + 1L, num2, 0) < 0)
			{
				this.clear();
				return VorbisFile.OV_EREAD;
			}
			this.prefetch_all_headers(first_i, first_c, dataoffset);
			return this.raw_seek(0);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00015C28 File Offset: 0x00013E28
		private int open_nonseekable()
		{
			this.links = 1;
			this.vi = new Info[this.links];
			this.vi[0] = new Info();
			this.vc = new Comment[this.links];
			this.vc[0] = new Comment();
			int[] array = new int[1];
			if (this.fetch_headers(this.vi[0], this.vc[0], array, null) == -1)
			{
				return -1;
			}
			this.current_serialno = array[0];
			this.make_decode_ready();
			return 0;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00015CB0 File Offset: 0x00013EB0
		private void decode_clear()
		{
			this.os.clear();
			this.vd.clear();
			this.vb.clear();
			this.decode_ready = false;
			this.bittrack = 0f;
			this.samptrack = 0f;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00015CFC File Offset: 0x00013EFC
		private int process_packet(int readp)
		{
			Page page = new Page();
			Packet packet;
			long num;
			for (;;)
			{
				if (this.decode_ready)
				{
					packet = new Packet();
					if (this.os.packetout(packet) > 0)
					{
						num = packet.granulepos;
						if (this.vb.synthesis(packet) == 0)
						{
							break;
						}
					}
				}
				if (readp == 0)
				{
					return 0;
				}
				if (this.get_next_page(page, -1L) < 0)
				{
					return 0;
				}
				this.bittrack += (float)(page.header_len * 8);
				if (this.decode_ready && this.current_serialno != page.serialno())
				{
					this.decode_clear();
				}
				if (!this.decode_ready)
				{
					if (this.skable)
					{
						this.current_serialno = page.serialno();
						int num2 = 0;
						while (num2 < this.links && this.serialnos[num2] != this.current_serialno)
						{
							num2++;
						}
						if (num2 == this.links)
						{
							return -1;
						}
						this.current_link = num2;
						this.os.init(this.current_serialno);
						this.os.reset();
					}
					else
					{
						int[] array = new int[1];
						int num3 = this.fetch_headers(this.vi[0], this.vc[0], array, page);
						this.current_serialno = array[0];
						if (num3 != 0)
						{
							return num3;
						}
						this.current_link++;
					}
					this.make_decode_ready();
				}
				this.os.pagein(page);
			}
			int num4 = this.vd.synthesis_pcmout(null, null);
			this.vd.synthesis_blockin(this.vb);
			this.samptrack += (float)(this.vd.synthesis_pcmout(null, null) - num4);
			this.bittrack += (float)(packet.bytes * 8);
			if (num != -1L && packet.e_o_s == 0)
			{
				int num5 = this.skable ? this.current_link : 0;
				int num6 = this.vd.synthesis_pcmout(null, null);
				num -= (long)num6;
				for (int i = 0; i < num5; i++)
				{
					num += this.pcmlengths[i];
				}
				this.pcm_offset = num;
			}
			return 1;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00015F14 File Offset: 0x00014114
		private int clear()
		{
			this.vb.clear();
			this.vd.clear();
			this.os.clear();
			if (this.vi != null && this.links != 0)
			{
				for (int i = 0; i < this.links; i++)
				{
					this.vi[i].clear();
					this.vc[i].clear();
				}
				this.vi = null;
				this.vc = null;
			}
			if (this.dataoffsets != null)
			{
				this.dataoffsets = null;
			}
			if (this.pcmlengths != null)
			{
				this.pcmlengths = null;
			}
			if (this.serialnos != null)
			{
				this.serialnos = null;
			}
			if (this.offsets != null)
			{
				this.offsets = null;
			}
			this.oy.clear();
			return 0;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00015FD8 File Offset: 0x000141D8
		private static int fseek(FileStream fis, long off, int whence)
		{
			if (fis.CanSeek)
			{
				try
				{
					if (whence == VorbisFile.SEEK_SET)
					{
						fis.Seek(off, SeekOrigin.Begin);
					}
					else if (whence == VorbisFile.SEEK_END)
					{
						fis.Seek(fis.Length - off, SeekOrigin.Begin);
					}
					else
					{
						Console.Error.WriteLine("seek: " + whence + " is not supported");
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
				return 0;
			}
			try
			{
				if (whence == 0)
				{
					fis.Seek(0L, SeekOrigin.Begin);
				}
				fis.Seek(off, SeekOrigin.Begin);
			}
			catch (Exception ex2)
			{
				Console.Error.WriteLine(ex2.Message);
				return -1;
			}
			return 0;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000160A0 File Offset: 0x000142A0
		private static long ftell(FileStream fis)
		{
			try
			{
				if (fis.CanSeek)
				{
					return fis.Position;
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return 0L;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x000160E8 File Offset: 0x000142E8
		private int open(FileStream iis, byte[] initial, int ibytes)
		{
			return this.open_callbacks(iis, initial, ibytes);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000160F4 File Offset: 0x000142F4
		private int open_callbacks(FileStream iis, byte[] initial, int ibytes)
		{
			this.datasource = iis;
			this.oy.init();
			if (initial != null)
			{
				int destinationIndex = this.oy.buffer(ibytes);
				Array.Copy(initial, 0, this.oy.data, destinationIndex, ibytes);
				this.oy.wrote(ibytes);
			}
			int num;
			if (iis.CanSeek)
			{
				num = this.open_seekable();
			}
			else
			{
				num = this.open_nonseekable();
			}
			if (num != 0)
			{
				this.datasource = null;
				this.clear();
			}
			return num;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0001616E File Offset: 0x0001436E
		public int streams()
		{
			return this.links;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00016176 File Offset: 0x00014376
		public bool seekable()
		{
			return this.skable;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00016180 File Offset: 0x00014380
		public int bitrate(int i)
		{
			if (i >= this.links)
			{
				return -1;
			}
			if (!this.skable && i != 0)
			{
				return this.bitrate(0);
			}
			if (i < 0)
			{
				long num = 0L;
				for (int j = 0; j < this.links; j++)
				{
					num += (this.offsets[j + 1] - this.dataoffsets[j]) * 8L;
				}
				return (int)Math.Round((double)((float)num / this.time_total(-1)));
			}
			if (this.skable)
			{
				return (int)Math.Round((double)((float)((this.offsets[i + 1] - this.dataoffsets[i]) * 8L) / this.time_total(i)));
			}
			if (this.vi[i].bitrate_nominal > 0)
			{
				return this.vi[i].bitrate_nominal;
			}
			if (this.vi[i].bitrate_upper <= 0)
			{
				return -1;
			}
			if (this.vi[i].bitrate_lower > 0)
			{
				return (this.vi[i].bitrate_upper + this.vi[i].bitrate_lower) / 2;
			}
			return this.vi[i].bitrate_upper;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00016288 File Offset: 0x00014488
		public int bitrate_instant()
		{
			int num = this.skable ? this.current_link : 0;
			if (this.samptrack == 0f)
			{
				return -1;
			}
			int result = (int)((double)(this.bittrack / this.samptrack * (float)this.vi[num].rate) + 0.5);
			this.bittrack = 0f;
			this.samptrack = 0f;
			return result;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000162F4 File Offset: 0x000144F4
		public int serialnumber(int i)
		{
			if (i >= this.links)
			{
				return -1;
			}
			if (!this.skable && i >= 0)
			{
				return this.serialnumber(-1);
			}
			if (i < 0)
			{
				return this.current_serialno;
			}
			return this.serialnos[i];
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00016328 File Offset: 0x00014528
		public long raw_total(int i)
		{
			if (!this.skable || i >= this.links)
			{
				return -1L;
			}
			if (i < 0)
			{
				long num = 0L;
				for (int j = 0; j < this.links; j++)
				{
					num += this.raw_total(j);
				}
				return num;
			}
			return this.offsets[i + 1] - this.offsets[i];
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00016380 File Offset: 0x00014580
		public long pcm_total(int i)
		{
			if (!this.skable || i >= this.links)
			{
				return -1L;
			}
			if (i < 0)
			{
				long num = 0L;
				for (int j = 0; j < this.links; j++)
				{
					num += this.pcm_total(j);
				}
				return num;
			}
			return this.pcmlengths[i];
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000163D0 File Offset: 0x000145D0
		public float time_total(int i)
		{
			if (!this.skable || i >= this.links)
			{
				return -1f;
			}
			if (i < 0)
			{
				float num = 0f;
				for (int j = 0; j < this.links; j++)
				{
					num += this.time_total(j);
				}
				return num;
			}
			return (float)this.pcmlengths[i] / (float)this.vi[i].rate;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00016434 File Offset: 0x00014634
		public int raw_seek(int pos)
		{
			if (!this.skable)
			{
				return -1;
			}
			if (pos < 0 || (long)pos > this.offsets[this.links])
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			this.pcm_offset = -1L;
			this.decode_clear();
			this.seek_helper((long)pos);
			int num = this.process_packet(1);
			if (num == -1)
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			if (num == 0)
			{
				this.pcm_offset = this.pcm_total(-1);
				return 0;
			}
			do
			{
				num = this.process_packet(0);
				if (num == -1)
				{
					goto IL_84;
				}
			}
			while (num != 0);
			return 0;
			IL_84:
			this.pcm_offset = -1L;
			this.decode_clear();
			return -1;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000164D4 File Offset: 0x000146D4
		public int pcm_seek(long pos)
		{
			long num = this.pcm_total(-1);
			if (!this.skable)
			{
				return -1;
			}
			if (pos < 0L || pos > num)
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			int i;
			for (i = this.links - 1; i >= 0; i--)
			{
				num -= this.pcmlengths[i];
				if (pos >= num)
				{
					break;
				}
			}
			long num2 = pos - num;
			long num3 = this.offsets[i + 1];
			long num4 = this.offsets[i];
			int pos2 = (int)num4;
			Page page = new Page();
			while (num4 < num3)
			{
				long num5;
				if (num3 - num4 < (long)VorbisFile.CHUNKSIZE)
				{
					num5 = num4;
				}
				else
				{
					num5 = (num3 + num4) / 2L;
				}
				this.seek_helper(num5);
				int num6 = this.get_next_page(page, num3 - num5);
				if (num6 == -1)
				{
					num3 = num5;
				}
				else if (page.granulepos() < num2)
				{
					pos2 = num6;
					num4 = this.offset;
				}
				else
				{
					num3 = num5;
				}
			}
			if (this.raw_seek(pos2) != 0)
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			if (this.pcm_offset >= pos)
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			if (pos > this.pcm_total(-1))
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			while (this.pcm_offset < pos)
			{
				int num7 = (int)(pos - this.pcm_offset);
				float[][][] array = new float[1][][];
				int[] index = new int[this.getInfo(-1).channels];
				int num8 = this.vd.synthesis_pcmout(array, index);
				float[][] array2 = array[0];
				if (num8 > num7)
				{
					num8 = num7;
				}
				this.vd.synthesis_read(num8);
				this.pcm_offset += (long)num8;
				if (num8 < num7 && this.process_packet(1) == 0)
				{
					this.pcm_offset = this.pcm_total(-1);
				}
			}
			return 0;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00016690 File Offset: 0x00014890
		public int time_seek(float seconds)
		{
			long num = this.pcm_total(-1);
			float num2 = this.time_total(-1);
			if (!this.skable)
			{
				return -1;
			}
			if (seconds < 0f || seconds > num2)
			{
				this.pcm_offset = -1L;
				this.decode_clear();
				return -1;
			}
			int i;
			for (i = this.links - 1; i >= 0; i--)
			{
				num -= this.pcmlengths[i];
				num2 -= this.time_total(i);
				if (seconds >= num2)
				{
					break;
				}
			}
			long pos = (long)((float)num + (seconds - num2) * (float)this.vi[i].rate);
			return this.pcm_seek(pos);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0001671F File Offset: 0x0001491F
		public long raw_tell()
		{
			return this.offset;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00016727 File Offset: 0x00014927
		public long pcm_tell()
		{
			return this.pcm_offset;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00016730 File Offset: 0x00014930
		public float time_tell()
		{
			int i = -1;
			long num = 0L;
			float num2 = 0f;
			if (this.skable)
			{
				num = this.pcm_total(-1);
				num2 = this.time_total(-1);
				for (i = this.links - 1; i >= 0; i--)
				{
					num -= this.pcmlengths[i];
					num2 -= this.time_total(i);
					if (this.pcm_offset >= num)
					{
						break;
					}
				}
			}
			return num2 + (float)(this.pcm_offset - num) / (float)this.vi[i].rate;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000167AC File Offset: 0x000149AC
		public Info getInfo(int link)
		{
			if (this.skable)
			{
				if (link < 0)
				{
					if (this.decode_ready)
					{
						return this.vi[this.current_link];
					}
					return null;
				}
				else
				{
					if (link >= this.links)
					{
						return null;
					}
					return this.vi[link];
				}
			}
			else
			{
				if (this.decode_ready)
				{
					return this.vi[0];
				}
				return null;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00016804 File Offset: 0x00014A04
		public Comment getComment(int link)
		{
			if (this.skable)
			{
				if (link < 0)
				{
					if (this.decode_ready)
					{
						return this.vc[this.current_link];
					}
					return null;
				}
				else
				{
					if (link >= this.links)
					{
						return null;
					}
					return this.vc[link];
				}
			}
			else
			{
				if (this.decode_ready)
				{
					return this.vc[0];
				}
				return null;
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000225B File Offset: 0x0000045B
		private int host_is_big_endian()
		{
			return 0;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0001685C File Offset: 0x00014A5C
		public int read(byte[] buffer, int length, int bigendianp, int word, int sgned, int[] bitstream)
		{
			int num = this.host_is_big_endian();
			int num2 = 0;
			int[] array2;
			int num3;
			float[][] array3;
			for (;;)
			{
				if (this.decode_ready)
				{
					float[][][] array = new float[1][][];
					array2 = new int[this.getInfo(-1).channels];
					num3 = this.vd.synthesis_pcmout(array, array2);
					array3 = array[0];
					if (num3 != 0)
					{
						break;
					}
				}
				int num4 = this.process_packet(1);
				if (num4 == -1)
				{
					return -1;
				}
				if (num4 == 0)
				{
					return 0;
				}
			}
			int channels = this.getInfo(-1).channels;
			int num5 = word * channels;
			if (num3 > length / num5)
			{
				num3 = length / num5;
			}
			if (word == 1)
			{
				int num6 = (sgned != 0) ? 0 : 128;
				for (int i = 0; i < num3; i++)
				{
					for (int j = 0; j < channels; j++)
					{
						int num7 = (int)((double)array3[j][array2[j] + i] * 128.0 + 0.5);
						if (num7 > 127)
						{
							num7 = 127;
						}
						else if (num7 < -128)
						{
							num7 = -128;
						}
						buffer[num2++] = (byte)(num7 + num6);
					}
				}
			}
			else
			{
				int num8 = (sgned != 0) ? 0 : 32768;
				if (num == bigendianp)
				{
					if (sgned != 0)
					{
						for (int k = 0; k < channels; k++)
						{
							int num9 = array2[k];
							int num10 = k * 2;
							for (int l = 0; l < num3; l++)
							{
								int num7 = (int)((double)array3[k][num9 + l] * 32767.0);
								if (num7 > 32767)
								{
									num7 = 32767;
								}
								else if (num7 < -32768)
								{
									num7 = -32768;
								}
								buffer[num10] = (byte)num7;
								buffer[num10 + 1] = (byte)((uint)num7 >> 8);
								num10 += num5;
							}
						}
					}
					else
					{
						for (int m = 0; m < channels; m++)
						{
							float[] array4 = array3[m];
							int num11 = m;
							for (int n = 0; n < num3; n++)
							{
								int num7 = (int)((double)array4[n] * 32768.0 + 0.5);
								if (num7 > 32767)
								{
									num7 = 32767;
								}
								else if (num7 < -32768)
								{
									num7 = -32768;
								}
								buffer[num11] = (byte)((uint)(num7 + num8) >> 8);
								buffer[num11 + 1] = (byte)(num7 + num8);
								num11 += channels * 2;
							}
						}
					}
				}
				else if (bigendianp != 0)
				{
					for (int num12 = 0; num12 < num3; num12++)
					{
						for (int num13 = 0; num13 < channels; num13++)
						{
							int num7 = (int)((double)array3[num13][num12] * 32768.0 + 0.5);
							if (num7 > 32767)
							{
								num7 = 32767;
							}
							else if (num7 < -32768)
							{
								num7 = -32768;
							}
							num7 += num8;
							buffer[num2++] = (byte)((uint)num7 >> 8);
							buffer[num2++] = (byte)num7;
						}
					}
				}
				else
				{
					for (int num14 = 0; num14 < num3; num14++)
					{
						for (int num15 = 0; num15 < channels; num15++)
						{
							int num7 = (int)((double)array3[num15][num14] * 32768.0 + 0.5);
							if (num7 > 32767)
							{
								num7 = 32767;
							}
							else if (num7 < -32768)
							{
								num7 = -32768;
							}
							num7 += num8;
							buffer[num2++] = (byte)num7;
							buffer[num2++] = (byte)((uint)num7 >> 8);
						}
					}
				}
			}
			this.vd.synthesis_read(num3);
			this.pcm_offset += (long)num3;
			if (bitstream != null)
			{
				bitstream[0] = this.current_link;
			}
			return num3 * num5;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00016BE6 File Offset: 0x00014DE6
		public Info[] getInfo()
		{
			return this.vi;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00016BEE File Offset: 0x00014DEE
		public Comment[] getComment()
		{
			return this.vc;
		}

		// Token: 0x040002A1 RID: 673
		private static int CHUNKSIZE = 8500;

		// Token: 0x040002A2 RID: 674
		private static int SEEK_SET = 0;

		// Token: 0x040002A3 RID: 675
		private static int SEEK_CUR = 1;

		// Token: 0x040002A4 RID: 676
		private static int SEEK_END = 2;

		// Token: 0x040002A5 RID: 677
		private static int OV_FALSE = -1;

		// Token: 0x040002A6 RID: 678
		private static int OV_EOF = -2;

		// Token: 0x040002A7 RID: 679
		private static int OV_HOLE = -3;

		// Token: 0x040002A8 RID: 680
		private static int OV_EREAD = -128;

		// Token: 0x040002A9 RID: 681
		private static int OV_EFAULT = -129;

		// Token: 0x040002AA RID: 682
		private static int OV_EIMPL = -130;

		// Token: 0x040002AB RID: 683
		private static int OV_EINVAL = -131;

		// Token: 0x040002AC RID: 684
		private static int OV_ENOTVORBIS = -132;

		// Token: 0x040002AD RID: 685
		private static int OV_EBADHEADER = -133;

		// Token: 0x040002AE RID: 686
		private static int OV_EVERSION = -134;

		// Token: 0x040002AF RID: 687
		private static int OV_ENOTAUDIO = -135;

		// Token: 0x040002B0 RID: 688
		private static int OV_EBADPACKET = -136;

		// Token: 0x040002B1 RID: 689
		private static int OV_EBADLINK = -137;

		// Token: 0x040002B2 RID: 690
		private static int OV_ENOSEEK = -138;

		// Token: 0x040002B3 RID: 691
		private FileStream datasource;

		// Token: 0x040002B4 RID: 692
		private bool skable;

		// Token: 0x040002B5 RID: 693
		private long offset;

		// Token: 0x040002B6 RID: 694
		private long end;

		// Token: 0x040002B7 RID: 695
		private SyncState oy = new SyncState();

		// Token: 0x040002B8 RID: 696
		private int links;

		// Token: 0x040002B9 RID: 697
		private long[] offsets;

		// Token: 0x040002BA RID: 698
		private long[] dataoffsets;

		// Token: 0x040002BB RID: 699
		private int[] serialnos;

		// Token: 0x040002BC RID: 700
		private long[] pcmlengths;

		// Token: 0x040002BD RID: 701
		private Info[] vi;

		// Token: 0x040002BE RID: 702
		private Comment[] vc;

		// Token: 0x040002BF RID: 703
		private long pcm_offset;

		// Token: 0x040002C0 RID: 704
		private bool decode_ready;

		// Token: 0x040002C1 RID: 705
		private int current_serialno;

		// Token: 0x040002C2 RID: 706
		private int current_link;

		// Token: 0x040002C3 RID: 707
		private float bittrack;

		// Token: 0x040002C4 RID: 708
		private float samptrack;

		// Token: 0x040002C5 RID: 709
		private StreamState os;

		// Token: 0x040002C6 RID: 710
		private DspState vd;

		// Token: 0x040002C7 RID: 711
		private Block vb;
	}
}
