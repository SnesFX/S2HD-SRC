using System;

namespace SonicOrca.Resources
{
	// Token: 0x02000004 RID: 4
	public interface ILoadedResource : IDisposable
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9
		// (set) Token: 0x0600000A RID: 10
		Resource Resource { get; set; }

		// Token: 0x0600000B RID: 11
		void OnLoaded();
	}
}
