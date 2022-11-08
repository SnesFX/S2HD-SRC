using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B9E RID: 2974
	[Flags]
	internal enum OutputFlags
	{
		// Token: 0x0400B92A RID: 47402
		OPOST = 2,
		// Token: 0x0400B92B RID: 47403
		OLCUC = 4,
		// Token: 0x0400B92C RID: 47404
		ONLCR = 8,
		// Token: 0x0400B92D RID: 47405
		OCRNL = 16,
		// Token: 0x0400B92E RID: 47406
		ONOCR = 32,
		// Token: 0x0400B92F RID: 47407
		ONLRET = 64,
		// Token: 0x0400B930 RID: 47408
		OFILL = 128,
		// Token: 0x0400B931 RID: 47409
		OFDEL = 256
	}
}
