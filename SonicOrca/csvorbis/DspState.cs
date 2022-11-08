using System;

namespace csvorbis
{
	// Token: 0x02000068 RID: 104
	public class DspState
	{
		// Token: 0x06000392 RID: 914 RVA: 0x0000FEE4 File Offset: 0x0000E0E4
		public DspState()
		{
			this.transform = new object[2][];
			this.wnd = new float[2][][][][];
			this.wnd[0] = new float[2][][][];
			this.wnd[0][0] = new float[2][][];
			this.wnd[0][1] = new float[2][][];
			this.wnd[0][0][0] = new float[2][];
			this.wnd[0][0][1] = new float[2][];
			this.wnd[0][1][0] = new float[2][];
			this.wnd[0][1][1] = new float[2][];
			this.wnd[1] = new float[2][][][];
			this.wnd[1][0] = new float[2][][];
			this.wnd[1][1] = new float[2][][];
			this.wnd[1][0][0] = new float[2][];
			this.wnd[1][0][1] = new float[2][];
			this.wnd[1][1][0] = new float[2][];
			this.wnd[1][1][1] = new float[2][];
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000FFFC File Offset: 0x0000E1FC
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

		// Token: 0x06000394 RID: 916 RVA: 0x0001001C File Offset: 0x0000E21C
		internal static float[] window(int type, int wnd, int left, int right)
		{
			float[] array = new float[wnd];
			if (type == 0)
			{
				int num = wnd / 4 - left / 2;
				int num2 = wnd - wnd / 4 - right / 2;
				for (int i = 0; i < left; i++)
				{
					float num3 = (float)(((double)i + 0.5) / (double)left * (double)DspState.M_PI / 2.0);
					num3 = (float)Math.Sin((double)num3);
					num3 *= num3;
					num3 *= (float)((double)DspState.M_PI / 2.0);
					num3 = (float)Math.Sin((double)num3);
					array[i + num] = num3;
				}
				for (int j = num + left; j < num2; j++)
				{
					array[j] = 1f;
				}
				for (int k = 0; k < right; k++)
				{
					float num4 = (float)(((double)(right - k) - 0.5) / (double)right * (double)DspState.M_PI / 2.0);
					num4 = (float)Math.Sin((double)num4);
					num4 *= num4;
					num4 *= (float)((double)DspState.M_PI / 2.0);
					num4 = (float)Math.Sin((double)num4);
					array[k + num2] = num4;
				}
				return array;
			}
			return null;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00010144 File Offset: 0x0000E344
		private int init(Info vi, bool encp)
		{
			this.vi = vi;
			this.modebits = DspState.ilog2(vi.modes);
			this.transform[0] = new object[DspState.VI_TRANSFORMB];
			this.transform[1] = new object[DspState.VI_TRANSFORMB];
			this.transform[0][0] = new Mdct();
			this.transform[1][0] = new Mdct();
			((Mdct)this.transform[0][0]).init(vi.blocksizes[0]);
			((Mdct)this.transform[1][0]).init(vi.blocksizes[1]);
			this.wnd[0][0][0] = new float[DspState.VI_WINDOWB][];
			this.wnd[0][0][1] = this.wnd[0][0][0];
			this.wnd[0][1][0] = this.wnd[0][0][0];
			this.wnd[0][1][1] = this.wnd[0][0][0];
			this.wnd[1][0][0] = new float[DspState.VI_WINDOWB][];
			this.wnd[1][0][1] = new float[DspState.VI_WINDOWB][];
			this.wnd[1][1][0] = new float[DspState.VI_WINDOWB][];
			this.wnd[1][1][1] = new float[DspState.VI_WINDOWB][];
			for (int i = 0; i < DspState.VI_WINDOWB; i++)
			{
				this.wnd[0][0][0][i] = DspState.window(i, vi.blocksizes[0], vi.blocksizes[0] / 2, vi.blocksizes[0] / 2);
				this.wnd[1][0][0][i] = DspState.window(i, vi.blocksizes[1], vi.blocksizes[0] / 2, vi.blocksizes[0] / 2);
				this.wnd[1][0][1][i] = DspState.window(i, vi.blocksizes[1], vi.blocksizes[0] / 2, vi.blocksizes[1] / 2);
				this.wnd[1][1][0][i] = DspState.window(i, vi.blocksizes[1], vi.blocksizes[1] / 2, vi.blocksizes[0] / 2);
				this.wnd[1][1][1][i] = DspState.window(i, vi.blocksizes[1], vi.blocksizes[1] / 2, vi.blocksizes[1] / 2);
			}
			this.fullbooks = new CodeBook[vi.books];
			for (int j = 0; j < vi.books; j++)
			{
				this.fullbooks[j] = new CodeBook();
				this.fullbooks[j].init_decode(vi.book_param[j]);
			}
			this.pcm_storage = 8192;
			this.pcm = new float[vi.channels][];
			for (int k = 0; k < vi.channels; k++)
			{
				this.pcm[k] = new float[this.pcm_storage];
			}
			this.lW = 0;
			this.W = 0;
			this.centerW = vi.blocksizes[1] / 2;
			this.pcm_current = this.centerW;
			this.mode = new object[vi.modes];
			for (int l = 0; l < vi.modes; l++)
			{
				int mapping = vi.mode_param[l].mapping;
				int num = vi.map_type[mapping];
				this.mode[l] = FuncMapping.mapping_P[num].look(this, vi.mode_param[l], vi.map_param[mapping]);
			}
			return 0;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000104B4 File Offset: 0x0000E6B4
		public int synthesis_init(Info vi)
		{
			this.init(vi, false);
			this.pcm_returned = this.centerW;
			this.centerW -= vi.blocksizes[this.W] / 4 + vi.blocksizes[this.lW] / 4;
			this.granulepos = -1L;
			this.sequence = -1L;
			return 0;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00010514 File Offset: 0x0000E714
		private DspState(Info vi) : this()
		{
			this.init(vi, false);
			this.pcm_returned = this.centerW;
			this.centerW -= vi.blocksizes[this.W] / 4 + vi.blocksizes[this.lW] / 4;
			this.granulepos = -1L;
			this.sequence = -1L;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00010578 File Offset: 0x0000E778
		public int synthesis_blockin(Block vb)
		{
			if (this.centerW > this.vi.blocksizes[1] / 2 && this.pcm_returned > 8192)
			{
				int num = this.centerW - this.vi.blocksizes[1] / 2;
				num = ((this.pcm_returned < num) ? this.pcm_returned : num);
				this.pcm_current -= num;
				this.centerW -= num;
				this.pcm_returned -= num;
				if (num != 0)
				{
					for (int i = 0; i < this.vi.channels; i++)
					{
						Array.Copy(this.pcm[i], num, this.pcm[i], 0, this.pcm_current);
					}
				}
			}
			this.lW = this.W;
			this.W = vb.W;
			this.nW = -1;
			this.glue_bits += (long)vb.glue_bits;
			this.time_bits += (long)vb.time_bits;
			this.floor_bits += (long)vb.floor_bits;
			this.res_bits += (long)vb.res_bits;
			if (this.sequence + 1L != vb.sequence)
			{
				this.granulepos = -1L;
			}
			this.sequence = vb.sequence;
			int num2 = this.vi.blocksizes[this.W];
			int num3 = this.centerW + this.vi.blocksizes[this.lW] / 4 + num2 / 4;
			int num4 = num3 - num2 / 2;
			int num5 = num4 + num2;
			int num6 = 0;
			int num7 = 0;
			if (num5 > this.pcm_storage)
			{
				this.pcm_storage = num5 + this.vi.blocksizes[1];
				for (int j = 0; j < this.vi.channels; j++)
				{
					float[] array = new float[this.pcm_storage];
					Array.Copy(this.pcm[j], 0, array, 0, this.pcm[j].Length);
					this.pcm[j] = array;
				}
			}
			int w = this.W;
			if (w != 0)
			{
				if (w == 1)
				{
					num6 = this.vi.blocksizes[1] / 4 - this.vi.blocksizes[this.lW] / 4;
					num7 = num6 + this.vi.blocksizes[this.lW] / 2;
				}
			}
			else
			{
				num6 = 0;
				num7 = this.vi.blocksizes[0] / 2;
			}
			for (int k = 0; k < this.vi.channels; k++)
			{
				int num8 = num4;
				int l;
				for (l = num6; l < num7; l++)
				{
					this.pcm[k][num8 + l] += vb.pcm[k][l];
				}
				while (l < num2)
				{
					this.pcm[k][num8 + l] = vb.pcm[k][l];
					l++;
				}
			}
			if (this.granulepos == -1L)
			{
				this.granulepos = vb.granulepos;
			}
			else
			{
				this.granulepos += (long)(num3 - this.centerW);
				if (vb.granulepos != -1L && this.granulepos != vb.granulepos)
				{
					if (this.granulepos > vb.granulepos && vb.eofflag != 0)
					{
						num3 -= (int)(this.granulepos - vb.granulepos);
					}
					this.granulepos = vb.granulepos;
				}
			}
			this.centerW = num3;
			this.pcm_current = num5;
			if (vb.eofflag != 0)
			{
				this.eofflag = 1;
			}
			return 0;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00010900 File Offset: 0x0000EB00
		public int synthesis_pcmout(float[][][] _pcm, int[] index)
		{
			if (this.pcm_returned < this.centerW)
			{
				if (_pcm != null)
				{
					for (int i = 0; i < this.vi.channels; i++)
					{
						index[i] = this.pcm_returned;
					}
					_pcm[0] = this.pcm;
				}
				return this.centerW - this.pcm_returned;
			}
			return 0;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00010955 File Offset: 0x0000EB55
		public int synthesis_read(int bytes)
		{
			if (bytes != 0 && this.pcm_returned + bytes > this.centerW)
			{
				return -1;
			}
			this.pcm_returned += bytes;
			return 0;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00006325 File Offset: 0x00004525
		public void clear()
		{
		}

		// Token: 0x040001B7 RID: 439
		private static float M_PI = 3.1415927f;

		// Token: 0x040001B8 RID: 440
		private static int VI_TRANSFORMB = 1;

		// Token: 0x040001B9 RID: 441
		private static int VI_WINDOWB = 1;

		// Token: 0x040001BA RID: 442
		internal int analysisp;

		// Token: 0x040001BB RID: 443
		internal Info vi;

		// Token: 0x040001BC RID: 444
		internal int modebits;

		// Token: 0x040001BD RID: 445
		private float[][] pcm;

		// Token: 0x040001BE RID: 446
		private int pcm_storage;

		// Token: 0x040001BF RID: 447
		private int pcm_current;

		// Token: 0x040001C0 RID: 448
		private int pcm_returned;

		// Token: 0x040001C1 RID: 449
		private float[] multipliers;

		// Token: 0x040001C2 RID: 450
		private int envelope_storage;

		// Token: 0x040001C3 RID: 451
		private int envelope_current;

		// Token: 0x040001C4 RID: 452
		private int eofflag;

		// Token: 0x040001C5 RID: 453
		private int lW;

		// Token: 0x040001C6 RID: 454
		private int W;

		// Token: 0x040001C7 RID: 455
		private int nW;

		// Token: 0x040001C8 RID: 456
		private int centerW;

		// Token: 0x040001C9 RID: 457
		private long granulepos;

		// Token: 0x040001CA RID: 458
		public long sequence;

		// Token: 0x040001CB RID: 459
		private long glue_bits;

		// Token: 0x040001CC RID: 460
		private long time_bits;

		// Token: 0x040001CD RID: 461
		private long floor_bits;

		// Token: 0x040001CE RID: 462
		private long res_bits;

		// Token: 0x040001CF RID: 463
		internal float[][][][][] wnd;

		// Token: 0x040001D0 RID: 464
		internal object[][] transform;

		// Token: 0x040001D1 RID: 465
		internal CodeBook[] fullbooks;

		// Token: 0x040001D2 RID: 466
		internal object[] mode;

		// Token: 0x040001D3 RID: 467
		private byte[] header;

		// Token: 0x040001D4 RID: 468
		private byte[] header1;

		// Token: 0x040001D5 RID: 469
		private byte[] header2;
	}
}
