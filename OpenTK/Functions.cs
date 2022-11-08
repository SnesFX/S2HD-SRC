using System;

namespace OpenTK
{
	// Token: 0x0200052E RID: 1326
	[Obsolete("Use OpenTK.MathHelper instead.")]
	public static class Functions
	{
		// Token: 0x06003FB0 RID: 16304 RVA: 0x000A9184 File Offset: 0x000A7384
		public static long NextPowerOfTwo(long n)
		{
			if (n < 0L)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (long)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06003FB1 RID: 16305 RVA: 0x000A91C0 File Offset: 0x000A73C0
		public static int NextPowerOfTwo(int n)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (int)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06003FB2 RID: 16306 RVA: 0x000A91FC File Offset: 0x000A73FC
		public static float NextPowerOfTwo(float n)
		{
			if (n < 0f)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (float)Math.Pow(2.0, Math.Ceiling(Math.Log((double)n, 2.0)));
		}

		// Token: 0x06003FB3 RID: 16307 RVA: 0x000A923C File Offset: 0x000A743C
		public static double NextPowerOfTwo(double n)
		{
			if (n < 0.0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return Math.Pow(2.0, Math.Ceiling(Math.Log(n, 2.0)));
		}

		// Token: 0x06003FB4 RID: 16308 RVA: 0x000A9288 File Offset: 0x000A7488
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

		// Token: 0x06003FB5 RID: 16309 RVA: 0x000A92AC File Offset: 0x000A74AC
		public static long BinomialCoefficient(int n, int k)
		{
			return Functions.Factorial(n) / (Functions.Factorial(k) * Functions.Factorial(n - k));
		}

		// Token: 0x06003FB6 RID: 16310 RVA: 0x000A92C4 File Offset: 0x000A74C4
		public unsafe static float InverseSqrtFast(float x)
		{
			float num = 0.5f * x;
			int num2 = *(int*)(&x);
			num2 = 1597463174 - (num2 >> 1);
			x = *(float*)(&num2);
			x *= 1.5f - num * x * x;
			return x;
		}

		// Token: 0x06003FB7 RID: 16311 RVA: 0x000A9300 File Offset: 0x000A7500
		public static double InverseSqrtFast(double x)
		{
			return (double)Functions.InverseSqrtFast((float)x);
		}

		// Token: 0x06003FB8 RID: 16312 RVA: 0x000A930C File Offset: 0x000A750C
		public static float DegreesToRadians(float degrees)
		{
			return degrees * 0.017453292f;
		}

		// Token: 0x06003FB9 RID: 16313 RVA: 0x000A9318 File Offset: 0x000A7518
		public static float RadiansToDegrees(float radians)
		{
			return radians * 57.295776f;
		}

		// Token: 0x06003FBA RID: 16314 RVA: 0x000A9324 File Offset: 0x000A7524
		public static void Swap(ref double a, ref double b)
		{
			double num = a;
			a = b;
			b = num;
		}

		// Token: 0x06003FBB RID: 16315 RVA: 0x000A933C File Offset: 0x000A753C
		public static void Swap(ref float a, ref float b)
		{
			float num = a;
			a = b;
			b = num;
		}

		// Token: 0x04004E04 RID: 19972
		public static readonly float PIF = 3.1415927f;

		// Token: 0x04004E05 RID: 19973
		public static readonly float RTODF = 180f / Functions.PIF;

		// Token: 0x04004E06 RID: 19974
		public static readonly float DTORF = Functions.PIF / 180f;

		// Token: 0x04004E07 RID: 19975
		public static readonly double PI = 3.141592653589793;

		// Token: 0x04004E08 RID: 19976
		public static readonly double RTOD = 180.0 / (double)Functions.PIF;

		// Token: 0x04004E09 RID: 19977
		public static readonly double DTOR = (double)Functions.PIF / 180.0;
	}
}
