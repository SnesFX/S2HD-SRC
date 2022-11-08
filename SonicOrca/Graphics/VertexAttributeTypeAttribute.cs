using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D1 RID: 209
	public class VertexAttributeTypeAttribute : Attribute
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x0001D668 File Offset: 0x0001B868
		public VertexAttributePointerType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x0001D670 File Offset: 0x0001B870
		public int Size
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001D678 File Offset: 0x0001B878
		public VertexAttributeTypeAttribute(VertexAttributePointerType type, int size)
		{
			this._type = type;
			this._size = size;
		}

		// Token: 0x040004AD RID: 1197
		private readonly VertexAttributePointerType _type;

		// Token: 0x040004AE RID: 1198
		private readonly int _size;
	}
}
