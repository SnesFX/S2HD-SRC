using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000124 RID: 292
	internal enum WindowState
	{
		// Token: 0x04000A38 RID: 2616
		Sticky = 1,
		// Token: 0x04000A39 RID: 2617
		Minimized,
		// Token: 0x04000A3A RID: 2618
		MaximizedVertically = 4,
		// Token: 0x04000A3B RID: 2619
		MaximizedHorizontally = 8,
		// Token: 0x04000A3C RID: 2620
		Hidden = 16,
		// Token: 0x04000A3D RID: 2621
		Shaded = 32,
		// Token: 0x04000A3E RID: 2622
		HID_WORKSPACE = 64,
		// Token: 0x04000A3F RID: 2623
		HID_TRANSIENT = 128,
		// Token: 0x04000A40 RID: 2624
		FixedPosition = 256,
		// Token: 0x04000A41 RID: 2625
		ArrangeIgnore = 512
	}
}
