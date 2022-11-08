using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200011F RID: 287
	[Flags]
	internal enum MotifFunctions
	{
		// Token: 0x04000A07 RID: 2567
		All = 1,
		// Token: 0x04000A08 RID: 2568
		Resize = 2,
		// Token: 0x04000A09 RID: 2569
		Move = 4,
		// Token: 0x04000A0A RID: 2570
		Minimize = 8,
		// Token: 0x04000A0B RID: 2571
		Maximize = 16,
		// Token: 0x04000A0C RID: 2572
		Close = 32
	}
}
