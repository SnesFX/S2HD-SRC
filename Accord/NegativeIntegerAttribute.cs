using System;

namespace Accord
{
	// Token: 0x0200001D RID: 29
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NegativeIntegerAttribute : IntegerAttribute
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00003667 File Offset: 0x00002667
		public NegativeIntegerAttribute(int minimum = -2147483648, int maximum = 2147483647) : base(minimum, maximum)
		{
			if (maximum >= 0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
		}
	}
}
