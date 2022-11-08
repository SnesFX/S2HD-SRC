using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000062 RID: 98
	public class Block
	{
		// Token: 0x06000357 RID: 855 RVA: 0x0000CAE6 File Offset: 0x0000ACE6
		public Block(DspState vd)
		{
			this.vd = vd;
			if (vd.analysisp != 0)
			{
				this.opb.writeinit();
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000CB1F File Offset: 0x0000AD1F
		public void init(DspState vd)
		{
			this.vd = vd;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000CB28 File Offset: 0x0000AD28
		public int clear()
		{
			if (this.vd != null && this.vd.analysisp != 0)
			{
				this.opb.writeclear();
			}
			return 0;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000CB4C File Offset: 0x0000AD4C
		public int synthesis(Packet op)
		{
			Info vi = this.vd.vi;
			this.opb.readinit(op.packet_base, op.packet, op.bytes);
			if (this.opb.read(1) != 0)
			{
				return -1;
			}
			int num = this.opb.read(this.vd.modebits);
			if (num == -1)
			{
				return -1;
			}
			this.mode = num;
			this.W = vi.mode_param[this.mode].blockflag;
			if (this.W != 0)
			{
				this.lW = this.opb.read(1);
				this.nW = this.opb.read(1);
				if (this.nW == -1)
				{
					return -1;
				}
			}
			else
			{
				this.lW = 0;
				this.nW = 0;
			}
			this.granulepos = op.granulepos;
			this.sequence = op.packetno - 3L;
			this.eofflag = op.e_o_s;
			this.pcmend = vi.blocksizes[this.W];
			if (this.pcm.Length < vi.channels)
			{
				this.pcm = new float[vi.channels][];
			}
			for (int i = 0; i < vi.channels; i++)
			{
				if (this.pcm[i] == null || this.pcm[i].Length < this.pcmend)
				{
					this.pcm[i] = new float[this.pcmend];
				}
				else
				{
					for (int j = 0; j < this.pcmend; j++)
					{
						this.pcm[i][j] = 0f;
					}
				}
			}
			int num2 = vi.map_type[vi.mode_param[this.mode].mapping];
			return FuncMapping.mapping_P[num2].inverse(this, this.vd.mode[this.mode]);
		}

		// Token: 0x0400018C RID: 396
		internal float[][] pcm = new float[0][];

		// Token: 0x0400018D RID: 397
		internal csBuffer opb = new csBuffer();

		// Token: 0x0400018E RID: 398
		internal int lW;

		// Token: 0x0400018F RID: 399
		internal int W;

		// Token: 0x04000190 RID: 400
		internal int nW;

		// Token: 0x04000191 RID: 401
		internal int pcmend;

		// Token: 0x04000192 RID: 402
		internal int mode;

		// Token: 0x04000193 RID: 403
		internal int eofflag;

		// Token: 0x04000194 RID: 404
		internal long granulepos;

		// Token: 0x04000195 RID: 405
		internal long sequence;

		// Token: 0x04000196 RID: 406
		internal DspState vd;

		// Token: 0x04000197 RID: 407
		internal int glue_bits;

		// Token: 0x04000198 RID: 408
		internal int time_bits;

		// Token: 0x04000199 RID: 409
		internal int floor_bits;

		// Token: 0x0400019A RID: 410
		internal int res_bits;
	}
}
