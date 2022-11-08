using System;

namespace Accord
{
	// Token: 0x02000017 RID: 23
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NegativeAttribute : RealAttribute
	{
		// Token: 0x060000CE RID: 206 RVA: 0x000035AD File Offset: 0x000025AD
		public NegativeAttribute(double minimum = -1.7976931348623157E+308, double maximum = -5E-324) : base(minimum, maximum)
		{
			if (maximum >= 0.0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
		}
	}
}
