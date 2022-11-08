using System;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x02000161 RID: 353
	[AttributeUsage(AttributeTargets.Class)]
	public class ObjectInstanceAttribute : Attribute
	{
		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x000378DC File Offset: 0x00035ADC
		public Type ObjectInstanceType
		{
			get
			{
				return this._objectInstanceType;
			}
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x000378E4 File Offset: 0x00035AE4
		public ObjectInstanceAttribute(Type objectInstanceType)
		{
			this._objectInstanceType = objectInstanceType;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x000378F3 File Offset: 0x00035AF3
		public static ObjectInstanceAttribute FromObject(object obj)
		{
			return AttributeHelpers.GetAttribute<ObjectInstanceAttribute>(obj.GetType());
		}

		// Token: 0x0400084C RID: 2124
		private readonly Type _objectInstanceType;
	}
}
