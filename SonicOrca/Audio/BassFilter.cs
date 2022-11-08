using System;
using System.Linq;
using SonicOrca.Extensions;

namespace SonicOrca.Audio
{
	// Token: 0x0200019F RID: 415
	internal class BassFilter
	{
		// Token: 0x060011E9 RID: 4585 RVA: 0x000470BC File Offset: 0x000452BC
		public static void Apply(byte[] buffer)
		{
			float[] array;
			float[] array2;
			Sample.PCMToSamples(buffer, out array, out array2);
			int num = 512;
			for (int i = 0; i < array.Length; i += num)
			{
				float[] range = array.GetRange(i, Math.Min(array.Length - i, num));
				float[] range2 = array2.GetRange(i, Math.Min(array2.Length - i, num));
				BassFilter.Apply(range);
				BassFilter.Apply(range2);
				Array.Copy(range, 0, array, i, range.Length);
				Array.Copy(range2, 0, array2, i, range2.Length);
			}
			Array.Copy(Sample.SamplesToPCM(array, array), buffer, buffer.Length);
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x0004714C File Offset: 0x0004534C
		private static void Apply(float[] samples)
		{
			int m = (int)Math.Log((double)samples.Length, 2.0);
			ComplexNumber[] array = FastFourierTransform.TimeToFrequency(m, (from x in samples
			select (double)x).ToArray<double>());
			for (int i = 32; i < samples.Length; i++)
			{
				array[i].Real = 0.0;
				array[i].Imaginary = 0.0;
			}
			FastFourierTransform.FrequencyToTime(m, array);
			for (int j = 0; j < samples.Length; j++)
			{
				samples[j] = (float)array[j].Real;
			}
		}
	}
}
