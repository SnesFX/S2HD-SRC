using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B2B RID: 2859
	[Flags]
	internal enum NSTrackingAreaOptions
	{
		// Token: 0x0400B5D8 RID: 46552
		MouseEnteredAndExited = 1,
		// Token: 0x0400B5D9 RID: 46553
		MouseMoved = 2,
		// Token: 0x0400B5DA RID: 46554
		CursorUpdate = 4,
		// Token: 0x0400B5DB RID: 46555
		ActiveWhenFirstResponder = 16,
		// Token: 0x0400B5DC RID: 46556
		ActiveInKeyWindow = 32,
		// Token: 0x0400B5DD RID: 46557
		ActiveInActiveApp = 64,
		// Token: 0x0400B5DE RID: 46558
		ActiveAlways = 128,
		// Token: 0x0400B5DF RID: 46559
		AssumeInside = 256,
		// Token: 0x0400B5E0 RID: 46560
		InVisibleRect = 512,
		// Token: 0x0400B5E1 RID: 46561
		EnabledDuringMouseDrag = 1024
	}
}
