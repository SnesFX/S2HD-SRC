using System;

namespace OpenTK.Input
{
	// Token: 0x0200000B RID: 11
	internal interface IJoystickDriver2
	{
		// Token: 0x0600003A RID: 58
		JoystickState GetState(int index);

		// Token: 0x0600003B RID: 59
		JoystickCapabilities GetCapabilities(int index);

		// Token: 0x0600003C RID: 60
		Guid GetGuid(int index);
	}
}
