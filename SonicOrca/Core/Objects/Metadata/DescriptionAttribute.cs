using System;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x0200015F RID: 351
	[AttributeUsage(AttributeTargets.Class)]
	public class DescriptionAttribute : Attribute
	{
		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00037894 File Offset: 0x00035A94
		public string Description
		{
			get
			{
				return this._description;
			}
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0003789C File Offset: 0x00035A9C
		public DescriptionAttribute(string description)
		{
			this._description = description;
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x000378AB File Offset: 0x00035AAB
		public static DescriptionAttribute FromObject(object obj)
		{
			return AttributeHelpers.GetAttribute<DescriptionAttribute>(obj.GetType());
		}

		// Token: 0x0400084A RID: 2122
		private readonly string _description;
	}
}
