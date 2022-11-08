using System;

namespace Accord
{
	// Token: 0x0200001E RID: 30
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NonpositiveIntegerAttribute : IntegerAttribute
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00003680 File Offset: 0x00002680
		public NonpositiveIntegerAttribute(int minimum = -2147483648, int maximum = 0) : base(minimum, maximum)
		{
			if (maximum > 0)
			{
				throw new ArgumentOutOfRangeException("minimum");
			}
		}
	}
}
