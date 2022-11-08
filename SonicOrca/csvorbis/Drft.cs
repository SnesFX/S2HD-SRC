using System;

namespace csvorbis
{
	// Token: 0x02000067 RID: 103
	internal class Drft
	{
		// Token: 0x06000382 RID: 898 RVA: 0x0000DCD1 File Offset: 0x0000BED1
		internal void backward(float[] data)
		{
			if (this.n == 1)
			{
				return;
			}
			Drft.drftb1(this.n, data, this.trigcache, this.trigcache, this.n, this.splitcache);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000DD01 File Offset: 0x0000BF01
		internal void init(int n)
		{
			this.n = n;
			this.trigcache = new float[3 * n];
			this.splitcache = new int[32];
			Drft.fdrffti(n, this.trigcache, this.splitcache);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000DD37 File Offset: 0x0000BF37
		internal void clear()
		{
			if (this.trigcache != null)
			{
				this.trigcache = null;
			}
			if (this.splitcache != null)
			{
				this.splitcache = null;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000DD58 File Offset: 0x0000BF58
		private static void drfti1(int n, float[] wa, int index, int[] ifac)
		{
			int num = 0;
			int i = -1;
			int num2 = n;
			int num3 = 0;
			for (;;)
			{
				i++;
				if (i < 4)
				{
					num = Drft.ntryh[i];
				}
				else
				{
					num += 2;
				}
				for (;;)
				{
					int num4 = num2 / num;
					if (num2 - num * num4 != 0)
					{
						break;
					}
					num3++;
					ifac[num3 + 1] = num;
					num2 = num4;
					if (num == 2 && num3 != 1)
					{
						for (int j = 1; j < num3; j++)
						{
							int num5 = num3 - j + 1;
							ifac[num5 + 1] = ifac[num5];
						}
						ifac[2] = 2;
					}
					if (num2 == 1)
					{
						goto Block_6;
					}
				}
			}
			Block_6:
			ifac[0] = n;
			ifac[1] = num3;
			float num6 = Drft.tpi / (float)n;
			int num7 = 0;
			int num8 = num3 - 1;
			int num9 = 1;
			if (num8 == 0)
			{
				return;
			}
			for (int k = 0; k < num8; k++)
			{
				int num10 = ifac[k + 2];
				int num11 = 0;
				int num12 = num9 * num10;
				int num13 = n / num12;
				int num14 = num10 - 1;
				for (i = 0; i < num14; i++)
				{
					num11 += num9;
					int j = num7;
					float num15 = (float)num11 * num6;
					float num16 = 0f;
					for (int l = 2; l < num13; l += 2)
					{
						num16 += 1f;
						float num17 = num16 * num15;
						wa[index + j++] = (float)Math.Cos((double)num17);
						wa[index + j++] = (float)Math.Sin((double)num17);
					}
					num7 += num13;
				}
				num9 = num12;
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000DEB6 File Offset: 0x0000C0B6
		private static void fdrffti(int n, float[] wsave, int[] ifac)
		{
			if (n == 1)
			{
				return;
			}
			Drft.drfti1(n, wsave, n, ifac);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000DEC8 File Offset: 0x0000C0C8
		private static void dradf2(int ido, int l1, float[] cc, float[] ch, float[] wa1, int index)
		{
			int num = 0;
			int num3;
			int num2 = num3 = l1 * ido;
			int num4 = ido << 1;
			for (int i = 0; i < l1; i++)
			{
				ch[num << 1] = cc[num] + cc[num2];
				ch[(num << 1) + num4 - 1] = cc[num] - cc[num2];
				num += ido;
				num2 += ido;
			}
			if (ido < 2)
			{
				return;
			}
			if (ido != 2)
			{
				num = 0;
				num2 = num3;
				for (int i = 0; i < l1; i++)
				{
					num4 = num2;
					int num5 = (num << 1) + (ido << 1);
					int num6 = num;
					int num7 = num + num;
					for (int j = 2; j < ido; j += 2)
					{
						num4 += 2;
						num5 -= 2;
						num6 += 2;
						num7 += 2;
						float num8 = wa1[index + j - 2] * cc[num4 - 1] + wa1[index + j - 1] * cc[num4];
						float num9 = wa1[index + j - 2] * cc[num4] - wa1[index + j - 1] * cc[num4 - 1];
						ch[num7] = cc[num6] + num9;
						ch[num5] = num9 - cc[num6];
						ch[num7 - 1] = cc[num6 - 1] + num8;
						ch[num5 - 1] = cc[num6 - 1] - num8;
					}
					num += ido;
					num2 += ido;
				}
				if (ido % 2 == 1)
				{
					return;
				}
			}
			num = ido;
			num2 = (num4 = ido - 1) + num3;
			for (int i = 0; i < l1; i++)
			{
				ch[num] = -cc[num2];
				ch[num - 1] = cc[num4];
				num += ido << 1;
				num2 += ido;
				num4 += ido;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000E050 File Offset: 0x0000C250
		private static void dradf4(int ido, int l1, float[] cc, float[] ch, float[] wa1, int index1, float[] wa2, int index2, float[] wa3, int index3)
		{
			int num = l1 * ido;
			int num2 = num;
			int num3 = num2 << 1;
			int num4 = num2 + (num2 << 1);
			int num5 = 0;
			int num8;
			for (int i = 0; i < l1; i++)
			{
				float num6 = cc[num2] + cc[num4];
				float num7 = cc[num5] + cc[num3];
				ch[num8 = num5 << 2] = num6 + num7;
				ch[(ido << 2) + num8 - 1] = num7 - num6;
				ch[(num8 += ido << 1) - 1] = cc[num5] - cc[num3];
				ch[num8] = cc[num4] - cc[num2];
				num2 += ido;
				num4 += ido;
				num5 += ido;
				num3 += ido;
			}
			if (ido < 2)
			{
				return;
			}
			int num9;
			if (ido != 2)
			{
				num2 = 0;
				for (int i = 0; i < l1; i++)
				{
					num4 = num2;
					num3 = num2 << 2;
					num8 = (num9 = ido << 1) + num3;
					for (int j = 2; j < ido; j += 2)
					{
						num4 = (num5 = num4 + 2);
						num3 += 2;
						num8 -= 2;
						num5 += num;
						float num10 = wa1[index1 + j - 2] * cc[num5 - 1] + wa1[index1 + j - 1] * cc[num5];
						float num11 = wa1[index1 + j - 2] * cc[num5] - wa1[index1 + j - 1] * cc[num5 - 1];
						num5 += num;
						float num12 = wa2[index2 + j - 2] * cc[num5 - 1] + wa2[index2 + j - 1] * cc[num5];
						float num13 = wa2[index2 + j - 2] * cc[num5] - wa2[index2 + j - 1] * cc[num5 - 1];
						num5 += num;
						float num14 = wa3[index3 + j - 2] * cc[num5 - 1] + wa3[index3 + j - 1] * cc[num5];
						float num15 = wa3[index3 + j - 2] * cc[num5] - wa3[index3 + j - 1] * cc[num5 - 1];
						float num6 = num10 + num14;
						float num16 = num14 - num10;
						float num17 = num11 + num15;
						float num18 = num11 - num15;
						float num19 = cc[num4] + num13;
						float num20 = cc[num4] - num13;
						float num7 = cc[num4 - 1] + num12;
						float num21 = cc[num4 - 1] - num12;
						ch[num3 - 1] = num6 + num7;
						ch[num3] = num17 + num19;
						ch[num8 - 1] = num21 - num18;
						ch[num8] = num16 - num20;
						ch[num3 + num9 - 1] = num18 + num21;
						ch[num3 + num9] = num16 + num20;
						ch[num8 + num9 - 1] = num7 - num6;
						ch[num8 + num9] = num17 - num19;
					}
					num2 += ido;
				}
				if ((ido & 1) != 0)
				{
					return;
				}
			}
			num4 = (num2 = num + ido - 1) + (num << 1);
			num5 = ido << 2;
			num3 = ido;
			num8 = ido << 1;
			num9 = ido;
			for (int i = 0; i < l1; i++)
			{
				float num17 = -Drft.hsqt2 * (cc[num2] + cc[num4]);
				float num6 = Drft.hsqt2 * (cc[num2] - cc[num4]);
				ch[num3 - 1] = num6 + cc[num9 - 1];
				ch[num3 + num8 - 1] = cc[num9 - 1] - num6;
				ch[num3] = num17 - cc[num2 + num];
				ch[num3 + num8] = num17 + cc[num2 + num];
				num2 += ido;
				num4 += ido;
				num3 += num5;
				num9 += ido;
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000E35C File Offset: 0x0000C55C
		private static void dradfg(int ido, int ip, int l1, int idl1, float[] cc, float[] c1, float[] c2, float[] ch, float[] ch2, float[] wa, int index)
		{
			float num = Drft.tpi / (float)ip;
			float num2 = (float)Math.Cos((double)num);
			float num3 = (float)Math.Sin((double)num);
			int num4 = ip + 1 >> 1;
			int num5 = ido - 1 >> 1;
			int num6 = l1 * ido;
			int num7 = ip * ido;
			int num8;
			int num9;
			int num12;
			int num13;
			int num14;
			if (ido != 1)
			{
				for (int i = 0; i < idl1; i++)
				{
					ch2[i] = c2[i];
				}
				num8 = 0;
				for (int j = 1; j < ip; j++)
				{
					num8 += num6;
					num9 = num8;
					for (int k = 0; k < l1; k++)
					{
						ch[num9] = c1[num9];
						num9 += ido;
					}
				}
				int num10 = -ido;
				num8 = 0;
				if (num5 > l1)
				{
					for (int j = 1; j < ip; j++)
					{
						num8 += num6;
						num10 += ido;
						num9 = -ido + num8;
						for (int k = 0; k < l1; k++)
						{
							int num11 = num10 - 1;
							num9 += ido;
							num12 = num9;
							for (int m = 2; m < ido; m += 2)
							{
								num11 += 2;
								num12 += 2;
								ch[num12 - 1] = wa[index + num11 - 1] * c1[num12 - 1] + wa[index + num11] * c1[num12];
								ch[num12] = wa[index + num11 - 1] * c1[num12] - wa[index + num11] * c1[num12 - 1];
							}
						}
					}
				}
				else
				{
					for (int j = 1; j < ip; j++)
					{
						num10 += ido;
						int num11 = num10 - 1;
						num8 += num6;
						num9 = num8;
						for (int m = 2; m < ido; m += 2)
						{
							num11 += 2;
							num9 += 2;
							num12 = num9;
							for (int k = 0; k < l1; k++)
							{
								ch[num12 - 1] = wa[index + num11 - 1] * c1[num12 - 1] + wa[index + num11] * c1[num12];
								ch[num12] = wa[index + num11 - 1] * c1[num12] - wa[index + num11] * c1[num12 - 1];
								num12 += ido;
							}
						}
					}
				}
				num8 = 0;
				num9 = ip * num6;
				if (num5 < l1)
				{
					for (int j = 1; j < num4; j++)
					{
						num8 += num6;
						num9 -= num6;
						num12 = num8;
						num13 = num9;
						for (int m = 2; m < ido; m += 2)
						{
							num12 += 2;
							num13 += 2;
							num14 = num12 - ido;
							int num15 = num13 - ido;
							for (int k = 0; k < l1; k++)
							{
								num14 += ido;
								num15 += ido;
								c1[num14 - 1] = ch[num14 - 1] + ch[num15 - 1];
								c1[num15 - 1] = ch[num14] - ch[num15];
								c1[num14] = ch[num14] + ch[num15];
								c1[num15] = ch[num15 - 1] - ch[num14 - 1];
							}
						}
					}
				}
				else
				{
					for (int j = 1; j < num4; j++)
					{
						num8 += num6;
						num9 -= num6;
						num12 = num8;
						num13 = num9;
						for (int k = 0; k < l1; k++)
						{
							num14 = num12;
							int num15 = num13;
							for (int m = 2; m < ido; m += 2)
							{
								num14 += 2;
								num15 += 2;
								c1[num14 - 1] = ch[num14 - 1] + ch[num15 - 1];
								c1[num15 - 1] = ch[num14] - ch[num15];
								c1[num14] = ch[num14] + ch[num15];
								c1[num15] = ch[num15 - 1] - ch[num14 - 1];
							}
							num12 += ido;
							num13 += ido;
						}
					}
				}
			}
			for (int i = 0; i < idl1; i++)
			{
				c2[i] = ch2[i];
			}
			num8 = 0;
			num9 = ip * idl1;
			for (int j = 1; j < num4; j++)
			{
				num8 += num6;
				num9 -= num6;
				num12 = num8 - ido;
				num13 = num9 - ido;
				for (int k = 0; k < l1; k++)
				{
					num12 += ido;
					num13 += ido;
					c1[num12] = ch[num12] + ch[num13];
					c1[num13] = ch[num13] - ch[num12];
				}
			}
			float num16 = 1f;
			float num17 = 0f;
			num8 = 0;
			num9 = ip * idl1;
			num12 = (ip - 1) * idl1;
			for (int n = 1; n < num4; n++)
			{
				num8 += idl1;
				num9 -= idl1;
				float num18 = num2 * num16 - num3 * num17;
				num17 = num2 * num17 + num3 * num16;
				num16 = num18;
				num13 = num8;
				num14 = num9;
				int num15 = num12;
				int num19 = idl1;
				for (int i = 0; i < idl1; i++)
				{
					ch2[num13++] = c2[i] + num16 * c2[num19++];
					ch2[num14++] = num17 * c2[num15++];
				}
				float num20 = num16;
				float num21 = num17;
				float num22 = num16;
				float num23 = num17;
				num13 = idl1;
				num14 = (ip - 1) * idl1;
				for (int j = 2; j < num4; j++)
				{
					num13 += idl1;
					num14 -= idl1;
					float num24 = num20 * num22 - num21 * num23;
					num23 = num20 * num23 + num21 * num22;
					num22 = num24;
					num15 = num8;
					num19 = num9;
					int num25 = num13;
					int num26 = num14;
					for (int i = 0; i < idl1; i++)
					{
						ch2[num15] += num22 * c2[num25++];
						num15++;
						ch2[num19] += num23 * c2[num26++];
						num19++;
					}
				}
			}
			num8 = 0;
			for (int j = 1; j < num4; j++)
			{
				num8 += idl1;
				num9 = num8;
				for (int i = 0; i < idl1; i++)
				{
					ch2[i] += c2[num9++];
				}
			}
			if (ido >= l1)
			{
				num8 = 0;
				num9 = 0;
				for (int k = 0; k < l1; k++)
				{
					num12 = num8;
					num13 = num9;
					for (int m = 0; m < ido; m++)
					{
						cc[num13++] = ch[num12++];
					}
					num8 += ido;
					num9 += num7;
				}
			}
			else
			{
				for (int m = 0; m < ido; m++)
				{
					num8 = m;
					num9 = m;
					for (int k = 0; k < l1; k++)
					{
						cc[num9] = ch[num8];
						num8 += ido;
						num9 += num7;
					}
				}
			}
			num8 = 0;
			num9 = ido << 1;
			num12 = 0;
			num13 = ip * num6;
			for (int j = 1; j < num4; j++)
			{
				num8 += num9;
				num12 += num6;
				num13 -= num6;
				num14 = num8;
				int num15 = num12;
				int num19 = num13;
				for (int k = 0; k < l1; k++)
				{
					cc[num14 - 1] = ch[num15];
					cc[num14] = ch[num19];
					num14 += num7;
					num15 += ido;
					num19 += ido;
				}
			}
			if (ido == 1)
			{
				return;
			}
			if (num5 >= l1)
			{
				num8 = -ido;
				num12 = 0;
				num13 = 0;
				num14 = ip * num6;
				for (int j = 1; j < num4; j++)
				{
					num8 += num9;
					num12 += num9;
					num13 += num6;
					num14 -= num6;
					int num15 = num8;
					int num19 = num12;
					int num25 = num13;
					int num26 = num14;
					for (int k = 0; k < l1; k++)
					{
						for (int m = 2; m < ido; m += 2)
						{
							int num27 = ido - m;
							cc[m + num19 - 1] = ch[m + num25 - 1] + ch[m + num26 - 1];
							cc[num27 + num15 - 1] = ch[m + num25 - 1] - ch[m + num26 - 1];
							cc[m + num19] = ch[m + num25] + ch[m + num26];
							cc[num27 + num15] = ch[m + num26] - ch[m + num25];
						}
						num15 += num7;
						num19 += num7;
						num25 += ido;
						num26 += ido;
					}
				}
				return;
			}
			num8 = -ido;
			num12 = 0;
			num13 = 0;
			num14 = ip * num6;
			for (int j = 1; j < num4; j++)
			{
				num8 += num9;
				num12 += num9;
				num13 += num6;
				num14 -= num6;
				for (int m = 2; m < ido; m += 2)
				{
					int num15 = ido + num8 - m;
					int num19 = m + num12;
					int num25 = m + num13;
					int num26 = m + num14;
					for (int k = 0; k < l1; k++)
					{
						cc[num19 - 1] = ch[num25 - 1] + ch[num26 - 1];
						cc[num15 - 1] = ch[num25 - 1] - ch[num26 - 1];
						cc[num19] = ch[num25] + ch[num26];
						cc[num15] = ch[num26] - ch[num25];
						num15 += num7;
						num19 += num7;
						num25 += ido;
						num26 += ido;
					}
				}
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000EC04 File Offset: 0x0000CE04
		private static void drftf1(int n, float[] c, float[] ch, float[] wa, int[] ifac)
		{
			int num = ifac[1];
			int num2 = 1;
			int num3 = n;
			int num4 = n;
			for (int i = 0; i < num; i++)
			{
				int num5 = num - i;
				int num6 = ifac[num5 + 1];
				int num7 = num3 / num6;
				int num8 = n / num3;
				int idl = num8 * num7;
				num4 -= (num6 - 1) * num8;
				num2 = 1 - num2;
				if (num6 == 4)
				{
					int num9 = num4 + num8;
					int num10 = num9 + num8;
					if (num2 != 0)
					{
						Drft.dradf4(num8, num7, ch, c, wa, num4 - 1, wa, num9 - 1, wa, num10 - 1);
					}
					else
					{
						Drft.dradf4(num8, num7, c, ch, wa, num4 - 1, wa, num9 - 1, wa, num10 - 1);
					}
				}
				else if (num6 == 2)
				{
					if (num2 == 0)
					{
						Drft.dradf2(num8, num7, c, ch, wa, num4 - 1);
					}
					else
					{
						Drft.dradf2(num8, num7, ch, c, wa, num4 - 1);
					}
				}
				else
				{
					if (num8 == 1)
					{
						num2 = 1 - num2;
					}
					if (num2 != 0)
					{
						Drft.dradfg(num8, num6, num7, idl, ch, ch, ch, c, c, wa, num4 - 1);
						num2 = 0;
						break;
					}
					Drft.dradfg(num8, num6, num7, idl, c, c, c, ch, ch, wa, num4 - 1);
					num2 = 1;
				}
				num3 = num7;
			}
			if (num2 == 1)
			{
				return;
			}
			for (int j = 0; j < n; j++)
			{
				c[j] = ch[j];
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000ED40 File Offset: 0x0000CF40
		private static void dradb2(int ido, int l1, float[] cc, float[] ch, float[] wa1, int index)
		{
			int num = l1 * ido;
			int num2 = 0;
			int num3 = 0;
			int num4 = (ido << 1) - 1;
			for (int i = 0; i < l1; i++)
			{
				ch[num2] = cc[num3] + cc[num4 + num3];
				ch[num2 + num] = cc[num3] - cc[num4 + num3];
				num3 = (num2 += ido) << 1;
			}
			if (ido < 2)
			{
				return;
			}
			if (ido != 2)
			{
				num2 = 0;
				num3 = 0;
				for (int i = 0; i < l1; i++)
				{
					num4 = num2;
					int num6;
					int num5 = (num6 = num3) + (ido << 1);
					int num7 = num + num2;
					for (int j = 2; j < ido; j += 2)
					{
						num4 += 2;
						num6 += 2;
						num5 -= 2;
						num7 += 2;
						ch[num4 - 1] = cc[num6 - 1] + cc[num5 - 1];
						float num8 = cc[num6 - 1] - cc[num5 - 1];
						ch[num4] = cc[num6] - cc[num5];
						float num9 = cc[num6] + cc[num5];
						ch[num7 - 1] = wa1[index + j - 2] * num8 - wa1[index + j - 1] * num9;
						ch[num7] = wa1[index + j - 2] * num9 + wa1[index + j - 1] * num8;
					}
					num3 = (num2 += ido) << 1;
				}
				if (ido % 2 == 1)
				{
					return;
				}
			}
			num2 = ido - 1;
			num3 = ido - 1;
			for (int i = 0; i < l1; i++)
			{
				ch[num2] = cc[num3] + cc[num3];
				ch[num2 + num] = -(cc[num3 + 1] + cc[num3 + 1]);
				num2 += ido;
				num3 += ido << 1;
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000EEB8 File Offset: 0x0000D0B8
		private static void dradb3(int ido, int l1, float[] cc, float[] ch, float[] wa1, int index1, float[] wa2, int index2)
		{
			int num = l1 * ido;
			int num2 = 0;
			int num3 = num << 1;
			int num4 = ido << 1;
			int num5 = ido + (ido << 1);
			int num6 = 0;
			for (int i = 0; i < l1; i++)
			{
				float num7 = cc[num4 - 1] + cc[num4 - 1];
				float num8 = cc[num6] + Drft.taur * num7;
				ch[num2] = cc[num6] + num7;
				float num9 = Drft.taui * (cc[num4] + cc[num4]);
				ch[num2 + num] = num8 - num9;
				ch[num2 + num3] = num8 + num9;
				num2 += ido;
				num4 += num5;
				num6 += num5;
			}
			if (ido == 1)
			{
				return;
			}
			num2 = 0;
			num4 = ido << 1;
			for (int i = 0; i < l1; i++)
			{
				int num10 = num2 + (num2 << 1);
				int num11;
				num6 = (num11 = num10 + num4);
				int num12 = num2;
				int num14;
				int num13 = (num14 = num2 + num) + num;
				for (int j = 2; j < ido; j += 2)
				{
					num6 += 2;
					num11 -= 2;
					num10 += 2;
					num12 += 2;
					num14 += 2;
					num13 += 2;
					float num7 = cc[num6 - 1] + cc[num11 - 1];
					float num8 = cc[num10 - 1] + Drft.taur * num7;
					ch[num12 - 1] = cc[num10 - 1] + num7;
					float num15 = cc[num6] - cc[num11];
					float num16 = cc[num10] + Drft.taur * num15;
					ch[num12] = cc[num10] + num15;
					float num17 = Drft.taui * (cc[num6 - 1] - cc[num11 - 1]);
					float num9 = Drft.taui * (cc[num6] + cc[num11]);
					float num18 = num8 - num9;
					float num19 = num8 + num9;
					float num20 = num16 + num17;
					float num21 = num16 - num17;
					ch[num14 - 1] = wa1[index1 + j - 2] * num18 - wa1[index1 + j - 1] * num20;
					ch[num14] = wa1[index1 + j - 2] * num20 + wa1[index1 + j - 1] * num18;
					ch[num13 - 1] = wa2[index2 + j - 2] * num19 - wa2[index2 + j - 1] * num21;
					ch[num13] = wa2[index2 + j - 2] * num21 + wa2[index2 + j - 1] * num19;
				}
				num2 += ido;
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000F0CC File Offset: 0x0000D2CC
		private static void dradb4(int ido, int l1, float[] cc, float[] ch, float[] wa1, int index1, float[] wa2, int index2, float[] wa3, int index3)
		{
			int num = l1 * ido;
			int num2 = 0;
			int num3 = ido << 2;
			int num4 = 0;
			int num5 = ido << 1;
			int num6;
			for (int i = 0; i < l1; i++)
			{
				num6 = num4 + num5;
				int num7 = num2;
				float num8 = cc[num6 - 1] + cc[num6 - 1];
				float num9 = cc[num6] + cc[num6];
				float num10 = cc[num4] - cc[(num6 += num5) - 1];
				float num11 = cc[num4] + cc[num6 - 1];
				ch[num7] = num11 + num8;
				ch[num7 += num] = num10 - num9;
				ch[num7 += num] = num11 - num8;
				ch[num7 + num] = num10 + num9;
				num2 += ido;
				num4 += num3;
			}
			if (ido < 2)
			{
				return;
			}
			if (ido != 2)
			{
				num2 = 0;
				for (int i = 0; i < l1; i++)
				{
					int num7 = (num6 = (num4 = (num3 = num2 << 2) + num5)) + num5;
					int num12 = num2;
					for (int j = 2; j < ido; j += 2)
					{
						num3 += 2;
						num4 += 2;
						num6 -= 2;
						num7 -= 2;
						num12 += 2;
						float num13 = cc[num3] + cc[num7];
						float num14 = cc[num3] - cc[num7];
						float num15 = cc[num4] - cc[num6];
						float num9 = cc[num4] + cc[num6];
						float num10 = cc[num3 - 1] - cc[num7 - 1];
						float num11 = cc[num3 - 1] + cc[num7 - 1];
						float num16 = cc[num4 - 1] - cc[num6 - 1];
						float num8 = cc[num4 - 1] + cc[num6 - 1];
						ch[num12 - 1] = num11 + num8;
						float num17 = num11 - num8;
						ch[num12] = num14 + num15;
						float num18 = num14 - num15;
						float num19 = num10 - num9;
						float num20 = num10 + num9;
						float num21 = num13 + num16;
						float num22 = num13 - num16;
						int num23;
						ch[(num23 = num12 + num) - 1] = wa1[index1 + j - 2] * num19 - wa1[index1 + j - 1] * num21;
						ch[num23] = wa1[index1 + j - 2] * num21 + wa1[index1 + j - 1] * num19;
						ch[(num23 += num) - 1] = wa2[index2 + j - 2] * num17 - wa2[index2 + j - 1] * num18;
						ch[num23] = wa2[index2 + j - 2] * num18 + wa2[index2 + j - 1] * num17;
						ch[(num23 += num) - 1] = wa3[index3 + j - 2] * num20 - wa3[index3 + j - 1] * num22;
						ch[num23] = wa3[index3 + j - 2] * num22 + wa3[index3 + j - 1] * num20;
					}
					num2 += ido;
				}
				if (ido % 2 == 1)
				{
					return;
				}
			}
			num2 = ido;
			num3 = ido << 2;
			num4 = ido - 1;
			num6 = ido + (ido << 1);
			for (int i = 0; i < l1; i++)
			{
				int num7 = num4;
				float num13 = cc[num2] + cc[num6];
				float num14 = cc[num6] - cc[num2];
				float num10 = cc[num2 - 1] - cc[num6 - 1];
				float num11 = cc[num2 - 1] + cc[num6 - 1];
				ch[num7] = num11 + num11;
				ch[num7 += num] = Drft.sqrt2 * (num10 - num13);
				ch[num7 += num] = num14 + num14;
				ch[num7 + num] = -Drft.sqrt2 * (num10 + num13);
				num4 += ido;
				num2 += num3;
				num6 += num3;
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000F408 File Offset: 0x0000D608
		private static void dradbg(int ido, int ip, int l1, int idl1, float[] cc, float[] c1, float[] c2, float[] ch, float[] ch2, float[] wa, int index)
		{
			int num = ip * ido;
			int num2 = l1 * ido;
			float num3 = Drft.tpi / (float)ip;
			float num4 = (float)Math.Cos((double)num3);
			float num5 = (float)Math.Sin((double)num3);
			int num6 = (int)((uint)(ido - 1) >> 1);
			int num7 = (int)((uint)(ip + 1) >> 1);
			int num8;
			int num9;
			int num10;
			if (ido >= l1)
			{
				num8 = 0;
				num9 = 0;
				for (int i = 0; i < l1; i++)
				{
					num10 = num8;
					int num11 = num9;
					for (int j = 0; j < ido; j++)
					{
						ch[num10] = cc[num11];
						num10++;
						num11++;
					}
					num8 += ido;
					num9 += num;
				}
			}
			else
			{
				num8 = 0;
				for (int j = 0; j < ido; j++)
				{
					num9 = num8;
					num10 = num8;
					for (int i = 0; i < l1; i++)
					{
						ch[num9] = cc[num10];
						num9 += ido;
						num10 += num;
					}
					num8++;
				}
			}
			num8 = 0;
			num9 = ip * num2;
			int num13;
			int num12 = num13 = ido << 1;
			for (int k = 1; k < num7; k++)
			{
				num8 += num2;
				num9 -= num2;
				num10 = num8;
				int num11 = num9;
				int num14 = num12;
				for (int i = 0; i < l1; i++)
				{
					ch[num10] = cc[num14 - 1] + cc[num14 - 1];
					ch[num11] = cc[num14] + cc[num14];
					num10 += ido;
					num11 += ido;
					num14 += num;
				}
				num12 += num13;
			}
			int num16;
			if (ido != 1)
			{
				if (num6 >= l1)
				{
					num8 = 0;
					num9 = ip * num2;
					num13 = 0;
					for (int k = 1; k < num7; k++)
					{
						num8 += num2;
						num9 -= num2;
						num10 = num8;
						int num11 = num9;
						num13 += ido << 1;
						int num15 = num13;
						for (int i = 0; i < l1; i++)
						{
							num12 = num10;
							int num14 = num11;
							num16 = num15;
							int num17 = num15;
							for (int j = 2; j < ido; j += 2)
							{
								num12 += 2;
								num14 += 2;
								num16 += 2;
								num17 -= 2;
								ch[num12 - 1] = cc[num16 - 1] + cc[num17 - 1];
								ch[num14 - 1] = cc[num16 - 1] - cc[num17 - 1];
								ch[num12] = cc[num16] - cc[num17];
								ch[num14] = cc[num16] + cc[num17];
							}
							num10 += ido;
							num11 += ido;
							num15 += num;
						}
					}
				}
				else
				{
					num8 = 0;
					num9 = ip * num2;
					num13 = 0;
					for (int k = 1; k < num7; k++)
					{
						num8 += num2;
						num9 -= num2;
						num10 = num8;
						int num11 = num9;
						num13 += ido << 1;
						int num15 = num13;
						num16 = num13;
						for (int j = 2; j < ido; j += 2)
						{
							num10 += 2;
							num11 += 2;
							num15 += 2;
							num16 -= 2;
							num12 = num10;
							int num14 = num11;
							int num17 = num15;
							int num18 = num16;
							for (int i = 0; i < l1; i++)
							{
								ch[num12 - 1] = cc[num17 - 1] + cc[num18 - 1];
								ch[num14 - 1] = cc[num17 - 1] - cc[num18 - 1];
								ch[num12] = cc[num17] - cc[num18];
								ch[num14] = cc[num17] + cc[num18];
								num12 += ido;
								num14 += ido;
								num17 += num;
								num18 += num;
							}
						}
					}
				}
			}
			float num19 = 1f;
			float num20 = 0f;
			num8 = 0;
			num9 = (num16 = ip * idl1);
			num10 = (ip - 1) * idl1;
			for (int m = 1; m < num7; m++)
			{
				num8 += idl1;
				num9 -= idl1;
				float num21 = num4 * num19 - num5 * num20;
				num20 = num4 * num20 + num5 * num19;
				num19 = num21;
				int num11 = num8;
				num12 = num9;
				int num14 = 0;
				num13 = idl1;
				int num15 = num10;
				for (int n = 0; n < idl1; n++)
				{
					c2[num11++] = ch2[num14++] + num19 * ch2[num13++];
					c2[num12++] = num20 * ch2[num15++];
				}
				float num22 = num19;
				float num23 = num20;
				float num24 = num19;
				float num25 = num20;
				num14 = idl1;
				num13 = num16 - idl1;
				for (int k = 2; k < num7; k++)
				{
					num14 += idl1;
					num13 -= idl1;
					float num26 = num22 * num24 - num23 * num25;
					num25 = num22 * num25 + num23 * num24;
					num24 = num26;
					num11 = num8;
					num12 = num9;
					int num17 = num14;
					int num18 = num13;
					for (int n = 0; n < idl1; n++)
					{
						c2[num11] += num24 * ch2[num17++];
						num11++;
						c2[num12] += num25 * ch2[num18++];
						num12++;
					}
				}
			}
			num8 = 0;
			for (int k = 1; k < num7; k++)
			{
				num8 += idl1;
				num9 = num8;
				for (int n = 0; n < idl1; n++)
				{
					ch2[n] += ch2[num9++];
				}
			}
			num8 = 0;
			num9 = ip * num2;
			for (int k = 1; k < num7; k++)
			{
				num8 += num2;
				num9 -= num2;
				num10 = num8;
				int num11 = num9;
				for (int i = 0; i < l1; i++)
				{
					ch[num10] = c1[num10] - c1[num11];
					ch[num11] = c1[num10] + c1[num11];
					num10 += ido;
					num11 += ido;
				}
			}
			if (ido != 1)
			{
				if (num6 >= l1)
				{
					num8 = 0;
					num9 = ip * num2;
					for (int k = 1; k < num7; k++)
					{
						num8 += num2;
						num9 -= num2;
						num10 = num8;
						int num11 = num9;
						for (int i = 0; i < l1; i++)
						{
							num12 = num10;
							int num14 = num11;
							for (int j = 2; j < ido; j += 2)
							{
								num12 += 2;
								num14 += 2;
								ch[num12 - 1] = c1[num12 - 1] - c1[num14];
								ch[num14 - 1] = c1[num12 - 1] + c1[num14];
								ch[num12] = c1[num12] + c1[num14 - 1];
								ch[num14] = c1[num12] - c1[num14 - 1];
							}
							num10 += ido;
							num11 += ido;
						}
					}
				}
				else
				{
					num8 = 0;
					num9 = ip * num2;
					for (int k = 1; k < num7; k++)
					{
						num8 += num2;
						num9 -= num2;
						num10 = num8;
						int num11 = num9;
						for (int j = 2; j < ido; j += 2)
						{
							num10 += 2;
							num11 += 2;
							num12 = num10;
							int num14 = num11;
							for (int i = 0; i < l1; i++)
							{
								ch[num12 - 1] = c1[num12 - 1] - c1[num14];
								ch[num14 - 1] = c1[num12 - 1] + c1[num14];
								ch[num12] = c1[num12] + c1[num14 - 1];
								ch[num14] = c1[num12] - c1[num14 - 1];
								num12 += ido;
								num14 += ido;
							}
						}
					}
				}
			}
			if (ido == 1)
			{
				return;
			}
			for (int n = 0; n < idl1; n++)
			{
				c2[n] = ch2[n];
			}
			num8 = 0;
			for (int k = 1; k < ip; k++)
			{
				num8 = (num9 = num8 + num2);
				for (int i = 0; i < l1; i++)
				{
					c1[num9] = ch[num9];
					num9 += ido;
				}
			}
			int num27;
			if (num6 <= l1)
			{
				num27 = -ido - 1;
				num8 = 0;
				for (int k = 1; k < ip; k++)
				{
					num27 += ido;
					num8 += num2;
					int num28 = num27;
					num9 = num8;
					for (int j = 2; j < ido; j += 2)
					{
						num9 += 2;
						num28 += 2;
						num10 = num9;
						for (int i = 0; i < l1; i++)
						{
							c1[num10 - 1] = wa[index + num28 - 1] * ch[num10 - 1] - wa[index + num28] * ch[num10];
							c1[num10] = wa[index + num28 - 1] * ch[num10] + wa[index + num28] * ch[num10 - 1];
							num10 += ido;
						}
					}
				}
				return;
			}
			num27 = -ido - 1;
			num8 = 0;
			for (int k = 1; k < ip; k++)
			{
				num27 += ido;
				num8 += num2;
				num9 = num8;
				for (int i = 0; i < l1; i++)
				{
					int num28 = num27;
					num10 = num9;
					for (int j = 2; j < ido; j += 2)
					{
						num28 += 2;
						num10 += 2;
						c1[num10 - 1] = wa[index + num28 - 1] * ch[num10 - 1] - wa[index + num28] * ch[num10];
						c1[num10] = wa[index + num28 - 1] * ch[num10] + wa[index + num28] * ch[num10 - 1];
					}
					num9 += ido;
				}
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000FCD4 File Offset: 0x0000DED4
		private static void drftb1(int n, float[] c, float[] ch, float[] wa, int index, int[] ifac)
		{
			int num = ifac[1];
			int num2 = 0;
			int num3 = 1;
			int num4 = 1;
			for (int i = 0; i < num; i++)
			{
				int num5 = ifac[i + 2];
				int num6 = num5 * num3;
				int num7 = n / num6;
				int idl = num7 * num3;
				if (num5 == 4)
				{
					int num8 = num4 + num7;
					int num9 = num8 + num7;
					if (num2 != 0)
					{
						Drft.dradb4(num7, num3, ch, c, wa, index + num4 - 1, wa, index + num8 - 1, wa, index + num9 - 1);
					}
					else
					{
						Drft.dradb4(num7, num3, c, ch, wa, index + num4 - 1, wa, index + num8 - 1, wa, index + num9 - 1);
					}
					num2 = 1 - num2;
				}
				else if (num5 == 2)
				{
					if (num2 != 0)
					{
						Drft.dradb2(num7, num3, ch, c, wa, index + num4 - 1);
					}
					else
					{
						Drft.dradb2(num7, num3, c, ch, wa, index + num4 - 1);
					}
					num2 = 1 - num2;
				}
				else if (num5 == 3)
				{
					int num8 = num4 + num7;
					if (num2 != 0)
					{
						Drft.dradb3(num7, num3, ch, c, wa, index + num4 - 1, wa, index + num8 - 1);
					}
					else
					{
						Drft.dradb3(num7, num3, c, ch, wa, index + num4 - 1, wa, index + num8 - 1);
					}
					num2 = 1 - num2;
				}
				else
				{
					if (num2 != 0)
					{
						Drft.dradbg(num7, num5, num3, idl, ch, ch, ch, c, c, wa, index + num4 - 1);
					}
					else
					{
						Drft.dradbg(num7, num5, num3, idl, c, c, c, ch, ch, wa, index + num4 - 1);
					}
					if (num7 == 1)
					{
						num2 = 1 - num2;
					}
					num4 += (num5 - 1) * num7;
				}
				num3 = num6;
				num4 += (num5 - 1) * num7;
			}
			if (num2 == 0)
			{
				return;
			}
			for (int j = 0; j < n; j++)
			{
				c[j] = ch[j];
			}
		}

		// Token: 0x040001AE RID: 430
		private int n;

		// Token: 0x040001AF RID: 431
		private float[] trigcache;

		// Token: 0x040001B0 RID: 432
		private int[] splitcache;

		// Token: 0x040001B1 RID: 433
		private static int[] ntryh = new int[]
		{
			4,
			2,
			3,
			5
		};

		// Token: 0x040001B2 RID: 434
		private static float tpi = 6.2831855f;

		// Token: 0x040001B3 RID: 435
		private static float hsqt2 = 0.70710677f;

		// Token: 0x040001B4 RID: 436
		private static float taui = 0.8660254f;

		// Token: 0x040001B5 RID: 437
		private static float taur = -0.5f;

		// Token: 0x040001B6 RID: 438
		private static float sqrt2 = 1.4142135f;
	}
}
