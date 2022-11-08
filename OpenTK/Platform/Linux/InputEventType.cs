using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B90 RID: 2960
	internal enum InputEventType
	{
		// Token: 0x0400B8E4 RID: 47332
		None,
		// Token: 0x0400B8E5 RID: 47333
		DeviceAdded,
		// Token: 0x0400B8E6 RID: 47334
		DeviceRemoved,
		// Token: 0x0400B8E7 RID: 47335
		KeyboardKey = 300,
		// Token: 0x0400B8E8 RID: 47336
		PointerMotion = 400,
		// Token: 0x0400B8E9 RID: 47337
		PointerMotionAbsolute,
		// Token: 0x0400B8EA RID: 47338
		PointerButton,
		// Token: 0x0400B8EB RID: 47339
		PointerAxis,
		// Token: 0x0400B8EC RID: 47340
		TouchDown = 500,
		// Token: 0x0400B8ED RID: 47341
		TouchUP,
		// Token: 0x0400B8EE RID: 47342
		TouchMotion,
		// Token: 0x0400B8EF RID: 47343
		TouchCancel,
		// Token: 0x0400B8F0 RID: 47344
		TouchFrame
	}
}
