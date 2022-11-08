using System;

namespace Accord
{
	// Token: 0x02000018 RID: 24
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NonpositiveAttribute : RealAttribute
	{
		// Token: 0x060000CF RID: 207 RVA: 0x000035CE File Offset: 0x000025CE
		public NonpositiveAttribute(double minimum = -1.7976931348623157E+308, double maximum = 0.0) : base(minimum, maximum)
		{
			if (maximum < 0.0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
		}
	}
}
