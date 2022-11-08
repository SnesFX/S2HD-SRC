using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000088 RID: 136
	internal class StaticCodeBook
	{
		// Token: 0x06000436 RID: 1078 RVA: 0x00002248 File Offset: 0x00000448
		internal StaticCodeBook()
		{
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00014CC0 File Offset: 0x00012EC0
		internal StaticCodeBook(int dim, int entries, int[] lengthlist, int maptype, int q_min, int q_delta, int q_quant, int q_sequencep, int[] quantlist, object nearest_tree, object thresh_tree) : this()
		{
			this.dim = dim;
			this.entries = entries;
			this.lengthlist = lengthlist;
			this.maptype = maptype;
			this.q_min = q_min;
			this.q_delta = q_delta;
			this.q_quant = q_quant;
			this.q_sequencep = q_sequencep;
			this.quantlist = quantlist;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00014D18 File Offset: 0x00012F18
		internal int pack(csBuffer opb)
		{
			bool flag = false;
			opb.write(5653314, 24);
			opb.write(this.dim, 16);
			opb.write(this.entries, 24);
			int i = 1;
			while (i < this.entries && this.lengthlist[i] >= this.lengthlist[i - 1])
			{
				i++;
			}
			if (i == this.entries)
			{
				flag = true;
			}
			if (flag)
			{
				int num = 0;
				opb.write(1, 1);
				opb.write(this.lengthlist[0] - 1, 5);
				for (i = 1; i < this.entries; i++)
				{
					int num2 = this.lengthlist[i];
					int num3 = this.lengthlist[i - 1];
					if (num2 > num3)
					{
						for (int j = num3; j < num2; j++)
						{
							opb.write(i - num, StaticCodeBook.ilog(this.entries - num));
							num = i;
						}
					}
				}
				opb.write(i - num, StaticCodeBook.ilog(this.entries - num));
			}
			else
			{
				opb.write(0, 1);
				i = 0;
				while (i < this.entries && this.lengthlist[i] != 0)
				{
					i++;
				}
				if (i == this.entries)
				{
					opb.write(0, 1);
					for (i = 0; i < this.entries; i++)
					{
						opb.write(this.lengthlist[i] - 1, 5);
					}
				}
				else
				{
					opb.write(1, 1);
					for (i = 0; i < this.entries; i++)
					{
						if (this.lengthlist[i] == 0)
						{
							opb.write(0, 1);
						}
						else
						{
							opb.write(1, 1);
							opb.write(this.lengthlist[i] - 1, 5);
						}
					}
				}
			}
			opb.write(this.maptype, 4);
			int num4 = this.maptype;
			if (num4 != 0)
			{
				if (num4 - 1 > 1)
				{
					return -1;
				}
				if (this.quantlist == null)
				{
					return -1;
				}
				opb.write(this.q_min, 32);
				opb.write(this.q_delta, 32);
				opb.write(this.q_quant - 1, 4);
				opb.write(this.q_sequencep, 1);
				int num5 = 0;
				num4 = this.maptype;
				if (num4 != 1)
				{
					if (num4 == 2)
					{
						num5 = this.entries * this.dim;
					}
				}
				else
				{
					num5 = this.maptype1_quantvals();
				}
				for (i = 0; i < num5; i++)
				{
					opb.write(Math.Abs(this.quantlist[i]), this.q_quant);
				}
			}
			return 0;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00014F74 File Offset: 0x00013174
		internal int unpack(csBuffer opb)
		{
			if (opb.read(24) != 5653314)
			{
				this.clear();
				return -1;
			}
			this.dim = opb.read(16);
			this.entries = opb.read(24);
			if (this.entries == -1)
			{
				this.clear();
				return -1;
			}
			int num = opb.read(1);
			if (num != 0)
			{
				if (num != 1)
				{
					return -1;
				}
				int num2 = opb.read(5) + 1;
				this.lengthlist = new int[this.entries];
				int i = 0;
				while (i < this.entries)
				{
					int num3 = opb.read(StaticCodeBook.ilog(this.entries - i));
					if (num3 == -1)
					{
						this.clear();
						return -1;
					}
					int j = 0;
					while (j < num3)
					{
						this.lengthlist[i] = num2;
						j++;
						i++;
					}
					num2++;
				}
			}
			else
			{
				this.lengthlist = new int[this.entries];
				if (opb.read(1) != 0)
				{
					for (int i = 0; i < this.entries; i++)
					{
						if (opb.read(1) != 0)
						{
							int num4 = opb.read(5);
							if (num4 == -1)
							{
								this.clear();
								return -1;
							}
							this.lengthlist[i] = num4 + 1;
						}
						else
						{
							this.lengthlist[i] = 0;
						}
					}
				}
				else
				{
					for (int i = 0; i < this.entries; i++)
					{
						int num5 = opb.read(5);
						if (num5 == -1)
						{
							this.clear();
							return -1;
						}
						this.lengthlist[i] = num5 + 1;
					}
				}
			}
			num = (this.maptype = opb.read(4));
			if (num != 0)
			{
				if (num - 1 > 1)
				{
					this.clear();
					return -1;
				}
				this.q_min = opb.read(32);
				this.q_delta = opb.read(32);
				this.q_quant = opb.read(4) + 1;
				this.q_sequencep = opb.read(1);
				int num6 = 0;
				num = this.maptype;
				if (num != 1)
				{
					if (num == 2)
					{
						num6 = this.entries * this.dim;
					}
				}
				else
				{
					num6 = this.maptype1_quantvals();
				}
				this.quantlist = new int[num6];
				for (int i = 0; i < num6; i++)
				{
					this.quantlist[i] = opb.read(this.q_quant);
				}
				if (this.quantlist[num6 - 1] == -1)
				{
					this.clear();
					return -1;
				}
			}
			return 0;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000151B8 File Offset: 0x000133B8
		internal int maptype1_quantvals()
		{
			int num = (int)Math.Floor(Math.Pow((double)this.entries, 1.0 / (double)this.dim));
			for (;;)
			{
				int num2 = 1;
				int num3 = 1;
				for (int i = 0; i < this.dim; i++)
				{
					num2 *= num;
					num3 *= num + 1;
				}
				if (num2 <= this.entries && num3 > this.entries)
				{
					break;
				}
				if (num2 > this.entries)
				{
					num--;
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00006325 File Offset: 0x00004525
		internal void clear()
		{
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00015230 File Offset: 0x00013430
		internal float[] unquantize()
		{
			if (this.maptype == 1 || this.maptype == 2)
			{
				float num = StaticCodeBook.float32_unpack(this.q_min);
				float num2 = StaticCodeBook.float32_unpack(this.q_delta);
				float[] array = new float[this.entries * this.dim];
				int num3 = this.maptype;
				if (num3 != 1)
				{
					if (num3 == 2)
					{
						for (int i = 0; i < this.entries; i++)
						{
							float num4 = 0f;
							for (int j = 0; j < this.dim; j++)
							{
								float num5 = (float)this.quantlist[i * this.dim + j];
								num5 = Math.Abs(num5) * num2 + num + num4;
								if (this.q_sequencep != 0)
								{
									num4 = num5;
								}
								array[i * this.dim + j] = num5;
							}
						}
					}
				}
				else
				{
					int num6 = this.maptype1_quantvals();
					for (int k = 0; k < this.entries; k++)
					{
						float num7 = 0f;
						int num8 = 1;
						for (int l = 0; l < this.dim; l++)
						{
							int num9 = k / num8 % num6;
							float num10 = (float)this.quantlist[num9];
							num10 = Math.Abs(num10) * num2 + num + num7;
							if (this.q_sequencep != 0)
							{
								num7 = num10;
							}
							array[k * this.dim + l] = num10;
							num8 *= num6;
						}
					}
				}
				return array;
			}
			return null;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00015394 File Offset: 0x00013594
		internal static int ilog(int v)
		{
			int num = 0;
			while (v != 0)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000153B4 File Offset: 0x000135B4
		internal static long float32_pack(float val)
		{
			uint num = 0U;
			if (val < 0f)
			{
				num = 2147483648U;
				val = -val;
			}
			int num2 = (int)Math.Floor(Math.Log((double)val) / Math.Log(2.0));
			int num3 = (int)Math.Round(Math.Pow((double)val, (double)(StaticCodeBook.VQ_FMAN - 1 - num2)));
			num2 = num2 + StaticCodeBook.VQ_FEXP_BIAS << StaticCodeBook.VQ_FMAN;
			return (long)(num | (uint)num2 | (uint)num3);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00015424 File Offset: 0x00013624
		internal static float float32_unpack(int val)
		{
			float num = (float)(val & 2097151);
			float num2 = (uint)(val & 2145386496) >> StaticCodeBook.VQ_FMAN;
			if (((long)val & (long)((ulong)-2147483648)) != 0L)
			{
				num = -num;
			}
			return StaticCodeBook.ldexp(num, (int)num2 - (StaticCodeBook.VQ_FMAN - 1) - StaticCodeBook.VQ_FEXP_BIAS);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00015471 File Offset: 0x00013671
		internal static float ldexp(float foo, int e)
		{
			return (float)((double)foo * Math.Pow(2.0, (double)e));
		}

		// Token: 0x04000294 RID: 660
		internal int dim;

		// Token: 0x04000295 RID: 661
		internal int entries;

		// Token: 0x04000296 RID: 662
		internal int[] lengthlist;

		// Token: 0x04000297 RID: 663
		internal int maptype;

		// Token: 0x04000298 RID: 664
		internal int q_min;

		// Token: 0x04000299 RID: 665
		internal int q_delta;

		// Token: 0x0400029A RID: 666
		internal int q_quant;

		// Token: 0x0400029B RID: 667
		internal int q_sequencep;

		// Token: 0x0400029C RID: 668
		internal int[] quantlist;

		// Token: 0x0400029D RID: 669
		internal EncodeAuxNearestMatch nearest_tree;

		// Token: 0x0400029E RID: 670
		internal EncodeAuxThreshMatch thresh_tree;

		// Token: 0x0400029F RID: 671
		private static int VQ_FMAN = 21;

		// Token: 0x040002A0 RID: 672
		private static int VQ_FEXP_BIAS = 768;
	}
}
