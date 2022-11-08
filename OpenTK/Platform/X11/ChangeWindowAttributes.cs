using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000168 RID: 360
	[Flags]
	internal enum ChangeWindowAttributes
	{
		// Token: 0x04000EE1 RID: 3809
		X = 1,
		// Token: 0x04000EE2 RID: 3810
		Y = 2,
		// Token: 0x04000EE3 RID: 3811
		Width = 4,
		// Token: 0x04000EE4 RID: 3812
		Height = 8,
		// Token: 0x04000EE5 RID: 3813
		BorderWidth = 16,
		// Token: 0x04000EE6 RID: 3814
		Sibling = 32,
		// Token: 0x04000EE7 RID: 3815
		StackMode = 64,
		// Token: 0x04000EE8 RID: 3816
		OverrideRedirect = 512
	}
}
