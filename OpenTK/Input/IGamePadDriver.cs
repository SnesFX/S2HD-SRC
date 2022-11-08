using System;

namespace OpenTK.Input
{
	// Token: 0x02000009 RID: 9
	internal interface IGamePadDriver
	{
		// Token: 0x06000032 RID: 50
		GamePadState GetState(int index);

		// Token: 0x06000033 RID: 51
		GamePadCapabilities GetCapabilities(int index);

		// Token: 0x06000034 RID: 52
		string GetName(int index);

		// Token: 0x06000035 RID: 53
		bool SetVibration(int index, float left, float right);
	}
}
