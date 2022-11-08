using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000AF7 RID: 2807
	[Flags]
	internal enum SymbolLookupFlags
	{
		// Token: 0x0400B48C RID: 46220
		Bind = 0,
		// Token: 0x0400B48D RID: 46221
		BindNow = 1,
		// Token: 0x0400B48E RID: 46222
		BindFully = 2,
		// Token: 0x0400B48F RID: 46223
		ReturnOnError = 4
	}
}
