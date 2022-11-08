using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000AE RID: 174
	internal interface IMenuViewPresenter
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000424 RID: 1060
		// (set) Token: 0x06000425 RID: 1061
		Rectanglei Bounds { get; set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000426 RID: 1062
		// (remove) Token: 0x06000427 RID: 1063
		event EventHandler NavigateBack;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000428 RID: 1064
		// (remove) Token: 0x06000429 RID: 1065
		event EventHandler<NavigateNextEventArgs> NavigateNext;

		// Token: 0x0600042A RID: 1066
		void Update();

		// Token: 0x0600042B RID: 1067
		void HandleInput();

		// Token: 0x0600042C RID: 1068
		void Draw(Renderer renderer);
	}
}
