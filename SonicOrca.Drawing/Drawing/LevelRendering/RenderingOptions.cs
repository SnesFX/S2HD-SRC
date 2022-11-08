using System;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x02000018 RID: 24
	public class RenderingOptions : IRenderingOptions
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600014F RID: 335 RVA: 0x0000718E File Offset: 0x0000538E
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00007196 File Offset: 0x00005396
		public bool EnableShadows { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000719F File Offset: 0x0000539F
		// (set) Token: 0x06000152 RID: 338 RVA: 0x000071A7 File Offset: 0x000053A7
		public bool EnableEffects { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000153 RID: 339 RVA: 0x000071B0 File Offset: 0x000053B0
		// (set) Token: 0x06000154 RID: 340 RVA: 0x000071B8 File Offset: 0x000053B8
		public bool EnableParticles { get; set; }
	}
}
