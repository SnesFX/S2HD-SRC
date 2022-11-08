using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200019C RID: 412
	internal enum XIEventType
	{
		// Token: 0x04001106 RID: 4358
		DeviceChanged = 1,
		// Token: 0x04001107 RID: 4359
		KeyPress,
		// Token: 0x04001108 RID: 4360
		KeyRelease,
		// Token: 0x04001109 RID: 4361
		ButtonPress,
		// Token: 0x0400110A RID: 4362
		ButtonRelease,
		// Token: 0x0400110B RID: 4363
		Motion,
		// Token: 0x0400110C RID: 4364
		Enter,
		// Token: 0x0400110D RID: 4365
		Leave,
		// Token: 0x0400110E RID: 4366
		FocusIn,
		// Token: 0x0400110F RID: 4367
		FocusOut,
		// Token: 0x04001110 RID: 4368
		HierarchyChanged,
		// Token: 0x04001111 RID: 4369
		PropertyEvent,
		// Token: 0x04001112 RID: 4370
		RawKeyPress,
		// Token: 0x04001113 RID: 4371
		RawKeyRelease,
		// Token: 0x04001114 RID: 4372
		RawButtonPress,
		// Token: 0x04001115 RID: 4373
		RawButtonRelease,
		// Token: 0x04001116 RID: 4374
		RawMotion,
		// Token: 0x04001117 RID: 4375
		LastEvent = 17
	}
}
