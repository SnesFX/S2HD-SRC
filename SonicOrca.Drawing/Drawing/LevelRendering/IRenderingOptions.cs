using System;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x02000017 RID: 23
	public interface IRenderingOptions
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600014C RID: 332
		bool EnableShadows { get; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600014D RID: 333
		bool EnableEffects { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600014E RID: 334
		bool EnableParticles { get; }
	}
}
