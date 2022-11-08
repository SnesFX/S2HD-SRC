using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200012D RID: 301
	internal enum EventMode
	{
		// Token: 0x04000BEA RID: 3050
		AsyncPointer,
		// Token: 0x04000BEB RID: 3051
		SyncPointer,
		// Token: 0x04000BEC RID: 3052
		ReplayPointer,
		// Token: 0x04000BED RID: 3053
		AsyncKeyboard,
		// Token: 0x04000BEE RID: 3054
		SyncKeyboard,
		// Token: 0x04000BEF RID: 3055
		ReplayKeyboard,
		// Token: 0x04000BF0 RID: 3056
		AsyncBoth,
		// Token: 0x04000BF1 RID: 3057
		SyncBoth
	}
}
