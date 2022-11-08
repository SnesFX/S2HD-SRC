using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Audio
{
	// Token: 0x0200019E RID: 414
	public class BasicSampleMixer : ISampleMixer
	{
		// Token: 0x060011E6 RID: 4582 RVA: 0x00046F50 File Offset: 0x00045150
		public void Mix(byte[] buffer, int offset, int length, IEnumerable<ISampleProvider> channels)
		{
			byte[] array = new byte[length];
			IEnumerable<ISampleProvider> second = from x in channels.OfType<SampleInstance>()
			where x.Classification == SampleInstanceClassification.Music
			select x;
			foreach (ISampleProvider sampleProvider in (from x in channels.Except(second).Concat(second)
			where x.Playing
			select x).ToArray<ISampleProvider>())
			{
				double calculatedVolume = sampleProvider.CalculatedVolume;
				if (calculatedVolume > 0.0)
				{
					int num = sampleProvider.Read(array, offset, length);
					for (int i = 0; i < num; i += 2)
					{
						short a = BitConverter.ToInt16(buffer, i);
						short b = (short)((double)BitConverter.ToInt16(array, i) * calculatedVolume);
						short num2 = this.MixSample(a, b);
						buffer[i] = (byte)(num2 & 255);
						buffer[i + 1] = (byte)(num2 >> 8 & 255);
					}
				}
			}
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x00047074 File Offset: 0x00045274
		private short MixSample(short a, short b)
		{
			int num;
			if (a < 0 && b < 0)
			{
				num = (int)(a + b - a * b / short.MinValue);
			}
			else if (a > 0 && b > 0)
			{
				num = (int)(a + b - a * b / short.MaxValue);
			}
			else
			{
				num = (int)(a + b);
			}
			return (short)num;
		}
	}
}
