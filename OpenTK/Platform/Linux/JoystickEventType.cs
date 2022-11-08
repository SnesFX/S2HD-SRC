using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B81 RID: 2945
	[Flags]
	internal enum JoystickEventType : byte
	{
		// Token: 0x0400B8A8 RID: 47272
		Button = 1,
		// Token: 0x0400B8A9 RID: 47273
		Axis = 2,
		// Token: 0x0400B8AA RID: 47274
		Init = 128
	}
}
