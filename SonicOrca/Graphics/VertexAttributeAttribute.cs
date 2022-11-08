using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000CF RID: 207
	public class VertexAttributeAttribute : Attribute
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x0001D651 File Offset: 0x0001B851
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001D659 File Offset: 0x0001B859
		public VertexAttributeAttribute(string name)
		{
			this._name = name;
		}

		// Token: 0x0400049F RID: 1183
		private readonly string _name;
	}
}
