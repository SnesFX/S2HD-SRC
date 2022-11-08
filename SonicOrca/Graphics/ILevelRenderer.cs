using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000DF RID: 223
	public interface ILevelRenderer : IDisposable
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600078F RID: 1935
		string[] LastDebugLog { get; }

		// Token: 0x06000790 RID: 1936
		Task LoadAsync(CancellationToken ct = default(CancellationToken));

		// Token: 0x06000791 RID: 1937
		void Initialise();

		// Token: 0x06000792 RID: 1938
		void Render(Renderer renderer, Viewport viewport, LayerViewOptions layerViewOptions);

		// Token: 0x06000793 RID: 1939
		void RenderToClipboard(Viewport viewport, LayerViewOptions layerViewOptions);
	}
}
