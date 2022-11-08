using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000DE RID: 222
	public interface IFadeTransitionRenderer : IDisposable
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600078B RID: 1931
		// (set) Token: 0x0600078C RID: 1932
		float Opacity { get; set; }

		// Token: 0x0600078D RID: 1933
		void Render();

		// Token: 0x0600078E RID: 1934
		void Render(IFramebuffer sourceFramebuffer, IFramebuffer destFramebuffer);
	}
}
