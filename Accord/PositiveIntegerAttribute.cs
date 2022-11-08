using System;

namespace Accord
{
	// Token: 0x0200001C RID: 28
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class PositiveIntegerAttribute : IntegerAttribute
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x0000364E File Offset: 0x0000264E
		public PositiveIntegerAttribute(int minimum = 1, int maximum = 2147483647) : base(minimum, maximum)
		{
			if (minimum <= 0)
			{
				throw new ArgumentOutOfRangeException("minimum");
			}
		}
	}
}
