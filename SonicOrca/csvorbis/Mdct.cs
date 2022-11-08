using System;
using System.Runtime.CompilerServices;

namespace csvorbis
{
	// Token: 0x02000080 RID: 128
	internal class Mdct
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x00013C4C File Offset: 0x00011E4C
		internal void init(int n)
		{
			this.bitrev = new int[n / 4];
			this.trig = new float[n + n / 4];
			this.log2n = (int)Math.Round(Math.Log((double)n) / Math.Log(2.0));
			this.n = n;
			int num = 0;
			int num2 = 1;
			int num3 = num + n / 2;
			int num4 = num3 + 1;
			int num5 = num3 + n / 2;
			int num6 = num5 + 1;
			for (int i = 0; i < n / 4; i++)
			{
				this.trig[num + i * 2] = (float)Math.Cos(3.141592653589793 / (double)n * (double)(4 * i));
				this.trig[num2 + i * 2] = (float)(-(float)Math.Sin(3.141592653589793 / (double)n * (double)(4 * i)));
				this.trig[num3 + i * 2] = (float)Math.Cos(3.141592653589793 / (double)(2 * n) * (double)(2 * i + 1));
				this.trig[num4 + i * 2] = (float)Math.Sin(3.141592653589793 / (double)(2 * n) * (double)(2 * i + 1));
			}
			for (int j = 0; j < n / 8; j++)
			{
				this.trig[num5 + j * 2] = (float)Math.Cos(3.141592653589793 / (double)n * (double)(4 * j + 2));
				this.trig[num6 + j * 2] = (float)(-(float)Math.Sin(3.141592653589793 / (double)n * (double)(4 * j + 2)));
			}
			int num7 = (1 << this.log2n - 1) - 1;
			int num8 = 1 << this.log2n - 2;
			for (int k = 0; k < n / 8; k++)
			{
				int num9 = 0;
				int num10 = 0;
				while ((uint)num8 >> num10 != 0U)
				{
					if (((ulong)((uint)num8 >> num10) & (ulong)((long)k)) != 0UL)
					{
						num9 |= 1 << num10;
					}
					num10++;
				}
				this.bitrev[k * 2] = (~num9 & num7);
				this.bitrev[k * 2 + 1] = num9;
			}
			this.scale = 4f / (float)n;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00006325 File Offset: 0x00004525
		internal void clear()
		{
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00006325 File Offset: 0x00004525
		internal void forward(float[] fin, float[] fout)
		{
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00013E68 File Offset: 0x00012068
		[MethodImpl(MethodImplOptions.Synchronized)]
		internal void backward(float[] fin, float[] fout)
		{
			if (this._x.Length < this.n / 2)
			{
				this._x = new float[this.n / 2];
			}
			if (this._w.Length < this.n / 2)
			{
				this._w = new float[this.n / 2];
			}
			float[] x = this._x;
			float[] w = this._w;
			int num = (int)((uint)this.n >> 1);
			int num2 = (int)((uint)this.n >> 2);
			int num3 = (int)((uint)this.n >> 3);
			int num4 = 1;
			int num5 = 0;
			int num6 = num;
			for (int i = 0; i < num3; i++)
			{
				num6 -= 2;
				x[num5++] = -fin[num4 + 2] * this.trig[num6 + 1] - fin[num4] * this.trig[num6];
				x[num5++] = fin[num4] * this.trig[num6 + 1] - fin[num4 + 2] * this.trig[num6];
				num4 += 4;
			}
			num4 = num - 4;
			for (int i = 0; i < num3; i++)
			{
				num6 -= 2;
				x[num5++] = fin[num4] * this.trig[num6 + 1] + fin[num4 + 2] * this.trig[num6];
				x[num5++] = fin[num4] * this.trig[num6] - fin[num4 + 2] * this.trig[num6 + 1];
				num4 -= 4;
			}
			float[] array = this.mdct_kernel(x, w, this.n, num, num2, num3);
			int num7 = 0;
			int num8 = num;
			int num9 = num2;
			int num10 = num9 - 1;
			int num11 = num2 + num;
			int num12 = num11 - 1;
			for (int j = 0; j < num2; j++)
			{
				float num13 = array[num7] * this.trig[num8 + 1] - array[num7 + 1] * this.trig[num8];
				float num14 = -(array[num7] * this.trig[num8] + array[num7 + 1] * this.trig[num8 + 1]);
				fout[num9] = -num13;
				fout[num10] = num13;
				fout[num11] = num14;
				fout[num12] = num14;
				num9++;
				num10--;
				num11++;
				num12--;
				num7 += 2;
				num8 += 2;
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000140A8 File Offset: 0x000122A8
		internal float[] mdct_kernel(float[] x, float[] w, int n, int n2, int n4, int n8)
		{
			int num = n4;
			int num2 = 0;
			int num3 = n2;
			for (int i = 0; i < n4; i++)
			{
				float num4 = x[num] - x[num2];
				w[n4 + i] = x[num++] + x[num2++];
				float num5 = x[num] - x[num2];
				num3 -= 4;
				w[i++] = num4 * this.trig[num3] + num5 * this.trig[num3 + 1];
				w[i] = num5 * this.trig[num3] - num4 * this.trig[num3 + 1];
				w[n4 + i] = x[num++] + x[num2++];
			}
			for (int j = 0; j < this.log2n - 3; j++)
			{
				int num6 = (int)((uint)n >> j + 2);
				int num7 = 1 << j + 3;
				int num8 = n2 - 2;
				num3 = 0;
				int num9 = 0;
				while ((long)num9 < (long)((ulong)((uint)num6 >> 2)))
				{
					int num10 = num8;
					int num11 = num10 - (num6 >> 1);
					float num12 = this.trig[num3];
					float num13 = this.trig[num3 + 1];
					num8 -= 2;
					num6++;
					for (int k = 0; k < 2 << j; k++)
					{
						float num14 = w[num10] - w[num11];
						x[num10] = w[num10] + w[num11];
						float num15 = w[++num10] - w[++num11];
						x[num10] = w[num10] + w[num11];
						x[num11] = num15 * num12 - num14 * num13;
						x[num11 - 1] = num14 * num12 + num15 * num13;
						num10 -= num6;
						num11 -= num6;
					}
					num6--;
					num3 += num7;
					num9++;
				}
				float[] array = w;
				w = x;
				x = array;
			}
			int num16 = n;
			int num17 = 0;
			int num18 = 0;
			int num19 = n2 - 1;
			for (int l = 0; l < n8; l++)
			{
				int num20 = this.bitrev[num17++];
				int num21 = this.bitrev[num17++];
				float num22 = w[num20] - w[num21 + 1];
				float num23 = w[num20 - 1] + w[num21];
				float num24 = w[num20] + w[num21 + 1];
				float num25 = w[num20 - 1] - w[num21];
				float num26 = num22 * this.trig[num16];
				float num27 = num23 * this.trig[num16++];
				float num28 = num22 * this.trig[num16];
				float num29 = num23 * this.trig[num16++];
				x[num18++] = (num24 + num28 + num27) * 0.5f;
				x[num19--] = (-num25 + num29 - num26) * 0.5f;
				x[num18++] = (num25 + num29 - num26) * 0.5f;
				x[num19--] = (num24 - num28 - num27) * 0.5f;
			}
			return x;
		}

		// Token: 0x04000263 RID: 611
		private int n;

		// Token: 0x04000264 RID: 612
		private int log2n;

		// Token: 0x04000265 RID: 613
		private float[] trig;

		// Token: 0x04000266 RID: 614
		private int[] bitrev;

		// Token: 0x04000267 RID: 615
		private float scale;

		// Token: 0x04000268 RID: 616
		private float[] _x = new float[1024];

		// Token: 0x04000269 RID: 617
		private float[] _w = new float[1024];
	}
}
