using System;

namespace SonicOrca
{
	// Token: 0x0200009A RID: 154
	public static class MathX
	{
		// Token: 0x06000537 RID: 1335 RVA: 0x00019E78 File Offset: 0x00018078
		public static double Lerp(double a, double b, double t)
		{
			return (1.0 - t) * a + t * b;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00019E8C File Offset: 0x0001808C
		public static double Lerp(double from, double to, double amount, double minChange)
		{
			double num = (to - from) * amount;
			if (to > from)
			{
				from += ((num < minChange) ? minChange : num);
				if (from <= to)
				{
					return from;
				}
				return to;
			}
			else
			{
				from += ((num > -minChange) ? (-minChange) : num);
				if (from >= to)
				{
					return from;
				}
				return to;
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00019ECC File Offset: 0x000180CC
		public static double LerpWrap(double from, double to, double amount, double minValue, double maxValue, double minChange = 0.0)
		{
			double num = maxValue - minValue;
			double num2 = num / 2.0;
			from %= num;
			for (to %= num; to < from - num2; to += num)
			{
			}
			while (to > from + num2)
			{
				to -= num;
			}
			from = MathX.Lerp(from, to, amount, minChange);
			if (from < minValue)
			{
				return from + num;
			}
			if (from > maxValue)
			{
				return from - num;
			}
			return from;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00019F2C File Offset: 0x0001812C
		public static double Snap(double value, double precision)
		{
			return Math.Round(value / precision) * precision;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00019F38 File Offset: 0x00018138
		public static bool IsBetween(double a, double b, double c)
		{
			return a <= b && b <= c;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00019F47 File Offset: 0x00018147
		public static int Clamp(int low, int value, int high)
		{
			if (value < low)
			{
				return low;
			}
			if (value > high)
			{
				return high;
			}
			return value;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00019F56 File Offset: 0x00018156
		public static int Clamp(int value, int high)
		{
			return MathX.Clamp(-high, value, high);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00019F61 File Offset: 0x00018161
		public static double Clamp(double low, double value, double high)
		{
			if (value < low)
			{
				return low;
			}
			if (value > high)
			{
				return high;
			}
			return value;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00019F70 File Offset: 0x00018170
		public static double Clamp(double value, double high)
		{
			return MathX.Clamp(-high, value, high);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00019F7C File Offset: 0x0001817C
		public static double ChangeSpeed(double x, double amount)
		{
			if (x < 0.0)
			{
				x -= amount;
				if (x > 0.0)
				{
					x = 0.0;
				}
			}
			else
			{
				x += amount;
				if (x < 0.0)
				{
					x = 0.0;
				}
			}
			return x;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00019FD0 File Offset: 0x000181D0
		public static double ChangeSpeedNonZero(double x, double amount)
		{
			if (x < 0.0)
			{
				x -= amount;
			}
			else
			{
				x += amount;
			}
			return x;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00019FEC File Offset: 0x000181EC
		public static int Wrap(int x, int max, int min = 0)
		{
			int num = max - min;
			while (x < min)
			{
				x += num;
			}
			while (x > max)
			{
				x -= num;
			}
			return x;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001A014 File Offset: 0x00018214
		public static double Wrap(double x, double max, double min = 0.0)
		{
			double num = max - min;
			while (x < min)
			{
				x += num;
			}
			while (x > max)
			{
				x -= num;
			}
			return x;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001A03C File Offset: 0x0001823C
		public static double WrapRadians(double radians)
		{
			if (radians < 3.141592653589793)
			{
				radians += 6.283185307179586;
			}
			if (radians > 3.141592653589793)
			{
				radians -= 6.283185307179586;
			}
			return radians;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001A071 File Offset: 0x00018271
		public static int GoTowards(int x, int dest, int maxChange)
		{
			if (x < dest)
			{
				return Math.Min(x + maxChange, dest);
			}
			if (x > dest)
			{
				return Math.Max(x - maxChange, dest);
			}
			return x;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001A090 File Offset: 0x00018290
		public static double GoTowards(double x, double dest, double maxChange)
		{
			if (x < dest)
			{
				return Math.Min(x + maxChange, dest);
			}
			if (x > dest)
			{
				return Math.Max(x - maxChange, dest);
			}
			return x;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001A0B0 File Offset: 0x000182B0
		public static double GoTowardsWrap(double x, double dest, double maxChange, double minValue, double maxValue)
		{
			x = MathX.Wrap(x, maxValue, minValue);
			dest = MathX.Wrap(dest, maxValue, minValue);
			if (x == dest)
			{
				return x;
			}
			if (x < dest)
			{
				double num = x - minValue + (maxValue - dest);
				double num2 = dest - x;
				if (num < num2)
				{
					return MathX.Wrap(x - Math.Min(num, maxChange), maxValue, minValue);
				}
				return Math.Min(x + maxChange, dest);
			}
			else
			{
				double num3 = x - dest;
				double num4 = maxValue - x + (dest - minValue);
				if (num3 < num4)
				{
					return Math.Max(x - maxChange, dest);
				}
				return MathX.Wrap(x + Math.Min(num4, maxChange), maxValue, minValue);
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001A134 File Offset: 0x00018334
		public static double WrapDifference(double a, double b, double minValue, double maxValue)
		{
			if (a == b)
			{
				return 0.0;
			}
			if (a < b)
			{
				double num = a - minValue + (maxValue - b);
				double num2 = b - a;
				if (num < num2)
				{
					return -num;
				}
				return num2;
			}
			else
			{
				double num3 = a - b;
				double num4 = maxValue - a + (b - minValue);
				if (num3 < num4)
				{
					return -num3;
				}
				return num4;
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001A17C File Offset: 0x0001837C
		public static double ToRadians(double degrees)
		{
			return degrees * 0.017453292519943295;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001A189 File Offset: 0x00018389
		public static double ToDegrees(double radians)
		{
			return radians * 57.29577951308232;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001A196 File Offset: 0x00018396
		public static double DifferenceRadians(double a, double b)
		{
			return MathX.WrapDifference(a, b, -3.141592653589793, 3.141592653589793);
		}

		// Token: 0x0400032A RID: 810
		public const double TWOPI = 6.283185307179586;

		// Token: 0x0400032B RID: 811
		public const double PI_2 = 1.5707963267948966;

		// Token: 0x0400032C RID: 812
		public const double PI_4 = 0.7853981633974483;
	}
}
