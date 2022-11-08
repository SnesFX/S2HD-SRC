using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B86 RID: 2950
	internal struct JoystickEvent
	{
		// Token: 0x0400B8C4 RID: 47300
		public uint Time;

		// Token: 0x0400B8C5 RID: 47301
		public short Value;

		// Token: 0x0400B8C6 RID: 47302
		public JoystickEventType Type;

		// Token: 0x0400B8C7 RID: 47303
		public byte Number;
	}
}
