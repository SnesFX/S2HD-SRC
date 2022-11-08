using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B2C RID: 2860
	internal enum NSApplicationPresentationOptions
	{
		// Token: 0x0400B5E3 RID: 46563
		Default,
		// Token: 0x0400B5E4 RID: 46564
		AutoHideDock,
		// Token: 0x0400B5E5 RID: 46565
		HideDock,
		// Token: 0x0400B5E6 RID: 46566
		AutoHideMenuBar = 4,
		// Token: 0x0400B5E7 RID: 46567
		HideMenuBar = 8,
		// Token: 0x0400B5E8 RID: 46568
		DisableAppleMenu = 16,
		// Token: 0x0400B5E9 RID: 46569
		DisableProcessSwitching = 32,
		// Token: 0x0400B5EA RID: 46570
		DisableForceQuit = 64,
		// Token: 0x0400B5EB RID: 46571
		DisableSessionTermination = 128,
		// Token: 0x0400B5EC RID: 46572
		DisableHideApplication = 256,
		// Token: 0x0400B5ED RID: 46573
		DisableMenuBarTransparency = 512,
		// Token: 0x0400B5EE RID: 46574
		FullScreen = 1024,
		// Token: 0x0400B5EF RID: 46575
		AutoHideToolbar = 2048
	}
}
