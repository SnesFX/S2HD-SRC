using System;
using SonicOrca.Audio;
using SonicOrca.Graphics;
using SonicOrca.Input;

namespace SonicOrca
{
	// Token: 0x02000099 RID: 153
	public interface IPlatform : IDisposable
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600052F RID: 1327
		WindowContext Window { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000530 RID: 1328
		InputContext Input { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000531 RID: 1329
		AudioContext Audio { get; }

		// Token: 0x06000532 RID: 1330
		void Initialise();

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000533 RID: 1331
		string GraphicsAPI { get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000534 RID: 1332
		string GraphicsVendor { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000535 RID: 1333
		int TotalMemory { get; }

		// Token: 0x06000536 RID: 1334
		Version GetOpenGLVersion();
	}
}
