using System;
using System.ComponentModel.DataAnnotations;

namespace Accord
{
	// Token: 0x0200001A RID: 26
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public class RealAttribute : RangeAttribute
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00003620 File Offset: 0x00002620
		public RealAttribute(double minimum = -1.7976931348623157E+308, double maximum = 1.7976931348623157E+308) : base(minimum, maximum)
		{
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x0000362A File Offset: 0x0000262A
		public new double Minimum
		{
			get
			{
				return (double)base.Minimum;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00003637 File Offset: 0x00002637
		public new double Maximum
		{
			get
			{
				return (double)base.Maximum;
			}
		}
	}
}
