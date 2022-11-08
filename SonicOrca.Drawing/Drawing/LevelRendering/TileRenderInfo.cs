using System;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x0200001C RID: 28
	internal struct TileRenderInfo
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000178 RID: 376 RVA: 0x0000853D File Offset: 0x0000673D
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00008545 File Offset: 0x00006745
		public LevelLayer Layer { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600017A RID: 378 RVA: 0x0000854E File Offset: 0x0000674E
		// (set) Token: 0x0600017B RID: 379 RVA: 0x00008556 File Offset: 0x00006756
		public int TileIndex { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600017C RID: 380 RVA: 0x0000855F File Offset: 0x0000675F
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00008567 File Offset: 0x00006767
		public Rectanglei Source { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00008570 File Offset: 0x00006770
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00008578 File Offset: 0x00006778
		public Rectanglei Destination { get; set; }
	}
}
