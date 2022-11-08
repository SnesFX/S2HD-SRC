using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B32 RID: 2866
	[Flags]
	internal enum MacOSKeyModifiers
	{
		// Token: 0x0400B665 RID: 46693
		None = 0,
		// Token: 0x0400B666 RID: 46694
		Shift = 512,
		// Token: 0x0400B667 RID: 46695
		CapsLock = 1024,
		// Token: 0x0400B668 RID: 46696
		Control = 4096,
		// Token: 0x0400B669 RID: 46697
		Command = 256,
		// Token: 0x0400B66A RID: 46698
		Option = 2048
	}
}
