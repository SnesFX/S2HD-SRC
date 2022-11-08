using System;
using System.Linq;

namespace SonicOrca.Audio
{
	// Token: 0x020001A0 RID: 416
	public static class FastFourierTransform
	{
		// Token: 0x060011EC RID: 4588 RVA: 0x000471FC File Offset: 0x000453FC
		public static double HammingWindow(int n, int frameSize)
		{
			return 0.54 - 0.46 * Math.Cos(6.283185307179586 * (double)n / (double)(frameSize - 1));
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x00047228 File Offset: 0x00045428
		public static ComplexNumber[] TimeToFrequency(int m, double[] samples)
		{
			ComplexNumber[] array = (from x in samples
			select new ComplexNumber(x, 0.0)).ToArray<ComplexNumber>();
			FastFourierTransform.Apply(true, m, array);
			return array;
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x00047269 File Offset: 0x00045469
		public static void TimeToFrequency(int m, ComplexNumber[] data)
		{
			FastFourierTransform.Apply(true, m, data);
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x00047273 File Offset: 0x00045473
		public static void FrequencyToTime(int m, ComplexNumber[] data)
		{
			FastFourierTransform.Apply(false, m, data);
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x00047280 File Offset: 0x00045480
		private static void Apply(bool forward, int m, ComplexNumber[] data)
		{
			int num = 1;
			int i = 0;
			int num2 = 1;
			double num3 = -1.0;
			double num4 = 0.0;
			for (int j = 0; j < m; j++)
			{
				num *= 2;
			}
			int num5 = num >> 1;
			for (int j = 0; j < num - 1; j++)
			{
				if (j < i)
				{
					double real = data[j].Real;
					double imaginary = data[j].Imaginary;
					data[j].Real = data[i].Real;
					data[j].Imaginary = data[i].Imaginary;
					data[i].Real = real;
					data[i].Imaginary = imaginary;
				}
				int k;
				for (k = num5; k <= i; k >>= 1)
				{
					i -= k;
				}
				i += k;
			}
			for (int l = 0; l < m; l++)
			{
				int num6 = num2;
				num2 <<= 1;
				double num7 = 1.0;
				double num8 = 0.0;
				for (i = 0; i < num6; i++)
				{
					for (int j = i; j < num; j += num2)
					{
						int num9 = j + num6;
						double num10 = num7 * data[num9].Real - num8 * data[num9].Imaginary;
						double num11 = num7 * data[num9].Imaginary + num8 * data[num9].Real;
						data[num9].Real = data[j].Real - num10;
						data[num9].Imaginary = data[j].Imaginary - num11;
						int num12 = j;
						data[num12].Real = data[num12].Real + num10;
						int num13 = j;
						data[num13].Imaginary = data[num13].Imaginary + num11;
					}
					double num14 = num7 * num3 - num8 * num4;
					num8 = num7 * num4 + num8 * num3;
					num7 = num14;
				}
				num4 = Math.Sqrt((1.0 - num3) / 2.0);
				if (forward)
				{
					num4 = -num4;
				}
				num3 = Math.Sqrt((1.0 + num3) / 2.0);
			}
			if (forward)
			{
				for (int j = 0; j < num; j++)
				{
					int num15 = j;
					data[num15].Real = data[num15].Real / (double)num;
					int num16 = j;
					data[num16].Imaginary = data[num16].Imaginary / (double)num;
				}
			}
		}
	}
}
