using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200010E RID: 270
	public interface ILevelTitleCard : IDisposable
	{
		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060009EE RID: 2542
		bool AllowLevelToStart { get; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060009EF RID: 2543
		bool AllowCharacterControl { get; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060009F0 RID: 2544
		bool Finished { get; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060009F1 RID: 2545
		// (set) Token: 0x060009F2 RID: 2546
		bool Seamless { get; set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060009F3 RID: 2547
		// (set) Token: 0x060009F4 RID: 2548
		bool UnlockCamera { get; set; }

		// Token: 0x060009F5 RID: 2549
		Task LoadAsync(ResourceTree resourceTree, CancellationToken ct = default(CancellationToken));

		// Token: 0x060009F6 RID: 2550
		void Update();

		// Token: 0x060009F7 RID: 2551
		void Draw(Renderer renderer);

		// Token: 0x060009F8 RID: 2552
		void Start();
	}
}
