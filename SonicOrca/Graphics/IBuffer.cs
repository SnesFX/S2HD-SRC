using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000B9 RID: 185
	public interface IBuffer : IDisposable
	{
		// Token: 0x0600062B RID: 1579
		void Bind();

		// Token: 0x0600062C RID: 1580
		void SetData<T>(T[] data, int offset, int length);
	}
}
