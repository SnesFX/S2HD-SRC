using System;
using System.Threading;

namespace Accord
{
	// Token: 0x02000006 RID: 6
	public class InterlockedEx
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000022C8 File Offset: 0x000012C8
		public static double Add(ref double location1, double value)
		{
			double num = 0.0;
			double num2;
			double num3;
			do
			{
				num2 = num;
				num3 = num2 + value;
				num = Interlocked.CompareExchange(ref location1, num3, num2);
			}
			while (num != num2);
			return num3;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000022F4 File Offset: 0x000012F4
		public static double Increment(ref double location1)
		{
			double num = 0.0;
			double num2;
			double num3;
			do
			{
				num2 = num;
				num3 = num2 + 1.0;
				num = Interlocked.CompareExchange(ref location1, num3, num2);
			}
			while (num != num2);
			return num3;
		}
	}
}
