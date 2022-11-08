using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000121 RID: 289
	[Flags]
	internal enum MotifInputMode
	{
		// Token: 0x04000A16 RID: 2582
		Modeless = 0,
		// Token: 0x04000A17 RID: 2583
		ApplicationModal = 1,
		// Token: 0x04000A18 RID: 2584
		SystemModal = 2,
		// Token: 0x04000A19 RID: 2585
		FullApplicationModal = 3
	}
}
