using System;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000E9 RID: 233
	public interface IFilmBuffer : IDisposable, ILoadedResource
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600080A RID: 2058
		int Width { get; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600080B RID: 2059
		int Height { get; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600080C RID: 2060
		double CurrentTime { get; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600080D RID: 2061
		double Duration { get; }

		// Token: 0x0600080E RID: 2062
		void Decode();

		// Token: 0x0600080F RID: 2063
		byte[] GetArgbData();
	}
}
