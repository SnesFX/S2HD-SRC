using System;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x0200015D RID: 349
	[AttributeUsage(AttributeTargets.Class)]
	public class ClassificationAttribute : Attribute
	{
		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000EBB RID: 3771 RVA: 0x00037841 File Offset: 0x00035A41
		public ObjectClassification Classification
		{
			get
			{
				return this._classification;
			}
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00037849 File Offset: 0x00035A49
		public ClassificationAttribute(ObjectClassification classification)
		{
			this._classification = classification;
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00037858 File Offset: 0x00035A58
		public static ClassificationAttribute FromObject(object obj)
		{
			return AttributeHelpers.GetAttribute<ClassificationAttribute>(obj.GetType());
		}

		// Token: 0x04000848 RID: 2120
		private readonly ObjectClassification _classification;
	}
}
