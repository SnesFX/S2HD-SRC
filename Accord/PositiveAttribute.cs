using System;

namespace Accord
{
	// Token: 0x02000016 RID: 22
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class PositiveAttribute : RealAttribute
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000358C File Offset: 0x0000258C
		public PositiveAttribute(double minimum = 5E-324, double maximum = 1.7976931348623157E+308) : base(minimum, maximum)
		{
			if (minimum <= 0.0)
			{
				throw new ArgumentOutOfRangeException("minimum");
			}
		}
	}
}
