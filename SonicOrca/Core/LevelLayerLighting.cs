using System;

namespace SonicOrca.Core
{
	// Token: 0x02000123 RID: 291
	public class LevelLayerLighting
	{
		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0002C64E File Offset: 0x0002A84E
		// (set) Token: 0x06000B73 RID: 2931 RVA: 0x0002C656 File Offset: 0x0002A856
		public LevelLayerLightingType Type { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x0002C65F File Offset: 0x0002A85F
		// (set) Token: 0x06000B75 RID: 2933 RVA: 0x0002C667 File Offset: 0x0002A867
		public double Light { get; set; }

		// Token: 0x06000B76 RID: 2934 RVA: 0x0002C670 File Offset: 0x0002A870
		public LevelLayerLighting()
		{
			this.Light = 1.0;
		}
	}
}
