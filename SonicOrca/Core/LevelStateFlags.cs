using System;

namespace SonicOrca.Core
{
	// Token: 0x0200012E RID: 302
	[Flags]
	public enum LevelStateFlags
	{
		// Token: 0x040006D0 RID: 1744
		Animating = 2,
		// Token: 0x040006D1 RID: 1745
		Updating = 4,
		// Token: 0x040006D2 RID: 1746
		AllowCharacterControl = 8,
		// Token: 0x040006D3 RID: 1747
		FadingIn = 16,
		// Token: 0x040006D4 RID: 1748
		FadingOut = 32,
		// Token: 0x040006D5 RID: 1749
		CompletingStage = 64,
		// Token: 0x040006D6 RID: 1750
		Restarting = 128,
		// Token: 0x040006D7 RID: 1751
		UpdateTime = 256,
		// Token: 0x040006D8 RID: 1752
		TitleCardActive = 512,
		// Token: 0x040006D9 RID: 1753
		Editing = 1024,
		// Token: 0x040006DA RID: 1754
		Dead = 2048,
		// Token: 0x040006DB RID: 1755
		StageCompleted = 4096,
		// Token: 0x040006DC RID: 1756
		TimeOver = 8192,
		// Token: 0x040006DD RID: 1757
		GameOver = 16384,
		// Token: 0x040006DE RID: 1758
		TimeUp = 32768,
		// Token: 0x040006DF RID: 1759
		Paused = 65536,
		// Token: 0x040006E0 RID: 1760
		WaitingForCharacterToWin = 131072
	}
}
