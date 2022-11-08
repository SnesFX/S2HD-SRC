using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000C0 RID: 192
	[Flags]
	internal enum QueueStatusFlags
	{
		// Token: 0x0400057A RID: 1402
		KEY = 1,
		// Token: 0x0400057B RID: 1403
		MOUSEMOVE = 2,
		// Token: 0x0400057C RID: 1404
		MOUSEBUTTON = 4,
		// Token: 0x0400057D RID: 1405
		POSTMESSAGE = 8,
		// Token: 0x0400057E RID: 1406
		TIMER = 16,
		// Token: 0x0400057F RID: 1407
		PAINT = 32,
		// Token: 0x04000580 RID: 1408
		SENDMESSAGE = 64,
		// Token: 0x04000581 RID: 1409
		HOTKEY = 128,
		// Token: 0x04000582 RID: 1410
		ALLPOSTMESSAGE = 256,
		// Token: 0x04000583 RID: 1411
		RAWINPUT = 1024,
		// Token: 0x04000584 RID: 1412
		MOUSE = 6,
		// Token: 0x04000585 RID: 1413
		INPUT = 1031,
		// Token: 0x04000586 RID: 1414
		INPUT_LEGACY = 7,
		// Token: 0x04000587 RID: 1415
		ALLEVENTS = 1215,
		// Token: 0x04000588 RID: 1416
		ALLINPUT = 1279
	}
}
