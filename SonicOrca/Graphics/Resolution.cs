using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000B7 RID: 183
	public struct Resolution
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0001CC15 File Offset: 0x0001AE15
		public int Width { get; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x0001CC1D File Offset: 0x0001AE1D
		public int Height { get; }

		// Token: 0x06000625 RID: 1573 RVA: 0x0001CC25 File Offset: 0x0001AE25
		public Resolution(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001CC35 File Offset: 0x0001AE35
		public override string ToString()
		{
			return string.Format("{0} x {1}", this.Width, this.Height);
		}
	}
}
