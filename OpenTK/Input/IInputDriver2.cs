using System;

namespace OpenTK.Input
{
	// Token: 0x0200000A RID: 10
	internal interface IInputDriver2 : IDisposable
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000036 RID: 54
		IMouseDriver2 MouseDriver { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000037 RID: 55
		IKeyboardDriver2 KeyboardDriver { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000038 RID: 56
		IGamePadDriver GamePadDriver { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000039 RID: 57
		IJoystickDriver2 JoystickDriver { get; }
	}
}
