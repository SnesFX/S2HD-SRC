using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200018C RID: 396
	internal enum XEmbedMessage
	{
		// Token: 0x0400109E RID: 4254
		EmbeddedNotify,
		// Token: 0x0400109F RID: 4255
		WindowActivate,
		// Token: 0x040010A0 RID: 4256
		WindowDeactivate,
		// Token: 0x040010A1 RID: 4257
		RequestFocus,
		// Token: 0x040010A2 RID: 4258
		FocusIn,
		// Token: 0x040010A3 RID: 4259
		FocusOut,
		// Token: 0x040010A4 RID: 4260
		FocusNext,
		// Token: 0x040010A5 RID: 4261
		FocusPrev,
		// Token: 0x040010A6 RID: 4262
		ModalityOn = 10,
		// Token: 0x040010A7 RID: 4263
		ModalityOff,
		// Token: 0x040010A8 RID: 4264
		RegisterAccelerator,
		// Token: 0x040010A9 RID: 4265
		UnregisterAccelerator,
		// Token: 0x040010AA RID: 4266
		ActivateAccelerator
	}
}
