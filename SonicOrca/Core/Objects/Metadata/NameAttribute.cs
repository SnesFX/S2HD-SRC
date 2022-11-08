using System;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x02000160 RID: 352
	[AttributeUsage(AttributeTargets.Class)]
	public class NameAttribute : Attribute
	{
		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x000378B8 File Offset: 0x00035AB8
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x000378C0 File Offset: 0x00035AC0
		public NameAttribute(string name)
		{
			this._name = name;
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x000378CF File Offset: 0x00035ACF
		public static NameAttribute FromObject(object obj)
		{
			return AttributeHelpers.GetAttribute<NameAttribute>(obj.GetType());
		}

		// Token: 0x0400084B RID: 2123
		private readonly string _name;
	}
}
