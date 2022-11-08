using System;
using csogg;

namespace csvorbis
{
	// Token: 0x0200006B RID: 107
	internal class Floor0 : FuncFloor
	{
		// Token: 0x0600039F RID: 927 RVA: 0x00010994 File Offset: 0x0000EB94
		public override void pack(object i, csBuffer opb)
		{
			InfoFloor0 infoFloor = (InfoFloor0)i;
			opb.write(infoFloor.order, 8);
			opb.write(infoFloor.rate, 16);
			opb.write(infoFloor.barkmap, 16);
			opb.write(infoFloor.ampbits, 6);
			opb.write(infoFloor.ampdB, 8);
			opb.write(infoFloor.numbooks - 1, 4);
			for (int j = 0; j < infoFloor.numbooks; j++)
			{
				opb.write(infoFloor.books[j], 8);
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00010A1C File Offset: 0x0000EC1C
		public override object unpack(Info vi, csBuffer opb)
		{
			InfoFloor0 infoFloor = new InfoFloor0();
			infoFloor.order = opb.read(8);
			infoFloor.rate = opb.read(16);
			infoFloor.barkmap = opb.read(16);
			infoFloor.ampbits = opb.read(6);
			infoFloor.ampdB = opb.read(8);
			infoFloor.numbooks = opb.read(4) + 1;
			if (infoFloor.order < 1 || infoFloor.rate < 1 || infoFloor.barkmap < 1 || infoFloor.numbooks < 1)
			{
				return null;
			}
			for (int i = 0; i < infoFloor.numbooks; i++)
			{
				infoFloor.books[i] = opb.read(8);
				if (infoFloor.books[i] < 0 || infoFloor.books[i] >= vi.books)
				{
					return null;
				}
			}
			return infoFloor;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00010AE8 File Offset: 0x0000ECE8
		public override object look(DspState vd, InfoMode mi, object i)
		{
			Info vi = vd.vi;
			InfoFloor0 infoFloor = (InfoFloor0)i;
			LookFloor0 lookFloor = new LookFloor0();
			lookFloor.m = infoFloor.order;
			lookFloor.n = vi.blocksizes[mi.blockflag] / 2;
			lookFloor.ln = infoFloor.barkmap;
			lookFloor.vi = infoFloor;
			lookFloor.lpclook.init(lookFloor.ln, lookFloor.m);
			float num = (float)lookFloor.ln / (float)Floor0.toBARK((float)((double)infoFloor.rate / 2.0));
			lookFloor.linearmap = new int[lookFloor.n];
			for (int j = 0; j < lookFloor.n; j++)
			{
				int num2 = (int)Math.Floor(Floor0.toBARK((float)((double)infoFloor.rate / 2.0 / (double)lookFloor.n * (double)j)) * (double)num);
				if (num2 >= lookFloor.ln)
				{
					num2 = lookFloor.ln;
				}
				lookFloor.linearmap[j] = num2;
			}
			return lookFloor;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00010BE8 File Offset: 0x0000EDE8
		private static double toBARK(float f)
		{
			double num = 13.1 * Math.Atan(0.00074 * (double)f);
			double num2 = 2.24 * Math.Atan((double)(f * f) * 1.85E-08);
			double num3 = 0.0001 * (double)f;
			return num + num2 + num3;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00010C40 File Offset: 0x0000EE40
		private object state(object i)
		{
			EchstateFloor0 echstateFloor = new EchstateFloor0();
			InfoFloor0 infoFloor = (InfoFloor0)i;
			echstateFloor.codewords = new int[infoFloor.order];
			echstateFloor.curve = new float[infoFloor.barkmap];
			echstateFloor.frameno = -1L;
			return echstateFloor;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_info(object i)
		{
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_look(object i)
		{
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_state(object vs)
		{
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000225B File Offset: 0x0000045B
		public override int forward(Block vb, object i, float[] fin, float[] fout, object vs)
		{
			return 0;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00010C84 File Offset: 0x0000EE84
		private int inverse(Block vb, object i, float[] fout)
		{
			LookFloor0 lookFloor = (LookFloor0)i;
			InfoFloor0 vi = lookFloor.vi;
			int num = vb.opb.read(vi.ampbits);
			if (num > 0)
			{
				int num2 = (1 << vi.ampbits) - 1;
				float amp = (float)num / (float)num2 * (float)vi.ampdB;
				int num3 = vb.opb.read(Floor0.ilog(vi.numbooks));
				if (num3 != -1 && num3 < vi.numbooks)
				{
					lock (this)
					{
						if (this.lsp == null || this.lsp.Length < lookFloor.m)
						{
							this.lsp = new float[lookFloor.m];
						}
						else
						{
							for (int j = 0; j < lookFloor.m; j++)
							{
								this.lsp[j] = 0f;
							}
						}
						CodeBook codeBook = vb.vd.fullbooks[vi.books[num3]];
						float num4 = 0f;
						for (int k = 0; k < lookFloor.m; k++)
						{
							fout[k] = 0f;
						}
						for (int l = 0; l < lookFloor.m; l += codeBook.dim)
						{
							if (codeBook.decodevs(this.lsp, l, vb.opb, 1, -1) == -1)
							{
								for (int m = 0; m < lookFloor.n; m++)
								{
									fout[m] = 0f;
								}
								return 0;
							}
						}
						int n = 0;
						while (n < lookFloor.m)
						{
							int num5 = 0;
							while (num5 < codeBook.dim)
							{
								this.lsp[n] += num4;
								num5++;
								n++;
							}
							num4 = this.lsp[n - 1];
						}
						Lsp.lsp_to_curve(fout, lookFloor.linearmap, lookFloor.n, lookFloor.ln, this.lsp, lookFloor.m, amp, (float)vi.ampdB);
						return 1;
					}
					return 0;
				}
			}
			return 0;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00010EA0 File Offset: 0x0000F0A0
		public override object inverse1(Block vb, object i, object memo)
		{
			LookFloor0 lookFloor = (LookFloor0)i;
			InfoFloor0 vi = lookFloor.vi;
			float[] array = null;
			if (memo is float[])
			{
				array = (float[])memo;
			}
			int num = vb.opb.read(vi.ampbits);
			if (num > 0)
			{
				int num2 = (1 << vi.ampbits) - 1;
				float num3 = (float)num / (float)num2 * (float)vi.ampdB;
				int num4 = vb.opb.read(Floor0.ilog(vi.numbooks));
				if (num4 != -1 && num4 < vi.numbooks)
				{
					CodeBook codeBook = vb.vd.fullbooks[vi.books[num4]];
					float num5 = 0f;
					if (array == null || array.Length < lookFloor.m + 1)
					{
						array = new float[lookFloor.m + 1];
					}
					else
					{
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = 0f;
						}
					}
					for (int k = 0; k < lookFloor.m; k += codeBook.dim)
					{
						if (codeBook.decodev_set(array, k, vb.opb, codeBook.dim) == -1)
						{
							return null;
						}
					}
					int l = 0;
					while (l < lookFloor.m)
					{
						int m = 0;
						while (m < codeBook.dim)
						{
							array[l] += num5;
							m++;
							l++;
						}
						num5 = array[l - 1];
					}
					array[lookFloor.m] = num3;
					return array;
				}
			}
			return null;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00011010 File Offset: 0x0000F210
		public override int inverse2(Block vb, object i, object memo, float[] fout)
		{
			LookFloor0 lookFloor = (LookFloor0)i;
			InfoFloor0 vi = lookFloor.vi;
			if (memo != null)
			{
				float[] array = (float[])memo;
				float amp = array[lookFloor.m];
				Lsp.lsp_to_curve(fout, lookFloor.linearmap, lookFloor.n, lookFloor.ln, array, lookFloor.m, amp, (float)vi.ampdB);
				return 1;
			}
			for (int j = 0; j < lookFloor.n; j++)
			{
				fout[j] = 0f;
			}
			return 0;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00011088 File Offset: 0x0000F288
		private static float fromdB(float x)
		{
			return (float)Math.Exp((double)x * 0.11512925);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0001109C File Offset: 0x0000F29C
		private static int ilog(int v)
		{
			int num = 0;
			while (v != 0)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000110BC File Offset: 0x0000F2BC
		private static void lsp_to_lpc(float[] lsp, float[] lpc, int m)
		{
			int num = m / 2;
			float[] array = new float[num];
			float[] array2 = new float[num];
			float[] array3 = new float[num + 1];
			float[] array4 = new float[num + 1];
			float[] array5 = new float[num];
			float[] array6 = new float[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (float)(-2.0 * Math.Cos((double)lsp[i * 2]));
				array2[i] = (float)(-2.0 * Math.Cos((double)lsp[i * 2 + 1]));
			}
			int j;
			for (j = 0; j < num; j++)
			{
				array3[j] = 0f;
				array4[j] = 1f;
				array5[j] = 0f;
				array6[j] = 1f;
			}
			array4[j] = 1f;
			array3[j] = 1f;
			for (int i = 1; i < m + 1; i++)
			{
				float num3;
				float num2 = num3 = 0f;
				for (j = 0; j < num; j++)
				{
					float num4 = array[j] * array4[j] + array3[j];
					array3[j] = array4[j];
					array4[j] = num3;
					num3 += num4;
					num4 = array2[j] * array6[j] + array5[j];
					array5[j] = array6[j];
					array6[j] = num2;
					num2 += num4;
				}
				lpc[i - 1] = (num3 + array4[j] + num2 - array3[j]) / 2f;
				array4[j] = num3;
				array3[j] = num2;
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001121C File Offset: 0x0000F41C
		private static void lpc_to_curve(float[] curve, float[] lpc, float amp, LookFloor0 l, string name, int frameno)
		{
			float[] array = new float[Math.Max(l.ln * 2, l.m * 2 + 2)];
			if (amp == 0f)
			{
				for (int i = 0; i < l.n; i++)
				{
					curve[i] = 0f;
				}
				return;
			}
			l.lpclook.lpc_to_curve(array, lpc, amp);
			for (int j = 0; j < l.n; j++)
			{
				curve[j] = array[l.linearmap[j]];
			}
		}

		// Token: 0x040001E0 RID: 480
		private float[] lsp;
	}
}
