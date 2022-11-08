using System;
using SonicOrca.Resources;

namespace SonicOrca.Graphics
{
	// Token: 0x020000E3 RID: 227
	public interface ITexture : IDisposable, ILoadedResource
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060007C9 RID: 1993
		int Width { get; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060007CA RID: 1994
		int Height { get; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060007CB RID: 1995
		int Id { get; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060007CC RID: 1996
		// (set) Token: 0x060007CD RID: 1997
		TextureFiltering Filtering { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060007CE RID: 1998
		// (set) Token: 0x060007CF RID: 1999
		TextureWrapping Wrapping { get; set; }

		// Token: 0x060007D0 RID: 2000
		byte[] GetArgbData();

		// Token: 0x060007D1 RID: 2001
		void SetArgbData(int width, int height, byte[] data);
	}
}
