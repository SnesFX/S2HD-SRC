using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B7F RID: 2943
	[Flags]
	internal enum OpenFlags
	{
		// Token: 0x0400B8A0 RID: 47264
		ReadOnly = 0,
		// Token: 0x0400B8A1 RID: 47265
		WriteOnly = 1,
		// Token: 0x0400B8A2 RID: 47266
		ReadWrite = 2,
		// Token: 0x0400B8A3 RID: 47267
		NonBlock = 2048,
		// Token: 0x0400B8A4 RID: 47268
		CloseOnExec = 524288
	}
}
