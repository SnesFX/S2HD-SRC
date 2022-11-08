using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BB RID: 187
	public interface IFramebuffer : IDisposable
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000642 RID: 1602
		int Width { get; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000643 RID: 1603
		int Height { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000644 RID: 1604
		IReadOnlyList<ITexture> Textures { get; }

		// Token: 0x06000645 RID: 1605
		void Activate();
	}
}
