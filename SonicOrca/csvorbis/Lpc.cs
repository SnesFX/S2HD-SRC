using System;

namespace csvorbis
{
	// Token: 0x0200007B RID: 123
	internal class Lpc
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x00012DD0 File Offset: 0x00010FD0
		private static float lpc_from_data(float[] data, float[] lpc, int n, int m)
		{
			float[] array = new float[m + 1];
			int i = m + 1;
			while (i-- != 0)
			{
				float num = 0f;
				for (int j = i; j < n; j++)
				{
					num += data[j] * data[j - i];
				}
				array[i] = num;
			}
			float num2 = array[0];
			for (int j = 0; j < m; j++)
			{
				float num3 = -array[j + 1];
				if (num2 == 0f)
				{
					for (int k = 0; k < m; k++)
					{
						lpc[k] = 0f;
					}
					return 0f;
				}
				for (i = 0; i < j; i++)
				{
					num3 -= lpc[i] * array[j - i];
				}
				num3 /= num2;
				lpc[j] = num3;
				for (i = 0; i < j / 2; i++)
				{
					float num4 = lpc[i];
					lpc[i] += num3 * lpc[j - 1 - i];
					lpc[j - 1 - i] += num3 * num4;
				}
				if (j % 2 != 0)
				{
					lpc[i] += lpc[i] * num3;
				}
				num2 *= (float)(1.0 - (double)(num3 * num3));
			}
			return num2;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00012EEC File Offset: 0x000110EC
		private float lpc_from_curve(float[] curve, float[] lpc)
		{
			int num = this.ln;
			float[] array = new float[num + num];
			float num2 = (float)(0.5 / (double)num);
			int i;
			for (i = 0; i < num; i++)
			{
				array[i * 2] = curve[i] * num2;
				array[i * 2 + 1] = 0f;
			}
			array[num * 2 - 1] = curve[num - 1] * num2;
			num *= 2;
			this.fft.backward(array);
			i = 0;
			int num3 = num / 2;
			while (i < num / 2)
			{
				float num4 = array[i];
				array[i++] = array[num3];
				array[num3++] = num4;
			}
			return Lpc.lpc_from_data(array, lpc, num, this.m);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00012F8F File Offset: 0x0001118F
		internal void init(int mapped, int m)
		{
			this.ln = mapped;
			this.m = m;
			this.fft.init(mapped * 2);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00012FAD File Offset: 0x000111AD
		private void clear()
		{
			this.fft.clear();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00012FBA File Offset: 0x000111BA
		private static float FAST_HYPOT(float a, float b)
		{
			return (float)Math.Sqrt((double)(a * a + b * b));
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00012FCC File Offset: 0x000111CC
		internal void lpc_to_curve(float[] curve, float[] lpc, float amp)
		{
			for (int i = 0; i < this.ln * 2; i++)
			{
				curve[i] = 0f;
			}
			if (amp == 0f)
			{
				return;
			}
			for (int j = 0; j < this.m; j++)
			{
				curve[j * 2 + 1] = lpc[j] / (4f * amp);
				curve[j * 2 + 2] = -lpc[j] / (4f * amp);
			}
			this.fft.backward(curve);
			int num = this.ln * 2;
			float num2 = (float)(1.0 / (double)amp);
			curve[0] = (float)(1.0 / (double)(curve[0] * 2f + num2));
			for (int k = 1; k < this.ln; k++)
			{
				float num3 = curve[k] + curve[num - k];
				float b = curve[k] - curve[num - k];
				float a = num3 + num2;
				curve[k] = (float)(1.0 / (double)Lpc.FAST_HYPOT(a, b));
			}
		}

		// Token: 0x04000249 RID: 585
		private Drft fft = new Drft();

		// Token: 0x0400024A RID: 586
		private int ln;

		// Token: 0x0400024B RID: 587
		private int m;
	}
}
