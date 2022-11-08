using System;

namespace Accord
{
	// Token: 0x02000004 RID: 4
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public sealed class SourceTypeAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000227D File Offset: 0x0000127D
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002285 File Offset: 0x00001285
		private Type SourceType { get; set; }

		// Token: 0x0600001F RID: 31 RVA: 0x0000228E File Offset: 0x0000128E
		public SourceTypeAttribute(Type type)
		{
			this.SourceType = type;
		}
	}
}
