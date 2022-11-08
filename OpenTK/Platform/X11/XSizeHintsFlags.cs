using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000182 RID: 386
	[Flags]
	internal enum XSizeHintsFlags
	{
		// Token: 0x04000FDB RID: 4059
		USPosition = 1,
		// Token: 0x04000FDC RID: 4060
		USSize = 2,
		// Token: 0x04000FDD RID: 4061
		PPosition = 4,
		// Token: 0x04000FDE RID: 4062
		PSize = 8,
		// Token: 0x04000FDF RID: 4063
		PMinSize = 16,
		// Token: 0x04000FE0 RID: 4064
		PMaxSize = 32,
		// Token: 0x04000FE1 RID: 4065
		PResizeInc = 64,
		// Token: 0x04000FE2 RID: 4066
		PAspect = 128,
		// Token: 0x04000FE3 RID: 4067
		PAllHints = 252,
		// Token: 0x04000FE4 RID: 4068
		PBaseSize = 256,
		// Token: 0x04000FE5 RID: 4069
		PWinGravity = 512
	}
}
