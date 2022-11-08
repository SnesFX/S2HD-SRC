using System;
using System.Runtime.CompilerServices;
using csogg;

namespace csvorbis
{
	// Token: 0x02000063 RID: 99
	internal class CodeBook
	{
		// Token: 0x0600035B RID: 859 RVA: 0x0000CD0E File Offset: 0x0000AF0E
		internal int encode(int a, csBuffer b)
		{
			b.write(this.codelist[a], this.c.lengthlist[a]);
			return this.c.lengthlist[a];
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000CD38 File Offset: 0x0000AF38
		internal int errorv(float[] a)
		{
			int num = this.best(a, 1);
			for (int i = 0; i < this.dim; i++)
			{
				a[i] = this.valuelist[num * this.dim + i];
			}
			return num;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000CD74 File Offset: 0x0000AF74
		internal int encodev(int best, float[] a, csBuffer b)
		{
			for (int i = 0; i < this.dim; i++)
			{
				a[i] = this.valuelist[best * this.dim + i];
			}
			return this.encode(best, b);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000CDB0 File Offset: 0x0000AFB0
		internal int encodevs(float[] a, csBuffer b, int step, int addmul)
		{
			int a2 = this.besterror(a, step, addmul);
			return this.encode(a2, b);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		[MethodImpl(MethodImplOptions.Synchronized)]
		internal int decodevs_add(float[] a, int offset, csBuffer b, int n)
		{
			int num = n / this.dim;
			if (this.t.Length < num)
			{
				this.t = new int[num];
			}
			int i;
			for (i = 0; i < num; i++)
			{
				int num2 = this.decode(b);
				if (num2 == -1)
				{
					return -1;
				}
				this.t[i] = num2 * this.dim;
			}
			i = 0;
			int num3 = 0;
			while (i < this.dim)
			{
				for (int j = 0; j < num; j++)
				{
					a[offset + num3 + j] += this.valuelist[this.t[j] + i];
				}
				i++;
				num3 += num;
			}
			return 0;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000CE70 File Offset: 0x0000B070
		internal int decodev_add(float[] a, int offset, csBuffer b, int n)
		{
			if (this.dim > 8)
			{
				int i = 0;
				while (i < n)
				{
					int num = this.decode(b);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.dim;
					int j = 0;
					while (j < this.dim)
					{
						a[offset + i++] += this.valuelist[num2 + j++];
					}
				}
			}
			else
			{
				int i = 0;
				while (i < n)
				{
					int num = this.decode(b);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.dim;
					int j = 0;
					for (int k = 0; k < this.dim; k++)
					{
						a[offset + i++] += this.valuelist[num2 + j++];
					}
				}
			}
			return 0;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000CF2C File Offset: 0x0000B12C
		internal int decodev_set(float[] a, int offset, csBuffer b, int n)
		{
			int i = 0;
			while (i < n)
			{
				int num = this.decode(b);
				if (num == -1)
				{
					return -1;
				}
				int num2 = num * this.dim;
				int j = 0;
				while (j < this.dim)
				{
					a[offset + i++] = this.valuelist[num2 + j++];
				}
			}
			return 0;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000CF80 File Offset: 0x0000B180
		internal int decodevv_add(float[][] a, int offset, int ch, csBuffer b, int n)
		{
			int num = 0;
			int i = offset / ch;
			while (i < (offset + n) / ch)
			{
				int num2 = this.decode(b);
				if (num2 == -1)
				{
					return -1;
				}
				int num3 = num2 * this.dim;
				for (int j = 0; j < this.dim; j++)
				{
					a[num][i] += this.valuelist[num3 + j];
					num++;
					if (num == ch)
					{
						num = 0;
						i++;
					}
				}
			}
			return 0;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000CFF0 File Offset: 0x0000B1F0
		internal int decode(csBuffer b)
		{
			int num = 0;
			DecodeAux decodeAux = this.decode_tree;
			int num2 = b.look(decodeAux.tabn);
			if (num2 >= 0)
			{
				num = decodeAux.tab[num2];
				b.adv(decodeAux.tabl[num2]);
				if (num <= 0)
				{
					return -num;
				}
			}
			for (;;)
			{
				switch (b.read1())
				{
				case 0:
					num = decodeAux.ptr0[num];
					goto IL_6D;
				case 1:
					num = decodeAux.ptr1[num];
					goto IL_6D;
				}
				break;
				IL_6D:
				if (num <= 0)
				{
					goto Block_4;
				}
			}
			return -1;
			Block_4:
			return -num;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000D070 File Offset: 0x0000B270
		internal int decodevs(float[] a, int index, csBuffer b, int step, int addmul)
		{
			int num = this.decode(b);
			if (num == -1)
			{
				return -1;
			}
			switch (addmul)
			{
			case -1:
			{
				int i = 0;
				int num2 = 0;
				while (i < this.dim)
				{
					a[index + num2] = this.valuelist[num * this.dim + i];
					i++;
					num2 += step;
				}
				break;
			}
			case 0:
			{
				int j = 0;
				int num3 = 0;
				while (j < this.dim)
				{
					a[index + num3] += this.valuelist[num * this.dim + j];
					j++;
					num3 += step;
				}
				break;
			}
			case 1:
			{
				int k = 0;
				int num4 = 0;
				while (k < this.dim)
				{
					a[index + num4] *= this.valuelist[num * this.dim + k];
					k++;
					num4 += step;
				}
				break;
			}
			}
			return num;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000D154 File Offset: 0x0000B354
		internal int best(float[] a, int step)
		{
			EncodeAuxNearestMatch nearest_tree = this.c.nearest_tree;
			EncodeAuxThreshMatch thresh_tree = this.c.thresh_tree;
			int num = 0;
			if (thresh_tree != null)
			{
				int num2 = 0;
				int i = 0;
				int num3 = step * (this.dim - 1);
				while (i < this.dim)
				{
					int num4 = 0;
					while (num4 < thresh_tree.threshvals - 1 && a[num3] >= thresh_tree.quantthresh[num4])
					{
						num4++;
					}
					num2 = num2 * thresh_tree.quantvals + thresh_tree.quantmap[num4];
					i++;
					num3 -= step;
				}
				if (this.c.lengthlist[num2] > 0)
				{
					return num2;
				}
			}
			if (nearest_tree != null)
			{
				do
				{
					double num5 = 0.0;
					int num6 = nearest_tree.p[num];
					int num7 = nearest_tree.q[num];
					int j = 0;
					int num8 = 0;
					while (j < this.dim)
					{
						num5 += (double)(this.valuelist[num6 + j] - this.valuelist[num7 + j]) * ((double)a[num8] - (double)(this.valuelist[num6 + j] + this.valuelist[num7 + j]) * 0.5);
						j++;
						num8 += step;
					}
					if (num5 > 0.0)
					{
						num = -nearest_tree.ptr0[num];
					}
					else
					{
						num = -nearest_tree.ptr1[num];
					}
				}
				while (num > 0);
				return -num;
			}
			int num9 = -1;
			float num10 = 0f;
			int num11 = 0;
			for (int k = 0; k < this.entries; k++)
			{
				if (this.c.lengthlist[k] > 0)
				{
					float num12 = CodeBook.dist(this.dim, this.valuelist, num11, a, step);
					if (num9 == -1 || num12 < num10)
					{
						num10 = num12;
						num9 = k;
					}
				}
				num11 += this.dim;
			}
			return num9;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000D318 File Offset: 0x0000B518
		internal int besterror(float[] a, int step, int addmul)
		{
			int num = this.best(a, step);
			if (addmul != 0)
			{
				if (addmul == 1)
				{
					int i = 0;
					int num2 = 0;
					while (i < this.dim)
					{
						float num3 = this.valuelist[num * this.dim + i];
						if (num3 == 0f)
						{
							a[num2] = 0f;
						}
						else
						{
							a[num2] /= num3;
						}
						i++;
						num2 += step;
					}
				}
			}
			else
			{
				int j = 0;
				int num4 = 0;
				while (j < this.dim)
				{
					a[num4] -= this.valuelist[num * this.dim + j];
					j++;
					num4 += step;
				}
			}
			return num;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00006325 File Offset: 0x00004525
		internal void clear()
		{
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000D3C0 File Offset: 0x0000B5C0
		internal static float dist(int el, float[] rref, int index, float[] b, int step)
		{
			float num = 0f;
			for (int i = 0; i < el; i++)
			{
				float num2 = rref[index + i] - b[i * step];
				num += num2 * num2;
			}
			return num;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000D3F4 File Offset: 0x0000B5F4
		internal int init_decode(StaticCodeBook s)
		{
			this.c = s;
			this.entries = s.entries;
			this.dim = s.dim;
			this.valuelist = s.unquantize();
			this.decode_tree = this.make_decode_tree();
			if (this.decode_tree == null)
			{
				this.clear();
				return -1;
			}
			return 0;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000D44C File Offset: 0x0000B64C
		internal static int[] make_words(int[] l, int n)
		{
			int[] array = new int[33];
			int[] array2 = new int[n];
			for (int i = 0; i < n; i++)
			{
				int num = l[i];
				if (num > 0)
				{
					int num2 = array[num];
					if (num < 32 && (uint)num2 >> num != 0U)
					{
						return null;
					}
					array2[i] = num2;
					int j = num;
					while (j > 0)
					{
						if ((array[j] & 1) != 0)
						{
							if (j == 1)
							{
								array[1]++;
								break;
							}
							array[j] = array[j - 1] << 1;
							break;
						}
						else
						{
							array[j]++;
							j--;
						}
					}
					int num3 = num + 1;
					while (num3 < 33 && (ulong)((uint)array[num3] >> 1) == (ulong)((long)num2))
					{
						num2 = array[num3];
						array[num3] = array[num3 - 1] << 1;
						num3++;
					}
				}
			}
			for (int k = 0; k < n; k++)
			{
				int num4 = 0;
				for (int m = 0; m < l[k]; m++)
				{
					num4 <<= 1;
					num4 |= (int)((uint)array2[k] >> m & 1U);
				}
				array2[k] = num4;
			}
			return array2;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000D55C File Offset: 0x0000B75C
		internal DecodeAux make_decode_tree()
		{
			int num = 0;
			DecodeAux decodeAux = new DecodeAux();
			int[] array = decodeAux.ptr0 = new int[this.entries * 2];
			int[] array2 = decodeAux.ptr1 = new int[this.entries * 2];
			int[] array3 = CodeBook.make_words(this.c.lengthlist, this.c.entries);
			if (array3 == null)
			{
				return null;
			}
			decodeAux.aux = this.entries * 2;
			for (int i = 0; i < this.entries; i++)
			{
				if (this.c.lengthlist[i] > 0)
				{
					int num2 = 0;
					int j;
					for (j = 0; j < this.c.lengthlist[i] - 1; j++)
					{
						if (((uint)array3[i] >> j & 1U) == 0U)
						{
							if (array[num2] == 0)
							{
								num = (array[num2] = num + 1);
							}
							num2 = array[num2];
						}
						else
						{
							if (array2[num2] == 0)
							{
								num = (array2[num2] = num + 1);
							}
							num2 = array2[num2];
						}
					}
					if (((uint)array3[i] >> j & 1U) == 0U)
					{
						array[num2] = -i;
					}
					else
					{
						array2[num2] = -i;
					}
				}
			}
			decodeAux.tabn = CodeBook.ilog(this.entries) - 4;
			if (decodeAux.tabn < 5)
			{
				decodeAux.tabn = 5;
			}
			int num3 = 1 << decodeAux.tabn;
			decodeAux.tab = new int[num3];
			decodeAux.tabl = new int[num3];
			for (int k = 0; k < num3; k++)
			{
				int num4 = 0;
				int num5 = 0;
				while (num5 < decodeAux.tabn && (num4 > 0 || num5 == 0))
				{
					if ((k & 1 << num5) != 0)
					{
						num4 = array2[num4];
					}
					else
					{
						num4 = array[num4];
					}
					num5++;
				}
				decodeAux.tab[k] = num4;
				decodeAux.tabl[k] = num5;
			}
			return decodeAux;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000D72C File Offset: 0x0000B92C
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

		// Token: 0x0400019B RID: 411
		internal int dim;

		// Token: 0x0400019C RID: 412
		internal int entries;

		// Token: 0x0400019D RID: 413
		internal StaticCodeBook c = new StaticCodeBook();

		// Token: 0x0400019E RID: 414
		internal float[] valuelist;

		// Token: 0x0400019F RID: 415
		internal int[] codelist;

		// Token: 0x040001A0 RID: 416
		internal DecodeAux decode_tree;

		// Token: 0x040001A1 RID: 417
		internal int[] t = new int[15];
	}
}
