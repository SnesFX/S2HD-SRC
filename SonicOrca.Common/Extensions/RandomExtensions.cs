using System;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000D RID: 13
	public static class RandomExtensions
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002688 File Offset: 0x00000888
		public static double NextSignedDouble(this Random random)
		{
			return random.NextDouble() * 2.0 - 1.0;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026A4 File Offset: 0x000008A4
		public static double NextRadians(this Random random)
		{
			return random.NextSignedDouble() * 3.141592653589793;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026B6 File Offset: 0x000008B6
		public static double NextDouble(this Random random, double maxValue)
		{
			return random.NextDouble() * maxValue;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000026C0 File Offset: 0x000008C0
		public static double NextDouble(this Random random, double minValue, double maxValue)
		{
			return minValue + random.NextDouble() * (maxValue - minValue);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026CE File Offset: 0x000008CE
		public static bool NextBoolean(this Random random)
		{
			return (random.Next() & 1) == 0;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000026DB File Offset: 0x000008DB
		public static int NextSign(this Random random)
		{
			if (!random.NextBoolean())
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026E8 File Offset: 0x000008E8
		public static int NextSign(this Random random, int value)
		{
			if (!random.NextBoolean())
			{
				return value;
			}
			return -value;
		}
	}
}
