using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200018A RID: 394
	[Flags]
	internal enum XIMProperties
	{
		// Token: 0x04001090 RID: 4240
		XIMPreeditArea = 1,
		// Token: 0x04001091 RID: 4241
		XIMPreeditCallbacks = 2,
		// Token: 0x04001092 RID: 4242
		XIMPreeditPosition = 4,
		// Token: 0x04001093 RID: 4243
		XIMPreeditNothing = 8,
		// Token: 0x04001094 RID: 4244
		XIMPreeditNone = 16,
		// Token: 0x04001095 RID: 4245
		XIMStatusArea = 256,
		// Token: 0x04001096 RID: 4246
		XIMStatusCallbacks = 512,
		// Token: 0x04001097 RID: 4247
		XIMStatusNothing = 1024,
		// Token: 0x04001098 RID: 4248
		XIMStatusNone = 2048
	}
}
