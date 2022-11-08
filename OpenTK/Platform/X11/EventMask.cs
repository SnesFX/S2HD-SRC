using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000162 RID: 354
	[Flags]
	public enum EventMask
	{
		// Token: 0x04000E58 RID: 3672
		NoEventMask = 0,
		// Token: 0x04000E59 RID: 3673
		KeyPressMask = 1,
		// Token: 0x04000E5A RID: 3674
		KeyReleaseMask = 2,
		// Token: 0x04000E5B RID: 3675
		ButtonPressMask = 4,
		// Token: 0x04000E5C RID: 3676
		ButtonReleaseMask = 8,
		// Token: 0x04000E5D RID: 3677
		EnterWindowMask = 16,
		// Token: 0x04000E5E RID: 3678
		LeaveWindowMask = 32,
		// Token: 0x04000E5F RID: 3679
		PointerMotionMask = 64,
		// Token: 0x04000E60 RID: 3680
		PointerMotionHintMask = 128,
		// Token: 0x04000E61 RID: 3681
		Button1MotionMask = 256,
		// Token: 0x04000E62 RID: 3682
		Button2MotionMask = 512,
		// Token: 0x04000E63 RID: 3683
		Button3MotionMask = 1024,
		// Token: 0x04000E64 RID: 3684
		Button4MotionMask = 2048,
		// Token: 0x04000E65 RID: 3685
		Button5MotionMask = 4096,
		// Token: 0x04000E66 RID: 3686
		ButtonMotionMask = 8192,
		// Token: 0x04000E67 RID: 3687
		KeymapStateMask = 16384,
		// Token: 0x04000E68 RID: 3688
		ExposureMask = 32768,
		// Token: 0x04000E69 RID: 3689
		VisibilityChangeMask = 65536,
		// Token: 0x04000E6A RID: 3690
		StructureNotifyMask = 131072,
		// Token: 0x04000E6B RID: 3691
		ResizeRedirectMask = 262144,
		// Token: 0x04000E6C RID: 3692
		SubstructureNotifyMask = 524288,
		// Token: 0x04000E6D RID: 3693
		SubstructureRedirectMask = 1048576,
		// Token: 0x04000E6E RID: 3694
		FocusChangeMask = 2097152,
		// Token: 0x04000E6F RID: 3695
		PropertyChangeMask = 4194304,
		// Token: 0x04000E70 RID: 3696
		ColormapChangeMask = 8388608,
		// Token: 0x04000E71 RID: 3697
		OwnerGrabButtonMask = 16777216
	}
}
