using System;

namespace OpenTK.Input
{
	// Token: 0x02000B03 RID: 2819
	internal class GamePadConfigurationItem
	{
		// Token: 0x0600598A RID: 22922 RVA: 0x000F3314 File Offset: 0x000F1514
		public GamePadConfigurationItem(GamePadConfigurationSource source, GamePadConfigurationTarget target)
		{
			this.Source = source;
			this.Target = target;
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x0600598B RID: 22923 RVA: 0x000F332C File Offset: 0x000F152C
		// (set) Token: 0x0600598C RID: 22924 RVA: 0x000F3334 File Offset: 0x000F1534
		public GamePadConfigurationSource Source
		{
			get
			{
				return this.source;
			}
			private set
			{
				this.source = value;
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x0600598D RID: 22925 RVA: 0x000F3340 File Offset: 0x000F1540
		// (set) Token: 0x0600598E RID: 22926 RVA: 0x000F3348 File Offset: 0x000F1548
		public GamePadConfigurationTarget Target
		{
			get
			{
				return this.target;
			}
			private set
			{
				this.target = value;
			}
		}

		// Token: 0x0400B4C6 RID: 46278
		private GamePadConfigurationSource source;

		// Token: 0x0400B4C7 RID: 46279
		private GamePadConfigurationTarget target;
	}
}
