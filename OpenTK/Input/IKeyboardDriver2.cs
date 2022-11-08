using System;

namespace OpenTK.Input
{
	// Token: 0x0200000C RID: 12
	internal interface IKeyboardDriver2
	{
		// Token: 0x0600003D RID: 61
		KeyboardState GetState();

		// Token: 0x0600003E RID: 62
		KeyboardState GetState(int index);

		// Token: 0x0600003F RID: 63
		string GetDeviceName(int index);
	}
}
