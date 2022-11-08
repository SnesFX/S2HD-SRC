using System;

namespace OpenTK
{
	// Token: 0x02000539 RID: 1337
	public static class MathHelper
	{
		// Token: 0x06004293 RID: 17043 RVA: 0x000B4140 File Offset: 0x000B2340
		public static long NextPowerOfTwo(long n)
		{
			if (n < 0L)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (long)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06004294 RID: 17044 RVA: 0x000B417C File Offset: 0x000B237C
		public static int NextPowerOfTwo(int n)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (int)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06004295 RID: 17045 RVA: 0x000B41B8 File Offset: 0x000B23B8
		public static float NextPowerOfTwo(float n)
		{
			if (n < 0f)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (float)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06004296 RID: 17046 RVA: 0x000B41F8 File Offset: 0x000B23F8
		public static double NextPowerOfTwo(double n)
		{
			if (n < 0.0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return Math.Pow(2.0, Math.Ceiling(Math.Log(n, 2.0)));
		}

		// Token: 0x06004297 RID: 17047 RVA: 0x000B4244 File Offset: 0x000B2444
		public static long Factorial(int n)
		{
			long num = 1L;
			while (n > 1)
			{
				num *= (long)n;
				n--;
			}
			return num;
		}

		// Token: 0x06004298 RID: 17048 RVA: 0x000B4268 File Offset: 0x000B2468
		public static long BinomialCoefficient(int n, int k)
		{
			return MathHelper.Factorial(n) / (MathHelper.Factorial(k) * MathHelper.Factorial(n - k));
		}

		// Token: 0x06004299 RID: 17049 RVA: 0x000B4280 File Offset: 0x000B2480
		public unsafe static float InverseSqrtFast(float x)
		{
			float num = 0.5f * x;
			int num2 = *(int*)(&x);
			num2 = 1597463174 - (num2 >> 1);
			x = *(float*)(&num2);
			x *= 1.5f - num * x * x;
			return x;
		}

		// Token: 0x0600429A RID: 17050 RVA: 0x000B42BC File Offset: 0x000B24BC
		public static double InverseSqrtFast(double x)
		{
			return (double)MathHelper.InverseSqrtFast((float)x);
		}

		// Token: 0x0600429B RID: 17051 RVA: 0x000B42C8 File Offset: 0x000B24C8
		public static float DegreesToRadians(float degrees)
		{
			return degrees * 0.017453292f;
		}

		// Token: 0x0600429C RID: 17052 RVA: 0x000B42D4 File Offset: 0x000B24D4
		public static float RadiansToDegrees(float radians)
		{
			return radians * 57.295776f;
		}

		// Token: 0x0600429D RID: 17053 RVA: 0x000B42E0 File Offset: 0x000B24E0
		public static double DegreesToRadians(double degrees)
		{
			return degrees * 0.017453292519943295;
		}

		// Token: 0x0600429E RID: 17054 RVA: 0x000B42F0 File Offset: 0x000B24F0
		public static double RadiansToDegrees(double radians)
		{
			return radians * 57.29577951308232;
		}

		// Token: 0x0600429F RID: 17055 RVA: 0x000B4300 File Offset: 0x000B2500
		public static void Swap(ref double a, ref double b)
		{
			double num = a;
			a = b;
			b = num;
		}

		// Token: 0x060042A0 RID: 17056 RVA: 0x000B4318 File Offset: 0x000B2518
		public static void Swap(ref float a, ref float b)
		{
			float num = a;
			a = b;
			b = num;
		}

		// Token: 0x060042A1 RID: 17057 RVA: 0x000B4330 File Offset: 0x000B2530
		public static int Clamp(int n, int min, int max)
		{
			return Math.Max(Math.Min(n, max), min);
		}

		// Token: 0x060042A2 RID: 17058 RVA: 0x000B4340 File Offset: 0x000B2540
		public static float Clamp(float n, float min, float max)
		{
			return Math.Max(Math.Min(n, max), min);
		}

		// Token: 0x060042A3 RID: 17059 RVA: 0x000B4350 File Offset: 0x000B2550
		public static double Clamp(double n, double min, double max)
		{
			return Math.Max(Math.Min(n, max), min);
		}

		// Token: 0x04004E49 RID: 20041
		public const float Pi = 3.1415927f;

		// Token: 0x04004E4A RID: 20042
		public const float PiOver2 = 1.5707964f;

		// Token: 0x04004E4B RID: 20043
		public const float PiOver3 = 1.0471976f;

		// Token: 0x04004E4C RID: 20044
		public const float PiOver4 = 0.7853982f;

		// Token: 0x04004E4D RID: 20045
		public const float PiOver6 = 0.5235988f;

		// Token: 0x04004E4E RID: 20046
		public const float TwoPi = 6.2831855f;

		// Token: 0x04004E4F RID: 20047
		public const float ThreePiOver2 = 4.712389f;

		// Token: 0x04004E50 RID: 20048
		public const float E = 2.7182817f;

		// Token: 0x04004E51 RID: 20049
		public const float Log10E = 0.4342945f;

		// Token: 0x04004E52 RID: 20050
		public const float Log2E = 1.442695f;
	}
}
