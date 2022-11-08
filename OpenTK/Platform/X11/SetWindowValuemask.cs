using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200015E RID: 350
	[Flags]
	internal enum SetWindowValuemask
	{
		// Token: 0x04000E19 RID: 3609
		Nothing = 0,
		// Token: 0x04000E1A RID: 3610
		BackPixmap = 1,
		// Token: 0x04000E1B RID: 3611
		BackPixel = 2,
		// Token: 0x04000E1C RID: 3612
		BorderPixmap = 4,
		// Token: 0x04000E1D RID: 3613
		BorderPixel = 8,
		// Token: 0x04000E1E RID: 3614
		BitGravity = 16,
		// Token: 0x04000E1F RID: 3615
		WinGravity = 32,
		// Token: 0x04000E20 RID: 3616
		BackingStore = 64,
		// Token: 0x04000E21 RID: 3617
		BackingPlanes = 128,
		// Token: 0x04000E22 RID: 3618
		BackingPixel = 256,
		// Token: 0x04000E23 RID: 3619
		OverrideRedirect = 512,
		// Token: 0x04000E24 RID: 3620
		SaveUnder = 1024,
		// Token: 0x04000E25 RID: 3621
		EventMask = 2048,
		// Token: 0x04000E26 RID: 3622
		DontPropagate = 4096,
		// Token: 0x04000E27 RID: 3623
		ColorMap = 8192,
		// Token: 0x04000E28 RID: 3624
		Cursor = 16384
	}
}
