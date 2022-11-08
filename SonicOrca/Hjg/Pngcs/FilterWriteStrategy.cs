using System;

namespace Hjg.Pngcs
{
	// Token: 0x02000020 RID: 32
	internal class FilterWriteStrategy
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000041E8 File Offset: 0x000023E8
		internal FilterWriteStrategy(ImageInfo imgInfo, FilterType configuredType)
		{
			this.imgInfo = imgInfo;
			this.configuredType = configuredType;
			if (configuredType < FilterType.FILTER_NONE)
			{
				if ((imgInfo.Rows < 8 && imgInfo.Cols < 8) || imgInfo.Indexed || imgInfo.BitDepth < 8)
				{
					this.currentType = FilterType.FILTER_NONE;
				}
				else
				{
					this.currentType = FilterType.FILTER_PAETH;
				}
			}
			else
			{
				this.currentType = configuredType;
			}
			if (configuredType == FilterType.FILTER_AGGRESSIVE)
			{
				this.discoverEachLines = FilterWriteStrategy.COMPUTE_STATS_EVERY_N_LINES;
			}
			if (configuredType == FilterType.FILTER_VERYAGGRESSIVE)
			{
				this.discoverEachLines = 1;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000042B6 File Offset: 0x000024B6
		internal bool shouldTestAll(int rown)
		{
			if (this.discoverEachLines > 0 && this.lastRowTested + this.discoverEachLines <= rown)
			{
				this.currentType = FilterType.FILTER_UNKNOWN;
				return true;
			}
			return false;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000042DC File Offset: 0x000024DC
		internal void setPreference(double none, double sub, double up, double ave, double paeth)
		{
			this.preference = new double[]
			{
				none,
				sub,
				up,
				ave,
				paeth
			};
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004300 File Offset: 0x00002500
		internal bool computesStatistics()
		{
			return this.discoverEachLines > 0;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000430C File Offset: 0x0000250C
		internal void fillResultsForFilter(int rown, FilterType type, double sum, int[] histo, bool tentative)
		{
			this.lastRowTested = rown;
			this.lastSums[(int)type] = sum;
			if (histo != null)
			{
				double num = (rown == 0) ? 0.0 : 0.3;
				double num2 = 1.0 - num;
				double num3 = 0.0;
				for (int i = 0; i < 256; i++)
				{
					double num4 = (double)histo[i] / (double)this.imgInfo.Cols;
					num4 = this.histogram1[i] * num + num4 * num2;
					if (tentative)
					{
						num3 += ((num4 > 1E-08) ? (num4 * Math.Log(num4)) : 0.0);
					}
					else
					{
						this.histogram1[i] = num4;
					}
				}
				this.lastEntropies[(int)type] = -num3;
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000043D4 File Offset: 0x000025D4
		internal FilterType gimmeFilterType(int rown, bool useEntropy)
		{
			if (this.currentType == FilterType.FILTER_UNKNOWN)
			{
				if (rown == 0)
				{
					this.currentType = FilterType.FILTER_SUB;
				}
				else
				{
					double num = double.MaxValue;
					for (int i = 0; i < 5; i++)
					{
						double num2 = useEntropy ? this.lastEntropies[i] : this.lastSums[i];
						num2 /= this.preference[i];
						if (num2 <= num)
						{
							num = num2;
							this.currentType = (FilterType)i;
						}
					}
				}
			}
			if (this.configuredType == FilterType.FILTER_CYCLIC)
			{
				this.currentType = (this.currentType + 1) % (FilterType)5;
			}
			return this.currentType;
		}

		// Token: 0x04000041 RID: 65
		private static readonly int COMPUTE_STATS_EVERY_N_LINES = 8;

		// Token: 0x04000042 RID: 66
		private readonly ImageInfo imgInfo;

		// Token: 0x04000043 RID: 67
		private readonly FilterType configuredType;

		// Token: 0x04000044 RID: 68
		private FilterType currentType;

		// Token: 0x04000045 RID: 69
		private int lastRowTested = -1000000;

		// Token: 0x04000046 RID: 70
		private double[] lastSums = new double[5];

		// Token: 0x04000047 RID: 71
		private double[] lastEntropies = new double[5];

		// Token: 0x04000048 RID: 72
		private double[] preference = new double[]
		{
			1.1,
			1.1,
			1.1,
			1.1,
			1.2
		};

		// Token: 0x04000049 RID: 73
		private int discoverEachLines = -1;

		// Token: 0x0400004A RID: 74
		private double[] histogram1 = new double[256];
	}
}
