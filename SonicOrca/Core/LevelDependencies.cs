using System;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200011B RID: 283
	public class LevelDependencies : ILoadedResource, IDisposable
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0002961D File Offset: 0x0002781D
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x00029625 File Offset: 0x00027825
		public Resource Resource { get; set; }

		// Token: 0x06000A8D RID: 2701 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}
	}
}
