using System;
using System.ComponentModel.DataAnnotations;

namespace Accord
{
	// Token: 0x02000019 RID: 25
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class NonnegativeAttribute : RangeAttribute
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x000035EF File Offset: 0x000025EF
		public NonnegativeAttribute(double minimum = 0.0, double maximum = 1.7976931348623157E+308) : base(0.0, double.MaxValue)
		{
			if (maximum < 0.0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
		}
	}
}
