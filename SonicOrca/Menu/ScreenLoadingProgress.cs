using System;

namespace SonicOrca.Menu
{
	// Token: 0x020000A9 RID: 169
	public class ScreenLoadingProgress
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0001B96A File Offset: 0x00019B6A
		public Screen Screen
		{
			get
			{
				return this._screen;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0001B972 File Offset: 0x00019B72
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0001B97A File Offset: 0x00019B7A
		public int MinimumValue { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0001B983 File Offset: 0x00019B83
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001B98B File Offset: 0x00019B8B
		public int MaximumValue { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001B994 File Offset: 0x00019B94
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0001B99C File Offset: 0x00019B9C
		public int CurrentValue { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001B9A5 File Offset: 0x00019BA5
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001B9AD File Offset: 0x00019BAD
		public string Status { get; set; }

		// Token: 0x0600059E RID: 1438 RVA: 0x0001B9B6 File Offset: 0x00019BB6
		public ScreenLoadingProgress(Screen screen)
		{
			this._screen = screen;
		}

		// Token: 0x04000347 RID: 839
		private readonly Screen _screen;
	}
}
