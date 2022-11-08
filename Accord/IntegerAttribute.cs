using System;
using System.ComponentModel.DataAnnotations;

namespace Accord
{
	// Token: 0x02000020 RID: 32
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public class IntegerAttribute : RangeAttribute
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x000036B2 File Offset: 0x000026B2
		public IntegerAttribute(int minimum = -2147483648, int maximum = 2147483647) : base(minimum, maximum)
		{
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000DA RID: 218 RVA: 0x000036BC File Offset: 0x000026BC
		public new int Minimum
		{
			get
			{
				return (int)base.Minimum;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000DB RID: 219 RVA: 0x000036C9 File Offset: 0x000026C9
		public new int Maximum
		{
			get
			{
				return (int)base.Maximum;
			}
		}
	}
}
