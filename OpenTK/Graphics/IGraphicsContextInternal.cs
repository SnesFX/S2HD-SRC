using System;

namespace OpenTK.Graphics
{
	// Token: 0x02000027 RID: 39
	public interface IGraphicsContextInternal
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000483 RID: 1155
		IGraphicsContext Implementation { get; }

		// Token: 0x06000484 RID: 1156
		void LoadAll();

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000485 RID: 1157
		ContextHandle Context { get; }

		// Token: 0x06000486 RID: 1158
		IntPtr GetAddress(string function);

		// Token: 0x06000487 RID: 1159
		IntPtr GetAddress(IntPtr function);
	}
}
