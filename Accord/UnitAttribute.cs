using System;
using System.ComponentModel.DataAnnotations;

namespace Accord
{
	// Token: 0x0200001B RID: 27
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class UnitAttribute : RangeAttribute
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00003644 File Offset: 0x00002644
		public UnitAttribute() : base(0, 1)
		{
		}
	}
}
