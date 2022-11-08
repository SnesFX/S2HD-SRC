using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B9D RID: 2973
	[Flags]
	internal enum InputFlags
	{
		// Token: 0x0400B91A RID: 47386
		IGNBRK = 1,
		// Token: 0x0400B91B RID: 47387
		BRKINT = 2,
		// Token: 0x0400B91C RID: 47388
		IGNPAR = 4,
		// Token: 0x0400B91D RID: 47389
		PARMRK = 8,
		// Token: 0x0400B91E RID: 47390
		INPCK = 16,
		// Token: 0x0400B91F RID: 47391
		ISTRIP = 32,
		// Token: 0x0400B920 RID: 47392
		INLCR = 64,
		// Token: 0x0400B921 RID: 47393
		IGNCR = 128,
		// Token: 0x0400B922 RID: 47394
		ICRNL = 256,
		// Token: 0x0400B923 RID: 47395
		IUCLC = 512,
		// Token: 0x0400B924 RID: 47396
		IXON = 1024,
		// Token: 0x0400B925 RID: 47397
		IXANY = 2048,
		// Token: 0x0400B926 RID: 47398
		IXOFF = 4096,
		// Token: 0x0400B927 RID: 47399
		IMAXBEL = 8192,
		// Token: 0x0400B928 RID: 47400
		IUTF8 = 16384
	}
}
