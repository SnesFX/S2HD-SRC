using System;

namespace Accord
{
	// Token: 0x0200001F RID: 31
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NonnegativeIntegerAttribute : IntegerAttribute
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00003699 File Offset: 0x00002699
		public NonnegativeIntegerAttribute(int minimum = 0, int maximum = 2147483647) : base(minimum, maximum)
		{
			if (maximum < 0)
			{
				throw new ArgumentOutOfRangeException("minimum");
			}
		}
	}
}
