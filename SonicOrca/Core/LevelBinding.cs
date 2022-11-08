using System;
using System.Collections.Generic;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000126 RID: 294
	public class LevelBinding : ILoadedResource, IDisposable
	{
		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x0002C7C6 File Offset: 0x0002A9C6
		// (set) Token: 0x06000B87 RID: 2951 RVA: 0x0002C7CE File Offset: 0x0002A9CE
		public Resource Resource { get; set; }

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x0002C7D7 File Offset: 0x0002A9D7
		public IList<ObjectPlacement> ObjectPlacements
		{
			get
			{
				return this._objectPlacements;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x0002C7DF File Offset: 0x0002A9DF
		// (set) Token: 0x06000B8A RID: 2954 RVA: 0x0002C7E7 File Offset: 0x0002A9E7
		public Level Level { get; set; }

		// Token: 0x06000B8C RID: 2956 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x040006A5 RID: 1701
		private readonly List<ObjectPlacement> _objectPlacements = new List<ObjectPlacement>();
	}
}
