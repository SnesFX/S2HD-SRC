using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B89 RID: 2953
	[Flags]
	internal enum PollFlags : short
	{
		// Token: 0x0400B8D4 RID: 47316
		In = 1,
		// Token: 0x0400B8D5 RID: 47317
		Pri = 2,
		// Token: 0x0400B8D6 RID: 47318
		Out = 4,
		// Token: 0x0400B8D7 RID: 47319
		Error = 8,
		// Token: 0x0400B8D8 RID: 47320
		Hup = 16,
		// Token: 0x0400B8D9 RID: 47321
		Invalid = 32
	}
}
