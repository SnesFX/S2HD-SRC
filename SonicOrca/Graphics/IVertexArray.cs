using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C6 RID: 198
	public interface IVertexArray : IDisposable
	{
		// Token: 0x060006C3 RID: 1731
		void Bind();

		// Token: 0x060006C4 RID: 1732
		void DefineAttribute(int attributeLocation, VertexAttributePointerType type, int size, int stride, int offset);

		// Token: 0x060006C5 RID: 1733
		void Render(PrimitiveType type, int index, int count);
	}
}
