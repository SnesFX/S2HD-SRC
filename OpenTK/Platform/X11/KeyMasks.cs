using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200016E RID: 366
	[Flags]
	internal enum KeyMasks
	{
		// Token: 0x04000F08 RID: 3848
		ShiftMask = 1,
		// Token: 0x04000F09 RID: 3849
		LockMask = 2,
		// Token: 0x04000F0A RID: 3850
		ControlMask = 4,
		// Token: 0x04000F0B RID: 3851
		Mod1Mask = 8,
		// Token: 0x04000F0C RID: 3852
		Mod2Mask = 16,
		// Token: 0x04000F0D RID: 3853
		Mod3Mask = 32,
		// Token: 0x04000F0E RID: 3854
		Mod4Mask = 64,
		// Token: 0x04000F0F RID: 3855
		Mod5Mask = 128,
		// Token: 0x04000F10 RID: 3856
		ModMasks = 248
	}
}
